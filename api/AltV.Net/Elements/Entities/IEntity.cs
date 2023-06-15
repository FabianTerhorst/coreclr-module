using System;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Entities
{
    public interface IEntity : ISharedEntity, IWorldObject
    {

        /// <summary>
        /// Get the network owner, or null if none is present
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        new IPlayer NetworkOwner { get; }

        /// <summary>
        /// Get or set rotation of the entity.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        new Rotation Rotation { get; set; }

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
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void SetStreamSyncedMetaData(string key, object value);

        /// <summary>
        /// Set synced meta data of the entity.
        /// </summary>
        /// <remarks>Stream synced meta data is accessible across different serverside resources and across all clients within the streaming range of the clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void SetStreamSyncedMetaData(string key, in MValueConst value);

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
        /// Attaches the entity to another entity.
        /// </summary>
        void AttachToEntity(IEntity entity, string otherBone, string ownBone, Position position, Rotation rotation, bool collision, bool noFixedRotation);

        /// <summary>
        /// Get or set collision of the entity.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool Collision { get; set; }

        /// <summary>
        /// Detaches the entity from its attached entity.
        /// </summary>
        void Detach();

        uint Timestamp { get; }
    }
}