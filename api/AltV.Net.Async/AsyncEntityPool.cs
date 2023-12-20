using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;
using AltV.Net.Shared;

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

    public abstract class AsyncEntityPool<TEntity> : IEntityPool<TEntity> where TEntity : class, IEntity
    {
        private readonly ConcurrentDictionary<IntPtr, TEntity> entities = new();

        private readonly IEntityFactory<TEntity> entityFactory;
        private readonly Dictionary<IntPtr, WeakReference<TEntity>> cache = new();
        private readonly bool forceAsync;

        public AsyncEntityPool(IEntityFactory<TEntity> entityFactory, bool forceAsync)
        {
            this.entityFactory = entityFactory;
            this.forceAsync = forceAsync;
        }

        public abstract uint GetId(IntPtr entityPointer);

        public TEntity Create(ICore core, IntPtr entityPointer, uint id)
        {
            if (entityPointer == IntPtr.Zero) return default;
            if (entities.TryGetValue(entityPointer, out var entity)) return entity;
            entity = entityFactory.Create(core, entityPointer, id);
            Add(entity);
            return entity;
        }

        public TEntity Create(ICore core, IntPtr entityPointer)
        {
            return Create(core, entityPointer, GetId(entityPointer));
        }

        public void Add(TEntity entity)
        {
            entities[entity.NativePointer] = entity;
            if (forceAsync && entity is not AsyncEntity)
                throw new Exception("Tried to add sync entity to async pool. Probably you used \"new Vehicle\" syntax (should be \"new AsyncVehicle\"), or didn't adapt your custom entity class to new Async API.");
            OnAdd(entity);
        }

        public bool Remove(TEntity entity)
        {
            return Remove(entity.NativePointer);
        }

        //TODO: what should happen on failure
        public bool Remove(IntPtr entityPointer)
        {
            if (!entities.TryRemove(entityPointer, out var entity) || entity is not IInternalBaseObject internalEntity || !entity.Exists) return false;
            lock (entity)
            {
                if (AltShared.CacheEntities)
                {
                    unsafe
                    {
                        var ptr = entity.Core.Library.Shared.BaseObject_TryCache(entity.BaseObjectNativePointer);
                        if (ptr != IntPtr.Zero)
                        {
                            internalEntity.SetCached(ptr);
                            cache[entity.NativePointer] = new WeakReference<TEntity>(entity);
                        }
                    }
                }
                entity.OnDestroy();
                BaseObjectPool<TEntity>.SetEntityNoLongerExists(entity);
            }

            OnRemove(entity);
            return true;
        }

        public TEntity Get(IntPtr entityPointer)
        {
            if (entities.TryGetValue(entityPointer, out var entity)) return entity;

            lock (cache) {
                if (cache.TryGetValue(entityPointer, out var cachedEntity))
                {
                    if (cachedEntity.TryGetTarget(out entity))
                    {
                        return entity;
                    }
                    cache.Remove(entityPointer);
                }
            }

            return default;
        }

        public TEntity GetOrCreate(ICore core, IntPtr entityPointer)
        {
            if (entityPointer == IntPtr.Zero)
            {
                return default;
            }

            if (Get(entityPointer) is { } entity) return entity;

            return Create(core, entityPointer);
        }

        public TEntity GetOrCreate(ICore core, IntPtr entityPointer, uint id)
        {
            if (entityPointer == IntPtr.Zero)
            {
                return default;
            }

            if (Get(entityPointer) is { } entity) return entity;

            return Create(core, entityPointer, id);
        }

        public IReadOnlyCollection<TEntity> GetAllEntities()
        {
            return (IReadOnlyCollection<TEntity>) entities.Values;
        }

        public KeyValuePair<IntPtr, TEntity>[] GetEntitiesArray()
        {
            return entities.ToArray();
        }

        public abstract void ForEach(IBaseObjectCallback<TEntity> baseObjectCallback);

        public abstract Task ForEach(IAsyncBaseObjectCallback<TEntity> asyncBaseObjectCallback);

        public virtual void OnAdd(TEntity entity)
        {
        }

        public virtual void OnRemove(TEntity entity)
        {
        }

        public void Dispose()
        {
            foreach (var entity in entities.Values)
            {
                if (!(entity is IInternalBaseObject internalEntity)) continue;
                internalEntity.ClearData();
                entity.OnDestroy();
                OnRemove(entity);
            }
            entities.Clear();
        }
    }
}