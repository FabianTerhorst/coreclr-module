using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;

namespace AltV.Net.Elements.Pools
{
    public abstract class EntityPool<TEntity> : IEntityPool<TEntity> where TEntity : class, IEntity
    {
        private readonly Dictionary<IntPtr, TEntity> entities = new();
        private readonly Dictionary<IntPtr, WeakReference<TEntity>> cache = new();

        private readonly IEntityFactory<TEntity> entityFactory;

        protected EntityPool(IEntityFactory<TEntity> entityFactory)
        {
            this.entityFactory = entityFactory;
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
            entities[entity.EntityNativePointer] = entity;
            OnAdd(entity);
        }

        public bool Remove(TEntity entity)
        {
            return Remove(entity.EntityNativePointer);
        }

        public bool Remove(IntPtr entityPointer)
        {
            if (!entities.Remove(entityPointer, out var entity) || entity is not IInternalBaseObject internalEntity || !entity.Exists) return false;

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
                            cache[entity.EntityNativePointer] = new WeakReference<TEntity>(entity);
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

            if (Get(entityPointer) is {} entity) return entity;

            return Create(core, entityPointer);
        }

        public TEntity GetOrCreate(ICore core, IntPtr entityPointer, uint entityId)
        {
            if (entityPointer == IntPtr.Zero)
            {
                return default;
            }

            if (Get(entityPointer) is {} entity) return entity;

            return Create(core, entityPointer, entityId);
        }

        public IReadOnlyCollection<TEntity> GetAllEntities()
        {
            return entities.Values;
        }

        public KeyValuePair<IntPtr, TEntity>[] GetEntitiesArray()
        {
            var arr = new KeyValuePair<IntPtr, TEntity>[entities.Count];
            var i = 0;
            foreach (var (ptr, entity) in entities)
            {
                arr[i++] = new KeyValuePair<IntPtr, TEntity>(ptr, entity);
            }

            return arr;
        }

        public void ForEach(IBaseObjectCallback<TEntity> baseObjectCallback)
        {
            foreach (var entity in entities.Values)
            {
                baseObjectCallback.OnBaseObject(entity);
            }
        }

        public async Task ForEach(IAsyncBaseObjectCallback<TEntity> asyncBaseObjectCallback)
        {
            foreach (var entity in entities.Values)
            {
                await asyncBaseObjectCallback.OnBaseObject(entity);
            }
        }

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