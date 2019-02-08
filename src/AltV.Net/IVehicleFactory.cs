using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public interface IVehicleFactory
    {
        IVehicle Create(IntPtr vehiclePointer);
    }
}