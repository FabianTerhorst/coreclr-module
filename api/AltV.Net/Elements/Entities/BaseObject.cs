using System;
using System.Collections.Concurrent;
using AltV.Net.Elements.Args;

namespace AltV.Net.Elements.Entities
{
    public abstract class BaseObject : IBaseObject, IInternalBaseObject
    {
        private readonly ConcurrentDictionary<string, object> data = new ConcurrentDictionary<string, object>();

        public IntPtr NativePointer { get; }
        public bool Exists { get; set; }

        public BaseObjectType Type { get; }

        public abstract void SetMetaData(string key, ref MValue value);
        public abstract void GetMetaData(string key, ref MValue value);

        protected BaseObject(IntPtr nativePointer, BaseObjectType type)
        {
            if (nativePointer == IntPtr.Zero)
            {
                throw new BaseObjectRemovedException(this);
            }

            NativePointer = nativePointer;
            Type = type;
            Exists = true;
        }

        public void SetMetaData(string key, object value)
        {
            CheckIfEntityExists();
            var mValue = MValue.CreateFromObject(value);
            SetMetaData(key, ref mValue);
        }

        public bool GetMetaData(string key, out int result)
        {
            CheckIfEntityExists();
            var mValue = MValue.Nil;
            GetMetaData(key, ref mValue);
            if (mValue.type != MValue.Type.INT)
            {
                result = default;
                return false;
            }

            result = (int) mValue.GetInt();
            return true;
        }

        public bool GetMetaData(string key, out uint result)
        {
            CheckIfEntityExists();
            var mValue = MValue.Nil;
            GetMetaData(key, ref mValue);
            if (mValue.type != MValue.Type.UINT)
            {
                result = default;
                return false;
            }

            result = (uint) mValue.GetUint();
            return true;
        }

        public bool GetMetaData(string key, out float result)
        {
            CheckIfEntityExists();
            var mValue = MValue.Nil;
            GetMetaData(key, ref mValue);
            if (mValue.type != MValue.Type.DOUBLE)
            {
                result = default;
                return false;
            }

            result = (float) mValue.GetDouble();
            return true;
        }

        public bool GetMetaData<T>(string key, out T result)
        {
            CheckIfEntityExists();
            var mValue = MValue.Nil;
            GetMetaData(key, ref mValue);
            if (!(mValue.ToObject() is T cast))
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

        public void ClearData()
        {
            data.Clear();
        }

        public virtual void CheckIfEntityExists()
        {
            if (Exists)
            {
                return;
            }

            throw new BaseObjectRemovedException(this);
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
    }
}