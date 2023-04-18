using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class TextLabelFactory : IBaseObjectFactory<ITextLabel>
    {
        public ITextLabel Create(ICore core, IntPtr blipPointer, uint id)
        {
            return new TextLabel(core, blipPointer, id);
        }
    }
}