using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class AudioOutputWorldFactory : IBaseObjectFactory<IAudioOutputWorld>
    {
        public IAudioOutputWorld Create(ICore core, IntPtr pointer, uint id)
        {
            return new AudioOutputWorld(core, pointer, id);
        }
    }
}