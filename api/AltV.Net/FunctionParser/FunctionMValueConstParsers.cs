using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.FunctionParser
{
    internal static class FunctionMValueConstParsers
    {
        private static object CreateArray(Type type, MValueConst[] mValues,
            FunctionTypeInfo typeInfo)
        {
            var length = mValues.Length;
            if (type == FunctionTypes.Obj)
            {
                var array = new object[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (!TryParseObject(in currMValue, type, typeInfo?.Element, out var obj))
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
                    if (currMValue.type == MValueConst.Type.BOOL)
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
                    if (currMValue.type == MValueConst.Type.INT)
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
                    if (currMValue.type == MValueConst.Type.INT)
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
                    if (currMValue.type == MValueConst.Type.UINT)
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
                    if (currMValue.type == MValueConst.Type.UINT)
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
                    if (currMValue.type == MValueConst.Type.DOUBLE)
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
                    if (currMValue.type == MValueConst.Type.STRING)
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

            var typeArray = Array.CreateInstance(type, length);
            for (var i = 0; i < length; i++)
            {
                var currMValue = mValues[i];
                if (!TryParseObject(in currMValue, type, typeInfo?.Element, out var obj))
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

        public static object ParseBool(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.BOOL)
            {
                return mValue.GetBool();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseInt(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.INT)
            {
                return (int) mValue.GetInt();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseLong(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.INT)
            {
                return mValue.GetInt();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseUInt(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.UINT)
            {
                return (uint) mValue.GetUint();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseULong(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.UINT)
            {
                return mValue.GetUint();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseFloat(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.DOUBLE)
            {
                return (float) mValue.GetDouble();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseDouble(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.DOUBLE)
            {
                return mValue.GetDouble();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseString(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type != MValueConst.Type.STRING ? null : mValue.GetString();
        }

        public static object ParseObject(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            //return mValue.ToObject(entityPool);
            object obj;
            switch (mValue.type)
            {
                case MValueConst.Type.NIL:
                    return null;
                case MValueConst.Type.BOOL:
                    return ParseBool(in mValue, type, typeInfo);
                case MValueConst.Type.INT:
                    return type == FunctionTypes.Int
                        ? ParseInt(in mValue, type, typeInfo)
                        : ParseLong(in mValue, type, typeInfo);
                case MValueConst.Type.UINT:
                    return type == FunctionTypes.UInt
                        ? ParseUInt(in mValue, type, typeInfo)
                        : ParseULong(in mValue, type, typeInfo);
                case MValueConst.Type.DOUBLE:
                    return type == FunctionTypes.Float
                        ? ParseFloat(in mValue, type, typeInfo)
                        : ParseDouble(in mValue, type, typeInfo);
                case MValueConst.Type.STRING:
                    return ParseString(in mValue, type, typeInfo);
                case MValueConst.Type.LIST:
                    if ((typeInfo?.IsMValueConvertible == true || typeInfo == null) &&
                        MValueAdapters.FromMValue(in mValue, type, out obj))
                    {
                        return obj;
                    }

                    return ParseArray(in mValue, type, typeInfo);
                case MValueConst.Type.ENTITY:
                    return ParseEntity(in mValue, type, typeInfo);
                case MValueConst.Type.DICT:
                    if ((typeInfo?.IsMValueConvertible == true || typeInfo == null) &&
                        MValueAdapters.FromMValue(in mValue, type, out obj))
                    {
                        return obj;
                    }

                    return ParseDictionary(in mValue, type, typeInfo);
                case MValueConst.Type.FUNCTION:
                    return ParseFunction(in mValue, type, typeInfo);
                default:
                    return null;
            }
        }

        public static bool TryParseObject(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo, out object obj)
        {
            switch (mValue.type)
            {
                case MValueConst.Type.NIL:
                    obj = GetDefault(type, typeInfo);
                    return true;
                case MValueConst.Type.BOOL:
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

                case MValueConst.Type.INT:
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

                case MValueConst.Type.UINT:
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

                case MValueConst.Type.DOUBLE:
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

                case MValueConst.Type.STRING:
                    if (type == FunctionTypes.Obj || type == FunctionTypes.String)
                    {
                        obj = mValue.GetString();
                        return true;
                    }

                    obj = GetDefault(type, typeInfo);
                    return false;
                case MValueConst.Type.LIST:
                    if (type == FunctionTypes.Obj || (typeInfo?.IsList ?? type.BaseType == FunctionTypes.Array))
                    {
                        if ((typeInfo?.IsMValueConvertible == true || typeInfo == null) &&
                            MValueAdapters.FromMValue(in mValue, type, out obj))
                        {
                            return true;
                        }
                        
                        obj = ParseArray(in mValue, type, typeInfo);
                        return true;
                    }

                    obj = GetDefault(type, typeInfo);
                    return false;
                case MValueConst.Type.ENTITY:
                    if (type == FunctionTypes.Obj ||
                        (typeInfo?.IsEntity ?? type.GetInterfaces().Contains(FunctionTypes.Entity)))
                    {
                        obj = ParseEntity(in mValue, type, typeInfo);
                        return true;
                    }
                    else
                    {
                        obj = GetDefault(type, typeInfo);
                        return false;
                    }

                case MValueConst.Type.DICT:
                    if (type == FunctionTypes.Obj || (typeInfo?.IsDict ?? type.Name.StartsWith("Dictionary")))
                    {
                        if ((typeInfo?.IsMValueConvertible == true || typeInfo == null) &&
                            MValueAdapters.FromMValue(in mValue, type, out obj))
                        {
                            return true;
                        }

                        obj = ParseDictionary(in mValue, type, typeInfo);
                        return true;
                    }

                    obj = GetDefault(type, typeInfo);
                    return false;
                case MValueConst.Type.FUNCTION:
                    //TODO: validate type somehow
                    obj = ParseFunction(in mValue, type, typeInfo);
                    return true;
                default:
                    obj = GetDefault(type, typeInfo);
                    return false;
            }
        }

        public static object ParseArray(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            // Types doesn't match
            if (mValue.type != MValueConst.Type.LIST) return null;
            var mValueList = mValue.GetList();
            var elementType = typeInfo?.ElementType ?? (
                                  type.GetElementType() ??
                                  type); // Object has no element type so we have to use the same type again
            var array = CreateArray(elementType, mValueList, typeInfo);
            for (int i = 0, length = mValueList.Length; i < length; i++)
            {
                mValueList[i].Dispose();
            }

            return array;
        }

        public static object ParseEntity(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            // Types doesn't match
            if (mValue.type != MValueConst.Type.ENTITY) return null;
            var entityType = BaseObjectType.Undefined;

            var entityPointer = mValue.GetEntityPointer(ref entityType);

            if (entityPointer == IntPtr.Zero || entityType == BaseObjectType.Undefined) return null;
            if (!ValidateEntityType(entityType, type, typeInfo))
            {
                return null;
            }

            if (!Alt.Module.BaseBaseObjectPool.Get(entityPointer, entityType, out var entity))
            {
                return null;
            }

            return entity;
        }

        public static object ParseDictionary(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            // Types doesn't match
            if (mValue.type != MValueConst.Type.DICT) return null;
            var args = typeInfo?.GenericArguments ?? type.GetGenericArguments();
            if (args.Length != 2) return null;
            var keyType = args[0];
            if (keyType != FunctionTypes.String) return null;
            var valueType = args[1];

            var length = AltNative.MValueNative.MValueConst_GetDictSize(mValue.nativePointer);
            var keyPointers = new IntPtr[length];
            var pointerValues = new IntPtr[length];
            AltNative.MValueNative.MValueConst_GetDict(mValue.nativePointer, keyPointers, pointerValues);

            var strings = new string[length];
            var valueArray = new MValueConst[length];
            for (ulong i = 0; i < length; i++)
            {
                strings[i] = Marshal.PtrToStringUTF8(keyPointers[i]);
                AltNative.FreeCharArray(keyPointers[i]);
                valueArray[i] = new MValueConst(pointerValues[i]);
            }

            var dictionary = CreateDictionary(typeInfo, keyType, valueType, length, strings, valueArray);

            for (ulong i = 0; i < length; i++)
            {
                valueArray[i].Dispose();
            }

            return dictionary;
        }

        private static object CreateDictionary(FunctionTypeInfo typeInfo, Type keyType, Type valueType, ulong length,
            string[] strings, MValueConst[] valueArray)
        {
            MValueConst currMValue;

            if (valueType == FunctionTypes.Obj)
            {
                var dict = new Dictionary<string, object>();
                for (ulong i = 0; i < length; i++)
                {
                    dict[strings[i]] = ParseObject(in valueArray[i], valueType,
                        typeInfo?.DictionaryValue);
                }

                return dict;
            }

            if (valueType == FunctionTypes.Bool)
            {
                var dict = new Dictionary<string, bool>();
                for (ulong i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValueConst.Type.BOOL)
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
                for (ulong i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValueConst.Type.INT)
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
                for (ulong i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValueConst.Type.INT)
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
                for (ulong i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValueConst.Type.UINT)
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
                for (ulong i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValueConst.Type.UINT)
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
                for (ulong i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValueConst.Type.DOUBLE)
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
                for (ulong i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValueConst.Type.DOUBLE)
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
                for (ulong i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValueConst.Type.DOUBLE)
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
                for (ulong i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValueConst.Type.STRING)
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
                            (IDictionary) Activator.CreateInstance(dictType);
            for (ulong i = 0; i < length; i++)
            {
                currMValue = valueArray[i];

                if (!TryParseObject(in currMValue, valueType, typeInfo?.DictionaryValue,
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

        public static object ParseFunction(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.FUNCTION)
            {
                return (Function.Func) new MValueConstFunctionWrapper(mValue.nativePointer).Call;
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
                case BaseObjectType.ColShape:
                    return typeInfo?.IsColShape ?? type == FunctionTypes.ColShape ||
                           type.GetInterfaces().Contains(FunctionTypes.ColShape);
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

        public static object ParseConvertible(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return MValueAdapters.FromMValue(in mValue, type, out var obj) ? obj : null;
        }

        public static object ParseEnum(in MValueConst value, Type type, FunctionTypeInfo typeInfo)
        {
            return !Enum.TryParse(type, value.ToString(), true, out var enumObject) ? null : enumObject;
        }
    }

    internal delegate object FunctionMValueConstParser(in MValueConst mValue, Type type,
        FunctionTypeInfo typeInfo);
}