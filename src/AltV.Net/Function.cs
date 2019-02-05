using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net
{
    public partial class Function
    {
        private class TypeInfo
        {
            public readonly bool IsEntity;

            public readonly bool IsVehicle;

            public readonly bool IsPlayer;

            public readonly bool IsBlip;

            public readonly bool IsDict;

            public readonly bool IsList;

            public readonly TypeInfo Element;

            public readonly TypeInfo DictionaryValue;

            public readonly Type[] GenericArguments;

            public readonly Type DictType;

            public TypeInfo(Type type)
            {
                IsList = type.BaseType == Array;
                IsDict = type.Name.StartsWith("Dictionary");
                if (IsDict)
                {
                    GenericArguments = type.GetGenericArguments();
                    DictType = typeof(Dictionary<,>).MakeGenericType(GenericArguments[0], GenericArguments[1]);
                    DictionaryValue = GenericArguments.Length == 2 ? new TypeInfo(GenericArguments[1]) : null;
                }
                else
                {
                    GenericArguments = null;
                    DictType = null;
                    DictionaryValue = null;
                }

                var interfaces = type.GetInterfaces();
                if (interfaces.Contains(Entity))
                {
                    IsEntity = true;
                    IsVehicle = type == Vehicle || interfaces.Contains(Vehicle);
                    IsPlayer = type == Player || interfaces.Contains(Player);
                    IsBlip = type == Blip || interfaces.Contains(Blip);
                }
                else
                {
                    IsEntity = false;
                    IsVehicle = false;
                    IsPlayer = false;
                    IsBlip = false;
                }

                var elementType = type.GetElementType();
                if (elementType != null)
                {
                    Element = new TypeInfo(elementType);
                }
            }
        }

        private delegate object Parser(ref MValue mValue, Type type, IEntityPool entityPool, TypeInfo typeInfo);

        private static readonly Type Void = typeof(void);

        private static readonly Type Bool = typeof(bool);

        private static readonly Type Int = typeof(int);

        private static readonly Type Long = typeof(long);

        private static readonly Type UInt = typeof(uint);

        private static readonly Type ULong = typeof(ulong);

        private static readonly Type Double = typeof(double);

        private static readonly Type String = typeof(string);

        private static readonly Type Player = typeof(IPlayer);

        private static readonly Type Vehicle = typeof(IVehicle);

        private static readonly Type Array = typeof(System.Array);

        private static readonly Type Entity = typeof(IEntity);

        private static readonly Type Blip = typeof(IBlip);

        private static readonly Type Obj = typeof(object);

        //TODO: for high optimization add ParseBoolUnsafe ect. that doesn't contains the mValue type check for scenarios where we already had to check the mValue type

        private static object CreateArray(Type type, MValue[] mValues, IEntityPool entityPool, TypeInfo typeInfo)
        {
            var length = mValues.Length;
            if (type == Obj)
            {
                var array = new object[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (!ValidateMValueType(currMValue.type, type, typeInfo?.Element))
                        return null;
                    array[i] = ParseObject(ref currMValue, type, entityPool, typeInfo?.Element);
                }

                return array;
            }

            if (type == Bool)
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

            if (type == Int)
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

            if (type == Long)
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

            if (type == UInt)
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

            if (type == ULong)
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

            if (type == Double)
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

            if (type == String)
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
                    return null;
                typeArray.SetValue(
                    Convert.ChangeType(ParseObject(ref currMValue, type, entityPool, typeInfo?.Element), type), i);
                //typeArray.SetValue(ParseObject(ref currMValue, type, entityPool, typeInfo?.Element), i);
            }

            return typeArray;
        }

        private static object ParseBool(ref MValue mValue, Type type, IEntityPool entityPool, TypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.BOOL)
            {
                return mValue.GetBool();
            }

            // Types doesn't match
            return null;
        }

        private static object ParseInt(ref MValue mValue, Type type, IEntityPool entityPool, TypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.INT)
            {
                return mValue.GetInt();
            }

            // Types doesn't match
            return null;
        }

        private static object ParseUInt(ref MValue mValue, Type type, IEntityPool entityPool, TypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.UINT)
            {
                return mValue.GetUint();
            }

            // Types doesn't match
            return null;
        }

        private static object ParseDouble(ref MValue mValue, Type type, IEntityPool entityPool, TypeInfo typeInfo)
        {
            if (mValue.type == MValue.Type.DOUBLE)
            {
                return mValue.GetDouble();
            }

            // Types doesn't match
            return null;
        }

        private static object ParseString(ref MValue mValue, Type type, IEntityPool entityPool, TypeInfo typeInfo)
        {
            return mValue.type != MValue.Type.STRING ? null : mValue.GetString();
        }

        private static object ParseObject(ref MValue mValue, Type type, IEntityPool entityPool, TypeInfo typeInfo)
        {
            //return mValue.ToObject(entityPool);
            switch (mValue.type)
            {
                case MValue.Type.NIL:
                    return null;
                case MValue.Type.BOOL:
                    return ParseBool(ref mValue, type, entityPool, typeInfo);
                case MValue.Type.INT:
                    return ParseInt(ref mValue, type, entityPool, typeInfo);
                case MValue.Type.UINT:
                    return ParseUInt(ref mValue, type, entityPool, typeInfo);
                case MValue.Type.DOUBLE:
                    return ParseDouble(ref mValue, type, entityPool, typeInfo);
                case MValue.Type.STRING:
                    return ParseString(ref mValue, type, entityPool, typeInfo);
                case MValue.Type.LIST:
                    return ParseArray(ref mValue, type, entityPool, typeInfo);
                case MValue.Type.ENTITY:
                    return ParseEntity(ref mValue, type, entityPool, typeInfo);
                case MValue.Type.DICT:
                    return ParseDictionary(ref mValue, type, entityPool, typeInfo);
                default:
                    return false; //TODO:, func, dict, ect.
            }
        }

        private static object ParseArray(ref MValue mValue, Type type, IEntityPool entityPool, TypeInfo typeInfo)
        {
            // Types doesn't match
            if (mValue.type != MValue.Type.LIST) return null;
            var mValueList = mValue.GetList();
            var elementType =
                type.GetElementType() ?? type; // Object has no element type so we have to use the same type again
            return CreateArray(elementType, mValueList, entityPool, typeInfo);
        }

        private static object ParseEntity(ref MValue mValue, Type type, IEntityPool entityPool, TypeInfo typeInfo)
        {
            // Types doesn't match
            if (mValue.type != MValue.Type.ENTITY) return null;
            var entityPointer = IntPtr.Zero;
            mValue.GetEntityPointer(ref entityPointer);
            if (entityPointer == IntPtr.Zero) return null;
            if (!entityPool.GetOrCreate(entityPointer, out var entity) ||
                !ValidateEntityType(entity.Type, type, typeInfo))
                return null;
            return entity;
        }

        private static object ParseDictionary(ref MValue mValue, Type type, IEntityPool entityPool, TypeInfo typeInfo)
        {
            // Types doesn't match
            if (mValue.type != MValue.Type.DICT) return null;
            var args = typeInfo?.GenericArguments ?? type.GetGenericArguments();
            if (args.Length != 2) return null;
            var keyType = args[0];
            if (keyType != String) return null;
            var valueType = args[1];
            var stringViewArrayRef = StringViewArray.Nil;
            var valueArrayRef = MValueArray.Nil;
            AltVNative.MValueGet.MValue_GetDict(ref mValue, ref stringViewArrayRef, ref valueArrayRef);
            var stringViewArray = stringViewArrayRef.ToArray();
            var valueArray = valueArrayRef.ToArray();
            var length = stringViewArray.Length;

            MValue currMValue;

            if (valueType == Obj)
            {
                var dict = new Dictionary<string, object>();
                for (var i = 0; i < length; i++)
                {
                    dict[stringViewArray[i].Text] = ParseObject(ref valueArray[i], valueType, entityPool,
                        typeInfo?.DictionaryValue);
                }

                return dict;
            }
            
            if (valueType == Bool)
            {
                var dict = new Dictionary<string, bool>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.BOOL)
                    {
                        dict[stringViewArray[i].Text] = currMValue.GetBool();
                    }
                    else
                    {
                        dict[stringViewArray[i].Text] = default;
                    }
                }

                return dict;
            }

            if (valueType == Int)
            {
                var dict = new Dictionary<string, int>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.INT)
                    {
                        dict[stringViewArray[i].Text] = (int) currMValue.GetInt();
                    }
                    else
                    {
                        dict[stringViewArray[i].Text] = default;
                    }
                }

                return dict;
            }

            if (valueType == Long)
            {
                var dict = new Dictionary<string, long>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.INT)
                    {
                        dict[stringViewArray[i].Text] = currMValue.GetInt();
                    }
                    else
                    {
                        dict[stringViewArray[i].Text] = default;
                    }
                }

                return dict;
            }

            if (valueType == UInt)
            {
                var dict = new Dictionary<string, uint>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.UINT)
                    {
                        dict[stringViewArray[i].Text] = (uint) currMValue.GetUint();
                    }
                    else
                    {
                        dict[stringViewArray[i].Text] = default;
                    }
                }

                return dict;
            }

            if (valueType == ULong)
            {
                var dict = new Dictionary<string, ulong>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.UINT)
                    {
                        dict[stringViewArray[i].Text] = currMValue.GetUint();
                    }
                    else
                    {
                        dict[stringViewArray[i].Text] = default;
                    }
                }

                return dict;
            }

            if (valueType == Double)
            {
                var dict = new Dictionary<string, double>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.DOUBLE)
                    {
                        dict[stringViewArray[i].Text] = currMValue.GetDouble();
                    }
                    else
                    {
                        dict[stringViewArray[i].Text] = default;
                    }
                }

                return dict;
            }

            if (valueType == String)
            {
                var dict = new Dictionary<string, string>();
                for (var i = 0; i < length; i++)
                {
                    currMValue = valueArray[i];
                    if (currMValue.type == MValue.Type.STRING)
                    {
                        dict[stringViewArray[i].Text] = currMValue.GetString();
                    }
                    else
                    {
                        dict[stringViewArray[i].Text] = null;
                    }
                }

                return dict;
            }

            var dictType = typeInfo?.DictType ?? typeof(Dictionary<,>).MakeGenericType(keyType, valueType);
            var typedDict = (System.Collections.IDictionary) Activator.CreateInstance(dictType);
            for (var i = 0; i < length; i++)
            {
                typedDict[stringViewArray[i].Text] =
                    Convert.ChangeType(ParseObject(ref valueArray[i], valueType, entityPool, typeInfo?.DictionaryValue),
                        valueType);
            }

            return typedDict;
        }

        private static bool ValidateEntityType(EntityType entityType, Type type, TypeInfo typeInfo)
        {
            if (type == Obj)
            {
                return true;
            }

            switch (entityType)
            {
                case EntityType.Blip:
                    return typeInfo?.IsBlip ?? type == Blip;
                case EntityType.Player:
                    return typeInfo?.IsPlayer ?? type == Player;
                case EntityType.Vehicle:
                    return typeInfo?.IsVehicle ?? type == Vehicle || type.GetInterfaces().Contains(Vehicle);
                case EntityType.Checkpoint:
                    return false; //TODO:
                default:
                    return false;
            }
        }

        private static bool ValidateMValueType(MValue.Type valueType, Type type, TypeInfo typeInfo)
        {
            if (type == Obj)
            {
                // object[] or object accepts anything
                return true;
            }

            switch (valueType)
            {
                case MValue.Type.NIL:
                    return !type.IsPrimitive || type == String; //TODO: check if there are more none nullable types
                case MValue.Type.BOOL:
                    return type == Bool;
                case MValue.Type.INT:
                    return type == Int || type == UInt;
                case MValue.Type.UINT:
                    return type == UInt || type == ULong;
                case MValue.Type.DOUBLE:
                    return type == Double;
                case MValue.Type.STRING:
                    return type == String;
                case MValue.Type.LIST:
                    return typeInfo?.IsList ?? type.BaseType == Array;
                case MValue.Type.ENTITY:
                    return typeInfo?.IsEntity ?? type.GetInterfaces().Contains(Entity);
                case MValue.Type.FUNCTION:
                    return false; //TODO: needs to be Func or Action
                case MValue.Type.DICT:
                    return typeInfo?.IsDict ?? type.Name.StartsWith("Dictionary");
                default:
                    return false;
            }
        }

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
                    returnType = Void;
                }
                else
                {
                    returnType = genericArguments[genericArguments.Length - 1];
                    genericArguments = genericArguments.SkipLast(1).ToArray();
                }
            }
            else
            {
                returnType = Void;
            }

            //TODO: check for unsupported types
            var parsers = new Parser[genericArguments.Length];
            var typeInfos = new TypeInfo[genericArguments.Length];
            for (int i = 0, length = genericArguments.Length; i < length; i++)
            {
                var arg = genericArguments[i];
                var typeInfo = new TypeInfo(arg);
                typeInfos[i] = typeInfo;
                if (arg == Obj)
                {
                    parsers[i] = ParseObject;
                }
                else if (arg == Bool)
                {
                    parsers[i] = ParseBool;
                }
                else if (arg == Int || arg == Long)
                {
                    parsers[i] = ParseInt;
                }
                else if (arg == UInt || arg == ULong)
                {
                    parsers[i] = ParseUInt;
                }
                else if (arg == Double)
                {
                    parsers[i] = ParseDouble;
                }
                else if (arg == String)
                {
                    parsers[i] = ParseString;
                }
                else if (arg.BaseType == Array)
                {
                    parsers[i] = ParseArray;
                }
                else if (typeInfo.IsEntity)
                {
                    parsers[i] = ParseEntity;
                }
                else if (typeInfo.IsDict)
                {
                    parsers[i] = ParseDictionary;
                }
                else
                {
                    // Unsupported type
                    return null;
                }
            }

            return new Function(func, returnType, genericArguments, parsers, typeInfos);
        }

        private readonly Delegate @delegate;

        private readonly Type returnType;

        private readonly Type[] args;

        private readonly Parser[] parsers;

        private readonly TypeInfo[] typeInfos;

        private Function(Delegate @delegate, Type returnType, Type[] args, Parser[] parsers, TypeInfo[] typeInfos)
        {
            this.@delegate = @delegate;
            this.returnType = returnType;
            this.args = args;
            this.parsers = parsers;
            this.typeInfos = typeInfos;
        }

        //TODO: add support for nullable args, these are reducing the required length, add support for default values as well
        internal MValue Call(IEntityPool entityPool, MValue[] values)
        {
            var length = values.Length;
            if (length != args.Length) return MValue.Nil;
            var invokeValues = new object[length];
            for (var i = 0; i < length; i++)
            {
                invokeValues[i] = parsers[i](ref values[i], args[i], entityPool, typeInfos[i]);
            }

            var result = @delegate.DynamicInvoke(invokeValues);
            if (returnType == Void) return MValue.Nil;
            return MValue.CreateFromObject(result) ?? MValue.Nil;
        }

        internal MValue Call(IEntityPool entityPool, MValue valueArgs)
        {
            return valueArgs.type != MValue.Type.LIST ? MValue.Nil : Call(entityPool, valueArgs.GetList());
        }

        internal void call(ref MValue args, ref MValue result)
        {
            result = Call(Alt.Module.EntityPool, args);
        }
    }
}