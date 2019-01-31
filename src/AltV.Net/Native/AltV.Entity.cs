using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        internal static class Entity
        {
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern ushort BaseObject_GetType(IntPtr baseObjectPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern ushort Entity_GetId(IntPtr entityPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_GetPosition(IntPtr entityPointer, ref Alt.Position position);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetPosition(IntPtr entityPointer, ref Alt.Position position);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetPosition(IntPtr entityPointer, float x, float y, float z);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_GetRotation(IntPtr entityPointer, ref Alt.Rotation rotation);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetRotation(IntPtr entityPointer, ref Alt.Rotation rotation);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetRotation(IntPtr entityPointer, float roll, float pitch, float yaw);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern ushort Entity_GetDimension(IntPtr entityPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetDimension(IntPtr entityPointer, ushort dimension);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern MValue Entity_GetMetaData(IntPtr entityPointer, string key, ref Alt.MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetMetaData(IntPtr entityPointer, string key, ref Alt.MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void
                Entity_GetSyncedMetaData(IntPtr entityPointer, string key, ref Alt.MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void
                Entity_SetSyncedMetaData(IntPtr entityPointer, string key, ref Alt.MValue value);
        }
    }
}