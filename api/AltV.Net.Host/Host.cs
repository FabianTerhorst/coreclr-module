using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;
using Buildalyzer;
using Buildalyzer.Workspaces;
using Microsoft.CodeAnalysis;

namespace AltV.Net.Host
{
    public static class Host
    {
        private delegate bool ImportDelegate(string resourceName, string key, out object value);

        private static readonly IDictionary<string, AssemblyLoadContext> LoadContexts =
            new Dictionary<string, AssemblyLoadContext>();

        private static readonly IDictionary<string, IDictionary<string, object>> Exports =
            new Dictionary<string, IDictionary<string, object>>();

        private static readonly IDictionary<string, Action<long>> TraceSizeChangeDelegates =
            new Dictionary<string, Action<long>>();

        private const string DllName = "csharp-module";

        private const CallingConvention NativeCallingConvention = CallingConvention.Cdecl;

        private delegate int CoreClrDelegate(IntPtr args, int argsLength);

        [DllImport(DllName, CallingConvention = NativeCallingConvention)]
        private static extern void CoreClr_SetResourceLoadDelegates(CoreClrDelegate resourceExecute,
            CoreClrDelegate resourceExecuteUnload);

        private static CoreClrDelegate _executeResource;

        private static CoreClrDelegate _executeResourceUnload;

        /// <summary>
        /// Main is present to execute the dll as a assembly
        /// </summary>
        public static int Main(string[] args)
        {
            var semaphore = new Semaphore(0, 1);
            SetDelegates();
            semaphore.WaitOne();
            return 0;
        }

        public static int Main2(IntPtr arg, int argLength)
        {
            SetDelegates();
            return 0;
        }

        private static void SetDelegates()
        {
            _executeResource = ExecuteResource;
            GCHandle.Alloc(_executeResource);
            _executeResourceUnload = ExecuteResourceUnload;
            GCHandle.Alloc(_executeResourceUnload);
            CoreClr_SetResourceLoadDelegates(_executeResource, _executeResourceUnload);
        }

        private static string GetPath(string resourcePath, string resourceMain) =>
            $"{resourcePath}{Path.DirectorySeparatorChar}{resourceMain}";

        [StructLayout(LayoutKind.Sequential)]
        public struct LibArgs
        {
            public IntPtr ResourcePath;
            public IntPtr ResourceName;
            public IntPtr ResourceMain;
            public IntPtr ServerPointer;
            public IntPtr ResourcePointer;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct UnloadArgs
        {
            public IntPtr ResourcePath;
            public IntPtr ResourceMain;
        }

        public static int ExecuteResource(IntPtr arg, int argLength)
        {
            if (argLength < Marshal.SizeOf(typeof(LibArgs)))
            {
                return 1;
            }

            var libArgs = Marshal.PtrToStructure<LibArgs>(arg);
            var resourcePath = Marshal.PtrToStringUTF8(libArgs.ResourcePath);
            var resourceName = Marshal.PtrToStringUTF8(libArgs.ResourceName);
            var resourceMain = Marshal.PtrToStringUTF8(libArgs.ResourceMain);

            string resourceDllPath;

            if (resourceMain.EndsWith(".csproj"))
            {
                Func<AssemblyLoadContext, AssemblyName, Assembly> resolving = (context, assemblyName) =>
                {
                    var dllPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "runtime" +
                                  Path.DirectorySeparatorChar + assemblyName.Name + ".dll";
                    if (File.Exists(dllPath))
                    {
                        try
                        {
                            return context.LoadFromAssemblyPath(dllPath);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception);
                        }
                    }

                    dllPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + assemblyName.Name +
                              ".dll";


                    if (File.Exists(dllPath))
                    {
                        try
                        {
                            return context.LoadFromAssemblyPath(dllPath);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception);
                        }
                    }

                    return null;
                };
                AssemblyLoadContext.Default.Resolving += resolving;
                var task = Task.Run(
                    async () => await CompileResource(resourceName, GetPath(resourcePath, resourceMain)));
                var (result, dllPath) = task.GetAwaiter().GetResult();
                AssemblyLoadContext.Default.Resolving -= resolving;
                if (!result)
                {
                    Console.WriteLine($"Compilation of resource {resourceName} wasn't successfully.");
                }

                resourceDllPath = dllPath;
            }
            else
            {
                resourceDllPath = GetPath(resourcePath, resourceMain);
            }

            var resourceAssemblyLoadContext =
                new ResourceAssemblyLoadContext(resourceDllPath, resourcePath, resourceName);

            LoadContexts[resourceDllPath] = resourceAssemblyLoadContext;

            resourceAssemblyLoadContext.SharedAssemblyNames.UnionWith(GetResourceSharedAssemblies(resourceDllPath));

