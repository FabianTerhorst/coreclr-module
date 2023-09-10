using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class VirtualEntityGroupFactory : IBaseObjectFactory<IVirtualEntityGroup>
    {
        public IVirtualEntityGroup Create(ICore core, IntPtr pointer, uint id)
        {
            return new VirtualEntityGroup(core, pointer, id);
        }
    }
}