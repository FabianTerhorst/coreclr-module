using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockCheckpoint : MockColShape, ICheckpoint
    {
        public MockCheckpoint(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        
        
        public byte CheckpointType { get; set; }
        public float Height { get; set; }
        public float Radius { get; set; }
        public Rgba Color { get; set; }
    }
}