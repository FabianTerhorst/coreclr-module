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

        public ResourceAssemblyLoadContext(string resourcePath, string resourceName) : base(resourceName)
        {
            resolver = new AssemblyDependencyResolver(resourcePath);
            this.resourceName = resourceName;
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            var assemblyPath = resolver.ResolveAssemblyToPath(assemblyName);
            return assemblyPath != null ? LoadFromAssemblyPath(assemblyPath) : null;
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            var libraryPath = resolver.ResolveUnmanagedDllToPath(unmanagedDllName) ??
                              resolver.ResolveUnmanagedDllToPath(
                                  "resources" + Path.DirectorySeparatorChar + resourceName +
                                  Path.DirectorySeparatorChar + unmanagedDllName);

            return libraryPath != null ? LoadUnmanagedDllFromPath(libraryPath) : IntPtr.Zero;
        }
    }
}