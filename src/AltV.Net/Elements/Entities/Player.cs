using System;

namespace AltV.Net.Elements.Entities
{
    internal class Player : Entity, IPlayer
    {
        internal Player(IntPtr nativePointer, Server server) : base(nativePointer, EntityType.Player, server)
        {
        }

        public void Call(string eventName, params object[] args)
        {
            Server.TriggerClientEvent(this, eventName, args);
        }
    }
}