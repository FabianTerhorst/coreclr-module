using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockMarkerPool : MarkerPool
    {
        public MockMarkerPool(IBaseObjectFactory<IMarker> factory) : base(factory)
        {
        }

        public override void OnRemove(IMarker entity)
        {
            MockEntities.FreeNoId(entity.NativePointer);
        }
    }
}