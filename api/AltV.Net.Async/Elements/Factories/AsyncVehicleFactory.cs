using System;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Factories
{
    public class AsyncVehicleFactory : IEntityFactory<IVehicle>
    {
        public IVehicle Create(ICore core, IntPtr entityPointer, uint id)
        {
            return new AsyncVehicle(core, entityPointer, id);
        }
    }
}