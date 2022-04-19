using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AltV.Net")]
[assembly: InternalsVisibleTo("AltV.Net.Mock")]
[assembly: InternalsVisibleTo("AltV.Net.Async")]
[assembly: InternalsVisibleTo("AltV.Net.Client")]

namespace AltV.Net.Shared
{
    public static class AltShared
    {
        public static ISharedCore Core { get; set; }
        public static void EmitLocal(string eventName, params object[] args) => Core.TriggerLocalEvent(eventName, args);
    }
}