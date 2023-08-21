using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class FontFactory : IBaseObjectFactory<IFont>
    {
        public IFont Create(ICore core, IntPtr pointer, uint id)
        {
            return new Font(core, pointer, id);
        }
    }
}