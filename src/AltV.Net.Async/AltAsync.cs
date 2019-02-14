using System;
using System.Threading.Tasks;
using AltV.Net.Async.Events;

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
        
        public static event VehicleChangeSeatAsyncDelegate OnVehicleChangeSeat
        {
            add => Module.VehicleChangeSeatAsyncEventHandler.Subscribe(value);
            remove => Module.VehicleChangeSeatAsyncEventHandler.Unsubscribe(value);
        }
        
        public static event VehicleEnterAsyncDelegate OnVehicleEnter
        {
            add => Module.VehicleEnterAsyncEventHandler.Subscribe(value);
            remove => Module.VehicleEnterAsyncEventHandler.Unsubscribe(value);
        }
        
        public static event VehicleLeaveAsyncDelegate OnVehicleLeave
        {
            add => Module.VehicleLeaveAsyncEventHandler.Subscribe(value);
            remove => Module.VehicleLeaveAsyncEventHandler.Unsubscribe(value);
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

        public static async Task Log(string message) => await Do(() => Alt.Server.LogInfo(message));

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