using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AltV.Net.EntitySync
{
    /// <summary>
    /// Saves the state of the entity data
    /// </summary>
    public class EntityDataSnapshot : DataSnapshot
    {
        private readonly ulong entityId;

        // This is a reference of the last clients that got synced with this snapshot to know who to notify when overflow of snapshot version is happening
        private readonly HashSet<IClient> lastClients = new HashSet<IClient>();

        public EntityDataSnapshot(ulong entityId)
        {
            this.entityId = entityId;
        }

        public override void OnOverflow(string key)
        {
            HashSet<IClient> clientsToRemove = null;
            foreach (var lastClient in lastClients)
            {
                if (!lastClient.Exists)
                {
                    if (clientsToRemove == null)
                    {
                        clientsToRemove = new HashSet<IClient>();
                    }

                    clientsToRemove.Add(lastClient);
                }
                else
                {
                    if (lastClient.Snapshot.TryGetSnapshotForEntity(entityId, out var entitySnapshotFromClient))
                    {
                        entitySnapshotFromClient.Reset(key);
                    }
                    else // he don't know us, we don't want to know him anymore
                    {
                        if (clientsToRemove == null)
                        {
                            clientsToRemove = new HashSet<IClient>();
                        }

                        clientsToRemove.Add(lastClient);
                    }
                }
            }

            if (clientsToRemove != null)
            {
                foreach (var clientToRemove in clientsToRemove)
                {
                    lastClients.Remove(clientToRemove);
                }
            }
        }

        /// <summary>
        /// Checks which keys have changed for the input data snapshot to stay in sync
        /// </summary>
        /// <param name="networkingClient">The networking client to compare, we need the client not the snapshot to keep reference for possible overflow</param>
        /// <returns>the changed keys, returns null when no changes</returns>
        public IEnumerable<string> CompareWithClient(IClient networkingClient)
        {
            if (Snapshots == null || Snapshots.IsEmpty) return null; // entity snapshot never updated, nothing to do
            lastClients.Add(networkingClient);
            IEnumerable<string> changedKeys;
            var clientDataSnapshot = networkingClient.Snapshot;
            if (clientDataSnapshot.TryGetSnapshotForEntity(entityId, out var entitySnapshotFromClient)
            ) // client visited entity before
            {
                changedKeys = Compare(entitySnapshotFromClient);

                // Here we align client and entity snapshot with same data
                entitySnapshotFromClient.Snapshots.Clear();
                foreach (var (key, value) in Snapshots)
                {
                    entitySnapshotFromClient.Snapshots[key] = value;
                }
            }
            else // client never visited entity before
            {
                changedKeys = Snapshots.Keys.ToArray();
                clientDataSnapshot.SetSnapshotForEntity(entityId,
                    new DataSnapshot(new ConcurrentDictionary<string, ulong>(Snapshots)));
            }

            return changedKeys;
        }

        private IEnumerable<string> Compare(DataSnapshot dataSnapshot)
        {
            var missing = false;
            foreach (var (key, value) in Snapshots)
            {
                if (dataSnapshot.Snapshots.TryGetValue(key, out var snapShotValue))
                {
                    if (snapShotValue < value)
                    {
                        yield return key;
                    }
                }
                else
                {
                    missing = true;

                    yield return key;
                }
            }

            if (missing || Snapshots.Count != dataSnapshot.Snapshots.Count
            ) // snapshot contains at least one removed key or has a different size, we need to notify the player about that
            {
                //TODO: is the removed key also just a changed key, because then we have to deliver a null mvalue as well, yeah why not
                foreach (var (key, _) in dataSnapshot.Snapshots)
                {
                    if (!Snapshots.ContainsKey(key))
                    {
                        yield return key;
                    }
                }
            }
        }

        /*
         private IEnumerable<string> Compare(DataSnapshot dataSnapshot)
        {
            var missing = false;
            //TODO: do we need to create a buffer for the hash sets?
            HashSet<string> changedKeys = null;
            foreach (var (key, value) in Snapshots)
            {
                if (dataSnapshot.Snapshots.TryGetValue(key, out var snapShotValue))
                {
                    if (snapShotValue < value)
                    {
                        if (changedKeys == null)
                        {
                            changedKeys = new HashSet<string>();
                        }

                        changedKeys.Add(key);
                    }
                }
                else
                {
                    missing = true;
                    if (changedKeys == null)
                    {
                        changedKeys = new HashSet<string>();
                    }

                    changedKeys.Add(key);
                }
            }

            if (missing || Snapshots.Count != dataSnapshot.Snapshots.Count
            ) // snapshot contains at least one removed key or has a different size, we need to notify the player about that
            {
                //TODO: is the removed key also just a changed key, because then we have to deliver a null mvalue as well, yeah why not
                foreach (var (key, _) in dataSnapshot.Snapshots)
                {
                    if (!Snapshots.ContainsKey(key))
                    {
                        if (changedKeys == null)
                        {
                            changedKeys = new HashSet<string>();
                        }

                        changedKeys.Add(key);
                    }
                }
            }

            return changedKeys;
        }
         */
    }
}