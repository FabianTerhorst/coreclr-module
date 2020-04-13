using System;
using System.Collections.Generic;
using AltV.Net.Elements.Args;

namespace AltV.Net.Elements.Entities
{
    public interface IBaseObject
    {
        /// <summary>
        /// Get the internal entity pointer.
        ///
        /// WARNING: Do NOT use this.
        /// </summary>
        IntPtr NativePointer { get; }

        /// <summary>
        /// Get current entity existence
        ///
        /// WARNING: Do NOT use this.
        /// </summary>
        bool Exists { get; }

        BaseObjectType Type { get; }

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
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        void GetMetaData(string key, out MValueConst value);

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

        void CheckIfEntityExists();

        void OnRemove();

        bool AddRef();

        bool RemoveRef();
    }

    public static class BaseObjectExtensions
    {
        public static bool GetMetaData(this IBaseObject baseObject, string key, out int result)
        {
            baseObject.CheckIfEntityExists();
            baseObject.GetMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Int)
                {
                    result = default;
                    return false;
                }

                result = (int) mValue.GetInt();
            }

            return true;
        }

        public static bool GetMetaData(this IBaseObject baseObject, string key, out uint result)
        {
            baseObject.CheckIfEntityExists();
            baseObject.GetMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Uint)
                {
                    result = default;
                    return false;
                }

                result = (uint) mValue.GetUint();
            }

            return true;
        }

        public static bool GetMetaData(this IBaseObject baseObject, string key, out float result)
        {
            baseObject.CheckIfEntityExists();
            baseObject.GetMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Double)
                {
                    result = default;
                    return false;
                }

                result = (float) mValue.GetDouble();
            }

            return true;
        }
    }
}