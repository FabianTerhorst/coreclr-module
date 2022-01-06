using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Exceptions;
using AltV.Net.Native;

namespace AltV.Net
{
    public class Server : IServer
    {
        public delegate bool EventCallback(IntPtr eventPointer, IntPtr userData);

        public delegate void TickCallback(IntPtr userData);

        public delegate void CommandCallback(StringView cmd, StringViewArray args, IntPtr userData);

        public IntPtr NativePointer { get; }

        private readonly IBaseBaseObjectPool baseBaseObjectPool;

        private readonly IBaseEntityPool baseEntityPool;

        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;

        private readonly IBaseObjectPool<IBlip> blipPool;

        private readonly IBaseObjectPool<ICheckpoint> checkpointPool;

        private readonly IBaseObjectPool<IVoiceChannel> voiceChannelPool;

        private readonly IBaseObjectPool<IColShape> colShapePool;

        private readonly INativeResourcePool nativeResourcePool;

        private string version;

        private string branch;

        public ILibrary Library { get; }

        public string Version
        {
            get
            {
                unsafe
                {
                    if (version != null) return version;
                    var ptr = IntPtr.Zero;
                    ulong size = 0;
                    Library.Core_GetVersion(NativePointer, &ptr, &size);
                    version = Marshal.PtrToStringUTF8(ptr, (int) size);

                    return version;
                }
            }
        }

        public string Branch
        {
            get
            {
                unsafe
                {
                    if (branch != null) return branch;
                    var ptr = IntPtr.Zero;
                    ulong size = 0;
                    Library.Core_GetBranch(NativePointer, &ptr, &size);
                    branch = Marshal.PtrToStringUTF8(ptr, (int) size);

                    return branch;
                }
            }
        }

        public int NetTime
        {
            get
            {
                unsafe
                {
                    return Library.Server_GetNetTime(NativePointer);
                }
            }
        }

        private string rootDirectory;

        private bool? isDebug;

        public string RootDirectory
        {
            get
            {
                unsafe
                {
                    if (rootDirectory != null) return rootDirectory;
                    var ptr = IntPtr.Zero;
                    Library.Server_GetRootDirectory(NativePointer, &ptr);
                    rootDirectory = Marshal.PtrToStringUTF8(ptr);

                    return rootDirectory;
                }
            }
        }

        public bool IsDebug
        {
            get
            {
                unsafe
                {
                    if (isDebug.HasValue) return isDebug.Value;
                    isDebug = Library.Core_IsDebug(NativePointer) == 1;
                    return isDebug.Value;
                }
            }
        }

        public INativeResource Resource { get; }

        public Server(IntPtr nativePointer, ILibrary library, INativeResource resource, IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool,
            IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool,
            INativeResourcePool nativeResourcePool)
        {
            NativePointer = nativePointer;
            this.baseBaseObjectPool = baseBaseObjectPool;
            this.baseEntityPool = baseEntityPool;
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
            this.blipPool = blipPool;
            this.checkpointPool = checkpointPool;
            this.voiceChannelPool = voiceChannelPool;
            this.colShapePool = colShapePool;
            this.nativeResourcePool = nativeResourcePool;
            Library = library;
            Resource = resource;
        }

        public void LogInfo(IntPtr messagePtr)
        {
            unsafe
            {
                Library.Server_LogInfo(NativePointer, messagePtr);
            }
        }

        public void LogDebug(IntPtr messagePtr)
        {
            unsafe
            {
                Library.Server_LogDebug(NativePointer, messagePtr);
            }
        }

        public void LogWarning(IntPtr messagePtr)
        {
            unsafe
            {
                Library.Server_LogWarning(NativePointer, messagePtr);
            }
        }

        public void LogError(IntPtr messagePtr)
        {
            unsafe
            {
                Library.Server_LogError(NativePointer, messagePtr);
            }
        }

        public void LogColored(IntPtr messagePtr)
        {
            unsafe
            {
                Library.Server_LogColored(NativePointer, messagePtr);
            }
        }

