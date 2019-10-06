﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;

//using Buildalyzer;
//using Buildalyzer.Workspaces;
//using Microsoft.CodeAnalysis;

namespace AltV.Net.Host
{
    public class Host
    {
        private delegate bool ImportDelegate(string resourceName, string key, out object value);

        private static readonly IDictionary<string, AssemblyLoadContext> _loadContexts =
            new Dictionary<string, AssemblyLoadContext>();

        private static readonly IDictionary<string, IDictionary<string, object>> _exports =
            new Dictionary<string, IDictionary<string, object>>();

        private static readonly IDictionary<string, Action<long>> _traceSizeChangeDelegates =
            new Dictionary<string, Action<long>>();

        private const string DllName = "csharp-module";
        private const CallingConvention NativeCallingConvention = CallingConvention.Cdecl;

        internal delegate int CoreClrDelegate(IntPtr args, int argsLength);

        [DllImport(DllName, CallingConvention = NativeCallingConvention)]
        internal static extern void CoreClr_SetResourceLoadDelegates(CoreClrDelegate resourceExecute,
            CoreClrDelegate resourceExecuteUnload);

        private static CoreClrDelegate _executeResource;

        private static CoreClrDelegate _executeResourceUnload;

        /// <summary>
        /// Main is present to execute the dll as a assembly
        /// </summary>
        static int Main(string[] args)
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

            var isCollectible = Environment.GetEnvironmentVariable("CSHARP_MODULE_DISABLE_COLLECTIBLE") == null;

            var resourceDllPath = GetPath(resourcePath, resourceMain);
            var resourceAssemblyLoadContext =
                new ResourceAssemblyLoadContext(resourceDllPath, resourcePath, resourceName, isCollectible);

            _loadContexts[resourceDllPath] = resourceAssemblyLoadContext;

            Assembly resourceAssembly;

            try
            {
                resourceAssembly = resourceAssemblyLoadContext.LoadFromAssemblyPath(resourceDllPath);
            }
            catch (FileLoadException e)
            {
                Console.WriteLine($"Threw a exception while loading the assembly \"{resourceDllPath}\": {e}");
                return 1;
            }

            var altVNetAssembly = resourceAssemblyLoadContext.LoadFromAssemblyName(new AssemblyName("AltV.Net"));
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
                            _traceSizeChangeDelegates[resourceName] = traceSizeChangeDelegate;
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
                if (!_loadContexts.Remove(resourceDllPath, out loadContext)) return 1;
                _traceSizeChangeDelegates.Remove(loadContext.Name);
                _exports.Remove(loadContext.Name);
                loadContext.Unload();
            }

            var weakLoadContext = new WeakReference(loadContext);
            loadContext = null;

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

        /*public static async void CompileResource()
        {
            var resourceProjPath = GetPath(resourcePath, resourceMain);
            var manager = new AnalyzerManager();
            var analyzer = manager.GetProject(resourceProjPath);
            var workspace = analyzer.GetWorkspace();
            var solution = workspace.CurrentSolution;
            //var dependencyGraph = solution.GetProjectDependencyGraph();
            //GetTopologicallySortedProjects
            foreach (var proj in solution.Projects)
            {
                var c = await proj.GetCompilationAsync(); .WithOptions(proj.CompilationOptions)
                    .AddReferences(proj.MetadataReferences);

                var result = c.Emit(proj.Name + ".dll");

                Console.WriteLine(result.Success);
            }
        }*/

        private static readonly object TracingMutex = new object();

        private static CollectTrace.Tracing _tracing;

        private static byte _tracingState = 0;

        public static void StartTracing(string traceFileName)
        {
            lock (TracingMutex)
            {
                if (_tracing != null || _tracingState == 1) return;
                _tracing = new CollectTrace.Tracing();
            }

            Task.Run(async () => await CollectTrace.Collect(_traceSizeChangeDelegates.Values, _tracing,
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
            if (_exports.TryGetValue(resourceName, out var resourceExports))
                return resourceExports.TryGetValue(key, out value);
            value = null;
            return false;
        }

        public static void Export(string resourceName, string key, object value)
        {
            if (!_exports.TryGetValue(resourceName, out var resourceExports))
            {
                resourceExports = new Dictionary<string, object>();
                _exports[resourceName] = resourceExports;
            }

            resourceExports[key] = value;
        }
    }
}