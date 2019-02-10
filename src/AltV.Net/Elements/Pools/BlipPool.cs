using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class BlipPool : EntityPool<IBlip>
    {
        public BlipPool(IEntityFactory<IBlip> blipFactory) : base(blipFactory)
        {
        }
    }
}