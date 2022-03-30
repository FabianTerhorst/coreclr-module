using AltV.Net.Data;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.CApi.Libraries
{
    public unsafe interface IServerLibrary
    {
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> Blip_AttachedTo { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_IsAttached { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Checkpoint_GetCheckpointType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Checkpoint_GetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Checkpoint_GetColShapeType { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Checkpoint_GetHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Checkpoint_GetNextPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Checkpoint_GetRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Checkpoint_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Checkpoint_IsEntityIn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Checkpoint_IsPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Checkpoint_SetCheckpointType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Checkpoint_SetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Checkpoint_SetHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Checkpoint_SetNextPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Checkpoint_SetPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Checkpoint_SetRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> ColShape_GetColShapeType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> ColShape_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> ColShape_IsEntityIn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> ColShape_IsPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> ColShape_SetPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, void> ConnectionInfo_Accept { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, void> ConnectionInfo_AddRef { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, nint, void> ConnectionInfo_Decline { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetAuthToken { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetBranch { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, uint> ConnectionInfo_GetBuild { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetCdnUrl { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetDiscordUserID { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetHwIdExHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetHwIdHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetIp { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, byte> ConnectionInfo_GetIsDebug { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetName { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetPasswordHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetSocialId { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, void> ConnectionInfo_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, Vector3, nint> Core_CreateBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, nint, nint> Core_CreateBlipAttached { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Vector3, float, float, Rgba, nint> Core_CreateCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, nint> Core_CreateColShapeCircle { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, Vector3, nint> Core_CreateColShapeCube { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint> Core_CreateColShapeCylinder { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, Vector2[], int, nint> Core_CreateColShapePolygon { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, nint> Core_CreateColShapeRectangle { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, nint> Core_CreateColShapeSphere { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, Vector3, Rotation, ushort*, nint> Core_CreateVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, nint> Core_CreateVoiceChannel { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocVehicleModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DeleteSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyColShape { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyVoiceChannel { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint*, void> Core_FileRead { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Core_GetNetTime { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetResource { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, void> Core_GetRootDirectory { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint> Core_GetVehicleModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ulong> Core_HashPassword { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_RestartResource { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Core_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_SetPassword { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Core_SetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_StartResource { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_StopResource { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_StopServer { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, CommandCallback, byte> Core_SubscribeCommand { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void> Core_TriggerClientEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerClientEventForAll { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], int, nint, nint[], int, void> Core_TriggerClientEventForSome { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerServerEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Entity_DeleteStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Entity_DeleteSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Entity_GetStreamed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Entity_GetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Entity_SetNetOwner { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation, void> Entity_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetStreamed { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Entity_SetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Entity_SetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Event_Cancel { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Event_PlayerBeforeConnect_Cancel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Event_WasCancelled { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, void> Player_AddWeaponComponent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void> Player_AttachToEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_ClearBloodDamage { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Player_ClearProps { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Player_DeleteLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_Despawn { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_Detach { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetAuthToken { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Cloth*, void> Player_GetClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetCurrentWeaponTintIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, DlcCloth*, void> Player_GetDlcClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, DlcProp*, void> Player_GetDlcProps { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetEyeColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Player_GetFaceFeatureScale { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetHairColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetHairHighlightColor { get; }
        public delegate* unmanaged[Cdecl]<nint, HeadBlendData*, void> Player_GetHeadBlendData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Rgba*, void> Player_GetHeadBlendPaletteColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, HeadOverlay*, void> Player_GetHeadOverlay { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Player_GetHwidExHash { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Player_GetHwidHash { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetInvincible { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetIP { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Player_GetLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetPing { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Prop*, void> Player_GetProps { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Player_GetSocialID { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Player_GetWeaponCount { get; }
        public delegate* unmanaged[Cdecl]<nint, WeaponArray*, void> Player_GetWeapons { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> Player_GetWeaponTintIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, int, byte, void> Player_GiveWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Player_HasLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, byte> Player_HasWeaponComponent { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsConnected { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsCrouching { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Player_IsEntityInStreamingRange { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsStealthy { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsSuperJumpEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Player_Kick { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, uint, void> Player_PlayAmbientSpeech { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_RemoveAllWeapons { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Player_RemoveFaceFeature { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Player_RemoveHeadOverlay { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> Player_RemoveWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, void> Player_RemoveWeaponComponent { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Player_SetArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte, void> Player_SetClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, int, int, int, int, int, int, void> Player_SetDateTime { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte, uint, void> Player_SetDlcClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, uint, void> Player_SetDlcProps { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte> Player_SetEyeColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, byte> Player_SetFaceFeature { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Player_SetHairColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Player_SetHairHighlightColor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, uint, uint, uint, uint, float, float, float, void> Player_SetHeadBlendData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, byte> Player_SetHeadBlendPaletteColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, float, byte> Player_SetHeadOverlay { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, byte> Player_SetHeadOverlayColor { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Player_SetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Player_SetIntoVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Player_SetInvincible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Player_SetLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Player_SetMaxArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Player_SetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, void> Player_SetProps { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte, void> Player_SetWeaponTintIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetWeather { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, uint, void> Player_Spawn { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, void> Resource_GetMain { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, void> Resource_GetPath { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Resource_Start { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Resource_Stop { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void> Vehicle_AttachToEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_Detach { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_DoesWheelHasTire { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetAppearanceDataBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetArmoredWindowHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetArmoredWindowShootCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetAttached { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetAttachedTo { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetBodyAdditionalHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetBodyHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetBumperDamageLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetCustomTires { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetDamageDataBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetDashboardColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetDirtLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetDoorState { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetDriver { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Vehicle_GetDriverID { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Vehicle_GetEngineHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetGameStateBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetHeadlightColor { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetHealthDataBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetInteriorColor { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetLightsMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetLivery { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetLockState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetMod { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetModKit { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetModKitsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetModsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, byte*, byte*, byte*, byte*, void> Vehicle_GetNeonActive { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Vehicle_GetNeonColor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetNumberplateIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetNumberplateText { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetPartBulletHoles { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetPartDamageLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetPearlColor { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Vehicle_GetPetrolTankHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetPrimaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Vehicle_GetPrimaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetRadioStationIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRearWheelVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRepairsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRoofLivery { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRoofState { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetScriptDataBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Vehicle_GetSecondaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSpecialDarkness { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Vehicle_GetTireSmokeColor { get; }
        public delegate* unmanaged[Cdecl]<nint, sbyte> Vehicle_GetTrainCarriageConfigIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, sbyte> Vehicle_GetTrainConfigIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetTrainCruiseSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetTrainDirection { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetTrainDistanceFromEngine { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetTrainEngineId { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetTrainForceDoorsOpen { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetTrainLinkedToBackwardId { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetTrainLinkedToForwardId { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetTrainRenderDerailed { get; }
        public delegate* unmanaged[Cdecl]<nint, sbyte> Vehicle_GetTrainTrackId { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_GetVelocity { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelType { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWindowTint { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_HasArmoredWindows { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_HasTrainPassengerCarriages { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsDaylightOn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsDestroyed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsDriftMode { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsEngineOn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsExtraOn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsFlamethrowerActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsHandbrakeActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsLightDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsManualEngineControl { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsNeonActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsNightlightOn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsPrimaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsSecondaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsSirenActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsSpecialLightDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsTireSmokeColorCustom { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsTrainCaboose { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsTrainEngine { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsTrainMissionTrain { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsWheelBurst { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsWheelDetached { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsWheelOnFire { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsWindowDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsWindowOpened { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_LoadAppearanceDataFromBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_LoadDamageDataFromBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_LoadGameStateFromBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_LoadHealthDataFromBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_LoadScriptDataFromBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_Repair { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetArmoredWindowHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetArmoredWindowShootCount { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_SetBodyAdditionalHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_SetBodyHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetBumperDamageLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetCustomTires { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetDashboardColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetDirtLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetDoorState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetDriftMode { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> Vehicle_SetEngineHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetEngineOn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetHeadlightColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetInteriorColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetLightDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetLightsMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetLivery { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetLockState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetManualEngineControl { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, byte> Vehicle_SetMod { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_SetModKit { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, void> Vehicle_SetNeonActive { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Vehicle_SetNeonColor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_SetNumberplateIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_SetNumberplateText { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetPartBulletHoles { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetPartDamageLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetPearlColor { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> Vehicle_SetPetrolTankHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetPrimaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Vehicle_SetPrimaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_SetRadioStationIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetRearWheels { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetRoofLivery { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetRoofState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint, byte> Vehicle_SetSearchLight { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Vehicle_SetSecondaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetSirenActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetSpecialDarkness { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetSpecialLightDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Vehicle_SetTireSmokeColor { get; }
        public delegate* unmanaged[Cdecl]<nint, sbyte, void> Vehicle_SetTrainCarriageConfigIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, sbyte, void> Vehicle_SetTrainConfigIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetTrainCruiseSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetTrainDirection { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetTrainDistanceFromEngine { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_SetTrainEngineId { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetTrainForceDoorsOpen { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetTrainHasPassengerCarriages { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetTrainIsCaboose { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetTrainIsEngine { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_SetTrainLinkedToBackwardId { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_SetTrainLinkedToForwardId { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetTrainMissionTrain { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetTrainRenderDerailed { get; }
        public delegate* unmanaged[Cdecl]<nint, sbyte, void> Vehicle_SetTrainTrackId { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetWheelBurst { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetWheelColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetWheelDetached { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetWheelFixed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetWheelHasTire { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetWheelHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetWheelOnFire { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetWheels { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetWindowDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetWindowOpened { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetWindowTint { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_ToggleExtra { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_AddPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, void> VoiceChannel_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> VoiceChannel_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, float> VoiceChannel_GetMaxDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> VoiceChannel_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> VoiceChannel_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> VoiceChannel_HasPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> VoiceChannel_IsPlayerMuted { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> VoiceChannel_IsSpatial { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_MutePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_RemovePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, void> VoiceChannel_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> VoiceChannel_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_UnmutePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, int> WorldObject_GetDimension { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> WorldObject_SetDimension { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> WorldObject_SetPosition { get; }
    }

    public unsafe class ServerLibrary : IServerLibrary
    {
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> Blip_AttachedTo { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_IsAttached { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Checkpoint_GetCheckpointType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Checkpoint_GetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Checkpoint_GetColShapeType { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Checkpoint_GetHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Checkpoint_GetNextPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Checkpoint_GetRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Checkpoint_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Checkpoint_IsEntityIn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Checkpoint_IsPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Checkpoint_SetCheckpointType { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Checkpoint_SetColor { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Checkpoint_SetHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Checkpoint_SetNextPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Checkpoint_SetPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Checkpoint_SetRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> ColShape_GetColShapeType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> ColShape_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> ColShape_IsEntityIn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> ColShape_IsPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> ColShape_SetPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, void> ConnectionInfo_Accept { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, void> ConnectionInfo_AddRef { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, nint, void> ConnectionInfo_Decline { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetAuthToken { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetBranch { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, uint> ConnectionInfo_GetBuild { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetCdnUrl { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetDiscordUserID { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetHwIdExHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetHwIdHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetIp { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, byte> ConnectionInfo_GetIsDebug { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetName { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetPasswordHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetSocialId { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, void> ConnectionInfo_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, Vector3, nint> Core_CreateBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, nint, nint> Core_CreateBlipAttached { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Vector3, float, float, Rgba, nint> Core_CreateCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, nint> Core_CreateColShapeCircle { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, Vector3, nint> Core_CreateColShapeCube { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint> Core_CreateColShapeCylinder { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, Vector2[], int, nint> Core_CreateColShapePolygon { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, nint> Core_CreateColShapeRectangle { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, nint> Core_CreateColShapeSphere { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, Vector3, Rotation, ushort*, nint> Core_CreateVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, nint> Core_CreateVoiceChannel { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocVehicleModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DeleteSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyColShape { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyVoiceChannel { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint*, void> Core_FileRead { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Core_GetNetTime { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetResource { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, void> Core_GetRootDirectory { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint> Core_GetVehicleModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ulong> Core_HashPassword { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_RestartResource { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Core_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_SetPassword { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Core_SetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_StartResource { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_StopResource { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_StopServer { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, CommandCallback, byte> Core_SubscribeCommand { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void> Core_TriggerClientEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerClientEventForAll { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], int, nint, nint[], int, void> Core_TriggerClientEventForSome { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerServerEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Entity_DeleteStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Entity_DeleteSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Entity_GetStreamed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Entity_GetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Entity_SetNetOwner { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation, void> Entity_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetStreamed { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Entity_SetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Entity_SetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Event_Cancel { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Event_PlayerBeforeConnect_Cancel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Event_WasCancelled { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, void> Player_AddWeaponComponent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void> Player_AttachToEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_ClearBloodDamage { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Player_ClearProps { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Player_DeleteLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_Despawn { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_Detach { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetAuthToken { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Cloth*, void> Player_GetClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetCurrentWeaponTintIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, DlcCloth*, void> Player_GetDlcClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, DlcProp*, void> Player_GetDlcProps { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetEyeColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Player_GetFaceFeatureScale { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetHairColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetHairHighlightColor { get; }
        public delegate* unmanaged[Cdecl]<nint, HeadBlendData*, void> Player_GetHeadBlendData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Rgba*, void> Player_GetHeadBlendPaletteColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, HeadOverlay*, void> Player_GetHeadOverlay { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Player_GetHwidExHash { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Player_GetHwidHash { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetInvincible { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetIP { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Player_GetLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetPing { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Prop*, void> Player_GetProps { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Player_GetSocialID { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Player_GetWeaponCount { get; }
        public delegate* unmanaged[Cdecl]<nint, WeaponArray*, void> Player_GetWeapons { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> Player_GetWeaponTintIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, int, byte, void> Player_GiveWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Player_HasLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, byte> Player_HasWeaponComponent { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsConnected { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsCrouching { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Player_IsEntityInStreamingRange { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsStealthy { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsSuperJumpEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Player_Kick { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, uint, void> Player_PlayAmbientSpeech { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_RemoveAllWeapons { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Player_RemoveFaceFeature { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Player_RemoveHeadOverlay { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> Player_RemoveWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, void> Player_RemoveWeaponComponent { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Player_SetArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte, void> Player_SetClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, int, int, int, int, int, int, void> Player_SetDateTime { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte, uint, void> Player_SetDlcClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, uint, void> Player_SetDlcProps { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte> Player_SetEyeColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, byte> Player_SetFaceFeature { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Player_SetHairColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Player_SetHairHighlightColor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, uint, uint, uint, uint, float, float, float, void> Player_SetHeadBlendData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, byte> Player_SetHeadBlendPaletteColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, float, byte> Player_SetHeadOverlay { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, byte> Player_SetHeadOverlayColor { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Player_SetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Player_SetIntoVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Player_SetInvincible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Player_SetLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Player_SetMaxArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Player_SetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, void> Player_SetProps { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte, void> Player_SetWeaponTintIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetWeather { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, uint, void> Player_Spawn { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, void> Resource_GetMain { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, void> Resource_GetPath { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Resource_Start { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Resource_Stop { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void> Vehicle_AttachToEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_Detach { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_DoesWheelHasTire { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetAppearanceDataBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetArmoredWindowHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetArmoredWindowShootCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetAttached { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetAttachedTo { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetBodyAdditionalHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetBodyHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetBumperDamageLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetCustomTires { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetDamageDataBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetDashboardColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetDirtLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetDoorState { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetDriver { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Vehicle_GetDriverID { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Vehicle_GetEngineHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetGameStateBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetHeadlightColor { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetHealthDataBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetInteriorColor { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetLightsMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetLivery { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetLockState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetMod { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetModKit { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetModKitsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetModsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, byte*, byte*, byte*, byte*, void> Vehicle_GetNeonActive { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Vehicle_GetNeonColor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetNumberplateIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetNumberplateText { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetPartBulletHoles { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetPartDamageLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetPearlColor { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Vehicle_GetPetrolTankHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetPrimaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Vehicle_GetPrimaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetRadioStationIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRearWheelVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRepairsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRoofLivery { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRoofState { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetScriptDataBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Vehicle_GetSecondaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSpecialDarkness { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Vehicle_GetTireSmokeColor { get; }
        public delegate* unmanaged[Cdecl]<nint, sbyte> Vehicle_GetTrainCarriageConfigIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, sbyte> Vehicle_GetTrainConfigIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetTrainCruiseSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetTrainDirection { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetTrainDistanceFromEngine { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetTrainEngineId { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetTrainForceDoorsOpen { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetTrainLinkedToBackwardId { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetTrainLinkedToForwardId { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetTrainRenderDerailed { get; }
        public delegate* unmanaged[Cdecl]<nint, sbyte> Vehicle_GetTrainTrackId { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_GetVelocity { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelType { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWindowTint { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_HasArmoredWindows { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_HasTrainPassengerCarriages { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsDaylightOn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsDestroyed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsDriftMode { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsEngineOn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsExtraOn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsFlamethrowerActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsHandbrakeActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsLightDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsManualEngineControl { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsNeonActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsNightlightOn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsPrimaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsSecondaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsSirenActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsSpecialLightDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsTireSmokeColorCustom { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsTrainCaboose { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsTrainEngine { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsTrainMissionTrain { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsWheelBurst { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsWheelDetached { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsWheelOnFire { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsWindowDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_IsWindowOpened { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_LoadAppearanceDataFromBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_LoadDamageDataFromBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_LoadGameStateFromBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_LoadHealthDataFromBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_LoadScriptDataFromBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_Repair { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetArmoredWindowHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetArmoredWindowShootCount { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_SetBodyAdditionalHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_SetBodyHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetBumperDamageLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetCustomTires { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetDashboardColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetDirtLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetDoorState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetDriftMode { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> Vehicle_SetEngineHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetEngineOn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetHeadlightColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetInteriorColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetLightDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetLightsMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetLivery { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetLockState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetManualEngineControl { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, byte> Vehicle_SetMod { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_SetModKit { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, void> Vehicle_SetNeonActive { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Vehicle_SetNeonColor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_SetNumberplateIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_SetNumberplateText { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetPartBulletHoles { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetPartDamageLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetPearlColor { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> Vehicle_SetPetrolTankHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetPrimaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Vehicle_SetPrimaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_SetRadioStationIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetRearWheels { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetRoofLivery { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetRoofState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint, byte> Vehicle_SetSearchLight { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Vehicle_SetSecondaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetSirenActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetSpecialDarkness { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetSpecialLightDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Vehicle_SetTireSmokeColor { get; }
        public delegate* unmanaged[Cdecl]<nint, sbyte, void> Vehicle_SetTrainCarriageConfigIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, sbyte, void> Vehicle_SetTrainConfigIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetTrainCruiseSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetTrainDirection { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetTrainDistanceFromEngine { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_SetTrainEngineId { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetTrainForceDoorsOpen { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetTrainHasPassengerCarriages { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetTrainIsCaboose { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetTrainIsEngine { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_SetTrainLinkedToBackwardId { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Vehicle_SetTrainLinkedToForwardId { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetTrainMissionTrain { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetTrainRenderDerailed { get; }
        public delegate* unmanaged[Cdecl]<nint, sbyte, void> Vehicle_SetTrainTrackId { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetWheelBurst { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetWheelColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetWheelDetached { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetWheelFixed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetWheelHasTire { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetWheelHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetWheelOnFire { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetWheels { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetWindowDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetWindowOpened { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetWindowTint { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_ToggleExtra { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_AddPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, void> VoiceChannel_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> VoiceChannel_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, float> VoiceChannel_GetMaxDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> VoiceChannel_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> VoiceChannel_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> VoiceChannel_HasPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> VoiceChannel_IsPlayerMuted { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> VoiceChannel_IsSpatial { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_MutePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_RemovePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, void> VoiceChannel_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> VoiceChannel_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_UnmutePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, int> WorldObject_GetDimension { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> WorldObject_SetDimension { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> WorldObject_SetPosition { get; }
        public ServerLibrary(string dllName)
        {
            const DllImportSearchPath dllImportSearchPath = DllImportSearchPath.LegacyBehavior | DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories | DllImportSearchPath.System32 | DllImportSearchPath.UserDirectories | DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UseDllDirectoryForDependencies;
            var handle = NativeLibrary.Load(dllName, Assembly.GetExecutingAssembly(), dllImportSearchPath);
            Blip_AttachedTo = (delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint>) NativeLibrary.GetExport(handle, "Blip_AttachedTo");
            Blip_IsAttached = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Blip_IsAttached");
            Checkpoint_GetCheckpointType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Checkpoint_GetCheckpointType");
            Checkpoint_GetColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) NativeLibrary.GetExport(handle, "Checkpoint_GetColor");
            Checkpoint_GetColShapeType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Checkpoint_GetColShapeType");
            Checkpoint_GetHeight = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Checkpoint_GetHeight");
            Checkpoint_GetNextPosition = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Checkpoint_GetNextPosition");
            Checkpoint_GetRadius = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Checkpoint_GetRadius");
            Checkpoint_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Checkpoint_GetWorldObject");
            Checkpoint_IsEntityIn = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Checkpoint_IsEntityIn");
            Checkpoint_IsPlayersOnly = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Checkpoint_IsPlayersOnly");
            Checkpoint_SetCheckpointType = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Checkpoint_SetCheckpointType");
            Checkpoint_SetColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) NativeLibrary.GetExport(handle, "Checkpoint_SetColor");
            Checkpoint_SetHeight = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Checkpoint_SetHeight");
            Checkpoint_SetNextPosition = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) NativeLibrary.GetExport(handle, "Checkpoint_SetNextPosition");
            Checkpoint_SetPlayersOnly = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Checkpoint_SetPlayersOnly");
            Checkpoint_SetRadius = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Checkpoint_SetRadius");
            ColShape_GetColShapeType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "ColShape_GetColShapeType");
            ColShape_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "ColShape_GetWorldObject");
            ColShape_IsEntityIn = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "ColShape_IsEntityIn");
            ColShape_IsPlayersOnly = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "ColShape_IsPlayersOnly");
            ColShape_SetPlayersOnly = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "ColShape_SetPlayersOnly");
            ConnectionInfo_Accept = (delegate* unmanaged[Cdecl]<IntPtr, void>) NativeLibrary.GetExport(handle, "ConnectionInfo_Accept");
            ConnectionInfo_AddRef = (delegate* unmanaged[Cdecl]<IntPtr, void>) NativeLibrary.GetExport(handle, "ConnectionInfo_AddRef");
            ConnectionInfo_Decline = (delegate* unmanaged[Cdecl]<IntPtr, nint, void>) NativeLibrary.GetExport(handle, "ConnectionInfo_Decline");
            ConnectionInfo_GetAuthToken = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) NativeLibrary.GetExport(handle, "ConnectionInfo_GetAuthToken");
            ConnectionInfo_GetBranch = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) NativeLibrary.GetExport(handle, "ConnectionInfo_GetBranch");
            ConnectionInfo_GetBuild = (delegate* unmanaged[Cdecl]<IntPtr, uint>) NativeLibrary.GetExport(handle, "ConnectionInfo_GetBuild");
            ConnectionInfo_GetCdnUrl = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) NativeLibrary.GetExport(handle, "ConnectionInfo_GetCdnUrl");
            ConnectionInfo_GetDiscordUserID = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) NativeLibrary.GetExport(handle, "ConnectionInfo_GetDiscordUserID");
            ConnectionInfo_GetHwIdExHash = (delegate* unmanaged[Cdecl]<IntPtr, ulong>) NativeLibrary.GetExport(handle, "ConnectionInfo_GetHwIdExHash");
            ConnectionInfo_GetHwIdHash = (delegate* unmanaged[Cdecl]<IntPtr, ulong>) NativeLibrary.GetExport(handle, "ConnectionInfo_GetHwIdHash");
            ConnectionInfo_GetIp = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) NativeLibrary.GetExport(handle, "ConnectionInfo_GetIp");
            ConnectionInfo_GetIsDebug = (delegate* unmanaged[Cdecl]<IntPtr, byte>) NativeLibrary.GetExport(handle, "ConnectionInfo_GetIsDebug");
            ConnectionInfo_GetName = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) NativeLibrary.GetExport(handle, "ConnectionInfo_GetName");
            ConnectionInfo_GetPasswordHash = (delegate* unmanaged[Cdecl]<IntPtr, ulong>) NativeLibrary.GetExport(handle, "ConnectionInfo_GetPasswordHash");
            ConnectionInfo_GetSocialId = (delegate* unmanaged[Cdecl]<IntPtr, ulong>) NativeLibrary.GetExport(handle, "ConnectionInfo_GetSocialId");
            ConnectionInfo_RemoveRef = (delegate* unmanaged[Cdecl]<IntPtr, void>) NativeLibrary.GetExport(handle, "ConnectionInfo_RemoveRef");
            Core_CreateBlip = (delegate* unmanaged[Cdecl]<nint, nint, byte, Vector3, nint>) NativeLibrary.GetExport(handle, "Core_CreateBlip");
            Core_CreateBlipAttached = (delegate* unmanaged[Cdecl]<nint, nint, byte, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateBlipAttached");
            Core_CreateCheckpoint = (delegate* unmanaged[Cdecl]<nint, byte, Vector3, float, float, Rgba, nint>) NativeLibrary.GetExport(handle, "Core_CreateCheckpoint");
            Core_CreateColShapeCircle = (delegate* unmanaged[Cdecl]<nint, Vector3, float, nint>) NativeLibrary.GetExport(handle, "Core_CreateColShapeCircle");
            Core_CreateColShapeCube = (delegate* unmanaged[Cdecl]<nint, Vector3, Vector3, nint>) NativeLibrary.GetExport(handle, "Core_CreateColShapeCube");
            Core_CreateColShapeCylinder = (delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint>) NativeLibrary.GetExport(handle, "Core_CreateColShapeCylinder");
            Core_CreateColShapePolygon = (delegate* unmanaged[Cdecl]<nint, float, float, Vector2[], int, nint>) NativeLibrary.GetExport(handle, "Core_CreateColShapePolygon");
            Core_CreateColShapeRectangle = (delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, nint>) NativeLibrary.GetExport(handle, "Core_CreateColShapeRectangle");
            Core_CreateColShapeSphere = (delegate* unmanaged[Cdecl]<nint, Vector3, float, nint>) NativeLibrary.GetExport(handle, "Core_CreateColShapeSphere");
            Core_CreateVehicle = (delegate* unmanaged[Cdecl]<nint, uint, Vector3, Rotation, ushort*, nint>) NativeLibrary.GetExport(handle, "Core_CreateVehicle");
            Core_CreateVoiceChannel = (delegate* unmanaged[Cdecl]<nint, byte, float, nint>) NativeLibrary.GetExport(handle, "Core_CreateVoiceChannel");
            Core_DeallocVehicleModelInfo = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Core_DeallocVehicleModelInfo");
            Core_DeleteMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_DeleteMetaData");
            Core_DeleteSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_DeleteSyncedMetaData");
            Core_DestroyCheckpoint = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_DestroyCheckpoint");
            Core_DestroyColShape = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_DestroyColShape");
            Core_DestroyVehicle = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_DestroyVehicle");
            Core_DestroyVoiceChannel = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_DestroyVoiceChannel");
            Core_FileExists = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_FileExists");
            Core_FileRead = (delegate* unmanaged[Cdecl]<nint, nint, nint*, void>) NativeLibrary.GetExport(handle, "Core_FileRead");
            Core_GetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_GetMetaData");
            Core_GetNetTime = (delegate* unmanaged[Cdecl]<nint, int>) NativeLibrary.GetExport(handle, "Core_GetNetTime");
            Core_GetResource = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_GetResource");
            Core_GetRootDirectory = (delegate* unmanaged[Cdecl]<nint, nint*, void>) NativeLibrary.GetExport(handle, "Core_GetRootDirectory");
            Core_GetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_GetSyncedMetaData");
            Core_GetVehicleModelInfo = (delegate* unmanaged[Cdecl]<nint, uint, nint>) NativeLibrary.GetExport(handle, "Core_GetVehicleModelInfo");
            Core_HashPassword = (delegate* unmanaged[Cdecl]<nint, nint, ulong>) NativeLibrary.GetExport(handle, "Core_HashPassword");
            Core_HasMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_HasMetaData");
            Core_HasSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_HasSyncedMetaData");
            Core_RestartResource = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_RestartResource");
            Core_SetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "Core_SetMetaData");
            Core_SetPassword = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_SetPassword");
            Core_SetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "Core_SetSyncedMetaData");
            Core_StartResource = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_StartResource");
            Core_StopResource = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_StopResource");
            Core_StopServer = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Core_StopServer");
            Core_SubscribeCommand = (delegate* unmanaged[Cdecl]<nint, nint, CommandCallback, byte>) NativeLibrary.GetExport(handle, "Core_SubscribeCommand");
            Core_TriggerClientEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void>) NativeLibrary.GetExport(handle, "Core_TriggerClientEvent");
            Core_TriggerClientEventForAll = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) NativeLibrary.GetExport(handle, "Core_TriggerClientEventForAll");
            Core_TriggerClientEventForSome = (delegate* unmanaged[Cdecl]<nint, nint[], int, nint, nint[], int, void>) NativeLibrary.GetExport(handle, "Core_TriggerClientEventForSome");
            Core_TriggerServerEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) NativeLibrary.GetExport(handle, "Core_TriggerServerEvent");
            Entity_DeleteStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Entity_DeleteStreamSyncedMetaData");
            Entity_DeleteSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Entity_DeleteSyncedMetaData");
            Entity_GetStreamed = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Entity_GetStreamed");
            Entity_GetVisible = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Entity_GetVisible");
            Entity_SetNetOwner = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) NativeLibrary.GetExport(handle, "Entity_SetNetOwner");
            Entity_SetRotation = (delegate* unmanaged[Cdecl]<nint, Rotation, void>) NativeLibrary.GetExport(handle, "Entity_SetRotation");
            Entity_SetStreamed = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Entity_SetStreamed");
            Entity_SetStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "Entity_SetStreamSyncedMetaData");
            Entity_SetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "Entity_SetSyncedMetaData");
            Entity_SetVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Entity_SetVisible");
            Event_Cancel = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Event_Cancel");
            Event_PlayerBeforeConnect_Cancel = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Event_PlayerBeforeConnect_Cancel");
            Event_WasCancelled = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Event_WasCancelled");
            Player_AddWeaponComponent = (delegate* unmanaged[Cdecl]<nint, uint, uint, void>) NativeLibrary.GetExport(handle, "Player_AddWeaponComponent");
            Player_AttachToEntity = (delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void>) NativeLibrary.GetExport(handle, "Player_AttachToEntity");
            Player_ClearBloodDamage = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Player_ClearBloodDamage");
            Player_ClearProps = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Player_ClearProps");
            Player_DeleteLocalMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Player_DeleteLocalMetaData");
            Player_Despawn = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Player_Despawn");
            Player_Detach = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Player_Detach");
            Player_GetAuthToken = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Player_GetAuthToken");
            Player_GetClothes = (delegate* unmanaged[Cdecl]<nint, byte, Cloth*, void>) NativeLibrary.GetExport(handle, "Player_GetClothes");
            Player_GetCurrentWeaponTintIndex = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_GetCurrentWeaponTintIndex");
            Player_GetDlcClothes = (delegate* unmanaged[Cdecl]<nint, byte, DlcCloth*, void>) NativeLibrary.GetExport(handle, "Player_GetDlcClothes");
            Player_GetDlcProps = (delegate* unmanaged[Cdecl]<nint, byte, DlcProp*, void>) NativeLibrary.GetExport(handle, "Player_GetDlcProps");
            Player_GetEyeColor = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetEyeColor");
            Player_GetFaceFeatureScale = (delegate* unmanaged[Cdecl]<nint, byte, float>) NativeLibrary.GetExport(handle, "Player_GetFaceFeatureScale");
            Player_GetHairColor = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_GetHairColor");
            Player_GetHairHighlightColor = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_GetHairHighlightColor");
            Player_GetHeadBlendData = (delegate* unmanaged[Cdecl]<nint, HeadBlendData*, void>) NativeLibrary.GetExport(handle, "Player_GetHeadBlendData");
            Player_GetHeadBlendPaletteColor = (delegate* unmanaged[Cdecl]<nint, byte, Rgba*, void>) NativeLibrary.GetExport(handle, "Player_GetHeadBlendPaletteColor");
            Player_GetHeadOverlay = (delegate* unmanaged[Cdecl]<nint, byte, HeadOverlay*, void>) NativeLibrary.GetExport(handle, "Player_GetHeadOverlay");
            Player_GetHwidExHash = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "Player_GetHwidExHash");
            Player_GetHwidHash = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "Player_GetHwidHash");
            Player_GetInvincible = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_GetInvincible");
            Player_GetIP = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Player_GetIP");
            Player_GetLocalMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Player_GetLocalMetaData");
            Player_GetPing = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Player_GetPing");
            Player_GetProps = (delegate* unmanaged[Cdecl]<nint, byte, Prop*, void>) NativeLibrary.GetExport(handle, "Player_GetProps");
            Player_GetSocialID = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "Player_GetSocialID");
            Player_GetWeaponCount = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "Player_GetWeaponCount");
            Player_GetWeapons = (delegate* unmanaged[Cdecl]<nint, WeaponArray*, void>) NativeLibrary.GetExport(handle, "Player_GetWeapons");
            Player_GetWeaponTintIndex = (delegate* unmanaged[Cdecl]<nint, uint, byte>) NativeLibrary.GetExport(handle, "Player_GetWeaponTintIndex");
            Player_GiveWeapon = (delegate* unmanaged[Cdecl]<nint, uint, int, byte, void>) NativeLibrary.GetExport(handle, "Player_GiveWeapon");
            Player_HasLocalMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Player_HasLocalMetaData");
            Player_HasWeaponComponent = (delegate* unmanaged[Cdecl]<nint, uint, uint, byte>) NativeLibrary.GetExport(handle, "Player_HasWeaponComponent");
            Player_IsConnected = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsConnected");
            Player_IsCrouching = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsCrouching");
            Player_IsEntityInStreamingRange = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Player_IsEntityInStreamingRange");
            Player_IsStealthy = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsStealthy");
            Player_IsSuperJumpEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsSuperJumpEnabled");
            Player_Kick = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Player_Kick");
            Player_PlayAmbientSpeech = (delegate* unmanaged[Cdecl]<nint, nint, nint, uint, void>) NativeLibrary.GetExport(handle, "Player_PlayAmbientSpeech");
            Player_RemoveAllWeapons = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Player_RemoveAllWeapons");
            Player_RemoveFaceFeature = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Player_RemoveFaceFeature");
            Player_RemoveHeadOverlay = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Player_RemoveHeadOverlay");
            Player_RemoveWeapon = (delegate* unmanaged[Cdecl]<nint, uint, byte>) NativeLibrary.GetExport(handle, "Player_RemoveWeapon");
            Player_RemoveWeaponComponent = (delegate* unmanaged[Cdecl]<nint, uint, uint, void>) NativeLibrary.GetExport(handle, "Player_RemoveWeaponComponent");
            Player_SetArmor = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Player_SetArmor");
            Player_SetClothes = (delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte, void>) NativeLibrary.GetExport(handle, "Player_SetClothes");
            Player_SetCurrentWeapon = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Player_SetCurrentWeapon");
            Player_SetDateTime = (delegate* unmanaged[Cdecl]<nint, int, int, int, int, int, int, void>) NativeLibrary.GetExport(handle, "Player_SetDateTime");
            Player_SetDlcClothes = (delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte, uint, void>) NativeLibrary.GetExport(handle, "Player_SetDlcClothes");
            Player_SetDlcProps = (delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, uint, void>) NativeLibrary.GetExport(handle, "Player_SetDlcProps");
            Player_SetEyeColor = (delegate* unmanaged[Cdecl]<nint, ushort, byte>) NativeLibrary.GetExport(handle, "Player_SetEyeColor");
            Player_SetFaceFeature = (delegate* unmanaged[Cdecl]<nint, byte, float, byte>) NativeLibrary.GetExport(handle, "Player_SetFaceFeature");
            Player_SetHairColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Player_SetHairColor");
            Player_SetHairHighlightColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Player_SetHairHighlightColor");
            Player_SetHeadBlendData = (delegate* unmanaged[Cdecl]<nint, uint, uint, uint, uint, uint, uint, float, float, float, void>) NativeLibrary.GetExport(handle, "Player_SetHeadBlendData");
            Player_SetHeadBlendPaletteColor = (delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, byte>) NativeLibrary.GetExport(handle, "Player_SetHeadBlendPaletteColor");
            Player_SetHeadOverlay = (delegate* unmanaged[Cdecl]<nint, byte, byte, float, byte>) NativeLibrary.GetExport(handle, "Player_SetHeadOverlay");
            Player_SetHeadOverlayColor = (delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, byte>) NativeLibrary.GetExport(handle, "Player_SetHeadOverlayColor");
            Player_SetHealth = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Player_SetHealth");
            Player_SetIntoVehicle = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) NativeLibrary.GetExport(handle, "Player_SetIntoVehicle");
            Player_SetInvincible = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Player_SetInvincible");
            Player_SetLocalMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "Player_SetLocalMetaData");
            Player_SetMaxArmor = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Player_SetMaxArmor");
            Player_SetMaxHealth = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Player_SetMaxHealth");
            Player_SetModel = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Player_SetModel");
            Player_SetProps = (delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, void>) NativeLibrary.GetExport(handle, "Player_SetProps");
            Player_SetWeaponTintIndex = (delegate* unmanaged[Cdecl]<nint, uint, byte, void>) NativeLibrary.GetExport(handle, "Player_SetWeaponTintIndex");
            Player_SetWeather = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Player_SetWeather");
            Player_Spawn = (delegate* unmanaged[Cdecl]<nint, Vector3, uint, void>) NativeLibrary.GetExport(handle, "Player_Spawn");
            Resource_GetMain = (delegate* unmanaged[Cdecl]<nint, nint*, void>) NativeLibrary.GetExport(handle, "Resource_GetMain");
            Resource_GetPath = (delegate* unmanaged[Cdecl]<nint, nint*, void>) NativeLibrary.GetExport(handle, "Resource_GetPath");
            Resource_Start = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Resource_Start");
            Resource_Stop = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Resource_Stop");
            Vehicle_AttachToEntity = (delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_AttachToEntity");
            Vehicle_Detach = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Vehicle_Detach");
            Vehicle_DoesWheelHasTire = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_DoesWheelHasTire");
            Vehicle_GetAppearanceDataBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetAppearanceDataBase64");
            Vehicle_GetArmoredWindowHealth = (delegate* unmanaged[Cdecl]<nint, byte, float>) NativeLibrary.GetExport(handle, "Vehicle_GetArmoredWindowHealth");
            Vehicle_GetArmoredWindowShootCount = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetArmoredWindowShootCount");
            Vehicle_GetAttached = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetAttached");
            Vehicle_GetAttachedTo = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetAttachedTo");
            Vehicle_GetBodyAdditionalHealth = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_GetBodyAdditionalHealth");
            Vehicle_GetBodyHealth = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_GetBodyHealth");
            Vehicle_GetBumperDamageLevel = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetBumperDamageLevel");
            Vehicle_GetCustomTires = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetCustomTires");
            Vehicle_GetDamageDataBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetDamageDataBase64");
            Vehicle_GetDashboardColor = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetDashboardColor");
            Vehicle_GetDirtLevel = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetDirtLevel");
            Vehicle_GetDoorState = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetDoorState");
            Vehicle_GetDriver = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetDriver");
            Vehicle_GetDriverID = (delegate* unmanaged[Cdecl]<nint, ushort*, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetDriverID");
            Vehicle_GetEngineHealth = (delegate* unmanaged[Cdecl]<nint, int>) NativeLibrary.GetExport(handle, "Vehicle_GetEngineHealth");
            Vehicle_GetGameStateBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetGameStateBase64");
            Vehicle_GetHeadlightColor = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetHeadlightColor");
            Vehicle_GetHealthDataBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetHealthDataBase64");
            Vehicle_GetInteriorColor = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetInteriorColor");
            Vehicle_GetLightsMultiplier = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_GetLightsMultiplier");
            Vehicle_GetLivery = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetLivery");
            Vehicle_GetLockState = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetLockState");
            Vehicle_GetMod = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetMod");
            Vehicle_GetModKit = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetModKit");
            Vehicle_GetModKitsCount = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetModKitsCount");
            Vehicle_GetModsCount = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetModsCount");
            Vehicle_GetNeonActive = (delegate* unmanaged[Cdecl]<nint, byte*, byte*, byte*, byte*, void>) NativeLibrary.GetExport(handle, "Vehicle_GetNeonActive");
            Vehicle_GetNeonColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) NativeLibrary.GetExport(handle, "Vehicle_GetNeonColor");
            Vehicle_GetNumberplateIndex = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_GetNumberplateIndex");
            Vehicle_GetNumberplateText = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetNumberplateText");
            Vehicle_GetPartBulletHoles = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetPartBulletHoles");
            Vehicle_GetPartDamageLevel = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetPartDamageLevel");
            Vehicle_GetPearlColor = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetPearlColor");
            Vehicle_GetPetrolTankHealth = (delegate* unmanaged[Cdecl]<nint, int>) NativeLibrary.GetExport(handle, "Vehicle_GetPetrolTankHealth");
            Vehicle_GetPrimaryColor = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetPrimaryColor");
            Vehicle_GetPrimaryColorRGB = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) NativeLibrary.GetExport(handle, "Vehicle_GetPrimaryColorRGB");
            Vehicle_GetRadioStationIndex = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_GetRadioStationIndex");
            Vehicle_GetRearWheelVariation = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetRearWheelVariation");
            Vehicle_GetRepairsCount = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetRepairsCount");
            Vehicle_GetRoofLivery = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetRoofLivery");
            Vehicle_GetRoofState = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetRoofState");
            Vehicle_GetScriptDataBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetScriptDataBase64");
            Vehicle_GetSecondaryColor = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetSecondaryColor");
            Vehicle_GetSecondaryColorRGB = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) NativeLibrary.GetExport(handle, "Vehicle_GetSecondaryColorRGB");
            Vehicle_GetSpecialDarkness = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetSpecialDarkness");
            Vehicle_GetTireSmokeColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) NativeLibrary.GetExport(handle, "Vehicle_GetTireSmokeColor");
            Vehicle_GetTrainCarriageConfigIndex = (delegate* unmanaged[Cdecl]<nint, sbyte>) NativeLibrary.GetExport(handle, "Vehicle_GetTrainCarriageConfigIndex");
            Vehicle_GetTrainConfigIndex = (delegate* unmanaged[Cdecl]<nint, sbyte>) NativeLibrary.GetExport(handle, "Vehicle_GetTrainConfigIndex");
            Vehicle_GetTrainCruiseSpeed = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_GetTrainCruiseSpeed");
            Vehicle_GetTrainDirection = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetTrainDirection");
            Vehicle_GetTrainDistanceFromEngine = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_GetTrainDistanceFromEngine");
            Vehicle_GetTrainEngineId = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetTrainEngineId");
            Vehicle_GetTrainForceDoorsOpen = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetTrainForceDoorsOpen");
            Vehicle_GetTrainLinkedToBackwardId = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetTrainLinkedToBackwardId");
            Vehicle_GetTrainLinkedToForwardId = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetTrainLinkedToForwardId");
            Vehicle_GetTrainRenderDerailed = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetTrainRenderDerailed");
            Vehicle_GetTrainTrackId = (delegate* unmanaged[Cdecl]<nint, sbyte>) NativeLibrary.GetExport(handle, "Vehicle_GetTrainTrackId");
            Vehicle_GetVelocity = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Vehicle_GetVelocity");
            Vehicle_GetWheelColor = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetWheelColor");
            Vehicle_GetWheelHealth = (delegate* unmanaged[Cdecl]<nint, byte, float>) NativeLibrary.GetExport(handle, "Vehicle_GetWheelHealth");
            Vehicle_GetWheelType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetWheelType");
            Vehicle_GetWheelVariation = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetWheelVariation");
            Vehicle_GetWindowTint = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetWindowTint");
            Vehicle_HasArmoredWindows = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_HasArmoredWindows");
            Vehicle_HasTrainPassengerCarriages = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_HasTrainPassengerCarriages");
            Vehicle_IsDaylightOn = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsDaylightOn");
            Vehicle_IsDestroyed = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsDestroyed");
            Vehicle_IsDriftMode = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsDriftMode");
            Vehicle_IsEngineOn = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsEngineOn");
            Vehicle_IsExtraOn = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsExtraOn");
            Vehicle_IsFlamethrowerActive = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsFlamethrowerActive");
            Vehicle_IsHandbrakeActive = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsHandbrakeActive");
            Vehicle_IsLightDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsLightDamaged");
            Vehicle_IsManualEngineControl = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsManualEngineControl");
            Vehicle_IsNeonActive = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsNeonActive");
            Vehicle_IsNightlightOn = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsNightlightOn");
            Vehicle_IsPrimaryColorRGB = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsPrimaryColorRGB");
            Vehicle_IsSecondaryColorRGB = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsSecondaryColorRGB");
            Vehicle_IsSirenActive = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsSirenActive");
            Vehicle_IsSpecialLightDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsSpecialLightDamaged");
            Vehicle_IsTireSmokeColorCustom = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsTireSmokeColorCustom");
            Vehicle_IsTrainCaboose = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsTrainCaboose");
            Vehicle_IsTrainEngine = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsTrainEngine");
            Vehicle_IsTrainMissionTrain = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsTrainMissionTrain");
            Vehicle_IsWheelBurst = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsWheelBurst");
            Vehicle_IsWheelDetached = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsWheelDetached");
            Vehicle_IsWheelOnFire = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsWheelOnFire");
            Vehicle_IsWindowDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsWindowDamaged");
            Vehicle_IsWindowOpened = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsWindowOpened");
            Vehicle_LoadAppearanceDataFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Vehicle_LoadAppearanceDataFromBase64");
            Vehicle_LoadDamageDataFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Vehicle_LoadDamageDataFromBase64");
            Vehicle_LoadGameStateFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Vehicle_LoadGameStateFromBase64");
            Vehicle_LoadHealthDataFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Vehicle_LoadHealthDataFromBase64");
            Vehicle_LoadScriptDataFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Vehicle_LoadScriptDataFromBase64");
            Vehicle_Repair = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Vehicle_Repair");
            Vehicle_SetArmoredWindowHealth = (delegate* unmanaged[Cdecl]<nint, byte, float, void>) NativeLibrary.GetExport(handle, "Vehicle_SetArmoredWindowHealth");
            Vehicle_SetArmoredWindowShootCount = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetArmoredWindowShootCount");
            Vehicle_SetBodyAdditionalHealth = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Vehicle_SetBodyAdditionalHealth");
            Vehicle_SetBodyHealth = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Vehicle_SetBodyHealth");
            Vehicle_SetBumperDamageLevel = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetBumperDamageLevel");
            Vehicle_SetCustomTires = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetCustomTires");
            Vehicle_SetDashboardColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetDashboardColor");
            Vehicle_SetDirtLevel = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetDirtLevel");
            Vehicle_SetDoorState = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetDoorState");
            Vehicle_SetDriftMode = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetDriftMode");
            Vehicle_SetEngineHealth = (delegate* unmanaged[Cdecl]<nint, int, void>) NativeLibrary.GetExport(handle, "Vehicle_SetEngineHealth");
            Vehicle_SetEngineOn = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetEngineOn");
            Vehicle_SetHeadlightColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetHeadlightColor");
            Vehicle_SetInteriorColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetInteriorColor");
            Vehicle_SetLightDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetLightDamaged");
            Vehicle_SetLightsMultiplier = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_SetLightsMultiplier");
            Vehicle_SetLivery = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetLivery");
            Vehicle_SetLockState = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetLockState");
            Vehicle_SetManualEngineControl = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetManualEngineControl");
            Vehicle_SetMod = (delegate* unmanaged[Cdecl]<nint, byte, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_SetMod");
            Vehicle_SetModKit = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Vehicle_SetModKit");
            Vehicle_SetNeonActive = (delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetNeonActive");
            Vehicle_SetNeonColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) NativeLibrary.GetExport(handle, "Vehicle_SetNeonColor");
            Vehicle_SetNumberplateIndex = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Vehicle_SetNumberplateIndex");
            Vehicle_SetNumberplateText = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Vehicle_SetNumberplateText");
            Vehicle_SetPartBulletHoles = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetPartBulletHoles");
            Vehicle_SetPartDamageLevel = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetPartDamageLevel");
            Vehicle_SetPearlColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetPearlColor");
            Vehicle_SetPetrolTankHealth = (delegate* unmanaged[Cdecl]<nint, int, void>) NativeLibrary.GetExport(handle, "Vehicle_SetPetrolTankHealth");
            Vehicle_SetPrimaryColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetPrimaryColor");
            Vehicle_SetPrimaryColorRGB = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) NativeLibrary.GetExport(handle, "Vehicle_SetPrimaryColorRGB");
            Vehicle_SetRadioStationIndex = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Vehicle_SetRadioStationIndex");
            Vehicle_SetRearWheels = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetRearWheels");
            Vehicle_SetRoofLivery = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetRoofLivery");
            Vehicle_SetRoofState = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetRoofState");
            Vehicle_SetSearchLight = (delegate* unmanaged[Cdecl]<nint, byte, nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_SetSearchLight");
            Vehicle_SetSecondaryColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetSecondaryColor");
            Vehicle_SetSecondaryColorRGB = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) NativeLibrary.GetExport(handle, "Vehicle_SetSecondaryColorRGB");
            Vehicle_SetSirenActive = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetSirenActive");
            Vehicle_SetSpecialDarkness = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetSpecialDarkness");
            Vehicle_SetSpecialLightDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetSpecialLightDamaged");
            Vehicle_SetTireSmokeColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTireSmokeColor");
            Vehicle_SetTrainCarriageConfigIndex = (delegate* unmanaged[Cdecl]<nint, sbyte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainCarriageConfigIndex");
            Vehicle_SetTrainConfigIndex = (delegate* unmanaged[Cdecl]<nint, sbyte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainConfigIndex");
            Vehicle_SetTrainCruiseSpeed = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainCruiseSpeed");
            Vehicle_SetTrainDirection = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainDirection");
            Vehicle_SetTrainDistanceFromEngine = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainDistanceFromEngine");
            Vehicle_SetTrainEngineId = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainEngineId");
            Vehicle_SetTrainForceDoorsOpen = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainForceDoorsOpen");
            Vehicle_SetTrainHasPassengerCarriages = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainHasPassengerCarriages");
            Vehicle_SetTrainIsCaboose = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainIsCaboose");
            Vehicle_SetTrainIsEngine = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainIsEngine");
            Vehicle_SetTrainLinkedToBackwardId = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainLinkedToBackwardId");
            Vehicle_SetTrainLinkedToForwardId = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainLinkedToForwardId");
            Vehicle_SetTrainMissionTrain = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainMissionTrain");
            Vehicle_SetTrainRenderDerailed = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainRenderDerailed");
            Vehicle_SetTrainTrackId = (delegate* unmanaged[Cdecl]<nint, sbyte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetTrainTrackId");
            Vehicle_SetWheelBurst = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetWheelBurst");
            Vehicle_SetWheelColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetWheelColor");
            Vehicle_SetWheelDetached = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetWheelDetached");
            Vehicle_SetWheelFixed = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetWheelFixed");
            Vehicle_SetWheelHasTire = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetWheelHasTire");
            Vehicle_SetWheelHealth = (delegate* unmanaged[Cdecl]<nint, byte, float, void>) NativeLibrary.GetExport(handle, "Vehicle_SetWheelHealth");
            Vehicle_SetWheelOnFire = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetWheelOnFire");
            Vehicle_SetWheels = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetWheels");
            Vehicle_SetWindowDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetWindowDamaged");
            Vehicle_SetWindowOpened = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetWindowOpened");
            Vehicle_SetWindowTint = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetWindowTint");
            Vehicle_ToggleExtra = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_ToggleExtra");
            VoiceChannel_AddPlayer = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "VoiceChannel_AddPlayer");
            VoiceChannel_AddRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "VoiceChannel_AddRef");
            VoiceChannel_DeleteMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "VoiceChannel_DeleteMetaData");
            VoiceChannel_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "VoiceChannel_GetBaseObject");
            VoiceChannel_GetMaxDistance = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "VoiceChannel_GetMaxDistance");
            VoiceChannel_GetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "VoiceChannel_GetMetaData");
            VoiceChannel_HasMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "VoiceChannel_HasMetaData");
            VoiceChannel_HasPlayer = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "VoiceChannel_HasPlayer");
            VoiceChannel_IsPlayerMuted = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "VoiceChannel_IsPlayerMuted");
            VoiceChannel_IsSpatial = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "VoiceChannel_IsSpatial");
            VoiceChannel_MutePlayer = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "VoiceChannel_MutePlayer");
            VoiceChannel_RemovePlayer = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "VoiceChannel_RemovePlayer");
            VoiceChannel_RemoveRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "VoiceChannel_RemoveRef");
            VoiceChannel_SetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "VoiceChannel_SetMetaData");
            VoiceChannel_UnmutePlayer = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "VoiceChannel_UnmutePlayer");
            WorldObject_GetDimension = (delegate* unmanaged[Cdecl]<nint, int>) NativeLibrary.GetExport(handle, "WorldObject_GetDimension");
            WorldObject_SetDimension = (delegate* unmanaged[Cdecl]<nint, int, void>) NativeLibrary.GetExport(handle, "WorldObject_SetDimension");
            WorldObject_SetPosition = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) NativeLibrary.GetExport(handle, "WorldObject_SetPosition");
        }
    }
}