using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Refs
{
    public readonly struct VehicleRef : IDisposable
    {
        private readonly IVehicle vehicle;

        public bool Exists => vehicle != null;

        public VehicleRef(IVehicle vehicle)
        {
            this.vehicle = vehicle.AddRef() ? vehicle : null;
            Alt.Module.CountUpRefForCurrentThread(vehicle);
        }

        public void Dispose()
        {
            vehicle?.RemoveRef();
            Alt.Module.CountDownRefForCurrentThread(vehicle);
        }
    }
}