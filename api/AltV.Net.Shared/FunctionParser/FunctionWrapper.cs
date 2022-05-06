using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Shared;

namespace AltV.Net.FunctionParser
{
    /// <summary>
    /// Converts the intptr args and result mvalues to objects
    /// </summary>
    internal class FunctionWrapper
    {
        private readonly ISharedCore core;
        private readonly MValueFunctionCallback function;

        public FunctionWrapper(ISharedCore core, MValueFunctionCallback function)
        {
            this.core = core;
            this.function = function;
        }

        public object Call(params object[] args)
        {
            var length = args.Length;
            var mValues = new MValueConst[length];
            core.CreateMValues(mValues, args);
            var argsPointers = Marshal.AllocHGlobal(length * IntPtr.Size);
            for (var i = 0; i < length; i++)
            {
                Marshal.WriteIntPtr(argsPointers, mValues[i].nativePointer);
            }

            var result = function(argsPointers, length);
            for (var i = 0; i < length; i++)
            {
                mValues[i].Dispose();
            }

            Marshal.FreeHGlobal(argsPointers);

            var resultMValue = new MValueConst(core, result);
            var resultObj = resultMValue.ToObject();
            resultMValue.Dispose();
            return resultObj;
        }
    }
}