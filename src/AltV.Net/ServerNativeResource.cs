using System;
using AltV.Net.Native;

namespace AltV.Net
{
    public class ServerNativeResource : NativeResource
    {
        public ServerNativeResource(IntPtr nativePointer) : base(nativePointer)
        {
        }

        public void GetExport(string key, ref MValue value)
        {
            AltVNative.Resource.Resource_GetExport(NativePointer, key, ref value);
        }
    }
}