using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class AudioOutputFactory : IBaseObjectFactory<IAudioOutput>
    {
        public IAudioOutput Create(ICore core, IntPtr pointer, uint id)
        {
            return new AudioOutput(core, pointer, id);
        }
    }
}