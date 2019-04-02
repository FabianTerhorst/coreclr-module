using System;
using System.Threading.Tasks;
using AltV.Net.Async.Events;
using AltV.Net.Elements.Args;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        internal static AsyncModule Module;

        internal static AltVAsync AltVAsync;

        public static event CheckpointAsyncDelegate OnCheckpoint
        {
            add => Module.CheckpointAsyncEventHandler.Add(value);
            remove => Module.CheckpointAsyncEventHandler.Remove(value);
        }

        public static event PlayerConnectAsyncDelegate OnPlayerConnect
        {
            add => Module.PlayerConnectAsyncEventHandler.Add(value);
            remove => Module.PlayerConnectAsyncEventHandler.Remove(value);
        }

        public static event PlayerDamageAsyncDelegate OnPlayerDamage
        {
            add => Module.PlayerDamageAsyncEventHandler.Add(value);
            remove => Module.PlayerDamageAsyncEventHandler.Remove(value);
        }

        public static event PlayerDeadAsyncDelegate OnPlayerDead
        {
            add => Module.PlayerDeadAsyncEventHandler.Add(value);
            remove => Module.PlayerDeadAsyncEventHandler.Remove(value);
        }

        public static event PlayerChangeVehicleSeatAsyncDelegate OnPlayerChangeVehicleSeat
        {
            add => Module.PlayerChangeVehicleSeatAsyncEventHandler.Add(value);
            remove => Module.PlayerChangeVehicleSeatAsyncEventHandler.Remove(value);
        }

        public static event PlayerEnterVehicleAsyncDelegate OnPlayerEnterVehicle
        {
            add => Module.PlayerEnterVehicleAsyncEventHandler.Add(value);
            remove => Module.PlayerEnterVehicleAsyncEventHandler.Remove(value);
        }

        public static event PlayerLeaveVehicleAsyncDelegate OnPlayerLeaveVehicle
        {
            add => Module.PlayerLeaveVehicleAsyncEventHandler.Add(value);
            remove => Module.PlayerLeaveVehicleAsyncEventHandler.Remove(value);
        }

        public static event PlayerDisconnectAsyncDelegate OnPlayerDisconnect
        {
            add => Module.PlayerDisconnectAsyncEventHandler.Add(value);
            remove => Module.PlayerDisconnectAsyncEventHandler.Remove(value);
        }

        public static event PlayerRemoveAsyncDelegate OnPlayerRemove
        {
            add => Module.PlayerRemoveAsyncEventHandler.Add(value);
            remove => Module.PlayerRemoveAsyncEventHandler.Remove(value);
        }

        public static event VehicleRemoveAsyncDelegate OnVehicleRemove
        {
            add => Module.VehicleRemoveAsyncEventHandler.Add(value);
            remove => Module.VehicleRemoveAsyncEventHandler.Remove(value);
        }

        public static event PlayerClientEventAsyncDelegate OnPlayerEvent
        {
            add => Module.PlayerClientEventAsyncEventHandler.Add(value);
            remove => Module.PlayerClientEventAsyncEventHandler.Remove(value);
        }

        public static event ConsoleCommandAsyncDelegate OnConsoleCommand
        {
            add => Module.ConsoleCommandAsyncDelegateHandlers.Add(value);
            remove => Module.ConsoleCommandAsyncDelegateHandlers.Remove(value);
        }

        public static async void Log(string message) => await Do(() => Alt.Server.LogInfo(message));

        public static async void Emit(string eventName, params object[] args)
        {
            var mValueArgs = MValue.Create(MValue.CreateFromObjects(args));
            await AltVAsync.Schedule(() => Alt.Server.TriggerServerEvent(eventName, ref mValueArgs));
        }

        public static async void EmitAll(string eventName, params object[] args)
        {
            var mValueArgs = MValue.Create(MValue.CreateFromObjects(args));
            await AltVAsync.Schedule(() => Alt.Server.TriggerClientEvent(null, eventName, ref mValueArgs));
        }

        internal static void Setup(AltVAsync altVAsync)
        {
            AltVAsync = altVAsync;
        }

        internal static void Setup(AsyncModule module)
        {
            Module = module;
        }

        public static Task Do(Action action)
        {
            return AltVAsync.Schedule(action);
        }

        public static Task<TResult> Do<TResult>(Func<TResult> action)
        {
            return AltVAsync.Schedule(action);
        }
    }
}