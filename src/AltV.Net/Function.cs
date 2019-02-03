using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net
{
    public class Function
    {
        private delegate object Parser(ref MValue mValue, Type type, IEntityPool entityPool);

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

        private static object CreateArray(Type type, MValue[] mValues, IEntityPool entityPool)
        {
            var length = mValues.Length;
            if (type == Obj)
            {
                var array = new object[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (!ValidateMValueType(currMValue.type, type))
                        return null;
                    array[i] = ParseObject(ref currMValue, type, entityPool);
                }

                return array;
            }

            if (type == Int)
            {
                var array = new int[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (!ValidateMValueType(currMValue.type, type))
                        return null;
                    array[i] = (int) currMValue.GetInt();
                }

                return array;
            }

            if (type == Long)
            {
                var array = new long[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (!ValidateMValueType(currMValue.type, type))
                        return null;
                    array[i] = currMValue.GetInt();
                }

                return array;
            }

            if (type == UInt)
            {
                var array = new uint[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (!ValidateMValueType(currMValue.type, type))
                        return null;
                    array[i] = (uint) currMValue.GetUint();
                }

                return array;
            }

            if (type == ULong)
            {
                var array = new ulong[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (!ValidateMValueType(currMValue.type, type))
                        return null;
                    array[i] = currMValue.GetUint();
                }

                return array;
            }

            if (type == Double)
            {
                var array = new double[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (!ValidateMValueType(currMValue.type, type))
                        return null; //TODO: maybe return empty array or skip element
                    array[i] = currMValue.GetDouble();
                }

                return array;
            }

            /*if (type == Vehicle)
            {
                var array = System.Array.CreateInstance(type, length);
                //var array = new IVehicle[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (!ValidateMValueType(currMValue.type, type))
                        return null;
                    //array[i] = (IVehicle) ParseEntity(ref currMValue, type, entityPool);
                    array.SetValue(ParseEntity(ref currMValue, type, entityPool), i);
                }

                return array;
            }
            
            if (type == Player)
            {
                var array = new IPlayer[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (!ValidateMValueType(currMValue.type, type))
                        return null;
                    array[i] = (IPlayer) ParseEntity(ref currMValue, type, entityPool);
                }

                return array;
            }
            
            if (type == Blip)
            {
                var array = new IBlip[length];
                for (var i = 0; i < length; i++)
                {
                    var currMValue = mValues[i];
                    if (!ValidateMValueType(currMValue.type, type))
                        return null;
                    array[i] = (IBlip) ParseEntity(ref currMValue, type, entityPool);
                }

                return array;
            }*/

            //type.MakeArrayType()
            var typeArray = System.Array.CreateInstance(type, length);
            for (var i = 0; i < length; i++)
            {
                var currMValue = mValues[i];
                if (!ValidateMValueType(currMValue.type, type))
                    return null;
                typeArray.SetValue(ParseObject(ref currMValue, type, entityPool), i);
            }

            return typeArray;
        }

        private static object ParseBool(ref MValue mValue, Type type, IEntityPool entityPool)
        {
            if (mValue.type == MValue.Type.BOOL)
            {
                return mValue.GetBool();
            }

            // Types doesn't match
            return null;
        }

        private static object ParseInt(ref MValue mValue, Type type, IEntityPool entityPool)
        {
            if (mValue.type == MValue.Type.INT)
            {
                return mValue.GetInt();
            }

            // Types doesn't match
            return null;
        }

        private static object ParseUInt(ref MValue mValue, Type type, IEntityPool entityPool)
        {
            if (mValue.type == MValue.Type.UINT)
            {
                return mValue.GetUint();
            }

            // Types doesn't match
            return null;
        }

        private static object ParseDouble(ref MValue mValue, Type type, IEntityPool entityPool)
        {
            if (mValue.type == MValue.Type.DOUBLE)
            {
                return mValue.GetDouble();
            }

            // Types doesn't match
            return null;
        }

        private static object ParseString(ref MValue mValue, Type type, IEntityPool entityPool)
        {
            return mValue.type != MValue.Type.STRING ? null : mValue.GetString();
        }

        private static object ParseObject(ref MValue mValue, Type type, IEntityPool entityPool)
        {
            switch (mValue.type)
            {
                case MValue.Type.BOOL:
                    return ParseBool(ref mValue, type, entityPool);
                case MValue.Type.INT:
                    return ParseInt(ref mValue, type, entityPool);
                case MValue.Type.UINT:
                    return ParseUInt(ref mValue, type, entityPool);
                case MValue.Type.DOUBLE:
                    return ParseDouble(ref mValue, type, entityPool);
                case MValue.Type.STRING:
                    return ParseString(ref mValue, type, entityPool);
                case MValue.Type.LIST:
                    return ParseArray(ref mValue, type, entityPool);
                case MValue.Type.ENTITY:
                    return ParseEntity(ref mValue, type, entityPool);
                case MValue.Type.DICT:
                    return ParseDictionary(ref mValue, type, entityPool);
                default:
                    return false; //TODO:, func, dict, ect.
            }
        }

        //TODO: we need more type informations as an parameter, maybe make an second delegate, or add unused params to all delegates
        private static object ParseArray(ref MValue mValue, Type type, IEntityPool entityPool)
        {
            // Types doesn't match
            if (mValue.type != MValue.Type.LIST) return null;
            var mValueList = mValue.GetList();
            var elementType = type.GetElementType();
            return CreateArray(elementType, mValueList, entityPool);
        }

        private static object ParseEntity(ref MValue mValue, Type type, IEntityPool entityPool)
        {
            // Types doesn't match
            if (mValue.type != MValue.Type.ENTITY) return null;
            var entityPointer = IntPtr.Zero;
            mValue.GetEntityPointer(ref entityPointer);
            if (!entityPool.Get(entityPointer, out var entity) || !ValidateEntityType(entity.Type, type)) return null;
            return entity;
        }

        private static object ParseDictionary(ref MValue mValue, Type type, IEntityPool entityPool)
        {
            // Types doesn't match
            if (mValue.type != MValue.Type.DICT) return null;
            var args = type.GetGenericArguments();
            if (args.Length != 2) return null;
            var keyType = args[0];
            if (keyType != String) return null;
            var valueType = args[1];
            var stringViewArrayRef = StringViewArray.Nil;
            var valueArrayRef = MValueArray.Nil;
            Alt.MValueGet.MValue_GetDict(ref mValue, ref stringViewArrayRef, ref valueArrayRef);
            var stringViewArray = stringViewArrayRef.ToArray();
            var valueArray = valueArrayRef.ToArray();
            var length = stringViewArray.Length;

            if (valueType == Obj)
            {
                var dict = new Dictionary<string, object>();
                for (var i = 0; i < length; i++)
                {
                    dict[stringViewArray[i].Text] = ParseObject(ref valueArray[i], type, entityPool);
                }

                return dict;
            }

            if (valueType == Int)
            {
                var dict = new Dictionary<string, int>();
                for (var i = 0; i < length; i++)
                {
                    dict[stringViewArray[i].Text] = (int) valueArray[i].GetInt();
                }

                return dict;
            }

            if (valueType == Long)
            {
                var dict = new Dictionary<string, long>();
                for (var i = 0; i < length; i++)
                {
                    dict[stringViewArray[i].Text] = valueArray[i].GetInt();
                }

                return dict;
            }

            if (valueType == UInt)
            {
                var dict = new Dictionary<string, uint>();
                for (var i = 0; i < length; i++)
                {
                    dict[stringViewArray[i].Text] = (uint) valueArray[i].GetUint();
                }

                return dict;
            }

            if (valueType == ULong)
            {
                var dict = new Dictionary<string, ulong>();
                for (var i = 0; i < length; i++)
                {
                    dict[stringViewArray[i].Text] = valueArray[i].GetUint();
                }

                return dict;
            }

            if (valueType == Double)
            {
                var dict = new Dictionary<string, double>();
                for (var i = 0; i < length; i++)
                {
                    dict[stringViewArray[i].Text] = valueArray[i].GetDouble();
                }

                return dict;
            }

            if (valueType == String)
            {
                var dict = new Dictionary<string, string>();
                for (var i = 0; i < length; i++)
                {
                    dict[stringViewArray[i].Text] = valueArray[i].GetString();
                }

                return dict;
            }

            var dictType = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);
            var newDict = (System.Collections.IDictionary) Activator.CreateInstance(dictType);
            for (var i = 0; i < length; i++)
            {
                newDict[stringViewArray[i].Text] = ParseObject(ref valueArray[i], valueType, entityPool);
            }

            return newDict;
        }

        private static bool ValidateEntityType(EntityType entityType, Type type)
        {
            if (type == Obj)
            {
                return true;
            }

            switch (entityType)
            {
                case EntityType.Blip:
                    return type == Blip;
                case EntityType.Player:
                    return type == Player;
                case EntityType.Vehicle:
                    return type == Vehicle;
                case EntityType.Checkpoint:
                    return false; //TODO:
                default:
                    return false;
            }
        }

        private static bool ValidateMValueType(MValue.Type valueType, Type type)
        {
            if (type == Obj)
            {
                // object[] or object accepts anything
                return true;
            }

            switch (valueType)
            {
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
                    return type.BaseType == Array;
                case MValue.Type.ENTITY:
                    return type.GetInterfaces().Contains(Entity);
                case MValue.Type.FUNCTION:
                    return false; //TODO: needs to be Func or Action
                case MValue.Type.DICT:
                    return type.Name.StartsWith("Dictionary");
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
            for (int i = 0, length = genericArguments.Length; i < length; i++)
            {
                var arg = genericArguments[i];
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
                else if (arg.GetInterfaces().Contains(Entity))
                {
                    parsers[i] = ParseEntity;
                }
                else if (arg.Name.StartsWith("Dictionary"))
                {
                    parsers[i] = ParseDictionary;
                }
                else
                {
                    // Unsupported type
                    return null;
                }
            }

            return new Function(func, returnType, genericArguments, parsers);
        }

        private readonly Delegate @delegate;

        private readonly Type returnType;

        private readonly Type[] args;

        private readonly Parser[] parsers;

        private Function(Delegate @delegate, Type returnType, Type[] args, Parser[] parsers)
        {
            this.@delegate = @delegate;
            this.returnType = returnType;
            this.args = args;
            this.parsers = parsers;
        }

        //TODO: add support for nullable args, these are reducing the required length, add support for default values as well
        //TODO: make private, internal just for testing
        internal MValue Call(IEntityPool entityPool, MValue valueArgs)
        {
            if (valueArgs.type != MValue.Type.LIST) return MValue.Nil;
            var valueArgsList = valueArgs.GetList();
            var length = valueArgsList.Length;
            if (length != args.Length) return MValue.Nil;
            var invokeValues = new object[length];
            for (var i = 0; i < length; i++)
            {
                invokeValues[i] = parsers[i](ref valueArgsList[i], args[i], entityPool);
            }

            var result = @delegate.DynamicInvoke(invokeValues);
            if (returnType == Void) return MValue.Nil;
            return MValue.CreateFromObject(result) ?? MValue.Nil;
        }

        internal void call(ref MValue args, ref MValue result)
        {
            result = Call(Server.Instance.EntityPool, args);
        }
    }
}