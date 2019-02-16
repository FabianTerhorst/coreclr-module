using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;

namespace AltV.Net.Native
{
    internal static partial class AltVNative
    {
        internal static class Checkpoint
        {
            // Entity
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern ushort Checkpoint_GetID(IntPtr entityPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern Position Checkpoint_GetPosition(IntPtr entityPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Checkpoint_SetPosition(IntPtr entityPointer, Position position);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern Rotation Checkpoint_GetRotation(IntPtr entityPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Checkpoint_SetRotation(IntPtr entityPointer, Rotation rotation);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern ushort Checkpoint_GetDimension(IntPtr entityPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Checkpoint_SetDimension(IntPtr entityPointer, ushort dimension);

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
            internal static extern Rgba Checkpoint_GetColor(IntPtr checkpointPointer);
        }
    }
}