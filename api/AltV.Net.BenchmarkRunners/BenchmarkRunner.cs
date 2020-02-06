using System;
using System.Reflection;
using BenchmarkDotNet.Running;

namespace AltV.Net.BenchmarkRunners
{
    public class BenchmarkRunner
    {
        public BenchmarkRunner()
        {
        }

        public void Run(string assemblyFile = "AltV.Net.Benchmarks")
        {
            try
            {
                var benchmarkAssembly =
                    Alt.LoadAssemblyFromName(new AssemblyName(assemblyFile));
                var benchmarkSwitcher = BenchmarkSwitcher.FromAssembly(benchmarkAssembly);
                benchmarkSwitcher.RunAll();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Couldn't load the assembly {assemblyFile}.");
                Console.Error.WriteLine(ex.ToString());
            }
        }
    }
}