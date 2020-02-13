using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Running;

namespace AltV.Net.EntitySync.Benchmarks
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher
                .FromAssembly(typeof(Program).Assembly)
                .Run(args,
                    DefaultConfig.Instance
                        .With(new EtwProfiler()));
            //BenchmarkRunner.Run<BenchmarkEntityThread>();
        }
    }
}