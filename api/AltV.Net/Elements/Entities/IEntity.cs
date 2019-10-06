using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Elements.Entities
{
    public interface IEntity : IWorldObject
    {
        /// <summary>
        /// Get the entity id.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        ushort Id { get; }
        
        /// <summary>
        /// Get the network owner, or null if none is present
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        IPlayer NetworkOwner { get; }

        /// <summary>
        /// Get or set rotation of the entity.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        Rotation Rotation { get; set; }

        /// <summary>
        /// Get model of the entity.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        uint Model { get; }

        /// <summary>
        /// Set synced meta data of the entity.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void SetSyncedMetaData(string key, object value);

        /// <summary>
        /// Get synced meta data of the entity.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool GetSyncedMetaData<T>(string key, out T result);

        void SetSyncedMetaData(string key, ref MValue value);

        void GetSyncedMetaData(string key, ref MValue value);
    }

    public static class EntityExtensions
    {
        public static bool GetSyncedMetaData(this IEntity entity, string key, out int result)
        {
            entity.CheckIfEntityExists();
            var mValue = MValue.Nil;
            entity.GetSyncedMetaData(key, ref mValue);
            if (mValue.type != MValue.Type.INT)
            {
                result = default;
                return false;
            }

            result = (int) mValue.GetInt();
            return true;
        }
        
        public static bool GetSyncedMetaData(this IEntity entity, string key, out uint result)
        {
            entity.CheckIfEntityExists();
            var mValue = MValue.Nil;
            entity.GetSyncedMetaData(key, ref mValue);
            if (mValue.type != MValue.Type.UINT)
            {
                result = default;
                return false;
            }

            result = (uint) mValue.GetUint();
            return true;
        }
        
        public static bool GetSyncedMetaData(this IEntity entity, string key, out float result)
        {
            entity.CheckIfEntityExists();
            var mValue = MValue.Nil;
            entity.GetSyncedMetaData(key, ref mValue);
            if (mValue.type != MValue.Type.DOUBLE)
            {
                result = default;
                return false;
            }

            result = (float) mValue.GetDouble();
            return true;
        }
    }
}