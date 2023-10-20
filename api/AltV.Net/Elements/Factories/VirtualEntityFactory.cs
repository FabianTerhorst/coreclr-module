using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class VirtualEntityFactory : IBaseObjectFactory<IVirtualEntity>
    {
        public IVirtualEntity Create(ICore core, IntPtr pointer, uint id)
        {
            return new VirtualEntity(core, pointer, id);
        }
    }
}