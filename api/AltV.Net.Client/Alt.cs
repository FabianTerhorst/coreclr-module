using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AltV.Net.Client.Elements;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client
{
    public static partial class Alt
    {
        public static Core CoreImpl { get; internal set; } = null!;
        public static ICore Core => CoreImpl;
        public static ILogger Logger { get; internal set; } = null!;

        public static bool GetEntityById(ushort id, [MaybeNullWhen(false)] out IEntity entity)
        {
            entity = default;
            var ent = Core.GetEntityById(id);
            if (ent is null) return false;
            entity = ent;
            return true;
        }

        public static ILocalPlayer LocalPlayer => Core.PlayerPool.LocalPlayer;

        // public static HandlingData? GetHandlingByModelHash(uint modelHash) => Core.GetHandlingByModelHash(modelHash); todo
        public static uint Hash(string key) => Core.Hash(key);

        public static void Log(string message) => Logger.LogInfo(message);
        public static void LogInfo(string message) => Logger.LogInfo(message);
        public static void LogWarning(string message) => Logger.LogWarning(message);
        public static void LogError(string message) => Logger.LogError(message);
        public static void LogDebug(string message) => Logger.LogDebug(message);
        // todo add time and some prefix maybe
        public static void LogExternal(string message) => Alt.Log(message);
    }
}
