using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Refs
{
    public readonly struct AsyncVehicleRef : IDisposable
    {
        private readonly IVehicle vehicle;

        public bool Exists => vehicle != null;

        public AsyncVehicleRef(IVehicle vehicle)
        {
            lock (vehicle)
            {
                if (vehicle.Exists)
                {
                    this.vehicle = vehicle.AddRef() ? vehicle : null;
                    Alt.Module.CountUpRefForCurrentThread(vehicle);
                }
                else
                {
                    this.vehicle = null;
                }
            }
        }

        public void Dispose()
        {
            if (vehicle == null) return;
            lock (vehicle)
            {
                if (vehicle.Exists)
                {
                    vehicle.RemoveRef();
                }
            }

            Alt.Module.CountDownRefForCurrentThread(vehicle);
        }
    }
}