using System.Collections.Concurrent;

namespace AltV.Net.NetworkingEntity
{
    /// <summary>
    /// This contains all snapshots of entities the client visited, and a buffer to use when comparing snapshots to reduce allocations
    /// </summary>
    public class ClientDataSnapshot
    {
        // Snapshots of all entities the client visited
        private readonly ConcurrentDictionary<ulong, DataSnapshot> snapshots = new ConcurrentDictionary<ulong, DataSnapshot>();

        public bool TryGetSnapshotForEntity(ulong id, out DataSnapshot snapshot) =>
            snapshots.TryGetValue(id, out snapshot);

        public void SetSnapshotForEntity(ulong id, DataSnapshot snapshot) => snapshots[id] = snapshot;
    }
}