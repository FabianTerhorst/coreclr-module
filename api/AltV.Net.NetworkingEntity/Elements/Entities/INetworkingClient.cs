using net.vieapps.Components.WebSockets;

namespace AltV.Net.NetworkingEntity.Elements.Entities
{
    public interface INetworkingClient
    {
        string Token { get; set; }
        
        bool Exists { get; }

        ClientDataSnapshot Snapshot { get; }

        ManagedWebSocket WebSocket { get; set; }
        
        int Dimension { get; set; }
    }
}