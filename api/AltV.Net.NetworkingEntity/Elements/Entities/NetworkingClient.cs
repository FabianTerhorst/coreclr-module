using net.vieapps.Components.WebSockets;

namespace AltV.Net.NetworkingEntity.Elements.Entities
{
    public class NetworkingClient : INetworkingClient, IInternalNetworkingClient
    {
        //TODO: make dimension functional
        
        //TODO: maybe move token out of the spec
        public string Token { get; }

        public bool Exists { get; set; }

        public ClientDataSnapshot Snapshot { get; } = new ClientDataSnapshot();

        public ManagedWebSocket WebSocket { get; set; }

        public int Dimension { get; set; }

        public NetworkingClient(string token)
        {
            Token = token;
            Exists = true;
        }
    }
}