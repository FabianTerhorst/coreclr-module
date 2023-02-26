using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Text;
using System.Threading;
using AltV.Net.CApi;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Events;
using AltV.Net.Exceptions;
using AltV.Net.FunctionParser;
using AltV.Net.Native;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Data;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Shared.Events;
using AltV.Net.Types;

namespace AltV.Net
{
    public partial class Core : SharedCore, ICore, IInternalCore, IDisposable
    {
        public override IBaseBaseObjectPool BaseBaseObjectPool { get;}
        IReadOnlyBaseBaseObjectPool ISharedCore.BaseBaseObjectPool => BaseBaseObjectPool;

        public IBaseEntityPool BaseEntityPool { get; }

        public override IEntityPool<IPlayer> PlayerPool { get; }
        IReadOnlyEntityPool<ISharedPlayer> ISharedCore.PlayerPool => PlayerPool;

        public override IEntityPool<IObject> ObjectPool { get; }
        IReadOnlyEntityPool<ISharedObject> ISharedCore.ObjectPool => ObjectPool;

        public override IEntityPool<IVehicle> VehiclePool { get; }
        IReadOnlyEntityPool<ISharedVehicle> ISharedCore.VehiclePool => VehiclePool;

        public override IBaseObjectPool<IBlip> BlipPool { get; }

        public override IBaseObjectPool<ICheckpoint> CheckpointPool { get; }

        public IBaseObjectPool<IVoiceChannel> VoiceChannelPool { get; }

        public IBaseObjectPool<IColShape> ColShapePool { get; }

        public INativeResourcePool NativeResourcePool { get; }

        private readonly ConcurrentDictionary<uint, VehicleModelInfo> vehicleModelInfoCache;
        private readonly ConcurrentDictionary<uint, PedModelInfo?> pedModelInfoCache;

        public int NetTime
        {
            get
            {
                unsafe
                {
                    return Library.Server.Core_GetNetTime(NativePointer);
                }
            }
        }

        private string rootDirectory;

        public string RootDirectory
        {
            get
            {
                unsafe
                {
                    if (rootDirectory != null) return rootDirectory;
                    var size = 0;
                    rootDirectory = PtrToStringUtf8AndFree(Library.Server.Core_GetRootDirectory(NativePointer, &size), size);

                    return rootDirectory;
                }
            }
        }

        public override INativeResource Resource { get; }

        public Core(IntPtr nativePointer, IntPtr resourcePointer, AssemblyLoadContext assemblyLoadContext, ILibrary library, IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool,
            IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool,
            INativeResourcePool nativeResourcePool) : base(nativePointer, library)
        {
            this.assemblyLoadContext = new WeakReference<AssemblyLoadContext>(assemblyLoadContext);
            this.BaseBaseObjectPool = baseBaseObjectPool;
            this.BaseEntityPool = baseEntityPool;
            this.PlayerPool = playerPool;
            this.VehiclePool = vehiclePool;
            this.BlipPool = blipPool;
            this.CheckpointPool = checkpointPool;
            this.VoiceChannelPool = voiceChannelPool;
            this.ColShapePool = colShapePool;
            this.NativeResourcePool = nativeResourcePool;
            this.vehicleModelInfoCache = new();
            this.pedModelInfoCache = new();
            nativeResourcePool.GetOrCreate(this, resourcePointer, out var resource);
            Resource = resource;
        }

        void IInternalCore.InitResource(INativeResource resource)
        {
        }

        public override void CheckIfCallIsValid([CallerMemberName] string callerName = "")
        {
        }

        [Conditional("DEBUG")]
        public void CheckIfThreadIsValid([CallerMemberName] string callerName = "")
        {
            if (IsMainThread()) return;
            throw new IllegalThreadException(this, callerName);
        }

