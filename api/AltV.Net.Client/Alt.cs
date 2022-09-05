﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using AltV.Net.Client.Elements;
using AltV.Net.Client.Elements.Data;
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
        public static Discord Discord => Core.Discord;
        public static DiscordUser? GetDiscordUser() => Core.GetDiscordUser();
        public static LocalStorage LocalStorage => Core.LocalStorage;
        public static Voice Voice => Core.Voice;
        public static FocusData FocusData => Core.FocusData;

        public static HandlingData? GetHandlingByModelHash(uint modelHash) => Core.GetHandlingByModelHash(modelHash);
        public static WeaponData? GetWeaponDataByWeaponHash(uint weaponHash) => Core.GetWeaponDataByWeaponHash(weaponHash);
        public static uint Hash(string key) => Core.Hash(key);

        public static void Log(string message) => Logger.LogInfo(message);
        public static void LogInfo(string message) => Logger.LogInfo(message);
        public static void LogWarning(string message) => Logger.LogWarning(message);
        public static void LogError(string message) => Logger.LogError(message);
        public static void LogDebug(string message) => Logger.LogDebug(message);

        public static string Branch => Core.Branch;
        public static string Version => Core.Version;
        public static string SdkVersion => Core.SdkVersion;
        public static string CApiVersion => Core.CApiVersion;
        public static bool IsDebug => Core.IsDebug;

        public static IReadOnlyCollection<IPlayer> GetAllPlayers() => Core.PlayerPool.GetAllEntities();
        public static IReadOnlyCollection<IVehicle> GetAllVehicles() => Core.VehiclePool.GetAllEntities();
        public static IReadOnlyCollection<IObject> GetAllObjects() => Core.GetAllObjects();
        public static IReadOnlyCollection<IObject> GetAllWorldObjects() => Core.GetAllWorldObjects();
        public static IReadOnlyCollection<IEntity> GetAllEntities() => GetAllPlayers().Concat<IEntity>(GetAllVehicles()).Concat(GetAllObjects()).Concat(GetAllWorldObjects()).ToList();

        public static void EmitServer(string eventName, params object[] args) => Core.TriggerServerEvent(eventName, args);
        public static void EmitClient(string eventName, params object[] args) => Core.TriggerLocalEvent(eventName, args);

        public static bool HasResource(string name) => Core.HasResource(name);
        public static INativeResource GetResource(string name) => Core.GetResource(name);
        public static INativeResource[] GetAllResources() => Core.GetAllResources();

        public static uint SetTimeout(Action action, uint duration, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0) => Core.SetTimeout(action, duration, filePath, lineNumber);
        public static uint SetInterval(Action action, uint duration, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0) => Core.SetInterval(action, duration, filePath, lineNumber);
        public static uint NextTick(Action action, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0) => Core.NextTick(action, filePath, lineNumber);
        public static uint EveryTick(Action action, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0) => Core.EveryTick(action, filePath, lineNumber);

        public static void ClearTimer(uint id) => Core.ClearTimer(id);
        public static void ClearTimeout(uint id) => ClearTimer(id);
        public static void ClearInterval(uint id) => ClearTimer(id);
        public static void ClearNextTick(uint id) => ClearTimer(id);
        public static void ClearEveryTick(uint id) => ClearTimer(id);

        public static bool FileExists(string path) => Core.FileExists(path);
        public static string ReadFile(string path) => Core.FileRead(path);
        public static byte[] ReadFileBinary(string path) => Core.FileReadBinary(path);
    }
}