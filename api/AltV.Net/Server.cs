using System;
using System.Runtime.InteropServices;
using System.Text;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net
{
    public class Server : IServer
    {
        public readonly IntPtr NativePointer;

        private readonly IBaseBaseObjectPool baseBaseObjectPool;

        private readonly IBaseEntityPool baseEntityPool;

        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;

        private readonly IBaseObjectPool<IBlip> blipPool;

        private readonly IBaseObjectPool<ICheckpoint> checkpointPool;

        private readonly IBaseObjectPool<IVoiceChannel> voiceChannelPool;

        private readonly IBaseObjectPool<IColShape> colShapePool;

        public Server(IntPtr nativePointer, IBaseBaseObjectPool baseBaseObjectPool, IBaseEntityPool baseEntityPool,
            IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool)
        {
            this.NativePointer = nativePointer;
            this.baseBaseObjectPool = baseBaseObjectPool;
            this.baseEntityPool = baseEntityPool;
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
            this.blipPool = blipPool;
            this.checkpointPool = checkpointPool;
            this.voiceChannelPool = voiceChannelPool;
            this.colShapePool = colShapePool;
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
            var mValues = MValue.CreateFromObjects(args);
            TriggerServerEvent(eventNamePtr, mValues);
            MValue.Dispose(mValues);
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
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
            var mValues = MValue.CreateFromObjects(args);
            TriggerClientEvent(player, eventNamePtr, mValues);
            MValue.Dispose(mValues);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params object[] args)
        {
            var mValues = MValue.CreateFromObjects(args);
            TriggerClientEvent(player, eventName, mValues);
            MValue.Dispose(mValues);
        }

        public IVehicle CreateVehicle(uint model, Position pos, Rotation rotation)
        {
            ushort id = default;
            vehiclePool.Create(AltNative.Server.Server_CreateVehicle(NativePointer, model, pos, rotation, ref id), id,
                out var vehicle);
            return vehicle;
        }

        public ICheckpoint CreateCheckpoint(IPlayer player, byte type, Position pos, float radius, float height,
            Rgba color)
        {
            checkpointPool.Create(AltNative.Server.Server_CreateCheckpoint(NativePointer,
                player?.NativePointer ?? IntPtr.Zero,
                type, pos, radius, height, color), out var checkpoint);
            return checkpoint;
        }

        public IBlip CreateBlip(IPlayer player, byte type, Position pos)
        {
            blipPool.Create(AltNative.Server.Server_CreateBlip(NativePointer, player?.NativePointer ?? IntPtr.Zero,
                type, pos), out var blip);
            return blip;
        }

        public IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach)
        {
            blipPool.Create(AltNative.Server.Server_CreateBlipAttached(NativePointer,
                player?.NativePointer ?? IntPtr.Zero,
                type, entityAttach.NativePointer), out var blip);
            return blip;
        }

        public IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance)
        {
            voiceChannelPool.Create(AltNative.Server.Server_CreateVoiceChannel(NativePointer,
                spatial, maxDistance), out var voiceChannel);
            return voiceChannel;
        }

        public IColShape CreateColShapeCylinder(Position pos, float radius, float height)
        {
            colShapePool.Create(AltNative.Server.Server_CreateColShapeCylinder(NativePointer, pos, radius, height),
                out var colShape);
            return colShape;
        }

        public IColShape CreateColShapeSphere(Position pos, float radius)
        {
            colShapePool.Create(AltNative.Server.Server_CreateColShapeSphere(NativePointer, pos, radius),
                out var colShape);
            return colShape;
        }

        public IColShape CreateColShapeCircle(Position pos, float radius)
        {
            colShapePool.Create(AltNative.Server.Server_CreateColShapeCircle(NativePointer, pos, radius),
                out var colShape);
            return colShape;
        }

        public IColShape CreateColShapeCube(Position pos, Position pos2)
        {
            colShapePool.Create(AltNative.Server.Server_CreateColShapeCube(NativePointer, pos, pos2), out var colShape);
            return colShape;
        }

        public IColShape CreateColShapeRectangle(Position pos, Position pos2)
        {
            colShapePool.Create(AltNative.Server.Server_CreateColShapeRectangle(NativePointer, pos, pos2),
                out var colShape);
            return colShape;
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

        public ServerNativeResource GetResource(string name)
        {
            var resourcePointer = IntPtr.Zero;
            AltNative.Server.Server_GetResource(NativePointer, name, ref resourcePointer);
            return resourcePointer == IntPtr.Zero ? null : new ServerNativeResource(resourcePointer);
        }

        public IntPtr CreateVehicleEntity(out ushort id, uint model, Position pos, Rotation rotation)
        {
            id = default;
            return AltNative.Server.Server_CreateVehicle(NativePointer, model, pos, rotation, ref id);
        }
    }
}