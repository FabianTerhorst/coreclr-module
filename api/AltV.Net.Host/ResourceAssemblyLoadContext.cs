using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Diagnostics;

namespace AltV.Net.Host
{
    public class ResourceAssemblyLoadContext : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver resolver;
        public readonly HashSet<string> SharedAssemblyNames;

        private readonly Func<string, Assembly> loadAssembly;

        public ResourceAssemblyLoadContext(string resourceDllPath, string resourcePath, string resourceName) : base(
            resourceName,
            Environment.GetEnvironmentVariable("CSHARP_MODULE_DISABLE_COLLECTIBLE") == null)
        {
            if (Environment.GetEnvironmentVariable("CSHARP_MODULE_DISABLE_IN_MEMORY_DLL") == null)
            {
                loadAssembly = LoadFromPathAsStream;
            }
            else
            {
                loadAssembly = LoadFromAssemblyPath;
            }
            
            resolver = new AssemblyDependencyResolver(resourceDllPath);
            SharedAssemblyNames = new HashSet<string>();
            Resolving += (context, assemblyName) =>
            {
                var dllPath = resourcePath + Path.DirectorySeparatorChar + assemblyName.Name + ".dll";
                if (File.Exists(dllPath))
                {
                    try
                    {
                        var assembly = loadAssembly(dllPath);
                        CheckAssembly(assembly);
                        return assembly;
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
                        var assembly = loadAssembly(dllPath);
                        CheckAssembly(assembly);
                        return assembly;
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
                        var assembly = loadAssembly(dllPath);
                        CheckAssembly(assembly);
                        return assembly;
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
                        var assembly = loadAssembly(dllPath);
                        CheckAssembly(assembly);
                        return assembly;
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
            if (SharedAssemblyNames.Contains(assemblyName.Name)) return null;
            var assemblyPath = resolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath == null) return null;
            var assembly = loadAssembly(assemblyPath);
            CheckAssembly(assembly);
            return assembly;
        }

        private Assembly LoadFromPathAsStream(string path)
        {
            using var assemblyStream = new MemoryStream(File.ReadAllBytes(path));
            Stream assemblySymbols = null;

            var symbolsPath = Path.ChangeExtension(path, ".pdb");
            if (File.Exists(symbolsPath))
            {
                // Found a symbol next to the dll to load it
                assemblySymbols = new MemoryStream(File.ReadAllBytes(symbolsPath));
            }

            var assembly = LoadFromStream(assemblyStream, assemblySymbols);
            assemblySymbols?.Dispose();
            return assembly;
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            var libraryPath = resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            return libraryPath != null ? LoadUnmanagedDllFromPath(libraryPath) : IntPtr.Zero;
        }

        private static void CheckAssembly(Assembly assembly)
        {
            if (!assembly.IsCollectible)
            {
                Console.WriteLine("WARNING: " + assembly.FullName +
                                  " is not collectible and will prevent you from dynamically starting and stopping resources.");
            }

            if (!assembly.IsOptimized())
            {
                Console.WriteLine("WARNING: " + assembly.FullName +
                                  " is not optimized and might not provide best possible runtime performance.");
            }
        }
    }

    internal static class AssemblyExtensions
    {
        public static bool IsOptimized(this Assembly asm)
        {
            var att = asm.GetCustomAttribute<DebuggableAttribute>();
            return att == null || att.IsJITOptimizerDisabled == false;
        }
    }
}
