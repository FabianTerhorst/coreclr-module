using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.CApi;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Pools;
using AltV.Net.Client.Extensions;
using AltV.Net.Client.WinApi;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;

namespace AltV.Net.Client
{
    public class ModuleWrapper
    {
        private static Core _core;
        private static IResource _resource;
        private static IntPtr _resourcePointer;
        private static IntPtr _corePointer;

        private static string DllName;
        public static void MainWithAssembly(Assembly resourceAssembly, IntPtr resourcePointer, IntPtr corePointer, string dllName)
        {
            DllName = dllName;

            var library = new Library(DllName, true);
            var logger = new Logger(library, corePointer);
            Alt.Logger = logger;
            Alt.Log("Library initialized");
            
            Console.SetOut(new AltTextWriter());
            Console.SetError(new AltErrorTextWriter());
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
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

            var checkpointPool = new CheckpointPool(_resource.GetCheckpointFactory());
            Alt.Log("Checkpoint pool created");

            var audioPool = new AudioPool(_resource.GetAudioFactory());
            Alt.Log("Audio pool created");

            var httpClientPool = new HttpClientPool(_resource.GetHttpClientFactory());
            Alt.Log("Http client pool created");

            var webSocketClientPool = new WebSocketClientPool(_resource.GetWebSocketClientFactory());
            Alt.Log("WebSocket client pool created");

            var webViewPool = new WebViewPool(_resource.GetWebViewFactory());
            Alt.Log("Webview pool created");

            var rmlDocumentPool = new RmlDocumentPool(new RmlDocumentFactory());
            var rmlElementPool = new RmlElementPool(new RmlElementFactory());
            Alt.Log("Rml pools created");

            var nativeResourcePool = new NativeResourcePool(_resource.GetResourceFactory());
            Alt.Log("Native resource pool created");

            var baseBaseObjectPool = new BaseBaseObjectPool(playerPool, vehiclePool, blipPool, checkpointPool, audioPool, httpClientPool, webSocketClientPool, webViewPool, rmlElementPool, rmlDocumentPool);
            var baseEntityPool = new BaseEntityPool(playerPool, vehiclePool);
            var timerPool = new TimerPool();

            var natives = _resource.GetNatives(DllName);

            var client = new Core(
                library,
                corePointer,
                resourcePointer,
                playerPool,
                vehiclePool,
                blipPool,
                checkpointPool,
                audioPool,
                httpClientPool,
                webSocketClientPool,
                webViewPool,
                rmlDocumentPool,
                rmlElementPool,
                baseBaseObjectPool,
                baseEntityPool,
                nativeResourcePool,
                timerPool,
                logger,
                natives
            );

            _core = client;
            Alt.CoreImpl = client;
            AltShared.Core = client;
            Alt.Log("Core initialized");

            _core.GetPlayers();
            _core.GetVehicles();
            _core.GetBlips();

            playerPool.InitLocalPlayer(_core);

            _core.Resource.CSharpResourceImpl.SetDelegates();
            Alt.Log("Delegates set");

            _resource.OnStart();
            Alt.Log("Startup finished");
        }
        
        private static void OnUnhandledException(object _, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            Alt.LogError(e.IsTerminating ? "FATAL EXCEPTION:" : "UNHANDLED EXCEPTION:");
            Alt.LogError(exception?.ToString());

            if (!e.IsTerminating) return;

            if (_core is null)
            {
                Alt.LogError("Cannot show error dialog because core is not initialized yet");
                return;
            }

            if (_resource is null)
            {
                Alt.LogError("Cannot show error dialog because resources is not initialized yet");
                return;
            }

            var options = _resource.OnUnhandledException(e);
            if (options == null)
            {
                Alt.LogInfo("Unhandled exception handler was null, skipping error dialog");
                return;
            }

            try
            {
                var dialog = new ErrorDialog(_core, options, exception);
                dialog.Show();
            }
            catch (Exception executionException)
            {
                Alt.LogError("Failed to show error dialog: " + executionException);
            }
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
            _core.BlipPool.Dispose();
            _core.AudioPool.Dispose();
            _core.CheckpointPool.Dispose();
            _core.HttpClientPool.Dispose();
            _core.WebSocketClientPool.Dispose();
            _core.WebViewPool.Dispose();
            _core.RmlElementPool.Dispose();
            _core.RmlDocumentPool.Dispose();

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
            _core.TimerPool.Tick(_core.Resource.Name);
            _resource.OnTick();
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

        public static void OnAnyResourceError(string name)
        {
            _core.OnAnyResourceError(name);
        }

        public static void OnAnyResourceStart(string name)
        {
            _core.OnAnyResourceStart(name);
        }

        public static void OnAnyResourceStop(string name)
        {
            _core.OnAnyResourceStop(name);
        }

        public static void OnKeyDown(uint key)
        {
            var consoleKey = (Key) key;
            _core.OnKeyDown(consoleKey);
        }

        public static void OnKeyUp(uint key)
        {
            var consoleKey = (Key) key;
            _core.OnKeyUp(consoleKey);
        }

        public static void OnServerEvent(string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }

            _core.OnServerEvent(name, args);
        }

