using System.Collections.Generic;

namespace AltV.Net.EntitySync.Events
{
    /// <summary>
    /// This event is used to notify about a created entity
    /// </summary>
    public readonly struct EntityCreateEvent
    {
        public readonly IEntity Entity;

        public readonly IDictionary<string, object> Data;

        public EntityCreateEvent(IEntity entity, IDictionary<string, object> data)
        {
            Entity = entity;
            Data = data;
        }
    }
}