using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client
{
    public static partial class Alt
    {
        public static Core CoreImpl { get; internal set; } = null!;
        public static ICore Core => CoreImpl;

        // public static bool GetEntityById(ushort id, [MaybeNullWhen(false)] out IEntity entity) => Module.GetEntityById(id, out entity);
        
        // public static bool GetPlayerById(ushort id, [MaybeNullWhen(false)] out IPlayer player)
        // {
        //     player = Module.PlayerPool.Get(id);
        //     return player is not null;
        // }
        //
        // public static bool GetVehicleById(ushort id, [MaybeNullWhen(false)] out IVehicle vehicle)
        // {
        //     vehicle = Module.VehiclePool.Get(id);
        //     return vehicle is not null;
        // }
        
        public static ILocalPlayer LocalPlayer => Core.PlayerPool.LocalPlayer;

        public static HandlingData? GetHandlingByModelHash(uint modelHash) => Core.GetHandlingByModelHash(modelHash);
        public static uint Hash(string key) => Core.Hash(key);

        public static void Log(string message) => Core.LogInfo(message);
        public static void LogInfo(string message) => Core.LogInfo(message);
        public static void LogWarning(string message) => Core.LogWarning(message);
        public static void LogError(string message) => Core.LogError(message);
        public static void LogDebug(string message) => Core.LogDebug(message);
        // todo add time and some prefix maybe
        public static void LogExternal(string message) => Alt.Log(message);
    }
}
