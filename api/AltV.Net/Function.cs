using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.FunctionParser;
using AltV.Net.ObjectMethodExecutors;
using AltV.Net.ObjectMethodExecutors.ParameterValues;

namespace AltV.Net
{
    //TODO: when received MValue is from type null set the value to null
    public partial class Function
    {
        public delegate object Func(params object[] args);

        /*private delegate bool CallArgsLengthCheck(Type[] args, int requiredArgsCount, FunctionTypeInfo[] typeInfos,
            MValueConst[] values);

        private delegate bool CallArgsLengthCheckPlayer(Type[] args, int requiredArgsCount,
            FunctionTypeInfo[] typeInfos, IPlayer player,
            MValueConst[] values);*/

        //TODO: for high optimization add ParseBoolUnsafe ect. that doesn't contains the mValue type check for scenarios where we already had to check the mValue type
        // Returns null when function signature isn't supported
        public static Function Create<T>(T func) where T : Delegate
        {
            var genericArguments = func.GetType().GetGenericArguments();
            var parameters = func.Method.GetParameters();
            var returnType = func.Method.ReturnType;

            //TODO: check for unsupported types
            var constParsers = new FunctionMValueConstParser[parameters.Length];
            var objectParsers = new FunctionObjectParser[parameters.Length];
            var stringParsers = new FunctionStringParser[parameters.Length];
            var typeInfos = new FunctionTypeInfo[parameters.Length];
            var requiredArgsCount = 0;
            for (int i = 0, length = parameters.Length; i < length; i++)
            {
                var parameterInfo = parameters[i];
                var arg = parameterInfo.ParameterType;
                var typeInfo = typeInfos[i] = new FunctionTypeInfo(arg, parameterInfo);

                if (!typeInfo.IsNullable && !typeInfo.IsParamArray)
                {
                    requiredArgsCount++;
                }

                constParsers[i] = typeInfo.ConstParser;
                objectParsers[i] = typeInfo.ObjectParser;
                stringParsers[i] = typeInfo.StringParser;
                if (constParsers[i] == null || objectParsers[i] == null || stringParsers[i] == null)
                {
                    // Unsupported type
                    return null;
                }
            }

            for (int i = 0, length = typeInfos.Length; i < length; i++)
            {
                if (typeInfos[i].IsParamArray && i + 1 < length)
                {
                    throw new ArgumentException(
                        "params array needs to be at the end of the method. E.g. (int p1, int p2, params int[] args)");
                }

                if (!typeInfos[i].IsNullable || i + 1 >= length) continue;
                if (!typeInfos[i + 1].IsNullable && !typeInfos[i + 1].IsParamArray)
                {
                    throw new ArgumentException(
                        "Method nullable needs to be at the end of the method. E.g. (int p1, int? p2, int p3?).");
                }
            }

            return new Function(func, returnType, genericArguments, constParsers, objectParsers, stringParsers,
                typeInfos, requiredArgsCount);
        }

        /*private static bool CheckArgsLength(Type[] args, int requiredArgsCount, FunctionTypeInfo[] typeInfos,
            MValueConst[] values)
        {
            return values.Length >= requiredArgsCount;
        }

        private static bool CheckArgsLengthWithPlayer(Type[] args, int requiredArgsCount, FunctionTypeInfo[] typeInfos,
            IPlayer player,
            MValueConst[] values)
        {
            return values.Length + 1 >= requiredArgsCount && typeInfos[0].IsPlayer;
        }*/

        private readonly Delegate @delegate;

        private readonly Type returnType;

        private readonly Type[] args;

        private readonly FunctionMValueConstParser[] constParsers;

        private readonly FunctionObjectParser[] objectParsers;

        private readonly FunctionStringParser[] stringParsers;

        private readonly FunctionTypeInfo[] typeInfos;

        private readonly int requiredArgsCount;

        private readonly ObjectMethodExecutor objectMethodExecutor;

        private readonly object target;