            try
            {
                resourceAssemblyLoadContext.LoadFromAssemblyPath(resourceDllPath);
                var newList = new HashSet<string>();
                foreach (var referencedAssembly in resourceAssemblyLoadContext.SharedAssemblyNames)
                {
                    var refAssembly =
                        AssemblyLoadContext.Default.LoadFromAssemblyPath(GetPath(resourcePath,
                            referencedAssembly + ".dll"));
                    foreach (var referencedAssembly2 in refAssembly.GetReferencedAssemblies())
                    {
                        newList.Add(referencedAssembly2.Name);
                    }
                }

                resourceAssemblyLoadContext.SharedAssemblyNames.UnionWith(newList);
            }
            catch (FileLoadException e)
            {
                Console.WriteLine($"Threw a exception while loading the assembly \"{resourceDllPath}\": {e}");
                return 1;
            }

            var isDefaultLoaded = false;
            var isShared = resourceAssemblyLoadContext.SharedAssemblyNames.Contains("AltV.Net");
            foreach (var assembly in AssemblyLoadContext.Default.Assemblies)
            {
                if (assembly.GetName().Name != "AltV.Net") continue;
                isDefaultLoaded = true;
                break;
            }

            if (!isDefaultLoaded && isShared)
            {
                var defaultAltVNetAssembly =
                    AssemblyLoadContext.Default.LoadFromAssemblyPath(GetPath(resourcePath, "AltV.Net.dll"));
                InitAltVAssembly(defaultAltVNetAssembly, libArgs, resourceAssemblyLoadContext, resourceName);
            }

            resourceAssemblyLoadContext.SharedAssemblyNames.Remove("AltV.Net");
            var altVNetAssembly = resourceAssemblyLoadContext.LoadFromAssemblyName(new AssemblyName("AltV.Net"));
            InitAltVAssembly(altVNetAssembly, libArgs, resourceAssemblyLoadContext, resourceName);
            if (isShared)
            {
                resourceAssemblyLoadContext.SharedAssemblyNames.Add("AltV.Net");
            }

            return 0;
        }

        public static int ExecuteResourceUnload(IntPtr arg, int argLength)
        {
            if (argLength < Marshal.SizeOf(typeof(UnloadArgs)))
            {
                return 1;
            }

            var libArgs = Marshal.PtrToStructure<UnloadArgs>(arg);
            var resourcePath = Marshal.PtrToStringUTF8(libArgs.ResourcePath);
            var resourceMain = Marshal.PtrToStringUTF8(libArgs.ResourceMain);
            AssemblyLoadContext loadContext;
            {
                var resourceDllPath = GetPath(resourcePath, resourceMain);
                if (!LoadContexts.Remove(resourceDllPath, out loadContext)) return 1;
                TraceSizeChangeDelegates.Remove(loadContext.Name);
                Exports.Remove(loadContext.Name);
                loadContext.Unload();
            }

            var weakLoadContext = new WeakReference(loadContext);

            if (weakLoadContext.IsAlive)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            if (weakLoadContext.IsAlive)
            {
                Console.WriteLine("Resource " + resourcePath + " leaked!");
            }

            return 0;
        }

        private static void InitAltVAssembly(Assembly altVNetAssembly, LibArgs libArgs,
            AssemblyLoadContext resourceAssemblyLoadContext, string resourceName)
        {
            foreach (var type in altVNetAssembly.GetTypes())
            {
                switch (type.Name)
                {
                    case "ModuleWrapper":
                        type.GetMethod("MainWithAssembly", BindingFlags.Public | BindingFlags.Static)?.Invoke(null,
                            new object[] {libArgs.ServerPointer, libArgs.ResourcePointer, resourceAssemblyLoadContext});
                        break;
                    case "HostWrapper":
                        try
                        {
                            type.GetMethod("SetStartTracingDelegate", BindingFlags.Public | BindingFlags.Static)
                                ?.Invoke(
                                    null,
                                    new object[] {new Action<string>(StartTracing)});
                            type.GetMethod("SetStopTracingDelegate", BindingFlags.Public | BindingFlags.Static)?.Invoke(
                                null,
                                new object[] {new Action(StopTracing)});
                            type.GetMethod("SetImportDelegate", BindingFlags.Public | BindingFlags.Static)?.Invoke(
                                null,
                                new object[] {new ImportDelegate(Import)});
                            type.GetMethod("SetExportDelegate", BindingFlags.Public | BindingFlags.Static)?.Invoke(
                                null,
                                new object[]
                                {
                                    new Action<string, object>((key, value) => { Export(resourceName, key, value); })
                                });
                            var traceSizeChangeDelegate = (Action<long>) type.GetMethod("GetTraceSizeChangeDelegate",
                                BindingFlags.Public | BindingFlags.Static)?.Invoke(
                                null,
                                new object[]
                                {
                                });
                            TraceSizeChangeDelegates[resourceName] = traceSizeChangeDelegate;
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(
                                "Consider updating the AltV.Net nuget package and AltV.Net.Host.dll to be able to access all csharp-module features.");
                            Console.WriteLine(exception);
                        }

                        break;
                }
            }
        }

