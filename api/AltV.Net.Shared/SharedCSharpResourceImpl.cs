using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;

namespace AltV.Net.Shared
{
    public class SharedCSharpResourceImpl : ISharedCSharpResourceImpl
    {
        internal readonly IntPtr NativePointer;
        
        protected ISharedCore core;
        
        private readonly Dictionary<IntPtr, GCHandle> invokers = new();

        public IntPtr CreateInvoker(MValueFunctionCallback function)
        {
            IntPtr invoker;
            unsafe
            {
                invoker = core.Library.Shared.Invoker_Create(NativePointer, function);
            }

            invokers[invoker] = GCHandle.Alloc(function);

            return invoker;
        }

        public void DestroyInvoker(IntPtr invoker)
        {
            if (invokers.Remove(invoker, out var gcHandle))
            {
                gcHandle.Free();
            }

            unsafe
            {
                core.Library.Shared.Invoker_Destroy(NativePointer, invoker);
            }
        }

        public SharedCSharpResourceImpl(ISharedCore core, IntPtr nativePointer)
        {
            this.core = core;
            this.NativePointer = nativePointer;
        }
    }
}