using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public partial class Alt
    {
        public static ICheckpoint CreateCheckpoint(IPlayer player, byte type, Position pos, float radius, float height,
            Rgba color) =>
            Module.Server.CreateCheckpoint(player, type, pos, radius, height, color);

        public static ICheckpoint CreateCheckpoint(IPlayer player, CheckpointType type, Position pos, float radius,
            float height,
            Rgba color) =>
            Module.Server.CreateCheckpoint(player, (byte) type, pos, radius, height, color);

        public static ICheckpoint CreateCheckpoint(byte type, Position pos, float radius, float height,
            Rgba color) =>
            Module.Server.CreateCheckpoint(null, type, pos, radius, height, color);

        public static ICheckpoint CreateCheckpoint(CheckpointType type, Position pos, float radius,
            float height,
            Rgba color) =>
            Module.Server.CreateCheckpoint(null, (byte) type, pos, radius, height, color);
    }
}