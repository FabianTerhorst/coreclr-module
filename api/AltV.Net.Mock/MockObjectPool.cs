using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockObjectPool : ObjectPool
    {
        public MockObjectPool(IEntityFactory<IObject> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            return 0;
        }

        public override void OnRemove(IObject entity)
        {
            MockEntities.Free(entity.NativePointer, entity.Id);
        }
    }
}