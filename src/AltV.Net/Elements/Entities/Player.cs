using System;
using AltV.Net.Data;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    internal class Player : Entity, IPlayer
    {
        internal Player(IntPtr nativePointer) : base(nativePointer, EntityType.Player)
        {
        }

        public void Call(string eventName, params object[] args)
        {
            Alt.Server.TriggerClientEvent(this, eventName, args);
        }

        public ReadOnlyPlayer Copy()
        {
            var readOnlyPlayer = ReadOnlyPlayer.Empty;
            AltVNative.Player.Player_Copy(NativePointer, ref readOnlyPlayer);
            return readOnlyPlayer;
        }
    }
}