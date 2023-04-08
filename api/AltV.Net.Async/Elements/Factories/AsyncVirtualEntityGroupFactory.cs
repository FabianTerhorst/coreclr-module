using System;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Factories
{
    public class AsyncVirtualEntityGroupFactory : IBaseObjectFactory<IVirtualEntityGroup>
    {
        public IVirtualEntityGroup Create(ICore core, IntPtr baseObjectPointer, uint id)
        {
            return new AsyncVirtualEntityGroup(core, baseObjectPointer, id);
        }
    }
}