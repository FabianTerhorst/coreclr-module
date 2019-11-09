using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Args
{
    /// <summary>
    /// MValue's created via ICore after MValue's
    /// </summary>
    public struct MValue2: IDisposable
    {
        public static MValue2 Nil = new MValue2(MValueConst.Type.NIL, IntPtr.Zero);
        
        public static MValue2[] CreateFrom(IntPtr[] pointers)
        {
            int length = pointers.Length;
            var mValues = new MValue2[length];
            for (var i = 0; i < length; i++)
            {
                mValues[i] = new MValue2(pointers[i]);
            }

            return mValues;
        }
        
        public readonly IntPtr nativePointer;
        public readonly MValueConst.Type type;

        public MValue2(MValueConst.Type type, IntPtr nativePointer)
        {
            this.nativePointer = nativePointer;
            this.type = type;
        }

        public MValue2(IntPtr nativePointer)
        {
            this.nativePointer = nativePointer;
            this.type = (MValueConst.Type) AltNative.MValueNative.MValue_GetType(nativePointer);
        }
        
        public bool GetBool()
        {
            return AltNative.MValueNative.MValue_GetBool(nativePointer);
        }

        public long GetInt()
        {
            return AltNative.MValueNative.MValue_GetInt(nativePointer);
        }

        public ulong GetUint()
        {
            return AltNative.MValueNative.MValue_GetUInt(nativePointer);
        }

        public double GetDouble()
        {
            return AltNative.MValueNative.MValue_GetDouble(nativePointer);
        }

        public string GetString()
        {
            var value = IntPtr.Zero;
            ulong size = 0;
            AltNative.MValueNative.MValue_GetString(nativePointer, ref value, ref size);
            return Marshal.PtrToStringUTF8(value, (int) size);
        }

        public IntPtr GetEntityPointer(ref BaseObjectType baseObjectType)
        {
            return AltNative.MValueNative.MValue_GetEntity(nativePointer, ref baseObjectType);
        }

        public IBaseObject GetBaseObject()
        {
            var baseObjectType = BaseObjectType.Undefined;
            var baseObjectPtr = GetEntityPointer(ref baseObjectType);
            Alt.Module.BaseBaseObjectPool.Get(baseObjectPtr, baseObjectType, out var baseObject);
            return baseObject;
        }

        public MValue2[] GetList()
        {
            var size = AltNative.MValueNative.MValueConst_GetListSize(nativePointer);
            var mValuePointers = new IntPtr[size];
            AltNative.MValueNative.MValueConst_GetList(nativePointer, mValuePointers);
            return CreateFrom(mValuePointers);
        }

        public Dictionary<string, MValueConst> GetDictionary()
        {
            var size = AltNative.MValueNative.MValue_GetDictSize(nativePointer);
            var keyPointers = new IntPtr[size];
            var mValuePointers = new IntPtr[size];
            AltNative.MValueNative.MValue_GetDict(nativePointer, keyPointers, mValuePointers);

            var dictionary = new Dictionary<string, MValueConst>();

            for (ulong i = 0; i < size; i++)
            {
                dictionary[Marshal.PtrToStringUTF8(keyPointers[i])] = new MValueConst(mValuePointers[i]);
            }

            return dictionary;
        }

        public MValue2 CallFunction(MValue2[] args)
        {
            var length = (ulong) args.Length;
            var argsPointers = new IntPtr[length];
            for (ulong i = 0; i < length; i++)
            {
                argsPointers[i] = args[i].nativePointer;
            }

            return new MValue2(AltNative.MValueNative.MValue_CallFunction(nativePointer, argsPointers, length));
        }

        public object ToObject()
        {
            switch (type)
            {
                case MValueConst.Type.NIL:
                    return null;
                case MValueConst.Type.BOOL:
                    return GetBool();
                case MValueConst.Type.INT:
                    return GetInt();
                case MValueConst.Type.UINT:
                    return GetUint();
                case MValueConst.Type.DOUBLE:
                    return GetDouble();
                case MValueConst.Type.STRING:
                    return GetString();
                case MValueConst.Type.LIST:
                    var listSize = AltNative.MValueNative.MValueConst_GetListSize(nativePointer);
                    var mValueListPointers = new IntPtr[listSize];
                    AltNative.MValueNative.MValueConst_GetList(nativePointer, mValueListPointers);
                    var arrayValues = new object[listSize];
                    for (ulong i = 0; i < listSize; i++)
                    {
                        arrayValues[i] = new MValueConst(mValueListPointers[i]).ToObject();
                    }

                    return arrayValues;
                case MValueConst.Type.DICT:
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
                case MValueConst.Type.ENTITY:
                    var entityType = BaseObjectType.Undefined;
                    var entityPointer = GetEntityPointer(ref entityType);
                    if (entityPointer == IntPtr.Zero) return null;
                    if (Alt.Module.BaseBaseObjectPool.Get(entityPointer, entityType, out var entity))
                    {
                        return entity;
                    }

                    return null;
                case MValueConst.Type.FUNCTION:
                    return null;
                default:
                    return null;
            }
        }

        public void Dispose()
        {
            // Nil types have zero int ptr to reduce allocations on heap
            if (nativePointer == IntPtr.Zero) return;
            AltNative.MValueNative.MValue_Delete(nativePointer);
        }
    }
}