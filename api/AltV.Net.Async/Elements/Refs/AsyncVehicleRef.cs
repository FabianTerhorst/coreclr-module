using System;
using System.Diagnostics;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Refs
{
    public readonly struct AsyncVehicleRef : IDisposable
    {
        private readonly IVehicle vehicle;

        public bool Exists => vehicle != null;

        public AsyncVehicleRef(IVehicle vehicle)
        {
            if (vehicle == null)
            {
                this.vehicle = null;
            }
            else
            {
                lock (vehicle)
                {
                    this.vehicle = vehicle.AddRef() ? vehicle : null;
                }
            }
        }

        [Conditional("DEBUG")]
        public void DebugCountUp()
        {
            Alt.Module.CountUpRefForCurrentThread(vehicle);
        }

        [Conditional("DEBUG")]
        public void DebugCountDown()
        {
            Alt.Module.CountDownRefForCurrentThread(vehicle);
        }

        public void Dispose()
        {
            vehicle?.RemoveRef();
        }
    }
}