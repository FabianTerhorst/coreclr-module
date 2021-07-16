using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class PlayerFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(IServer server, IntPtr playerPointer, ushort id)
        {
            return new Player(server, playerPointer, id);
        }
    }
}