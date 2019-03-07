using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.FunctionParser
{
    internal class FunctionWrapper
    {
        private readonly MValue.Function function;

        public FunctionWrapper(MValue.Function function)
        {
            this.function = function;
        }

        public object Call(params object[] args)
        {
            var result = MValue.Nil;

            var length = args.Length;
            var mValues = new MValue[length];
            for (var i = 0; i < length; i++)
            {
                mValues[i] = MValue.CreateFromObject(args[i]);
            }

            var mValueArgs = MValue.Create(mValues);
            function(ref mValueArgs, ref result);
            return result.ToObject(Alt.Module.BaseBaseObjectPool);
        }
    }
}