using System.Numerics;
using net.vieapps.Components.WebSockets;

namespace AltV.Net.NetworkingEntity.Elements.Entities
{
    public interface INetworkingClient
    {
        string Token { get; }
        
        /// <summary>
        /// Overrides the client position with the defined position, will reset when set to null 
        /// </summary>
        Vector3? PositionOverride { get; set; }

        bool Exists { get; }

        ClientDataSnapshot Snapshot { get; }

        ManagedWebSocket WebSocket { get; set; }
        
        int Dimension { get; set; }

        void OnConnect(ManagedWebSocket managedWebSocket);
    }
}