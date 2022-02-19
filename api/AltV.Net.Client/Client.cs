using AltV.Net.Client.CApi;

namespace AltV.Net.Client
{
    public class Client : IClient
    {
        public ILibrary Library { get; }
        private readonly IntPtr _corePointer;

        public Client(ILibrary library, IntPtr corePointer)
        {
            Library = library;
            _corePointer = corePointer;
        }

        public void LogInfo(string message)
        {
            unsafe
            {
                this.Library.LogInfo(message);
            }
        }

        public void LogWarning(string message)
        {
            unsafe
            {
                this.Library.LogWarning(message);
            }
        }
        
        public void LogError(string message)
        {
            unsafe
            {
                this.Library.LogError(message);
            }
        }
        
        public void LogDebug(string message)
        {
            unsafe
            {
                this.Library.LogDebug(message);
            }
        }
    }
}