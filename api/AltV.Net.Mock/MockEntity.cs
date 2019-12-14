using System;
using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Mock
{
    public abstract class MockEntity : IEntity
    {
        public IntPtr NativePointer { get; }
        public IPlayer NetworkOwner { get; }
        public bool Exists { get; }
        public ushort Id { get; }
        public BaseObjectType Type { get; }
        public Position Position { get; set; }
        public Rotation Rotation { get; set; }
        public int Dimension { get; set; }
        public uint Model { get; set; }

        private readonly Dictionary<string, object> data = new Dictionary<string, object>();

        private readonly Dictionary<string, MValueConst> metaData = new Dictionary<string, MValueConst>();

        private readonly Dictionary<string, MValueConst> syncedMetaData = new Dictionary<string, MValueConst>();

        public MockEntity(IntPtr nativePointer, BaseObjectType baseObjectType, ushort id)
        {
            NativePointer = nativePointer;
            Type = baseObjectType;
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
            Alt.Server.CreateMValue(out var mValue, value);
            metaData[key] = mValue;
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
            Alt.Server.CreateMValue(out var mValue, value);
            syncedMetaData[key] = mValue;
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

        public void SetMetaData(string key, in MValueConst value)
        {
            throw new NotImplementedException();
        }

        public void GetMetaData(string key, out MValueConst value)
        {
            throw new NotImplementedException();
        }

        public void SetSyncedMetaData(string key, in MValueConst value)
        {
            throw new NotImplementedException();
        }

        public void GetSyncedMetaData(string key, out MValueConst value)
        {
            throw new NotImplementedException();
        }

        public void SetStreamSyncedMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool GetStreamSyncedMetaData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }

        public void SetStreamSyncedMetaData(string key, in MValueConst value)
        {
            throw new NotImplementedException();
        }

        public void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            throw new NotImplementedException();
        }

        public abstract void Remove();

        public void CheckIfEntityExists()
        {
            if (Exists)
            {
                return;
            }

            throw new EntityRemovedException(this);
        }

        public void OnRemove()
        {
        }
        
        public bool AddRef()
        {
            throw new NotImplementedException();
        }

        public bool RemoveRef()
        {
            throw new NotImplementedException();
        }
    }
}