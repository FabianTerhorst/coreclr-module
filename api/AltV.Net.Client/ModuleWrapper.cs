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
        private static Runtime.CSharpResourceImpl _runtime;

        public static void MainWithAssembly(Assembly resourceAssembly, IntPtr resourcePointer, IntPtr corePointer)
        {
            var library = new Library();
            var client = new Core(library, corePointer);
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
                _runtime = new Runtime.CSharpResourceImpl(library, pointer); // todo pool, move somewhere else
                _runtime.SetDelegates();
            }

            _resource = (IResource) Activator.CreateInstance(resource)!;
            Alt.Log("Instance created");
            
            var playerPool = new PlayerPool(_resource.GetPlayerFactory());
            Alt.Log("Player pool created");
            
            var vehiclePool = new VehiclePool(_resource.GetVehicleFactory());
            Alt.Log("Vehicle pool created");
            
            _module.InitPools(playerPool, vehiclePool);
            Alt.Log("Pools initialized");

            _resource.OnStart();
            Alt.Log("Finished");
        }
        
        public static void OnStop()
        {
            _resource.OnStop();
            
            Alt.Log("Stopping timers");
            foreach (var safeTimer in _module.RunningTimers.ToArray())
            {
                safeTimer.Stop();
                safeTimer.Dispose();
            }
            _module.PlayerPool.Dispose();
            _module.VehiclePool.Dispose();

            _runtime.Dispose();
        }
        
        public static void OnCreatePlayer(IntPtr pointer, ushort id)
        {
            _module.OnCreatePlayer(pointer, id);
        }

        public static void OnRemovePlayer(ushort id)
        {
            _module.OnRemovePlayer(id);
        }

        public static void OnCreateVehicle(IntPtr pointer, ushort id)
        {
            _module.OnCreateVehicle(pointer, id);
        }

        public static void OnRemoveVehicle(ushort id)
        {
            _module.OnRemoveVehicle(id);
        }

        public static void OnTick()
        {
            _module.OnTick();
        }

        public static void OnPlayerSpawn()
        {
            _module.OnPlayerSpawn();
        }
        
        public static void OnPlayerDisconnect()
        {
            _module.OnPlayerDisconnect();
        }

        public static void OnPlayerEnterVehicle(ushort id, byte seat)
        {
            _module.OnPlayerEnterVehicle(id, seat);
        }

        public static void OnResourceError(string name)
        {
            _module.OnResourceError(name);
        }
        
        public static void OnResourceStart(string name)
        {
            _module.OnResourceStart(name);
        }
        
        public static void OnResourceStop(string name)
        {
            _module.OnResourceStop(name);
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

        public static void OnClientEvent(string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }
            
            Alt.Log($"Client event \"{name}\" called. Parsed {args.Length} arguments");
            
            _module.OnClientEvent(name, args);
        }
        
        public static void OnConsoleCommand(string name,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            string[] args, int _)
        {
            args ??= new string[0];
            _module.OnConsoleCommand(name, args);
        }
    }
}