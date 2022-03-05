using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    /*[StructLayout(LayoutKind.Sequential)]
    public struct MValueArray : IDisposable
    {
        internal IntPtr data; // Array of MValue's
        public ulong Size;
        private ulong capacity;

        public static MValueArray Nil = new MValueArray
        {
            data = IntPtr.Zero,
            Size = 0,
            capacity = 0
        };

        public MValue[] ToArray()
        {
            var value = data;
            var values = new MValue[Size];
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = Marshal.PtrToStructure<MValue>(value);
                value += MValue.Size;
            }

            return values;
        }

        /// <summary>
        /// Consumes and returns next string in the array
        /// </summary>
        /// <returns></returns>
        public MValue GetNextWithOffset(ref IntPtr offset)
        {
            if (Size == 0) return MValue.Nil;
            var value = Marshal.PtrToStructure<MValue>(offset);
            Size--;
            offset += StringView.Size;
            return value;
        }

        public void Dispose()
        {
            AltNative.FreeMValueArray(ref this);
        }

        public MValueArrayBuffer Reader()
        {
            return new MValueArrayBuffer(data, Size);
        }
    }*/

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
        public string GetNextWithOffset(ref IntPtr offset)
        {
            if (size == 0) return null;
            var value = Marshal.PtrToStructure<StringView>(offset).Text;
            size--;
            offset += StringView.Size;
            return value;
        }
    }

    /*[StructLayout(LayoutKind.Sequential)]
    public struct StringArray
    {
        public IntPtr data; // Array of StringView's
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
        public string GetNextWithOffset(ref IntPtr offset)
        {
            if (size == 0) return null;
            size--;
            var value = Marshal.PtrToStructure<StringView>(offset).Text;
            offset += StringView.Size;
            return value;
        }

        public void SkipValueWithOffset(ref IntPtr offset)
        {
            if (size == 0) return;
            size--;
            offset += StringView.Size;
        }
    }*/

    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponArray
    {
        public IntPtr data; // Array of weapon's
        public ulong size;
        public ulong capacity;

        public static WeaponArray Nil = new()
        {
            data = IntPtr.Zero,
            size = 0,
            capacity = 0
        };

        public WeaponData[] ToArray()
        {
            return Convert(ToInternalArray());
        }

        internal WeaponDataInternal[] ToInternalArray()
        {
            var value = data;
            var values = new WeaponDataInternal[size];
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = Marshal.PtrToStructure<WeaponDataInternal>(value);
                value += WeaponDataInternal.Size;
            }

            return values;
        }

        internal static WeaponData[] Convert(WeaponDataInternal[] weapons)
        {
            var result = new WeaponData[weapons.Length];

            for (var i = 0;i < weapons.Length; i++)
            {
                result[i] = new WeaponData(weapons[i].Hash, weapons[i].TintIndex, weapons[i].GetComponents());
            }

            return result;
        }
    }

    /*[StructLayout(LayoutKind.Sequential)]
    public struct PlayerPointerArray : IDisposable
    {
        public IntPtr data; // Array of player pointers
        public ulong size;
        public ulong capacity;

        public static PlayerPointerArray Nil = new PlayerPointerArray
        {
            data = IntPtr.Zero,
            size = 0,
            capacity = 0
        };

        public IntPtr[] ToArrayAndFree()
        {
            var value = data;
            var length = (int) size;
            var values = new IntPtr[length];
            for (var i = 0; i < length; i++)
            {
                values[i] = value;
                value += IntPtr.Size;
            }

            Dispose();

            size = 0;

            return values;
        }

        public void Dispose()
        {
            AltNative.FreePlayerPointerArray(ref this);
        }
    }*/
}