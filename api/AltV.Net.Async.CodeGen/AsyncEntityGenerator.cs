using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace AltV.Net.Async.CodeGen
{
    internal static class TypeSymbolExtensions
    {
        internal static string GetGlobalName(this ITypeSymbol symbol)
        {
            return symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
        }
    }
    
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
            return string.Join(" ", attributes.Select(a => $"[global::{a}]"));
        }

        private const string AttributeText = @"
using System;
using AltV.Net.Async;

namespace AltV.Net.Async.CodeGen {
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    sealed class AsyncEntityAttribute : Attribute
    {
        public AsyncEntityAttribute(Type interfaceType)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false)]
    sealed class AsyncPropertyAttribute : Attribute
    {
        public bool ThreadSafe { get; set; } = false;
        public AsyncPropertyAttribute()
        {
        }
    }
}";

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SyntaxTreeReceiver());
        }

        private static IList<INamedTypeSymbol> GetBaseTypes(INamedTypeSymbol @class)
        {
            var list = new List<INamedTypeSymbol>();
            var currentClass = @class;

            while (currentClass.BaseType is { } type)
            {
                list.Add(type);
                currentClass = type;
            }

            return list;
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
            var propertyAttributeSymbol =
                compilation.GetTypeByMetadataName("AltV.Net.Async.CodeGen.AsyncPropertyAttribute");

            var validClasses = new List<INamedTypeSymbol>();

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

                if (baseType is not null)
                    while (!baseType!.ToString().StartsWith("AltV.Net.Elements.Entities."))
                        baseType = baseType.BaseType;

                if (baseType is null)
                {
                    context.ReportDiagnostic(Diagnostic.Create(Diagnostics.AsyncEntityShouldImplementEntity,
                        @class.Locations.FirstOrDefault(), @class.ToString()));
                    continue;
                }

                validClasses.Add(@class);

                var classBaseDeclaration = @class.BaseType!.ToString().StartsWith("AltV.Net.Elements.Entities.")
                    ? ""
                    : " : " + @class.BaseType;

                var members = new List<string>();

                foreach (var member in @interface.GetMembers())
                {
                    var classMember = @class.FindImplementationForInterfaceMember(member);

                    // does member hide base class property (new keyword)
                    var isNew = classMember?.DeclaringSyntaxReferences.Any(s =>
                        s.GetSyntax() is MemberDeclarationSyntax declarationSyntax &&
                        declarationSyntax.Modifiers.Any(SyntaxKind.NewKeyword)) ?? false;

                    var propertyAttribute = classMember?.GetAttributes().FirstOrDefault(a =>
                        a.AttributeClass?.Equals(propertyAttributeSymbol, SymbolEqualityComparer.Default) == true);

                    var propertySettings = propertyAttribute?.NamedArguments
                                               .ToDictionary(e => e.Key, e => e.Value) ??
                                           new Dictionary<string, TypedConstant>();

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
                                var getter = $"=> CustomBaseObject.{member.Name}; ";
                                var setter = $"=> CustomBaseObject.{member.Name} = value; ";

                                if (propertySettings.TryGetValue("ThreadSafe", out var threadSafe) &&
                                    threadSafe.ToCSharpString() == "true")
                                {
                                    getter = $"{{ lock (CustomBaseObject) return AsyncContext.CheckIfExistsNullable(CustomBaseObject) ? CustomBaseObject.{member.Name} : default; }}";
                                    setter = $"{{ lock (CustomBaseObject) if (AsyncContext.CheckIfExistsNullable(CustomBaseObject)) CustomBaseObject.{member.Name} = value; }}";
                                }

                                var propertyValue = "";
                                if (property.GetMethod is not null)
                                    propertyValue += $"\n    get {getter} ";
                                if (property.SetMethod is not null && !property.SetMethod.IsInitOnly)
                                    propertyValue += $"\n    set {setter} ";
                                else if (property.SetMethod is not null)
                                    propertyValue +=
                                        @$"init => throw new global::System.MemberAccessException(""Manual construction of Async class is prohibited. Property {property.Name} is marked as init-only and therefore cannot be set on the async entity.""); ";

                                var attributes = classProperty.GetAttributes().Where(a => !a.Equals(propertyAttribute)).ToArray();
                                var formattedAttributes =
                                    attributes.Length == 0 ? "" : FormatAttributes(attributes) + "\n";
                                var @new = isNew ? "new " : "";

                                var newline = property.GetMethod is not null && property.SetMethod is not null
                                    ? "\n"
                                    : "";
                                members.Add(formattedAttributes +
                                            $"public {@new}{property.Type.GetGlobalName()} {member.Name} {{ {propertyValue}{newline}}}");
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

                                var modifier = methodParameter.RefKind switch
                                {
                                    RefKind.Out => "out ",
                                    RefKind.Ref => "ref ",
                                    RefKind.In => "in ",
                                    _ => ""
                                };
                                
                                argumentsList[index] =
                                    (parameterAttrs.Length == 0
                                        ? ""
                                        : FormatAttributes(methodParameter.GetAttributes()) + " ") + modifier + methodParameter.Type.GetGlobalName() +
                                    " " + methodParameter.Name;
                                callArgumentsList[index] = modifier + methodParameter.Name;
                            }

                            var constraintClauses = "";
                            foreach (var typeParameter in classMethod.TypeParameters)
                            {
                                var constraintDeclarations = new List<string>();
                                if (typeParameter.HasReferenceTypeConstraint) constraintDeclarations.Add("class");
                                if (typeParameter.HasValueTypeConstraint) constraintDeclarations.Add("struct");
                                if (typeParameter.HasUnmanagedTypeConstraint) constraintDeclarations.Add("unmanaged");
                                if (typeParameter.HasNotNullConstraint) constraintDeclarations.Add("notnull");
                                constraintDeclarations.AddRange(typeParameter.ConstraintTypes.Select(e => e.GetGlobalName()));
                                if (typeParameter.HasConstructorConstraint) constraintDeclarations.Add("new()");
                                
                                if (constraintDeclarations.Count == 0) continue;
                                constraintClauses +=
                                    $"where {typeParameter.Name} : {string.Join(", ", constraintDeclarations)} ";
                            }

                            var genericTypes = "";
                            if (classMethod.TypeParameters.Length > 0)
                            {
                                genericTypes = "<" + string.Join(", ", classMethod.TypeParameters.Select(t => t.ToString())) + ">";
                            }

                            var arguments = string.Join(", ", argumentsList);
                            var callArguments = string.Join(", ", callArgumentsList);
                            var returnAction = classMethod.ReturnsVoid ? "" : "return ";
                            var name = member.Name;

                            var attributes = classMethod.GetAttributes().Where(a => !a.Equals(propertyAttribute)).ToArray();
                            var formattedAttributes = attributes.Length == 0 ? "" : FormatAttributes(attributes) + "\n";
                            var @new = isNew ? "new " : "";

                            var methodCall = $"CustomBaseObject.{name}{genericTypes}({callArguments})";
                            var methodValue = "";

                            if (propertySettings.TryGetValue("ThreadSafe", out var threadSafe) &&
                                threadSafe.ToCSharpString() == "true")
                            {
                                if (classMethod.ReturnsVoid)
                                    methodValue =
                                        $"AsyncContext.RunOnMainThreadBlockingAndRunAll(() => {methodCall});";
                                else
                                    methodValue =
                                        $"{classMethod.ReturnType} res = default; AsyncContext.RunOnMainThreadBlockingAndRunAll(() => res = {methodCall}); return res;";
                            }
                            else
                            {
                                methodValue = $"{returnAction}{methodCall};";
                            }

                            members.Add(formattedAttributes +
                                        $"public {@new}{classMethod.ReturnType.GetGlobalName()} {name}{genericTypes}({arguments}) {constraintClauses}\n{{\n{Indent(methodValue)}\n}}");

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
public partial class {@class.Name}{classBaseDeclaration} {{
    public {@interface} ToAsync(AltV.Net.Async.IAsyncContext asyncContext) {{
        return new Async(this, asyncContext);
    }}

    public {@interface} ToAsync() {{
        return new Async(this, null);
    }} 

    private class Async : {asyncEntityType}, {@interface} {{
        public Async({@interface} player, AltV.Net.Async.IAsyncContext? asyncContext) : base(player, asyncContext) {{
            this.CustomBaseObject = player;
        }}

        private readonly {@interface} CustomBaseObject;

        public new {@interface} ToAsync(AltV.Net.Async.IAsyncContext asyncContext) {{
            return asyncContext == AsyncContext ? this : new Async(CustomBaseObject, asyncContext);
        }}

        public {@interface} ToAsync() {{
            return this;
        }}
        {Indent("\n" + string.Join("\n", members), 2)}
    }}
}}";
                if (@class.ContainingNamespace?.ToString() is { } classNamespace)
                    classDeclaration = $"\nnamespace {classNamespace} {{{Indent(classDeclaration)}\n}}";


                sourceBuilder.Append($"\n\n{interfaceDeclaration}\n{classDeclaration}");
            }

            foreach (var @class in validClasses)
            {
                var types = GetBaseTypes(@class);
                var invalid = types.FirstOrDefault(e => validClasses.Contains(e, SymbolEqualityComparer.Default));
                if (invalid is not { } invalidClass) continue;

                context.ReportDiagnostic(Diagnostic.Create(Diagnostics.AsyncEntityCannotBeNested,
                    @class.Locations.FirstOrDefault(), @class.ToString(), invalidClass.ToString()));
            }

            context.AddSource("GeneratedAsyncEntities.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }
    }
}
