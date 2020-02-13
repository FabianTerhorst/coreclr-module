using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace AltV.Net.Host
{
    public class ResourceAssemblyLoadContext : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver resolver;
        public readonly HashSet<string> SharedAssemblyNames;

        public ResourceAssemblyLoadContext(string resourceDllPath, string resourcePath, string resourceName) : base(
            resourceName,
            Environment.GetEnvironmentVariable("CSHARP_MODULE_DISABLE_COLLECTIBLE") == null)
        {
            resolver = new AssemblyDependencyResolver(resourceDllPath);
            SharedAssemblyNames = new HashSet<string>();
            Resolving += (context, assemblyName) =>
            {
                var dllPath = resourcePath + Path.DirectorySeparatorChar + assemblyName.Name + ".dll";
                if (File.Exists(dllPath))
                {
                    try
                    {
                        return LoadFromAssemblyPath(dllPath);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }
                }

                dllPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "runtime" +
                          Path.DirectorySeparatorChar + assemblyName.Name + ".dll";
                if (File.Exists(dllPath))
                {
                    try
                    {
                        return LoadFromAssemblyPath(dllPath);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }
                }

                dllPath = Path.GetDirectoryName(resourceDllPath) + Path.DirectorySeparatorChar +
                          assemblyName.Name + ".dll";
                if (File.Exists(dllPath))
                {
                    try
                    {
                        return LoadFromAssemblyPath(dllPath);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }
                }

                dllPath = Path.GetDirectoryName(resourceDllPath) + Path.DirectorySeparatorChar + "publish" +
                          Path.DirectorySeparatorChar +
                          assemblyName.Name + ".dll";
                if (File.Exists(dllPath))
                {
                    try
                    {
                        return LoadFromAssemblyPath(dllPath);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }
                }

                return null;
            };
            ResolvingUnmanagedDll += (assembly, unmanagedDllName) =>
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

                dllPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "runtime" +
                          Path.DirectorySeparatorChar + unmanagedDllName;
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

                dllPath = Path.GetDirectoryName(resourceDllPath) + Path.DirectorySeparatorChar +
                          unmanagedDllName;
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

                dllPath = Path.GetDirectoryName(resourceDllPath) + Path.DirectorySeparatorChar + "publish" +
                          Path.DirectorySeparatorChar +
                          unmanagedDllName;
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

                return IntPtr.Zero;
            };
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            if (!SharedAssemblyNames.Contains(assemblyName.Name)) return null;
            var assemblyPath = resolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath == null) return null;
            return LoadFromAssemblyPath(assemblyPath);
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            var libraryPath = resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            return libraryPath != null ? LoadUnmanagedDllFromPath(libraryPath) : IntPtr.Zero;
        }
    }
}