using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.FunctionParser
{
    internal static class FunctionObjectParsers
    {
        public static object ParseObject(object value, Type type, FunctionTypeInfo typeInfo)
        {
            if (MValueAdapters.FromObject(value, type, out var result))
            {
                return result;
            }

            if (!type.IsValueType || type == FunctionTypes.String) return value;
            var defaultValue = typeInfo?.DefaultValue;
            return defaultValue ?? Activator.CreateInstance(type);
        }

        public static object ParseFunction(object value, Type type, FunctionTypeInfo typeInfo)
        {
            if (value is MValueFunctionCallback function)
            {
                return (Function.Func) new FunctionWrapper(function).Call;
            }

            return null;
        }

        public static object ParseBool(object value, Type type, FunctionTypeInfo typeInfo)
        {
            switch (value)
            {
                case bool _:
                    return value;
                case string stringValue:
                    switch (stringValue)
                    {
                        case "true":
                            return true;
                        case "false":
                            return false;
                    }

                    break;
            }

            return null;
        }

        public static object ParseInt(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value switch
            {
                long longValue => (int) longValue,
                ulong ulongValue => (int) ulongValue,
                double doubleValue => (int) doubleValue,
                string stringValue when int.TryParse(stringValue, out var intValue) => intValue,
                bool boolValue => boolValue ? 1 : 0,
                _ => default
            };
        }

        public static object ParseLong(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value switch
            {
                long longValue => longValue,
                ulong ulongValue => (long) ulongValue,
                double doubleValue => (long) doubleValue,
                string stringValue when long.TryParse(stringValue, out var longValue) => longValue,
                bool boolValue => boolValue ? 1L : 0L,
                _ => default
            };
        }

        public static object ParseUInt(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value switch
            {
                long longValue => (uint) longValue,
                ulong ulongValue => (uint) ulongValue,
                double doubleValue => (uint) doubleValue,
                string stringValue when uint.TryParse(stringValue, out var uintValue) => uintValue,
                bool boolValue => boolValue ? (uint) 1 : (uint) 0,
                _ => default
            };
        }

        public static object ParseULong(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value switch
            {
                long longValue => (ulong) longValue,
                ulong ulongValue => ulongValue,
                double doubleValue => (ulong) doubleValue,
                string stringValue when ulong.TryParse(stringValue, out var ulongValue) => ulongValue,
                bool boolValue => boolValue ? (ulong) 1L : (ulong) 0L,
                _ => default
            };
        }

        public static object ParseFloat(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value switch
            {
                long longValue => (float) longValue,
                ulong ulongValue => (float) ulongValue,
                double doubleValue => (float) doubleValue,
                string stringValue when float.TryParse(stringValue, out var floatValue) => floatValue,
                bool boolValue => boolValue ? (float) 1.0 : (float) 0.0,
                _ => default
            };
        }

        public static object ParseDouble(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value switch
            {
                long longValue => (double) longValue,
                ulong ulongValue => (double) ulongValue,
                double doubleValue => (double) doubleValue,
                string stringValue when double.TryParse(stringValue, out var doubleValue) => doubleValue,
                bool boolValue => boolValue ? (double) 1.0 : (double) 0.0,
                _ => default
            };
        }

        public static object ParseString(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value switch
            {
                long longValue => longValue.ToString(CultureInfo.InvariantCulture),
                ulong ulongValue => ulongValue.ToString(CultureInfo.InvariantCulture),
                double doubleValue =>doubleValue.ToString(CultureInfo.InvariantCulture),
                string stringValue => stringValue,
                bool boolValue => boolValue ? "true" : "false",
                _ => default
            };
        }

        public static object ParseEntity(object value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!(value is IEntity entity)) return null;

            return ValidateEntityType(entity.Type, type, typeInfo) ? entity : null;
        }

        public static bool ValidateEntityType(BaseObjectType baseObjectType, Type type, FunctionTypeInfo typeInfo)
        {
            if (type == FunctionTypes.Obj)
            {
                return true;
            }
            
            if (typeInfo?.IsEntity == true)
            {
                return true;
            }

            switch (baseObjectType)
            {
                case BaseObjectType.Blip:
                    return typeInfo?.IsBlip ??
                           type == FunctionTypes.Blip || type.GetInterfaces().Contains(FunctionTypes.Blip);
                case BaseObjectType.Player:
                    return typeInfo?.IsPlayer ?? type == FunctionTypes.Player ||
                           type.GetInterfaces().Contains(FunctionTypes.Player);
                case BaseObjectType.Vehicle:
                    return typeInfo?.IsVehicle ?? type == FunctionTypes.Vehicle ||
                           type.GetInterfaces().Contains(FunctionTypes.Vehicle);
                case BaseObjectType.ColShape:
                    return typeInfo?.IsColShape ?? type == FunctionTypes.ColShape ||
                           type.GetInterfaces().Contains(FunctionTypes.ColShape);
                case BaseObjectType.Checkpoint:
                    return typeInfo?.IsCheckpoint ?? type == FunctionTypes.Checkpoint ||
                           type.GetInterfaces().Contains(FunctionTypes.Checkpoint);
                default:
                    return false;
            }
        }

        public static object ParseArray(object value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!(value is object[] objects)) return null;
            var length = objects.Length;
            var elementType = typeInfo?.ElementType ?? type.GetElementType();
            if (elementType == FunctionTypes.Obj) return objects;

            if (elementType == FunctionTypes.String)
            {
                var stringArray = new string[length];
                for (var i = 0; i < length; i++)
                {
                    var obj = objects[i];
                    switch (obj)
                    {
                        case null:
                            stringArray[i] = null;
                            break;
                        case string stringValue:
                            stringArray[i] = stringValue;
                            break;
                    }
                }

                return stringArray;
            }

            //TODO: optimize like in MValueParsers for default arrays,
            //TODO: and add IVehicle, IPlayer, IBlip and ICheckpoint types as well for optimization in both parsers

            object defaultValue = null;
            var defaultValueSet = false;
            var nullableDefaultValue = typeInfo?.Element?.DefaultValue;
            if (nullableDefaultValue != null)
            {
                defaultValue = nullableDefaultValue;
                defaultValueSet = true;
            }

            var typedArray = Array.CreateInstance(elementType, length);

            for (var i = 0; i < length; i++)
            {
                var curr = objects[i];
                if (curr == null)
                {
                    if (defaultValueSet)
                    {
                        typedArray.SetValue(defaultValue, i);
                    }
                    else
                    {
                        if (type.IsValueType && type != FunctionTypes.String)
                        {
                            defaultValue = Activator.CreateInstance(type);
                        }

                        defaultValueSet = true;
                        typedArray.SetValue(defaultValue, i);
                    }
                }
                else
                {
                    if ((typeInfo?.Element?.IsMValueConvertible == true || typeInfo?.Element == null) &&
                        MValueAdapters.FromObject(curr, elementType, out var result))
                    {
                        typedArray.SetValue(result, i);
                    }
                    else
                    {
                        typedArray.SetValue(curr is IConvertible ? Convert.ChangeType(curr, elementType) : curr, i);
                    }
                }
            }

            return typedArray;
        }

        public static object ParseDictionary(object value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!(value is Dictionary<string, object> dictionary)) return null;
            var args = typeInfo?.GenericArguments ?? type.GetGenericArguments();
            if (args.Length != 2) return null;
            var keyType = args[0];
            if (keyType != FunctionTypes.String) return null;
            var valueType = args[1];
            IDictionary typedDictionary;
            if (typeInfo != null)
            {
                typedDictionary = typeInfo.CreateDictionary();
            }
            else
            {
                var dictType = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);
                typedDictionary = (IDictionary) Activator.CreateInstance(dictType);
            }

            object defaultValue = null;
            var defaultValueSet = false;
            var nullableDefaultValue = typeInfo?.DictionaryValue?.DefaultValue;
            if (nullableDefaultValue != null)
            {
                defaultValue = nullableDefaultValue;
                defaultValueSet = true;
            }

            foreach (var (key, obj) in dictionary)
            {
                if (obj == null)
                {
                    if (defaultValueSet)
                    {
                        typedDictionary[key] = defaultValue;
                    }
                    else
                    {
                        if (type.IsValueType && type != FunctionTypes.String)
                        {
                            defaultValue = Activator.CreateInstance(type);
                        }

                        defaultValueSet = true;
                        typedDictionary[key] = defaultValue;
                    }
                }
                else
                {
                    if ((typeInfo?.IsMValueConvertible == true || typeInfo == null) &&
                        MValueAdapters.FromObject(obj, valueType, out var result))
                    {
                        typedDictionary[key] = result;
                    }
                    else
                    {
                        if (obj is IConvertible)
                        {
                            typedDictionary[key] = Convert.ChangeType(obj, valueType);
                        }
                        else
                        {
                            typedDictionary[key] = obj;
                        }
                    }
                }
            }

            return typedDictionary;
        }

        public static object ParseConvertible(object value, Type type, FunctionTypeInfo typeInfo)
        {
            if (!(value is IDictionary dictionary)) return null;
            Alt.Server.CreateMValue(out var mValue, dictionary);
            if (!MValueAdapters.FromMValue(in mValue, type, out var obj))
            {
                mValue.Dispose();
                return null;
            }

            mValue.Dispose();
            return obj;
        }

        public static object ParseEnum(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return !Enum.TryParse(type, value.ToString(), true, out var enumObject) ? null : enumObject;
        }
        
        public static object ParsePosition(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value is Position position ? position : default;
        }
        
        public static object ParseRotation(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value is Position position ? (Rotation) position : default;
        }
        
        public static object ParseVector3(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value is Position position ? (Vector3) position : default;
        }
        
        public static object ParseRgba(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value is Rgba rgba ? rgba : default;
        }
        
        public static object ParseByteArray(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value is byte[] bytes ? bytes : default;
        }
    }

    internal delegate object FunctionObjectParser(object value, Type type, FunctionTypeInfo typeInfo);
}