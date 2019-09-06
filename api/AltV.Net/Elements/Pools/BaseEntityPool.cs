using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class BaseEntityPool : IBaseEntityPool
    {
        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;

        public BaseEntityPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool)
        {
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
        }

        public bool GetOrCreate(IntPtr entityPointer, BaseObjectType baseObjectType, out IEntity entity)
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
                default:
                    entity = default;
                    return false;
            }
        }

        public bool GetOrCreate(IntPtr entityPointer, BaseObjectType baseObjectType, ushort entityId, out IEntity entity)
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
                default:
                    entity = default;
                    return false;
            }
        }

        public bool Remove(IEntity entity)
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
                default:
                    return false;
            }
        }
    }
}