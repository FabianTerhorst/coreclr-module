using System;
using System.Collections.Generic;
using System.Threading;

namespace AltV.Net.EntitySync
{
    /// <summary>
    /// The entity thread checks in a endless loop if entities should be created or removed for all clients.
    /// </summary>
    public class EntityThread
    {
        private bool running = true;

        private readonly Thread thread;

        private readonly IEntityThreadRepository entityThreadRepository;

        private readonly IClientRepository clientRepository;

        private readonly HashSet<IClient> clientsToRemoveFromEntity = new HashSet<IClient>();
        private readonly HashSet<IClient> clientsToResetFromEntity = new HashSet<IClient>();

        private readonly Action<IClient, IEntity, IEnumerable<string>> onEntityCreate;

        private readonly Action<IClient, IEntity> onEntityRemove;

        public EntityThread(IEntityThreadRepository entityThreadRepository, IClientRepository clientRepository,
            Action<IClient, IEntity, IEnumerable<string>> onEntityCreate, Action<IClient, IEntity> onEntityRemove)
        {
            if (onEntityCreate == null)
            {
                throw new ArgumentException("onEntityCreate should not be null.");
            }
            
            if (onEntityRemove == null)
            {
                throw new ArgumentException("onEntityRemove should not be null.");
            }
            
            thread = new Thread(OnLoop);
            thread.Start();
            this.entityThreadRepository = entityThreadRepository;
            this.clientRepository = clientRepository;
            this.onEntityCreate = onEntityCreate;
            this.onEntityRemove = onEntityRemove;
        }

        public void OnLoop()
        {
            while (running)
            {
                var (entities, removedEntities) = entityThreadRepository.GetAll();
                
                if (removedEntities != null)
                {
                    foreach (var removedEntity in removedEntities)
                    {
                        foreach (var client in removedEntity.GetClients())
                        {
                            onEntityRemove(client, removedEntity);
                        }
                    }
                }

                var clients = clientRepository.GetAll();
                foreach (var client in clients)
                {
                    if (!client.TryGetPosition(out var position))
                    {
                        continue;
                    }

                    foreach (var foundEntity in entityThreadRepository.Find(in position))
                    {
                        foundEntity.AddCheck(client);
                        var changedKeys = foundEntity.CompareSnapshotWithClient(client);
                        if (foundEntity.TryAddClient(client))
                        {
                            onEntityCreate(client, foundEntity, changedKeys);
                        }
                    }
                }

                foreach (var entity in entities)
                {
                    var lastCheckedClients = entity.GetLastCheckedClients();
                    if (lastCheckedClients.Count == 0) continue;

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

                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            running = false;
            thread.Join();
        }
    }
}