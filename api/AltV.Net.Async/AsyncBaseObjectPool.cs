using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Async
{
    public abstract class AsyncBaseObjectPool<TBaseObject> : IBaseObjectPool<TBaseObject>
        where TBaseObject : IBaseObject
    {
        private readonly ConcurrentDictionary<IntPtr, TBaseObject> entities =
            new ConcurrentDictionary<IntPtr, TBaseObject>();

        private readonly IBaseObjectFactory<TBaseObject> entityFactory;

        protected AsyncBaseObjectPool(IBaseObjectFactory<TBaseObject> entityFactory)
        {
            this.entityFactory = entityFactory;
        }

        public TBaseObject Create(ICore core, IntPtr entityPointer)
        {
            var entity = entityFactory.Create(core, entityPointer);
            Add(entity);
            return entity;
        }
        
        public void Add(TBaseObject entity)
        {
            entities[entity.NativePointer] = entity;
            OnAdd(entity);
        }

        public bool Remove(TBaseObject entity)
        {
            return Remove(entity.NativePointer);
        }

        public bool Remove(IntPtr entityPointer)
        {
            if (!entities.TryRemove(entityPointer, out var entity) || !entity.Exists) return false;
            entity.OnRemove();
            lock (entity)
            {
                BaseObjectPool<TBaseObject>.SetEntityNoLongerExists(entity);
            }

            OnRemove(entity);

            return true;
        }

        public TBaseObject Get(IntPtr entityPointer)
        {
            return entities.TryGetValue(entityPointer, out var entity) ? entity : default;
        }

        public TBaseObject GetOrCreate(ICore core, IntPtr entityPointer)
        {
            if (entityPointer == IntPtr.Zero)
            {
                return default;
            }

            if (entities.TryGetValue(entityPointer, out var entity)) return entity;

            entity = Create(core, entityPointer);

            return entity;
        }

        public IReadOnlyCollection<TBaseObject> GetAllObjects()
        {
            return (IReadOnlyCollection<TBaseObject>) entities.Values;
        }
        
        public KeyValuePair<IntPtr, TBaseObject>[] GetObjectsArray()
        {
            var arr = new KeyValuePair<IntPtr, TBaseObject>[entities.Count];
            var i = 0;
            foreach (var (ptr, entity) in entities)
            {
                arr[i++] = new KeyValuePair<IntPtr, TBaseObject>(ptr, entity);
            }

            return arr;
        }

        public abstract void ForEach(IBaseObjectCallback<TBaseObject> baseObjectCallback);

        public abstract Task ForEach(IAsyncBaseObjectCallback<TBaseObject> asyncBaseObjectCallback);

        public virtual void OnAdd(TBaseObject entity)
        {
        }

        public virtual void OnRemove(TBaseObject entity)
        {
        }

        public void Dispose()
        {
            foreach (var entity in entities.Values)
            {
                if (!(entity is IInternalBaseObject internalEntity)) continue;
                internalEntity.ClearData();
                entity.OnRemove();
                OnRemove(entity);
            }
            entities.Clear();
        }
    }
}