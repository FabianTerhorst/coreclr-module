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

        ValueTuple<IEntity[], IEntity[], IEntity[]> GetAll();
    }
}