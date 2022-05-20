using System;
using System.Collections.Generic;

namespace AltV.Net.Elements.Args
{
    public static class MValueAdapters
    {
        [Obsolete("Use Alt.RegisterMValueAdapter instead")]
        public static void Register<T>(IMValueAdapter<T> adapter)
        {
            Alt.LogWarning("MValueAdapters.Register is deprecated, use Alt.RegisterMValueAdapter instead");
            Alt.Core.RegisterMValueAdapter(adapter);
        }

        [Obsolete("Use Alt.ToMValue instead")]
        public static bool ToMValue(object obj, Type type, out MValueConst mValue)
        {
            Alt.LogWarning("MValueAdapters.ToMValue is deprecated, use Alt.ToMValue instead");
            return Alt.Core.ToMValue(obj, type, out mValue);
        }

        [Obsolete("Use Alt.FromMValue instead")]
        public static bool FromMValue(in MValueConst mValue, Type type, out object obj)
        {
            Alt.LogWarning("MValueAdapters.FromMValue is deprecated, use Alt.FromMValue instead");
            return Alt.Core.FromMValue(mValue, type, out obj);
        }

        [Obsolete("Use Alt.MValueFromObject instead")]
        public static bool FromObject(object obj, Type type, out object result)
        {
            Alt.LogWarning("MValueAdapters.FromObject is deprecated, use Alt.MValueFromObject instead");
            return Alt.Core.MValueFromObject(obj, type, out result);
        }

        [Obsolete("Use Alt.IsMValueConvertible instead")]
        public static bool IsConvertible(Type type)
        {
            Alt.LogWarning("MValueAdapters.IsConvertible is deprecated, use Alt.IsMValueConvertible instead");
            return Alt.Core.IsMValueConvertible(type);
        }
    }
}