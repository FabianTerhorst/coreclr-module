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
        /// Set the net owner of the current entity.
        /// </summary>
        /// <param name="player">The player that is the net owner of this entity</param>
        /// <param name="disableMigration">Setting this true will prevent other players getting network owner.</param>
        void SetNetworkOwner(IPlayer player, bool disableMigration = true);

        /// <summary>
        /// Resets the net owner of the current entity and set it to default calculations.
        /// </summary>
        public void ResetNetworkOwner(bool disableMigration = false);

        /// <summary>
        /// Set synced meta data of the entity.
        /// </summary>
        /// <remarks>Synced meta data is accessible across different serverside resources and across all clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void SetSyncedMetaData(string key, object value);

        /// <summary>
        /// Get synced meta data of the entity.
        /// </summary>
        /// <remarks>Synced meta data is accessible across different serverside resources and across all clients.</remarks>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool GetSyncedMetaData<T>(string key, out T result);

        /// <summary>
        /// Set synced meta data of the entity.
        /// </summary>
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void SetStreamSyncedMetaData(string key, object value);

        /// <summary>
        /// Get synced meta data of the entity.
        /// </summary>
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool GetStreamSyncedMetaData<T>(string key, out T result);

        /// <summary>
        /// Sets the synced meta data of an entity.
        /// </summary>
        /// <remarks>Synced meta data is accessible across different serverside resources and across all clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetSyncedMetaData(string key, in MValueConst value);

        /// <summary>
        /// Gets the synced meta data of an entity.
        /// </summary>
        /// <remarks>Synced meta data is accessible across different serverside resources and across all clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void GetSyncedMetaData(string key, out MValueConst value);

        /// <summary>
        /// Set synced meta data of the entity.
        /// </summary>
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void SetStreamSyncedMetaData(string key, in MValueConst value);

        /// <summary>
        /// Get synced meta data of the entity.
        /// </summary>
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void GetStreamSyncedMetaData(string key, out MValueConst value);
        
        /// <summary>
        /// Checks if a synced meta data key is set on an entity.
        /// </summary>
        /// <remarks>Synced meta data is accessible across different serverside resources and across all clients.</remarks>
        /// <param name="key"></param>
        /// <returns></returns>
        bool HasSyncedMetaData(string key);

        /// <summary>
        /// Deletes synced meta data from an entity.
        /// </summary>
        /// <remarks>Synced meta data is accessible across different serverside resources and across all clients.</remarks>
        /// <param name="key"></param>
        void DeleteSyncedMetaData(string key);

        /// <summary>
        /// Checks if a stream synced meta data key is set on an entity.
        /// </summary>
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <returns></returns>
        bool HasStreamSyncedMetaData(string key);

        /// <summary>
        /// Deletes stream synced meta data from an entity.
        /// </summary>
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <returns></returns>
        void DeleteStreamSyncedMetaData(string key);
    }

    public static class EntityExtensions
    {
        public static bool GetSyncedMetaData(this IEntity entity, string key, out int result)
        {
            entity.CheckIfEntityExists();
            entity.GetSyncedMetaData(key, out var mValue);
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
        
        public static bool GetSyncedMetaData(this IEntity entity, string key, out uint result)
        {
            entity.CheckIfEntityExists();
            entity.GetSyncedMetaData(key, out var mValue);
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
        
        public static bool GetSyncedMetaData(this IEntity entity, string key, out float result)
        {
            entity.CheckIfEntityExists();
            entity.GetSyncedMetaData(key, out var mValue);
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
        
        public static bool GetStreamSyncedMetaData(this IEntity entity, string key, out int result)
        {
            entity.CheckIfEntityExists();
            entity.GetStreamSyncedMetaData(key, out var mValue);
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
        
        public static bool GetStreamSyncedMetaData(this IEntity entity, string key, out uint result)
        {
            entity.CheckIfEntityExists();
            entity.GetStreamSyncedMetaData(key, out var mValue);
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
        
        public static bool GetStreamSyncedMetaData(this IEntity entity, string key, out float result)
        {
            entity.CheckIfEntityExists();
            entity.GetStreamSyncedMetaData(key, out var mValue);
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