using System;
using System.Collections.Generic;
using AltV.Net.Native;
using System.Runtime.InteropServices;
using AltV.Net.CApi;
using AltV.Net.Elements.Args;
using AltV.Net.Shared;

namespace AltV.Net
{
    /// <summary>
    /// A wrapper around none standard csharp-module alt:V cpp apis
    /// </summary>
    public class CSharpResourceImpl : SharedCSharpResourceImpl, IDisposable
    {
        private readonly LinkedList<GCHandle> handles = new();

        internal CSharpResourceImpl(ISharedCore core, IntPtr nativePointer) : base(core, nativePointer)
        {
        }

        internal void SetDelegates(AltNative.Resource.MainDelegate onStart)
        {
            handles.AddFirst(GCHandle.Alloc(onStart));
            AltNative.Resource.CSharpResourceImpl_SetMainDelegate(NativePointer, onStart);

            AltNative.Resource.StopDelegate onStop = ModuleWrapper.OnStop;
            handles.AddFirst(GCHandle.Alloc(onStop));
            AltNative.Resource.CSharpResourceImpl_SetStopDelegate(NativePointer, onStop);

            AltNative.Resource.TickDelegate onTick = ModuleWrapper.OnTick;
            handles.AddFirst(GCHandle.Alloc(onTick));
            AltNative.Resource.CSharpResourceImpl_SetTickDelegate(NativePointer, onTick);

            AltNative.Resource.ServerEventDelegate onServerEvent = ModuleWrapper.OnServerEvent;
            handles.AddFirst(GCHandle.Alloc(onServerEvent));
            AltNative.Resource.CSharpResourceImpl_SetServerEventDelegate(NativePointer, onServerEvent);

            AltNative.Resource.CheckpointDelegate onCheckpoint = ModuleWrapper.OnCheckpoint;
            handles.AddFirst(GCHandle.Alloc(onCheckpoint));
            AltNative.Resource.CSharpResourceImpl_SetCheckpointDelegate(NativePointer, onCheckpoint);

            AltNative.Resource.ClientEventDelegate onClientEvent = ModuleWrapper.OnClientEvent;
            handles.AddFirst(GCHandle.Alloc(onClientEvent));
            AltNative.Resource.CSharpResourceImpl_SetClientEventDelegate(NativePointer, onClientEvent);

            AltNative.Resource.PlayerDamageDelegate onPlayerDamage = ModuleWrapper.OnPlayerDamage;
            handles.AddFirst(GCHandle.Alloc(onPlayerDamage));
            AltNative.Resource.CSharpResourceImpl_SetPlayerDamageDelegate(NativePointer, onPlayerDamage);

            AltNative.Resource.PlayerConnectDelegate onPlayerConnect = ModuleWrapper.OnPlayerConnect;
            handles.AddFirst(GCHandle.Alloc(onPlayerConnect));
            AltNative.Resource.CSharpResourceImpl_SetPlayerConnectDelegate(NativePointer, onPlayerConnect);

            AltNative.Resource.PlayerConnectDeniedDelegate onPlayerConnectDenied = ModuleWrapper.OnPlayerConnectDenied;
            handles.AddFirst(GCHandle.Alloc(onPlayerConnectDenied));
            AltNative.Resource.CSharpResourceImpl_SetPlayerConnectDeniedDelegate(NativePointer, onPlayerConnectDenied);

            AltNative.Resource.ResourceEventDelegate onResourceStart = ModuleWrapper.OnResourceStart;
            handles.AddFirst(GCHandle.Alloc(onResourceStart));
            AltNative.Resource.CSharpResourceImpl_SetResourceStartDelegate(NativePointer, onResourceStart);

            AltNative.Resource.ResourceEventDelegate onResourceStop = ModuleWrapper.OnResourceStop;
            handles.AddFirst(GCHandle.Alloc(onResourceStop));
            AltNative.Resource.CSharpResourceImpl_SetResourceStopDelegate(NativePointer, onResourceStop);

            AltNative.Resource.ResourceEventDelegate onResourceError = ModuleWrapper.OnResourceError;
            handles.AddFirst(GCHandle.Alloc(onResourceError));
            AltNative.Resource.CSharpResourceImpl_SetResourceErrorDelegate(NativePointer, onResourceError);

            AltNative.Resource.PlayerDeathDelegate onPlayerDeath = ModuleWrapper.OnPlayerDeath;
            handles.AddFirst(GCHandle.Alloc(onPlayerDeath));
            AltNative.Resource.CSharpResourceImpl_SetPlayerDeathDelegate(NativePointer, onPlayerDeath);

            AltNative.Resource.PlayerHealDelegate onPlayerHeal = ModuleWrapper.OnPlayerHeal;
            handles.AddFirst(GCHandle.Alloc(onPlayerHeal));
            AltNative.Resource.CSharpResourceImpl_SetPlayerHealDelegate(NativePointer, onPlayerHeal);

            AltNative.Resource.ExplosionDelegate onExplosion = ModuleWrapper.OnExplosion;
            handles.AddFirst(GCHandle.Alloc(onExplosion));
            AltNative.Resource.CSharpResourceImpl_SetExplosionDelegate(NativePointer, onExplosion);

            AltNative.Resource.WeaponDamageDelegate onWeaponDamage = ModuleWrapper.OnWeaponDamage;
            handles.AddFirst(GCHandle.Alloc(onWeaponDamage));
            AltNative.Resource.CSharpResourceImpl_SetWeaponDamageDelegate(NativePointer, onWeaponDamage);

            AltNative.Resource.PlayerDisconnectDelegate onPlayerDisconnect = ModuleWrapper.OnPlayerDisconnect;
            handles.AddFirst(GCHandle.Alloc(onPlayerDisconnect));
            AltNative.Resource.CSharpResourceImpl_SetPlayerDisconnectDelegate(NativePointer, onPlayerDisconnect);

            AltNative.Resource.PlayerChangeVehicleSeatDelegate onPlayerChangeVehicleSeat =
                ModuleWrapper.OnPlayerChangeVehicleSeat;
            handles.AddFirst(GCHandle.Alloc(onPlayerChangeVehicleSeat));
            AltNative.Resource.CSharpResourceImpl_SetPlayerChangeVehicleSeatDelegate(NativePointer,
                onPlayerChangeVehicleSeat);

            AltNative.Resource.PlayerEnterVehicleDelegate onPlayerEnterVehicle = ModuleWrapper.OnPlayerEnterVehicle;
            handles.AddFirst(GCHandle.Alloc(onPlayerEnterVehicle));
            AltNative.Resource.CSharpResourceImpl_SetPlayerEnterVehicleDelegate(NativePointer, onPlayerEnterVehicle);

            AltNative.Resource.PlayerEnteringVehicleDelegate onPlayerEnteringVehicle =
                ModuleWrapper.OnPlayerEnteringVehicle;
            handles.AddFirst(GCHandle.Alloc(onPlayerEnteringVehicle));
            AltNative.Resource.CSharpResourceImpl_SetPlayerEnteringVehicleDelegate(NativePointer,
                onPlayerEnteringVehicle);

            AltNative.Resource.PlayerLeaveVehicleDelegate onPlayerLeaveVehicle = ModuleWrapper.OnPlayerLeaveVehicle;
            handles.AddFirst(GCHandle.Alloc(onPlayerLeaveVehicle));
            AltNative.Resource.CSharpResourceImpl_SetPlayerLeaveVehicleDelegate(NativePointer, onPlayerLeaveVehicle);

            AltNative.Resource.ConsoleCommandDelegate onConsoleCommand = ModuleWrapper.OnConsoleCommand;
            handles.AddFirst(GCHandle.Alloc(onConsoleCommand));
            AltNative.Resource.CSharpResourceImpl_SetConsoleCommandDelegate(NativePointer, onConsoleCommand);

            AltNative.Resource.MetaChangeDelegate onMetaDataChange = ModuleWrapper.OnMetaDataChange;
            handles.AddFirst(GCHandle.Alloc(onMetaDataChange));
            AltNative.Resource.CSharpResourceImpl_SetMetaChangeDelegate(NativePointer, onMetaDataChange);

            AltNative.Resource.MetaChangeDelegate onSyncedMetaDataChange = ModuleWrapper.OnSyncedMetaDataChange;
            handles.AddFirst(GCHandle.Alloc(onSyncedMetaDataChange));
            AltNative.Resource.CSharpResourceImpl_SetSyncedMetaChangeDelegate(NativePointer, onSyncedMetaDataChange);

            AltNative.Resource.ColShapeDelegate onColShape = ModuleWrapper.OnColShape;
            handles.AddFirst(GCHandle.Alloc(onColShape));
            AltNative.Resource.CSharpResourceImpl_SetColShapeDelegate(NativePointer, onColShape);

            AltNative.Resource.VehicleDestroyDelegate onVehicleDestroy = ModuleWrapper.OnVehicleDestroy;
            handles.AddFirst(GCHandle.Alloc(onVehicleDestroy));
            AltNative.Resource.CSharpResourceImpl_SetVehicleDestroyDelegate(NativePointer, onVehicleDestroy);

            AltNative.Resource.FireDelegate onFire = ModuleWrapper.OnFire;
            handles.AddFirst(GCHandle.Alloc(onFire));
            AltNative.Resource.CSharpResourceImpl_SetFireDelegate(NativePointer, onFire);

            AltNative.Resource.StartProjectileDelegate onStartProjectile = ModuleWrapper.OnStartProjectile;
            handles.AddFirst(GCHandle.Alloc(onStartProjectile));
            AltNative.Resource.CSharpResourceImpl_SetStartProjectileDelegate(NativePointer, onStartProjectile);

            AltNative.Resource.PlayerWeaponChangeDelegate onPlayerWeaponChange = ModuleWrapper.OnPlayerWeaponChange;
            handles.AddFirst(GCHandle.Alloc(onPlayerWeaponChange));
            AltNative.Resource.CSharpResourceImpl_SetPlayerWeaponChangeDelegate(NativePointer, onPlayerWeaponChange);

            AltNative.Resource.NetOwnerChangeDelegate onNetOwnerChange = ModuleWrapper.OnNetOwnerChange;
            handles.AddFirst(GCHandle.Alloc(onNetOwnerChange));
            AltNative.Resource.CSharpResourceImpl_SetNetOwnerChangeDelegate(NativePointer, onNetOwnerChange);

            AltNative.Resource.VehicleAttachDelegate onVehicleAttach = ModuleWrapper.OnVehicleAttach;
            handles.AddFirst(GCHandle.Alloc(onVehicleAttach));
            AltNative.Resource.CSharpResourceImpl_SetVehicleAttachDelegate(NativePointer, onVehicleAttach);

            AltNative.Resource.VehicleDetachDelegate onVehicleDetach = ModuleWrapper.OnVehicleDetach;
            handles.AddFirst(GCHandle.Alloc(onVehicleDetach));
            AltNative.Resource.CSharpResourceImpl_SetVehicleDetachDelegate(NativePointer, onVehicleDetach);

            AltNative.Resource.VehicleDamageDelegate onVehicleDamage = ModuleWrapper.OnVehicleDamage;
            handles.AddFirst(GCHandle.Alloc(onVehicleDamage));
            AltNative.Resource.CSharpResourceImpl_SetVehicleDamageDelegate(NativePointer, onVehicleDamage);

            AltNative.Resource.VehicleHornDelegate onVehicleHorn = ModuleWrapper.OnVehicleHorn;
            handles.AddFirst(GCHandle.Alloc(onVehicleHorn));
            AltNative.Resource.CSharpResourceImpl_SetVehicleHornDelegate(NativePointer, onVehicleHorn);

            AltNative.Resource.ConnectionQueueAddDelegate onConnectionQueueAdd = ModuleWrapper.OnConnectionQueueAdd;
            handles.AddFirst(GCHandle.Alloc(onConnectionQueueAdd));
            AltNative.Resource.CSharpResourceImpl_SetConnectionQueueAddDelegate(NativePointer, onConnectionQueueAdd);

            AltNative.Resource.ConnectionQueueRemoveDelegate onConnectionQueueRemove = ModuleWrapper.OnConnectionQueueRemove;
            handles.AddFirst(GCHandle.Alloc(onConnectionQueueRemove));
            AltNative.Resource.CSharpResourceImpl_SetConnectionQueueRemoveDelegate(NativePointer, onConnectionQueueRemove);

            AltNative.Resource.ServerStartedDelegate onServerStarted = ModuleWrapper.OnServerStarted;
            handles.AddFirst(GCHandle.Alloc(onServerStarted));
            AltNative.Resource.CSharpResourceImpl_SetServerStartedDelegate(NativePointer, onServerStarted);

            AltNative.Resource.PlayerRequestControlDelegate onPlayerRequestControl = ModuleWrapper.OnPlayerRequestControl;
            handles.AddFirst(GCHandle.Alloc(onPlayerRequestControl));
            AltNative.Resource.CSharpResourceImpl_SetPlayerRequestControlDelegate(NativePointer, onPlayerRequestControl);

            AltNative.Resource.PlayerChangeAnimationDelegate onPlayerChangeAnimation = ModuleWrapper.OnPlayerChangeAnimation;
            handles.AddFirst(GCHandle.Alloc(onPlayerChangeAnimation));
            AltNative.Resource.CSharpResourceImpl_SetPlayerChangeAnimationDelegate(NativePointer, onPlayerChangeAnimation);

            AltNative.Resource.PlayerChangeInteriorDelegate onPlayerChangeInterior = ModuleWrapper.OnPlayerChangeInterior;
            handles.AddFirst(GCHandle.Alloc(onPlayerChangeInterior));
            AltNative.Resource.CSharpResourceImpl_SetPlayerChangeInteriorDelegate(NativePointer, onPlayerChangeInterior);

            AltNative.Resource.PlayerDimensionChangeDelegate onPlayerDimensionChange = ModuleWrapper.OnPlayerDimensionChange;
            handles.AddFirst(GCHandle.Alloc(onPlayerDimensionChange));
            AltNative.Resource.CSharpResourceImpl_SetPlayerDimensionChangeDelegate(NativePointer, onPlayerDimensionChange);

            AltNative.Resource.VehicleSirenDelegate onVehicleSiren = ModuleWrapper.OnVehicleSiren;
            handles.AddFirst(GCHandle.Alloc(onVehicleSiren));
            AltNative.Resource.CSharpResourceImpl_SetVehicleSirenDelegate(NativePointer, onVehicleSiren);

            AltNative.Resource.PlayerSpawnDelegate onPlayerSpawn = ModuleWrapper.OnPlayerSpawn;
            handles.AddFirst(GCHandle.Alloc(onPlayerSpawn));
            AltNative.Resource.CSharpResourceImpl_SetPlayerSpawnDelegate(NativePointer, onPlayerSpawn);

            AltNative.Resource.CreateBaseObjectDelegate onCreateBaseObject = ModuleWrapper.OnCreateBaseObject;
            handles.AddFirst(GCHandle.Alloc(onCreateBaseObject));
            AltNative.Resource.CSharpResourceImpl_SetCreateBaseObjectDelegate(NativePointer, onCreateBaseObject);

            AltNative.Resource.RemoveBaseObjectDelegate onRemoveRemoveBaseObject = ModuleWrapper.OnRemoveBaseObject;
            handles.AddFirst(GCHandle.Alloc(onRemoveRemoveBaseObject));
            AltNative.Resource.CSharpResourceImpl_SetRemoveBaseObjectDelegate(NativePointer, onRemoveRemoveBaseObject);

            AltNative.Resource.RequestSyncedSceneDelegate onRequestSyncedSceneDelegate =
                ModuleWrapper.OnRequestSyncedScene;
            handles.AddFirst(GCHandle.Alloc(onRequestSyncedSceneDelegate));
            AltNative.Resource.CSharpResourceImpl_SetRequestSyncedSceneDelegate(NativePointer, onRequestSyncedSceneDelegate);

            AltNative.Resource.StartSyncedSceneDelegate onStartSyncedScene =
                ModuleWrapper.OnStartSyncedScene;
            handles.AddFirst(GCHandle.Alloc(onStartSyncedScene));
            AltNative.Resource.CSharpResourceImpl_SetStartSyncedSceneDelegate(NativePointer, onStartSyncedScene);

            AltNative.Resource.StopSyncedSceneDelegate onStopSyncedScene =
                ModuleWrapper.OnStopSyncedScene;
            handles.AddFirst(GCHandle.Alloc(onStopSyncedScene));
            AltNative.Resource.CSharpResourceImpl_SetStopSyncedSceneDelegate(NativePointer, onStopSyncedScene);

            AltNative.Resource.UpdateSyncedSceneDelegate onUpdateSyncedSceneDelegate =
                ModuleWrapper.OnUpdateSyncedScene;
            handles.AddFirst(GCHandle.Alloc(onUpdateSyncedSceneDelegate));
            AltNative.Resource.CSharpResourceImpl_SetUpdateSyncedSceneDelegate(NativePointer, onUpdateSyncedSceneDelegate);

            AltNative.Resource.GivePedScriptedTaskDelegate onGivePedScriptedTaskDelegate =
                ModuleWrapper.OnGivePedScriptedTask;
            handles.AddFirst(GCHandle.Alloc(onGivePedScriptedTaskDelegate));
            AltNative.Resource.CSharpResourceImpl_SetGivePedScriptedTaskDelegate(NativePointer, onGivePedScriptedTaskDelegate);


            AltNative.Resource.PedDamageDelegate onPedDamage = ModuleWrapper.OnPedDamage;
            handles.AddFirst(GCHandle.Alloc(onPedDamage));
            AltNative.Resource.CSharpResourceImpl_SetPedDamageDelegate(NativePointer, onPedDamage);

            AltNative.Resource.PedDeathDelegate onPedDeath = ModuleWrapper.OnPedDeath;
            handles.AddFirst(GCHandle.Alloc(onPedDeath));
            AltNative.Resource.CSharpResourceImpl_SetPedDeathDelegate(NativePointer, onPedDeath);

            AltNative.Resource.PedHealDelegate onPedHeal = ModuleWrapper.OnPedHeal;
            handles.AddFirst(GCHandle.Alloc(onPedHeal));
            AltNative.Resource.CSharpResourceImpl_SetPedHealDelegate(NativePointer, onPedHeal);

            AltNative.Resource.PlayerStartTalkingDelegate onPlayerStartTalking = ModuleWrapper.OnPlayerStartTalking;
            handles.AddFirst(GCHandle.Alloc(onPlayerStartTalking));
            AltNative.Resource.CSharpResourceImpl_SetPlayerStartTalkingDelegate(NativePointer, onPlayerStartTalking);

            AltNative.Resource.PlayerStopTalkingDelegate onPlayerStopTalking = ModuleWrapper.OnPlayerStopTalking;
            handles.AddFirst(GCHandle.Alloc(onPlayerStopTalking));
            AltNative.Resource.CSharpResourceImpl_SetPlayerStopTalkingDelegate(NativePointer, onPlayerStopTalking);

            AltNative.Resource.ScriptRPCDelegate onScriptRPC = ModuleWrapper.OnScriptRPC;
            handles.AddFirst(GCHandle.Alloc(onScriptRPC));
            AltNative.Resource.CSharpResourceImpl_SetScriptRPCDelegate(NativePointer, onScriptRPC);

            AltNative.Resource.ScriptRPCAnswerDelegate onScriptRPCAnswer = ModuleWrapper.OnScriptRPCAnswer;
            handles.AddFirst(GCHandle.Alloc(onScriptRPCAnswer));
            AltNative.Resource.CSharpResourceImpl_SetScriptRPCAnswerDelegate(this.NativePointer, onScriptRPCAnswer);

        }

        public void Dispose()
        {
            foreach (var handle in handles)
            {
                handle.Free();
            }

            handles.Clear();
        }
    }
}