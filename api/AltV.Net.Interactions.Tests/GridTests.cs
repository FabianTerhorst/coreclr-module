using System;
using System.Numerics;
using NUnit.Framework;

namespace AltV.Net.Interactions.Tests
{
    public class GridTests
    {
        private Grid grid, smallGrid;
        
        [SetUp]
        public void Setup()
        {
            grid = new Grid(50_000, 50_000, 100, 10_000, 10_000);
            smallGrid = new Grid(100, 100, 10, 100, 100);
        }

        [Test]
        public void AddTest()
        {
            var position = GetRandomVector3();
            var entity = new Interaction(1, 1, position, 0, 1);
            grid.Add(entity);
            using (var enumerator = grid.Find(position, 0).GetEnumerator())
            {
                Assert.True(enumerator.MoveNext());
                Assert.AreEqual(entity, enumerator.Current);
            }
        }
        
        [Test]
        public void RemoveTest()
        {
            var position = GetRandomVector3();
            var entity = new Interaction(1, 1, position, 0, 1);
            grid.Add(entity);
            grid.Remove(entity);
            using (var enumerator = grid.Find(position, 0).GetEnumerator())
            {
                Assert.False(enumerator.MoveNext());
            }
        }

        [Test]
        public void AddAutoExpandTest()
        {
            var position = new Vector3(200, 200, 200);
            var entity = new Interaction(1, 1, position, 0, 1);
            smallGrid.Add(entity);
            using (var enumerator = smallGrid.Find(position, 0).GetEnumerator())
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
        
        [TearDown]
        public void Cleanup()
        {
        }
    }
}