        public static void OnClientEvent(string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }

            _core.OnClientEvent(name, args);
        }

        public static void OnWebViewEvent(IntPtr webView, string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }

            _core.OnWebViewEvent(webView, name, args);
        }

        public static void OnRmlElementEvent(IntPtr webView, string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }

            _core.OnRmlElementEvent(webView, name, args);
        }

        public static void OnConsoleCommand(string name,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            string[] args, int _)
        {
            args ??= Array.Empty<string>();
            _core.OnConsoleCommand(name, args);
        }

        public static void OnGlobalMetaChange(string key, IntPtr value, IntPtr oldValue)
        {
            _core.OnGlobalMetaChange(key, value, oldValue);
        }

        public static void OnGlobalSyncedMetaChange(string key, IntPtr value, IntPtr oldValue)
        {
            _core.OnGlobalSyncedMetaChange(key, value, oldValue);
        }

        public static void OnConnectionComplete()
        {
            _core.OnConnectionComplete();
        }

        public static void OnPlayerChangeVehicleSeat(IntPtr vehicle, byte oldSeat, byte newSeat)
        {
            _core.OnPlayerChangeVehicleSeat(vehicle, oldSeat, newSeat);
        }

        public static void OnLocalMetaChange(string key, IntPtr value, IntPtr oldValue)
        {
            _core.OnLocalMetaChange(key, value, oldValue);
        }

        public static void OnStreamSyncedMetaChange(IntPtr target, BaseObjectType type, string key, IntPtr value, IntPtr oldValue)
        {
            _core.OnStreamSyncedMetaChange(target, type, key, value, oldValue);
        }

        public static void OnSyncedMetaChange(IntPtr target, BaseObjectType type, string key, IntPtr value, IntPtr oldValue)
        {
            _core.OnSyncedMetaChange(target, type, key, value, oldValue);
        }

        public static void OnTaskChange(int oldTask, int newTask)
        {
            _core.OnTaskChange(oldTask, newTask);
        }

        public static void OnWindowFocusChange(byte state)
        {
            _core.OnWindowFocusChange(state);
        }

        public static void OnWindowResolutionChange(Vector2 oldRes, Vector2 newRes)
        {
            _core.OnWindowResolutionChange(oldRes, newRes);
        }

        public static void OnNetOwnerChange(IntPtr target, BaseObjectType type, IntPtr newOwner, IntPtr oldOwner)
        {
            var playerPool = _core.PlayerPool.GetAllEntities().Select(x => x.PlayerNativePointer);
            _core.OnNetOwnerChange(target, type, newOwner, oldOwner);
        }

        public static void OnRemoveEntity(IntPtr target, BaseObjectType type)
        {
            _core.OnRemoveEntity(target, type);
        }

        public static void OnPlayerLeaveVehicle(IntPtr vehicle, byte seat)
        {
            _core.OnPlayerLeaveVehicle(vehicle, seat);
        }

        public static void OnBlipCreate(IntPtr blipPointer)
        {
            _core.OnBlipCreate(blipPointer);
        }

        public static void OnWebViewCreate(IntPtr webView)
        {
            _core.OnWebViewCreate(webView);
        }

        public static void OnCheckpointCreate(IntPtr checkpoint)
        {
            _core.OnCheckpointCreate(checkpoint);
        }

        public static void OnWebSocketClientCreate(IntPtr webSocket)
        {
            _core.OnWebSocketClientCreate(webSocket);
        }

        public static void OnHttpClientCreate(IntPtr httpClient)
        {
            _core.OnHttpClientCreate(httpClient);
        }

        public static void OnAudioCreate(IntPtr audio)
        {
            _core.OnAudioCreate(audio);
        }

        public static void OnRmlElementCreate(IntPtr element)
        {
            _core.OnRmlElementCreate(element);
        }

        public static void OnRmlDocumentCreate(IntPtr document)
        {
            _core.OnRmlDocumentCreate(document);
        }

        public static void OnBlipRemove(IntPtr blipPointer)
        {
            _core.OnBlipRemove(blipPointer);
        }

        public static void OnWebViewRemove(IntPtr webView)
        {
            _core.OnWebViewRemove(webView);
        }

        public static void OnCheckpointRemove(IntPtr checkpoint)
        {
            _core.OnCheckpointRemove(checkpoint);
        }

        public static void OnWebSocketClientRemove(IntPtr webSocket)
        {
            _core.OnWebSocketClientRemove(webSocket);
        }

        public static void OnHttpClientRemove(IntPtr httpClient)
        {
            _core.OnHttpClientRemove(httpClient);
        }

        public static void OnAudioRemove(IntPtr audio)
        {
            _core.OnAudioRemove(audio);
        }

        public static void OnRmlElementRemove(IntPtr element)
        {
            _core.OnRmlElementRemove(element);
        }

        public static void OnRmlDocumentRemove(IntPtr document)
        {
            _core.OnRmlDocumentRemove(document);
        }
    }
}