        public void LogInfo(string message)
        {
            unsafe
            {
                var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
                Library.Server_LogInfo(NativePointer, messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogDebug(string message)
        {
            unsafe
            {
                var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
                Library.Server_LogDebug(NativePointer, messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogWarning(string message)
        {
            unsafe
            {
                var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
                Library.Server_LogWarning(NativePointer, messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogError(string message)
        {
            unsafe
            {
                var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
                Library.Server_LogError(NativePointer, messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogColored(string message)
        {
            unsafe
            {
                var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
                Library.Server_LogColored(NativePointer, messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public ulong HashPassword(string password)
        {
            unsafe
            {
                var passwordPtr = AltNative.StringUtils.StringToHGlobalUtf8(password);
                var value = Library.Core_HashPassword(NativePointer, passwordPtr);
                Marshal.FreeHGlobal(passwordPtr);
                return value;
            }
        }

        public uint Hash(string stringToHash)
        {
            //return AltVNative.Server.Server_Hash(NativePointer, hash);
            if (string.IsNullOrEmpty(stringToHash)) return 0;

            var characters = Encoding.UTF8.GetBytes(stringToHash.ToLower());

            uint hash = 0;

            foreach (var c in characters)
            {
                hash += c;
                hash += hash << 10;
                hash ^= hash >> 6;
            }

            hash += hash << 3;
            hash ^= hash >> 11;
            hash += hash << 15;

            return hash;
        }

        public void SetPassword(string password)
        {
            unsafe
            {
                var passwordPtr = AltNative.StringUtils.StringToHGlobalUtf8(password);
                Library.Core_SetPassword(NativePointer, passwordPtr);
                Marshal.FreeHGlobal(passwordPtr);
            }
        }

        public void StopServer()
        {
            unsafe
            {
                Library.Core_StopServer(NativePointer);  
            }
        }

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
                Library.Server_TriggerServerEvent(NativePointer, eventNamePtr, args, args.Length);
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
                Library.Server_TriggerClientEvent(NativePointer, player.NativePointer,
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

                Library.Server_TriggerClientEventForAll(NativePointer, eventNamePtr, mValuePointers, args.Length);
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
                Library.Server_TriggerClientEventForAll(NativePointer, eventNamePtr, args, args.Length);
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
                    clPtrs[i] = clients[i].NativePointer;
                }
                Library.Server_TriggerClientEventForSome(NativePointer, clPtrs, size,
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
        
        public IVehicle CreateVehicle(uint model, Position pos, Rotation rotation)
        {
            unsafe
            {
                CheckIfCallIsValid();
                ushort id = default;
                var ptr = Library.Server_CreateVehicle(NativePointer, model, pos, rotation, &id);
                if (ptr == IntPtr.Zero) return null;
                vehiclePool.Create(this, ptr, id, out var vehicle);
                return vehicle;
            }
        }

        public ICheckpoint CreateCheckpoint(byte type, Position pos, float radius, float height,
            Rgba color)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var ptr = Library.Server_CreateCheckpoint(NativePointer, type, pos, radius, height, color);
                if (ptr == IntPtr.Zero) return null;
                checkpointPool.Create(this, ptr, out var checkpoint);
                return checkpoint;
            }
        }

        public IBlip CreateBlip(IPlayer player, byte type, Position pos)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var ptr = Library.Server_CreateBlip(NativePointer, player?.NativePointer ?? IntPtr.Zero,
                    type, pos);
                if (ptr == IntPtr.Zero) return null;
                blipPool.Create(this, ptr, out var blip);
                return blip;
            }
        }

        public IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach)
        {
            unsafe
            {
                CheckIfCallIsValid();
                if (entityAttach is IPlayer playerAttach)
                {
                    var ptr = Library.Server_CreateBlipAttachedPlayer(NativePointer,
                        player?.NativePointer ?? IntPtr.Zero,
                        type, playerAttach.NativePointer);
                    if (ptr == IntPtr.Zero) return null;
                    blipPool.Create(this, ptr, out var blip);
                    return blip;
                }
                if (entityAttach is IVehicle vehicleAttach)
                {
                    var ptr = Library.Server_CreateBlipAttachedVehicle(NativePointer,
                        player?.NativePointer ?? IntPtr.Zero,
                        type, vehicleAttach.NativePointer);
                    if (ptr == IntPtr.Zero) return null;
                    blipPool.Create(this, ptr, out var blip);
                    return blip;
                }

                return null;
            }
        }

        public IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var ptr = Library.Server_CreateVoiceChannel(NativePointer,
                    spatial ? (byte) 1 : (byte) 0, maxDistance);
                if (ptr == IntPtr.Zero) return null;
                voiceChannelPool.Create(this, ptr, out var voiceChannel);
                return voiceChannel;
            }
        }

        public IColShape CreateColShapeCylinder(Position pos, float radius, float height)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var ptr = Library.Server_CreateColShapeCylinder(NativePointer, pos, radius, height);
                if (ptr == IntPtr.Zero) return null;
                colShapePool.Create(this, ptr, out var colShape);
                return colShape;
            }
        }

        public IColShape CreateColShapeSphere(Position pos, float radius)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var ptr = Library.Server_CreateColShapeSphere(NativePointer, pos, radius);
                if (ptr == IntPtr.Zero) return null;
                colShapePool.Create(this, ptr, out var colShape);
                return colShape;
            }
        }

        public IColShape CreateColShapeCircle(Position pos, float radius)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var ptr = Library.Server_CreateColShapeCircle(NativePointer, pos, radius);
                if (ptr == IntPtr.Zero) return null;
                colShapePool.Create(this, ptr, out var colShape);
                return colShape;
            }
        }

        public IColShape CreateColShapeCube(Position pos, Position pos2)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var ptr = Library.Server_CreateColShapeCube(NativePointer, pos, pos2);
                if (ptr == IntPtr.Zero) return null;
                colShapePool.Create(this, ptr, out var colShape);
                return colShape;
            }
        }

        public IColShape CreateColShapeRectangle(float x1, float y1, float x2, float y2, float z)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var ptr = Library.Server_CreateColShapeRectangle(NativePointer, x1, y1, x2, y2, z);
                if (ptr == IntPtr.Zero) return null;
                colShapePool.Create(this, ptr, out var colShape);
                return colShape;
            }
        }

