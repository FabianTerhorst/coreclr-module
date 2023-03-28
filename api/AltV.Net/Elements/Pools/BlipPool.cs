using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
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