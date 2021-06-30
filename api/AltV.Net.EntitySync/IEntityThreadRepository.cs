using System.Collections.Generic;

namespace AltV.Net.EntitySync
{
    /// <summary>
    /// Each thread has a own entity thread repository, so we can split the work between multiple cpus
    /// </summary>
    public interface IEntityThreadRepository
    {
        void Add(IEntity entity);

        void Remove(IEntity entity);

        void Remove(ulong id, ulong type);

        void Remove(IList<IEntity> entities);

        void Update(IEntity entity);

        void UpdateData(IEntity entity, string key, object value);
        
        void ResetData(IEntity entity, string key);

        IEnumerable<IEntity> GetAll();

        bool TryGet(ulong id, ulong type, out IEntity entity);
    }
}