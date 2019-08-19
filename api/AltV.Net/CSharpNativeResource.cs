using System;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net
{
    /// <summary>
    /// A wrapper around none standard alt:V cpp apis
    /// </summary>
    //TODO: move SetDelegates to this thing
    public class CSharpNativeResource : NativeResource
    {
        internal CSharpNativeResource(IntPtr nativePointer) : base(nativePointer)
        {
        }

        public void SetExport(string key, MValue value)
        {
            //TODO: throw exception when not called in OnStart()
            AltNative.Resource.CSharpResource_SetExport(NativePointer, key, ref value);
        }

        public void Reload()
        {
            AltNative.Resource.CSharpResource_Reload(NativePointer);
        }
    }
}