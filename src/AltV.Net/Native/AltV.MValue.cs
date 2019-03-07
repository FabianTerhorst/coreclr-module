using System;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltVNative
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class MValueCreate
        {
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

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateString([MarshalAs(UnmanagedType.LPStr)] string value,
                ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateList(MValue[] values, ulong size, ref MValue mValue);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern MValue MValue_CreateDict(MValue[] values, string[] keys, ulong size,
                ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreatePlayer(IntPtr playerPointer, ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateVehicle(IntPtr vehiclePointer, ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateBlip(IntPtr blipPointer, ref MValue mValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CreateCheckpoint(IntPtr checkpointPointer, ref MValue mValue);

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
            internal static extern IntPtr MValue_GetEntity(ref MValue mValue, ref BaseObjectType baseObjectType);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern MValue.Function MValue_GetFunction(ref MValue mValue);
        }

        [SuppressUnmanagedCodeSecurity]
        internal static class MValueCall
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CallFunction(ref MValue mValue, MValue[] args, ulong size,
                ref MValue result);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void MValue_CallFunctionValue(ref MValue mValue, ref MValue args, ref MValue result);
        }
    }
}