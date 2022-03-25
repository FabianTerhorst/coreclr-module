using System;
using System.Diagnostics;
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
        }
        
        [Conditional("DEBUG")]
        public void DebugCountUp()
        {
            Alt.CoreImpl.CountUpRefForCurrentThread(vehicle);
        }

        [Conditional("DEBUG")]
        public void DebugCountDown()
        {
            Alt.CoreImpl.CountDownRefForCurrentThread(vehicle);
        }

        public void Dispose()
        {
            vehicle?.RemoveRef();
        }
    }
}