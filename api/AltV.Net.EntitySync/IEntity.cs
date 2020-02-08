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
        
        object FlagsMutex { get; }

        int Flags { get; }

        void SetData(string key, object value);

        bool TryGetData(string key, out object value);
        
        bool TryGetData<T>(string key, out T value);

        void ResetData(string key);

        bool TryAddClient(IClient client);

        bool RemoveClient(IClient client);

        void AddCheck(IClient client);

        void RemoveCheck(IClient client);

        IDictionary<IClient, bool> GetLastCheckedClients();

        HashSet<IClient> GetClients();

        byte[] Serialize(IEnumerable<string> changedKeys);

        void SetPositionInternal(Vector3 position);

        bool TrySetPositionComputing(out Vector3 newPosition);

        void SetPositionComputed();

        IEnumerable<string> CompareSnapshotWithClient(IClient client);
    }
}