using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Example;

namespace AltV.Net.Mock.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!2");
            var mockAltV = new MockAltV<IPlayer, IMyVehicle, IBlip, ICheckpoint>();
        }
    }
}