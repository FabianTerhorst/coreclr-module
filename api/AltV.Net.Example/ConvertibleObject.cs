using System.Collections.Generic;
using AltV.Net.Elements.Args;

namespace AltV.Net.Example
{
    public class ConvertibleObject : IMValueConvertible
    {
        public class ConvertibleObjectAdapter : IMValueAdapter<ConvertibleObject>
        {
            private readonly IMValueAdapter<List<ChildConvertibleObject>> listAdapter;

            public ConvertibleObjectAdapter()
            {
                listAdapter = DefaultMValueAdapters.GetArrayAdapter(ChildConvertibleObject.Adapter);
            }

            public ConvertibleObject FromMValue(IMValueReader reader)
            {
                reader.BeginObject();
                string test = null;
                List<ChildConvertibleObject> list = null;
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

            public void ToMValue(ConvertibleObject value, IMValueWriter writer)
            {
                writer.BeginObject();
                writer.Name("test");
                writer.Value(value.Test);
                writer.Name("list");
                listAdapter.ToMValue(value.List, writer);
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

        private static readonly IMValueBaseAdapter MyAdapter = new ConvertibleObjectAdapter();

        public readonly string Test;

        public readonly List<ChildConvertibleObject> List;

        public ConvertibleObject()
        {
            Test = "123";
            List = new List<ChildConvertibleObject>
            {
                new ChildConvertibleObject(), new ChildConvertibleObject(), new ChildConvertibleObject()
            };
        }

        private ConvertibleObject(string test, List<ChildConvertibleObject> list)
        {
            this.Test = test;
            this.List = list;
        }

        public IMValueBaseAdapter GetAdapter()
        {
            return MyAdapter;
        }
    }
}