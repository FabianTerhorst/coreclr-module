using System.Collections.Generic;

namespace AltV.Net.NetworkingEntity
{
    public class EntityIdStorage
    {
        private readonly Stack<ulong> freeIds = new Stack<ulong>();

        private ulong currId = 0;

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