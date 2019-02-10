using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockBlipPool : BlipPool
    {
        public MockBlipPool(IEntityFactory<IBlip> blipFactory) : base(blipFactory)
        {
        }

        public override ushort GetId(IntPtr entityPointer)
        {
            return 0;
        }
    }
}