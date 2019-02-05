using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public partial class Alt
    {
        public static bool RemoveEntity(IEntity entity) =>
            Module.Server.RemoveEntity(entity);
    }
}