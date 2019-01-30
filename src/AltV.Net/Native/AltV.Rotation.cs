using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Rotation
        {
            public float roll;
            public float pitch;
            public float yaw;
        }
    }
}