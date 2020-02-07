using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace AltV.Net.EntitySync
{
    public class Entity : IEntity
    {
        public ulong Id { get; }
        public ulong Type { get; }
        public Vector3 Position { get; set; }
        public uint Range { get; }
        
        private readonly IDictionary<string, object> data = new Dictionary<string, object>();

        private readonly EntityDataSnapshot dataSnapshot;

        /// <summary>
        /// List of clients that have the entity created.
        /// </summary>
        private readonly HashSet<IClient> clients = new HashSet<IClient>();

        /// <summary>
        /// List of clients that had the entity created last time, so we can calculate when a client is not in range anymore.
        /// </summary>
        private readonly IDictionary<IClient, bool> lastCheckedClients = new Dictionary<IClient, bool>();

        public Entity(ulong type, Vector3 position, uint range) : this(AltEntitySync._idProvider.GetNext(), type,
            position, range)
        {
        }

        internal Entity(ulong id, ulong type, Vector3 position, uint range)
        {
            Id = id;
            Type = type;
            Position = position;
            Range = range;
            dataSnapshot = new EntityDataSnapshot(Id);
        }

        public void SetData(string key, object value)
        {
            dataSnapshot.Update(key);
            data[key] = value;
        }

        public void ResetData(string key)
        {
            dataSnapshot.Update(key);
            data.Remove(key);
        }

        /// <summary>
        /// Tries to add a client to the list of clients that created this entity.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool TryAddClient(IClient client)
        {
            return clients.Add(client);
        }

        public bool RemoveClient(IClient client)
        {
            lastCheckedClients.Remove(client);
            return clients.Remove(client);
        }

        public void AddCheck(IClient client)
        {
            lastCheckedClients[client] = true;
        }

        public void RemoveCheck(IClient client)
        {
            lastCheckedClients[client] = false;
        }

        public IDictionary<IClient, bool> GetLastCheckedClients()
        {
            return lastCheckedClients;
        }

        public HashSet<IClient> GetClients()
        {
            return clients;
        }

        public void SetPositionInternal(Vector3 position)
        {
            Position = position;
        }

        public virtual byte[] Serialize(IEnumerable<string> changedKeys)
        {
            using var m = new MemoryStream();
            using (var writer = new BinaryWriter(m))
            {
                writer.Write(Id);
                writer.Write(Type);
                writer.Write(Position.X);
                writer.Write(Position.Y);
                writer.Write(Position.Z);
                writer.Write(Range);
                //TODO: serialize data depending on changedKeys
            }

            return m.ToArray();
        }

        public IEnumerable<string> CompareSnapshotWithClient(IClient client)
        {
            return dataSnapshot.CompareWithClient(client);
        }
    }
}