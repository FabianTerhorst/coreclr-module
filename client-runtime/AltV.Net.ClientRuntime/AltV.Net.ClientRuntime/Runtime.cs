using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.Loader;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.IO;
using Unbreakable;
using Unbreakable.Policy;
using Unbreakable.Policy.Rewriters;

//TODO: move default api policies to this file as well instead of unknown use
namespace AltV.Net.ClientRuntime
{
    using static ApiAccess;

    public static class Runtime
    {
        private class IsolatedAssemblyLoadContext : AssemblyLoadContext, IDisposable
        {
            private readonly Func<AssemblyName, bool> _shouldShareAssembly;

            public IsolatedAssemblyLoadContext(Func<AssemblyName, bool> shouldShareAssembly)
                : base(isCollectible: true)
            {
                _shouldShareAssembly = shouldShareAssembly;
            }

            public IsolatedAssemblyLoadContext()
                : base(isCollectible: true)
            {
                _shouldShareAssembly = _ => false;
            }

            protected override Assembly Load(AssemblyName assemblyName)
            {
                Console.WriteLine(assemblyName);
                if (assemblyName.Name == "Unbreakable.Runtime")
                {
                    return Assembly.Load("Unbreakable.Runtime");
                }

                if (assemblyName.Name == "netstandard" || assemblyName.Name == "mscorlib" ||
                    assemblyName.Name.StartsWith("System.") || _shouldShareAssembly(assemblyName))
                    return Assembly.Load(assemblyName);

                return null; //LoadFromAssemblyPath(Path.Combine(AppContext.BaseDirectory, assemblyName.Name + ".dll"));
            }

            public void Dispose()
            {
                Unload();
            }
        }

        private static readonly List<MetadataReference> MetadataReferences = new List<MetadataReference>
        {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location),
            //MetadataReference.CreateFromFile(typeof(File).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
            MetadataReference.CreateFromFile(Assembly.Load("System.Runtime").Location)
        };

        private static readonly RecyclableMemoryStreamManager MemoryStreamManager = new RecyclableMemoryStreamManager();

