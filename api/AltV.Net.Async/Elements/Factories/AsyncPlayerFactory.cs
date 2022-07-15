using System;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Factories
{
    public class AsyncPlayerFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(ICore core, IntPtr entityPointer, ushort id)
        {
            return new AsyncPlayer(core, entityPointer, id);
        }
    }
}