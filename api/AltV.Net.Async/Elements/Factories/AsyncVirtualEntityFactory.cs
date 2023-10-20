using System;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Factories
{
    public class AsyncVirtualEntityFactory : IBaseObjectFactory<IVirtualEntity>
    {
        public IVirtualEntity Create(ICore core, IntPtr baseObjectPointer, uint id)
        {
            return new AsyncVirtualEntity(core, baseObjectPointer, id);
        }
    }
}