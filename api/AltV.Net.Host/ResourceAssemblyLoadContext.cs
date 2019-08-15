using System;
using System.Reflection;
using System.Runtime.Loader;

namespace AltV.Net.Host
{
    public class ResourceAssemblyLoadContext : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver resolver;

        public ResourceAssemblyLoadContext(string resourcePath)
        {
            resolver = new AssemblyDependencyResolver(resourcePath);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            var assemblyPath = resolver.ResolveAssemblyToPath(assemblyName);
            return assemblyPath != null ? LoadFromAssemblyPath(assemblyPath) : null;
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            var libraryPath = resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            return libraryPath != null ? LoadUnmanagedDllFromPath(libraryPath) : IntPtr.Zero;
        }
    }
}