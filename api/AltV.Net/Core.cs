using System;
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
using AltV.Net.CApi;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Exceptions;
using AltV.Net.Native;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Data;
using AltV.Net.Shared.Enums;

namespace AltV.Net
{
    public partial class Core : SharedCore, ICore, IInternalCore
    {
        public override IPoolManager PoolManager { get;}
        public Dictionary<IntPtr, List<InternalPlayerSeat>> VehiclePassengers { get; }
        ISharedPoolManager ISharedCore.PoolManager => PoolManager;

        public INativeResourcePool NativeResourcePool { get; }

        private readonly ConcurrentDictionary<uint, VehicleModelInfo> vehicleModelInfoCache;
        private readonly ConcurrentDictionary<uint, PedModelInfo?> pedModelInfoCache;
        private readonly ConcurrentDictionary<uint, WeaponModelInfo?> weaponModelInfoCache;

        private readonly ConcurrentDictionary<string, Metric?> metricCache;

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

        public Core(IntPtr nativePointer, IntPtr resourcePointer, AssemblyLoadContext assemblyLoadContext, ILibrary library, IPoolManager poolManager,
            INativeResourcePool nativeResourcePool) : base(nativePointer, library)
        {
            this.assemblyLoadContext = new WeakReference<AssemblyLoadContext>(assemblyLoadContext);
            this.PoolManager = poolManager;
            this.NativeResourcePool = nativeResourcePool;
            this.vehicleModelInfoCache = new();
            this.pedModelInfoCache = new();
            this.metricCache = new();
            this.weaponModelInfoCache = new();
            nativeResourcePool.GetOrCreate(this, resourcePointer, out var resource);
            Resource = resource;
            this.VehiclePassengers = new();
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
                    var structure = Marshal.PtrToStructure<VehicleModelInfoInternal>(ptr);
                    var publicStructure = structure.ToPublic();
                    Library.Server.Core_DeallocVehicleModelInfo(ptr);
                    return publicStructure;
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

        public WeaponModelInfo? GetWeaponModelInfo(uint hash)
        {
            return this.weaponModelInfoCache.GetOrAdd(hash, u =>
            {
                unsafe
                {
                    var ptr = Library.Server.Core_GetWeaponModelByHash(NativePointer, u);
                    var structure = Marshal.PtrToStructure<WeaponModelInfoInternal>(ptr);
                    var publicStructure = structure.ToPublic();
                    Library.Server.Core_DeallocWeaponModelInfo(ptr);
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

        public void TriggerClientEventUnreliable(IPlayer player, IntPtr eventNamePtr, MValueConst[] args)
        {
            var size = args.Length;
            var mValuePointers = new IntPtr[size];
            for (var i = 0; i < size; i++)
            {
                mValuePointers[i] = args[i].nativePointer;
            }

            TriggerClientEventUnreliable(player, eventNamePtr, mValuePointers);
        }

        public void TriggerClientEventUnreliable(IPlayer player, string eventName, MValueConst[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEventUnreliable(player, eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TriggerClientEventUnreliable(IPlayer player, IntPtr eventNamePtr, IntPtr[] args)
        {
            unsafe
            {
                Library.Server.Core_TriggerClientEventUnreliable(NativePointer, player.PlayerNativePointer,
                    eventNamePtr, args, args.Length);
            }
        }

        public void TriggerClientEventUnreliable(IPlayer player, string eventName, IntPtr[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEventUnreliable(player, eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerClientEventUnreliable(IPlayer player, IntPtr eventNamePtr, params object[] args)
        {
            if (player == null) throw new ArgumentException("player should not be null.");
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerClientEventUnreliable(player, eventNamePtr, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerClientEventUnreliable(IPlayer player, string eventName, params object[] args)
        {
            if (player == null) throw new ArgumentException("player should not be null.");
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerClientEventUnreliable(player, eventName, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerClientEventUnreliableForAll(IntPtr eventNamePtr, MValueConst[] args)
        {
            unsafe
            {
                var size = args.Length;
                var mValuePointers = new IntPtr[size];
                for (var i = 0; i < size; i++)
                {
                    mValuePointers[i] = args[i].nativePointer;
                }

                Library.Server.Core_TriggerClientEventUnreliableForAll(NativePointer, eventNamePtr, mValuePointers, args.Length);
            }
        }

        public void TriggerClientEventUnreliableForAll(string eventName, MValueConst[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEventUnreliableForAll(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerClientEventUnreliableForAll(IntPtr eventNamePtr, IntPtr[] args)
        {
            unsafe
            {
                Library.Server.Core_TriggerClientEventUnreliableForAll(NativePointer, eventNamePtr, args, args.Length);
            }
        }

        public void TriggerClientEventUnreliableForAll(string eventName, IntPtr[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEventUnreliableForAll(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerClientEventUnreliableForAll(IntPtr eventNamePtr, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerClientEventUnreliableForAll(eventNamePtr, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerClientEventUnreliableForAll(string eventName, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerClientEventUnreliableForAll(eventName, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerClientEventUnreliableForSome(IPlayer[] clients, IntPtr eventNamePtr, MValueConst[] args)
        {
            var size = args.Length;
            var mValuePointers = new IntPtr[size];
            for (var i = 0; i < size; i++)
            {
                mValuePointers[i] = args[i].nativePointer;
            }

            TriggerClientEventUnreliableForSome(clients, eventNamePtr, mValuePointers);
        }

        public void TriggerClientEventUnreliableForSome(IPlayer[] clients, string eventName, MValueConst[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEventUnreliableForSome(clients, eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TriggerClientEventUnreliableForSome(IPlayer[] clients, IntPtr eventNamePtr, IntPtr[] args)
        {
            unsafe
            {
                var size = clients.Length;
                var clPtrs = new IntPtr[size];
                for (var i = 0; i < size; i++)
                {
                    clPtrs[i] = clients[i].PlayerNativePointer;
                }
                Library.Server.Core_TriggerClientEventUnreliableForSome(NativePointer, clPtrs, size,
                    eventNamePtr, args, args.Length);
            }
        }

        public void TriggerClientEventUnreliableForSome(IPlayer[] clients, string eventName, IntPtr[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEventUnreliableForSome(clients, eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerClientEventUnreliableForSome(IPlayer[] clients, IntPtr eventNamePtr, params object[] args)
        {
            if (clients == null) throw new ArgumentException("players should not be null.");
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerClientEventUnreliableForSome(clients, eventNamePtr, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerClientEventUnreliableForSome(IPlayer[] clients, string eventName, params object[] args)
        {
            if (clients == null) throw new ArgumentException("players should not be null.");
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerClientEventUnreliableForSome(clients, eventName, mValues);
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
                uint id = default;
                var ptr = Library.Server.Core_CreateVehicle(NativePointer, model, pos, rotation, &id);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.Vehicle.GetOrCreate(this, ptr, id);
            }
        }

        public IntPtr CreateVehicleEntity(out uint id, uint model, Position pos, Rotation rotation)
        {
            unsafe
            {
                CheckIfThreadIsValid();
                uint pId;
                var pointer = Library.Server.Core_CreateVehicle(NativePointer, model, pos, rotation, &pId);
                id = pId;
                return pointer;
            }
        }
        public IPed CreatePed(uint model, Position pos, Rotation rotation)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                uint id = default;
                var ptr = Library.Server.Core_CreatePed(NativePointer, model, pos, rotation, &id);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.Ped.GetOrCreate(this, ptr, id);
            }
        }

        public ICheckpoint CreateCheckpoint(byte type, Position pos, float radius, float height,
            Rgba color, uint streamingDistance)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                uint id = default;
                var ptr = Library.Server.Core_CreateCheckpoint(NativePointer, type, pos, radius, height, color, streamingDistance, &id);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.Checkpoint.GetOrCreate(this, ptr, id);
            }
        }

        public IBlip CreateBlip(bool global, byte type, Position pos, IPlayer[] targets)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                uint id = default;
                var ptr = Library.Server.Core_CreateBlip(NativePointer, global ? (byte)1 : (byte)0,
                    type, pos, targets.Select(x => x.PlayerNativePointer).ToArray(), targets.Length, &id);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.Blip.GetOrCreate(this, ptr, id);
            }
        }

        public IBlip CreateBlip(bool global, byte type, IEntity entityAttach, IPlayer[] targets)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                uint id = default;
                var ptr = Library.Server.Core_CreateBlipAttached(NativePointer,
                    global ? (byte)1 : (byte)0,
                    type, entityAttach.EntityNativePointer, targets.Select(x => x.PlayerNativePointer).ToArray(), targets.Length, &id);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.Blip.GetOrCreate(this, ptr, id);
            }
        }

        public IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                uint id = default;
                var ptr = Library.Server.Core_CreateVoiceChannel(NativePointer,
                    spatial ? (byte) 1 : (byte) 0, maxDistance, &id);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.VoiceChannel.GetOrCreate(this, ptr, id);
            }
        }

        public IColShape CreateColShapeCylinder(Position pos, float radius, float height)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                uint id = default;
                var ptr = Library.Shared.Core_CreateColShapeCylinder(NativePointer, pos, radius, height, &id);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.ColShape.GetOrCreate(this, ptr, id);
            }
        }

        public IColShape CreateColShapeSphere(Position pos, float radius)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                uint id = default;
                var ptr = Library.Shared.Core_CreateColShapeSphere(NativePointer, pos, radius, &id);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.ColShape.GetOrCreate(this, ptr, id);
            }
        }

        public IColShape CreateColShapeCircle(Position pos, float radius)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                uint id = default;
                var ptr = Library.Shared.Core_CreateColShapeCircle(NativePointer, pos, radius, &id);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.ColShape.GetOrCreate(this, ptr, id);
            }
        }

        public IColShape CreateColShapeCube(Position pos, Position pos2)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                uint id = default;
                var ptr = Library.Shared.Core_CreateColShapeCube(NativePointer, pos, pos2, &id);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.ColShape.GetOrCreate(this, ptr, id);
            }
        }

        public IColShape CreateColShapeRectangle(float x1, float y1, float x2, float y2, float z)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                uint id = default;
                var ptr = Library.Shared.Core_CreateColShapeRectangle(NativePointer, x1, y1, x2, y2, z, &id);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.ColShape.GetOrCreate(this, ptr, id);
            }
        }

        public IColShape CreateColShapePolygon(float minZ, float maxZ, Vector2[] points)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                int size = points.Count();
                uint id = default;
                var ptr = Library.Shared.Core_CreateColShapePolygon(NativePointer, minZ, maxZ, points, size, &id);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.ColShape.GetOrCreate(this, ptr, id);
            }
        }

        [Obsolete("Use blip.Destroy() instead")]
        public void RemoveBlip(IBlip blip)
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

        [Obsolete("Use checkpoint.Destroy() instead")]
        public void RemoveCheckpoint(ICheckpoint checkpoint)
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

        [Obsolete("Use vehicle.Destroy() instead")]
        public void RemoveVehicle(IVehicle vehicle)
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

        [Obsolete("Use channel.Destroy() instead")]
        public void RemoveVoiceChannel(IVoiceChannel channel)
        {
            if (channel.Exists)
            {
                unsafe
                {
                    Library.Server.Core_DestroyVoiceChannel(NativePointer, channel.VoiceChannelNativePointer);
                }
            }
        }

        [Obsolete("Use colShape.Destroy() instead")]
        public void RemoveColShape(IColShape colShape)
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

        public IReadOnlyCollection<IPlayer> GetAllPlayers()
        {
            unsafe
            {
                CheckIfCallIsValid();
                ulong size = 0;
                var ptr = Library.Shared.Core_GetPlayers(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => PoolManager.Player.GetOrCreate(this, e)).ToArray();
                Library.Shared.FreePlayerArray(ptr);
                return arr;
            }
        }

        public IReadOnlyCollection<IConnectionInfo> GetAllConnectionInfos()
        {
            unsafe
            {
                CheckIfCallIsValid();
                ulong size = 0;
                var ptr = Library.Server.Core_GetConnectionInfos(NativePointer, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => PoolManager.ConnectionInfo.GetOrCreate(this, e)).ToArray();
                Library.Shared.FreeConnectionInfoArray(ptr);
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
                var arr = data.Select(e => PoolManager.Vehicle.GetOrCreate(this, e)).ToArray();
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
                var arr = data.Select(e => PoolManager.Blip.GetOrCreate(this, e)).ToArray();
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
                var arr = data.Select(e => PoolManager.Checkpoint.GetOrCreate(this, e)).ToArray();
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
                var arr = data.Select(e => PoolManager.VirtualEntity.GetOrCreate(this, e)).ToArray();
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
                var arr = data.Select(e => PoolManager.VirtualEntityGroup.GetOrCreate(this, e)).ToArray();
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
                Marshal.Copy(ptr, data, 0, (int)size);
                var arr = data.Select(e => PoolManager.Ped.GetOrCreate(this, e)).ToArray();
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

        public new IBaseObject GetBaseObjectById(BaseObjectType type, uint id)
        {
            return (IBaseObject) base.GetBaseObjectById(type, id);
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

        internal readonly LinkedList<GCHandle> functionExportHandles = new();

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

        public IBaseObject[] GetClosestEntities(Position position, int range, int dimension, int limit,
            EntityType allowedTypes)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var entitiesCount = Library.Server.Core_GetClosestEntitiesCount(NativePointer, position, range, dimension, limit, (ulong)allowedTypes);
                var pointers = new IntPtr[entitiesCount];
                var types = new byte[entitiesCount];
                Library.Server.Core_GetClosestEntities(NativePointer,position, range, dimension, limit, (ulong)allowedTypes, pointers, types, entitiesCount);
                var baseObjects = new IBaseObject[entitiesCount];
                for (ulong i = 0; i < entitiesCount; i++)
                {
                    var basePointer = pointers[i];
                    baseObjects[i] = PoolManager.GetOrCreate(this, basePointer, (BaseObjectType)types[i]);
                }

                return baseObjects;
            }
        }

        public IBaseObject[] GetEntitiesInDimension(int dimension, EntityType allowedTypes)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var entitiesCount = Library.Server.Core_GetEntitiesInDimensionCount(NativePointer, dimension, (ulong)allowedTypes);
                var pointers = new IntPtr[entitiesCount];
                var types = new byte[entitiesCount];
                Library.Server.Core_GetEntitiesInDimension(NativePointer, dimension, (ulong)allowedTypes, pointers, types, entitiesCount);
                var baseObjects = new IBaseObject[entitiesCount];
                for (ulong i = 0; i < entitiesCount; i++)
                {
                    var basePointer = pointers[i];
                    baseObjects[i] = PoolManager.GetOrCreate(this, basePointer, (BaseObjectType)types[i]);
                }

                return baseObjects;
            }
        }

        public IBaseObject[] GetEntitiesInRange(Position position, int range, int dimension, EntityType allowedTypes)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var entitiesCount = Library.Server.Core_GetEntitiesInRangeCount(NativePointer, position, range, dimension, (ulong)allowedTypes);
                var pointers = new IntPtr[entitiesCount];
                var types = new byte[entitiesCount];
                Library.Server.Core_GetEntitiesInRange(NativePointer, position, range, dimension, (ulong)allowedTypes, pointers, types, entitiesCount);
                var baseObjects = new IBaseObject[entitiesCount];
                for (ulong i = 0; i < entitiesCount; i++)
                {
                    var basePointer = pointers[i];
                    baseObjects[i] = PoolManager.GetOrCreate(this, basePointer, (BaseObjectType)types[i]);
                }

                return baseObjects;
            }
        }

        public IBaseObject GetBaseObject(BaseObjectType type, uint id)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                var ptr = Library.Shared.Core_GetBaseObjectByID(NativePointer, (byte)type, id);

                return PoolManager.Get(ptr, type);
            }
        }

        public IMetric RegisterMetric(string name, MetricType type = MetricType.MetricTypeGauge,
            Dictionary<string, string> dataDict = default)
        {
            unsafe
            {
                var data = new Dictionary<IntPtr, IntPtr>();

                var dictionary = dataDict ?? new Dictionary<string, string>();

                var keys = new IntPtr[dictionary.Count];
                var values = new IntPtr[dictionary.Count];

                for (var i = 0; i < dictionary.Count; i++)
                {
                    var keyptr = AltNative.StringUtils.StringToHGlobalUtf8(dictionary.ElementAt(i).Key);
                    var valueptr = AltNative.StringUtils.StringToHGlobalUtf8(dictionary.ElementAt(i).Value);
                    keys[i] = keyptr;
                    values[i] = valueptr;
                    data.Add(keyptr, valueptr);
                }

                var namePtr = AltNative.StringUtils.StringToHGlobalUtf8(name);

                var ptr = Library.Server.Core_RegisterMetric(NativePointer, namePtr, (byte)type, keys, values,
                    (uint)data.Count);

                foreach (var dataValue in data)
                {
                    Marshal.FreeHGlobal(dataValue.Key);
                    Marshal.FreeHGlobal(dataValue.Value);
                }

                Marshal.FreeHGlobal(namePtr);
                if (ptr == IntPtr.Zero) return null;

                var metric = new Metric(this, ptr);
                metricCache.TryAdd(metric.Name, metric);
                return metric;
            }
        }

        public void UnregisterMetric(IMetric metric)
        {
            if (metricCache.TryRemove(metric.Name, out var removedMetric))
            {
                unsafe
                {
                    Library.Server.Core_UnregisterMetric(NativePointer, removedMetric.MetricNativePointer);
                }
            }
            else
            {
                Console.WriteLine("FEHLER LÖSCHEN");
            }
        }

        public IMarker CreateMarker(IPlayer player, MarkerType type, Position pos, Rgba color)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                uint pId = default;
                var ptr = Library.Server.Core_CreateMarker(NativePointer, player?.PlayerNativePointer ?? IntPtr.Zero, (byte)type, pos, color, Resource.NativePointer, &pId);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.Marker.GetOrCreate(this, ptr, pId);
            }
        }

        public IObject CreateObject(uint hash, Position position, Rotation rotation, byte alpha, byte textureVariation,
            ushort lodDistance)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
                uint pId = default;
                var ptr = Library.Server.Core_CreateObject(NativePointer, hash, position, rotation, alpha, textureVariation, lodDistance, &pId);
                if (ptr == IntPtr.Zero) return null;
                return PoolManager.Object.GetOrCreate(this, ptr, pId);
            }
        }

        public IVirtualEntityGroup CreateVirtualEntityGroup(uint streamingDistance)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CheckIfThreadIsValid();
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
                CheckIfThreadIsValid();

                var data = new Dictionary<IntPtr, MValueConst>();

                var keys = new IntPtr[dataDict.Count];
                var values = new IntPtr[dataDict.Count];

                for (var i = 0; i < dataDict.Count; i++)
                {
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(dataDict.ElementAt(i).Key);
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

        public void SetVoiceExternalPublic(string host, ushort port)
        {
            unsafe
            {
                var hostPtr = AltNative.StringUtils.StringToHGlobalUtf8(host);
                Library.Server.Core_SetVoiceExternalPublic(NativePointer, hostPtr, port);
                Marshal.FreeHGlobal(hostPtr);
            }
        }

        public void SetVoiceExternal(string host, ushort port)
        {
            unsafe
            {
                var hostPtr = AltNative.StringUtils.StringToHGlobalUtf8(host);
                Library.Server.Core_SetVoiceExternal(NativePointer, hostPtr, port);
                Marshal.FreeHGlobal(hostPtr);
            }
        }

        public ushort MaxStreamingPeds
        {
            get
            {
                unsafe
                {
                    return Library.Server.Core_GetMaxStreamingPeds(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Library.Server.Core_SetMaxStreamingPeds(NativePointer, value);
                }
            }
        }

        public ushort MaxStreamingObjects
        {
            get
            {
                unsafe
                {
                    return Library.Server.Core_GetMaxStreamingObjects(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Library.Server.Core_SetMaxStreamingObjects(NativePointer, value);
                }
            }
        }
        public ushort MaxStreamingVehicles
        {
            get
            {
                unsafe
                {
                    return Library.Server.Core_GetMaxStreamingVehicles(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Library.Server.Core_SetMaxStreamingVehicles(NativePointer, value);
                }
            }
        }
        public byte StreamerThreadCount
        {
            get
            {
                unsafe
                {
                    return Library.Server.Core_GetStreamerThreadCount(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Library.Server.Core_SetStreamerThreadCount(NativePointer, value);
                }
            }
        }
        public uint StreamingTickRate
        {
            get
            {
                unsafe
                {
                    return Library.Server.Core_GetStreamingTickRate(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Library.Server.Core_SetStreamingTickRate(NativePointer, value);
                }
            }
        }
        public uint StreamingDistance
        {
            get
            {
                unsafe
                {
                    return Library.Server.Core_GetStreamingDistance(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Library.Server.Core_SetStreamingDistance(NativePointer, value);
                }
            }
        }

        public uint ColShapeTickRate
        {
            get
            {
                unsafe
                {
                    return Library.Server.Core_GetColShapeTickRate(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Library.Server.Core_SetColShapeTickRate(NativePointer, value);
                }
            }
        }
        public uint MigrationDistance
        {
            get
            {
                unsafe
                {
                    return Library.Server.Core_GetMigrationDistance(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Library.Server.Core_SetMigrationDistance(NativePointer, value);
                }
            }
        }
        public byte MigrationThreadCount
        {
            get
            {
                unsafe
                {
                    return Library.Server.Core_GetMigrationThreadCount(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Library.Server.Core_SetMigrationThreadCount(NativePointer, value);
                }
            }
        }
        public uint MigrationTickRate
        {
            get
            {
                unsafe
                {
                    return Library.Server.Core_GetMigrationTickRate(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Library.Server.Core_SetMigrationTickRate(NativePointer, value);
                }
            }
        }
        public byte SyncReceiveThreadCount
        {
            get
            {
                unsafe
                {
                    return Library.Server.Core_GetSyncReceiveThreadCount(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Library.Server.Core_SetSyncReceiveThreadCount(NativePointer, value);
                }
            }
        }
        public byte SyncSendThreadCount
        {
            get
            {
                unsafe
                {
                    return Library.Server.Core_GetSyncSendThreadCount(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Library.Server.Core_SetSyncSendThreadCount(NativePointer, value);
                }
            }
        }

        public IReadOnlyCollection<IMetric> GetAllMetrics()
        {
            return metricCache.Values.ToList();
        }
    }
}