using System.Runtime.InteropServices;
using AltV.Net.Client.CApi;
using AltV.Net.Client.CApi.Events;
using AltV.Net.Client.Events;

namespace AltV.Net.Client.Runtime
{
    public class CSharpResourceImpl : IDisposable
    {
        private readonly ILibrary _library;

        internal readonly IntPtr NativePointer;
        
        private readonly LinkedList<GCHandle> _handles = new();
        
        internal CSharpResourceImpl(ILibrary library, IntPtr nativePointer)
        {
            this._library = library;
            NativePointer = nativePointer;
        }

        internal void SetDelegates()
        {
            unsafe
            {
                TickModuleDelegate onTick = ModuleWrapper.OnTick;
                _handles.AddFirst(GCHandle.Alloc(onTick));
                _library.Event_SetTickDelegate(this.NativePointer, onTick);
                
                ServerEventModuleDelegate onServerEvent = ModuleWrapper.OnServerEvent;
                _handles.AddFirst(GCHandle.Alloc(onServerEvent));
                _library.Event_SetServerEventDelegate(this.NativePointer, onServerEvent);
                
                ClientEventModuleDelegate onClientEvent = ModuleWrapper.OnClientEvent;
                _handles.AddFirst(GCHandle.Alloc(onClientEvent));
                _library.Event_SetClientEventDelegate(this.NativePointer, onClientEvent);
                
                ConsoleCommandModuleDelegate onConsoleCommand = ModuleWrapper.OnConsoleCommand;
                _handles.AddFirst(GCHandle.Alloc(onConsoleCommand));
                _library.Event_SetConsoleCommandDelegate(this.NativePointer, onConsoleCommand);
                
                CreatePlayerModuleDelegate onCreatePlayer = ModuleWrapper.OnCreatePlayer;
                _handles.AddFirst(GCHandle.Alloc(onCreatePlayer));
                _library.Event_SetCreatePlayerDelegate(this.NativePointer, onCreatePlayer);
                
                RemovePlayerModuleDelegate onRemovePlayer = ModuleWrapper.OnRemovePlayer;
                _handles.AddFirst(GCHandle.Alloc(onRemovePlayer));
                _library.Event_SetRemovePlayerDelegate(this.NativePointer, onRemovePlayer);
                
                CreateVehicleModuleDelegate onCreateVehicle = ModuleWrapper.OnCreateVehicle;
                _handles.AddFirst(GCHandle.Alloc(onCreateVehicle));
                _library.Event_SetCreateVehicleDelegate(this.NativePointer, onCreateVehicle);
                
                RemoveVehicleModuleDelegate onRemoveVehicle = ModuleWrapper.OnRemoveVehicle;
                _handles.AddFirst(GCHandle.Alloc(onRemoveVehicle));
                _library.Event_SetRemoveVehicleDelegate(this.NativePointer, onRemoveVehicle);

                PlayerSpawnModuleDelegate onPlayerSpawn = ModuleWrapper.OnPlayerSpawn;
                _handles.AddFirst(GCHandle.Alloc(onPlayerSpawn));
                _library.Event_SetPlayerSpawnDelegate(this.NativePointer, onPlayerSpawn);
                
                PlayerDisconnectModuleDelegate onPlayerDisconnect = ModuleWrapper.OnPlayerDisconnect;
                _handles.AddFirst(GCHandle.Alloc(onPlayerDisconnect));
                _library.Event_SetPlayerDisconnectDelegate(this.NativePointer, onPlayerDisconnect);
                
                PlayerEnterVehicleModuleDelegate onPlayerEnterVehicle = ModuleWrapper.OnPlayerEnterVehicle;
                _handles.AddFirst(GCHandle.Alloc(onPlayerEnterVehicle));
                _library.Event_SetPlayerEnterVehicleDelegate(this.NativePointer, onPlayerEnterVehicle);
                
                ResourceErrorModuleDelegate onResourceError = ModuleWrapper.OnResourceError;
                _handles.AddFirst(GCHandle.Alloc(onResourceError));
                _library.Event_SetResourceErrorDelegate(this.NativePointer, onResourceError);
                
                ResourceStartModuleDelegate onResourceStart = ModuleWrapper.OnResourceStart;
                _handles.AddFirst(GCHandle.Alloc(onResourceStart));
                _library.Event_SetResourceStartDelegate(this.NativePointer, onResourceStart);
                
                ResourceStopModuleDelegate onResourceStop = ModuleWrapper.OnResourceStop;
                _handles.AddFirst(GCHandle.Alloc(onResourceStop));
                _library.Event_SetResourceStopDelegate(this.NativePointer, onResourceStop);
                
                KeyDownModuleDelegate onKeyDown = ModuleWrapper.OnKeyDown;
                _handles.AddFirst(GCHandle.Alloc(onKeyDown));
                _library.Event_SetKeyDownDelegate(this.NativePointer, onKeyDown);
                
                KeyUpModuleDelegate onKeyUp = ModuleWrapper.OnKeyUp;
                _handles.AddFirst(GCHandle.Alloc(onKeyUp));
                _library.Event_SetKeyUpDelegate(this.NativePointer, onKeyUp);
            }
        }
        
        public void Dispose()
        {
            foreach (var handle in _handles)
            {
                handle.Free();
            }

            _handles.Clear();
        }
    }
}