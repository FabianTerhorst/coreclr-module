using System.Collections;
using System.Collections.Generic;
using Entity;

namespace AltV.Net.NetworkingEntity.Elements.Args
{
    public static class MValueUtils
    {
        public static object FromMValue(MValue mValue)
        {
            if (mValue == null) return null;
            switch (mValue.MValueCase)
            {
                case MValue.MValueOneofCase.StringValue:
                    return mValue.StringValue;
                case MValue.MValueOneofCase.BoolValue:
                    return mValue.BoolValue;
                case MValue.MValueOneofCase.IntValue:
                    return mValue.IntValue;
                case MValue.MValueOneofCase.UintValue:
                    return mValue.UintValue;
                case MValue.MValueOneofCase.DoubleValue:
                    return mValue.DoubleValue;
                case MValue.MValueOneofCase.DictionaryValue:
                    var dictionary = new Dictionary<string, object>();
                    foreach (var (key, dictValue) in mValue.DictionaryValue.Value)
                    {
                        dictionary[key] = FromMValue(dictValue);
                    }

                    return dictionary;
                case MValue.MValueOneofCase.ListValue:
                    var list = new List<object>();
                    foreach (var curr in mValue.ListValue.Value)
                    {
                        list.Add(FromMValue(curr));
                    }

                    return list;
                default:
                    return null;
            }
        }
        
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
                case int currValue:
                    return new MValue {IntValue = currValue};
                case uint currValue:
                    return new MValue {UintValue = currValue};
                case short currValue:
                    return new MValue {IntValue = currValue};
                case ushort currValue:
                    return new MValue {UintValue = currValue};
                case float currValue:
                    return new MValue {DoubleValue = currValue};
                default:
                    return new MValue {NullValue = false};
            }
        }
    }
}