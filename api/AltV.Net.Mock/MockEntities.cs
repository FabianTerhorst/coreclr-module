using System;

namespace AltV.Net.Mock
{
    public static class MockEntities
    {
        private static IntPtr _ptr = IntPtr.Zero;

        private static ushort _id = 0;

        public static IntPtr GetNextPtr(out ushort id)
        {
            _ptr += 1;
            id = ++_id;
            return _ptr;
        }
        
        public static IntPtr GetNextPtrNoId()
        {
            _ptr += 1;
            return _ptr;
        }
    }
}