using System.Collections;
using System.Collections.Generic;
using Entity;

namespace AltV.Net.NetworkingEntity
{
    public static class MValueUtils
    {
        public static MValue ToMValue(object value)
        {
            if (value == null) return new MValue {NullValue = false};
            switch (value)
            {
                case string currValue:
                    return new MValue {StringValue = currValue};
                case bool currValue:
                    return new MValue {BoolValue = currValue};
                case long currValue:
                    return new MValue {IntValue = currValue};
                case ulong currValue:
                    return new MValue {UintValue = currValue};
                case double currValue:
                    return new MValue {DoubleValue = currValue};
                case IDictionary<string, object> currValue:
                    var dictionaryMValue = new DictionaryMValue();
                    foreach (var (key, dictValue) in currValue)
                    {
                        dictionaryMValue.Value[key] = ToMValue(dictValue);
                    }

                    return new MValue {DictionaryValue = dictionaryMValue};
                case ICollection currValue:
                    var listMValue = new ListMValue();
                    foreach (var curr in currValue)
                    {
                        listMValue.Value.Add(ToMValue(curr));
                    }

                    return new MValue {ListValue = listMValue};
                default:
                    return new MValue {NullValue = false};
            }
        }
    }
}