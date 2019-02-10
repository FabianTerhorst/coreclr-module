using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockCheckpoint : MockEntity, ICheckpoint
    {
        public MockCheckpoint(IntPtr nativePointer, ushort id) : base(nativePointer, EntityType.Checkpoint, id)
        {
        }

        public bool IsGlobal { get; set; }
        public byte CheckpointType { get; set; }
        public float Height { get; set; }
        public float Radius { get; set; }
        public Rgba Color { get; set; }

        public void Init()
        {
        }
    }
}