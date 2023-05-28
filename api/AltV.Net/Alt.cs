using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Data;

[assembly: InternalsVisibleTo("AltV.Net")]
[assembly: InternalsVisibleTo("AltV.Net.Mock")]
[assembly: InternalsVisibleTo("AltV.Net.Mock2")]
[assembly: InternalsVisibleTo("AltV.Net.Async")]

namespace AltV.Net
{
    public static partial class Alt
    {
        public static ICore Core => CoreImpl;
        internal static Core CoreImpl;

        public static bool CacheEntities { get => AltShared.CacheEntities; set => AltShared.CacheEntities = value; }
        public static bool ThrowIfEntityDoesNotExist = false;

        public static bool IsDebug => Core.IsDebug;

        public static void Emit(string eventName, params object[] args) => Core.TriggerLocalEvent(eventName, args);

        public static void EmitAllClients(string eventName, params object[] args) =>
            Core.TriggerClientEventForAll(eventName, args);

        public static void EmitClients(IPlayer[] clients, string eventName, params object[] args) =>
            Core.TriggerClientEventForSome(clients, eventName, args);

        public static void EmitEventUnreliableAllClients(string eventName, params object[] args) =>
            Core.TriggerClientEventUnreliableForAll(eventName, args);

        public static void EmitUnreliableClients(IPlayer[] clients, string eventName, params object[] args) =>
            Core.TriggerClientEventUnreliableForSome(clients, eventName, args);

        public static IEnumerable<string> GetRegisteredClientEvents() => Core.GetRegisteredClientEvents();
        public static IEnumerable<string> GetRegisteredServerEvents() => Core.GetRegisteredServerEvents();

        public static void Log(string message) => Core.LogInfo(message);

        public static IReadOnlyCollection<IPlayer> GetAllPlayers() => Core.PoolManager.Player.GetAllEntities();

        public static IReadOnlyCollection<IVehicle> GetAllVehicles() =>Core.PoolManager.Vehicle.GetAllEntities();

        public static IReadOnlyCollection<IPed> GetAllPeds() =>Core.PoolManager.Ped.GetAllEntities();

        public static IReadOnlyCollection<IBlip> GetAllBlips() =>Core.PoolManager.Blip.GetAllObjects();

        public static IReadOnlyCollection<ICheckpoint> GetAllCheckpoints() =>Core.PoolManager.Checkpoint.GetAllObjects();

        public static IReadOnlyCollection<IVoiceChannel> GetAllVoiceChannels() =>Core.PoolManager.VoiceChannel.GetAllObjects();

        public static IReadOnlyCollection<IColShape> GetAllColShapes() =>Core.PoolManager.ColShape.GetAllObjects();

        public static IReadOnlyCollection<IConnectionInfo> GetAllConnectionInfos() => Core.PoolManager.ConnectionInfo.GetAllObjects();

        public static KeyValuePair<IntPtr, IPlayer>[] GetPlayersArray() => Core.PoolManager.Player.GetEntitiesArray();

        public static KeyValuePair<IntPtr, IVehicle>[] GetVehiclesArray() => Core.PoolManager.Vehicle.GetEntitiesArray();

        public static KeyValuePair<IntPtr, IPed>[] GetPedsArray() => Core.PoolManager.Ped.GetEntitiesArray();

        public static KeyValuePair<IntPtr, IBlip>[] GetBlipsArray() => Core.PoolManager.Blip.GetObjectsArray();

        public static KeyValuePair<IntPtr, ICheckpoint>[] GetCheckpointsArray() => Core.PoolManager.Checkpoint.GetObjectsArray();

        public static KeyValuePair<IntPtr, IVoiceChannel>[] GetVoiceChannelsArray() => Core.PoolManager.VoiceChannel.GetObjectsArray();

        public static KeyValuePair<IntPtr, IColShape>[] GetColShapesArray() => Core.PoolManager.ColShape.GetObjectsArray();
        public static KeyValuePair<IntPtr, IConnectionInfo>[] GetConnectionInfoArray() => Core.PoolManager.ConnectionInfo.GetObjectsArray();

