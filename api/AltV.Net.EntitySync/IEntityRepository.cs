using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    public interface IEntityRepository
    {
        void Add(IEntity entity);

        void Remove(IEntity entity);

        void Update(IEntity entity);

        bool TryGet(ulong id, ulong type, out IEntity entity);

        IEnumerable<IEntity> GetAll();
    }
}