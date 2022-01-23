using System;
using System.Numerics;
using NUnit.Framework;

namespace AltV.Net.Interactions.Tests
{
    public class InteractionTests
    {
        private InteractionsService interactionsService;
        
        [SetUp]
        public void Setup()
        {
            var interactionsServiceBuilder = InteractionsService.CreateBuilder();
            interactionsServiceBuilder.AddThreadForType(1);
            interactionsService = interactionsServiceBuilder.Build();
        }

        [Test]
        public void AddTest()
        {
            var position = GetRandomVector3();
            var entity = new Interaction(1, 1, position, 0, 1);
            interactionsService.Add(entity);
            var task = interactionsService.Find(1, position, 0);
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
            interactionsService.Add(entity);
            interactionsService.Remove(entity);
            var task = interactionsService.Find(1, position, 0);
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
            interactionsService.Dispose();
        }
    }
}