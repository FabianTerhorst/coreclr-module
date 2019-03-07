using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltVNative
    {
        internal static class Blip
        {
            // Entity

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Blip_GetPosition(IntPtr entityPointer, ref Position position);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Blip_SetPosition(IntPtr entityPointer, Position position);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Blip_GetRotation(IntPtr entityPointer, ref Rotation rotation);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Blip_SetRotation(IntPtr entityPointer, Rotation rotation);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern short Blip_GetDimension(IntPtr entityPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Blip_SetDimension(IntPtr entityPointer, short dimension);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Blip_GetMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Blip_SetMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void
                Blip_GetSyncedMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void
                Blip_SetSyncedMetaData(IntPtr entityPointer, string key, ref MValue value);
            
            // Blip
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Blip_IsGlobal(IntPtr blipPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Blip_IsAttached(IntPtr blipPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr Blip_AttachedTo(IntPtr blipPointer, ref BaseObjectType baseObjectType);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern byte Blip_GetType(IntPtr blipPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Blip_SetSprite(IntPtr blipPointer, ushort sprite);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Blip_SetColor(IntPtr blipPointer, byte color);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Blip_SetRoute(IntPtr blipPointer, bool state);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Blip_SetRouteColor(IntPtr blipPointer, byte color);
        }
    }
}