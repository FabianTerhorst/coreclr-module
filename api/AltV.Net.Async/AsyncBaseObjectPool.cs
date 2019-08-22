using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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

        public void Create(IntPtr entityPointer)
        {
            Add(entityFactory.Create(entityPointer));
        }

        public void Create(IntPtr entityPointer, out TBaseObject entity)
        {
            entity = entityFactory.Create(entityPointer);
            Add(entity);
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

        public bool Get(IntPtr entityPointer, out TBaseObject entity)
        {
            return entities.TryGetValue(entityPointer, out entity) && entity.Exists;
        }

        public bool GetOrCreate(IntPtr entityPointer, out TBaseObject entity)
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

        public ICollection<TBaseObject> GetAllObjects()
        {
            return entities.Values;
        }

        public virtual void OnAdd(TBaseObject entity)
        {
        }

        public virtual void OnRemove(TBaseObject entity)
        {
        }
    }
}