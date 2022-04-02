using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class RmlDocumentFactory : IBaseObjectFactory<IRmlDocument>
    {
        public IRmlDocument Create(ICore core, IntPtr blipPointer)
        {
            return new RmlDocument(core, blipPointer);
        }
    }
}