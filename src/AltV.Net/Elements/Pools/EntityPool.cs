using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Pools
{
    public class EntityPool : IEntityPool
    {
        private readonly Dictionary<IntPtr, IEntity> entities = new Dictionary<IntPtr, IEntity>();

        private readonly IVehicleFactory vehicleFactory;

        public EntityPool(IVehicleFactory vehicleFactory)
        {
            this.vehicleFactory = vehicleFactory;
        }

        public void Add(IEntity entity)
        {
            entities[entity.NativePointer] = entity;
        }

        public bool Get(IntPtr entityPointer, out IEntity entity)
        {
            return entities.TryGetValue(entityPointer, out entity) && entity.Exists;
        }

        public bool GetOrCreate(IntPtr entityPointer, out IEntity entity)
        {
            if (entityPointer == IntPtr.Zero)
            {
                entity = default;
                return false;
            }

            if (entities.TryGetValue(entityPointer, out entity)) return entity.Exists;
            var entityType = (EntityType) AltVNative.Entity.BaseObject_GetType(entityPointer);
            switch (entityType)
            {
                case EntityType.Player:
                    return false;
                case EntityType.Vehicle:
                    entity = vehicleFactory.Create(entityPointer);
                    Add(entity);
                    break;
                case EntityType.Blip:
                    return false;
                case EntityType.Checkpoint:
                    return false;
                default:
                    return false;
            }

            return entity.Exists;
        }

        public bool Remove(IEntity entity)
        {
            return Remove(entity.NativePointer);
        }

        public bool Remove(IntPtr entityPointer)
        {
            if (!entities.Remove(entityPointer, out var entity) || !entity.Exists) return false;
            if (entity is IInternalEntity internalEntity)
            {
                internalEntity.Exists = false;
            }

            return true;
        }
    }
}