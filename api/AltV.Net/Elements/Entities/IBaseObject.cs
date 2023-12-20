using System;
using System.Collections.Generic;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Types;

namespace AltV.Net.Elements.Entities
{
    public interface IBaseObject : ISharedBaseObject
    {
        new ICore Core { get; }

        /// <summary>
        /// Set synced meta data of the entity.
        /// </summary>
        /// <remarks>Synced meta data is accessible across different serverside resources and across all clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        [Obsolete]
        void SetSyncedMetaData(string key, object value);

        [Obsolete]
        void SetSyncedMetaData(Dictionary<string, object> metaData);

        /// <summary>
        /// Sets the synced meta data of an entity.
        /// </summary>
        /// <remarks>Synced meta data is accessible across different serverside resources and across all clients.</remarks>
        /// <param name="key"></param>
        /// <param name="value"></param>
        [Obsolete]
        void SetSyncedMetaData(string key, in MValueConst value);

        /// <summary>
        /// Deletes synced meta data from an entity.
        /// </summary>
        /// <remarks>Synced meta data is accessible across different serverside resources and across all clients.</remarks>
        /// <param name="key"></param>
        [Obsolete]
        void DeleteSyncedMetaData(string key);
    }
}