namespace AltV.Net.EntitySync.Events
{
    public delegate void ConnectionConnectEventDelegate(IClient client);

    public delegate void ConnectionDisconnectEventDelegate(IClient client);


    public delegate void EntityCreateEventDelegate(IClient client,
        in EntityCreateEvent entityCreate);

    public delegate void EntityRemoveEventDelegate(IClient client,
        in EntityRemoveEvent entityRemove);

    public delegate void EntityPositionUpdateEventDelegate(IClient client,
        in EntityPositionUpdateEvent entityPositionUpdate);
}