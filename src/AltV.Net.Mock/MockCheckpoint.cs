using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockCheckpoint : MockWorldObject, ICheckpoint
    {
        public MockCheckpoint(IntPtr nativePointer) : base(nativePointer, BaseObjectType.Checkpoint)
        {
        }

        public bool IsGlobal { get; set; }
        public byte CheckpointType { get; set; }
        public float Height { get; set; }
        public float Radius { get; set; }
        public Rgba Color { get; set; }
        public bool IsPlayerIn(IPlayer player)
        {
            throw new NotImplementedException();
        }

        bool ICheckpoint.IsVehicleIn(IVehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public IPlayer Target { get; }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}