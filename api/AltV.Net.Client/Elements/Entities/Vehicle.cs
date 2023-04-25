using System.Numerics;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities
{
    public class Vehicle : Entity, IVehicle
    {
        private static IntPtr GetEntityPointer(ICore core, IntPtr vehicleNativePointer)
        {
            unsafe
            {
                return core.Library.Shared.Vehicle_GetEntity(vehicleNativePointer);
            }
        }

        public IntPtr VehicleNativePointer { get; private set; }
        public override IntPtr NativePointer => VehicleNativePointer;

        public Vehicle(ICore core, IntPtr vehiclePointer, uint id) : base(core, GetEntityPointer(core, vehiclePointer), id, BaseObjectType.Vehicle)
        {
            VehicleNativePointer = vehiclePointer;
        }

        public ushort Gear
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetCurrentGear(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Vehicle_SetCurrentGear(VehicleNativePointer, value);
                }
            }
        }

        public byte IndicatorLights
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetLightsIndicator (VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Vehicle_SetLightsIndicator(VehicleNativePointer, value);
                }
            }
        }

        public ushort MaxGear
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetMaxGear(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Vehicle_SetMaxGear(VehicleNativePointer, value);
                }
            }
        }

        public float Rpm
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetCurrentRPM(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Vehicle_SetCurrentRPM(VehicleNativePointer, value);
                }
            }
        }

        public float OilLevel
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetOilLevel(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Vehicle_SetOilLevel(VehicleNativePointer, value);
                }
            }
        }

        public float EngineTemperature
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetEngineTemperature(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Vehicle_SetEngineTemperature(VehicleNativePointer, value);
                }
            }
        }

        public float FuelLevel
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetFuelLevel(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Vehicle_SetFuelLevel(VehicleNativePointer, value);
                }
            }
        }

        public byte SeatCount
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetSeatCount(VehicleNativePointer);
                }
            }
        }

        public byte OccupiedSeatsCount
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetOccupiedSeatsCount(VehicleNativePointer);
                }
            }
        }

        public float WheelSpeed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetWheelSpeed(VehicleNativePointer);
                }
            }
        }

        public Vector3 SpeedVector
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var position = Vector3.Zero;
                    Core.Library.Client.Vehicle_GetSpeedVector(VehicleNativePointer, &position);
                    return position;
                }
            }
        }

        public bool EngineLight
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetEngineLightState(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Vehicle_SetEngineLightState(VehicleNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public bool AbsLight
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetAbsLightState(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Vehicle_SetAbsLightState(VehicleNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public bool PetrolLight
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetPetrolLightState(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Vehicle_SetPetrolLightState(VehicleNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public bool OilLight
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetOilLightState(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Vehicle_SetOilLightState(VehicleNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public bool BatteryLight
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_GetBatteryLightState(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Vehicle_SetBatteryLightState(VehicleNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public byte WheelsCount
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Shared.Vehicle_GetWheelsCount(VehicleNativePointer);
                }
            }
        }

        public int PetrolTankHealth
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Shared.Vehicle_GetPetrolTankHealth(VehicleNativePointer);
                }
            }
        }

        public void ResetDashboardLights()
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.Vehicle_ResetDashboardLights(VehicleNativePointer);
            }
        }

        public bool IsTaxiLightOn
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Client.Vehicle_IsTaxiLightOn(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Vehicle_ToggleTaxiLight(VehicleNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public Handling GetHandling()
        {
            return new Handling(Core, VehicleNativePointer);
        }

        public uint GetWheelSurfaceMaterial(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Client.Vehicle_GetWheelSurfaceMaterial(VehicleNativePointer, wheel);
            }
        }

        public float GetWheelCamber(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Client.Vehicle_GetWheelCamber(VehicleNativePointer, wheel);
            }
        }

        public void SetWheelCamber(byte wheel, float value)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                Core.Library.Client.Vehicle_SetWheelCamber(VehicleNativePointer, wheel, value);
            }
        }

        public float GetWheelTrackWidth(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Client.Vehicle_GetWheelTrackWidth(VehicleNativePointer, wheel);
            }
        }

        public void SetWheelTrackWidth(byte wheel, float value)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                Core.Library.Client.Vehicle_SetWheelTrackWidth(VehicleNativePointer, wheel, value);
            }
        }

        public float GetWheelHeight(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Client.Vehicle_GetWheelHeight(VehicleNativePointer, wheel);
            }
        }

        public void SetWheelHeight(byte wheel, float value)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                Core.Library.Client.Vehicle_SetWheelHeight(VehicleNativePointer, wheel, value);
            }
        }

        public float GetWheelTyreRadius(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Client.Vehicle_GetWheelTyreRadius(VehicleNativePointer, wheel);
            }
        }

        public void SetWheelTyreRadius(byte wheel, float value)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                Core.Library.Client.Vehicle_SetWheelTyreRadius(VehicleNativePointer, wheel, value);
            }
        }

        public float GetWheelRimRadius(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Client.Vehicle_GetWheelRimRadius(VehicleNativePointer, wheel);
            }
        }

        public void SetWheelRimRadius(byte wheel, float value)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                Core.Library.Client.Vehicle_SetWheelRimRadius(VehicleNativePointer, wheel, value);
            }
        }

        public float GetWheelTyreWidth(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Client.Vehicle_GetWheelTyreWidth(VehicleNativePointer, wheel);
            }
        }

        public void SetWheelTyreWidth(byte wheel, float value)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                Core.Library.Client.Vehicle_SetWheelTyreWidth(VehicleNativePointer, wheel, value);
            }
        }

        public override void SetCached(IntPtr cachedVehicle)
        {
            this.VehicleNativePointer = cachedVehicle;
            base.SetCached(GetEntityPointer(Core, cachedVehicle));
        }
    }
}