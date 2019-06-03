using AltV.Net.NetworkingEntity.Elements.Entities;
using Entity;

namespace AltV.Net.NetworkingEntity
{
    public interface IEntityStreamer
    {
        void CreateEntity(Entity.Entity entity);

        void RemoveEntity(Entity.Entity entity);

        void UpdateEntityData(INetworkingEntity entity, string key, MValue value);

        void UpdateEntityPosition(Entity.Entity entity, Position position);
        
        void UpdateEntityRange(Entity.Entity entity, uint range);

        void UpdateEntityDimension(Entity.Entity entity, int dimension);
    }
}