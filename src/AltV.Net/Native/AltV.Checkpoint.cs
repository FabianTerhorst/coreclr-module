using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltVNative
    {
        internal static class Checkpoint
        {
            // Entity

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Checkpoint_GetPosition(IntPtr entityPointer, ref Position position);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Checkpoint_SetPosition(IntPtr entityPointer, Position position);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Checkpoint_GetRotation(IntPtr entityPointer, ref Rotation rotation);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Checkpoint_SetRotation(IntPtr entityPointer, Rotation rotation);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern short Checkpoint_GetDimension(IntPtr entityPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Checkpoint_SetDimension(IntPtr entityPointer, short dimension);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Checkpoint_GetMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Checkpoint_SetMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void
                Checkpoint_GetSyncedMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void
                Checkpoint_SetSyncedMetaData(IntPtr entityPointer, string key, ref MValue value);
            
            // Checkpoint
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Checkpoint_IsGlobal(IntPtr checkpointPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern byte Checkpoint_GetType(IntPtr checkpointPointer);
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern float Checkpoint_GetHeight(IntPtr checkpointPointer);
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern float Checkpoint_GetRadius(IntPtr checkpointPointer);
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Checkpoint_GetColor(IntPtr checkpointPointer, ref Rgba color);
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Checkpoint_IsPlayerIn(IntPtr checkpointPointer, IntPtr playerPointer);
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Checkpoint_IsVehicleIn(IntPtr checkpointPointer, IntPtr vehiclePointer);
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr Checkpoint_GetTarget(IntPtr checkpointPointer);
        }
    }
}