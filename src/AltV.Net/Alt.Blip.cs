using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public partial class Alt
    {
        public static IBlip CreateBlip(IPlayer player, byte type, Position pos) =>
            Module.Server.CreateBlip(player, type, pos);

        public static IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach) =>
            Module.Server.CreateBlip(player, type, entityAttach);
        
        public static IBlip CreateBlip(byte type, Position pos) =>
            Module.Server.CreateBlip(null, type, pos);

        public static IBlip CreateBlip(byte type, IEntity entityAttach) =>
            Module.Server.CreateBlip(null, type, entityAttach);
    }
}