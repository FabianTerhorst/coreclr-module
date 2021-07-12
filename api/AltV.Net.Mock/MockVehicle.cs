using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockVehicle: Vehicle
    {   
        public MockVehicle(IServer server, IntPtr nativePointer, ushort id): base(server, nativePointer, id)
        {
        }
    }
}