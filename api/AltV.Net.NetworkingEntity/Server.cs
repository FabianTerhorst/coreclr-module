using System;
using System.Threading.Tasks;
using AltV.Net.NetworkingEntity.Elements.Entities;
using AltV.Net.NetworkingEntity.Elements.Factories;
using AltV.Net.NetworkingEntity.Elements.Providers;
using Entity;
using Google.Protobuf;
using net.vieapps.Components.WebSockets;

namespace AltV.Net.NetworkingEntity
{
    public class Server
    {
        private readonly WebSocket webSocket;

        private readonly IAuthenticationProvider authenticationProvider;

        private readonly IEntityStreamer streamer;
        
        public event Action<INetworkingEntity, INetworkingClient> EntityStreamInHandler;

        public event Action<INetworkingEntity, INetworkingClient> EntityStreamOutHandler;

        public Server(IAuthenticationProviderFactory authenticationProviderFactory, IEntityStreamer streamer)
        {
            this.streamer = streamer;
            webSocket = new WebSocket
            {
                OnError = (webSocket, exception) =>
                {
                    authenticationProvider.OnError(webSocket, exception);
                },
                OnConnectionEstablished = (webSocket) =>
                {
                    authenticationProvider.OnConnectionEstablished(webSocket); 
                },
                OnConnectionBroken = (webSocket) =>
                {
                    authenticationProvider.OnConnectionBroken(webSocket);
                },
                OnMessageReceived = (webSocket, result, data) =>
                {
                    Task.Run(() =>
                    {
                        var clientEvent = ClientEvent.Parser.ParseFrom(data);
                        if (clientEvent == null) return;
                        var authEvent = clientEvent.Auth;
                        var streamIn = clientEvent.StreamIn;
                        var streamOut = clientEvent.StreamOut;
                        if (authEvent != null)
                        {
                            var token = authEvent.Token;
                            if (token == null) return;
                            var verified = authenticationProvider.Verify(webSocket, token, out var client);
                            if (!verified)
                            {
                                return;
                            }

                            var sendEvent = new ServerEvent();
                            var currSendEvent = new EntitySendEvent();
                            lock (AltNetworking.Module.EntityPool.Entities)
                            {
                                foreach (var entity in AltNetworking.Module.EntityPool.Entities)
                                {
                                    currSendEvent.Entities.Add(entity.Value.StreamedEntity);
                                }
                            }

                            sendEvent.Send = currSendEvent;
                            webSocket.SendAsync(sendEvent.ToByteArray(), true);
                        }
                        else if (streamIn != null)
                        {
                            var client = authenticationProvider.GetClient(webSocket);
                            if (client == null) return;
                            var entityId = streamIn.EntityId;
                            if (AltNetworking.Module.EntityPool.TryGet(entityId, out var entity))
                            {
                                EntityStreamInHandler?.Invoke(entity, client);
                                entity.ClientStreamedIn(client);
                                var changedKeys = entity.Snapshot.CompareWithClient(client);
                                if (changedKeys != null)
                                {
                                    var multipleDataChangeEvent = new EntityMultipleDataChangeEvent();
                                    foreach (var changedKey in changedKeys)
                                    {
                                        if (entity.StreamedEntity.Data.TryGetValue(changedKey, out var mValue))
                                        {
                                            multipleDataChangeEvent.Data[changedKey] = mValue;
                                        }
                                        else // data got deleted probably
                                        {
                                            multipleDataChangeEvent.Data[changedKey] = new MValue {NullValue = false};
                                        }
                                    }

                                    var serverEvent = new ServerEvent {MultipleDataChange = multipleDataChangeEvent};
                                    webSocket.SendAsync(serverEvent.ToByteArray(), true);
                                }
                            }
                        }
                        else if (streamOut != null)
                        {
                            var client = authenticationProvider.GetClient(webSocket);
                            if (client == null) return;
                            var entityId = streamOut.EntityId;
                            if (AltNetworking.Module.EntityPool.TryGet(entityId, out var entity))
                            {
                                EntityStreamOutHandler?.Invoke(entity, client);
                                entity.ClientStreamedOut(client);
                            }
                        }
                    });
                }
            };
            authenticationProvider = authenticationProviderFactory.Create(webSocket);
            webSocket.StartListen();
        }
    }
}