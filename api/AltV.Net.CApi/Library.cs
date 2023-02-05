using System.Runtime.CompilerServices;
using AltV.Net.CApi.Libraries;
using AltV.Net.Native;

#pragma warning disable CS8618

[assembly: InternalsVisibleTo("AltV.Net")]
[assembly: InternalsVisibleTo("AltV.Net.Shared")]
[assembly: InternalsVisibleTo("AltV.Net.Client")]
[assembly: InternalsVisibleTo("AltV.Net.Mock")]
[assembly: InternalsVisibleTo("AltV.Net.Mock2")]
[assembly: InternalsVisibleTo("AltV.Net.Async")]

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
        
        public bool Outdated { get; }
    }

    public class Library : ILibrary
    {
        public IClientLibrary Client { get; }
        public IServerLibrary Server { get; }
        public ISharedLibrary Shared { get; }

        public bool Outdated { get; }
        
        public Library(Dictionary<ulong, IntPtr> funcTable, bool client)
        {
            Shared = new SharedLibrary(funcTable);
            if (Shared.Outdated) Outdated = true;

            if (client)
            {
                Client = new ClientLibrary(funcTable);
                if (Client.Outdated) Outdated = true;
            }
            else
            {
                Server = new ServerLibrary(funcTable);
                if (Server.Outdated) Outdated = true;
            }
        }
    }
}