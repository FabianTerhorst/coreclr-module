using System;
using System.Threading.Tasks;
using AltV.Net.NetworkingEntity;
using AltV.Net.NetworkingEntity.Elements.Entities;
using AltV.Net.NetworkingEntity.Elements.Pools;
using AltV.Net.NetworkingEntity.Elements.Providers;
using net.vieapps.Components.WebSockets;

namespace AltV.Net.Networking.Example
{
    public class NonePlayerAuthenticationProvider : IAuthenticationProvider
    {
        private readonly WebSocket webSocket;

        public NonePlayerAuthenticationProvider(WebSocket webSocket)
        {
            this.webSocket = webSocket;
        }

        public Task<bool> Verify(INetworkingClientPool networkingClientPool, ManagedWebSocket managedWebSocket,
            string token, out INetworkingClient client)
        {
            if (networkingClientPool.TryGet(token, out client))
            {
                //managedWebSocket.Extra.TryAdd("client", client);
                /*if (client.WebSocket != managedWebSocket)
                {
                    webSocket.CloseWebSocket(client.WebSocket);
                }

                client.WebSocket = managedWebSocket;*/
                //return Task.FromResult(true);
                networkingClientPool.Remove(client);
                //TODO: maybe try to reuse clients later when client can send if it was a reconnect or new connection in auth event
            }

            client = AltNetworking.CreateClient(token);
            //client.WebSocket = managedWebSocket; //TODO: maybe do that automatically, but we would lost freedom
            client.Dimension = 1;
            managedWebSocket.Extra.TryAdd("client", client);
            return Task.FromResult(true);
        }

        public INetworkingClient GetClient(ManagedWebSocket managedWebSocket)
        {
            if (managedWebSocket.Extra.TryGetValue("client", out var clientObj) &&
                clientObj is INetworkingClient client)
            {
                return client;
            }

            return null;
        }

        public void OnConnectionBroken(ManagedWebSocket managedWebSocket)
        {
            //TODO: remove after 5min without life signal from client pool
            managedWebSocket.Extra.Remove("client");
        }

        public void OnConnectionEstablished(ManagedWebSocket managedWebSocket)
        {
        }

        public void OnError(ManagedWebSocket managedWebSocket, Exception exception)
        {
            Console.WriteLine(exception);
        }

        public bool VerifyPosition(INetworkingClient client, INetworkingEntity entity, bool inRange)
        {
            return true;
        }
    }
}