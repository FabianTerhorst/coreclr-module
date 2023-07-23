using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockVirtualEntityGroupPool : VirtualEntityGroupPool
    {
        public MockVirtualEntityGroupPool(IBaseObjectFactory<IVirtualEntityGroup> factory) : base(factory)
        {
        }

        public override void OnRemove(IVirtualEntityGroup entity)
        {
            MockEntities.FreeNoId(entity.NativePointer);
        }
    }
}