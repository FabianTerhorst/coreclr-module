using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Types;

namespace AltV.Net.Shared.Elements.Entities
{
    public interface ISharedBaseObject : IRefCountable
    {
        IntPtr BaseObjectNativePointer { get; }
        BaseObjectType Type { get; }
        ISharedCore Core { get; }

        
        /// <summary>
        /// Sets the given object into the meta data with the given key.
        /// </summary>
        /// <remarks>Meta data is accessible across different serverside resources.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="EntityRemovedException">This entity was deleted before</exception>
        void SetMetaData(string key, object value);

        /// <summary>
        /// Returns meta data for a given key.
        /// </summary>
        /// <remarks>Meta data is accessible across different serverside resources.</remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        bool GetMetaData<T>(string key, out T result);

        /// <summary>
        /// Sets the given object into the meta data with the given key.
        /// </summary>
        /// <remarks>Meta data is accessible across different serverside resources.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="EntityRemovedException">This entity was deleted before</exception>
        void SetMetaData(string key, in MValueConst value);

        /// <summary>
        /// Returns meta data for a given key.
        /// </summary>
        /// <remarks>Meta data is accessible across different serverside resources.</remarks>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        void GetMetaData(string key, out MValueConst result);

        /// <summary>
        /// Checks if the entity has a given meta data key.
        /// </summary>
        /// <remarks>Meta data is accessible across different serverside resources.</remarks>
        /// <param name="key"></param>
        /// <returns></returns>
        bool HasMetaData(string key);

        /// <summary>
        /// Deletes a meta data key from an entity.
        /// </summary>
        /// <remarks>Meta data is accessible across different serverside resources.</remarks>
        /// <param name="key"></param>
        void DeleteMetaData(string key);

        bool GetMetaData(string key, out int result);

        bool GetMetaData(string key, out uint result);

        bool GetMetaData(string key, out float result);

        /// <summary>
        /// Sets a value with a given on an entity.
        /// </summary>
        /// <remarks>Data is accessible only within the resource that set the data.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetData(string key, object value);

        /// <summary>
        /// Returns data for a given key.
        /// </summary>
        /// <remarks>Data is accessible only within the resource that set the data.</remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        bool GetData<T>(string key, out T result);

        /// <summary>
        /// Checks if the entity has a value for the given key.
        /// </summary>
        /// <remarks>Data is accessible only within the resource that set the data.</remarks>
        /// <param name="key"></param>
        /// <returns></returns>
        bool HasData(string key);

        /// <summary>
        /// Returns all stored data keys retrievable with <see cref="GetData{T}(string, out T)"/>
        /// </summary>
        /// <returns>IEnumerable</returns>
        IEnumerable<string> GetAllDataKeys();

        /// <summary>
        /// Deletes a value by a given key from the entity.
        /// </summary>
        /// <remarks>Data is accessible only within the resource that set the data.</remarks>
        /// <param name="key"></param>
        void DeleteData(string key);

        /// <summary>
        /// Deletes all set data from the entity.
        /// </summary>
        /// <remarks>Data is accessible only within the resource that set the data.</remarks>
        void ClearData();
        
        void OnRemove();
        
        void CheckIfEntityExists();
    }
}