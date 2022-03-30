using System.Runtime.InteropServices;
using AltV.Net.Client.CApi;
using AltV.Net.Client.CApi.Memory;
using AltV.Net.Client.Elements;

namespace AltV.Net.Client
{
    public class Logger : ILogger
    {
        private readonly ILibrary library;
        
        public Logger(ILibrary library)
        {
            this.library = library;
        }
        
        public void LogInfo(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message);
                library.LogInfo(messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogWarning(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message);
                library.LogWarning(messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogError(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message);
                library.LogError(messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogDebug(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message);
                library.LogDebug(messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }
    }
}