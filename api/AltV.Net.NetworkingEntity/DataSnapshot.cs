using System.Collections.Concurrent;

namespace AltV.Net.NetworkingEntity
{
    /// <summary>
    /// Saves the state of the entity data and player received data
    /// </summary>
    public class DataSnapshot
    {
        // snapshot versions for each data key
        public ConcurrentDictionary<string, ulong> Snapshots;

        public DataSnapshot()
        {
            
        }
        
        public DataSnapshot(ConcurrentDictionary<string, ulong> snapshots)
        {
            Snapshots = snapshots;
        }

        public void Update(string key)
        {
            if (Snapshots == null)
            {
                Snapshots = new ConcurrentDictionary<string, ulong>();
            }

            if (Snapshots.TryGetValue(key, out var currSnapshot))
            {
                if (currSnapshot == 0)
                {
                    OnOverflow(key);
                    currSnapshot = 1;
                }

                Snapshots[key] = currSnapshot;
            }
            else
            {
                Snapshots[key] = 1;
            }
        }

        public void Reset(string key)
        {
            Snapshots[key] = 0;
        }

        public virtual void OnOverflow(string key)
        {
        }
    }
}