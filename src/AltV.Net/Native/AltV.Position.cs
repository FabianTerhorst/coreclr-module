using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Position
        {
            public float x;
            public float y;
            public float z;
        }
    }
}