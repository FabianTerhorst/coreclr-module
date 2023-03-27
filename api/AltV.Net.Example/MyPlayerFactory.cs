using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    [EntityFactory(BaseObjectType.Player)]
    public class MyPlayerFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(ICore core, IntPtr playerPointer, uint id)
        {
            return new MyPlayer(core, playerPointer, id);
        }
    }
}