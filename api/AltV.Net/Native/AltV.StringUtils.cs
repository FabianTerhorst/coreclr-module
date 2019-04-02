using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AltV.Net.Native
{
    internal static class StringUtils
    {
        //https://github.com/Microsoft/xbox-live-unity-plugin/blob/master/CSharpSource/Source/api/System/MarshallingHelpers.cs
        public static IntPtr StringToHGlobalUtf8(string str)
        {
            if (str == null)
            {
                return IntPtr.Zero;
            }

            var bytes = Encoding.UTF8.GetBytes(str);
            var pointer = Marshal.AllocHGlobal(bytes.Length + 1);

            Marshal.Copy(bytes, 0, pointer, bytes.Length);
            // Add null terminator
            Marshal.WriteByte(pointer + bytes.Length, 0);

            return pointer;
        }
    }
}