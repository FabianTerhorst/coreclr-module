using System;

namespace AltV.Net.Elements.Entities
{
    public class EntityRemovedException : Exception
    {
        internal EntityRemovedException(IEntity entity) : base(
            $"Entity(Type={entity.Type.ToString()}, id={entity.Id}) got removed.")
        {
        }
    }
}