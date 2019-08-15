using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace AltV.Net.Host
{
    public class AssemblyLoader
    {
        private readonly Dictionary<string, Assembly> loadedAssemblies =
            AppDomain.CurrentDomain.GetAssemblies().ToDictionary(x => x.GetName().FullName, x => x);

        public Assembly LoadAssembly(AssemblyLoadContext assemblyLoadContext, string path)
        {
            var reflectionAssembly = AssemblyName.GetAssemblyName(path);

            if (loadedAssemblies.TryGetValue(reflectionAssembly.FullName, out var element)) return element;

            try
            {
                var loadedAssembly = assemblyLoadContext.LoadFromAssemblyPath(path);

                loadedAssemblies[loadedAssembly.GetName().FullName] = loadedAssembly;

                return loadedAssembly;
            }
            catch (FileLoadException e)
            {
                Console.WriteLine($"Threw a exception while loading the assembly \"{path}\": {e}");
                return null;
            }
        }

        public MethodInfo FindMainEntryPoint()
        {
            foreach (var (name, assembly) in loadedAssemblies)
            {
                Type[] types;
                try
                {
                    types = assembly.GetTypes();
                }
                catch (Exception e)
                {
                    Console.WriteLine(
                        $"{assembly.Location}: Threw a exception while looking in assembly '{assembly.FullName}': {e}");

                    if (!(e is ReflectionTypeLoadException reflectionException)) continue;
                    Console.WriteLine("---");

                    foreach (var exception in reflectionException.LoaderExceptions)
                    {
                        Console.WriteLine($"Exception: {exception}");
                    }

                    Console.WriteLine("---");

                    continue;
                }

                foreach (var type in types)
                {
                    if (!type.IsAbstract || !type.IsSealed)
                    {
                        continue;
                    }

                    var methodInfos = type.GetMethods(BindingFlags.Static);
                    foreach (var method in methodInfos)
                    {
                        if (method.Name != "Main")
                        {
                            continue;
                        }

                        var parameters = method.GetParameters();
                        if (parameters.Length != 1)
                        {
                            continue;
                        }

                        if (parameters[0].ParameterType != typeof(string[]))
                        {
                            continue;
                        }

                        return method;
                    }
                }
            }

            return null;
        }

        public T[] FindAllTypes<T>()
        {
            var typeToFind = typeof(T);
            var typesFound = new LinkedList<T>();
            foreach (var (name, assembly) in loadedAssemblies)
            {
                Type[] types;
                try
                {
                    types = assembly.GetTypes();
                }
                catch (Exception e)
                {
                    Console.WriteLine(
                        $"{assembly.Location}: Threw a exception while looking in assembly '{assembly.FullName}': {e}");

                    if (!(e is ReflectionTypeLoadException reflectionException)) continue;
                    Console.WriteLine("---");

                    foreach (var exception in reflectionException.LoaderExceptions)
                    {
                        Console.WriteLine($"Exception: {exception}");
                    }

                    Console.WriteLine("---");

                    continue;
                }

                foreach (var type in types)
                {
                    if (type.IsClass == false || type.IsAbstract ||
                        typeToFind.IsAssignableFrom((Type) type) == false)
                    {
                        continue;
                    }

                    var constructor =
                        type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null,
                            Type.EmptyTypes, null);

                    if (constructor == null)
                    {
                        Console.WriteLine(
                            $"Possible {typeToFind} \"{type}\" found, but no constructor without parameters available");

                        continue;
                    }

                    try
                    {
                        typesFound.AddFirst((T) constructor.Invoke(null));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Threw a exception while executing constructor: + {e}");
                    }
                }
            }

            return typesFound.ToArray();
        }
    }
}