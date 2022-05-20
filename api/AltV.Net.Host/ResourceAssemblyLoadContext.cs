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

        private readonly Dictionary<string, byte[]> standardDlls;

        private readonly Dictionary<string, byte[]> standardSymbols;

        public ResourceAssemblyLoadContext(string resourceDllPath, string resourcePath, string resourceName, Dictionary<string, byte[]> standardDlls, Dictionary<string, byte[]> standardSymbols) : base(
            resourceName,
            Environment.GetEnvironmentVariable("CSHARP_MODULE_DISABLE_COLLECTIBLE") == null)
        {
            this.standardDlls = standardDlls;
            this.standardSymbols = standardSymbols;
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
                var assemblyFileName = assemblyName.Name + ".dll";
                var dllPath = resourcePath + Path.DirectorySeparatorChar + assemblyFileName;
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
                          Path.DirectorySeparatorChar + assemblyFileName;
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
                          assemblyFileName;
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
                          assemblyFileName;
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
                
                if (standardDlls.TryGetValue(assemblyFileName, out var content))
                {
                    Stream assemblyStream = new MemoryStream(content);
                    Stream assemblySymbols = null;
                    if (standardSymbols.TryGetValue(assemblyName.Name + ".pdb", out var symbolsContent))
                    {
                        assemblySymbols = new MemoryStream(symbolsContent);
                    }
                    
                    var assembly = LoadFromStream(assemblyStream, assemblySymbols);
                    assemblySymbols?.Dispose();
                    return assembly;
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
