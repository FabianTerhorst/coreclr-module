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

        public void Log(string message)
        {
            unsafe
            {
                this._library.LogInfo(message);
            }
        }
    }
}