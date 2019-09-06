using System;
using AltV.Net.Elements.Args;
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
            return AltNative.Resource.Resource_GetExport(NativePointer, key, ref value);
        }
    }
}