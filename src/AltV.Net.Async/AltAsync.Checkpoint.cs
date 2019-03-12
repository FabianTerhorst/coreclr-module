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

        public static async Task<ICheckpoint> CreateCheckpoint(IPlayer player, CheckpointType type, Position pos,
            float radius,
            float height,
            Rgba color) =>
            await AltVAsync.Schedule(() => Alt.CreateCheckpoint(player, type, pos, radius, height, color))
                .ConfigureAwait(false);

        public static async Task<ICheckpoint> CreateCheckpoint(byte type, Position pos, float radius,
            float height,
            Rgba color) =>
            await AltVAsync.Schedule(() => Alt.CreateCheckpoint(type, pos, radius, height, color))
                .ConfigureAwait(false);

        public static async Task<ICheckpoint> CreateCheckpoint(CheckpointType type, Position pos, float radius,
            float height,
            Rgba color) =>
            await AltVAsync.Schedule(() => Alt.CreateCheckpoint(type, pos, radius, height, color))
                .ConfigureAwait(false);

        public static async Task<bool> IsGlobalAsync(this ICheckpoint checkpoint) =>
            await AltVAsync.Schedule(() => checkpoint.IsGlobal).ConfigureAwait(false);

        public static async Task<CheckpointType> GetCheckpointTypeAsync(this ICheckpoint checkpoint) =>
            await AltVAsync.Schedule(() => (CheckpointType) checkpoint.CheckpointType).ConfigureAwait(false);

        public static async Task<float> GetHeightAsync(this ICheckpoint checkpoint) =>
            await AltVAsync.Schedule(() => checkpoint.Height).ConfigureAwait(false);

        public static async Task<float> GetRadiusAsync(this ICheckpoint checkpoint) =>
            await AltVAsync.Schedule(() => checkpoint.Radius).ConfigureAwait(false);

        public static async Task<Rgba> GetColorAsync(this ICheckpoint checkpoint) =>
            await AltVAsync.Schedule(() => checkpoint.Color).ConfigureAwait(false);

        public static async Task<IPlayer> GetTargetAsync(this ICheckpoint checkpoint) =>
            await AltVAsync.Schedule(() => checkpoint.Target).ConfigureAwait(false);

        public static async Task<bool> IsPlayerInAsync(this ICheckpoint checkpoint, IPlayer player) =>
            await AltVAsync.Schedule(() => checkpoint.IsPlayerIn(player)).ConfigureAwait(false);

        public static async Task<bool> IsVehicleInAsync(this ICheckpoint checkpoint, IVehicle vehicle) =>
            await AltVAsync.Schedule(() => checkpoint.IsVehicleIn(vehicle)).ConfigureAwait(false);

        public static async Task RemoveAsync(this ICheckpoint checkpoint) =>
            await AltVAsync.Schedule(checkpoint.Remove).ConfigureAwait(false);
    }
}