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
        public static Server Instance { get; private set; }

        private readonly IntPtr nativePointer;

        private readonly IBaseEntityPool baseEntityPool;

        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;

        private readonly IEntityPool<IBlip> blipPool;

        private readonly IEntityPool<ICheckpoint> checkpointPool;

        internal Server(IntPtr nativePointer, IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IBlip> blipPool,
            IEntityPool<ICheckpoint> checkpointPool)
        {
            this.nativePointer = nativePointer;
            this.baseEntityPool = baseEntityPool;
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
            this.blipPool = blipPool;
            this.checkpointPool = checkpointPool;
            Instance = this;
        }

        public void LogInfo(string message)
        {
            AltVNative.Server.Server_LogInfo(nativePointer, message);
        }

        public void LogDebug(string message)
        {
            AltVNative.Server.Server_LogDebug(nativePointer, message);
        }

        public void LogWarning(string message)
        {
            AltVNative.Server.Server_LogWarning(nativePointer, message);
        }

        public void LogError(string message)
        {
            AltVNative.Server.Server_LogError(nativePointer, message);
        }

        public void LogColored(string message)
        {
            AltVNative.Server.Server_LogColored(nativePointer, message);
        }

        public uint Hash(string hash)
        {
            return AltVNative.Server.Server_Hash(nativePointer, hash);
        }

        public void TriggerServerEvent(string eventName, params MValue[] args)
        {
            var mValueList = MValue.Nil;
            AltVNative.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValueList);
            AltVNative.Server.Server_TriggerServerEvent(nativePointer, eventName, ref mValueList);
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
            TriggerServerEvent(eventName, ConvertObjectsToMValues(args));
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params MValue[] args)
        {
            var mValueList = MValue.Nil;
            AltVNative.MValueCreate.MValue_CreateList(args, (ulong) args.Length, ref mValueList);
            AltVNative.Server.Server_TriggerClientEvent(nativePointer, player?.NativePointer ?? IntPtr.Zero, eventName,
                ref mValueList);
        }

        public void TriggerClientEvent(IPlayer player, string eventName, params object[] args)
        {
            TriggerClientEvent(player, eventName, ConvertObjectsToMValues(args));
        }

        private static MValue[] ConvertObjectsToMValues(IEnumerable<object> objects)
        {
            return (from obj in objects
                select MValue.CreateFromObject(obj)
                into mValue
                where mValue.HasValue
                select mValue.Value).ToArray();
        }

        public IVehicle CreateVehicle(uint model, Position pos, float heading)
        {
            var vehicle =
                vehiclePool.Create(AltVNative.Server.Server_CreateVehicle(nativePointer, model, pos, heading));
            return vehicle;
        }

        public ICheckpoint CreateCheckpoint(IPlayer player, byte type, Position pos, float radius, float height,
            Rgba color)
        {
            var checkpoint =
                checkpointPool.Create(AltVNative.Server.Server_CreateCheckpoint(nativePointer, player.NativePointer,
                    type, pos, radius, height, color));
            return checkpoint;
        }

        public IBlip CreateBlip(IPlayer player, byte type, Position pos)
        {
            var blip =
                blipPool.Create(AltVNative.Server.Server_CreateBlip(nativePointer, player.NativePointer,
                    type, pos));
            return blip;
        }

        public IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach)
        {
            var blip =
                blipPool.Create(AltVNative.Server.Server_CreateBlipAttached(nativePointer, player.NativePointer,
                    type, entityAttach.NativePointer));
            return blip;
        }

        public bool RemoveEntity(IEntity entity)
        {
            if (!baseEntityPool.Remove(entity))
            {
                return false;
            }

            AltVNative.Server.Server_RemoveEntity(nativePointer, entity.NativePointer);
            return true;
        }
    }
}