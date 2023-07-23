using System;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Factories
{
    public class AsyncVoiceChannelFactory : IBaseObjectFactory<IVoiceChannel>
    {
        public IVoiceChannel Create(ICore core, IntPtr baseObjectPointer, uint id)
        {
            return new AsyncVoiceChannel(core, baseObjectPointer, id);
        }
    }
}