using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;

namespace AltV.Net.Shared
{
    public interface ISharedCSharpResourceImpl
    {
        public IntPtr CreateInvoker(MValueFunctionCallback function);

        public void DestroyInvoker(IntPtr invoker);
    }
}