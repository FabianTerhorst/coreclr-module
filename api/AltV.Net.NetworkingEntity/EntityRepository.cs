using System.Collections.Generic;

namespace AltV.Net.NetworkingEntity
{
    public class EntityRepository
    {
        private readonly Dictionary<ulong, Entity.Entity> entities = new Dictionary<ulong, Entity.Entity>();

        public void Add(Entity.Entity entity)
        {
            lock (entities)
            {
                entities[entity.Id] = entity;
            }
        }

        public void Delete(ulong id)
        {
            lock (entities)
            {
                entities.Remove(id);
            }
        }

        public IEnumerable<Entity.Entity> GetAll()
        {
            lock (entities)
            {
                return new Dictionary<ulong, Entity.Entity>(entities).Values;
            }
        }
    }
}