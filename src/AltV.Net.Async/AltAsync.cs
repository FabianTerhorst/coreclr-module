using System;
using System.Threading.Tasks;
using AltV.Net.Async.Events;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        internal static AsyncModule Module;

        internal static AltVAsync AltVAsync;

        public static event CheckpointAsyncDelegate OnCheckpoint
        {
            add => Module.CheckpointAsyncEventHandler.Subscribe(value);
            remove => Module.CheckpointAsyncEventHandler.Unsubscribe(value);
        }

        public static event PlayerConnectAsyncDelegate OnPlayerConnect
        {
            add => Module.PlayerConnectAsyncEventHandler.Subscribe(value);
            remove => Module.PlayerConnectAsyncEventHandler.Unsubscribe(value);
        }

        public static event PlayerDamageAsyncDelegate OnPlayerDamage
        {
            add => Module.PlayerDamageAsyncEventHandler.Subscribe(value);
            remove => Module.PlayerDamageAsyncEventHandler.Unsubscribe(value);
        }

        public static event PlayerDeadAsyncDelegate OnPlayerDead
        {
            add => Module.PlayerDeadAsyncEventHandler.Subscribe(value);
            remove => Module.PlayerDeadAsyncEventHandler.Unsubscribe(value);
        }

        public static event PlayerChangeVehicleSeatAsyncDelegate OnPlayerChangeVehicleSeat
        {
            add => Module.PlayerChangeVehicleSeatAsyncEventHandler.Subscribe(value);
            remove => Module.PlayerChangeVehicleSeatAsyncEventHandler.Unsubscribe(value);
        }

        public static event PlayerEnterVehicleAsyncDelegate OnPlayerEnterVehicle
        {
            add => Module.PlayerEnterVehicleAsyncEventHandler.Subscribe(value);
            remove => Module.PlayerEnterVehicleAsyncEventHandler.Unsubscribe(value);
        }

        public static event PlayerLeaveVehicleAsyncDelegate OnPlayerLeaveVehicle
        {
            add => Module.PlayerLeaveVehicleAsyncEventHandler.Subscribe(value);
            remove => Module.PlayerLeaveVehicleAsyncEventHandler.Unsubscribe(value);
        }

        public static event PlayerDisconnectAsyncDelegate OnPlayerDisconnect
        {
            add => Module.PlayerDisconnectAsyncEventHandler.Subscribe(value);
            remove => Module.PlayerDisconnectAsyncEventHandler.Unsubscribe(value);
        }

        public static event EntityRemoveAsyncDelegate OnEntityRemove
        {
            add => Module.EntityRemoveAsyncEventHandler.Subscribe(value);
            remove => Module.EntityRemoveAsyncEventHandler.Unsubscribe(value);
        }

        public static event PlayerClientEventAsyncDelegate OnPlayerEvent
        {
            add => Module.PlayerClientEventAsyncEventHandler.Subscribe(value);
            remove => Module.PlayerClientEventAsyncEventHandler.Unsubscribe(value);
        }

        public static void On(string eventName, ClientEventAsyncDelegate clientEventDelegate)
        {
            Module.On(eventName, clientEventDelegate);
        }

        public static void On(string eventName, ServerEventAsyncDelegate serverEventDelegate)
        {
            Module.On(eventName, serverEventDelegate);
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

        public static async Task Do(Action action)
        {
            await AltVAsync.Schedule(action);
        }

        public static async Task<TResult> Do<TResult>(Func<TResult> action)
        {
            return await AltVAsync.Schedule(action);
        }
    }
}