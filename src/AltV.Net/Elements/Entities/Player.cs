using System;

namespace AltV.Net.Elements.Entities
{
    internal class Player : Entity, IPlayer
    {
        internal Player(IntPtr nativePointer) : base(nativePointer, EntityType.Player)
        {
        }
    }
}