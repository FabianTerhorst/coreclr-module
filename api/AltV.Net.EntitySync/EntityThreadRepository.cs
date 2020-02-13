using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    public class EntityThreadRepository : IEntityThreadRepository
    {
        public readonly object Mutex = new object();
        
        internal readonly IDictionary<ulong, IEntity> Entities = new Dictionary<ulong, IEntity>();

        internal readonly Queue<(IEntity, byte)> EntitiesQueue = new Queue<(IEntity, byte)>();

        public void Add(IEntity entity)
        {
            lock (Mutex)
            {
                if (!Entities.TryAdd(entity.Id, entity)) return;
                EntitiesQueue.Enqueue((entity, 0));
            }
        }

        public void Remove(IEntity entity)
        {
            lock (Mutex)
            {
                if (!Entities.Remove(entity.Id, out _)) return;
                EntitiesQueue.Enqueue((entity, 1));
            }
        }

        public void Update(IEntity entity)
        {
            lock (Mutex)
            {
                EntitiesQueue.Enqueue((entity, 2));
            }
        }
        
        public bool TryGet(ulong id, out IEntity entity)
        {
            lock (Mutex)
            {
                return Entities.TryGetValue(id, out entity);
            }
        }

        public IEnumerable<IEntity> GetAll()
        {
            lock (Mutex)
            {
                foreach (var (_, entity) in Entities)
                {
                    yield return entity;
                }
            }
        }
    }
}