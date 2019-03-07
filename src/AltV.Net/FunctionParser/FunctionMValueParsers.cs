using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.FunctionParser
{
    internal static class FunctionMValueParsers
    {
        public static object CreateArray(Type type, MValue[] mValues, IBaseBaseObjectPool baseBaseObjectPool,
            FunctionTypeInfo typeInfo)
        {
            var length = mValues.Length;
            if (type == FunctionTypes.Obj)
            {
                var array = new object[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (!TryParseObject(ref currMValue, type, baseBaseObjectPool, typeInfo?.Element, out var obj))
                    {
                        array[i] = obj;
                        //return null;
                    }
                    else
                    {
                        array[i] = obj;
                    }
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
                if (!TryParseObject(ref currMValue, type, baseBaseObjectPool, typeInfo?.Element, out var obj))
                {
                    typeArray.SetValue( /*null*/obj, i);
                }
                else
                {
                    typeArray.SetValue(obj is IConvertible ? Convert.ChangeType(obj, type) : obj, i);
                }
            }

            return typeArray;
        }

        public static object ParseBool(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.BOOL)
            {
                return mValue.GetBool();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseInt(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.INT)
            {
                return (int) mValue.GetInt();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseLong(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.INT)
            {
                return mValue.GetInt();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseUInt(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.UINT)
            {
                return (uint) mValue.GetUint();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseULong(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.UINT)
            {
                return mValue.GetUint();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseFloat(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.DOUBLE)
            {
                return (float) mValue.GetDouble();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseDouble(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.DOUBLE)
            {
                return mValue.GetDouble();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseString(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type != MValue.Type.STRING ? null : mValue.GetString();
        }

        public static object ParseObject(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
            FunctionTypeInfo typeInfo)
        {
            //return mValue.ToObject(entityPool);
            object obj;
            switch (mValue.type)
            {
                case MValue.Type.NIL:
                    return null;
                case MValue.Type.BOOL:
                    return ParseBool(ref mValue, type, baseBaseObjectPool, typeInfo);
                case MValue.Type.INT:
                    return type == FunctionTypes.Int
                        ? ParseInt(ref mValue, type, baseBaseObjectPool, typeInfo)
                        : ParseLong(ref mValue, type, baseBaseObjectPool, typeInfo);
                case MValue.Type.UINT:
                    return type == FunctionTypes.UInt
                        ? ParseUInt(ref mValue, type, baseBaseObjectPool, typeInfo)
                        : ParseULong(ref mValue, type, baseBaseObjectPool, typeInfo);
                case MValue.Type.DOUBLE:
                    return type == FunctionTypes.Float
                        ? ParseFloat(ref mValue, type, baseBaseObjectPool, typeInfo)
                        : ParseDouble(ref mValue, type, baseBaseObjectPool, typeInfo);
                case MValue.Type.STRING:
                    return ParseString(ref mValue, type, baseBaseObjectPool, typeInfo);
                case MValue.Type.LIST:
                    if (MValueAdapters.FromMValue(ref mValue, type, out obj))
                    {
                        return obj;
                    }

                    return ParseArray(ref mValue, type, baseBaseObjectPool, typeInfo);
                case MValue.Type.ENTITY:
                    return ParseEntity(ref mValue, type, baseBaseObjectPool, typeInfo);
                case MValue.Type.DICT:
                    if (MValueAdapters.FromMValue(ref mValue, type, out obj))
                    {
                        return obj;
                    }

                    return ParseDictionary(ref mValue, type, baseBaseObjectPool, typeInfo);
                case MValue.Type.FUNCTION:
                    return ParseFunction(ref mValue, type, baseBaseObjectPool, typeInfo);
                default:
                    return null;
            }
        }

        public static bool TryParseObject(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
            FunctionTypeInfo typeInfo, out object obj)
        {
            switch (mValue.type)
            {
                case MValue.Type.NIL:
                    obj = GetDefault(type, typeInfo);
                    return true;
                case MValue.Type.BOOL:
                    if (type == FunctionTypes.Obj || type == FunctionTypes.Bool)
                    {
                        obj = mValue.GetBool();
                        return true;
                    }
                    else
                    {
                        obj = GetDefault(type, typeInfo);
                        return false;
                    }
                case MValue.Type.INT:
                    if (type == FunctionTypes.Int)
                    {
                        obj = (int) mValue.GetInt();
                        return true;
                    }
                    else if (type == FunctionTypes.Obj || type == FunctionTypes.Long)
                    {
                        obj = mValue.GetInt();
                        return true;
                    }
                    else
                    {
                        obj = GetDefault(type, typeInfo);
                        return false;
                    }
                case MValue.Type.UINT:
                    if (type == FunctionTypes.UInt)
                    {
                        obj = (uint) mValue.GetUint();
                        return true;
                    }
                    else if (type == FunctionTypes.Obj || type == FunctionTypes.ULong)
                    {
                        obj = mValue.GetUint();
                        return true;
                    }
                    else
                    {
                        obj = mValue.GetDouble();
                        return false;
                    }
                case MValue.Type.DOUBLE:
                    if (type == FunctionTypes.Float)
                    {
                        obj = (float) mValue.GetDouble();
                        return true;
                    }
                    else if (type == FunctionTypes.Obj || type == FunctionTypes.Double)
                    {
                        obj = mValue.GetDouble();
                        return true;
                    }
                    else
                    {
                        obj = GetDefault(type, typeInfo);
                        return false;
                    }
                case MValue.Type.STRING:
                    if (type == FunctionTypes.Obj || type == FunctionTypes.String)
                    {
                        obj = mValue.GetString();
                        return true;
                    }

                    obj = GetDefault(type, typeInfo);
                    return false;
                case MValue.Type.LIST:
                    if (type == FunctionTypes.Obj || (typeInfo?.IsList ?? type.BaseType == FunctionTypes.Array))
                    {
                        if (MValueAdapters.FromMValue(ref mValue, type, out obj))
                        {
                            return true;
                        }

                        obj = ParseArray(ref mValue, type, baseBaseObjectPool, typeInfo);
                        return true;
                    }

                    obj = GetDefault(type, typeInfo);
                    return false;
                case MValue.Type.ENTITY:
                    if (type == FunctionTypes.Obj ||
                        (typeInfo?.IsEntity ?? type.GetInterfaces().Contains(FunctionTypes.Entity)))
                    {
                        obj = ParseEntity(ref mValue, type, baseBaseObjectPool, typeInfo);
                        return true;
                    }
                    else
                    {
                        obj = GetDefault(type, typeInfo);
                        return false;
                    }
                case MValue.Type.DICT:
                    if (type == FunctionTypes.Obj || (typeInfo?.IsDict ?? type.Name.StartsWith("Dictionary")))
                    {
                        if (MValueAdapters.FromMValue(ref mValue, type, out obj))
                        {
                            return true;
                        }

                        obj = ParseDictionary(ref mValue, type, baseBaseObjectPool, typeInfo);
                        return true;
                    }

                    obj = GetDefault(type, typeInfo);
                    return false;
                case MValue.Type.FUNCTION:
                    //TODO: validate type somehow
                    obj = ParseFunction(ref mValue, type, baseBaseObjectPool, typeInfo);
                    return true;
                default:
                    obj = GetDefault(type, typeInfo);
                    return false;
            }
        }

        public static object ParseArray(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
            FunctionTypeInfo typeInfo)
        {
            // Types doesn't match
            if (mValue.type != MValue.Type.LIST) return null;
            var mValueList = mValue.GetList();
            var elementType = typeInfo?.ElementType ?? (
                                  type.GetElementType() ??
                                  type); // Object has no element type so we have to use the same type again
            return CreateArray(elementType, mValueList, baseBaseObjectPool, typeInfo);
        }

        public static object ParseEntity(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
            FunctionTypeInfo typeInfo)
        {
            // Types doesn't match
            if (mValue.type != MValue.Type.ENTITY) return null;
            var entityType = BaseObjectType.Undefined;

            var entityPointer = mValue.GetEntityPointer(ref entityType);

            if (entityPointer == IntPtr.Zero) return null;
            if (!ValidateEntityType(entityType, type, typeInfo))
            {
                return null;
            }

            if (!baseBaseObjectPool.GetOrCreate(entityPointer, entityType, out var entity))
            {
                return null;
            }

            return entity;
        }

        public static object ParseDictionary(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
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
                    dict[strings[i]] = ParseObject(ref valueArray[i], valueType, baseBaseObjectPool,
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

                if (!TryParseObject(ref currMValue, valueType, baseBaseObjectPool, typeInfo?.DictionaryValue,
                    out var dictObject))
                {
                    typedDict[strings[i]] = dictObject; //null;
                }
                else
                {
                    if (dictObject is IConvertible)
                    {
                        typedDict[strings[i]] = Convert.ChangeType(dictObject, valueType);
                    }
                    else
                    {
                        typedDict[strings[i]] = dictObject;
                    }
                }
            }

            return typedDict;
        }

        public static object ParseFunction(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.FUNCTION)
            {
                return (Function.Func) new FunctionWrapper(mValue.GetFunction()).Call;
            }

            // Types doesn't match
            return null;
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

        private static object GetDefault(Type type, FunctionTypeInfo typeInfo)
        {
            if (type.IsPrimitive && type != FunctionTypes.String)
            {
                return typeInfo?.DefaultValue ?? Activator.CreateInstance(type);
            }

            return null;
        }
    }

    internal delegate object FunctionMValueParser(ref MValue mValue, Type type, IBaseBaseObjectPool baseBaseObjectPool,
        FunctionTypeInfo typeInfo);
}