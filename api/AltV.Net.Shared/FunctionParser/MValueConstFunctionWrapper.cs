using System;
using AltV.Net.Elements.Args;
using AltV.Net.Native;
using AltV.Net.Shared;

namespace AltV.Net.FunctionParser
{
    internal class MValueConstFunctionWrapper
    {
        private readonly ISharedCore core;
        private readonly IntPtr nativePointer;

        public MValueConstFunctionWrapper(ISharedCore core, IntPtr nativePointer)
        {
            this.core = core;
            this.nativePointer = nativePointer;
        }

        public object Call(params object[] args)
        {
            unsafe
            {
                var length = (ulong) args.Length;
                var mValues = new IntPtr[length];
                for (ulong i = 0; i < length; i++)
                {
                    core.CreateMValue(out var mValueElement, args[i]);
                    mValues[i] = mValueElement.nativePointer;
                }

                var result =
                    new MValueConst(core, core.Library.Shared.MValueConst_CallFunction(core.NativePointer, nativePointer,
                        mValues, length)).ToObject();
                for (ulong i = 0; i < length; i++)
                {
                    core.Library.Shared.MValueConst_Delete(mValues[i]);
                }

                return result;
            }
        }
    }
}