using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class AudioAttachedOutputFactory : IBaseObjectFactory<IAudioAttachedOutput>
    {
        public IAudioAttachedOutput Create(ICore core, IntPtr pointer, uint id)
        {
            return new AudioAttachedOutput(core, pointer, id);
        }
    }
}