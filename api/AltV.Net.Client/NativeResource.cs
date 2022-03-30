using AltV.Net.Client.Runtime;

namespace AltV.Net.Client
{
    public class NativeResource : INativeResource
    {
        public IntPtr NativePointer { get; }
        private readonly ICore core;

        private CSharpResourceImpl? cSharpResourceImpl;

        public CSharpResourceImpl CSharpResourceImpl
        {
            get
            {
                unsafe
                {
                    return cSharpResourceImpl ??=
                        new CSharpResourceImpl(core.Library, core.Library.Shared.Resource_GetCSharpImpl(NativePointer));
                }
            }
        }

        internal NativeResource(ICore core, IntPtr nativePointer)
        {
            NativePointer = nativePointer;
            this.core = core;
        }
    }
}