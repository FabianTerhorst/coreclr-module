using System.Numerics;
using AltV.Net.EntitySync.SpatialPartitions;
using NUnit.Framework;

namespace AltV.Net.EntitySync.Tests
{
    public class Grid2Tests
    {
        private Grid2 grid2;
        
        [SetUp]
        public void Setup()
        {
            AltEntitySync.Init(1, 500,
                repository => new MockNetworkLayer(repository),
                () => new Grid(50_000, 50_000, 100, 10_000, 10_000),
                new IdProvider());
            grid2 = new Grid2(50_000, 50_000, 100, 10_000, 10_000);
        }

        [Test]
        public void AddTest()
        {
            var entity = new Entity(1, Vector3.Zero, 0, 1);
            grid2.Add(entity);
            using (var enumerator = grid2.Find(Vector3.Zero, 0).GetEnumerator())
            {
                Assert.True(enumerator.MoveNext());
                Assert.AreEqual(entity, enumerator.Current);
            }
        }
    }
}