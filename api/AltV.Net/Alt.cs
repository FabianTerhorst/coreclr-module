using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

[assembly: InternalsVisibleTo("AltV.Net")]
[assembly: InternalsVisibleTo("AltV.Net.Mock")]
[assembly: InternalsVisibleTo("AltV.Net.Mock2")]
[assembly: InternalsVisibleTo("AltV.Net.Async")]

namespace AltV.Net
{
    public static partial class Alt
    {
        internal static Module Module;

        public static ICore Core => Module.Core;

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

        public static void Emit(string eventName, params object[] args) => Core.TriggerServerEvent(eventName, args);

        public static void EmitAllClients(string eventName, params object[] args) =>
            Core.TriggerClientEventForAll(eventName, args);

        public static void EmitClients(IPlayer[] clients, string eventName, params object[] args) =>
            Core.TriggerClientEventForSome(clients, eventName, args);
        
        public static void Log(string message) => Core.LogInfo(message);

        public static ICollection<IPlayer> GetAllPlayers() => Module.PlayerPool.GetAllEntities();

        public static ICollection<IVehicle> GetAllVehicles() =>
            Module.VehiclePool.GetAllEntities();

        public static ICollection<IBlip> GetAllBlips() => Module.BlipPool.GetAllObjects();

        public static ICollection<ICheckpoint> GetAllCheckpoints() =>
            Module.CheckpointPool.GetAllObjects();

        public static ICollection<IVoiceChannel> GetAllVoiceChannels() =>
            Module.VoiceChannelPool.GetAllObjects();

        public static ICollection<IColShape> GetAllColShapes() =>
            Module.ColShapePool.GetAllObjects();

        public static KeyValuePair<IntPtr, IPlayer>[] GetPlayersArray() => Module.PlayerPool.GetEntitiesArray();

        public static KeyValuePair<IntPtr, IVehicle>[] GetVehiclesArray() => Module.VehiclePool.GetEntitiesArray();

        public static KeyValuePair<IntPtr, IBlip>[] GetBlipsArray() => Module.BlipPool.GetObjectsArray();

        public static KeyValuePair<IntPtr, ICheckpoint>[] GetCheckpointsArray() =>
            Module.CheckpointPool.GetObjectsArray();

        public static KeyValuePair<IntPtr, IVoiceChannel>[] GetVoiceChannelsArray() =>
            Module.VoiceChannelPool.GetObjectsArray();

        public static KeyValuePair<IntPtr, IColShape>[] GetColShapesArray() => Module.ColShapePool.GetObjectsArray();

        public static void ForEachPlayers(IBaseObjectCallback<IPlayer> baseObjectCallback) =>
            Module.PlayerPool.ForEach(baseObjectCallback);

        public static Task ForEachPlayers(IAsyncBaseObjectCallback<IPlayer> baseObjectCallback) =>
            Module.PlayerPool.ForEach(baseObjectCallback);

        public static void ForEachVehicles(IBaseObjectCallback<IVehicle> baseObjectCallback) =>
            Module.VehiclePool.ForEach(baseObjectCallback);

        public static Task ForEachVehicles(IAsyncBaseObjectCallback<IVehicle> baseObjectCallback) =>
            Module.VehiclePool.ForEach(baseObjectCallback);

        public static void ForEachBlips(IBaseObjectCallback<IBlip> baseObjectCallback) =>
            Module.BlipPool.ForEach(baseObjectCallback);

        public static Task ForEachBlips(IAsyncBaseObjectCallback<IBlip> baseObjectCallback) =>
            Module.BlipPool.ForEach(baseObjectCallback);

        public static void ForEachCheckpoints(IBaseObjectCallback<ICheckpoint> baseObjectCallback) =>
            Module.CheckpointPool.ForEach(baseObjectCallback);

        public static Task ForEachCheckpoints(IAsyncBaseObjectCallback<ICheckpoint> baseObjectCallback) =>
            Module.CheckpointPool.ForEach(baseObjectCallback);

        public static void ForEachVoiceChannels(IBaseObjectCallback<IVoiceChannel> baseObjectCallback) =>
            Module.VoiceChannelPool.ForEach(baseObjectCallback);

        public static Task ForEachVoiceChannels(IAsyncBaseObjectCallback<IVoiceChannel> baseObjectCallback) =>
            Module.VoiceChannelPool.ForEach(baseObjectCallback);
        
        public static void ForEachColShapes(IBaseObjectCallback<IColShape> baseObjectCallback) =>
            Module.ColShapePool.ForEach(baseObjectCallback);

        public static Task ForEachColShapes(IAsyncBaseObjectCallback<IColShape> baseObjectCallback) =>
            Module.ColShapePool.ForEach(baseObjectCallback);

        public static VehicleModelInfo GetVehicleModelInfo(uint hash) => Core.GetVehicleModelInfo(hash);
        public static VehicleModelInfo GetVehicleModelInfo(string name) => Core.GetVehicleModelInfo(Hash(name));
        
        public static uint Hash(string stringToHash) => Core.Hash(stringToHash);
        public static ulong HashPassword(string password) => Core.HashPassword(password);

        internal static void Init(Module module)
        {
            Module = module;
        }
    }
}