        public void RemoveBlip(IBlip blip)
        {
            CheckIfCallIsValid();
            if (blip.Exists)
            {
                unsafe
                {
                    Library.Server_DestroyBlip(NativePointer, blip.NativePointer);
                }
            }
        }

        public void RemoveCheckpoint(ICheckpoint checkpoint)
        {
            CheckIfCallIsValid();
            if (checkpoint.Exists)
            {
                unsafe
                {
                    Library.Server_DestroyCheckpoint(NativePointer, checkpoint.NativePointer);
                }
            }
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            CheckIfCallIsValid();
            if (vehicle.Exists)
            {
                unsafe
                {
                    Library.Server_DestroyVehicle(NativePointer, vehicle.NativePointer);
                }
            }
        }

        public void RemoveVoiceChannel(IVoiceChannel channel)
        {
            if (channel.Exists)
            {
                unsafe
                {
                    Library.Server_DestroyVoiceChannel(NativePointer, channel.NativePointer);
                }
            }
        }

        public void RemoveColShape(IColShape colShape)
        {
            CheckIfCallIsValid();
            if (colShape.Exists)
            {
                unsafe
                {
                    Library.Server_DestroyColShape(NativePointer, colShape.NativePointer);
                }
            }
        }

        public INativeResource GetResource(string name)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
                var resourcePointer = Library.Server_GetResource(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return !nativeResourcePool.GetOrCreate(Library, NativePointer, resourcePointer, out var nativeResource)
                    ? null
                    : nativeResource;
            }
        }

        public INativeResource GetResource(IntPtr resourcePointer)
        {
            return !nativeResourcePool.GetOrCreate(Library, NativePointer, resourcePointer, out var nativeResource)
                ? null
                : nativeResource;
        }

        public IntPtr CreateVehicleEntity(out ushort id, uint model, Position pos, Rotation rotation)
        {
            unsafe
            {
                ushort pId;
                var pointer = Library.Server_CreateVehicle(NativePointer, model, pos, rotation, &pId);
                id = pId;
                return pointer;
            }
        }

        public IPlayer[] GetPlayers()
        {
            unsafe
            {
                CheckIfCallIsValid();
                var playerCount = Library.Server_GetPlayerCount(NativePointer);
                var pointers = new IntPtr[playerCount];
                Library.Server_GetPlayers(NativePointer, pointers, playerCount);
                var players = new IPlayer[playerCount];
                for (ulong i = 0; i < playerCount; i++)
                {
                    var playerPointer = pointers[i];
                    if (playerPool.GetOrCreate(this, playerPointer, out var player))
                    {
                        players[i] = player;
                    }
                }

                return players;
            }
        }

        public IVehicle[] GetVehicles()
        {
            unsafe
            {
                CheckIfCallIsValid();
                var vehicleCount = Library.Server_GetVehicleCount(NativePointer);
                var pointers = new IntPtr[vehicleCount];
                Library.Server_GetVehicles(NativePointer, pointers, vehicleCount);
                var vehicles = new IVehicle[vehicleCount];
                for (ulong i = 0; i < vehicleCount; i++)
                {
                    var vehiclePointer = pointers[i];
                    if (vehiclePool.GetOrCreate(this, vehiclePointer, out var vehicle))
                    {
                        vehicles[i] = vehicle;
                    }
                }

                return vehicles;
            }
        }

        public IEntity GetEntityById(ushort id)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var type = (byte) BaseObjectType.Undefined;
                var entityPointer = Library.Server_GetEntityById(NativePointer, id, &type);
                if (entityPointer == IntPtr.Zero) return null;
                switch (type)
                {
                    case (byte) BaseObjectType.Player:
                        return playerPool.Get(entityPointer, out var player) ? player : null;
                    case (byte) BaseObjectType.Vehicle:
                        return vehiclePool.Get(entityPointer, out var vehicle) ? vehicle : null;
                    default:
                        return null;
                }
            }
        }

        public void StartResource(string name)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var namePtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
                Library.Server_StartResource(NativePointer, namePtr);
                Marshal.FreeHGlobal(namePtr);
            }
        }

        public void StopResource(string name)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var namePtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
                Library.Server_StopResource(NativePointer, namePtr);
                Marshal.FreeHGlobal(namePtr);
            }
        }

        public void RestartResource(string name)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var namePtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
                Library.Server_RestartResource(NativePointer, namePtr);
                Marshal.FreeHGlobal(namePtr);
            }
        }

        public void GetMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Library.Server_GetMetaData(NativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void SetMetaData(string key, object value)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CreateMValue(out var mValue, value);
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Library.Server_SetMetaData(NativePointer, stringPtr, mValue.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
                mValue.Dispose();
            }
        }

        public bool HasMetaData(string key)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Library.Server_HasMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public void DeleteMetaData(string key)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Library.Server_DeleteMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void GetSyncedMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Library.Server_GetSyncedMetaData(NativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void SetSyncedMetaData(string key, object value)
        {
            unsafe
            {
                CheckIfCallIsValid();
                CreateMValue(out var mValue, value);
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Library.Server_SetSyncedMetaData(NativePointer, stringPtr, mValue.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
                mValue.Dispose();
            }
        }

        public bool HasSyncedMetaData(string key)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Library.Server_HasSyncedMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public void DeleteSyncedMetaData(string key)
        {
            unsafe
            {
                CheckIfCallIsValid();
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Library.Server_DeleteSyncedMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void CreateMValueNil(out MValueConst mValue)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Nil, Library.Core_CreateMValueNil(NativePointer));
            }
        }

        public void CreateMValueBool(out MValueConst mValue, bool value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Bool,
                    Library.Core_CreateMValueBool(NativePointer, value ? (byte) 1 : (byte) 0));
            }
        }

        public void CreateMValueInt(out MValueConst mValue, long value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Int, Library.Core_CreateMValueInt(NativePointer, value));
            }
        }

        public void CreateMValueUInt(out MValueConst mValue, ulong value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Uint,
                    Library.Core_CreateMValueUInt(NativePointer, value));
            }
        }

        public void CreateMValueDouble(out MValueConst mValue, double value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Double,
                    Library.Core_CreateMValueDouble(NativePointer, value));
            }
        }

        public void CreateMValueString(out MValueConst mValue, string value)
        {
            unsafe
            {
                var valuePtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                mValue = new MValueConst(MValueConst.Type.String,
                    Library.Core_CreateMValueString(NativePointer, valuePtr));
                Marshal.FreeHGlobal(valuePtr);
            }
        }

        public void CreateMValueList(out MValueConst mValue, MValueConst[] val, ulong size)
        {
            unsafe
            {
                var pointers = new IntPtr[size];
                for (ulong i = 0; i < size; i++)
                {
                    pointers[i] = val[i].nativePointer;
                }

                mValue = new MValueConst(MValueConst.Type.List,
                    Library.Core_CreateMValueList(NativePointer, pointers, size));
            }
        }

        public void CreateMValueDict(out MValueConst mValue, string[] keys, MValueConst[] val, ulong size)
        {
            unsafe
            {
                var pointers = new IntPtr[size];
                for (ulong i = 0; i < size; i++)
                {
                    pointers[i] = val[i].nativePointer;
                }
                
                var keyPointers = new IntPtr[size];
                for (ulong i = 0; i < size; i++)
                {
                    keyPointers[i] = AltNative.StringUtils.StringToHGlobalUtf8(keys[i]);
                }

                mValue = new MValueConst(MValueConst.Type.Dict,
                    Library.Core_CreateMValueDict(NativePointer, keyPointers, pointers, size));
                for (ulong i = 0; i < size; i++)
                {
                    Marshal.FreeHGlobal(keyPointers[i]);  
                }
            }
        }

        public void CreateMValueCheckpoint(out MValueConst mValue, ICheckpoint value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.BaseObject,
                    Library.Core_CreateMValueCheckpoint(NativePointer, value.NativePointer));
            }
        }

        public void CreateMValueBlip(out MValueConst mValue, IBlip value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.BaseObject,
                    Library.Core_CreateMValueBlip(NativePointer, value.NativePointer));
            }
        }

        public void CreateMValueVoiceChannel(out MValueConst mValue, IVoiceChannel value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.BaseObject,
                    Library.Core_CreateMValueVoiceChannel(NativePointer, value.NativePointer));
            }
        }

        public void CreateMValuePlayer(out MValueConst mValue, IPlayer value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.BaseObject,
                    Library.Core_CreateMValuePlayer(NativePointer, value.NativePointer));
            }
        }

        public void CreateMValueVehicle(out MValueConst mValue, IVehicle value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.BaseObject,
                    Library.Core_CreateMValueVehicle(NativePointer, value.NativePointer));
            }
        }

        public void CreateMValueFunction(out MValueConst mValue, IntPtr value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Function,
                    Library.Core_CreateMValueFunction(NativePointer, value));
            }
        }

        public void CreateMValueVector3(out MValueConst mValue, Position value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Vector3,
                    Library.Core_CreateMValueVector3(NativePointer, value));
            }
        }
        
        public void CreateMValueVector2(out MValueConst mValue, Vector2 value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Vector2,
                    Library.Core_CreateMValueVector2(NativePointer, value));
            }
        }

        public void CreateMValueRgba(out MValueConst mValue, Rgba value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Rgba,
                    Library.Core_CreateMValueRgba(NativePointer, value));
            }
        }

        public void CreateMValueByteArray(out MValueConst mValue, byte[] value)
        {
            unsafe
            {
                var size = value.Length;
                var dataPtr = Marshal.AllocHGlobal(size);
                Marshal.Copy(value, 0, dataPtr, size);
                mValue = new MValueConst(MValueConst.Type.ByteArray,
                    Library.Core_CreateMValueByteArray(NativePointer, (ulong) size, dataPtr));
                Marshal.FreeHGlobal(dataPtr);
            }
        }

        public void CreateMValue(out MValueConst mValue, object obj)
        {
            if (obj == null)
            {
                mValue = MValueConst.Nil;
                return;
            }

            int i;

            string[] dictKeys;
            MValueConst[] dictValues;
            MValueWriter2 writer;

            switch (obj)
            {
                case IPlayer player:
                    CreateMValuePlayer(out mValue, player);
                    return;
                case IVehicle vehicle:
                    CreateMValueVehicle(out mValue, vehicle);
                    return;
                case IBlip blip:
                    CreateMValueBlip(out mValue, blip);
                    return;
                case ICheckpoint checkpoint:
                    CreateMValueCheckpoint(out mValue, checkpoint);
                    return;
                case bool value:
                    CreateMValueBool(out mValue, value);
                    return;
                case int value:
                    CreateMValueInt(out mValue, value);
                    return;
                case uint value:
                    CreateMValueUInt(out mValue, value);
                    return;
                case long value:
                    CreateMValueInt(out mValue, value);
                    return;
                case ulong value:
                    CreateMValueUInt(out mValue, value);
                    return;
                case double value:
                    CreateMValueDouble(out mValue, value);
                    return;
                case float value:
                    CreateMValueDouble(out mValue, value);
                    return;
                case string value:
                    CreateMValueString(out mValue, value);
                    return;
                case MValueConst value:
                    mValue = value;
                    return;
                case MValueConst[] value:
                    CreateMValueList(out mValue, value, (ulong) value.Length);
                    return;
                case Invoker value:
                    CreateMValueFunction(out mValue, value.NativePointer);
                    return;
                case MValueFunctionCallback value:
                    CreateMValueFunction(out mValue, Resource.CSharpResourceImpl.CreateInvoker(value));
                    return;
                case Function function:
                    CreateMValueFunction(out mValue,
                        Resource.CSharpResourceImpl.CreateInvoker(function.Call));
                    return;
                case byte[] byteArray:
                    CreateMValueByteArray(out mValue, byteArray);
                    return;
                case IDictionary dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValueConst[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        if (key is string stringKey)
                        {
                            dictKeys[i++] = stringKey;
                        }
                        else
                        {
                            mValue = MValueConst.Nil;
                            return;
                        }
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        CreateMValue(out var elementMValue, value);
                        dictValues[i++] = elementMValue;
                    }

                    CreateMValueDict(out mValue, dictKeys, dictValues, (ulong) dictionary.Count);
                    for (int j = 0, dictLength = dictionary.Count; j < dictLength; j++)
                    {
                        dictValues[j].Dispose();
                    }

                    return;
                case ICollection collection:
                    var length = (ulong) collection.Count;
                    var listValues = new MValueConst[length];
                    i = 0;
                    foreach (var value in collection)
                    {
                        CreateMValue(out var elementMValue, value);
                        listValues[i++] = elementMValue;
                    }

                    CreateMValueList(out mValue, listValues, length);
                    for (ulong j = 0; j < length; j++)
                    {
                        listValues[j].Dispose();
                    }

                    return;
                case IDictionary<string, object> dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValueConst[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        dictKeys[i++] = key;
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        CreateMValue(out var elementMValue, value);
                        dictValues[i++] = elementMValue;
                    }

                    CreateMValueDict(out mValue, dictKeys, dictValues, (ulong) dictionary.Count);
                    for (int j = 0, dictLength = dictionary.Count; j < dictLength; j++)
                    {
                        dictValues[j].Dispose();
                    }

                    return;
                case IWritable writable:
                    writer = new MValueWriter2();
                    writable.OnWrite(writer);
                    writer.ToMValue(out mValue);
                    return;
                case IMValueConvertible convertible:
                    writer = new MValueWriter2();
                    convertible.GetAdapter().ToMValue(obj, writer);
                    writer.ToMValue(out mValue);
                    return;
                case Position position:
                    CreateMValueVector3(out mValue, position);
                    return;
                case Rotation rotation:
                    CreateMValueVector3(out mValue, rotation);
                    return;
                case Rgba rgba:
                    CreateMValueRgba(out mValue, rgba);
                    return;
                case short value:
                    CreateMValueInt(out mValue, value);
                    return;
                case ushort value:
                    CreateMValueUInt(out mValue, value);
                    return;
                case Vector3 position:
                    CreateMValueVector3(out mValue, position);
                    return;
                case Vector2 value:
                    CreateMValueVector2(out mValue, value);
                    return;
                default:
                    Alt.Log("can't convert type:" + obj.GetType());
                    mValue = MValueConst.Nil;
                    return;
            }
        }

        public void CreateMValues(MValueConst[] mValues, object[] objects)
        {
            for (int i = 0, length = objects.Length; i < length; i++)
            {
                CreateMValue(out var mValue, objects[i]);
                mValues[i] = mValue;
            }
        }

        [Conditional("DEBUG")]
        public void CheckIfCallIsValid([CallerMemberName] string callerName = "")
        {
            if (Alt.Module.IsMainThread()) return;
            throw new IllegalThreadException(this, callerName);
        }

        public bool FileExists(string path)
        {
            unsafe
            {
                var valuePtr = AltNative.StringUtils.StringToHGlobalUtf8(path);
                var result = Library.Server_FileExists(NativePointer, valuePtr);
                Marshal.FreeHGlobal(valuePtr);
                return result == 1;
            }
        }

        public string FileRead(string path)
        {
            unsafe
            {
                var valuePtr = AltNative.StringUtils.StringToHGlobalUtf8(path);
                var ptr = IntPtr.Zero;
                Library.Server_FileRead(NativePointer, valuePtr, &ptr);
                var result = Marshal.PtrToStringUTF8(ptr);
                Marshal.FreeHGlobal(valuePtr);
                return result;
            }
        }
    }
}