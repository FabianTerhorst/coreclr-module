using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class VirtualEntityPool : BaseObjectPool<IVirtualEntity>
    {
        public VirtualEntityPool(IBaseObjectFactory<IVirtualEntity> virtualEntityFactory) : base(virtualEntityFactory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.VirtualEntityGroup_GetID(entityPointer);
            }
        }
    }
}