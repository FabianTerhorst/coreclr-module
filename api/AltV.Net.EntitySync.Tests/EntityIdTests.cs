using System.Numerics;
using AltV.Net.EntitySync.SpatialPartitions;
using NUnit.Framework;

namespace AltV.Net.EntitySync.Tests
{
    public class EntityIdTests
    {
        [SetUp]
        public void Setup()
        {
            AltEntitySync.Init(1, 500, _ => true,
                (threadCount, repository) => new MockNetworkLayer(threadCount, repository),
                (entity, threadCount) => (entity.Id % threadCount), 
                (entityId, entityType, threadCount) => (entityId % threadCount),
                (id) => new Grid2(50_000, 50_000, 100, 10_000, 10_000), 
                new IdProvider());
        }

        [Test]
        public void AddTest()
        {
            var entity = new Entity(1, Vector3.One, 0, 1);
            AltEntitySync.AddEntity(entity);
            AltEntitySync.RemoveEntity(entity);
        }
    }
}