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
            get
            {
                lock (this)
                {
                    return dimension;
                }
            }
            set
            {
                lock (this)
                {
                    if (dimension == value) return;
                    entityStreamer.UpdateClientDimension(this, value);
                    dimension = value;
                }
            }
        }

        public NetworkingClient(string token, IEntityStreamer entityStreamer)
        {
            Token = token;
            Exists = true;
            this.entityStreamer = entityStreamer;
        }

        public void OnConnect(ManagedWebSocket managedWebSocket)
        {
            lock (this)
            {
                WebSocket = managedWebSocket;
                if (dimension != 0)
                {
                    entityStreamer.UpdateClientDimension(this, dimension);
                }
            }
        }
    }
}