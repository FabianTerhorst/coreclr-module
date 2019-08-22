using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public abstract class BaseObjectPool<TBaseObject> : IBaseObjectPool<TBaseObject> where TBaseObject : IBaseObject
    {
        public static void SetEntityNoLongerExists(TBaseObject entity)
        {
            if (!(entity is IInternalBaseObject internalEntity)) return;
            internalEntity.Exists = false;
            internalEntity.ClearData();
        }

        private readonly Dictionary<IntPtr, TBaseObject> entities = new Dictionary<IntPtr, TBaseObject>();

        private readonly IBaseObjectFactory<TBaseObject> entityFactory;

        protected BaseObjectPool(IBaseObjectFactory<TBaseObject> entityFactory)
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
            if (!entities.Remove(entityPointer, out var entity) || !entity.Exists) return false;
            entity.OnRemove();
            SetEntityNoLongerExists(entity);
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