using System.Numerics;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Interfaces;

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

        public Vehicle(ICore core, IntPtr vehiclePointer, ushort id) : base(core, GetEntityPointer(core, vehiclePointer), id)
        {
            VehicleNativePointer = vehiclePointer;
        }

        public ushort Gear
        {
            get
            {
                unsafe
                {
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
                    return Core.Library.Client.Vehicle_GetIndicatorLights(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
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
                    return Core.Library.Client.Vehicle_GetMaxGear(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Core.Library.Client.Vehicle_SetMaxGear(VehicleNativePointer, value);
                }
            }
        }

        public float RPM
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.Vehicle_GetRPM(VehicleNativePointer);
                }
            }
        }

        public byte SeatCount
        {
            get
            {
                unsafe
                {
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
                    var position = Vector3.Zero;
                    Core.Library.Client.Vehicle_GetSpeedVector(VehicleNativePointer, &position);
                    return position;
                }
            }
        }

        public byte WheelsCount
        {
            get
            {
                unsafe
                {
                    return Core.Library.Shared.Vehicle_GetWheelsCount(VehicleNativePointer);
                }
            }
        }

        public Handling GetHandling()
        {
            return new Handling(Core, VehicleNativePointer);
        }
    }
}