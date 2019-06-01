using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using Google.Protobuf;
using net.vieapps.Components.WebSockets;
using WebSocket = net.vieapps.Components.WebSockets.WebSocket;

namespace AltV.Net.NetworkingEntity
{
    /// <summary>
    /// Manages websockets associated with the players and sends events to them
    /// </summary>
    public class WebSocketRepository
    {
        private readonly Dictionary<IPlayer, ManagedWebSocket> playerWebSockets =
            new Dictionary<IPlayer, ManagedWebSocket>();

        private readonly Dictionary<ManagedWebSocket, IPlayer> webSocketPlayers =
            new Dictionary<ManagedWebSocket, IPlayer>();

        public void Add(IPlayer player, ManagedWebSocket webSocket)
        {
            lock (playerWebSockets)
            {
                playerWebSockets[player] = webSocket;
                webSocketPlayers[webSocket] = player;
            }
        }

        public void SendToAll(Entity.ServerEvent entityEvent)
        {
            var bytes = entityEvent.ToByteArray();
            lock (playerWebSockets)
            {
                foreach (var value in playerWebSockets.Values)
                {
                    value.SendAsync(bytes, false);
                }
            }
        }

        public void SendToPlayers(HashSet<IPlayer>.Enumerator players, Entity.ServerEvent entityEvent)
        {
            var bytes = entityEvent.ToByteArray();
            lock (playerWebSockets)
            {
                while (players.MoveNext())
                {
                    var player = players.Current;
                    if (playerWebSockets.TryGetValue(player, out var webSocket))
                    {
                        webSocket.SendAsync(bytes, false);
                    }
                }
            }
        }

        public Task<bool> Remove(IPlayer player, WebSocket webSocket)
        {
            ManagedWebSocket currWebSocket;
            bool webSocketExists;
            lock (playerWebSockets)
            {
                webSocketExists = playerWebSockets.Remove(player, out currWebSocket);
                if (webSocketExists)
                {
                    webSocketPlayers.Remove(currWebSocket);
                }
            }

            if (webSocketExists && currWebSocket != null)
            {
                return webSocket.CloseWebSocketAsync(currWebSocket, WebSocketCloseStatus.NormalClosure,
                    "disconnected");
            }

            return null;
        }

        public IPlayer GetPlayer(ManagedWebSocket webSocket)
        {
            lock (playerWebSockets)
            {
                if (webSocketPlayers.TryGetValue(webSocket, out var player)) return player;
            }

            return null;
        }
    }
}