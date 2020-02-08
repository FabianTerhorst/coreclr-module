using System;
using System.Numerics;

namespace AltV.Net.EntitySync
{
    /// <summary>
    /// Each thread has a own entity thread repository, so we can split the work between multiple cpus
    /// </summary>
    public interface IEntityThreadRepository
    {
        void Add(IEntity entity);

        void Remove(IEntity entity);
        
        void UpdatePosition(IEntity entity, Vector3 newPosition);

        ValueTuple<IEntity[], IEntity[], IEntity[]> GetAll();
    }
}