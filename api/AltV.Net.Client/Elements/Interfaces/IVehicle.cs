using System.Numerics;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IVehicle : ISharedVehicle, IEntity
    {
        ushort Gear { get; set; }
        byte IndicatorLights { get; set; }
        ushort MaxGear { get; set; }
        float Rpm { get; set; }
        float OilLevel { get; set; }
        float EngineTemperature { get; set; }
        float FuelLevel { get; set; }
        byte SeatCount { get; }
        byte OccupiedSeatsCount { get; }
        float WheelSpeed { get; }
        Vector3 SpeedVector { get; }
        bool EngineLight { get; set; }
        bool AbsLight { get; set; }
        bool PetrolLight { get; set; }
        bool OilLight { get; set; }
        bool BatteryLight { get; set; }
        void ResetDashboardLights();

        bool IsTaxiLightOn { get; set; }

        Handling GetHandling();

        uint GetWheelSurfaceMaterial(byte wheel);
        float GetWheelCamber(byte wheel);
        void SetWheelCamber(byte wheel, float value);
        float GetWheelTrackWidth(byte wheel);
        void SetWheelTrackWidth(byte wheel, float value);
        float GetWheelHeight(byte wheel);
        void SetWheelHeight(byte wheel, float value);
        float GetWheelTyreRadius(byte wheel);
        void SetWheelTyreRadius(byte wheel, float value);
        float GetWheelRimRadius(byte wheel);
        void SetWheelRimRadius(byte wheel, float value);
        float GetWheelTyreWidth(byte wheel);
        void SetWheelTyreWidth(byte wheel, float value);
    }
}