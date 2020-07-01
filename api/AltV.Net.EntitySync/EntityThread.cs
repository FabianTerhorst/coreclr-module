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

        private readonly ulong threadIndex;

        private readonly Thread thread;

        private readonly EntityThreadRepository entityThreadRepository;

        private readonly ClientThreadRepository clientThreadRepository;

        private readonly SpatialPartition spatialPartition;

        private readonly int syncRate;

        private readonly bool netOwnerEvents;

        private readonly LinkedList<IEntity> entitiesToRemoveFromClient = new LinkedList<IEntity>();
        private readonly LinkedList<IEntity> entitiesToResetFromClient = new LinkedList<IEntity>();

        private readonly LinkedList<string> changedEntityDataKeys = new LinkedList<string>();

        private readonly Action<IClient, IEntity, LinkedList<string>> onEntityCreate;

        private readonly Action<IClient, IEntity> onEntityRemove;

        private readonly Action<IClient, IEntity, LinkedList<string>> onEntityDataChange;

        private readonly Action<IClient, IEntity, Vector3> onEntityPositionChange;

        private readonly Action<IClient, IEntity> onEntityClearCache;

        private readonly Action<IClient, IEntity, bool> onEntityNetOwnerChange;

        private Vector3 clientPosition = Vector3.Zero;

        public EntityThread(ulong threadIndex, EntityThreadRepository entityThreadRepository,
            ClientThreadRepository clientThreadRepository,
            SpatialPartition spatialPartition, int syncRate, bool netOwnerEvents,
            Action<IClient, IEntity, LinkedList<string>> onEntityCreate, Action<IClient, IEntity> onEntityRemove,
            Action<IClient, IEntity, LinkedList<string>> onEntityDataChange,
            Action<IClient, IEntity, Vector3> onEntityPositionChange, Action<IClient, IEntity> onEntityClearCache,
            Action<IClient, IEntity, bool> onEntityNetOwnerChange)
        {
            this.threadIndex = threadIndex;

            this.entityThreadRepository = entityThreadRepository ??
                                          throw new ArgumentException("entityThreadRepository should not be null.");
            this.clientThreadRepository = clientThreadRepository;
            this.spatialPartition =
                spatialPartition ?? throw new ArgumentException("spatialPartition should not be null.");
            this.syncRate = syncRate;
            this.netOwnerEvents = netOwnerEvents;
            this.onEntityCreate = onEntityCreate ?? throw new ArgumentException("onEntityCreate should not be null.");
            this.onEntityRemove = onEntityRemove ?? throw new ArgumentException("onEntityRemove should not be null.");
            this.onEntityDataChange = onEntityDataChange ??
                                      throw new ArgumentException("onEntityDataChange should not be null.");
            this.onEntityPositionChange = onEntityPositionChange ??
                                          throw new ArgumentException("onEntityPositionChange should not be null.");
            this.onEntityClearCache = onEntityClearCache ??
                                      throw new ArgumentException("onEntityPositionChange should not be null.");
            this.onEntityNetOwnerChange = onEntityNetOwnerChange ??
                                          throw new ArgumentException("onEntityNetOwnerChange should not be null.");

            thread = new Thread(OnLoop) {IsBackground = true};
            thread.Start();
        }

        private void OnLoop()
        {
            while (running)
            {
                try
                {
                    while (entityThreadRepository.EntitiesChannelReader.TryRead(out var entityQueueResult))
                    {
                        var (entityToChange, state) = entityQueueResult;
                        switch (state)
                        {
                            case 0:
                                spatialPartition.Add(entityToChange);
                                foreach (var (key, _) in entityToChange.ThreadLocalData)
                                {
                                    entityToChange.DataSnapshot.Update(key);
                                }

                                break;
                            case 1:
                                spatialPartition.Remove(entityToChange);
                                foreach (var client in entityToChange.GetClients())
                                {
                                    client.RemoveEntity(threadIndex, entityToChange);
                                    onEntityRemove(client, entityToChange);
                                }

                                // We don't have to do this, but we do for for consistency because entity gets garbage collected anyway
                                //entityToChange.GetClients().Clear();

                                foreach (var client in entityToChange.DataSnapshot.GetLastClients())
                                {
                                    onEntityClearCache(client, entityToChange);
                                }

                                break;
                            case 2:
                                // Check if position state is new position so we can set the new position to the entity internal position
                                var (hasNewPosition, hasNewRange, hasNewDimension) =
                                    entityToChange.TrySetPropertiesComputing(
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

                    while (entityThreadRepository.EntitiesDataChannelReader.TryRead(out var entityDataQueueResult))
                    {
                        var (entityWithChangedData, changedDataKey, changedDataValue, notDeleted) =
                            entityDataQueueResult;
                        entityWithChangedData.DataSnapshot.Update(changedDataKey);
                        if (notDeleted)
                        {
                            entityWithChangedData.SetThreadLocalData(changedDataKey, changedDataValue);
                        }
                        else
                        {
                            entityWithChangedData.ResetThreadLocalData(changedDataKey);
                        }
                    }

                    //TODO: when the id provider add / remove doesn't work use the idprovider inside this loop only

                    lock (clientThreadRepository.Mutex)
                    {
                        if (clientThreadRepository.ClientsToRemove.Count != 0)
                        {
                            while (clientThreadRepository.ClientsToRemove.TryDequeue(out var clientToRemove))
                            {
                                clientToRemove.Snapshot.CleanupEntities(threadIndex, clientToRemove);
                                foreach (var entityFromRemovedClient in clientToRemove.GetEntities(threadIndex))
                                {
                                    entityFromRemovedClient.RemoveClient(clientToRemove);
                                    if (!netOwnerEvents) continue;
                                    if (entityFromRemovedClient.NetOwner == clientToRemove)
                                    {
                                        entityFromRemovedClient.NetOwner = null;
                                        entityFromRemovedClient.NetOwnerRange = float.MaxValue;
                                    }

                                    if (entityFromRemovedClient.TempNetOwner == clientToRemove)
                                    {
                                        entityFromRemovedClient.TempNetOwner = null;
                                        entityFromRemovedClient.TempNetOwnerRange = float.MaxValue;
                                    }
                                }
                            }
                        }

                        foreach (var (_, client) in clientThreadRepository.Clients)
                        {
                            if (!client.TryGetDimensionAndPosition(out var dimension, ref clientPosition))
                            {
                                continue;
                            }

                            var foundEntities = spatialPartition.Find(clientPosition, dimension);

                            var lastCheckedEntities = client.GetLastCheckedEntities(threadIndex);
                            if (lastCheckedEntities.Count != 0)
                            {
                                foreach (var (lastCheckedEntity, lastChecked) in lastCheckedEntities)
                                {
                                    if (lastChecked)
                                    {
                                        entitiesToResetFromClient.AddLast(lastCheckedEntity);
                                    }
                                    else
                                    {
                                        entitiesToRemoveFromClient.AddLast(lastCheckedEntity);
                                        onEntityRemove(client, lastCheckedEntity);
                                        if (!netOwnerEvents) continue;
                                        if (lastCheckedEntity.NetOwner == client)
                                        {
                                            lastCheckedEntity.NetOwner = null;
                                            lastCheckedEntity.NetOwnerRange = float.MaxValue;
                                        }

                                        if (lastCheckedEntity.TempNetOwner == client)
                                        {
                                            lastCheckedEntity.TempNetOwner = null;
                                            lastCheckedEntity.TempNetOwnerRange = float.MaxValue;
                                        }
                                    }
                                }

                                if (entitiesToResetFromClient.Count != 0)
                                {
                                    var currEntity = entitiesToResetFromClient.First;

                                    while (currEntity != null)
                                    {
                                        client.RemoveCheck(threadIndex, currEntity.Value);
                                        currEntity = currEntity.Next;
                                    }

                                    entitiesToResetFromClient.Clear();
                                }

                                if (entitiesToRemoveFromClient.Count != 0)
                                {
                                    var currEntity = entitiesToRemoveFromClient.First;

                                    while (currEntity != null)
                                    {
                                        client.RemoveEntity(threadIndex, currEntity.Value);
                                        currEntity = currEntity.Next;
                                    }

                                    entitiesToRemoveFromClient.Clear();
                                }
                            }

                            if (foundEntities != null)
                            {
                                for (int i = 0, length = foundEntities.Count; i < length; i++)
                                {
                                    var foundEntity = foundEntities[i];

                                    client.AddCheck(threadIndex, foundEntity);
                                    foundEntity.DataSnapshot.CompareWithClient(threadIndex, changedEntityDataKeys,
                                        client);
                                    // We add client to entity here so we can remove it from the client when the entity got removed
                                    foundEntity.TryAddClient(client);

                                    if (client.TryAddEntity(threadIndex, foundEntity))
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
                                    else
                                    {
                                        if (changedEntityDataKeys.Count != 0)
                                        {
                                            onEntityDataChange(client, foundEntity, changedEntityDataKeys);
                                            changedEntityDataKeys.Clear();
                                        }

                                        if (!netOwnerEvents) continue;
                                        // Net Owner
                                        var lastStreamInRange = foundEntity.LastStreamInRange;
                                        if (foundEntity.NetOwner == null)
                                        {
                                            // If net owner is null, we need closest player
                                            if (foundEntity.TempNetOwner == client)
                                            {
                                                var lastNetOwner = foundEntity.NetOwner;
                                                if (lastNetOwner != null)
                                                {
                                                    onEntityNetOwnerChange(foundEntity.NetOwner, foundEntity, false);
                                                }

                                                foundEntity.NetOwner = client;
                                                foundEntity.NetOwnerRange = lastStreamInRange;
                                                foundEntity.TempNetOwnerRange = float.MaxValue;
                                                foundEntity.TempNetOwner = null;
                                                onEntityNetOwnerChange(client, foundEntity, true);
                                            }
                                            else if (foundEntity.TempNetOwnerRange > lastStreamInRange)
                                            {
                                                foundEntity.TempNetOwner = client;
                                                foundEntity.TempNetOwnerRange = lastStreamInRange;
                                            }
                                        }
                                        else
                                        {
                                            // If net owner is not null, we need closest player but with migration distance
                                            // And we need to update own range to entity
                                            if (foundEntity.NetOwner == client)
                                            {
                                                foundEntity.NetOwnerRange = lastStreamInRange;
                                                if (foundEntity.TempNetOwnerRange > lastStreamInRange)
                                                {
                                                    foundEntity.TempNetOwner = client;
                                                    foundEntity.TempNetOwnerRange = lastStreamInRange;
                                                }
                                            }
                                            else if (foundEntity.TempNetOwner == client)
                                            {
                                                var lastNetOwner = foundEntity.NetOwner;
                                                if (lastNetOwner != null)
                                                {
                                                    onEntityNetOwnerChange(foundEntity.NetOwner, foundEntity, false);
                                                }

                                                foundEntity.NetOwner = client;
                                                foundEntity.NetOwnerRange = lastStreamInRange;
                                                foundEntity.TempNetOwnerRange = float.MaxValue;
                                                foundEntity.TempNetOwner = null;
                                                onEntityNetOwnerChange(client, foundEntity, true);
                                            }
                                            else if (foundEntity.NetOwnerRange > foundEntity.MigrationDistance
                                                     && foundEntity.TempNetOwnerRange > lastStreamInRange)
                                            {
                                                foundEntity.TempNetOwner = client;
                                                foundEntity.TempNetOwnerRange = lastStreamInRange;
                                            }
                                        }
                                    }
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