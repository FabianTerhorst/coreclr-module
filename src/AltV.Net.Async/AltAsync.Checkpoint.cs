using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static async Task<ICheckpoint> CreateCheckpoint(IPlayer player, byte type, Position pos, float radius,
            float height,
            Rgba color) =>
            await AltVAsync.Schedule(() => Alt.CreateCheckpoint(player, type, pos, radius, height, color))
                .ConfigureAwait(false);
        
        public static async Task<ICheckpoint> CreateCheckpoint(IPlayer player, CheckpointType type, Position pos, float radius,
            float height,
            Rgba color) =>
            await AltVAsync.Schedule(() => Alt.CreateCheckpoint(player, type, pos, radius, height, color))
                .ConfigureAwait(false);
    }
}