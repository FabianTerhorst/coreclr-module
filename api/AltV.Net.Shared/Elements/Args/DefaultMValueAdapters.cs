using System.Collections.Generic;

namespace AltV.Net.Elements.Args
{
    public static class DefaultMValueAdapters
    {
        public class DefaultArrayAdapter<T> : IMValueAdapter<List<T>>
        {
            private readonly IMValueAdapter<T> elementAdapter;

            public DefaultArrayAdapter(IMValueAdapter<T> elementAdapter)
            {
                this.elementAdapter = elementAdapter;
            }

            public List<T> FromMValue(IMValueReader reader)
            {
                var list = new List<T>();
                reader.BeginArray();
                while (reader.HasNext())
                {
                    list.Add(elementAdapter.FromMValue(reader));
                }

                reader.EndArray();
                return list;
            }

            public void ToMValue(List<T> list, IMValueWriter writer)
            {
                writer.BeginArray();
                foreach (var element in list)
                {
                    elementAdapter.ToMValue(element, writer);
                }

                writer.EndArray();
            }

            object IMValueBaseAdapter.FromMValue(IMValueReader reader)
            {
                return FromMValue(reader);
            }

            public void ToMValue(object obj, IMValueWriter writer)
            {
                if (obj is List<T> list)
                {
                    ToMValue(list, writer);
                }
                else
                {
                    writer.BeginArray();
                    writer.EndArray();
                }
            }
        }

        public class DefaultDictionaryAdapter<T> : IMValueAdapter<IDictionary<string, T>>
        {
            private readonly IMValueAdapter<T> elementAdapter;

            public DefaultDictionaryAdapter(IMValueAdapter<T> elementAdapter)
            {
                this.elementAdapter = elementAdapter;
            }

            public IDictionary<string, T> FromMValue(IMValueReader reader)
            {
                var dictionary = new Dictionary<string, T>();
                reader.BeginObject();
                while (reader.HasNext())
                {
                    var key = reader.NextName();
                    dictionary[key] = elementAdapter.FromMValue(reader);
                }

                reader.EndObject();
                return dictionary;
            }

            public void ToMValue(IDictionary<string, T> dictionary, IMValueWriter writer)
            {
                writer.BeginObject();
                foreach (var (key, value) in dictionary)
                {
                    writer.Name(key);
                    elementAdapter.ToMValue(value, writer);
                }

                writer.EndObject();
            }

            object IMValueBaseAdapter.FromMValue(IMValueReader reader)
            {
                return FromMValue(reader);
            }

            public void ToMValue(object obj, IMValueWriter writer)
            {
                if (obj is IDictionary<string, T> list)
                {
                    ToMValue(list, writer);
                }
                else
                {
                    writer.BeginObject();
                    writer.EndObject();
                }
            }
        }

        public static IMValueAdapter<List<T>> GetArrayAdapter<T>(IMValueAdapter<T> elementAdapter)
        {
            return new DefaultArrayAdapter<T>(elementAdapter);
        }

        public static IMValueAdapter<IDictionary<string, T>> GetDictionaryAdapter<T>(IMValueAdapter<T> elementAdapter)
        {
            return new DefaultDictionaryAdapter<T>(elementAdapter);
        }
    }
}