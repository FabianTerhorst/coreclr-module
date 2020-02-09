using System.Numerics;
using AltV.Net.EntitySync.SpatialPartitions;
using NUnit.Framework;

namespace AltV.Net.EntitySync.Tests
{
    public class EntitySyncTests
    {
        private MockNetworkLayer mockNetworkLayer;
        
        [SetUp]
        public void Setup()
        {
            AltEntitySync.Init(1,
                repository =>
                {
                    mockNetworkLayer = new MockNetworkLayer(repository);
                    return mockNetworkLayer;
                },
                () => new Grid(50_000, 50_000, 100, 10_000, 10_000),
                new IdProvider());
        }

        [Test]
        public void AddTest()
        {
            var readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            var entity = new Entity(1, Vector3.Zero, 2);
            entity.Dimension = 0;
            AltEntitySync.AddEntity(entity);
            var createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            var createResult = createTask.Result;
            Assert.AreSame(createResult.Entity, entity);
            var readAsyncRemove = mockNetworkLayer.RemoveEventChannel.Reader.ReadAsync();
            AltEntitySync.RemoveEntity(entity);
            var removeTask = readAsyncRemove.AsTask();
            removeTask.Wait();
            var removeResult = removeTask.Result;
            Assert.AreSame(removeResult.Entity, entity);
        }

        [Test]
        public void UpdatePositionTest()
        {
            var readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            var entity = new Entity(1, Vector3.Zero, 2);
            entity.Dimension = 0;
            AltEntitySync.AddEntity(entity);
            var createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            var createResult = createTask.Result;
            Assert.AreSame(createResult.Entity, entity);
            
            var readAsyncPositionUpdate = mockNetworkLayer.PositionUpdateEventChannel.Reader.ReadAsync();
            var newPosition = new Vector3(1, 1, 1);
            entity.Position = newPosition;
            var positionUpdateTask = readAsyncPositionUpdate.AsTask();
            positionUpdateTask.Wait();
            var positionUpdateResult = positionUpdateTask.Result;
            Assert.AreSame(positionUpdateResult.Entity, entity);
            Assert.AreEqual(newPosition, positionUpdateResult.Position);
            
            var readAsyncRemove = mockNetworkLayer.RemoveEventChannel.Reader.ReadAsync();
            AltEntitySync.RemoveEntity(entity);
            var removeTask = readAsyncRemove.AsTask();
            removeTask.Wait();
            var removeResult = removeTask.Result;
            Assert.AreSame(removeResult.Entity, entity);
        }
    }
}