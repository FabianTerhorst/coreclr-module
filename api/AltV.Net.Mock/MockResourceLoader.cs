using System;
using AltV.Net.ResourceLoaders;

namespace AltV.Net.Mock
{
    internal class MockResourceLoader : ResourceLoader
    {
        internal MockResourceLoader(IntPtr serverPointer, string resourceName, string entryPoint) : base(serverPointer,
            new MockAssemblyLoader(), resourceName, entryPoint)
        {
        }

        protected override string GetPath(string pathResourceName, string pathEntryName) => pathEntryName;

        protected override void Log(string message) => Console.WriteLine(message);
    }
}