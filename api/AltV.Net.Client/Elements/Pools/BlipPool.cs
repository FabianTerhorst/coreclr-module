using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class BlipPool : BaseObjectPool<IBlip>
    {
        public BlipPool(IBaseObjectFactory<IBlip> blipFactory) : base(blipFactory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.Blip_GetID(entityPointer);
            }
        }
    }
}