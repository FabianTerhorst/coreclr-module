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
        public delegate* unmanaged[Cdecl]<nint, void> BaseObject_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> BaseObject_AddRefIfExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> BaseObject_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> BaseObject_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> BaseObject_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> BaseObject_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, void> BaseObject_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> BaseObject_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, void> Blip_Fade { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsFriendly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsHighDetail { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsMissionCreator { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsShortRange { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetBright { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetCategory { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetCrewIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, short> Blip_GetDisplay { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetFlashes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetFlashesAlternate { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetFlashInterval { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetFlashTimer { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetFriendIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Blip_GetGxtName { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetHeadingIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Blip_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetNumber { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetOutlineIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetPriority { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetPulse { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Blip_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetRoute { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Blip_GetRouteColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2*, void> Blip_GetScaleXY { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Blip_GetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetShowCone { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetShrinked { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetSprite { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetTickVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Blip_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_IsGlobal { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsFriendly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsHighDetail { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsMissionCreator { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsShortRange { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetBright { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetCategory { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetCrewIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, short, void> Blip_SetDisplay { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetFlashes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetFlashesAlternate { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetFlashInterval { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetFlashTimer { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetFriendIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Blip_SetGxtName { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetHeadingIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Blip_SetName { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetNumber { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetOutlineIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetPriority { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetPulse { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Blip_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetRoute { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Blip_SetRouteColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, void> Blip_SetScaleXY { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Blip_SetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetShowCone { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetShrinked { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetSprite { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetTickVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Checkpoint_GetCheckpointType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Checkpoint_GetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Checkpoint_GetColShape { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Checkpoint_GetHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Checkpoint_GetNextPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Checkpoint_GetRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Checkpoint_SetCheckpointType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Checkpoint_SetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Checkpoint_SetHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Checkpoint_SetNextPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Checkpoint_SetRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> ColShape_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte> ColShape_IsEntityIdIn { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> ColShape_IsEntityIn { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, byte> ColShape_IsPointIn { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Config_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint> Core_CreateMValueBool { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint, nint> Core_CreateMValueByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint> Core_CreateMValueDict { get; }
        public delegate* unmanaged[Cdecl]<nint, double, nint> Core_CreateMValueDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, long, nint> Core_CreateMValueInt { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint> Core_CreateMValueList { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_CreateMValueNil { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, nint> Core_CreateMValueRgba { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueString { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint> Core_CreateMValueUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, nint> Core_CreateMValueVector2 { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_CreateMValueVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint> Core_FileRead { get; }
        public delegate* unmanaged[Cdecl]<nint, uint*, nint> Core_GetAllResources { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Core_GetBlipCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, void> Core_GetBlips { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetBranch { get; }
        public delegate* unmanaged[Cdecl]<nint> Core_GetCoreInstance { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte*, nint> Core_GetEntityById { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Core_GetPlayerCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, void> Core_GetPlayers { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetResource { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Core_GetVehicleCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, void> Core_GetVehicles { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetVersion { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsDebug { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogColored { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogDebug { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogError { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogWarning { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Core_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Core_ToggleEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerLocalEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Entity_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Entity_GetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetNetOwner { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Entity_GetNetOwnerID { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> Entity_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte> Entity_GetTypeByID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeCharArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeMValueConstArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeResourceArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeString { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> FreeStringArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeUInt32Array { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeUInt8Array { get; }
        public delegate* unmanaged[Cdecl]<UIntArray*, void> FreeUIntArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeVoidPointerArray { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetBranchStatic { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetCApiVersion { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetSDKVersion { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetVersionStatic { get; }
        public delegate* unmanaged[Cdecl]<nint, MValueFunctionCallback, nint> Invoker_Create { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Invoker_Destroy { get; }
        public delegate* unmanaged[Cdecl]<byte> IsDebugStatic { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint> MValueConst_CallFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetBool { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint, void> MValueConst_GetByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetByteArraySize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte> MValueConst_GetDict { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetDictSize { get; }
        public delegate* unmanaged[Cdecl]<nint, double> MValueConst_GetDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> MValueConst_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, long> MValueConst_GetInt { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], byte> MValueConst_GetList { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetListSize { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> MValueConst_GetRGBA { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> MValueConst_GetString { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> MValueConst_GetVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetAimPos { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentAnimationDict { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentAnimationName { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, UIntArray*, void> Player_GetCurrentWeaponComponents { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> Player_GetEntityAimingAt { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetEntityAimOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetForwardSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> Player_GetHeadRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMoveSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetSeat { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetStrafeSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Player_GetVehicleID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsAiming { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsDead { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsFlashlightActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInRagdoll { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsJumping { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsReloading { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsShooting { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsSpawned { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetCSharpImpl { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], int, void> Resource_GetDependants { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Resource_GetDependantsSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], int, void> Resource_GetDependencies { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Resource_GetDependenciesSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Resource_GetExport { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], void> Resource_GetExports { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Resource_GetExportsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetImpl { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Resource_IsStarted { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, void> Resource_SetExport { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], nint[], int, void> Resource_SetExports { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Vehicle_GetPetrolTankHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> WorldObject_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> WorldObject_GetPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, float*, float*, float*, int*, void> WorldObject_GetPositionCoords { get; }
    }

    public unsafe class SharedLibrary : ISharedLibrary
    {
        public delegate* unmanaged[Cdecl]<nint, void> BaseObject_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> BaseObject_AddRefIfExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> BaseObject_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> BaseObject_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> BaseObject_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> BaseObject_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, void> BaseObject_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> BaseObject_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, void> Blip_Fade { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsFriendly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsHighDetail { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsMissionCreator { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetAsShortRange { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetBright { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetCategory { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetCrewIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, short> Blip_GetDisplay { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetFlashes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetFlashesAlternate { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetFlashInterval { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetFlashTimer { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetFriendIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Blip_GetGxtName { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetHeadingIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Blip_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetNumber { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetOutlineIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetPriority { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetPulse { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Blip_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetRoute { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Blip_GetRouteColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2*, void> Blip_GetScaleXY { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Blip_GetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetShowCone { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetShrinked { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Blip_GetSprite { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetTickVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Blip_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_IsGlobal { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsFriendly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsHighDetail { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsMissionCreator { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetAsShortRange { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetBright { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetCategory { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetCrewIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, short, void> Blip_SetDisplay { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetFlashes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetFlashesAlternate { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetFlashInterval { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetFlashTimer { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetFriendIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Blip_SetGxtName { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetHeadingIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Blip_SetName { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetNumber { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetOutlineIndicatorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetPriority { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetPulse { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Blip_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetRoute { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Blip_SetRouteColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, void> Blip_SetScaleXY { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Blip_SetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetShowCone { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetShrinked { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Blip_SetSprite { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Blip_SetTickVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Checkpoint_GetCheckpointType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Checkpoint_GetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Checkpoint_GetColShape { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Checkpoint_GetHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Checkpoint_GetNextPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Checkpoint_GetRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Checkpoint_SetCheckpointType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Checkpoint_SetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Checkpoint_SetHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Checkpoint_SetNextPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Checkpoint_SetRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> ColShape_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte> ColShape_IsEntityIdIn { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> ColShape_IsEntityIn { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, byte> ColShape_IsPointIn { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Config_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint> Core_CreateMValueBool { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint, nint> Core_CreateMValueByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint> Core_CreateMValueDict { get; }
        public delegate* unmanaged[Cdecl]<nint, double, nint> Core_CreateMValueDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, long, nint> Core_CreateMValueInt { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint> Core_CreateMValueList { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_CreateMValueNil { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, nint> Core_CreateMValueRgba { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueString { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint> Core_CreateMValueUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, nint> Core_CreateMValueVector2 { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_CreateMValueVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint> Core_FileRead { get; }
        public delegate* unmanaged[Cdecl]<nint, uint*, nint> Core_GetAllResources { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Core_GetBlipCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, void> Core_GetBlips { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetBranch { get; }
        public delegate* unmanaged[Cdecl]<nint> Core_GetCoreInstance { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte*, nint> Core_GetEntityById { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Core_GetPlayerCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, void> Core_GetPlayers { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetResource { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Core_GetVehicleCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, void> Core_GetVehicles { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetVersion { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsDebug { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogColored { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogDebug { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogError { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_LogWarning { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Core_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Core_ToggleEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerLocalEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Entity_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Entity_GetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetNetOwner { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Entity_GetNetOwnerID { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> Entity_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte> Entity_GetTypeByID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeCharArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeMValueConstArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeResourceArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeString { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> FreeStringArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeUInt32Array { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeUInt8Array { get; }
        public delegate* unmanaged[Cdecl]<UIntArray*, void> FreeUIntArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeVoidPointerArray { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetBranchStatic { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetCApiVersion { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetSDKVersion { get; }
        public delegate* unmanaged[Cdecl]<int*, nint> GetVersionStatic { get; }
        public delegate* unmanaged[Cdecl]<nint, MValueFunctionCallback, nint> Invoker_Create { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Invoker_Destroy { get; }
        public delegate* unmanaged[Cdecl]<byte> IsDebugStatic { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint> MValueConst_CallFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetBool { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint, void> MValueConst_GetByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetByteArraySize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte> MValueConst_GetDict { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetDictSize { get; }
        public delegate* unmanaged[Cdecl]<nint, double> MValueConst_GetDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> MValueConst_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, long> MValueConst_GetInt { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], byte> MValueConst_GetList { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetListSize { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> MValueConst_GetRGBA { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> MValueConst_GetString { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> MValueConst_GetVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetAimPos { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentAnimationDict { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentAnimationName { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, UIntArray*, void> Player_GetCurrentWeaponComponents { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> Player_GetEntityAimingAt { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetEntityAimOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetForwardSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation*, void> Player_GetHeadRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMoveSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetSeat { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetStrafeSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Player_GetVehicleID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsAiming { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsDead { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsFlashlightActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInRagdoll { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsJumping { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsReloading { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsShooting { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsSpawned { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetCSharpImpl { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], int, void> Resource_GetDependants { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Resource_GetDependantsSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], int, void> Resource_GetDependencies { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Resource_GetDependenciesSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Resource_GetExport { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], void> Resource_GetExports { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Resource_GetExportsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetImpl { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Resource_IsStarted { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, void> Resource_SetExport { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], nint[], int, void> Resource_SetExports { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Vehicle_GetPetrolTankHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> WorldObject_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> WorldObject_GetPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, float*, float*, float*, int*, void> WorldObject_GetPositionCoords { get; }
        public SharedLibrary(string dllName)
        {
            const DllImportSearchPath dllImportSearchPath = DllImportSearchPath.LegacyBehavior | DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories | DllImportSearchPath.System32 | DllImportSearchPath.UserDirectories | DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UseDllDirectoryForDependencies;
            var handle = NativeLibrary.Load(dllName, Assembly.GetExecutingAssembly(), dllImportSearchPath);
            BaseObject_AddRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "BaseObject_AddRef");
            BaseObject_AddRefIfExists = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "BaseObject_AddRefIfExists");
            BaseObject_DeleteMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "BaseObject_DeleteMetaData");
            BaseObject_GetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "BaseObject_GetMetaData");
            BaseObject_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "BaseObject_GetType");
            BaseObject_HasMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "BaseObject_HasMetaData");
            BaseObject_RemoveRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "BaseObject_RemoveRef");
            BaseObject_SetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "BaseObject_SetMetaData");
            Blip_Fade = (delegate* unmanaged[Cdecl]<nint, uint, uint, void>) NativeLibrary.GetExport(handle, "Blip_Fade");
            Blip_GetAlpha = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetAlpha");
            Blip_GetAsFriendly = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetAsFriendly");
            Blip_GetAsHighDetail = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetAsHighDetail");
            Blip_GetAsMissionCreator = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetAsMissionCreator");
            Blip_GetAsShortRange = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetAsShortRange");
            Blip_GetBright = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetBright");
            Blip_GetCategory = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Blip_GetCategory");
            Blip_GetColor = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetColor");
            Blip_GetCrewIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetCrewIndicatorVisible");
            Blip_GetDisplay = (delegate* unmanaged[Cdecl]<nint, short>) NativeLibrary.GetExport(handle, "Blip_GetDisplay");
            Blip_GetFlashes = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetFlashes");
            Blip_GetFlashesAlternate = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetFlashesAlternate");
            Blip_GetFlashInterval = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Blip_GetFlashInterval");
            Blip_GetFlashTimer = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Blip_GetFlashTimer");
            Blip_GetFriendIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetFriendIndicatorVisible");
            Blip_GetGxtName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Blip_GetGxtName");
            Blip_GetHeadingIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetHeadingIndicatorVisible");
            Blip_GetName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Blip_GetName");
            Blip_GetNumber = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Blip_GetNumber");
            Blip_GetOutlineIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetOutlineIndicatorVisible");
            Blip_GetPriority = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Blip_GetPriority");
            Blip_GetPulse = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetPulse");
            Blip_GetRotation = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Blip_GetRotation");
            Blip_GetRoute = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetRoute");
            Blip_GetRouteColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) NativeLibrary.GetExport(handle, "Blip_GetRouteColor");
            Blip_GetScaleXY = (delegate* unmanaged[Cdecl]<nint, Vector2*, void>) NativeLibrary.GetExport(handle, "Blip_GetScaleXY");
            Blip_GetSecondaryColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) NativeLibrary.GetExport(handle, "Blip_GetSecondaryColor");
            Blip_GetShowCone = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetShowCone");
            Blip_GetShrinked = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetShrinked");
            Blip_GetSprite = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Blip_GetSprite");
            Blip_GetTickVisible = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetTickVisible");
            Blip_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_GetType");
            Blip_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Blip_GetWorldObject");
            Blip_IsGlobal = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_IsGlobal");
            Blip_SetAlpha = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetAlpha");
            Blip_SetAsFriendly = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetAsFriendly");
            Blip_SetAsHighDetail = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetAsHighDetail");
            Blip_SetAsMissionCreator = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetAsMissionCreator");
            Blip_SetAsShortRange = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetAsShortRange");
            Blip_SetBright = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetBright");
            Blip_SetCategory = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Blip_SetCategory");
            Blip_SetColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetColor");
            Blip_SetCrewIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetCrewIndicatorVisible");
            Blip_SetDisplay = (delegate* unmanaged[Cdecl]<nint, short, void>) NativeLibrary.GetExport(handle, "Blip_SetDisplay");
            Blip_SetFlashes = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetFlashes");
            Blip_SetFlashesAlternate = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetFlashesAlternate");
            Blip_SetFlashInterval = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Blip_SetFlashInterval");
            Blip_SetFlashTimer = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Blip_SetFlashTimer");
            Blip_SetFriendIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetFriendIndicatorVisible");
            Blip_SetGxtName = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Blip_SetGxtName");
            Blip_SetHeadingIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetHeadingIndicatorVisible");
            Blip_SetName = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Blip_SetName");
            Blip_SetNumber = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Blip_SetNumber");
            Blip_SetOutlineIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetOutlineIndicatorVisible");
            Blip_SetPriority = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Blip_SetPriority");
            Blip_SetPulse = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetPulse");
            Blip_SetRotation = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Blip_SetRotation");
            Blip_SetRoute = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetRoute");
            Blip_SetRouteColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) NativeLibrary.GetExport(handle, "Blip_SetRouteColor");
            Blip_SetScaleXY = (delegate* unmanaged[Cdecl]<nint, Vector2, void>) NativeLibrary.GetExport(handle, "Blip_SetScaleXY");
            Blip_SetSecondaryColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) NativeLibrary.GetExport(handle, "Blip_SetSecondaryColor");
            Blip_SetShowCone = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetShowCone");
            Blip_SetShrinked = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetShrinked");
            Blip_SetSprite = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Blip_SetSprite");
            Blip_SetTickVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Blip_SetTickVisible");
            Checkpoint_GetCheckpointType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Checkpoint_GetCheckpointType");
            Checkpoint_GetColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) NativeLibrary.GetExport(handle, "Checkpoint_GetColor");
            Checkpoint_GetColShape = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Checkpoint_GetColShape");
            Checkpoint_GetHeight = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Checkpoint_GetHeight");
            Checkpoint_GetNextPosition = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Checkpoint_GetNextPosition");
            Checkpoint_GetRadius = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Checkpoint_GetRadius");
            Checkpoint_SetCheckpointType = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Checkpoint_SetCheckpointType");
            Checkpoint_SetColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) NativeLibrary.GetExport(handle, "Checkpoint_SetColor");
            Checkpoint_SetHeight = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Checkpoint_SetHeight");
            Checkpoint_SetNextPosition = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) NativeLibrary.GetExport(handle, "Checkpoint_SetNextPosition");
            Checkpoint_SetRadius = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Checkpoint_SetRadius");
            ColShape_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "ColShape_GetWorldObject");
            ColShape_IsEntityIdIn = (delegate* unmanaged[Cdecl]<nint, ushort, byte>) NativeLibrary.GetExport(handle, "ColShape_IsEntityIdIn");
            ColShape_IsEntityIn = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "ColShape_IsEntityIn");
            ColShape_IsPointIn = (delegate* unmanaged[Cdecl]<nint, Vector3, byte>) NativeLibrary.GetExport(handle, "ColShape_IsPointIn");
            Config_Delete = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Config_Delete");
            Core_CreateMValueBaseObject = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueBaseObject");
            Core_CreateMValueBool = (delegate* unmanaged[Cdecl]<nint, byte, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueBool");
            Core_CreateMValueByteArray = (delegate* unmanaged[Cdecl]<nint, ulong, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueByteArray");
            Core_CreateMValueDict = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueDict");
            Core_CreateMValueDouble = (delegate* unmanaged[Cdecl]<nint, double, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueDouble");
            Core_CreateMValueFunction = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueFunction");
            Core_CreateMValueInt = (delegate* unmanaged[Cdecl]<nint, long, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueInt");
            Core_CreateMValueList = (delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueList");
            Core_CreateMValueNil = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueNil");
            Core_CreateMValueRgba = (delegate* unmanaged[Cdecl]<nint, Rgba, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueRgba");
            Core_CreateMValueString = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueString");
            Core_CreateMValueUInt = (delegate* unmanaged[Cdecl]<nint, ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueUInt");
            Core_CreateMValueVector2 = (delegate* unmanaged[Cdecl]<nint, Vector2, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueVector2");
            Core_CreateMValueVector3 = (delegate* unmanaged[Cdecl]<nint, Vector3, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueVector3");
            Core_DeleteMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_DeleteMetaData");
            Core_DestroyBaseObject = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_DestroyBaseObject");
            Core_FileExists = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_FileExists");
            Core_FileRead = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint>) NativeLibrary.GetExport(handle, "Core_FileRead");
            Core_GetAllResources = (delegate* unmanaged[Cdecl]<nint, uint*, nint>) NativeLibrary.GetExport(handle, "Core_GetAllResources");
            Core_GetBlipCount = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "Core_GetBlipCount");
            Core_GetBlips = (delegate* unmanaged[Cdecl]<nint, nint[], ulong, void>) NativeLibrary.GetExport(handle, "Core_GetBlips");
            Core_GetBranch = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Core_GetBranch");
            Core_GetCoreInstance = (delegate* unmanaged[Cdecl]<nint>) NativeLibrary.GetExport(handle, "Core_GetCoreInstance");
            Core_GetEntityById = (delegate* unmanaged[Cdecl]<nint, ushort, byte*, nint>) NativeLibrary.GetExport(handle, "Core_GetEntityById");
            Core_GetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_GetMetaData");
            Core_GetPlayerCount = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "Core_GetPlayerCount");
            Core_GetPlayers = (delegate* unmanaged[Cdecl]<nint, nint[], ulong, void>) NativeLibrary.GetExport(handle, "Core_GetPlayers");
            Core_GetResource = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_GetResource");
            Core_GetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_GetSyncedMetaData");
            Core_GetVehicleCount = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "Core_GetVehicleCount");
            Core_GetVehicles = (delegate* unmanaged[Cdecl]<nint, nint[], ulong, void>) NativeLibrary.GetExport(handle, "Core_GetVehicles");
            Core_GetVersion = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Core_GetVersion");
            Core_HasMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_HasMetaData");
            Core_HasSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_HasSyncedMetaData");
            Core_IsDebug = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Core_IsDebug");
            Core_LogColored = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_LogColored");
            Core_LogDebug = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_LogDebug");
            Core_LogError = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_LogError");
            Core_LogInfo = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_LogInfo");
            Core_LogWarning = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_LogWarning");
            Core_SetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "Core_SetMetaData");
            Core_ToggleEvent = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Core_ToggleEvent");
            Core_TriggerLocalEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) NativeLibrary.GetExport(handle, "Core_TriggerLocalEvent");
            Entity_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Entity_GetID");
            Entity_GetModel = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Entity_GetModel");
            Entity_GetNetOwner = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Entity_GetNetOwner");
            Entity_GetNetOwnerID = (delegate* unmanaged[Cdecl]<nint, ushort*, byte>) NativeLibrary.GetExport(handle, "Entity_GetNetOwnerID");
            Entity_GetRotation = (delegate* unmanaged[Cdecl]<nint, Rotation*, void>) NativeLibrary.GetExport(handle, "Entity_GetRotation");
            Entity_GetStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Entity_GetStreamSyncedMetaData");
            Entity_GetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Entity_GetSyncedMetaData");
            Entity_GetTypeByID = (delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte>) NativeLibrary.GetExport(handle, "Entity_GetTypeByID");
            Entity_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Entity_GetWorldObject");
            Entity_HasStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Entity_HasStreamSyncedMetaData");
            Entity_HasSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Entity_HasSyncedMetaData");
            FreeCharArray = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeCharArray");
            FreeMValueConstArray = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeMValueConstArray");
            FreeResourceArray = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeResourceArray");
            FreeString = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeString");
            FreeStringArray = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "FreeStringArray");
            FreeUInt32Array = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeUInt32Array");
            FreeUInt8Array = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeUInt8Array");
            FreeUIntArray = (delegate* unmanaged[Cdecl]<UIntArray*, void>) NativeLibrary.GetExport(handle, "FreeUIntArray");
            FreeVoidPointerArray = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeVoidPointerArray");
            GetBranchStatic = (delegate* unmanaged[Cdecl]<int*, nint>) NativeLibrary.GetExport(handle, "GetBranchStatic");
            GetCApiVersion = (delegate* unmanaged[Cdecl]<int*, nint>) NativeLibrary.GetExport(handle, "GetCApiVersion");
            GetSDKVersion = (delegate* unmanaged[Cdecl]<int*, nint>) NativeLibrary.GetExport(handle, "GetSDKVersion");
            GetVersionStatic = (delegate* unmanaged[Cdecl]<int*, nint>) NativeLibrary.GetExport(handle, "GetVersionStatic");
            Invoker_Create = (delegate* unmanaged[Cdecl]<nint, MValueFunctionCallback, nint>) NativeLibrary.GetExport(handle, "Invoker_Create");
            Invoker_Destroy = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Invoker_Destroy");
            IsDebugStatic = (delegate* unmanaged[Cdecl]<byte>) NativeLibrary.GetExport(handle, "IsDebugStatic");
            MValueConst_AddRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_AddRef");
            MValueConst_CallFunction = (delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint>) NativeLibrary.GetExport(handle, "MValueConst_CallFunction");
            MValueConst_Delete = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_Delete");
            MValueConst_GetBool = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "MValueConst_GetBool");
            MValueConst_GetByteArray = (delegate* unmanaged[Cdecl]<nint, ulong, nint, void>) NativeLibrary.GetExport(handle, "MValueConst_GetByteArray");
            MValueConst_GetByteArraySize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetByteArraySize");
            MValueConst_GetDict = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte>) NativeLibrary.GetExport(handle, "MValueConst_GetDict");
            MValueConst_GetDictSize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetDictSize");
            MValueConst_GetDouble = (delegate* unmanaged[Cdecl]<nint, double>) NativeLibrary.GetExport(handle, "MValueConst_GetDouble");
            MValueConst_GetEntity = (delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint>) NativeLibrary.GetExport(handle, "MValueConst_GetEntity");
            MValueConst_GetInt = (delegate* unmanaged[Cdecl]<nint, long>) NativeLibrary.GetExport(handle, "MValueConst_GetInt");
            MValueConst_GetList = (delegate* unmanaged[Cdecl]<nint, nint[], byte>) NativeLibrary.GetExport(handle, "MValueConst_GetList");
            MValueConst_GetListSize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetListSize");
            MValueConst_GetRGBA = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) NativeLibrary.GetExport(handle, "MValueConst_GetRGBA");
            MValueConst_GetString = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "MValueConst_GetString");
            MValueConst_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "MValueConst_GetType");
            MValueConst_GetUInt = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetUInt");
            MValueConst_GetVector3 = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "MValueConst_GetVector3");
            MValueConst_RemoveRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_RemoveRef");
            Player_GetAimPos = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Player_GetAimPos");
            Player_GetArmor = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetArmor");
            Player_GetCurrentAnimationDict = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Player_GetCurrentAnimationDict");
            Player_GetCurrentAnimationName = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Player_GetCurrentAnimationName");
            Player_GetCurrentWeapon = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Player_GetCurrentWeapon");
            Player_GetCurrentWeaponComponents = (delegate* unmanaged[Cdecl]<nint, UIntArray*, void>) NativeLibrary.GetExport(handle, "Player_GetCurrentWeaponComponents");
            Player_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Player_GetEntity");
            Player_GetEntityAimingAt = (delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint>) NativeLibrary.GetExport(handle, "Player_GetEntityAimingAt");
            Player_GetEntityAimOffset = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Player_GetEntityAimOffset");
            Player_GetForwardSpeed = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetForwardSpeed");
            Player_GetHeadRotation = (delegate* unmanaged[Cdecl]<nint, Rotation*, void>) NativeLibrary.GetExport(handle, "Player_GetHeadRotation");
            Player_GetHealth = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetHealth");
            Player_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetID");
            Player_GetMaxArmor = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetMaxArmor");
            Player_GetMaxHealth = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetMaxHealth");
            Player_GetMoveSpeed = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetMoveSpeed");
            Player_GetName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Player_GetName");
            Player_GetSeat = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_GetSeat");
            Player_GetStrafeSpeed = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetStrafeSpeed");
            Player_GetVehicle = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Player_GetVehicle");
            Player_GetVehicleID = (delegate* unmanaged[Cdecl]<nint, ushort*, byte>) NativeLibrary.GetExport(handle, "Player_GetVehicleID");
            Player_IsAiming = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsAiming");
            Player_IsDead = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsDead");
            Player_IsFlashlightActive = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsFlashlightActive");
            Player_IsInRagdoll = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsInRagdoll");
            Player_IsInVehicle = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsInVehicle");
            Player_IsJumping = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsJumping");
            Player_IsReloading = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsReloading");
            Player_IsShooting = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsShooting");
            Player_IsSpawned = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsSpawned");
            Resource_GetCSharpImpl = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Resource_GetCSharpImpl");
            Resource_GetDependants = (delegate* unmanaged[Cdecl]<nint, nint[], int, void>) NativeLibrary.GetExport(handle, "Resource_GetDependants");
            Resource_GetDependantsSize = (delegate* unmanaged[Cdecl]<nint, int>) NativeLibrary.GetExport(handle, "Resource_GetDependantsSize");
            Resource_GetDependencies = (delegate* unmanaged[Cdecl]<nint, nint[], int, void>) NativeLibrary.GetExport(handle, "Resource_GetDependencies");
            Resource_GetDependenciesSize = (delegate* unmanaged[Cdecl]<nint, int>) NativeLibrary.GetExport(handle, "Resource_GetDependenciesSize");
            Resource_GetExport = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Resource_GetExport");
            Resource_GetExports = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], void>) NativeLibrary.GetExport(handle, "Resource_GetExports");
            Resource_GetExportsCount = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "Resource_GetExportsCount");
            Resource_GetImpl = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Resource_GetImpl");
            Resource_GetName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Resource_GetName");
            Resource_GetType = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Resource_GetType");
            Resource_IsStarted = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Resource_IsStarted");
            Resource_SetExport = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint, void>) NativeLibrary.GetExport(handle, "Resource_SetExport");
            Resource_SetExports = (delegate* unmanaged[Cdecl]<nint, nint, nint[], nint[], int, void>) NativeLibrary.GetExport(handle, "Resource_SetExports");
            Vehicle_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetEntity");
            Vehicle_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Vehicle_GetID");
            Vehicle_GetPetrolTankHealth = (delegate* unmanaged[Cdecl]<nint, int>) NativeLibrary.GetExport(handle, "Vehicle_GetPetrolTankHealth");
            Vehicle_GetWheelsCount = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetWheelsCount");
            WorldObject_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "WorldObject_GetBaseObject");
            WorldObject_GetPosition = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "WorldObject_GetPosition");
            WorldObject_GetPositionCoords = (delegate* unmanaged[Cdecl]<nint, float*, float*, float*, int*, void>) NativeLibrary.GetExport(handle, "WorldObject_GetPositionCoords");
        }
    }
}