using System;
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
        /// Sets the given object into the meta data with the given key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="EntityRemovedException">This entity was deleted before</exception>
        void SetMetaData(string key, object value);

        bool GetMetaData<T>(string key, out T result);

        void SetMetaData(string key, in MValueConst value);

        void GetMetaData(string key, out MValueConst value);

        void SetData(string key, object value);

        bool GetData<T>(string key, out T result);

        void CheckIfEntityExists();

        void OnRemove();
    }

    public static class BaseObjectExtensions
    {
        public static bool GetMetaData(this IBaseObject baseObject, string key, out int result)
        {
            baseObject.CheckIfEntityExists();
            baseObject.GetMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.INT)
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
                if (mValue.type != MValueConst.Type.UINT)
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
                if (mValue.type != MValueConst.Type.DOUBLE)
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