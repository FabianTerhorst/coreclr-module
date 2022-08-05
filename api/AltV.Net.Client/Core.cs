using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AltV.Net.CApi;
using AltV.Net.Client.Elements;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Elements.Pools;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;
using AltV.Net.Shared;
using AltV.Net.Shared.Utils;
using WeaponData = AltV.Net.Client.Elements.Data.WeaponData;

namespace AltV.Net.Client
{
    public partial class Core : SharedCore, ICore
    {

        public override IPlayerPool PlayerPool { get; }
        public override IEntityPool<IVehicle> VehiclePool { get; }
        public override IBaseObjectPool<IBlip> BlipPool { get; }
        public override IBaseObjectPool<ICheckpoint> CheckpointPool { get; }
        public IBaseObjectPool<IAudio> AudioPool { get; }
        public IBaseObjectPool<IHttpClient> HttpClientPool { get; }
        public IBaseObjectPool<IWebSocketClient> WebSocketClientPool { get; }
        public IBaseObjectPool<IWebView> WebViewPool { get; }
        public IBaseObjectPool<IRmlDocument> RmlDocumentPool { get; }
        public IBaseObjectPool<IRmlElement> RmlElementPool { get; }
        public IBaseObjectPool<IObject> ObjectPool { get; }

        public IBaseEntityPool BaseEntityPool { get; }
        public INativeResourcePool NativeResourcePool { get; }
        public ITimerPool TimerPool { get; }
        public override IBaseBaseObjectPool BaseBaseObjectPool { get; }

        public override INativeResource Resource { get; }
        public ILogger Logger { get; }
        public INatives Natives { get; }

        public LocalStorage LocalStorage { get; }
        public Voice Voice { get; }
        public Discord Discord { get; }
        public FocusData FocusData { get; }

        public List<SafeTimer> RunningTimers { get; } = new();

        public Core(
            ILibrary library,
            IntPtr nativePointer,
            IntPtr resourcePointer,
            IPlayerPool playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IAudio> audioPool,
            IBaseObjectPool<IHttpClient> httpClientPool,
            IBaseObjectPool<IWebSocketClient> webSocketClientPool,
            IBaseObjectPool<IWebView> webViewPool,
            IBaseObjectPool<IRmlDocument> rmlDocumentPool,
            IBaseObjectPool<IRmlElement> rmlElementPool,
            IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool,
            INativeResourcePool nativeResourcePool,
            ITimerPool timerPool,
            ILogger logger,
            INatives natives
        ) : base(nativePointer, library)
        {
            PlayerPool = playerPool;
            VehiclePool = vehiclePool;
            BlipPool = blipPool;
            CheckpointPool = checkpointPool;
            AudioPool = audioPool;
            HttpClientPool = httpClientPool;
            WebSocketClientPool = webSocketClientPool;
            WebViewPool = webViewPool;
            RmlDocumentPool = rmlDocumentPool;
            RmlElementPool = rmlElementPool;
            Logger = logger;
            BaseBaseObjectPool = baseBaseObjectPool;
            BaseEntityPool = baseEntityPool;
            NativeResourcePool = nativeResourcePool;
            TimerPool = timerPool;
            nativeResourcePool.GetOrCreate(this, resourcePointer, out var resource);
            Resource = resource;
            LocalStorage = new LocalStorage(this, GetLocalStoragePtr());
            Voice = new Voice(this);
            Discord = new Discord(this);
            FocusData = new FocusData(this);
            Natives = natives;
        }

        #region Log

        private IntPtr GetLocalStoragePtr()
        {
            unsafe
            {
                return this.Library.Client.Resource_GetLocalStorage(this.Resource.NativePointer);
            }
        }

        public new void LogInfo(string message) => Logger.LogInfo(message);
        public new void LogWarning(string message) => Logger.LogWarning(message);
        public new void LogError(string message) => Logger.LogError(message);
        public new void LogDebug(string message) => Logger.LogDebug(message);

        #endregion

