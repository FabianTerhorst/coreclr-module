using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        internal static class Entity
        {
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern uint Entity_GetId(IntPtr entityPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern Alt.Position Entity_GetPosition(IntPtr entityPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetPosition(IntPtr entityPointer, Alt.Position position);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetPosition(IntPtr entityPointer, float x, float y, float z);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern Alt.Rotation Entity_GetRotation(IntPtr entityPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetRotation(IntPtr entityPointer, Alt.Rotation rotation);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetRotation(IntPtr entityPointer, float roll, float pitch, float yaw);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern uint Entity_GetDimension(IntPtr entityPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetDimension(IntPtr entityPointer, uint dimension);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern Alt.MValue Entity_GetMetaData(IntPtr entityPointer, string key, ref Alt.MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetMetaData(IntPtr entityPointer, string key, ref Alt.MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern Alt.MValue Entity_GetSyncedMetaData(IntPtr entityPointer, string key);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetSyncedMetaData(IntPtr entityPointer, string key, Alt.MValue value);

            //TODO: alt::MValue fast c# representation
            //The C++ standard guarantees that memory layouts of a C struct and a C++ class (or struct -- same thing) will be identical
        }
    }
}