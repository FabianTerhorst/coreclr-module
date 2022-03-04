using System.Numerics;
using AltV.Net.Client.Elements.Data;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IVehicle : IEntity
    {
        public IntPtr VehicleNativePointer { get; }
        ushort Gear { get; }
        byte IndicatorLights { get; set; }
        ushort MaxGear { get; set; }
        float RPM { get; }
        byte SeatCount { get; }
        float WheelSpeed { get; }
        Vector3 SpeedVector { get; }
        byte WheelsCount { get; }
        // todo
        Handling GetHandling();
    }
}