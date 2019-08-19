using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AltV.Net.Host
{
    public class Host
    {
        private static IDictionary<string, ResourceAssemblyLoadContext> _loadContexts =
            new Dictionary<string, ResourceAssemblyLoadContext>();

        /// <summary>
        /// Main is present to execute the dll as a assembly
        /// </summary>
        static void Main()
        {
            //TODO: init stuff we need
            Console.WriteLine("Init host");
        }

        private static string GetPath(string resourcePath, string resourceMain) =>
            $"{resourcePath}/{resourceMain}";

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

            var resourceDllPath = GetPath(resourcePath, resourceMain);
            var resourceAssemblyLoadContext =
                new ResourceAssemblyLoadContext(resourceDllPath, resourcePath, resourceName);

            Assembly resourceAssembly;

            try
            {
                resourceAssembly = resourceAssemblyLoadContext.LoadFromAssemblyPath(resourceDllPath);
            }
            catch (FileLoadException e)
            {
                Console.WriteLine($"Threw a exception while loading the assembly \"{resourceDllPath}\": {e}");
                resourceAssembly = null;
            }

            var altVNetAssembly = resourceAssemblyLoadContext.LoadFromAssemblyName(new AssemblyName("AltV.Net"));
            foreach (var type in altVNetAssembly.GetTypes())
            {
                if (type.Name == "ModuleWrapper")
                {
                    type.GetMethod("MainWithAssembly", BindingFlags.Public | BindingFlags.Static)?.Invoke(null,
                        new object[] {libArgs.ServerPointer, libArgs.ResourcePointer, resourceAssemblyLoadContext});
                }
            }

            _loadContexts[resourceDllPath] = resourceAssemblyLoadContext;

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

            var resourceDllPath = GetPath(resourcePath, resourceMain);

            if (!_loadContexts.Remove(resourceDllPath, out var loadContext)) return 1;
            var altVNetAssembly = loadContext.LoadFromAssemblyName(new AssemblyName("AltV.Net"));
            foreach (var type in altVNetAssembly.GetTypes())
            {
                if (type.Name == "ModuleWrapper")
                {
                    type.GetMethod("AssemblyUnload", BindingFlags.Public | BindingFlags.Static)?.Invoke(null,
                        new object[] { });
                }
            }

            loadContext.Unload();
            return 0;
        }
    }
}