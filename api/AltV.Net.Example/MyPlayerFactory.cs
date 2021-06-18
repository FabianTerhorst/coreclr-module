using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    [EntityFactory(BaseObjectType.Player)]
    public class MyPlayerFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(IntPtr playerPointer, ushort id)
        {
            return new MyPlayer(playerPointer, id);
        }
    }
}