using System;

namespace AltV.Net.Mock
{
    internal class MockResourceLoader : ResourceLoader
    {
        internal MockResourceLoader(IntPtr serverPointer, string resourceName, string entryPoint) : base(serverPointer,
            resourceName, entryPoint)
        {
        }

        public override string GetPath(string pathResourceName, string pathEntryName)
        {
            return pathEntryName;
        }

        public override void Log(string message, Exception exception = null)
        {
            Console.WriteLine(message, exception);
        }
    }
}