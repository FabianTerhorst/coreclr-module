using BenchmarkDotNet.Running;

namespace AltV.Net.EntitySync.Benchmarks
{
    public static class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<BenchmarkEntityThread>();
        }
    }
}