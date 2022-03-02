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
                    if (!arg.IsNullable && !arg.HasDefault) throw new Exception($"Invalid event call: not enough arguments at index {i}");
                }
            }
            
            for (var i = 0; i < argsLength; i++)
            {
                var arg = _args[i];
                
                if (i == argsLength - 1 && _paramArgumentType != null)
                {
                    var paramArray = Array.CreateInstance(_paramArgumentType, values.Count - i);
                    for (var j = 0; j < values.Count - i; j++)
                    {
                        paramArray.SetValue(Convert.ChangeType(values[i + j].ToObject(), _paramArgumentType), j);
                    }
                    
                    invokeValues.Add(paramArray);
                    break;
                }
                
                MValueConst? value = values.Count > i ? values[i] : null;
                
                if (arg.HasDefault && value is null) break;
                
                if ((arg.IsNullable || arg.HasDefault) && (value is null || value.Value.type is MValueConst.Type.Nil or MValueConst.Type.None))
                {
                    invokeValues.Add(arg.DefaultValue);
                    continue;
                }

                if (value is null || value.Value.type is MValueConst.Type.Nil or MValueConst.Type.None) throw new Exception("Invalid event call: null argument at index " + i);

                var objValue = value.Value.ToObject();
                invokeValues.Add(objValue is null ? null : Convert.ChangeType(objValue, arg.Type));
            }

            if (length < argsLength)
            {
                for (var i = length; i < argsLength; i++)
                {
                    invokeValues.Add(_args[i].DefaultValue);
                }
            }
            
            return invokeValues;
        }
        
        internal object? Call(MValueConst[] values)
        {
            var invokeValues = CalculateInvokeValues(values);
            return _delegate.DynamicInvoke(invokeValues.ToArray());
        }
        
        internal object? CallCatching(MValueConst[] values, string exceptionLocation)
        {
            try
            {
                return this.Call(values);
            }
            catch (TargetInvocationException exception)
            {
                Alt.Log($"Exception at {exceptionLocation}: {exception.InnerException}");
                return null;
            }
            catch (Exception exception)
            {
                Alt.Log($"Exception at {exceptionLocation}: {exception}");
                return null;
            }
        }

        public static Function Create(Delegate action)
        {
            var parameters = action.Method.GetParameters();
            var paramArgument = parameters.Length > 0 && parameters.Last().IsDefined(typeof(ParamArrayAttribute), false) 
                ? parameters.Last().ParameterType.GetElementType() 
                : null;
            
            return new Function(action, action.Method.ReturnType, parameters.Select(e => new FunctionArgumentType(e)).ToArray(), paramArgument);
        }
    }
}