        public ulong HashPassword(string password)
        {
            unsafe
            {
                var passwordPtr = AltNative.StringUtils.StringToHGlobalUtf8(password);
                var value = Library.Server.Core_HashPassword(NativePointer, passwordPtr);
                Marshal.FreeHGlobal(passwordPtr);
                return value;
            }
        }

        public void SetPassword(string password)
        {
            unsafe
            {
                var passwordPtr = AltNative.StringUtils.StringToHGlobalUtf8(password);
                Library.Server.Core_SetPassword(NativePointer, passwordPtr);
                Marshal.FreeHGlobal(passwordPtr);
            }
        }

        public VehicleModelInfo GetVehicleModelInfo(uint hash)
        {
            return this.vehicleModelInfoCache.GetOrAdd(hash, u =>
            {
                unsafe
                {
                    var ptr = Library.Server.Core_GetVehicleModelInfo(NativePointer, u);
                    var structure = Marshal.PtrToStructure<VehicleModelInfo>(ptr);
                    Library.Server.Core_DeallocVehicleModelInfo(ptr);
                    return structure;
                }
            });
        }

        public PedModelInfo? GetPedModelInfo(uint hash)
        {
            return this.pedModelInfoCache.GetOrAdd(hash, u =>
            {
                unsafe
                {
                    var ptr = Library.Server.Core_GetPedModelInfo(NativePointer, u);
                    var structure = Marshal.PtrToStructure<PedModelInfoInternal>(ptr);
                    var publicStructure = structure.ToPublic();
                    Library.Server.Core_DeallocPedModelInfo(ptr);
                    return publicStructure.Hash == 0 ? null : publicStructure;
                }
            });
        }

        public void StopServer()
        {
            unsafe
            {
                Library.Server.Core_StopServer(NativePointer);
            }
        }

