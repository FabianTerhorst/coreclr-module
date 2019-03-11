using System;

namespace AltV.Net.Mock
{
    internal class MockResourceLoader : ResourceLoader
    {
        internal MockResourceLoader(IntPtr serverPointer, string resourceName, string entryPoint) : base(serverPointer,
            resourceName, entryPoint)
        {
        }

        public override string GetPath(string pathResourceName, string pathEntryName) => pathEntryName;

        public override void Log(string message) => Console.WriteLine(message);
    }
}