using System;
using System.Collections.Generic;

namespace AltV.Net.Mock
{
    public static class MockEntities
    {
        private static IntPtr _ptr = IntPtr.Zero;

        private static uint _id = 0;

        private static readonly Stack<IntPtr> FreePointers = new Stack<IntPtr>();

        private static readonly Stack<uint> FreeIds = new Stack<uint>();

        public static IntPtr GetNextPtr(out uint id)
        {
            if (FreeIds.Count > 0 && FreePointers.Count > 0)
            {
                id = FreeIds.Pop();
                return FreePointers.Pop();
            }

            _ptr += 1;
            id = ++_id;
            return _ptr;
        }

        public static void Free(IntPtr intPtr, uint id)
        {
            FreeIds.Push(id);
            FreePointers.Push(intPtr);
        }

        public static void FreeNoId(IntPtr intPtr)
        {
            FreePointers.Push(intPtr);
        }

        public static IntPtr GetNextPtrNoId()
        {
            if (FreePointers.Count > 0)
            {
                return FreePointers.Pop();
            }

            _ptr += 1;
            return _ptr;
        }
    }
}