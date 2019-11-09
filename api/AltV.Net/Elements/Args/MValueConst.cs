using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Args
{
    /// <summary>
    /// MValue's received from events are MValueConst
    /// </summary>
    public readonly struct MValueConst : IDisposable
    {
        public static MValueConst Nil = new MValueConst(Type.NIL, IntPtr.Zero);
        
        public enum Type : byte
        {
            NIL = 0,
            BOOL = 1,
            INT = 2,
            UINT = 3,
            DOUBLE = 4,
            STRING = 5,
            LIST = 6,
            DICT = 7,
            ENTITY = 8,
            FUNCTION = 9
        }

        public static MValueConst[] CreateFrom(IntPtr[] pointers)
        {
            int length = pointers.Length;
            var mValues = new MValueConst[length];
            for (var i = 0; i < length; i++)
            {
                mValues[i] = new MValueConst(pointers[i]);
            }

            return mValues;
        }

        public readonly IntPtr nativePointer;
        public readonly Type type;

        public MValueConst(IntPtr nativePointer)
        {
            this.nativePointer = nativePointer;
            this.type = (Type) AltNative.MValueNative.MValueConst_GetType(nativePointer);
        }
        
        public MValueConst(Type type, IntPtr nativePointer)
        {
            this.nativePointer = nativePointer;
            this.type = type;
        }

        public bool GetBool()
        {
            return AltNative.MValueNative.MValueConst_GetBool(nativePointer);
        }

        public long GetInt()
        {
            return AltNative.MValueNative.MValueConst_GetInt(nativePointer);
        }

        public ulong GetUint()
        {
            return AltNative.MValueNative.MValueConst_GetUInt(nativePointer);
        }

        public double GetDouble()
        {
            return AltNative.MValueNative.MValueConst_GetDouble(nativePointer);
        }

        public string GetString()
        {
            var value = IntPtr.Zero;
            ulong size = 0;
            AltNative.MValueNative.MValueConst_GetString(nativePointer, ref value, ref size);
            return Marshal.PtrToStringUTF8(value, (int) size);
        }

        public IntPtr GetEntityPointer(ref BaseObjectType baseObjectType)
        {
            return AltNative.MValueNative.MValueConst_GetEntity(nativePointer, ref baseObjectType);
        }

        public IBaseObject GetBaseObject()
        {
            var baseObjectType = BaseObjectType.Undefined;
            var baseObjectPtr = GetEntityPointer(ref baseObjectType);
            Alt.Module.BaseBaseObjectPool.Get(baseObjectPtr, baseObjectType, out var baseObject);
            return baseObject;
        }

        public MValueConst[] GetList()
        {
            var size = AltNative.MValueNative.MValueConst_GetListSize(nativePointer);
            var mValuePointers = new IntPtr[size];
            AltNative.MValueNative.MValueConst_GetList(nativePointer, mValuePointers);
            return CreateFrom(mValuePointers);
        }

        public Dictionary<string, MValueConst> GetDictionary()
        {
            var size = AltNative.MValueNative.MValueConst_GetDictSize(nativePointer);
            var keyPointers = new IntPtr[size];
            var mValuePointers = new IntPtr[size];
            AltNative.MValueNative.MValueConst_GetDict(nativePointer, keyPointers, mValuePointers);

            var dictionary = new Dictionary<string, MValueConst>();

            for (ulong i = 0; i < size; i++)
            {
                dictionary[Marshal.PtrToStringUTF8(keyPointers[i])] = new MValueConst(mValuePointers[i]);
            }

            return dictionary;
        }

        public void CallFunction(MValueConst[] args, out MValueConst result)
        {
            var length = (ulong) args.Length;
            var argsPointers = new IntPtr[length];
            for (ulong i = 0; i < length; i++)
            {
                argsPointers[i] = args[i].nativePointer;
            }

            result = new MValueConst(AltNative.MValueNative.MValueConst_CallFunction(nativePointer, argsPointers, length));
        }

        public object ToObject()
        {
            switch (type)
            {
                case Type.NIL:
                    return null;
                case Type.BOOL:
                    return GetBool();
                case Type.INT:
                    return GetInt();
                case Type.UINT:
                    return GetUint();
                case Type.DOUBLE:
                    return GetDouble();
                case Type.STRING:
                    return GetString();
                case Type.LIST:
                    var listSize = AltNative.MValueNative.MValueConst_GetListSize(nativePointer);
                    var mValueListPointers = new IntPtr[listSize];
                    AltNative.MValueNative.MValueConst_GetList(nativePointer, mValueListPointers);
                    var arrayValues = new object[listSize];
                    for (ulong i = 0; i < listSize; i++)
                    {
                        arrayValues[i] = new MValueConst(mValueListPointers[i]).ToObject();
                    }

                    return arrayValues;
                case Type.DICT:
                    var size = AltNative.MValueNative.MValueConst_GetDictSize(nativePointer);
                    var keyPointers = new IntPtr[size];
                    var mValuePointers = new IntPtr[size];
                    AltNative.MValueNative.MValueConst_GetDict(nativePointer, keyPointers, mValuePointers);

                    var dictionary = new Dictionary<string, object>();

                    for (ulong i = 0; i < size; i++)
                    {
                        dictionary[Marshal.PtrToStringUTF8(keyPointers[i])] =
                            new MValueConst(mValuePointers[i]).ToObject();
                    }

                    return dictionary;
                case Type.ENTITY:
                    var entityType = BaseObjectType.Undefined;
                    var entityPointer = GetEntityPointer(ref entityType);
                    if (entityPointer == IntPtr.Zero) return null;
                    if (Alt.Module.BaseBaseObjectPool.Get(entityPointer, entityType, out var entity))
                    {
                        return entity;
                    }

                    return null;
                case Type.FUNCTION:
                    return null;
                default:
                    return null;
            }
        }

        public void Dispose()
        {
            // Nil types have zero int ptr to reduce allocations on heap
            if (nativePointer == IntPtr.Zero) return;
            AltNative.MValueNative.MValueConst_Delete(nativePointer);
        }
    }
}