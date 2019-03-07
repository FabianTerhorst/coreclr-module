using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

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
            if (value is MValue.Function function)
            {
                return (Function.Func) new FunctionWrapper(function).Call;
            }

            return null;
        }

        public static object ParseBool(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value is bool ? value : null;
        }

        public static object ParseInt(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value is long l ? (int) l : default;
        }

        public static object ParseLong(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value is long ? value : null;
        }

        public static object ParseUInt(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value is ulong ul ? (uint) ul : default;
        }

        public static object ParseULong(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value is ulong ? value : null;
        }

        public static object ParseFloat(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value is double d ? (float) d : default;
        }

        public static object ParseDouble(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value is double ? value : null;
        }

        public static object ParseString(object value, Type type, FunctionTypeInfo typeInfo)
        {
            return value is string ? value : null;
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

            var typedArray = System.Array.CreateInstance(elementType, length);

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
                    if (MValueAdapters.FromObject(curr, elementType, out var result))
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
            System.Collections.IDictionary typedDictionary;
            if (typeInfo != null)
            {
                typedDictionary = typeInfo.CreateDictionary();
            }
            else
            {
                var dictType = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);
                typedDictionary = (System.Collections.IDictionary) Activator.CreateInstance(dictType);
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
                    if (MValueAdapters.FromObject(obj, valueType, out var result))
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
    }

    internal delegate object FunctionObjectParser(object value, Type type, FunctionTypeInfo typeInfo);
}