        private Function(Delegate @delegate, Type returnType, Type[] args,
            FunctionMValueConstParser[] constParsers,
            FunctionObjectParser[] objectParsers, FunctionStringParser[] stringParsers, FunctionTypeInfo[] typeInfos,
            int requiredArgsCount)
        {
            this.@delegate = @delegate;
            this.returnType = returnType;
            this.args = args;
            this.constParsers = constParsers;
            this.objectParsers = objectParsers;
            this.stringParsers = stringParsers;
            this.typeInfos = typeInfos;
            this.requiredArgsCount = requiredArgsCount;

            var parameterDefaultValues = ParameterDefaultValues
                .GetParameterDefaultValues(@delegate.Method);

            objectMethodExecutor = ObjectMethodExecutor.Create(
                @delegate.Method,
                @delegate.Target?.GetType().GetTypeInfo(),
                parameterDefaultValues);
            target = @delegate.Target;
        }

        //TODO: make call async because it doesnt matter there is no concurrent problems inside
        //TODO: write function parser in cpp so it can do that natively without any native calls for mvalues (experimental)
        //TODO: register event callbacks to cpp as dynamic function pointers with void** so cpp knows the types it needs to check
        //TODO: add support for nullable args, these are reducing the required length, add support for default values as well
        //TODO: maybe cache var invokeValues = new object[length];
        internal object Call(MValueConst[] values)
        {
            var invokeValues = CalculateInvokeValues(values);

            var resultObj = @delegate.DynamicInvoke(invokeValues);
            return returnType == FunctionTypes.Void ? null : resultObj;
        }

        internal object Call(IPlayer player, MValueConst[] values)
        {
            var invokeValues = CalculateInvokeValues(player, values);

