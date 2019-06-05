using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using AltV.Net.NetworkingEntity.Elements.Entities;
using AltV.Net.NetworkingEntity.Elements.Providers;
using Entity;
using Google.Protobuf;
using net.vieapps.Components.WebSockets;

namespace AltV.Net.NetworkingEntity
{
    //TODO: create a server entity streaming handler as well that calculates the stream in, stream out from server side
    /// <summary>
    /// Handles entity streaming via events emitted from client
    /// </summary>
    public class ClientEntityStreamingHandler : IStreamingHandler
    {
        private readonly IAuthenticationProvider authenticationProvider;

        public event Action<INetworkingEntity, INetworkingClient> EntityStreamInHandler;

        public event Action<INetworkingEntity, INetworkingClient> EntityStreamOutHandler;

        public ClientEntityStreamingHandler(IAuthenticationProvider authenticationProvider)
        {
            this.authenticationProvider = authenticationProvider;
        }

        public void OnMessage(ManagedWebSocket managedWebSocket, WebSocketReceiveResult result, byte[] data)
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
                    var verified = authenticationProvider.Verify(managedWebSocket, token, out var client);
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
                    managedWebSocket.SendAsync(sendEvent.ToByteArray(), true);
                }
                else if (streamIn != null)
                {
                    var client = authenticationProvider.GetClient(managedWebSocket);
                    if (client == null) return;
                    var entityId = streamIn.EntityId;
                    if (AltNetworking.Module.EntityPool.TryGet(entityId, out var entity))
                    {
                        if (!authenticationProvider.VerifyPosition(client, entity)) return;
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
                            managedWebSocket.SendAsync(serverEvent.ToByteArray(), true);
                        }
                    }
                }
                else if (streamOut != null)
                {
                    var client = authenticationProvider.GetClient(managedWebSocket);
                    if (client == null) return;
                    var entityId = streamOut.EntityId;
                    if (AltNetworking.Module.EntityPool.TryGet(entityId, out var entity))
                    {
                        if (authenticationProvider.VerifyPosition(client, entity)) return;
                        if (entity.ClientStreamedOut(client))
                        {
                            EntityStreamOutHandler?.Invoke(entity, client);
                        }
                    }
                }
            });
        }
    }
}