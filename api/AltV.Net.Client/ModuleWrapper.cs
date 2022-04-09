using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.CApi;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Pools;
using AltV.Net.Client.Extensions;

namespace AltV.Net.Client
{
    public class ModuleWrapper
    {
        private static Core _core;
        private static IResource _resource;
        private static IntPtr _resourcePointer;
        private static IntPtr _corePointer;

        private const string DllName = "coreclr-client-module";
        public static void MainWithAssembly(Assembly resourceAssembly, IntPtr resourcePointer, IntPtr corePointer)
        {
            var library = new Library(DllName, true);
            var logger = new Logger(library, corePointer);
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

            Alt.Logger = _resource.GetLogger(library, corePointer);
            
            var playerPool = new PlayerPool(_resource.GetPlayerFactory());
            Alt.Log("Player pool created");
            
            var vehiclePool = new VehiclePool(_resource.GetVehicleFactory());
            Alt.Log("Vehicle pool created");

            var blipPool = new BlipPool(_resource.GetBlipFactory());
            Alt.Log("Blip pool created");

            var webViewPool = new WebViewPool(_resource.GetWebViewFactory());
            Alt.Log("Blip pool created");

            var rmlDocumentPool = new RmlDocumentPool(new RmlDocumentFactory());
            var rmlElementPool = new RmlElementPool(new RmlElementFactory());
            Alt.Log("Rml pools created");

            var nativeResourcePool = new NativeResourcePool(_resource.GetResourceFactory());
            Alt.Log("Native resource pool created");

            var baseBaseObjectPool = new BaseBaseObjectPool(playerPool, vehiclePool, blipPool, webViewPool);
            var baseEntityPool = new BaseEntityPool(playerPool, vehiclePool);

            var natives = _resource.GetNatives(DllName);

            var client = new Core(
                library,
                corePointer,
                resourcePointer,
                playerPool,
                vehiclePool,
                blipPool,
                webViewPool,
                rmlDocumentPool,
                rmlElementPool,
                baseBaseObjectPool,
                baseEntityPool,
                nativeResourcePool,
                logger,
                natives
            );
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

        public static void OnGameEntityCreate(IntPtr pointer, byte type)
        {
            _core.OnGameEntityCreate(pointer, type);
        }

        public static void OnGameEntityDestroy(IntPtr pointer, byte type)
        {
            _core.OnGameEntityDestroy(pointer, type);
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