        public static string Execute(string code)
        {
            try
            {
                //CSharpRoslynGuard.Validate(code);
                var compilation = CSharpCompilation.Create(
                    "_",
                    new[] {CSharpSyntaxTree.ParseText(code)},
                    MetadataReferences,
                    new CSharpCompilationOptions(outputKind: OutputKind.DynamicallyLinkedLibrary, allowUnsafe: false)
                );
                using var assemblyStream = MemoryStreamManager.GetStream();
                using var rewrittenStream = MemoryStreamManager.GetStream();
                var compilationResult = compilation.Emit(assemblyStream);
                if (!compilationResult.Success)
                    return string.Join("\r\n", compilationResult.Diagnostics);
                assemblyStream.Seek(0, SeekOrigin.Begin);
                var guardToken = Rewrite(assemblyStream, rewrittenStream);
                rewrittenStream.Seek(0, SeekOrigin.Begin);

                var appDomain = AppDomain.CurrentDomain;
                appDomain.PermissionSet.RemovePermission(typeof(FileIOPermission));
                appDomain.PermissionSet.RemovePermission(typeof(SecurityPermission));
                appDomain.PermissionSet.RemovePermission(typeof(ReflectionPermission));
                appDomain.PermissionSet.SetPermission(new FileIOPermission(FileIOPermissionAccess.NoAccess,
                    new string[0]));
                appDomain.PermissionSet.SetPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
                appDomain.PermissionSet.SetPermission(
                    new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess));

                using var context = new IsolatedAssemblyLoadContext();
                var assembly = context.LoadFromStream(rewrittenStream);
                var type = assembly.GetType("Program", true);
                var method = type.GetMethod("Run",
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                if (method == null)
                    throw new NotSupportedException("Static method 'Run' not found on type 'Program'.");
                using (guardToken.Scope())
                {
                    var result = method.Invoke(null, null);
                    if (result?.GetType().Assembly == assembly ||
                        (result is MemberInfo m && m.Module.Assembly == assembly))
                        throw new Exception("Result returned by Program.Run must not belong to the user assembly.");
                    return result?.ToString();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        public static RuntimeGuardToken Rewrite(Stream source, Stream target)
        {
            return AssemblyGuard.Rewrite(source, target, CreateGuardSettings());
        }

        public static AssemblyGuardSettings CreateGuardSettings()
        {
            var settings = AssemblyGuardSettings.DefaultForCSharpAssembly();
            settings.ApiPolicy = CreatePolicy();
            settings.AllowExplicitLayoutInTypesMatchingPattern =
                new Regex(settings.AllowExplicitLayoutInTypesMatchingPattern.ToString(), RegexOptions.Compiled);
            settings.AllowPointerOperationsInTypesMatchingPattern =
                new Regex(settings.AllowPointerOperationsInTypesMatchingPattern.ToString(), RegexOptions.Compiled);
            return settings;
        }

        public static ApiPolicy CreatePolicy() => ApiPolicy.SafeDefault()
            .Namespace("System", Neutral, SetupSystem)
            .Namespace("System.Threading", Neutral, SetupThreading)
            .Namespace("System.Collections.Concurrent", Neutral, SetupSystemCollectionsConcurrent)
            .Namespace("System.Collections.Specialized", Neutral, SetupSystemCollectionsSpecialized)
            //.Namespace("System.Globalization", Neutral, SetupSystemGlobalization)
            //.Namespace("System.IO", Neutral, SetupSystemIO)
            //.Namespace("System.Linq.Expressions", Neutral, SetupSystemLinqExpressions)
            //.Namespace("System.Net", Neutral, SetupSystemNet)
            .Namespace("System.Numerics", Neutral, SetupSystemNumerics);
        //.Namespace("System.Runtime.InteropServices", Neutral, SetupSystemRuntimeInteropServices)
        //.Namespace("System.Web", Neutral, SetupSystemWeb);

        private static void SetupSystem(NamespacePolicy namespacePolicy)
        {
            namespacePolicy
                .Type(typeof(Console), Neutral,
                    t => t.Member(nameof(Console.WriteLine), Allowed)
                )
                .Type(typeof(NotImplementedException), Neutral, t => t.Constructor(Allowed))
                .Type(typeof(Type), Neutral, SetupSystemType);
        }

        private static void SetupThreading(NamespacePolicy namespacePolicy)
        {
            namespacePolicy
                .Type(typeof(Thread), Neutral, t =>
                    t
                        .Member("get_Name", Allowed)
                        .Member(nameof(Thread.Priority), Allowed)
                        //.Member(nameof(Thread.CurrentCulture), Allowed)
                        //.Member(nameof(Thread.CurrentPrincipal), Allowed)
                        .Member("get_CurrentThread", Allowed)//TODO: not sure
                        //.Member(nameof(Thread.ExecutionContext), Allowed)
                        .Member(nameof(Thread.IsAlive), Allowed)
                        .Member(nameof(Thread.IsBackground), Allowed)
                        .Member(nameof(Thread.ThreadState), Allowed)
                        //.Member(nameof(Thread.ManagedThreadId), Allowed)
                        //.Member(nameof(Thread.CurrentUICulture), Allowed)
                        //.Member(nameof(Thread.IsThreadPoolThread), Allowed)
                        .Member(nameof(Thread.Abort), Allowed)
                        .Member(nameof(Thread.Equals), Allowed)
                        .Member(nameof(Thread.Interrupt), Allowed)
                        .Member(nameof(Thread.Join), Allowed)
                        .Member(nameof(Thread.Sleep), Allowed)
                        .Member(nameof(Thread.Start), Allowed)
                        .Member(nameof(Thread.Yield), Allowed)
                        //Some not accepted between
                        .Member(nameof(Thread.SpinWait), Allowed)
                );
        }

        private static void SetupSystemType(TypePolicy typePolicy)
        {
            typePolicy
                .Getter(nameof(Type.AssemblyQualifiedName), Allowed)
                .Getter(nameof(Type.IsGenericType), Allowed)
                .Getter(nameof(Type.IsConstructedGenericType), Allowed)
                .Getter(nameof(Type.IsGenericTypeDefinition), Allowed)
                .Getter(nameof(Type.ContainsGenericParameters), Allowed)
                .Member(nameof(Type.GetGenericTypeDefinition), Allowed)
                .Member(nameof(Type.GetConstructor), Allowed)
                .Member(nameof(Type.GetEvent), Allowed)
                .Member(nameof(Type.GetField), Allowed)
                .Member(nameof(Type.GetInterface), Allowed)
                .Member(nameof(Type.GetMethod), Allowed)
                .Member(nameof(Type.GetProperty), Allowed);
        }

        private static void SetupSystemCollectionsConcurrent(NamespacePolicy namespacePolicy)
        {
            namespacePolicy.Type(typeof(ConcurrentDictionary<,>), Allowed,
                t => t.Constructor(Allowed, CountArgumentRewriter.ForCapacity)
                    .Member(nameof(ConcurrentDictionary<object, object>.AddOrUpdate), Allowed, AddCallRewriter.Default)
                    .Member(nameof(ConcurrentDictionary<object, object>.GetOrAdd), Allowed, AddCallRewriter.Default)
                    .Member(nameof(ConcurrentDictionary<object, object>.TryAdd), Allowed, AddCallRewriter.Default)
            );
        }

        private static void SetupSystemCollectionsSpecialized(NamespacePolicy namespacePolicy)
        {
            namespacePolicy.Type(typeof(NameValueCollection), Allowed,
                t => t.Constructor(Allowed, CountArgumentRewriter.ForCapacity)
                    .Member(nameof(NameValueCollection.Add), Allowed, AddCallRewriter.Default)
                    .Member(nameof(NameValueCollection.Set), Allowed, AddCallRewriter.Default)
                    .Member("set_Item", Allowed, AddCallRewriter.Default)
            );
        }

        /*private static void SetupSystemGlobalization(NamespacePolicy namespacePolicy)
        {
            namespacePolicy
                .Type(typeof(CultureInfo), Neutral, typePolicy =>
                {
                    typePolicy.Constructor(Allowed)
                        .Member(nameof(CultureInfo.GetCultureInfo), Allowed)
                        .Member(nameof(CultureInfo.GetCultureInfoByIetfLanguageTag), Allowed);
                    foreach (var property in typeof(CultureInfo).GetProperties())
                    {
                        typePolicy.Getter(property.Name, Allowed);
                    }
                });
        }*/

        /*private static void SetupSystemIO(NamespacePolicy namespacePolicy)
        {
            namespacePolicy
                .Type(typeof(TextWriter), Neutral)
                .Type(typeof(TextReader), Neutral,
                    t => t.Member(nameof(TextReader.Dispose), Allowed)
                        .Member(nameof(TextReader.Close), Allowed)
                        .Member(nameof(TextReader.Peek), Allowed)
                        .Member(nameof(TextReader.ReadBlock), Allowed)
                )
                .Type(typeof(StringReader), Neutral,
                    t => t.Constructor(Allowed)
                        .Member(nameof(StringReader.Close), Allowed)
                        .Member(nameof(StringReader.Peek), Allowed)
                        .Member(nameof(StringReader.Read), Allowed)
                );
        }*/

        /*private static void SetupSystemLinqExpressions(NamespacePolicy namespacePolicy)
        {
            ForEachTypeInNamespaceOf<Expression>(type =>
            {
                if (type.IsEnum)
                {
                    namespacePolicy.Type(type, Allowed);
                    return;
                }

                if (!type.GetTypeInfo().IsSameAsOrSubclassOf<Expression>())
                    return;

                namespacePolicy.Type(type, Allowed, typePolicy =>
                {
                    foreach (var method in type.GetMethods())
                    {
                        if (method.Name.Contains("Compile"))
                            typePolicy.Member(method.Name, Denied);
                    }
                });
            });
        }*/

        /*private static void SetupSystemNet(NamespacePolicy namespacePolicy)
        {
            namespacePolicy
                .Type(typeof(IPAddress), Allowed);
        }*/

        private static void SetupSystemNumerics(NamespacePolicy namespacePolicy)
        {
            namespacePolicy
                .Type(typeof(Complex), Allowed);
        }

        /*private static void SetupSystemRuntimeInteropServices(NamespacePolicy namespacePolicy)
        {
            namespacePolicy
                .Type(typeof(Marshal), Neutral,
                    t => t.Member(nameof(Marshal.SizeOf), Allowed)
                );
        }*/

        /*private static void SetupSystemWeb(NamespacePolicy namespacePolicy)
        {
            namespacePolicy
                .Type(typeof(HttpUtility), Neutral,
                    t => t.Member(nameof(HttpUtility.HtmlDecode), Allowed)
                        .Member(nameof(HttpUtility.HtmlEncode), Allowed)
                        .Member(nameof(HttpUtility.UrlDecode), Allowed)
                        .Member(nameof(HttpUtility.UrlEncode), Allowed)
                        .Member(nameof(HttpUtility.HtmlAttributeEncode), Allowed)
                        .Member(nameof(HttpUtility.JavaScriptStringEncode), Allowed)
                        .Member(nameof(HttpUtility.ParseQueryString), Allowed)
                );
        }*/

        private static void ForEachTypeInNamespaceOf<T>(Action<Type> action)
        {
            var types = typeof(T).Assembly.GetExportedTypes();
            foreach (var type in types)
            {
                if (type.Namespace != typeof(T).Namespace)
                    continue;

                action(type);
            }
        }

        public static bool IsSameAsOrSubclassOf(this Type type, Type otherType)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (otherType == null) throw new ArgumentNullException(nameof(otherType));

            return type == otherType || type.IsSubclassOf(otherType);
        }

        public static bool IsSameAsOrSubclassOf<TClass>(this Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return type.IsSameAsOrSubclassOf(typeof(TClass));
        }
    }
}