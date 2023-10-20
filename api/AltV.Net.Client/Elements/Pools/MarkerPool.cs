using AltV.Net.Client.Elements.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltV.Net.Client.Elements.Pools
{
    public class MarkerPool : BaseObjectPool<IMarker>
    {
        public MarkerPool(IBaseObjectFactory<IMarker> markerFactory) : base(markerFactory)
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
