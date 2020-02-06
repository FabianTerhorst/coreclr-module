using System.Numerics;
using System.Threading.Tasks;
using AltV.Net.NetworkingEntity.Elements.Entities;
using Entity;

namespace AltV.Net.NetworkingEntity
{
    public interface IEntityStreamer
    {
        void CreateEntity(INetworkingEntity networkingEntity);

        Task RemoveEntity(INetworkingEntity networkingEntity);

        void UpdateEntityData(INetworkingEntity entity, string key, MValue value);

        void UpdateEntityPosition(Entity.Entity entity, Position position);
        
        void UpdateEntityRange(Entity.Entity entity, float range);

        void UpdateEntityDimension(Entity.Entity entity, int dimension);

        void UpdateClientDimension(INetworkingClient networkingClient, int dimension);

        void UpdateClientPositionOverride(INetworkingClient networkingClient, Vector3? position);
    }
}