using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static Task<ICheckpoint> CreateCheckpoint(byte type, Position pos, float radius,
            float height,
            Rgba color) =>
            AltVAsync.Schedule(() => Alt.CreateCheckpoint(type, pos, radius, height, color));

        public static Task<ICheckpoint> CreateCheckpoint(CheckpointType type, Position pos, float radius,
            float height,
            Rgba color) =>
            AltVAsync.Schedule(() => Alt.CreateCheckpoint(type, pos, radius, height, color));

        public static Task<CheckpointType> GetCheckpointTypeAsync(this ICheckpoint checkpoint) =>
            AltVAsync.Schedule(() => (CheckpointType) checkpoint.CheckpointType);

        public static Task<float> GetHeightAsync(this ICheckpoint checkpoint) =>
            AltVAsync.Schedule(() => checkpoint.Height);

        public static Task<float> GetRadiusAsync(this ICheckpoint checkpoint) =>
            AltVAsync.Schedule(() => checkpoint.Radius);

        public static Task<Rgba> GetColorAsync(this ICheckpoint checkpoint) =>
            AltVAsync.Schedule(() => checkpoint.Color);

        public static Task<bool> IsPlayerInAsync(this ICheckpoint checkpoint, IPlayer player) =>
            AltVAsync.Schedule(() => checkpoint.IsPlayerIn(player));

        public static Task<bool> IsVehicleInAsync(this ICheckpoint checkpoint, IVehicle vehicle) =>
            AltVAsync.Schedule(() => checkpoint.IsVehicleIn(vehicle));

        public static Task RemoveAsync(this ICheckpoint checkpoint) =>
            AltVAsync.Schedule(checkpoint.Remove);
    }
}