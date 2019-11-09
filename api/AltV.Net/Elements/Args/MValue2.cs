using System;
using AltV.Net.Native;

namespace AltV.Net.Elements.Args
{
    /// <summary>
    /// MValue's created via ICore after MValue's
    /// </summary>
    public struct MValue2: IDisposable
    {
        public static MValue2 Nil = new MValue2(MValueConst.Type.NIL, IntPtr.Zero);
        
        public readonly IntPtr nativePointer;
        public readonly MValueConst.Type type;

        public MValue2(MValueConst.Type type, IntPtr nativePointer)
        {
            this.nativePointer = nativePointer;
            this.type = type;
        }

        public MValue2(IntPtr nativePointer)
        {
            this.nativePointer = nativePointer;
            this.type = (MValueConst.Type) AltNative.MValueNative.MValue_GetType(nativePointer);
        }

        public void Dispose()
        {
            // Nil types have zero int ptr to reduce allocations on heap
            if (nativePointer == IntPtr.Zero) return;
            AltNative.MValueNative.MValue_Delete(nativePointer);
        }
    }
}