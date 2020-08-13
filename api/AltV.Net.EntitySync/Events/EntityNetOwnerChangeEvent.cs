namespace AltV.Net.EntitySync.Events
{
    /// <summary>
    /// This event is used to notify about a local client net owner update of a entity
    /// </summary>
    public readonly struct EntityNetOwnerChangeEvent
    {
        public readonly IEntity Entity;

        public readonly bool State;

        public EntityNetOwnerChangeEvent(IEntity entity, bool state)
        {
            Entity = entity;
            State = state;
        }
    }
}