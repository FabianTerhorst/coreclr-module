using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AltV.Net.ResourceLoaders
{
    public class AssemblyLoader
    {
        private readonly Dictionary<string, Assembly> loadedAssemblies =
            AppDomain.CurrentDomain.GetAssemblies().ToDictionary(x => x.GetName().FullName, x => x);

        public Assembly LoadAssembly(string path)
        {
            var reflectionAssembly = AssemblyName.GetAssemblyName(path);

            if (loadedAssemblies.TryGetValue(reflectionAssembly.FullName, out var element)) return element;

            try
            {
                var loadedAssembly = Assembly.LoadFrom(path);

                loadedAssemblies[loadedAssembly.GetName().FullName] = loadedAssembly;

                return loadedAssembly;
            }
            catch (FileLoadException e)
            {
                Console.WriteLine($"Threw a exception while loading the assembly \"{path}\": {e}");
                return null;
            }
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
                        typeToFind.IsAssignableFrom(type) == false)
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
        
        public static T[] FindAllTypes<T>(IEnumerable<Assembly> assemblies)
        {
            var typeToFind = typeof(T);
            var typesFound = new LinkedList<T>();
            foreach (var assembly in assemblies)
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
                        typeToFind.IsAssignableFrom(type) == false)
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

        public static bool FindType<T>(IEnumerable<Assembly> assemblies, out T t)
        {
            foreach (var assembly in assemblies)
            {
                var typeToFind = typeof(T);
                Type[] types;
                try
                {
                    types = assembly.GetTypes();
                }
                catch (Exception e)
                {
                    Console.WriteLine(
                        $"{assembly.Location}: Threw a exception while looking in assembly '{assembly.FullName}': {e}");

                    if (!(e is ReflectionTypeLoadException reflectionException))
                    {
                        continue;
                    }

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
                        typeToFind.IsAssignableFrom(type) == false)
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
                        t = (T) constructor.Invoke(null);
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Threw a exception while executing constructor: + {e}");
                    }
                }
            }

            t = default;
            return false;
        }
    }
}