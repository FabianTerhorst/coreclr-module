namespace AltV.Net.EntitySync.Events
{
    /// <summary>
    /// This event is used to notify about a removed entity
    /// </summary>
    public readonly struct EntityRemoveEvent
    {
        public readonly IEntity Entity;

        public EntityRemoveEvent(IEntity entity)
        {
            Entity = entity;
        }
    }
}