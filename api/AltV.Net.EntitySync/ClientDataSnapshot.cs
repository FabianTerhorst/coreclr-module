using System.Collections.Concurrent;

namespace AltV.Net.EntitySync
{
    /// <summary>
    /// This contains all snapshots of entities the client visited, and a buffer to use when comparing snapshots to reduce allocations
    /// </summary>
    public class ClientDataSnapshot
    {
        // Snapshots of all entities the client visited
        private readonly ConcurrentDictionary<IEntity, DataSnapshot> snapshots =
            new ConcurrentDictionary<IEntity, DataSnapshot>();

        public bool TryGetSnapshotForEntity(IEntity entity, out DataSnapshot snapshot) =>
            snapshots.TryGetValue(entity, out snapshot);

        public void SetSnapshotForEntity(IEntity entity, DataSnapshot snapshot) => snapshots[entity] = snapshot;

        public void CleanupEntities(IClient client)
        {
            foreach (var snapshot in snapshots)
            {
                snapshot.Key.DataSnapshot.RemoveClient(client);
            }
        }
    }
}