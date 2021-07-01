using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    public class MyVehicle : Vehicle, IMyVehicle
    {
        public int MyData { get; set; }

        // This constructor is used for creation via constructor
        public MyVehicle(uint model, Position position, Rotation rotation) : base(Alt.Server, model, position, rotation)
        {
            MyData = 7;
        }

        // This constructor is used for creation via entity factory
        public MyVehicle(IServer server, IntPtr nativePointer, ushort id) : base(server, nativePointer, id)
        {
            MyData = 6;
        }
    }
}