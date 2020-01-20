using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net
{
    public class NativeResource : INativeResource
    {
        private readonly IntPtr corePointer;
        
        internal readonly IntPtr NativePointer;

        public IntPtr ResourceImplPtr => AltNative.Resource.Resource_GetImpl(NativePointer);

        private CSharpResourceImpl cSharpResourceImpl;

        public CSharpResourceImpl CSharpResourceImpl =>
            cSharpResourceImpl ??= new CSharpResourceImpl(AltNative.Resource.Resource_GetCSharpImpl(NativePointer));

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

        internal NativeResource(IntPtr corePointer, IntPtr nativePointer)
        {
            this.corePointer = corePointer;
            NativePointer = nativePointer;
        }

        public void SetExport(string key, object value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            Alt.Server.CreateMValue(out var mValue, value);
            AltNative.Resource.Resource_SetExport(corePointer, NativePointer, stringPtr, mValue.nativePointer);
            Marshal.FreeHGlobal(stringPtr);
            mValue.Dispose();
        }

        public void SetExport(string key, in MValueConst value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Resource.Resource_SetExport(corePointer, NativePointer, stringPtr, value.nativePointer);
            Marshal.FreeHGlobal(stringPtr);
        }

        public object GetExport(string key)
        {
            var ptr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            var mValue = new MValueConst(AltNative.Resource.Resource_GetExport(NativePointer, ptr));
            var obj = mValue.ToObject();
            mValue.Dispose();
            Marshal.FreeHGlobal(ptr);
            return obj;
        }
        
        public bool GetExport(string key, out MValueConst mValue)
        {
            var ptr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            mValue = new MValueConst(AltNative.Resource.Resource_GetExport(NativePointer, ptr));
            Marshal.FreeHGlobal(ptr);
            return mValue.type != MValueConst.Type.Nil;
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