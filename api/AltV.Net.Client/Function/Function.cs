using System.Reflection;
using System.Runtime.CompilerServices;
using AltV.Net.Client.Elements.Args;

namespace AltV.Net.Client.Function
{
    public class Function
    {
        private readonly Delegate _delegate;

        private readonly Type _returnType;

        private readonly FunctionArgumentType[] _args;

        private readonly Type? _paramArgumentType = null;

        private Function(Delegate @delegate, Type returnType, FunctionArgumentType[] args, Type? paramArgumentType)
        {
            this._delegate = @delegate;
            this._returnType = returnType;
            this._args = args;
            this._paramArgumentType = paramArgumentType;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private IEnumerable<object?> CalculateInvokeValues(IReadOnlyList<MValueConst> values)
        {
            var length = values.Count;
            
            var argsLength = _args.Length;
            var invokeValues = new List<object?>();

            if (length < argsLength)
            {
                for (var i = length; i < argsLength; i++)
                {
                    var arg = _args[i];
                    if (!arg.Nullable && !arg.HasDefault) throw new Exception("Invalid event call: not enough arguments");
                }
            }
            
            for (var i = 0; i < _args.Length; i++)
            {
                var arg = _args[i];
                MValueConst? value = values.Count > i ? values[i] : null;
                
                if (arg.HasDefault && value is null) break;
                
                if ((arg.Nullable || arg.HasDefault) && (value is null || value.Value.type is MValueConst.Type.Nil or MValueConst.Type.None))
                {
                    invokeValues.Add(arg.HasDefault ? arg.DefaultValue : null);
                    continue;
                }

                if (value is null || value.Value.type is MValueConst.Type.Nil or MValueConst.Type.None) throw new Exception("Invalid event call: null argument at index " + i);

                invokeValues.Add(Convert.ChangeType(value.Value.ToObject(), arg.Type));
            }
            
            return invokeValues;
        }
        
        internal object? Call(MValueConst[] values)
        {
            var invokeValues = CalculateInvokeValues(values);
            return _delegate.DynamicInvoke(invokeValues.ToArray());
        }

        public static Function Create(Delegate action)
        {
            var parameters = action.Method.GetParameters();
            var paramArgument = parameters.Length > 0 && parameters.Last().IsDefined(typeof(ParamArrayAttribute), false) 
                ? parameters.Last().ParameterType 
                : null;
            
            return new Function(action, action.Method.ReturnType, parameters.Select(e => new FunctionArgumentType(e)).ToArray(), paramArgument);
        }
    }
}