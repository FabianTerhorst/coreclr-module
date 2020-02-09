using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    public interface IEntityRepository
    {
        void Add(IEntity entity);

        void Remove(IEntity entity);

        bool TryGet(ulong id, out IEntity entity);

        IEnumerable<IEntity> GetAll();
    }
}