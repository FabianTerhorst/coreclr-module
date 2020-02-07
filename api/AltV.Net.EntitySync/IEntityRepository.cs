using System.Numerics;

namespace AltV.Net.EntitySync
{
    public interface IEntityRepository
    {
        void Add(IEntity entity);

        void Remove(IEntity entity);

        void UpdatePosition(IEntity entity, Vector3 newPosition);
    }
}