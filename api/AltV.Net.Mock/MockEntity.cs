using System;
using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Mock
{
    public abstract class MockEntity : Entity
    {
        public IntPtr NativePointer { get; }
        public bool Exists { get; }
        public uint Id { get; }
        public BaseObjectType Type { get; }
        public override uint Model { get; set; }

        private readonly Dictionary<string, object> data = new Dictionary<string, object>();

        private readonly Dictionary<string, MValueConst> metaData = new Dictionary<string, MValueConst>();

        private readonly Dictionary<string, MValueConst> syncedMetaData = new Dictionary<string, MValueConst>();

        public MockEntity(ICore core, IntPtr nativePointer, BaseObjectType baseObjectType, uint id):base(core, nativePointer, baseObjectType, id)
        {
            NativePointer = nativePointer;
            Type = baseObjectType;
            Id = id;
            Exists = true;
        }

        public void ResetNetworkOwner()
        {
            throw new NotImplementedException();
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
            Alt.Core.CreateMValue(out var mValue, value);
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
            Alt.Core.CreateMValue(out var mValue, value);
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

        public bool HasData(string key)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(string key)
        {
            throw new NotImplementedException();
        }

        public void ClearData()
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

        public abstract void Destroy();

        public void CheckIfEntityExists()
        {
            if (Exists)
            {
                return;
            }

            throw new EntityRemovedException(this);
        }

        public void OnDestroy()
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

        public IEnumerable<string> GetAllDataKeys()
        {
            throw new NotImplementedException();
        }

        public bool GetSyncedMetaData(string key, out int value)
        {
            throw new NotImplementedException();
        }

        public bool GetSyncedMetaData(string key, out uint value)
        {
            throw new NotImplementedException();
        }

        public bool GetSyncedMetaData(string key, out float value)
        {
            throw new NotImplementedException();
        }

        public bool GetStreamSyncedMetaData(string key, out int value)
        {
            throw new NotImplementedException();
        }

        public bool GetStreamSyncedMetaData(string key, out uint value)
        {
            throw new NotImplementedException();
        }

        public bool GetStreamSyncedMetaData(string key, out float value)
        {
            throw new NotImplementedException();
        }
    }
}