using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AltV.Net.Async.Events;
using AltV.Net.Elements.Args;
using AltV.Net.Events;
using AltV.Net.Native;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        internal static AsyncCore Core;

        internal static AltVAsync AltVAsync;

        public static event CheckpointAsyncDelegate OnCheckpoint
        {
            add => Core.CheckpointAsyncEventHandler.Add(value);
            remove => Core.CheckpointAsyncEventHandler.Remove(value);
        }

        public static event PlayerConnectAsyncDelegate OnPlayerConnect
        {
            add => Core.PlayerConnectAsyncEventHandler.Add(value);
            remove => Core.PlayerConnectAsyncEventHandler.Remove(value);
        }

        public static event PlayerBeforeConnectAsyncDelegate OnPlayerBeforeConnect
        {
            add => Core.PlayerBeforeConnectAsyncEventHandler.Add(value);
            remove => Core.PlayerBeforeConnectAsyncEventHandler.Remove(value);
        }

        public static event PlayerDamageAsyncDelegate OnPlayerDamage
        {
            add => Core.PlayerDamageAsyncEventHandler.Add(value);
            remove => Core.PlayerDamageAsyncEventHandler.Remove(value);
        }

        public static event PlayerDeadAsyncDelegate OnPlayerDead
        {
            add => Core.PlayerDeadAsyncEventHandler.Add(value);
            remove => Core.PlayerDeadAsyncEventHandler.Remove(value);
        }

        public static event ExplosionAsyncDelegate OnExplosion
        {
            add => Core.ExplosionAsyncEventHandler.Add(value);
            remove => Core.ExplosionAsyncEventHandler.Remove(value);
        }

        public static event WeaponDamageAsyncDelegate OnWeaponDamage
        {
            add => Core.WeaponDamageAsyncEventHandler.Add(value);
            remove => Core.WeaponDamageAsyncEventHandler.Remove(value);
        }

        public static event PlayerChangeVehicleSeatAsyncDelegate OnPlayerChangeVehicleSeat
        {
            add => Core.PlayerChangeVehicleSeatAsyncEventHandler.Add(value);
            remove => Core.PlayerChangeVehicleSeatAsyncEventHandler.Remove(value);
        }

        public static event PlayerEnterVehicleAsyncDelegate OnPlayerEnterVehicle
        {
            add => Core.PlayerEnterVehicleAsyncEventHandler.Add(value);
            remove => Core.PlayerEnterVehicleAsyncEventHandler.Remove(value);
        }

        public static event PlayerEnteringVehicleAsyncDelegate OnPlayerEnteringVehicle
        {
            add => Core.PlayerEnteringVehicleAsyncEventHandler.Add(value);
            remove => Core.PlayerEnteringVehicleAsyncEventHandler.Remove(value);
        }

        public static event PlayerLeaveVehicleAsyncDelegate OnPlayerLeaveVehicle
        {
            add => Core.PlayerLeaveVehicleAsyncEventHandler.Add(value);
            remove => Core.PlayerLeaveVehicleAsyncEventHandler.Remove(value);
        }

        public static event PlayerDisconnectAsyncDelegate OnPlayerDisconnect
        {
            add => Core.PlayerDisconnectAsyncEventHandler.Add(value);
            remove => Core.PlayerDisconnectAsyncEventHandler.Remove(value);
        }

        public static event PlayerRemoveAsyncDelegate OnPlayerRemove
        {
            add => Core.PlayerRemoveAsyncEventHandler.Add(value);
            remove => Core.PlayerRemoveAsyncEventHandler.Remove(value);
        }

        public static event VehicleRemoveAsyncDelegate OnVehicleRemove
        {
            add => Core.VehicleRemoveAsyncEventHandler.Add(value);
            remove => Core.VehicleRemoveAsyncEventHandler.Remove(value);
        }

        public static event PlayerClientEventAsyncDelegate OnPlayerEvent
        {
            add => Core.PlayerClientEventAsyncEventHandler.Add(value);
            remove => Core.PlayerClientEventAsyncEventHandler.Remove(value);
        }

        public static event ConsoleCommandAsyncDelegate OnConsoleCommand
        {
            add => Core.ConsoleCommandAsyncDelegateHandlers.Add(value);
            remove => Core.ConsoleCommandAsyncDelegateHandlers.Remove(value);
        }

        public static event MetaDataChangeAsyncDelegate OnMetaDataChange
        {
            add => Core.MetaDataChangeAsyncDelegateHandlers.Add(value);
            remove => Core.MetaDataChangeAsyncDelegateHandlers.Remove(value);
        }

        public static event MetaDataChangeAsyncDelegate OnSyncedMetaDataChange
        {
            add => Core.SyncedMetaDataChangeAsyncDelegateHandlers.Add(value);
            remove => Core.SyncedMetaDataChangeAsyncDelegateHandlers.Remove(value);
        }

        public static event ColShapeAsyncDelegate OnColShape
        {
            add => Core.ColShapeAsyncDelegateHandlers.Add(value);
            remove => Core.ColShapeAsyncDelegateHandlers.Remove(value);
        }

        public static event VehicleDestroyAsyncDelegate OnVehicleDestroy
        {
            add => Core.VehicleDestroyAsyncDelegateHandlers.Add(value);
            remove => Core.VehicleDestroyAsyncDelegateHandlers.Remove(value);
        }

        public static event FireAsyncDelegate OnFire
        {
            add => Core.FireAsyncDelegateHandlers.Add(value);
            remove => Core.FireAsyncDelegateHandlers.Remove(value);
        }

        public static event StartProjectileAsyncDelegate OnStartProjectile
        {
            add => Core.StartProjectileAsyncDelegateHandlers.Add(value);
            remove => Core.StartProjectileAsyncDelegateHandlers.Remove(value);
        }

        public static event PlayerWeaponChangeAsyncDelegate OnPlayerWeaponChange
        {
            add => Core.PlayerWeaponChangeAsyncDelegateHandlers.Add(value);
            remove => Core.PlayerWeaponChangeAsyncDelegateHandlers.Remove(value);
        }

        public static event NetOwnerChangeAsyncDelegate OnNetworkOwnerChange
        {
            add => Core.NetOwnerChangeAsyncEventHandler.Add(value);
            remove => Core.NetOwnerChangeAsyncEventHandler.Remove(value);
        }

        public static event VehicleAttachAsyncDelegate OnVehicleAttach
        {
            add => Core.VehicleAttachAsyncEventHandler.Add(value);
            remove => Core.VehicleAttachAsyncEventHandler.Remove(value);
        }

        public static event VehicleDetachAsyncDelegate OnVehicleDetach
        {
            add => Core.VehicleDetachAsyncEventHandler.Add(value);
            remove => Core.VehicleDetachAsyncEventHandler.Remove(value);
        }

        public static event VehicleDamageAsyncDelegate OnVehicleDamage
        {
            add => Core.VehicleDamageAsyncEventHandler.Add(value);
            remove => Core.VehicleDamageAsyncEventHandler.Remove(value);
        }
        
        public static event ConnectionQueueAddAsyncDelegate OnConnectionQueueAdd
        {
            add => Core.ConnectionQueueAddAsyncEventHandler.Add(value);
            remove => Core.ConnectionQueueAddAsyncEventHandler.Remove(value);
        }
        
        public static event ConnectionQueueRemoveAsyncDelegate OnConnectionQueueRemove
        {
            add => Core.ConnectionQueueRemoveAsyncEventHandler.Add(value);
            remove => Core.ConnectionQueueRemoveAsyncEventHandler.Remove(value);
        }
        
        public static event ServerStartedAsyncDelegate OnServerStarted
        {
            add => Core.ServerStartedAsyncEventHandler.Add(value);
            remove => Core.ServerStartedAsyncEventHandler.Remove(value);
        }
        
        public static event PlayerRequestControlAsyncDelegate OnPlayerRequestControl
        {
            add => Core.PlayerRequestControlAsyncEventHandler.Add(value);
            remove => Core.PlayerRequestControlAsyncEventHandler.Remove(value);
        }

        public static async void Log(string message)
        {
            var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
            await Do(() => Alt.Core.LogInfo(messagePtr));
            Marshal.FreeHGlobal(messagePtr);
        }

        public static async void Emit(string eventName, params object[] args)
        {
            var size = args.Length;
            var mValues = new MValueConst[size];
            Alt.Core.CreateMValues(mValues, args);
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            await Do(() => Alt.Core.TriggerServerEvent(eventNamePtr, mValues));
            Marshal.FreeHGlobal(eventNamePtr);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public static async void EmitAllClients(string eventName, params object[] args)
        {
            var size = args.Length;
            var mValues = new MValueConst[size];
            Alt.Core.CreateMValues(mValues, args);
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            await Do(() => Alt.Core.TriggerClientEventForAll(eventNamePtr, mValues));
            Marshal.FreeHGlobal(eventNamePtr);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        [Conditional("DEBUG")]
        private static void CheckIfAsyncResource()
        {
            if (AltVAsync == null)
            {
                throw new InvalidOperationException(
                    "Resource doesn't extends AsyncResource. Please read https://fabianterhorst.github.io/coreclr-module/articles/async.html#setup-async-module");
            }
        }

        internal static void Setup(AltVAsync altVAsync)
        {
            AltVAsync = altVAsync;
        }

        internal static void Setup(AsyncCore core)
        {
            Core = core;
        }

        public static Task Do(Action action)
        {
            CheckIfAsyncResource();
            return AltVAsync.Schedule(action);
        }
        
        public static Task Do(Task task)
        {
            throw new ArgumentException("AltAsync.Do should never have async code inside");
        }
        
        public static Task Do(Func<Task> task)
        {
            throw new ArgumentException("AltAsync.Do should never have async code inside");
        }
        
        public static void RunOnMainThreadBlocking(Action action, SemaphoreSlim semaphoreSlim)
        {
            CheckIfAsyncResource();
            AltVAsync.ScheduleBlocking(action, semaphoreSlim);
        }

        public static void RunOnMainThreadBlockingThrows(Action action, SemaphoreSlim semaphoreSlim)
        {
            CheckIfAsyncResource();
            AltVAsync.ScheduleBlockingThrows(action, semaphoreSlim);
        }

        public static Task Do(Action<object> action, object value)
        {
            CheckIfAsyncResource();
            return AltVAsync.Schedule(action, value);
        }

        public static Task<TResult> Do<TResult>(Func<TResult> action)
        {
            CheckIfAsyncResource();
            return AltVAsync.Schedule(action);
        }

        public static Task<TResult> Do<TResult>(Func<object, TResult> action, object value)
        {
            CheckIfAsyncResource();
            return AltVAsync.Schedule(action, value);
        }

        public static void RunOnMainThread(Action action)
        {
            CheckIfAsyncResource();
            AltVAsync.ScheduleNoneTask(action);
        }

        public static void RunOnMainThread(Action<object> action, object value)
        {
            CheckIfAsyncResource();
            AltVAsync.ScheduleNoneTask(action, value);
        }
    }
}