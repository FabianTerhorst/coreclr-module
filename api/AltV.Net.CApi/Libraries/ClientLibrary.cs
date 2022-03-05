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
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsTalking { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMicLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint> Player_GetLocal { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetCurrentAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetRPM { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSeatCount { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetWheelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_GetSpeedVector { get; }
    }

    public unsafe class ClientLibrary : IClientLibrary
    {
        public delegate* unmanaged[Cdecl]<nint, int> Entity_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsTalking { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMicLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint> Player_GetLocal { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetCurrentAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetRPM { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSeatCount { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetWheelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_GetSpeedVector { get; }
        public ClientLibrary(string dllName)
        {
            const DllImportSearchPath dllImportSearchPath = DllImportSearchPath.LegacyBehavior | DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories | DllImportSearchPath.System32 | DllImportSearchPath.UserDirectories | DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UseDllDirectoryForDependencies;
            var handle = NativeLibrary.Load(dllName, Assembly.GetExecutingAssembly(), dllImportSearchPath);
            Entity_GetScriptID = (delegate* unmanaged[Cdecl]<nint, int>) NativeLibrary.GetExport(handle, "Entity_GetScriptID");
            Player_IsTalking = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsTalking");
            Player_GetMicLevel = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetMicLevel");
            Player_GetNonSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetNonSpatialVolume");
            Player_SetNonSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Player_SetNonSpatialVolume");
            Player_GetSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetSpatialVolume");
            Player_SetSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Player_SetSpatialVolume");
            LocalPlayer_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "LocalPlayer_GetID");
            Player_GetLocal = (delegate* unmanaged[Cdecl]<nint>) NativeLibrary.GetExport(handle, "Player_GetLocal");
            LocalPlayer_GetPlayer = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "LocalPlayer_GetPlayer");
            LocalPlayer_GetCurrentAmmo = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "LocalPlayer_GetCurrentAmmo");
            Vehicle_GetGear = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Vehicle_GetGear");
            Vehicle_SetGear = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Vehicle_SetGear");
            Vehicle_GetIndicatorLights = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetIndicatorLights");
            Vehicle_SetIndicatorLights = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetIndicatorLights");
            Vehicle_GetMaxGear = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Vehicle_GetMaxGear");
            Vehicle_SetMaxGear = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Vehicle_SetMaxGear");
            Vehicle_GetRPM = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_GetRPM");
            Vehicle_GetSeatCount = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetSeatCount");
            Vehicle_GetWheelSpeed = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_GetWheelSpeed");
            Vehicle_GetSpeedVector = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Vehicle_GetSpeedVector");
        }
    }
}