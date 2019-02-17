using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MValueArrayBuffer
    {
        public IntPtr data; // Array of MValue's
        public ulong size;
        public ulong capacity;

        public MValueArrayBuffer(IntPtr data, ulong size, ulong capacity)
        {
            this.data = data;
            this.size = size;
            this.capacity = capacity;
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

            var readType = Marshal.ReadByte(data);
            if (readType != (byte) MValue.Type.BOOL)
            {
                data += MValue.Size;
                value = default;
                return false;
            }

            data += 1;
            value = new MValue((MValue.Type) readType, Marshal.ReadIntPtr(data)).GetBool();
            data += IntPtr.Size;
            size--;
            return true;
        }

        public bool GetNext(out int value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var readType = Marshal.ReadByte(data);
            if (readType != (byte) MValue.Type.INT)
            {
                data += MValue.Size;
                value = default;
                return false;
            }

            data += 1;
            value = (int) new MValue((MValue.Type) readType, Marshal.ReadIntPtr(data)).GetInt();
            data += IntPtr.Size;
            size--;
            return true;
        }

        public bool GetNext(out uint value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var readType = Marshal.ReadByte(data);
            if (readType != (byte) MValue.Type.UINT)
            {
                data += MValue.Size;
                value = default;
                return false;
            }

            data += 1;
            value = (uint) new MValue((MValue.Type) readType, Marshal.ReadIntPtr(data)).GetUint();
            data += IntPtr.Size;
            size--;
            return true;
        }

        public bool GetNext(out long value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var readType = Marshal.ReadByte(data);
            if (readType != (byte) MValue.Type.INT)
            {
                data += MValue.Size;
                value = default;
                return false;
            }

            data += 1;
            value = new MValue((MValue.Type) readType, Marshal.ReadIntPtr(data)).GetInt();
            data += IntPtr.Size;
            size--;
            return true;
        }

        public bool GetNext(out ulong value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var readType = Marshal.ReadByte(data);
            if (readType != (byte) MValue.Type.UINT)
            {
                data += MValue.Size;
                value = default;
                return false;
            }

            data += 1;
            value = new MValue((MValue.Type) readType, Marshal.ReadIntPtr(data)).GetUint();
            data += IntPtr.Size;
            size--;
            return true;
        }

        public bool GetNext(out double value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var readType = Marshal.ReadByte(data);
            if (readType != (byte) MValue.Type.DOUBLE)
            {
                data += MValue.Size;
                value = default;
                return false;
            }

            data += 1;
            value = new MValue((MValue.Type) readType, Marshal.ReadIntPtr(data)).GetDouble();
            data += IntPtr.Size;
            size--;
            return true;
        }

        public bool GetNext(out string value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var readType = Marshal.ReadByte(data);
            if (readType != (byte) MValue.Type.STRING)
            {
                data += MValue.Size;
                value = default;
                return false;
            }

            data += 1;
            value = new MValue((MValue.Type) readType, Marshal.ReadIntPtr(data)).GetString();
            data += IntPtr.Size;
            size--;
            return true;
        }

        public bool GetNext(out MValue.Function value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var readType = Marshal.ReadByte(data);
            if (readType != (byte) MValue.Type.FUNCTION)
            {
                data += MValue.Size;
                value = default;
                return false;
            }

            data += 1;
            value = new MValue((MValue.Type) readType, Marshal.ReadIntPtr(data)).GetFunction();
            data += IntPtr.Size;
            size--;
            return true;
        }

        public bool GetNext<TEntity>(out TEntity value) where TEntity : IEntity
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var readType = Marshal.ReadByte(data);
            if (readType != (byte) MValue.Type.ENTITY)
            {
                data += MValue.Size;
                value = default;
                return false;
            }

            data += 1;
            var entityType = EntityType.Undefined;
            var ptr = new MValue((MValue.Type) readType, Marshal.ReadIntPtr(data)).GetEntityPointer(ref entityType);
            data += IntPtr.Size;
            size--;
            if (Alt.Module.BaseEntityPool.GetOrCreate(ptr, entityType, out var entity))
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

            var readType = Marshal.ReadByte(data);
            if (readType != (byte) MValue.Type.DICT)
            {
                data += MValue.Size;
                keys = default;
                values = default;
                return false;
            }

            data += 1;
            var mValue = new MValue((MValue.Type) readType, Marshal.ReadIntPtr(data));
            var stringViewArray = StringViewArray.Nil;
            var valueArrayRef = MValueArray.Nil;
            AltVNative.MValueGet.MValue_GetDict(ref mValue, ref stringViewArray, ref valueArrayRef);
            keys = stringViewArray;
            values = valueArrayRef;
            data += IntPtr.Size;
            size--;
            return true;
        }

        public bool GetNext(out MValueArray values)
        {
            if (size == 0)
            {
                values = default;
                return false;
            }

            var readType = Marshal.ReadByte(data);
            if (readType != (byte) MValue.Type.LIST)
            {
                data += MValue.Size;
                values = default;
                return false;
            }

            data += 1;
            var mValue = new MValue((MValue.Type) readType, Marshal.ReadIntPtr(data));
            var valueArrayRef = MValueArray.Nil;
            AltVNative.MValueGet.MValue_GetList(ref mValue, ref valueArrayRef);
            values = valueArrayRef;
            data += IntPtr.Size;
            size--;
            return true;
        }

        public bool HasNext()
        {
            return size != 0;
        }
    }
}