using System.Threading;
using AltV.Net.Data;
using NUnit.Framework;

namespace AltV.Net.ColShape.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            AltColShape.Init(new ColShapeModule(new MockPlayerPool(), new MockVehiclePool()));
        }

        [Test]
        public void Test1()
        {
            var enter = false;
            AltColShape.OnEntityEnterColShape = (o, shape) => { enter = true; };
            AltColShape.Create(new Position(1, 1, 1), 50);
            Thread.Sleep(5000);
            Assert.True(enter);
            Assert.Pass();
        }
    }
}