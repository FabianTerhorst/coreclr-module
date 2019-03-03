using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Async
{
    //TODO: write GetOrCreateAsync for BaseEntityPool
    /*public partial class AltAsync
    {
        /// <summary>
        /// Create entity async in entity pool, don't provide a IntPtr.Zero
        /// </summary>
        /// <param name="entityPool"></param>
        /// <param name="entityPointer"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public static async Task<TEntity> CreateAsync<TEntity>(this IEntityPool<TEntity> entityPool,
            IntPtr entityPointer) where TEntity : IEntity
        {
            var id = await Do(() => Entity.GetId(entityPointer));
            entityPool.Create(entityPointer, id, out var entity);
            return entity;
        }

        /// <summary>
        /// Get or create entity async in entity pool, don't provide a IntPtr.Zero
        /// </summary>
        /// <param name="entityPool"></param>
        /// <param name="entityPointer"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public static async Task<TEntity> GetOrCreateAsync<TEntity>(this IEntityPool<TEntity> entityPool,
            IntPtr entityPointer) where TEntity : IEntity
        {
            if (entityPool.Get(entityPointer, out var entity)) return entity;

            entity = await entityPool.CreateAsync(entityPointer);
            return entity;
        }
    }*/

    public abstract class AsyncEntityPool<TEntity> : IEntityPool<TEntity> where TEntity : IEntity
    {
        private readonly ConcurrentDictionary<IntPtr, TEntity> entities = new ConcurrentDictionary<IntPtr, TEntity>();

        private readonly IEntityFactory<TEntity> entityFactory;

        public AsyncEntityPool(IEntityFactory<TEntity> entityFactory)
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

        //TODO: what should happen on failure
        public void Add(TEntity entity)
        {
            entities.TryAdd(entity.NativePointer, entity);
        }

        public bool Remove(TEntity entity)
        {
            return Remove(entity.NativePointer);
        }

        //TODO: what should happen on failure
        public bool Remove(IntPtr entityPointer)
        {
            if (!entities.TryRemove(entityPointer, out var entity) || !entity.Exists) return false;
            EntityPool<TEntity>.SetEntityNoLongerExists(entity);
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
        
        public bool GetOrCreate(IntPtr entityPointer, ushort id, out TEntity entity)
        {
            if (entityPointer == IntPtr.Zero)
            {
                entity = default;
                return false;
            }

            if (entities.TryGetValue(entityPointer, out entity)) return entity.Exists;

            Create(entityPointer, id, out entity);

            return entity.Exists;
        }

        public ICollection<TEntity> GetAllEntities()
        {
            return entities.Values;
        }
    }
}