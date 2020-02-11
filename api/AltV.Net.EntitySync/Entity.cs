using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace AltV.Net.EntitySync
{
    public class Entity : IEntity
    {
        public ulong Id { get; }
        public ulong Type { get; }

        private Vector3 position;

        public Vector3 Position
        {
            get => position;
            set => SetPositionInternal(value);
        }

        private bool positionState = false;

        private Vector3 newPosition;

        private readonly object positionMutex = new object();

        private int dimension;

        public int Dimension
        {
            get => dimension;
            set => SetDimensionInternal(value);
        }

        private bool dimensionState = false;

        private int newDimension;

        private readonly object dimensionMutex = new object();

        private uint range;

        public uint Range
        {
            get => range;
            set => SetRangeInternal(value);
        }

        private bool rangeState = false;

        private uint newRange;

        private readonly object rangeMutex = new object();

        private readonly IDictionary<string, object> data;

        public EntityDataSnapshot DataSnapshot { get; }

        /// <summary>
        /// List of clients that have the entity created.
        /// </summary>
        private readonly HashSet<IClient> clients = new HashSet<IClient>();

        /// <summary>
        /// List of clients that had the entity created last time, so we can calculate when a client is not in range anymore.
        /// </summary>
        private readonly IDictionary<IClient, bool> lastCheckedClients = new Dictionary<IClient, bool>();

        public Entity(ulong type, Vector3 position, int dimension, uint range) : this(
            AltEntitySync.IdProvider.GetNext(), type,
            position, dimension, range, new Dictionary<string, object>())
        {
        }

        public Entity(ulong type, Vector3 position, int dimension, uint range, IDictionary<string, object> data) : this(
            AltEntitySync.IdProvider.GetNext(), type,
            position, dimension, range, data)
        {
        }

        internal Entity(ulong id, ulong type, Vector3 position, int dimension, uint range,
            IDictionary<string, object> data)
        {
            Id = id;
            Type = type;
            this.position = position;
            this.dimension = dimension;
            this.range = range;
            this.data = data;
            DataSnapshot = new EntityDataSnapshot(this);
            foreach (var (key, _) in data)
            {
                DataSnapshot.Update(key);
            }
        }

        public void SetData(string key, object value)
        {
            lock (data)
            {
                DataSnapshot.Update(key);
                data[key] = value;
            }
        }

        public void ResetData(string key)
        {
            lock (data)
            {
                DataSnapshot.Update(key);
                data.Remove(key);
            }
        }

        public bool TryGetData(string key, out object value)
        {
            lock (data)
            {
                return data.TryGetValue(key, out value);
            }
        }

        public bool TryGetData<T>(string key, out T value)
        {
            lock (data)
            {
                if (!data.TryGetValue(key, out var currValue))
                {
                    value = default;
                    return false;
                }

                if (!(currValue is T correctValue))
                {
                    value = default;
                    return false;
                }

                value = correctValue;
                return true;
            }
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

        public void SetPositionInternal(Vector3 currNewPosition)
        {
            lock (positionMutex)
            {
                positionState = true;
                newPosition = currNewPosition;
            }
        }

        public bool TrySetPositionComputing(out Vector3 currNewPosition)
        {
            lock (positionMutex)
            {
                if (!positionState)
                {
                    currNewPosition = default;
                    return false;
                }

                currNewPosition = newPosition;
                positionState = false;
            }

            return true;
        }

        public void SetPositionComputed(in Vector3 currNewPosition)
        {
            lock (positionMutex)
            {
                position = currNewPosition;
            }
        }

        public void SetDimensionInternal(int currNewDimension)
        {
            lock (dimensionMutex)
            {
                dimensionState = true;
                newDimension = currNewDimension;
            }
        }

        public bool TrySetDimensionComputing(out int currNewDimension)
        {
            lock (dimensionMutex)
            {
                if (!dimensionState)
                {
                    currNewDimension = default;
                    return false;
                }

                currNewDimension = newDimension;
                dimensionState = false;
            }

            return true;
        }

        public void SetDimensionComputed(int currNewDimension)
        {
            lock (dimensionMutex)
            {
                dimension = currNewDimension;
            }
        }

        public void SetRangeInternal(uint currNewRange)
        {
            lock (rangeMutex)
            {
                rangeState = true;
                newRange = currNewRange;
            }
        }

        public bool TrySetRangeComputing(out uint currNewRange)
        {
            lock (rangeMutex)
            {
                if (!rangeState)
                {
                    currNewRange = default;
                    return false;
                }

                currNewRange = newRange;
                rangeState = false;
            }

            return true;
        }

        public void SetRangeComputed(uint currNewRange)
        {
            lock (rangeMutex)
            {
                range = currNewRange;
            }
        }

        public virtual byte[] Serialize(IEnumerable<string> changedKeys)
        {
            using var m = new MemoryStream();
            using (var writer = new BinaryWriter(m))
            {
                writer.Write(Id);
                writer.Write(Type);
                writer.Write(position.X);
                writer.Write(position.Y);
                writer.Write(position.Z);
                writer.Write(Range);
                //TODO: serialize data depending on changedKeys
            }

            return m.ToArray();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Entity entity)) return false;
            if (entity.Id != Id) return false;
            if (entity.Type != Type) return false;
            if (entity.dimension != dimension) return false;
            if (entity.range != range) return false;
            if (entity.position != position) return false;
            if (entity.data != data) return false;
            return true;
        }
    }
}