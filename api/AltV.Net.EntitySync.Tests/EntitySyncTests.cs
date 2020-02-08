using System.Numerics;
using System.Threading;
using AltV.Net.EntitySync.SpatialPartitions;
using NUnit.Framework;

namespace AltV.Net.EntitySync.Tests
{
    public class EntitySyncTests
    {
        [SetUp]
        public void Setup()
        {
            AltEntitySync.Init(1,
                repository => new MockNetworkLayer(repository),
                () => new Grid(50_000, 50_000, 100, 10_000, 10_000),
                new IdProvider());
        } 

        [Test]
        public void AddTest()
        {
            var entity = new Entity(1, Vector3.Zero, 2);
            AltEntitySync.AddEntity(entity);
            Thread.Sleep(3000);
            AltEntitySync.RemoveEntity(entity);
            Thread.Sleep(5000);
        }
    }
}