using System.Collections.Generic;

namespace AltV.Net.Example
{
    public class ConvertibleObject : IMValueConvertible
    {
        private class ConvertibleObjectAdapter : IMValueAdapter<ConvertibleObject>
        {
            private readonly IMValueAdapter<List<ConvertibleObject>> listAdapter;

            public ConvertibleObjectAdapter()
            {
                listAdapter = DefaultAdapters.GetArrayAdapter(this);
            }

            public ConvertibleObject FromMValue(MValueReader reader)
            {
                reader.BeginObject();
                string test = null;
                List<ConvertibleObject> list = null;
                while (reader.HasNext())
                {
                    switch (reader.NextName())
                    {
                        case "test":
                            test = reader.NextString();
                            break;
                        case "list":
                            list = listAdapter.FromMValue(reader);
                            break;
                        default:
                            reader.SkipValue();
                            break;
                    }
                }

                reader.EndObject();
                return test == null ? null : new ConvertibleObject(test, list);
            }

            public void ToMValue(ConvertibleObject value, MValueWriter writer)
            {
                writer.BeginObject();
                writer.Name("test");
                writer.Value(value.test);
                listAdapter.ToMValue(value, writer);
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

        private readonly List<ConvertibleObject> list;

        public ConvertibleObject()
        {
            test = "123";
            list = new List<ConvertibleObject>();
        }

        private ConvertibleObject(string test, List<ConvertibleObject> list)
        {
            this.test = test;
            this.list = list;
        }

        public IMValueBaseAdapter GetAdapter()
        {
            return MyAdapter;
        }
    }
}