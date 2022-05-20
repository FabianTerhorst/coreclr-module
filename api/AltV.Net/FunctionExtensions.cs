using System;
using System.Runtime.CompilerServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.FunctionParser;

namespace AltV.Net
{
    public static class FunctionExtensions
    {
        public static object Call(this Function function, IPlayer player, string[] values)
        {
            var invokeValues = function.CalculateInvokeValues(player, values);

            if (invokeValues == null) return null;
            //var resultObj = objectMethodExecutor.Execute(target, invokeValues);
            object resultObj;
            try
            {
                resultObj = function.@delegate.DynamicInvoke(invokeValues);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                resultObj = null;
            }

            if (function.returnType == FunctionTypes.Void)
            {
                return null;
            }

            return resultObj;
        }
        
        public static object Call(this Function function, IPlayer player, MValueConst[] values)
        {
            var invokeValues = function.CalculateInvokeValues(player, values);
            if (invokeValues == null) return null;

            var resultObj = function.@delegate.DynamicInvoke(invokeValues);
            return function.returnType == FunctionTypes.Void ? null : resultObj;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static object[] CalculateInvokeValues(this Function function, IPlayer player, MValueConst[] values)
        {
            var length = values.Length;
            if (length + 1 < function.requiredArgsCount || !function.typeInfos[0].IsPlayer)
            {
                return null;
            }

            var argsLength = function.args.Length;
            var invokeValues = new object[argsLength];
            var parserValuesLength = Math.Max(1, Math.Min(argsLength, length + 1));
            invokeValues[0] = player;
            for (var i = 1; i < parserValuesLength; i++)
            {
                invokeValues[i] = function.constParsers[i](function.core, in values[i - 1], function.args[i], function.typeInfos[i]);
            }

            for (var i = parserValuesLength; i < argsLength; i++)
            {
                invokeValues[i] = function.typeInfos[i].DefaultValue;
            }

            if (argsLength > 0)
            {
                var lastTypeInfo = function.typeInfos[^1];
                if (lastTypeInfo.IsParamArray)
                {
                    if (length + 1 > function.requiredArgsCount)
                    {
                        var remainingLength = length - function.requiredArgsCount + 1;
                        var remainingValues = lastTypeInfo.CreateArrayOfTypeExp(remainingLength);
                        var elementTypeInfo = lastTypeInfo.Element;
                        var elementConstParser = elementTypeInfo.ConstParser;
                        var elementType = lastTypeInfo.ElementType;
                        for (var i = 0; i < remainingLength; i++)
                        {
                            var elementObject = elementConstParser(function.core, values[i + function.requiredArgsCount - 1],
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
        internal static object[] CalculateInvokeValues(this Function function, IPlayer player, object[] values)
        {
            var length = values.Length;
            if (length + 1 < function.requiredArgsCount || !function.typeInfos[0].IsPlayer)
            {
                return null;
            }

            var argsLength = function.args.Length;
            var invokeValues = new object[argsLength];
            invokeValues[0] = player;
            var parserValuesLength = Math.Max(1, Math.Min(argsLength, length + 1));
            for (var i = 1; i < parserValuesLength; i++)
            {
                invokeValues[i] = function.objectParsers[i](function.core, values[i - 1], function.args[i], function.typeInfos[i]);
            }

            for (var i = parserValuesLength; i < argsLength; i++)
            {
                invokeValues[i] = function.typeInfos[i].DefaultValue;
            }

            if (argsLength > 0)
            {
                var lastTypeInfo = function.typeInfos[^1];
                if (lastTypeInfo.IsParamArray)
                {
                    if (length + 1 > function.requiredArgsCount)
                    {
                        var remainingLength = length - function.requiredArgsCount + 1;
                        var remainingValues = lastTypeInfo.CreateArrayOfTypeExp(remainingLength);
                        var elementTypeInfo = lastTypeInfo.Element;
                        var elementConstParser = elementTypeInfo.ObjectParser;
                        var elementType = lastTypeInfo.ElementType;
                        for (var i = 0; i < remainingLength; i++)
                        {
                            var elementObject = elementConstParser(function.core, values[i + function.requiredArgsCount - 1],
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
        public static object[] CalculateInvokeValues(this Function function, IPlayer player, string[] values)
        {
            var length = values.Length;
            if (length + 1 < function.requiredArgsCount || !function.typeInfos[0].IsPlayer)
            {
                return null;
            }

            var argsLength = function.args.Length;
            var invokeValues = new object[argsLength];
            invokeValues[0] = player;
            var parserValuesLength = Math.Max(1, Math.Min(argsLength, length + 1));
            for (var i = 1; i < parserValuesLength; i++)
            {
                invokeValues[i] = function.stringParsers[i](function.core, values[i - 1], function.args[i], function.typeInfos[i]);
            }

            for (var i = parserValuesLength; i < argsLength; i++)
            {
                invokeValues[i] = function.typeInfos[i].DefaultValue;
            }

            if (argsLength > 0)
            {
                var lastTypeInfo = function.typeInfos[^1];
                if (lastTypeInfo.IsParamArray)
                {
                    if (length + 1 > function.requiredArgsCount)
                    {
                        var remainingLength = length - function.requiredArgsCount + 1;
                        var remainingValues = lastTypeInfo.CreateArrayOfTypeExp(remainingLength);
                        var elementTypeInfo = lastTypeInfo.Element;
                        var elementConstParser = elementTypeInfo.StringParser;
                        var elementType = lastTypeInfo.ElementType;
                        for (var i = 0; i < remainingLength; i++)
                        {
                            var elementObject = elementConstParser(function.core, values[i + function.requiredArgsCount - 1],
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
        
    }
}