using System.Collections.Generic;
using System.Numerics;

namespace AltV.Net.EntitySync
{
    //TODO: make client dirty when position or dimension changes, only check dirty characters in entity thread
    //TODO: this requires to calculate stream out somehow
    //TODO: dirty clients can only calculate stream outs and position changes
    /// <summary>
    /// A client is a connected peer that authenticated itself via a token.
    /// In most cases the client contains a IPlayer object and gets the position and exists status out of this.
    /// </summary>
    public class Client : IClient
    {
        public string Token { get; }

        public virtual Vector3 Position { get; set; }

        public virtual int Dimension { get; set; }

        public ClientDataSnapshot Snapshot { get; }

        public virtual bool Exists { get; } = true;

        private Vector3 positionOverride;

        private bool isPositionOverwritten;

        /// <summary>
        /// List of entities this client has created.
        /// </summary>
        private readonly HashSet<IEntity>[] entities;

        /// <summary>
        /// List of entities that this client had created last time, so we can calculate when a entity is not in range of this client anymore.
        /// </summary>
        private readonly IDictionary<IEntity, bool>[] lastCheckedEntities;

        public Client(ulong threadCount, string token)
        {
            Snapshot = new ClientDataSnapshot(threadCount);
            entities = new HashSet<IEntity>[threadCount];
            for (ulong i = 0; i < threadCount; i++)
            {
                entities[i] = new HashSet<IEntity>();
            }

            lastCheckedEntities = new IDictionary<IEntity, bool>[threadCount];
            for (ulong i = 0; i < threadCount; i++)
            {
                lastCheckedEntities[i] = new Dictionary<IEntity, bool>();
            }

            Token = token;
        }

        public virtual bool TryGetDimensionAndPosition(out int dimension, ref Vector3 position)
        {
            lock (this)
            {
                if (isPositionOverwritten)
                {
                    position = positionOverride;
                }
                else
                {
                    position = Position;
                }

                dimension = Dimension;
            }

            return true;
        }

        public virtual void SetPositionOverride(Vector3 newPositionOverride)
        {
            lock (this)
            {
                positionOverride = newPositionOverride;
                isPositionOverwritten = true;
            }
        }

        public virtual void ResetPositionOverride()
        {
            lock (this)
            {
                isPositionOverwritten = false;
            }
        }


        /// <summary>
        /// Tries to add a entity to the list of entities that this client got created.
        /// </summary>
        /// <param name="threadIndex"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool TryAddEntity(ulong threadIndex, IEntity entity)
        {
            return entities[threadIndex].Add(entity);
        }

        public bool RemoveEntity(ulong threadIndex, IEntity entity)
        {
            lastCheckedEntities[threadIndex].Remove(entity);
            return entities[threadIndex].Remove(entity);
        }

        public void AddCheck(ulong threadIndex, IEntity entity)
        {
            lastCheckedEntities[threadIndex][entity] = true;
        }

        public void RemoveCheck(ulong threadIndex, IEntity entity)
        {
            lastCheckedEntities[threadIndex][entity] = false;
        }

        public IDictionary<IEntity, bool> GetLastCheckedEntities(ulong threadIndex)
        {
            return lastCheckedEntities[threadIndex];
        }

        public HashSet<IEntity> GetEntities(ulong threadIndex)
        {
            return entities[threadIndex];
        }
    }
}