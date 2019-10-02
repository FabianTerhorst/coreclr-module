using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net
{
    public class Server : IServer
    {
        public delegate bool EventCallback(IntPtr eventPointer, IntPtr userData);

        public delegate void TickCallback(IntPtr userData);

        public delegate void CommandCallback(StringView cmd, StringViewArray args, IntPtr userData);

        public readonly IntPtr NativePointer;

        private readonly IBaseBaseObjectPool baseBaseObjectPool;

        private readonly IBaseEntityPool baseEntityPool;

        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;

        private readonly IBaseObjectPool<IBlip> blipPool;

        private readonly IBaseObjectPool<ICheckpoint> checkpointPool;

        private readonly IBaseObjectPool<IVoiceChannel> voiceChannelPool;

        private readonly IBaseObjectPool<IColShape> colShapePool;

        private readonly INativeResourcePool nativeResourcePool;

        public int NetTime => AltNative.Server.Server_GetNetTime(NativePointer);

        private string rootDirectory;

        public string RootDirectory
        {
            get
            {
                if (rootDirectory != null) return rootDirectory;
                var ptr = IntPtr.Zero;
                AltNative.Server.Server_GetRootDirectory(NativePointer, ref ptr);
                rootDirectory = Marshal.PtrToStringUTF8(ptr);

                return rootDirectory;
            }
        }

        public INativeResource Resource { get; }

        public Server(IntPtr nativePointer, INativeResource resource, IBaseBaseObjectPool baseBaseObjectPool,
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
            Resource = resource;
        }

        public void LogInfo(IntPtr messagePtr)
        {
            AltNative.Server.Server_LogInfo(NativePointer, messagePtr);
        }

        public void LogDebug(IntPtr messagePtr)
        {
            AltNative.Server.Server_LogDebug(NativePointer, messagePtr);
        }

        public void LogWarning(IntPtr messagePtr)
        {
            AltNative.Server.Server_LogWarning(NativePointer, messagePtr);
        }

        public void LogError(IntPtr messagePtr)
        {
            AltNative.Server.Server_LogError(NativePointer, messagePtr);
        }

        public void LogColored(IntPtr messagePtr)
        {
            AltNative.Server.Server_LogColored(NativePointer, messagePtr);
        }

        public void LogInfo(string message)
        {
            var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
            AltNative.Server.Server_LogInfo(NativePointer, messagePtr);
            Marshal.FreeHGlobal(messagePtr);
        }

        public void LogDebug(string message)
        {
            var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
            AltNative.Server.Server_LogDebug(NativePointer, messagePtr);
            Marshal.FreeHGlobal(messagePtr);
        }

        public void LogWarning(string message)
        {
            var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
            AltNative.Server.Server_LogWarning(NativePointer, messagePtr);
            Marshal.FreeHGlobal(messagePtr);
        }

        public void LogError(string message)
        {
            var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
            AltNative.Server.Server_LogError(NativePointer, messagePtr);
            Marshal.FreeHGlobal(messagePtr);
        }

        public void LogColored(string message)
        {
            var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
            AltNative.Server.Server_LogColored(NativePointer, messagePtr);
            Marshal.FreeHGlobal(messagePtr);
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

        public void TriggerServerEvent(string eventName, params MValue[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerServerEvent(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, params MValue[] args)
        {
            var mValueList = MValue.Nil;
            AltNative.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValueList);
            AltNative.Server.Server_TriggerServerEvent(NativePointer, eventNamePtr, ref mValueList);
            AltNative.MValueDispose.MValue_Dispose(ref mValueList);
        }

        public void TriggerServerEvent(string eventName, ref MValue args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerServerEvent(eventNamePtr, ref args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, ref MValue args)
        {
            AltNative.Server.Server_TriggerServerEvent(NativePointer, eventNamePtr, ref args);
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var mValues = MValue.CreateFromObjects(args);
            TriggerServerEvent(eventNamePtr, mValues);
            MValue.Dispose(mValues);
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var mValues = MValue.CreateFromObjects(args);
            TriggerServerEvent(eventName, mValues);
            MValue.Dispose(mValues);
        }

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, params MValue[] args)
        {
            var mValueList = MValue.Nil;
            AltNative.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValueList);
            AltNative.Server.Server_TriggerClientEvent(NativePointer, player?.NativePointer ?? IntPtr.Zero,
                eventNamePtr,
                ref mValueList);
            AltNative.MValueDispose.MValue_Dispose(ref mValueList);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params MValue[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEvent(player, eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, ref MValue args)
        {
            AltNative.Server.Server_TriggerClientEvent(NativePointer, player?.NativePointer ?? IntPtr.Zero,
                eventNamePtr,
                ref args);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, ref MValue args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerClientEvent(player, eventNamePtr, ref args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var mValues = MValue.CreateFromObjects(args);
            TriggerClientEvent(player, eventNamePtr, mValues);
            MValue.Dispose(mValues);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var mValues = MValue.CreateFromObjects(args);
            TriggerClientEvent(player, eventName, mValues);
            MValue.Dispose(mValues);
        }

        public IVehicle CreateVehicle(uint model, Position pos, Rotation rotation)
        {
            ushort id = default;
            var ptr = AltNative.Server.Server_CreateVehicle(NativePointer, model, pos, rotation, ref id);
            return vehiclePool.Get(ptr, out var vehicle) ? vehicle : null;
        }

        public ICheckpoint CreateCheckpoint(IPlayer player, byte type, Position pos, float radius, float height,
            Rgba color)
        {
            var ptr = AltNative.Server.Server_CreateCheckpoint(NativePointer,
                player?.NativePointer ?? IntPtr.Zero,
                type, pos, radius, height, color);
            return checkpointPool.Get(ptr, out var checkpoint) ? checkpoint : null;
        }

        public IBlip CreateBlip(IPlayer player, byte type, Position pos)
        {
            var ptr = AltNative.Server.Server_CreateBlip(NativePointer, player?.NativePointer ?? IntPtr.Zero,
                type, pos);
            return blipPool.Get(ptr, out var blip) ? blip : null;
        }

        public IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach)
        {
            var ptr = AltNative.Server.Server_CreateBlipAttached(NativePointer,
                player?.NativePointer ?? IntPtr.Zero,
                type, entityAttach.NativePointer);
            return blipPool.Get(ptr, out var blip) ? blip : null;
        }

        public IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance)
        {
            var ptr = AltNative.Server.Server_CreateVoiceChannel(NativePointer,
                spatial, maxDistance);
            return voiceChannelPool.Get(ptr, out var voiceChannel) ? voiceChannel : null;
        }

        public IColShape CreateColShapeCylinder(Position pos, float radius, float height)
        {
            var ptr = AltNative.Server.Server_CreateColShapeCylinder(NativePointer, pos, radius, height);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public IColShape CreateColShapeSphere(Position pos, float radius)
        {
            var ptr = AltNative.Server.Server_CreateColShapeSphere(NativePointer, pos, radius);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public IColShape CreateColShapeCircle(Position pos, float radius)
        {
            var ptr = AltNative.Server.Server_CreateColShapeCircle(NativePointer, pos, radius);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public IColShape CreateColShapeCube(Position pos, Position pos2)
        {
            var ptr = AltNative.Server.Server_CreateColShapeCube(NativePointer, pos, pos2);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public IColShape CreateColShapeRectangle(Position pos, Position pos2)
        {
            var ptr = AltNative.Server.Server_CreateColShapeRectangle(NativePointer, pos, pos2);
            return colShapePool.Get(ptr, out var colShape) ? colShape : null;
        }

        public void RemoveBlip(IBlip blip)
        {
            if (blip.Exists)
            {
                AltNative.Server.Server_DestroyBlip(NativePointer, blip.NativePointer);
            }
        }

        public void RemoveCheckpoint(ICheckpoint checkpoint)
        {
            if (checkpoint.Exists)
            {
                AltNative.Server.Server_DestroyCheckpoint(NativePointer, checkpoint.NativePointer);
            }
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            if (vehicle.Exists)
            {
                AltNative.Server.Server_DestroyVehicle(NativePointer, vehicle.NativePointer);
            }
        }

        public void RemoveVoiceChannel(IVoiceChannel channel)
        {
            if (channel.Exists)
            {
                AltNative.Server.Server_DestroyVoiceChannel(NativePointer, channel.NativePointer);
            }
        }

        public void RemoveColShape(IColShape colShape)
        {
            if (colShape.Exists)
            {
                AltNative.Server.Server_DestroyColShape(NativePointer, colShape.NativePointer);
            }
        }

        public INativeResource GetResource(string name)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
            var resourcePointer = AltNative.Server.Server_GetResource(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
            return !nativeResourcePool.GetOrCreate(resourcePointer, out var nativeResource) ? null : nativeResource;
        }

        public IntPtr CreateVehicleEntity(out ushort id, uint model, Position pos, Rotation rotation)
        {
            id = default;
            return AltNative.Server.Server_CreateVehicle(NativePointer, model, pos, rotation, ref id);
        }

        public IEnumerable<IPlayer> GetPlayers()
        {
            var playerPointerArray = PlayerPointerArray.Nil;
            AltNative.Server.Server_GetPlayers(NativePointer, ref playerPointerArray);
            var playerPointers = playerPointerArray.ToArrayAndFree();
            foreach (var playerPointer in playerPointers)
            {
                if (playerPool.GetOrCreate(playerPointer, out var vehicle))
                {
                    yield return vehicle;
                }
            }
        }

        public IEnumerable<IVehicle> GetVehicles()
        {
            var vehiclePointerArray = VehiclePointerArray.Nil;
            AltNative.Server.Server_GetVehicles(NativePointer, ref vehiclePointerArray);
            var vehiclePointers = vehiclePointerArray.ToArrayAndFree();
            foreach (var vehiclePointer in vehiclePointers)
            {
                if (vehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
                {
                    yield return vehicle;
                }
            }
        }

        public void StartResource(string name)
        {
            var namePtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
            AltNative.Server.Server_StartResource(NativePointer, namePtr);
            Marshal.FreeHGlobal(namePtr);
        }

        public void StopResource(string name)
        {
            var namePtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
            AltNative.Server.Server_StopResource(NativePointer, namePtr);
            Marshal.FreeHGlobal(namePtr);
        }

        public void RestartResource(string name)
        {
            var namePtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
            AltNative.Server.Server_RestartResource(NativePointer, namePtr);
            Marshal.FreeHGlobal(namePtr);
        }
    }
}