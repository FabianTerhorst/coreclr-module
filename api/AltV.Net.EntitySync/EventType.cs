namespace AltV.Net.EntitySync
{
    public enum EventType
    {
        ConnectionConnect,
        ConnectionDisconnect,
        
        EntityCreate,
        EntityUpdate,
        EntityRemove,
        
        EntityControlAdd,
        EntityControlRemove,
        EntityControlUpdate,
        
        Custom
    }
}