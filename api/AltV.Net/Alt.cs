using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;
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

        [Obsolete("Use Core instead")]
        public static ICore Server
        {
            get
            {
                LogWarning("Alt.Server is deprecated, use Alt.Core instead");
                return Core;
            }
        }

        public static bool IsDebug => Core.IsDebug;

        public static void Emit(string eventName, params object[] args) => Core.TriggerLocalEvent(eventName, args);

        public static void EmitAllClients(string eventName, params object[] args) =>
            Core.TriggerClientEventForAll(eventName, args);

        public static void EmitClients(IPlayer[] clients, string eventName, params object[] args) =>
            Core.TriggerClientEventForSome(clients, eventName, args);
        
        public static void Log(string message) => Core.LogInfo(message);

        public static IReadOnlyCollection<IPlayer> GetAllPlayers() => Core.PlayerPool.GetAllEntities();

        public static IReadOnlyCollection<IVehicle> GetAllVehicles() =>
            Core.VehiclePool.GetAllEntities();

        public static IReadOnlyCollection<IBlip> GetAllBlips() => Core.BlipPool.GetAllObjects();

        public static IReadOnlyCollection<ICheckpoint> GetAllCheckpoints() =>
            Core.CheckpointPool.GetAllObjects();

        public static IReadOnlyCollection<IVoiceChannel> GetAllVoiceChannels() =>
            Core.VoiceChannelPool.GetAllObjects();

        public static IReadOnlyCollection<IColShape> GetAllColShapes() =>
            Core.ColShapePool.GetAllObjects();

        public static KeyValuePair<IntPtr, IPlayer>[] GetPlayersArray() => Core.PlayerPool.GetEntitiesArray();

        public static KeyValuePair<IntPtr, IVehicle>[] GetVehiclesArray() => Core.VehiclePool.GetEntitiesArray();

        public static KeyValuePair<IntPtr, IBlip>[] GetBlipsArray() => Core.BlipPool.GetObjectsArray();

        public static KeyValuePair<IntPtr, ICheckpoint>[] GetCheckpointsArray() =>
            Core.CheckpointPool.GetObjectsArray();

        public static KeyValuePair<IntPtr, IVoiceChannel>[] GetVoiceChannelsArray() =>
            Core.VoiceChannelPool.GetObjectsArray();

        public static KeyValuePair<IntPtr, IColShape>[] GetColShapesArray() => Core.ColShapePool.GetObjectsArray();

        public static void ForEachPlayers(IBaseObjectCallback<IPlayer> baseObjectCallback) =>
            Core.PlayerPool.ForEach(baseObjectCallback);

        public static Task ForEachPlayers(IAsyncBaseObjectCallback<IPlayer> baseObjectCallback) =>
            Core.PlayerPool.ForEach(baseObjectCallback);

        public static void ForEachVehicles(IBaseObjectCallback<IVehicle> baseObjectCallback) =>
            Core.VehiclePool.ForEach(baseObjectCallback);

        public static Task ForEachVehicles(IAsyncBaseObjectCallback<IVehicle> baseObjectCallback) =>
            Core.VehiclePool.ForEach(baseObjectCallback);

        public static void ForEachBlips(IBaseObjectCallback<IBlip> baseObjectCallback) =>
            Core.BlipPool.ForEach(baseObjectCallback);

        public static Task ForEachBlips(IAsyncBaseObjectCallback<IBlip> baseObjectCallback) =>
            Core.BlipPool.ForEach(baseObjectCallback);

        public static void ForEachCheckpoints(IBaseObjectCallback<ICheckpoint> baseObjectCallback) =>
            Core.CheckpointPool.ForEach(baseObjectCallback);

        public static Task ForEachCheckpoints(IAsyncBaseObjectCallback<ICheckpoint> baseObjectCallback) =>
            Core.CheckpointPool.ForEach(baseObjectCallback);

        public static void ForEachVoiceChannels(IBaseObjectCallback<IVoiceChannel> baseObjectCallback) =>
            Core.VoiceChannelPool.ForEach(baseObjectCallback);

        public static Task ForEachVoiceChannels(IAsyncBaseObjectCallback<IVoiceChannel> baseObjectCallback) =>
            Core.VoiceChannelPool.ForEach(baseObjectCallback);
        
        public static void ForEachColShapes(IBaseObjectCallback<IColShape> baseObjectCallback) =>
            Core.ColShapePool.ForEach(baseObjectCallback);

        public static Task ForEachColShapes(IAsyncBaseObjectCallback<IColShape> baseObjectCallback) =>
            Core.ColShapePool.ForEach(baseObjectCallback);

        public static VehicleModelInfo GetVehicleModelInfo(uint hash) => Core.GetVehicleModelInfo(hash);
        public static VehicleModelInfo GetVehicleModelInfo(string name) => Core.GetVehicleModelInfo(Hash(name));
        public static PedModelInfo GetPedModelInfo(uint hash) => Core.GetPedModelInfo(hash);
        public static PedModelInfo GetPedModelInfo(string name) => Core.GetPedModelInfo(Hash(name));
        
        public static uint Hash(string stringToHash) => Core.Hash(stringToHash);
        public static ulong HashPassword(string password) => Core.HashPassword(password);
        
        public static bool FileExists(string path) => Core.FileExists(path);
        public static string ReadFile(string path) => Core.FileRead(path);
        public static byte[] ReadFileBinary(string path) => Core.FileReadBinary(path);

        public static IConfig GetServerConfig() => Core.GetServerConfig();
        public static IEntity GetEntityById(ushort id) => Core.GetEntityById(id);
    }
}