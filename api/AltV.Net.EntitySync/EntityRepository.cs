using System;
using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    public class EntityRepository : IEntityRepository
    {
        private readonly EntityThreadRepository[] entityThreadRepositories;

        private readonly ulong threadCount;

        private readonly Func<IEntity, ulong, ulong> entityThreadId;
        
        private readonly Func<ulong, ulong, ulong, ulong> entityIdAndTypeThreadId;

        public EntityRepository(EntityThreadRepository[] entityThreadRepositories, Func<IEntity, ulong, ulong> entityThreadId, Func<ulong, ulong, ulong, ulong> entityIdAndTypeThreadId)
        {
            this.entityThreadRepositories = entityThreadRepositories;
            threadCount = (ulong) entityThreadRepositories.Length;
            this.entityThreadId = entityThreadId;
            this.entityIdAndTypeThreadId = entityIdAndTypeThreadId;
        }

        // Entity id needs to start at 0 to work for this

        public void Add(IEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity must not be null.");
            }
            entityThreadRepositories[entityThreadId(entity, threadCount)].Add(entity);
        }

        public void Remove(IEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity must not be null.");
            }
            entityThreadRepositories[entityThreadId(entity, threadCount)].Remove(entity);
        }

        public void Update(IEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity must not be null.");
            }
            entityThreadRepositories[entityThreadId(entity, threadCount)].Update(entity);
        }

        public bool TryGet(ulong id, ulong type, out IEntity entity)
        {
            return entityThreadRepositories[entityIdAndTypeThreadId(id, type, threadCount)].TryGet(id, type, out entity);
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