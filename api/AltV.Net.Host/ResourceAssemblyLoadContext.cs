using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace AltV.Net.Host
{
    public class ResourceAssemblyLoadContext : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver resolver;

        private readonly string resourceName;

        private readonly string resourcePath;

        public ResourceAssemblyLoadContext(string resourceDllPath, string resourcePath, string resourceName) : base(resourceName,
            true)
        {
            resolver = new AssemblyDependencyResolver(resourceDllPath);
            this.resourceName = resourceName;
            this.resourcePath = resourcePath;
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            var assemblyPath = resolver.ResolveAssemblyToPath(assemblyName);
            return assemblyPath != null ? LoadFromAssemblyPath(assemblyPath) : null;
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            var libraryPath = resolver.ResolveUnmanagedDllToPath(unmanagedDllName);

            if (libraryPath == null)
            {
                var dllPath = resourcePath + Path.DirectorySeparatorChar + unmanagedDllName;
                if (File.Exists(dllPath))
                {
                    try
                    {
                        return LoadUnmanagedDllFromPath(dllPath);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }
                }
            }

            return libraryPath != null ? LoadUnmanagedDllFromPath(libraryPath) : IntPtr.Zero;
        }
    }
}