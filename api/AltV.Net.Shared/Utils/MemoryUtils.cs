using System.Runtime.InteropServices;
using System.Text;

namespace AltV.Net.Shared.Utils
{
    public class MemoryUtils
    {
        //https://github.com/Microsoft/xbox-live-unity-plugin/blob/master/CSharpSource/Source/api/System/MarshallingHelpers.cs
        public static IntPtr StringToHGlobalUtf8(string str)
        {
            if (str == null)
            {
                str = "";
            }

            var bytes = Encoding.UTF8.GetBytes(str);
            var pointer = Marshal.AllocHGlobal(bytes.Length + 1);

            Marshal.Copy(bytes, 0, pointer, bytes.Length);
            // Add null terminator
            Marshal.WriteByte(pointer + bytes.Length, 0);

            return pointer;
        }

        public static IntPtr ByteArrayToHGlobal(byte[] bytes)
        {
            var pointer = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, pointer, bytes.Length);
            return pointer;
        }
    }
}