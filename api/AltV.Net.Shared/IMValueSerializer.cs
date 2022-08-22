using AltV.Net.Elements.Args;

namespace AltV.Net
{
    public interface IMValueSerializer<TValue> : IMValueSerializer
    {
        new TValue Deserialize(IMValueConst mValueConst);
        MValueConst Serialize(TValue value);
    
        new TValue DeserializeFromString(string mValueConst);
        string SerializeToString(TValue value);
    }
    
    public interface IMValueSerializer
    {
        Type ValueType { get; }
    
        object Deserialize(IMValueConst mValueConst);
        MValueConst Serialize(object value);
    
        object DeserializeFromString(string value);
        string SerializeToString(object value);
    }
}