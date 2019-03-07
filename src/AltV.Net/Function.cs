using System;
using System.Linq;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.FunctionParser;
using AltV.Net.Native;

namespace AltV.Net
{
    //TODO: when received MValue is from type null set the value to null
    public partial class Function
    {
        public delegate object Func(params object[] args);

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
            var parsers = new FunctionMValueParser[genericArguments.Length];
            var objectParsers = new FunctionObjectParser[genericArguments.Length];
            var typeInfos = new FunctionTypeInfo[genericArguments.Length];
            for (int i = 0, length = genericArguments.Length; i < length; i++)
            {
                var arg = genericArguments[i];
                var typeInfo = new FunctionTypeInfo(arg);
                typeInfos[i] = typeInfo;
                if (arg == FunctionTypes.Obj)
                {
                    //TODO: use MValue.ToObject here 
                    parsers[i] = FunctionMValueParsers.ParseObject;
                    objectParsers[i] = FunctionObjectParsers.ParseObject;
                }
                else if (arg == FunctionTypes.Bool)
                {
                    parsers[i] = FunctionMValueParsers.ParseBool;
                    objectParsers[i] = FunctionObjectParsers.ParseBool;
                }
                else if (arg == FunctionTypes.Int)
                {
                    parsers[i] = FunctionMValueParsers.ParseInt;
                    objectParsers[i] = FunctionObjectParsers.ParseInt;
                }
                else if (arg == FunctionTypes.Long)
                {
                    parsers[i] = FunctionMValueParsers.ParseLong;
                    objectParsers[i] = FunctionObjectParsers.ParseLong;
                }
                else if (arg == FunctionTypes.UInt)
                {
                    parsers[i] = FunctionMValueParsers.ParseUInt;
                    objectParsers[i] = FunctionObjectParsers.ParseUInt;
                }
                else if (arg == FunctionTypes.ULong)
                {
                    parsers[i] = FunctionMValueParsers.ParseULong;
                    objectParsers[i] = FunctionObjectParsers.ParseULong;
                }
                else if (arg == FunctionTypes.Float)
                {
                    parsers[i] = FunctionMValueParsers.ParseFloat;
                    objectParsers[i] = FunctionObjectParsers.ParseFloat;
                }
                else if (arg == FunctionTypes.Double)
                {
                    parsers[i] = FunctionMValueParsers.ParseDouble;
                    objectParsers[i] = FunctionObjectParsers.ParseDouble;
                }
                else if (arg == FunctionTypes.String)
                {
                    parsers[i] = FunctionMValueParsers.ParseString;
                    objectParsers[i] = FunctionObjectParsers.ParseString;
                }
                else if (arg.BaseType == FunctionTypes.Array)
                {
                    parsers[i] = FunctionMValueParsers.ParseArray;
                    objectParsers[i] = FunctionObjectParsers.ParseArray;
                }
                else if (typeInfo.IsEntity)
                {
                    parsers[i] = FunctionMValueParsers.ParseEntity;
                    objectParsers[i] = FunctionObjectParsers.ParseEntity;
                }
                else if (typeInfo.IsDict)
                {
                    parsers[i] = FunctionMValueParsers.ParseDictionary;
                    objectParsers[i] = FunctionObjectParsers.ParseDictionary;
                }
                else if (arg == FunctionTypes.FunctionType)
                {
                    parsers[i] = FunctionMValueParsers.ParseFunction;
                    objectParsers[i] = FunctionObjectParsers.ParseFunction;
                }
                else
                {
                    // Unsupported type
                    return null;
                }
            }

            return new Function(func, returnType, genericArguments, parsers, objectParsers, typeInfos);
        }

        private readonly Delegate @delegate;

        private readonly Type returnType;

        private readonly Type[] args;

        private readonly FunctionMValueParser[] parsers;

        private readonly FunctionObjectParser[] objectParsers;

        private readonly FunctionTypeInfo[] typeInfos;

