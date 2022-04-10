using System.Runtime.InteropServices;
using AltV.Net.CApi;
using AltV.Net.Client.Elements;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client
{
    public class Logger : ILogger
    {
        private readonly ILibrary library;
        private readonly IntPtr corePointer;

        public Logger(ILibrary library, IntPtr corePointer)
        {
            this.library = library;
            this.corePointer = corePointer;
        }
        
        public void LogInfo(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message ?? "null");
                library.Shared.Core_LogInfo(corePointer, messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogWarning(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message ?? "null");
                library.Shared.Core_LogWarning(corePointer, messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogError(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message ?? "null");
                library.Shared.Core_LogError(corePointer, messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogDebug(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message ?? "null");
                library.Shared.Core_LogDebug(corePointer, messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }
    }
}