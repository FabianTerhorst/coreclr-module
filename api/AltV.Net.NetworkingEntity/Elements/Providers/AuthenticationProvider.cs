using System;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.NetworkingEntity.Elements.Entities;
using net.vieapps.Components.WebSockets;
using WebSocket = net.vieapps.Components.WebSockets.WebSocket;

namespace AltV.Net.NetworkingEntity.Elements.Providers
{
    /// <summary>
    /// Default authentication provider to handle authentication based on player connect, disconnect and sends the player the url to connect the websocket to
    /// </summary>
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private const string ClientExtra = "CLIENT";

        private readonly Dictionary<string, IPlayer> playerTokens = new Dictionary<string, IPlayer>();

        private readonly Dictionary<IPlayer, string> playerTokenAccess = new Dictionary<IPlayer, string>();

        public AuthenticationProvider(string ip, int port, WebSocket webSocket) : this(
            "ws://" + (ip ?? GetIpAddress()) + $":{port}/",
            webSocket)
        {
        }

        public AuthenticationProvider(string url, WebSocket webSocket)
        {
            Alt.OnPlayerConnect += (player, reason) =>
            {
                Task.Run(() =>
                {
                    var client = AltNetworking.CreateClient();
                    lock (client)
                    {
                        if (!client.Exists) return;
                        lock (playerTokens)
                        {
                            playerTokens[client.Token] = player;
                            playerTokenAccess[player] = client.Token;

                            player.Emit("streamingToken", url, client.Token);
                        }
                    }
                });
            };
            Alt.OnPlayerDisconnect += (player, reason) =>
            {
                Task.Run(async () =>
                {
                    string token;
                    lock (playerTokens)
                    {
                        if (playerTokenAccess.Remove(player, out token))
                        {
                            playerTokens.Remove(token);
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (AltNetworking.Module.ClientPool.Remove(token, out var client))
                    {
                        var clientWebSocket = client.WebSocket;
                        if (clientWebSocket != null)
                        {
                            await webSocket.CloseWebSocketAsync(clientWebSocket, WebSocketCloseStatus.NormalClosure,
                                "disconnected");
                        }
                    }
                });
            };
        }

        public Task<bool> Verify(ManagedWebSocket webSocket, string token, out INetworkingClient client)
        {
            if (!AltNetworking.Module.ClientPool.TryGet(token, out client)) return Task.FromResult(false);
            client.WebSocket = webSocket; //TODO: check if already has websocket ect.
            webSocket.Extra[ClientExtra] = client;
            return Task.FromResult(true);
        }

        public INetworkingClient GetClient(ManagedWebSocket webSocket)
        {
            if (!webSocket.Extra.TryGetValue(ClientExtra, out var playerObject) ||
                !(playerObject is INetworkingClient client)) return null;
            return client;
        }

        public void OnConnectionBroken(ManagedWebSocket webSocket)
        {
            webSocket.Extra.Remove(ClientExtra);
        }

        public void OnConnectionEstablished(ManagedWebSocket webSocket)
        {
            // we don't care about websockets that are just here, maybe timeout them after 5sec without authentication
        }

        public void OnError(ManagedWebSocket webSocket, Exception exception)
        {
            Console.WriteLine(exception);
        }

        public bool VerifyPosition(INetworkingClient client, INetworkingEntity entity, bool inRange)
        {
            // Can be extended when more trustful position checking is needed 
            return true;
        }

        private static string GetIpAddress()
        {
            var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName()); // `Dns.Resolve()` method is deprecated.
            if (ipHostInfo.AddressList.Length == 0) return null;
            var ipAddress = ipHostInfo.AddressList[0];

            return ipAddress.ToString();
        }
    }
}