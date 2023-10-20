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
        /// <param name="global">If the blip global</param>
        /// <param name="type">The type of the blip.</param>
        /// <param name="pos">The position on which the blip is created.</param>
        /// <param name="targets">Targets there can see the blip</param>
        /// <returns>The created Blip.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IBlip CreateBlip(bool global, byte type, Position pos, IPlayer[] targets) =>
            Core.CreateBlip(global, type, pos, targets);

        /// <summary>
        /// Create a blip for a specific player, attached to specific entity.
        /// </summary>
        /// <param name="global">If the blip global</param>
        /// <param name="type">The type of the blip.</param>
        /// <param name="entityAttach">The entity to which the blip is atteched to.</param>
        /// <param name="targets">Targets there can see the blip</param>
        /// <returns>The created Blip.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IBlip CreateBlip(bool global, byte type, IEntity entityAttach, IPlayer[] targets) =>
            Core.CreateBlip(global, type, entityAttach, targets);

        /// <summary>
        /// Creates a blip for a specific player on a specific position.
        /// </summary>
        /// <param name="global">If the blip global</param>
        /// <param name="type">The type of the blip.</param>
        /// <param name="pos">The position on which the blip is created.</param>
        /// <param name="targets">Targets there can see the blip</param>
        /// <returns>The created Blip.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IBlip CreateBlip(bool global, BlipType type, Position pos, IPlayer[] targets) =>
            Core.CreateBlip(global, (byte) type, pos, targets);

        /// <summary>
        /// Creates a blip for a specific player, attached to specific entity.
        /// </summary>
        /// <param name="global">If the blip global</param>
        /// <param name="type">The type of the blip.</param>
        /// <param name="entityAttach">The entity to which the blip is atteched to.</param>
        /// <param name="targets">Targets there can see the blip</param>
        /// <returns>The created Blip.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IBlip CreateBlip(bool global, BlipType type, IEntity entityAttach, IPlayer[] targets) =>
            Core.CreateBlip(global, (byte) type, entityAttach, targets);
    }
}