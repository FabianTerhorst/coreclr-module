using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public partial class Alt
    {
        /// <summary>
        /// Creates a checkpoint for a specific player, with given type, position, radius, height and color.
        /// </summary>
        /// <param name="player">The player for which the checkpoint is created.</param>
        /// <param name="type">The type of the checkpoint.</param>
        /// <param name="pos">The position of the checkpoint.</param>
        /// <param name="radius">The size of the checkpoint.</param>
        /// <param name="height">The height of the checkpoint.</param>
        /// <param name="color">The color of the checkpoint.</param>
        /// <returns>The created Checkpoint.</returns>
        public static ICheckpoint CreateCheckpoint(IPlayer player, byte type, Position pos, float radius, float height,
            Rgba color) =>
            Module.Server.CreateCheckpoint(player, type, pos, radius, height, color);

        /// <summary>
        /// Creates a checkpoint for a specific player, with given type, position, radius, height and color.
        /// </summary>
        /// <param name="player">The player for which the checkpoint is created.</param>
        /// <param name="type">The type of the checkpoint.</param>
        /// <param name="pos">The position of the checkpoint.</param>
        /// <param name="radius">The size of the checkpoint.</param>
        /// <param name="height">The height of the checkpoint.</param>
        /// <param name="color">The color (of the checkpoint.</param>
        /// <returns>The created Checkpoint.</returns>
        public static ICheckpoint CreateCheckpoint(IPlayer player, CheckpointType type, Position pos, float radius,
            float height,
            Rgba color) =>
            Module.Server.CreateCheckpoint(player, (byte) type, pos, radius, height, color);

        /// <summary>
        /// Creates a checkpoint for a all players, with given type, position, radius, height and color.
        /// </summary>
        /// <param name="type">The type of the checkpoint.</param>
        /// <param name="pos">The position of the checkpoint.</param>
        /// <param name="radius">The size of the checkpoint.</param>
        /// <param name="height">The height of the checkpoint.</param>
        /// <param name="color">The color of the checkpoint.</param>
        /// <returns>The created Checkpoint.</returns>
        public static ICheckpoint CreateCheckpoint(byte type, Position pos, float radius, float height,
            Rgba color) =>
            Module.Server.CreateCheckpoint(null, type, pos, radius, height, color);

        /// <summary>
        /// Creates a checkpoint for a all players, with given type, position, radius, height and color.
        /// </summary>
        /// <param name="type">The type of the checkpoint.</param>
        /// <param name="pos">The position of the checkpoint.</param>
        /// <param name="radius">The size of the checkpoint.</param>
        /// <param name="height">The height of the checkpoint.</param>
        /// <param name="color">The color of the checkpoint.</param>
        /// <returns></returns>
        public static ICheckpoint CreateCheckpoint(CheckpointType type, Position pos, float radius,
            float height,
            Rgba color) =>
            Module.Server.CreateCheckpoint(null, (byte) type, pos, radius, height, color);
    }
}