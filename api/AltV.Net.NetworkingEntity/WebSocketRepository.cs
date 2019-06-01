using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using Google.Protobuf;
using net.vieapps.Components.WebSockets;
using WebSocket = net.vieapps.Components.WebSockets.WebSocket;

namespace AltV.Net.NetworkingEntity
{
    public class WebSocketRepository
    {
        private readonly Dictionary<IPlayer, ManagedWebSocket> playerWebSockets =
            new Dictionary<IPlayer, ManagedWebSocket>();

        public void Add(IPlayer player, ManagedWebSocket webSocket)
        {
            lock (playerWebSockets)
            {
                playerWebSockets[player] = webSocket;
            }
        }

        public void SendToAll(Entity.Event entityEvent)
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

        public Task<bool> Remove(IPlayer player, WebSocket webSocket)
        {
            ManagedWebSocket currWebSocket;
            bool webSocketExists;
            lock (playerWebSockets)
            {
                webSocketExists = playerWebSockets.Remove(player, out currWebSocket);
            }

            if (webSocketExists && currWebSocket != null)
            {
                return webSocket.CloseWebSocketAsync(currWebSocket, WebSocketCloseStatus.NormalClosure,
                    "disconnected");
            }

            return null;
        }
    }
}