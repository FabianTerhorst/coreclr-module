using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using AltV.Net.EntitySync.SpatialPartitions;

namespace AltV.Net.EntitySync
{
    /// <summary>
    /// The entity thread checks in a endless loop if entities should be created or removed for all clients.
    /// And it delivers the results via the provided action callbacks.
    /// </summary>
    public class EntityThread
    {
        private bool running = true;

        private readonly Thread thread;

        private readonly EntityThreadRepository entityThreadRepository;

        private readonly ClientThreadRepository clientThreadRepository;

        private readonly SpatialPartition spatialPartition;

        private readonly int syncRate;

        private readonly LinkedList<IClient> clientsToRemoveFromEntity = new LinkedList<IClient>();
        private readonly LinkedList<IClient> clientsToResetFromEntity = new LinkedList<IClient>();

        private readonly LinkedList<string> changedEntityDataKeys = new LinkedList<string>();

        private readonly Action<IClient, IEntity, LinkedList<string>> onEntityCreate;

        private readonly Action<IClient, IEntity> onEntityRemove;

        private readonly Action<IClient, IEntity, LinkedList<string>> onEntityDataChange;

        private readonly Action<IClient, IEntity, Vector3> onEntityPositionChange;

        private readonly Action<IClient, IEntity> onEntityClearCache;
        
        private Vector3 clientPosition = Vector3.Zero;

        public EntityThread(EntityThreadRepository entityThreadRepository,
            ClientThreadRepository clientThreadRepository,
            SpatialPartition spatialPartition, int syncRate,
            Action<IClient, IEntity, LinkedList<string>> onEntityCreate, Action<IClient, IEntity> onEntityRemove,
            Action<IClient, IEntity, LinkedList<string>> onEntityDataChange,
            Action<IClient, IEntity, Vector3> onEntityPositionChange, Action<IClient, IEntity> onEntityClearCache)
        {
            if (spatialPartition == null)
            {
                throw new ArgumentException("spatialPartition should not be null.");
            }

            if (entityThreadRepository == null)
            {
                throw new ArgumentException("entityThreadRepository should not be null.");
            }

            if (onEntityCreate == null)
            {
                throw new ArgumentException("onEntityCreate should not be null.");
            }

            if (onEntityRemove == null)
            {
                throw new ArgumentException("onEntityRemove should not be null.");
            }

            if (onEntityDataChange == null)
            {
                throw new ArgumentException("onEntityDataChange should not be null.");
            }

            if (onEntityPositionChange == null)
            {
                throw new ArgumentException("onEntityPositionChange should not be null.");
            }

            if (onEntityClearCache == null)
            {
                throw new ArgumentException("onEntityPositionChange should not be null.");
            }

            thread = new Thread(OnLoop) {IsBackground = true};
            thread.Start();
            this.entityThreadRepository = entityThreadRepository;
            this.clientThreadRepository = clientThreadRepository;
            this.spatialPartition = spatialPartition;
            this.syncRate = syncRate;
            this.onEntityCreate = onEntityCreate;
            this.onEntityRemove = onEntityRemove;
            this.onEntityDataChange = onEntityDataChange;
            this.onEntityPositionChange = onEntityPositionChange;
            this.onEntityClearCache = onEntityClearCache;
        }

