using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        internal static class Entity
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Entity_GetId(IntPtr entityPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern Alt.Position Entity_GetPosition(IntPtr entityPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetPosition(IntPtr entityPointer, [MarshalAs(UnmanagedType.Struct)] Alt.Position position);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetPosition(IntPtr entityPointer, float x, float y, float z);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            [return: MarshalAs(UnmanagedType.Struct)]
            internal static extern Alt.Rotation Entity_GetRotation(IntPtr entityPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetRotation(IntPtr entityPointer, [MarshalAs(UnmanagedType.Struct)] Alt.Rotation rotation);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetRotation(IntPtr entityPointer, float roll, float pitch, float yaw);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Entity_GetDimension(IntPtr entityPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetDimension(IntPtr entityPointer, uint dimension);

            //TODO: alt::MValue fast c# representation
            //The C++ standard guarantees that memory layouts of a C struct and a C++ class (or struct -- same thing) will be identical
        }
    }
}