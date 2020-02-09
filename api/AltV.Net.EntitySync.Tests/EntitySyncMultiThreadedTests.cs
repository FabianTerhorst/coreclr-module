using System.Numerics;
using AltV.Net.EntitySync.SpatialPartitions;
using NUnit.Framework;

namespace AltV.Net.EntitySync.Tests
{
    public class EntitySyncMultiThreadedTests
    {
        private MockNetworkLayer mockNetworkLayer;
        
        [SetUp]
        public void Setup()
        {
            AltEntitySync.Init(2, 500,
                repository =>
                {
                    mockNetworkLayer = new MockNetworkLayer(repository);
                    return mockNetworkLayer;
                },
                () => new Grid(50_000, 50_000, 100, 10_000, 10_000),
                new IdProvider());
        }

        [Test]
        public void MultiAddTest()
        {
            var readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            var entityA = new Entity(1, Vector3.Zero, 2);
            entityA.Dimension = 0;
            AltEntitySync.AddEntity(entityA);
            var createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            var createResult = createTask.Result;
            Assert.AreSame(createResult.Entity, entityA);
            
            readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            var entityB = new Entity(1, Vector3.Zero, 2);
            entityB.Dimension = 0;
            AltEntitySync.AddEntity(entityB);
            createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            createResult = createTask.Result;
            Assert.AreSame(createResult.Entity, entityB);
            
            
            var readAsyncRemove = mockNetworkLayer.RemoveEventChannel.Reader.ReadAsync();
            AltEntitySync.RemoveEntity(entityA);
            var removeTask = readAsyncRemove.AsTask();
            removeTask.Wait();
            var removeResult = removeTask.Result;
            Assert.AreSame(removeResult.Entity, entityA);
            
            readAsyncRemove = mockNetworkLayer.RemoveEventChannel.Reader.ReadAsync();
            AltEntitySync.RemoveEntity(entityB);
            removeTask = readAsyncRemove.AsTask();
            removeTask.Wait();
            removeResult = removeTask.Result;
            Assert.AreSame(removeResult.Entity, entityB);
        }
    }
}