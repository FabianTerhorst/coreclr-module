using System;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Native
{
    internal static partial class AltVNative
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class MValueCreate
        {
            [DllImport(_dllName, CharSet = CharSet.Auto, CallingConvention = _callingConvention)]
            internal static extern void String_Create([MarshalAs(UnmanagedType.LPStr)] string value,
                ref StringView stringView);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr Invoker_Create(MValue.Function function);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Invoker_Destroy(IntPtr invokerPointer);

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

            [DllImport(_dllName, CharSet = CharSet.Auto, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateString([MarshalAs(UnmanagedType.LPStr)] string value,
                ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateList(MValue[] values, ulong size, ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern MValue MValue_CreateDict(MValue[] values, string[] keys, ulong size,
                ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateEntity(IntPtr baseObjectPointer, ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern MValue MValue_CreateFunction(IntPtr invoker, ref MValue mValue);
        }

        [SuppressUnmanagedCodeSecurity]
        internal static class MValueGet
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool MValue_GetBool(ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern long MValue_GetInt(ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern ulong MValue_GetUInt(ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern double MValue_GetDouble(ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_GetString(ref MValue mValue, ref IntPtr value);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_GetList(ref MValue mValue, ref MValueArray value);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_GetDict(ref MValue mValue, ref StringViewArray keys,
                ref MValueArray values);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_GetEntity(ref MValue mValue, ref IntPtr value, ref EntityType entityType);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern MValue.Function MValue_GetFunction(ref MValue mValue);
        }

        [SuppressUnmanagedCodeSecurity]
        internal static class MValueCall
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CallFunction(ref MValue mValue, MValue[] args, ulong size,
                ref MValue result);
        }
    }
}