using net.vieapps.Components.WebSockets;

namespace AltV.Net.NetworkingEntity.Elements.Entities
{
    public class NetworkingClient : INetworkingClient, IInternalNetworkingClient
    {
        //TODO: maybe move token out of the spec
        public string Token { get; }

        public bool Exists { get; set; }

        private readonly IEntityStreamer entityStreamer;

        public ClientDataSnapshot Snapshot { get; } = new ClientDataSnapshot();

        public ManagedWebSocket WebSocket { get; set; }

        private int dimension;

        public int Dimension
        {
            get => dimension;
            set
            {
                if (dimension == value) return;
                entityStreamer.UpdateClientDimension(this, value);
                dimension = value;
            }
        }

        public NetworkingClient(string token, IEntityStreamer entityStreamer)
        {
            Token = token;
            Exists = true;
            this.entityStreamer = entityStreamer;
        }
    }
}