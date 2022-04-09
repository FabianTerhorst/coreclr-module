using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
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
        public static INativeResource Resource => Core.Resource;
        public static ILogger Logger { get; internal set; } = null!;

        public static bool GetEntityById(ushort id, [MaybeNullWhen(false)] out IEntity entity)
        {
            entity = default;
            var ent = Core.GetEntityById(id);
            if (ent is null) return false;
            entity = ent;
            return true;
        }

        public static INatives Natives => Core.Natives;
        public static ILocalPlayer LocalPlayer => Core.PlayerPool.LocalPlayer;
        public static DiscordUser? GetDiscordUser() => Core.GetDiscordUser();
        public static LocalStorage LocalStorage => Core.LocalStorage;

        public static HandlingData? GetHandlingByModelHash(uint modelHash) => Core.GetHandlingByModelHash(modelHash);
        public static uint Hash(string key) => Core.Hash(key);

        public static void Log(string message) => Logger.LogInfo(message);
        public static void LogInfo(string message) => Logger.LogInfo(message);
        public static void LogWarning(string message) => Logger.LogWarning(message);
        public static void LogError(string message) => Logger.LogError(message);
        public static void LogDebug(string message) => Logger.LogDebug(message);
        // todo add time and some prefix maybe
        public static void LogExternal(string message) => Alt.Log(message);

        public static string Branch => Core.Branch;
        public static string Version => Core.Version;
        public static bool IsDebug => Core.IsDebug;

        public static void ShowCursor(bool state) => Core.ShowCursor(state);

        public static void EmitServer(string eventName, params object[] args) => Core.TriggerServerEvent(eventName, args);
        public static Vector2 WorldToScreen(Vector3 position) => Core.WorldToScreen(position);
        public static void LoadRmlFont(string path, string name, bool italic = false, bool bold = false) => Core.LoadRmlFont(path, name, italic, bold);
    }
}
