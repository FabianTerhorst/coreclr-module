using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockColShapePool : ColShapePool
    {
        public MockColShapePool(IBaseObjectFactory<IColShape> colShapeFactory) : base(colShapeFactory)
        {
        }

        public override void OnRemove(IColShape entity)
        {
            MockEntities.FreeNoId(entity.NativePointer);
        }
    }
}