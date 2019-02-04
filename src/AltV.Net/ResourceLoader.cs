using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AltV.Net
{
    internal class ResourceLoader
    {
        private readonly Module module;
        private readonly string basePath;

        private readonly Dictionary<string, Assembly> loadedAssemblies;
        private IResource resource;

        internal ResourceLoader(Module module, string resourceName, string entryPoint)
        {
            this.module = module;
            basePath = $"resources/{resourceName}/{entryPoint}";
            loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToDictionary(x => x.GetName().FullName, x => x);
        }

        public void Prepare()
        {
            var resourceInterfaceType = typeof(IResource);
            var assembly = LoadAssembly(basePath);
            Type[] types;
            try
            {
                types = assembly.GetTypes();
            }
            catch (Exception e)
            {
                Log(
                    $"{basePath}: An error occured during entrypoint search in assembly \"{assembly.FullName}\": ",
                    e);

                if (e is ReflectionTypeLoadException reflectionException)
                {
                    Log("Following LoaderExceptions are given:");

                    var loaderExceptions = reflectionException.LoaderExceptions;

                    for (int i = 0; i < loaderExceptions.Length; i++)
                    {
                        Log($"LoaderException {i + 1} / {loaderExceptions.Length}: ",
                            loaderExceptions[i]);
                    }
                }

                return;
            }

            foreach (var type in types)
            {
                if (type.IsClass == false || type.IsAbstract ||
                    resourceInterfaceType.IsAssignableFrom((Type) type) == false)
                {
                    continue;
                }

                var constructor =
                    type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null,
                        Type.EmptyTypes, null);

                if (constructor == null)
                {
                    Log(
                        $"Possible type \"{type}\" was found, but no parameterless-constructor is available!");

                    continue;
                }

                Log($"Entrypoint \"{type}\" found, executing constructor...");

                try
                {
                    resource = (IResource) constructor.Invoke(null);
                }
                catch (Exception e)
                {
                    Log("An error occured during constructor-execution: ", e);
                }
            }
        }

        private void Log(string message, Exception exception = null)
        {
            module.Server.LogInfo($"{basePath}: {message} + {exception}");
        }

        public void Start()
        {
            resource?.OnStart();
        }

        public void Stop()
        {
            resource?.OnStop();
        }


        private Assembly LoadAssembly(string path)
        {
            var reflectionAssembly = AssemblyName.GetAssemblyName(path);

            if (loadedAssemblies.TryGetValue(reflectionAssembly.FullName, out var element))
            {
                return element;
            }

            try
            {
                var loadedAssembly = Assembly.LoadFrom(path);

                loadedAssemblies[loadedAssembly.GetName().FullName] = loadedAssembly;

                return loadedAssembly;
            }
            catch (FileLoadException e)
            {
                module.Server.LogInfo($"An error occured while loading assembly \"{path}\": {e}");

                return null;
            }
        }
    }
}