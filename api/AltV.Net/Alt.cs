using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using AltV.Net.Events;

namespace AltV.Net
{
    public static partial class Alt
    {
        internal static Module Module;

        public static IServer Server => Module.Server;

        public static event CheckpointDelegate OnCheckpoint
        {
            add => Module.CheckpointEventHandler.Add(value);
            remove => Module.CheckpointEventHandler.Remove(value);
        }

        public static event PlayerConnectDelegate OnPlayerConnect
        {
            add => Module.PlayerConnectEventHandler.Add(value);
            remove => Module.PlayerConnectEventHandler.Remove(value);
        }

        public static event PlayerDamageDelegate OnPlayerDamage
        {
            add => Module.PlayerDamageEventHandler.Add(value);
            remove => Module.PlayerDamageEventHandler.Remove(value);
        }

        public static event PlayerDeadDelegate OnPlayerDead
        {
            add => Module.PlayerDeadEventHandler.Add(value);
            remove => Module.PlayerDeadEventHandler.Remove(value);
        }

        public static event PlayerDisconnectDelegate OnPlayerDisconnect
        {
            add => Module.PlayerDisconnectEventHandler.Add(value);
            remove => Module.PlayerDisconnectEventHandler.Remove(value);
        }

        public static event PlayerRemoveDelegate OnPlayerRemove
        {
            add => Module.PlayerRemoveEventHandler.Add(value);
            remove => Module.PlayerRemoveEventHandler.Remove(value);
        }
        
        public static event VehicleRemoveDelegate OnVehicleRemove
        {
            add => Module.VehicleRemoveEventHandler.Add(value);
            remove => Module.VehicleRemoveEventHandler.Remove(value);
        }

        public static event PlayerChangeVehicleSeatDelegate OnPlayerChangeVehicleSeat
        {
            add => Module.PlayerChangeVehicleSeatEventHandler.Add(value);
            remove => Module.PlayerChangeVehicleSeatEventHandler.Remove(value);
        }

        public static event PlayerEnterVehicleDelegate OnPlayerEnterVehicle
        {
            add => Module.PlayerEnterVehicleEventHandler.Add(value);
            remove => Module.PlayerEnterVehicleEventHandler.Remove(value);
        }

        public static event PlayerLeaveVehicleDelegate OnPlayerLeaveVehicle
        {
            add => Module.PlayerLeaveVehicleEventHandler.Add(value);
            remove => Module.PlayerLeaveVehicleEventHandler.Remove(value);
        }

        public static event PlayerClientEventDelegate OnPlayerEvent
        {
            add => Module.PlayerClientEventEventHandler.Add(value);
            remove => Module.PlayerClientEventEventHandler.Remove(value);
        }

        public static event PlayerClientCustomEventDelegate OnPlayerCustomEvent
        {
            add => Module.PlayerClientCustomEventEventHandler.Add(value);
            remove => Module.PlayerClientCustomEventEventHandler.Remove(value);
        }

        public static event ServerEventEventDelegate OnServerEvent
        {
            add => Module.ServerEventEventHandler.Add(value);
            remove => Module.ServerEventEventHandler.Remove(value);
        }

        public static event ServerCustomEventEventDelegate OnServerCustomEvent
        {
            add => Module.ServerCustomEventEventHandler.Add(value);
            remove => Module.ServerCustomEventEventHandler.Remove(value);
        }
        
        public static event ConsoleCommandDelegate OnConsoleCommand
        {
            add => Module.ConsoleCommandEventHandler.Add(value);
            remove => Module.ConsoleCommandEventHandler.Remove(value);
        }
        
        public static event MetaDataChangeDelegate OnMetaDataChange
        {
            add => Module.MetaDataChangeEventHandler.Add(value);
            remove => Module.MetaDataChangeEventHandler.Remove(value);
        }
        
        public static event MetaDataChangeDelegate OnSyncedMetaDataChange
        {
            add => Module.SyncedMetaDataChangeEventHandler.Add(value);
            remove => Module.SyncedMetaDataChangeEventHandler.Remove(value);
        }
        
        public static event ColShapeDelegate OnColShape
        {
            add => Module.ColShapeEventHandler.Add(value);
            remove => Module.ColShapeEventHandler.Remove(value);
        }

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