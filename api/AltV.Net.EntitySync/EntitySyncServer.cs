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

        private readonly IEntityRepository entityRepository;

        private readonly IClientRepository clientRepository;

        private readonly NetworkLayer networkLayer;

        private readonly IIdProvider<ulong> idProvider;
        
        internal readonly HashSet<EntityCreateDelegate> EntityCreateCallbacks = new HashSet<EntityCreateDelegate>();
        
        internal readonly HashSet<EntityRemoveDelegate> EntityRemoveCallbacks = new HashSet<EntityRemoveDelegate>();

        public EntitySyncServer(long threadCount, int syncRate,
            Func<IClientRepository, NetworkLayer> createNetworkLayer,
            Func<SpatialPartition> createSpatialPartition, IIdProvider<ulong> idProvider)
        {
            if (threadCount < 1)
            {
                throw new ArgumentException("threadCount must be >= 1");
            }

            clientRepository = new ClientRepository();
            networkLayer = createNetworkLayer(clientRepository);
            networkLayer.OnConnectionConnect += OnConnectionConnect;
            networkLayer.OnConnectionDisconnect += OnConnectionDisconnect;

            entityThreads = new EntityThread[threadCount];
            entityThreadRepositories = new EntityThreadRepository[threadCount];

            for (var i = 0; i < threadCount; i++)
            {
                var entityThreadRepository = new EntityThreadRepository();
                entityThreadRepositories[i] = entityThreadRepository;
                entityThreads[i] = new EntityThread(entityThreadRepository, clientRepository, createSpatialPartition(),syncRate,
                    OnEntityCreate,
                    OnEntityRemove, OnEntityDataChange, OnEntityPositionChange);
            }

            entityRepository = new EntityRepository(entityThreadRepositories);
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

        private void OnEntityCreate(IClient client, IEntity entity, IEnumerable<string> changedKeys)
        {
            networkLayer.SendEvent(client, new EntityCreateEvent(entity, changedKeys));
            foreach (var entityCreateCallback in EntityCreateCallbacks)
            {
                entityCreateCallback(client, entity);
            }
        }

        private void OnEntityRemove(IClient client, IEntity entity)
        {
            networkLayer.SendEvent(client, new EntityRemoveEvent(entity));
            foreach (var entityRemoveCallback in EntityRemoveCallbacks)
            {
                entityRemoveCallback(client, entity);
            }
        }

        private void OnEntityDataChange(IClient client, IEntity entity, IEnumerable<string> changedKeys)
        {
            networkLayer.SendEvent(client,
                new EntityDataChangeEvent(entity, GetChangedEntityData(entity, changedKeys)));
        }

        private void OnEntityPositionChange(IClient client, IEntity entity, Vector3 newPosition)
        {
            networkLayer.SendEvent(client, new EntityPositionUpdateEvent(entity, newPosition));
        }

        private IEnumerable<object> GetChangedEntityData(IEntity entity, IEnumerable<string> changedKeys)
        {
            if (changedKeys == null) yield break;
            foreach (var key in changedKeys)
            {
                if (!entity.TryGetData(key, out var value)) continue;
                yield return key;
                yield return value;
            }
        }

        public IEntity CreateEntity(ulong type, Vector3 position, int dimension, uint range, IDictionary<string, object> data)
        {
            var entity = new Entity(idProvider.GetNext(), type, position, dimension, range, data);
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
            idProvider.Free(entity.Id);
        }

        public bool TryGetEntity(ulong id, out IEntity entity)
        {
            return entityRepository.TryGet(id, out entity);
        }

        public IEnumerable<IEntity> GetAllEntities()
        {
            return entityRepository.GetAll();
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