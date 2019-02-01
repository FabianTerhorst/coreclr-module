using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        internal static class MValueCreate
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateNil(ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateBool(bool value, ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateInt(long value, ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateUInt(ulong value, ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateDouble(double value, ref MValue mValue);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateString(string value, ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateList([Out] MValue[] values, ulong size,
                ref MValue mValue);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern MValue MValue_CreateDict([Out] MValue[] values, [Out] string[] keys, ulong size,
                ref MValue mValue);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateEntity(IntPtr baseObjectPointer, ref MValue mValue);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern MValue MValue_CreateFunction(MValue.Function function, ref MValue mValue);
        }
    }
}