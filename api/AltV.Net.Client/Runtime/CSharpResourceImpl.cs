using System.Runtime.InteropServices;
using AltV.Net.CApi;
using AltV.Net.CApi.ClientEvents;
using AltV.Net.Client.Events;
using AltV.Net.Shared;

namespace AltV.Net.Client.Runtime
{
    public class CSharpResourceImpl : SharedCSharpResourceImpl, IDisposable
    {
        private readonly LinkedList<GCHandle> handles = new();
        
        internal CSharpResourceImpl(ISharedCore core, IntPtr nativePointer) : base(core, nativePointer)
        {
            
        }

        internal void SetDelegates()
        {
            unsafe
            {
                TickModuleDelegate onTick = ModuleWrapper.OnTick;
                handles.AddFirst(GCHandle.Alloc(onTick));
                core.Library.Client.Event_SetTickDelegate(this.NativePointer, onTick);
                
                ServerEventModuleDelegate onServerEvent = ModuleWrapper.OnServerEvent;
                handles.AddFirst(GCHandle.Alloc(onServerEvent));
                core.Library.Client.Event_SetServerEventDelegate(this.NativePointer, onServerEvent);
                
                ClientEventModuleDelegate onClientEvent = ModuleWrapper.OnClientEvent;
                handles.AddFirst(GCHandle.Alloc(onClientEvent));
                core.Library.Client.Event_SetClientEventDelegate(this.NativePointer, onClientEvent);
                
                WebViewEventModuleDelegate onWebViewEvent = ModuleWrapper.OnWebViewEvent;
                handles.AddFirst(GCHandle.Alloc(onWebViewEvent));
                core.Library.Client.Event_SetWebViewEventDelegate(this.NativePointer, onWebViewEvent);
                
                ConsoleCommandModuleDelegate onConsoleCommand = ModuleWrapper.OnConsoleCommand;
                handles.AddFirst(GCHandle.Alloc(onConsoleCommand));
                core.Library.Client.Event_SetConsoleCommandDelegate(this.NativePointer, onConsoleCommand);
                
                CreatePlayerModuleDelegate onCreatePlayer = ModuleWrapper.OnCreatePlayer;
                handles.AddFirst(GCHandle.Alloc(onCreatePlayer));
                core.Library.Client.Event_SetCreatePlayerDelegate(this.NativePointer, onCreatePlayer);
                
                RemovePlayerModuleDelegate onRemovePlayer = ModuleWrapper.OnRemovePlayer;
                handles.AddFirst(GCHandle.Alloc(onRemovePlayer));
                core.Library.Client.Event_SetRemovePlayerDelegate(this.NativePointer, onRemovePlayer);
                
                CreateVehicleModuleDelegate onCreateVehicle = ModuleWrapper.OnCreateVehicle;
                handles.AddFirst(GCHandle.Alloc(onCreateVehicle));
                core.Library.Client.Event_SetCreateVehicleDelegate(this.NativePointer, onCreateVehicle);
                
                RemoveVehicleModuleDelegate onRemoveVehicle = ModuleWrapper.OnRemoveVehicle;
                handles.AddFirst(GCHandle.Alloc(onRemoveVehicle));
                core.Library.Client.Event_SetRemoveVehicleDelegate(this.NativePointer, onRemoveVehicle);
            
                PlayerSpawnModuleDelegate onPlayerSpawn = ModuleWrapper.OnPlayerSpawn;
                handles.AddFirst(GCHandle.Alloc(onPlayerSpawn));
                core.Library.Client.Event_SetPlayerSpawnDelegate(this.NativePointer, onPlayerSpawn);
                
                PlayerDisconnectModuleDelegate onPlayerDisconnect = ModuleWrapper.OnPlayerDisconnect;
                handles.AddFirst(GCHandle.Alloc(onPlayerDisconnect));
                core.Library.Client.Event_SetPlayerDisconnectDelegate(this.NativePointer, onPlayerDisconnect);
                
                PlayerEnterVehicleModuleDelegate onPlayerEnterVehicle = ModuleWrapper.OnPlayerEnterVehicle;
                handles.AddFirst(GCHandle.Alloc(onPlayerEnterVehicle));
                core.Library.Client.Event_SetPlayerEnterVehicleDelegate(this.NativePointer, onPlayerEnterVehicle);
                
                GameEntityCreateModuleDelegate onGameEntityCreate = ModuleWrapper.OnGameEntityCreate;
                handles.AddFirst(GCHandle.Alloc(onGameEntityCreate));
                core.Library.Client.Event_SetGameEntityCreateDelegate(this.NativePointer, onGameEntityCreate);
                
                GameEntityDestroyModuleDelegate onGameEntityDestroy = ModuleWrapper.OnGameEntityDestroy;
                handles.AddFirst(GCHandle.Alloc(onGameEntityDestroy));
                core.Library.Client.Event_SetGameEntityDestroyDelegate(this.NativePointer, onGameEntityDestroy);
                
                ResourceErrorModuleDelegate onResourceError = ModuleWrapper.OnResourceError;
                handles.AddFirst(GCHandle.Alloc(onResourceError));
                core.Library.Client.Event_SetResourceErrorDelegate(this.NativePointer, onResourceError);
                
                ResourceStartModuleDelegate onResourceStart = ModuleWrapper.OnResourceStart;
                handles.AddFirst(GCHandle.Alloc(onResourceStart));
                core.Library.Client.Event_SetResourceStartDelegate(this.NativePointer, onResourceStart);
                
                ResourceStopModuleDelegate onResourceStop = ModuleWrapper.OnResourceStop;
                handles.AddFirst(GCHandle.Alloc(onResourceStop));
                core.Library.Client.Event_SetResourceStopDelegate(this.NativePointer, onResourceStop);
                
                KeyDownModuleDelegate onKeyDown = ModuleWrapper.OnKeyDown;
                handles.AddFirst(GCHandle.Alloc(onKeyDown));
                core.Library.Client.Event_SetKeyDownDelegate(this.NativePointer, onKeyDown);
                
                KeyUpModuleDelegate onKeyUp = ModuleWrapper.OnKeyUp;
                handles.AddFirst(GCHandle.Alloc(onKeyUp));
                core.Library.Client.Event_SetKeyUpDelegate(this.NativePointer, onKeyUp);
                
                ConnectionCompleteModuleDelegate onConnectionComplete = ModuleWrapper.OnConnectionComplete;
                handles.AddFirst(GCHandle.Alloc(onConnectionComplete));
                core.Library.Client.Event_SetConnectionCompleteDelegate(this.NativePointer, onConnectionComplete);
                
                PlayerChangeVehicleSeatModuleDelegate onPlayerChangeVehicleSeat = ModuleWrapper.OnPlayerChangeVehicleSeat;
                handles.AddFirst(GCHandle.Alloc(onPlayerChangeVehicleSeat));
                core.Library.Client.Event_SetPlayerChangeVehicleSeatDelegate(this.NativePointer, onPlayerChangeVehicleSeat);
                
                GlobalMetaChangeModuleDelegate onGlobalMetaChange = ModuleWrapper.OnGlobalMetaChange;
                handles.AddFirst(GCHandle.Alloc(onGlobalMetaChange));
                core.Library.Client.Event_SetGlobalMetaChangeDelegate(this.NativePointer, onGlobalMetaChange);
                
                GlobalSyncedMetaChangeModuleDelegate onGlobalSyncedMetaChange = ModuleWrapper.OnGlobalSyncedMetaChange;
                handles.AddFirst(GCHandle.Alloc(onGlobalSyncedMetaChange));
                core.Library.Client.Event_SetGlobalSyncedMetaChangeDelegate(this.NativePointer, onGlobalSyncedMetaChange);
                
                LocalMetaChangeModuleDelegate onLocalMetaChange = ModuleWrapper.OnLocalMetaChange;
                handles.AddFirst(GCHandle.Alloc(onLocalMetaChange));
                core.Library.Client.Event_SetLocalMetaChangeDelegate(this.NativePointer, onLocalMetaChange);
                
                StreamSyncedMetaChangeModuleDelegate onStreamSyncedMetaChange = ModuleWrapper.OnStreamSyncedMetaChange;
                handles.AddFirst(GCHandle.Alloc(onStreamSyncedMetaChange));
                core.Library.Client.Event_SetStreamSyncedMetaChangeDelegate(this.NativePointer, onStreamSyncedMetaChange);
                
                SyncedMetaChangeModuleDelegate onSyncedMetaChange = ModuleWrapper.OnSyncedMetaChange;
                handles.AddFirst(GCHandle.Alloc(onSyncedMetaChange));
                core.Library.Client.Event_SetSyncedMetaChangeDelegate(this.NativePointer, onSyncedMetaChange);
                
                TaskChangeModuleDelegate onTaskChange = ModuleWrapper.OnTaskChange;
                handles.AddFirst(GCHandle.Alloc(onTaskChange));
                core.Library.Client.Event_SetTaskChangeDelegate(this.NativePointer, onTaskChange);
                
                WindowFocusChangeModuleDelegate onWindowFocusChange = ModuleWrapper.OnWindowFocusChange;
                handles.AddFirst(GCHandle.Alloc(onWindowFocusChange));
                core.Library.Client.Event_SetWindowFocusChangeDelegate(this.NativePointer, onWindowFocusChange);
                
                WindowResolutionChangeModuleDelegate onWindowResolutionChange = ModuleWrapper.OnWindowResolutionChange;
                handles.AddFirst(GCHandle.Alloc(onWindowResolutionChange));
                core.Library.Client.Event_SetWindowResolutionChangeDelegate(this.NativePointer, onWindowResolutionChange);
                
                NetOwnerChangeModuleDelegate onNetOwnerChange = ModuleWrapper.OnNetOwnerChange;
                handles.AddFirst(GCHandle.Alloc(onNetOwnerChange));
                core.Library.Client.Event_SetNetOwnerChangeDelegate(this.NativePointer, onNetOwnerChange);
                
                RemoveEntityModuleDelegate onRemoveEntity = ModuleWrapper.OnRemoveEntity;
                handles.AddFirst(GCHandle.Alloc(onRemoveEntity));
                core.Library.Client.Event_SetRemoveEntityDelegate(this.NativePointer, onRemoveEntity);
                
                PlayerLeaveVehicleModuleDelegate onPlayerLeaveVehicle = ModuleWrapper.OnPlayerLeaveVehicle;
                handles.AddFirst(GCHandle.Alloc(onPlayerLeaveVehicle));
                core.Library.Client.Event_SetPlayerLeaveVehicleDelegate(this.NativePointer, onPlayerLeaveVehicle);
                
            }
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