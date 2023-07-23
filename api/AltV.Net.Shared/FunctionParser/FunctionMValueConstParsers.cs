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
using AltV.Net.Shared;

namespace AltV.Net.FunctionParser
{
    internal static class FunctionMValueConstParsers
    {
        private static object CreateArray(ISharedCore core, Type type, MValueConst[] mValues,
            FunctionTypeInfo typeInfo)
        {
            var length = mValues.Length;
            if (type == FunctionTypes.Obj)
            {
                var array = new object[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (!TryParseObject(core, in currMValue, type, typeInfo?.Element, out var obj))
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
                if (!TryParseObject(core, in currMValue, type, typeInfo?.Element, out var obj))
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

        public static object ParseBool(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Bool)
            {
                return mValue.GetBool();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseSByte(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type switch
            {
                MValueConst.Type.Int => (sbyte) mValue.GetInt(),
                MValueConst.Type.Uint => (sbyte) mValue.GetUint(),
                MValueConst.Type.Double => (sbyte) mValue.GetDouble(),
                _ => null!
            };
        }

        public static object ParseShort(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type switch
            {
                MValueConst.Type.Int => (short) mValue.GetInt(),
                MValueConst.Type.Uint => (short) mValue.GetUint(),
                MValueConst.Type.Double => (short) mValue.GetDouble(),
                _ => null!
            };
        }

        public static object ParseInt(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type switch
            {
                MValueConst.Type.Int => (int) mValue.GetInt(),
                MValueConst.Type.Uint => (int) mValue.GetUint(),
                MValueConst.Type.Double => (int) mValue.GetDouble(),
                _ => null!
            };
        }

        public static object ParseLong(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type switch
            {
                MValueConst.Type.Int => mValue.GetInt(),
                MValueConst.Type.Uint => (long) mValue.GetUint(),
                MValueConst.Type.Double => (long) mValue.GetDouble(),
                _ => null!
            };
        }

        public static object ParseByte(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type switch
            {
                MValueConst.Type.Uint => (byte) mValue.GetUint(),
                MValueConst.Type.Int => (byte) mValue.GetInt(),
                MValueConst.Type.Double => (byte) mValue.GetDouble(),
                _ => null!
            };
        }

        public static object ParseUShort(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type switch
            {
                MValueConst.Type.Uint => (ushort) mValue.GetUint(),
                MValueConst.Type.Int => (ushort) mValue.GetInt(),
                MValueConst.Type.Double => (ushort) mValue.GetDouble(),
                _ => null!
            };
        }

        public static object ParseUInt(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type switch
            {
                MValueConst.Type.Uint => (uint) mValue.GetUint(),
                MValueConst.Type.Int => (uint) mValue.GetInt(),
                MValueConst.Type.Double => (uint) mValue.GetDouble(),
                _ => null!
            };
        }

        public static object ParseULong(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type switch
            {
                MValueConst.Type.Uint => mValue.GetUint(),
                MValueConst.Type.Int => (ulong) mValue.GetInt(),
                MValueConst.Type.Double => (ulong) mValue.GetDouble(),
                _ => null!
            };
        }

        public static object ParseFloat(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type switch
            {
                MValueConst.Type.Double => (float) mValue.GetDouble(),
                MValueConst.Type.Int => Convert.ToSingle(mValue.GetInt()),
                MValueConst.Type.Uint => Convert.ToSingle(mValue.GetUint()),
                _ => null!
            };
        }

        public static object ParseDouble(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type switch
            {
                MValueConst.Type.Double => mValue.GetDouble(),
                MValueConst.Type.Int => Convert.ToDouble(mValue.GetInt()),
                MValueConst.Type.Uint => Convert.ToDouble(mValue.GetUint()),
                _ => null!
            };
        }

        public static object ParseString(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return mValue.type != MValueConst.Type.String ? null : mValue.GetString();
        }

        public static object ParseObject(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            //return mValue.ToObject(entityPool);
            object obj;
            switch (mValue.type)
            {
                case MValueConst.Type.Nil:
                    return null;
                case MValueConst.Type.Bool:
                    return ParseBool(core, in mValue, type, typeInfo);
                case MValueConst.Type.Int:
                    return type == FunctionTypes.Int
                        ? ParseInt(core, in mValue, type, typeInfo)
                        : ParseLong(core, in mValue, type, typeInfo);
                case MValueConst.Type.Uint:
                    return type == FunctionTypes.UInt
                        ? ParseUInt(core, in mValue, type, typeInfo)
                        : ParseULong(core, in mValue, type, typeInfo);
                case MValueConst.Type.Double:
                    return type == FunctionTypes.Float
                        ? ParseFloat(core, in mValue, type, typeInfo)
                        : ParseDouble(core, in mValue, type, typeInfo);
                case MValueConst.Type.String:
                    return ParseString(core, in mValue, type, typeInfo);
                case MValueConst.Type.List:
                    if ((typeInfo?.IsMValueConvertible == true || typeInfo == null) &&
                        core.FromMValue(in mValue, type, out obj))
                    {
                        return obj;
                    }

                    return ParseArray(core, in mValue, type, typeInfo);
                case MValueConst.Type.BaseObject:
                    return ParseBaseObject(core, in mValue, type, typeInfo);
                case MValueConst.Type.Dict:
                    if ((typeInfo?.IsMValueConvertible == true || typeInfo == null) &&
                        core.FromMValue(in mValue, type, out obj))
                    {
                        return obj;
                    }

                    return ParseDictionary(core, in mValue, type, typeInfo);
                case MValueConst.Type.Function:
                    return ParseFunction(core, in mValue, type, typeInfo);
                case MValueConst.Type.Vector3:
                    return ParseVector3(core, in mValue, type, typeInfo);
                default:
                    return null;
            }
        }

        public static bool TryParseObject(ISharedCore core, in MValueConst mValue, Type type,
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
                            core.FromMValue(in mValue, type, out obj))
                        {
                            return true;
                        }

                        obj = ParseArray(core, in mValue, type, typeInfo);
                        return true;
                    }

                    obj = GetDefault(type, typeInfo);
                    return false;
                case MValueConst.Type.BaseObject:
                    if (type == FunctionTypes.Obj ||
                        (typeInfo?.IsBaseObject ?? type.GetInterfaces().Contains(FunctionTypes.Entity)))
                    {
                        obj = ParseBaseObject(core, in mValue, type, typeInfo);
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
                            core.FromMValue(in mValue, type, out obj))
                        {
                            return true;
                        }

                        obj = ParseDictionary(core, in mValue, type, typeInfo);
                        return true;
                    }

                    obj = GetDefault(type, typeInfo);
                    return false;
                case MValueConst.Type.Function:
                    //TODO: validate type somehow
                    obj = ParseFunction(core, in mValue, type, typeInfo);
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

        public static object ParseArray(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            // Types doesn't match
            if (mValue.type != MValueConst.Type.List) return null;
            var mValueList = mValue.GetList();
            var elementType = typeInfo?.ElementType ?? (
                type.GetElementType() ??
                type); // Object has no element type so we have to use the same type again
            var array = CreateArray(core, elementType, mValueList, typeInfo);
            for (int i = 0, length = mValueList.Length; i < length; i++)
            {
                mValueList[i].Dispose();
            }

            return array;
        }

        public static object ParseBaseObject(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            // Types doesn't match
            if (mValue.type != MValueConst.Type.BaseObject) return null;
            var entityType = BaseObjectType.Undefined;

            var entityPointer = mValue.GetEntityPointer(ref entityType);

            if (entityPointer == IntPtr.Zero || entityType == BaseObjectType.Undefined) return null;
            var entity = core.PoolManager.GetOrCreate(core, entityPointer, entityType);
            
            if (entity == null) return null;
            return type == FunctionTypes.Obj || entity.GetType().IsAssignableTo(type) ? entity : null;
        }

        public static object ParseDictionary(ISharedCore core, in MValueConst mValue, Type type,
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
                var length = core.Library.Shared.MValueConst_GetDictSize(mValue.nativePointer);
                var keyPointers = new IntPtr[length];
                var pointerValues = new IntPtr[length];
                core.Library.Shared.MValueConst_GetDict(mValue.nativePointer, keyPointers, pointerValues);


                var strings = new string[length];
                var valueArray = new MValueConst[length];
                for (ulong i = 0; i < length; i++)
                {
                    strings[i] = Marshal.PtrToStringUTF8(keyPointers[i]);
                    core.Library.Shared.FreeCharArray(keyPointers[i]);
                    valueArray[i] = new MValueConst(core, pointerValues[i]);
                }

                var dictionary = CreateDictionary(core, typeInfo, keyType, valueType, length, strings, valueArray);

                for (ulong i = 0; i < length; i++)
                {
                    valueArray[i].Dispose();
                }

                return dictionary;
            }
        }

        private static object CreateDictionary(ISharedCore core, FunctionTypeInfo typeInfo, Type keyType, Type valueType, ulong length,
            string[] strings, MValueConst[] valueArray)
        {
            MValueConst currMValue;

            if (valueType == FunctionTypes.Obj)
            {
                var dict = new Dictionary<string, object>();
                for (ulong i = 0; i < length; i++)
                {
                    dict[strings[i]] = ParseObject(core, in valueArray[i], valueType,
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

                if (!TryParseObject(core, in currMValue, valueType, typeInfo?.DictionaryValue,
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

        public static object ParseFunction(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Function)
            {
                return (Function.Func) new MValueConstFunctionWrapper(core, mValue.nativePointer).Call;
            }

            // Types doesn't match
            return null;
        }

        public static object ParsePosition(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Vector3)
            {
                return mValue.GetVector3();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseRotation(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Vector3)
            {
                return (Rotation) mValue.GetVector3();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseVector3(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Vector3)
            {
                return (Vector3) mValue.GetVector3();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseRgba(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.Rgba)
            {
                return mValue.GetRgba();
            }

            // Types doesn't match
            return null;
        }

        public static object ParseByteArray(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            if (mValue.type == MValueConst.Type.ByteArray)
            {
                return mValue.GetByteArray();
            }

            // Types doesn't match
            return null;
        }

        private static object GetDefault(Type type, FunctionTypeInfo typeInfo)
        {
            if (type.IsPrimitive && type != FunctionTypes.String)
            {
                return typeInfo?.DefaultValue ?? Activator.CreateInstance(type);
            }

            return null;
        }

        public static object ParseConvertible(ISharedCore core, in MValueConst mValue, Type type,
            FunctionTypeInfo typeInfo)
        {
            return core.FromMValue(in mValue, type, out var obj) ? obj : null;
        }

        public static object ParseEnum(ISharedCore core, in MValueConst value, Type type, FunctionTypeInfo typeInfo)
        {
            return !Enum.TryParse(type, value.ToString(), true, out var enumObject) ? null : enumObject;
        }
    }

    internal delegate object FunctionMValueConstParser(ISharedCore core, in MValueConst mValue, Type type,
        FunctionTypeInfo typeInfo);
}