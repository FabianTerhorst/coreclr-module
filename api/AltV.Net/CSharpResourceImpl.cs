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
            AltNative.Resource.CSharpResource_Reload(NativePointer);
        }

        public void Load()
        {
            AltNative.Resource.CSharpResource_Load(NativePointer);
        }

        public void Unload()
        {
            AltNative.Resource.CSharpResource_Unload(NativePointer);
        }

        internal void SetDelegates(AltNative.Resource.MainDelegate onStartResource)
        {
            AltNative.Resource.CSharpResource_SetMain(NativePointer,
                onStartResource,
                ModuleWrapper.OnStop,
                ModuleWrapper.OnTick,
                ModuleWrapper.OnServerEvent,
                ModuleWrapper.OnCheckpoint,
                ModuleWrapper.OnClientEvent,
                ModuleWrapper.OnPlayerDamage,
                ModuleWrapper.OnPlayerConnect,
                ModuleWrapper.OnPlayerDeath,
                ModuleWrapper.OnExplosion,
                ModuleWrapper.OnWeaponDamage,
                ModuleWrapper.OnPlayerDisconnect,
                ModuleWrapper.OnPlayerRemove,
                ModuleWrapper.OnVehicleRemove,
                ModuleWrapper.OnPlayerChangeVehicleSeat,
                ModuleWrapper.OnPlayerEnterVehicle,
                ModuleWrapper.OnPlayerLeaveVehicle,
                ModuleWrapper.OnCreatePlayer,
                ModuleWrapper.OnRemovePlayer,
                ModuleWrapper.OnCreateVehicle,
                ModuleWrapper.OnRemoveVehicle,
                ModuleWrapper.OnCreateBlip,
                ModuleWrapper.OnRemoveBlip,
                ModuleWrapper.OnCreateCheckpoint,
                ModuleWrapper.OnRemoveCheckpoint,
                ModuleWrapper.OnCreateVoiceChannel,
                ModuleWrapper.OnRemoveVoiceChannel,
                ModuleWrapper.OnConsoleCommand,
                ModuleWrapper.OnMetaDataChange,
                ModuleWrapper.OnSyncedMetaDataChange,
                ModuleWrapper.OnCreateColShape,
                ModuleWrapper.OnRemoveColShape,
                ModuleWrapper.OnColShape);
        }
    }
}