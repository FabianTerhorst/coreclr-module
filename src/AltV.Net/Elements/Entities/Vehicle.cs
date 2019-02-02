using System;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    internal class Vehicle : Entity, IVehicle
    {
        public IPlayer Driver
        {
            get
            {
                if (!Exists) return null;
                var entityPointer = Alt.Vehicle.Vehicle_GetDriver(NativePointer);
                if (entityPointer == IntPtr.Zero) return null;
                if (EntityPool.Get(entityPointer, out var entity) && entity is IPlayer player)
                {
                    return player;
                }

                return null;
            }
        }
        
        public byte PrimaryColor
        {
            get => !Exists ? byte.MinValue : Alt.Vehicle.Vehicle_GetPrimaryColor(NativePointer);
            set
            {
                if (!Exists) return;
                Alt.Vehicle.Vehicle_SetPrimaryColor(NativePointer, value);
            }
        }

        internal Vehicle(IntPtr nativePointer, IEntityPool entityPool) : base(nativePointer, EntityType.Vehicle, entityPool)
        {
        }
    }
}