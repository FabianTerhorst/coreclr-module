using System;
using System.Collections.Generic;
using Entity;

namespace AltV.Net.NetworkingEntity
{
    public class EntityRepository
    {
        public event Action<Entity.Entity> EntityAddHandler;

        public event Action<ulong> EntityRemoveHandler;

        public event Action<ulong, Position> EntityPositionUpdateHandler;

        public event Action<ulong, string, MValue> EntityDataUpdateHandler;

        public Action<Entity.Entity> OnEntityAdd
        {
            set => EntityAddHandler += value;
            get => EntityAddHandler;
        }

        public Action<ulong> OnEntityRemove
        {
            set => EntityRemoveHandler += value;
            get => EntityRemoveHandler;
        }

        public Action<ulong, Position> OnEntityPositionUpdate
        {
            set => EntityPositionUpdateHandler += value;
            get => EntityPositionUpdateHandler;
        }

        public Action<ulong, string, MValue> OnEntityDataUpdate
        {
            set => EntityDataUpdateHandler += value;
            get => EntityDataUpdateHandler;
        }

        public readonly Dictionary<ulong, Entity.Entity> Entities = new Dictionary<ulong, Entity.Entity>();

        public void Add(Entity.Entity entity)
        {
            lock (Entities)
            {
                Entities[entity.Id] = entity;
                if (EntityAddHandler == null) return;
                EntityAddHandler(entity);
            }
        }

        public Entity.Entity Get(ulong id)
        {
            lock (Entities)
            {
                return Entities[id];
            }
        }

        public void Delete(ulong id)
        {
            lock (Entities)
            {
                if (!Entities.Remove(id)) return;
                if (EntityRemoveHandler == null) return;
                EntityRemoveHandler(id);
            }
        }

        public void UpdatePosition(ulong id, Position position)
        {
            lock (Entities)
            {
                var entity = Entities[id];
                entity.Position = position;
                if (EntityPositionUpdateHandler == null) return;
                EntityPositionUpdateHandler(id, position);
            }
        }

        public void UpdateData(ulong id, string key, MValue value)
        {
            lock (Entities)
            {
                var entity = Entities[id];
                entity.Data[key] = value;
                if (EntityDataUpdateHandler == null) return;
                EntityDataUpdateHandler(id, key, value);
            }
        }

        public IEnumerable<Entity.Entity> GetAll()
        {
            lock (Entities)
            {
                return new Dictionary<ulong, Entity.Entity>(Entities).Values;
            }
        }
    }
}