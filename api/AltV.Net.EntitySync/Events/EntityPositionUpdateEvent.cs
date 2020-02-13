using System.Numerics;

namespace AltV.Net.EntitySync.Events
{
    /// <summary>
    /// This event is used to notify about a position update of a entity
    /// </summary>
    public readonly struct EntityPositionUpdateEvent
    {
        public readonly IEntity Entity;

        public readonly Vector3 Position;

        public EntityPositionUpdateEvent(IEntity entity, Vector3 position)
        {
            Entity = entity;
            Position = position;
        }
    }
}