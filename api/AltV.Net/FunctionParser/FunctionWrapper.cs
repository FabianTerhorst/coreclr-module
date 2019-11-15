using System;
using AltV.Net.Elements.Args;

namespace AltV.Net.FunctionParser
{
    /// <summary>
    /// Converts the intptr args and result mvalues to objects
    /// </summary>
    internal class FunctionWrapper
    {
        private readonly MValueFunctionCallback function;

        public FunctionWrapper(MValueFunctionCallback function)
        {
            this.function = function;
        }

        public object Call(params object[] args)
        {
            var length = args.Length;
            var mValues = new MValueConst[length];
            Alt.Server.CreateMValues(mValues, args);
            var mValuePointers = new IntPtr[length];
            for (var i = 0; i < length; i++)
            {
                mValuePointers[i] = mValues[i].nativePointer;
            }

            var result = IntPtr.Zero;
            function(mValuePointers, ref result);
            for (var i = 0; i < length; i++)
            {
                mValues[i].Dispose();
            }

            var resultMValue = new MValueConst(result);
            var resultObj = resultMValue.ToObject();
            resultMValue.Dispose();
            return resultObj;
        }
    }
}