using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class ColShapePool : BaseObjectPool<IColShape>
    {
        public ColShapePool(IBaseObjectFactory<IColShape> colShapeFactory) : base(colShapeFactory)
        {
        }
    }
}