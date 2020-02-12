using System;
using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    public class EntityThreadRepository : IEntityThreadRepository
    {
        private readonly IDictionary<ulong, IEntity> entities = new Dictionary<ulong, IEntity>();

        private readonly HashSet<IEntity> entitiesToRemove = new HashSet<IEntity>();

        private readonly HashSet<IEntity> entitiesToAdd = new HashSet<IEntity>();

        public void Add(IEntity entity)
        {
            lock (entities)
            {
                entitiesToRemove.Remove(entity);
                if (!entitiesToAdd.Add(entity)) return;
                if (!entities.TryAdd(entity.Id, entity)) return;
            }
        }

        public void Remove(IEntity entity)
        {
            lock (entities)
            {
                entitiesToAdd.Remove(entity);
                if (!entitiesToRemove.Add(entity)) return;
                if (!entities.Remove(entity.Id, out _)) return;
            }
        }

        public bool TryGet(ulong id, out IEntity entity)
        {
            lock (entities)
            {
                return entities.TryGetValue(id, out entity);
            }
        }

        public IEnumerable<IEntity> GetAll()
        {
            lock (entities)
            {
                foreach (var (_, entity) in entities)
                {
                    yield return entity;
                }
            }
        }
        
        public IEnumerable<IEntity> GetAllAdded()
        {
            lock (entities)
            {
                if (entitiesToAdd.Count == 0) yield break;
                foreach (var entity in entitiesToAdd)
                {
                    yield return entity;
                }
                entitiesToAdd.Clear();
            }
        }
        
        public IEnumerable<IEntity> GetAllDeleted()
        {
            lock (entities)
            {
                if (entitiesToRemove.Count == 0) yield break;
                foreach (var entity in entitiesToRemove)
                {
                    yield return entity;
                }
                entitiesToRemove.Clear();
            }
        }
    }
}