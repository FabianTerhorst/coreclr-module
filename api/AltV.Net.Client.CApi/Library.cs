using AltV.Net.Client.Data;
using AltV.Net.Client.CApi.Events;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
namespace AltV.Net.Client.CApi
{
    public unsafe interface ILibrary
    {
        public delegate* unmanaged[Cdecl]<object, void> Event_Cancel { get; }
        public delegate* unmanaged[Cdecl]<object, byte> Event_WasCancelled { get; }
        public delegate* unmanaged[Cdecl]<nint, TickModuleDelegate, void> Event_SetTickDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ServerEventModuleDelegate, void> Event_SetServerEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEventModuleDelegate, void> Event_SetClientEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ConsoleCommandModuleDelegate, void> Event_SetConsoleCommandDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, CreatePlayerModuleDelegate, void> Event_SetCreatePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, RemovePlayerModuleDelegate, void> Event_SetRemovePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, CreateVehicleModuleDelegate, void> Event_SetCreateVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, RemoveVehicleModuleDelegate, void> Event_SetRemoveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<object, void> FreeUIntArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeCharArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_CreateMValueNil { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint> Core_CreateMValueBool { get; }
        public delegate* unmanaged[Cdecl]<nint, long, nint> Core_CreateMValueInt { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint> Core_CreateMValueUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, double, nint> Core_CreateMValueDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint> Core_CreateMValueList { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint> Core_CreateMValueDict { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_CreateMValueVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, nint> Core_CreateMValueVector2 { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, nint> Core_CreateMValueRgba { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, object, nint> Core_CreateMValueByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetBool { get; }
        public delegate* unmanaged[Cdecl]<nint, long> MValueConst_GetInt { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, double> MValueConst_GetDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, ulong*, byte> MValueConst_GetString { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetListSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], byte> MValueConst_GetList { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetDictSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte> MValueConst_GetDict { get; }
        public delegate* unmanaged[Cdecl]<nint, object, object> MValueConst_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint> MValueConst_CallFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> MValueConst_GetVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> MValueConst_GetRGBA { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, object, void> MValueConst_GetByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetByteArraySize { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint*, void> Resource_GetFile { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, bool> Resource_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetCSharpImpl { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogDebug { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogWarning { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogError { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogColored { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> BaseObject_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> BaseObject_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> BaseObject_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> BaseObject_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> BaseObject_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Entity_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte> Entity_GetTypeByID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Entity_GetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte*, ushort*, void> Entity_GetNetOwnerId { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Entity_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Entity_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Player_GetVehicleId { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetAimPos { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetArmour { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetEntityAimOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsFlashlightActive { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetHeadRot { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsAiming { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsDead { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInRagdoll { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsReloading { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsTalking { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxArmour { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMicLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMoveSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetSeat { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint> Player_GetLocal { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetCurrentAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetEntity { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> WorldObject_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> WorldObject_GetPosition { get; }
    }

    public unsafe class Library : ILibrary
    {
        private const string DllName = "coreclr-client-module";

        public delegate* unmanaged[Cdecl]<object, void> Event_Cancel { get; }
        public delegate* unmanaged[Cdecl]<object, byte> Event_WasCancelled { get; }
        public delegate* unmanaged[Cdecl]<nint, TickModuleDelegate, void> Event_SetTickDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ServerEventModuleDelegate, void> Event_SetServerEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEventModuleDelegate, void> Event_SetClientEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ConsoleCommandModuleDelegate, void> Event_SetConsoleCommandDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, CreatePlayerModuleDelegate, void> Event_SetCreatePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, RemovePlayerModuleDelegate, void> Event_SetRemovePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, CreateVehicleModuleDelegate, void> Event_SetCreateVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, RemoveVehicleModuleDelegate, void> Event_SetRemoveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<object, void> FreeUIntArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeCharArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_CreateMValueNil { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint> Core_CreateMValueBool { get; }
        public delegate* unmanaged[Cdecl]<nint, long, nint> Core_CreateMValueInt { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint> Core_CreateMValueUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, double, nint> Core_CreateMValueDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint> Core_CreateMValueList { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint> Core_CreateMValueDict { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_CreateMValueVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, nint> Core_CreateMValueVector2 { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, nint> Core_CreateMValueRgba { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, object, nint> Core_CreateMValueByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetBool { get; }
        public delegate* unmanaged[Cdecl]<nint, long> MValueConst_GetInt { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, double> MValueConst_GetDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, ulong*, byte> MValueConst_GetString { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetListSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], byte> MValueConst_GetList { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetDictSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte> MValueConst_GetDict { get; }
        public delegate* unmanaged[Cdecl]<nint, object, object> MValueConst_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint> MValueConst_CallFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> MValueConst_GetVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> MValueConst_GetRGBA { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, object, void> MValueConst_GetByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetByteArraySize { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint*, void> Resource_GetFile { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, bool> Resource_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetCSharpImpl { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogDebug { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogWarning { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogError { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogColored { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> BaseObject_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> BaseObject_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> BaseObject_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> BaseObject_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> BaseObject_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Entity_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte> Entity_GetTypeByID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Entity_GetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte*, ushort*, void> Entity_GetNetOwnerId { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Entity_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Entity_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Player_GetVehicleId { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetAimPos { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetArmour { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetEntityAimOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsFlashlightActive { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetHeadRot { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsAiming { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsDead { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInRagdoll { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsReloading { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsTalking { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxArmour { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMicLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMoveSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetSeat { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint> Player_GetLocal { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetCurrentAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetEntity { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> WorldObject_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> WorldObject_GetPosition { get; }
        public Library()
        {
            const DllImportSearchPath dllImportSearchPath = DllImportSearchPath.LegacyBehavior | DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories | DllImportSearchPath.System32 | DllImportSearchPath.UserDirectories | DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UseDllDirectoryForDependencies;
            var handle = NativeLibrary.Load(DllName, Assembly.GetExecutingAssembly(), dllImportSearchPath);
            Event_Cancel = (delegate* unmanaged[Cdecl]<object, void>) NativeLibrary.GetExport(handle, "Event_Cancel");
            Event_WasCancelled = (delegate* unmanaged[Cdecl]<object, byte>) NativeLibrary.GetExport(handle, "Event_WasCancelled");
            Event_SetTickDelegate = (delegate* unmanaged[Cdecl]<nint, TickModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetTickDelegate");
            Event_SetServerEventDelegate = (delegate* unmanaged[Cdecl]<nint, ServerEventModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetServerEventDelegate");
            Event_SetClientEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEventModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetClientEventDelegate");
            Event_SetConsoleCommandDelegate = (delegate* unmanaged[Cdecl]<nint, ConsoleCommandModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetConsoleCommandDelegate");
            Event_SetCreatePlayerDelegate = (delegate* unmanaged[Cdecl]<nint, CreatePlayerModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetCreatePlayerDelegate");
            Event_SetRemovePlayerDelegate = (delegate* unmanaged[Cdecl]<nint, RemovePlayerModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetRemovePlayerDelegate");
            Event_SetCreateVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, CreateVehicleModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetCreateVehicleDelegate");
            Event_SetRemoveVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, RemoveVehicleModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetRemoveVehicleDelegate");
            FreeUIntArray = (delegate* unmanaged[Cdecl]<object, void>) NativeLibrary.GetExport(handle, "FreeUIntArray");
            FreeCharArray = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeCharArray");
            FreeString = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeString");
            Core_CreateMValueNil = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueNil");
            Core_CreateMValueBool = (delegate* unmanaged[Cdecl]<nint, byte, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueBool");
            Core_CreateMValueInt = (delegate* unmanaged[Cdecl]<nint, long, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueInt");
            Core_CreateMValueUInt = (delegate* unmanaged[Cdecl]<nint, ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueUInt");
            Core_CreateMValueDouble = (delegate* unmanaged[Cdecl]<nint, double, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueDouble");
            Core_CreateMValueString = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueString");
            Core_CreateMValueList = (delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueList");
            Core_CreateMValueDict = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueDict");
            Core_CreateMValueVector3 = (delegate* unmanaged[Cdecl]<nint, Vector3, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueVector3");
            Core_CreateMValueVector2 = (delegate* unmanaged[Cdecl]<nint, Vector2, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueVector2");
            Core_CreateMValueRgba = (delegate* unmanaged[Cdecl]<nint, Rgba, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueRgba");
            Core_CreateMValueByteArray = (delegate* unmanaged[Cdecl]<nint, ulong, object, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueByteArray");
            MValueConst_GetBool = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "MValueConst_GetBool");
            MValueConst_GetInt = (delegate* unmanaged[Cdecl]<nint, long>) NativeLibrary.GetExport(handle, "MValueConst_GetInt");
            MValueConst_GetUInt = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetUInt");
            MValueConst_GetDouble = (delegate* unmanaged[Cdecl]<nint, double>) NativeLibrary.GetExport(handle, "MValueConst_GetDouble");
            MValueConst_GetString = (delegate* unmanaged[Cdecl]<nint, nint*, ulong*, byte>) NativeLibrary.GetExport(handle, "MValueConst_GetString");
            MValueConst_GetListSize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetListSize");
            MValueConst_GetList = (delegate* unmanaged[Cdecl]<nint, nint[], byte>) NativeLibrary.GetExport(handle, "MValueConst_GetList");
            MValueConst_GetDictSize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetDictSize");
            MValueConst_GetDict = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte>) NativeLibrary.GetExport(handle, "MValueConst_GetDict");
            MValueConst_GetEntity = (delegate* unmanaged[Cdecl]<nint, object, object>) NativeLibrary.GetExport(handle, "MValueConst_GetEntity");
            MValueConst_CallFunction = (delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint>) NativeLibrary.GetExport(handle, "MValueConst_CallFunction");
            MValueConst_GetVector3 = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "MValueConst_GetVector3");
            MValueConst_GetRGBA = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) NativeLibrary.GetExport(handle, "MValueConst_GetRGBA");
            MValueConst_GetByteArray = (delegate* unmanaged[Cdecl]<nint, ulong, object, void>) NativeLibrary.GetExport(handle, "MValueConst_GetByteArray");
            MValueConst_GetByteArraySize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetByteArraySize");
            MValueConst_AddRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_AddRef");
            MValueConst_RemoveRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_RemoveRef");
            MValueConst_Delete = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_Delete");
            MValueConst_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "MValueConst_GetType");
            Resource_GetName = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Resource_GetName");
            Resource_GetFile = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint*, void>) NativeLibrary.GetExport(handle, "Resource_GetFile");
            Resource_FileExists = (delegate* unmanaged[Cdecl]<nint, nint, bool>) NativeLibrary.GetExport(handle, "Resource_FileExists");
            Resource_GetCSharpImpl = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Resource_GetCSharpImpl");
            LogInfo = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "LogInfo");
            LogDebug = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "LogDebug");
            LogWarning = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "LogWarning");
            LogError = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "LogError");
            LogColored = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "LogColored");
            BaseObject_SetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "BaseObject_SetMetaData");
            BaseObject_HasMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "BaseObject_HasMetaData");
            BaseObject_DeleteMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "BaseObject_DeleteMetaData");
            BaseObject_GetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "BaseObject_GetMetaData");
            BaseObject_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "BaseObject_GetType");
            Entity_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Entity_GetID");
            Entity_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Entity_GetWorldObject");
            Entity_GetTypeByID = (delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte>) NativeLibrary.GetExport(handle, "Entity_GetTypeByID");
            Entity_GetModel = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Entity_GetModel");
            Entity_GetNetOwnerId = (delegate* unmanaged[Cdecl]<nint, byte*, ushort*, void>) NativeLibrary.GetExport(handle, "Entity_GetNetOwnerId");
            Entity_GetScriptID = (delegate* unmanaged[Cdecl]<nint, int>) NativeLibrary.GetExport(handle, "Entity_GetScriptID");
            Entity_GetRotation = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Entity_GetRotation");
            Entity_HasStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Entity_HasStreamSyncedMetaData");
            Entity_GetStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Entity_GetStreamSyncedMetaData");
            Entity_HasSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Entity_HasSyncedMetaData");
            Entity_GetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Entity_GetSyncedMetaData");
            Player_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetID");
            Player_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Player_GetEntity");
            Player_GetVehicleId = (delegate* unmanaged[Cdecl]<nint, ushort*, byte>) NativeLibrary.GetExport(handle, "Player_GetVehicleId");
            Player_GetName = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Player_GetName");
            Player_GetAimPos = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Player_GetAimPos");
            Player_GetArmour = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetArmour");
            Player_GetCurrentWeapon = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Player_GetCurrentWeapon");
            Player_GetEntityAimOffset = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Player_GetEntityAimOffset");
            Player_IsFlashlightActive = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsFlashlightActive");
            Player_GetHeadRot = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Player_GetHeadRot");
            Player_GetHealth = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetHealth");
            Player_IsAiming = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsAiming");
            Player_IsDead = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsDead");
            Player_IsInRagdoll = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsInRagdoll");
            Player_IsReloading = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsReloading");
            Player_IsTalking = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsTalking");
            Player_GetMaxArmour = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetMaxArmour");
            Player_GetMaxHealth = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetMaxHealth");
            Player_GetMicLevel = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetMicLevel");
            Player_GetMoveSpeed = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetMoveSpeed");
            Player_GetNonSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetNonSpatialVolume");
            Player_SetNonSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Player_SetNonSpatialVolume");
            Player_GetSeat = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_GetSeat");
            Player_GetSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetSpatialVolume");
            Player_SetSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Player_SetSpatialVolume");
            LocalPlayer_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "LocalPlayer_GetID");
            Player_GetLocal = (delegate* unmanaged[Cdecl]<nint>) NativeLibrary.GetExport(handle, "Player_GetLocal");
            LocalPlayer_GetPlayer = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "LocalPlayer_GetPlayer");
            LocalPlayer_GetCurrentAmmo = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "LocalPlayer_GetCurrentAmmo");
            Vehicle_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Vehicle_GetID");
            Vehicle_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetEntity");
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
            Vehicle_GetWheelsCount = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetWheelsCount");
            WorldObject_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "WorldObject_GetBaseObject");
            WorldObject_GetPosition = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "WorldObject_GetPosition");
        }
    }
}