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

                WebSocketEventModuleDelegate onWebSocketEvent = ModuleWrapper.OnWebSocketEvent;
                handles.AddFirst(GCHandle.Alloc(onWebSocketEvent));
                core.Library.Client.Event_SetWebSocketEventDelegate(this.NativePointer, onWebSocketEvent);

                RmlEventModuleDelegate onRmlElementEvent = ModuleWrapper.OnRmlElementEvent;
                handles.AddFirst(GCHandle.Alloc(onRmlElementEvent));
                core.Library.Client.Event_SetRmlEventDelegate(this.NativePointer, onRmlElementEvent);

                ConsoleCommandModuleDelegate onConsoleCommand = ModuleWrapper.OnConsoleCommand;
                handles.AddFirst(GCHandle.Alloc(onConsoleCommand));
                core.Library.Client.Event_SetConsoleCommandDelegate(this.NativePointer, onConsoleCommand);

                CreateBaseObjectModuleDelegate onCreateBaseObject = ModuleWrapper.OnCreateBaseObject;
                handles.AddFirst(GCHandle.Alloc(onCreateBaseObject));
                core.Library.Client.Event_SetCreateBaseObjectDelegate (this.NativePointer, onCreateBaseObject);

                RemoveBaseObjectModuleDelegate onRemoveBaseObject = ModuleWrapper.OnRemoveBaseObject;
                handles.AddFirst(GCHandle.Alloc(onRemoveBaseObject));
                core.Library.Client.Event_SetRemoveBaseObjectDelegate(this.NativePointer, onRemoveBaseObject);

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

                PlayerLeaveVehicleModuleDelegate onPlayerLeaveVehicle = ModuleWrapper.OnPlayerLeaveVehicle;
                handles.AddFirst(GCHandle.Alloc(onPlayerLeaveVehicle));
                core.Library.Client.Event_SetPlayerLeaveVehicleDelegate(this.NativePointer, onPlayerLeaveVehicle);

                PlayerChangeAnimationModuleDelegate onPlayerChangeAnimation = ModuleWrapper.OnPlayerChangeAnimation;
                handles.AddFirst(GCHandle.Alloc(onPlayerChangeAnimation));
                core.Library.Client.Event_SetPlayerChangeAnimationDelegate(this.NativePointer, onPlayerChangeAnimation);

                PlayerChangeInteriorModuleDelegate onPlayerChangeInterior = ModuleWrapper.OnPlayerChangeInterior;
                handles.AddFirst(GCHandle.Alloc(onPlayerChangeInterior));
                core.Library.Client.Event_SetPlayerChangeInteriorDelegate(this.NativePointer, onPlayerChangeInterior);

                PlayerWeaponShootModuleDelegate onPlayerWeaponShoot = ModuleWrapper.OnPlayerWeaponShoot;
                handles.AddFirst(GCHandle.Alloc(onPlayerWeaponShoot));
                core.Library.Client.Event_SetPlayerWeaponShootDelegate(this.NativePointer, onPlayerWeaponShoot);

                PlayerWeaponChangeModuleDelegate onPlayerWeaponChange = ModuleWrapper.OnPlayerWeaponChange;
                handles.AddFirst(GCHandle.Alloc(onPlayerWeaponChange));
                core.Library.Client.Event_SetPlayerWeaponChangeDelegate(this.NativePointer, onPlayerWeaponChange);

                WeaponDamageModuleDelegate onWeaponDamage = ModuleWrapper.OnWeaponDamage;
                handles.AddFirst(GCHandle.Alloc(onWeaponDamage));
                core.Library.Client.Event_SetWeaponDamageDelegate(this.NativePointer, onWeaponDamage);

                WorldObjectPositionChangeModuleDelegate onWorldObjectPositionChange = ModuleWrapper.OnWorldObjectPositionChange;
                handles.AddFirst(GCHandle.Alloc(onWorldObjectPositionChange));
                core.Library.Client.Event_SetWorldObjectPositionChangeDelegate(this.NativePointer, onWorldObjectPositionChange);

                WorldObjectStreamInModuleDelegate onWorldObjectStreamIn = ModuleWrapper.OnWorldObjectStreamIn;
                handles.AddFirst(GCHandle.Alloc(onWorldObjectStreamIn));
                core.Library.Client.Event_SetWorldObjectStreamInDelegate(this.NativePointer, onWorldObjectStreamIn);

                WorldObjectStreamOutModuleDelegate onWorldObjectStreamOut = ModuleWrapper.OnWorldObjectStreamOut;
                handles.AddFirst(GCHandle.Alloc(onWorldObjectStreamOut));
                core.Library.Client.Event_SetWorldObjectStreamOutDelegate(this.NativePointer, onWorldObjectStreamOut);

                ColShapeModuleDelegate onColShape = ModuleWrapper.OnColShape;
                handles.AddFirst(GCHandle.Alloc(onColShape));
                core.Library.Client.Event_SetColShapeDelegate(this.NativePointer, onColShape);

                CheckpointModuleDelegate onCheckpoint = ModuleWrapper.OnCheckpoint;
                handles.AddFirst(GCHandle.Alloc(onCheckpoint));
                core.Library.Client.Event_SetCheckpointDelegate(this.NativePointer, onCheckpoint);

                MetaChangeModuleDelegate onMetaChange = ModuleWrapper.OnMetaChange;
                handles.AddFirst(GCHandle.Alloc(onMetaChange));
                core.Library.Client.Event_SetMetaChangeDelegate(this.NativePointer, onMetaChange);

                EntityHitEntityModuleDelegate onEntityHitEntity = ModuleWrapper.OnEntityHitEntity;
                handles.AddFirst(GCHandle.Alloc(onEntityHitEntity));
                core.Library.Client.Event_SetEntityHitEntityDelegate(this.NativePointer, onEntityHitEntity);

                PlayerStartEnterVehicleModuleDelegate onPlayerStartEnterVehicle = ModuleWrapper.OnPlayerStartEnterVehicle;
                handles.AddFirst(GCHandle.Alloc(onPlayerStartEnterVehicle));
                core.Library.Client.Event_SetPlayerStartEnterVehicleDelegate(this.NativePointer, onPlayerStartEnterVehicle);

                PlayerStartLeaveVehicleModuleDelegate onPlayerStartLeaveVehicle = ModuleWrapper.OnPlayerStartLeaveVehicle;
                handles.AddFirst(GCHandle.Alloc(onPlayerStartLeaveVehicle));
                core.Library.Client.Event_SetPlayerStartLeaveVehicleDelegate(this.NativePointer, onPlayerStartLeaveVehicle);
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