using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Mock
{
    public class MockBlip : IBlip
    {
        public IntPtr NativePointer { get; }
        public bool Exists { get; }
        public ushort Id { get; }
        public EntityType Type { get; }
        public Position Position { get; set; }
        public Rotation Rotation { get; set; }
        public ushort Dimension { get; set; }
        
        public MockBlip()
        {
            Type = EntityType.Blip;
            Id = MockEntityId.Get();
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
        public bool IsAttached { get; }
        public IEntity AttachedTo { get; }
        public byte BlipType { get; }
        public ushort Sprite { get; set; }
        public byte Color { get; set; }
        public bool Route { get; set; }
        public byte RouteColor { get; set; }
    }
}