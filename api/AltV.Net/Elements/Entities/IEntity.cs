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
        /// Get or set visibility of the entity.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool Visible { get; set; }

        /// <summary>
        /// Get or set if the entity should be streamed.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool Streamed { get; set; }

        /// <summary>
        /// Set the net owner of the current entity.
        /// </summary>
        /// <param name="player">The player that is the net owner of this entity</param>
        /// <param name="disableMigration">Setting this true will prevent other players getting network owner.</param>
        void SetNetworkOwner(IPlayer player, bool disableMigration = true);

        /// <summary>
        /// Resets the net owner of the current entity and set it to default calculations.
        /// </summary>
        public void ResetNetworkOwner();

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
        /// Gets the synced meta data of an entity.
        /// </summary>
        /// <remarks>Synced meta data is accessible across different serverside resources and across all clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        bool GetSyncedMetaData(string key, out int value);

        /// <summary>
        /// Gets the synced meta data of an entity.
        /// </summary>
        /// <remarks>Synced meta data is accessible across different serverside resources and across all clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        bool GetSyncedMetaData(string key, out uint value);

        /// <summary>
        /// Gets the synced meta data of an entity.
        /// </summary>
        /// <remarks>Synced meta data is accessible across different serverside resources and across all clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        bool GetSyncedMetaData(string key, out float value);

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
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void GetStreamSyncedMetaData(string key, out MValueConst value);

        /// <summary>
        /// Get synced meta data of the entity.
        /// </summary>
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool GetStreamSyncedMetaData(string key, out int value);

        /// <summary>
        /// Get synced meta data of the entity.
        /// </summary>
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool GetStreamSyncedMetaData(string key, out uint value);

        /// <summary>
        /// Get synced meta data of the entity.
        /// </summary>
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool GetStreamSyncedMetaData(string key, out float value);
        
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

        /// <summary>
        /// Attaches the entity to another entity.
        /// </summary>
        void AttachToEntity(IEntity entity, short otherBone, short ownBone, Position position, Rotation rotation, bool collision, bool noFixedRotation);

        /// <summary>
        /// Detaches the entity from its attached entity.
        /// </summary>
        void Detach();
    }
}