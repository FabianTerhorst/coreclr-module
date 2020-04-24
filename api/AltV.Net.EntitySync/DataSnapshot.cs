using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    /// <summary>
    /// Saves the state of the entity data and player received data
    /// </summary>
    public class DataSnapshot
    {
        // snapshot versions for each data key
        public readonly IDictionary<string, ulong> Snapshots;

        public DataSnapshot()
        {
            Snapshots = new Dictionary<string, ulong>();
        }

        public DataSnapshot(IDictionary<string, ulong> snapshots)
        {
            Snapshots = snapshots;
        }

        public void Update(string key)
        {
            if (Snapshots.TryGetValue(key, out var currSnapshot))
            {
                if (currSnapshot == 0)
                {
                    OnOverflow(key);
                    currSnapshot = 1;
                }

                Snapshots[key] = currSnapshot + 1;
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