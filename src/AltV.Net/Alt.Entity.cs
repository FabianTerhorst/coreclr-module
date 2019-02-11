using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public partial class Alt
    {
        public static void RemoveEntity(IEntity entity) =>
            Module.Server.RemoveEntity(entity);
    }
}