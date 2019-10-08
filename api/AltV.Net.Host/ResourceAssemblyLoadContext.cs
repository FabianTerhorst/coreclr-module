using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace AltV.Net.Host
{
    public class ResourceAssemblyLoadContext : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver resolver;

        public ResourceAssemblyLoadContext(string resourceDllPath, string resourcePath, string resourceName) : base(resourceName,
            true)
        {
            resolver = new AssemblyDependencyResolver(resourceDllPath);
            Resolving += (context, assemblyName) =>
            {
                var dllPath = resourcePath + Path.DirectorySeparatorChar + assemblyName.Name;
                if (!File.Exists(dllPath)) return null;
                try
                {
                    return LoadFromAssemblyPath(dllPath);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                return null;
            };
            ResolvingUnmanagedDll += (assembly, unmanagedDllName) =>
            {
                var dllPath = resourcePath + Path.DirectorySeparatorChar + unmanagedDllName;
                if (!File.Exists(dllPath)) return IntPtr.Zero;
                try
                {
                    return LoadUnmanagedDllFromPath(dllPath);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                return IntPtr.Zero;
            };
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