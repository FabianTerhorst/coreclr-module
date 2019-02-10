using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockPlayerPool : PlayerPool
    {
        public MockPlayerPool(IEntityFactory<IPlayer> playerFactory) : base(playerFactory)
        {
        }

        public override ushort GetId(IntPtr entityPointer)
        {
            return 0;
        }
    }
}