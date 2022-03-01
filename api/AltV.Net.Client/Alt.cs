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

        public static void Log(string message) => Client.LogInfo(message);
        public static void LogInfo(string message) => Client.LogInfo(message);
        public static void LogWarning(string message) => Client.LogWarning(message);
        public static void LogError(string message) => Client.LogError(message);
        public static void LogDebug(string message) => Client.LogDebug(message);
        // todo add time and some prefix maybe
        public static void LogExternal(string message) => Console.WriteLine(message);
        public static void OnClient(string eventName, Function.Function function) => Module.AddClientEventListener(eventName, function);
    }
}