            var resultObj = @delegate.DynamicInvoke(invokeValues);
            return returnType == FunctionTypes.Void ? null : resultObj;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal object[] CalculateInvokeValues(IPlayer player, MValueConst[] values)
        {
            var length = values.Length;
            if (length + 1 < requiredArgsCount || !typeInfos[0].IsPlayer)
            {
                return null;
            }

            var argsLength = args.Length;
            var invokeValues = new object[argsLength];
            var parserValuesLength = Math.Min(requiredArgsCount, length);
            invokeValues[0] = player;
            for (var i = 1; i < parserValuesLength; i++)
            {
                invokeValues[i] = constParsers[i](in values[i - 1], args[i], typeInfos[i]);
            }

            for (var i = parserValuesLength; i < argsLength; i++)
            {
                invokeValues[i] = typeInfos[i].DefaultValue;
            }

            if (argsLength > 0)
            {
                var lastTypeInfo = typeInfos[^1];
                if (lastTypeInfo.IsParamArray)
                {
                    if (length > requiredArgsCount)
                    {
                        var remainingLength = length - requiredArgsCount - 1;
                        var remainingValues = lastTypeInfo.CreateArrayOfTypeExp(remainingLength);
                        var elementTypeInfo = lastTypeInfo.Element;
                        var elementConstParser = elementTypeInfo.ConstParser;
                        var elementType = lastTypeInfo.ElementType;
                        for (var i = 0; i < remainingLength; i++)
                        {
                            var elementObject = elementConstParser(values[i + requiredArgsCount - 1],
                                elementType, lastTypeInfo.Element);
                            var convertedElementObject = Convert.ChangeType(elementObject, elementType);
                            remainingValues.SetValue(convertedElementObject, i);
                        }

                        invokeValues[^1] = remainingValues;
                    }
                    else
                    {
                        var remainingValues = lastTypeInfo.EmptyArrayOfType;
                        invokeValues[^1] = remainingValues;
                    }
                }
            }

            return invokeValues;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal object[] CalculateInvokeValues(MValueConst[] values)
        {
            var length = values.Length;
            if (length < requiredArgsCount)
            {
                return null;
            }

            var argsLength = args.Length;
            var invokeValues = new object[argsLength];
            var parserValuesLength = Math.Min(requiredArgsCount, length);
            for (var i = 0; i < parserValuesLength; i++)
            {
                invokeValues[i] = constParsers[i](in values[i], args[i], typeInfos[i]);
            }

            for (var i = parserValuesLength; i < argsLength; i++)
            {
                invokeValues[i] = typeInfos[i].DefaultValue;
            }

            if (argsLength > 0)
            {
                var lastTypeInfo = typeInfos[^1];
                if (lastTypeInfo.IsParamArray)
                {
                    if (length > requiredArgsCount)
                    {
                        var remainingLength = length - requiredArgsCount;
                        var remainingValues = lastTypeInfo.CreateArrayOfTypeExp(remainingLength);
                        var elementTypeInfo = lastTypeInfo.Element;
                        var elementConstParser = elementTypeInfo.ConstParser;
                        var elementType = lastTypeInfo.ElementType;
                        if (elementConstParser != null)
                        {
                            for (var i = 0; i < remainingLength; i++)
                            {
                                var elementObject = elementConstParser(in values[i + requiredArgsCount],
                                    elementType, lastTypeInfo.Element);
                                var convertedElementObject = Convert.ChangeType(elementObject, elementType);
                                remainingValues.SetValue(convertedElementObject, i);
                            }
                        }

                        invokeValues[^1] = remainingValues;
                    }
                    else
                    {
                        var remainingValues = lastTypeInfo.EmptyArrayOfType;
                        invokeValues[^1] = remainingValues;
                    }
                }
            }

            return invokeValues;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal object[] CalculateInvokeValues(object[] values)
        {
            var length = values.Length;
            if (length < requiredArgsCount)
            {
                return null;
            }

            var argsLength = args.Length;
            var invokeValues = new object[argsLength];
            var parserValuesLength = Math.Min(requiredArgsCount, length);
            for (var i = 0; i < parserValuesLength; i++)
            {
                invokeValues[i] = objectParsers[i](values[i], args[i], typeInfos[i]);
            }

            for (var i = parserValuesLength; i < argsLength; i++)
            {
                invokeValues[i] = typeInfos[i].DefaultValue;
            }

            if (argsLength > 0)
            {
                var lastTypeInfo = typeInfos[^1];
                if (lastTypeInfo.IsParamArray)
                {
                    if (length > requiredArgsCount)
                    {
                        var remainingLength = length - requiredArgsCount;
                        var remainingValues = lastTypeInfo.CreateArrayOfTypeExp(remainingLength);
                        var elementTypeInfo = lastTypeInfo.Element;
                        var elementConstParser = elementTypeInfo.ObjectParser;
                        var elementType = lastTypeInfo.ElementType;
                        if (elementConstParser != null)
                        {
                            for (var i = 0; i < remainingLength; i++)
                            {
                                var elementObject = elementConstParser(values[i + requiredArgsCount],
                                    elementType, lastTypeInfo.Element);
                                var convertedElementObject = Convert.ChangeType(elementObject, elementType);
                                remainingValues.SetValue(convertedElementObject, i);
                            }
                        }

                        invokeValues[^1] = remainingValues;
                    }
                    else
                    {
                        var remainingValues = lastTypeInfo.EmptyArrayOfType;
                        invokeValues[^1] = remainingValues;
                    }
                }
            }

            return invokeValues;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal object[] CalculateInvokeValues(IPlayer player, object[] values)
        {
            var length = values.Length;
            if (length + 1 < requiredArgsCount || !typeInfos[0].IsPlayer)
            {
                return null;
            }

            var argsLength = args.Length;
            var invokeValues = new object[argsLength];
            invokeValues[0] = player;
            var parserValuesLength = Math.Max(1, Math.Min(requiredArgsCount, length));
            for (var i = 1; i < parserValuesLength; i++)
            {
                invokeValues[i] = objectParsers[i](values[i - 1], args[i], typeInfos[i]);
            }

            for (var i = parserValuesLength; i < argsLength; i++)
            {
                invokeValues[i] = typeInfos[i].DefaultValue;
            }

            if (argsLength > 0)
            {
                var lastTypeInfo = typeInfos[^1];
                if (lastTypeInfo.IsParamArray)
                {
                    if (length > requiredArgsCount)
                    {
                        var remainingLength = length - requiredArgsCount - 1;
                        var remainingValues = lastTypeInfo.CreateArrayOfTypeExp(remainingLength);
                        var elementTypeInfo = lastTypeInfo.Element;
                        var elementConstParser = elementTypeInfo.ObjectParser;
                        var elementType = lastTypeInfo.ElementType;
                        for (var i = 0; i < remainingLength; i++)
                        {
                            var elementObject = elementConstParser(values[i + requiredArgsCount - 1],
                                elementType, lastTypeInfo.Element);
                            var convertedElementObject = Convert.ChangeType(elementObject, elementType);
                            remainingValues.SetValue(convertedElementObject, i);
                        }

                        invokeValues[^1] = remainingValues;
                    }
                    else
                    {
                        var remainingValues = lastTypeInfo.EmptyArrayOfType;
                        invokeValues[^1] = remainingValues;
                    }
                }
            }

            return invokeValues;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object[] CalculateInvokeValues(IPlayer player, string[] values)
        {
            var length = values.Length;
            Console.WriteLine("commands:" + string.Join(",", values));
            Console.WriteLine("commands length:" + length);
            Console.WriteLine("commands requiredArgsCount:" + requiredArgsCount);
            if (length + 1 < requiredArgsCount || !typeInfos[0].IsPlayer)
            {
                return null;
            }

            var argsLength = args.Length;
            var invokeValues = new object[argsLength];
            invokeValues[0] = player;
            var parserValuesLength = Math.Min(requiredArgsCount, length);
            for (var i = 1; i < parserValuesLength; i++)
            {
                invokeValues[i] = stringParsers[i](values[i - 1], args[i], typeInfos[i]);
            }

            for (var i = parserValuesLength; i < argsLength; i++)
            {
                invokeValues[i] = typeInfos[i].DefaultValue;
            }

            if (argsLength > 0)
            {
                var lastTypeInfo = typeInfos[^1];
                if (lastTypeInfo.IsParamArray)
                {
                    if (length > requiredArgsCount)
                    {
                        var remainingLength = length - requiredArgsCount - 1;
                        var remainingValues = lastTypeInfo.CreateArrayOfTypeExp(remainingLength);
                        var elementTypeInfo = lastTypeInfo.Element;
                        var elementConstParser = elementTypeInfo.StringParser;
                        var elementType = lastTypeInfo.ElementType;
                        for (var i = 0; i < remainingLength; i++)
                        {
                            var elementObject = elementConstParser(values[i + requiredArgsCount - 1],
                                elementType, lastTypeInfo.Element);
                            var convertedElementObject = Convert.ChangeType(elementObject, elementType);
                            remainingValues.SetValue(convertedElementObject, i);
                        }

                        invokeValues[^1] = remainingValues;
                    }
                    else
                    {
                        var remainingValues = lastTypeInfo.EmptyArrayOfType;
                        invokeValues[^1] = remainingValues;
                    }
                }
            }

            return invokeValues;
        }


        public object Call(IPlayer player, string[] values)
        {
            var invokeValues = CalculateInvokeValues(player, values);

            //var resultObj = objectMethodExecutor.Execute(target, invokeValues);
            var resultObj = @delegate.DynamicInvoke(invokeValues);
            if (returnType == FunctionTypes.Void)
            {
                return null;
            }

            return resultObj;
        }

        internal void Invoke(object[] invokeValues, out MValueConst resultMValue)
        {
            var result = @delegate.DynamicInvoke(invokeValues);
            if (returnType == FunctionTypes.Void)
            {
                resultMValue = MValueConst.Nil;
                return;
            }

            Alt.Server.CreateMValue(out resultMValue, result);
        }

        internal async Task<MValueConst> InvokeAsync(object[] invokeValues)
        {
            if (returnType == FunctionTypes.Void)
            {
                @delegate.DynamicInvoke(invokeValues);
                return MValueConst.Nil;
            }

            //TODO: fix async with result
            var result = await (Task<object>) @delegate.DynamicInvoke(invokeValues);
            if (returnType == FunctionTypes.Void) return MValueConst.Nil;
            Alt.Server.CreateMValue(out var mValueConst, result);
            return mValueConst;
        }

        public void InvokeNoResult(object[] invokeValues)
        {
            @delegate.DynamicInvoke(invokeValues);
        }

        internal Task InvokeTaskOrNull(object[] invokeValues)
        {
            var result = @delegate.DynamicInvoke(invokeValues);
            if (result is Task task)
            {
                return task;
            }

            return null;
        }

        internal void Call(IntPtr[] nativePointers, out IntPtr result)
        {
            var length = nativePointers.Length;
            var mValues = new MValueConst[length];
            for (var i = 0; i < length; i++)
            {
                mValues[i] = new MValueConst(nativePointers[i]);
            }

            Alt.Server.CreateMValue(out var resultMValue, Call(mValues));
            result = resultMValue.nativePointer;
        }
    }
}