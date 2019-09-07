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
        public void CreateEntity(INetworkingEntity networkingEntity)
        {
            if (networkingEntity.StreamingType == StreamingType.EntityStreaming)
            {
                return;
            }

            byte[] bytes;
            if (networkingEntity.StreamingType == StreamingType.DataStreaming)
            {
                // Remove data before sending it over the wire
                var entityWithoutData = networkingEntity.StreamedEntity.Clone();
                entityWithoutData.Data.Clear();

                var entityCreateEvent = new EntityCreateEvent {Entity = entityWithoutData};
                var serverEvent = new ServerEvent {Create = entityCreateEvent};
                bytes = serverEvent.ToByteArray();
            }
            else
            {
                var entityCreateEvent = new EntityCreateEvent {Entity = networkingEntity.StreamedEntity};
                var serverEvent = new ServerEvent {Create = entityCreateEvent};
                bytes = serverEvent.ToByteArray();
            }

            AltNetworking.Module.ClientPool.SendToAll(bytes);
        }

        public void RemoveEntity(INetworkingEntity networkingEntity)
        {
            if (networkingEntity.StreamingType == StreamingType.EntityStreaming)
            {
                return;
            }

            var entityDeleteEvent = new EntityDeleteEvent {Id = networkingEntity.StreamedEntity.Id};
            var serverEvent = new ServerEvent {Delete = entityDeleteEvent};
            var bytes = serverEvent.ToByteArray();
            AltNetworking.Module.ClientPool.SendToAll(bytes);
        }

        public void UpdateEntityData(INetworkingEntity entity, string key, MValue value)
        {
            lock (entity.StreamedInClients)
            {
                if (entity.StreamedInClients.Count <= 0) return;
                var entityDataChangeEvent = new EntityDataChangeEvent {Id = entity.Id, Key = key, Value = value};
                var serverEvent = new ServerEvent {DataChange = entityDataChangeEvent};
                var bytes = serverEvent.ToByteArray();
                foreach (var streamedInClient in entity.StreamedInClients)
                {
                    lock (streamedInClient)
                    {
                        if (streamedInClient.Exists)
                        {
                            streamedInClient.WebSocket?.SendAsync(bytes, true);
                        }
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

        public void UpdateClientDimension(INetworkingClient networkingClient, int dimension)
        {
            var clientDimensionChangeEvent = new ClientDimensionChangeEvent {Dimension = dimension};
            var serverEvent = new ServerEvent {ClientDimensionChange = clientDimensionChangeEvent};
            var bytes = serverEvent.ToByteArray();
            lock (networkingClient)
            {
                if (networkingClient.Exists)
                {
                    networkingClient.WebSocket?.SendAsync(bytes, true);
                }
            }
        }
    }
}