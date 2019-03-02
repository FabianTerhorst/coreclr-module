using System.Collections.Generic;

namespace AltV.Net.Elements.Args
{
    public static class DefaultMValueAdapters
    {
        //TODO: create DefaultDictionaryAdapter
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
            }
        }

        public static IMValueAdapter<List<T>> GetArrayAdapter<T>(IMValueAdapter<T> elementAdapter)
        {
            return new DefaultArrayAdapter<T>(elementAdapter);
        }
    }
}