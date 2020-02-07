using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AltV.Net.EntitySync.SpatialPartitions;

namespace AltV.Net.EntitySync
{
    public class EntityThreadRepository : IEntityThreadRepository
    {
        private readonly IDictionary<ulong, IEntity> entities = new Dictionary<ulong, IEntity>();

        private readonly LinkedList<IEntity> entitiesToRemove = new LinkedList<IEntity>();

        private readonly SpatialPartition spatialPartition;

        public EntityThreadRepository(SpatialPartition spatialPartition)
        {
            this.spatialPartition = spatialPartition;
        }

        public void Add(IEntity entity)
        {
            lock (entities)
            {
                entities[entity.Id] = entity;
            }

            spatialPartition.Add(entity);
        }

        public void Remove(IEntity entity)
        {
            lock (entities)
            {
                entities.Remove(entity.Id);
                entitiesToRemove.AddLast(entity);
            }

            spatialPartition.Remove(entity);
        }

        public void UpdatePosition(IEntity entity, Vector3 newPosition)
        {
            spatialPartition.UpdateEntityPosition(entity, newPosition);
            entity.SetPositionInternal(newPosition);
        }

        public KeyValuePair<IEntity[], IEntity[]> GetAll()
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

                return KeyValuePair.Create(currEntities, currEntitiesToRemove);
            }
        }

        public IEnumerable<IEntity> Find(in Vector3 position)
        {
            return spatialPartition.Find(position);
        }
    }
}