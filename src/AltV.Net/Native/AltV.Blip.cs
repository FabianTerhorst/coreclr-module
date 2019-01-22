using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        internal static class Blip
        {

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Blip_SetColor(IntPtr blipPointer, uint color);
        }
    }
}