using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class EntityPool : IEntityPool
    {
        private readonly Dictionary<IntPtr, IEntity> entities = new Dictionary<IntPtr, IEntity>();

        public void Add(IEntity entity)
        {
            entities[entity.NativePointer] = entity;
        }

        public bool Get(IntPtr entityPointer, out IEntity entity)
        {
            if (!entities.TryGetValue(entityPointer, out var poolEntity) || !poolEntity.Exists)
            {
                entity = default;
                return false;
            }

            entity = poolEntity;
            return true;
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