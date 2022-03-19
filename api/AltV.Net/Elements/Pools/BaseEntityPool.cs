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

        public bool GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, out IEntity entity)
        {
            bool result;
            switch (baseObjectType)
            {
                case BaseObjectType.Player:
                    var player = playerPool.GetOrCreate(core, entityPointer);
                    entity = player;
                    return player is not null;
                case BaseObjectType.Vehicle:
                    var vehicle = vehiclePool.GetOrCreate(core, entityPointer);
                    entity = vehicle;
                    return vehicle is not null;
                default:
                    entity = default;
                    return false;
            }
        }

        public bool Get(IntPtr entityPointer, BaseObjectType baseObjectType, out IEntity entity)
        {
            bool result;
            switch (baseObjectType)
            {
                case BaseObjectType.Player:
                    var player = playerPool.Get(entityPointer);
                    entity = player;
                    return player is not null;
                case BaseObjectType.Vehicle:
                    var vehicle = vehiclePool.Get(entityPointer);
                    entity = vehicle;
                    return vehicle is not null;
                default:
                    entity = default;
                    return false;
            }
        }

        public bool GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, ushort entityId, out IEntity entity)
        {
            bool result;
            switch (baseObjectType)
            {
                case BaseObjectType.Player:
                    var player = playerPool.GetOrCreate(core, entityPointer, entityId);
                    entity = player;
                    return player is not null;
                case BaseObjectType.Vehicle:
                    var vehicle = vehiclePool.GetOrCreate(core, entityPointer, entityId);
                    entity = vehicle;
                    return vehicle is not null;
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