using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using NUnit.Framework;

namespace AltV.Net.ColShape.Tests
{
    public class Tests
    {
        private ColShapeModule colShapeModule;

        [SetUp]
        public void Setup()
        {
            colShapeModule = new ColShapeModule(new MockPlayerPool(), new MockVehiclePool());
        }

        [Test]
        public void Test1()
        {
            colShapeModule.Add(new ColShape
            {
                Id = 1,
                Position = new Position(1, 1, 1),
                Radius = 50,
                WorldObjects = new HashSet<IWorldObject>()
            });
            Assert.Pass();
        }
    }
}