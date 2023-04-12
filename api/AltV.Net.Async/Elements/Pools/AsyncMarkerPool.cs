using System;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncMarkerPool : AsyncBaseObjectPool<IMarker>
    {
        public AsyncMarkerPool(IBaseObjectFactory<IMarker> entityFactory, bool forceAsync = false) : base(entityFactory, forceAsync)
        {
        }

        public override async Task ForEach(IAsyncBaseObjectCallback<IMarker> asyncBaseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                if (!baseObject.Exists) continue;
                await asyncBaseObjectCallback.OnBaseObject(baseObject);
            }
        }

        public override uint GetId(IntPtr entityPointer)
        {
            return AltAsync.Do(() => Marker.GetId(entityPointer)).Result;
        }

        public override void ForEach(IBaseObjectCallback<IMarker> baseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                if (!baseObject.Exists) continue;
                baseObjectCallback.OnBaseObject(baseObject);
            }
        }
    }
}