using System;
using System.Numerics;
using AltV.Net.EntitySync.SpatialPartitions;
using NUnit.Framework;

namespace AltV.Net.EntitySync.Tests
{
    public class Grid3Tests
    {
        private Grid3 grid3;

        [SetUp]
        public void Setup()
        {
            AltEntitySync.Init(1, 500,
                (threadCount, repository) => new MockNetworkLayer(threadCount, repository),
                (entity, threadCount) => (entity.Id % threadCount), 
                (entityId, entityType, threadCount) => (entityId % threadCount),
                (id) => new Grid(50_000, 50_000, 100, 10_000, 10_000),
                new IdProvider());
            grid3 = new Grid3(50_000, 50_000, 100, 10_000, 10_000);
        }

        [Test]
        public void AddTest()
        {
            var position = GetRandomVector3();
            var entity = new Entity(1, position, 0, 1);
            grid3.Add(entity);
            using (var enumerator = grid3.Find(position, 0).GetEnumerator())
            {
                Assert.True(enumerator.MoveNext());
                Assert.AreEqual(entity, enumerator.Current);
            }
        }

        private static Vector3 GetRandomVector3()
        {
            return new Vector3((float) GetRandomNumber(0, 49_899), (float) GetRandomNumber(0, 49_899),
                (float) GetRandomNumber(0, 49_899));
        }

        private static double GetRandomNumber(double minimum, double maximum)
        {
            var random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}