namespace AltV.Net.Elements.Entities
{
    public interface IColShape : IWorldObject
    {
        ColShapeType ColShapeType { get; }
        bool IsEntityIn(IEntity entity);
        void Remove();
    }
}