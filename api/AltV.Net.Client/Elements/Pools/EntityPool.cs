using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;

namespace AltV.Net.Client.Elements.Pools
{
    public abstract class EntityPool<TEntity> : IEntityPool<TEntity> where TEntity : class, IEntity
    {
        private readonly Dictionary<IntPtr, TEntity> _entities = new();
        private readonly Dictionary<IntPtr, WeakReference<TEntity>> cache = new();
        protected IEntityFactory<TEntity> _entityFactory;

        public EntityPool(IEntityFactory<TEntity> entityFactory)
        {
            this._entityFactory = entityFactory;
        }

        protected abstract ushort GetId(IntPtr highestPointer);


        public TEntity? Create(ICore core, IntPtr entityPointer, ushort id)
        {
            if (_entities.TryGetValue(entityPointer, out var entity)) return entity;
            entity = _entityFactory.Create(core, entityPointer, id);
            Add(entity);
            return entity;
        }

        public TEntity? Create(ICore core, IntPtr entityPointer)
        {
            return Create(core, entityPointer, GetId(entityPointer));
        }

        public void Add(TEntity entity)
        {
            _entities[entity.NativePointer] = entity;
            OnAdd(entity);
        }

        public bool Remove(TEntity entity)
        {
            return Remove(entity.NativePointer);
        }

        public bool Remove(IntPtr entityPointer)
        {
            if (!_entities.Remove(entityPointer, out var entity) || entity is not IInternalBaseObject internalEntity || !entity.Exists) return false;
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

                entity.OnRemove();
                BaseObjectPool<TEntity>.SetEntityNoLongerExists(entity);
            }
            OnRemove(entity);
            return true;
        }

        public TEntity? Get(IntPtr entityPointer)
        {
            if (_entities.TryGetValue(entityPointer, out var entity)) return entity;
            
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

        public IReadOnlyCollection<TEntity> GetAllEntities()
        {
            return _entities.Values;
        }

        public TEntity GetOrCreate(ICore core, IntPtr entityPointer, ushort entityId)
        {
            if (Get(entityPointer) is { } entity) return entity;

            entity = _entityFactory.Create(core, entityPointer, entityId);
            Add(entity);

            return entity;
        }

        public TEntity GetOrCreate(ICore core, IntPtr entityPointer)
        {
            return this.GetOrCreate(core, entityPointer, GetId(entityPointer));
        }

        public KeyValuePair<IntPtr, TEntity>[] GetEntitiesArray()
        {
            var arr = new KeyValuePair<IntPtr, TEntity>[_entities.Count];
            var i = 0;
            foreach (var (ptr, entity) in _entities)
            {
                arr[i++] = new KeyValuePair<IntPtr, TEntity>(ptr, entity);
            }

            return arr;
        }

        public virtual void OnAdd(TEntity entity)
        {
        }

        public virtual void OnRemove(TEntity entity)
        {
        }

        public void Dispose()
        {
            _entities.Clear();
        }
    }
}