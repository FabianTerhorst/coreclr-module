using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Native
{
    internal static partial class AltVNative
    {
        internal static class Blip
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Blip_IsGlobal(IntPtr blipPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Blip_IsAttached(IntPtr blipPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr Blip_AttachedTo(IntPtr blipPointer, ref EntityType entityType);

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