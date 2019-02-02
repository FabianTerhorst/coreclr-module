using System;

namespace AltV.Net.Native
{
    public class Invoker : IDisposable
    {
        public static Invoker Create(MValue.Function function)
        {
            return new Invoker(Alt.MValueCreate.Invoker_Create(function));
        }

        internal IntPtr NativePointer { get; }

        private Invoker(IntPtr nativePointer)
        {
            NativePointer = nativePointer;
        }

        public void Destroy()
        {
            Alt.MValueCreate.Invoker_Destroy(NativePointer);
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