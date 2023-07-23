using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class AudioFrontendOutputFactory : IBaseObjectFactory<IAudioFrontendOutput>
    {
        public IAudioFrontendOutput Create(ICore core, IntPtr pointer, uint id)
        {
            return new AudioFrontendOutput(core, pointer, id);
        }
    }
}