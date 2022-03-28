using System;

namespace AltV.Net.Client
{
    public static partial class Alt
    {
        internal static Module Module;
        public static IClient Client => Module.Client;
        
        internal static void Init(Module module)
        {
            Module = module;
        }
        
        public static void Log(string message)
        {
            Client.Log(message);
        }
    }
}
