using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    /// <summary>
    /// This contains all snapshots of entities the client visited, and a buffer to use when comparing snapshots to reduce allocations
    /// </summary>
    public class ClientDataSnapshot
    {
        // Snapshots of all entities the client visited
        private readonly Dictionary<IEntity, DataSnapshot>[] snapshots;

        public ClientDataSnapshot(ulong threadCount)
        {
            snapshots = new Dictionary<IEntity, DataSnapshot>[threadCount];
            for (ulong i = 0; i < threadCount; i++)
            {
                snapshots[i] = new Dictionary<IEntity, DataSnapshot>();
            }
        }

        public bool TryGetSnapshotForEntity(IEntity entity, ulong threadIndex, out DataSnapshot snapshot) =>
            snapshots[threadIndex].TryGetValue(entity, out snapshot);

        public bool TryGetSnapshotForEntityOnAnySnapshot(IEntity entity, out DataSnapshot snapshot)
        {
            for (int i = 0, length = snapshots.Length; i < length; i++)
            {
                if (snapshots[i].TryGetValue(entity, out snapshot))
                {
                    return true;
                }
            }

            snapshot = default;
            return false;
        }

        public void SetSnapshotForEntity(IEntity entity, ulong threadIndex, DataSnapshot snapshot) =>
            snapshots[threadIndex][entity] = snapshot;

        public Dictionary<IEntity, DataSnapshot> GetSnapshot(ulong threadIndex)
        {
            return snapshots[threadIndex];
        }
    }
}