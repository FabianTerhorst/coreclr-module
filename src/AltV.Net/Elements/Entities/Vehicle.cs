using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    internal class Vehicle : Entity, IVehicle
    {
        public byte PrimaryColor
        {
            get
            {
                CheckExistence();
                return Alt.Vehicle.Vehicle_GetPrimaryColor(NativePointer);
            }
            set
            {
                CheckExistence();
                Alt.Vehicle.Vehicle_SetPrimaryColor(NativePointer, value);
            }
        }
    }
}