using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RGBA
        {
            public byte r;
            public byte g;
            public byte b;
            public byte a;
        }

        //TODO: test because rgba return value from dll isn't a pointer
        class RGBAMarshaler : ICustomMarshaler
        {
            public object MarshalNativeToManaged(IntPtr pNativeData)
            {
                return Marshal.PtrToStructure<RGBA>(pNativeData);
            }

            public IntPtr MarshalManagedToNative(object managedObj)
            {
                if (!(managedObj is RGBA s))
                    return IntPtr.Zero;
                var len = Marshal.SizeOf(managedObj);
                var ptr = Marshal.AllocHGlobal(len);
                Marshal.StructureToPtr(s, ptr, false);
                return ptr;
            }

            public void CleanUpNativeData(IntPtr pNativeData)
            {
                Marshal.FreeCoTaskMem(pNativeData);
            }

            public void CleanUpManagedData(object managedObj)
            {
            }

            public int GetNativeDataSize()
            {
                return IntPtr.Size;
            }

            static readonly RGBAMarshaler instance = new RGBAMarshaler();

            public static ICustomMarshaler GetInstance(string s)
            {
                return instance;
            }
        }
    }
}