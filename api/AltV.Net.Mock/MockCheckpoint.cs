using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockCheckpoint : MockColShape, ICheckpoint
    {
        public MockCheckpoint(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, id)
        {
        }



        public IntPtr CheckpointNativePointer { get; }
        public byte CheckpointType { get; set; }
        public float Height { get; set; }
        public float Radius { get; set; }
        public Rgba Color { get; set; }

        public Position NextPosition { get; set; }
        public uint StreamingDistance { get; }
        public bool Visible { get; set; }
    }
}