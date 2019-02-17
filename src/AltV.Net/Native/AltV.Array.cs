using System;
using System.Runtime.InteropServices;

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

        public MValueArrayBuffer Reader()
        {
            return new MValueArrayBuffer(data, size, capacity);
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

        /// <summary>
        /// Consumes and returns next string in the array
        /// </summary>
        /// <returns></returns>
        public string GetNext()
        {
            if (size == 0) return null;
            var value = Marshal.PtrToStructure<StringView>(data).Text;
            size--;
            data += StringView.Size;
            return value;
        }
    }
}