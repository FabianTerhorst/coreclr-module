using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        public enum MValueType : byte
        {
            NIL,
            BOOL,
            INT,
            UINT,
            DOUBLE,
            STRING,
            LIST,
            DICT,
            ENTITY,
            FUNCTION
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct MValue
        {
            MValueType type;
            IntPtr storagePointer;
        }
    }
}