        public IPlayer[] GetPlayers()
        {
            unsafe
            {
                CheckIfCallIsValid();
                var playerCount = Library.Shared.Core_GetPlayerCount(NativePointer);
                var pointers = new IntPtr[playerCount];
                Library.Shared.Core_GetPlayers(NativePointer, pointers, playerCount);
                var players = new IPlayer[playerCount];
                for (ulong i = 0; i < playerCount; i++)
                {
                    var playerPointer = pointers[i];
                    players[i] = PlayerPool.GetOrCreate(this, playerPointer);
                }

                return players;
            }
        }

        public IVehicle[] GetVehicles()
        {
            unsafe
            {
                CheckIfCallIsValid();
                var vehicleCount = Library.Shared.Core_GetVehicleCount(NativePointer);
                var pointers = new IntPtr[vehicleCount];
                Library.Shared.Core_GetVehicles(NativePointer, pointers, vehicleCount);
                var vehicles = new IVehicle[vehicleCount];
                for (ulong i = 0; i < vehicleCount; i++)
                {
                    var vehiclePointer = pointers[i];
                    vehicles[i] = VehiclePool.GetOrCreate(this, vehiclePointer);
                }

                return vehicles;
            }
        }

        public IBlip[] GetBlips()
        {
            unsafe
            {
                CheckIfCallIsValid();
                var blipCount = Library.Shared.Core_GetBlipCount(NativePointer);
                var pointers = new IntPtr[blipCount];
                Library.Shared.Core_GetBlips(NativePointer, pointers, blipCount);
                var blips = new IBlip[blipCount];
                for (ulong i = 0; i < blipCount; i++)
                {
                    var blipPointer = pointers[i];
                    blips[i] = BlipPool.GetOrCreate(this, blipPointer);
                }

                return blips;
            }
        }

        public new IEntity GetEntityById(ushort id)
        {
            return (IEntity) base.GetEntityById(id);
        }

        public HandlingData? GetHandlingByModelHash(uint modelHash)
        {
            unsafe
            {
                var pointer = IntPtr.Zero;
                var success = Library.Client.Vehicle_Handling_GetByModelHash(NativePointer, modelHash, &pointer);
                if (success == 0 || pointer == IntPtr.Zero) return null;
                return new HandlingData(this, pointer);
            }
        }

        public WeaponData? GetWeaponDataByWeaponHash(uint weaponHash)
        {
            unsafe
            {
                var pointer = IntPtr.Zero;
                var success = Library.Client.WeaponData_GetByWeaponHash(NativePointer, weaponHash, &pointer);
                if (success == 0 || pointer == IntPtr.Zero) return null;
                return new WeaponData(this, pointer);
            }
        }

        public DiscordUser? GetDiscordUser()
        {
            unsafe
            {
                var ptr = Library.Client.Core_GetDiscordUser(NativePointer);
                if (ptr == IntPtr.Zero) return null;
                var structure = Marshal.PtrToStructure<DiscordUser>(ptr);
                Library.Client.Core_DeallocDiscordUser(ptr);
                return structure;
            }
        }

        #region Create

        public IntPtr CreatePointBlipPtr(Position position)
        {
            unsafe
            {
                return Library.Client.Core_Client_CreatePointBlip(NativePointer, position);
            }
        }

        public IBlip CreatePointBlip(Position position)
        {
            var ptr = CreatePointBlipPtr(position);
            if (ptr == IntPtr.Zero) return null;
            return BlipPool.Create(this, ptr);
        }

        public IntPtr CreateRadiusBlipPtr(Position position, float radius)
        {
            unsafe
            {
                return Library.Client.Core_Client_CreateRadiusBlip(NativePointer, position, radius);
            }
        }

        public IBlip CreateRadiusBlip(Position position, float radius)
        {
            var ptr = CreateRadiusBlipPtr(position, radius);
            if (ptr == IntPtr.Zero) return null;
            return BlipPool.Create(this, ptr);
        }

        public IntPtr CreateAreaBlipPtr(Position position, int width, int height)
        {
            unsafe
            {
                return Library.Client.Core_Client_CreateAreaBlip(NativePointer, position, width, height);
            }
        }

