using System;
using System.Collections.Concurrent;

namespace AltV.Net.Elements.Entities
{
    public abstract class BaseObject : IBaseObject, IInternalBaseObject
    {
        private readonly ConcurrentDictionary<string, object> data = new ConcurrentDictionary<string, object>();

        public IntPtr NativePointer { get; }
        public bool Exists { get; set; }

        public BaseObjectType Type { get; }

        public abstract void SetMetaData(string key, object value);
        public abstract bool GetMetaData<T>(string key, out T result);

        protected BaseObject(IntPtr nativePointer, BaseObjectType type)
        {
            NativePointer = nativePointer;
            Type = type;
            Exists = true;
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

        protected virtual void CheckExistence()
        {
            if (Exists)
            {
                return;
            }

            throw new BaseObjectDeletedException(this);
        }
    }
}