using System;
using System.Collections.Generic;
using System.Linq;

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

        public ValueTuple<IEntity[], IEntity[], IEntity[]> GetAll()
        {
            lock (entities)
            {
                var currEntities = entities.Values.ToArray();
                IEntity[] currEntitiesToRemove;
                if (entitiesToRemove.Count == 0)
                {
                    currEntitiesToRemove = null;
                }
                else
                {
                    currEntitiesToRemove = entitiesToRemove.ToArray();
                    entitiesToRemove.Clear();
                }
                
                IEntity[] currEntitiesToAdd;
                if (entitiesToAdd.Count == 0)
                {
                    currEntitiesToAdd = null;
                }
                else
                {
                    currEntitiesToAdd = entitiesToAdd.ToArray();
                    entitiesToAdd.Clear();
                }

                return ValueTuple.Create(currEntities, currEntitiesToRemove, currEntitiesToAdd);
            }
        }
    }
}