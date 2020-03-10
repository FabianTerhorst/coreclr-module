using System.Collections.Generic;
using AltV.Net.Client.Elements.Entities;
using WebAssembly;

namespace AltV.Net.Client.Elements.Pools
{
    public class BaseObjectPool<TBaseObject> : IBaseObjectPool<TBaseObject> where TBaseObject : IBaseObject
    {
        /*public static void SetEntityNoLongerExists(TBaseObject entity)
        {
            if (!(entity is IInternalBaseObject internalEntity)) return;
            internalEntity.Exists = false;
            internalEntity.ClearData();
        }*/

        private readonly Dictionary<int, TBaseObject> entities = new Dictionary<int, TBaseObject>();

        private readonly IBaseObjectFactory<TBaseObject> entityFactory;

        public BaseObjectPool(IBaseObjectFactory<TBaseObject> entityFactory)
        {
            this.entityFactory = entityFactory;
        }

        public void Create(JSObject entityPointer)
        {
            Add(entityFactory.Create(entityPointer));
        }

        public void Create(JSObject entityPointer, out TBaseObject entity)
        {
            entity = entityFactory.Create(entityPointer);
            Add(entity);
        }

        public void Add(TBaseObject entity)
        {
            entities[entity.NativeObject.JSHandle] = entity;
            OnAdd(entity);
        }

        public bool Remove(TBaseObject entity)
        {
            return Remove(entity.NativeObject);
        }

        public bool Remove(JSObject entityPointer)
        {
            if (!entities.TryGetValue(entityPointer.JSHandle, out var entity) || !entity.Exists) return false;
            //entity.OnRemove();
            entities.Remove(entityPointer.JSHandle);
            //SetEntityNoLongerExists(entity);
            OnRemove(entity);
            return true;
        }

        public bool Get(JSObject entityPointer, out TBaseObject entity)
        {
            return entities.TryGetValue(entityPointer.JSHandle, out entity) && entity.Exists;
        }

        public bool GetOrCreate(JSObject entityPointer, out TBaseObject entity)
        {
            if (entityPointer == null)
            {
                entity = default;
                return false;
            }

            if (entities.TryGetValue(entityPointer.JSHandle, out entity)) return entity.Exists;

            Create(entityPointer, out entity);

            return entity.Exists;
        }

        public ICollection<TBaseObject> GetAllObjects()
        {
            return entities.Values;
        }

        public KeyValuePair<int, TBaseObject>[] GetObjectsArray()
        {
            var arr = new KeyValuePair<int, TBaseObject>[entities.Count];
            var i = 0;
            foreach (var keyValuePair in entities)
            {
                arr[i++] = new KeyValuePair<int, TBaseObject>(keyValuePair.Key, keyValuePair.Value);
            }

            return arr;
        }

        public virtual void OnAdd(TBaseObject entity)
        {
        }

        public virtual void OnRemove(TBaseObject entity)
        {
        }
    }
}