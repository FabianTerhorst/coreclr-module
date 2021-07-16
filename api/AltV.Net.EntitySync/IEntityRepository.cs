using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    public interface IEntityRepository
    {
        void Add(IEntity entity);

        void Remove(IEntity entity);

        void Remove(ulong id, ulong type);

        void Update(IEntity entity);
        
        void UpdateData(IEntity entity, string key, object value);

        void ResetData(IEntity entity, string key);

        bool TryGet(ulong id, ulong type, out IEntity entity);

        IEnumerable<IEntity> GetAll();
    }
}