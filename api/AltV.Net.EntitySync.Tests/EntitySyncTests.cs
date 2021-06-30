using System.Collections.Generic;
using System.Numerics;
using System.Threading;
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
            AltEntitySync.Init(1, (id) => 100, _ => true,
                (threadCount, repository) =>
                {
                    mockNetworkLayer = new MockNetworkLayer(threadCount, repository);
                    return mockNetworkLayer;
                },
                (entity, threadCount) => (entity.Id % threadCount),
                (entityId, entityType, threadCount) => (entityId % threadCount),
                (id) => new Grid2(50_000, 50_000, 100, 10_000, 10_000),
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
            //Assert.AreEqual(0, entity.GetClients().Count);
            Assert.AreEqual(0, mockNetworkLayer.a.GetEntities(0).Count);
            Assert.AreEqual(0, mockNetworkLayer.a.GetLastCheckedEntities(0).Count);
        }

        [Test]
        public void RemoveTestWithoutInitialData()
        {
            var readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            var entity = new Entity(1, Vector3.Zero, 0, 2);
            AltEntitySync.AddEntity(entity);
            var createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            var createResult = createTask.Result;
            Assert.AreSame(createResult.Entity, entity);

            var readAsyncDataUpdate = mockNetworkLayer.DataChangeEventChannel.Reader.ReadAsync();

            entity.SetData("bla", 1337);

            var updateDataTask = readAsyncDataUpdate.AsTask();
            updateDataTask.Wait();
            var updateDataResult = updateDataTask.Result;

            using (var enumerator = updateDataResult.Data.GetEnumerator())
            {
                Assert.AreEqual(true, enumerator.MoveNext());
                Assert.AreEqual("bla", enumerator.Current.Key);
                Assert.AreEqual(1337, enumerator.Current.Value);
                Assert.AreEqual(false, enumerator.MoveNext());
            }

            Assert.AreSame(updateDataResult.Entity, entity);

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
            // Two clients in range
            var createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            var createResult = createTask.Result;
            Assert.AreSame(createResult.Entity, entity);

            var readAsyncRemove = mockNetworkLayer.RemoveEventChannel.Reader.ReadAsync();
            
            mockNetworkLayer.a.SetPositionOverride(new Vector3(10, 10, 10));

            var removeTask = readAsyncRemove.AsTask();
            removeTask.Wait();
            var removeResult = removeTask.Result;
            Assert.AreSame(removeResult.Entity, entity);
            
            mockNetworkLayer.a.ResetPositionOverride();

            readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            createResult = createTask.Result;

            Assert.AreSame(createResult.Entity, entity);

            readAsyncRemove = mockNetworkLayer.RemoveEventChannel.Reader.ReadAsync();

            mockNetworkLayer.a.SetPositionOverride(new Vector3(100, 100, 100));

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
            Assert.AreEqual(new string[] {"bla"}, createResult.Data.Keys);
            Assert.AreEqual(new object[] {1337}, createResult.Data.Values);

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

        [Test]
        public void AddRepositoryTest()
        {
            var entity2 = new Entity(0, Vector3.Zero, 0, 2);
            AltEntitySync.AddEntity(entity2);
            if (AltEntitySync.TryGetEntity(entity2.Id, 0, out var foundEntity2))
            {
                Assert.AreSame(entity2, foundEntity2);
            }

            var entity = new Entity(1, Vector3.Zero, 0, 2);
            AltEntitySync.AddEntity(entity);
            if (AltEntitySync.TryGetEntity(entity.Id, 1, out var foundEntity))
            {
                Assert.AreSame(entity, foundEntity);
            }

            AltEntitySync.RemoveEntity(entity2);
            Assert.False(AltEntitySync.TryGetEntity(entity2.Id, 0, out _));
            AltEntitySync.RemoveEntity(entity);
            Assert.False(AltEntitySync.TryGetEntity(entity.Id, 1, out _));
        }

        //TODO: migrate to migration distance testing
        [Test]
        public void NetOwnerTest()
        {
            var readerCreate = mockNetworkLayer.CreateEventChannel.Reader;
            var readerNetOwnerChange = mockNetworkLayer.NetOwnerChangeEventChannel.Reader;
            var readAsyncCreate = readerCreate.ReadAsync();
            var entity2 = new Entity(0, Vector3.Zero, 0, 2, 0);
            AltEntitySync.AddEntity(entity2);
            var createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            Assert.True(readerCreate.TryRead(out var clientCCreateEvent));
            var readAsyncNetOwnerChange = readerNetOwnerChange.ReadAsync();
            var netOwnerChangeTask = readAsyncNetOwnerChange.AsTask();
            netOwnerChangeTask.Wait();
            Assert.AreEqual(mockNetworkLayer.a, netOwnerChangeTask.Result.Item1);
            Assert.True(netOwnerChangeTask.Result.Item2.State);
            Assert.AreEqual(entity2, netOwnerChangeTask.Result.Item2.Entity);
            readAsyncNetOwnerChange = readerNetOwnerChange.ReadAsync();
            netOwnerChangeTask = readAsyncNetOwnerChange.AsTask();
            entity2.Position = new Vector3(1, 1, 1);
            netOwnerChangeTask.Wait();
            Assert.AreEqual(mockNetworkLayer.a, netOwnerChangeTask.Result.Item1);
            Assert.False(netOwnerChangeTask.Result.Item2.State);
            Assert.AreEqual(entity2, netOwnerChangeTask.Result.Item2.Entity);
            readAsyncNetOwnerChange = readerNetOwnerChange.ReadAsync();
            netOwnerChangeTask = readAsyncNetOwnerChange.AsTask();
            netOwnerChangeTask.Wait();
            Assert.AreEqual(mockNetworkLayer.c, netOwnerChangeTask.Result.Item1);
            Assert.True(netOwnerChangeTask.Result.Item2.State);
            Assert.AreEqual(entity2, netOwnerChangeTask.Result.Item2.Entity);
            readAsyncNetOwnerChange = readerNetOwnerChange.ReadAsync();
            netOwnerChangeTask = readAsyncNetOwnerChange.AsTask();
            entity2.Position = new Vector3(0, 0, 0);
            netOwnerChangeTask.Wait();
            Assert.AreEqual(mockNetworkLayer.c, netOwnerChangeTask.Result.Item1);
            Assert.False(netOwnerChangeTask.Result.Item2.State);
            Assert.AreEqual(entity2, netOwnerChangeTask.Result.Item2.Entity);
            readAsyncNetOwnerChange = readerNetOwnerChange.ReadAsync();
            netOwnerChangeTask = readAsyncNetOwnerChange.AsTask();
            netOwnerChangeTask.Wait();
            Assert.AreEqual(mockNetworkLayer.a, netOwnerChangeTask.Result.Item1);
            Assert.True(netOwnerChangeTask.Result.Item2.State);
            Assert.AreEqual(entity2, netOwnerChangeTask.Result.Item2.Entity);
            readAsyncNetOwnerChange = readerNetOwnerChange.ReadAsync();
            netOwnerChangeTask = readAsyncNetOwnerChange.AsTask();
            mockNetworkLayer.ClientRepository.Remove(mockNetworkLayer.a);
            netOwnerChangeTask.Wait();
            Assert.AreEqual(mockNetworkLayer.c, netOwnerChangeTask.Result.Item1);
            Assert.True(netOwnerChangeTask.Result.Item2.State);
            Assert.AreEqual(entity2, netOwnerChangeTask.Result.Item2.Entity);
            readAsyncNetOwnerChange = readerNetOwnerChange.ReadAsync();
            netOwnerChangeTask = readAsyncNetOwnerChange.AsTask();
            mockNetworkLayer.ClientRepository.Add(mockNetworkLayer.a);
            netOwnerChangeTask.Wait();
            Assert.AreEqual(mockNetworkLayer.c, netOwnerChangeTask.Result.Item1);
            Assert.False(netOwnerChangeTask.Result.Item2.State);
            Assert.AreEqual(entity2, netOwnerChangeTask.Result.Item2.Entity);
            readAsyncNetOwnerChange = readerNetOwnerChange.ReadAsync();
            netOwnerChangeTask = readAsyncNetOwnerChange.AsTask();
            netOwnerChangeTask.Wait();
            Assert.AreEqual(mockNetworkLayer.a, netOwnerChangeTask.Result.Item1);
            Assert.True(netOwnerChangeTask.Result.Item2.State);
            Assert.AreEqual(entity2, netOwnerChangeTask.Result.Item2.Entity);
            //TODO: add tests for changing client position, even when that won't have impact with the current computation state
            //TODO: but it makes the test more future proofed
        }
        
        [Test]
        public void NetOwnerTest2()
        {
            var readerCreate = mockNetworkLayer.CreateEventChannel.Reader;
            var readerNetOwnerChange = mockNetworkLayer.NetOwnerChangeEventChannel.Reader;
            var readAsyncCreate = readerCreate.ReadAsync();
            var entity2 = new Entity(0, Vector3.Zero, 0, 4);
            AltEntitySync.AddEntity(entity2);
            var createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            Assert.True(readerCreate.TryRead(out var clientCCreateEvent));
            var readAsyncNetOwnerChange = readerNetOwnerChange.ReadAsync();
            var netOwnerChangeTask = readAsyncNetOwnerChange.AsTask();
            netOwnerChangeTask.Wait();
            Assert.AreEqual(mockNetworkLayer.a, netOwnerChangeTask.Result.Item1);
            Assert.True(netOwnerChangeTask.Result.Item2.State);
            Assert.AreEqual(entity2, netOwnerChangeTask.Result.Item2.Entity);
            entity2.Position = new Vector3(1, 1, 0);
        }
        
        [Test]
        public void NetOwnerTest3()
        {
            var readerCreate = mockNetworkLayer.CreateEventChannel.Reader;
            var readerNetOwnerChange = mockNetworkLayer.NetOwnerChangeEventChannel.Reader;
            var readAsyncCreate = readerCreate.ReadAsync();
            var entity2 = new Entity(0, Vector3.Zero, 0, 2);
            AltEntitySync.AddEntity(entity2);
            var createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            var readAsyncNetOwnerChange = readerNetOwnerChange.ReadAsync();
            var netOwnerChangeTask = readAsyncNetOwnerChange.AsTask();
            netOwnerChangeTask.Wait();
            Assert.AreEqual(mockNetworkLayer.a, netOwnerChangeTask.Result.Item1);
            Assert.True(netOwnerChangeTask.Result.Item2.State);
            Assert.AreEqual(entity2, netOwnerChangeTask.Result.Item2.Entity);
            var client = new Client(1, "d");
            client.Position = new Vector3(0, 0, 1);
            mockNetworkLayer.ClientRepository.Add(client);
            entity2.Position = new Vector3(0, 0, 1);
            Thread.Sleep(1000);
            mockNetworkLayer.ClientRepository.Remove(client);
            Assert.False(mockNetworkLayer.NetOwnerChangeEventChannel.Reader.TryRead(out _));
            client = new Client(1, "d");
            entity2.Position = new Vector3(0, 0, 2);
            client.Position = new Vector3(0, 0, 2);
            mockNetworkLayer.ClientRepository.Add(client);
            Thread.Sleep(1000);
            mockNetworkLayer.ClientRepository.Remove(client);
            Assert.True(mockNetworkLayer.NetOwnerChangeEventChannel.Reader.TryRead(out var changeEvent));
            Assert.AreEqual(mockNetworkLayer.a, changeEvent.Item1);
            Assert.False(changeEvent.Item2.State);
            Assert.AreEqual(entity2, changeEvent.Item2.Entity);
            Assert.True(mockNetworkLayer.NetOwnerChangeEventChannel.Reader.TryRead(out changeEvent));
            Assert.AreEqual(client, changeEvent.Item1);
            Assert.True(changeEvent.Item2.State);
            Assert.AreEqual(entity2, changeEvent.Item2.Entity);
        }
        
        
        [Test]
        public void RemoveClientTest()
        {
            var readAsyncCreate = mockNetworkLayer.CreateEventChannel.Reader.ReadAsync();
            var data = new Dictionary<string, object>();
            data["bla"] = 1337;
            var entity = new Entity(1, new Vector3(1000, 1000, 1000), 0, 2, data);
            AltEntitySync.AddEntity(entity);
            mockNetworkLayer.AddDummyClient();
            var createTask = readAsyncCreate.AsTask();
            createTask.Wait();
            var createResult = createTask.Result;
            Assert.AreSame(createResult.Entity, entity);
            Assert.AreEqual(1, entity.GetClients().Count);
            Assert.AreEqual(1, entity.DataSnapshot.GetLastClients().Count);

            mockNetworkLayer.RemoveDummyClient();
            
            Thread.Sleep(100);

            Assert.AreEqual(0, entity.DataSnapshot.GetLastClients().Count);
            Assert.AreEqual(0, entity.GetClients().Count);
            
            AltEntitySync.RemoveEntity(entity);
        }
    }
}