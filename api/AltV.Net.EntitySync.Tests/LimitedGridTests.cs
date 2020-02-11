using System;
using System.Numerics;
using AltV.Net.EntitySync.SpatialPartitions;
using NUnit.Framework;

namespace AltV.Net.EntitySync.Tests
{
    public class LimitedGridTests
    {
        private LimitedGrid grid2;

        [SetUp]
        public void Setup()
        {
            AltEntitySync.Init(1, 500,
                repository => new MockNetworkLayer(repository),
                () => new Grid(50_000, 50_000, 100, 10_000, 10_000),
                new IdProvider());
            grid2 = new LimitedGrid(50_000, 50_000, 100, 10_000, 10_000, 3);
        }

        [Test]
        public void AddTest()
        {
            var position = GetRandomVector3();
            var entity = new Entity(1, position, 0, 1);
            var entity2 = new Entity(1, new Vector3(position.X + 1, position.Y, position.Z), 0, 1);
            var entity3 = new Entity(1, new Vector3(position.X, position.Y + 1, position.Z), 0, 1);
            var entity4 = new Entity(1, new Vector3(position.X, position.Y + 1, position.Z + 1), 0, 2);
            grid2.Add(entity);
            grid2.Add(entity2);
            grid2.Add(entity3);
            grid2.Add(entity4);
            using (var enumerator = grid2.Find(position, 0).GetEnumerator())
            {
                Assert.True(enumerator.MoveNext());
                Assert.AreEqual(entity, enumerator.Current);
                Assert.True(enumerator.MoveNext());
                Assert.AreEqual(entity2, enumerator.Current);
                Assert.True(enumerator.MoveNext());
                Assert.AreEqual(entity3, enumerator.Current);
                Assert.False(enumerator.MoveNext());
            }
        }

        private static Vector3 GetRandomVector3()
        {
            return new Vector3((float) GetRandomNumber(0, 49_997), (float) GetRandomNumber(0, 49_997),
                (float) GetRandomNumber(0, 49_997));
        }

        private static double GetRandomNumber(double minimum, double maximum)
        {
            var random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}