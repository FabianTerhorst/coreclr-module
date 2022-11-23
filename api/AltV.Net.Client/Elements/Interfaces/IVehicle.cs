using System.Numerics;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IVehicle : ISharedVehicle, IEntity
    {
        ushort Gear { get; }
        byte IndicatorLights { get; set; }
        ushort MaxGear { get; set; }
        float Rpm { get; }
        float OilLevel { get; set; }
        float EngineTemperature { get; set; }
        float FuelLevel { get; set; }
        byte SeatCount { get; }
        float WheelSpeed { get; }
        Vector3 SpeedVector { get; }
        bool EngineLight { get; set; }
        bool AbsLight { get; set; }
        bool PetrolLight { get; set; }
        bool OilLight { get; set; }
        bool BatteryLight { get; set; }
        void ResetDashboardLights();
        
        
        Handling GetHandling();

        uint GetWheelSurfaceMaterial(byte wheel);
    }
}