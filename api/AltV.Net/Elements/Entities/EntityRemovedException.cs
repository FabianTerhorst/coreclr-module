namespace AltV.Net.Elements.Entities
{
    public class EntityRemovedException : WorldObjectRemovedException
    {
        internal EntityRemovedException(IEntity entity) : base(
            $"Entity(Type={entity.Type.ToString()}, id={entity.Id}) got removed.")
        {
        }
    }
}