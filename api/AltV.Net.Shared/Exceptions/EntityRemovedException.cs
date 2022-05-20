using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Entities
{
    public class EntityRemovedException : WorldObjectRemovedException
    {
        internal EntityRemovedException(ISharedEntity entity) : base(
            $"Entity(Type={entity.Type.ToString()}, id={entity.Id}) got removed.")
        {
        }
    }
}