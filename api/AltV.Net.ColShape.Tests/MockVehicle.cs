using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.ColShape.Tests
{
    public class MockVehicle : Vehicle
    {
        public MockVehicle(IServer server) : base(server, IntPtr.Zero, 0)
        {
            
        }
    }
}