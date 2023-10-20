using System;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static Task<ICheckpoint> CreateCheckpoint(byte type, Position pos, float radius,
            float height,
            Rgba color, uint streamingDistance) =>
            AltVAsync.Schedule(() => Alt.CreateCheckpoint(type, pos, radius, height, color, streamingDistance));

        public static Task<ICheckpoint> CreateCheckpoint(CheckpointType type, Position pos, float radius,
            float height,
            Rgba color, uint streamingDistance) =>
            AltVAsync.Schedule(() => Alt.CreateCheckpoint(type, pos, radius, height, color, streamingDistance));

        [Obsolete("Use async entities instead")]
        public static Task<CheckpointType> GetCheckpointTypeAsync(this ICheckpoint checkpoint) =>
            AltVAsync.Schedule(() => (CheckpointType) checkpoint.CheckpointType);

        [Obsolete("Use async entities instead")]
        public static Task<float> GetHeightAsync(this ICheckpoint checkpoint) =>
            AltVAsync.Schedule(() => checkpoint.Height);

        [Obsolete("Use async entities instead")]
        public static Task<float> GetRadiusAsync(this ICheckpoint checkpoint) =>
            AltVAsync.Schedule(() => checkpoint.Radius);

        [Obsolete("Use async entities instead")]
        public static Task<Rgba> GetColorAsync(this ICheckpoint checkpoint) =>
            AltVAsync.Schedule(() => checkpoint.Color);


        [Obsolete("Use Checkpoint.IsEntityIn on async entity instead")]
        public static Task<bool> IsPlayerInAsync(this ICheckpoint checkpoint, IPlayer player) =>
            AltVAsync.Schedule(() => checkpoint.IsPlayerIn(player));

        [Obsolete("Use Checkpoint.IsEntityIn on async entity instead")]
        public static Task<bool> IsVehicleInAsync(this ICheckpoint checkpoint, IVehicle vehicle) =>
            AltVAsync.Schedule(() => checkpoint.IsVehicleIn(vehicle));

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsEntityInAsync(this ICheckpoint checkpoint, IEntity entity) =>
            AltVAsync.Schedule(() => checkpoint.IsEntityIn(entity));

        [Obsolete("Use async entities instead")]
        public static Task DestroyAsync(this ICheckpoint checkpoint) =>
            AltVAsync.Schedule(checkpoint.Destroy);
    }
}