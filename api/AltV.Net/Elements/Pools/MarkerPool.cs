using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class MarkerPool : BaseObjectPool<IMarker>
    {
        public MarkerPool(IBaseObjectFactory<IMarker> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.Marker_GetID(entityPointer);
            }
        }
    }
}