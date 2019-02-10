using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AltV.Net.Native;

namespace AltV.Net
{
    internal class ResourceLoader
    {
        private static readonly Type ResourceInterfaceType = typeof(IResource);

        private readonly IntPtr serverPointer;
        private readonly string resourceName;
        private readonly string entryPoint;

        private readonly Dictionary<string, Assembly> loadedAssemblies;
        private IResource resource;

        internal ResourceLoader(IntPtr serverPointer, string resourceName, string entryPoint)
        {
            this.serverPointer = serverPointer;
            this.resourceName = resourceName;
            this.entryPoint = entryPoint;
            loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToDictionary(x => x.GetName().FullName, x => x);
        }

        public virtual string GetPath(string pathResourceName, string pathEntryName)
        {
            return $"resources/{pathResourceName}/{pathEntryName}";
        }

        public IResource Prepare()
        {
            var basePath = GetPath(resourceName, entryPoint);
            var assembly = LoadAssembly(basePath);
            Type[] types;
            try
            {
                types = assembly.GetTypes();
            }
            catch (Exception e)
            {
                Log(
                    $"{basePath}: An error occured during Resource search in assembly \"{assembly.FullName}\": ",
                    e);

                if (!(e is ReflectionTypeLoadException reflectionException)) return null;
                Log("Following Exceptions are given:");

                foreach (var exception in reflectionException.LoaderExceptions)
                {
                    Log("Exception: ", exception);
                }

                return null;
            }

            foreach (var type in types)
            {
                if (type.IsClass == false || type.IsAbstract ||
                    ResourceInterfaceType.IsAssignableFrom(type) == false)
                {
                    continue;
                }

                var constructor =
                    type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null,
                        Type.EmptyTypes, null);

                if (constructor == null)
                {
                    Log(
                        $"Possible Resource \"{type}\" found, but no constructor without parameters available!");

                    continue;
                }

                Log($"Resource \"{type}\" found, executing constructor...");

                try
                {
                    resource = (IResource) constructor.Invoke(null);
                }
                catch (Exception e)
                {
                    Log("An error occured during constructor execution: ", e);
                }
            }

            return resource;
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
                Log($"An error occured while loading assembly \"{path}\": {e}");
                return null;
            }
        }

        public virtual void Log(string message, Exception exception = null)
        {
            AltVNative.Server.Server_LogInfo(serverPointer, $"{message} + {exception}");
        }
    }
}