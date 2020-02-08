using System;
using System.Numerics;
using AltV.Net.EntitySync.Events;

namespace AltV.Net.EntitySync.Tests
{
    public class MockNetworkLayer : NetworkLayer
    {
        public override event ConnectionConnectEventDelegate OnConnectionConnect;
        public override event ConnectionDisconnectEventDelegate OnConnectionDisconnect;
        public override event EntityCreateEventDelegate OnEntityCreate;
        public override event EntityRemoveEventDelegate OnEntityRemove;
        public override event EntityPositionUpdateEventDelegate OnEntityPositionUpdate;
        public override event EntityPositionUpdateEventDelegate OnEntityDataUpdate;

        public MockNetworkLayer(IClientRepository clientRepository) : base(clientRepository)
        {
            var a = new Client("a");
            a.Position = new Vector3(0, 0, 0);
            var b = new Client("b");
            b.Position = new Vector3(100, 100, 100);
            clientRepository.Add(a);
            clientRepository.Add(b);
        }

        public override void SendEvent(IClient client, in EntityCreateEvent entityCreate)
        {
            Console.WriteLine("SendEvent EntityCreateEvent");
        }

        public override void SendEvent(IClient client, in EntityRemoveEvent entityRemove)
        {
            Console.WriteLine("SendEvent EntityRemoveEvent");
        }

        public override void SendEvent(IClient client, in EntityPositionUpdateEvent entityPositionUpdate)
        {
            Console.WriteLine("SendEvent EntityPositionUpdateEvent");
        }

        public override void SendEvent(IClient client, in EntityDataChangeEvent entityDataChange)
        {
            Console.WriteLine("SendEvent EntityDataChangeEvent");
        }
    }
}