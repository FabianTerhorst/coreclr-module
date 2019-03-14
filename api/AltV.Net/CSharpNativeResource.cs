using System;
using AltV.Net.Elements.Args;
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
            //TODO: throw exception when not called in OnStart()
            AltNative.Resource.CSharpResource_SetExport(NativePointer, key, ref value);
        }
    }
}