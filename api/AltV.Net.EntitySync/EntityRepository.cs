using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    public class EntityRepository : IEntityRepository
    {
        private readonly EntityThreadRepository[] entityThreadRepositories;

        private readonly ulong threadCount;

        public EntityRepository(EntityThreadRepository[] entityThreadRepositories)
        {
            this.entityThreadRepositories = entityThreadRepositories;
            threadCount = (ulong) entityThreadRepositories.Length;
        }

        // Entity id needs to start at 0 to work for this

        public void Add(IEntity entity)
        {
            var threadIndex = (int) (entity.Id % threadCount);
            entityThreadRepositories[threadIndex].Add(entity);
        }

        public void Remove(IEntity entity)
        {
            var threadIndex = (int) (entity.Id % threadCount);
            entityThreadRepositories[threadIndex].Remove(entity);
        }

        public bool TryGet(ulong id, out IEntity entity)
        {
            var threadIndex = (int) (id % threadCount);
            return entityThreadRepositories[threadIndex].TryGet(id, out entity);
        }

        public IEnumerable<IEntity> GetAll()
        {
            foreach (var entityThreadRepository in entityThreadRepositories)
            {
                foreach (var entity in entityThreadRepository.GetAll())
                {
                    yield return entity;
                }
            }
        }
    }
}