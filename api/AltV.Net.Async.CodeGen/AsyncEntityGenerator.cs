using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace AltV.Net.Async.CodeGen
{
    internal class SyntaxTreeReceiver : ISyntaxReceiver
    {
        public readonly List<ClassDeclarationSyntax> Classes = new();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax classSyntax &&
                classSyntax.AttributeLists.Any(l =>
                    l.Attributes.Any(a => a.Name.ToString() is "AsyncEntity" or "AsyncEntityAttribute")))
            {
                Classes.Add(classSyntax);
            }
        }
    }

    [Generator]
    public class AsyncEntityGenerator : ISourceGenerator
    {
        private static string Indent(string text, int n = 1)
        {
            return string.Join("\n", text.Split('\n').Select(s => new string(' ', n * 4) + s));
        }

        private static string FormatAttributes(IEnumerable<AttributeData> attributes)
        {
            return string.Join(" ", attributes.Select(a => $"[{a}]"));
        }

        private const string AttributeText = @"
using System;
namespace AltV.Net.Async.CodeGen {
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    sealed class AsyncEntityAttribute : Attribute
    {
        public AsyncEntityAttribute(Type interfaceType)
        {
        }
    }
}";

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SyntaxTreeReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var receiver = (SyntaxTreeReceiver) context.SyntaxReceiver!;

            var sourceBuilder = new StringBuilder(AttributeText);

            var options = (CSharpParseOptions) ((CSharpCompilation) context.Compilation).SyntaxTrees[0].Options;
            Compilation compilation =
                context.Compilation.AddSyntaxTrees(
                    CSharpSyntaxTree.ParseText(SourceText.From(AttributeText, Encoding.UTF8), options));

            var attributeSymbol = compilation.GetTypeByMetadataName("AltV.Net.Async.CodeGen.AsyncEntityAttribute");

            foreach (var classSyntax in receiver.Classes)
            {
                var @class = compilation.GetSemanticModel(classSyntax.SyntaxTree).GetDeclaredSymbol(classSyntax)!;

                if (!classSyntax.Modifiers.Any(SyntaxKind.PartialKeyword))
                {
                    context.ReportDiagnostic(Diagnostic.Create(Diagnostics.AsyncEntityClassShouldBePartial,
                        @class.Locations.FirstOrDefault(), @class.ToString()));
                    continue;
                }

                var attribute = @class.GetAttributes().FirstOrDefault(a =>
                    a.AttributeClass?.Equals(attributeSymbol, SymbolEqualityComparer.Default) == true);
                if (attribute is null || attribute.ConstructorArguments.Length != 1)
                    continue; // that's some other async entity decorator, skipping

                var @interface = (INamedTypeSymbol?) attribute.ConstructorArguments[0].Value;
                if (@interface is null || !@class.Interfaces.Contains(@interface, SymbolEqualityComparer.Default))
                {
                    context.ReportDiagnostic(Diagnostic.Create(Diagnostics.AsyncEntityShouldImplementInterface,
                        @class.Locations.FirstOrDefault(), @class.ToString(), @interface?.ToString() ?? ""));
                    continue;
                }

                if (@interface.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax() is InterfaceDeclarationSyntax
                    interfaceSyntax && !interfaceSyntax.Modifiers.Any(SyntaxKind.PartialKeyword))
                {
                    context.ReportDiagnostic(Diagnostic.Create(Diagnostics.AsyncEntityInterfaceShouldBePartial,
                        @interface.Locations.FirstOrDefault(), @interface.ToString()));
                    continue;
                }

                var baseType = @class.BaseType;
                if (baseType is null || !baseType.ToString().StartsWith("AltV.Net.Elements.Entities."))
                {
                    context.ReportDiagnostic(Diagnostic.Create(Diagnostics.AsyncEntityShouldImplementEntity,
                        @class.Locations.FirstOrDefault(), @class.ToString()));
                    continue;
                }

                var members = new List<string>();

                var interfaceMembers = @interface.GetMembers();
                var classMembers = @class.GetMembers();

                foreach (var member in interfaceMembers)
                {
                    var classMember = classMembers.FirstOrDefault(m => m.Name == member.Name);
                    
                    // does member hide base class property (new keyword)
                    var isNew = classMember?.DeclaringSyntaxReferences.Any(s =>
                        s.GetSyntax() is MemberDeclarationSyntax declarationSyntax &&
                        declarationSyntax.Modifiers.Any(SyntaxKind.NewKeyword)) ?? false;

                    switch (member)
                    {
                        case IPropertySymbol property:
                        {
                            if (classMember is not IPropertySymbol classProperty)
                            {
                                context.ReportDiagnostic(Diagnostic.Create(
                                    Diagnostics.AsyncEntityInterfacePropertyNotFoundInClass,
                                    member.Locations.FirstOrDefault(), member.Name, @interface.ToString(),
                                    @class.ToString()));
                                continue;
                            }

                            if (property.GetMethod is not null &&
                                classProperty.GetMethod?.DeclaredAccessibility != Accessibility.Public)
                            {
                                context.ReportDiagnostic(Diagnostic.Create(Diagnostics.AsyncEntityGetterNotFound,
                                    member.Locations.FirstOrDefault(), member.Name, @interface.ToString(),
                                    @class.ToString()));
                                continue;
                            }

                            if (property.SetMethod is not null &&
                                classProperty.SetMethod?.DeclaredAccessibility != Accessibility.Public)
                            {
                                context.ReportDiagnostic(Diagnostic.Create(Diagnostics.AsyncEntitySetterNotFound,
                                    member.Locations.FirstOrDefault(), member.Name, @interface.ToString(),
                                    @class.ToString()));
                                continue;
                            }

                            if (property.GetMethod is not null || property.SetMethod is not null)
                            {
                                var propertyValue = "";
                                if (property.GetMethod is not null)
                                    propertyValue += $"get => BaseObject.{member.Name}; ";
                                if (property.SetMethod is not null)
                                    propertyValue += $"set => BaseObject.{member.Name} = value; ";

                                var attributes = classProperty.GetAttributes();
                                var formattedAttributes =
                                    attributes.Length == 0 ? "" : FormatAttributes(attributes) + "\n";
                                var @new = isNew ? "new " : "";
                                
                                members.Add(formattedAttributes +
                                            $"public {@new}{property.Type} {member.Name} {{ {propertyValue}}}");
                            }

                            break;
                        }

                        case IMethodSymbol {MethodKind: MethodKind.Ordinary}:
                        {
                            if (classMember is not IMethodSymbol
                            {
                                DeclaredAccessibility: Accessibility.Public
                            } classMethod)
                            {
                                context.ReportDiagnostic(Diagnostic.Create(
                                    Diagnostics.AsyncEntityInterfaceMethodNotFoundInClass,
                                    member.Locations.FirstOrDefault(), member.Name, @interface.ToString(),
                                    @class.ToString()));
                                continue;
                            }

                            // arguments to arguments list
                            var argumentsList = new string[classMethod.Parameters.Length];
                            // arguments to provide to call the base method
                            var callArgumentsList = new string[classMethod.Parameters.Length];

                            for (var index = 0; index < classMethod.Parameters.Length; index++)
                            {
                                var methodParameter = classMethod.Parameters[index];

                                var parameterAttrs = methodParameter.GetAttributes();
                                // ToString of methodParameter gives ref/out/in and type, without a name
                                argumentsList[index] =
                                    (parameterAttrs.Length == 0
                                        ? ""
                                        : FormatAttributes(methodParameter.GetAttributes()) + " ") + methodParameter +
                                    " " + methodParameter.Name;

                                var modifier = methodParameter.RefKind switch
                                {
                                    RefKind.Out => "out ",
                                    RefKind.Ref => "ref ",
                                    _ => ""
                                };
                                callArgumentsList[index] = modifier + methodParameter.Name;
                            }

                            var arguments = string.Join(", ", argumentsList);
                            var callArguments = string.Join(", ", callArgumentsList);
                            var returnAction = classMethod.ReturnsVoid ? "" : "return ";
                            var name = member.Name;

                            var attributes = classMethod.GetAttributes();
                            var formattedAttributes = attributes.Length == 0 ? "" : FormatAttributes(attributes) + "\n";
                            var @new = isNew ? "new " : "";
                            
                            members.Add(formattedAttributes +
                                        $"public {@new}{classMethod.ReturnType} {name}({arguments})\n{{\n    {returnAction}BaseObject.{name}({callArguments});\n}}");

                            break;
                        }
                    }
                }

                var asyncEntityType = "AltV.Net.Async.Elements.Entities.Async" + baseType.Name;

                var interfaceDeclaration =
                    $"public partial interface {@interface.Name} : AltV.Net.Async.IAsyncConvertible<{@interface.Name}> {{ }}";
                if (@interface.ContainingNamespace?.ToString() is { } interfaceNamespace)
                    interfaceDeclaration = $"namespace {interfaceNamespace} {{\n{Indent(interfaceDeclaration)}\n}}";

                var classDeclaration = $@"
public partial class {@class.Name} {{
    public {@interface} ToAsync(AltV.Net.Async.IAsyncContext asyncContext) {{
        return new Async(this, asyncContext);
    }}

    private class Async : {asyncEntityType}<{@interface}>, {@interface} {{
        public Async({@interface} player, AltV.Net.Async.IAsyncContext asyncContext) : base(player, asyncContext) {{ }}

        public {@interface} ToAsync(AltV.Net.Async.IAsyncContext asyncContext) {{
            return asyncContext == AsyncContext ? this : new Async(BaseObject, asyncContext);
        }}
        {Indent("\n" + string.Join("\n", members), 2)}
    }}
}}";
                if (@class.ContainingNamespace?.ToString() is { } classNamespace)
                    classDeclaration = $"\nnamespace {classNamespace} {{{Indent(classDeclaration)}\n}}";


                sourceBuilder.Append($"\n\n{interfaceDeclaration}\n{classDeclaration}");
            }

            context.AddSource("GeneratedAsyncEntities.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }
    }
}