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

        public static bool ToMValue(object obj, Type type, out MValueConst mValue)
        {
            if (Adapters.TryGetValue(type, out var adapter))
            {
                var writer = new MValueWriter2();
                adapter.ToMValue(obj, writer);
                writer.ToMValue(out mValue);
                return true;
            }

            mValue = default;
            return false;
        }

        public static bool FromMValue(in MValueConst mValue, Type type, out object obj)
        {
            switch (mValue.type)
            {
                case MValueConst.Type.LIST when Adapters.TryGetValue(type, out var adapter):
                {
                    using (var reader = new MValueReader2(in mValue))
                    {
                        obj = adapter.FromMValue(reader);
                    }

                    return true;
                }
                case MValueConst.Type.DICT when Adapters.TryGetValue(type, out var adapter):
                    using (var reader = new MValueReader2(in mValue))
                    {
                        obj = adapter.FromMValue(reader);
                    }

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