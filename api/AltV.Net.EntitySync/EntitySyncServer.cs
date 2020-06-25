using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net.EntitySync.Events;
using AltV.Net.EntitySync.SpatialPartitions;

namespace AltV.Net.EntitySync
{
    /// <summary>
    /// The sync server creates the threads, the client repository and entity repositories.
    /// It transmits the streamer callbacks to the network layer.
    /// It will also transfer callbacks from network layer to streamer, for e.g. updating entity position when net owner is implemented.
    /// </summary>
    public class EntitySyncServer
    {
        private readonly EntityThread[] entityThreads;

        private readonly EntityThreadRepository[] entityThreadRepositories;
        
        private readonly ClientThreadRepository[] clientThreadRepositories;

        private readonly SpatialPartition[] spatialPartitions;

        private readonly IEntityRepository entityRepository;

        private readonly IClientRepository clientRepository;

        private readonly NetworkLayer networkLayer;

        private readonly IIdProvider<ulong> idProvider;
        
        internal readonly LinkedList<EntityCreateDelegate> EntityCreateCallbacks = new LinkedList<EntityCreateDelegate>();
        
        internal readonly LinkedList<EntityRemoveDelegate> EntityRemoveCallbacks = new LinkedList<EntityRemoveDelegate>();

        public EntitySyncServer(ulong threadCount, int syncRate, bool netOwnerEvents,
            Func<ulong, IClientRepository, NetworkLayer> createNetworkLayer,
            Func<IEntity, ulong, ulong> entityThreadId,
            Func<ulong, ulong, ulong, ulong> entityIdAndTypeThreadId,
            Func<ulong, SpatialPartition> createSpatialPartition, IIdProvider<ulong> idProvider)
        {
            if (threadCount < 1)
            {
                throw new ArgumentException("threadCount must be >= 1");
            }
            
            if (syncRate < 0)
            {
                throw new ArgumentException("syncRate must be >= 0");
            }

            entityThreads = new EntityThread[threadCount];
            entityThreadRepositories = new EntityThreadRepository[threadCount];
            clientThreadRepositories = new ClientThreadRepository[threadCount];
            spatialPartitions = new SpatialPartition[threadCount];

            for (ulong i = 0; i < threadCount; i++)
            {
                var clientThreadRepository = new ClientThreadRepository();
                var entityThreadRepository = new EntityThreadRepository();
                var spatialPartition = createSpatialPartition(i);
                entityThreadRepositories[i] = entityThreadRepository;
                clientThreadRepositories[i] = clientThreadRepository;
                spatialPartitions[i] = spatialPartition;
                entityThreads[i] = new EntityThread(i, entityThreadRepository, clientThreadRepository, spatialPartition, syncRate, netOwnerEvents,
                    OnEntityCreate,
                    OnEntityRemove, OnEntityDataChange, OnEntityPositionChange, OnEntityClearCache, OnEntityNetOwnerChange);
            }

            entityRepository = new EntityRepository(entityThreadRepositories, entityThreadId, entityIdAndTypeThreadId);
            clientRepository = new ClientRepository(clientThreadRepositories);
            networkLayer = createNetworkLayer(threadCount, clientRepository);
            networkLayer.OnConnectionConnect += OnConnectionConnect;
            networkLayer.OnConnectionDisconnect += OnConnectionDisconnect;
            this.idProvider = idProvider;
        }

        private void OnConnectionConnect(IClient client)
        {
            //clientRepository.Add(client);
        }

        private void OnConnectionDisconnect(IClient client)
        {
            //clientRepository.Remove(client);
        }

        private void OnEntityCreate(IClient client, IEntity entity, LinkedList<string> changedKeys)
        {
            Dictionary<string, object> data;
            if (changedKeys != null) {
                data = new Dictionary<string, object>();
                var changedKey = changedKeys.First;
                while (changedKey != null)
                {
                    var key = changedKey.Value;
                    if (entity.TryGetThreadLocalData(key, out var value))
                    {
                        data[key] = value;
                    }
                    else
                    {
                        data[key] = null;
                    }
                    changedKey = changedKey.Next;
                }
            }
            else
            {
                data = null;
            }
            networkLayer.SendEvent(client, new EntityCreateEvent(entity, data));

            var callback = EntityCreateCallbacks.First;
            while (callback != null)
            {
                callback.Value(client, entity);
                callback = callback.Next;
            }
        }

