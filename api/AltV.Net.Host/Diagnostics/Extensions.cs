using System;
using System.IO;
using System.Text;
#if DEBUG
using AltV.Net.Host.Diagnostics.Eventing;
using System.Runtime.InteropServices;

#endif

namespace AltV.Net.Host.Diagnostics
{
    public static class Extensions
    {
        public static void WriteString(this BinaryWriter @this, string value)
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));

            @this.Write(value != null ? (value.Length + 1) : 0);
            if (value != null)
                @this.Write(Encoding.Unicode.GetBytes(value + '\0'));
        }

#if DEBUG
        private static int GetByteCount(this string @this)
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));

            var strLength = @this == null ? 0 : Encoding.Unicode.GetByteCount(@this + '\0');
            return Marshal.SizeOf(typeof(int)) + strLength;
        }

        public static int GetByteCount(this SessionConfiguration @this)
        {
            int size = 0;

            size += Marshal.SizeOf(@this.CircularBufferSizeInMB.GetType());
            size += Marshal.SizeOf(typeof(int));

            foreach (var provider in @this.Providers)
            {
                size += Marshal.SizeOf(provider.Keywords.GetType());
                size += Marshal.SizeOf(typeof(uint)); // provider.EventLevel.GetType()
                size += provider.Name.GetByteCount();
                size += provider.FilterData.GetByteCount();
            }

            return size;
        }
#endif // DEBUG
    }
}