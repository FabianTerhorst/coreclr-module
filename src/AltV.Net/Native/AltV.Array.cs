using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Array
    {
        public IntPtr data;
        public ulong size;
        public ulong capacity;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MValueArray
    {
        public IntPtr data; // Array of MValue's
        public ulong size;
        public ulong capacity;

        public static MValueArray Nil = new MValueArray
        {
            data = IntPtr.Zero,
            size = 0,
            capacity = 0
        };

        public MValue[] ToArray()
        {
            var value = data;
            var values = new MValue[size];
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = Marshal.PtrToStructure<MValue>(value);
                value += MValue.Size;
            }

            return values;
        }

        //TODO: change return values to bool and get MValue by ref

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

        /// <summary>
        /// Consumes and returns next MValue string value in the array if the type is correct otherwise returns false
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        //TODO: can we improve this with an own c method that only needs the storage pointer to read the string
        /*public bool GetNext(out string value)
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
        }*/
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

    [StructLayout(LayoutKind.Sequential)]
    public struct StringArray
    {
        public IntPtr data; // Array of string's
        public ulong size;
        public ulong capacity;

        public static StringArray Nil = new StringArray
        {
            data = IntPtr.Zero,
            size = 0,
            capacity = 0
        };

        public string[] ToArray()
        {
            var values = new IntPtr[size];
            Marshal.Copy(data, values, 0, (int) size);
            var strings = new string[size];
            for (var i = 0; i < values.Length; i++)
            {
                strings[i] = Marshal.PtrToStringAnsi(values[i]);
            }

            return strings;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StringViewArray
    {
        public IntPtr data; // Array of StringView's
        public ulong size;
        public ulong capacity;

        public static StringViewArray Nil = new StringViewArray
        {
            data = IntPtr.Zero,
            size = 0,
            capacity = 0
        };

        public string[] ToArray()
        {
            var value = data;
            var values = new string[size];
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = Marshal.PtrToStructure<StringView>(value).Text;
                value += StringView.Size;
            }

            return values;
        }
    }
}