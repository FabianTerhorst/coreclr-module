using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Mock
{
    public class MockCheckpoint : ICheckpoint
    {
        public IntPtr NativePointer { get; }
        public bool Exists { get; }
        public ushort Id { get; }
        public EntityType Type { get; }
        public Position Position { get; set; }
        public Rotation Rotation { get; set; }
        public ushort Dimension { get; set; }
        
        public MockCheckpoint(IntPtr nativePointer, ushort id)
        {
            NativePointer = nativePointer;
            Type = EntityType.Checkpoint;
            Id = id;
            Exists = true;
        }
        
        public void SetPosition(float x, float y, float z)
        {
            
        }

        public void SetRotation(float roll, float pitch, float yaw)
        {
            
        }

        public void SetMetaData(string key, MValue value)
        {
            
        }

        public MValue GetMetaData(string key)
        {
            return MValue.Nil;
        }

        public void SetData(string key, object value)
        {
            
        }

        public bool GetData<T>(string key, out T result)
        {
            result = default;
            return false;
        }

        public bool Remove()
        {
            return false;
        }

        public bool IsGlobal { get; }
        public byte CheckpointType { get; }
        public float Height { get; }
        public float Radius { get; }
        public Rgba Color { get; }
    }
}