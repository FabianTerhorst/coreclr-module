using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using AltV.Net.Events;

namespace AltV.Net
{
    public static partial class Alt
    {
        internal static Module Module;

        public static IServer Server => Module.Server;

        public static void Emit(string eventName, params object[] args) => Server.TriggerServerEvent(eventName, args);

        public static void EmitAllClients(string eventName, params object[] args) =>
            Server.TriggerClientEvent(null, eventName, args);

        public static void Log(string message) => Server.LogInfo(message);

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

        public static uint Hash(string stringToHash) => Server.Hash(stringToHash);

        internal static void Init(Module module)
        {
            Module = module;
        }
    }
}