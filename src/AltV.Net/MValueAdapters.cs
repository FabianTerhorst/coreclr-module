using System;
using System.Collections.Generic;
using AltV.Net.Native;

namespace AltV.Net
{
    public static class MValueAdapters
    {
        private static readonly Dictionary<Type, IMValueBaseAdapter> Adapters =
            new Dictionary<Type, IMValueBaseAdapter>();

        public static void Register<T>(IMValueAdapter<T> adapter)
        {
            Adapters[typeof(T)] = adapter;
        }

        public static bool ToMValue(object obj, Type type, out MValue mValue)
        {
            if (Adapters.TryGetValue(type, out var adapter))
            {
                var writer = new MValueWriter();
                adapter.ToMValue(obj, writer);
                mValue = writer.ToMValue();
                return true;
            }

            mValue = default;
            return false;
        }

        public static bool FromMValue(MValueArray mValueArray, Type type, out object obj)
        {
            if (Adapters.TryGetValue(type, out var adapter))
            {
                obj = adapter.FromMValue(new MValueReader(mValueArray.data, mValueArray.Size));
                return true;
            }

            obj = null;
            return false;
        }
    }
}