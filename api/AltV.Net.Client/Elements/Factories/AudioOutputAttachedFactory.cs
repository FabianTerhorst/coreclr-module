using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class AudioOutputAttachedFactory : IBaseObjectFactory<IAudioOutputAttached>
    {
        public IAudioOutputAttached Create(ICore core, IntPtr pointer, uint id)
        {
            return new AudioOutputAttached(core, pointer, id);
        }
    }
}