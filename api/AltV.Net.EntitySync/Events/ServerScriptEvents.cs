namespace AltV.Net.EntitySync.Events
{
    public delegate void EntityCreateDelegate(IClient client, IEntity entity);
    
    public delegate void EntityRemoveDelegate(IClient client, IEntity entity);
}