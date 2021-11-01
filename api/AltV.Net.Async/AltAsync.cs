using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
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
            add => Module.CheckpointAsyncEventHandler.Add(value);
            remove => Module.CheckpointAsyncEventHandler.Remove(value);
        }

        public static event PlayerConnectAsyncDelegate OnPlayerConnect
        {
            add => Module.PlayerConnectAsyncEventHandler.Add(value);
            remove => Module.PlayerConnectAsyncEventHandler.Remove(value);
        }

        public static event PlayerBeforeConnectAsyncDelegate OnPlayerBeforeConnect
        {
            add => Module.PlayerBeforeConnectAsyncEventHandler.Add(value);
            remove => Module.PlayerBeforeConnectAsyncEventHandler.Remove(value);
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

        public static event ExplosionAsyncDelegate OnExplosion
        {
            add => Module.ExplosionAsyncEventHandler.Add(value);
            remove => Module.ExplosionAsyncEventHandler.Remove(value);
        }

        public static event WeaponDamageAsyncDelegate OnWeaponDamage
        {
            add => Module.WeaponDamageAsyncEventHandler.Add(value);
            remove => Module.WeaponDamageAsyncEventHandler.Remove(value);
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

        public static event PlayerEnteringVehicleAsyncDelegate OnPlayerEnteringVehicle
        {
            add => Module.PlayerEnteringVehicleAsyncEventHandler.Add(value);
            remove => Module.PlayerEnteringVehicleAsyncEventHandler.Remove(value);
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

        public static event MetaDataChangeAsyncDelegate OnMetaDataChange
        {
            add => Module.MetaDataChangeAsyncDelegateHandlers.Add(value);
            remove => Module.MetaDataChangeAsyncDelegateHandlers.Remove(value);
        }

        public static event MetaDataChangeAsyncDelegate OnSyncedMetaDataChange
        {
            add => Module.SyncedMetaDataChangeAsyncDelegateHandlers.Add(value);
            remove => Module.SyncedMetaDataChangeAsyncDelegateHandlers.Remove(value);
        }

        public static event ColShapeAsyncDelegate OnColShape
        {
            add => Module.ColShapeAsyncDelegateHandlers.Add(value);
            remove => Module.ColShapeAsyncDelegateHandlers.Remove(value);
        }

        public static event VehicleDestroyAsyncDelegate OnVehicleDestroy
        {
            add => Module.VehicleDestroyAsyncDelegateHandlers.Add(value);
            remove => Module.VehicleDestroyAsyncDelegateHandlers.Remove(value);
        }

        public static event FireAsyncDelegate OnFire
        {
            add => Module.FireAsyncDelegateHandlers.Add(value);
            remove => Module.FireAsyncDelegateHandlers.Remove(value);
        }

        public static event StartProjectileAsyncDelegate OnStartProjectile
        {
            add => Module.StartProjectileAsyncDelegateHandlers.Add(value);
            remove => Module.StartProjectileAsyncDelegateHandlers.Remove(value);
        }

        public static event PlayerWeaponChangeAsyncDelegate OnPlayerWeaponChange
        {
            add => Module.PlayerWeaponChangeAsyncDelegateHandlers.Add(value);
            remove => Module.PlayerWeaponChangeAsyncDelegateHandlers.Remove(value);
        }

        public static event NetOwnerChangeAsyncDelegate OnNetworkOwnerChange
        {
            add => Module.NetOwnerChangeAsyncEventHandler.Add(value);
            remove => Module.NetOwnerChangeAsyncEventHandler.Remove(value);
        }

        public static event VehicleAttachAsyncDelegate OnVehicleAttach
        {
            add => Module.VehicleAttachAsyncEventHandler.Add(value);
            remove => Module.VehicleAttachAsyncEventHandler.Remove(value);
        }

        public static event VehicleDetachAsyncDelegate OnVehicleDetach
        {
            add => Module.VehicleDetachAsyncEventHandler.Add(value);
            remove => Module.VehicleDetachAsyncEventHandler.Remove(value);
        }

        public static event VehicleDamageAsyncDelegate OnVehicleDamage
        {
            add => Module.VehicleDamageAsyncEventHandler.Add(value);
            remove => Module.VehicleDamageAsyncEventHandler.Remove(value);
        }

        public static async void Log(string message)
        {
            var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
            await Do(() => Alt.Server.LogInfo(messagePtr));
            Marshal.FreeHGlobal(messagePtr);
        }

        public static async void Emit(string eventName, params object[] args)
        {
            var size = args.Length;
            var mValues = new MValueConst[size];
            Alt.Server.CreateMValues(mValues, args);
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            await Do(() => Alt.Server.TriggerServerEvent(eventNamePtr, mValues));
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
            Alt.Server.CreateMValues(mValues, args);
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            await Do(() => Alt.Server.TriggerClientEventForAll(eventNamePtr, mValues));
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

        internal static void Setup(AsyncModule module)
        {
            Module = module;
        }

        public static Task Do(Action action)
        {
            CheckIfAsyncResource();
            return AltVAsync.Schedule(action);
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