using System.Collections.Generic;
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
            AltEntitySync.Init(1, 100,
                repository =>
                {
                    mockNetworkLayer = new MockNetworkLayer(repository);
                    return mockNetworkLayer;
                },
                () => new Grid2(50_000, 50_000, 100, 10_000, 10_000),
                new IdProvider());
        }

        [Test]
        public void AddTest()
        {
            var readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            var entity = new Entity(1, Vector3.Zero, 0, 2);
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
        public void RemoveTest()
        {
            var readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            var data = new Dictionary<string, object>();
            data["bla"] = 1337;
            var entity = new Entity(1, Vector3.Zero, 0, 2, data);
            AltEntitySync.AddEntity(entity);
            var createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            var createResult = createTask.Result;
            Assert.AreSame(createResult.Entity, entity);
            
            var readAsyncRemove = mockNetworkLayer.RemoveEventChannel.Reader.ReadAsync();
            var readAsyncClearCache = mockNetworkLayer.ClearCacheEventChannel.Reader.ReadAsync();
            
            AltEntitySync.RemoveEntity(entity);

            var removeTask = readAsyncRemove.AsTask();
            removeTask.Wait();
            var removeResult = removeTask.Result;
            Assert.AreSame(removeResult.Entity, entity);
            
            var clearCacheTask = readAsyncClearCache.AsTask();
            clearCacheTask.Wait();
            var clearCacheResult = clearCacheTask.Result;
            
            Assert.AreSame(clearCacheResult.Entity, entity);
        }

        [Test]
        public void UpdatePositionTest()
        {
            var readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            var entity = new Entity(1, Vector3.Zero, 0, 2);
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

        [Test]
        public void UpdateDimensionTest()
        {
            var readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            var entity = new Entity(1, Vector3.Zero, 0, 2);
            AltEntitySync.AddEntity(entity);
            var createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            var createResult = createTask.Result;
            Assert.AreSame(createResult.Entity, entity);

            var readAsyncRemove = mockNetworkLayer.RemoveEventChannel.Reader.ReadAsync();
            entity.Dimension = 1;
            var removeTask = readAsyncRemove.AsTask();
            removeTask.Wait();
            var removeResult = removeTask.Result;
            Assert.AreSame(removeResult.Entity, entity);
        }

        [Test]
        public void UpdateRangeTest()
        {
            var readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            var entity = new Entity(1, Vector3.One, 0, 2);
            AltEntitySync.AddEntity(entity);
            var createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            var createResult = createTask.Result;
            Assert.AreSame(createResult.Entity, entity);

            var readAsyncRemove = mockNetworkLayer.RemoveEventChannel.Reader.ReadAsync();
            entity.Range = 1;
            var removeTask = readAsyncRemove.AsTask();
            removeTask.Wait();
            var removeResult = removeTask.Result;
            Assert.AreSame(removeResult.Entity, entity);
        }

        [Test]
        public void PositionOverrideTest()
        {
            var readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            var entity = new Entity(1, Vector3.One, 0, 2);
            AltEntitySync.AddEntity(entity);
            var createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            var createResult = createTask.Result;
            Assert.AreSame(createResult.Entity, entity);

            var readAsyncRemove = mockNetworkLayer.RemoveEventChannel.Reader.ReadAsync();

            if (mockNetworkLayer.ClientRepository.TryGet("a", out var client))
            {
                client.SetPositionOverride(new Vector3(10, 10, 10));
            }

            var removeTask = readAsyncRemove.AsTask();
            removeTask.Wait();
            var removeResult = removeTask.Result;
            Assert.AreSame(removeResult.Entity, entity);


            if (mockNetworkLayer.ClientRepository.TryGet("a", out client))
            {
                client.ResetPositionOverride();
            }

            readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            createResult = createTask.Result;

            Assert.AreSame(createResult.Entity, entity);

            readAsyncRemove = mockNetworkLayer.RemoveEventChannel.Reader.ReadAsync();

            if (mockNetworkLayer.ClientRepository.TryGet("a", out client))
            {
                client.SetPositionOverride(new Vector3(100, 100, 100));
            }

            removeTask = readAsyncRemove.AsTask();
            removeTask.Wait();
            removeResult = removeTask.Result;
            Assert.AreSame(removeResult.Entity, entity);
        }

        [Test]
        public void DataTest()
        {
            var readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            var data = new Dictionary<string, object>();
            data["bla"] = 1337;
            var entity = new Entity(1, Vector3.Zero, 0, 2, data);
            AltEntitySync.AddEntity(entity);
            var createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            var createResult = createTask.Result;
            Assert.AreSame(entity, createResult.Entity);
            Assert.AreEqual(new string[] {"bla"}, createResult.ChangedKeys);

            var readAsyncDataUpdate = mockNetworkLayer.DataChangeEventChannel.Reader.ReadAsync();

            entity.SetData("bla", 1338);

            var updateDataTask = readAsyncDataUpdate.AsTask();
            updateDataTask.Wait();
            var updateDataResult = updateDataTask.Result;

            using (var enumerator = updateDataResult.Data.GetEnumerator())
            {
                Assert.AreEqual(true, enumerator.MoveNext());
                Assert.AreEqual("bla", enumerator.Current.Key);
                Assert.AreEqual(1338, enumerator.Current.Value);
                Assert.AreEqual(false, enumerator.MoveNext());
            }

            Assert.AreSame(updateDataResult.Entity, entity);

            var readAsyncRemove = mockNetworkLayer.RemoveEventChannel.Reader.ReadAsync();
            AltEntitySync.RemoveEntity(entity);
            var removeTask = readAsyncRemove.AsTask();
            removeTask.Wait();
            var removeResult = removeTask.Result;
            Assert.AreSame(removeResult.Entity, entity);
        }
    }
}