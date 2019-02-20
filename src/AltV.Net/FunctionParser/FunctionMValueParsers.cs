using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.FunctionParser
{
    internal static class FunctionMValueParsers
    {
        public static object CreateArray(Type type, MValue[] mValues, IBaseEntityPool baseEntityPool,
            FunctionTypeInfo typeInfo)
        {
            var length = mValues.Length;
            if (type == FunctionTypes.Obj)
            {
                var array = new object[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (!ValidateMValueType(currMValue.type, type, typeInfo?.Element))
                        return null;
                    array[i] = ParseObject(ref currMValue, type, baseEntityPool, typeInfo?.Element);
                }

                return array;
            }

            if (type == FunctionTypes.Bool)
            {
                var array = new bool[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (currMValue.type == MValue.Type.BOOL)
                    {
                        array[i] = currMValue.GetBool();
                    }
                    else
                    {
                        array[i] = default;
                    }

                    array[i] = currMValue.GetBool();
                }

                return array;
            }

            if (type == FunctionTypes.Int)
            {
                var array = new int[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (currMValue.type == MValue.Type.INT)
                    {
                        array[i] = (int) currMValue.GetInt();
                    }
                    else
                    {
                        array[i] = default;
                    }
                }

                return array;
            }

            if (type == FunctionTypes.Long)
            {
                var array = new long[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (currMValue.type == MValue.Type.INT)
                    {
                        array[i] = currMValue.GetInt();
                    }
                    else
                    {
                        array[i] = default;
                    }
                }

                return array;
            }

            if (type == FunctionTypes.UInt)
            {
                var array = new uint[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (currMValue.type == MValue.Type.UINT)
                    {
                        array[i] = (uint) currMValue.GetUint();
                    }
                    else
                    {
                        array[i] = default;
                    }
                }

                return array;
            }

            if (type == FunctionTypes.ULong)
            {
                var array = new ulong[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (currMValue.type == MValue.Type.UINT)
                    {
                        array[i] = currMValue.GetUint();
                    }
                    else
                    {
                        array[i] = default;
                    }
                }

                return array;
            }

            if (type == FunctionTypes.Double)
            {
                var array = new double[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (currMValue.type == MValue.Type.DOUBLE)
                    {
                        array[i] = currMValue.GetDouble();
                    }
                    else
                    {
                        array[i] = default;
                    }
                }

                return array;
            }

            if (type == FunctionTypes.String)
            {
                var array = new string[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (currMValue.type == MValue.Type.STRING)
                    {
                        array[i] = currMValue.GetString();
                    }
                    else
                    {
                        array[i] = null;
                    }
                }

                return array;
            }

            var typeArray = System.Array.CreateInstance(type, length);
            for (var i = 0; i < length; i++)
            {
                var currMValue = mValues[i];
                if (!ValidateMValueType(currMValue.type, type, typeInfo?.Element))
                {
                    typeArray.SetValue(null, i);
                }
                else
                {
                    var obj = ParseObject(ref currMValue, type, baseEntityPool, typeInfo?.Element);
                    typeArray.SetValue(obj is IConvertible ? Convert.ChangeType(obj, type) : obj, i);
                }
            }

            return typeArray;
        }

        public static object ParseBool(ref MValue mValue, Type type, IBaseEntityPool baseEntityPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.BOOL)
            {
                return mValue.GetBool();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseInt(ref MValue mValue, Type type, IBaseEntityPool baseEntityPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.INT)
            {
                return (int) mValue.GetInt();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseLong(ref MValue mValue, Type type, IBaseEntityPool baseEntityPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.INT)
            {
                return mValue.GetInt();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseUInt(ref MValue mValue, Type type, IBaseEntityPool baseEntityPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.UINT)
            {
                return (uint) mValue.GetUint();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseULong(ref MValue mValue, Type type, IBaseEntityPool baseEntityPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.UINT)
            {
                return mValue.GetUint();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseFloat(ref MValue mValue, Type type, IBaseEntityPool baseEntityPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.DOUBLE)
            {
                return (float) mValue.GetDouble();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseDouble(ref MValue mValue, Type type, IBaseEntityPool baseEntityPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.DOUBLE)
            {
                return mValue.GetDouble();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseString(ref MValue mValue, Type type, IBaseEntityPool baseEntityPool,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type != MValue.Type.STRING ? null : mValue.GetString();
        }

        public static object ParseObject(ref MValue mValue, Type type, IBaseEntityPool baseEntityPool,
            FunctionTypeInfo typeInfo)
        {
            //return mValue.ToObject(entityPool);
            switch (mValue.type)
            {
                case MValue.Type.NIL:
                    return null;
                case MValue.Type.BOOL:
                    return ParseBool(ref mValue, type, baseEntityPool, typeInfo);
                case MValue.Type.INT:
                    return type == FunctionTypes.Int
                        ? ParseInt(ref mValue, type, baseEntityPool, typeInfo)
                        : ParseLong(ref mValue, type, baseEntityPool, typeInfo);
                case MValue.Type.UINT:
                    return type == FunctionTypes.UInt
                        ? ParseUInt(ref mValue, type, baseEntityPool, typeInfo)
                        : ParseULong(ref mValue, type, baseEntityPool, typeInfo);
                case MValue.Type.DOUBLE:
                    return type == FunctionTypes.Float
                        ? ParseFloat(ref mValue, type, baseEntityPool, typeInfo)
                        : ParseDouble(ref mValue, type, baseEntityPool, typeInfo);
                case MValue.Type.STRING:
                    return ParseString(ref mValue, type, baseEntityPool, typeInfo);
                case MValue.Type.LIST:
                    return ParseArray(ref mValue, type, baseEntityPool, typeInfo);
                case MValue.Type.ENTITY:
                    return ParseEntity(ref mValue, type, baseEntityPool, typeInfo);
                case MValue.Type.DICT:
                    return ParseDictionary(ref mValue, type, baseEntityPool, typeInfo);
                case MValue.Type.FUNCTION:
                    return ParseFunction(ref mValue, type, baseEntityPool, typeInfo);
                default:
                    return false;
            }
        }

        public static object ParseArray(ref MValue mValue, Type type, IBaseEntityPool baseEntityPool,
            FunctionTypeInfo typeInfo)
        {
            // Types doesn't match
            if (mValue.type != MValue.Type.LIST) return null;
            var mValueList = mValue.GetList();
            var elementType = typeInfo?.ElementType ?? (
                                  type.GetElementType() ??
                                  type); // Object has no element type so we have to use the same type again
            return CreateArray(elementType, mValueList, baseEntityPool, typeInfo);
        }

        public static object ParseEntity(ref MValue mValue, Type type, IBaseEntityPool baseEntityPool,
            FunctionTypeInfo typeInfo)
        {
            // Types doesn't match
            if (mValue.type != MValue.Type.ENTITY) return null;
            var entityType = EntityType.Undefined;

            var entityPointer = mValue.GetEntityPointer(ref entityType);

            if (entityPointer == IntPtr.Zero) return null;
            if (!ValidateEntityType(entityType, type, typeInfo))
            {
                return null;
            }

            if (!baseEntityPool.GetOrCreate(entityPointer, entityType, out var entity))
            {
                return null;
            }

            return entity;
        }

        public static object ParseDictionary(ref MValue mValue, Type type, IBaseEntityPool baseEntityPool,
            FunctionTypeInfo typeInfo)
        {
            // Types doesn't match
            if (mValue.type != MValue.Type.DICT) return null;
            var args = typeInfo?.GenericArguments ?? type.GetGenericArguments();
            if (args.Length != 2) return null;
            var keyType = args[0];
            if (keyType != FunctionTypes.String) return null;
            var valueType = args[1];
            var stringViewArrayRef = StringViewArray.Nil;
            var valueArrayRef = MValueArray.Nil;
            AltVNative.MValueGet.MValue_GetDict(ref mValue, ref stringViewArrayRef, ref valueArrayRef);
            var strings = stringViewArrayRef.ToArray();
            var valueArray = valueArrayRef.ToArray();
            var length = strings.Length;
            if (valueArrayRef.Size != (ulong) length) // Value size != key size should never happen
            {
                return null;
            }

            MValue currMValue;

            if (valueType == FunctionTypes.Obj)
            {
                var dict = new Dictionary<string, object>();
                for (var i = 0; i < length; i++)
                {
                    dict[strings[i]] = ParseObject(ref valueArray[i], valueType, baseEntityPool,
                        typeInfo?.DictionaryValue);
                }

                return dict;
            }

            if (valueType == FunctionTypes.Bool)
            {
                var dict = new Dictionary<string, bool>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.BOOL)
                    {
                        dict[strings[i]] = currMValue.GetBool();
                    }
                    else
                    {
                        dict[strings[i]] = default;
                    }
                }

                return dict;
            }

            if (valueType == FunctionTypes.Int)
            {
                var dict = new Dictionary<string, int>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.INT)
                    {
                        dict[strings[i]] = (int) currMValue.GetInt();
                    }
                    else
                    {
                        dict[strings[i]] = default;
                    }
                }

                return dict;
            }

            if (valueType == FunctionTypes.Long)
            {
                var dict = new Dictionary<string, long>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.INT)
                    {
                        dict[strings[i]] = currMValue.GetInt();
                    }
                    else
                    {
                        dict[strings[i]] = default;
                    }
                }

                return dict;
            }

            if (valueType == FunctionTypes.UInt)
            {
                var dict = new Dictionary<string, uint>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.UINT)
                    {
                        dict[strings[i]] = (uint) currMValue.GetUint();
                    }
                    else
                    {
                        dict[strings[i]] = default;
                    }
                }

                return dict;
            }

            if (valueType == FunctionTypes.ULong)
            {
                var dict = new Dictionary<string, ulong>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.UINT)
                    {
                        dict[strings[i]] = currMValue.GetUint();
                    }
                    else
                    {
                        dict[strings[i]] = default;
                    }
                }

                return dict;
            }

            if (valueType == FunctionTypes.Float)
            {
                var dict = new Dictionary<string, float>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.DOUBLE)
                    {
                        dict[strings[i]] = (float) currMValue.GetDouble();
                    }
                    else
                    {
                        dict[strings[i]] = default;
                    }
                }

                return dict;
            }

            if (valueType == FunctionTypes.Float)
            {
                var dict = new Dictionary<string, float>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.DOUBLE)
                    {
                        dict[strings[i]] = (float) currMValue.GetDouble();
                    }
                    else
                    {
                        dict[strings[i]] = default;
                    }
                }

                return dict;
            }

            if (valueType == FunctionTypes.Double)
            {
                var dict = new Dictionary<string, double>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.DOUBLE)
                    {
                        dict[strings[i]] = currMValue.GetDouble();
                    }
                    else
                    {
                        dict[strings[i]] = default;
                    }
                }

                return dict;
            }

            if (valueType == FunctionTypes.String)
            {
                var dict = new Dictionary<string, string>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.STRING)
                    {
                        dict[strings[i]] = currMValue.GetString();
                    }
                    else
                    {
                        dict[strings[i]] = null;
                    }
                }

                return dict;
            }

            var dictType = typeInfo?.DictType ?? typeof(Dictionary<,>).MakeGenericType(keyType, valueType);
            var typedDict = typeInfo?.CreateDictionary() ??
                            (System.Collections.IDictionary) Activator.CreateInstance(dictType);
            for (var i = 0; i < length; i++)
            {
                currMValue = valueArray[i];
                if (!ValidateMValueType(currMValue.type, valueType, typeInfo?.DictionaryValue))
                {
                    typedDict[strings[i]] = null;
                }
                else
                {
                    var obj = ParseObject(ref currMValue, valueType, baseEntityPool, typeInfo?.DictionaryValue);
                    if (obj is IConvertible)
                    {
                        typedDict[strings[i]] = Convert.ChangeType(obj, valueType);
                    }
                    else
                    {
                        typedDict[strings[i]] = obj;
                    }
                }
            }

            return typedDict;
        }

        public static object ParseFunction(ref MValue mValue, Type type, IBaseEntityPool baseEntityPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.FUNCTION)
            {
                return (Function.Func) new FunctionWrapper(mValue.GetFunction()).Call;
            }

            // Types doesn't match
            return null;
        }

        public static bool ValidateEntityType(EntityType entityType, Type type, FunctionTypeInfo typeInfo)
        {
            if (type == FunctionTypes.Obj)
            {
                return true;
            }

            switch (entityType)
            {
                case EntityType.Blip:
                    return typeInfo?.IsBlip ??
                           type == FunctionTypes.Blip || type.GetInterfaces().Contains(FunctionTypes.Blip);
                case EntityType.Player:
                    return typeInfo?.IsPlayer ?? type == FunctionTypes.Player ||
                           type.GetInterfaces().Contains(FunctionTypes.Player);
                case EntityType.Vehicle:
                    return typeInfo?.IsVehicle ?? type == FunctionTypes.Vehicle ||
                           type.GetInterfaces().Contains(FunctionTypes.Vehicle);
                case EntityType.Checkpoint:
                    return typeInfo?.IsCheckpoint ?? type == FunctionTypes.Checkpoint ||
                           type.GetInterfaces().Contains(FunctionTypes.Checkpoint);
                default:
                    return false;
            }
        }

        public static bool ValidateMValueType(MValue.Type valueType, Type type, FunctionTypeInfo typeInfo)
        {
            if (type == FunctionTypes.Obj)
            {
                // object[] or object accepts anything
                return true;
            }

            switch (valueType)
            {
                case MValue.Type.NIL:
                    return !type.IsPrimitive ||
                           type == FunctionTypes.String; //TODO: check if there are more none nullable types
                /*case MValue.Type.NIL:
                     // Validate if the given type supports null values, otherwise the type isn't compatible
                     if (typeInfo == null)
                     {
                         return type == String || type == Obj || type.BaseType == Array ||
                                type.Name.StartsWith("Dictionary") || type.GetInterfaces().Contains(Entity);
                     }
                     else
                     {
                         return type == String || type == Obj || typeInfo.IsList || typeInfo.IsDict || typeInfo.IsEntity;
                     }*/
                //case MValue.Type.NIL:
                //    return true;
                case MValue.Type.BOOL:
                    return type == FunctionTypes.Bool;
                case MValue.Type.INT:
                    return type == FunctionTypes.Int || type == FunctionTypes.UInt;
                case MValue.Type.UINT:
                    return type == FunctionTypes.UInt || type == FunctionTypes.ULong;
                case MValue.Type.DOUBLE:
                    return type == FunctionTypes.Double;
                case MValue.Type.STRING:
                    return type == FunctionTypes.String;
                case MValue.Type.LIST:
                    return typeInfo?.IsList ?? type.BaseType == FunctionTypes.Array;
                case MValue.Type.ENTITY:
                    return typeInfo?.IsEntity ?? type.GetInterfaces().Contains(FunctionTypes.Entity);
                case MValue.Type.FUNCTION:
                    return false; //TODO: needs to be Func or Action
                case MValue.Type.DICT:
                    return typeInfo?.IsDict ?? type.Name.StartsWith("Dictionary");
                default:
                    return false;
            }
        }
    }

    internal delegate object FunctionMValueParser(ref MValue mValue, Type type, IBaseEntityPool baseEntityPool,
        FunctionTypeInfo typeInfo);
}