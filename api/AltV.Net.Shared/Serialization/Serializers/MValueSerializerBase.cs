using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers;

public abstract class MValueSerializerBase<TValue> : IMValueSerializer<TValue>
{
    protected readonly ISharedCore _core;
    
    public MValueSerializerBase(ISharedCore core)
    {
        _core = core;
    }
    
    public Type ValueType => typeof(TValue);
    

    object IMValueSerializer.Deserialize(MValueConst mValueConst) => Deserialize(mValueConst);
    public virtual TValue Deserialize(MValueConst mValueConst)
    {
        throw new NotImplementedException();
    }
    
    MValueConst IMValueSerializer.Serialize(object value) => Serialize((TValue)value);
    public virtual MValueConst Serialize(TValue value)
    {
        throw new NotImplementedException();
    }
    
    object IMValueSerializer.DeserializeFromString(string value) => DeserializeFromString(value);
    public virtual TValue DeserializeFromString(string value)
    {
        throw new CannotConvertTypeException("string", typeof(TValue).Name);
    }

    string IMValueSerializer.SerializeToString(object value) => SerializeToString((TValue) value);
    public virtual string SerializeToString(TValue value)
    {
        throw new CannotConvertTypeException(typeof(TValue).Name, "string");
    }
}