using System;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class Checkpoint
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_GetPosition(IntPtr checkpoint, ref Position position);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_SetPosition(IntPtr checkpoint, Position pos);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern int Checkpoint_GetDimension(IntPtr checkpoint);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_SetDimension(IntPtr checkpoint, int dimension);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Checkpoint_GetMetaData(IntPtr checkpoint, IntPtr key);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_SetMetaData(IntPtr checkpoint, IntPtr key, IntPtr val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Checkpoint_HasMetaData(IntPtr checkpoint, IntPtr key);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_DeleteMetaData(IntPtr checkpoint, IntPtr key);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_AddRef(IntPtr checkpoint);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_RemoveRef(IntPtr checkpoint);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Checkpoint_GetCheckpointType(IntPtr checkpoint);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_SetCheckpointType(IntPtr checkpoint, byte type);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern float Checkpoint_GetHeight(IntPtr checkpoint);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_SetHeight(IntPtr checkpoint, float height);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern float Checkpoint_GetRadius(IntPtr checkpoint);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_SetRadius(IntPtr checkpoint, float radius);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_GetColor(IntPtr checkpoint, ref Rgba color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_SetColor(IntPtr checkpoint, Rgba color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Checkpoint_IsPlayerIn(IntPtr checkpoint, IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Checkpoint_IsVehicleIn(IntPtr checkpoint, IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ColShapeType Checkpoint_GetColShapeType(IntPtr checkpoint);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_SetPlayersOnly(IntPtr checkpoint, bool state);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Checkpoint_IsPlayersOnly(IntPtr checkpoint);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_GetNextPosition(IntPtr checkpoint, ref Position pos);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_SetNextPosition(IntPtr checkpoint, Position pos);
        }
    }
}