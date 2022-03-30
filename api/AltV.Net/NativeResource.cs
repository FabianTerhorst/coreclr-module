using System;
using System.Runtime.InteropServices;
using AltV.Net.CApi;
using AltV.Net.Elements.Args;
using AltV.Net.Native;
using AltV.Net.Shared;

namespace AltV.Net
{
    public class NativeResource : SharedNativeResource, INativeResource
    {
        private CSharpResourceImpl cSharpResourceImpl;

        public override CSharpResourceImpl CSharpResourceImpl
        {
            get
            {
                unsafe
                {
                    return cSharpResourceImpl ??=
                        new CSharpResourceImpl(core, core.Library.Shared.Resource_GetCSharpImpl(NativePointer));
                }
            }
        }

        public string Path
        {
            get
            {
                unsafe
                {
                    var ptr = IntPtr.Zero;
                    core.Library.Server.Resource_GetPath(NativePointer, &ptr);
                    return Marshal.PtrToStringUTF8(ptr);
                }
            }
        }

        public string Main
        {
            get
            {
                unsafe
                {
                    var ptr = IntPtr.Zero;
                    core.Library.Server.Resource_GetMain(NativePointer, &ptr);
                    return Marshal.PtrToStringUTF8(ptr);
                }
            }
        }

        public void Start()
        {
            unsafe
            {
                core.Library.Server.Resource_Start(NativePointer);
            }
        }

        public void Stop()
        {
            unsafe
            {
                core.Library.Server.Resource_Stop(NativePointer);
            }
        }

        internal NativeResource(ISharedCore core, IntPtr nativePointer) : base(core, nativePointer)
        {
        }
    }
}