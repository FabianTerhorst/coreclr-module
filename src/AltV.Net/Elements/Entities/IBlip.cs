namespace AltV.Net.Elements.Entities
{
    public interface IBlip : IWorldObject
    {
        bool IsGlobal { get; }
        bool IsAttached { get; }
        IEntity AttachedTo { get; }
        byte BlipType { get; }
        ushort Sprite { set; }
        byte Color { set; }
        bool Route { set; }
        byte RouteColor { set; }
        void Remove();
    }
}