using System.Reflection;
using System.Runtime.Loader;
using AltV.Net.Client.CApi;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AltV.Net.Client
{
    public class ModuleWrapper
    {
        private static Module _module;
        private static IResource _resource;
        private static IntPtr _resourcePointer;
        private static IntPtr _corePointer;

        public static void MainWithAssembly(Assembly resourceAssembly, IntPtr resourcePointer, IntPtr corePointer)
        {
            var library = new Library();
            var client = new Client(library, corePointer);
            var module = new Module(client);

            _module = module;
            _resourcePointer = resourcePointer;
            _corePointer = corePointer;

            var type = typeof(IResource);
            var resource = resourceAssembly.GetTypes().FirstOrDefault(t => t.IsClass && !t.IsAbstract && type.IsAssignableFrom(t));
            if (resource is null)
            {
                Alt.Log("Cannot find resource!");
                return;
            }

            _resource = (IResource) Activator.CreateInstance(resource)!;
            _resource.OnStart();
        }
    }
}