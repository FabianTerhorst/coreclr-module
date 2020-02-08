using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net.EntitySync.Events;
using AltV.Net.EntitySync.SpatialPartitions;

namespace AltV.Net.EntitySync
{
    //TODO: find out where to implement position update
    public class EntitySyncServer
    {
        private readonly EntityThread[] entityThreads;

        private readonly EntityThreadRepository[] entityThreadRepositories;

        private readonly IEntityRepository entityRepository;

        private readonly IClientRepository clientRepository;

        private readonly NetworkLayer networkLayer;

        private readonly IIdProvider<ulong> idProvider;

        public EntitySyncServer(long threadCount,
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
                entityThreads[i] = new EntityThread(entityThreadRepository, clientRepository, createSpatialPartition(), OnEntityCreate,
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
        }

        private void OnEntityRemove(IClient client, IEntity entity)
        {
            networkLayer.SendEvent(client, new EntityRemoveEvent(entity));
        }
        
        private void OnEntityDataChange(IClient client, IEntity entity, IEnumerable<string> changedKeys)
        {
            networkLayer.SendEvent(client, new EntityDataChangeEvent(entity, GetChangedEntityData(entity, changedKeys)));
        }
        
        private void OnEntityPositionChange(IClient client, IEntity entity, Vector3 newPosition)
        {
            networkLayer.SendEvent(client, new EntityPositionUpdateEvent(entity, newPosition));
        }

        private IEnumerable<object> GetChangedEntityData(IEntity entity, IEnumerable<string> changedKeys)
        {
            foreach (var key in changedKeys)
            {
                if (!entity.TryGetData(key, out var value)) continue;
                yield return key;
                yield return value;
            }
        }

        public IEntity CreateEntity(ulong type, Vector3 position, uint range)
        {
            var entity = new Entity(idProvider.GetNext(), type, position, range);
            AddEntity(entity);
            return entity;
        }

        // set position update flag to true in entity when updating position
        // thread will normally check if client is near entity
        // 1.) when client was near entity and is not anymore stream not, ( no change)
        // 2.) when client was not near entity and is now near entity stream in, (no change)
        // 3.) when client was not near entity and is still not near entity do nothing, (no change)
        // 4.) when client was near entity and is still near entity send client position change, client knows old position, don't send it
        public void UpdateEntityPosition(IEntity entity, Vector3 newPosition)
        {
            entityRepository.UpdatePosition(entity, newPosition);
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
    }
}