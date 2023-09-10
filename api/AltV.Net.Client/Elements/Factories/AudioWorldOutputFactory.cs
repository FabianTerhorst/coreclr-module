using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class AudioWorldOutputFactory : IBaseObjectFactory<IAudioWorldOutput>
    {
        public IAudioWorldOutput Create(ICore core, IntPtr pointer, uint id)
        {
            return new AudioWorldOutput(core, pointer, id);
        }
    }
}