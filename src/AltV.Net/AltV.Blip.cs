using System;
using System.Runtime.InteropServices;

namespace AltV.Net
{
    internal static partial class AltV
    {
        internal static class Blip
        {

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Blip_SetColor(IntPtr blipPointer, uint color);
        }
    }
}
