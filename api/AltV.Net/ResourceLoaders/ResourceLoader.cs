using System;
using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.Native;

namespace AltV.Net.ResourceLoaders
{
    internal class ResourceLoader
    {
        private static readonly Type ResourceInterfaceType = typeof(IResource);

        private readonly IntPtr serverPointer;
        private readonly AssemblyLoader assemblyLoader;
        private readonly string resourceName;
        private readonly string entryPoint;

        internal ResourceLoader(IntPtr serverPointer, AssemblyLoader assemblyLoader, string resourceName,
            string entryPoint)
        {
            this.serverPointer = serverPointer;
            this.assemblyLoader = assemblyLoader;
            this.resourceName = resourceName;
            this.entryPoint = entryPoint;
        }

        protected virtual string GetPath(string pathResourceName, string pathEntryName) =>
            $"resources/{pathResourceName}/{pathEntryName}";

        public IResource Init()
        {
            var basePath = GetPath(resourceName, entryPoint);
            var assembly = assemblyLoader.LoadAssembly(basePath);
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

        protected virtual void Log(string message)
        {
            var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
            AltNative.Server.Server_LogInfo(serverPointer, messagePtr);
            Marshal.FreeHGlobal(messagePtr);
        }
    }
}