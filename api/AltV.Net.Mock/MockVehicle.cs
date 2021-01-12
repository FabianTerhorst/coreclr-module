using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockVehicle: Vehicle
    {   
        public MockVehicle(IntPtr nativePointer, ushort id): base(nativePointer, id)
        {
        }
    }
}