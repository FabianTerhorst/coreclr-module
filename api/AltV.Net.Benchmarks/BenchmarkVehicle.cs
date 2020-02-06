using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace AltV.Net.Benchmarks
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    //[RPlotExporter]
    public class BenchmarkVehicle
    {
        private LinkedList<IVehicle> vehicles;

        [GlobalSetup]
        public void Setup()
        {
            vehicles = new LinkedList<IVehicle>();
        }

        [Benchmark]
        public void CreateVehicle() =>
            vehicles.AddFirst(Alt.CreateVehicle(VehicleModel.Adder, Position.Zero, Rotation.Zero));

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            foreach (var vehicle in vehicles)
            {
                vehicle.Remove();
            }
        }
    }
}