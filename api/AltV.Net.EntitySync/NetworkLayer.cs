using AltV.Net.EntitySync.Events;

namespace AltV.Net.EntitySync
{
    /// <summary>
    /// The Network layer transfers network events to the application layer
    /// The Network layer transfers application events to the network layer
    /// </summary>
    public abstract class NetworkLayer
    {
        public abstract event ConnectionConnectEventDelegate OnConnectionConnect;
        public abstract event ConnectionDisconnectEventDelegate OnConnectionDisconnect;

        public abstract event EntityCreateEventDelegate OnEntityCreate;
        public abstract event EntityRemoveEventDelegate OnEntityRemove;
        public abstract event EntityPositionUpdateEventDelegate OnEntityPositionUpdate;

        public IClientRepository ClientRepository;

        public NetworkLayer(IClientRepository clientRepository)
        {
            this.ClientRepository = clientRepository;
        }

        public abstract void SendEvent(IClient client, in EntityCreateEvent entityCreate);
        public abstract void SendEvent(IClient client, in EntityRemoveEvent entityRemove);
        public abstract void SendEvent(IClient client, in EntityPositionUpdateEvent entityPositionUpdate);
    }
}