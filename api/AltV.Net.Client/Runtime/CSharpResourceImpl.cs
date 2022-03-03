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
            Alt.Log($"Set delegates! Pointer was: {this.NativePointer}");
            
            unsafe
            {
                TickDelegate onTick = ModuleWrapper.OnTick;
                _handles.AddFirst(GCHandle.Alloc(onTick));
                _library.Event_SetTickDelegate(this.NativePointer, onTick);
                
                ServerEventDelegate onServerEvent = ModuleWrapper.OnServerEvent;
                _handles.AddFirst(GCHandle.Alloc(onServerEvent));
                _library.Event_SetServerEventDelegate(this.NativePointer, onServerEvent);
                
                CreatePlayerDelegate onCreatePlayer = ModuleWrapper.OnCreatePlayer;
                _handles.AddFirst(GCHandle.Alloc(onCreatePlayer));
                _library.Event_SetCreatePlayerDelegate(this.NativePointer, onCreatePlayer);
                
                RemovePlayerDelegate onRemovePlayer = ModuleWrapper.OnRemovePlayer;
                _handles.AddFirst(GCHandle.Alloc(onRemovePlayer));
                _library.Event_SetRemovePlayerDelegate(this.NativePointer, onRemovePlayer);
                
                CreateVehicleDelegate onCreateVehicle = ModuleWrapper.OnCreateVehicle;
                _handles.AddFirst(GCHandle.Alloc(onCreateVehicle));
                _library.Event_SetCreateVehicleDelegate(this.NativePointer, onCreateVehicle);
                
                RemoveVehicleDelegate onRemoveVehicle = ModuleWrapper.OnRemoveVehicle;
                _handles.AddFirst(GCHandle.Alloc(onRemoveVehicle));
                _library.Event_SetRemoveVehicleDelegate(this.NativePointer, onRemoveVehicle);
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