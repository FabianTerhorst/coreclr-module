using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public abstract class EntityPool<TEntity> : IEntityPool<TEntity> where TEntity : IEntity
    {
        private readonly Dictionary<IntPtr, TEntity> entities = new Dictionary<IntPtr, TEntity>();

        private readonly IEntityFactory<TEntity> entityFactory;

        protected EntityPool(IEntityFactory<TEntity> entityFactory)
        {
            this.entityFactory = entityFactory;
        }

        public TEntity Create(IntPtr entityPointer)
        {
            var entity = entityFactory.Create(entityPointer);
            Add(entity);
            return entity;
        }

        public void Add(TEntity entity)
        {
            entities[entity.NativePointer] = entity;
        }

        public bool Remove(TEntity entity)
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

        public bool Get(IntPtr entityPointer, out TEntity entity)
        {
            return entities.TryGetValue(entityPointer, out entity) && entity.Exists;
        }

        public bool GetOrCreate(IntPtr entityPointer, out TEntity entity)
        {
            if (entityPointer == IntPtr.Zero)
            {
                entity = default;
                return false;
            }

            if (entities.TryGetValue(entityPointer, out entity)) return entity.Exists;
            entity = entityFactory.Create(entityPointer);
            Add(entity);

            return entity.Exists;
        }

        public Dictionary<IntPtr, TEntity>.ValueCollection GetAllEntities()
        {
            return entities.Values;
        }
    }
}