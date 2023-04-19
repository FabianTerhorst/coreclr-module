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

        public static event PedRemoveAsyncDelegate OnPedRemove
        {
            add => Core.PedRemoveAsyncEventHandler.Add(value);
            remove => Core.PedRemoveAsyncEventHandler.Remove(value);
        }

        public static event PlayerClientEventAsyncDelegate OnPlayerEvent
        {
            add => Core.PlayerClientEventAsyncEventHandler.Add(value);
            remove => Core.PlayerClientEventAsyncEventHandler.Remove(value);
        }

        public static event ConsoleCommandAsyncDelegate OnConsoleCommand
        {
            add => Core.ConsoleCommandAsyncEventHandler.Add(value);
            remove => Core.ConsoleCommandAsyncEventHandler.Remove(value);
        }

        public static event MetaDataChangeAsyncDelegate OnMetaDataChange
        {
            add => Core.MetaDataChangeAsyncEventHandler.Add(value);
            remove => Core.MetaDataChangeAsyncEventHandler.Remove(value);
        }

        public static event MetaDataChangeAsyncDelegate OnSyncedMetaDataChange
        {
            add => Core.SyncedMetaDataChangeAsyncEventHandler.Add(value);
            remove => Core.SyncedMetaDataChangeAsyncEventHandler.Remove(value);
        }

        public static event ColShapeAsyncDelegate OnColShape
        {
            add => Core.ColShapeAsyncEventHandler.Add(value);
            remove => Core.ColShapeAsyncEventHandler.Remove(value);
        }

        public static event VehicleDestroyAsyncDelegate OnVehicleDestroy
        {
            add => Core.VehicleDestroyAsyncEventHandler.Add(value);
            remove => Core.VehicleDestroyAsyncEventHandler.Remove(value);
        }

        public static event FireAsyncDelegate OnFire
        {
            add => Core.FireAsyncEventHandler.Add(value);
            remove => Core.FireAsyncEventHandler.Remove(value);
        }

        public static event StartProjectileAsyncDelegate OnStartProjectile
        {
            add => Core.StartProjectileAsyncEventHandler.Add(value);
            remove => Core.StartProjectileAsyncEventHandler.Remove(value);
        }

        public static event PlayerWeaponChangeAsyncDelegate OnPlayerWeaponChange
        {
            add => Core.PlayerWeaponChangeAsyncEventHandler.Add(value);
            remove => Core.PlayerWeaponChangeAsyncEventHandler.Remove(value);
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

        public static event VehicleHornAsyncDelegate OnVehicleHorn
        {
            add => Core.VehicleHornAsyncEventHandler.Add(value);
            remove => Core.VehicleHornAsyncEventHandler.Remove(value);
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

        public static event PlayerChangeAnimationAsyncDelegate OnPlayerChangeAnimation
        {
            add => Core.PlayerChangeAnimationAsyncEventHandler.Add(value);
            remove => Core.PlayerChangeAnimationAsyncEventHandler.Remove(value);
        }

        public static event PlayerChangeInteriorAsyncDelegate OnPlayerChangeInterior
        {
            add => Core.PlayerChangeInteriorAsyncEventHandler.Add(value);
            remove => Core.PlayerChangeInteriorAsyncEventHandler.Remove(value);
        }

        public static event PlayerDimensionChangeAsyncDelegate OnPlayerDimensionChange
        {
            add => Core.PlayerDimensionChangeAsyncEventHandler.Add(value);
            remove => Core.PlayerDimensionChangeAsyncEventHandler.Remove(value);
        }

        public static event VehicleSirenAsyncDelegate OnVehicleSiren
        {
            add => Core.VehicleSirenAsyncEventHandler.Add(value);
            remove => Core.VehicleSirenAsyncEventHandler.Remove(value);
        }

        public static event PlayerSpawnAsyncDelegate OnPlayerSpawn
        {
            add => Core.PlayerSpawnAsyncEventHandler.Add(value);
            remove => Core.PlayerSpawnAsyncEventHandler.Remove(value);
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
            await Do(() => Alt.Core.TriggerLocalEvent(eventNamePtr, mValues));
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

        public static async void EmitUnreliableAllClients(string eventName, params object[] args)
        {
            var size = args.Length;
            var mValues = new MValueConst[size];
            Alt.Core.CreateMValues(mValues, args);
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            await Do(() => Alt.Core.TriggerClientEventUnreliableForAll(eventNamePtr, mValues));
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