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

        private readonly IEntityThreadRepository entityThreadRepository;

        private readonly IClientRepository clientRepository;

        private readonly SpatialPartition spatialPartition;

        private readonly int syncRate;

        private readonly HashSet<IClient> clientsToRemoveFromEntity = new HashSet<IClient>();
        private readonly HashSet<IClient> clientsToResetFromEntity = new HashSet<IClient>();

        private readonly Action<IClient, IEntity, IEnumerable<string>> onEntityCreate;

        private readonly Action<IClient, IEntity> onEntityRemove;

        private readonly Action<IClient, IEntity, IEnumerable<string>> onEntityDataChange;

        private readonly Action<IClient, IEntity, Vector3> onEntityPositionChange;

        public EntityThread(IEntityThreadRepository entityThreadRepository, IClientRepository clientRepository,
            SpatialPartition spatialPartition, int syncRate,
            Action<IClient, IEntity, IEnumerable<string>> onEntityCreate, Action<IClient, IEntity> onEntityRemove,
            Action<IClient, IEntity, IEnumerable<string>> onEntityDataChange,
            Action<IClient, IEntity, Vector3> onEntityPositionChange)
        {
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

            thread = new Thread(OnLoop);
            thread.Start();
            this.entityThreadRepository = entityThreadRepository;
            this.clientRepository = clientRepository;
            this.spatialPartition = spatialPartition;
            this.syncRate = syncRate;
            this.onEntityCreate = onEntityCreate;
            this.onEntityRemove = onEntityRemove;
            this.onEntityDataChange = onEntityDataChange;
            this.onEntityPositionChange = onEntityPositionChange;
        }

        public void OnLoop()
        {
            while (running)
            {
                var (entities, removedEntities, addedEntities) = entityThreadRepository.GetAll();

                if (removedEntities != null)
                {
                    foreach (var removedEntity in removedEntities)
                    {
                        spatialPartition.Remove(removedEntity);
                        foreach (var client in removedEntity.GetClients())
                        {
                            onEntityRemove(client, removedEntity);
                        }
                    }
                }

                if (addedEntities != null)
                {
                    foreach (var addedEntity in addedEntities)
                    {
                        spatialPartition.Add(addedEntity);
                    }
                }

                var clients = clientRepository.GetAll();

                foreach (var client in clients)
                {
                    if (!client.TryGetPosition(out var position))
                    {
                        continue;
                    }

                    foreach (var foundEntity in spatialPartition.Find(position, client.Dimension))
                    {
                        foundEntity.AddCheck(client);
                        var changedKeys = foundEntity.CompareSnapshotWithClient(client);
                        if (foundEntity.TryAddClient(client))
                        {
                            onEntityCreate(client, foundEntity, changedKeys);
                        }
                        else if (changedKeys != null)
                        {
                            onEntityDataChange(client, foundEntity, changedKeys);
                        }
                    }
                }

                foreach (var entity in entities)
                {
                    var lastCheckedClients = entity.GetLastCheckedClients();
                    if (lastCheckedClients.Count != 0)
                    {
                        if (clientsToRemoveFromEntity.Count != 0)
                        {
                            clientsToRemoveFromEntity.Clear();
                        }

                        if (clientsToResetFromEntity.Count != 0)
                        {
                            clientsToResetFromEntity.Clear();
                        }

                        foreach (var (client, lastChecked) in lastCheckedClients)
                        {
                            if (lastChecked)
                            {
                                clientsToResetFromEntity.Add(client);
                            }
                            else
                            {
                                clientsToRemoveFromEntity.Add(client);
                                onEntityRemove(client, entity);
                            }
                        }

                        foreach (var client in clientsToResetFromEntity)
                        {
                            entity.RemoveCheck(client);
                        }

                        foreach (var client in clientsToRemoveFromEntity)
                        {
                            entity.RemoveClient(client);
                        }
                    }

                    // Check if position state is new position so we can set the new position to the entity internal position

                    if (entity.TrySetPositionComputing(out var newPosition))
                    {
                        spatialPartition.UpdateEntityPosition(entity, newPosition);
                        foreach (var entityClient in entity.GetClients())
                        {
                            onEntityPositionChange(entityClient, entity, newPosition);
                        }

                        entity.SetPositionComputed(in newPosition);
                    }

                    if (entity.TrySetDimensionComputing(out var newDimension))
                    {
                        spatialPartition.UpdateEntityDimension(entity, newDimension);
                        entity.SetDimensionComputed(newDimension);
                    }

                    if (entity.TrySetRangeComputing(out var newRange))
                    {
                        spatialPartition.UpdateEntityRange(entity, newRange);
                        entity.SetRangeComputed(newRange);
                    }
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