        public static void ForEachPlayers(IBaseObjectCallback<IPlayer> baseObjectCallback) =>
            Core.PoolManager.Player.ForEach(baseObjectCallback);

        public static Task ForEachPlayers(IAsyncBaseObjectCallback<IPlayer> baseObjectCallback) =>
            Core.PoolManager.Player.ForEach(baseObjectCallback);

        public static void ForEachVehicles(IBaseObjectCallback<IVehicle> baseObjectCallback) =>
            Core.PoolManager.Vehicle.ForEach(baseObjectCallback);

        public static Task ForEachVehicles(IAsyncBaseObjectCallback<IVehicle> baseObjectCallback) =>
            Core.PoolManager.Vehicle.ForEach(baseObjectCallback);

        public static void ForEachPeds(IBaseObjectCallback<IPed> baseObjectCallback) =>
            Core.PoolManager.Ped.ForEach(baseObjectCallback);

        public static Task ForEachPeds(IAsyncBaseObjectCallback<IPed> baseObjectCallback) =>
            Core.PoolManager.Ped.ForEach(baseObjectCallback);

        public static void ForEachBlips(IBaseObjectCallback<IBlip> baseObjectCallback) =>
            Core.PoolManager.Blip.ForEach(baseObjectCallback);

        public static Task ForEachBlips(IAsyncBaseObjectCallback<IBlip> baseObjectCallback) =>
            Core.PoolManager.Blip.ForEach(baseObjectCallback);

        public static void ForEachCheckpoints(IBaseObjectCallback<ICheckpoint> baseObjectCallback) =>
            Core.PoolManager.Checkpoint.ForEach(baseObjectCallback);

        public static Task ForEachCheckpoints(IAsyncBaseObjectCallback<ICheckpoint> baseObjectCallback) =>
            Core.PoolManager.Checkpoint.ForEach(baseObjectCallback);

        public static void ForEachVoiceChannels(IBaseObjectCallback<IVoiceChannel> baseObjectCallback) =>
            Core.PoolManager.VoiceChannel.ForEach(baseObjectCallback);

        public static Task ForEachVoiceChannels(IAsyncBaseObjectCallback<IVoiceChannel> baseObjectCallback) =>
            Core.PoolManager.VoiceChannel.ForEach(baseObjectCallback);

        public static void ForEachColShapes(IBaseObjectCallback<IColShape> baseObjectCallback) =>
            Core.PoolManager.ColShape.ForEach(baseObjectCallback);

        public static Task ForEachColShapes(IAsyncBaseObjectCallback<IColShape> baseObjectCallback) =>
            Core.PoolManager.ColShape.ForEach(baseObjectCallback);

        public static VehicleModelInfo GetVehicleModelInfo(uint hash) => Core.GetVehicleModelInfo(hash);
        public static VehicleModelInfo GetVehicleModelInfo(string name) => Core.GetVehicleModelInfo(Hash(name));
        public static PedModelInfo? GetPedModelInfo(uint hash) => Core.GetPedModelInfo(hash);
        public static PedModelInfo? GetPedModelInfo(string name) => Core.GetPedModelInfo(Hash(name));

        public static uint Hash(string stringToHash) => Core.Hash(stringToHash);
        public static ulong HashPassword(string password) => Core.HashPassword(password);

        public static bool FileExists(string path) => Core.FileExists(path);
        public static string ReadFile(string path) => Core.FileRead(path);
        public static byte[] ReadFileBinary(string path) => Core.FileReadBinary(path);

        public static IConfig GetServerConfig() => Core.GetServerConfig();
        public static IBaseObject GetBaseObjectById(BaseObjectType type, uint id) => Core.GetBaseObjectById(type, id);

        public static IMetric RegisterMetric(string name, MetricType type = MetricType.MetricTypeGauge, Dictionary<string, string> dataDict = default) => Core.RegisterMetric(name, type, dataDict);
        public static void UnregisterMetric(IMetric metric) => Core.UnregisterMetric(metric);
        public static IReadOnlyCollection<IMetric> GetAllMetrics() => Core.GetAllMetrics();
    }
}