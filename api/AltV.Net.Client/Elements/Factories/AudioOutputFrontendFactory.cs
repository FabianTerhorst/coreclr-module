using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class AudioOutputFrontendFactory : IBaseObjectFactory<IAudioOutputFrontend>
    {
        public IAudioOutputFrontend Create(ICore core, IntPtr pointer, uint id)
        {
            return new AudioOutputFrontend(core, pointer, id);
        }
    }
}