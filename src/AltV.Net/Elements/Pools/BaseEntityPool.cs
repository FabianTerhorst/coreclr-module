using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Pools
{
    public class BaseEntityPool : IBaseEntityPool
    {
        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;

        private readonly IEntityPool<IBlip> blipPool;

        private readonly IEntityPool<ICheckpoint> checkpointPool;

        public BaseEntityPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IBlip> blipPool,
            IEntityPool<ICheckpoint> checkpointPool)
        {
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
            this.blipPool = blipPool;
            this.checkpointPool = checkpointPool;
        }

        public virtual EntityType GetType(IntPtr entityPointer)
        {
            return AltVNative.Entity.BaseObject_GetType(entityPointer);
        }

        public bool GetOrCreate(IntPtr entityPointer, out IEntity entity)
        {
            if (entityPointer == IntPtr.Zero)
            {
                entity = default;
                return false;
            }

            var entityType = GetType(entityPointer);
            return GetOrCreate(entityPointer, entityType, out entity);
        }

        public bool GetOrCreate(IntPtr entityPointer, EntityType entityType, out IEntity entity)
        {
            bool result;
            switch (entityType)
            {
                case EntityType.Player:
                    result = playerPool.GetOrCreate(entityPointer, out var player);
                    entity = player;
                    return result;
                case EntityType.Vehicle:
                    result = vehiclePool.GetOrCreate(entityPointer, out var vehicle);
                    entity = vehicle;
                    return result;
                case EntityType.Blip:
                    result = blipPool.GetOrCreate(entityPointer, out var blip);
                    entity = blip;
                    return result;
                case EntityType.Checkpoint:
                    result = checkpointPool.GetOrCreate(entityPointer, out var checkpoint);
                    entity = checkpoint;
                    return result;
                default:
                    entity = default;
                    return false;
            }
        }

        public bool Remove(IntPtr entityPointer)
        {
            return entityPointer != IntPtr.Zero &&
                   Remove(GetType(entityPointer), entityPointer);
        }

        public bool Remove(IEntity entity)
        {
            return Remove(entity.Type, entity.NativePointer);
        }

        public bool Remove(EntityType entityType, IntPtr entityPointer)
        {
            switch (entityType)
            {
                case EntityType.Player:
                    return playerPool.Remove(entityPointer);
                case EntityType.Vehicle:
                    return vehiclePool.Remove(entityPointer);
                case EntityType.Blip:
                    return blipPool.Remove(entityPointer);
                case EntityType.Checkpoint:
                    return checkpointPool.Remove(entityPointer);
                default:
                    return false;
            }
        }
    }
}