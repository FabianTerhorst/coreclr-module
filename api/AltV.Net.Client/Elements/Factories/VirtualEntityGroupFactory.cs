using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class VirtualEntityGroupFactory : IBaseObjectFactory<IVirtualEntityGroup>
    {
        public IVirtualEntityGroup Create(ICore core, IntPtr virtualEntityGroupPointer)
        {
            return new VirtualEntityGroup(core, virtualEntityGroupPointer);
        }
    }
}