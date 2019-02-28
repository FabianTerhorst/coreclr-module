namespace AltV.Net.Example
{
    public class ConvertibleObject : IMValueConvertible
    {
        public class ConvertibleObjectAdapter : IMValueAdapter<ConvertibleObject>
        {
            public ConvertibleObject FromMValue(MValueReader reader)
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
                return test == null ? null : new ConvertibleObject(test);
            }

            public void ToMValue(ConvertibleObject value, MValueWriter writer)
            {
                writer.BeginObject();
                writer.Name("test");
                writer.Value(value.test);
                writer.EndObject();
            }

            object IMValueBaseAdapter.FromMValue(MValueReader reader)
            {
                return FromMValue(reader);
            }

            public void ToMValue(object obj, MValueWriter writer)
            {
                if (obj is ConvertibleObject value)
                {
                    ToMValue(value, writer);
                }
            }
        }

        private static readonly IMValueBaseAdapter MyAdapter = new ConvertibleObjectAdapter();

        private readonly string test;

        public ConvertibleObject()
        {
            test = "123";
        }

        private ConvertibleObject(string test)
        {
            this.test = test;
        }

        public IMValueBaseAdapter GetAdapter()
        {
            return MyAdapter;
        }
    }
}