        #region TriggerClientEvent
        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, MValueConst[] args)
        {
            var size = args.Length;
            var mValuePointers = new IntPtr[size];
            for (var i = 0; i < size; i++)
            {
                mValuePointers[i] = args[i].nativePointer;
            }

            TriggerClientEvent(player, eventNamePtr, mValuePointers);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, MValueConst[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEvent(player, eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, IntPtr[] args)
        {
            unsafe
            {
                Library.Server.Core_TriggerClientEvent(NativePointer, player.PlayerNativePointer,
                    eventNamePtr, args, args.Length);
            }
        }

        public void TriggerClientEvent(IPlayer player, string eventName, IntPtr[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEvent(player, eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, params object[] args)
        {
            if (player == null) throw new ArgumentException("player should not be null.");
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerClientEvent(player, eventNamePtr, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params object[] args)
        {
            if (player == null) throw new ArgumentException("player should not be null.");
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerClientEvent(player, eventName, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerClientEventForAll(IntPtr eventNamePtr, MValueConst[] args)
        {
            unsafe
            {
                var size = args.Length;
                var mValuePointers = new IntPtr[size];
                for (var i = 0; i < size; i++)
                {
                    mValuePointers[i] = args[i].nativePointer;
                }

                Library.Server.Core_TriggerClientEventForAll(NativePointer, eventNamePtr, mValuePointers, args.Length);
            }
        }

        public void TriggerClientEventForAll(string eventName, MValueConst[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEventForAll(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerClientEventForAll(IntPtr eventNamePtr, IntPtr[] args)
        {
            unsafe
            {
                Library.Server.Core_TriggerClientEventForAll(NativePointer, eventNamePtr, args, args.Length);
            }
        }

        public void TriggerClientEventForAll(string eventName, IntPtr[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEventForAll(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerClientEventForAll(IntPtr eventNamePtr, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerClientEventForAll(eventNamePtr, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerClientEventForAll(string eventName, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerClientEventForAll(eventName, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerClientEventForSome(IPlayer[] clients, IntPtr eventNamePtr, MValueConst[] args)
        {
            var size = args.Length;
            var mValuePointers = new IntPtr[size];
            for (var i = 0; i < size; i++)
            {
                mValuePointers[i] = args[i].nativePointer;
            }

            TriggerClientEventForSome(clients, eventNamePtr, mValuePointers);
        }

        public void TriggerClientEventForSome(IPlayer[] clients, string eventName, MValueConst[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEventForSome(clients, eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TriggerClientEventForSome(IPlayer[] clients, IntPtr eventNamePtr, IntPtr[] args)
        {
            unsafe
            {
                var size = clients.Length;
                var clPtrs = new IntPtr[size];
                for (var i = 0; i < size; i++)
                {
                    clPtrs[i] = clients[i].PlayerNativePointer;
                }
                Library.Server.Core_TriggerClientEventForSome(NativePointer, clPtrs, size,
                    eventNamePtr, args, args.Length);
            }
        }

        public void TriggerClientEventForSome(IPlayer[] clients, string eventName, IntPtr[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEventForSome(clients, eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerClientEventForSome(IPlayer[] clients, IntPtr eventNamePtr, params object[] args)
        {
            if (clients == null) throw new ArgumentException("players should not be null.");
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerClientEventForSome(clients, eventNamePtr, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerClientEventForSome(IPlayer[] clients, string eventName, params object[] args)
        {
            if (clients == null) throw new ArgumentException("players should not be null.");
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerClientEventForSome(clients, eventName, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }
        #endregion

        #region BaseObject creation/removal
        public IVehicle CreateVehicle(uint model, Position pos, Rotation rotation)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                ushort id = default;
                var ptr = Library.Server.Core_CreateVehicle(NativePointer, model, pos, rotation, &id);
                if (ptr == IntPtr.Zero) return null;
                return VehiclePool.Create(this, ptr, id);
            }
        }

        public IntPtr CreateVehicleEntity(out ushort id, uint model, Position pos, Rotation rotation)
        {
            unsafe
            {
                CheckIfThreadIsValid();
                ushort pId;
                var pointer = Library.Server.Core_CreateVehicle(NativePointer, model, pos, rotation, &pId);
                id = pId;
                return pointer;
            }
        }

        public ICheckpoint CreateCheckpoint(byte type, Position pos, float radius, float height,
            Rgba color)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                var ptr = Library.Server.Core_CreateCheckpoint(NativePointer, type, pos, radius, height, color);
                if (ptr == IntPtr.Zero) return null;
                return CheckpointPool.Create(this, ptr);
            }
        }

        public IBlip CreateBlip(IPlayer player, byte type, Position pos)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                var ptr = Library.Server.Core_CreateBlip(NativePointer, player?.PlayerNativePointer ?? IntPtr.Zero,
                    type, pos);
                if (ptr == IntPtr.Zero) return null;
                return BlipPool.Create(this, ptr);
            }
        }

        public IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();

                var ptr = Library.Server.Core_CreateBlipAttached(NativePointer,
                    player?.PlayerNativePointer ?? IntPtr.Zero,
                    type, entityAttach.EntityNativePointer);
                if (ptr == IntPtr.Zero) return null;
                return BlipPool.Create(this, ptr);
            }
        }

        public IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                var ptr = Library.Server.Core_CreateVoiceChannel(NativePointer,
                    spatial ? (byte) 1 : (byte) 0, maxDistance);
                if (ptr == IntPtr.Zero) return null;
                return VoiceChannelPool.Create(this, ptr);
            }
        }

        public IColShape CreateColShapeCylinder(Position pos, float radius, float height)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                var ptr = Library.Server.Core_CreateColShapeCylinder(NativePointer, pos, radius, height);
                if (ptr == IntPtr.Zero) return null;
                return ColShapePool.Create(this, ptr);
            }
        }

        public IColShape CreateColShapeSphere(Position pos, float radius)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                var ptr = Library.Server.Core_CreateColShapeSphere(NativePointer, pos, radius);
                if (ptr == IntPtr.Zero) return null;
                return ColShapePool.Create(this, ptr);
            }
        }

        public IColShape CreateColShapeCircle(Position pos, float radius)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                var ptr = Library.Server.Core_CreateColShapeCircle(NativePointer, pos, radius);
                if (ptr == IntPtr.Zero) return null;
                return ColShapePool.Create(this, ptr);
            }
        }

        public IColShape CreateColShapeCube(Position pos, Position pos2)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                var ptr = Library.Server.Core_CreateColShapeCube(NativePointer, pos, pos2);
                if (ptr == IntPtr.Zero) return null;
                return ColShapePool.Create(this, ptr);
            }
        }

        public IColShape CreateColShapeRectangle(float x1, float y1, float x2, float y2, float z)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                var ptr = Library.Server.Core_CreateColShapeRectangle(NativePointer, x1, y1, x2, y2, z);
                if (ptr == IntPtr.Zero) return null;
                return ColShapePool.Create(this, ptr);
            }
        }

        public IColShape CreateColShapePolygon(float minZ, float maxZ, Vector2[] points)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                int size = points.Count();
                var ptr = Library.Server.Core_CreateColShapePolygon(NativePointer, minZ, maxZ, points, size);
                if (ptr == IntPtr.Zero) return null;
                return ColShapePool.Create(this, ptr);
            }
        }

        public void DestroyBlip(IBlip blip)
        {
            CheckIfCallIsValid();
            if (blip.Exists)
            {
                unsafe
                {
                    Library.Shared.Core_DestroyBaseObject(NativePointer, blip.BaseObjectNativePointer);
                }
            }
        }

        public void DestroyCheckpoint(ICheckpoint checkpoint)
        {
            CheckIfCallIsValid();
            if (checkpoint.Exists)
            {
                unsafe
                {
                    Library.Server.Core_DestroyCheckpoint(NativePointer, checkpoint.CheckpointNativePointer);
                }
            }
        }

        public void DestroyVehicle(IVehicle vehicle)
        {
            CheckIfCallIsValid();
            if (vehicle.Exists)
            {
                unsafe
                {
                    Library.Server.Core_DestroyVehicle(NativePointer, vehicle.VehicleNativePointer);
                }
            }
        }

        public void DestroyVoiceChannel(IVoiceChannel channel)
        {
            if (channel.Exists)
            {
                unsafe
                {
                    Library.Server.Core_DestroyVoiceChannel(NativePointer, channel.VoiceChannelNativePointer);
                }
            }
        }

        public void DestroyColShape(IColShape colShape)
        {
            CheckIfCallIsValid();
            if (colShape.Exists)
            {
                unsafe
                {
                    Library.Server.Core_DestroyColShape(NativePointer, colShape.ColShapeNativePointer);
                }
            }
        }
        #endregion

        public INativeResource GetResource(string name)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
                var resourcePointer = Library.Shared.Core_GetResource(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return !NativeResourcePool.GetOrCreate(this, resourcePointer, out var nativeResource)
                    ? null
                    : nativeResource;
            }
        }

        public INativeResource GetResource(IntPtr resourcePointer)
        {
            return !NativeResourcePool.GetOrCreate(this, resourcePointer, out var nativeResource)
                ? null
                : nativeResource;
        }

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

        public new IEntity GetEntityById(ushort id)
        {
            return (IEntity) base.GetEntityById(id);
        }

        public void StartResource(string name)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var namePtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
                Library.Server.Core_StartResource(NativePointer, namePtr);
                Marshal.FreeHGlobal(namePtr);
            }
        }

        public void StopResource(string name)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var namePtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
                Library.Server.Core_StopResource(NativePointer, namePtr);
                Marshal.FreeHGlobal(namePtr);
            }
        }

        public void RestartResource(string name)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var namePtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
                Library.Server.Core_RestartResource(NativePointer, namePtr);
                Marshal.FreeHGlobal(namePtr);
            }
        }

        #region SyncedMetaData
        public void SetSyncedMetaData(string key, object value)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CreateMValue(out var mValue, value);
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Library.Server.Core_SetSyncedMetaData(NativePointer, stringPtr, mValue.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
                mValue.Dispose();
            }
        }

        public void DeleteSyncedMetaData(string key)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Library.Server.Core_DeleteSyncedMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }
        #endregion

        public void OnScriptsLoaded(IScript[] scripts)
        {
            foreach (var script in scripts)
            {
                Alt.RegisterEvents(script);
                OnScriptLoaded(script);
            }
        }

        public virtual void OnScriptLoaded(IScript script)
        {
        }


        internal readonly IDictionary<string, Function> functionExports = new Dictionary<string, Function>();

        internal readonly LinkedList<GCHandle> functionExportHandles = new LinkedList<GCHandle>();

        public void SetExport(string key, Function function)
        {
            unsafe
            {
                if (function == null) return;
                functionExports[key] = function;
                MValueFunctionCallback callDelegate = function.Call;
                functionExportHandles.AddFirst(GCHandle.Alloc(callDelegate));
                this.CreateMValueFunction(out var mValue,
                    this.Library.Shared.Invoker_Create(Resource.ResourceImplPtr, callDelegate));
                Resource.SetExport(key, in mValue);
                mValue.Dispose();
            }
        }

        private readonly WeakReference<AssemblyLoadContext> assemblyLoadContext;

        internal IEnumerable<Assembly> Assemblies => !assemblyLoadContext.TryGetTarget(out var target)
            ? new List<Assembly>()
            : target.Assemblies;

        public Assembly LoadAssemblyFromName(AssemblyName assemblyName)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromAssemblyName(assemblyName);
        }

        public Assembly LoadAssemblyFromStream(Stream stream)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromStream(stream);
        }

        public Assembly LoadAssemblyFromStream(Stream stream, Stream assemblySymbols)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromStream(stream, assemblySymbols);
        }

        public Assembly LoadAssemblyFromPath(string path)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromAssemblyPath(path);
        }

        public Assembly LoadAssemblyFromNativeImagePath(string nativeImagePath, string assemblyPath)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromNativeImagePath(nativeImagePath, assemblyPath);
        }

        public WeakReference<AssemblyLoadContext> GetAssemblyLoadContext()
        {
            return assemblyLoadContext;
        }
        public override void Dispose() {
            base.Dispose();
            assemblyLoadContext.SetTarget(null);
        }

        public bool FileExists(string path)
        {
            unsafe
            {
                var pathPtr = AltNative.StringUtils.StringToHGlobalUtf8(path);
                var result = Library.Shared.Core_FileExists(NativePointer, pathPtr);
                Marshal.FreeHGlobal(pathPtr);
                return result == 1;
            }
        }

        public string FileRead(string path)
        {
            unsafe
            {
                var pathPtr = AltNative.StringUtils.StringToHGlobalUtf8(path);
                var size = 0;
                var result = PtrToStringUtf8AndFree(Library.Shared.Core_FileRead(NativePointer, pathPtr, &size), size);
                Marshal.FreeHGlobal(pathPtr);
                return result;
            }
        }

        public byte[] FileReadBinary(string path)
        {
            unsafe
            {
                var pathPtr = AltNative.StringUtils.StringToHGlobalUtf8(path);
                var size = 0;
                var result = Library.Shared.Core_FileRead(NativePointer, pathPtr, &size);
                var buffer = new byte[size];
                Marshal.Copy(result, buffer, 0, size);
                Marshal.FreeHGlobal(pathPtr);
                return buffer;
            }
        }

        public IConfig GetServerConfig()
        {
            unsafe
            {
                return new Config(this, Library.Server.Core_GetServerConfig(NativePointer));
            }
        }

        public void SetWorldProfiler(bool state)
        {
            unsafe
            {
                Library.Server.Core_SetWorldProfiler(NativePointer, state ? (byte)1 : (byte)0);
            }
        }
    }
}