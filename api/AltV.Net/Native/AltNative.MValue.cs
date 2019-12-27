using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Native
{
    internal partial class AltNative
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class MValueNative
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Invoker_Create(IntPtr resource, MValueFunctionCallback val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Invoker_Destroy(IntPtr resource, IntPtr val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool MValueConst_GetBool(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern long MValueConst_GetInt(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ulong MValueConst_GetUInt(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern double MValueConst_GetDouble(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool MValueConst_GetString(IntPtr mValueConst, ref IntPtr value, ref ulong size);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ulong MValueConst_GetListSize(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool MValueConst_GetList(IntPtr mValueConst, IntPtr[] values);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ulong MValueConst_GetDictSize(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool MValueConst_GetDict(IntPtr mValueConst, IntPtr[] keys, IntPtr[] values);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr MValueConst_GetEntity(IntPtr mValueConst, ref BaseObjectType type);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr MValueConst_CallFunction(IntPtr core, IntPtr mValueConst, IntPtr[] val, ulong size);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValueConst_AddRef(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValueConst_RemoveRef(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void MValueConst_Delete(IntPtr mValueCons);

            //[DllImport(DllName, CallingConvention = NativeCallingConvention)]
            //internal static extern void MValue_Delete(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte MValueConst_GetType(IntPtr mValueConst);

            /*[DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte MValue_GetType(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool MValue_GetBool(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern long MValue_GetInt(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ulong MValue_GetUInt(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern double MValue_GetDouble(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool MValue_GetString(IntPtr mValueConst, ref IntPtr value, ref ulong size);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ulong MValue_GetListSize(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool MValue_GetList(IntPtr mValueConst, IntPtr[] values);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ulong MValue_GetDictSize(IntPtr mValueConst);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool MValue_GetDict(IntPtr mValueConst, IntPtr[] keys, IntPtr[] values);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr MValue_GetEntity(IntPtr mValueConst, ref BaseObjectType type);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr MValue_CallFunction(IntPtr mValueConst, IntPtr[] val, ulong size);*/
        }
    }
}