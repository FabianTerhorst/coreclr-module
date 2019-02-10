using System;
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

        public static event VehicleChangeSeatDelegate OnVehicleChangeSeat
        {
            add => Module.VehicleChangeSeatEventHandler.Subscribe(value);
            remove => Module.VehicleChangeSeatEventHandler.Unsubscribe(value);
        }

        public static event VehicleEnterDelegate OnVehicleEnter
        {
            add => Module.VehicleEnterEventHandler.Subscribe(value);
            remove => Module.VehicleEnterEventHandler.Unsubscribe(value);
        }

        public static event VehicleLeaveDelegate OnVehicleLeave
        {
            add => Module.VehicleLeaveEventHandler.Subscribe(value);
            remove => Module.VehicleLeaveEventHandler.Unsubscribe(value);
        }

        public static void Emit(string eventName, params object[] args) => Server.TriggerServerEvent(eventName, args);

        public static void EmitAllClients(string eventName, params object[] args) =>
            Server.TriggerClientEvent(null, eventName, args);

        public static void Log(string message) => Server.LogInfo(message);

        public static Dictionary<IntPtr, IPlayer>.ValueCollection GetAllPlayers() => Module.PlayerPool.GetAllEntities();

        public static Dictionary<IntPtr, IVehicle>.ValueCollection GetAllVehicles() =>
            Module.VehiclePool.GetAllEntities();

        public static Dictionary<IntPtr, IBlip>.ValueCollection GetAllBlips() => Module.BlipPool.GetAllEntities();

        public static Dictionary<IntPtr, ICheckpoint>.ValueCollection GetAllCheckpoints() =>
            Module.CheckpointPool.GetAllEntities();

        public static uint Hash(string hash) => Server.Hash(hash);

        internal static void Setup(Module module)
        {
            Module = module;
        }
    }
}