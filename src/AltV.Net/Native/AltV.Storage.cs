using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    //TODO: create multiple storage classes for each possible MValue.type return and use the correct one instead of an generic one
    internal static partial class Alt
    {
        [StructLayout(LayoutKind.Sequential)]
        public sealed class Storage<T>
        {
            public uint refCount;
            public T value;
        }
    }
}