using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class AudioFilterFactory : IBaseObjectFactory<IAudioFilter>
    {
        public IAudioFilter Create(ICore core, IntPtr pointer, uint id)
        {
            return new AudioFilter(core, pointer, id);
        }
    }
}