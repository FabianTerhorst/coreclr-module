using System;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class MValueCreate
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Invoker_Create(IntPtr csharpResourcePointer, MValue.Function function);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Invoker_Destroy(IntPtr csharpResourcePointer, IntPtr invokerPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_CreateNil(ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_CreateBool(bool value, ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_CreateInt(long value, ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_CreateUInt(ulong value, ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_CreateDouble(double value, ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_CreateString(IntPtr value, ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_CreateList(MValue[] values, ulong size, ref MValue mValue);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_CreateDict(MValue[] values, string[] keys, ulong size,
                ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_CreatePlayer(IntPtr playerPointer, ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_CreateVehicle(IntPtr vehiclePointer, ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_CreateBlip(IntPtr blipPointer, ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_CreateCheckpoint(IntPtr checkpointPointer, ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern MValue MValue_CreateFunction(IntPtr invoker, ref MValue mValue);
        }

        [SuppressUnmanagedCodeSecurity]
        internal static class MValueGet
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool MValue_GetBool(ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern long MValue_GetInt(ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ulong MValue_GetUInt(ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern double MValue_GetDouble(ref MValue mValue);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_GetString(ref MValue mValue, ref IntPtr value, ref ulong size);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_GetList(ref MValue mValue, ref MValueArray value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_GetDict(ref MValue mValue, ref StringArray keys,
                ref MValueArray values);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr MValue_GetEntity(ref MValue mValue, ref BaseObjectType baseObjectType);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern MValue.Function MValue_GetFunction(ref MValue mValue);
        }

        [SuppressUnmanagedCodeSecurity]
        internal static class MValueCall
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_CallFunction(ref MValue mValue, MValue[] args, int size,
                ref MValue result);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_CallFunctionValue(ref MValue mValue, ref MValue args, ref MValue result);
        }

        [SuppressUnmanagedCodeSecurity]
        internal static class MValueDispose
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValue_Dispose(ref MValue mValue);
        }
    }
}