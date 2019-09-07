using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using Entity;

namespace AltV.Net.NetworkingEntity.Elements.Entities
{
    public interface INetworkingEntity
    {
        /// <summary>
        /// The current entity id
        /// </summary>
        ulong Id { get; }

        /// <summary>
        /// The current dimension of the entity
        /// </summary>
        int Dimension { get; set; }

        /// <summary>
        /// The current position of the entity
        /// </summary>
        Position Position { get; set; }

        /// <summary>
        /// The distance the entity will stream in, out
        /// </summary>
        float Range { get; set; }

        /// <summary>
        /// Check if the entity still exists, when you do it inside a lock(entity) it will even be thread safe
        /// </summary>
        bool Exists { get; }

        /// <summary>
        /// Clients that are in streaming range of entity
        /// </summary>
        HashSet<INetworkingClient> StreamedInClients { get; }
        
        /// <summary>
        /// The way the entity gets streamed
        /// </summary>
        StreamingType StreamingType { get; }
        
        /// <summary>
        /// The main entity streamer, not in use currently
        /// </summary>
        INetworkingClient MainStreamer { get; }
        

        /// <summary>
        /// This method is required to call to change entity data after creation to update data snapshot
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetData(string key, bool value);

        /// <summary>
        /// This method is required to call to change entity data after creation to update data snapshot
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetData(string key, double value);

        /// <summary>
        /// This method is required to call to change entity data after creation to update data snapshot
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetData(string key, string value);

        /// <summary>
        /// This method is required to call to change entity data after creation to update data snapshot
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetData(string key, long value);

        /// <summary>
        /// This method is required to call to change entity data after creation to update data snapshot
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetData(string key, ulong value);

        /// <summary>
        /// This method is required to call to change entity data after creation to update data snapshot
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetData(string key, IEnumerable<object> value);


        /// <summary>
        /// This method is required to call to change entity data after creation to update data snapshot
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetData(string key, IDictionary<string, object> value);
        
        /// <summary>
        /// This method is required to call to change entity data after creation to update data snapshot
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetData(string key, object value);

        /// <summary>
        /// This method is required to call to change entity data after creation to update data snapshot
        /// </summary>
        /// <param name="key"></param>
        void SetDataNull(string key);

        bool GetData(string key, out bool value);

        bool GetData(string key, out double value);

        bool GetData(string key, out string value);

        bool GetData(string key, out ulong value);

        bool GetData(string key, out long value);

        bool IsDataNull(string key);

        /// <summary>
        /// Removes entity
        /// </summary>
        void Remove();

        // Internal

        Entity.Entity StreamedEntity { get; }

        EntityDataSnapshot Snapshot { get; }

        void ClientStreamedIn(INetworkingClient client);

        // Returns true when removed successfully
        bool ClientStreamedOut(INetworkingClient client);
    }
}