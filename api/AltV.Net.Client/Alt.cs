using System;
using System.Linq;
using AltV.Net.Client.Elements.Entities;

namespace AltV.Net.Client
{
    public static partial class Alt
    {
        internal static Module Module;
        public static ICore Core => Module.Core;
        
        internal static void Init(Module module)
        {
            Module = module;
        }

        public static IPlayer LocalPlayer => Module.PlayerPool.LocalPlayer;

        public static void Log(string message) => Core.LogInfo(message);
        public static void LogInfo(string message) => Core.LogInfo(message);
        public static void LogWarning(string message) => Core.LogWarning(message);
        public static void LogError(string message) => Core.LogError(message);
        public static void LogDebug(string message) => Core.LogDebug(message);
        // todo add time and some prefix maybe
        public static void LogExternal(string message) => Console.WriteLine(message);
    }
}
