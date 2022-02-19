using AltV.Net.Client.CApi;

namespace AltV.Net.Client
{
    public class Client : IClient
    {
        private readonly ILibrary _library;
        private readonly IntPtr _corePointer;

        public Client(ILibrary library, IntPtr corePointer)
        {
            _library = library;
            _corePointer = corePointer;
        }

        public void LogInfo(string message)
        {
            unsafe
            {
                this._library.LogInfo(message);
            }
        }

        public void LogWarning(string message)
        {
            unsafe
            {
                this._library.LogWarning(message);
            }
        }
        
        public void LogError(string message)
        {
            unsafe
            {
                this._library.LogError(message);
            }
        }
        
        public void LogDebug(string message)
        {
            unsafe
            {
                this._library.LogDebug(message);
            }
        }
    }
}