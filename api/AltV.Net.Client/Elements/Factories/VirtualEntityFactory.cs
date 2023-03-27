using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class VirtualEntityFactory : IBaseObjectFactory<IVirtualEntity>
    {
        public IVirtualEntity Create(ICore core, IntPtr virtualEntityPointer)
        {
            return new VirtualEntity(core, virtualEntityPointer);
        }
    }
}