using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using AltV.Net.Client.CApi.Memory;
using AltV.Net.Client.Elements.Args;
using AltV.Net.Client.Elements.Enums;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Entities
{
    public class BaseObject : IBaseObject
    {
        protected ICore Core { get; }
        public IntPtr BaseObjectNativePointer { get; }

        public BaseObject(ICore core, IntPtr baseObjectPointer)
        {
            Core = core;
            BaseObjectNativePointer = baseObjectPointer;
        }

        public BaseObjectType Type
        {
            get
            {
                unsafe
                {
                    return (BaseObjectType) Core.Library.BaseObject_GetType(BaseObjectNativePointer);
                }
            }
        }
        
        #region Data
        private Dictionary<string, object?> _data = new();
        
        public void SetData<T>(string key, T value)
        {
            this._data[key] = value;
        }
        
        public bool HasData(string key)
        {
            return this._data.ContainsKey(key);
        }
        
        public void DeleteData(string key)
        {
            this._data.Remove(key);
        }
        
        public bool GetData<T>(string key, out T? value)
        {
            value = default;
            if (!this._data.TryGetValue(key, out var obj)) return false;
            if (obj is not T convertedObj) return false;
            value = convertedObj;
            return true;
        }
        #endregion
        
        #region MetaData
        public void SetMetaData<T>(string key, T value)
        {
            unsafe
            {
                Core.CreateMValue(out var mValue, value);
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                Core.Library.BaseObject_SetMetaData(this.BaseObjectNativePointer, stringPtr, mValue.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
                mValue.Dispose();
            }
        }
        
        public bool HasMetaData(string key)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var result = Core.Library.BaseObject_HasMetaData(this.BaseObjectNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }
        
        public void DeleteMetaData(string key)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                Core.Library.BaseObject_DeleteMetaData(this.BaseObjectNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }
        
        private MValueConst GetMetaData(string key)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var mValue = new MValueConst(Core.Library.BaseObject_GetMetaData(this.BaseObjectNativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
                return mValue;
            }
        }
        
        public bool GetMetaData<T>(string key, out T? value)
        {
            using var mValue = GetMetaData(key);
            var obj = mValue.ToObject();
            if (obj is not T convertedObj)
            {
                value = default;
                return false;
            }

            value = convertedObj;
            return true;
        }

        public bool GetMetaData(string key, out int value)
        {
            using var mValue = GetMetaData(key);
            value = default;
            if (mValue.type != MValueConst.Type.Int) return false;

            value = (int) mValue.GetInt();
            return true;
        }

        public bool GetMetaData(string key, out uint value)
        {
            using var mValue = GetMetaData(key);
            value = default;
            if (mValue.type != MValueConst.Type.Uint) return false;

            value = (uint) mValue.GetInt();
            return true;
        }

        public bool GetMetaData(string key, out float value)
        {
            using var mValue = GetMetaData(key);
            value = default;
            if (mValue.type != MValueConst.Type.Double) return false;

            value = (float) mValue.GetDouble();
            return true;
        }
        #endregion
    }
}