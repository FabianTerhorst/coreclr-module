using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class AudioFactory : IBaseObjectFactory<IAudio>
    {
        public IAudio Create(ICore core, IntPtr blipPointer, uint id)
        {
            return new Audio(core, blipPointer, id);
        }
    }
}