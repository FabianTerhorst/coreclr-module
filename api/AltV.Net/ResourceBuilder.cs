using System;
using System.Runtime.InteropServices;
using AltV.Net.Native;

namespace AltV.Net
{
    public class ResourceBuilder
    {
        private readonly string[] args;

        private readonly IResource resource;

        public ResourceBuilder(string[] args, IResource resource)
        {
            this.args = args;
            this.resource = resource;
        }

        public void Start()
        {
            var indexChar = args[0].ToCharArray()[0];
            var resourceIndex = indexChar - '0';
            var serverPointer = AltNative.Resource.CSharpResource_GetServerPointer();
            var resourcePointer = AltNative.Resource.CSharpResource_GetResourcePointer(resourceIndex);

            ModuleWrapper.MainWithResource(serverPointer, resourcePointer, resource);

            AltNative.Resource.MainDelegate onStart = OnStart;

            GCHandle.Alloc(onStart);

            AltNative.Resource.TickDelegate onTick = ModuleWrapper.OnTick;

            GCHandle.Alloc(onTick);

            AltNative.Resource.ServerEventDelegate onServerEvent = ModuleWrapper.OnServerEvent;

            GCHandle.Alloc(onServerEvent);

            AltNative.Resource.CheckpointDelegate onCheckpoint = ModuleWrapper.OnCheckpoint;

            GCHandle.Alloc(onCheckpoint);

            AltNative.Resource.ClientEventDelegate onClientEvent = ModuleWrapper.OnClientEvent;

            GCHandle.Alloc(onClientEvent);

            AltNative.Resource.PlayerDamageDelegate onPlayerDamage = ModuleWrapper.OnPlayerDamage;

            GCHandle.Alloc(onPlayerDamage);

            AltNative.Resource.PlayerConnectDelegate onPlayerConnect = ModuleWrapper.OnPlayerConnect;

            GCHandle.Alloc(onPlayerConnect);

            AltNative.Resource.PlayerDeathDelegate onPlayerDeath = ModuleWrapper.OnPlayerDeath;

            GCHandle.Alloc(onPlayerDeath);

            AltNative.Resource.PlayerDisconnectDelegate onPlayerDisconnect = ModuleWrapper.OnPlayerDisconnect;

            GCHandle.Alloc(onPlayerDisconnect);

            AltNative.Resource.PlayerRemoveDelegate onPlayerRemove = ModuleWrapper.OnPlayerRemove;

            GCHandle.Alloc(onPlayerRemove);

            AltNative.Resource.VehicleRemoveDelegate onVehicleRemove = ModuleWrapper.OnVehicleRemove;

            GCHandle.Alloc(onVehicleRemove);

            AltNative.Resource.PlayerChangeVehicleSeatDelegate onPlayerChangeVehicleSeat =
                ModuleWrapper.OnPlayerChangeVehicleSeat;

            GCHandle.Alloc(onPlayerChangeVehicleSeat);

            AltNative.Resource.PlayerEnterVehicleDelegate onPlayerEnterVehicle = ModuleWrapper.OnPlayerEnterVehicle;

            GCHandle.Alloc(onPlayerEnterVehicle);

            AltNative.Resource.PlayerLeaveVehicleDelegate onPlayerLeaveVehicle = ModuleWrapper.OnPlayerLeaveVehicle;

            GCHandle.Alloc(onPlayerLeaveVehicle);

            AltNative.Resource.CreatePlayerDelegate onCreatePlayer = ModuleWrapper.OnCreatePlayer;

            GCHandle.Alloc(onCreatePlayer);

            AltNative.Resource.RemovePlayerDelegate onRemovePlayer = ModuleWrapper.OnRemovePlayer;

            GCHandle.Alloc(onRemovePlayer);

            AltNative.Resource.CreateVehicleDelegate onCreateVehicle = ModuleWrapper.OnCreateVehicle;

            GCHandle.Alloc(onCreateVehicle);

            AltNative.Resource.RemoveVehicleDelegate onRemoveVehicle = ModuleWrapper.OnRemoveVehicle;

            GCHandle.Alloc(onRemoveVehicle);

            AltNative.Resource.CreateBlipDelegate onCreateBlip = ModuleWrapper.OnCreateBlip;

            GCHandle.Alloc(onCreateBlip);

            AltNative.Resource.RemoveBlipDelegate onRemoveBlip = ModuleWrapper.OnRemoveBlip;

            GCHandle.Alloc(onRemoveBlip);

            AltNative.Resource.CreateCheckpointDelegate onCreateCheckpoint = ModuleWrapper.OnCreateCheckpoint;

            GCHandle.Alloc(onCreateCheckpoint);

            AltNative.Resource.RemoveCheckpointDelegate onRemoveCheckpoint = ModuleWrapper.OnRemoveCheckpoint;

            GCHandle.Alloc(onRemoveCheckpoint);

            AltNative.Resource.CreateVoiceChannelDelegate onCreateVoiceChannel = ModuleWrapper.OnCreateVoiceChannel;

            GCHandle.Alloc(onCreateVoiceChannel);

            AltNative.Resource.RemoveVoiceChannelDelegate onRemoveVoiceChannel = ModuleWrapper.OnRemoveVoiceChannel;

            GCHandle.Alloc(onRemoveVoiceChannel);

            AltNative.Resource.ConsoleCommandDelegate onConsoleCommand = ModuleWrapper.OnConsoleCommand;

            GCHandle.Alloc(onConsoleCommand);

            AltNative.Resource.MetaDataChange onMetaDataChange = ModuleWrapper.OnMetaDataChange;

            GCHandle.Alloc(onMetaDataChange);

            AltNative.Resource.MetaDataChange onSyncedMetaDataChange = ModuleWrapper.OnSyncedMetaDataChange;

            GCHandle.Alloc(onSyncedMetaDataChange);

            AltNative.Resource.CreateColShapeDelegate onCreateColShape = ModuleWrapper.OnCreateColShape;

            GCHandle.Alloc(onCreateColShape);

            AltNative.Resource.RemoveColShapeDelegate onRemoveColShape = ModuleWrapper.OnRemoveColShape;

            GCHandle.Alloc(onRemoveColShape);

            AltNative.Resource.ColShapeDelegate onColShape = ModuleWrapper.OnColShape;

            GCHandle.Alloc(onColShape);

            AltNative.Resource.CSharpResource_SetMain(resourcePointer, onStart, onTick, onServerEvent, onCheckpoint,
                onClientEvent, onPlayerDamage, onPlayerConnect, onPlayerDeath, onPlayerDisconnect, onPlayerRemove,
                onVehicleRemove,
                onPlayerChangeVehicleSeat, onPlayerEnterVehicle, onPlayerLeaveVehicle, onCreatePlayer, onRemovePlayer,
                onCreateVehicle, onRemoveVehicle,
                onCreateBlip, onRemoveBlip, onCreateCheckpoint, onRemoveCheckpoint, onCreateVoiceChannel,
                onRemoveVoiceChannel, onConsoleCommand, onMetaDataChange, onSyncedMetaDataChange, onCreateColShape,
                onRemoveColShape, onColShape);
        }

        private void OnStart(IntPtr pointer, IntPtr ptr, string name, string point)
        {
            resource.OnStart();
        }
    }
}