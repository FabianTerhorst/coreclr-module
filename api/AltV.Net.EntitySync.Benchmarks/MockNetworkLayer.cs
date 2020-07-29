using System;
using System.Numerics;
using System.Threading.Channels;
using AltV.Net.EntitySync.Events;

namespace AltV.Net.EntitySync.Benchmarks
{
    public class MockNetworkLayer : NetworkLayer
    {
        public override event ConnectionConnectEventDelegate OnConnectionConnect;
        public override event ConnectionDisconnectEventDelegate OnConnectionDisconnect;
        public override event ClientSubscribeEntityDelegate OnClientSubscribeEntity;
        public override event ClientUnsubscribeEntityDelegate OnClientUnsubscribeEntity;
        public override event EntityCreateEventDelegate OnEntityCreate;
        public override event EntityRemoveEventDelegate OnEntityRemove;
        public override event EntityPositionUpdateEventDelegate OnEntityPositionUpdate;
        public override event EntityDataUpdateEventDelegate OnEntityDataUpdate;
        public override event EntityNetOwnerUpdateEventDelegate OnEntityNetOwnerUpdate;

        public readonly Channel<EntityCreateEvent> CreateEventChannel = Channel.CreateUnbounded<EntityCreateEvent>();
        public readonly Channel<EntityRemoveEvent> RemoveEventChannel = Channel.CreateUnbounded<EntityRemoveEvent>();
        public readonly Channel<EntityPositionUpdateEvent> PositionUpdateEventChannel = Channel.CreateUnbounded<EntityPositionUpdateEvent>();
        public readonly Channel<EntityDataChangeEvent> DataChangeEventChannel = Channel.CreateUnbounded<EntityDataChangeEvent>();
        public readonly Channel<EntityClearCacheEvent> ClearCacheEventChannel = Channel.CreateUnbounded<EntityClearCacheEvent>();
        public readonly Channel<EntityNetOwnerChangeEvent> NetOwnerChangeEventChannel = Channel.CreateUnbounded<EntityNetOwnerChangeEvent>();

        public MockNetworkLayer(ulong threadCount, IClientRepository clientRepository) : base(threadCount, clientRepository)
        {
            var a = new Client(threadCount, "a");
            a.Dimension = 0;
            a.Position = new Vector3(0, 0, 0);
            var b = new Client(threadCount, "b");
            b.Dimension = 0;
            b.Position = new Vector3(100, 100, 100);
            clientRepository.Add(a);
            clientRepository.Add(b);
        }

        public override void SendEvent(IClient client, in EntityCreateEvent entityCreate)
        {
            CreateEventChannel.Writer.TryWrite(entityCreate);
            Console.WriteLine("SendEvent EntityCreateEvent");
        }

        public override void SendEvent(IClient client, in EntityRemoveEvent entityRemove)
        {
            RemoveEventChannel.Writer.TryWrite(entityRemove);
            Console.WriteLine("SendEvent EntityRemoveEvent");
        }

        public override void SendEvent(IClient client, in EntityPositionUpdateEvent entityPositionUpdate)
        {
            PositionUpdateEventChannel.Writer.TryWrite(entityPositionUpdate);
            Console.WriteLine("SendEvent EntityPositionUpdateEvent");
        }

        public override void SendEvent(IClient client, in EntityDataChangeEvent entityDataChange)
        {
            DataChangeEventChannel.Writer.TryWrite(entityDataChange);
            Console.WriteLine("SendEvent EntityDataChangeEvent");
        }

        public override void SendEvent(IClient client, in EntityClearCacheEvent entityClearCache)
        {
            ClearCacheEventChannel.Writer.TryWrite(entityClearCache);
            Console.WriteLine("SendEvent EntityClearCacheEvent");
        }

        public override void SendEvent(IClient client, in EntityNetOwnerChangeEvent entityNetOwnerChange)
        {
            NetOwnerChangeEventChannel.Writer.TryWrite(entityNetOwnerChange);
            Console.WriteLine("SendEvent EntityNetOwnerChangeEvent");
        }
    }
}