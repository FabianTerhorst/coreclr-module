using System.Runtime.CompilerServices;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public partial class Alt
    {
        /// <summary>
        /// Creates a blip for a specific player on a specific position.
        /// </summary>
        /// <param name="player">The player for which the blip is created.</param>
        /// <param name="type">The type of the blip.</param>
        /// <param name="pos">The position on which the blip is created.</param>
        /// <returns>The created Blip.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IBlip CreateBlip(IPlayer player, byte type, Position pos) =>
            Module.Server.CreateBlip(player, type, pos);

        /// <summary>
        /// Create a blip for a specific player, attached to specific entity.
        /// </summary>
        /// <param name="player">The player for which the blip is created.</param>
        /// <param name="type">The type of the blip.</param>
        /// <param name="entityAttach">The entity to which the blip is atteched to.</param>
        /// <returns>The created Blip.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach) =>
            Module.Server.CreateBlip(player, type, entityAttach);

        /// <summary>
        /// Creates a blip for a specific player on a specific position.
        /// </summary>
        /// <param name="player">The player for which the blip is created.</param>
        /// <param name="type">The type of the blip.</param>
        /// <param name="pos">The position on which the blip is created.</param>
        /// <returns>The created Blip.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IBlip CreateBlip(IPlayer player, BlipType type, Position pos) =>
            Module.Server.CreateBlip(player, (byte) type, pos);

        /// <summary>
        /// Creates a blip for a specific player, attached to specific entity.
        /// </summary>
        /// <param name="player">The player for which the blip is created.</param>
        /// <param name="type">The type of the blip.</param>
        /// <param name="entityAttach">The entity to which the blip is atteched to.</param>
        /// <returns>The created Blip.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IBlip CreateBlip(IPlayer player, BlipType type, IEntity entityAttach) =>
            Module.Server.CreateBlip(player, (byte) type, entityAttach);

        /// <summary>
        /// Creates a blip for all players on a specific position.
        /// </summary>
        /// <param name="type">The type of the blip.</param>
        /// <param name="pos">The position on which the blip is created.</param>
        /// <returns>The created Blip.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IBlip CreateBlip(byte type, Position pos) =>
            Module.Server.CreateBlip(null, type, pos);

        /// <summary>
        /// Creates a blip for all players, attached to specific entity.
        /// </summary>
        /// <param name="type">The type of the blip.</param>
        /// <param name="entityAttach">The entity to which the blip is atteched to.</param>
        /// <returns>The created Blip.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IBlip CreateBlip(byte type, IEntity entityAttach) =>
            Module.Server.CreateBlip(null, type, entityAttach);

        /// <summary>
        /// Creates a blip for all players on a specific position.
        /// </summary>
        /// <param name="type">The type of the blip.</param>
        /// <param name="pos">The position on which the blip is created.</param>
        /// <returns>The created Blip.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IBlip CreateBlip(BlipType type, Position pos) =>
            Module.Server.CreateBlip(null, (byte) type, pos);

        /// <summary>
        /// Creates a blip for all players, attached to specific entity.
        /// </summary>
        /// <param name="type">The type of the blip.</param>
        /// <param name="entityAttach">The entity to which the blip is atteched to.</param>
        /// <returns>The created Blip.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IBlip CreateBlip(BlipType type, IEntity entityAttach) =>
            Module.Server.CreateBlip(null, (byte) type, entityAttach);
    }
}