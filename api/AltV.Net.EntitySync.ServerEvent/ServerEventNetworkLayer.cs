using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Channels;
using System.Threading.Tasks;
using AltV.Net.EntitySync.Events;

namespace AltV.Net.EntitySync.ServerEvent
{
    public class ServerEventNetworkLayer : NetworkLayer
    {
        public override event ConnectionConnectEventDelegate OnConnectionConnect;
        public override event ConnectionDisconnectEventDelegate OnConnectionDisconnect;
        public override event EntityCreateEventDelegate OnEntityCreate;
        public override event EntityRemoveEventDelegate OnEntityRemove;
        public override event EntityPositionUpdateEventDelegate OnEntityPositionUpdate;
        public override event EntityPositionUpdateEventDelegate OnEntityDataUpdate;

        private readonly struct ServerEntityEvent
        {
            public readonly byte EventType;

            public readonly IEntity Entity;

            public readonly IEnumerable<string> ChangedKeys;

            public readonly Vector3 Position;

            public readonly IEnumerable<object> ChangedData;

            public ServerEntityEvent(byte eventType, IEntity entity, IEnumerable<string> changedKeys, Vector3 position,
                IEnumerable<object> changedData)
            {
                EventType = eventType;
                Entity = entity;
                ChangedKeys = changedKeys;
                Position = position;
                ChangedData = changedData;
            }

            public ServerEntityEvent(byte eventType, IEntity entity, IEnumerable<string> changedKeys) : this(eventType,
                entity, changedKeys, Vector3.Zero, null)
            {
            }
        }

        private readonly IDictionary<IClient, Channel<ServerEntityEvent>> serverEventChannels =
            new Dictionary<IClient, Channel<ServerEntityEvent>>();

        public ServerEventNetworkLayer(IClientRepository clientRepository) : base(clientRepository)
        {
            Alt.OnPlayerConnect += (player, reason) =>
            {
                var playerClient = new PlayerClient(player.Id.ToString(), player);
                player.SetEntitySyncClient(playerClient);
                clientRepository.Add(playerClient);
                Task.Factory.StartNew(async obj =>
                {
                    var currPlayerClient = (PlayerClient) obj;
                    var channel = Channel.CreateUnbounded<ServerEntityEvent>(new UnboundedChannelOptions
                        {SingleReader = true});
                    lock (serverEventChannels)
                    {
                        serverEventChannels[currPlayerClient] = channel;
                    }

                    var channelReader = channel.Reader;
                    while (await channelReader.WaitToReadAsync())
                    {
                        while (channelReader.TryRead(out var entityEvent))
                        {
                            try
                            {
                                switch (entityEvent.EventType)
                                {
                                    case 1:
                                        currPlayerClient.Emit("entitySync:create",
                                            entityEvent.Entity.Serialize(entityEvent.ChangedKeys));
                                        break;
                                    case 2:
                                        currPlayerClient.Emit("entitySync:remove", entityEvent.Entity.Id);
                                        break;
                                    case 3:
                                        currPlayerClient.Emit("entitySync:updatePosition", entityEvent.Entity.Id,
                                            entityEvent.Position);
                                        break;
                                    case 4:
                                        var dictionary = new Dictionary<string, object>();
                                        var changedData = entityEvent.ChangedData;
                                        if (changedData != null)
                                        {
                                            using var changedDataIterator = changedData.GetEnumerator();
                                            while (true)
                                            {
                                                string key;
                                                if (changedDataIterator.MoveNext())
                                                {
                                                    key = (string) changedDataIterator.Current;
                                                }
                                                else
                                                {
                                                    break;
                                                }

                                                if (changedDataIterator.MoveNext() && key != null)
                                                {
                                                    dictionary[key] = changedDataIterator.Current;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                        }

                                        currPlayerClient.Emit("entitySync:updateData", entityEvent.Entity.Id,
                                            dictionary);
                                        break;
                                }
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception);
                            }
                        }
                    }
                }, playerClient);
            };
            Alt.OnPlayerDisconnect += (player, reason) =>
            {
                var client = clientRepository.Remove(player.Id.ToString());
                if (client == null) return;
                Channel<ServerEntityEvent> channel;
                lock (serverEventChannels)
                {
                    if (!serverEventChannels.Remove(client, out channel)) return;
                }

                channel.Writer.Complete();
            };
        }

        public override void SendEvent(IClient client, in EntityCreateEvent entityCreate)
        {
            Channel<ServerEntityEvent> channel;
            lock (serverEventChannels)
            {
                if (!serverEventChannels.TryGetValue(client, out channel)) return;
            }

            channel.Writer.TryWrite(new ServerEntityEvent(1, entityCreate.Entity, entityCreate.ChangedKeys));
        }

        public override void SendEvent(IClient client, in EntityRemoveEvent entityRemove)
        {
            Channel<ServerEntityEvent> channel;
            lock (serverEventChannels)
            {
                if (!serverEventChannels.TryGetValue(client, out channel)) return;
            }

            channel.Writer.TryWrite(new ServerEntityEvent(2, entityRemove.Entity, null));
        }

        public override void SendEvent(IClient client, in EntityPositionUpdateEvent entityPositionUpdate)
        {
            Channel<ServerEntityEvent> channel;
            lock (serverEventChannels)
            {
                if (!serverEventChannels.TryGetValue(client, out channel)) return;
            }

            channel.Writer.TryWrite(new ServerEntityEvent(3, entityPositionUpdate.Entity, null,
                entityPositionUpdate.Position, null));
        }

        public override void SendEvent(IClient client, in EntityDataChangeEvent entityDataChange)
        {
            Channel<ServerEntityEvent> channel;
            lock (serverEventChannels)
            {
                if (!serverEventChannels.TryGetValue(client, out channel)) return;
            }

            channel.Writer.TryWrite(new ServerEntityEvent(4, entityDataChange.Entity, null,
                Vector3.Zero, entityDataChange.Data));
        }
    }
}