        public IBlip CreateAreaBlip(Position position, int width, int height)
        {
            var ptr = CreateAreaBlipPtr(position, width, height);
            if (ptr == IntPtr.Zero) return null;
            return BlipPool.Create(this, ptr);
        }

        public IntPtr CreateWebViewPtr(string url, bool isOverlay = false, Vector2? pos = null, Vector2? size = null)
        {
            pos ??= Vector2.Zero;
            size ??= Vector2.Zero;

            unsafe
            {
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var ptr = Library.Client.Core_CreateWebView(NativePointer, Resource.NativePointer, urlPtr, pos.Value, size.Value, (byte) (isOverlay ? 1 : 0));
                Marshal.FreeHGlobal(urlPtr);
                return ptr;
            }
        }

        public IWebView CreateWebView(string url, bool isOverlay = false, Vector2? pos = null, Vector2? size = null)
        {
            var ptr = CreateWebViewPtr(url, isOverlay, pos, size);
            if (ptr == IntPtr.Zero) return null;
            return WebViewPool.Create(this, ptr);
        }

        public IntPtr CreateWebViewPtr(string url, uint propHash, string targetTexture)
        {
            unsafe
            {
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var targetTexturePtr = MemoryUtils.StringToHGlobalUtf8(targetTexture);
                var ptr = Library.Client.Core_CreateWebView3D(NativePointer, Resource.NativePointer, urlPtr, propHash, targetTexturePtr);
                Marshal.FreeHGlobal(urlPtr);
                Marshal.FreeHGlobal(targetTexturePtr);
                return ptr;
            }
        }

        public IWebView CreateWebView(string url, uint propHash, string targetTexture)
        {
            var ptr = CreateWebViewPtr(url, propHash, targetTexture);
            if (ptr == IntPtr.Zero) return null;
            return WebViewPool.Create(this, ptr);
        }

        public IntPtr CreateRmlDocumentPtr(string url)
        {
            unsafe
            {
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var ptr = Library.Client.Core_CreateRmlDocument(NativePointer, Resource.NativePointer, urlPtr);
                Marshal.FreeHGlobal(urlPtr);
                return ptr;
            }
        }

        public IRmlDocument CreateRmlDocument(string url)
        {
            var ptr = CreateRmlDocumentPtr(url);
            if (ptr == IntPtr.Zero) return null;
            return RmlDocumentPool.Create(this, ptr);
        }

        public IntPtr CreateCheckpointPtr(CheckpointType type, Vector3 pos, Vector3 nextPos, float radius, float height, Rgba color)
        {
            unsafe
            {
                return Library.Client.Core_CreateCheckpoint(NativePointer, (byte) type, pos, nextPos, radius, height, color);
            }
        }

        public ICheckpoint CreateCheckpoint(CheckpointType type, Vector3 pos, Vector3 nextPos, float radius, float height, Rgba color)
        {
            var ptr = CreateCheckpointPtr(type, pos, nextPos, radius, height, color);
            if (ptr == IntPtr.Zero) return null;
            return CheckpointPool.Create(this, ptr);
        }

        public IntPtr CreateAudioPtr(string source, float volume, uint category, bool frontend)
        {
            unsafe
            {
                var sourcePtr = MemoryUtils.StringToHGlobalUtf8(source);
                var ptr = Library.Client.Core_CreateAudio(NativePointer, Resource.NativePointer, sourcePtr, volume, category, (byte) (frontend ? 1 : 0));
                Marshal.FreeHGlobal(sourcePtr);
                return ptr;
            }
        }

        public IAudio CreateAudio(string source, float volume, uint category, bool frontend)
        {
            var ptr = CreateAudioPtr(source, volume, category, frontend);
            if (ptr == IntPtr.Zero) return null;
            return AudioPool.Create(this, ptr);
        }

        public IntPtr CreateObjectPtr(uint modelHash, Position position, Rotation rotation, bool noOffset = false,
            bool dynamic = false)
        {
            unsafe
            {
                var ptr = Library.Client.Core_CreateObject(NativePointer, modelHash, position, rotation, (byte) (noOffset ? 1 : 0), (byte) (dynamic ? 1 : 0));
                return ptr;
            }
        }

