using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net
{
    public class NativeResource : INativeResource
    {
        internal readonly IntPtr NativePointer;
        
        public string Path
        {
            get
            {
                var ptr = IntPtr.Zero;
                AltNative.Resource.Resource_GetPath(NativePointer, ref ptr);
                return Marshal.PtrToStringUTF8(ptr);
            }
        }

        public string Name
        {
            get
            {
                var ptr = IntPtr.Zero;
                AltNative.Resource.Resource_GetName(NativePointer, ref ptr);
                return Marshal.PtrToStringUTF8(ptr);
            }
        }

        public string Main
        {
            get
            {
                var ptr = IntPtr.Zero;
                AltNative.Resource.Resource_GetMain(NativePointer, ref ptr);
                return Marshal.PtrToStringUTF8(ptr);
            }
        }

        public string Type
        {
            get
            {
                var ptr = IntPtr.Zero;
                AltNative.Resource.Resource_GetType(NativePointer, ref ptr);
                return Marshal.PtrToStringUTF8(ptr);
            }
        }

        public ResourceState State => AltNative.Resource.Resource_GetState(NativePointer);

        internal NativeResource(IntPtr nativePointer)
        {
            NativePointer = nativePointer;
        }

        public void SetExport(string key, object value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            var mValue = MValue.CreateFromObject(value);
            AltNative.Resource.Resource_SetExport(NativePointer, stringPtr, ref mValue);
            Marshal.FreeHGlobal(stringPtr);
            mValue.Dispose();
        }
    }
}