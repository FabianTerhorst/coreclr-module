namespace AltV.Net.Example
{
    public class ChildConvertibleObject : IMValueConvertible
    {
        private class ChildConvertibleObjectAdapter : IMValueAdapter<ChildConvertibleObject>
        {
            public ChildConvertibleObjectAdapter()
            {
            }

            public ChildConvertibleObject FromMValue(IMValueReader reader)
            {
                reader.BeginObject();
                string test = null;
                while (reader.HasNext())
                {
                    switch (reader.NextName())
                    {
                        case "test":
                            test = reader.NextString();
                            break;
                        default:
                            reader.SkipValue();
                            break;
                    }
                }

                reader.EndObject();
                return test == null ? null : new ChildConvertibleObject(test);
            }

            public void ToMValue(ChildConvertibleObject value, IMValueWriter writer)
            {
                writer.BeginObject();
                writer.Name("test");
                writer.Value(value.Test);
                writer.EndObject();
            }

            object IMValueBaseAdapter.FromMValue(IMValueReader reader)
            {
                return FromMValue(reader);
            }

            public void ToMValue(object obj, IMValueWriter writer)
            {
                if (obj is ConvertibleObject value)
                {
                    ToMValue(value, writer);
                }
            }
        }

        public static readonly IMValueAdapter<ChildConvertibleObject> Adapter = new ChildConvertibleObjectAdapter();

        public readonly string Test;

        public ChildConvertibleObject()
        {
            Test = "123";
        }

        private ChildConvertibleObject(string test)
        {
            this.Test = test;
        }

        public IMValueBaseAdapter GetAdapter()
        {
            return Adapter;
        }
    }
}