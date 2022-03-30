using System.Runtime.InteropServices;
using AltV.Net.CApi;
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