        public IObject CreateObject(uint modelHash, Position position, Rotation rotation, bool noOffset = false, bool dynamic = false)
        {
            var ptr = CreateObjectPtr(modelHash, position, rotation, noOffset, dynamic);
            if (ptr == IntPtr.Zero) return null;
            return ObjectPool.Create(this, ptr);
        }

        public IntPtr CreateHttpClientPtr()
        {
            unsafe
            {
                return Library.Client.Core_CreateHttpClient(NativePointer, Resource.NativePointer);
            }
        }

        public IHttpClient CreateHttpClient()
        {
            var ptr = CreateHttpClientPtr();
            if (ptr == IntPtr.Zero) return null;
            return HttpClientPool.Create(this, ptr);
        }

        public IntPtr CreateWebSocketClientPtr(string url)
        {
            unsafe
            {
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var ptr = Library.Client.Core_CreateWebsocketClient(NativePointer, Resource.NativePointer, urlPtr);
                Marshal.FreeHGlobal(urlPtr);
                return ptr;
            }
        }

        public IWebSocketClient CreateWebSocketClient(string url)
        {
            var ptr = CreateWebSocketClientPtr(url);
            if (ptr == IntPtr.Zero) return null;
            return WebSocketClientPool.Create(this, ptr);
        }

        #endregion

        #region TriggerServerEvent

        public void TriggerServerEvent(string eventName, MValueConst[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerServerEvent(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, MValueConst[] args)
        {
            var size = args.Length;
            var mValuePointers = new IntPtr[size];
            for (var i = 0; i < size; i++)
            {
                mValuePointers[i] = args[i].nativePointer;
            }

            TriggerServerEvent(eventNamePtr, mValuePointers);
        }

        public void TriggerServerEvent(string eventName, IntPtr[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerServerEvent(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TriggerServerEvent(IntPtr eventNamePtr, IntPtr[] args)
        {
            unsafe
            {
                Library.Client.Core_TriggerServerEvent(NativePointer, eventNamePtr, args, args.Length);
            }
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerServerEvent(eventNamePtr, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerServerEvent(eventName, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        #endregion

        public INativeResource GetResource(string name)
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var ptr = Library.Shared.Core_GetResource(NativePointer, namePtr);
                Marshal.FreeHGlobal(namePtr);
                NativeResourcePool.GetOrCreate(this, ptr, out var resource);
                return resource;
            }
        }

        public bool HasResource(string name)
        {
            unsafe
            {
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var ptr = Library.Shared.Core_GetResource(NativePointer, namePtr);
                Marshal.FreeHGlobal(namePtr);
                return ptr != IntPtr.Zero;
            }
        }

        public INativeResource[] GetAllResources()
        {
            unsafe
            {
                uint size = 0;
                var ptr = Library.Shared.Core_GetAllResources(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => NativeResourcePool.GetOrCreate(this, e, out var v) ? v : null).ToArray();
                Library.Shared.FreeResourceArray(ptr);
                return arr;
            }
        }

        public string[] MarshalStringArrayPtrAndFree(IntPtr ptr, uint size)
        {
            unsafe
            {
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => Marshal.PtrToStringUTF8(e)).ToArray();
                this.Library.Shared.FreeStringArray(ptr, size);
                return arr;
            }
        }

        public uint SetTimeout(Action action, uint duration, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            return TimerPool.Add(new ModuleTimer(action, duration, true, filePath, lineNumber));
        }

        public uint SetInterval(Action action, uint duration, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            return TimerPool.Add(new ModuleTimer(action, duration, false, filePath, lineNumber));
        }

        public uint NextTick(Action action, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            return TimerPool.Add(new ModuleTimer(action, 0, true, filePath, lineNumber));
        }

        public uint EveryTick(Action action, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            return TimerPool.Add(new ModuleTimer(action, 0, false, filePath, lineNumber));
        }

        public void ClearTimer(uint id)
        {
            TimerPool.Remove(id);
        }
    }
}