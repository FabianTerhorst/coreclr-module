using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            if (nativePointer == IntPtr.Zero)
            {
                this.type = Type.NIL;
            }
            else
            {
                this.type = (Type) AltNative.MValueNative.MValueConst_GetType(nativePointer);
            }
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
            if (size == 0) return new MValueConst[] { };
            var mValuePointers = new IntPtr[size];
            AltNative.MValueNative.MValueConst_GetList(nativePointer, mValuePointers);
            return CreateFrom(mValuePointers);
        }

        public Dictionary<string, MValueConst> GetDictionary()
        {
            var size = AltNative.MValueNative.MValueConst_GetDictSize(nativePointer);
            if (size == 0) return new Dictionary<string, MValueConst>();
            var keyPointers = new IntPtr[size];
            var mValuePointers = new IntPtr[size];
            AltNative.MValueNative.MValueConst_GetDict(nativePointer, keyPointers, mValuePointers);

            var dictionary = new Dictionary<string, MValueConst>();

            for (ulong i = 0; i < size; i++)
            {
                var keyPointer = keyPointers[i];
                var mValue = new MValueConst(mValuePointers[i]);
                dictionary[Marshal.PtrToStringUTF8(keyPointer)] = mValue;
                AltNative.FreeCharArray(keyPointer);
                mValue.Dispose();
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

            result = new MValueConst(
                AltNative.MValueNative.MValueConst_CallFunction(Alt.Server.NativePointer, nativePointer, argsPointers, length));
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
                    if (listSize == 0) return new MValueConst[] {};
                    var mValueListPointers = new IntPtr[listSize];
                    AltNative.MValueNative.MValueConst_GetList(nativePointer, mValueListPointers);
                    var arrayValues = new object[listSize];
                    for (ulong i = 0; i < listSize; i++)
                    {
                        var mValue = new MValueConst(mValueListPointers[i]);
                        arrayValues[i] = mValue.ToObject();
                        mValue.Dispose();
                    }

                    return arrayValues;
                case Type.DICT:
                    var size = AltNative.MValueNative.MValueConst_GetDictSize(nativePointer);
                    if (size == 0) return new Dictionary<string, MValueConst>();
                    var keyPointers = new IntPtr[size];
                    var mValuePointers = new IntPtr[size];
                    if (!AltNative.MValueNative.MValueConst_GetDict(nativePointer, keyPointers, mValuePointers))
                        return null;

                    var dictionary = new Dictionary<string, object>();

                    for (ulong i = 0; i < size; i++)
                    {
                        var keyPointer = keyPointers[i];
                        var mValue = new MValueConst(mValuePointers[i]);
                        dictionary[Marshal.PtrToStringUTF8(keyPointer)] = mValue.ToObject();
                        AltNative.FreeCharArray(keyPointer);
                        mValue.Dispose();
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

        public override string ToString()
        {
            switch (type)
            {
                case Type.NIL:
                    return "MValueNil<>";
                case Type.BOOL:
                    return "MValueBool<" + GetBool().ToString() + ">";
                case Type.INT:
                    return "MValueInt<" + GetInt().ToString() + ">";
                case Type.UINT:
                    return "MValueUInt<" + GetUint().ToString() + ">";
                case Type.DOUBLE:
                    return "MValueDouble<" + GetDouble().ToString(CultureInfo.InvariantCulture) + ">";
                case Type.STRING:
                    return "MValueString<" + GetString() + ">";
                case Type.LIST:
                    return "MValueList<{" + GetList().Aggregate("", (current, value) =>
                    {
                        var result = current + value.ToString() + ",";
                        value.Dispose();
                        return result;
                    }) + "}>";
                case Type.DICT:
                    return "MValueDict<{" + GetDictionary().Aggregate("",
                               (current, value) =>
                               {
                                   var (key, mValueConst) = value;
                                   var result = current + key.ToString() + "=" + mValueConst.ToString() + ",";
                                   mValueConst.Dispose();
                                   return result;
                               }) + "}>";
                case Type.ENTITY:
                    var entityType = BaseObjectType.Undefined;
                    var ptr = GetEntityPointer(ref entityType);
                    if (ptr == IntPtr.Zero) return $"MValue<entity:nilptr>";
                    if (Alt.Module.BaseBaseObjectPool.Get(ptr, entityType, out var entity))
                    {
                        return $"MValue<{entity.Type.ToString()}>";
                    }

                    return "MValue<Entity>";
                case Type.FUNCTION:
                    return "MValue<Function>";
            }

            return "MValue<>";
        }

        public void AddRef()
        {
            // Nil types have zero int ptr to reduce allocations on heap
            if (nativePointer == IntPtr.Zero) return;
            AltNative.MValueNative.MValueConst_AddRef(nativePointer);
        }

        public void RemoveRef()
        {
            // Nil types have zero int ptr to reduce allocations on heap
            if (nativePointer == IntPtr.Zero) return;
            AltNative.MValueNative.MValueConst_RemoveRef(nativePointer);
        }

        public void Dispose()
        {
            // Nil types have zero int ptr to reduce allocations on heap
            if (nativePointer == IntPtr.Zero) return;
            AltNative.MValueNative.MValueConst_Delete(nativePointer);
        }
    }
}