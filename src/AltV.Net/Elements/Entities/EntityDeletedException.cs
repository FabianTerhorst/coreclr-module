using System;

namespace AltV.Net.Elements.Entities
{
    public class EntityDeletedException : Exception
    {
        internal EntityDeletedException(IEntity entity) : base(
            $"Entity(Type: {entity.Type.ToString()}: ID {entity.Id}) got deleted.")
        {
        }
    }
}