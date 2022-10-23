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

        public IntPtr VehicleNativePointer { get; }
        public override IntPtr NativePointer => VehicleNativePointer;

        public Vehicle(ICore core, IntPtr vehiclePointer, ushort id) : base(core, GetEntityPointer(core, vehiclePointer), id, BaseObjectType.Vehicle)
        {
            VehicleNativePointer = vehiclePointer;
        }

        public ushort Gear
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Client.Vehicle_GetGear(VehicleNativePointer);
                }
            }
        }

        public byte IndicatorLights
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Client.Vehicle_GetIndicatorLights(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Client.Vehicle_SetIndicatorLights(VehicleNativePointer, value);
                }
            }
        }

        public ushort MaxGear
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
                    return Core.Library.Client.Vehicle_GetRPM(VehicleNativePointer);
                }
            }
        }

        public float OilLevel
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
                    return Core.Library.Client.Vehicle_GetSeatCount(VehicleNativePointer);
                }
            }
        }

        public float WheelSpeed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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

        public Handling GetHandling()
        {
            return new Handling(Core, VehicleNativePointer);
        }

        public uint GetWheelSurfaceMaterial(byte wheel)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.Vehicle_GetWheelSurfaceMaterial(VehicleNativePointer, wheel);
            }
        }
    }
}