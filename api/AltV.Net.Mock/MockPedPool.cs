using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockPedPool : PedPool
    {
        public MockPedPool(IEntityFactory<IPed> pedFactory) : base(pedFactory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            return 0;
        }

        public override void OnRemove(IPed entity)
        {
            MockEntities.Free(entity.NativePointer, entity.Id);
        }
    }
}