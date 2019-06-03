using AltV.Net.NetworkingEntity.Elements.Entities;
using Entity;
using Google.Protobuf;

namespace AltV.Net.NetworkingEntity
{
    /// <summary>
    /// The streamer needs to stream the changes to the correct client('s)
    /// </summary>
    public class EntityStreamer : IEntityStreamer
    {
        public void CreateEntity(Entity.Entity entity)
        {
            var entityCreateEvent = new EntityCreateEvent {Entity = entity};
            var serverEvent = new ServerEvent {Create = entityCreateEvent};
            var bytes = serverEvent.ToByteArray();
            AltNetworking.Module.ClientPool.SendToAll(bytes);
        }

        public void RemoveEntity(Entity.Entity entity)
        {
            var entityDeleteEvent = new EntityDeleteEvent {Id = entity.Id};
            var serverEvent = new ServerEvent {Delete = entityDeleteEvent};
            var bytes = serverEvent.ToByteArray();
            AltNetworking.Module.ClientPool.SendToAll(bytes);
        }

        public void UpdateEntityData(INetworkingEntity entity, string key, MValue value)
        {
            var entityDataChangeEvent = new EntityDataChangeEvent {Id = entity.Id, Key = key, Value = value};
            var serverEvent = new ServerEvent {DataChange = entityDataChangeEvent};
            var bytes = serverEvent.ToByteArray();
            lock (entity.StreamedInClients)
            {
                foreach (var streamedInClient in entity.StreamedInClients)
                {
                    if (streamedInClient.Exists)
                    {
                        streamedInClient.WebSocket?.SendAsync(bytes, true);
                    }
                }
            }
        }

        public void UpdateEntityPosition(Entity.Entity entity, Position position)
        {
            var entityPositionChangeEvent = new EntityPositionChangeEvent {Id = entity.Id, Position = position};
            var serverEvent = new ServerEvent {PositionChange = entityPositionChangeEvent};
            var bytes = serverEvent.ToByteArray();
            AltNetworking.Module.ClientPool.SendToAll(bytes);
        }

        public void UpdateEntityRange(Entity.Entity entity, float range)
        {
            var entityRangeChangeEvent = new EntityRangeChangeEvent {Id = entity.Id, Range = range};
            var serverEvent = new ServerEvent {RangeChange = entityRangeChangeEvent};
            var bytes = serverEvent.ToByteArray();
            AltNetworking.Module.ClientPool.SendToAll(bytes);
        }

        //TODO: should this only be streamed to players with old dimension and new dimension,
        //TODO: but then we would have to send a client all entities again when the client changes the dimension, which we should implement as well
        public void UpdateEntityDimension(Entity.Entity entity, int dimension)
        {
            var entityDimensionChangeEvent = new EntityDimensionChangeEvent {Id = entity.Id, Dimension = dimension};
            var serverEvent = new ServerEvent {DimensionChange = entityDimensionChangeEvent};
            var bytes = serverEvent.ToByteArray();
            AltNetworking.Module.ClientPool.SendToAll(bytes);
        }
    }
}