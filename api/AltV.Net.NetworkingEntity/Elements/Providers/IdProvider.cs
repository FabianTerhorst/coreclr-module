using System.Collections.Generic;

namespace AltV.Net.NetworkingEntity.Elements.Providers
{
    /// <summary>
    /// Default id provider that returns unique ids and reuses freed ids
    /// </summary>
    public class IdProvider : IIdProvider<ulong>
    {
        private readonly Stack<ulong> freeIds = new Stack<ulong>();

        private ulong currId;
        
        public ulong GetNext()
        {
            lock (freeIds)
            {
                if (freeIds.TryPop(out var id))
                {
                    return id;
                }
            }

            return currId++;
        }

        public void Free(ulong id)
        {
            lock (freeIds)
            {
                freeIds.Push(id);
            }
        }
    }
}