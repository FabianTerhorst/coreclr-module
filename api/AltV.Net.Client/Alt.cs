using System;
using System.Linq;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

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

        public static bool GetPlayerById(ushort id, out IPlayer player) => Module.PlayerPool.Get(id, out player);
        public static bool GetVehicleById(ushort id, out IVehicle vehicle) => Module.VehiclePool.Get(id, out vehicle);
        public static ILocalPlayer LocalPlayer => Module.PlayerPool.LocalPlayer;

        public static void Log(string message) => Core.LogInfo(message);
        public static void LogInfo(string message) => Core.LogInfo(message);
        public static void LogWarning(string message) => Core.LogWarning(message);
        public static void LogError(string message) => Core.LogError(message);
        public static void LogDebug(string message) => Core.LogDebug(message);
        // todo add time and some prefix maybe
        public static void LogExternal(string message) => Alt.Log(message);
    }
}
