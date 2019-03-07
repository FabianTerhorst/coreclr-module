using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Pools
{
    public abstract class EntityPool<TEntity> : IEntityPool<TEntity> where TEntity : IEntity
    {
        public static void SetEntityNoLongerExists(TEntity entity)
        {
            if (entity is IInternalBaseObject internalEntity)
            {
                internalEntity.Exists = false;
            }
        }

        private readonly Dictionary<IntPtr, TEntity> entities = new Dictionary<IntPtr, TEntity>();

        private readonly IEntityFactory<TEntity> entityFactory;

        protected EntityPool(IEntityFactory<TEntity> entityFactory)
        {
            this.entityFactory = entityFactory;
        }

        public abstract ushort GetId(IntPtr entityPointer);

        public void Create(IntPtr entityPointer, ushort id, out TEntity entity)
        {
            entity = entityFactory.Create(entityPointer, id);
            Add(entity);
        }

        public void Create(IntPtr entityPointer, out TEntity entity)
        {
            Create(entityPointer, GetId(entityPointer), out entity);
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
            SetEntityNoLongerExists(entity);
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

            Create(entityPointer, out entity);

            return entity.Exists;
        }
        
        public bool GetOrCreate(IntPtr entityPointer, ushort entityId, out TEntity entity)
        {
            if (entityPointer == IntPtr.Zero)
            {
                entity = default;
                return false;
            }

            if (entities.TryGetValue(entityPointer, out entity)) return entity.Exists;

            Create(entityPointer, entityId, out entity);

            return entity.Exists;
        }

        public ICollection<TEntity> GetAllEntities()
        {
            return entities.Values;
        }
    }
}