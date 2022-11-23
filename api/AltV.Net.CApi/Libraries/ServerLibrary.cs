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
        public delegate* unmanaged[Cdecl]<nint, byte> ColShape_GetColShapeType { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> ColShape_IsPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> ColShape_SetPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, byte, void> ConnectionInfo_Accept { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, nint, void> ConnectionInfo_Decline { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetAuthToken { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetBranch { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, uint> ConnectionInfo_GetBuild { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetCdnUrl { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, long> ConnectionInfo_GetDiscordUserID { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetHwIdExHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetHwIdHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetIp { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, byte> ConnectionInfo_GetIsDebug { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetName { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetPasswordHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetSocialId { get; }
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
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocPedModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocVehicleModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DeleteSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyColShape { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyVoiceChannel { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Core_GetNetTime { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint> Core_GetPedModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetRootDirectory { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_GetServerConfig { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint> Core_GetVehicleModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ulong> Core_HashPassword { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_RestartResource { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_SetPassword { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Core_SetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_SetWorldProfiler { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte> Entity_HasCollision { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Entity_IsFrozen { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetCollision { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetFrozen { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Entity_SetNetOwner { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation, void> Entity_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetStreamed { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Entity_SetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Entity_SetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Event_Cancel { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Event_PlayerBeforeConnect_Cancel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Event_WasCancelled { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Event_WeaponDamageEvent_SetDamageValue { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, void> Player_AddWeaponComponent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void> Player_AttachToEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, Vector3, Rotation, byte, byte, void> Player_AttachToEntity_BoneString { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_ClearBloodDamage { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Player_ClearProps { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Player_DeleteLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_Despawn { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_Detach { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetAuthToken { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Cloth*, void> Player_GetClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetCurrentWeaponTintIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, long> Player_GetDiscordId { get; }
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
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetInteriorLocation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetInvincible { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetIP { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetLastDamagedBodyPart { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Player_GetLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetPing { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Prop*, void> Player_GetProps { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetSendNames { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte, byte> Player_SetClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, int, int, int, int, int, int, void> Player_SetDateTime { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte, uint, byte> Player_SetDlcClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, uint, byte> Player_SetDlcProps { get; }
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
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetLastDamagedBodyPart { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Player_SetLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Player_SetMaxArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Player_SetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte> Player_SetProps { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Player_SetSendNames { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte, void> Player_SetWeaponTintIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetWeather { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, uint, void> Player_Spawn { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetConfig { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetMain { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetPath { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Resource_Start { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Resource_Stop { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void> Vehicle_AttachToEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, Vector3, Rotation, byte, byte, void> Vehicle_AttachToEntity_BoneString { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_Detach { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_DoesWheelHasTire { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetAppearanceDataBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetArmoredWindowHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetArmoredWindowShootCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetAttached { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetAttachedTo { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetBoatAnchor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetBodyAdditionalHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetBodyHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetBumperDamageLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetCounterMeasureCount { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetHybridExtraActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetHybridExtraState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetInteriorColor { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetLightsMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetLightState { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetPrimaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Vehicle_GetPrimaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetRadioStationIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRearWheelVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRepairsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetRocketRefuelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRoofLivery { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRoofState { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetScriptDataBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetScriptMaxSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Vehicle_GetSecondaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSpecialDarkness { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetTimedExplosionCulprit { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetTimedExplosionTime { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte, int> Vehicle_GetWeaponCapacity { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelType { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWindowTint { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_HasArmoredWindows { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_HasTimedExplosion { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsTowingDisabled { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetBoatAnchor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_SetBodyAdditionalHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_SetBodyHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetBumperDamageLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_SetCounterMeasureCount { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetCustomTires { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetDashboardColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetDirtLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetDisableTowing { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetDoorState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetDriftMode { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> Vehicle_SetEngineHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetEngineOn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetHeadlightColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetHybridExtraActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetHybridExtraState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetInteriorColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetLightDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetLightsMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetLightState { get; }
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
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetRocketRefuelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetRoofLivery { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetRoofState { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetScriptMaxSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint, byte> Vehicle_SetSearchLight { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Vehicle_SetSecondaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetSirenActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetSpecialDarkness { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetSpecialLightDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint, uint, void> Vehicle_SetTimedExplosion { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte, int, void> Vehicle_SetWeaponCapacity { get; }
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
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> VoiceChannel_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_UnmutePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, int> WorldObject_GetDimension { get; }
        public delegate* unmanaged[Cdecl]<nint, float*, float*, float*, int*, void> WorldObject_GetPositionCoords { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> WorldObject_SetDimension { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> WorldObject_SetPosition { get; }
    }

    public unsafe class ServerLibrary : IServerLibrary
    {
        public readonly uint Methods = 1306;
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> Blip_AttachedTo { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_IsAttached { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> ColShape_GetColShapeType { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> ColShape_IsPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> ColShape_SetPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, byte, void> ConnectionInfo_Accept { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, nint, void> ConnectionInfo_Decline { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetAuthToken { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetBranch { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, uint> ConnectionInfo_GetBuild { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetCdnUrl { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, long> ConnectionInfo_GetDiscordUserID { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetHwIdExHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetHwIdHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetIp { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, byte> ConnectionInfo_GetIsDebug { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetName { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetPasswordHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetSocialId { get; }
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
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocPedModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocVehicleModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DeleteSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyColShape { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyVoiceChannel { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Core_GetNetTime { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint> Core_GetPedModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetRootDirectory { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_GetServerConfig { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint> Core_GetVehicleModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ulong> Core_HashPassword { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_RestartResource { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_SetPassword { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Core_SetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_SetWorldProfiler { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte> Entity_HasCollision { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Entity_IsFrozen { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetCollision { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetFrozen { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Entity_SetNetOwner { get; }
        public delegate* unmanaged[Cdecl]<nint, Rotation, void> Entity_SetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetStreamed { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Entity_SetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Entity_SetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Event_Cancel { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Event_PlayerBeforeConnect_Cancel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Event_WasCancelled { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Event_WeaponDamageEvent_SetDamageValue { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, void> Player_AddWeaponComponent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void> Player_AttachToEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, Vector3, Rotation, byte, byte, void> Player_AttachToEntity_BoneString { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_ClearBloodDamage { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Player_ClearProps { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Player_DeleteLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_Despawn { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_Detach { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetAuthToken { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Cloth*, void> Player_GetClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetCurrentWeaponTintIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, long> Player_GetDiscordId { get; }
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
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetInteriorLocation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetInvincible { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetIP { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetLastDamagedBodyPart { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Player_GetLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetPing { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Prop*, void> Player_GetProps { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetSendNames { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte, byte> Player_SetClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, int, int, int, int, int, int, void> Player_SetDateTime { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte, uint, byte> Player_SetDlcClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, uint, byte> Player_SetDlcProps { get; }
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
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetLastDamagedBodyPart { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Player_SetLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Player_SetMaxArmor { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Player_SetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte> Player_SetProps { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Player_SetSendNames { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte, void> Player_SetWeaponTintIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetWeather { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, uint, void> Player_Spawn { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetConfig { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetMain { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetPath { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Resource_Start { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Resource_Stop { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void> Vehicle_AttachToEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, Vector3, Rotation, byte, byte, void> Vehicle_AttachToEntity_BoneString { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_Detach { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_DoesWheelHasTire { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetAppearanceDataBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetArmoredWindowHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetArmoredWindowShootCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetAttached { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetAttachedTo { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetBoatAnchor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetBodyAdditionalHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetBodyHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Vehicle_GetBumperDamageLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetCounterMeasureCount { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetHybridExtraActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetHybridExtraState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetInteriorColor { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetLightsMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetLightState { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetPrimaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Vehicle_GetPrimaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetRadioStationIndex { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRearWheelVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRepairsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetRocketRefuelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRoofLivery { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetRoofState { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Vehicle_GetScriptDataBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetScriptMaxSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> Vehicle_GetSecondaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSpecialDarkness { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetTimedExplosionCulprit { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_GetTimedExplosionTime { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte, int> Vehicle_GetWeaponCapacity { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelType { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWindowTint { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_HasArmoredWindows { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_HasTimedExplosion { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsTowingDisabled { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetBoatAnchor { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_SetBodyAdditionalHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_SetBodyHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetBumperDamageLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_SetCounterMeasureCount { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetCustomTires { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetDashboardColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetDirtLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetDisableTowing { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetDoorState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetDriftMode { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> Vehicle_SetEngineHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetEngineOn { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetHeadlightColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetHybridExtraActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetHybridExtraState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetInteriorColor { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetLightDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetLightsMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetLightState { get; }
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
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetRocketRefuelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetRoofLivery { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetRoofState { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetScriptMaxSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint, byte> Vehicle_SetSearchLight { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetSecondaryColor { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, void> Vehicle_SetSecondaryColorRGB { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetSirenActive { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetSpecialDarkness { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> Vehicle_SetSpecialLightDamaged { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint, uint, void> Vehicle_SetTimedExplosion { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte, int, void> Vehicle_SetWeaponCapacity { get; }
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
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> VoiceChannel_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_UnmutePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, int> WorldObject_GetDimension { get; }
        public delegate* unmanaged[Cdecl]<nint, float*, float*, float*, int*, void> WorldObject_GetPositionCoords { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> WorldObject_SetDimension { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> WorldObject_SetPosition { get; }
        public ServerLibrary(Dictionary<ulong, IntPtr> funcTable)
        {
            Blip_AttachedTo = (delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint>) funcTable[8246223245924620254UL];
            Blip_IsAttached = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[9198858762629145399UL];
            ColShape_GetColShapeType = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[9472918389023864742UL];
            ColShape_IsPlayersOnly = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[10157525576187292213UL];
            ColShape_SetPlayersOnly = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[8591093422702326731UL];
            ConnectionInfo_Accept = (delegate* unmanaged[Cdecl]<IntPtr, byte, void>) funcTable[10324150125365232266UL];
            ConnectionInfo_Decline = (delegate* unmanaged[Cdecl]<IntPtr, nint, void>) funcTable[1140588701471045928UL];
            ConnectionInfo_GetAuthToken = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) funcTable[4816575844307815897UL];
            ConnectionInfo_GetBranch = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) funcTable[4320632337184369030UL];
            ConnectionInfo_GetBuild = (delegate* unmanaged[Cdecl]<IntPtr, uint>) funcTable[14776332534640311278UL];
            ConnectionInfo_GetCdnUrl = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) funcTable[6982194245841807046UL];
            ConnectionInfo_GetDiscordUserID = (delegate* unmanaged[Cdecl]<IntPtr, long>) funcTable[3780875226835268696UL];
            ConnectionInfo_GetHwIdExHash = (delegate* unmanaged[Cdecl]<IntPtr, ulong>) funcTable[4906900018073282815UL];
            ConnectionInfo_GetHwIdHash = (delegate* unmanaged[Cdecl]<IntPtr, ulong>) funcTable[5876384577158942254UL];
            ConnectionInfo_GetIp = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) funcTable[3441013384838967143UL];
            ConnectionInfo_GetIsDebug = (delegate* unmanaged[Cdecl]<IntPtr, byte>) funcTable[1888295228463636173UL];
            ConnectionInfo_GetName = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) funcTable[15834570281627910005UL];
            ConnectionInfo_GetPasswordHash = (delegate* unmanaged[Cdecl]<IntPtr, ulong>) funcTable[2972876587672054891UL];
            ConnectionInfo_GetSocialId = (delegate* unmanaged[Cdecl]<IntPtr, ulong>) funcTable[215508044563445688UL];
            Core_CreateBlip = (delegate* unmanaged[Cdecl]<nint, nint, byte, Vector3, nint>) funcTable[16035995202761254964UL];
            Core_CreateBlipAttached = (delegate* unmanaged[Cdecl]<nint, nint, byte, nint, nint>) funcTable[5186469007729645776UL];
            Core_CreateCheckpoint = (delegate* unmanaged[Cdecl]<nint, byte, Vector3, float, float, Rgba, nint>) funcTable[102161523841082289UL];
            Core_CreateColShapeCircle = (delegate* unmanaged[Cdecl]<nint, Vector3, float, nint>) funcTable[215859812428056000UL];
            Core_CreateColShapeCube = (delegate* unmanaged[Cdecl]<nint, Vector3, Vector3, nint>) funcTable[16857411738683681169UL];
            Core_CreateColShapeCylinder = (delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint>) funcTable[1994815569500469178UL];
            Core_CreateColShapePolygon = (delegate* unmanaged[Cdecl]<nint, float, float, Vector2[], int, nint>) funcTable[10942821479224145106UL];
            Core_CreateColShapeRectangle = (delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, nint>) funcTable[2250765166809023737UL];
            Core_CreateColShapeSphere = (delegate* unmanaged[Cdecl]<nint, Vector3, float, nint>) funcTable[5559152682636832497UL];
            Core_CreateVehicle = (delegate* unmanaged[Cdecl]<nint, uint, Vector3, Rotation, ushort*, nint>) funcTable[10802505489731436497UL];
            Core_CreateVoiceChannel = (delegate* unmanaged[Cdecl]<nint, byte, float, nint>) funcTable[752707054014963094UL];
            Core_DeallocPedModelInfo = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[4087928540029601183UL];
            Core_DeallocVehicleModelInfo = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[8036879201507359696UL];
            Core_DeleteSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[501355037141898959UL];
            Core_DestroyCheckpoint = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[2513206290886229609UL];
            Core_DestroyColShape = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[5384312504083917924UL];
            Core_DestroyVehicle = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[16811101009628766745UL];
            Core_DestroyVoiceChannel = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[9632486792103941758UL];
            Core_GetNetTime = (delegate* unmanaged[Cdecl]<nint, int>) funcTable[14353440959413452777UL];
            Core_GetPedModelInfo = (delegate* unmanaged[Cdecl]<nint, uint, nint>) funcTable[17688674471288762391UL];
            Core_GetRootDirectory = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[6193845607378658944UL];
            Core_GetServerConfig = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[3079388499935862372UL];
            Core_GetVehicleModelInfo = (delegate* unmanaged[Cdecl]<nint, uint, nint>) funcTable[4319694972501891736UL];
            Core_HashPassword = (delegate* unmanaged[Cdecl]<nint, nint, ulong>) funcTable[7350290179654052866UL];
            Core_RestartResource = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[16913913350512809810UL];
            Core_SetPassword = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[2678280898790643500UL];
            Core_SetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[6746533346070396754UL];
            Core_SetWorldProfiler = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[13788493873612846814UL];
            Core_StartResource = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[1097536539088840289UL];
            Core_StopResource = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[10776889339545945655UL];
            Core_StopServer = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[2434389418567157880UL];
            Core_SubscribeCommand = (delegate* unmanaged[Cdecl]<nint, nint, CommandCallback, byte>) funcTable[985488850653912266UL];
            Core_TriggerClientEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void>) funcTable[11136686457792849234UL];
            Core_TriggerClientEventForAll = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) funcTable[138497345848532152UL];
            Core_TriggerClientEventForSome = (delegate* unmanaged[Cdecl]<nint, nint[], int, nint, nint[], int, void>) funcTable[15600276219801831941UL];
            Core_TriggerServerEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) funcTable[12151558921348552198UL];
            Entity_DeleteStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[1246386365480757443UL];
            Entity_DeleteSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[2259434463229850571UL];
            Entity_GetStreamed = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[9077986016059031736UL];
            Entity_GetVisible = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[17327783597324808645UL];
            Entity_HasCollision = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[508246289045661255UL];
            Entity_IsFrozen = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[3141115708186153445UL];
            Entity_SetCollision = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[14518566458750778031UL];
            Entity_SetFrozen = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[3004105704185895459UL];
            Entity_SetNetOwner = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) funcTable[9099019213457638031UL];
            Entity_SetRotation = (delegate* unmanaged[Cdecl]<nint, Rotation, void>) funcTable[6445796519815642271UL];
            Entity_SetStreamed = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[17789054533709622796UL];
            Entity_SetStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[17403761561129329206UL];
            Entity_SetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[3161520862829932470UL];
            Entity_SetVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[2771725210540944417UL];
            Event_Cancel = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[16366231753228483546UL];
            Event_PlayerBeforeConnect_Cancel = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[8255366639612079223UL];
            Event_WasCancelled = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[1674369606153072852UL];
            Event_WeaponDamageEvent_SetDamageValue = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[1465274996405036654UL];
            Player_AddWeaponComponent = (delegate* unmanaged[Cdecl]<nint, uint, uint, void>) funcTable[4442368368574649055UL];
            Player_AttachToEntity = (delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void>) funcTable[1088511941260470314UL];
            Player_AttachToEntity_BoneString = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint, Vector3, Rotation, byte, byte, void>) funcTable[11819470486272283848UL];
            Player_ClearBloodDamage = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[7742553293095802479UL];
            Player_ClearProps = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[17329631487810271824UL];
            Player_DeleteLocalMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[13054356381631112988UL];
            Player_Despawn = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[4062100613704067569UL];
            Player_Detach = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[3440251799907171210UL];
            Player_GetAuthToken = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[13989301086329467294UL];
            Player_GetClothes = (delegate* unmanaged[Cdecl]<nint, byte, Cloth*, void>) funcTable[18272766207161781037UL];
            Player_GetCurrentWeaponTintIndex = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[2352880471488994311UL];
            Player_GetDiscordId = (delegate* unmanaged[Cdecl]<nint, long>) funcTable[7185215862160953592UL];
            Player_GetDlcClothes = (delegate* unmanaged[Cdecl]<nint, byte, DlcCloth*, void>) funcTable[11452237987048589644UL];
            Player_GetDlcProps = (delegate* unmanaged[Cdecl]<nint, byte, DlcProp*, void>) funcTable[4990357205898413010UL];
            Player_GetEyeColor = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[6613647396884772791UL];
            Player_GetFaceFeatureScale = (delegate* unmanaged[Cdecl]<nint, byte, float>) funcTable[5317504600409744570UL];
            Player_GetHairColor = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[16569646347513407174UL];
            Player_GetHairHighlightColor = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[14758884170519905752UL];
            Player_GetHeadBlendData = (delegate* unmanaged[Cdecl]<nint, HeadBlendData*, void>) funcTable[9717608003841111184UL];
            Player_GetHeadBlendPaletteColor = (delegate* unmanaged[Cdecl]<nint, byte, Rgba*, void>) funcTable[1015686321939338198UL];
            Player_GetHeadOverlay = (delegate* unmanaged[Cdecl]<nint, byte, HeadOverlay*, void>) funcTable[2711126484019392947UL];
            Player_GetHwidExHash = (delegate* unmanaged[Cdecl]<nint, ulong>) funcTable[12384463470220120186UL];
            Player_GetHwidHash = (delegate* unmanaged[Cdecl]<nint, ulong>) funcTable[18202908306753965131UL];
            Player_GetInteriorLocation = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[14487831262954152560UL];
            Player_GetInvincible = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[14369096343264475034UL];
            Player_GetIP = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[13529147803112765414UL];
            Player_GetLastDamagedBodyPart = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[11074751086018496195UL];
            Player_GetLocalMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[9108824844036010363UL];
            Player_GetPing = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[8666584047888469875UL];
            Player_GetProps = (delegate* unmanaged[Cdecl]<nint, byte, Prop*, void>) funcTable[15463405182208669955UL];
            Player_GetSendNames = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[5288378544263386659UL];
            Player_GetSocialID = (delegate* unmanaged[Cdecl]<nint, ulong>) funcTable[16174361114046576917UL];
            Player_GetWeaponCount = (delegate* unmanaged[Cdecl]<nint, ulong>) funcTable[11909131726046952598UL];
            Player_GetWeapons = (delegate* unmanaged[Cdecl]<nint, WeaponArray*, void>) funcTable[18079609989589875092UL];
            Player_GetWeaponTintIndex = (delegate* unmanaged[Cdecl]<nint, uint, byte>) funcTable[17585361563525106870UL];
            Player_GiveWeapon = (delegate* unmanaged[Cdecl]<nint, uint, int, byte, void>) funcTable[10658141267395236824UL];
            Player_HasLocalMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[14902436847651979839UL];
            Player_HasWeaponComponent = (delegate* unmanaged[Cdecl]<nint, uint, uint, byte>) funcTable[15719913457148630230UL];
            Player_IsConnected = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[15922866257099493016UL];
            Player_IsCrouching = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[2261171735705761445UL];
            Player_IsEntityInStreamingRange = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[3477485955286238728UL];
            Player_IsStealthy = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[14026971749344632823UL];
            Player_IsSuperJumpEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[10154368239372642825UL];
            Player_Kick = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[13236258341100251735UL];
            Player_PlayAmbientSpeech = (delegate* unmanaged[Cdecl]<nint, nint, nint, uint, void>) funcTable[15944102593522203711UL];
            Player_RemoveAllWeapons = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[8267448905308401793UL];
            Player_RemoveFaceFeature = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[16037967498660529610UL];
            Player_RemoveHeadOverlay = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[3619693675440217953UL];
            Player_RemoveWeapon = (delegate* unmanaged[Cdecl]<nint, uint, byte>) funcTable[12936075101220067297UL];
            Player_RemoveWeaponComponent = (delegate* unmanaged[Cdecl]<nint, uint, uint, void>) funcTable[4809323853163787452UL];
            Player_SetArmor = (delegate* unmanaged[Cdecl]<nint, ushort, void>) funcTable[9537376088915078602UL];
            Player_SetClothes = (delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte, byte>) funcTable[2596982613145418929UL];
            Player_SetCurrentWeapon = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[17437097198179007240UL];
            Player_SetDateTime = (delegate* unmanaged[Cdecl]<nint, int, int, int, int, int, int, void>) funcTable[6313111636640731358UL];
            Player_SetDlcClothes = (delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte, uint, byte>) funcTable[4532104071977767560UL];
            Player_SetDlcProps = (delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, uint, byte>) funcTable[3560699682817316966UL];
            Player_SetEyeColor = (delegate* unmanaged[Cdecl]<nint, ushort, byte>) funcTable[7739993261109353275UL];
            Player_SetFaceFeature = (delegate* unmanaged[Cdecl]<nint, byte, float, byte>) funcTable[3058405801718073508UL];
            Player_SetHairColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[5563506516381950146UL];
            Player_SetHairHighlightColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[5122158571944183148UL];
            Player_SetHeadBlendData = (delegate* unmanaged[Cdecl]<nint, uint, uint, uint, uint, uint, uint, float, float, float, void>) funcTable[1634114380624662724UL];
            Player_SetHeadBlendPaletteColor = (delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, byte>) funcTable[14350143879665168426UL];
            Player_SetHeadOverlay = (delegate* unmanaged[Cdecl]<nint, byte, byte, float, byte>) funcTable[11098246977957822359UL];
            Player_SetHeadOverlayColor = (delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, byte>) funcTable[18074367875729473350UL];
            Player_SetHealth = (delegate* unmanaged[Cdecl]<nint, ushort, void>) funcTable[10718294941416048061UL];
            Player_SetIntoVehicle = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) funcTable[15050122433691243619UL];
            Player_SetInvincible = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[10142600277137238686UL];
            Player_SetLastDamagedBodyPart = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[4725427814826661095UL];
            Player_SetLocalMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[14311589676512815823UL];
            Player_SetMaxArmor = (delegate* unmanaged[Cdecl]<nint, ushort, void>) funcTable[3143936413486306802UL];
            Player_SetMaxHealth = (delegate* unmanaged[Cdecl]<nint, ushort, void>) funcTable[6708258486109796357UL];
            Player_SetModel = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[8682235775556115384UL];
            Player_SetProps = (delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte>) funcTable[122863409121347231UL];
            Player_SetSendNames = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[12565862366697002807UL];
            Player_SetWeaponTintIndex = (delegate* unmanaged[Cdecl]<nint, uint, byte, void>) funcTable[8956455601716626810UL];
            Player_SetWeather = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[1744522413790086237UL];
            Player_Spawn = (delegate* unmanaged[Cdecl]<nint, Vector3, uint, void>) funcTable[17652413048535628544UL];
            Resource_GetConfig = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[18229425535071859076UL];
            Resource_GetMain = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[13890602780071694115UL];
            Resource_GetPath = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[512680569203118745UL];
            Resource_Start = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[6133834618494539694UL];
            Resource_Stop = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[11902711224704708726UL];
            Vehicle_AttachToEntity = (delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void>) funcTable[9721378079946240063UL];
            Vehicle_AttachToEntity_BoneString = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint, Vector3, Rotation, byte, byte, void>) funcTable[17855247389910817663UL];
            Vehicle_Detach = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[17343904501193152103UL];
            Vehicle_DoesWheelHasTire = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[18231285962478307714UL];
            Vehicle_GetAppearanceDataBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[7141339909541293417UL];
            Vehicle_GetArmoredWindowHealth = (delegate* unmanaged[Cdecl]<nint, byte, float>) funcTable[4772248440982996180UL];
            Vehicle_GetArmoredWindowShootCount = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[4945046294067305060UL];
            Vehicle_GetAttached = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[17928657131267967704UL];
            Vehicle_GetAttachedTo = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[9251505844187397425UL];
            Vehicle_GetBoatAnchor = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[2690644376988844699UL];
            Vehicle_GetBodyAdditionalHealth = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[12618855601539425711UL];
            Vehicle_GetBodyHealth = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[11088378283549798654UL];
            Vehicle_GetBumperDamageLevel = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[13236943727700043380UL];
            Vehicle_GetCounterMeasureCount = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[485289678211488495UL];
            Vehicle_GetCustomTires = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[15426552398989133774UL];
            Vehicle_GetDamageDataBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[9439612796052719298UL];
            Vehicle_GetDashboardColor = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[4689962177434880519UL];
            Vehicle_GetDirtLevel = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[4943755986655131597UL];
            Vehicle_GetDoorState = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[14062421191934531817UL];
            Vehicle_GetDriver = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[17395083227796204146UL];
            Vehicle_GetDriverID = (delegate* unmanaged[Cdecl]<nint, ushort*, byte>) funcTable[214513517736914559UL];
            Vehicle_GetEngineHealth = (delegate* unmanaged[Cdecl]<nint, int>) funcTable[3184787218307135956UL];
            Vehicle_GetGameStateBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[14999812204683401580UL];
            Vehicle_GetHeadlightColor = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[8617432081508484101UL];
            Vehicle_GetHealthDataBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[6299619046240903365UL];
            Vehicle_GetHybridExtraActive = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[5712072416254222906UL];
            Vehicle_GetHybridExtraState = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[275092992353284485UL];
            Vehicle_GetInteriorColor = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[13591345579580753299UL];
            Vehicle_GetLightsMultiplier = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[8571771842707943834UL];
            Vehicle_GetLightState = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[17642396039274412677UL];
            Vehicle_GetLivery = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[13721885512687412511UL];
            Vehicle_GetLockState = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[4109640252930367220UL];
            Vehicle_GetMod = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[2958078787905285072UL];
            Vehicle_GetModKit = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[14731927607175692292UL];
            Vehicle_GetModKitsCount = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[10506773036463884868UL];
            Vehicle_GetModsCount = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[12241670698318978368UL];
            Vehicle_GetNeonActive = (delegate* unmanaged[Cdecl]<nint, byte*, byte*, byte*, byte*, void>) funcTable[17412015570609171814UL];
            Vehicle_GetNeonColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) funcTable[8050024598004389611UL];
            Vehicle_GetNumberplateIndex = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[5267946291902922417UL];
            Vehicle_GetNumberplateText = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[163981800126807468UL];
            Vehicle_GetPartBulletHoles = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[1413685884763098344UL];
            Vehicle_GetPartDamageLevel = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[9705764958919883386UL];
            Vehicle_GetPearlColor = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[1217919115714803303UL];
            Vehicle_GetPrimaryColor = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[15992561361354260893UL];
            Vehicle_GetPrimaryColorRGB = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) funcTable[6066539018711123940UL];
            Vehicle_GetRadioStationIndex = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[7638410131097487547UL];
            Vehicle_GetRearWheelVariation = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[15078132105646510874UL];
            Vehicle_GetRepairsCount = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[10809015629258231181UL];
            Vehicle_GetRocketRefuelSpeed = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[6644164586803593672UL];
            Vehicle_GetRoofLivery = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[1709332226290527397UL];
            Vehicle_GetRoofState = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[12243493859877432983UL];
            Vehicle_GetScriptDataBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[11197050326871353656UL];
            Vehicle_GetScriptMaxSpeed = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[16747685571545646458UL];
            Vehicle_GetSecondaryColor = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[17668384667841686681UL];
            Vehicle_GetSecondaryColorRGB = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) funcTable[1641116694935980800UL];
            Vehicle_GetSpecialDarkness = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[7208616107358507240UL];
            Vehicle_GetTimedExplosionCulprit = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[1353796078915476377UL];
            Vehicle_GetTimedExplosionTime = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[6902188433009739171UL];
            Vehicle_GetTireSmokeColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) funcTable[8565660242447295194UL];
            Vehicle_GetTrainCarriageConfigIndex = (delegate* unmanaged[Cdecl]<nint, sbyte>) funcTable[14823192962250361246UL];
            Vehicle_GetTrainConfigIndex = (delegate* unmanaged[Cdecl]<nint, sbyte>) funcTable[3478398701577749804UL];
            Vehicle_GetTrainCruiseSpeed = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[8224634049512934712UL];
            Vehicle_GetTrainDirection = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[1388228765481341515UL];
            Vehicle_GetTrainDistanceFromEngine = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[8328973864652715251UL];
            Vehicle_GetTrainEngineId = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[2912674572257259049UL];
            Vehicle_GetTrainForceDoorsOpen = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[18113999117889183446UL];
            Vehicle_GetTrainLinkedToBackwardId = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[13939832827158272778UL];
            Vehicle_GetTrainLinkedToForwardId = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[6026193156543808202UL];
            Vehicle_GetTrainRenderDerailed = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[14356122929828990200UL];
            Vehicle_GetTrainTrackId = (delegate* unmanaged[Cdecl]<nint, sbyte>) funcTable[13500021794876217536UL];
            Vehicle_GetVelocity = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) funcTable[491431513133665831UL];
            Vehicle_GetWeaponCapacity = (delegate* unmanaged[Cdecl]<nint, byte, int>) funcTable[10108005386379901108UL];
            Vehicle_GetWheelColor = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[6683447355448832866UL];
            Vehicle_GetWheelHealth = (delegate* unmanaged[Cdecl]<nint, byte, float>) funcTable[9168757161831155413UL];
            Vehicle_GetWheelType = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[2380514860226088827UL];
            Vehicle_GetWheelVariation = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[2106243487143150120UL];
            Vehicle_GetWindowTint = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[14788150710609073045UL];
            Vehicle_HasArmoredWindows = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[16317068023373786051UL];
            Vehicle_HasTimedExplosion = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[12205417322261382950UL];
            Vehicle_HasTrainPassengerCarriages = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[5022001788933958729UL];
            Vehicle_IsDaylightOn = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[13324992420100574687UL];
            Vehicle_IsDestroyed = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[1099664456380252179UL];
            Vehicle_IsDriftMode = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[14284695685977030732UL];
            Vehicle_IsEngineOn = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[7564450666055690131UL];
            Vehicle_IsExtraOn = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[14505212927966303383UL];
            Vehicle_IsFlamethrowerActive = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[3196944959124900808UL];
            Vehicle_IsHandbrakeActive = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[5475206054850537974UL];
            Vehicle_IsLightDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[17750851581110628427UL];
            Vehicle_IsManualEngineControl = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[154883503073383145UL];
            Vehicle_IsNeonActive = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[15107233194798479898UL];
            Vehicle_IsNightlightOn = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[8656131823178916347UL];
            Vehicle_IsPrimaryColorRGB = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[287535114076765584UL];
            Vehicle_IsSecondaryColorRGB = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[16087964034103533780UL];
            Vehicle_IsSirenActive = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[10746025813828893319UL];
            Vehicle_IsSpecialLightDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[3400186478763105556UL];
            Vehicle_IsTireSmokeColorCustom = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[3707366369733984429UL];
            Vehicle_IsTowingDisabled = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[9218431851954266630UL];
            Vehicle_IsTrainCaboose = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[2061599685371125450UL];
            Vehicle_IsTrainEngine = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[16026428500027741792UL];
            Vehicle_IsTrainMissionTrain = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[15533197985460505190UL];
            Vehicle_IsWheelBurst = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[3285666993154637219UL];
            Vehicle_IsWheelDetached = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[355940780378797305UL];
            Vehicle_IsWheelOnFire = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[6043766364339597990UL];
            Vehicle_IsWindowDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[9574886165282119267UL];
            Vehicle_IsWindowOpened = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[11737851998723621525UL];
            Vehicle_LoadAppearanceDataFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[9460668391105494925UL];
            Vehicle_LoadDamageDataFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[5140481864102242386UL];
            Vehicle_LoadGameStateFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[9683125805030159088UL];
            Vehicle_LoadHealthDataFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[16641565416288932929UL];
            Vehicle_LoadScriptDataFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[18418115921584108740UL];
            Vehicle_Repair = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[17311798986599763685UL];
            Vehicle_SetArmoredWindowHealth = (delegate* unmanaged[Cdecl]<nint, byte, float, void>) funcTable[17364037803017145744UL];
            Vehicle_SetArmoredWindowShootCount = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[11171858117417258208UL];
            Vehicle_SetBoatAnchor = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[16831595260087658191UL];
            Vehicle_SetBodyAdditionalHealth = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[13392612127770315083UL];
            Vehicle_SetBodyHealth = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[15765773268680518698UL];
            Vehicle_SetBumperDamageLevel = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[16727389846276950048UL];
            Vehicle_SetCounterMeasureCount = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[11419176023132816883UL];
            Vehicle_SetCustomTires = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[17063056088444027082UL];
            Vehicle_SetDashboardColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[14506406134285509147UL];
            Vehicle_SetDirtLevel = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[7115460722936709265UL];
            Vehicle_SetDisableTowing = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[14332457157385345962UL];
            Vehicle_SetDoorState = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[13007705873637921189UL];
            Vehicle_SetDriftMode = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[10432140927923251188UL];
            Vehicle_SetEngineHealth = (delegate* unmanaged[Cdecl]<nint, int, void>) funcTable[1935772489264617144UL];
            Vehicle_SetEngineOn = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[6411099082957445067UL];
            Vehicle_SetHeadlightColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[6607005191456521737UL];
            Vehicle_SetHybridExtraActive = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[8845759033615557894UL];
            Vehicle_SetHybridExtraState = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[146116566076115897UL];
            Vehicle_SetInteriorColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[5502010976972308487UL];
            Vehicle_SetLightDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[14816781557527999091UL];
            Vehicle_SetLightsMultiplier = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[8137833252714021478UL];
            Vehicle_SetLightState = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[15199478154977473353UL];
            Vehicle_SetLivery = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[2739176049355370891UL];
            Vehicle_SetLockState = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[17926762006441749096UL];
            Vehicle_SetManualEngineControl = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[16078206917868437153UL];
            Vehicle_SetMod = (delegate* unmanaged[Cdecl]<nint, byte, byte, byte>) funcTable[2528063280588122884UL];
            Vehicle_SetModKit = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[6928786153550384344UL];
            Vehicle_SetNeonActive = (delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, void>) funcTable[3437844912155037218UL];
            Vehicle_SetNeonColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) funcTable[2624414132838947903UL];
            Vehicle_SetNumberplateIndex = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[7962549431209964437UL];
            Vehicle_SetNumberplateText = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[16656446852923914904UL];
            Vehicle_SetPartBulletHoles = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[30312183328040844UL];
            Vehicle_SetPartDamageLevel = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[490224508800165526UL];
            Vehicle_SetPearlColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[12810571514173707635UL];
            Vehicle_SetPetrolTankHealth = (delegate* unmanaged[Cdecl]<nint, int, void>) funcTable[5842836310610219704UL];
            Vehicle_SetPrimaryColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[3822546323726107953UL];
            Vehicle_SetPrimaryColorRGB = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) funcTable[11852532086043244168UL];
            Vehicle_SetRadioStationIndex = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[12110831169188614415UL];
            Vehicle_SetRearWheels = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[6142819993893898506UL];
            Vehicle_SetRocketRefuelSpeed = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[5921297257344499628UL];
            Vehicle_SetRoofLivery = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[5505815873063704905UL];
            Vehicle_SetRoofState = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[16895810717861855475UL];
            Vehicle_SetScriptMaxSpeed = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[7812823883483214902UL];
            Vehicle_SetSearchLight = (delegate* unmanaged[Cdecl]<nint, byte, nint, byte>) funcTable[10944681132155325504UL];
            Vehicle_SetSecondaryColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[10513916256608073301UL];
            Vehicle_SetSecondaryColorRGB = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) funcTable[4037519659470824652UL];
            Vehicle_SetSirenActive = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[3044482236176149999UL];
            Vehicle_SetSpecialDarkness = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[3102383534466233052UL];
            Vehicle_SetSpecialLightDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[5736562163945373772UL];
            Vehicle_SetTimedExplosion = (delegate* unmanaged[Cdecl]<nint, byte, nint, uint, void>) funcTable[16610133400907463102UL];
            Vehicle_SetTireSmokeColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) funcTable[3621510097027434190UL];
            Vehicle_SetTrainCarriageConfigIndex = (delegate* unmanaged[Cdecl]<nint, sbyte, void>) funcTable[7022754355815925162UL];
            Vehicle_SetTrainConfigIndex = (delegate* unmanaged[Cdecl]<nint, sbyte, void>) funcTable[11737632396104476216UL];
            Vehicle_SetTrainCruiseSpeed = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[16049421601515151140UL];
            Vehicle_SetTrainDirection = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[15992450228773944871UL];
            Vehicle_SetTrainDistanceFromEngine = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[5104280884677604335UL];
            Vehicle_SetTrainEngineId = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[14239123598098621429UL];
            Vehicle_SetTrainForceDoorsOpen = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[12997424740298738154UL];
            Vehicle_SetTrainHasPassengerCarriages = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[9343175927460300873UL];
            Vehicle_SetTrainIsCaboose = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[16169771838195371302UL];
            Vehicle_SetTrainIsEngine = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[4519524846083371236UL];
            Vehicle_SetTrainLinkedToBackwardId = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[5942631005197348414UL];
            Vehicle_SetTrainLinkedToForwardId = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[10700547817922111862UL];
            Vehicle_SetTrainMissionTrain = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[12659057398635580654UL];
            Vehicle_SetTrainRenderDerailed = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[9632926037266115436UL];
            Vehicle_SetTrainTrackId = (delegate* unmanaged[Cdecl]<nint, sbyte, void>) funcTable[9085977001203146804UL];
            Vehicle_SetWeaponCapacity = (delegate* unmanaged[Cdecl]<nint, byte, int, void>) funcTable[15660310337543212624UL];
            Vehicle_SetWheelBurst = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[12639904298595477067UL];
            Vehicle_SetWheelColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[10289187849606561694UL];
            Vehicle_SetWheelDetached = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[4522876720267119137UL];
            Vehicle_SetWheelFixed = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[12038411960804560075UL];
            Vehicle_SetWheelHasTire = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[13686448911876585131UL];
            Vehicle_SetWheelHealth = (delegate* unmanaged[Cdecl]<nint, byte, float, void>) funcTable[11641817719976869961UL];
            Vehicle_SetWheelOnFire = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[10480697380826687950UL];
            Vehicle_SetWheels = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[5979468759173941524UL];
            Vehicle_SetWindowDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[15228375535061986811UL];
            Vehicle_SetWindowOpened = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[11422327441667882061UL];
            Vehicle_SetWindowTint = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[9434495696018556569UL];
            Vehicle_ToggleExtra = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[7052917584705550874UL];
            VoiceChannel_AddPlayer = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[11480731622415663889UL];
            VoiceChannel_DeleteMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[16980366384902047783UL];
            VoiceChannel_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[17400492540972468697UL];
            VoiceChannel_GetMaxDistance = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[11467500650620780400UL];
            VoiceChannel_GetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[7452185796551681250UL];
            VoiceChannel_HasMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[13716244061363889254UL];
            VoiceChannel_HasPlayer = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[8720092938692268106UL];
            VoiceChannel_IsPlayerMuted = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[2614389959184933679UL];
            VoiceChannel_IsSpatial = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[14951425886020740427UL];
            VoiceChannel_MutePlayer = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[12065461469661482481UL];
            VoiceChannel_RemovePlayer = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[5654188700644832496UL];
            VoiceChannel_SetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[4956759779487566838UL];
            VoiceChannel_UnmutePlayer = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[9736361074722605058UL];
            WorldObject_GetDimension = (delegate* unmanaged[Cdecl]<nint, int>) funcTable[15182911217769927409UL];
            WorldObject_GetPositionCoords = (delegate* unmanaged[Cdecl]<nint, float*, float*, float*, int*, void>) funcTable[7469948310820491890UL];
            WorldObject_SetDimension = (delegate* unmanaged[Cdecl]<nint, int, void>) funcTable[10474817540727671173UL];
            WorldObject_SetPosition = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) funcTable[15794898554691126400UL];
        }
    }
}