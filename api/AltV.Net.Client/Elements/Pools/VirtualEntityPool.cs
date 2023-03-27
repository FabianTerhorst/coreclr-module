using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class VirtualEntityPool : BaseObjectPool<IVirtualEntity>
    {
        public VirtualEntityPool(IBaseObjectFactory<IVirtualEntity> virtualEntityFactory) : base(virtualEntityFactory)
        {
        }
    }
}