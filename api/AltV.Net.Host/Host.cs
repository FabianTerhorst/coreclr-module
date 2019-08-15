using System;

namespace AltV.Net.Host
{
    class Host
    {
        /// <summary>
        /// Main is present to execute the dll as a assembly
        /// </summary>
        static void Main()
        {
            //TODO: init stuff we need
        }

        private static string GetPath(string resourceName, string resourceMain) =>
            $"resources/{resourceName}/{resourceMain}";

        /// <summary>
        /// This is called when a resource should get executed
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="resourceMain"></param>
        /// <param name="resourceIndex"></param>
        static void ExecuteResource(string resourceName, string resourceMain, int resourceIndex)
        {
            var assemblyLoader = new AssemblyLoader();
            var resourceAssemblyLoadContext = new ResourceAssemblyLoadContext();
            assemblyLoader.LoadAssembly(resourceAssemblyLoadContext, GetPath(resourceName, resourceMain));
            var mainEntryPoint = assemblyLoader.FindMainEntryPoint();
            if (mainEntryPoint == null)
            {
                //TODO: when this happens try to find AltV.Net.dll in resource directory and execute the ModuleWrapper static main instead
                Console.WriteLine("No main entry point found");
                return;
            }

            var args = new object[1];
            args[0] = resourceIndex.ToString();
            mainEntryPoint.Invoke(null, args);
        }
    }
}