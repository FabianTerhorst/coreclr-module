using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Shared.Elements.Entities
{
    public abstract class SharedBaseObject : ISharedBaseObject, IInternalBaseObject
    {
        public abstract IntPtr BaseObjectNativePointer { get; protected set; }
        public abstract ISharedCore Core { get; }
        public virtual IntPtr NativePointer => BaseObjectNativePointer;

        ~SharedBaseObject()
        {
            unsafe
            {
                if (Cached) Core.Library.Shared.BaseObject_DestructCache(BaseObjectNativePointer);
            }
        }
        
        public abstract BaseObjectType Type { get; }
        
        private readonly ConcurrentDictionary<string, object> data = new ConcurrentDictionary<string, object>();
        
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

        
        public IEnumerable<string> GetAllDataKeys()
        {
            return data.Keys.ToList(); // make copy!
        }

        public bool HasData(string key)
        {
            return data.ContainsKey(key);
        }

        public void DeleteData(string key)
        {
            data.TryRemove(key, out _);
        }

        public void ClearData()
        {
            data.Clear();
        }
        public void OnRemove()
        {
        }

        public void GetMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Core, Core.Library.Shared.BaseObject_GetMetaData(BaseObjectNativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void SetMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                Core.Library.Shared.BaseObject_SetMetaData(BaseObjectNativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public bool HasMetaData(string key)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var result = Core.Library.Shared.BaseObject_HasMetaData(BaseObjectNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public void DeleteMetaData(string key)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                Core.Library.Shared.BaseObject_DeleteMetaData(BaseObjectNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void SetMetaData(string key, object value)
        {
            CheckIfEntityExists();
            Core.CreateMValue(out var mValue, value);
            SetMetaData(key, in mValue);
            mValue.Dispose();
        }

        public bool GetMetaData(string key, out int result)
        {
            CheckIfEntityExistsOrCached();
            GetMetaData(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Int)
                {
                    result = default;
                    return false;
                }

                result = (int) mValue.GetInt();
            }

            return true;
        }

        public bool GetMetaData(string key, out uint result)
        {
            CheckIfEntityExistsOrCached();
            GetMetaData(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Uint)
                {
                    result = default;
                    return false;
                }

                result = (uint) mValue.GetUint();
            }

            return true;
        }

        public bool GetMetaData(string key, out float result)
        {
            CheckIfEntityExistsOrCached();
            GetMetaData(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Double)
                {
                    result = default;
                    return false;
                }

                result = (float) mValue.GetDouble();
            }

            return true;
        }

        public bool GetMetaData<T>(string key, out T result)
        {
            CheckIfEntityExistsOrCached();
            GetMetaData(key, out MValueConst mValue);
            using (mValue)
            {
                if (!(mValue.ToObject() is T cast))
                {
                    result = default;
                    return false;
                }

                result = cast;
            }

            return true;
        }


        
        public virtual void CheckIfEntityExists() {}
        public void CheckIfEntityExistsOrCached()
        {
            if (Cached) return;
            this.CheckIfEntityExists();
        }
        
        [Conditional("DEBUG")]
        public virtual void CheckIfCallIsValid()
        {
        }

        public bool Exists { get; set; }
        public bool Cached { get; internal set; }


        public override bool Equals(object obj)
        {
            if (!(obj is ISharedBaseObject baseObject)) return false;
            if (baseObject.Type != Type) return false;
            if (baseObject.NativePointer != NativePointer) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return NativePointer.GetHashCode();
        }

        public void Remove()
        {
            if (!Exists) return;
            unsafe
            {
                Core.Library.Shared.Core_DestroyBaseObject(Core.NativePointer, BaseObjectNativePointer);
            }
        }

        public virtual void SetCached(IntPtr cachedBaseObject)
        {
            this.BaseObjectNativePointer = cachedBaseObject;
            this.Cached = true;
        }
    }
}