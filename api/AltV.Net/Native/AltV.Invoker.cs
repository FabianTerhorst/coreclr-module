using System;
using AltV.Net.Elements.Args;

//TODO: maybe cache invoker here instead of using cpp?
namespace AltV.Net.Native
{
    internal class Invoker : IDisposable
    {
        public static Invoker Create(MValue.Function function)
        {
            return new Invoker(AltNative.MValueCreate.Invoker_Create(function));
        }

        internal IntPtr NativePointer { get; }

        private Invoker(IntPtr nativePointer)
        {
            NativePointer = nativePointer;
        }

        public void Destroy()
        {
            AltNative.MValueCreate.Invoker_Destroy(NativePointer);
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