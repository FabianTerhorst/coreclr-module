using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockNetworkObjectPool : NetworkObjectPool
    {
        public MockNetworkObjectPool(IEntityFactory<INetworkObject> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            return 0;
        }

        public override void OnRemove(INetworkObject entity)
        {
            MockEntities.Free(entity.NativePointer, entity.Id);
        }
    }
}