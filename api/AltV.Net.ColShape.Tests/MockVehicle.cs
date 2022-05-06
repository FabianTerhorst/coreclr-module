using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.ColShape.Tests
{
    public class MockVehicle : Vehicle
    {
        public MockVehicle(ICore core) : base(core, IntPtr.Zero, 0)
        {
            
        }
    }
}