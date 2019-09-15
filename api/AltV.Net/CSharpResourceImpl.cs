using System;
using AltV.Net.Native;
using System.Runtime.InteropServices;

namespace AltV.Net
{
    /// <summary>
    /// A wrapper around none standard alt:V cpp apis
    /// </summary>
    public class CSharpResourceImpl
    {
        internal readonly IntPtr NativePointer;

        internal CSharpResourceImpl(IntPtr nativePointer)
        {
            NativePointer = nativePointer;
        }

        public void Reload()
        {
            AltNative.Resource.CSharpResourceImpl_Reload(NativePointer);
        }

        public void Load()
        {
            AltNative.Resource.CSharpResourceImpl_Load(NativePointer);
        }

        public void Unload()
        {
            AltNative.Resource.CSharpResourceImpl_Unload(NativePointer);
        }

        internal void SetDelegates(AltNative.Resource.MainDelegate onStart)
        {
            GCHandle.Alloc(onStart);
            AltNative.Resource.CSharpResourceImpl_SetMainDelegate(NativePointer, onStart);

            AltNative.Resource.StopDelegate onStop = ModuleWrapper.OnStop;
            GCHandle.Alloc(onStop);
            AltNative.Resource.CSharpResourceImpl_SetStopDelegate(NativePointer, onStop);

            AltNative.Resource.TickDelegate onTick  = ModuleWrapper.OnTick;
            GCHandle.Alloc(onTick);
            AltNative.Resource.CSharpResourceImpl_SetTickDelegate(NativePointer, onTick);

            AltNative.Resource.ServerEventDelegate onServerEvent = ModuleWrapper.OnServerEvent;
            GCHandle.Alloc(onServerEvent);
            AltNative.Resource.CSharpResourceImpl_SetServerEventDelegate(NativePointer, onServerEvent);

            AltNative.Resource.CheckpointDelegate onCheckpoint = ModuleWrapper.OnCheckpoint;
            GCHandle.Alloc(onCheckpoint);
            AltNative.Resource.CSharpResourceImpl_SetCheckpointDelegate(NativePointer, onCheckpoint);

            AltNative.Resource.ClientEventDelegate onClientEvent = ModuleWrapper.OnClientEvent;
            GCHandle.Alloc(onClientEvent);
            AltNative.Resource.CSharpResourceImpl_SetClientEventDelegate(NativePointer, onClientEvent);

            AltNative.Resource.PlayerDamageDelegate onPlayerDamage = ModuleWrapper.OnPlayerDamage;
            GCHandle.Alloc(onPlayerDamage);
            AltNative.Resource.CSharpResourceImpl_SetPlayerDamageDelegate(NativePointer, onPlayerDamage);

            AltNative.Resource.PlayerConnectDelegate onPlayerConnect = ModuleWrapper.OnPlayerConnect;
            GCHandle.Alloc(onPlayerConnect);
            AltNative.Resource.CSharpResourceImpl_SetPlayerConnectDelegate(NativePointer, onPlayerConnect);

            AltNative.Resource.PlayerDeathDelegate onPlayerDeath = ModuleWrapper.OnPlayerDeath;
            GCHandle.Alloc(onPlayerDeath);
            AltNative.Resource.CSharpResourceImpl_SetPlayerDeathDelegate(NativePointer, onPlayerDeath);

            AltNative.Resource.ExplosionDelegate onExplosion = ModuleWrapper.OnExplosion;
            GCHandle.Alloc(onExplosion);
            AltNative.Resource.CSharpResourceImpl_SetExplosionDelegate(NativePointer, onExplosion);

            AltNative.Resource.WeaponDamageDelegate onWeaponDamage = ModuleWrapper.OnWeaponDamage;
            GCHandle.Alloc(onWeaponDamage);
            AltNative.Resource.CSharpResourceImpl_SetWeaponDamageDelegate(NativePointer, onWeaponDamage);

            AltNative.Resource.PlayerDisconnectDelegate onPlayerDisconnect = ModuleWrapper.OnPlayerDisconnect;
            GCHandle.Alloc(onPlayerDisconnect);
            AltNative.Resource.CSharpResourceImpl_SetPlayerDisconnectDelegate(NativePointer, onPlayerDisconnect);

            AltNative.Resource.PlayerRemoveDelegate onPlayerRemove = ModuleWrapper.OnPlayerRemove;
            GCHandle.Alloc(onPlayerRemove);
            AltNative.Resource.CSharpResourceImpl_SetPlayerRemoveDelegate(NativePointer, onPlayerRemove);

            AltNative.Resource.VehicleRemoveDelegate onVehicleRemove = ModuleWrapper.OnVehicleRemove;
            GCHandle.Alloc(onVehicleRemove);
            AltNative.Resource.CSharpResourceImpl_SetVehicleRemoveDelegate(NativePointer, onVehicleRemove);

            AltNative.Resource.PlayerChangeVehicleSeatDelegate onPlayerChangeVehicleSeat = ModuleWrapper.OnPlayerChangeVehicleSeat;
            GCHandle.Alloc(onPlayerChangeVehicleSeat);
            AltNative.Resource.CSharpResourceImpl_SetPlayerChangeVehicleSeatDelegate(NativePointer, onPlayerChangeVehicleSeat);

            AltNative.Resource.PlayerEnterVehicleDelegate onPlayerEnterVehicle = ModuleWrapper.OnPlayerEnterVehicle;
            GCHandle.Alloc(onPlayerEnterVehicle);
            AltNative.Resource.CSharpResourceImpl_SetPlayerEnterVehicleDelegate(NativePointer, onPlayerEnterVehicle);

            AltNative.Resource.PlayerLeaveVehicleDelegate onPlayerLeaveVehicle = ModuleWrapper.OnPlayerLeaveVehicle;
            GCHandle.Alloc(onPlayerLeaveVehicle);
            AltNative.Resource.CSharpResourceImpl_SetPlayerLeaveVehicleDelegate(NativePointer, onPlayerLeaveVehicle);

            AltNative.Resource.CreatePlayerDelegate onCreatePlayer = ModuleWrapper.OnCreatePlayer;
            GCHandle.Alloc(onCreatePlayer);
            AltNative.Resource.CSharpResourceImpl_SetCreatePlayerDelegate(NativePointer, onCreatePlayer);

            AltNative.Resource.RemovePlayerDelegate onRemovePlayer = ModuleWrapper.OnRemovePlayer;
            GCHandle.Alloc(onRemovePlayer);
            AltNative.Resource.CSharpResourceImpl_SetRemovePlayerDelegate(NativePointer, onRemovePlayer);

            AltNative.Resource.CreateVehicleDelegate onCreateVehicle = ModuleWrapper.OnCreateVehicle;
            GCHandle.Alloc(onCreateVehicle);
            AltNative.Resource.CSharpResourceImpl_SetCreateVehicleDelegate(NativePointer, onCreateVehicle);

            AltNative.Resource.RemoveVehicleDelegate onRemoveVehicle = ModuleWrapper.OnRemoveVehicle;
            GCHandle.Alloc(onRemoveVehicle);
            AltNative.Resource.CSharpResourceImpl_SetRemoveVehicleDelegate(NativePointer, onRemoveVehicle);

            AltNative.Resource.CreateBlipDelegate onCreateBlip = ModuleWrapper.OnCreateBlip;
            GCHandle.Alloc(onCreateBlip);
            AltNative.Resource.CSharpResourceImpl_SetCreateBlipDelegate(NativePointer, onCreateBlip);

            AltNative.Resource.RemoveBlipDelegate onRemoveBlip = ModuleWrapper.OnRemoveBlip;
            GCHandle.Alloc(onRemoveBlip);
            AltNative.Resource.CSharpResourceImpl_SetRemoveBlipDelegate(NativePointer, onRemoveBlip);

            AltNative.Resource.CreateCheckpointDelegate onCreateCheckpoint = ModuleWrapper.OnCreateCheckpoint;
            GCHandle.Alloc(onCreateCheckpoint);
            AltNative.Resource.CSharpResourceImpl_SetCreateCheckpointDelegate(NativePointer, onCreateCheckpoint);

            AltNative.Resource.RemoveCheckpointDelegate onRemoveCheckpoint = ModuleWrapper.OnRemoveCheckpoint;
            GCHandle.Alloc(onRemoveCheckpoint);
            AltNative.Resource.CSharpResourceImpl_SetRemoveCheckpointDelegate(NativePointer, onRemoveCheckpoint);

            AltNative.Resource.CreateVoiceChannelDelegate onCreateVoiceChannel = ModuleWrapper.OnCreateVoiceChannel;
            GCHandle.Alloc(onCreateVoiceChannel);
            AltNative.Resource.CSharpResourceImpl_SetCreateVoiceChannelDelegate(NativePointer, onCreateVoiceChannel);

            AltNative.Resource.RemoveVoiceChannelDelegate onRemoveVoiceChannel = ModuleWrapper.OnRemoveVoiceChannel;
            GCHandle.Alloc(onRemoveVoiceChannel);
            AltNative.Resource.CSharpResourceImpl_SetRemoveVoiceChannelDelegate(NativePointer, onRemoveVoiceChannel);

            AltNative.Resource.ConsoleCommandDelegate onConsoleCommand = ModuleWrapper.OnConsoleCommand;
            GCHandle.Alloc(onConsoleCommand);
            AltNative.Resource.CSharpResourceImpl_SetConsoleCommandDelegate(NativePointer, onConsoleCommand);

            AltNative.Resource.MetaChangeDelegate onMetaDataChange = ModuleWrapper.OnMetaDataChange;
            GCHandle.Alloc(onMetaDataChange);
            AltNative.Resource.CSharpResourceImpl_SetMetaChangeDelegate(NativePointer, onMetaDataChange);

            AltNative.Resource.MetaChangeDelegate onSyncedMetaDataChange = ModuleWrapper.OnSyncedMetaDataChange;
            GCHandle.Alloc(onSyncedMetaDataChange);
            AltNative.Resource.CSharpResourceImpl_SetSyncedMetaChangeDelegate(NativePointer, onSyncedMetaDataChange);

            AltNative.Resource.CreateColShapeDelegate onCreateColShape = ModuleWrapper.OnCreateColShape;
            GCHandle.Alloc(onCreateColShape);
            AltNative.Resource.CSharpResourceImpl_SetCreateColShapeDelegate(NativePointer, onCreateColShape);

            AltNative.Resource.RemoveColShapeDelegate onRemoveColShape = ModuleWrapper.OnRemoveColShape;
            GCHandle.Alloc(onRemoveColShape);
            AltNative.Resource.CSharpResourceImpl_SetRemoveColShapeDelegate(NativePointer, onRemoveColShape);

            AltNative.Resource.ColShapeDelegate onColShape = ModuleWrapper.OnColShape;
            GCHandle.Alloc(onColShape);
            AltNative.Resource.CSharpResourceImpl_SetColShapeDelegate(NativePointer, onColShape);
        }
    }
}