using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using AltV.Net.Elements.Args;
using AltV.Net.Exceptions;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public abstract class BaseObject : IBaseObject, IInternalBaseObject
    {
        public IntPtr BaseObjectNativePointer { get; }
        public virtual IntPtr NativePointer => BaseObjectNativePointer;
        
        private readonly ConcurrentDictionary<string, object> data = new ConcurrentDictionary<string, object>();

        public ICore Core;
        
        [Obsolete("Use Core instead")]
        public ICore Server
        {
            get
            {
                Alt.LogWarning("baseObject.Server is deprecated, use baseObject.Core instead");
                return Core;
            }
        }

        private bool exists;

        public bool Exists
        {
            get
            {
                if (exists)
                {
                    return true;
                }

                return refCount != 0;
            }
            set => exists = value;
        }

        private ulong refCount = 0;

        public BaseObjectType Type { get; }

        public void GetMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Core, Core.Library.Shared.BaseObject_GetMetaData(BaseObjectNativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void SetMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Core.Library.Shared.BaseObject_SetMetaData(BaseObjectNativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public bool HasMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Core.Library.Shared.BaseObject_HasMetaData(BaseObjectNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public void DeleteMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Core.Library.Shared.BaseObject_DeleteMetaData(BaseObjectNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        protected void InternalAddRef()
        {
            unsafe
            {
                Core.Library.Shared.BaseObject_AddRef(BaseObjectNativePointer);
                
            }
        }
        protected void InternalRemoveRef()
        {
            unsafe
            {
                Core.Library.Shared.BaseObject_RemoveRef(BaseObjectNativePointer);
            }
        }

        protected BaseObject(ICore core, IntPtr nativePointer, BaseObjectType type)
        {
            Core = core;
            BaseObjectNativePointer = nativePointer;
            Type = type;
            
            if (nativePointer == IntPtr.Zero)
            {
                throw new BaseObjectRemovedException(this);
            }
            
            exists = true;
        }

        public void SetMetaData(string key, object value)
        {
            CheckIfEntityExists();
            Alt.Core.CreateMValue(out var mValue, value);
            SetMetaData(key, in mValue);
            mValue.Dispose();
        }

        public bool GetMetaData(string key, out int result)
        {
            CheckIfEntityExists();
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
            CheckIfEntityExists();
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
            CheckIfEntityExists();
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
            CheckIfEntityExists();
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

        public virtual void CheckIfEntityExists()
        {
            CheckIfCallIsValid();
            if (Exists)
            {
                return;
            }

            throw new BaseObjectRemovedException(this);
        }

        [Conditional("DEBUG")]
        public void CheckIfCallIsValid([CallerMemberName] string callerName = "")
        {
            if (Alt.CoreImpl.IsMainThread()) return;
            if (Monitor.IsEntered(this)) return;
            if (Alt.CoreImpl.HasRefForCurrentThread(this)) return;
            throw new IllegalThreadException(this, callerName);
        }

        public override int GetHashCode()
        {
            return NativePointer.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is IBaseObject baseObject)) return false;
            if (baseObject.Type != Type) return false;
            if (baseObject.NativePointer != NativePointer) return false;
            return true;
        }

        public virtual void OnRemove()
        {
        }

        /// <summary>
        /// Increases the reference count, only works when entity didn't got deleted yet
        /// </summary>
        public bool AddRef()
        {
            lock (this)
            {
                if (!Exists) return false;
                InternalAddRef();
                ++refCount;
            }
            return true;
        }

        /// <summary>
        /// Reduces the reference count, also works when entity got deleted, but a reference still exists
        /// </summary>
        public bool RemoveRef()
        {
            lock (this)
            {
                if (refCount == 0) return false;
                --refCount;
                InternalRemoveRef();
            }
            return true;
        }
    }
}