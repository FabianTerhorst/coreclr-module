using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockCheckpoint : MockColShape, ICheckpoint
    {
        public MockCheckpoint(ICore core, IntPtr nativePointer) : base(core, nativePointer)
        {
        }



        public IntPtr CheckpointNativePointer { get; }
        public byte CheckpointType { get; set; }
        public float Height { get; set; }
        public float Radius { get; set; }
        public Rgba Color { get; set; }

        public Position NextPosition { get; set; }
    }
}