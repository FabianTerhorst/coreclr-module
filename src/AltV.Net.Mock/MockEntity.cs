using System;
using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Mock
{
    public class MockEntity : IEntity
    {
        public IntPtr NativePointer { get; }
        public bool Exists { get; }
        public ushort Id { get; }
        public EntityType Type { get; }
        public Position Position { get; set; }
        public Rotation Rotation { get; set; }
        public ushort Dimension { get; set; }

        private readonly Dictionary<string, object> data = new Dictionary<string, object>();

        private readonly Dictionary<string, MValue> metaData = new Dictionary<string, MValue>();

        private readonly Dictionary<string, MValue> syncedMetaData = new Dictionary<string, MValue>();

        public MockEntity(IntPtr nativePointer, EntityType entityType, ushort id)
        {
            NativePointer = nativePointer;
            Type = entityType;
            Id = id;
            Exists = true;
        }

        public void SetPosition(float x, float y, float z)
        {
            Position = new Position(x, y, z);
        }

        public void SetRotation(float roll, float pitch, float yaw)
        {
            Rotation = new Rotation(roll, pitch, yaw);
        }

        public void SetMetaData(string key, object value)
        {
            metaData[key] = MValue.CreateFromObject(value) ?? MValue.Nil;
        }

        public bool GetMetaData<T>(string key, out T result)
        {
            if (!metaData.TryGetValue(key, out var value))
            {
                result = default;
                return false;
            }

            if (!(value.ToObject() is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        public void SetData(string key, object value)
        {
            data[key] = value;
        }

        public bool GetData<T>(string key, out T result)
        {
            if (!data.TryGetValue(key, out var value))
            {
                result = default;
                return false;
            }

            if (!(value is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        public void SetSyncedMetaData(string key, object value)
        {
            syncedMetaData[key] = MValue.CreateFromObject(value) ?? MValue.Nil;
        }

        public bool GetSyncedMetaData<T>(string key, out T result)
        {
            if (!syncedMetaData.TryGetValue(key, out var value))
            {
                result = default;
                return false;
            }

            if (!(value.ToObject() is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        public void Remove()
        {
            Alt.Server.RemoveEntity(this);
        }
    }
}