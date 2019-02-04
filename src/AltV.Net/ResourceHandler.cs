using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AltV.Net
{
    internal class ResourceHandler
    {
        private readonly Module _module;
        private readonly DirectoryInfo _directory;
        private readonly ResourceLoader _resourceLoader;

        private readonly string _resourceName;
        private readonly List<Assembly> _loadedAssemblies = new List<Assembly>();

        private IResource _entryPoint;

        public ResourceHandler(Module module, DirectoryInfo directory, ResourceLoader resourceLoader)
        {
            _module = module;
            _directory = directory;
            _resourceLoader = resourceLoader;

            _resourceName = _directory.Name;
        }

        public void Prepare()
        {
            Log("Prepare resource...");

            if (TryLoadAssemblies() == false)
            {
                Log("Resource preparation has been aborted!");

                return;
            }

            if (_loadedAssemblies.Any() == false)
            {
                Log("Could not find any assembly inside resource folder.");

                return;
            }

            _entryPoint = LoadEntryPoint();

            Log("Resource successfully prepared!");
        }

        public void Start()
        {
            Log("Starting resource...");

            if (_entryPoint == null)
            {
                Log(
                    $"Could not find a valid entrypoint-class implementing interface \"{typeof(IResource)}\"!");

                return;
            }

            try
            {
                _entryPoint.OnStart();
            }
            catch (Exception e)
            {
                Log("An error occured during resource startup!", e);

                return;
            }

            Log("Resource successfully started!");
        }
        
        public void Stop()
        {
            Log("Stopping resource...");

            if (_entryPoint == null)
            {
                Log(
                    $"Could not find a valid entrypoint-class implementing interface \"{typeof(IResource)}\"!");

                return;
            }

            try
            {
                _entryPoint.OnStop();
            }
            catch (Exception e)
            {
                Log("An error occured during resource stop!", e);

                return;
            }

            Log("Resource successfully stopped!");
        }

        private bool TryLoadAssemblies()
        {
            try
            {
                foreach (var file in _directory.GetFiles("*.dll"))
                {
                    var assembly = _resourceLoader.LoadAssembly(file.FullName);
                    if (assembly == null)
                    {
                        Log(
                            $"Skipping assembly \"{file.FullName}\", because an error occured during load!");

                        continue;
                    }

                    _loadedAssemblies.Add(assembly);
                }

                return true;
            }
            catch (Exception e)
            {
                Log("An error occured during assembly loading:", e);
            }

            return false;
        }

        private IResource LoadEntryPoint()
        {
            var resourceInterfaceType = typeof(IResource);

            foreach (var assembly in _loadedAssemblies)
            {
                Type[] types;
                try
                {
                    types = assembly.GetTypes();
                }
                catch (Exception e)
                {
                    Log(
                        $"{_directory.Name}: An error occured during entrypoint search in assembly \"{assembly.FullName}\": ",
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

                    return null;
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

                    Log( $"Entrypoint \"{type}\" found, executing constructor...");

                    try
                    {
                        return (IResource) constructor.Invoke(null);
                    }
                    catch (Exception e)
                    {
                        Log("An error occured during constructor-execution: ", e);

                        return null;
                    }
                }
            }

            return null;
        }

        private void Log(string message, Exception exception = null)
        {
            _module.Server.LogInfo($"{_resourceName}: {message} + {exception}");
        }
    }
}