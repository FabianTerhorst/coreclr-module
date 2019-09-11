using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net
{
    public class NativeResource : INativeResource
    {
        internal readonly IntPtr NativePointer;

        public IntPtr ResourceImpl => AltNative.Resource.Resource_GetImpl(NativePointer);

        private CSharpResourceImpl cSharpResourceImpl;

        public CSharpResourceImpl CSharpResourceImpl =>
            cSharpResourceImpl ?? (cSharpResourceImpl =
                new CSharpResourceImpl(AltNative.Resource.Resource_GetCSharpImpl(NativePointer)));

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

        public bool IsStarted => AltNative.Resource.Resource_IsStarted(NativePointer);

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

        public bool GetExport(string key, ref MValue value)
        {
            return AltNative.Resource.Resource_GetExport(NativePointer, key, ref value);
        }

        public void Start()
        {
            AltNative.Resource.Resource_Start(NativePointer);
        }

        public void Stop()
        {
            AltNative.Resource.Resource_Stop(NativePointer);
        }
    }
}