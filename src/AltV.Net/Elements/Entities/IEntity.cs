using AltV.Net.Data;

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
    }
}