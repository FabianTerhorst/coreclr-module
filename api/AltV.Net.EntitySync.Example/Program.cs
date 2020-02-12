using System;
using System.Numerics;
using System.Threading;
using AltV.Net.EntitySync.SpatialPartitions;

namespace AltV.Net.EntitySync.Example
{
    public static class Program
    {
        private static MockNetworkLayer mockNetworkLayer;
        
        public static void Main(string[] args)
        {
            AltEntitySync.Init(1, 100,
                repository =>
                {
                    mockNetworkLayer = new MockNetworkLayer(repository);
                    return mockNetworkLayer;
                },
                () => new Grid2(50_000, 50_000, 10, 10_000, 10_000), 
                new IdProvider());
        }
        
        private static Vector3 GetRandomVector3()
        {
            return new Vector3((float) GetRandomNumber(0, 50_000), (float) GetRandomNumber(0, 50_000),
                (float) GetRandomNumber(0, 50_000));
        }

        private static double GetRandomNumber(double minimum, double maximum)
        {
            var random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
        
        public static void Entities()
        {
            for (var i = 0; i < 100; i++)
            {
                var entity = new Entity(1, GetRandomVector3(), 0, 2);
                AltEntitySync.AddEntity(entity);
            }
            Thread.Sleep(5000);
        }
    }
}