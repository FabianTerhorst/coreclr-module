using System.Numerics;
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

        private Vector3? position;

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
                    dimension = value;
                }
                entityStreamer.UpdateClientDimension(this, value);
            }
        }

        public Vector3? PositionOverride
        {
            get
            {
                lock (this)
                {
                    return position;
                }
            }
            set
            {
                lock (this)
                {
                    if (position == value) return;
                    position = value;
                }
                entityStreamer.UpdateClientPositionOverride(this, value);
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

                if (PositionOverride != null)
                {
                    entityStreamer.UpdateClientPositionOverride(this, PositionOverride);
                }
            }
        }
    }
}