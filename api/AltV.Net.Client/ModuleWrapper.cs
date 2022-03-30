using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using AltV.Net.Client.CApi;
using AltV.Net.Client.CApi.Memory;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Pools;
using AltV.Net.Client.Extensions;
using AltV.Net.Elements.Pools;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AltV.Net.Client
{
    public class ModuleWrapper
    {
        private static Core _core;
        private static IResource _resource;
        private static IntPtr _resourcePointer;
        private static IntPtr _corePointer;

        private static void Log(ILibrary library, string msg)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(msg);
                library.LogInfo(messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        } 

        public static void MainWithAssembly(Assembly resourceAssembly, IntPtr resourcePointer, IntPtr corePointer)
        {
            var library = new Library();
            var logger = new Logger(library);
            Alt.Logger = logger;
            Alt.Log("Library initialized");
            
            Console.SetOut(new AltTextWriter());
            Console.SetError(new AltErrorTextWriter());
            Alt.Log("Out set");
            
            _resourcePointer = resourcePointer;
            _corePointer = corePointer;

            var type = typeof(IResource);
            var resource = resourceAssembly.GetTypes().FirstOrDefault(t => t.IsClass && !t.IsAbstract && type.IsAssignableFrom(t));
            if (resource is null)
            {
                throw new Exception("Cannot find resource");
                return;
            }

            _resource = (IResource) Activator.CreateInstance(resource)!;
            Alt.Log("Resource created");

            Alt.Logger = _resource.GetLogger(library);
            
            var playerPool = new PlayerPool(_resource.GetPlayerFactory());
            Alt.Log("Player pool created");
            
            var vehiclePool = new VehiclePool(_resource.GetVehicleFactory());
            Alt.Log("Vehicle pool created");

            var nativeResourcePool = new NativeResourcePool(_resource.GetResourceFactory());
            Alt.Log("Native resource pool created");
            
            var client = new Core(library, corePointer, resourcePointer, playerPool, vehiclePool, nativeResourcePool, logger);
            _core = client;
            Alt.CoreImpl = client;
            Alt.Log("Core initialized");
            
            playerPool.InitLocalPlayer(_core);

            _core.Resource.CSharpResourceImpl.SetDelegates();
            Alt.Log("Delegates set");

            _resource.OnStart();
            Alt.Log("Startup finished");
        }
        
        public static void OnStop()
        {
            _resource.OnStop();
            
            Alt.Log("Stopping timers");
            foreach (var safeTimer in _core.RunningTimers.ToArray())
            {
                safeTimer.Stop();
                safeTimer.Dispose();
            }
            _core.PlayerPool.Dispose();
            _core.VehiclePool.Dispose();

            _core.Resource.CSharpResourceImpl.Dispose();
        }
        
        public static void OnCreatePlayer(IntPtr pointer, ushort id)
        {
            _core.OnCreatePlayer(pointer, id);
        }

        public static void OnRemovePlayer(IntPtr pointer)
        {
            _core.OnRemovePlayer(pointer);
        }

        public static void OnCreateVehicle(IntPtr pointer, ushort id)
        {
            _core.OnCreateVehicle(pointer, id);
        }

        public static void OnRemoveVehicle(IntPtr pointer)
        {
            _core.OnRemoveVehicle(pointer);
        }

        public static void OnTick()
        {
            _core.OnTick();
        }

        public static void OnPlayerSpawn()
        {
            _core.OnPlayerSpawn();
        }
        
        public static void OnPlayerDisconnect()
        {
            _core.OnPlayerDisconnect();
        }

        public static void OnPlayerEnterVehicle(IntPtr pointer, byte seat)
        {
            _core.OnPlayerEnterVehicle(pointer, seat);
        }

        public static void OnResourceError(string name)
        {
            _core.OnResourceError(name);
        }
        
        public static void OnResourceStart(string name)
        {
            _core.OnResourceStart(name);
        }
        
        public static void OnResourceStop(string name)
        {
            _core.OnResourceStop(name);
        }
        
        public static void OnKeyDown(uint key)
        {
            var consoleKey = (ConsoleKey) key;
            _core.OnKeyDown(consoleKey);
        }
        
        public static void OnKeyUp(uint key)
        {
            var consoleKey = (ConsoleKey) key;
            _core.OnKeyUp(consoleKey);
        }
        
        public static void OnServerEvent(string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }
            
            Alt.Log($"Server event \"{name}\" called. Parsed {args.Length} arguments");
            
            _core.OnServerEvent(name, args);
        }

        public static void OnClientEvent(string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }
            
            Alt.Log($"Client event \"{name}\" called. Parsed {args.Length} arguments");
            
            _core.OnClientEvent(name, args);
        }
        
        public static void OnConsoleCommand(string name,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            string[] args, int _)
        {
            args ??= new string[0];
            _core.OnConsoleCommand(name, args);
        }
    }
}