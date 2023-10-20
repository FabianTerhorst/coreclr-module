using System;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncVirtualEntityGroupPool : AsyncBaseObjectPool<IVirtualEntityGroup>
    {
        public AsyncVirtualEntityGroupPool(IBaseObjectFactory<IVirtualEntityGroup> entityFactory, bool forceAsync = false) : base(entityFactory, forceAsync)
        {
        }

        public override async Task ForEach(IAsyncBaseObjectCallback<IVirtualEntityGroup> asyncBaseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                if (baseObject.Exists)
                {
                    await asyncBaseObjectCallback.OnBaseObject(baseObject);
                }
            }
        }

        public override uint GetId(IntPtr entityPointer)
        {
            return AltAsync.Do(() => VirtualEntityGroup.GetId(entityPointer)).Result;
        }

        public override void ForEach(IBaseObjectCallback<IVirtualEntityGroup> baseObjectCallback)
        {
            foreach (var baseObject in GetAllObjects())
            {
                if (baseObject.Exists)
                {
                    baseObjectCallback.OnBaseObject(baseObject);
                }
            }
        }
    }
}