using System.Collections.Generic;
using System.Numerics;

namespace AltV.Net.EntitySync
{
    public interface IEntity
    {
        ulong Id { get; }

        ulong Type { get; }

        // set position update flag to true in entity when updating position
        // thread will normally check if client is near entity
        // 1.) when client was near entity and is not anymore stream not, ( no change)
        // 2.) when client was not near entity and is now near entity stream in, (no change)
        // 3.) when client was not near entity and is still not near entity do nothing, (no change)
        // 4.) when client was near entity and is still near entity send client position change, client knows old position, don't send it
        Vector3 Position { get; set; }
        
        int Dimension { get; set; }

        uint Range { get; }

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

        bool TrySetPositionComputing(out Vector3 newPosition);

        void SetPositionComputed(in Vector3 currNewPosition);

        bool TrySetDimensionComputing(out int currNewDimension);

        void SetDimensionComputed(int currNewDimension);

        public bool TrySetRangeComputing(out uint currNewRange);

        public void SetRangeComputed(uint currNewRange);

        IEnumerable<string> CompareSnapshotWithClient(IClient client);
    }
}