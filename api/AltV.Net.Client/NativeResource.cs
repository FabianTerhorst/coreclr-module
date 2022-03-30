using AltV.Net.Client.Runtime;
using AltV.Net.Shared;

namespace AltV.Net.Client
{
    public class NativeResource : SharedNativeResource, INativeResource
    {
        private CSharpResourceImpl? cSharpResourceImpl;

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

        internal NativeResource(ICore core, IntPtr nativePointer) : base(core, nativePointer)
        {
        }
    }
}