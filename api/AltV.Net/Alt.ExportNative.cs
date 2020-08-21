using System;

namespace AltV.Net
{
    public partial class Alt
    {
        public static void ExportNativeNative(string key, object value)
        {
            Module.Server.Resource.SetExport(key, value);
        }

        public static void ExportNative(string key, bool value)
        {
            Alt.Server.CreateMValueBool(out var mValue, value);
            Module.ModuleResource.SetExport(key, in mValue);
            mValue.Dispose();
        }

        public static void ExportNative(string key, int value)
        {
            Alt.Server.CreateMValueInt(out var mValue, value);
            Module.ModuleResource.SetExport(key, in mValue);
            mValue.Dispose();
        }

        public static void ExportNative(string key, long value)
        {
            Alt.Server.CreateMValueInt(out var mValue, value);
            Module.ModuleResource.SetExport(key, in mValue);
            mValue.Dispose();
        }

        public static void ExportNative(string key, uint value)
        {
            Alt.Server.CreateMValueUInt(out var mValue, value);
            Module.ModuleResource.SetExport(key, mValue);
            mValue.Dispose();
        }

        public static void ExportNative(string key, ulong value)
        {
            Alt.Server.CreateMValueUInt(out var mValue, value);
            Module.ModuleResource.SetExport(key, mValue);
            mValue.Dispose();
        }

        public static void ExportNative(string key, double value)
        {
            Alt.Server.CreateMValueDouble(out var mValue, value);
            Module.ModuleResource.SetExport(key,mValue);
            mValue.Dispose();
        }

        public static void ExportNative(string key, string value)
        {
            Alt.Server.CreateMValueString(out var mValue, value);
            Module.ModuleResource.SetExport(key, mValue);
            mValue.Dispose();
        }

        public static void ExportNative(string key, Delegate value)
        {
            Module.SetExport(key, Function.Create(value));
        }


        public static void ExportNative(string key, Action value)
        {
            Module.SetExport(key, Function.Create(value));
        }


        public static void ExportNative<T1>(string key, Action<T1> value)
        {
            Module.SetExport(key, Function.Create(value));
        }


        public static void ExportNative<T1, T2>(string key, Action<T1, T2> value)
        {
            Module.SetExport(key, Function.Create(value));
        }


        public static void ExportNative<T1, T2, T3>(string key, Action<T1, T2, T3> value)
        {
            Module.SetExport(key, Function.Create(value));
        }


        public static void ExportNative<T1, T2, T3, T4>(string key, Action<T1, T2, T3, T4> value)
        {
            Module.SetExport(key, Function.Create(value));
        }


        public static void ExportNative<T1, T2, T3, T4, T5>(string key, Action<T1, T2, T3, T4, T5> value)
        {
            Module.SetExport(key, Function.Create(value));
        }


        public static void ExportNative<T1, T2, T3, T4, T5, T6>(string key, Action<T1, T2, T3, T4, T5, T6> value)
        {
            Module.SetExport(key, Function.Create(value));
        }


        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7>(string key, Action<T1, T2, T3, T4, T5, T6, T7> value)
        {
            Module.SetExport(key, Function.Create(value));
        }


        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> value)
        {
            Module.SetExport(key, Function.Create(value));
        }


        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> value)
        {
            Module.SetExport(key, Function.Create(value));
        }


        public static void ExportNative<T1>(string key, Func<T1> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2>(string key, Func<T1, T2> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3>(string key, Func<T1, T2, T3> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4>(string key, Func<T1, T2, T3, T4> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5>(string key, Func<T1, T2, T3, T4, T5> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6>(string key, Func<T1, T2, T3, T4, T5, T6> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7>(string key, Func<T1, T2, T3, T4, T5, T6, T7> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> value)
        {
            Module.SetExport(key, Function.Create(value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> value)
        {
            Module.SetExport(key, Function.Create(value));
        }
    }
}