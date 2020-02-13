using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    public class EntityThreadRepository : IEntityThreadRepository
    {
        public readonly object Mutex = new object();
        
        internal readonly IDictionary<ulong, IEntity> Entities = new Dictionary<ulong, IEntity>();

        internal readonly LinkedList<IEntity> EntitiesToRemove = new LinkedList<IEntity>();

        internal readonly LinkedList<IEntity> EntitiesToAdd = new LinkedList<IEntity>();
        
        internal readonly LinkedList<IEntity> EntitiesToUpdate = new LinkedList<IEntity>();

        public void Add(IEntity entity)
        {
            lock (Mutex)
            {
                if (!Entities.TryAdd(entity.Id, entity)) return;
                EntitiesToAdd.AddLast(entity);
                EntitiesToRemove.Remove(entity);
                EntitiesToUpdate.Remove(entity);
            }
        }

        public void Remove(IEntity entity)
        {
            lock (Mutex)
            {
                if (!Entities.Remove(entity.Id, out _)) return;
                EntitiesToRemove.AddLast(entity);
                EntitiesToAdd.Remove(entity);
                EntitiesToUpdate.Remove(entity);
            }
        }

        public void Update(IEntity entity)
        {
            lock (Mutex)
            {
                EntitiesToUpdate.AddLast(entity);
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
        
        public IEnumerable<IEntity> GetAllAdded()
        {
            lock (Mutex)
            {
                if (EntitiesToAdd.Count == 0) yield break;
                var entityToAdd = EntitiesToAdd.First;
                while (entityToAdd != null)
                {
                    yield return entityToAdd.Value;
                    entityToAdd = entityToAdd.Next;
                }
                EntitiesToAdd.Clear();
            }
        }
        
        public IEnumerable<IEntity> GetAllDeleted()
        {
            lock (Mutex)
            {
                if (EntitiesToRemove.Count == 0) yield break;
                var entityToRemove = EntitiesToRemove.First;
                while (entityToRemove != null)
                {
                    yield return entityToRemove.Value;
                    entityToRemove = entityToRemove.Next;
                }
                EntitiesToRemove.Clear();
            }
        }
        
        public IEnumerable<IEntity> GetAllUpdated()
        {
            lock (Mutex)
            {
                if (EntitiesToUpdate.Count == 0) yield break;
                var entityToUpdate = EntitiesToUpdate.First;
                while (entityToUpdate != null)
                {
                    yield return entityToUpdate.Value;
                    entityToUpdate = entityToUpdate.Next;
                }
                EntitiesToUpdate.Clear();
            }
        }
    }
}