        private Function(Delegate @delegate, Type returnType, Type[] args, FunctionMValueParser[] parsers,
            FunctionObjectParser[] objectParsers, FunctionTypeInfo[] typeInfos)
        {
            this.@delegate = @delegate;
            this.returnType = returnType;
            this.args = args;
            this.parsers = parsers;
            this.objectParsers = objectParsers;
            this.typeInfos = typeInfos;
        }

        //TODO: make call async because it doesnt matter there is no concurrent problems inside

        //TODO: write function parser in cpp so it can do that natively without any native calls for mvalues (experimental)
        //TODO: register event callbacks to cpp as dynamic function pointers with void** so cpp knows the types it needs to check

        //TODO: add support for nullable args, these are reducing the required length, add support for default values as well
        internal MValue Call(IBaseBaseObjectPool baseBaseObjectPool, MValue[] values)
        {
            var length = values.Length;
            if (length != args.Length) return MValue.Nil;
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            var invokeValues = new object[length];
            for (var i = 0; i < length; i++)
            {
                invokeValues[i] = parsers[i](ref values[i], args[i], baseBaseObjectPool, typeInfos[i]);
            }

            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //Alt.Log("ms:" + elapsedMs);

            var result = @delegate.DynamicInvoke(invokeValues);
            if (returnType == FunctionTypes.Void) return MValue.Nil;
            return MValue.CreateFromObject(result);
        }

        internal MValue Call(IPlayer player, IBaseBaseObjectPool baseBaseObjectPool, MValue[] values)
        {
            var length = values.Length;
            if (length + 1 != args.Length) return MValue.Nil;
            if (!typeInfos[0].IsPlayer) return MValue.Nil;
            var invokeValues = new object[length + 1];
            invokeValues[0] = player;
            for (var i = 0; i < length; i++)
            {
                invokeValues[i + 1] = parsers[i](ref values[i], args[i], baseBaseObjectPool, typeInfos[i]);
            }

            var result = @delegate.DynamicInvoke(invokeValues);
            if (returnType == FunctionTypes.Void) return MValue.Nil;
            return MValue.CreateFromObject(result);
        }

        internal object[] CalculateInvokeValues(IPlayer player, IBaseBaseObjectPool baseBaseObjectPool, MValue[] values)
        {
            var length = values.Length;
            if (length + 1 != args.Length) return null;
            if (!typeInfos[0].IsPlayer) return null;
            var invokeValues = new object[length + 1];
            invokeValues[0] = player;
            for (var i = 0; i < length; i++)
            {
                invokeValues[i + 1] = parsers[i](ref values[i], args[i], baseBaseObjectPool, typeInfos[i]);
            }

            return invokeValues;
        }

        internal object[] CalculateInvokeValues(IBaseBaseObjectPool baseBaseObjectPool, MValue[] values)
        {
            var length = values.Length;
            if (length != args.Length) return null;
            var invokeValues = new object[length];
            for (var i = 0; i < length; i++)
            {
                invokeValues[i] = parsers[i](ref values[i], args[i], baseBaseObjectPool, typeInfos[i]);
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

        internal MValue Invoke(object[] invokeValues)
        {
            var result = @delegate.DynamicInvoke(invokeValues);
            if (returnType == FunctionTypes.Void) return MValue.Nil;
            return MValue.CreateFromObject(result);
        }

        internal async Task<MValue> InvokeAsync(object[] invokeValues)
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
        }

        internal void InvokeNoResult(object[] invokeValues)
        {
            @delegate.DynamicInvoke(invokeValues);
        }

        internal MValue Call(IBaseBaseObjectPool baseBaseObjectPool, MValue valueArgs)
        {
            return valueArgs.type != MValue.Type.LIST ? MValue.Nil : Call(baseBaseObjectPool, valueArgs.GetList());
        }

        internal void call(ref MValue args, ref MValue result)
        {
            result = Call(Alt.Module.BaseBaseObjectPool, args);
        }
    }
}