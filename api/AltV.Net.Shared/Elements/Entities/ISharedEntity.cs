using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Shared.Elements.Entities
{
    public interface ISharedEntity : ISharedWorldObject
    {
        IntPtr EntityNativePointer { get; }

        /// <summary>
        /// Get the entity id.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        uint Id { get; }

        bool Exists { get; }

        /// <summary>
        /// Get model of the entity.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        uint Model { get; }

        /// <summary>
        /// Get the network owner, or null if none is present
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        ISharedPlayer NetworkOwner { get; }

        /// <summary>
        /// Get rotation of the entity.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        Rotation Rotation { get; }

        /// <summary>
        /// Checks if a stream synced meta data key is set on an entity.
        /// </summary>
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get or set frozen of the entity.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool Frozen { get; set; }
    }
}