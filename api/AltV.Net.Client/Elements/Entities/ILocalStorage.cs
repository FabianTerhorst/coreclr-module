namespace AltV.Net.Client.Elements.Entities
{
    public interface ILocalStorage
    {
        void Delete(string key);

        void DeleteAll(string key);

        object Get(string key);

        void Save();

        void Set(string key, object value);
    }
}