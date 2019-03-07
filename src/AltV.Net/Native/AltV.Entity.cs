using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltVNative
    {
        internal static class Entity
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern BaseObjectType BaseObject_GetType(IntPtr baseObjectPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern ushort Entity_GetID(IntPtr entityPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_GetPositionRef(IntPtr entityPointer, ref Position position);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetPositionRef(IntPtr entityPointer, ref Position position);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern Position Entity_GetPosition(IntPtr entityPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetPosition(IntPtr entityPointer, Position position);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetPositionXYZ(IntPtr entityPointer, float x, float y, float z);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_GetRotationRef(IntPtr entityPointer, ref Rotation rotation);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetRotationRef(IntPtr entityPointer, ref Rotation rotation);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern Rotation Entity_GetRotation(IntPtr entityPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetRotation(IntPtr entityPointer, Rotation rotation);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetRotationRPY(IntPtr entityPointer, float roll, float pitch, float yaw);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern ushort Entity_GetDimension(IntPtr entityPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetDimension(IntPtr entityPointer, ushort dimension);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_GetMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Entity_SetMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void
                Entity_GetSyncedMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void
                Entity_SetSyncedMetaData(IntPtr entityPointer, string key, ref MValue value);
        }
    }
}