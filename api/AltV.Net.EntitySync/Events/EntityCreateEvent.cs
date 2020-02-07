using System.Collections.Generic;

namespace AltV.Net.EntitySync.Events
{
    /// <summary>
    /// This event is used to notify about a created entity
    /// </summary>
    public readonly struct EntityCreateEvent
    {
        public readonly IEntity Entity;

        public readonly IEnumerable<string> ChangedKeys;

        public EntityCreateEvent(IEntity entity, IEnumerable<string> changedKeys)
        {
            Entity = entity;
            ChangedKeys = changedKeys;
        }
    }
}