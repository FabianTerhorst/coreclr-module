using AltV.Net.Data;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.CApi.Libraries
{
    public unsafe interface IClientLibrary
    {
        public delegate* unmanaged[Cdecl]<nint, int> Entity_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ClientEventModuleDelegate, void> Event_SetClientEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ConsoleCommandModuleDelegate, void> Event_SetConsoleCommandDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreatePlayerModuleDelegate, void> Event_SetCreatePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateVehicleModuleDelegate, void> Event_SetCreateVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void> Event_SetKeyDownDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void> Event_SetKeyUpDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerDisconnectModuleDelegate, void> Event_SetPlayerDisconnectDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerEnterVehicleModuleDelegate, void> Event_SetPlayerEnterVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerSpawnModuleDelegate, void> Event_SetPlayerSpawnDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemovePlayerModuleDelegate, void> Event_SetRemovePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveVehicleModuleDelegate, void> Event_SetRemoveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceErrorModuleDelegate, void> Event_SetResourceErrorDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceStartModuleDelegate, void> Event_SetResourceStartDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceStopModuleDelegate, void> Event_SetResourceStopDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ServerEventModuleDelegate, void> Event_SetServerEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.TickModuleDelegate, void> Event_SetTickDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetCurrentAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint> Player_GetLocal { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMicLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsTalking { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetRPM { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSeatCount { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_GetSpeedVector { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetWheelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetMaxGear { get; }
    }

    public unsafe class ClientLibrary : IClientLibrary
    {
        public delegate* unmanaged[Cdecl]<nint, int> Entity_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ClientEventModuleDelegate, void> Event_SetClientEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ConsoleCommandModuleDelegate, void> Event_SetConsoleCommandDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreatePlayerModuleDelegate, void> Event_SetCreatePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateVehicleModuleDelegate, void> Event_SetCreateVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void> Event_SetKeyDownDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void> Event_SetKeyUpDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerDisconnectModuleDelegate, void> Event_SetPlayerDisconnectDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerEnterVehicleModuleDelegate, void> Event_SetPlayerEnterVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerSpawnModuleDelegate, void> Event_SetPlayerSpawnDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemovePlayerModuleDelegate, void> Event_SetRemovePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveVehicleModuleDelegate, void> Event_SetRemoveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceErrorModuleDelegate, void> Event_SetResourceErrorDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceStartModuleDelegate, void> Event_SetResourceStartDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceStopModuleDelegate, void> Event_SetResourceStopDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ServerEventModuleDelegate, void> Event_SetServerEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.TickModuleDelegate, void> Event_SetTickDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetCurrentAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint> Player_GetLocal { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMicLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsTalking { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetRPM { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSeatCount { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_GetSpeedVector { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetWheelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetMaxGear { get; }
        public ClientLibrary(string dllName)
        {
            const DllImportSearchPath dllImportSearchPath = DllImportSearchPath.LegacyBehavior | DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories | DllImportSearchPath.System32 | DllImportSearchPath.UserDirectories | DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UseDllDirectoryForDependencies;
            var handle = NativeLibrary.Load(dllName, Assembly.GetExecutingAssembly(), dllImportSearchPath);
            Entity_GetScriptID = (delegate* unmanaged[Cdecl]<nint, int>) NativeLibrary.GetExport(handle, "Entity_GetScriptID");
            Event_SetClientEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ClientEventModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetClientEventDelegate");
            Event_SetConsoleCommandDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ConsoleCommandModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetConsoleCommandDelegate");
            Event_SetCreatePlayerDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreatePlayerModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetCreatePlayerDelegate");
            Event_SetCreateVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateVehicleModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetCreateVehicleDelegate");
            Event_SetKeyDownDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetKeyDownDelegate");
            Event_SetKeyUpDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetKeyUpDelegate");
            Event_SetPlayerDisconnectDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerDisconnectModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetPlayerDisconnectDelegate");
            Event_SetPlayerEnterVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerEnterVehicleModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetPlayerEnterVehicleDelegate");
            Event_SetPlayerSpawnDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerSpawnModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetPlayerSpawnDelegate");
            Event_SetRemovePlayerDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemovePlayerModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetRemovePlayerDelegate");
            Event_SetRemoveVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveVehicleModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetRemoveVehicleDelegate");
            Event_SetResourceErrorDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceErrorModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetResourceErrorDelegate");
            Event_SetResourceStartDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceStartModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetResourceStartDelegate");
            Event_SetResourceStopDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceStopModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetResourceStopDelegate");
            Event_SetServerEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ServerEventModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetServerEventDelegate");
            Event_SetTickDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.TickModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetTickDelegate");
            LocalPlayer_GetCurrentAmmo = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "LocalPlayer_GetCurrentAmmo");
            LocalPlayer_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "LocalPlayer_GetID");
            LocalPlayer_GetPlayer = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "LocalPlayer_GetPlayer");
            Player_GetLocal = (delegate* unmanaged[Cdecl]<nint>) NativeLibrary.GetExport(handle, "Player_GetLocal");
            Player_GetMicLevel = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetMicLevel");
            Player_GetNonSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetNonSpatialVolume");
            Player_GetSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetSpatialVolume");
            Player_IsTalking = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsTalking");
            Player_SetNonSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Player_SetNonSpatialVolume");
            Player_SetSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Player_SetSpatialVolume");
            Vehicle_GetGear = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Vehicle_GetGear");
            Vehicle_GetIndicatorLights = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetIndicatorLights");
            Vehicle_GetMaxGear = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Vehicle_GetMaxGear");
            Vehicle_GetRPM = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_GetRPM");
            Vehicle_GetSeatCount = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetSeatCount");
            Vehicle_GetSpeedVector = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Vehicle_GetSpeedVector");
            Vehicle_GetWheelSpeed = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_GetWheelSpeed");
            Vehicle_SetGear = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Vehicle_SetGear");
            Vehicle_SetIndicatorLights = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetIndicatorLights");
            Vehicle_SetMaxGear = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Vehicle_SetMaxGear");
        }
    }
}