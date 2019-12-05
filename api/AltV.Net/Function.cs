using System;
using System.Linq;
using System.Reflection;
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

        private delegate bool CallArgsLengthCheck(Type[] args, int requiredArgsCount, FunctionTypeInfo[] typeInfos,
            MValueConst[] values);

        private delegate bool CallArgsLengthCheckPlayer(Type[] args, int requiredArgsCount,
            FunctionTypeInfo[] typeInfos, IPlayer player,
            MValueConst[] values);

        //TODO: for high optimization add ParseBoolUnsafe ect. that doesn't contains the mValue type check for scenarios where we already had to check the mValue type

        //TODO: add support for own function arguments parser for significant performance improvements with all benefits
        // Returns null when function signature isn't supported
        public static Function Create<T>(T func) where T : Delegate
        {
            var type = func.GetType();
            var genericArguments = type.GetGenericArguments();
            Type returnType;
            if (type.Name.StartsWith("Func"))
            {
                // Return type is last generic argument
                // Function never has empty generic arguments, so no need for size check, but we do it anyway
                if (genericArguments.Length == 0)
                {
                    returnType = FunctionTypes.Void;
                }
                else
                {
                    returnType = genericArguments[genericArguments.Length - 1];
                    genericArguments = genericArguments.SkipLast(1).ToArray();
                }
            }
            else
            {
                returnType = FunctionTypes.Void;
            }

            //TODO: check for unsupported types
            //TODO: check if last type is a object[] and add all to it that didnt fit with length, like (string bla, object[] args) 
            //TODO: add parameter type attribute to annotate object[] with 
            var constParsers = new FunctionMValueConstParser[genericArguments.Length];
            var objectParsers = new FunctionObjectParser[genericArguments.Length];
            var stringParsers = new FunctionStringParser[genericArguments.Length];
            var typeInfos = new FunctionTypeInfo[genericArguments.Length];
            var requiredArgsCount = 0;
            for (int i = 0, length = genericArguments.Length; i < length; i++)
            {
                var arg = genericArguments[i];
                var typeInfo = new FunctionTypeInfo(arg);
                if (typeInfo.IsNullable)
                {
                    arg = typeInfo.NullableType;
                }
                typeInfos[i] = typeInfo;

                if (!typeInfo.IsNullable && !typeInfo.IsEventParams)
                {
                    requiredArgsCount++;
                }

                if (arg == FunctionTypes.Obj)
                {
                    //TODO: use MValue.ToObject here 
                    constParsers[i] = FunctionMValueConstParsers.ParseObject;
                    objectParsers[i] = FunctionObjectParsers.ParseObject;
                    stringParsers[i] = FunctionStringParsers.ParseObject;
                }
                else if (arg == FunctionTypes.Bool)
                {
                    constParsers[i] = FunctionMValueConstParsers.ParseBool;
                    objectParsers[i] = FunctionObjectParsers.ParseBool;
                    stringParsers[i] = FunctionStringParsers.ParseBool;
                }
                else if (arg == FunctionTypes.Int)
                {
                    constParsers[i] = FunctionMValueConstParsers.ParseInt;
                    objectParsers[i] = FunctionObjectParsers.ParseInt;
                    stringParsers[i] = FunctionStringParsers.ParseInt;
                }
                else if (arg == FunctionTypes.Long)
                {
                    constParsers[i] = FunctionMValueConstParsers.ParseLong;
                    objectParsers[i] = FunctionObjectParsers.ParseLong;
                    stringParsers[i] = FunctionStringParsers.ParseLong;
                }
                else if (arg == FunctionTypes.UInt)
                {
                    constParsers[i] = FunctionMValueConstParsers.ParseUInt;
                    objectParsers[i] = FunctionObjectParsers.ParseUInt;
                    stringParsers[i] = FunctionStringParsers.ParseUInt;
                }
                else if (arg == FunctionTypes.ULong)
                {
                    constParsers[i] = FunctionMValueConstParsers.ParseULong;
                    objectParsers[i] = FunctionObjectParsers.ParseULong;
                    stringParsers[i] = FunctionStringParsers.ParseULong;
                }
                else if (arg == FunctionTypes.Float)
                {
                    constParsers[i] = FunctionMValueConstParsers.ParseFloat;
                    objectParsers[i] = FunctionObjectParsers.ParseFloat;
                    stringParsers[i] = FunctionStringParsers.ParseFloat;
                }
                else if (arg == FunctionTypes.Double)
                {
                    constParsers[i] = FunctionMValueConstParsers.ParseDouble;
                    objectParsers[i] = FunctionObjectParsers.ParseDouble;
                    stringParsers[i] = FunctionStringParsers.ParseDouble;
                }
                else if (arg == FunctionTypes.String)
                {
                    constParsers[i] = FunctionMValueConstParsers.ParseString;
                    objectParsers[i] = FunctionObjectParsers.ParseString;
                    stringParsers[i] = FunctionStringParsers.ParseString;
                }
                else if (arg.BaseType == FunctionTypes.Array)
                {
                    constParsers[i] = FunctionMValueConstParsers.ParseArray;
                    objectParsers[i] = FunctionObjectParsers.ParseArray;
                    stringParsers[i] = FunctionStringParsers.ParseArray;
                }
                else if (typeInfo.IsEntity)
                {
                    constParsers[i] = FunctionMValueConstParsers.ParseEntity;
                    objectParsers[i] = FunctionObjectParsers.ParseEntity;
                    stringParsers[i] = FunctionStringParsers.ParseEntity;
                }
                else if (typeInfo.IsDict)
                {
                    constParsers[i] = FunctionMValueConstParsers.ParseDictionary;
                    objectParsers[i] = FunctionObjectParsers.ParseDictionary;
                    stringParsers[i] = FunctionStringParsers.ParseDictionary;
                }
                else if (typeInfo.IsMValueConvertible)
                {
                    constParsers[i] = FunctionMValueConstParsers.ParseConvertible;
                    objectParsers[i] = FunctionObjectParsers.ParseConvertible;
                    stringParsers[i] = FunctionStringParsers.ParseConvertible;
                }
                else if (arg == FunctionTypes.FunctionType)
                {
                    constParsers[i] = FunctionMValueConstParsers.ParseFunction;
                    objectParsers[i] = FunctionObjectParsers.ParseFunction;
                    stringParsers[i] = FunctionStringParsers.ParseFunction;
                }
                else if (typeInfo.IsEnum)
                {
                    constParsers[i] = FunctionMValueConstParsers.ParseEnum;
                    objectParsers[i] = FunctionObjectParsers.ParseEnum;
                }
                else
                {
                    // Unsupported type
                    return null;
                }
            }

            for (int i = 0, length = typeInfos.Length; i < length; i++)
            {
                if (!typeInfos[i].IsNullable || i + 1 >= length) continue;
                if (!typeInfos[i + 1].IsNullable && !typeInfos[i + 1].IsEventParams)
                {
                    throw new ArgumentException(
                        "Method nullable needs to be at the end of the method. E.g. (int p1, int? p2, int p3?).");
                }
            }

            CallArgsLengthCheck callArgsLengthCheck = CheckArgsLength;
            CallArgsLengthCheckPlayer callArgsLengthCheckPlayer = CheckArgsLengthWithPlayer;

            if (typeInfos.Length > 0)
            {
                var lastTypeInfo = typeInfos[typeInfos.Length - 1];
                if (lastTypeInfo.IsEventParams)
                {
                    if (lastTypeInfo.IsList)
                    {
                        throw new ArgumentException("EventParams needs to be a array.");
                    }

                    callArgsLengthCheck = CheckArgsLengthWithEventParams;
                    callArgsLengthCheckPlayer = CheckArgsLengthWithPlayerWithEventParams;
                }
            }

            return new Function(func, returnType, genericArguments, constParsers, objectParsers, stringParsers, typeInfos,
                callArgsLengthCheck, callArgsLengthCheckPlayer, requiredArgsCount);
        }

        private static bool CheckArgsLength(Type[] args, int requiredArgsCount, FunctionTypeInfo[] typeInfos,
            MValueConst[] values)
        {
            return values.Length >= requiredArgsCount;
        }

        private static bool CheckArgsLengthWithPlayer(Type[] args, int requiredArgsCount, FunctionTypeInfo[] typeInfos,
            IPlayer player,
            MValueConst[] values)
        {
            return values.Length + 1 >= requiredArgsCount && typeInfos[0].IsPlayer;
        }

        private static bool CheckArgsLengthWithEventParams(Type[] args, int requiredArgsCount,
            FunctionTypeInfo[] typeInfos, MValueConst[] values)
        {
            return values.Length >= requiredArgsCount;
        }

        private static bool CheckArgsLengthWithPlayerWithEventParams(Type[] args, int requiredArgsCount,
            FunctionTypeInfo[] typeInfos,
            IPlayer player,
            MValueConst[] values)
        {
            return values.Length + 1 >= requiredArgsCount && typeInfos[0].IsPlayer;
        }

        private readonly Delegate @delegate;

        private readonly Type returnType;

        private readonly Type[] args;

        private readonly FunctionMValueConstParser[] constParsers;

        private readonly FunctionObjectParser[] objectParsers;

        private readonly FunctionStringParser[] stringParsers;

        private readonly FunctionTypeInfo[] typeInfos;

        private readonly CallArgsLengthCheck callArgsLengthCheck;

        private readonly CallArgsLengthCheckPlayer callArgsLengthCheckPlayer;

        private readonly int requiredArgsCount;

        private readonly ObjectMethodExecutor objectMethodExecutor;

        private readonly object target;

        private Function(Delegate @delegate, Type returnType, Type[] args,
            FunctionMValueConstParser[] constParsers,
            FunctionObjectParser[] objectParsers, FunctionStringParser[] stringParsers, FunctionTypeInfo[] typeInfos, CallArgsLengthCheck callArgsLengthCheck,
            CallArgsLengthCheckPlayer callArgsLengthCheckPlayer, int requiredArgsCount)
        {
            this.@delegate = @delegate;
            this.returnType = returnType;
            this.args = args;
            this.constParsers = constParsers;
            this.objectParsers = objectParsers;
            this.stringParsers = stringParsers;
            this.typeInfos = typeInfos;
            this.callArgsLengthCheck = callArgsLengthCheck;
            this.callArgsLengthCheckPlayer = callArgsLengthCheckPlayer;
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
        /*internal MValue Call(MValue[] values)
        {
            var length = values.Length;
            if (length < requiredArgsCount) return MValue.Nil;
            var argsLength = args.Length;
            var invokeValues = new object[argsLength];
            var parserValuesLength = Math.Min(argsLength, length);
            for (var i = 0; i < parserValuesLength; i++)
            {
                invokeValues[i] = parsers[i](ref values[i], args[i], typeInfos[i]);
            }

            for (var i = parserValuesLength; i < argsLength; i++)
            {
                invokeValues[i] = typeInfos[i].DefaultValue;
            }
            
            //TODO: fill remaining values in event params

            var result = @delegate.DynamicInvoke(invokeValues);
            if (returnType == FunctionTypes.Void) return MValue.Nil;
            return MValue.CreateFromObject(result);
        }*/
        
        internal object Call(MValueConst[] values)
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
                invokeValues[i] = constParsers[i](in values[i], args[i], typeInfos[i]);
            }

            for (var i = parserValuesLength; i < argsLength; i++)
            {
                invokeValues[i] = typeInfos[i].DefaultValue;
            }
            
            //TODO: fill remaining values in event params

            var resultObj = @delegate.DynamicInvoke(invokeValues);
            if (returnType == FunctionTypes.Void)
            {
                return null;
            }

            return resultObj;
        }

        /*internal MValue Call(IPlayer player, MValue[] values)
        {
            var length = values.Length;
            if (length + 1 != args.Length) return MValue.Nil;
            if (!typeInfos[0].IsPlayer) return MValue.Nil;
            var invokeValues = new object[length + 1];
            invokeValues[0] = player;
            for (var i = 0; i < length; i++)
            {
                invokeValues[i + 1] =
                    parsers[i + 1](ref values[i], args[i + 1], typeInfos[i + 1]);
            }

            var result = @delegate.DynamicInvoke(invokeValues);
            if (returnType == FunctionTypes.Void) return MValue.Nil;
            return MValue.CreateFromObject(result);
        }*/
        
        internal object Call(IPlayer player, MValueConst[] values)
        {
            var length = values.Length;
            if (length + 1 != args.Length)
            {
                return null;
            }

            if (!typeInfos[0].IsPlayer)
            {
                return null;
            }
            var invokeValues = new object[length + 1];
            invokeValues[0] = player;
            for (var i = 0; i < length; i++)
            {
                invokeValues[i + 1] =
                    constParsers[i + 1](in values[i], args[i + 1], typeInfos[i + 1]);
            }

            var resultObj = @delegate.DynamicInvoke(invokeValues);
            if (returnType == FunctionTypes.Void)
            {
                return null;
            }

            return resultObj;
        }

        /*internal object[] CalculateInvokeValues(IPlayer player, MValue[] values)
        {
            var length = values.Length;
            if (length + 1 != args.Length) return null;
            if (!typeInfos[0].IsPlayer) return null;
            var invokeValues = new object[length + 1];
            invokeValues[0] = player;
            for (var i = 0; i < length; i++)
            {
                invokeValues[i + 1] =
                    parsers[i + 1](ref values[i], args[i + 1], typeInfos[i + 1]);
            }


            return invokeValues;
        }*/
        
        internal object[] CalculateInvokeValues(IPlayer player, MValueConst[] values)
        {
            var length = values.Length;
            if (length + 1 != args.Length) return null;
            if (!typeInfos[0].IsPlayer) return null;
            var invokeValues = new object[length + 1];
            invokeValues[0] = player;
            for (var i = 0; i < length; i++)
            {
                invokeValues[i + 1] =
                    constParsers[i + 1](in values[i], args[i + 1], typeInfos[i + 1]);
            }


            return invokeValues;
        }

        /*internal object[] CalculateInvokeValues(MValue[] values)
        {
            var length = values.Length;
            if (length != args.Length) return null;
            var invokeValues = new object[length];
            for (var i = 0; i < length; i++)
            {
                invokeValues[i] = parsers[i](ref values[i], args[i], typeInfos[i]);
            }

            return invokeValues;
        }*/
        
        internal object[] CalculateInvokeValues(MValueConst[] values)
        {
            var length = values.Length;
            if (length != args.Length) return null;
            var invokeValues = new object[length];
            for (var i = 0; i < length; i++)
            {
                invokeValues[i] = constParsers[i](in values[i], args[i], typeInfos[i]);
            }

            return invokeValues;
        }

        internal object[] CalculateInvokeValues(object[] values)
        {
            var length = values.Length;
            if (length != args.Length) return null;
            var invokeValues = new object[length];
            for (var i = 0; i < length; i++)
            {
                invokeValues[i] = objectParsers[i](values[i], args[i], typeInfos[i]);
            }

            return invokeValues;
        }

        internal object[] CalculateInvokeValues(object[] values, IPlayer player)
        {
            var length = values.Length;
            if (length + 1 != args.Length) return null;
            if (!typeInfos[0].IsPlayer) return null;
            var invokeValues = new object[length + 1];
            invokeValues[0] = player;
            for (var i = 0; i < length; i++)
            {
                invokeValues[i + 1] = objectParsers[i + 1](values[i], args[i + 1], typeInfos[i + 1]);
            }

            return invokeValues;
        }
        
        public object[] CalculateStringInvokeValues(string[] values, IPlayer player)
        {
            var length = values.Length;
            if (length + 1 != args.Length)
            {
                return null;
            }

            if (!typeInfos[0].IsPlayer)
            {
                return null;
            }
            var invokeValues = new object[length + 1];
            invokeValues[0] = player;
            for (var i = 0; i < length; i++)
            {
                invokeValues[i + 1] = stringParsers[i + 1](values[i], args[i + 1], typeInfos[i + 1]);
            }

            return invokeValues;
        }
        
        
        public object Call(string[] values, IPlayer player)
        {
            var length = values.Length;
            if (length + 1 < requiredArgsCount)
            {
                return null;
            }
            var argsLength = args.Length;
            var invokeValues = new object[argsLength];
            invokeValues[0] = player;
            var parserValuesLength = Math.Min(argsLength, length);
            for (var i = 0; i < parserValuesLength; i++)
            {
                invokeValues[i + 1] = stringParsers[i + 1](values[i], args[i + 1], typeInfos[i + 1]);
            }

            for (var i = parserValuesLength; i < (argsLength - 1); i++)
            {
                invokeValues[i + 1] = typeInfos[i + 1].DefaultValue;
            }

            //TODO: fill remaining values in event params

            //var resultObj = objectMethodExecutor.Execute(target, invokeValues);
            var resultObj = @delegate.DynamicInvoke(invokeValues);
            if (returnType == FunctionTypes.Void)
            {
                return null;
            }

            return resultObj;
        }


        /*internal MValue Invoke(object[] invokeValues)
        {
            var result = @delegate.DynamicInvoke(invokeValues);
            if (returnType == FunctionTypes.Void) return MValue.Nil;
            return MValue.CreateFromObject(result);
        }*/
        
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

        /*internal async Task<MValue> InvokeAsync(object[] invokeValues)
        {
            if (returnType == FunctionTypes.Void)
            {
                @delegate.DynamicInvoke(invokeValues);
                return MValue.Nil;
            }

            //TODO: fix async with result
            var result = await (Task<object>) @delegate.DynamicInvoke(invokeValues);
            if (returnType == FunctionTypes.Void) return MValue.Nil;
            return MValue.CreateFromObject(result);
        }*/
        
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

        internal void Call(IntPtr[] valueArgs, ref IntPtr result)
        {
            var length = valueArgs.Length;
            var mValues = new MValueConst[length];
            for (int i = 0; i < length; i++)
            {
                mValues[i] = new MValueConst(valueArgs[i]);
            }
            Alt.Server.CreateMValue(out var resultMValue, Call(mValues));
            result = resultMValue.nativePointer;
        }

        internal void call(IntPtr[] args, ref IntPtr result)
        {
            Call(args, ref result);
        }
    }
}