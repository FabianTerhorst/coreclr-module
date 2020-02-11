namespace AltV.Net.EntitySync.Events
{
    /// <summary>
    /// This event is used to notify about clearing the cache of a entity
    /// </summary>
    public readonly struct EntityClearCacheEvent
    {
        public readonly IEntity Entity;

        public EntityClearCacheEvent(IEntity entity)
        {
            Entity = entity;
        }
    }
}