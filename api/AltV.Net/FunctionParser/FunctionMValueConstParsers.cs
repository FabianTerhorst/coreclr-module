using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Data;
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
                    if (currMValue.type == MValueConst.Type.Bool)
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
                    if (currMValue.type == MValueConst.Type.Int)
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
                    if (currMValue.type == MValueConst.Type.Int)
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
                    if (currMValue.type == MValueConst.Type.Uint)
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
                    if (currMValue.type == MValueConst.Type.Uint)
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
                    if (currMValue.type == MValueConst.Type.Double)
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
                    if (currMValue.type == MValueConst.Type.String)
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

            if (type == FunctionTypes.Vector3)
            {
                var array = new Vector3[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (currMValue.type == MValueConst.Type.Vector3)
                    {
                        array[i] = currMValue.GetVector3();
                    }
                    else
                    {
                        array[i] = Position.Zero;
                    }
                }

                return array;
            }

            if (type == FunctionTypes.Position)
            {
                var array = new Position[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (currMValue.type == MValueConst.Type.Vector3)
                    {
                        array[i] = currMValue.GetVector3();
                    }
                    else
                    {
                        array[i] = Position.Zero;
                    }
                }

                return array;
            }


            var typeArray = typeInfo != null
                ? typeInfo.CreateArrayOfType(length, type)
                : Array.CreateInstance(type, length);

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
            if (mValue.type == MValueConst.Type.Bool)
            {
                return mValue.GetBool();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseSByte(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Int)
            {
                return (sbyte) mValue.GetInt();
            }

            if (mValue.type == MValueConst.Type.Uint)
            {
                return (sbyte) mValue.GetUint();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseShort(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Int)
            {
                return (short) mValue.GetInt();
            }

            if (mValue.type == MValueConst.Type.Uint)
            {
                return (short) mValue.GetUint();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseInt(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Int)
            {
                return (int) mValue.GetInt();
            }

            if (mValue.type == MValueConst.Type.Uint)
            {
                return (int) mValue.GetUint();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseLong(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Int)
            {
                return mValue.GetInt();
            }

            if (mValue.type == MValueConst.Type.Uint)
            {
                return (long) mValue.GetUint();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseByte(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Uint)
            {
                return (byte) mValue.GetUint();
            }

            if (mValue.type == MValueConst.Type.Int)
            {
                return (byte) mValue.GetInt();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseUShort(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Uint)
            {
                return (ushort) mValue.GetUint();
            }

            if (mValue.type == MValueConst.Type.Int)
            {
                return (ushort) mValue.GetInt();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseUInt(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Uint)
            {
                return (uint) mValue.GetUint();
            }

            if (mValue.type == MValueConst.Type.Int)
            {
                return (uint) mValue.GetInt();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseULong(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Uint)
            {
                return mValue.GetUint();
            }

            if (mValue.type == MValueConst.Type.Int)
            {
                return (ulong) mValue.GetInt();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseFloat(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Double)
            {
                return (float) mValue.GetDouble();
            }

            if (mValue.type == MValueConst.Type.Int)
            {
                return Convert.ToSingle(mValue.GetInt());
            }

            if (mValue.type == MValueConst.Type.Uint)
            {
                return Convert.ToSingle(mValue.GetUint());
            }

            // Types doesn't match
            return null;
        }

        public static object ParseDouble(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Double)
            {
                return mValue.GetDouble();
            }

            if (mValue.type == MValueConst.Type.Int)
            {
                return Convert.ToDouble(mValue.GetInt());
            }

            if (mValue.type == MValueConst.Type.Uint)
            {
                return Convert.ToDouble(mValue.GetUint());
            }

            // Types doesn't match
            return null;
        }

        public static object ParseString(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type != MValueConst.Type.String ? null : mValue.GetString();
        }

        public static object ParseObject(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            //return mValue.ToObject(entityPool);
            object obj;
            switch (mValue.type)
            {
                case MValueConst.Type.Nil:
                    return null;
                case MValueConst.Type.Bool:
                    return ParseBool(in mValue, type, typeInfo);
                case MValueConst.Type.Int:
                    return type == FunctionTypes.Int
                        ? ParseInt(in mValue, type, typeInfo)
                        : ParseLong(in mValue, type, typeInfo);
                case MValueConst.Type.Uint:
                    return type == FunctionTypes.UInt
                        ? ParseUInt(in mValue, type, typeInfo)
                        : ParseULong(in mValue, type, typeInfo);
                case MValueConst.Type.Double:
                    return type == FunctionTypes.Float
                        ? ParseFloat(in mValue, type, typeInfo)
                        : ParseDouble(in mValue, type, typeInfo);
                case MValueConst.Type.String:
                    return ParseString(in mValue, type, typeInfo);
                case MValueConst.Type.List:
                    if ((typeInfo?.IsMValueConvertible == true || typeInfo == null) &&
                        MValueAdapters.FromMValue(in mValue, type, out obj))
                    {
                        return obj;
                    }

                    return ParseArray(in mValue, type, typeInfo);
                case MValueConst.Type.BaseObject:
                    return ParseEntity(in mValue, type, typeInfo);
                case MValueConst.Type.Dict:
                    if ((typeInfo?.IsMValueConvertible == true || typeInfo == null) &&
                        MValueAdapters.FromMValue(in mValue, type, out obj))
                    {
                        return obj;
                    }

                    return ParseDictionary(in mValue, type, typeInfo);
                case MValueConst.Type.Function:
                    return ParseFunction(in mValue, type, typeInfo);
                case MValueConst.Type.Vector3:
                    return ParseVector3(in mValue, type, typeInfo);
                default:
                    return null;
            }
        }

        public static bool TryParseObject(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo, out object obj)
        {
            switch (mValue.type)
            {
                case MValueConst.Type.Nil:
                    obj = GetDefault(type, typeInfo);
                    return true;
                case MValueConst.Type.Bool:
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

                case MValueConst.Type.Int:
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

                case MValueConst.Type.Uint:
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

                case MValueConst.Type.Double:
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

                case MValueConst.Type.String:
                    if (type == FunctionTypes.Obj || type == FunctionTypes.String)
                    {
                        obj = mValue.GetString();
                        return true;
                    }

                    obj = GetDefault(type, typeInfo);
                    return false;
                case MValueConst.Type.List:
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
                case MValueConst.Type.BaseObject:
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

                case MValueConst.Type.Dict:
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
                case MValueConst.Type.Function:
                    //TODO: validate type somehow
                    obj = ParseFunction(in mValue, type, typeInfo);
                    return true;
                case MValueConst.Type.Vector3:
                    if (type == FunctionTypes.Obj || type == FunctionTypes.Vector3)
                    {
                        obj = mValue.GetVector3();
                        return true;
                    }
                    else if (type == FunctionTypes.Position)
                    {
                        obj = (Position) mValue.GetVector3();
                        return true;
                    }
                    else if (type == FunctionTypes.Rotation)
                    {
                        obj = (Rotation) mValue.GetVector3();
                        return true;
                    }

                    obj = GetDefault(type, typeInfo);
                    return false;
                default:
                    obj = GetDefault(type, typeInfo);
                    return false;
            }
        }

        public static object ParseArray(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            // Types doesn't match
            if (mValue.type != MValueConst.Type.List) return null;
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
            if (mValue.type != MValueConst.Type.BaseObject) return null;
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
            if (mValue.type != MValueConst.Type.Dict) return null;

            Type keyType;
            Type valueType;
            if (type == FunctionTypes.Obj)
            {
                keyType = FunctionTypes.String;
                valueType = FunctionTypes.Obj;
            }
            else
            {
                var args = typeInfo?.GenericArguments ?? type.GetGenericArguments();
                if (args.Length != 2) return null;
                keyType = args[0];
                if (keyType != FunctionTypes.String) return null;
                valueType = args[1];
            }

            unsafe
            {
                var length = Alt.Core.Library.Shared.MValueConst_GetDictSize(mValue.nativePointer);
                var keyPointers = new IntPtr[length];
                var pointerValues = new IntPtr[length];
                Alt.Core.Library.Shared.MValueConst_GetDict(mValue.nativePointer, keyPointers, pointerValues);


                var strings = new string[length];
                var valueArray = new MValueConst[length];
                for (ulong i = 0; i < length; i++)
                {
                    strings[i] = Marshal.PtrToStringUTF8(keyPointers[i]);
                    Alt.Core.Library.Shared.FreeCharArray(keyPointers[i]);
                    valueArray[i] = new MValueConst(pointerValues[i]);
                }

                var dictionary = CreateDictionary(typeInfo, keyType, valueType, length, strings, valueArray);

                for (ulong i = 0; i < length; i++)
                {
                    valueArray[i].Dispose();
                }

                return dictionary;
            }
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
                    if (currMValue.type == MValueConst.Type.Bool)
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
                    if (currMValue.type == MValueConst.Type.Int)
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
                    if (currMValue.type == MValueConst.Type.Int)
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
                    if (currMValue.type == MValueConst.Type.Uint)
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
                    if (currMValue.type == MValueConst.Type.Uint)
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
                    if (currMValue.type == MValueConst.Type.Double)
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
                    if (currMValue.type == MValueConst.Type.Double)
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
                    if (currMValue.type == MValueConst.Type.Double)
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
                    if (currMValue.type == MValueConst.Type.String)
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

            if (valueType == FunctionTypes.Vector3)
            {
                var dict = new Dictionary<string, Vector3>();
                for (ulong i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValueConst.Type.Vector3)
                    {
                        dict[strings[i]] = currMValue.GetVector3();
                    }
                    else
                    {
                        dict[strings[i]] = Position.Zero;
                    }
                }

                return dict;
            }

            if (valueType == FunctionTypes.Position)
            {
                var dict = new Dictionary<string, Position>();
                for (ulong i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValueConst.Type.Vector3)
                    {
                        dict[strings[i]] = currMValue.GetVector3();
                    }
                    else
                    {
                        dict[strings[i]] = Position.Zero;
                    }
                }

                return dict;
            }

            if (valueType == FunctionTypes.Rotation)
            {
                var dict = new Dictionary<string, Rotation>();
                for (ulong i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValueConst.Type.Vector3)
                    {
                        dict[strings[i]] = currMValue.GetVector3();
                    }
                    else
                    {
                        dict[strings[i]] = Position.Zero;
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
            if (mValue.type == MValueConst.Type.Function)
            {
                return (Function.Func) new MValueConstFunctionWrapper(mValue.nativePointer).Call;
            }

            // Types doesn't match
            return null;
        }

        public static object ParsePosition(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Vector3)
            {
                return mValue.GetVector3();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseRotation(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Vector3)
            {
                return (Rotation) mValue.GetVector3();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseVector3(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Vector3)
            {
                return (Vector3) mValue.GetVector3();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseRgba(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Rgba)
            {
                return mValue.GetRgba();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseByteArray(in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.ByteArray)
            {
                return mValue.GetByteArray();
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