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
        public delegate* unmanaged[Cdecl]<nint, nint, void> BaseObject_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> BaseObject_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> BaseObject_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> BaseObject_HasMetaData { get; }
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
        public delegate* unmanaged[Cdecl]<byte> Core_GetEventEnumSize { get; }
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
        public delegate* unmanaged[Cdecl]<nint, void> FreeObjectArray { get; }
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
        public delegate* unmanaged[Cdecl]<nint, void> Object_ActivatePhysics { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, short, Vector3, Rotation, byte, byte, byte, void> Object_AttachToEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, short, Vector3, Rotation, byte, byte, byte, void> Object_AttachToEntity_ScriptId { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_Detach { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_GetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Object_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Object_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Object_GetLodDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_GetTextureVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_HasGravity { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsCollisionEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsDynamic { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Object_PlaceOnGroundProperly { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Object_ResetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_SetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Object_SetLodDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_SetPositionFrozen { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_SetTextureVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Object_ToggleCollision { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_ToggleGravity { get; }
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
    }

    public unsafe class SharedLibrary : ISharedLibrary
    {
        public readonly uint Methods = 1303;
        public delegate* unmanaged[Cdecl]<nint, nint, void> BaseObject_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> BaseObject_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> BaseObject_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> BaseObject_HasMetaData { get; }
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
        public delegate* unmanaged[Cdecl]<byte> Core_GetEventEnumSize { get; }
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
        public delegate* unmanaged[Cdecl]<nint, void> FreeObjectArray { get; }
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
        public delegate* unmanaged[Cdecl]<nint, void> Object_ActivatePhysics { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, short, Vector3, Rotation, byte, byte, byte, void> Object_AttachToEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, short, Vector3, Rotation, byte, byte, byte, void> Object_AttachToEntity_ScriptId { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_Detach { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_GetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Object_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Object_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Object_GetLodDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_GetTextureVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_HasGravity { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsCollisionEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsDynamic { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Object_PlaceOnGroundProperly { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Object_ResetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_SetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Object_SetLodDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_SetPositionFrozen { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_SetTextureVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Object_ToggleCollision { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Object_ToggleGravity { get; }
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
        public SharedLibrary(Dictionary<ulong, IntPtr> funcTable)
        {
            BaseObject_DeleteMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[708437361947313558UL];
            BaseObject_GetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[94878368862433577UL];
            BaseObject_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[18209683949357219620UL];
            BaseObject_HasMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[11071671396837829565UL];
            BaseObject_SetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[17855518237816145157UL];
            Blip_Fade = (delegate* unmanaged[Cdecl]<nint, uint, uint, void>) funcTable[7919605214560618601UL];
            Blip_GetAlpha = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[18165027774468110743UL];
            Blip_GetAsFriendly = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[14442880220511169610UL];
            Blip_GetAsHighDetail = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[15518177057843406776UL];
            Blip_GetAsMissionCreator = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[3126455498543332575UL];
            Blip_GetAsShortRange = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[1172548134432265566UL];
            Blip_GetBright = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[16669151784337538769UL];
            Blip_GetCategory = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[17124988444567170381UL];
            Blip_GetColor = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[10161413011017508596UL];
            Blip_GetCrewIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[7489076557768286025UL];
            Blip_GetDisplay = (delegate* unmanaged[Cdecl]<nint, short>) funcTable[4252702831802823849UL];
            Blip_GetFlashes = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[2104864518804770913UL];
            Blip_GetFlashesAlternate = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[17970482163436361505UL];
            Blip_GetFlashInterval = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[7268399438733338528UL];
            Blip_GetFlashTimer = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[18012872850535179050UL];
            Blip_GetFriendIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[1284553805803690156UL];
            Blip_GetGxtName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[9638686443361526541UL];
            Blip_GetHeadingIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[1544639341239889388UL];
            Blip_GetName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[6023697164866971082UL];
            Blip_GetNumber = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[6499825197145467356UL];
            Blip_GetOutlineIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[7151930674085082596UL];
            Blip_GetPriority = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[12632472660267595957UL];
            Blip_GetPulse = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[7257172800563416970UL];
            Blip_GetRotation = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[5702674297810853299UL];
            Blip_GetRoute = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[16653539139235421378UL];
            Blip_GetRouteColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) funcTable[17064807464537399125UL];
            Blip_GetScaleXY = (delegate* unmanaged[Cdecl]<nint, Vector2*, void>) funcTable[11607734941118633722UL];
            Blip_GetSecondaryColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) funcTable[963433508794487912UL];
            Blip_GetShowCone = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[2901886689426515467UL];
            Blip_GetShrinked = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[17121302494407187349UL];
            Blip_GetSprite = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[14083917171894209256UL];
            Blip_GetTickVisible = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[8240730200168110122UL];
            Blip_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[17238464136056972089UL];
            Blip_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[12101381495710790212UL];
            Blip_IsGlobal = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[1596569233630630336UL];
            Blip_SetAlpha = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[827526123028486003UL];
            Blip_SetAsFriendly = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[787285555691727838UL];
            Blip_SetAsHighDetail = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[10952140126105149868UL];
            Blip_SetAsMissionCreator = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[4259466712060494347UL];
            Blip_SetAsShortRange = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[11444504913196635074UL];
            Blip_SetBright = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[12951227871163453789UL];
            Blip_SetCategory = (delegate* unmanaged[Cdecl]<nint, ushort, void>) funcTable[10908482830560933545UL];
            Blip_SetColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[4359213668992430544UL];
            Blip_SetCrewIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[5021791765560450045UL];
            Blip_SetDisplay = (delegate* unmanaged[Cdecl]<nint, short, void>) funcTable[765521681468970253UL];
            Blip_SetFlashes = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[9719457212042336413UL];
            Blip_SetFlashesAlternate = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[16980328663411287653UL];
            Blip_SetFlashInterval = (delegate* unmanaged[Cdecl]<nint, ushort, void>) funcTable[6214100447904171196UL];
            Blip_SetFlashTimer = (delegate* unmanaged[Cdecl]<nint, ushort, void>) funcTable[1367888844464568270UL];
            Blip_SetFriendIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[13142666920853619216UL];
            Blip_SetGxtName = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[9573760768798768585UL];
            Blip_SetHeadingIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[15700853203216123656UL];
            Blip_SetName = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[10160430756249653502UL];
            Blip_SetNumber = (delegate* unmanaged[Cdecl]<nint, ushort, void>) funcTable[8790599012317355736UL];
            Blip_SetOutlineIndicatorVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[14432952392893787024UL];
            Blip_SetPriority = (delegate* unmanaged[Cdecl]<nint, ushort, void>) funcTable[3632067607182078689UL];
            Blip_SetPulse = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[1846258490270900758UL];
            Blip_SetRotation = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[11843758821216320887UL];
            Blip_SetRoute = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[12209518135091118902UL];
            Blip_SetRouteColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) funcTable[16164192783657598681UL];
            Blip_SetScaleXY = (delegate* unmanaged[Cdecl]<nint, Vector2, void>) funcTable[6717728395244832814UL];
            Blip_SetSecondaryColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) funcTable[17686447591482765772UL];
            Blip_SetShowCone = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[3778768543137040703UL];
            Blip_SetShrinked = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[13148291405831983849UL];
            Blip_SetSprite = (delegate* unmanaged[Cdecl]<nint, ushort, void>) funcTable[12679562522051391268UL];
            Blip_SetTickVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[12301129353484862462UL];
            Checkpoint_GetCheckpointType = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[4468015372226338538UL];
            Checkpoint_GetColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) funcTable[3060780930087959043UL];
            Checkpoint_GetColShape = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[14307496819100881307UL];
            Checkpoint_GetHeight = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[10824205268136835519UL];
            Checkpoint_GetNextPosition = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) funcTable[17903934855727355674UL];
            Checkpoint_GetRadius = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[2020890038989364322UL];
            Checkpoint_SetCheckpointType = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[13376157559809529246UL];
            Checkpoint_SetColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) funcTable[5248247616935456519UL];
            Checkpoint_SetHeight = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[9224402025453695499UL];
            Checkpoint_SetNextPosition = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) funcTable[9666277662912136326UL];
            Checkpoint_SetRadius = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[14085042752674206838UL];
            ColShape_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[10737084266638046596UL];
            ColShape_IsEntityIdIn = (delegate* unmanaged[Cdecl]<nint, ushort, byte>) funcTable[5869452894078625098UL];
            ColShape_IsEntityIn = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[7195796169914493467UL];
            ColShape_IsPointIn = (delegate* unmanaged[Cdecl]<nint, Vector3, byte>) funcTable[14730476857638624976UL];
            Config_Delete = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[7317062620834459283UL];
            Core_CreateMValueBaseObject = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[5766415601923287037UL];
            Core_CreateMValueBool = (delegate* unmanaged[Cdecl]<nint, byte, nint>) funcTable[6215947625799767015UL];
            Core_CreateMValueByteArray = (delegate* unmanaged[Cdecl]<nint, ulong, nint, nint>) funcTable[3593725825158754778UL];
            Core_CreateMValueDict = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint>) funcTable[15859098018404006899UL];
            Core_CreateMValueDouble = (delegate* unmanaged[Cdecl]<nint, double, nint>) funcTable[16242142122941629214UL];
            Core_CreateMValueFunction = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[4657269419219583283UL];
            Core_CreateMValueInt = (delegate* unmanaged[Cdecl]<nint, long, nint>) funcTable[12481901724785534268UL];
            Core_CreateMValueList = (delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint>) funcTable[14851400310496395323UL];
            Core_CreateMValueNil = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[14313308765387586898UL];
            Core_CreateMValueRgba = (delegate* unmanaged[Cdecl]<nint, Rgba, nint>) funcTable[7470444750118649089UL];
            Core_CreateMValueString = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[8662408974678811830UL];
            Core_CreateMValueUInt = (delegate* unmanaged[Cdecl]<nint, ulong, nint>) funcTable[13185731657110853387UL];
            Core_CreateMValueVector2 = (delegate* unmanaged[Cdecl]<nint, Vector2, nint>) funcTable[14209218917773541446UL];
            Core_CreateMValueVector3 = (delegate* unmanaged[Cdecl]<nint, Vector3, nint>) funcTable[14209220017285169657UL];
            Core_DeleteMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[4400707511942386101UL];
            Core_DestroyBaseObject = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[5259800943635588661UL];
            Core_FileExists = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[3901271461579002085UL];
            Core_FileRead = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint>) funcTable[9760322637789525869UL];
            Core_GetAllResources = (delegate* unmanaged[Cdecl]<nint, uint*, nint>) funcTable[6732542261895805625UL];
            Core_GetBlipCount = (delegate* unmanaged[Cdecl]<nint, ulong>) funcTable[11007750040303004177UL];
            Core_GetBlips = (delegate* unmanaged[Cdecl]<nint, nint[], ulong, void>) funcTable[1917439644533318059UL];
            Core_GetBranch = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[6690168401436253437UL];
            Core_GetCoreInstance = (delegate* unmanaged[Cdecl]<nint>) funcTable[6337496489317379009UL];
            Core_GetEntityById = (delegate* unmanaged[Cdecl]<nint, ushort, byte*, nint>) funcTable[18047752154616389974UL];
            Core_GetEventEnumSize = (delegate* unmanaged[Cdecl]<byte>) funcTable[92328002015237983UL];
            Core_GetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[4962810708229775752UL];
            Core_GetPlayerCount = (delegate* unmanaged[Cdecl]<nint, ulong>) funcTable[9039461081005071287UL];
            Core_GetPlayers = (delegate* unmanaged[Cdecl]<nint, nint[], ulong, void>) funcTable[11861055459526076209UL];
            Core_GetResource = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[10536163479263043901UL];
            Core_GetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[15692791650389615518UL];
            Core_GetVehicleCount = (delegate* unmanaged[Cdecl]<nint, ulong>) funcTable[2823364380739421630UL];
            Core_GetVehicles = (delegate* unmanaged[Cdecl]<nint, nint[], ulong, void>) funcTable[3235559180935122972UL];
            Core_GetVersion = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[14465876538568411535UL];
            Core_HasMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[526835444446666988UL];
            Core_HasSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[8287345762226423418UL];
            Core_IsDebug = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[3743078238673604470UL];
            Core_LogColored = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[18216431582726856771UL];
            Core_LogDebug = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[2823729106002025274UL];
            Core_LogError = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[10891295114061747259UL];
            Core_LogInfo = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[14877110261382004871UL];
            Core_LogWarning = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[1040611282316859125UL];
            Core_SetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[14392325663991424196UL];
            Core_ToggleEvent = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[10255109545425113429UL];
            Core_TriggerLocalEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) funcTable[8156519968050262184UL];
            Entity_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[9087594972632768060UL];
            Entity_GetModel = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[14085866899597080750UL];
            Entity_GetNetOwner = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[8567145605175130875UL];
            Entity_GetNetOwnerID = (delegate* unmanaged[Cdecl]<nint, ushort*, byte>) funcTable[17787500225623214326UL];
            Entity_GetRotation = (delegate* unmanaged[Cdecl]<nint, Rotation*, void>) funcTable[15850066457941071707UL];
            Entity_GetStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[5575408495236846882UL];
            Entity_GetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[17547631773096257994UL];
            Entity_GetTypeByID = (delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte>) funcTable[7997516127451707853UL];
            Entity_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[5428808758885526812UL];
            Entity_HasStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[17507712689507862030UL];
            Entity_HasSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[13485609717128995678UL];
            FreeCharArray = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[16225037769244386888UL];
            FreeMValueConstArray = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[4069449017940596015UL];
            FreeObjectArray = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[5578275922188021101UL];
            FreeResourceArray = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[6554604447971714996UL];
            FreeString = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[11629237033957135486UL];
            FreeStringArray = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[9529728860812939111UL];
            FreeUInt32Array = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[1947694414810612927UL];
            FreeUInt8Array = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[5960113823565150810UL];
            FreeUIntArray = (delegate* unmanaged[Cdecl]<UIntArray*, void>) funcTable[14856349963727788424UL];
            FreeVoidPointerArray = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[2483773874873355099UL];
            GetBranchStatic = (delegate* unmanaged[Cdecl]<int*, nint>) funcTable[7166006842963864493UL];
            GetCApiVersion = (delegate* unmanaged[Cdecl]<int*, nint>) funcTable[6426204784331965736UL];
            GetSDKVersion = (delegate* unmanaged[Cdecl]<int*, nint>) funcTable[12829489855253341107UL];
            GetVersionStatic = (delegate* unmanaged[Cdecl]<int*, nint>) funcTable[8723031759902147375UL];
            Invoker_Create = (delegate* unmanaged[Cdecl]<nint, MValueFunctionCallback, nint>) funcTable[13124968469479193234UL];
            Invoker_Destroy = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[10594554066242046632UL];
            IsDebugStatic = (delegate* unmanaged[Cdecl]<byte>) funcTable[4877298225340664926UL];
            MValueConst_AddRef = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[13238013155478018457UL];
            MValueConst_CallFunction = (delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint>) funcTable[15308010697310934269UL];
            MValueConst_Delete = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[5208125713755310202UL];
            MValueConst_GetBool = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[11088288234116655539UL];
            MValueConst_GetByteArray = (delegate* unmanaged[Cdecl]<nint, ulong, nint, void>) funcTable[3549085397639113974UL];
            MValueConst_GetByteArraySize = (delegate* unmanaged[Cdecl]<nint, ulong>) funcTable[2948775393893878615UL];
            MValueConst_GetDict = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte>) funcTable[864591458098989191UL];
            MValueConst_GetDictSize = (delegate* unmanaged[Cdecl]<nint, ulong>) funcTable[5894378329472540734UL];
            MValueConst_GetDouble = (delegate* unmanaged[Cdecl]<nint, double>) funcTable[10269245833596234202UL];
            MValueConst_GetEntity = (delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint>) funcTable[3919856118327873248UL];
            MValueConst_GetInt = (delegate* unmanaged[Cdecl]<nint, long>) funcTable[3517164961954622984UL];
            MValueConst_GetList = (delegate* unmanaged[Cdecl]<nint, nint[], byte>) funcTable[7923966564341260495UL];
            MValueConst_GetListSize = (delegate* unmanaged[Cdecl]<nint, ulong>) funcTable[4779387178279277510UL];
            MValueConst_GetRGBA = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) funcTable[5261817276075391869UL];
            MValueConst_GetString = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[15545678503660759154UL];
            MValueConst_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[4825313280512411071UL];
            MValueConst_GetUInt = (delegate* unmanaged[Cdecl]<nint, ulong>) funcTable[17394434301728901815UL];
            MValueConst_GetVector3 = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) funcTable[6939621852607573605UL];
            MValueConst_RemoveRef = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[16719028100610299610UL];
            Object_ActivatePhysics = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[9606374534204341755UL];
            Object_AttachToEntity = (delegate* unmanaged[Cdecl]<nint, nint, short, Vector3, Rotation, byte, byte, byte, void>) funcTable[10514599887053466456UL];
            Object_AttachToEntity_ScriptId = (delegate* unmanaged[Cdecl]<nint, uint, short, Vector3, Rotation, byte, byte, byte, void>) funcTable[15722417851376571847UL];
            Object_Detach = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[17822531205808095184UL];
            Object_GetAlpha = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[16946279683583996943UL];
            Object_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[5993095190208669998UL];
            Object_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[9771131084350658876UL];
            Object_GetLodDistance = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[4347447065271831447UL];
            Object_GetTextureVariation = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[10060423869005405869UL];
            Object_HasGravity = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[13718428067165128397UL];
            Object_IsCollisionEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[5170968123789122622UL];
            Object_IsDynamic = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[13795465085161703016UL];
            Object_IsWorldObject = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[8255652786266033414UL];
            Object_PlaceOnGroundProperly = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[10357990694838043369UL];
            Object_ResetAlpha = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[5312802994075382UL];
            Object_SetAlpha = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[5932338440310697259UL];
            Object_SetLodDistance = (delegate* unmanaged[Cdecl]<nint, ushort, void>) funcTable[10966514812657015763UL];
            Object_SetPositionFrozen = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[2811084004146178600UL];
            Object_SetTextureVariation = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[768646703992673153UL];
            Object_ToggleCollision = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[12664218893021849909UL];
            Object_ToggleGravity = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[6118141396684864939UL];
            Player_GetAimPos = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) funcTable[12055228920754510438UL];
            Player_GetArmor = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[7987175764076571142UL];
            Player_GetCurrentAnimationDict = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[16723753462771656002UL];
            Player_GetCurrentAnimationName = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[14199429433893111373UL];
            Player_GetCurrentWeapon = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[11722701579516800724UL];
            Player_GetCurrentWeaponComponents = (delegate* unmanaged[Cdecl]<nint, UIntArray*, void>) funcTable[903737297265794112UL];
            Player_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[4219554370208343576UL];
            Player_GetEntityAimingAt = (delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint>) funcTable[8756153063636051370UL];
            Player_GetEntityAimOffset = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) funcTable[17052091012239270302UL];
            Player_GetForwardSpeed = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[10477409440198311767UL];
            Player_GetHeadRotation = (delegate* unmanaged[Cdecl]<nint, Rotation*, void>) funcTable[569750430609482447UL];
            Player_GetHealth = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[9627375203842267657UL];
            Player_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[13529169793345329634UL];
            Player_GetMaxArmor = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[18198951985038993902UL];
            Player_GetMaxHealth = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[9580708801779571281UL];
            Player_GetMoveSpeed = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[14116553093415128985UL];
            Player_GetName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[18208358185438436044UL];
            Player_GetSeat = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[17783634308194244054UL];
            Player_GetStrafeSpeed = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[17472156043257663151UL];
            Player_GetVehicle = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[6460458032371095477UL];
            Player_GetVehicleID = (delegate* unmanaged[Cdecl]<nint, ushort*, byte>) funcTable[4282033199082041680UL];
            Player_IsAiming = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[19422907341087170UL];
            Player_IsDead = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[16541873945799242735UL];
            Player_IsFlashlightActive = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[11364144814361369317UL];
            Player_IsInRagdoll = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[18289859726611042969UL];
            Player_IsInVehicle = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[17647219891975255146UL];
            Player_IsJumping = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[2774748351170754987UL];
            Player_IsReloading = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[8442543187693158756UL];
            Player_IsShooting = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[14354912280795983824UL];
            Player_IsSpawned = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[1932704011972581825UL];
            Resource_GetCSharpImpl = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[7961141357174306011UL];
            Resource_GetDependants = (delegate* unmanaged[Cdecl]<nint, nint[], int, void>) funcTable[3527878370801900338UL];
            Resource_GetDependantsSize = (delegate* unmanaged[Cdecl]<nint, int>) funcTable[1156155992924307355UL];
            Resource_GetDependencies = (delegate* unmanaged[Cdecl]<nint, nint[], int, void>) funcTable[15497666607657809255UL];
            Resource_GetDependenciesSize = (delegate* unmanaged[Cdecl]<nint, int>) funcTable[9313014807395764702UL];
            Resource_GetExport = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[16562616898274351656UL];
            Resource_GetExports = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], void>) funcTable[1742568333452740769UL];
            Resource_GetExportsCount = (delegate* unmanaged[Cdecl]<nint, ulong>) funcTable[13732050801943809688UL];
            Resource_GetImpl = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[17439052109499018136UL];
            Resource_GetName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[2004047452491814481UL];
            Resource_GetType = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[6910900490118249642UL];
            Resource_IsStarted = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[7381783592249104347UL];
            Resource_SetExport = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint, void>) funcTable[44213070459954956UL];
            Resource_SetExports = (delegate* unmanaged[Cdecl]<nint, nint, nint[], nint[], int, void>) funcTable[4381924041826262221UL];
            Vehicle_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[7696065235019062903UL];
            Vehicle_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[14290141191345431297UL];
            Vehicle_GetPetrolTankHealth = (delegate* unmanaged[Cdecl]<nint, int>) funcTable[723861135077624300UL];
            Vehicle_GetWheelsCount = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[18205025242291418495UL];
            WorldObject_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[13783539956199648033UL];
            WorldObject_GetPosition = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) funcTable[13686142672988940052UL];
        }
    }
}