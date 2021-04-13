using System;
using System.Numerics;
using NUnit.Framework;

namespace AltV.Net.Interactions.Tests
{
    public class InteractionTests
    {
        [SetUp]
        public void Setup()
        {
            AltInteractions.Init();
        }

        [Test]
        public void AddTest()
        {
            var position = GetRandomVector3();
            var entity = new Interaction(1, 1, position, 0, 1);
            AltInteractions.AddInteraction(entity);
            var task = AltInteractions.FindInteractions(position, 0);
            task.Wait();
            var interactions = task.Result;
            Assert.AreEqual(1, interactions.Length);
            Assert.AreEqual(entity, interactions[0]);
        }
        
        [Test]
        public void RemoveTest()
        {
            var position = GetRandomVector3();
            var entity = new Interaction(1, 1, position, 0, 1);
            AltInteractions.AddInteraction(entity);
            AltInteractions.RemoveInteraction(entity);
            var task = AltInteractions.FindInteractions(position, 0);
            task.Wait();
            var interactions = task.Result;
            Assert.AreEqual(0, interactions.Length);
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
            AltInteractions.Dispose();
        }
    }
}