using System.Runtime.InteropServices;

namespace AltV.Net.Shared.Utils
{
    
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct FunctionTable
    {
        private readonly uint Size;
        private readonly IntPtr Hashes;
        private readonly IntPtr Pointers;

        public Dictionary<ulong, IntPtr> GetTable()
        {
            var hashes = new long[Size];
            var pointers = new IntPtr[Size];
            Marshal.Copy(Hashes, hashes, 0, (int) Size);
            Marshal.Copy(Pointers, pointers, 0, (int) Size);

            var dict = new Dictionary<ulong, IntPtr>();
            for (var i = 0; i < Size; i++) dict[unchecked((ulong) hashes[i])] = pointers[i];
            return dict;
        }
    }
}