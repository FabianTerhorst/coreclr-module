using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    public class EntityThreadRepository : IEntityThreadRepository
    {
        public readonly object Mutex = new object();
        
        internal readonly IDictionary<(ulong, ulong), IEntity> Entities = new Dictionary<(ulong, ulong), IEntity>();

        internal readonly Queue<(IEntity, byte)> EntitiesQueue = new Queue<(IEntity, byte)>();
        
        internal readonly Queue<(IEntity, string, object, bool)> EntitiesDataQueue = new Queue<(IEntity, string, object, bool)>();

        public void Add(IEntity entity)
        {
            lock (Mutex)
            {
                if (!Entities.TryAdd(entity.HashKey, entity)) return;
                EntitiesQueue.Enqueue((entity, 0));
            }
        }

        public void Remove(IEntity entity)
        {
            lock (Mutex)
            {
                if (!Entities.Remove(entity.HashKey, out _)) return;
                EntitiesQueue.Enqueue((entity, 1));
            }
        }

        public void Remove(IList<IEntity> entities)
        {
            lock (Mutex)
            {
                for (int i = 0, length = entities.Count; i < length; i++)
                {
                    var entity = entities[i];
                    if (!Entities.Remove(entity.HashKey, out _)) return;
                    EntitiesQueue.Enqueue((entity, 1));
                }
            }
        }

        public void Update(IEntity entity)
        {
            lock (Mutex)
            {
                EntitiesQueue.Enqueue((entity, 2));
            }
        }

        public void UpdateData(IEntity entity, string key, object value)
        {
            lock (Mutex)
            {
                EntitiesDataQueue.Enqueue((entity, key, value, true));
            }
        }

        public void ResetData(IEntity entity, string key)
        {
            lock (Mutex)
            {
                EntitiesDataQueue.Enqueue((entity, key, null, false));
            }
        }

        public bool TryGet(ulong id, ulong type, out IEntity entity)
        {
            lock (Mutex)
            {
                return Entities.TryGetValue((id, type), out entity);
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