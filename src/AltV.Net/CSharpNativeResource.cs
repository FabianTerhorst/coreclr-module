using System;
using AltV.Net.Native;

namespace AltV.Net
{
    public class CSharpNativeResource : NativeResource
    {
        public CSharpNativeResource(IntPtr nativePointer) : base(nativePointer)
        {
        }

        public void SetExport(string key, MValue value)
        {
            AltVNative.Resource.CSharpResource_SetExport(NativePointer, key, ref value);
        }
    }
}