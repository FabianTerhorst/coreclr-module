using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using AltV.Net.Client.CApi;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Pools;
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
                throw new Exception("Cannot find resource");
                return;
            }

            unsafe
            {
                var pointer = library.Resource_GetCSharpImpl(_resourcePointer);
                var runtime = new Runtime.CSharpResourceImpl(library, pointer); // todo pool, move somewhere else
                runtime.SetDelegates();
            }

            _resource = (IResource) Activator.CreateInstance(resource)!;

            var playerPool = new PlayerPool(_resource.GetPlayerFactory());
            _module.InitPools(playerPool);
            
            _resource.OnStart();
        }

        public static void OnTick()
        {
            _module.OnTick();
        }

        public static void OnServerEvent(string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }
            
            Alt.Log($"Server event \"{name}\" called. Parsed {args.Length} arguments");
            
            _module.OnServerEvent(name, args);
        }
    }
}