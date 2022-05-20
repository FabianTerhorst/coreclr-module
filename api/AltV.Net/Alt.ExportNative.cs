using System;

namespace AltV.Net
{
    public partial class Alt
    {
        public static void ExportNativeNative(string key, object value)
        {
            CoreImpl.Resource.SetExport(key, value);
        }

        public static void ExportNative(string key, bool value)
        {
            Alt.Core.CreateMValueBool(out var mValue, value);
            CoreImpl.Resource.SetExport(key, in mValue);
            mValue.Dispose();
        }

        public static void ExportNative(string key, int value)
        {
            Alt.Core.CreateMValueInt(out var mValue, value);
            CoreImpl.Resource.SetExport(key, in mValue);
            mValue.Dispose();
        }

        public static void ExportNative(string key, long value)
        {
            Alt.Core.CreateMValueInt(out var mValue, value);
            CoreImpl.Resource.SetExport(key, in mValue);
            mValue.Dispose();
        }

        public static void ExportNative(string key, uint value)
        {
            Alt.Core.CreateMValueUInt(out var mValue, value);
            CoreImpl.Resource.SetExport(key, mValue);
            mValue.Dispose();
        }

        public static void ExportNative(string key, ulong value)
        {
            Alt.Core.CreateMValueUInt(out var mValue, value);
            CoreImpl.Resource.SetExport(key, mValue);
            mValue.Dispose();
        }

        public static void ExportNative(string key, double value)
        {
            Alt.Core.CreateMValueDouble(out var mValue, value);
            CoreImpl.Resource.SetExport(key,mValue);
            mValue.Dispose();
        }

        public static void ExportNative(string key, string value)
        {
            Alt.Core.CreateMValueString(out var mValue, value);
            CoreImpl.Resource.SetExport(key, mValue);
            mValue.Dispose();
        }

        public static void ExportNative(string key, Delegate value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }


        public static void ExportNative(string key, Action value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }


        public static void ExportNative<T1>(string key, Action<T1> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }


        public static void ExportNative<T1, T2>(string key, Action<T1, T2> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }


        public static void ExportNative<T1, T2, T3>(string key, Action<T1, T2, T3> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }


        public static void ExportNative<T1, T2, T3, T4>(string key, Action<T1, T2, T3, T4> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }


        public static void ExportNative<T1, T2, T3, T4, T5>(string key, Action<T1, T2, T3, T4, T5> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }


        public static void ExportNative<T1, T2, T3, T4, T5, T6>(string key, Action<T1, T2, T3, T4, T5, T6> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }


        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7>(string key, Action<T1, T2, T3, T4, T5, T6, T7> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }


        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }


        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string key,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }


        public static void ExportNative<T1>(string key, Func<T1> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2>(string key, Func<T1, T2> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3>(string key, Func<T1, T2, T3> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4>(string key, Func<T1, T2, T3, T4> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5>(string key, Func<T1, T2, T3, T4, T5> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6>(string key, Func<T1, T2, T3, T4, T5, T6> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7>(string key, Func<T1, T2, T3, T4, T5, T6, T7> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }

        public static void ExportNative<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            string key,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> value)
        {
            CoreImpl.SetExport(key, Function.Create(Core, value));
        }
    }
}