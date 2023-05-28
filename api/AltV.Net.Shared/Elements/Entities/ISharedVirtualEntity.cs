using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Shared.Elements.Entities
{
    public interface ISharedVirtualEntity : ISharedWorldObject
    {
        IntPtr VirtualEntityNativePointer { get; }
        uint Id { get; }

        ISharedVirtualEntityGroup Group { get; }

        bool HasStreamSyncedMetaData(string key);


        /// <summary>
        /// Get synced meta data of the entity.
        /// </summary>
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool GetStreamSyncedMetaData(string key, out int result);

        /// <summary>
        /// Get synced meta data of the entity.
        /// </summary>
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool GetStreamSyncedMetaData(string key, out uint result);

        /// <summary>
        /// Get synced meta data of the entity.
        /// </summary>
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool GetStreamSyncedMetaData(string key, out float result);

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
        /// <param name="result"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool GetStreamSyncedMetaData<T>(string key, out T result);

        uint StreamingDistance { get; }

        bool Visible { get; set; }
    }
}