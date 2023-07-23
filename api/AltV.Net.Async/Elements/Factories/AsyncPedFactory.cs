using System;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Factories
{
    public class AsyncPedFactory : IEntityFactory<IPed>
    {
        public IPed Create(ICore core, IntPtr baseObjectPointer, uint id)
        {
            return new AsyncPed(core, baseObjectPointer, id);
        }
    }
}