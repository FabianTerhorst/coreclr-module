using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MValue
    {
        // The MValue param needs to be an List type
        public delegate ref MValue Function(MValue args);
        
        public enum Type : byte
        {
            NIL = 0,
            BOOL = 1,
            INT = 2,
            UINT = 3,
            DOUBLE = 4,
            STRING = 5,
            LIST = 6,
            DICT = 7,
            ENTITY = 8,
            FUNCTION = 9
        }

        public static MValue Nil = new MValue(0, IntPtr.Zero);

        public byte type;
        public IntPtr storagePointer;

        public MValue(byte type, IntPtr storagePointer)
        {
            this.type = type;
            this.storagePointer = storagePointer;
        }

        /*~MValue()
        {
            if (storagePointer == IntPtr.Zero) return;
            Marshal.FreeHGlobal(storagePointer);
            storagePointer = IntPtr.Zero;
        }*/
    }
}