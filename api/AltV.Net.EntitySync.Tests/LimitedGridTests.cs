using System;
using System.Collections.Generic;
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
                () => new LimitedGrid(50_000, 50_000, 100, 10_000, 10_000, 3),
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
                var currSet = new HashSet<IEntity>();
                while (enumerator.MoveNext())
                {
                    currSet.Add(enumerator.Current);
                }
                Assert.True(currSet.Contains(entity));
                Assert.True(currSet.Contains(entity2));
                Assert.True(currSet.Contains(entity3));
                Assert.False(currSet.Contains(entity4));
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