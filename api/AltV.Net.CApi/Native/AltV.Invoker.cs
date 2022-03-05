using System;
using AltV.Net.CApi;

//TODO: maybe cache invoker here instead of using cpp?
namespace AltV.Net.Native
{
    internal class Invoker : IDisposable
    {
        private readonly ICApiCore core;
        internal IntPtr NativePointer { get; }

        private Invoker(ICApiCore core, IntPtr nativePointer)
        {
            this.core = core;
            NativePointer = nativePointer;
        }

        public void Destroy()
        {
            // todo
            // Alt.Server.Resource.CSharpResourceImpl.DestroyInvoker(NativePointer);
        }

        public void Dispose()
        {
            Destroy();
        }

        ~Invoker()
        {
            Destroy();
        }
    }
}