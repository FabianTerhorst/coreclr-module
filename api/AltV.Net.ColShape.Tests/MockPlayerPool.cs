using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.ColShape.Tests
{
    public class MockPlayerPool : IEntityPool<IPlayer>
    {
        private readonly List<IPlayer> players;
        
        public MockPlayerPool(List<IPlayer> players)
        {
            this.players = players;
        }

        public IPlayer Create(ICore core, IntPtr entityPointer, ushort id)
        {
            throw new NotImplementedException();
        }
        public IPlayer Create(ICore core, IntPtr entityPointer)
        {
            throw new NotImplementedException();
        }
        public void Add(IPlayer entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IPlayer entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IntPtr entityPointer)
        {
            throw new NotImplementedException();
        }

        public bool Get(IntPtr entityPointer, out IPlayer entity)
        {
            throw new NotImplementedException();
        }

        public IPlayer Get(IntPtr entityPointer)
        {
            throw new NotImplementedException();
        }
        public IPlayer GetOrCreate(ICore core, IntPtr entityPointer, ushort entityId)
        {
            throw new NotImplementedException();
        }
        public IPlayer GetOrCreate(ICore core, IntPtr entityPointer)
        {
            throw new NotImplementedException();
        }
        IReadOnlyCollection<IPlayer> IReadOnlyEntityPool<IPlayer>.GetAllEntities()
        {
            throw new NotImplementedException();
        }
        public ICollection<IPlayer> GetAllEntities()
        {
            return players;
        }

        public KeyValuePair<IntPtr, IPlayer>[] GetEntitiesArray()
        {
            var arr = new KeyValuePair<IntPtr, IPlayer>[players.Count];
            var i = 0;
            foreach (var entity in players)
            {
                arr[i++] = new KeyValuePair<IntPtr, IPlayer>(IntPtr.Zero, entity);
            }

            return arr;
        }

        public void OnAdd(IPlayer entity)
        {
            throw new NotImplementedException();
        }

        public void OnRemove(IPlayer entity)
        {
            throw new NotImplementedException();
        }

        public void ForEach(IBaseObjectCallback<IPlayer> baseObjectCallback)
        {
            throw new NotImplementedException();
        }

        public Task ForEach(IAsyncBaseObjectCallback<IPlayer> asyncBaseObjectCallback)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}