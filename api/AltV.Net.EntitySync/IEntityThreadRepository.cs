using System;
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

        IEnumerable<IEntity> GetAll();
        
        IEnumerable<IEntity> GetAllDeleted();
        
        IEnumerable<IEntity> GetAllAdded();

        bool TryGet(ulong id, out IEntity entity);
    }
}