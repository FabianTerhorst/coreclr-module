using System;

//TODO: maybe cache invoker here instead of using cpp?
namespace AltV.Net.Native
{
    internal class Invoker : IDisposable
    {
        internal IntPtr NativePointer { get; }

        private Invoker(IntPtr nativePointer)
        {
            NativePointer = nativePointer;
        }

        public void Destroy()
        {
            Alt.Server.Resource.CSharpResourceImpl.DestroyInvoker(NativePointer);
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