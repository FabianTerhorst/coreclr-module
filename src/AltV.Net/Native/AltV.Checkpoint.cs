using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;

namespace AltV.Net.Native
{
    internal static partial class AltVNative
    {
        internal static class Checkpoint
        {
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