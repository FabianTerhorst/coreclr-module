using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Pools
{
    public class BlipPool : BaseObjectPool<IBlip>
    {
        public BlipPool(IBaseObjectFactory<IBlip> blipFactory) : base(blipFactory)
        {
        }
    }
}