using System;
using System.Runtime.InteropServices;
using AltV.Net.CApi;
using AltV.Net.Elements.Args;
using AltV.Net.Native;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Data;

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
                    var size = 0;
                    return core.PtrToStringUtf8AndFree(core.Library.Server.Resource_GetPath(NativePointer, &size), size);
                }
            }
        }

        public string Main
        {
            get
            {
                unsafe
                {
                    var size = 0;
                    return core.PtrToStringUtf8AndFree(core.Library.Server.Resource_GetMain(NativePointer, &size), size);
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