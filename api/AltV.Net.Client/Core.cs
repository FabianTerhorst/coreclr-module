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

        public IReadOnlyCollection<IObject> GetAllNetworkObjects()
        {
            unsafe
            {
                CheckIfCallIsValid();
                ulong size = 0;
                var ptr = Library.Shared.Core_GetNetworkObjects(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int)size);
                var arr = data.Select(e => PoolManager.Object.GetOrCreate(this, e)).ToArray();
                Library.Shared.FreeNetworkObjectArray(ptr);
                return arr;
            }
        }

        public IReadOnlyCollection<IColShape> GetAllColShapes()
        {
            unsafe
            {
                CheckIfCallIsValid();
                ulong size = 0;
                var ptr = Library.Shared.Core_GetColShapes(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int)size);
                var arr = data.Select(e => PoolManager.ColShape.GetOrCreate(this, e)).ToArray();
                Library.Shared.FreeColShapeArray(ptr);
                return arr;
            }
        }

        public IReadOnlyCollection<IMarker> GetAllMarkers()
        {
            unsafe
            {
                CheckIfCallIsValid();
                ulong size = 0;
                var ptr = Library.Shared.Core_GetMarkers(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int)size);
                var arr = data.Select(e => PoolManager.Marker.GetOrCreate(this, e)).ToArray();
                Library.Shared.FreeMarkerArray(ptr);
                return arr;
            }
        }

        public IReadOnlyCollection<ITextLabel> GetAllTextLabels()
        {
            unsafe
            {
                CheckIfCallIsValid();
                ulong size = 0;
                var ptr = Library.Shared.Core_GetMarkers(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int)size);
                var arr = data.Select(e => PoolManager.TextLabel.GetOrCreate(this, e)).ToArray();
                Library.Shared.FreeTextLabelArray(ptr);
                return arr;
            }
        }

        public IntPtr CreateMarkerPtr(out uint id, MarkerType type, Position pos, Rgba color, bool useStreaming, uint streamingDistance)
        {
            unsafe
            {
                uint pId = default;
                var markerPoint = Library.Client.Core_CreateMarker_Client(NativePointer, (byte)type, pos, color, useStreaming ? (byte)1:(byte)0, streamingDistance, Resource.NativePointer, &pId);
                id = pId;
                return markerPoint;
            }
        }

        public new IBaseObject GetBaseObjectById(BaseObjectType type, uint id)
        {
            return (IBaseObject) base.GetBaseObjectById(type, id);
        }

        public HandlingData? GetHandlingByModelHash(uint modelHash)
        {
            return new HandlingData(this, modelHash);
        }

        public AudioCategory GetAudioCategoryByName(string audioCategory)
        {
            return new AudioCategory(this, audioCategory);
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

        public IntPtr CreateCheckpointPtr(out uint id, CheckpointType type, Vector3 pos, Vector3 nextPos, float radius, float height, Rgba color, Rgba iconColor, uint streamingDistance)
        {
            unsafe
            {
                uint pId = default;
                var checkPoint = Library.Client.Core_CreateCheckpoint(NativePointer, (byte) type, pos, nextPos, radius, height, color, iconColor, streamingDistance, Resource.NativePointer, &pId);
                id = pId;

                return checkPoint;
            }
        }

        public ICheckpoint CreateCheckpoint(CheckpointType type, Vector3 pos, Vector3 nextPos, float radius, float height, Rgba color, Rgba iconColor, uint streamingDistance)
        {
            var ptr = CreateCheckpointPtr(out var id, type, pos, nextPos, radius, height, color, iconColor, streamingDistance);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.Checkpoint.Create(this, ptr, id);
        }

        public IntPtr CreateAudioPtr(out uint id, string source, float volume, bool isRadio = false, bool clearCache = true, string basePath = "")
        {
            unsafe
            {
                uint pId = default;
                var sourcePtr = MemoryUtils.StringToHGlobalUtf8(source);
                var basePathPtr = MemoryUtils.StringToHGlobalUtf8(basePath);
                var ptr = Library.Client.Core_CreateAudio(NativePointer, sourcePtr, volume, isRadio ? (byte)1 : (byte)0, clearCache ? (byte)1 : (byte)0, basePathPtr, Resource.NativePointer,  &pId);
                id = pId;
                Marshal.FreeHGlobal(basePathPtr);
                Marshal.FreeHGlobal(sourcePtr);
                return ptr;
            }
        }

        public IAudio CreateAudio(string source, float volume, bool isRadio = false, bool clearCache = true, string basePath = "")
        {
            var ptr = CreateAudioPtr(out var id, source, volume, isRadio, clearCache, basePath);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.Audio.Create(this, ptr, id);
        }

        public IntPtr CreateAudioFilterPtr(out uint id, uint hash)
        {
            unsafe
            {
                uint pId = default;
                var ptr = Library.Client.Core_CreateAudioFilter(NativePointer, hash, Resource.NativePointer,  &pId);
                id = pId;
                return ptr;
            }
        }

        public IntPtr CreateFrontendOutputPtr(out uint id, uint categoryHash)
        {
            unsafe
            {
                uint pId = default;
                var ptr = Library.Client.Core_CreateFrontendOutput(NativePointer, categoryHash, Resource.NativePointer,  &pId);
                id = pId;
                return ptr;
            }
        }

        public IntPtr CreateWorldOutputPtr(out uint id, uint categoryHash, Position pos)
        {
            unsafe
            {
                uint pId = default;
                var ptr = Library.Client.Core_CreateWorldOutput(NativePointer, categoryHash, pos, Resource.NativePointer,  &pId);
                id = pId;
                return ptr;
            }
        }

        public IntPtr CreateAttachedOutputPtr(out uint id, uint categoryHash, IWorldObject worldObject)
        {
            unsafe
            {
                uint pId = default;
                var ptr = Library.Client.Core_CreateAttachedOutput(NativePointer, categoryHash, worldObject.WorldObjectNativePointer, Resource.NativePointer,  &pId);
                id = pId;
                return ptr;
            }
        }

        public IAudioFilter CreateAudioFilter(uint hash)
        {
            var ptr = CreateAudioFilterPtr(out var id, hash);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.AudioFilter.Create(this, ptr, id);
        }

        public IAudioOutputFrontend CreateAudioOutputFrontend(uint categoryHash)
        {
            var ptr = CreateFrontendOutputPtr(out var id, categoryHash);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.AudioOutputFrontend.Create(this, ptr, id);
        }

        public IAudioOutputWorld CreateAudioOutputWorld(uint categoryHash, Position pos)
        {
            var ptr = CreateWorldOutputPtr(out var id, categoryHash, pos);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.AudioOutputWorld.Create(this, ptr, id);
        }

        public IAudioOutputAttached CreateAudioOutputAttached(uint categoryHash, IWorldObject worldObject)
        {
            var ptr = CreateAttachedOutputPtr(out var id, categoryHash, worldObject);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.AudioOutputAttached.Create(this, ptr, id);
        }

        public WeaponData[] GetAllWeaponData()
        {
            unsafe
            {
                CheckIfCallIsValid();
                var weaponDataCount = Library.Client.Core_GetAllWeaponDataCount(NativePointer);
                var weaponHashes = new uint[weaponDataCount];
                Library.Client.Core_GetAllWeaponData(NativePointer, weaponHashes, weaponDataCount);
                var weaponDatas = new WeaponData[weaponDataCount];
                for (ulong i = 0; i < weaponDataCount; i++)
                {
                    var weaponHash = weaponHashes[i];
                    weaponDatas[i] = new WeaponData(this, weaponHash);
                }

                return weaponDatas;
            }
        }

        public IntPtr CreateLocalObjectPtr(out uint id, uint modelHash, Position position, Rotation rotation, bool noOffset = false,
            bool dynamic = false, bool useStreaming = false, uint streamingDistance = 0)
        {
            unsafe
            {
                uint pId = default;
                var ptr = Library.Client.Core_CreateLocalObject(NativePointer, modelHash, position, rotation, (byte) (noOffset ? 1 : 0), (byte) (dynamic ? 1 : 0), (byte) (useStreaming ? 1 : 0), streamingDistance, Resource.NativePointer, &pId);
                id = pId;
                return ptr;
            }
        }

        public ILocalObject CreateLocalObject(uint modelHash, Position position, Rotation rotation, bool noOffset = false, bool dynamic = false, bool useStreaming = false, uint streamingDistance = 0)
        {
            var ptr = CreateLocalObjectPtr(out var id, modelHash, position, rotation, noOffset, dynamic, useStreaming, streamingDistance);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.LocalObject.Create(this, ptr, id);
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

        public IntPtr CreateColShapeCirclePtr(out uint id, Position position, float radius)
        {
            unsafe
            {
                uint pId = default;
                var colShapeCircle = Library.Shared.Core_CreateColShapeCircle(NativePointer, position, radius, &pId);
                id = pId;
                return colShapeCircle;
            }
        }

        public IColShape CreateColShapeCircle(Position position, float radius)
        {
            var ptr = CreateColShapeCirclePtr(out var id, position, radius);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.ColShape.Create(this, ptr, id);
        }

        public IntPtr CreateColShapeCubePtr(out uint id, Position pos1, Position pos2)
        {
            unsafe
            {
                uint pId = default;
                var colShapeCube = Library.Shared.Core_CreateColShapeCube(NativePointer, pos1, pos2, &pId);
                id = pId;
                return colShapeCube;
            }
        }

        public IColShape CreateColShapeCube(Position pos1, Position pos2)
        {
            var ptr = CreateColShapeCubePtr(out var id, pos1, pos2);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.ColShape.Create(this, ptr, id);
        }

        public IntPtr CreateColShapeCylinderPtr(out uint id, Position position, float radius, float height)
        {
            unsafe
            {
                uint pId = default;
                var colShapeCylinder = Library.Shared.Core_CreateColShapeCylinder(NativePointer, position, radius, height, &pId);
                id = pId;
                return colShapeCylinder;
            }
        }

        public IColShape CreateColShapeCylinder(Position position, float radius, float height)
        {
            var ptr = CreateColShapeCylinderPtr(out var id, position, radius, height);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.ColShape.Create(this, ptr, id);
        }

        public IntPtr CreateColShapePolygonPtr(out uint id, float minZ, float maxZ, Vector2[] points)
        {
            unsafe
            {
                uint pId = default;
                var colShapePolygon = Library.Shared.Core_CreateColShapePolygon(NativePointer, minZ, maxZ, points, points.Length, &pId);
                id = pId;
                return colShapePolygon;
            }
        }

        public IColShape CreateColShapePolygon(float minZ, float maxZ, Vector2[] points)
        {
            var ptr = CreateColShapePolygonPtr(out var id, minZ, maxZ, points);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.ColShape.Create(this, ptr, id);
        }

        public IntPtr CreateColShapeRectanglePtr(out uint id, float x1, float y1, float x2, float y2, float z)
        {
            unsafe
            {
                uint pId = default;
                var colShapeRectangle = Library.Shared.Core_CreateColShapeRectangle(NativePointer, x1, y1, x2, y2, z, &pId);
                id = pId;
                return colShapeRectangle;
            }
        }

        public IColShape CreateColShapeRectangle(float x1, float y1, float x2, float y2, float z)
        {
            var ptr = CreateColShapeRectanglePtr(out var id, x1, y1, x2, y2, z);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.ColShape.Create(this, ptr, id);
        }

        public IntPtr CreateColShapeSpherePtr(out uint id, Vector3 position, float radius)
        {
            unsafe
            {
                uint pId = default;
                var colShapeSphere = Library.Shared.Core_CreateColShapeSphere(NativePointer, position, radius, &pId);
                id = pId;
                return colShapeSphere;
            }
        }

        public IColShape CreateColShapeSphere(Vector3 position, float radius)
        {
            var ptr = CreateColShapeSpherePtr(out var id, position, radius);
            if (ptr == IntPtr.Zero) return null;
            return PoolManager.ColShape.Create(this, ptr, id);
        }

        public void UpdateClipContext(Dictionary<string, string> context)
        {
            unsafe
            {
                var data = new Dictionary<IntPtr, IntPtr>();

                var keys = new IntPtr[context.Count];
                var values = new IntPtr[context.Count];

                for (var i = 0; i < context.Count; i++)
                {
                    var keyptr = MemoryUtils.StringToHGlobalUtf8(context.ElementAt(i).Key);
                    var valueptr = MemoryUtils.StringToHGlobalUtf8(context.ElementAt(i).Value);
                    keys[i] = keyptr;
                    values[i] = valueptr;
                    data.Add(keyptr, valueptr);
                }

                Library.Client.Core_UpdateClipContext(NativePointer, keys, values,(uint)data.Count);

                foreach (var dataValue in data)
                {
                    Marshal.FreeHGlobal(dataValue.Key);
                    Marshal.FreeHGlobal(dataValue.Value);
                }
            }
        }

        public ulong ServerTime
        {
            get
            {
                unsafe
                {
                    return this.Library.Client.Core_GetServerTime(NativePointer);
                }
            }
        }

        #endregion

        #region TriggerServerEvent

        public void TriggerServerEvent(string eventName, MValueConst[] args)
        {
            var eventNamePtr = MemoryUtils.StringToHGlobalUtf8(eventName);
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
            var eventNamePtr = MemoryUtils.StringToHGlobalUtf8(eventName);
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

        public ushort TriggerServerRPCEvent(string name, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            var result = TriggerServerRPCEvent(name, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }

            return result;
        }

        public ushort TriggerServerRPCEvent(string eventName, MValueConst[] args)
        {
            var eventNamePtr = MemoryUtils.StringToHGlobalUtf8(eventName);
            var result = TriggerServerRPCEvent(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
            return result;
        }

        public ushort TriggerServerRPCEvent(IntPtr eventNamePtr, MValueConst[] args)
        {
            var size = args.Length;
            var mValuePointers = new IntPtr[size];
            for (var i = 0; i < size; i++)
            {
                mValuePointers[i] = args[i].nativePointer;
            }

            return TriggerServerRPCEvent(eventNamePtr, mValuePointers);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort TriggerServerRPCEvent(IntPtr eventNamePtr, IntPtr[] args)
        {
            unsafe
            {
                return Library.Client.Core_TriggerServerRPCEvent(NativePointer, eventNamePtr, args, args.Length);
            }
        }

        public void TriggerServerRPCAnswer(ushort answerId, object answer, string error)
        {
            CreateMValue(out var mValue, answer);
            TriggerServerRPCAnswer(answerId, mValue, error);
            mValue.Dispose();
        }

        public void TriggerServerRPCAnswer(ushort answerId, MValueConst answer, string error)
        {
            unsafe
            {
                var errorPtr = MemoryUtils.StringToHGlobalUtf8(error);
                Library.Client.Core_TriggerServerRPCAnswer(NativePointer, answerId, answer.nativePointer, errorPtr);
                Marshal.FreeHGlobal(errorPtr);
            }

            if (UnansweredClientRpcRequest.Contains(answerId))
            {
                UnansweredClientRpcRequest.Remove(answerId);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort TriggerServerRPCAnswerEvent(IntPtr eventNamePtr, IntPtr[] args)
        {
            unsafe
            {
                return Library.Client.Core_TriggerServerRPCEvent(NativePointer, eventNamePtr, args, args.Length);
            }
        }

        public void TriggerServerEventUnreliable(string eventName, MValueConst[] args)
        {
            var eventNamePtr = MemoryUtils.StringToHGlobalUtf8(eventName);
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
            var eventNamePtr = MemoryUtils.StringToHGlobalUtf8(eventName);
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

        public IReadOnlyCollection<ILocalObject> GetAllLocalObjects()
        {
            unsafe
            {
                CheckIfCallIsValid();
                uint size = 0;
                var ptr = Library.Client.Core_GetLocalObjects(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int)size);
                var arr = data.Select(e => PoolManager.LocalObject.GetOrCreate(this, e)).ToArray();
                Library.Shared.FreeLocalObjectArray(ptr);
                return arr;
            }
        }

        public IReadOnlyCollection<ILocalVehicle> GetAllLocalVehicles()
        {
            unsafe
            {
                CheckIfCallIsValid();
                uint size = 0;
                var ptr = Library.Client.Core_GetLocalVehicles(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int)size);
                var arr = data.Select(e => PoolManager.LocalVehicle.GetOrCreate(this, e)).ToArray();
                Library.Client.FreeLocalVehicleArray(ptr);
                return arr;
            }
        }

        public IReadOnlyCollection<ILocalPed> GetAllLocalPeds()
        {
            unsafe
            {
                CheckIfCallIsValid();
                uint size = 0;
                var ptr = Library.Client.Core_GetLocalPeds(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int)size);
                var arr = data.Select(e => PoolManager.LocalPed.GetOrCreate(this, e)).ToArray();
                Library.Client.FreeLocalPedArray(ptr);
                return arr;
            }
        }

        public IBlip GetBlipByGameId(uint gameId)
        {
            unsafe
            {
                var blipPtr = Library.Client.Core_GetBlipByGameID(NativePointer, gameId);

                if (blipPtr == IntPtr.Zero) return null;
                return PoolManager.Blip.GetOrCreate(this, blipPtr);
            }
        }

        public ICheckpoint GetCheckpointByGameID(uint gameId)
        {
            unsafe
            {
                var checkpointPtr = Library.Client.Core_GetCheckpointByGameID(NativePointer, gameId);

                if (checkpointPtr == IntPtr.Zero) return null;
                return PoolManager.Checkpoint.GetOrCreate(this, checkpointPtr);
            }
        }

        public bool IsWebViewGpuAccelerationActive
        {
            get
            {
                unsafe
                {
                    return Library.Client.Core_IsWebViewGpuAccelerationActive(NativePointer) == 1;
                }
            }
        }

        public IWorldObject GetWorldObjectByScriptID(BaseObjectType type, uint scriptId)
        {
            unsafe
            {
                var wordlObjectPtr = Library.Client.Core_GetWorldObjectByScriptID(NativePointer, scriptId);
                if (wordlObjectPtr == IntPtr.Zero) return null;
                return (IWorldObject) PoolManager.Get(wordlObjectPtr, type);
            }
        }

        public IVirtualEntityGroup CreateVirtualEntityGroup(uint streamingDistance)
        {
            unsafe
            {
                CheckIfCallIsValid();

                uint pId = default;
                var ptr = Library.Shared.Core_CreateVirtualEntityGroup(NativePointer, streamingDistance, &pId);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.VirtualEntityGroup.GetOrCreate(this, ptr, pId);
            }
        }

        public IVirtualEntity CreateVirtualEntity(IVirtualEntityGroup group, Position position, uint streamingDistance,
            Dictionary<string, object> dataDict)
        {
            unsafe
            {
                CheckIfCallIsValid();

                var data = new Dictionary<IntPtr, MValueConst>();

                var keys = new IntPtr[dataDict.Count];
                var values = new IntPtr[dataDict.Count];

                for (var i = 0; i < dataDict.Count; i++)
                {
                    var stringPtr = MemoryUtils.StringToHGlobalUtf8(dataDict.ElementAt(i).Key);
                    Alt.Core.CreateMValue(out var mValue, dataDict.ElementAt(i).Value);
                    keys[i] = stringPtr;
                    values[i] = mValue.nativePointer;
                    data.Add(stringPtr, mValue);
                }

                uint pId = default;
                var ptr = Library.Shared.Core_CreateVirtualEntity(NativePointer, group.VirtualEntityGroupNativePointer, position, streamingDistance, keys, values, (uint)data.Count, &pId);

                foreach (var dataValue in data)
                {
                    dataValue.Value.Dispose();
                    Marshal.FreeHGlobal(dataValue.Key);
                }
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.VirtualEntity.GetOrCreate(this, ptr, pId);
            }
        }

        public ILocalPed CreateLocalPed(uint modelHash, int dimension, Position position, Rotation rotation, bool useStreaming,
            uint streamingDistance)
        {
            unsafe
            {
                CheckIfCallIsValid();

                uint pId = default;
                var ptr = Library.Client.Core_CreateLocalPed(NativePointer, modelHash, dimension, position, rotation,
                    useStreaming ? (byte)1 : (byte)0, streamingDistance, Resource.NativePointer, &pId);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.LocalPed.GetOrCreate(this, ptr, pId);
            }
        }

        public ILocalVehicle CreateLocalVehicle(uint modelHash, int dimension, Position position, Rotation rotation, bool useStreaming,
            uint streamingDistance)
        {
            unsafe
            {
                CheckIfCallIsValid();

                uint pId = default;
                var ptr = Library.Client.Core_CreateLocalVehicle(NativePointer, modelHash, dimension, position, rotation,
                    useStreaming ? (byte)1 : (byte)0, streamingDistance, Resource.NativePointer, &pId);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.LocalVehicle.GetOrCreate(this, ptr, pId);
            }
        }

        public IMarker CreateMarker(MarkerType type, Position pos, Rgba color, bool useStreaming, uint streamingDistance)
        {
            unsafe
            {
                uint pId = default;
                var ptr = Library.Client.Core_CreateMarker_Client(NativePointer, (byte)type, pos, color,
                    useStreaming ? (byte)1 : (byte)0, streamingDistance, Resource.NativePointer, &pId);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.Marker.GetOrCreate(this, ptr, pId);
            }
        }

        public ITextLabel CreateTextLabel(string name, string fontName, float fontSize, float scale, Position pos, Rotation rot,
            Rgba color, float outlineWidth, Rgba outlineColor, bool useStreaming, uint streamingDistance)
        {
            unsafe
            {
                uint pId = default;
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                var fontSizePtr = MemoryUtils.StringToHGlobalUtf8(fontName);

                var ptr = Library.Client.Core_CreateTextLabel(NativePointer, namePtr, fontSizePtr, fontSize, scale, pos, rot, color, outlineWidth, outlineColor,
                    useStreaming ? (byte)1:(byte)0, streamingDistance, Resource.NativePointer, &pId);

                Marshal.FreeHGlobal(namePtr);
                Marshal.FreeHGlobal(fontSizePtr);

                if (ptr == IntPtr.Zero) return null;
                return PoolManager.TextLabel.GetOrCreate(this, ptr, pId);
            }
        }

        public IReadOnlyCollection<ILocalObject> GetAllWorldObjects()
        {
            unsafe
            {
                CheckIfCallIsValid();
                uint size = 0;
                var ptr = Library.Client.Core_GetWorldObjects(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => PoolManager.LocalObject.GetOrCreate(this, e)).ToArray();
                Library.Shared.FreeLocalObjectArray(ptr);
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