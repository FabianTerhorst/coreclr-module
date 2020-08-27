using System;
using System.Collections.Generic;
using AltV.Net.Native;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;

namespace AltV.Net
{
    /// <summary>
    /// A wrapper around none standard csharp-module alt:V cpp apis
    /// </summary>
    public class CSharpResourceImpl : IDisposable
    {
        internal readonly IntPtr NativePointer;

        private readonly LinkedList<GCHandle> handles = new LinkedList<GCHandle>();

        internal CSharpResourceImpl(IntPtr nativePointer)
        {
            NativePointer = nativePointer;
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

            AltNative.Resource.ExplosionDelegate onExplosion = ModuleWrapper.OnExplosion;
            handles.AddFirst(GCHandle.Alloc(onExplosion));
            AltNative.Resource.CSharpResourceImpl_SetExplosionDelegate(NativePointer, onExplosion);

            AltNative.Resource.WeaponDamageDelegate onWeaponDamage = ModuleWrapper.OnWeaponDamage;
            handles.AddFirst(GCHandle.Alloc(onWeaponDamage));
            AltNative.Resource.CSharpResourceImpl_SetWeaponDamageDelegate(NativePointer, onWeaponDamage);

            AltNative.Resource.PlayerDisconnectDelegate onPlayerDisconnect = ModuleWrapper.OnPlayerDisconnect;
            handles.AddFirst(GCHandle.Alloc(onPlayerDisconnect));
            AltNative.Resource.CSharpResourceImpl_SetPlayerDisconnectDelegate(NativePointer, onPlayerDisconnect);

            AltNative.Resource.PlayerRemoveDelegate onPlayerRemove = ModuleWrapper.OnPlayerRemove;
            handles.AddFirst(GCHandle.Alloc(onPlayerRemove));
            AltNative.Resource.CSharpResourceImpl_SetPlayerRemoveDelegate(NativePointer, onPlayerRemove);

            AltNative.Resource.VehicleRemoveDelegate onVehicleRemove = ModuleWrapper.OnVehicleRemove;
            handles.AddFirst(GCHandle.Alloc(onVehicleRemove));
            AltNative.Resource.CSharpResourceImpl_SetVehicleRemoveDelegate(NativePointer, onVehicleRemove);

            AltNative.Resource.PlayerChangeVehicleSeatDelegate onPlayerChangeVehicleSeat =
                ModuleWrapper.OnPlayerChangeVehicleSeat;
            handles.AddFirst(GCHandle.Alloc(onPlayerChangeVehicleSeat));
            AltNative.Resource.CSharpResourceImpl_SetPlayerChangeVehicleSeatDelegate(NativePointer,
                onPlayerChangeVehicleSeat);

            AltNative.Resource.PlayerEnterVehicleDelegate onPlayerEnterVehicle = ModuleWrapper.OnPlayerEnterVehicle;
            handles.AddFirst(GCHandle.Alloc(onPlayerEnterVehicle));
            AltNative.Resource.CSharpResourceImpl_SetPlayerEnterVehicleDelegate(NativePointer, onPlayerEnterVehicle);

            AltNative.Resource.PlayerLeaveVehicleDelegate onPlayerLeaveVehicle = ModuleWrapper.OnPlayerLeaveVehicle;
            handles.AddFirst(GCHandle.Alloc(onPlayerLeaveVehicle));
            AltNative.Resource.CSharpResourceImpl_SetPlayerLeaveVehicleDelegate(NativePointer, onPlayerLeaveVehicle);

            AltNative.Resource.CreatePlayerDelegate onCreatePlayer = ModuleWrapper.OnCreatePlayer;
            handles.AddFirst(GCHandle.Alloc(onCreatePlayer));
            AltNative.Resource.CSharpResourceImpl_SetCreatePlayerDelegate(NativePointer, onCreatePlayer);

            AltNative.Resource.RemovePlayerDelegate onRemovePlayer = ModuleWrapper.OnRemovePlayer;
            handles.AddFirst(GCHandle.Alloc(onRemovePlayer));
            AltNative.Resource.CSharpResourceImpl_SetRemovePlayerDelegate(NativePointer, onRemovePlayer);

            AltNative.Resource.CreateVehicleDelegate onCreateVehicle = ModuleWrapper.OnCreateVehicle;
            handles.AddFirst(GCHandle.Alloc(onCreateVehicle));
            AltNative.Resource.CSharpResourceImpl_SetCreateVehicleDelegate(NativePointer, onCreateVehicle);

            AltNative.Resource.RemoveVehicleDelegate onRemoveVehicle = ModuleWrapper.OnRemoveVehicle;
            handles.AddFirst(GCHandle.Alloc(onRemoveVehicle));
            AltNative.Resource.CSharpResourceImpl_SetRemoveVehicleDelegate(NativePointer, onRemoveVehicle);

            AltNative.Resource.CreateBlipDelegate onCreateBlip = ModuleWrapper.OnCreateBlip;
            handles.AddFirst(GCHandle.Alloc(onCreateBlip));
            AltNative.Resource.CSharpResourceImpl_SetCreateBlipDelegate(NativePointer, onCreateBlip);

            AltNative.Resource.RemoveBlipDelegate onRemoveBlip = ModuleWrapper.OnRemoveBlip;
            handles.AddFirst(GCHandle.Alloc(onRemoveBlip));
            AltNative.Resource.CSharpResourceImpl_SetRemoveBlipDelegate(NativePointer, onRemoveBlip);

            AltNative.Resource.CreateCheckpointDelegate onCreateCheckpoint = ModuleWrapper.OnCreateCheckpoint;
            handles.AddFirst(GCHandle.Alloc(onCreateCheckpoint));
            AltNative.Resource.CSharpResourceImpl_SetCreateCheckpointDelegate(NativePointer, onCreateCheckpoint);

            AltNative.Resource.RemoveCheckpointDelegate onRemoveCheckpoint = ModuleWrapper.OnRemoveCheckpoint;
            handles.AddFirst(GCHandle.Alloc(onRemoveCheckpoint));
            AltNative.Resource.CSharpResourceImpl_SetRemoveCheckpointDelegate(NativePointer, onRemoveCheckpoint);

            AltNative.Resource.CreateVoiceChannelDelegate onCreateVoiceChannel = ModuleWrapper.OnCreateVoiceChannel;
            handles.AddFirst(GCHandle.Alloc(onCreateVoiceChannel));
            AltNative.Resource.CSharpResourceImpl_SetCreateVoiceChannelDelegate(NativePointer, onCreateVoiceChannel);

            AltNative.Resource.RemoveVoiceChannelDelegate onRemoveVoiceChannel = ModuleWrapper.OnRemoveVoiceChannel;
            handles.AddFirst(GCHandle.Alloc(onRemoveVoiceChannel));
            AltNative.Resource.CSharpResourceImpl_SetRemoveVoiceChannelDelegate(NativePointer, onRemoveVoiceChannel);

            AltNative.Resource.ConsoleCommandDelegate onConsoleCommand = ModuleWrapper.OnConsoleCommand;
            handles.AddFirst(GCHandle.Alloc(onConsoleCommand));
            AltNative.Resource.CSharpResourceImpl_SetConsoleCommandDelegate(NativePointer, onConsoleCommand);

            AltNative.Resource.MetaChangeDelegate onMetaDataChange = ModuleWrapper.OnMetaDataChange;
            handles.AddFirst(GCHandle.Alloc(onMetaDataChange));
            AltNative.Resource.CSharpResourceImpl_SetMetaChangeDelegate(NativePointer, onMetaDataChange);

            AltNative.Resource.MetaChangeDelegate onSyncedMetaDataChange = ModuleWrapper.OnSyncedMetaDataChange;
            handles.AddFirst(GCHandle.Alloc(onSyncedMetaDataChange));
            AltNative.Resource.CSharpResourceImpl_SetSyncedMetaChangeDelegate(NativePointer, onSyncedMetaDataChange);

            AltNative.Resource.CreateColShapeDelegate onCreateColShape = ModuleWrapper.OnCreateColShape;
            handles.AddFirst(GCHandle.Alloc(onCreateColShape));
            AltNative.Resource.CSharpResourceImpl_SetCreateColShapeDelegate(NativePointer, onCreateColShape);

            AltNative.Resource.RemoveColShapeDelegate onRemoveColShape = ModuleWrapper.OnRemoveColShape;
            handles.AddFirst(GCHandle.Alloc(onRemoveColShape));
            AltNative.Resource.CSharpResourceImpl_SetRemoveColShapeDelegate(NativePointer, onRemoveColShape);

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
        }

        public IntPtr CreateInvoker(MValueFunctionCallback function)
        {
            return AltNative.MValueNative.Invoker_Create(NativePointer, function);
        }

        public void DestroyInvoker(IntPtr invoker)
        {
            AltNative.MValueNative.Invoker_Destroy(NativePointer, invoker);
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