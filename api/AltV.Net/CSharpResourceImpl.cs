using System;
using AltV.Net.Native;

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

        internal void SetDelegates(AltNative.Resource.MainDelegate onStartResource)
        {
            AltNative.Resource.CSharpResourceImpl_SetMainDelegate(NativePointer,
                onStartResource);
            AltNative.Resource.CSharpResourceImpl_SetStopDelegate(NativePointer, ModuleWrapper.OnStop);
            AltNative.Resource.CSharpResourceImpl_SetTickDelegate(NativePointer, ModuleWrapper.OnTick);
            AltNative.Resource.CSharpResourceImpl_SetServerEventDelegate(NativePointer, ModuleWrapper.OnServerEvent);
            AltNative.Resource.CSharpResourceImpl_SetCheckpointDelegate(NativePointer, ModuleWrapper.OnCheckpoint);
            AltNative.Resource.CSharpResourceImpl_SetClientEventDelegate(NativePointer, ModuleWrapper.OnClientEvent);
            AltNative.Resource.CSharpResourceImpl_SetPlayerDamageDelegate(NativePointer,
                ModuleWrapper.OnPlayerDamage);
            AltNative.Resource.CSharpResourceImpl_SetPlayerConnectDelegate(NativePointer,
                ModuleWrapper.OnPlayerConnect);
            AltNative.Resource.CSharpResourceImpl_SetPlayerDeathDelegate(NativePointer,
                ModuleWrapper.OnPlayerDeath);
            AltNative.Resource.CSharpResourceImpl_SetExplosionDelegate(NativePointer,
                ModuleWrapper.OnExplosion);
            AltNative.Resource.CSharpResourceImpl_SetWeaponDamageDelegate(NativePointer,
                ModuleWrapper.OnWeaponDamage);
            AltNative.Resource.CSharpResourceImpl_SetPlayerDisconnectDelegate(NativePointer,
                ModuleWrapper.OnPlayerDisconnect);
            AltNative.Resource.CSharpResourceImpl_SetPlayerRemoveDelegate(NativePointer,
                ModuleWrapper.OnPlayerRemove);
            AltNative.Resource.CSharpResourceImpl_SetVehicleRemoveDelegate(NativePointer,
                ModuleWrapper.OnVehicleRemove);
            AltNative.Resource.CSharpResourceImpl_SetPlayerChangeVehicleSeatDelegate(NativePointer,
                ModuleWrapper.OnPlayerChangeVehicleSeat);
            AltNative.Resource.CSharpResourceImpl_SetPlayerEnterVehicleDelegate(NativePointer,
                ModuleWrapper.OnPlayerEnterVehicle);
            AltNative.Resource.CSharpResourceImpl_SetPlayerLeaveVehicleDelegate(NativePointer,
                ModuleWrapper.OnPlayerLeaveVehicle);
            AltNative.Resource.CSharpResourceImpl_SetCreatePlayerDelegate(NativePointer,
                ModuleWrapper.OnCreatePlayer);
            AltNative.Resource.CSharpResourceImpl_SetRemovePlayerDelegate(NativePointer,
                ModuleWrapper.OnRemovePlayer);
            AltNative.Resource.CSharpResourceImpl_SetCreateVehicleDelegate(NativePointer,
                ModuleWrapper.OnCreateVehicle);
            AltNative.Resource.CSharpResourceImpl_SetRemoveVehicleDelegate(NativePointer,
                ModuleWrapper.OnRemoveVehicle);
            AltNative.Resource.CSharpResourceImpl_SetCreateBlipDelegate(NativePointer, ModuleWrapper.OnCreateBlip);
            AltNative.Resource.CSharpResourceImpl_SetRemoveBlipDelegate(NativePointer, ModuleWrapper.OnRemoveBlip);
            AltNative.Resource.CSharpResourceImpl_SetCreateCheckpointDelegate(NativePointer,
                ModuleWrapper.OnCreateCheckpoint);
            AltNative.Resource.CSharpResourceImpl_SetRemoveCheckpointDelegate(NativePointer,
                ModuleWrapper.OnRemoveCheckpoint);
            AltNative.Resource.CSharpResourceImpl_SetCreateVoiceChannelDelegate(NativePointer,
                ModuleWrapper.OnCreateVoiceChannel);
            AltNative.Resource.CSharpResourceImpl_SetRemoveVoiceChannelDelegate(NativePointer,
                ModuleWrapper.OnRemoveVoiceChannel);
            AltNative.Resource.CSharpResourceImpl_SetConsoleCommandDelegate(NativePointer,
                ModuleWrapper.OnConsoleCommand);
            AltNative.Resource.CSharpResourceImpl_SetMetaChangeDelegate(NativePointer, ModuleWrapper.OnMetaDataChange);
            AltNative.Resource.CSharpResourceImpl_SetSyncedMetaChangeDelegate(NativePointer,
                ModuleWrapper.OnSyncedMetaDataChange);
            AltNative.Resource.CSharpResourceImpl_SetCreateColShapeDelegate(NativePointer,
                ModuleWrapper.OnCreateColShape);
            AltNative.Resource.CSharpResourceImpl_SetRemoveColShapeDelegate(NativePointer,
                ModuleWrapper.OnRemoveColShape);
            AltNative.Resource.CSharpResourceImpl_SetColShapeDelegate(NativePointer, ModuleWrapper.OnColShape);
        }
    }
}