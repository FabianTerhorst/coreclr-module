using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.Native;

namespace AltV.Net
{
    internal class ResourceLoader
    {
        private static readonly Type ResourceInterfaceType = typeof(IResource);

        private readonly IntPtr serverPointer;
        private readonly string resourceName;
        private readonly string entryPoint;

        private readonly Dictionary<string, Assembly> loadedAssemblies =
            AppDomain.CurrentDomain.GetAssemblies().ToDictionary(x => x.GetName().FullName, x => x);

        internal ResourceLoader(IntPtr serverPointer, string resourceName, string entryPoint)
        {
            this.serverPointer = serverPointer;
            this.resourceName = resourceName;
            this.entryPoint = entryPoint;
        }

        protected virtual string GetPath(string pathResourceName, string pathEntryName) =>
            $"resources/{pathResourceName}/{pathEntryName}";

        public IResource Init()
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
                    $"{basePath}: Threw a exception while looking in assembly '{assembly.FullName}': {e}");

                if (!(e is ReflectionTypeLoadException reflectionException)) return null;
                Log("---");

                foreach (var exception in reflectionException.LoaderExceptions)
                {
                    Log($"Exception: {exception}");
                }

                Log("---");

                return null;
            }

            IResource resource = null;

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
                        $"Possible Resource \"{type}\" found, but no constructor without parameters available");

                    continue;
                }

                Log($"Resource \"{type}\" found, executing constructor");

                try
                {
                    resource = (IResource) constructor.Invoke(null);
                }
                catch (Exception e)
                {
                    Log($"Threw a exception while executing constructor: + {e}");
                }
            }

            if (resource == null)
            {
                Log($"No resource in assembly \"{basePath}\" found for type: \"{ResourceInterfaceType}\"");
            }

            return resource;
        }

        private Assembly LoadAssembly(string path)
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
                Log($"Threw a exception while loading the assembly \"{path}\": {e}");
                return null;
            }
        }

        protected virtual void Log(string message)
        {
            var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
            AltNative.Server.Server_LogInfo(serverPointer, messagePtr);
            Marshal.FreeHGlobal(messagePtr);
        }
    }
}