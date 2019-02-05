using System;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Vehicle : Entity, IVehicle
    {
        public IPlayer Driver
        {
            get
            {
                if (!Exists) return null;
                var entityPointer = AltVNative.Vehicle.Vehicle_GetDriver(NativePointer);
                if (entityPointer == IntPtr.Zero) return null;
                if (Alt.Module.EntityPool.GetOrCreate(entityPointer, out var entity) && entity is IPlayer player)
                {
                    return player;
                }

                return null;
            }
        }
        
        public byte PrimaryColor
        {
            get => !Exists ? byte.MinValue : AltVNative.Vehicle.Vehicle_GetPrimaryColor(NativePointer);
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetPrimaryColor(NativePointer, value);
            }
        }

        public Vehicle(IntPtr nativePointer) : base(nativePointer, EntityType.Vehicle)
        {
        }
    }
}