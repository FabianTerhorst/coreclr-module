using System;

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
        /// Sets the given object into the meta data with the given key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetMetaData(string key, object value);

        bool GetMetaData<T>(string key, out T result);

        void SetData(string key, object value);

        bool GetData<T>(string key, out T result);
    }
}