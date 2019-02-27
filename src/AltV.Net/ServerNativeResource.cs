using System;
using AltV.Net.Native;

namespace AltV.Net
{
    public class ServerNativeResource : NativeResource
    {
        public ServerNativeResource(IntPtr nativePointer) : base(nativePointer)
        {
        }

        public bool GetExport(string key, ref MValue value)
        {
            return AltVNative.Resource.Resource_GetExport(NativePointer, key, ref value);
        }
    }
}