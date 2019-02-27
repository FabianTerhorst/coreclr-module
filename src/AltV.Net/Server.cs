using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net
{
    public class Server : IServer
    {
        public readonly IntPtr NativePointer;

        private readonly IBaseEntityPool baseEntityPool;

        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;

        private readonly IEntityPool<IBlip> blipPool;

        private readonly IEntityPool<ICheckpoint> checkpointPool;

        public Server(IntPtr nativePointer, IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IBlip> blipPool,
            IEntityPool<ICheckpoint> checkpointPool)
        {
            this.NativePointer = nativePointer;
            this.baseEntityPool = baseEntityPool;
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
            this.blipPool = blipPool;
            this.checkpointPool = checkpointPool;
        }

        public void LogInfo(string message)
        {
            AltVNative.Server.Server_LogInfo(NativePointer, message);
        }

        public void LogDebug(string message)
        {
            AltVNative.Server.Server_LogDebug(NativePointer, message);
        }

        public void LogWarning(string message)
        {
            AltVNative.Server.Server_LogWarning(NativePointer, message);
        }

        public void LogError(string message)
        {
            AltVNative.Server.Server_LogError(NativePointer, message);
        }

        public void LogColored(string message)
        {
            AltVNative.Server.Server_LogColored(NativePointer, message);
        }

        public uint Hash(string hash)
        {
            return AltVNative.Server.Server_Hash(NativePointer, hash);
        }

        public void TriggerServerEvent(string eventName, params MValue[] args)
        {
            var mValueList = MValue.Nil;
            AltVNative.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValueList);
            AltVNative.Server.Server_TriggerServerEvent(NativePointer, eventName, ref mValueList);
        }

        public void TriggerServerEvent(string eventName, ref MValue args)
        {
            AltVNative.Server.Server_TriggerServerEvent(NativePointer, eventName, ref args);
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
            TriggerServerEvent(eventName, MValue.CreateFromObjects(args));
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params MValue[] args)
        {
            var mValueList = MValue.Nil;
            AltVNative.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValueList);
            AltVNative.Server.Server_TriggerClientEvent(NativePointer, player?.NativePointer ?? IntPtr.Zero, eventName,
                ref mValueList);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, ref MValue args)
        {
            AltVNative.Server.Server_TriggerClientEvent(NativePointer, player?.NativePointer ?? IntPtr.Zero, eventName,
                ref args);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params object[] args)
        {
            TriggerClientEvent(player, eventName, MValue.CreateFromObjects(args));
        }

        public IVehicle CreateVehicle(uint model, Position pos, float heading)
        {
            ushort id = default;
            vehiclePool.Create(AltVNative.Server.Server_CreateVehicle(NativePointer, model, pos, heading, ref id), id,
                out var vehicle);
            return vehicle;
        }

        public ICheckpoint CreateCheckpoint(IPlayer player, byte type, Position pos, float radius, float height,
            Rgba color)
        {
            ushort id = default;
            checkpointPool.Create(AltVNative.Server.Server_CreateCheckpoint(NativePointer, player?.NativePointer ?? IntPtr.Zero,
                type, pos, radius, height, color, ref id), id, out var checkpoint);
            return checkpoint;
        }

        public IBlip CreateBlip(IPlayer player, byte type, Position pos)
        {
            ushort id = default;
            blipPool.Create(AltVNative.Server.Server_CreateBlip(NativePointer, player?.NativePointer ?? IntPtr.Zero,
                type, pos, ref id), id, out var blip);
            return blip;
        }

        public IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach)
        {
            ushort id = default;
            blipPool.Create(AltVNative.Server.Server_CreateBlipAttached(NativePointer,
                player?.NativePointer ?? IntPtr.Zero,
                type, entityAttach.NativePointer, ref id), id, out var blip);
            return blip;
        }

        public void RemoveEntity(IEntity entity)
        {
            if (entity.Exists)
            {
                AltVNative.Server.Server_RemoveEntity(NativePointer, entity.NativePointer);
            }
        }

        public ServerNativeResource GetResource(string name)
        {
            var resourcePointer = IntPtr.Zero;
            AltVNative.Server.Server_GetResource(NativePointer, name, ref resourcePointer);
            return resourcePointer == IntPtr.Zero ? null : new ServerNativeResource(resourcePointer);
        }
    }
}