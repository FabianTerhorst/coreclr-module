using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public abstract class BaseObjectPool<TBaseObject> : IBaseObjectPool<TBaseObject> where TBaseObject : IBaseObject
    {
        public abstract uint GetId(IntPtr entityPointer);
        public static void SetEntityNoLongerExists(TBaseObject entity)
        {
            if (entity is not IInternalBaseObject internalEntity) return;
            internalEntity.Exists = false;
            if (!entity.Cached)
            {
                internalEntity.ClearData();
            }
        }

        private readonly Dictionary<IntPtr, TBaseObject> entities = new ();

        private readonly IBaseObjectFactory<TBaseObject> entityFactory;

        protected BaseObjectPool(IBaseObjectFactory<TBaseObject> entityFactory)
        {
            this.entityFactory = entityFactory;
        }

        public TBaseObject Create(ICore core, IntPtr entityPointer, uint id)
        {
            if (entityPointer == IntPtr.Zero) return default;
            if (entities.TryGetValue(entityPointer, out var baseObject)) return baseObject;
            baseObject = entityFactory.Create(core, entityPointer, id);
            Add(baseObject);
            return baseObject;
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
            entity.OnDestroy();
            lock (entity)
            {
                SetEntityNoLongerExists(entity);
            }

            OnRemove(entity);
            return true;
        }

        public TBaseObject GetOrCreate(ICore core, IntPtr entityPointer, uint entityId)
        {
            if (entityPointer == IntPtr.Zero)
            {
                return default;
            }

            if (entities.TryGetValue(entityPointer, out var entity)) return entity;

            return Create(core, entityPointer, entityId);
        }

        public TBaseObject Get(IntPtr entityPointer)
        {
            return entities.TryGetValue(entityPointer, out var baseObject) ? baseObject : default;
        }
        public TBaseObject GetOrCreate(ICore core, IntPtr entityPointer)
        {
            if (entityPointer == IntPtr.Zero)
            {
                return default;
            }

            if (entities.TryGetValue(entityPointer, out var entity)) return entity;

            return Create(core, entityPointer, GetId(entityPointer));
        }

        public IReadOnlyCollection<TBaseObject> GetAllObjects()
        {
            return entities.Values;
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

        public void ForEach(IBaseObjectCallback<TBaseObject> baseObjectCallback)
        {
            foreach (var entity in entities.Values)
            {
                baseObjectCallback.OnBaseObject(entity);
            }
        }

        public async Task ForEach(IAsyncBaseObjectCallback<TBaseObject> asyncBaseObjectCallback)
        {
            foreach (var entity in entities.Values)
            {
                await asyncBaseObjectCallback.OnBaseObject(entity);
            }
        }

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
                entity.OnDestroy();
                OnRemove(entity);
            }
            entities.Clear();
        }
    }
}