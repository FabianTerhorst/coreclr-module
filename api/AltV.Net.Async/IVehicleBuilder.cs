using System;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net.Async
{
    public interface IVehicleBuilder : IDisposable
    {
        IVehicleBuilder ModKit(byte value);
        IVehicleBuilder PrimaryColor(byte value);
        IVehicleBuilder PrimaryColorRgb(Rgba value);
        IVehicleBuilder SecondaryColor(byte value);
        IVehicleBuilder SecondaryColorRgb(Rgba value);
        IVehicleBuilder PearlColor(byte value);
        IVehicleBuilder WheelColor(byte value);
        IVehicleBuilder InteriorColor(byte value);
        IVehicleBuilder DashboardColor(byte value);
        IVehicleBuilder TireSmokeColor(Rgba value);
        IVehicleBuilder CustomTires(bool value);
        IVehicleBuilder SpecialDarkness(byte value);
        IVehicleBuilder NumberplateIndex(uint value);
        IVehicleBuilder NumberplateText(string value);
        IVehicleBuilder WindowTint(byte value);
        IVehicleBuilder DirtLevel(byte value);
        IVehicleBuilder NeonColor(Rgba value);
        IVehicleBuilder EngineOn(bool value);
        IVehicleBuilder HeadlightColor(byte value);
        IVehicleBuilder SirenActive(bool value);
        IVehicleBuilder LockState(VehicleLockState value);
        IVehicleBuilder RoofOpened(bool value);
        IVehicleBuilder State(string value);
        IVehicleBuilder EngineHealth(int value);
        IVehicleBuilder PetrolTankHealth(int value);
        IVehicleBuilder BodyHealth(uint value);
        IVehicleBuilder BodyAdditionalHealth(uint value);
        IVehicleBuilder HealthData(string value);
        IVehicleBuilder DamageData(string value);
        IVehicleBuilder Appearance(string value);
        IVehicleBuilder ScriptData(string value);

        Task<IVehicle> Build();
    }
}