using System.Collections.Generic;
using System.Numerics;

namespace AltV.Net.EntitySync
{
    public interface IEntity
    {
        ulong Id { get; }

        ulong Type { get; }

        Vector3 Position { get; }

        uint Range { get; }

        bool TryAddClient(IClient client);

        bool RemoveClient(IClient client);

        void AddCheck(IClient client);

        void RemoveCheck(IClient client);

        IDictionary<IClient, bool> GetLastCheckedClients();

        HashSet<IClient> GetClients();

        byte[] Serialize(IEnumerable<string> changedKeys);

        void SetPositionInternal(Vector3 position);

        IEnumerable<string> CompareSnapshotWithClient(IClient client);
    }
}