using System;

namespace AltV.Net
{
    public class NativeResource
    {
        internal readonly IntPtr NativePointer;

        internal NativeResource(IntPtr nativePointer)
        {
            NativePointer = nativePointer;
        }
    }
}