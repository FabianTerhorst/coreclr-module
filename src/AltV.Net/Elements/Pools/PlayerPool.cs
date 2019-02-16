using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Pools
{
    public class PlayerPool : EntityPool<IPlayer>
    {
        public PlayerPool(IEntityFactory<IPlayer> playerFactory) : base(playerFactory)
        {
        }
        
        public override ushort GetId(IntPtr entityPointer)
        {
            return AltVNative.Player.Player_GetID(entityPointer);
        }
    }
}