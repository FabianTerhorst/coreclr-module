using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RGBA
        {
            public static RGBA Zero = new RGBA
            {
                r = 0,
                g = 0,
                b = 0,
                a = 0
            };

            public byte r;
            public byte g;
            public byte b;
            public byte a;
        }
    }
}