using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class RmlElementFactory : IBaseObjectFactory<IRmlElement>
    {
        public IRmlElement Create(ICore core, IntPtr blipPointer, uint id)
        {
            return new RmlElement(core, blipPointer, id);
        }
    }
}