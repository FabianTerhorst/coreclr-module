using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class BaseBaseObjectPool : IBaseBaseObjectPool
    {
        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;

        private readonly IBaseObjectPool<IBlip> blipPool;

        private readonly IBaseObjectPool<ICheckpoint> checkpointPool;

        public BaseBaseObjectPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool)
        {
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
            this.blipPool = blipPool;
            this.checkpointPool = checkpointPool;
        }

        public bool GetOrCreate(IntPtr entityPointer, BaseObjectType baseObjectType, out IBaseObject entity)
        {
            bool result;
            switch (baseObjectType)
            {
                case BaseObjectType.Player:
                    result = playerPool.GetOrCreate(entityPointer, out var player);
                    entity = player;
                    return result;
                case BaseObjectType.Vehicle:
                    result = vehiclePool.GetOrCreate(entityPointer, out var vehicle);
                    entity = vehicle;
                    return result;
                case BaseObjectType.Blip:
                    result = blipPool.GetOrCreate(entityPointer, out var blip);
                    entity = blip;
                    return result;
                case BaseObjectType.Checkpoint:
                    result = checkpointPool.GetOrCreate(entityPointer, out var checkpoint);
                    entity = checkpoint;
                    return result;
                default:
                    entity = default;
                    return false;
            }
        }

        public bool GetOrCreate(IntPtr entityPointer, BaseObjectType baseObjectType, ushort entityId, out IBaseObject entity)
        {
            bool result;
            switch (baseObjectType)
            {
                case BaseObjectType.Player:
                    result = playerPool.GetOrCreate(entityPointer, entityId, out var player);
                    entity = player;
                    return result;
                case BaseObjectType.Vehicle:
                    result = vehiclePool.GetOrCreate(entityPointer, entityId, out var vehicle);
                    entity = vehicle;
                    return result;
                case BaseObjectType.Blip:
                    result = blipPool.GetOrCreate(entityPointer, out var blip);
                    entity = blip;
                    return result;
                case BaseObjectType.Checkpoint:
                    result = checkpointPool.GetOrCreate(entityPointer, out var checkpoint);
                    entity = checkpoint;
                    return result;
                default:
                    entity = default;
                    return false;
            }
        }

        public bool Remove(IBaseObject entity)
        {
            return Remove(entity.NativePointer, entity.Type);
        }

        public bool Remove(IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            switch (baseObjectType)
            {
                case BaseObjectType.Player:
                    return playerPool.Remove(entityPointer);
                case BaseObjectType.Vehicle:
                    return vehiclePool.Remove(entityPointer);
                case BaseObjectType.Blip:
                    return blipPool.Remove(entityPointer);
                case BaseObjectType.Checkpoint:
                    return checkpointPool.Remove(entityPointer);
                default:
                    return false;
            }
        }
    }
}