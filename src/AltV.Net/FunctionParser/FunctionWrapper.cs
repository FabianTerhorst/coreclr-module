using AltV.Net.Native;
using System.Linq;

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
            var mValueArgs = MValue.Create((from obj in args
                select MValue.CreateFromObject(obj)
                into mValue
                where mValue.HasValue
                select mValue.Value).ToArray());
            function(ref mValueArgs, ref result);
            return result.ToObject(Alt.Module.BaseEntityPool);
        }
    }
}