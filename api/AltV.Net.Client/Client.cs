using System.Runtime.InteropServices;
using AltV.Net.Client.CApi;
using AltV.Net.Client.CApi.Memory;

namespace AltV.Net.Client
{
    public class Client : IClient
    {
        public ILibrary Library { get; }
        public IntPtr NativePointer { get; }

        public Client(ILibrary library, IntPtr nativePointer)
        {
            Library = library;
            NativePointer = nativePointer;
        }
        
        public void LogInfo(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message);
                this.Library.LogInfo(messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogWarning(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message);
                this.Library.LogWarning(messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }
        
        public void LogError(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message);
                this.Library.LogError(messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }
        
        public void LogDebug(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message);
                this.Library.LogDebug(messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }
    }
}