using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public class EntityPool : IEntityPool
    {
        private readonly Dictionary<IntPtr, IEntity> entities = new Dictionary<IntPtr, IEntity>();

        public void Register(IEntity entity)
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

        public void Remove(IEntity entity)
        {
            Remove(entity.NativePointer);
        }

        public void Remove(IntPtr entityPointer)
        {
            if (!entities.Remove(entityPointer, out var entity)) return;
            //todo find better solution
            if (entity is IInternalEntity internalEntity)
            {
                internalEntity.Exists = false;
            }
        }
    }
}