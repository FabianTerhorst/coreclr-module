using System.Numerics;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Entities
{
    public class Vehicle : Entity, IVehicle
    {
        private static IntPtr GetEntityPointer(ICore core, IntPtr vehicleNativePointer)
        {
            unsafe
            {
                return core.Library.Vehicle_GetEntity(vehicleNativePointer);
            }
        }
        
        public IntPtr VehicleNativePointer { get; }
        
        public Vehicle(ICore core, IntPtr vehiclePointer, ushort id) : base(core, GetEntityPointer(core, vehiclePointer), id)
        {
            VehicleNativePointer = vehiclePointer;
        }

        public uint Model
        {
            get {
                unsafe
                {
                    return Core.Library.Vehicle_GetModel(VehicleNativePointer);
                }
            }
        }
    }
}