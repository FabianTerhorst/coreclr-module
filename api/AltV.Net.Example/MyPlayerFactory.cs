using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    [EntityFactory(BaseObjectType.Player)]
    public class MyPlayerFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(IServer server, IntPtr playerPointer, ushort id)
        {
            return new MyPlayer(server, playerPointer, id);
        }
    }
}