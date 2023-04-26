using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class ColShapePool : BaseObjectPool<IColShape>
    {
        public ColShapePool(IBaseObjectFactory<IColShape> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.ColShape_GetID(entityPointer);
            }
        }
    }
}