using AltV.Net.Elements.Args;

namespace AltV.Net.Shared.Serialization.Serializers;

public class ValueTupleSerializer<T1, T2> : MValueSerializerBase<ValueTuple<T1, T2>>
{
    private readonly IMValueSerializer<T1> _lazyItem1Serializer;
    private readonly IMValueSerializer<T2> _lazyItem2Serializer;

    public ValueTupleSerializer(ISharedCore core) : base(core)
    {
        _lazyItem1Serializer = core.SerializerRegistry.GetSerializer<T1>();
        _lazyItem2Serializer = core.SerializerRegistry.GetSerializer<T2>();
    }

    public override ValueTuple<T1, T2> Deserialize(MValueConst mValueConst)
    {
        var list = mValueConst.GetList();
        return new ValueTuple<T1, T2>(_lazyItem1Serializer.Deserialize(list[0]), _lazyItem2Serializer.Deserialize(list[1]));
    }

    public override MValueConst Serialize(ValueTuple<T1, T2> value)
    {
        _core.CreateMValueList(out var mValue, new[]
        {
            _lazyItem1Serializer.Serialize(value.Item1),
            _lazyItem2Serializer.Serialize(value.Item2)
        }, 2);
        return mValue;
    }
}