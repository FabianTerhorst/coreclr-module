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
using AltV.Net.Shared.Enums;
using AltV.Net.Shared.Utils;
using WeaponData = AltV.Net.Client.Elements.Data.WeaponData;

namespace AltV.Net.Client
{
    public partial class Core : SharedCore, ICore
    {
        public INativeResourcePool NativeResourcePool { get; }
        public ITimerPool TimerPool { get; }
        public override IPoolManager PoolManager { get; }

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
            IPoolManager poolManager,
            INativeResourcePool nativeResourcePool,
            ITimerPool timerPool,
            ILogger logger,
            INatives natives
        ) : base(nativePointer, library)
        {
            Logger = logger;
            PoolManager = poolManager;
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

        public IReadOnlyCollection<IPlayer> GetAllPlayers()
        {
            unsafe
            {
                CheckIfCallIsValid();
                ulong size = 0;
                var ptr = Library.Shared.Core_GetPlayers(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => (IPlayer)PoolManager.GetOrCreate(this, e, BaseObjectType.Player)).ToArray();
                Library.Shared.FreePlayerArray(ptr);
                return arr;
            }
        }

        public IReadOnlyCollection<IVehicle> GetAllVehicles()
        {
            unsafe
            {
                CheckIfCallIsValid();
                ulong size = 0;
                var ptr = Library.Shared.Core_GetVehicles(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => (IVehicle)PoolManager.GetOrCreate(this, e, BaseObjectType.Vehicle)).ToArray();
                Library.Shared.FreeVehicleArray(ptr);
                return arr;
            }
        }

        public IReadOnlyCollection<IBlip> GetAllBlips()
        {
            unsafe
            {
                CheckIfCallIsValid();
                ulong size = 0;
                var ptr = Library.Shared.Core_GetBlips(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => (IBlip)PoolManager.GetOrCreate(this, e, BaseObjectType.Blip)).ToArray();
                Library.Shared.FreeBlipArray(ptr);
                return arr;
            }
        }

        public IReadOnlyCollection<ICheckpoint> GetAllCheckpoints()
        {
            unsafe
            {
                CheckIfCallIsValid();
                ulong size = 0;
                var ptr = Library.Shared.Core_GetCheckpoints(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => (ICheckpoint)PoolManager.GetOrCreate(this, e, BaseObjectType.Checkpoint)).ToArray();
                Library.Shared.FreeCheckpointArray(ptr);
                return arr;
            }
        }

        public IReadOnlyCollection<IVirtualEntity> GetAllVirtualEntities()
        {
            unsafe
            {
                CheckIfCallIsValid();
                ulong size = 0;
                var ptr = Library.Shared.Core_GetVirtualEntities(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => (IVirtualEntity)PoolManager.GetOrCreate(this, e, BaseObjectType.VirtualEntity)).ToArray();
                Library.Shared.FreeVirtualEntityArray(ptr);
                return arr;
            }
        }

        public IReadOnlyCollection<IVirtualEntityGroup> GetAllVirtualEntityGroups()
        {
            unsafe
            {
                CheckIfCallIsValid();
                ulong size = 0;
                var ptr = Library.Shared.Core_GetVirtualEntityGroups(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => (IVirtualEntityGroup)PoolManager.GetOrCreate(this, e, BaseObjectType.VirtualEntityGroup)).ToArray();
                Library.Shared.FreeVirtualEntityGroupArray(ptr);
                return arr;
            }
        }

        public IReadOnlyCollection<IPed> GetAllPeds()
        {
            unsafe
            {
                CheckIfCallIsValid();
                ulong size = 0;
                var ptr = Library.Shared.Core_GetPeds(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => (IPed)PoolManager.GetOrCreate(this, e, BaseObjectType.Ped)).ToArray();
                Library.Shared.FreePedArray(ptr);
                return arr;
            }
        }

        public IntPtr CreateMarkerPtr(out uint id, MarkerType type, Position pos, Rgba color)
        {
            unsafe
            {
                uint pId = default;
                var markerPoint = Library.Client.Core_CreateMarker_Client(NativePointer, (byte)type, pos, color, Resource.NativePointer, &pId);
                id = pId;
                return markerPoint;
            }
        }

        public new IEntity GetEntityById(uint id)
        {
            return (IEntity) base.GetEntityById(id);
        }

        public HandlingData? GetHandlingByModelHash(uint modelHash)
        {
            return new HandlingData(this, modelHash);
        }

        public WeaponData? GetWeaponDataByWeaponHash(uint weaponHash)
        {
            return new WeaponData(this, weaponHash);
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

        public IntPtr CreatePointBlipPtr(out uint id, Position position)
        {
            unsafe
            {
                uint pId = default;
                var pointBlip = Library.Client.Core_Client_CreatePointBlip(NativePointer, position, Resource.NativePointer, &pId);
                id = pId;
                return pointBlip;
            }
        }

        public IBlip CreatePointBlip(Position position)
        {
            var ptr = CreatePointBlipPtr(out var id, position);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.Blip.Create(this, ptr, id);
        }

        public IntPtr CreateRadiusBlipPtr(out uint id, Position position, float radius)
        {
            unsafe
            {
                uint pId = default;
                var radiusBlip = Library.Client.Core_Client_CreateRadiusBlip(NativePointer, position, radius, Resource.NativePointer, &pId);
                id = pId;
                return radiusBlip;
            }
        }

        public IBlip CreateRadiusBlip(Position position, float radius)
        {
            var ptr = CreateRadiusBlipPtr(out var id, position, radius);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.Blip.Create(this, ptr, id);
        }

        public IntPtr CreateAreaBlipPtr(out uint id, Position position, int width, int height)
        {
            unsafe
            {
                uint pId = default;
                var ariaBlip = Library.Client.Core_Client_CreateAreaBlip(NativePointer, position, width, height, Resource.NativePointer, &pId);
                id = pId;
                return ariaBlip;
            }
        }

        public IBlip CreateAreaBlip(Position position, int width, int height)
        {
            var ptr = CreateAreaBlipPtr(out var id, position, width, height);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.Blip.Create(this, ptr, id);
        }

        public IntPtr CreateWebViewPtr(out uint id, string url, bool isOverlay = false, Vector2? pos = null, Vector2? size = null)
        {
            pos ??= Vector2.Zero;
            size ??= Vector2.Zero;

            unsafe
            {
                uint pId = default;
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var ptr = Library.Client.Core_CreateWebView(NativePointer, Resource.NativePointer, urlPtr, pos.Value, size.Value, (byte) (isOverlay ? 1 : 0), &pId);
                id = pId;
                Marshal.FreeHGlobal(urlPtr);
                return ptr;
            }
        }

        public IWebView CreateWebView(string url, bool isOverlay = false, Vector2? pos = null, Vector2? size = null)
        {
            var ptr = CreateWebViewPtr(out var id, url, isOverlay, pos, size);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.WebView.Create(this, ptr, id);
        }

        public IntPtr CreateWebViewPtr(out uint id, string url, uint propHash, string targetTexture)
        {
            unsafe
            {
                uint pId = default;
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var targetTexturePtr = MemoryUtils.StringToHGlobalUtf8(targetTexture);
                var ptr = Library.Client.Core_CreateWebView3D(NativePointer, Resource.NativePointer, urlPtr, propHash, targetTexturePtr, &pId);
                id = pId;
                Marshal.FreeHGlobal(urlPtr);
                Marshal.FreeHGlobal(targetTexturePtr);
                return ptr;
            }
        }

        public IWebView CreateWebView(string url, uint propHash, string targetTexture)
        {
            var ptr = CreateWebViewPtr(out var id, url, propHash, targetTexture);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.WebView.Create(this, ptr, id);
        }

        public IntPtr CreateRmlDocumentPtr(out uint id, string url)
        {
            unsafe
            {
                uint pId = default;
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var ptr = Library.Client.Core_CreateRmlDocument(NativePointer, Resource.NativePointer, urlPtr, &pId);
                id = pId;
                Marshal.FreeHGlobal(urlPtr);
                return ptr;
            }
        }

        public IRmlDocument CreateRmlDocument(string url)
        {
            var ptr = CreateRmlDocumentPtr(out var id, url);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.RmlDocument.Create(this, ptr, id);
        }

        public IntPtr CreateCheckpointPtr(out uint id, CheckpointType type, Vector3 pos, Vector3 nextPos, float radius, float height, Rgba color, uint streamingDistance)
        {
            unsafe
            {
                uint pId = default;
                var checkPoint = Library.Client.Core_CreateCheckpoint(NativePointer, (byte) type, pos, nextPos, radius, height, color, streamingDistance, Resource.NativePointer, &pId);
                id = pId;

                return checkPoint;
            }
        }

        public ICheckpoint CreateCheckpoint(CheckpointType type, Vector3 pos, Vector3 nextPos, float radius, float height, Rgba color, uint streamingDistance)
        {
            var ptr = CreateCheckpointPtr(out var id, type, pos, nextPos, radius, height, color, streamingDistance);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.Checkpoint.Create(this, ptr, id);
        }

        public IntPtr CreateAudioPtr(out uint id, string source, float volume, uint category, bool frontend)
        {
            unsafe
            {
                uint pId = default;
                var sourcePtr = MemoryUtils.StringToHGlobalUtf8(source);
                var ptr = Library.Client.Core_CreateAudio(NativePointer, Resource.NativePointer, sourcePtr, volume, category, (byte) (frontend ? 1 : 0), &pId);
                id = pId;
                Marshal.FreeHGlobal(sourcePtr);
                return ptr;
            }
        }

        public IAudio CreateAudio(string source, float volume, uint category, bool frontend)
        {
            var ptr = CreateAudioPtr(out var id, source, volume, category, frontend);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.Audio.Create(this, ptr, id);
        }

        public IntPtr CreateObjectPtr(out uint id, uint modelHash, Position position, Rotation rotation, bool noOffset = false,
            bool dynamic = false)
        {
            unsafe
            {
                ushort pId = default;
                var ptr = Library.Client.Core_CreateObject(NativePointer, modelHash, position, rotation, (byte) (noOffset ? 1 : 0), (byte) (dynamic ? 1 : 0), Resource.NativePointer, &pId);
                id = pId;
                return ptr;
            }
        }

        public IObject CreateObject(uint modelHash, Position position, Rotation rotation, bool noOffset = false, bool dynamic = false)
        {
            var ptr = CreateObjectPtr(out var id, modelHash, position, rotation, noOffset, dynamic);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.Object.Create(this, ptr, id);
        }

        public IntPtr CreateHttpClientPtr(out uint id)
        {
            unsafe
            {
                uint pId = default;
                var httpClient = Library.Client.Core_CreateHttpClient(NativePointer, Resource.NativePointer, &pId);
                id = pId;

                return httpClient;
            }
        }

        public IHttpClient CreateHttpClient()
        {
            var ptr = CreateHttpClientPtr(out var id);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.HttpClient.Create(this, ptr, id);
        }

        public IntPtr CreateWebSocketClientPtr(out uint id, string url)
        {
            unsafe
            {
                uint pId = default;
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var ptr = Library.Client.Core_CreateWebsocketClient(NativePointer, Resource.NativePointer, urlPtr,
                    &pId);
                id = pId;
                Marshal.FreeHGlobal(urlPtr);
                return ptr;
            }
        }

        public IWebSocketClient CreateWebSocketClient(string url)
        {
            var ptr = CreateWebSocketClientPtr(out var id, url);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.WebSocketClient.Create(this, ptr, id);
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

        public void TriggerServerEventUnreliable(string eventName, MValueConst[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerServerEventUnreliable(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerServerEventUnreliable(IntPtr eventNamePtr, MValueConst[] args)
        {
            var size = args.Length;
            var mValuePointers = new IntPtr[size];
            for (var i = 0; i < size; i++)
            {
                mValuePointers[i] = args[i].nativePointer;
            }

            TriggerServerEventUnreliable(eventNamePtr, mValuePointers);
        }

        public void TriggerServerEventUnreliable(string eventName, IntPtr[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerServerEventUnreliable(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TriggerServerEventUnreliable(IntPtr eventNamePtr, IntPtr[] args)
        {
            unsafe
            {
                Library.Client.Core_TriggerServerEventUnreliable(NativePointer, eventNamePtr, args, args.Length);
            }
        }

        public void TriggerServerEventUnreliable(IntPtr eventNamePtr, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerServerEventUnreliable(eventNamePtr, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerServerEventUnreliable(string eventName, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerServerEventUnreliable(eventName, mValues);
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

        public IReadOnlyCollection<IObject> GetAllObjects()
        {
            unsafe
            {
                CheckIfCallIsValid();
                uint size = 0;
                var ptr = Library.Client.Core_GetObjects(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => PoolManager.Object.GetOrCreate(this, e)).ToArray();
                Library.Shared.FreeObjectArray(ptr);
                return arr;
            }
        }

        public IntPtr CreateTextLabelPtr(out uint id, string name, string fontName, float fontSize, float scale, Position pos, Rotation rot, Rgba color, float outlineWidth, Rgba outlineColor)
        {
            unsafe
            {
                uint pId = default;
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var fontSizePtr = MemoryUtils.StringToHGlobalUtf8(fontName);
                var textLabelMarker = Library.Client.Core_CreateTextLabel(NativePointer, namePtr, fontSizePtr, fontSize, scale, pos, rot, color, outlineWidth, outlineColor, Resource.NativePointer, &pId);
                id = pId;
                Marshal.FreeHGlobal(namePtr);
                Marshal.FreeHGlobal(fontSizePtr);
                return textLabelMarker;
            }
        }

        public IntPtr CreateVirtualEntityEntity(out uint id, IVirtualEntityGroup group, Position position, uint streamingDistance,
            Dictionary<string, object> dataDict)
        {
            unsafe
            {
                var data = new Dictionary<IntPtr, MValueConst>();

                foreach (var dataValue in dataDict)
                {
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(dataValue.Key);
                    Alt.Core.CreateMValue(out var mValue, dataValue);
                    data.Add(stringPtr, mValue);
                }

                uint pId = default;
                var ptr = Library.Shared.Core_CreateVirtualEntity(NativePointer, group.NativePointer, position, streamingDistance, data.Keys.ToArray(), data.Values.Select(x => x.nativePointer).ToArray(), (uint)data.Count, &pId);
                id = pId;

                foreach (var dataValue in data)
                {
                    dataValue.Value.Dispose();
                    Marshal.FreeHGlobal(dataValue.Key);
                }

                return ptr;
            }
        }

        public IntPtr CreateVirtualEntityGroupEntity(out uint id, uint streamingDistance)
        {
            unsafe
            {
                uint pId = default;
                var ptr = Library.Shared.Core_CreateVirtualEntityGroup(NativePointer, streamingDistance, &pId);
                id = pId;
                return ptr;
            }
        }

        public IntPtr CreateLocalVehiclePtr(out uint id, uint modelHash, int dimension, Position position, Rotation rotation,
            bool useStreaming, uint streamingDistance)
        {
            unsafe
            {
                uint pId = default;
                var ptr = Library.Client.Core_CreateLocalVehicle(NativePointer, modelHash, dimension, position, rotation, useStreaming ? (byte)1:(byte)0, streamingDistance, Resource.NativePointer, &pId);
                id = pId;
                return ptr;
            }
        }

        public IntPtr CreateLocalPedPtr(out uint id, uint modelHash, int dimension, Position position, Rotation rotation,
            bool useStreaming, uint streamingDistance)
        {
            unsafe
            {
                uint pId = default;
                var ptr = Library.Client.Core_CreateLocalPed(NativePointer, modelHash, dimension, position, rotation, useStreaming ? (byte)1:(byte)0, streamingDistance, Resource.NativePointer, &pId);
                id = pId;
                return ptr;
            }
        }

        public IReadOnlyCollection<IObject> GetAllWorldObjects()
        {
            unsafe
            {
                CheckIfCallIsValid();
                uint size = 0;
                var ptr = Library.Client.Core_GetWorldObjects(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => PoolManager.Object.GetOrCreate(this, e)).ToArray();
                Library.Shared.FreeObjectArray(ptr);
                return arr;
            }
        }

        public Vector3 PedBonesPosition(int scriptId, ushort boneId)
        {
            unsafe
            {
                var vec = Vector3.Zero;
                Library.Client.Core_GetPedBonePos(NativePointer, scriptId, boneId, &vec);
                return vec;
            }
        }
    }
}