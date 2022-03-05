using AltV.Net.CApi.Libraries;
using AltV.Net.Native;

#pragma warning disable CS8618

namespace AltV.Net.CApi
{
    public delegate bool EventCallback(IntPtr eventPointer, IntPtr userData);

    public delegate void TickCallback(IntPtr userData);

    public delegate void CommandCallback(StringView cmd, StringViewArray args, IntPtr userData);
    
    public interface ILibrary
    {
        public IClientLibrary Client { get; }
        public IServerLibrary Server { get; }
        public ISharedLibrary Shared { get; }
    }

    public class Library : ILibrary
    {
        public IClientLibrary Client { get; }
        public IServerLibrary Server { get; }
        public ISharedLibrary Shared { get; }
        
        public Library(string dllName, bool client)
        {
            Shared = new SharedLibrary(dllName);
            if (client) Client = new ClientLibrary(dllName);
            else Server = new ServerLibrary(dllName);
        }
    }
}