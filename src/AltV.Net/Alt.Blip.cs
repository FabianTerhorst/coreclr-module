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

        public static IBlip CreateBlip(IPlayer player, BlipType type, Position pos) =>
            Module.Server.CreateBlip(player, (byte) type, pos);

        public static IBlip CreateBlip(IPlayer player, BlipType type, IEntity entityAttach) =>
            Module.Server.CreateBlip(player, (byte) type, entityAttach);

        public static IBlip CreateBlip(byte type, Position pos) =>
            Module.Server.CreateBlip(null, type, pos);

        public static IBlip CreateBlip(byte type, IEntity entityAttach) =>
            Module.Server.CreateBlip(null, type, entityAttach);

        public static IBlip CreateBlip(BlipType type, Position pos) =>
            Module.Server.CreateBlip(null, (byte) type, pos);

        public static IBlip CreateBlip(BlipType type, IEntity entityAttach) =>
            Module.Server.CreateBlip(null, (byte) type, entityAttach);
    }
}