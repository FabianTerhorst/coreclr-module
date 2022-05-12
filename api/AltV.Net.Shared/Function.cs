using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.FunctionParser;
using AltV.Net.ObjectMethodExecutors;
using AltV.Net.ObjectMethodExecutors.ParameterValues;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Entities;

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

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T>(T func) where T : Delegate
        {
            AltShared.Core.LogWarning("Function.Create<T>(T func) is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create(AltShared.Core, func);
        }
        
        //TODO: for high optimization add ParseBoolUnsafe ect. that doesn't contains the mValue type check for scenarios where we already had to check the mValue type
        // Returns null when function signature isn't supported
        public static Function Create<T>(ISharedCore core, T func) where T : Delegate
        {
            var genericArguments = func.GetType().GetGenericArguments();
            var parameters = func.Method.GetParameters();
            var returnType = func.Method.ReturnType;
            if (returnType != FunctionTypes.Void)
            {
                genericArguments = genericArguments.SkipLast(1).ToArray();
            }

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

                if (!typeInfo.IsNullable && !typeInfo.IsParamArray && !parameterInfo.HasDefaultValue)
                {
                    requiredArgsCount++;
                }

                constParsers[i] = typeInfo.ConstParser;
                objectParsers[i] = typeInfo.ObjectParser;
                stringParsers[i] = typeInfo.StringParser;
                if (constParsers[i] == null || objectParsers[i] == null || stringParsers[i] == null)
                {
                    AltShared.Core.LogWarning("Failed to construct a function because of unsupported argument type " + arg + " at index " + i);
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

            return new Function(core, func, returnType, genericArguments, constParsers, objectParsers, stringParsers,
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

        internal readonly ISharedCore core;
        internal readonly Delegate @delegate;

        internal readonly Type returnType;

        internal readonly Type[] args;

        internal readonly FunctionMValueConstParser[] constParsers;

        internal readonly FunctionObjectParser[] objectParsers;

        internal readonly FunctionStringParser[] stringParsers;

        internal readonly FunctionTypeInfo[] typeInfos;

        internal readonly int requiredArgsCount;

        private readonly ObjectMethodExecutor objectMethodExecutor;

        private readonly object target;

        private Function(ISharedCore core, Delegate @delegate, Type returnType, Type[] args,
            FunctionMValueConstParser[] constParsers,
            FunctionObjectParser[] objectParsers, FunctionStringParser[] stringParsers, FunctionTypeInfo[] typeInfos,
            int requiredArgsCount)
        {
            this.core = core;
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
            if (invokeValues == null) return null;

            var resultObj = @delegate.DynamicInvoke(invokeValues);
            return returnType == FunctionTypes.Void ? null : resultObj;
        }

        internal object CallCatching(MValueConst[] values, string exceptionLocation)
        {
            try
            {
                return this.Call(values);
            }
            catch (TargetInvocationException exception)
            {
                core.LogError($"Exception at {exceptionLocation}: {exception.InnerException}");
                return null;
            }
            catch (Exception exception)
            {
                core.LogError($"Exception at {exceptionLocation}: {exception}");
                return null;
            }
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
            var parserValuesLength = Math.Min(argsLength, length);
            for (var i = 0; i < parserValuesLength; i++)
            {
                invokeValues[i] = constParsers[i](core, in values[i], args[i], typeInfos[i]);
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
                                var elementObject = elementConstParser(core, in values[i + requiredArgsCount],
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
            var parserValuesLength = Math.Min(argsLength, length);
            for (var i = 0; i < parserValuesLength; i++)
            {
                invokeValues[i] = objectParsers[i](core, values[i], args[i], typeInfos[i]);
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
                                var elementObject = elementConstParser(core, values[i + requiredArgsCount],
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

        internal void Invoke(object[] invokeValues, out MValueConst resultMValue)
        {
            var result = @delegate.DynamicInvoke(invokeValues);
            if (returnType == FunctionTypes.Void)
            {
                resultMValue = MValueConst.Nil;
                return;
            }

            core.CreateMValue(out resultMValue, result);
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
            core.CreateMValue(out var mValueConst, result);
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

        internal IntPtr Call(IntPtr pointer, long size)
        {
            var currArgs = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, currArgs, 0, (int) size);
            }
            
            var mValues = new MValueConst[size];
            for (var i = 0; i < size; i++)
            {
                mValues[i] = new MValueConst(core, currArgs[i]);
            }

            core.CreateMValue(out var resultMValue, Call(mValues));
            if (resultMValue.nativePointer != IntPtr.Zero) return resultMValue.nativePointer;
            core.CreateMValueNil(out resultMValue);
            return resultMValue.nativePointer;
        }
    }
}