        public void OnLoop()
        {
            while (running)
            {
                try
                {
                    lock (entityThreadRepository.Mutex)
                    {
                        foreach (var (_, entity) in entityThreadRepository.Entities)
                        {
                            var lastCheckedClients = entity.GetLastCheckedClients();
                            if (lastCheckedClients.Count == 0) continue;

                            foreach (var (client, lastChecked) in lastCheckedClients)
                            {
                                if (lastChecked)
                                {
                                    clientsToResetFromEntity.AddLast(client);
                                }
                                else
                                {
                                    clientsToRemoveFromEntity.AddLast(client);
                                    onEntityRemove(client, entity);
                                }
                            }

                            if (clientsToResetFromEntity.Count != 0)
                            {
                                var currClient = clientsToResetFromEntity.First;

                                while (currClient != null)
                                {
                                    entity.RemoveCheck(currClient.Value);
                                    currClient = currClient.Next;
                                }
                                clientsToResetFromEntity.Clear();
                            }

                            if (clientsToRemoveFromEntity.Count != 0)
                            {
                                var currClient = clientsToRemoveFromEntity.First;

                                while (currClient != null)
                                {
                                    entity.RemoveClient(currClient.Value);
                                    currClient = currClient.Next;
                                }
                                clientsToRemoveFromEntity.Clear();
                            }
                        }
                        
                        if (entityThreadRepository.EntitiesQueue.Count != 0)
                        {
                            while (entityThreadRepository.EntitiesQueue.TryDequeue(out var entityQueueResult))
                            {
                                var (entityToChange, state) = entityQueueResult;
                                switch (state)
                                {
                                    case 0:
                                        spatialPartition.Add(entityToChange);
                                        break;
                                    case 1:
                                        spatialPartition.Remove(entityToChange);
                                        foreach (var client in entityToChange.GetClients())
                                        {
                                            onEntityRemove(client, entityToChange);
                                        }

                                        foreach (var client in entityToChange.DataSnapshot.GetLastClients())
                                        {
                                            onEntityClearCache(client, entityToChange);
                                        }
                                        break;
                                    case 2:
                                        // Check if position state is new position so we can set the new position to the entity internal position
                                        var (hasNewPosition, hasNewRange, hasNewDimension) = entityToChange.TrySetPropertiesComputing(
                                            out var newPosition,
                                            out var newRange, out var newDimension);

                                        if (hasNewPosition)
                                        {
                                            spatialPartition.UpdateEntityPosition(entityToChange, newPosition);
                                            foreach (var entityClient in entityToChange.GetClients())
                                            {
                                                onEntityPositionChange(entityClient, entityToChange, newPosition);
                                            }
                                        }

                                        if (hasNewRange)
                                        {
                                            spatialPartition.UpdateEntityRange(entityToChange, newRange);
                                        }

                                        if (hasNewDimension)
                                        {
                                            spatialPartition.UpdateEntityDimension(entityToChange, newDimension);
                                        }
                                        break;
                                }
                            }
                        }
                        //TODO: when the id provider add / remove doesn't work use the idprovider inside this loop only
                    }

                    lock (clientThreadRepository.Mutex)
                    {
                        if (clientThreadRepository.ClientsToRemove.Count != 0)
                        {
                            var clientToRemove = clientThreadRepository.ClientsToRemove.First;
                            while (clientToRemove != null)
                            {
                                clientToRemove.Value.Snapshot.CleanupEntities(clientToRemove.Value);
                                clientToRemove = clientToRemove.Next;
                            }

                            clientThreadRepository.ClientsToRemove.Clear();
                        }

                        foreach (var (_, client) in clientThreadRepository.Clients)
                        {
                            if (!client.TryGetDimensionAndPosition(out var dimension, ref clientPosition))
                            {
                                continue;
                            }

                            //TODO: cache streamed in entities in list, so we don't have to iterate all entities
                            foreach (var foundEntity in spatialPartition.Find(clientPosition, dimension))
                            {
                                foundEntity.AddCheck(client);
                                foundEntity.DataSnapshot.CompareWithClient(changedEntityDataKeys, client);

                                if (foundEntity.TryAddClient(client))
                                {
                                    if (changedEntityDataKeys.Count == 0)
                                    {
                                        onEntityCreate(client, foundEntity, null);
                                    }
                                    else
                                    {
                                        onEntityCreate(client, foundEntity, changedEntityDataKeys);
                                        changedEntityDataKeys.Clear();
                                    }
                                }
                                else if (changedEntityDataKeys.Count != 0)
                                {
                                    onEntityDataChange(client, foundEntity, changedEntityDataKeys);
                                    changedEntityDataKeys.Clear();
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                Thread.Sleep(syncRate);
            }
        }

        public void Stop()
        {
            running = false;
            thread.Join();
        }
    }
}