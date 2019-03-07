using System;
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

        public Server(IntPtr nativePointer, IBaseBaseObjectPool baseBaseObjectPool, IBaseEntityPool baseEntityPool,
            IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool)
        {
            this.NativePointer = nativePointer;
            this.baseBaseObjectPool = baseBaseObjectPool;
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

        public uint Hash(string stringToHash)
        {
            //return AltVNative.Server.Server_Hash(NativePointer, hash);
            if (string.IsNullOrEmpty(stringToHash))
            {
                return 0;
            }

            var characters = Encoding.UTF8.GetBytes(stringToHash.ToLower());

            uint hash = 0;

            foreach (var t in characters)
            {
                hash += t;
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
            checkpointPool.Create(AltVNative.Server.Server_CreateCheckpoint(NativePointer,
                player?.NativePointer ?? IntPtr.Zero,
                type, pos, radius, height, color), out var checkpoint);
            return checkpoint;
        }

        public IBlip CreateBlip(IPlayer player, byte type, Position pos)
        {
            blipPool.Create(AltVNative.Server.Server_CreateBlip(NativePointer, player?.NativePointer ?? IntPtr.Zero,
                type, pos), out var blip);
            return blip;
        }

        public IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach)
        {
            blipPool.Create(AltVNative.Server.Server_CreateBlipAttached(NativePointer,
                player?.NativePointer ?? IntPtr.Zero,
                type, entityAttach.NativePointer), out var blip);
            return blip;
        }

        public void RemoveEntity(IEntity entity)
        {
            if (entity.Exists)
            {
                AltVNative.Server.Server_RemoveEntity(NativePointer, entity.NativePointer);
            }
        }

        public void RemoveBlip(IBlip blip)
        {
            if (blip.Exists)
            {
                AltVNative.Server.Server_RemoveBlip(NativePointer, blip.NativePointer);
            }
        }

        public void RemoveCheckpoint(ICheckpoint checkpoint)
        {
            if (checkpoint.Exists)
            {
                AltVNative.Server.Server_RemoveCheckpoint(NativePointer, checkpoint.NativePointer);
            }
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            if (vehicle.Exists)
            {
                AltVNative.Server.Server_RemoveVehicle(NativePointer, vehicle.NativePointer);
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