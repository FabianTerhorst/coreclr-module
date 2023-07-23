using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockVirtualEntityPool : VirtualEntityPool
    {
        public MockVirtualEntityPool(IBaseObjectFactory<IVirtualEntity> factory) : base(factory)
        {
        }

        public override void OnRemove(IVirtualEntity entity)
        {
            MockEntities.FreeNoId(entity.NativePointer);
        }
    }
}