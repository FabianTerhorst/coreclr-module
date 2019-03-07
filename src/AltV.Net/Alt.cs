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
            add => Module.CheckpointEventHandler.Subscribe(value);
            remove => Module.CheckpointEventHandler.Unsubscribe(value);
        }

        public static event PlayerConnectDelegate OnPlayerConnect
        {
            add => Module.PlayerConnectEventHandler.Subscribe(value);
            remove => Module.PlayerConnectEventHandler.Unsubscribe(value);
        }

        public static event PlayerDamageDelegate OnPlayerDamage
        {
            add => Module.PlayerDamageEventHandler.Subscribe(value);
            remove => Module.PlayerDamageEventHandler.Unsubscribe(value);
        }

        public static event PlayerDeadDelegate OnPlayerDead
        {
            add => Module.PlayerDeadEventHandler.Subscribe(value);
            remove => Module.PlayerDeadEventHandler.Unsubscribe(value);
        }

        public static event PlayerDisconnectDelegate OnPlayerDisconnect
        {
            add => Module.PlayerDisconnectEventHandler.Subscribe(value);
            remove => Module.PlayerDisconnectEventHandler.Unsubscribe(value);
        }

        public static event EntityRemoveDelegate OnEntityRemove
        {
            add => Module.EntityRemoveEventHandler.Subscribe(value);
            remove => Module.EntityRemoveEventHandler.Unsubscribe(value);
        }

        public static event PlayerChangeVehicleSeatDelegate OnPlayerChangeVehicleSeat
        {
            add => Module.PlayerChangeVehicleSeatEventHandler.Subscribe(value);
            remove => Module.PlayerChangeVehicleSeatEventHandler.Unsubscribe(value);
        }

        public static event PlayerEnterVehicleDelegate OnPlayerEnterVehicle
        {
            add => Module.PlayerEnterVehicleEventHandler.Subscribe(value);
            remove => Module.PlayerEnterVehicleEventHandler.Unsubscribe(value);
        }

        public static event PlayerLeaveVehicleDelegate OnPlayerLeaveVehicle
        {
            add => Module.PlayerLeaveVehicleEventHandler.Subscribe(value);
            remove => Module.PlayerLeaveVehicleEventHandler.Unsubscribe(value);
        }

        public static event PlayerClientEventDelegate OnPlayerEvent
        {
            add => Module.PlayerClientEventEventHandler.Subscribe(value);
            remove => Module.PlayerClientEventEventHandler.Unsubscribe(value);
        }

        public static event PlayerClientCustomEventDelegate OnPlayerCustomEvent
        {
            add => Module.PlayerClientCustomEventEventHandler.Subscribe(value);
            remove => Module.PlayerClientCustomEventEventHandler.Unsubscribe(value);
        }

        public static event ServerEventEventDelegate OnServerEvent
        {
            add => Module.ServerEventEventHandler.Subscribe(value);
            remove => Module.ServerEventEventHandler.Unsubscribe(value);
        }

        public static event ServerCustomEventEventDelegate OnServerCustomEvent
        {
            add => Module.ServerCustomEventEventHandler.Subscribe(value);
            remove => Module.ServerCustomEventEventHandler.Unsubscribe(value);
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

        public static uint Hash(string stringToHash) => Server.Hash(stringToHash);

        internal static void Setup(Module module)
        {
            Module = module;
        }
    }
}