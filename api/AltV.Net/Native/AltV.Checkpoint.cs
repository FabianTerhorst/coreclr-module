using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        internal static class Checkpoint
        {
            // Entity

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_GetPosition(IntPtr entityPointer, ref Position position);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_SetPosition(IntPtr entityPointer, Position position);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_GetRotation(IntPtr entityPointer, ref Rotation rotation);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_SetRotation(IntPtr entityPointer, Rotation rotation);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern short Checkpoint_GetDimension(IntPtr entityPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_SetDimension(IntPtr entityPointer, short dimension);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_GetMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_SetMetaData(IntPtr entityPointer, string key, ref MValue value);

            // Checkpoint
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Checkpoint_IsGlobal(IntPtr checkpointPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Checkpoint_GetCheckpointType(IntPtr checkpointPointer);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern float Checkpoint_GetHeight(IntPtr checkpointPointer);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern float Checkpoint_GetRadius(IntPtr checkpointPointer);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Checkpoint_GetColor(IntPtr checkpointPointer, ref Rgba color);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Checkpoint_IsPlayerIn(IntPtr checkpointPointer, IntPtr playerPointer);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Checkpoint_IsVehicleIn(IntPtr checkpointPointer, IntPtr vehiclePointer);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Checkpoint_GetTarget(IntPtr checkpointPointer);
        }
    }
}