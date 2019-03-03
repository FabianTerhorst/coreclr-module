using System;
using System.Collections.Generic;

namespace AltV.Net.Elements.Args
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

        public static bool FromMValue(ref MValue mValue, Type type, out object obj)
        {
            switch (mValue.type)
            {
                case MValue.Type.LIST when Adapters.TryGetValue(type, out var adapter):
                {
                    obj = adapter.FromMValue(new MValueReader(ref mValue));
                    return true;
                }
                case MValue.Type.DICT when Adapters.TryGetValue(type, out var adapter):
                    obj = adapter.FromMValue(new MValueReader(ref mValue));
                    return true;
                default:
                    obj = null;
                    return false;
            }
        }

        public static bool FromObject(object obj, Type type, out object result)
        {
            if (Adapters.TryGetValue(type, out var adapter))
            {
                result = adapter.FromMValue(new MValueObjectReader(obj));
                return true;
            }

            result = null;
            return false;
        }

        public static bool IsConvertible(Type type)
        {
            return Adapters.ContainsKey(type);
        }
    }
}