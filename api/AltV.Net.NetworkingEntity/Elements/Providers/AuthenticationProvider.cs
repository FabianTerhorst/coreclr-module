using System;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Threading.Channels;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.NetworkingEntity.Elements.Entities;
using AltV.Net.NetworkingEntity.Elements.Pools;
using net.vieapps.Components.WebSockets;
using WebSocket = net.vieapps.Components.WebSockets.WebSocket;

namespace AltV.Net.NetworkingEntity.Elements.Providers
{
    //TODO: synchronize connect, disconnect via channel as coroutine e.g. for concurrent free token access
    //TODO: and preventing problems when player connects and disconnects soon after and tasks executes in wrong order
    /// <summary>
    /// Default authentication provider to handle authentication based on player connect, disconnect and sends the player the url to connect the websocket to
    /// </summary>
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private struct PlayerEvent
        {
            public IPlayer Player { get; }
            public bool Connected { get; }

            public PlayerEvent(IPlayer player, bool connected)
            {
                Player = player;
                Connected = connected;
            }
        }

        private const string ClientExtra = "CLIENT";

        private readonly Dictionary<string, IPlayer> playerTokens = new Dictionary<string, IPlayer>();

        private readonly Dictionary<IPlayer, string> playerTokenAccess = new Dictionary<IPlayer, string>();

        private readonly Channel<PlayerEvent> playerEvents = Channel.CreateUnbounded<PlayerEvent>(
            new UnboundedChannelOptions
            {
                SingleReader = true
            });

        private readonly ChannelReader<PlayerEvent> playerEventsReader;

        private readonly ChannelWriter<PlayerEvent> playerEventsWriter;

        public AuthenticationProvider(string ip, int port, WebSocket webSocket) : this(
            "ws://" + (ip ?? GetIpAddress()) + $":{port}/",
            webSocket)
        {
            playerEventsReader = playerEvents.Reader;
            playerEventsWriter = playerEvents.Writer;
        }

        public AuthenticationProvider(string url, WebSocket webSocket)
        {
            Task.Run(async () =>
            {
                while (await playerEventsReader.WaitToReadAsync())
                {
                    while (playerEventsReader.TryRead(out var playerEvent))
                    {
                        var player = playerEvent.Player;
                        if (playerEvent.Connected)
                        {
                            var client = AltNetworking.CreateClient();
                            lock (client)
                            {
                                if (!client.Exists) continue;
                                playerTokens[client.Token] = player;
                                playerTokenAccess[player] = client.Token;
                                player.SetNetworkingClient(client);

                                lock (player)
                                {
                                    if (player.Exists)
                                    {
                                        player.Emit("streamingToken", url, client.Token);
                                    }
                                }
                            }
                        }
                        else
                        {
                            player.RemoveNetworkingClient();
                            if (playerTokenAccess.Remove(player, out var token))
                            {
                                playerTokens.Remove(token);
                            }
                            else
                            {
                                continue;
                            }

                            if (!AltNetworking.Module.ClientPool.Remove(token, out var client)) continue;
                            var clientWebSocket = client.WebSocket;
                            if (clientWebSocket != null)
                            {
                                await webSocket.CloseWebSocketAsync(clientWebSocket, WebSocketCloseStatus.NormalClosure,
                                    "disconnected");
                            }
                        }
                    }
                }
            });
            Alt.OnPlayerConnect += (player, reason) =>
            {
                playerEventsWriter.WriteAsync(new PlayerEvent(player, true));
            };
            Alt.OnPlayerDisconnect += (player, reason) =>
            {
                playerEventsWriter.WriteAsync(new PlayerEvent(player, false));
            };
        }

        public Task<bool> Verify(INetworkingClientPool networkingClientPool, ManagedWebSocket webSocket, string token,
            out INetworkingClient client)
        {
            if (!networkingClientPool.TryGet(token, out client)) return Task.FromResult(false);
            //TODO: check if already has websocket ect. client.WebSocket
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