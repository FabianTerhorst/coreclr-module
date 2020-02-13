using System.Collections.Generic;
using System.Threading.Channels;
using AltV.Net.EntitySync.Events;

namespace AltV.Net.EntitySync.WebSocket
{
    public class WebSocketNetworkLayer : NetworkLayer
    {
        public override event ConnectionConnectEventDelegate OnConnectionConnect;
        public override event ConnectionDisconnectEventDelegate OnConnectionDisconnect;
        public override event EntityCreateEventDelegate OnEntityCreate;
        public override event EntityRemoveEventDelegate OnEntityRemove;
        public override event EntityPositionUpdateEventDelegate OnEntityPositionUpdate;
        public override event EntityPositionUpdateEventDelegate OnEntityDataUpdate;

        //TODO: save here dictionary of websockets / client i think

        //TODO: create one channel for each websocket, so we can synchronize the event sending, because websockets don't allow parallel send

        private readonly struct WebSocketEntityEvent
        {
            public readonly byte EventType;

            public readonly IEntity Entity;

            public readonly IDictionary<string, object> Data;

            public WebSocketEntityEvent(byte eventType, IEntity entity, IDictionary<string, object> data)
            {
                EventType = eventType;
                Entity = entity;
                Data = data;
            }
        }

        private readonly IDictionary<IClient, Channel<WebSocketEntityEvent>> webSocketWriters =
            new Dictionary<IClient, Channel<WebSocketEntityEvent>>();

        public WebSocketNetworkLayer(IClientRepository clientRepository) : base(clientRepository)
        {
        }

        public override void SendEvent(IClient client, in EntityCreateEvent entityCreate)
        {
            if (!webSocketWriters.TryGetValue(client, out var channel)) return;
            channel.Writer.TryWrite(new WebSocketEntityEvent(1, entityCreate.Entity, entityCreate.Data));
        }

        public override void SendEvent(IClient client, in EntityRemoveEvent entityRemove)
        {
            if (!webSocketWriters.TryGetValue(client, out var channel)) return;
            channel.Writer.TryWrite(new WebSocketEntityEvent(2, entityRemove.Entity, null));
        }

        public override void SendEvent(IClient client, in EntityPositionUpdateEvent entityPositionUpdate)
        {
            throw new System.NotImplementedException();
        }

        public override void SendEvent(IClient client, in EntityDataChangeEvent entityDataChange)
        {
            throw new System.NotImplementedException();
        }

        public override void SendEvent(IClient client, in EntityClearCacheEvent entityClearCache)
        {
            throw new System.NotImplementedException();
        }
    }
}