        private static IEnumerable<string> GetResourceSharedAssemblies(string resourceDllPath)
        {
            try
            {
                using var stream = File.OpenRead(resourceDllPath);
                using var peFile = new PEReader(stream);
                var mdReader = peFile.GetMetadataReader();
                foreach (var attrHandle in mdReader.GetAssemblyDefinition().GetCustomAttributes())
                {
                    var attr = mdReader.GetCustomAttribute(attrHandle);
                    var attrCtor = mdReader.GetMemberReference((MemberReferenceHandle) attr.Constructor);
                    var attrType = mdReader.GetTypeReference((TypeReferenceHandle) attrCtor.Parent);
                    if (!mdReader.StringComparer.Equals(attrType.Name, "ResourceSharedAssembliesAttribute")) continue;
                    var valueReader = mdReader.GetBlobReader(attr.Value);
                    valueReader.Offset = 2;
                    var strCount = valueReader.ReadInt32();
                    valueReader.Offset = 6;
                    var sharedAssemblies = new string[strCount];
                    for (var i = 0; i < strCount; i++)
                    {
                        var strLen = valueReader.ReadCompressedInteger();
                        var sharedAssemblyName = valueReader.ReadUTF8(strLen);
                        sharedAssemblies[i] = sharedAssemblyName;
                    }

                    return sharedAssemblies;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return new string[] { };
        }

        public static async Task<(bool, string)> CompileResource(string resourceName, string resourceProjPath)
        {
            //TODO: need solution path as well for supporting solutions


            var manager = new AnalyzerManager();
            var analyzer = manager.GetProject(resourceProjPath);
            analyzer.SetGlobalProperty("Configuration", "Release");
            
            var buildEnvironment = analyzer.EnvironmentFactory.GetBuildEnvironment().WithTargetsToBuild("publish");
            var analyzerResults = analyzer.Build(buildEnvironment);
            
            var workspace = analyzer.GetWorkspace();
            
            workspace.ClearSolution();
            foreach (var analyzerResult in analyzerResults)
            {
                analyzerResult.AddToWorkspace(workspace);
            }

            var solution = workspace.CurrentSolution;
            var dependencyGraph = solution.GetProjectDependencyGraph();
            var projectIds = dependencyGraph.GetTopologicallySortedProjects();
            var success = true;
            string projectAssemblyDllPath = null;
            foreach (var projectId in projectIds)
            {
                var proj = solution.GetProject(projectId);
                Console.WriteLine($"Compiling {proj.Name}");
                var c = await proj
                    .GetCompilationAsync();

                var result = c.WithOptions(proj.CompilationOptions).AddReferences(proj.MetadataReferences)
                    .Emit(proj.OutputFilePath);
                Console.WriteLine($"Compiled {proj.AssemblyName}");
                foreach (var diagnostic in result.Diagnostics)
                {
                    Console.WriteLine(diagnostic.GetMessage());
                }

                if (!result.Success)
                {
                    success = false;
                }
                else if (proj.Name.Equals(resourceName) || projectAssemblyDllPath == null)
                {
                    projectAssemblyDllPath = proj.OutputFilePath;
                }
            }

            //var dependencyGraph = solution.GetProjectDependencyGraph();
            //GetTopologicallySortedProjects
            /*foreach (var proj in solution.Projects)
            {
                var c = await proj
                    .GetCompilationAsync(); //.WithOptions(proj.CompilationOptions).AddReferences(proj.MetadataReferences);

                var result = c.WithOptions(proj.CompilationOptions).AddReferences(proj.MetadataReferences)
                    .Emit(resourcePath + Path.DirectorySeparatorChar + proj.Name + ".dll");

                Console.WriteLine(result.Success);
            }*/

            return (success, projectAssemblyDllPath);
        }

        private static readonly object TracingMutex = new object();

        private static CollectTrace.Tracing _tracing;

        private static byte _tracingState;

        public static void StartTracing(string traceFileName)
        {
            lock (TracingMutex)
            {
                if (_tracing != null || _tracingState == 1) return;
                _tracing = new CollectTrace.Tracing();
            }

            Task.Run(async () => await CollectTrace.Collect(TraceSizeChangeDelegates.Values, _tracing,
                new FileInfo(traceFileName + ".nettrace")));

            lock (TracingMutex)
            {
                _tracingState = 1;
            }
        }

        public static void StopTracing()
        {
            lock (TracingMutex)
            {
                if (_tracing == null || _tracingState == 0) return;
                _tracing.Stop();
                _tracing = null;
                _tracingState = 0;
            }
        }

        public static bool Import(string resourceName, string key, out object value)
        {
            if (Exports.TryGetValue(resourceName, out var resourceExports))
                return resourceExports.TryGetValue(key, out value);
            value = null;
            return false;
        }

        public static void Export(string resourceName, string key, object value)
        {
            if (!Exports.TryGetValue(resourceName, out var resourceExports))
            {
                resourceExports = new Dictionary<string, object>();
                Exports[resourceName] = resourceExports;
            }

            resourceExports[key] = value;
        }
    }
}