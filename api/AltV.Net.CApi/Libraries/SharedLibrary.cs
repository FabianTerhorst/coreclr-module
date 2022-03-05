using AltV.Net.Data;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.CApi.Libraries
{
    public unsafe interface ISharedLibrary
    {
        public delegate* unmanaged[Cdecl]<UIntArray*, void> FreeUIntArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeCharArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogDebug { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogWarning { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogError { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogColored { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_CreateMValueNil { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint> Core_CreateMValueBool { get; }
        public delegate* unmanaged[Cdecl]<nint, long, nint> Core_CreateMValueInt { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint> Core_CreateMValueUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, double, nint> Core_CreateMValueDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint> Core_CreateMValueList { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint> Core_CreateMValueDict { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueVoiceChannel { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValuePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_CreateMValueVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, nint> Core_CreateMValueVector2 { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, nint> Core_CreateMValueRgba { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint, nint> Core_CreateMValueByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetBool { get; }
        public delegate* unmanaged[Cdecl]<nint, long> MValueConst_GetInt { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, double> MValueConst_GetDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, ulong*, byte> MValueConst_GetString { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetListSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], byte> MValueConst_GetList { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetDictSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte> MValueConst_GetDict { get; }
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> MValueConst_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint> MValueConst_CallFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> MValueConst_GetVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> MValueConst_GetRGBA { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint, void> MValueConst_GetByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetByteArraySize { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, void> Resource_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, void> BaseObject_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> BaseObject_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> BaseObject_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> BaseObject_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> BaseObject_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> BaseObject_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> BaseObject_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Entity_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte> Entity_GetTypeByID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Entity_GetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Entity_GetNetOwnerID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetNetOwner { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> Entity_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, UIntArray*, void> Player_GetCurrentWeaponComponents { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsDead { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsJumping { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInRagdoll { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsAiming { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsShooting { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsReloading { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMoveSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetAimPos { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> Player_GetHeadRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Player_GetVehicleID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetSeat { get; }
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> Player_GetEntityAimingAt { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetEntityAimOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsFlashlightActive { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> WorldObject_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> WorldObject_GetPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, object, object, object, int*, void> WorldObject_GetPositionCoords { get; }
    }

    public unsafe class SharedLibrary : ISharedLibrary
    {
        public delegate* unmanaged[Cdecl]<UIntArray*, void> FreeUIntArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeCharArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogDebug { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogWarning { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogError { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogColored { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_CreateMValueNil { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint> Core_CreateMValueBool { get; }
        public delegate* unmanaged[Cdecl]<nint, long, nint> Core_CreateMValueInt { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint> Core_CreateMValueUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, double, nint> Core_CreateMValueDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint> Core_CreateMValueList { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint> Core_CreateMValueDict { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueVoiceChannel { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValuePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_CreateMValueVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, nint> Core_CreateMValueVector2 { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, nint> Core_CreateMValueRgba { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint, nint> Core_CreateMValueByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetBool { get; }
        public delegate* unmanaged[Cdecl]<nint, long> MValueConst_GetInt { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, double> MValueConst_GetDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, ulong*, byte> MValueConst_GetString { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetListSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], byte> MValueConst_GetList { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetDictSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte> MValueConst_GetDict { get; }
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> MValueConst_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint> MValueConst_CallFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> MValueConst_GetVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> MValueConst_GetRGBA { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint, void> MValueConst_GetByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetByteArraySize { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, void> Resource_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, void> BaseObject_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> BaseObject_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> BaseObject_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> BaseObject_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> BaseObject_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> BaseObject_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> BaseObject_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Entity_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte> Entity_GetTypeByID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Entity_GetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Entity_GetNetOwnerID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetNetOwner { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> Entity_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, UIntArray*, void> Player_GetCurrentWeaponComponents { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsDead { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsJumping { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInRagdoll { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsAiming { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsShooting { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsReloading { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMoveSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetAimPos { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> Player_GetHeadRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Player_GetVehicleID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetSeat { get; }
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> Player_GetEntityAimingAt { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetEntityAimOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsFlashlightActive { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> WorldObject_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> WorldObject_GetPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, object, object, object, int*, void> WorldObject_GetPositionCoords { get; }
        public SharedLibrary(string dllName)
        {
            const DllImportSearchPath dllImportSearchPath = DllImportSearchPath.LegacyBehavior | DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories | DllImportSearchPath.System32 | DllImportSearchPath.UserDirectories | DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UseDllDirectoryForDependencies;
            var handle = NativeLibrary.Load(dllName, Assembly.GetExecutingAssembly(), dllImportSearchPath);
            FreeUIntArray = (delegate* unmanaged[Cdecl]<UIntArray*, void>) NativeLibrary.GetExport(handle, "FreeUIntArray");
            FreeCharArray = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeCharArray");
            FreeString = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeString");
            Core_LogInfo = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_LogInfo");
            Core_LogDebug = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_LogDebug");
            Core_LogWarning = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_LogWarning");
            Core_LogError = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_LogError");
            Core_LogColored = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_LogColored");
            Core_CreateMValueNil = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueNil");
            Core_CreateMValueBool = (delegate* unmanaged[Cdecl]<nint, byte, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueBool");
            Core_CreateMValueInt = (delegate* unmanaged[Cdecl]<nint, long, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueInt");
            Core_CreateMValueUInt = (delegate* unmanaged[Cdecl]<nint, ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueUInt");
            Core_CreateMValueDouble = (delegate* unmanaged[Cdecl]<nint, double, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueDouble");
            Core_CreateMValueString = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueString");
            Core_CreateMValueList = (delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueList");
            Core_CreateMValueDict = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueDict");
            Core_CreateMValueCheckpoint = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueCheckpoint");
            Core_CreateMValueBlip = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueBlip");
            Core_CreateMValueVoiceChannel = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueVoiceChannel");
            Core_CreateMValuePlayer = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValuePlayer");
            Core_CreateMValueVehicle = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueVehicle");
            Core_CreateMValueVector3 = (delegate* unmanaged[Cdecl]<nint, Vector3, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueVector3");
            Core_CreateMValueVector2 = (delegate* unmanaged[Cdecl]<nint, Vector2, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueVector2");
            Core_CreateMValueRgba = (delegate* unmanaged[Cdecl]<nint, Rgba, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueRgba");
            Core_CreateMValueByteArray = (delegate* unmanaged[Cdecl]<nint, ulong, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueByteArray");
            MValueConst_GetBool = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "MValueConst_GetBool");
            MValueConst_GetInt = (delegate* unmanaged[Cdecl]<nint, long>) NativeLibrary.GetExport(handle, "MValueConst_GetInt");
            MValueConst_GetUInt = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetUInt");
            MValueConst_GetDouble = (delegate* unmanaged[Cdecl]<nint, double>) NativeLibrary.GetExport(handle, "MValueConst_GetDouble");
            MValueConst_GetString = (delegate* unmanaged[Cdecl]<nint, nint*, ulong*, byte>) NativeLibrary.GetExport(handle, "MValueConst_GetString");
            MValueConst_GetListSize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetListSize");
            MValueConst_GetList = (delegate* unmanaged[Cdecl]<nint, nint[], byte>) NativeLibrary.GetExport(handle, "MValueConst_GetList");
            MValueConst_GetDictSize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetDictSize");
            MValueConst_GetDict = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte>) NativeLibrary.GetExport(handle, "MValueConst_GetDict");
            MValueConst_GetEntity = (delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint>) NativeLibrary.GetExport(handle, "MValueConst_GetEntity");
            MValueConst_CallFunction = (delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint>) NativeLibrary.GetExport(handle, "MValueConst_CallFunction");
            MValueConst_GetVector3 = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "MValueConst_GetVector3");
            MValueConst_GetRGBA = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) NativeLibrary.GetExport(handle, "MValueConst_GetRGBA");
            MValueConst_GetByteArray = (delegate* unmanaged[Cdecl]<nint, ulong, nint, void>) NativeLibrary.GetExport(handle, "MValueConst_GetByteArray");
            MValueConst_GetByteArraySize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetByteArraySize");
            MValueConst_AddRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_AddRef");
            MValueConst_RemoveRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_RemoveRef");
            MValueConst_Delete = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_Delete");
            MValueConst_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "MValueConst_GetType");
            Resource_GetName = (delegate* unmanaged[Cdecl]<nint, nint*, void>) NativeLibrary.GetExport(handle, "Resource_GetName");
            BaseObject_AddRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "BaseObject_AddRef");
            BaseObject_RemoveRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "BaseObject_RemoveRef");
            BaseObject_SetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "BaseObject_SetMetaData");
            BaseObject_HasMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "BaseObject_HasMetaData");
            BaseObject_DeleteMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "BaseObject_DeleteMetaData");
            BaseObject_GetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "BaseObject_GetMetaData");
            BaseObject_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "BaseObject_GetType");
            Entity_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Entity_GetID");
            Entity_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Entity_GetWorldObject");
            Entity_GetTypeByID = (delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte>) NativeLibrary.GetExport(handle, "Entity_GetTypeByID");
            Entity_GetModel = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Entity_GetModel");
            Entity_GetNetOwnerID = (delegate* unmanaged[Cdecl]<nint, ushort*, byte>) NativeLibrary.GetExport(handle, "Entity_GetNetOwnerID");
            Entity_GetNetOwner = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Entity_GetNetOwner");
            Entity_GetRotation = (delegate* unmanaged[Cdecl]<nint, Rotation*, void>) NativeLibrary.GetExport(handle, "Entity_GetRotation");
            Entity_HasStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Entity_HasStreamSyncedMetaData");
            Entity_GetStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Entity_GetStreamSyncedMetaData");
            Entity_HasSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Entity_HasSyncedMetaData");
            Entity_GetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Entity_GetSyncedMetaData");
            Player_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetID");
            Player_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Player_GetEntity");
            Player_GetName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Player_GetName");
            Player_GetHealth = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetHealth");
            Player_GetMaxHealth = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetMaxHealth");
            Player_GetCurrentWeaponComponents = (delegate* unmanaged[Cdecl]<nint, UIntArray*, void>) NativeLibrary.GetExport(handle, "Player_GetCurrentWeaponComponents");
            Player_GetCurrentWeapon = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Player_GetCurrentWeapon");
            Player_IsDead = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsDead");
            Player_IsJumping = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsJumping");
            Player_IsInRagdoll = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsInRagdoll");
            Player_IsAiming = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsAiming");
            Player_IsShooting = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsShooting");
            Player_IsReloading = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsReloading");
            Player_GetArmor = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetArmor");
            Player_GetMaxArmor = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetMaxArmor");
            Player_GetMoveSpeed = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetMoveSpeed");
            Player_GetAimPos = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Player_GetAimPos");
            Player_GetHeadRotation = (delegate* unmanaged[Cdecl]<nint, Rotation*, void>) NativeLibrary.GetExport(handle, "Player_GetHeadRotation");
            Player_IsInVehicle = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsInVehicle");
            Player_GetVehicle = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Player_GetVehicle");
            Player_GetVehicleID = (delegate* unmanaged[Cdecl]<nint, ushort*, byte>) NativeLibrary.GetExport(handle, "Player_GetVehicleID");
            Player_GetSeat = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_GetSeat");
            Player_GetEntityAimingAt = (delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint>) NativeLibrary.GetExport(handle, "Player_GetEntityAimingAt");
            Player_GetEntityAimOffset = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Player_GetEntityAimOffset");
            Player_IsFlashlightActive = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsFlashlightActive");
            Vehicle_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Vehicle_GetID");
            Vehicle_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetEntity");
            Vehicle_GetWheelsCount = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetWheelsCount");
            WorldObject_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "WorldObject_GetBaseObject");
            WorldObject_GetPosition = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "WorldObject_GetPosition");
            WorldObject_GetPositionCoords = (delegate* unmanaged[Cdecl]<nint, object, object, object, int*, void>) NativeLibrary.GetExport(handle, "WorldObject_GetPositionCoords");
        }
    }
}