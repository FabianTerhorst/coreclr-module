using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public abstract class EntityPool<TEntity> : IEntityPool<TEntity> where TEntity : IEntity
    {
        private readonly Dictionary<IntPtr, TEntity> _entities = new();
        private IEntityFactory<TEntity> _entityFactory;

        public EntityPool(IEntityFactory<TEntity> entityFactory)
        {
            this._entityFactory = entityFactory;
        }

        protected abstract ushort GetId(IntPtr highestPointer);
        
        
        public TEntity? Create(ICore server, IntPtr entityPointer, ushort id)
        {
            if (_entities.TryGetValue(entityPointer, out var entity)) return entity;
            entity = _entityFactory.Create(server, entityPointer, id);
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
            if (!_entities.Remove(entityPointer, out var entity) || !entity.Exists) return false;
            // todo call on remove
            // todo set exists false
            OnRemove(entity);
            return true;
        }
        
        public TEntity? Get(IntPtr entityPointer)
        {
            if (!_entities.TryGetValue(entityPointer, out var entity)) return default;
            return entity;
        }
        
        public TEntity GetOrCreate(ICore core, IntPtr entityPointer, ushort entityId)
        {
            if (_entities.TryGetValue(entityPointer, out var entity)) return entity;

            entity = _entityFactory.Create(core, entityPointer, entityId);
            Add(entity);

            return entity;
        }
        
        public TEntity GetOrCreate(ICore core, IntPtr entityPointer)
        {
            return this.GetOrCreate(core, entityPointer, GetId(entityPointer));
        }

        public ICollection<TEntity> GetAllEntities()
        {
            return _entities.Values;
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