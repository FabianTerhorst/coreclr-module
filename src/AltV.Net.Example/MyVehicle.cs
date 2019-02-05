using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    public class MyVehicle : Vehicle
    {
        public int MyData { get; set; }

        public MyVehicle(IntPtr nativePointer) : base(nativePointer)
        {
            MyData = 6;
        }
    }
}