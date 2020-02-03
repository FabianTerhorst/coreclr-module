using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using AltV.Net.Elements.Args;
using AltV.Net.Exceptions;

namespace AltV.Net.Elements.Entities
{
    public abstract class BaseObject : IBaseObject, IInternalBaseObject
    {
        private readonly ConcurrentDictionary<string, object> data = new ConcurrentDictionary<string, object>();

        public IntPtr NativePointer { get; }
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

        public abstract void SetMetaData(string key, in MValueConst value);
        public abstract void GetMetaData(string key, out MValueConst value);
        public abstract bool HasMetaData(string key);
        public abstract void DeleteMetaData(string key);

        protected abstract void InternalAddRef();
        protected abstract void InternalRemoveRef();

        protected BaseObject(IntPtr nativePointer, BaseObjectType type)
        {
            if (nativePointer == IntPtr.Zero)
            {
                throw new BaseObjectRemovedException(this);
            }

            NativePointer = nativePointer;
            Type = type;
            exists = true;
        }

        public void SetMetaData(string key, object value)
        {
            CheckIfEntityExists();
            Alt.Server.CreateMValue(out var mValue, value);
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
            if (Alt.Module.IsMainThread()) return;
            if (Monitor.IsEntered(this)) return;
            if (Alt.Module.HasRefForCurrentThread(this)) return;
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
                ++refCount;
            }

            InternalAddRef();
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
            }

            InternalRemoveRef();
            return true;
        }
    }
}