        private void OnEntityRemove(IClient client, IEntity entity)
        {
            networkLayer.SendEvent(client, new EntityRemoveEvent(entity));
            var callback = EntityRemoveCallbacks.First;
            while (callback != null)
            {
                callback.Value(client, entity);
                callback = callback.Next;
            }
        }

        private void OnEntityDataChange(IClient client, IEntity entity, LinkedList<string> changedKeys)
        {
            Dictionary<string, object> data;
            if (changedKeys != null) {
                data = new Dictionary<string, object>();
                var changedKey = changedKeys.First;
                while (changedKey != null)
                {
                    var key = changedKey.Value;
                    if (entity.TryGetThreadLocalData(key, out var value))
                    {
                        data[key] = value;
                    }
                    else
                    {
                        data[key] = null;
                    }
                    changedKey = changedKey.Next;
                }
            }
            else
            {
                data = null;
            }
            networkLayer.SendEvent(client, new EntityDataChangeEvent(entity, data));
        }

        private void OnEntityPositionChange(IClient client, IEntity entity, Vector3 newPosition)
        {
            networkLayer.SendEvent(client, new EntityPositionUpdateEvent(entity, newPosition));
        }

        private void OnEntityClearCache(IClient client, IEntity entity)
        {
            networkLayer.SendEvent(client, new EntityClearCacheEvent(entity));
        }
        
        private void OnEntityNetOwnerChange(IClient client, IEntity entity, bool netOwner)
        {
            networkLayer.SendEvent(client, new EntityNetOwnerChangeEvent(entity, netOwner));
        }

        public IEntity CreateEntity(ulong type, Vector3 position, int dimension, uint range, IDictionary<string, object> data)
        {
            var entity = new Entity(idProvider.GetNext(), type, position, dimension, range, data);
            AddEntity(entity);
            return entity;
        }
        
        public IEntity CreateEntity(ulong id, ulong type, Vector3 position, int dimension, uint range, IDictionary<string, object> data)
        {
            if (idProvider != null)
            {
                throw new InvalidOperationException("IdProvider needs to be null to use own id management.");
            }
            var entity = new Entity(id, type, position, dimension, range, data);
            AddEntity(entity);
            return entity;
        }

        public void AddEntity(IEntity entity)
        {
            entityRepository.Add(entity);
        }

        public void RemoveEntity(IEntity entity)
        {
            entityRepository.Remove(entity);
            idProvider?.Free(entity.Id);
        }
        
        public void UpdateEntity(IEntity entity)
        {
            entityRepository.Update(entity);
        }
        
        public void UpdateEntityData(IEntity entity, string key, object value)
        {
            entityRepository.UpdateData(entity, key, value);
        }
        
        public void ResetEntityData(IEntity entity, string key)
        {
            entityRepository.ResetData(entity, key);
        }

        public bool TryGetEntity(ulong id, ulong type, out IEntity entity)
        {
            return entityRepository.TryGet(id, type, out entity);
        }

        public IEnumerable<IEntity> GetAllEntities()
        {
            return entityRepository.GetAll();
        }

        public List<IEntity> FindEntities(Vector3 position, int dimension)
        {
            var foundEntities = new List<IEntity>();
            for (int i = 0, length = entityThreads.Length; i < length; i++)
            {
                lock (clientThreadRepositories[i].Mutex)
                {
                    foundEntities.AddRange(spatialPartitions[i].Find(position, dimension));
                }
            }

            return foundEntities;
        }

        public void Stop()
        {
            foreach (var entityThread in entityThreads)
            {
                entityThread.Stop();
            }
        }
    }
}