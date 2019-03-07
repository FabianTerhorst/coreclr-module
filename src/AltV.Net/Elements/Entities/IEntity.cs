using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public interface IEntity : IWorldObject
    {
        /// <summary>
        /// Get the entity id.
        /// </summary>
        ushort Id { get; }

        /// <summary>
        /// Get or set rotation of the entity.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Rotation Rotation { get; set; }
        
        /// <summary>
        /// Get model of the entity.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint Model { get; }

        void SetSyncedMetaData(string key, object value);

        bool GetSyncedMetaData<T>(string key, out T result);
    }
}