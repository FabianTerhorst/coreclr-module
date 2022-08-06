using System.Runtime.InteropServices;
using AltV.Net.CApi.ClientEvents;
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

                RmlEventModuleDelegate onRmlElementEvent = ModuleWrapper.OnRmlElementEvent;
                handles.AddFirst(GCHandle.Alloc(onRmlElementEvent));
                core.Library.Client.Event_SetRmlEventDelegate(this.NativePointer, onRmlElementEvent);

                ConsoleCommandModuleDelegate onConsoleCommand = ModuleWrapper.OnConsoleCommand;
                handles.AddFirst(GCHandle.Alloc(onConsoleCommand));
                core.Library.Client.Event_SetConsoleCommandDelegate(this.NativePointer, onConsoleCommand);

                CreatePlayerModuleDelegate onCreatePlayer = ModuleWrapper.OnCreatePlayer;
                handles.AddFirst(GCHandle.Alloc(onCreatePlayer));
                core.Library.Client.Event_SetCreatePlayerDelegate(this.NativePointer, onCreatePlayer);

                RemovePlayerModuleDelegate onRemovePlayer = ModuleWrapper.OnRemovePlayer;
                handles.AddFirst(GCHandle.Alloc(onRemovePlayer));
                core.Library.Client.Event_SetRemovePlayerDelegate(this.NativePointer, onRemovePlayer);

                CreateObjectModuleDelegate onCreateObject = ModuleWrapper.OnCreateObject;
                handles.AddFirst(GCHandle.Alloc(onCreateObject));
                core.Library.Client.Event_SetCreateObjectDelegate(this.NativePointer, onCreateObject);

                RemoveObjectModuleDelegate onRemoveObject = ModuleWrapper.OnRemoveObject;
                handles.AddFirst(GCHandle.Alloc(onRemoveObject));
                core.Library.Client.Event_SetRemoveObjectDelegate(this.NativePointer, onRemoveObject);

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

                AnyResourceErrorModuleDelegate onAnyResourceError = ModuleWrapper.OnAnyResourceError;
                handles.AddFirst(GCHandle.Alloc(onAnyResourceError));
                core.Library.Client.Event_SetAnyResourceErrorDelegate(this.NativePointer, onAnyResourceError);

                AnyResourceStartModuleDelegate onAnyResourceStart = ModuleWrapper.OnAnyResourceStart;
                handles.AddFirst(GCHandle.Alloc(onAnyResourceStart));
                core.Library.Client.Event_SetAnyResourceStartDelegate(this.NativePointer, onAnyResourceStart);

                AnyResourceStopModuleDelegate onAnyResourceStop = ModuleWrapper.OnAnyResourceStop;
                handles.AddFirst(GCHandle.Alloc(onAnyResourceStop));
                core.Library.Client.Event_SetAnyResourceStopDelegate(this.NativePointer, onAnyResourceStop);

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

                CreateBlipModuleDelegate onCreateBlip = ModuleWrapper.OnBlipCreate;
                handles.AddFirst(GCHandle.Alloc(onCreateBlip));
                core.Library.Client.Event_SetCreateBlipDelegate(this.NativePointer, onCreateBlip);

                CreateWebViewModuleDelegate onCreateWebView = ModuleWrapper.OnWebViewCreate;
                handles.AddFirst(GCHandle.Alloc(onCreateWebView));
                core.Library.Client.Event_SetCreateWebViewDelegate(this.NativePointer, onCreateWebView);

                CreateCheckpointModuleDelegate onCreateCheckpoint = ModuleWrapper.OnCheckpointCreate;
                handles.AddFirst(GCHandle.Alloc(onCreateCheckpoint));
                core.Library.Client.Event_SetCreateCheckpointDelegate(this.NativePointer, onCreateCheckpoint);

                CreateWebSocketClientModuleDelegate onCreateWebSocketClient = ModuleWrapper.OnWebSocketClientCreate;
                handles.AddFirst(GCHandle.Alloc(onCreateWebSocketClient));
                core.Library.Client.Event_SetCreateWebSocketClientDelegate(this.NativePointer, onCreateWebSocketClient);

                CreateHttpClientModuleDelegate onCreateHttpClient = ModuleWrapper.OnHttpClientCreate;
                handles.AddFirst(GCHandle.Alloc(onCreateHttpClient));
                core.Library.Client.Event_SetCreateHttpClientDelegate(this.NativePointer, onCreateHttpClient);

                CreateAudioModuleDelegate onCreateAudio = ModuleWrapper.OnAudioCreate;
                handles.AddFirst(GCHandle.Alloc(onCreateAudio));
                core.Library.Client.Event_SetCreateAudioDelegate(this.NativePointer, onCreateAudio);

                CreateRmlElementModuleDelegate onCreateRmlElement = ModuleWrapper.OnRmlElementCreate;
                handles.AddFirst(GCHandle.Alloc(onCreateRmlElement));
                core.Library.Client.Event_SetCreateRmlElementDelegate(this.NativePointer, onCreateRmlElement);

                CreateRmlDocumentModuleDelegate onCreateRmlDocument = ModuleWrapper.OnRmlDocumentCreate;
                handles.AddFirst(GCHandle.Alloc(onCreateRmlDocument));
                core.Library.Client.Event_SetCreateRmlDocumentDelegate(this.NativePointer, onCreateRmlDocument);

                RemoveBlipModuleDelegate onRemoveBlip = ModuleWrapper.OnBlipRemove;
                handles.AddFirst(GCHandle.Alloc(onRemoveBlip));
                core.Library.Client.Event_SetRemoveBlipDelegate(this.NativePointer, onRemoveBlip);

                RemoveWebViewModuleDelegate onRemoveWebView = ModuleWrapper.OnWebViewRemove;
                handles.AddFirst(GCHandle.Alloc(onRemoveWebView));
                core.Library.Client.Event_SetRemoveWebViewDelegate(this.NativePointer, onRemoveWebView);

                RemoveCheckpointModuleDelegate onRemoveCheckpoint = ModuleWrapper.OnCheckpointRemove;
                handles.AddFirst(GCHandle.Alloc(onRemoveCheckpoint));
                core.Library.Client.Event_SetRemoveCheckpointDelegate(this.NativePointer, onRemoveCheckpoint);

                RemoveWebSocketClientModuleDelegate onRemoveWebSocketClient = ModuleWrapper.OnWebSocketClientRemove;
                handles.AddFirst(GCHandle.Alloc(onRemoveWebSocketClient));
                core.Library.Client.Event_SetRemoveWebSocketClientDelegate(this.NativePointer, onRemoveWebSocketClient);

                RemoveHttpClientModuleDelegate onRemoveHttpClient = ModuleWrapper.OnHttpClientRemove;
                handles.AddFirst(GCHandle.Alloc(onRemoveHttpClient));
                core.Library.Client.Event_SetRemoveHttpClientDelegate(this.NativePointer, onRemoveHttpClient);

                RemoveAudioModuleDelegate onRemoveAudio = ModuleWrapper.OnAudioRemove;
                handles.AddFirst(GCHandle.Alloc(onRemoveAudio));
                core.Library.Client.Event_SetRemoveAudioDelegate(this.NativePointer, onRemoveAudio);

                RemoveRmlElementModuleDelegate onRemoveRmlElement = ModuleWrapper.OnRmlElementRemove;
                handles.AddFirst(GCHandle.Alloc(onRemoveRmlElement));
                core.Library.Client.Event_SetRemoveRmlElementDelegate(this.NativePointer, onRemoveRmlElement);

                RemoveRmlDocumentModuleDelegate onRemoveRmlDocument = ModuleWrapper.OnRmlDocumentRemove;
                handles.AddFirst(GCHandle.Alloc(onRemoveRmlDocument));
                core.Library.Client.Event_SetRemoveRmlDocumentDelegate(this.NativePointer, onRemoveRmlDocument);

                PlayerChangeAnimationModuleDelegate onPlayerChangeAnimation = ModuleWrapper.OnPlayerChangeAnimation;
                handles.AddFirst(GCHandle.Alloc(onPlayerChangeAnimation));
                core.Library.Client.Event_SetPlayerChangeAnimationDelegate(this.NativePointer, onPlayerChangeAnimation);

                PlayerChangeInteriorModuleDelegate onPlayerChangeInterior = ModuleWrapper.OnPlayerChangeInterior;
                handles.AddFirst(GCHandle.Alloc(onPlayerChangeInterior));
                core.Library.Client.Event_SetPlayerChangeInteriorDelegate(this.NativePointer, onPlayerChangeInterior);
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