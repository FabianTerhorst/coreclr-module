using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        [StructLayout(LayoutKind.Sequential)]
        public sealed class Rotation
        {
            float roll;
            float pitch;
            float yaw;
        }
    }
}