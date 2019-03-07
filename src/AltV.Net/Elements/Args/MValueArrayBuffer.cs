using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Args
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MValueArrayBuffer
    {
        private IntPtr data; // Array of MValue's
        internal ulong size;

        public MValueArrayBuffer(IntPtr data, ulong size)
        {
            this.data = data;
            this.size = size;
        }

        /// <summary>
        /// Consumes and returns next MValue in the array
        /// </summary>
        /// <returns></returns>
        public MValue GetNext()
        {
            if (size == 0) return MValue.Nil;
            var value = Marshal.PtrToStructure<MValue>(data);
            size--;
            data += MValue.Size;
            return value;
        }

        public bool GetNext(out bool value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = Marshal.PtrToStructure<MValue>(data);
            data += MValue.Size;
            size--;
            if (mValue.type != MValue.Type.BOOL)
            {
                value = default;
                return false;
            }

            value = mValue.GetBool();
            return true;
        }

        public bool GetNext(out int value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = Marshal.PtrToStructure<MValue>(data);
            data += MValue.Size;
            size--;
            if (mValue.type != MValue.Type.INT)
            {
                value = default;
                return false;
            }

            value = (int) mValue.GetInt();
            return true;
        }

        public bool GetNext(out uint value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = Marshal.PtrToStructure<MValue>(data);
            data += MValue.Size;
            size--;
            if (mValue.type != MValue.Type.UINT)
            {
                value = default;
                return false;
            }

            value = (uint) mValue.GetUint();
            return true;
        }

        public bool GetNext(out long value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = Marshal.PtrToStructure<MValue>(data);
            data += MValue.Size;
            size--;
            if (mValue.type != MValue.Type.INT)
            {
                value = default;
                return false;
            }

            value = mValue.GetInt();
            return true;
        }

        public bool GetNext(out ulong value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = Marshal.PtrToStructure<MValue>(data);
            data += MValue.Size;
            size--;
            if (mValue.type != MValue.Type.UINT)
            {
                value = default;
                return false;
            }

            value = mValue.GetUint();
            return true;
        }

        public bool GetNext(out double value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = Marshal.PtrToStructure<MValue>(data);
            data += MValue.Size;
            size--;
            if (mValue.type != MValue.Type.DOUBLE)
            {
                value = default;
                return false;
            }

            value = mValue.GetDouble();
            return true;
        }

        public bool GetNext(out string value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = Marshal.PtrToStructure<MValue>(data);
            data += MValue.Size;
            size--;
            if (mValue.type != MValue.Type.STRING)
            {
                value = default;
                return false;
            }

            value = mValue.GetString();
            return true;
        }

        public bool GetNextConvertible<T>(out object obj)
        {
            if (size == 0)
            {
                obj = null;
                return false;
            }

            var mValue = Marshal.PtrToStructure<MValue>(data);
            data += MValue.Size;
            size--;
            if (mValue.type == MValue.Type.LIST || mValue.type == MValue.Type.DICT)
            {
                MValueAdapters.FromMValue(ref mValue, typeof(T), out obj);
                return true;
            }

            obj = null;
            return false;
        }

        public bool GetNext(out MValue.Function value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = Marshal.PtrToStructure<MValue>(data);
            data += MValue.Size;
            size--;
            if (mValue.type != MValue.Type.FUNCTION)
            {
                value = default;
                return false;
            }

            value = mValue.GetFunction();
            return true;
        }

        public void SkipValue()
        {
            if (size == 0)
            {
                return;
            }

            data += MValue.Size;
            size--;
        }

        public bool GetNext<TEntity>(out TEntity value) where TEntity : IEntity
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = Marshal.PtrToStructure<MValue>(data);
            data += MValue.Size;
            size--;
            if (mValue.type != MValue.Type.ENTITY)
            {
                value = default;
                return false;
            }

            var entityType = BaseObjectType.Undefined;
            var ptr = mValue.GetEntityPointer(ref entityType);
            if (Alt.Module.BaseBaseObjectPool.GetOrCreate(ptr, entityType, out var entity))
            {
                if (entity is TEntity typedEntity)
                {
                    value = typedEntity;
                    return true;
                }

                value = default;
                return false;
            }

            value = default;
            return false;
        }

        public bool GetNext(out StringViewArray keys, out MValueArray values)
        {
            if (size == 0)
            {
                keys = default;
                values = default;
                return false;
            }

            var mValue = Marshal.PtrToStructure<MValue>(data);
            data += MValue.Size;
            size--;
            if (mValue.type != MValue.Type.DICT)
            {
                keys = default;
                values = default;
                return false;
            }

            var stringViewArray = StringViewArray.Nil;
            var valueArrayRef = MValueArray.Nil;
            AltVNative.MValueGet.MValue_GetDict(ref mValue, ref stringViewArray, ref valueArrayRef);
            keys = stringViewArray;
            values = valueArrayRef;
            return true;
        }

        public bool GetNext(out MValueArray values)
        {
            if (size == 0)
            {
                values = default;
                return false;
            }

            var mValue = Marshal.PtrToStructure<MValue>(data);
            data += MValue.Size;
            size--;
            if (mValue.type != MValue.Type.LIST)
            {
                values = default;
                return false;
            }

            var valueArrayRef = MValueArray.Nil;
            AltVNative.MValueGet.MValue_GetList(ref mValue, ref valueArrayRef);
            values = valueArrayRef;
            return true;
        }

        public bool HasNext()
        {
            return size != 0;
        }

        public MValue.Type GePreviousType()
        {
            var mValue = Marshal.PtrToStructure<MValue>(data - MValue.Size);
            return mValue.type;
        }
    }
}