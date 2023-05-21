using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockConnectionInfoPool : ConnectionInfoPool
    {
        public MockConnectionInfoPool(IBaseObjectFactory<IConnectionInfo> factory) : base(factory)
        {
        }

        public override void OnRemove(IConnectionInfo entity)
        {
            MockEntities.FreeNoId(entity.NativePointer);
        }
    }
}