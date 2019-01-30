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
            public static MValue Nil = new MValue
            {
                type = 0,
                storagePointer = IntPtr.Zero
            };
            public byte type;
            public IntPtr storagePointer;
        }

        internal static class MValueCreate
        {
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern MValue MValue_CreateNil();
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern MValue MValue_CreateBool(bool value);
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern MValue MValue_CreateInt(int value);
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern MValue MValue_CreateUInt(uint value);
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern MValue MValue_CreateDouble(double value);
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern MValue MValue_CreateString(string value);
            /*[DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern MValue MValue_CreateList(const alt::Array<alt::MValue> &val);
    [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern MValue MValue_CreateDict(const std::unordered_map<alt::String, alt::MValue> &val);*/
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern MValue MValue_CreateEntity(IntPtr baseObjectPointer);
            /* [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
                    internal static extern MValue MValue_CreateFunction(const alt::MValue::Function &val);*/
        }
    }
}