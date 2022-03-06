using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockVehicle: Vehicle
    {   
        public MockVehicle(ICore core, IntPtr nativePointer, ushort id): base(core, nativePointer, id)
        {
        }
    }
}