// ReSharper disable InconsistentNaming
using AltV.Net.Data;
using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.CApi.Libraries
{
    public unsafe interface IServerLibrary
    {
        public bool Outdated { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> BaseObject_DeleteSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> BaseObject_SetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> Blip_AttachedTo { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_IsAttached { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> ColShape_GetColShapeType { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> ColShape_IsPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> ColShape_SetPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, byte, void> ConnectionInfo_Accept { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, nint, void> ConnectionInfo_Decline { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetAuthToken { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, nint> ConnectionInfo_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetBranch { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, uint> ConnectionInfo_GetBuild { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetCdnUrl { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetCloudAuthHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, long> ConnectionInfo_GetDiscordUserID { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetHwIdExHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetHwIdHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, uint> ConnectionInfo_GetID { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetIp { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, byte> ConnectionInfo_GetIsDebug { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetName { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetPasswordHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetSocialId { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetSocialName { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, byte> ConnectionInfo_IsAccepted { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, Vector3, uint*, nint> Core_CreateBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, nint, uint*, nint> Core_CreateBlipAttached { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Vector3, float, float, Rgba, uint, uint*, nint> Core_CreateCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, Vector3, Rgba, nint, uint*, nint> Core_CreateMarker { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, Vector3, Rotation, byte, byte, ushort, uint*, nint> Core_CreateNetworkObject { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, Vector3, Rotation, uint*, nint> Core_CreatePed { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, Vector3, Rotation, uint*, nint> Core_CreateVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, uint*, nint> Core_CreateVoiceChannel { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocPedModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocVehicleModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DeleteSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyColShape { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyVoiceChannel { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, int, int, int, ulong, nint[], byte[], ulong, void> Core_GetClosestEntities { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, int, int, int, ulong, ulong> Core_GetClosestEntitiesCount { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetConnectionInfos { get; }
        public delegate* unmanaged[Cdecl]<nint, int, ulong, nint[], byte[], ulong, void> Core_GetEntitiesInDimension { get; }
        public delegate* unmanaged[Cdecl]<nint, int, ulong, ulong> Core_GetEntitiesInDimensionCount { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, int, int, ulong, nint[], byte[], ulong, void> Core_GetEntitiesInRange { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, int, int, ulong, ulong> Core_GetEntitiesInRangeCount { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Core_GetNetTime { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint> Core_GetPedModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetRootDirectory { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_GetServerConfig { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint> Core_GetVehicleModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ulong> Core_HashPassword { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, nint[], nint[], ulong, nint> Core_RegisterMetric { get; }
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
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void> Core_TriggerClientEventUnreliable { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerClientEventUnreliableForAll { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], int, nint, nint[], int, void> Core_TriggerClientEventUnreliableForSome { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerServerEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_UnrgisterMetric { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void> Entity_AttachToEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, Vector3, Rotation, byte, byte, void> Entity_AttachToEntity_BoneString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Entity_DeleteStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Entity_Detach { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Entity_GetStreamed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Entity_GetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Entity_HasCollision { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetCollision { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Entity_SetNetOwner { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetStreamed { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Entity_SetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Event_WeaponDamageEvent_SetDamageValue { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Metric_Begin { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Metric_End { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Metric_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Metric_GetValue { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, void> Metric_SetValue { get; }
        public delegate* unmanaged[Cdecl]<nint, void> NetworkObject_ActivatePhysics { get; }
        public delegate* unmanaged[Cdecl]<nint, void> NetworkObject_PlaceOnGroundProperly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> NetworkObject_SetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> NetworkObject_SetLodDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> NetworkObject_SetTextureVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Ped_SetArmour { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Ped_SetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Ped_SetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Ped_SetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, void> Player_AddWeaponComponent { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_ClearBloodDamage { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Player_ClearProps { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_ClearTasks { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Player_DeleteLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_Despawn { get; }
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
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetSocialClubName { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Player_GetSocialID { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Player_GetWeaponCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, uint*, void> Player_GetWeapons { get; }
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
        public delegate* unmanaged[Cdecl]<nint, nint, nint, float, float, int, int, float, byte, byte, byte, void> Player_PlayAnimation { get; }
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
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetMain { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetPath { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Resource_Start { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Resource_Stop { get; }
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
        public delegate* unmanaged[Cdecl]<nint, Quaternion> Vehicle_GetQuaternion { get; }
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
        public delegate* unmanaged[Cdecl]<nint, Quaternion, void> Vehicle_SetQuaternion { get; }
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
        public delegate* unmanaged[Cdecl]<nint, nint, void> VirtualEntity_DeleteStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> VirtualEntity_SetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_AddPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> VoiceChannel_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VoiceChannel_GetFilter { get; }
        public delegate* unmanaged[Cdecl]<nint, float> VoiceChannel_GetMaxDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> VoiceChannel_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, int> VoiceChannel_GetPriority { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> VoiceChannel_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> VoiceChannel_HasPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> VoiceChannel_IsPlayerMuted { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> VoiceChannel_IsSpatial { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_MutePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_RemovePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> VoiceChannel_SetFilter { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> VoiceChannel_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> VoiceChannel_SetPriority { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_UnmutePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, float*, float*, float*, int*, void> WorldObject_GetPositionCoords { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> WorldObject_SetDimension { get; }
    }

    public unsafe class ServerLibrary : IServerLibrary
    {
        public readonly uint Methods = 1523;
        public delegate* unmanaged[Cdecl]<nint, nint, void> BaseObject_DeleteSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> BaseObject_SetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint> Blip_AttachedTo { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_IsAttached { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> ColShape_GetColShapeType { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> ColShape_IsPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> ColShape_SetPlayersOnly { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, byte, void> ConnectionInfo_Accept { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, nint, void> ConnectionInfo_Decline { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetAuthToken { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, nint> ConnectionInfo_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetBranch { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, uint> ConnectionInfo_GetBuild { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetCdnUrl { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetCloudAuthHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, long> ConnectionInfo_GetDiscordUserID { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetHwIdExHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetHwIdHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, uint> ConnectionInfo_GetID { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetIp { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, byte> ConnectionInfo_GetIsDebug { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetName { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetPasswordHash { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, ulong> ConnectionInfo_GetSocialId { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, int*, nint> ConnectionInfo_GetSocialName { get; }
        public delegate* unmanaged[Cdecl]<IntPtr, byte> ConnectionInfo_IsAccepted { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, Vector3, uint*, nint> Core_CreateBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, nint, uint*, nint> Core_CreateBlipAttached { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Vector3, float, float, Rgba, uint, uint*, nint> Core_CreateCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, Vector3, Rgba, nint, uint*, nint> Core_CreateMarker { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, Vector3, Rotation, byte, byte, ushort, uint*, nint> Core_CreateNetworkObject { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, Vector3, Rotation, uint*, nint> Core_CreatePed { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, Vector3, Rotation, uint*, nint> Core_CreateVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, uint*, nint> Core_CreateVoiceChannel { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocPedModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocVehicleModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DeleteSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyColShape { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_DestroyVoiceChannel { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, int, int, int, ulong, nint[], byte[], ulong, void> Core_GetClosestEntities { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, int, int, int, ulong, ulong> Core_GetClosestEntitiesCount { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong*, nint> Core_GetConnectionInfos { get; }
        public delegate* unmanaged[Cdecl]<nint, int, ulong, nint[], byte[], ulong, void> Core_GetEntitiesInDimension { get; }
        public delegate* unmanaged[Cdecl]<nint, int, ulong, ulong> Core_GetEntitiesInDimensionCount { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, int, int, ulong, nint[], byte[], ulong, void> Core_GetEntitiesInRange { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, int, int, ulong, ulong> Core_GetEntitiesInRangeCount { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Core_GetNetTime { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint> Core_GetPedModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetRootDirectory { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_GetServerConfig { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint> Core_GetVehicleModelInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ulong> Core_HashPassword { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, nint[], nint[], ulong, nint> Core_RegisterMetric { get; }
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
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void> Core_TriggerClientEventUnreliable { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerClientEventUnreliableForAll { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], int, nint, nint[], int, void> Core_TriggerClientEventUnreliableForSome { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerServerEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_UnrgisterMetric { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void> Entity_AttachToEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, Vector3, Rotation, byte, byte, void> Entity_AttachToEntity_BoneString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Entity_DeleteStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Entity_Detach { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Entity_GetStreamed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Entity_GetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Entity_HasCollision { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetCollision { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Entity_SetNetOwner { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetStreamed { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Entity_SetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Entity_SetVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Event_WeaponDamageEvent_SetDamageValue { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Metric_Begin { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Metric_End { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Metric_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Metric_GetValue { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, void> Metric_SetValue { get; }
        public delegate* unmanaged[Cdecl]<nint, void> NetworkObject_ActivatePhysics { get; }
        public delegate* unmanaged[Cdecl]<nint, void> NetworkObject_PlaceOnGroundProperly { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> NetworkObject_SetAlpha { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> NetworkObject_SetLodDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> NetworkObject_SetTextureVariation { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Ped_SetArmour { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Ped_SetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Ped_SetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Ped_SetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, uint, void> Player_AddWeaponComponent { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_ClearBloodDamage { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Player_ClearProps { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_ClearTasks { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Player_DeleteLocalMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Player_Despawn { get; }
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
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Player_GetSocialClubName { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Player_GetSocialID { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Player_GetWeaponCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, uint*, void> Player_GetWeapons { get; }
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
        public delegate* unmanaged[Cdecl]<nint, nint, nint, float, float, int, int, float, byte, byte, byte, void> Player_PlayAnimation { get; }
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
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetMain { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Resource_GetPath { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Resource_Start { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Resource_Stop { get; }
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
        public delegate* unmanaged[Cdecl]<nint, Quaternion> Vehicle_GetQuaternion { get; }
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
        public delegate* unmanaged[Cdecl]<nint, Quaternion, void> Vehicle_SetQuaternion { get; }
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
        public delegate* unmanaged[Cdecl]<nint, nint, void> VirtualEntity_DeleteStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> VirtualEntity_SetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_AddPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> VoiceChannel_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VoiceChannel_GetFilter { get; }
        public delegate* unmanaged[Cdecl]<nint, float> VoiceChannel_GetMaxDistance { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> VoiceChannel_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, int> VoiceChannel_GetPriority { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> VoiceChannel_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> VoiceChannel_HasPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> VoiceChannel_IsPlayerMuted { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> VoiceChannel_IsSpatial { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_MutePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_RemovePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> VoiceChannel_SetFilter { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> VoiceChannel_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> VoiceChannel_SetPriority { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> VoiceChannel_UnmutePlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, float*, float*, float*, int*, void> WorldObject_GetPositionCoords { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> WorldObject_SetDimension { get; }
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void BaseObject_DeleteSyncedMetaDataDelegate(nint _baseObject, nint _key);
        private static void BaseObject_DeleteSyncedMetaDataFallback(nint _baseObject, nint _key) => throw new Exceptions.OutdatedSdkException("BaseObject_DeleteSyncedMetaData", "BaseObject_DeleteSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void BaseObject_SetSyncedMetaDataDelegate(nint _baseObject, nint _key, nint _val);
        private static void BaseObject_SetSyncedMetaDataFallback(nint _baseObject, nint _key, nint _val) => throw new Exceptions.OutdatedSdkException("BaseObject_SetSyncedMetaData", "BaseObject_SetSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Blip_AttachedToDelegate(nint _blip, BaseObjectType* _type);
        private static nint Blip_AttachedToFallback(nint _blip, BaseObjectType* _type) => throw new Exceptions.OutdatedSdkException("Blip_AttachedTo", "Blip_AttachedTo SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_IsAttachedDelegate(nint _blip);
        private static byte Blip_IsAttachedFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_IsAttached", "Blip_IsAttached SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte ColShape_GetColShapeTypeDelegate(nint _colShape);
        private static byte ColShape_GetColShapeTypeFallback(nint _colShape) => throw new Exceptions.OutdatedSdkException("ColShape_GetColShapeType", "ColShape_GetColShapeType SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte ColShape_IsPlayersOnlyDelegate(nint _colShape);
        private static byte ColShape_IsPlayersOnlyFallback(nint _colShape) => throw new Exceptions.OutdatedSdkException("ColShape_IsPlayersOnly", "ColShape_IsPlayersOnly SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void ColShape_SetPlayersOnlyDelegate(nint _colShape, byte _state);
        private static void ColShape_SetPlayersOnlyFallback(nint _colShape, byte _state) => throw new Exceptions.OutdatedSdkException("ColShape_SetPlayersOnly", "ColShape_SetPlayersOnly SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void ConnectionInfo_AcceptDelegate(IntPtr _connectionInfo, byte _sendNames);
        private static void ConnectionInfo_AcceptFallback(IntPtr _connectionInfo, byte _sendNames) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_Accept", "ConnectionInfo_Accept SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void ConnectionInfo_DeclineDelegate(IntPtr _connectionInfo, nint _reason);
        private static void ConnectionInfo_DeclineFallback(IntPtr _connectionInfo, nint _reason) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_Decline", "ConnectionInfo_Decline SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint ConnectionInfo_GetAuthTokenDelegate(IntPtr _connectionInfo, int* _size);
        private static nint ConnectionInfo_GetAuthTokenFallback(IntPtr _connectionInfo, int* _size) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetAuthToken", "ConnectionInfo_GetAuthToken SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint ConnectionInfo_GetBaseObjectDelegate(IntPtr _connectionInfo);
        private static nint ConnectionInfo_GetBaseObjectFallback(IntPtr _connectionInfo) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetBaseObject", "ConnectionInfo_GetBaseObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint ConnectionInfo_GetBranchDelegate(IntPtr _connectionInfo, int* _size);
        private static nint ConnectionInfo_GetBranchFallback(IntPtr _connectionInfo, int* _size) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetBranch", "ConnectionInfo_GetBranch SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint ConnectionInfo_GetBuildDelegate(IntPtr _connectionInfo);
        private static uint ConnectionInfo_GetBuildFallback(IntPtr _connectionInfo) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetBuild", "ConnectionInfo_GetBuild SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint ConnectionInfo_GetCdnUrlDelegate(IntPtr _connectionInfo, int* _size);
        private static nint ConnectionInfo_GetCdnUrlFallback(IntPtr _connectionInfo, int* _size) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetCdnUrl", "ConnectionInfo_GetCdnUrl SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint ConnectionInfo_GetCloudAuthHashDelegate(IntPtr _connectionInfo, int* _size);
        private static nint ConnectionInfo_GetCloudAuthHashFallback(IntPtr _connectionInfo, int* _size) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetCloudAuthHash", "ConnectionInfo_GetCloudAuthHash SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate long ConnectionInfo_GetDiscordUserIDDelegate(IntPtr _connectionInfo);
        private static long ConnectionInfo_GetDiscordUserIDFallback(IntPtr _connectionInfo) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetDiscordUserID", "ConnectionInfo_GetDiscordUserID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong ConnectionInfo_GetHwIdExHashDelegate(IntPtr _connectionInfo);
        private static ulong ConnectionInfo_GetHwIdExHashFallback(IntPtr _connectionInfo) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetHwIdExHash", "ConnectionInfo_GetHwIdExHash SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong ConnectionInfo_GetHwIdHashDelegate(IntPtr _connectionInfo);
        private static ulong ConnectionInfo_GetHwIdHashFallback(IntPtr _connectionInfo) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetHwIdHash", "ConnectionInfo_GetHwIdHash SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint ConnectionInfo_GetIDDelegate(IntPtr _connectionInfo);
        private static uint ConnectionInfo_GetIDFallback(IntPtr _connectionInfo) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetID", "ConnectionInfo_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint ConnectionInfo_GetIpDelegate(IntPtr _connectionInfo, int* _size);
        private static nint ConnectionInfo_GetIpFallback(IntPtr _connectionInfo, int* _size) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetIp", "ConnectionInfo_GetIp SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte ConnectionInfo_GetIsDebugDelegate(IntPtr _connectionInfo);
        private static byte ConnectionInfo_GetIsDebugFallback(IntPtr _connectionInfo) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetIsDebug", "ConnectionInfo_GetIsDebug SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint ConnectionInfo_GetNameDelegate(IntPtr _connectionInfo, int* _size);
        private static nint ConnectionInfo_GetNameFallback(IntPtr _connectionInfo, int* _size) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetName", "ConnectionInfo_GetName SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong ConnectionInfo_GetPasswordHashDelegate(IntPtr _connectionInfo);
        private static ulong ConnectionInfo_GetPasswordHashFallback(IntPtr _connectionInfo) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetPasswordHash", "ConnectionInfo_GetPasswordHash SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong ConnectionInfo_GetSocialIdDelegate(IntPtr _connectionInfo);
        private static ulong ConnectionInfo_GetSocialIdFallback(IntPtr _connectionInfo) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetSocialId", "ConnectionInfo_GetSocialId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint ConnectionInfo_GetSocialNameDelegate(IntPtr _connectionInfo, int* _size);
        private static nint ConnectionInfo_GetSocialNameFallback(IntPtr _connectionInfo, int* _size) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_GetSocialName", "ConnectionInfo_GetSocialName SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte ConnectionInfo_IsAcceptedDelegate(IntPtr _connectionInfo);
        private static byte ConnectionInfo_IsAcceptedFallback(IntPtr _connectionInfo) => throw new Exceptions.OutdatedSdkException("ConnectionInfo_IsAccepted", "ConnectionInfo_IsAccepted SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateBlipDelegate(nint _server, nint _target, byte _type, Vector3 _pos, uint* _id);
        private static nint Core_CreateBlipFallback(nint _server, nint _target, byte _type, Vector3 _pos, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateBlip", "Core_CreateBlip SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateBlipAttachedDelegate(nint _server, nint _target, byte _type, nint _attachTo, uint* _id);
        private static nint Core_CreateBlipAttachedFallback(nint _server, nint _target, byte _type, nint _attachTo, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateBlipAttached", "Core_CreateBlipAttached SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateCheckpointDelegate(nint _server, byte _type, Vector3 _pos, float _radius, float _height, Rgba _color, uint _streamingDistance, uint* _id);
        private static nint Core_CreateCheckpointFallback(nint _server, byte _type, Vector3 _pos, float _radius, float _height, Rgba _color, uint _streamingDistance, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateCheckpoint", "Core_CreateCheckpoint SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMarkerDelegate(nint _core, nint _target, byte _type, Vector3 _pos, Rgba _color, nint _resource, uint* _id);
        private static nint Core_CreateMarkerFallback(nint _core, nint _target, byte _type, Vector3 _pos, Rgba _color, nint _resource, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateMarker", "Core_CreateMarker SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateNetworkObjectDelegate(nint _core, uint _model, Vector3 _position, Rotation _rotation, byte _alpha, byte _textureVariation, ushort _lodDistance, uint* _id);
        private static nint Core_CreateNetworkObjectFallback(nint _core, uint _model, Vector3 _position, Rotation _rotation, byte _alpha, byte _textureVariation, ushort _lodDistance, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateNetworkObject", "Core_CreateNetworkObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreatePedDelegate(nint _core, uint _model, Vector3 _pos, Rotation _rot, uint* _id);
        private static nint Core_CreatePedFallback(nint _core, uint _model, Vector3 _pos, Rotation _rot, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreatePed", "Core_CreatePed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateVehicleDelegate(nint _server, uint _model, Vector3 _pos, Rotation _rot, uint* _id);
        private static nint Core_CreateVehicleFallback(nint _server, uint _model, Vector3 _pos, Rotation _rot, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateVehicle", "Core_CreateVehicle SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateVoiceChannelDelegate(nint _server, byte _spatial, float _maxDistance, uint* _id);
        private static nint Core_CreateVoiceChannelFallback(nint _server, byte _spatial, float _maxDistance, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateVoiceChannel", "Core_CreateVoiceChannel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_DeallocPedModelInfoDelegate(nint _modelInfo);
        private static void Core_DeallocPedModelInfoFallback(nint _modelInfo) => throw new Exceptions.OutdatedSdkException("Core_DeallocPedModelInfo", "Core_DeallocPedModelInfo SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_DeallocVehicleModelInfoDelegate(nint _modelInfo);
        private static void Core_DeallocVehicleModelInfoFallback(nint _modelInfo) => throw new Exceptions.OutdatedSdkException("Core_DeallocVehicleModelInfo", "Core_DeallocVehicleModelInfo SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_DeleteSyncedMetaDataDelegate(nint _core, nint _key);
        private static void Core_DeleteSyncedMetaDataFallback(nint _core, nint _key) => throw new Exceptions.OutdatedSdkException("Core_DeleteSyncedMetaData", "Core_DeleteSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_DestroyCheckpointDelegate(nint _server, nint _baseObject);
        private static void Core_DestroyCheckpointFallback(nint _server, nint _baseObject) => throw new Exceptions.OutdatedSdkException("Core_DestroyCheckpoint", "Core_DestroyCheckpoint SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_DestroyColShapeDelegate(nint _server, nint _baseObject);
        private static void Core_DestroyColShapeFallback(nint _server, nint _baseObject) => throw new Exceptions.OutdatedSdkException("Core_DestroyColShape", "Core_DestroyColShape SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_DestroyVehicleDelegate(nint _server, nint _baseObject);
        private static void Core_DestroyVehicleFallback(nint _server, nint _baseObject) => throw new Exceptions.OutdatedSdkException("Core_DestroyVehicle", "Core_DestroyVehicle SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_DestroyVoiceChannelDelegate(nint _server, nint _baseObject);
        private static void Core_DestroyVoiceChannelFallback(nint _server, nint _baseObject) => throw new Exceptions.OutdatedSdkException("Core_DestroyVoiceChannel", "Core_DestroyVoiceChannel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_GetClosestEntitiesDelegate(nint _core, Vector3 _position, int _range, int _dimension, int _limit, ulong _allowedTypes, nint[] entities, byte[] types, ulong _size);
        private static void Core_GetClosestEntitiesFallback(nint _core, Vector3 _position, int _range, int _dimension, int _limit, ulong _allowedTypes, nint[] entities, byte[] types, ulong _size) => throw new Exceptions.OutdatedSdkException("Core_GetClosestEntities", "Core_GetClosestEntities SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong Core_GetClosestEntitiesCountDelegate(nint _core, Vector3 _position, int _range, int _dimension, int _limit, ulong _allowedTypes);
        private static ulong Core_GetClosestEntitiesCountFallback(nint _core, Vector3 _position, int _range, int _dimension, int _limit, ulong _allowedTypes) => throw new Exceptions.OutdatedSdkException("Core_GetClosestEntitiesCount", "Core_GetClosestEntitiesCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetConnectionInfosDelegate(nint _core, ulong* _size);
        private static nint Core_GetConnectionInfosFallback(nint _core, ulong* _size) => throw new Exceptions.OutdatedSdkException("Core_GetConnectionInfos", "Core_GetConnectionInfos SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_GetEntitiesInDimensionDelegate(nint _core, int _dimension, ulong _allowedTypes, nint[] entities, byte[] types, ulong _size);
        private static void Core_GetEntitiesInDimensionFallback(nint _core, int _dimension, ulong _allowedTypes, nint[] entities, byte[] types, ulong _size) => throw new Exceptions.OutdatedSdkException("Core_GetEntitiesInDimension", "Core_GetEntitiesInDimension SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong Core_GetEntitiesInDimensionCountDelegate(nint _core, int _dimension, ulong _allowedTypes);
        private static ulong Core_GetEntitiesInDimensionCountFallback(nint _core, int _dimension, ulong _allowedTypes) => throw new Exceptions.OutdatedSdkException("Core_GetEntitiesInDimensionCount", "Core_GetEntitiesInDimensionCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_GetEntitiesInRangeDelegate(nint _core, Vector3 _position, int _range, int _dimension, ulong _allowedTypes, nint[] entities, byte[] types, ulong _size);
        private static void Core_GetEntitiesInRangeFallback(nint _core, Vector3 _position, int _range, int _dimension, ulong _allowedTypes, nint[] entities, byte[] types, ulong _size) => throw new Exceptions.OutdatedSdkException("Core_GetEntitiesInRange", "Core_GetEntitiesInRange SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong Core_GetEntitiesInRangeCountDelegate(nint _core, Vector3 _position, int _range, int _dimension, ulong _allowedTypes);
        private static ulong Core_GetEntitiesInRangeCountFallback(nint _core, Vector3 _position, int _range, int _dimension, ulong _allowedTypes) => throw new Exceptions.OutdatedSdkException("Core_GetEntitiesInRangeCount", "Core_GetEntitiesInRangeCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate int Core_GetNetTimeDelegate(nint _server);
        private static int Core_GetNetTimeFallback(nint _server) => throw new Exceptions.OutdatedSdkException("Core_GetNetTime", "Core_GetNetTime SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetPedModelInfoDelegate(nint _core, uint _hash);
        private static nint Core_GetPedModelInfoFallback(nint _core, uint _hash) => throw new Exceptions.OutdatedSdkException("Core_GetPedModelInfo", "Core_GetPedModelInfo SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetRootDirectoryDelegate(nint _server, int* _size);
        private static nint Core_GetRootDirectoryFallback(nint _server, int* _size) => throw new Exceptions.OutdatedSdkException("Core_GetRootDirectory", "Core_GetRootDirectory SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetServerConfigDelegate(nint _core);
        private static nint Core_GetServerConfigFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_GetServerConfig", "Core_GetServerConfig SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetVehicleModelInfoDelegate(nint _server, uint _hash);
        private static nint Core_GetVehicleModelInfoFallback(nint _server, uint _hash) => throw new Exceptions.OutdatedSdkException("Core_GetVehicleModelInfo", "Core_GetVehicleModelInfo SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong Core_HashPasswordDelegate(nint _core, nint _password);
        private static ulong Core_HashPasswordFallback(nint _core, nint _password) => throw new Exceptions.OutdatedSdkException("Core_HashPassword", "Core_HashPassword SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_RegisterMetricDelegate(nint _core, nint _metricName, byte _type, nint[] keys, nint[] values, ulong _size);
        private static nint Core_RegisterMetricFallback(nint _core, nint _metricName, byte _type, nint[] keys, nint[] values, ulong _size) => throw new Exceptions.OutdatedSdkException("Core_RegisterMetric", "Core_RegisterMetric SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_RestartResourceDelegate(nint _server, nint _text);
        private static void Core_RestartResourceFallback(nint _server, nint _text) => throw new Exceptions.OutdatedSdkException("Core_RestartResource", "Core_RestartResource SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetPasswordDelegate(nint _core, nint _value);
        private static void Core_SetPasswordFallback(nint _core, nint _value) => throw new Exceptions.OutdatedSdkException("Core_SetPassword", "Core_SetPassword SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetSyncedMetaDataDelegate(nint _core, nint _key, nint _val);
        private static void Core_SetSyncedMetaDataFallback(nint _core, nint _key, nint _val) => throw new Exceptions.OutdatedSdkException("Core_SetSyncedMetaData", "Core_SetSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetWorldProfilerDelegate(nint _core, byte _state);
        private static void Core_SetWorldProfilerFallback(nint _core, byte _state) => throw new Exceptions.OutdatedSdkException("Core_SetWorldProfiler", "Core_SetWorldProfiler SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_StartResourceDelegate(nint _server, nint _text);
        private static void Core_StartResourceFallback(nint _server, nint _text) => throw new Exceptions.OutdatedSdkException("Core_StartResource", "Core_StartResource SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_StopResourceDelegate(nint _server, nint _text);
        private static void Core_StopResourceFallback(nint _server, nint _text) => throw new Exceptions.OutdatedSdkException("Core_StopResource", "Core_StopResource SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_StopServerDelegate(nint _core);
        private static void Core_StopServerFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_StopServer", "Core_StopServer SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_SubscribeCommandDelegate(nint _server, nint _cmd, CommandCallback _cb);
        private static byte Core_SubscribeCommandFallback(nint _server, nint _cmd, CommandCallback _cb) => throw new Exceptions.OutdatedSdkException("Core_SubscribeCommand", "Core_SubscribeCommand SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_TriggerClientEventDelegate(nint _server, nint _target, nint _ev, nint[] args, int _size);
        private static void Core_TriggerClientEventFallback(nint _server, nint _target, nint _ev, nint[] args, int _size) => throw new Exceptions.OutdatedSdkException("Core_TriggerClientEvent", "Core_TriggerClientEvent SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_TriggerClientEventForAllDelegate(nint _server, nint _ev, nint[] args, int _size);
        private static void Core_TriggerClientEventForAllFallback(nint _server, nint _ev, nint[] args, int _size) => throw new Exceptions.OutdatedSdkException("Core_TriggerClientEventForAll", "Core_TriggerClientEventForAll SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_TriggerClientEventForSomeDelegate(nint _server, nint[] targets, int _targetsSize, nint _ev, nint[] args, int _argsSize);
        private static void Core_TriggerClientEventForSomeFallback(nint _server, nint[] targets, int _targetsSize, nint _ev, nint[] args, int _argsSize) => throw new Exceptions.OutdatedSdkException("Core_TriggerClientEventForSome", "Core_TriggerClientEventForSome SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_TriggerClientEventUnreliableDelegate(nint _server, nint _target, nint _ev, nint[] args, int _size);
        private static void Core_TriggerClientEventUnreliableFallback(nint _server, nint _target, nint _ev, nint[] args, int _size) => throw new Exceptions.OutdatedSdkException("Core_TriggerClientEventUnreliable", "Core_TriggerClientEventUnreliable SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_TriggerClientEventUnreliableForAllDelegate(nint _server, nint _ev, nint[] args, int _size);
        private static void Core_TriggerClientEventUnreliableForAllFallback(nint _server, nint _ev, nint[] args, int _size) => throw new Exceptions.OutdatedSdkException("Core_TriggerClientEventUnreliableForAll", "Core_TriggerClientEventUnreliableForAll SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_TriggerClientEventUnreliableForSomeDelegate(nint _server, nint[] targets, int _targetsSize, nint _ev, nint[] args, int _argsSize);
        private static void Core_TriggerClientEventUnreliableForSomeFallback(nint _server, nint[] targets, int _targetsSize, nint _ev, nint[] args, int _argsSize) => throw new Exceptions.OutdatedSdkException("Core_TriggerClientEventUnreliableForSome", "Core_TriggerClientEventUnreliableForSome SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_TriggerServerEventDelegate(nint _server, nint _ev, nint[] args, int _size);
        private static void Core_TriggerServerEventFallback(nint _server, nint _ev, nint[] args, int _size) => throw new Exceptions.OutdatedSdkException("Core_TriggerServerEvent", "Core_TriggerServerEvent SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_UnrgisterMetricDelegate(nint _core, nint _metric);
        private static void Core_UnrgisterMetricFallback(nint _core, nint _metric) => throw new Exceptions.OutdatedSdkException("Core_UnrgisterMetric", "Core_UnrgisterMetric SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Entity_AttachToEntityDelegate(nint _entity, nint _secondEntity, short _otherBone, short _ownBone, Vector3 _pos, Rotation _rot, byte _collision, byte _noFixedRot);
        private static void Entity_AttachToEntityFallback(nint _entity, nint _secondEntity, short _otherBone, short _ownBone, Vector3 _pos, Rotation _rot, byte _collision, byte _noFixedRot) => throw new Exceptions.OutdatedSdkException("Entity_AttachToEntity", "Entity_AttachToEntity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Entity_AttachToEntity_BoneStringDelegate(nint _entity, nint _secondEntity, nint _otherBone, nint _ownBone, Vector3 _pos, Rotation _rot, byte _collision, byte _noFixedRot);
        private static void Entity_AttachToEntity_BoneStringFallback(nint _entity, nint _secondEntity, nint _otherBone, nint _ownBone, Vector3 _pos, Rotation _rot, byte _collision, byte _noFixedRot) => throw new Exceptions.OutdatedSdkException("Entity_AttachToEntity_BoneString", "Entity_AttachToEntity_BoneString SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Entity_DeleteStreamSyncedMetaDataDelegate(nint _entity, nint _key);
        private static void Entity_DeleteStreamSyncedMetaDataFallback(nint _entity, nint _key) => throw new Exceptions.OutdatedSdkException("Entity_DeleteStreamSyncedMetaData", "Entity_DeleteStreamSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Entity_DetachDelegate(nint _entity);
        private static void Entity_DetachFallback(nint _entity) => throw new Exceptions.OutdatedSdkException("Entity_Detach", "Entity_Detach SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Entity_GetStreamedDelegate(nint _entity);
        private static byte Entity_GetStreamedFallback(nint _entity) => throw new Exceptions.OutdatedSdkException("Entity_GetStreamed", "Entity_GetStreamed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Entity_GetVisibleDelegate(nint _entity);
        private static byte Entity_GetVisibleFallback(nint _entity) => throw new Exceptions.OutdatedSdkException("Entity_GetVisible", "Entity_GetVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Entity_HasCollisionDelegate(nint _entity);
        private static byte Entity_HasCollisionFallback(nint _entity) => throw new Exceptions.OutdatedSdkException("Entity_HasCollision", "Entity_HasCollision SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Entity_SetCollisionDelegate(nint _entity, byte _state);
        private static void Entity_SetCollisionFallback(nint _entity, byte _state) => throw new Exceptions.OutdatedSdkException("Entity_SetCollision", "Entity_SetCollision SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Entity_SetNetOwnerDelegate(nint _entity, nint _networkOwnerPlayer, byte _disableMigration);
        private static void Entity_SetNetOwnerFallback(nint _entity, nint _networkOwnerPlayer, byte _disableMigration) => throw new Exceptions.OutdatedSdkException("Entity_SetNetOwner", "Entity_SetNetOwner SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Entity_SetStreamedDelegate(nint _entity, byte _state);
        private static void Entity_SetStreamedFallback(nint _entity, byte _state) => throw new Exceptions.OutdatedSdkException("Entity_SetStreamed", "Entity_SetStreamed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Entity_SetStreamSyncedMetaDataDelegate(nint _entity, nint _key, nint _val);
        private static void Entity_SetStreamSyncedMetaDataFallback(nint _entity, nint _key, nint _val) => throw new Exceptions.OutdatedSdkException("Entity_SetStreamSyncedMetaData", "Entity_SetStreamSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Entity_SetVisibleDelegate(nint _entity, byte _state);
        private static void Entity_SetVisibleFallback(nint _entity, byte _state) => throw new Exceptions.OutdatedSdkException("Entity_SetVisible", "Entity_SetVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_WeaponDamageEvent_SetDamageValueDelegate(nint _event, uint _damageValue);
        private static void Event_WeaponDamageEvent_SetDamageValueFallback(nint _event, uint _damageValue) => throw new Exceptions.OutdatedSdkException("Event_WeaponDamageEvent_SetDamageValue", "Event_WeaponDamageEvent_SetDamageValue SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Metric_BeginDelegate(nint _metric);
        private static void Metric_BeginFallback(nint _metric) => throw new Exceptions.OutdatedSdkException("Metric_Begin", "Metric_Begin SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Metric_EndDelegate(nint _metric);
        private static void Metric_EndFallback(nint _metric) => throw new Exceptions.OutdatedSdkException("Metric_End", "Metric_End SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Metric_GetNameDelegate(nint _metric, int* _size);
        private static nint Metric_GetNameFallback(nint _metric, int* _size) => throw new Exceptions.OutdatedSdkException("Metric_GetName", "Metric_GetName SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong Metric_GetValueDelegate(nint _metric);
        private static ulong Metric_GetValueFallback(nint _metric) => throw new Exceptions.OutdatedSdkException("Metric_GetValue", "Metric_GetValue SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Metric_SetValueDelegate(nint _metric, ulong _value);
        private static void Metric_SetValueFallback(nint _metric, ulong _value) => throw new Exceptions.OutdatedSdkException("Metric_SetValue", "Metric_SetValue SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void NetworkObject_ActivatePhysicsDelegate(nint _networkObject);
        private static void NetworkObject_ActivatePhysicsFallback(nint _networkObject) => throw new Exceptions.OutdatedSdkException("NetworkObject_ActivatePhysics", "NetworkObject_ActivatePhysics SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void NetworkObject_PlaceOnGroundProperlyDelegate(nint _networkObject);
        private static void NetworkObject_PlaceOnGroundProperlyFallback(nint _networkObject) => throw new Exceptions.OutdatedSdkException("NetworkObject_PlaceOnGroundProperly", "NetworkObject_PlaceOnGroundProperly SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void NetworkObject_SetAlphaDelegate(nint _networkObject, byte _alpha);
        private static void NetworkObject_SetAlphaFallback(nint _networkObject, byte _alpha) => throw new Exceptions.OutdatedSdkException("NetworkObject_SetAlpha", "NetworkObject_SetAlpha SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void NetworkObject_SetLodDistanceDelegate(nint _networkObject, ushort _lodDistance);
        private static void NetworkObject_SetLodDistanceFallback(nint _networkObject, ushort _lodDistance) => throw new Exceptions.OutdatedSdkException("NetworkObject_SetLodDistance", "NetworkObject_SetLodDistance SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void NetworkObject_SetTextureVariationDelegate(nint _networkObject, byte _textureVariation);
        private static void NetworkObject_SetTextureVariationFallback(nint _networkObject, byte _textureVariation) => throw new Exceptions.OutdatedSdkException("NetworkObject_SetTextureVariation", "NetworkObject_SetTextureVariation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Ped_SetArmourDelegate(nint _ped, ushort _armor);
        private static void Ped_SetArmourFallback(nint _ped, ushort _armor) => throw new Exceptions.OutdatedSdkException("Ped_SetArmour", "Ped_SetArmour SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Ped_SetCurrentWeaponDelegate(nint _ped, uint _weapon);
        private static void Ped_SetCurrentWeaponFallback(nint _ped, uint _weapon) => throw new Exceptions.OutdatedSdkException("Ped_SetCurrentWeapon", "Ped_SetCurrentWeapon SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Ped_SetHealthDelegate(nint _ped, ushort _health);
        private static void Ped_SetHealthFallback(nint _ped, ushort _health) => throw new Exceptions.OutdatedSdkException("Ped_SetHealth", "Ped_SetHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Ped_SetMaxHealthDelegate(nint _ped, ushort _maxHealth);
        private static void Ped_SetMaxHealthFallback(nint _ped, ushort _maxHealth) => throw new Exceptions.OutdatedSdkException("Ped_SetMaxHealth", "Ped_SetMaxHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_AddWeaponComponentDelegate(nint _player, uint _weapon, uint _component);
        private static void Player_AddWeaponComponentFallback(nint _player, uint _weapon, uint _component) => throw new Exceptions.OutdatedSdkException("Player_AddWeaponComponent", "Player_AddWeaponComponent SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_ClearBloodDamageDelegate(nint _player);
        private static void Player_ClearBloodDamageFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_ClearBloodDamage", "Player_ClearBloodDamage SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_ClearPropsDelegate(nint _player, byte _component);
        private static void Player_ClearPropsFallback(nint _player, byte _component) => throw new Exceptions.OutdatedSdkException("Player_ClearProps", "Player_ClearProps SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_ClearTasksDelegate(nint _player);
        private static void Player_ClearTasksFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_ClearTasks", "Player_ClearTasks SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_DeleteLocalMetaDataDelegate(nint _player, nint _key);
        private static void Player_DeleteLocalMetaDataFallback(nint _player, nint _key) => throw new Exceptions.OutdatedSdkException("Player_DeleteLocalMetaData", "Player_DeleteLocalMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_DespawnDelegate(nint _player);
        private static void Player_DespawnFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_Despawn", "Player_Despawn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Player_GetAuthTokenDelegate(nint _player, int* _size);
        private static nint Player_GetAuthTokenFallback(nint _player, int* _size) => throw new Exceptions.OutdatedSdkException("Player_GetAuthToken", "Player_GetAuthToken SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_GetClothesDelegate(nint _player, byte _component, Cloth* _cloth);
        private static void Player_GetClothesFallback(nint _player, byte _component, Cloth* _cloth) => throw new Exceptions.OutdatedSdkException("Player_GetClothes", "Player_GetClothes SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_GetCurrentWeaponTintIndexDelegate(nint _player);
        private static byte Player_GetCurrentWeaponTintIndexFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetCurrentWeaponTintIndex", "Player_GetCurrentWeaponTintIndex SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate long Player_GetDiscordIdDelegate(nint _player);
        private static long Player_GetDiscordIdFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetDiscordId", "Player_GetDiscordId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_GetDlcClothesDelegate(nint _player, byte _component, DlcCloth* _cloth);
        private static void Player_GetDlcClothesFallback(nint _player, byte _component, DlcCloth* _cloth) => throw new Exceptions.OutdatedSdkException("Player_GetDlcClothes", "Player_GetDlcClothes SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_GetDlcPropsDelegate(nint _player, byte _component, DlcProp* _prop);
        private static void Player_GetDlcPropsFallback(nint _player, byte _component, DlcProp* _prop) => throw new Exceptions.OutdatedSdkException("Player_GetDlcProps", "Player_GetDlcProps SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Player_GetEyeColorDelegate(nint _player);
        private static ushort Player_GetEyeColorFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetEyeColor", "Player_GetEyeColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Player_GetFaceFeatureScaleDelegate(nint _player, byte _index);
        private static float Player_GetFaceFeatureScaleFallback(nint _player, byte _index) => throw new Exceptions.OutdatedSdkException("Player_GetFaceFeatureScale", "Player_GetFaceFeatureScale SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_GetHairColorDelegate(nint _player);
        private static byte Player_GetHairColorFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetHairColor", "Player_GetHairColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_GetHairHighlightColorDelegate(nint _player);
        private static byte Player_GetHairHighlightColorFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetHairHighlightColor", "Player_GetHairHighlightColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_GetHeadBlendDataDelegate(nint _player, HeadBlendData* _headBlendData);
        private static void Player_GetHeadBlendDataFallback(nint _player, HeadBlendData* _headBlendData) => throw new Exceptions.OutdatedSdkException("Player_GetHeadBlendData", "Player_GetHeadBlendData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_GetHeadBlendPaletteColorDelegate(nint _player, byte _id, Rgba* _headBlendPaletteColor);
        private static void Player_GetHeadBlendPaletteColorFallback(nint _player, byte _id, Rgba* _headBlendPaletteColor) => throw new Exceptions.OutdatedSdkException("Player_GetHeadBlendPaletteColor", "Player_GetHeadBlendPaletteColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_GetHeadOverlayDelegate(nint _player, byte _overlayID, HeadOverlay* _headOverlay);
        private static void Player_GetHeadOverlayFallback(nint _player, byte _overlayID, HeadOverlay* _headOverlay) => throw new Exceptions.OutdatedSdkException("Player_GetHeadOverlay", "Player_GetHeadOverlay SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong Player_GetHwidExHashDelegate(nint _player);
        private static ulong Player_GetHwidExHashFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetHwidExHash", "Player_GetHwidExHash SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong Player_GetHwidHashDelegate(nint _player);
        private static ulong Player_GetHwidHashFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetHwidHash", "Player_GetHwidHash SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Player_GetInteriorLocationDelegate(nint _player);
        private static uint Player_GetInteriorLocationFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetInteriorLocation", "Player_GetInteriorLocation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_GetInvincibleDelegate(nint _player);
        private static byte Player_GetInvincibleFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetInvincible", "Player_GetInvincible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Player_GetIPDelegate(nint _player, int* _size);
        private static nint Player_GetIPFallback(nint _player, int* _size) => throw new Exceptions.OutdatedSdkException("Player_GetIP", "Player_GetIP SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Player_GetLastDamagedBodyPartDelegate(nint _player);
        private static uint Player_GetLastDamagedBodyPartFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetLastDamagedBodyPart", "Player_GetLastDamagedBodyPart SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Player_GetLocalMetaDataDelegate(nint _player, nint _key);
        private static nint Player_GetLocalMetaDataFallback(nint _player, nint _key) => throw new Exceptions.OutdatedSdkException("Player_GetLocalMetaData", "Player_GetLocalMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Player_GetPingDelegate(nint _player);
        private static uint Player_GetPingFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetPing", "Player_GetPing SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_GetPropsDelegate(nint _player, byte _component, Prop* _prop);
        private static void Player_GetPropsFallback(nint _player, byte _component, Prop* _prop) => throw new Exceptions.OutdatedSdkException("Player_GetProps", "Player_GetProps SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_GetSendNamesDelegate(nint _player);
        private static byte Player_GetSendNamesFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetSendNames", "Player_GetSendNames SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Player_GetSocialClubNameDelegate(nint _player, int* _size);
        private static nint Player_GetSocialClubNameFallback(nint _player, int* _size) => throw new Exceptions.OutdatedSdkException("Player_GetSocialClubName", "Player_GetSocialClubName SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong Player_GetSocialIDDelegate(nint _player);
        private static ulong Player_GetSocialIDFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetSocialID", "Player_GetSocialID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong Player_GetWeaponCountDelegate(nint _player);
        private static ulong Player_GetWeaponCountFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetWeaponCount", "Player_GetWeaponCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_GetWeaponsDelegate(nint _player, nint* _weapons, uint* _size);
        private static void Player_GetWeaponsFallback(nint _player, nint* _weapons, uint* _size) => throw new Exceptions.OutdatedSdkException("Player_GetWeapons", "Player_GetWeapons SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_GetWeaponTintIndexDelegate(nint _player, uint _weapon);
        private static byte Player_GetWeaponTintIndexFallback(nint _player, uint _weapon) => throw new Exceptions.OutdatedSdkException("Player_GetWeaponTintIndex", "Player_GetWeaponTintIndex SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_GiveWeaponDelegate(nint _player, uint _weapon, int _ammo, byte _selectWeapon);
        private static void Player_GiveWeaponFallback(nint _player, uint _weapon, int _ammo, byte _selectWeapon) => throw new Exceptions.OutdatedSdkException("Player_GiveWeapon", "Player_GiveWeapon SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_HasLocalMetaDataDelegate(nint _player, nint _key);
        private static byte Player_HasLocalMetaDataFallback(nint _player, nint _key) => throw new Exceptions.OutdatedSdkException("Player_HasLocalMetaData", "Player_HasLocalMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_HasWeaponComponentDelegate(nint _player, uint _weapon, uint _component);
        private static byte Player_HasWeaponComponentFallback(nint _player, uint _weapon, uint _component) => throw new Exceptions.OutdatedSdkException("Player_HasWeaponComponent", "Player_HasWeaponComponent SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsConnectedDelegate(nint _player);
        private static byte Player_IsConnectedFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsConnected", "Player_IsConnected SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsCrouchingDelegate(nint _player);
        private static byte Player_IsCrouchingFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsCrouching", "Player_IsCrouching SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsEntityInStreamingRangeDelegate(nint _player, nint _entity);
        private static byte Player_IsEntityInStreamingRangeFallback(nint _player, nint _entity) => throw new Exceptions.OutdatedSdkException("Player_IsEntityInStreamingRange", "Player_IsEntityInStreamingRange SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsStealthyDelegate(nint _player);
        private static byte Player_IsStealthyFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsStealthy", "Player_IsStealthy SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsSuperJumpEnabledDelegate(nint _playere);
        private static byte Player_IsSuperJumpEnabledFallback(nint _playere) => throw new Exceptions.OutdatedSdkException("Player_IsSuperJumpEnabled", "Player_IsSuperJumpEnabled SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_KickDelegate(nint _player, nint _reason);
        private static void Player_KickFallback(nint _player, nint _reason) => throw new Exceptions.OutdatedSdkException("Player_Kick", "Player_Kick SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_PlayAmbientSpeechDelegate(nint _player, nint _speechName, nint _speechParam, uint _speechDictHash);
        private static void Player_PlayAmbientSpeechFallback(nint _player, nint _speechName, nint _speechParam, uint _speechDictHash) => throw new Exceptions.OutdatedSdkException("Player_PlayAmbientSpeech", "Player_PlayAmbientSpeech SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_PlayAnimationDelegate(nint _player, nint _animDict, nint _animName, float _blendInSpeed, float _blendOutSpeed, int _duration, int _flags, float _playbackRate, byte _lockX, byte _lockY, byte _lockZ);
        private static void Player_PlayAnimationFallback(nint _player, nint _animDict, nint _animName, float _blendInSpeed, float _blendOutSpeed, int _duration, int _flags, float _playbackRate, byte _lockX, byte _lockY, byte _lockZ) => throw new Exceptions.OutdatedSdkException("Player_PlayAnimation", "Player_PlayAnimation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_RemoveAllWeaponsDelegate(nint _player);
        private static void Player_RemoveAllWeaponsFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_RemoveAllWeapons", "Player_RemoveAllWeapons SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_RemoveFaceFeatureDelegate(nint _player, byte _index);
        private static byte Player_RemoveFaceFeatureFallback(nint _player, byte _index) => throw new Exceptions.OutdatedSdkException("Player_RemoveFaceFeature", "Player_RemoveFaceFeature SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_RemoveHeadOverlayDelegate(nint _player, byte _overlayID);
        private static byte Player_RemoveHeadOverlayFallback(nint _player, byte _overlayID) => throw new Exceptions.OutdatedSdkException("Player_RemoveHeadOverlay", "Player_RemoveHeadOverlay SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_RemoveWeaponDelegate(nint _player, uint _weapon);
        private static byte Player_RemoveWeaponFallback(nint _player, uint _weapon) => throw new Exceptions.OutdatedSdkException("Player_RemoveWeapon", "Player_RemoveWeapon SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_RemoveWeaponComponentDelegate(nint _player, uint _weapon, uint _component);
        private static void Player_RemoveWeaponComponentFallback(nint _player, uint _weapon, uint _component) => throw new Exceptions.OutdatedSdkException("Player_RemoveWeaponComponent", "Player_RemoveWeaponComponent SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetArmorDelegate(nint _player, ushort _armor);
        private static void Player_SetArmorFallback(nint _player, ushort _armor) => throw new Exceptions.OutdatedSdkException("Player_SetArmor", "Player_SetArmor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_SetClothesDelegate(nint _player, byte _component, ushort _drawable, byte _texture, byte _palette);
        private static byte Player_SetClothesFallback(nint _player, byte _component, ushort _drawable, byte _texture, byte _palette) => throw new Exceptions.OutdatedSdkException("Player_SetClothes", "Player_SetClothes SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetCurrentWeaponDelegate(nint _player, uint _weapon);
        private static void Player_SetCurrentWeaponFallback(nint _player, uint _weapon) => throw new Exceptions.OutdatedSdkException("Player_SetCurrentWeapon", "Player_SetCurrentWeapon SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetDateTimeDelegate(nint _player, int _day, int _month, int _year, int _hour, int _minute, int _second);
        private static void Player_SetDateTimeFallback(nint _player, int _day, int _month, int _year, int _hour, int _minute, int _second) => throw new Exceptions.OutdatedSdkException("Player_SetDateTime", "Player_SetDateTime SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_SetDlcClothesDelegate(nint _player, byte _component, ushort _drawable, byte _texture, byte _palette, uint _dlc);
        private static byte Player_SetDlcClothesFallback(nint _player, byte _component, ushort _drawable, byte _texture, byte _palette, uint _dlc) => throw new Exceptions.OutdatedSdkException("Player_SetDlcClothes", "Player_SetDlcClothes SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_SetDlcPropsDelegate(nint _player, byte _component, ushort _drawable, byte _texture, uint _dlc);
        private static byte Player_SetDlcPropsFallback(nint _player, byte _component, ushort _drawable, byte _texture, uint _dlc) => throw new Exceptions.OutdatedSdkException("Player_SetDlcProps", "Player_SetDlcProps SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_SetEyeColorDelegate(nint _player, ushort _eyeColor);
        private static byte Player_SetEyeColorFallback(nint _player, ushort _eyeColor) => throw new Exceptions.OutdatedSdkException("Player_SetEyeColor", "Player_SetEyeColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_SetFaceFeatureDelegate(nint _player, byte _index, float _scale);
        private static byte Player_SetFaceFeatureFallback(nint _player, byte _index, float _scale) => throw new Exceptions.OutdatedSdkException("Player_SetFaceFeature", "Player_SetFaceFeature SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetHairColorDelegate(nint _player, byte _hairColor);
        private static void Player_SetHairColorFallback(nint _player, byte _hairColor) => throw new Exceptions.OutdatedSdkException("Player_SetHairColor", "Player_SetHairColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetHairHighlightColorDelegate(nint _player, byte _hairHighlightColor);
        private static void Player_SetHairHighlightColorFallback(nint _player, byte _hairHighlightColor) => throw new Exceptions.OutdatedSdkException("Player_SetHairHighlightColor", "Player_SetHairHighlightColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetHeadBlendDataDelegate(nint _player, uint _shapeFirstID, uint _shapeSecondID, uint _shapeThirdID, uint _skinFirstID, uint _skinSecondID, uint _skinThirdID, float _shapeMix, float _skinMix, float _thirdMix);
        private static void Player_SetHeadBlendDataFallback(nint _player, uint _shapeFirstID, uint _shapeSecondID, uint _shapeThirdID, uint _skinFirstID, uint _skinSecondID, uint _skinThirdID, float _shapeMix, float _skinMix, float _thirdMix) => throw new Exceptions.OutdatedSdkException("Player_SetHeadBlendData", "Player_SetHeadBlendData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_SetHeadBlendPaletteColorDelegate(nint _player, byte _id, byte _red, byte _green, byte _blue);
        private static byte Player_SetHeadBlendPaletteColorFallback(nint _player, byte _id, byte _red, byte _green, byte _blue) => throw new Exceptions.OutdatedSdkException("Player_SetHeadBlendPaletteColor", "Player_SetHeadBlendPaletteColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_SetHeadOverlayDelegate(nint _player, byte _overlayID, byte _index, float _opacity);
        private static byte Player_SetHeadOverlayFallback(nint _player, byte _overlayID, byte _index, float _opacity) => throw new Exceptions.OutdatedSdkException("Player_SetHeadOverlay", "Player_SetHeadOverlay SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_SetHeadOverlayColorDelegate(nint _player, byte _overlayID, byte _colorType, byte _colorIndex, byte _secondColorIndex);
        private static byte Player_SetHeadOverlayColorFallback(nint _player, byte _overlayID, byte _colorType, byte _colorIndex, byte _secondColorIndex) => throw new Exceptions.OutdatedSdkException("Player_SetHeadOverlayColor", "Player_SetHeadOverlayColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetHealthDelegate(nint _player, ushort _health);
        private static void Player_SetHealthFallback(nint _player, ushort _health) => throw new Exceptions.OutdatedSdkException("Player_SetHealth", "Player_SetHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetIntoVehicleDelegate(nint _player, nint _vehicle, byte _seat);
        private static void Player_SetIntoVehicleFallback(nint _player, nint _vehicle, byte _seat) => throw new Exceptions.OutdatedSdkException("Player_SetIntoVehicle", "Player_SetIntoVehicle SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetInvincibleDelegate(nint _player, byte _state);
        private static void Player_SetInvincibleFallback(nint _player, byte _state) => throw new Exceptions.OutdatedSdkException("Player_SetInvincible", "Player_SetInvincible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetLastDamagedBodyPartDelegate(nint _player, uint _bodyPart);
        private static void Player_SetLastDamagedBodyPartFallback(nint _player, uint _bodyPart) => throw new Exceptions.OutdatedSdkException("Player_SetLastDamagedBodyPart", "Player_SetLastDamagedBodyPart SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetLocalMetaDataDelegate(nint _player, nint _key, nint _val);
        private static void Player_SetLocalMetaDataFallback(nint _player, nint _key, nint _val) => throw new Exceptions.OutdatedSdkException("Player_SetLocalMetaData", "Player_SetLocalMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetMaxArmorDelegate(nint _player, ushort _armor);
        private static void Player_SetMaxArmorFallback(nint _player, ushort _armor) => throw new Exceptions.OutdatedSdkException("Player_SetMaxArmor", "Player_SetMaxArmor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetMaxHealthDelegate(nint _player, ushort _maxHealth);
        private static void Player_SetMaxHealthFallback(nint _player, ushort _maxHealth) => throw new Exceptions.OutdatedSdkException("Player_SetMaxHealth", "Player_SetMaxHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetModelDelegate(nint _player, uint _model);
        private static void Player_SetModelFallback(nint _player, uint _model) => throw new Exceptions.OutdatedSdkException("Player_SetModel", "Player_SetModel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_SetPropsDelegate(nint _player, byte _component, ushort _drawable, byte _texture);
        private static byte Player_SetPropsFallback(nint _player, byte _component, ushort _drawable, byte _texture) => throw new Exceptions.OutdatedSdkException("Player_SetProps", "Player_SetProps SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetSendNamesDelegate(nint _player, byte _state);
        private static void Player_SetSendNamesFallback(nint _player, byte _state) => throw new Exceptions.OutdatedSdkException("Player_SetSendNames", "Player_SetSendNames SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetWeaponTintIndexDelegate(nint _player, uint _weapon, byte _tintIndex);
        private static void Player_SetWeaponTintIndexFallback(nint _player, uint _weapon, byte _tintIndex) => throw new Exceptions.OutdatedSdkException("Player_SetWeaponTintIndex", "Player_SetWeaponTintIndex SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetWeatherDelegate(nint _player, uint _weather);
        private static void Player_SetWeatherFallback(nint _player, uint _weather) => throw new Exceptions.OutdatedSdkException("Player_SetWeather", "Player_SetWeather SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SpawnDelegate(nint _player, Vector3 _pos, uint _delayMs);
        private static void Player_SpawnFallback(nint _player, Vector3 _pos, uint _delayMs) => throw new Exceptions.OutdatedSdkException("Player_Spawn", "Player_Spawn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Resource_GetMainDelegate(nint _resource, int* _size);
        private static nint Resource_GetMainFallback(nint _resource, int* _size) => throw new Exceptions.OutdatedSdkException("Resource_GetMain", "Resource_GetMain SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Resource_GetPathDelegate(nint _resource, int* _size);
        private static nint Resource_GetPathFallback(nint _resource, int* _size) => throw new Exceptions.OutdatedSdkException("Resource_GetPath", "Resource_GetPath SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Resource_StartDelegate(nint _resource);
        private static void Resource_StartFallback(nint _resource) => throw new Exceptions.OutdatedSdkException("Resource_Start", "Resource_Start SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Resource_StopDelegate(nint _resource);
        private static void Resource_StopFallback(nint _resource) => throw new Exceptions.OutdatedSdkException("Resource_Stop", "Resource_Stop SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_DoesWheelHasTireDelegate(nint _vehicle, byte _wheelId);
        private static byte Vehicle_DoesWheelHasTireFallback(nint _vehicle, byte _wheelId) => throw new Exceptions.OutdatedSdkException("Vehicle_DoesWheelHasTire", "Vehicle_DoesWheelHasTire SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Vehicle_GetAppearanceDataBase64Delegate(nint _vehicle, int* _size);
        private static nint Vehicle_GetAppearanceDataBase64Fallback(nint _vehicle, int* _size) => throw new Exceptions.OutdatedSdkException("Vehicle_GetAppearanceDataBase64", "Vehicle_GetAppearanceDataBase64 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetArmoredWindowHealthDelegate(nint _vehicle, byte _windowId);
        private static float Vehicle_GetArmoredWindowHealthFallback(nint _vehicle, byte _windowId) => throw new Exceptions.OutdatedSdkException("Vehicle_GetArmoredWindowHealth", "Vehicle_GetArmoredWindowHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetArmoredWindowShootCountDelegate(nint _vehicle, byte _windowId);
        private static byte Vehicle_GetArmoredWindowShootCountFallback(nint _vehicle, byte _windowId) => throw new Exceptions.OutdatedSdkException("Vehicle_GetArmoredWindowShootCount", "Vehicle_GetArmoredWindowShootCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Vehicle_GetAttachedDelegate(nint _vehicle);
        private static nint Vehicle_GetAttachedFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetAttached", "Vehicle_GetAttached SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Vehicle_GetAttachedToDelegate(nint _vehicle);
        private static nint Vehicle_GetAttachedToFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetAttachedTo", "Vehicle_GetAttachedTo SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetBoatAnchorDelegate(nint _vehicle);
        private static byte Vehicle_GetBoatAnchorFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetBoatAnchor", "Vehicle_GetBoatAnchor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Vehicle_GetBodyAdditionalHealthDelegate(nint _vehicle);
        private static uint Vehicle_GetBodyAdditionalHealthFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetBodyAdditionalHealth", "Vehicle_GetBodyAdditionalHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Vehicle_GetBodyHealthDelegate(nint _vehicle);
        private static uint Vehicle_GetBodyHealthFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetBodyHealth", "Vehicle_GetBodyHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetBumperDamageLevelDelegate(nint _vehicle, byte _bumperId);
        private static byte Vehicle_GetBumperDamageLevelFallback(nint _vehicle, byte _bumperId) => throw new Exceptions.OutdatedSdkException("Vehicle_GetBumperDamageLevel", "Vehicle_GetBumperDamageLevel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Vehicle_GetCounterMeasureCountDelegate(nint _vehicle);
        private static uint Vehicle_GetCounterMeasureCountFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetCounterMeasureCount", "Vehicle_GetCounterMeasureCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetCustomTiresDelegate(nint _vehicle);
        private static byte Vehicle_GetCustomTiresFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetCustomTires", "Vehicle_GetCustomTires SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Vehicle_GetDamageDataBase64Delegate(nint _vehicle, int* _size);
        private static nint Vehicle_GetDamageDataBase64Fallback(nint _vehicle, int* _size) => throw new Exceptions.OutdatedSdkException("Vehicle_GetDamageDataBase64", "Vehicle_GetDamageDataBase64 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetDashboardColorDelegate(nint _vehicle);
        private static byte Vehicle_GetDashboardColorFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetDashboardColor", "Vehicle_GetDashboardColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetDirtLevelDelegate(nint _vehicle);
        private static byte Vehicle_GetDirtLevelFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetDirtLevel", "Vehicle_GetDirtLevel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetDoorStateDelegate(nint _vehicle, byte _doorId);
        private static byte Vehicle_GetDoorStateFallback(nint _vehicle, byte _doorId) => throw new Exceptions.OutdatedSdkException("Vehicle_GetDoorState", "Vehicle_GetDoorState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Vehicle_GetDriverDelegate(nint _vehicle);
        private static nint Vehicle_GetDriverFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetDriver", "Vehicle_GetDriver SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetDriverIDDelegate(nint _vehicle, ushort* _id);
        private static byte Vehicle_GetDriverIDFallback(nint _vehicle, ushort* _id) => throw new Exceptions.OutdatedSdkException("Vehicle_GetDriverID", "Vehicle_GetDriverID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate int Vehicle_GetEngineHealthDelegate(nint _vehicle);
        private static int Vehicle_GetEngineHealthFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetEngineHealth", "Vehicle_GetEngineHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Vehicle_GetGameStateBase64Delegate(nint _vehicle, int* _size);
        private static nint Vehicle_GetGameStateBase64Fallback(nint _vehicle, int* _size) => throw new Exceptions.OutdatedSdkException("Vehicle_GetGameStateBase64", "Vehicle_GetGameStateBase64 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetHeadlightColorDelegate(nint _vehicle);
        private static byte Vehicle_GetHeadlightColorFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetHeadlightColor", "Vehicle_GetHeadlightColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Vehicle_GetHealthDataBase64Delegate(nint _vehicle, int* _size);
        private static nint Vehicle_GetHealthDataBase64Fallback(nint _vehicle, int* _size) => throw new Exceptions.OutdatedSdkException("Vehicle_GetHealthDataBase64", "Vehicle_GetHealthDataBase64 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetHybridExtraActiveDelegate(nint _vehicle);
        private static byte Vehicle_GetHybridExtraActiveFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetHybridExtraActive", "Vehicle_GetHybridExtraActive SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetHybridExtraStateDelegate(nint _vehicle);
        private static byte Vehicle_GetHybridExtraStateFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetHybridExtraState", "Vehicle_GetHybridExtraState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetInteriorColorDelegate(nint _vehicle);
        private static byte Vehicle_GetInteriorColorFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetInteriorColor", "Vehicle_GetInteriorColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetLightsMultiplierDelegate(nint _vehicle);
        private static float Vehicle_GetLightsMultiplierFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetLightsMultiplier", "Vehicle_GetLightsMultiplier SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetLightStateDelegate(nint _vehicle);
        private static byte Vehicle_GetLightStateFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetLightState", "Vehicle_GetLightState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetLiveryDelegate(nint _vehicle);
        private static byte Vehicle_GetLiveryFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetLivery", "Vehicle_GetLivery SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetLockStateDelegate(nint _vehicle);
        private static byte Vehicle_GetLockStateFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetLockState", "Vehicle_GetLockState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetModDelegate(nint _vehicle, byte _category);
        private static byte Vehicle_GetModFallback(nint _vehicle, byte _category) => throw new Exceptions.OutdatedSdkException("Vehicle_GetMod", "Vehicle_GetMod SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetModKitDelegate(nint _vehicle);
        private static byte Vehicle_GetModKitFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetModKit", "Vehicle_GetModKit SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetModKitsCountDelegate(nint _vehicle);
        private static byte Vehicle_GetModKitsCountFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetModKitsCount", "Vehicle_GetModKitsCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetModsCountDelegate(nint _vehicle, byte _category);
        private static byte Vehicle_GetModsCountFallback(nint _vehicle, byte _category) => throw new Exceptions.OutdatedSdkException("Vehicle_GetModsCount", "Vehicle_GetModsCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_GetNeonActiveDelegate(nint _vehicle, byte* _left, byte* _right, byte* _front, byte* _back);
        private static void Vehicle_GetNeonActiveFallback(nint _vehicle, byte* _left, byte* _right, byte* _front, byte* _back) => throw new Exceptions.OutdatedSdkException("Vehicle_GetNeonActive", "Vehicle_GetNeonActive SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_GetNeonColorDelegate(nint _vehicle, Rgba* _neonColor);
        private static void Vehicle_GetNeonColorFallback(nint _vehicle, Rgba* _neonColor) => throw new Exceptions.OutdatedSdkException("Vehicle_GetNeonColor", "Vehicle_GetNeonColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Vehicle_GetNumberplateIndexDelegate(nint _vehicle);
        private static uint Vehicle_GetNumberplateIndexFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetNumberplateIndex", "Vehicle_GetNumberplateIndex SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Vehicle_GetNumberplateTextDelegate(nint _vehicle, int* _size);
        private static nint Vehicle_GetNumberplateTextFallback(nint _vehicle, int* _size) => throw new Exceptions.OutdatedSdkException("Vehicle_GetNumberplateText", "Vehicle_GetNumberplateText SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetPartBulletHolesDelegate(nint _vehicle, byte _partId);
        private static byte Vehicle_GetPartBulletHolesFallback(nint _vehicle, byte _partId) => throw new Exceptions.OutdatedSdkException("Vehicle_GetPartBulletHoles", "Vehicle_GetPartBulletHoles SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetPartDamageLevelDelegate(nint _vehicle, byte _partId);
        private static byte Vehicle_GetPartDamageLevelFallback(nint _vehicle, byte _partId) => throw new Exceptions.OutdatedSdkException("Vehicle_GetPartDamageLevel", "Vehicle_GetPartDamageLevel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetPearlColorDelegate(nint _vehicle);
        private static byte Vehicle_GetPearlColorFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetPearlColor", "Vehicle_GetPearlColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetPrimaryColorDelegate(nint _vehicle);
        private static byte Vehicle_GetPrimaryColorFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetPrimaryColor", "Vehicle_GetPrimaryColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_GetPrimaryColorRGBDelegate(nint _vehicle, Rgba* _primaryColor);
        private static void Vehicle_GetPrimaryColorRGBFallback(nint _vehicle, Rgba* _primaryColor) => throw new Exceptions.OutdatedSdkException("Vehicle_GetPrimaryColorRGB", "Vehicle_GetPrimaryColorRGB SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate Quaternion Vehicle_GetQuaternionDelegate(nint _vehicle);
        private static Quaternion Vehicle_GetQuaternionFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetQuaternion", "Vehicle_GetQuaternion SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Vehicle_GetRadioStationIndexDelegate(nint _vehicle);
        private static uint Vehicle_GetRadioStationIndexFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetRadioStationIndex", "Vehicle_GetRadioStationIndex SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetRearWheelVariationDelegate(nint _vehicle);
        private static byte Vehicle_GetRearWheelVariationFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetRearWheelVariation", "Vehicle_GetRearWheelVariation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetRepairsCountDelegate(nint _vehicle);
        private static byte Vehicle_GetRepairsCountFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetRepairsCount", "Vehicle_GetRepairsCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetRocketRefuelSpeedDelegate(nint _vehicle);
        private static float Vehicle_GetRocketRefuelSpeedFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetRocketRefuelSpeed", "Vehicle_GetRocketRefuelSpeed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetRoofLiveryDelegate(nint _vehicle);
        private static byte Vehicle_GetRoofLiveryFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetRoofLivery", "Vehicle_GetRoofLivery SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetRoofStateDelegate(nint _vehicle);
        private static byte Vehicle_GetRoofStateFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetRoofState", "Vehicle_GetRoofState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Vehicle_GetScriptDataBase64Delegate(nint _vehicle, int* _size);
        private static nint Vehicle_GetScriptDataBase64Fallback(nint _vehicle, int* _size) => throw new Exceptions.OutdatedSdkException("Vehicle_GetScriptDataBase64", "Vehicle_GetScriptDataBase64 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetScriptMaxSpeedDelegate(nint _vehicle);
        private static float Vehicle_GetScriptMaxSpeedFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetScriptMaxSpeed", "Vehicle_GetScriptMaxSpeed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetSecondaryColorDelegate(nint _vehicle);
        private static byte Vehicle_GetSecondaryColorFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetSecondaryColor", "Vehicle_GetSecondaryColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_GetSecondaryColorRGBDelegate(nint _vehicle, Rgba* _secondaryColor);
        private static void Vehicle_GetSecondaryColorRGBFallback(nint _vehicle, Rgba* _secondaryColor) => throw new Exceptions.OutdatedSdkException("Vehicle_GetSecondaryColorRGB", "Vehicle_GetSecondaryColorRGB SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetSpecialDarknessDelegate(nint _vehicle);
        private static byte Vehicle_GetSpecialDarknessFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetSpecialDarkness", "Vehicle_GetSpecialDarkness SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Vehicle_GetTimedExplosionCulpritDelegate(nint _vehicle);
        private static nint Vehicle_GetTimedExplosionCulpritFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetTimedExplosionCulprit", "Vehicle_GetTimedExplosionCulprit SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Vehicle_GetTimedExplosionTimeDelegate(nint _vehicle);
        private static uint Vehicle_GetTimedExplosionTimeFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetTimedExplosionTime", "Vehicle_GetTimedExplosionTime SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_GetTireSmokeColorDelegate(nint _vehicle, Rgba* _tireSmokeColor);
        private static void Vehicle_GetTireSmokeColorFallback(nint _vehicle, Rgba* _tireSmokeColor) => throw new Exceptions.OutdatedSdkException("Vehicle_GetTireSmokeColor", "Vehicle_GetTireSmokeColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate sbyte Vehicle_GetTrainCarriageConfigIndexDelegate(nint _vehicle);
        private static sbyte Vehicle_GetTrainCarriageConfigIndexFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetTrainCarriageConfigIndex", "Vehicle_GetTrainCarriageConfigIndex SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate sbyte Vehicle_GetTrainConfigIndexDelegate(nint _vehicle);
        private static sbyte Vehicle_GetTrainConfigIndexFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetTrainConfigIndex", "Vehicle_GetTrainConfigIndex SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetTrainCruiseSpeedDelegate(nint _vehicle);
        private static float Vehicle_GetTrainCruiseSpeedFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetTrainCruiseSpeed", "Vehicle_GetTrainCruiseSpeed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetTrainDirectionDelegate(nint _vehicle);
        private static byte Vehicle_GetTrainDirectionFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetTrainDirection", "Vehicle_GetTrainDirection SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetTrainDistanceFromEngineDelegate(nint _vehicle);
        private static float Vehicle_GetTrainDistanceFromEngineFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetTrainDistanceFromEngine", "Vehicle_GetTrainDistanceFromEngine SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Vehicle_GetTrainEngineIdDelegate(nint _vehicle);
        private static nint Vehicle_GetTrainEngineIdFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetTrainEngineId", "Vehicle_GetTrainEngineId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetTrainForceDoorsOpenDelegate(nint _vehicle);
        private static byte Vehicle_GetTrainForceDoorsOpenFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetTrainForceDoorsOpen", "Vehicle_GetTrainForceDoorsOpen SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Vehicle_GetTrainLinkedToBackwardIdDelegate(nint _vehicle);
        private static nint Vehicle_GetTrainLinkedToBackwardIdFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetTrainLinkedToBackwardId", "Vehicle_GetTrainLinkedToBackwardId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Vehicle_GetTrainLinkedToForwardIdDelegate(nint _vehicle);
        private static nint Vehicle_GetTrainLinkedToForwardIdFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetTrainLinkedToForwardId", "Vehicle_GetTrainLinkedToForwardId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetTrainRenderDerailedDelegate(nint _vehicle);
        private static byte Vehicle_GetTrainRenderDerailedFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetTrainRenderDerailed", "Vehicle_GetTrainRenderDerailed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate sbyte Vehicle_GetTrainTrackIdDelegate(nint _vehicle);
        private static sbyte Vehicle_GetTrainTrackIdFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetTrainTrackId", "Vehicle_GetTrainTrackId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_GetVelocityDelegate(nint _vehicle, Vector3* _velocity);
        private static void Vehicle_GetVelocityFallback(nint _vehicle, Vector3* _velocity) => throw new Exceptions.OutdatedSdkException("Vehicle_GetVelocity", "Vehicle_GetVelocity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate int Vehicle_GetWeaponCapacityDelegate(nint _vehicle, byte _index);
        private static int Vehicle_GetWeaponCapacityFallback(nint _vehicle, byte _index) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWeaponCapacity", "Vehicle_GetWeaponCapacity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetWheelColorDelegate(nint _vehicle);
        private static byte Vehicle_GetWheelColorFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWheelColor", "Vehicle_GetWheelColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetWheelHealthDelegate(nint _vehicle, byte _wheelId);
        private static float Vehicle_GetWheelHealthFallback(nint _vehicle, byte _wheelId) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWheelHealth", "Vehicle_GetWheelHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetWheelTypeDelegate(nint _vehicle);
        private static byte Vehicle_GetWheelTypeFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWheelType", "Vehicle_GetWheelType SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetWheelVariationDelegate(nint _vehicle);
        private static byte Vehicle_GetWheelVariationFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWheelVariation", "Vehicle_GetWheelVariation SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetWindowTintDelegate(nint _vehicle);
        private static byte Vehicle_GetWindowTintFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWindowTint", "Vehicle_GetWindowTint SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_HasArmoredWindowsDelegate(nint _vehicle);
        private static byte Vehicle_HasArmoredWindowsFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_HasArmoredWindows", "Vehicle_HasArmoredWindows SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_HasTimedExplosionDelegate(nint _vehicle);
        private static byte Vehicle_HasTimedExplosionFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_HasTimedExplosion", "Vehicle_HasTimedExplosion SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_HasTrainPassengerCarriagesDelegate(nint _vehicle);
        private static byte Vehicle_HasTrainPassengerCarriagesFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_HasTrainPassengerCarriages", "Vehicle_HasTrainPassengerCarriages SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsDaylightOnDelegate(nint _vehicle);
        private static byte Vehicle_IsDaylightOnFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsDaylightOn", "Vehicle_IsDaylightOn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsDestroyedDelegate(nint _vehicle);
        private static byte Vehicle_IsDestroyedFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsDestroyed", "Vehicle_IsDestroyed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsDriftModeDelegate(nint _vehicle);
        private static byte Vehicle_IsDriftModeFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsDriftMode", "Vehicle_IsDriftMode SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsEngineOnDelegate(nint _vehicle);
        private static byte Vehicle_IsEngineOnFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsEngineOn", "Vehicle_IsEngineOn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsExtraOnDelegate(nint _vehicle, byte _extraID);
        private static byte Vehicle_IsExtraOnFallback(nint _vehicle, byte _extraID) => throw new Exceptions.OutdatedSdkException("Vehicle_IsExtraOn", "Vehicle_IsExtraOn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsFlamethrowerActiveDelegate(nint _vehicle);
        private static byte Vehicle_IsFlamethrowerActiveFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsFlamethrowerActive", "Vehicle_IsFlamethrowerActive SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsHandbrakeActiveDelegate(nint _vehicle);
        private static byte Vehicle_IsHandbrakeActiveFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsHandbrakeActive", "Vehicle_IsHandbrakeActive SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsLightDamagedDelegate(nint _vehicle, byte _lightId);
        private static byte Vehicle_IsLightDamagedFallback(nint _vehicle, byte _lightId) => throw new Exceptions.OutdatedSdkException("Vehicle_IsLightDamaged", "Vehicle_IsLightDamaged SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsManualEngineControlDelegate(nint _vehicle);
        private static byte Vehicle_IsManualEngineControlFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsManualEngineControl", "Vehicle_IsManualEngineControl SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsNeonActiveDelegate(nint _vehicle);
        private static byte Vehicle_IsNeonActiveFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsNeonActive", "Vehicle_IsNeonActive SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsNightlightOnDelegate(nint _vehicle);
        private static byte Vehicle_IsNightlightOnFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsNightlightOn", "Vehicle_IsNightlightOn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsPrimaryColorRGBDelegate(nint _vehicle);
        private static byte Vehicle_IsPrimaryColorRGBFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsPrimaryColorRGB", "Vehicle_IsPrimaryColorRGB SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsSecondaryColorRGBDelegate(nint _vehicle);
        private static byte Vehicle_IsSecondaryColorRGBFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsSecondaryColorRGB", "Vehicle_IsSecondaryColorRGB SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsSirenActiveDelegate(nint _vehicle);
        private static byte Vehicle_IsSirenActiveFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsSirenActive", "Vehicle_IsSirenActive SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsSpecialLightDamagedDelegate(nint _vehicle, byte _specialLightId);
        private static byte Vehicle_IsSpecialLightDamagedFallback(nint _vehicle, byte _specialLightId) => throw new Exceptions.OutdatedSdkException("Vehicle_IsSpecialLightDamaged", "Vehicle_IsSpecialLightDamaged SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsTireSmokeColorCustomDelegate(nint _vehicle);
        private static byte Vehicle_IsTireSmokeColorCustomFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsTireSmokeColorCustom", "Vehicle_IsTireSmokeColorCustom SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsTowingDisabledDelegate(nint _vehicle);
        private static byte Vehicle_IsTowingDisabledFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsTowingDisabled", "Vehicle_IsTowingDisabled SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsTrainCabooseDelegate(nint _vehicle);
        private static byte Vehicle_IsTrainCabooseFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsTrainCaboose", "Vehicle_IsTrainCaboose SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsTrainEngineDelegate(nint _vehicle);
        private static byte Vehicle_IsTrainEngineFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsTrainEngine", "Vehicle_IsTrainEngine SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsTrainMissionTrainDelegate(nint _vehicle);
        private static byte Vehicle_IsTrainMissionTrainFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsTrainMissionTrain", "Vehicle_IsTrainMissionTrain SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsWheelBurstDelegate(nint _vehicle, byte _wheelId);
        private static byte Vehicle_IsWheelBurstFallback(nint _vehicle, byte _wheelId) => throw new Exceptions.OutdatedSdkException("Vehicle_IsWheelBurst", "Vehicle_IsWheelBurst SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsWheelDetachedDelegate(nint _vehicle, byte _wheelId);
        private static byte Vehicle_IsWheelDetachedFallback(nint _vehicle, byte _wheelId) => throw new Exceptions.OutdatedSdkException("Vehicle_IsWheelDetached", "Vehicle_IsWheelDetached SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsWheelOnFireDelegate(nint _vehicle, byte _wheelId);
        private static byte Vehicle_IsWheelOnFireFallback(nint _vehicle, byte _wheelId) => throw new Exceptions.OutdatedSdkException("Vehicle_IsWheelOnFire", "Vehicle_IsWheelOnFire SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsWindowDamagedDelegate(nint _vehicle, byte _windowId);
        private static byte Vehicle_IsWindowDamagedFallback(nint _vehicle, byte _windowId) => throw new Exceptions.OutdatedSdkException("Vehicle_IsWindowDamaged", "Vehicle_IsWindowDamaged SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsWindowOpenedDelegate(nint _vehicle, byte _windowId);
        private static byte Vehicle_IsWindowOpenedFallback(nint _vehicle, byte _windowId) => throw new Exceptions.OutdatedSdkException("Vehicle_IsWindowOpened", "Vehicle_IsWindowOpened SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_LoadAppearanceDataFromBase64Delegate(nint _vehicle, nint _base64);
        private static void Vehicle_LoadAppearanceDataFromBase64Fallback(nint _vehicle, nint _base64) => throw new Exceptions.OutdatedSdkException("Vehicle_LoadAppearanceDataFromBase64", "Vehicle_LoadAppearanceDataFromBase64 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_LoadDamageDataFromBase64Delegate(nint _vehicle, nint _base64);
        private static void Vehicle_LoadDamageDataFromBase64Fallback(nint _vehicle, nint _base64) => throw new Exceptions.OutdatedSdkException("Vehicle_LoadDamageDataFromBase64", "Vehicle_LoadDamageDataFromBase64 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_LoadGameStateFromBase64Delegate(nint _vehicle, nint _base64);
        private static void Vehicle_LoadGameStateFromBase64Fallback(nint _vehicle, nint _base64) => throw new Exceptions.OutdatedSdkException("Vehicle_LoadGameStateFromBase64", "Vehicle_LoadGameStateFromBase64 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_LoadHealthDataFromBase64Delegate(nint _vehicle, nint _base64);
        private static void Vehicle_LoadHealthDataFromBase64Fallback(nint _vehicle, nint _base64) => throw new Exceptions.OutdatedSdkException("Vehicle_LoadHealthDataFromBase64", "Vehicle_LoadHealthDataFromBase64 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_LoadScriptDataFromBase64Delegate(nint _vehicle, nint _base64);
        private static void Vehicle_LoadScriptDataFromBase64Fallback(nint _vehicle, nint _base64) => throw new Exceptions.OutdatedSdkException("Vehicle_LoadScriptDataFromBase64", "Vehicle_LoadScriptDataFromBase64 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_RepairDelegate(nint _vehicle);
        private static void Vehicle_RepairFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Repair", "Vehicle_Repair SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetArmoredWindowHealthDelegate(nint _vehicle, byte _windowId, float _health);
        private static void Vehicle_SetArmoredWindowHealthFallback(nint _vehicle, byte _windowId, float _health) => throw new Exceptions.OutdatedSdkException("Vehicle_SetArmoredWindowHealth", "Vehicle_SetArmoredWindowHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetArmoredWindowShootCountDelegate(nint _vehicle, byte _windowId, byte _count);
        private static void Vehicle_SetArmoredWindowShootCountFallback(nint _vehicle, byte _windowId, byte _count) => throw new Exceptions.OutdatedSdkException("Vehicle_SetArmoredWindowShootCount", "Vehicle_SetArmoredWindowShootCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetBoatAnchorDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetBoatAnchorFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetBoatAnchor", "Vehicle_SetBoatAnchor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetBodyAdditionalHealthDelegate(nint _vehicle, uint _health);
        private static void Vehicle_SetBodyAdditionalHealthFallback(nint _vehicle, uint _health) => throw new Exceptions.OutdatedSdkException("Vehicle_SetBodyAdditionalHealth", "Vehicle_SetBodyAdditionalHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetBodyHealthDelegate(nint _vehicle, uint _health);
        private static void Vehicle_SetBodyHealthFallback(nint _vehicle, uint _health) => throw new Exceptions.OutdatedSdkException("Vehicle_SetBodyHealth", "Vehicle_SetBodyHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetBumperDamageLevelDelegate(nint _vehicle, byte _bumperId, byte _damageLevel);
        private static void Vehicle_SetBumperDamageLevelFallback(nint _vehicle, byte _bumperId, byte _damageLevel) => throw new Exceptions.OutdatedSdkException("Vehicle_SetBumperDamageLevel", "Vehicle_SetBumperDamageLevel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetCounterMeasureCountDelegate(nint _vehicle, uint _counterMeasureCount);
        private static void Vehicle_SetCounterMeasureCountFallback(nint _vehicle, uint _counterMeasureCount) => throw new Exceptions.OutdatedSdkException("Vehicle_SetCounterMeasureCount", "Vehicle_SetCounterMeasureCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetCustomTiresDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetCustomTiresFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetCustomTires", "Vehicle_SetCustomTires SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetDashboardColorDelegate(nint _vehicle, byte _color);
        private static void Vehicle_SetDashboardColorFallback(nint _vehicle, byte _color) => throw new Exceptions.OutdatedSdkException("Vehicle_SetDashboardColor", "Vehicle_SetDashboardColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetDirtLevelDelegate(nint _vehicle, byte _level);
        private static void Vehicle_SetDirtLevelFallback(nint _vehicle, byte _level) => throw new Exceptions.OutdatedSdkException("Vehicle_SetDirtLevel", "Vehicle_SetDirtLevel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetDisableTowingDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetDisableTowingFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetDisableTowing", "Vehicle_SetDisableTowing SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetDoorStateDelegate(nint _vehicle, byte _doorId, byte _state);
        private static void Vehicle_SetDoorStateFallback(nint _vehicle, byte _doorId, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetDoorState", "Vehicle_SetDoorState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetDriftModeDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetDriftModeFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetDriftMode", "Vehicle_SetDriftMode SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetEngineHealthDelegate(nint _vehicle, int _health);
        private static void Vehicle_SetEngineHealthFallback(nint _vehicle, int _health) => throw new Exceptions.OutdatedSdkException("Vehicle_SetEngineHealth", "Vehicle_SetEngineHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetEngineOnDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetEngineOnFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetEngineOn", "Vehicle_SetEngineOn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetHeadlightColorDelegate(nint _vehicle, byte _color);
        private static void Vehicle_SetHeadlightColorFallback(nint _vehicle, byte _color) => throw new Exceptions.OutdatedSdkException("Vehicle_SetHeadlightColor", "Vehicle_SetHeadlightColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetHybridExtraActiveDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetHybridExtraActiveFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetHybridExtraActive", "Vehicle_SetHybridExtraActive SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetHybridExtraStateDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetHybridExtraStateFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetHybridExtraState", "Vehicle_SetHybridExtraState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetInteriorColorDelegate(nint _vehicle, byte _color);
        private static void Vehicle_SetInteriorColorFallback(nint _vehicle, byte _color) => throw new Exceptions.OutdatedSdkException("Vehicle_SetInteriorColor", "Vehicle_SetInteriorColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetLightDamagedDelegate(nint _vehicle, byte _lightId, byte _isDamaged);
        private static void Vehicle_SetLightDamagedFallback(nint _vehicle, byte _lightId, byte _isDamaged) => throw new Exceptions.OutdatedSdkException("Vehicle_SetLightDamaged", "Vehicle_SetLightDamaged SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetLightsMultiplierDelegate(nint _vehicle, float _multiplier);
        private static void Vehicle_SetLightsMultiplierFallback(nint _vehicle, float _multiplier) => throw new Exceptions.OutdatedSdkException("Vehicle_SetLightsMultiplier", "Vehicle_SetLightsMultiplier SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetLightStateDelegate(nint _vehicle, byte _value);
        private static void Vehicle_SetLightStateFallback(nint _vehicle, byte _value) => throw new Exceptions.OutdatedSdkException("Vehicle_SetLightState", "Vehicle_SetLightState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetLiveryDelegate(nint _vehicle, byte _livery);
        private static void Vehicle_SetLiveryFallback(nint _vehicle, byte _livery) => throw new Exceptions.OutdatedSdkException("Vehicle_SetLivery", "Vehicle_SetLivery SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetLockStateDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetLockStateFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetLockState", "Vehicle_SetLockState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetManualEngineControlDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetManualEngineControlFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetManualEngineControl", "Vehicle_SetManualEngineControl SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_SetModDelegate(nint _vehicle, byte _category, byte _id);
        private static byte Vehicle_SetModFallback(nint _vehicle, byte _category, byte _id) => throw new Exceptions.OutdatedSdkException("Vehicle_SetMod", "Vehicle_SetMod SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_SetModKitDelegate(nint _vehicle, byte _id);
        private static byte Vehicle_SetModKitFallback(nint _vehicle, byte _id) => throw new Exceptions.OutdatedSdkException("Vehicle_SetModKit", "Vehicle_SetModKit SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetNeonActiveDelegate(nint _vehicle, byte _left, byte _right, byte _front, byte _back);
        private static void Vehicle_SetNeonActiveFallback(nint _vehicle, byte _left, byte _right, byte _front, byte _back) => throw new Exceptions.OutdatedSdkException("Vehicle_SetNeonActive", "Vehicle_SetNeonActive SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetNeonColorDelegate(nint _vehicle, Rgba _color);
        private static void Vehicle_SetNeonColorFallback(nint _vehicle, Rgba _color) => throw new Exceptions.OutdatedSdkException("Vehicle_SetNeonColor", "Vehicle_SetNeonColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetNumberplateIndexDelegate(nint _vehicle, uint _index);
        private static void Vehicle_SetNumberplateIndexFallback(nint _vehicle, uint _index) => throw new Exceptions.OutdatedSdkException("Vehicle_SetNumberplateIndex", "Vehicle_SetNumberplateIndex SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetNumberplateTextDelegate(nint _vehicle, nint _text);
        private static void Vehicle_SetNumberplateTextFallback(nint _vehicle, nint _text) => throw new Exceptions.OutdatedSdkException("Vehicle_SetNumberplateText", "Vehicle_SetNumberplateText SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetPartBulletHolesDelegate(nint _vehicle, byte _partId, byte _shootsCount);
        private static void Vehicle_SetPartBulletHolesFallback(nint _vehicle, byte _partId, byte _shootsCount) => throw new Exceptions.OutdatedSdkException("Vehicle_SetPartBulletHoles", "Vehicle_SetPartBulletHoles SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetPartDamageLevelDelegate(nint _vehicle, byte _partId, byte _damage);
        private static void Vehicle_SetPartDamageLevelFallback(nint _vehicle, byte _partId, byte _damage) => throw new Exceptions.OutdatedSdkException("Vehicle_SetPartDamageLevel", "Vehicle_SetPartDamageLevel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetPearlColorDelegate(nint _vehicle, byte _color);
        private static void Vehicle_SetPearlColorFallback(nint _vehicle, byte _color) => throw new Exceptions.OutdatedSdkException("Vehicle_SetPearlColor", "Vehicle_SetPearlColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetPetrolTankHealthDelegate(nint _vehicle, int _health);
        private static void Vehicle_SetPetrolTankHealthFallback(nint _vehicle, int _health) => throw new Exceptions.OutdatedSdkException("Vehicle_SetPetrolTankHealth", "Vehicle_SetPetrolTankHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetPrimaryColorDelegate(nint _vehicle, byte _color);
        private static void Vehicle_SetPrimaryColorFallback(nint _vehicle, byte _color) => throw new Exceptions.OutdatedSdkException("Vehicle_SetPrimaryColor", "Vehicle_SetPrimaryColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetPrimaryColorRGBDelegate(nint _vehicle, Rgba _color);
        private static void Vehicle_SetPrimaryColorRGBFallback(nint _vehicle, Rgba _color) => throw new Exceptions.OutdatedSdkException("Vehicle_SetPrimaryColorRGB", "Vehicle_SetPrimaryColorRGB SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetQuaternionDelegate(nint _vehicle, Quaternion _quaternion);
        private static void Vehicle_SetQuaternionFallback(nint _vehicle, Quaternion _quaternion) => throw new Exceptions.OutdatedSdkException("Vehicle_SetQuaternion", "Vehicle_SetQuaternion SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetRadioStationIndexDelegate(nint _vehicle, uint _stationIndex);
        private static void Vehicle_SetRadioStationIndexFallback(nint _vehicle, uint _stationIndex) => throw new Exceptions.OutdatedSdkException("Vehicle_SetRadioStationIndex", "Vehicle_SetRadioStationIndex SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetRearWheelsDelegate(nint _vehicle, byte _variation);
        private static void Vehicle_SetRearWheelsFallback(nint _vehicle, byte _variation) => throw new Exceptions.OutdatedSdkException("Vehicle_SetRearWheels", "Vehicle_SetRearWheels SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetRocketRefuelSpeedDelegate(nint _vehicle, float _rocketRefuleSpeed);
        private static void Vehicle_SetRocketRefuelSpeedFallback(nint _vehicle, float _rocketRefuleSpeed) => throw new Exceptions.OutdatedSdkException("Vehicle_SetRocketRefuelSpeed", "Vehicle_SetRocketRefuelSpeed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetRoofLiveryDelegate(nint _vehicle, byte _roofLivery);
        private static void Vehicle_SetRoofLiveryFallback(nint _vehicle, byte _roofLivery) => throw new Exceptions.OutdatedSdkException("Vehicle_SetRoofLivery", "Vehicle_SetRoofLivery SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetRoofStateDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetRoofStateFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetRoofState", "Vehicle_SetRoofState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetScriptMaxSpeedDelegate(nint _vehicle, float _scriptMaxSpeed);
        private static void Vehicle_SetScriptMaxSpeedFallback(nint _vehicle, float _scriptMaxSpeed) => throw new Exceptions.OutdatedSdkException("Vehicle_SetScriptMaxSpeed", "Vehicle_SetScriptMaxSpeed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_SetSearchLightDelegate(nint _vehicle, byte _state, nint _spottedEntity);
        private static byte Vehicle_SetSearchLightFallback(nint _vehicle, byte _state, nint _spottedEntity) => throw new Exceptions.OutdatedSdkException("Vehicle_SetSearchLight", "Vehicle_SetSearchLight SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetSecondaryColorDelegate(nint _vehicle, byte _color);
        private static void Vehicle_SetSecondaryColorFallback(nint _vehicle, byte _color) => throw new Exceptions.OutdatedSdkException("Vehicle_SetSecondaryColor", "Vehicle_SetSecondaryColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetSecondaryColorRGBDelegate(nint _vehicle, Rgba _color);
        private static void Vehicle_SetSecondaryColorRGBFallback(nint _vehicle, Rgba _color) => throw new Exceptions.OutdatedSdkException("Vehicle_SetSecondaryColorRGB", "Vehicle_SetSecondaryColorRGB SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetSirenActiveDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetSirenActiveFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetSirenActive", "Vehicle_SetSirenActive SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetSpecialDarknessDelegate(nint _vehicle, byte _value);
        private static void Vehicle_SetSpecialDarknessFallback(nint _vehicle, byte _value) => throw new Exceptions.OutdatedSdkException("Vehicle_SetSpecialDarkness", "Vehicle_SetSpecialDarkness SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetSpecialLightDamagedDelegate(nint _vehicle, byte _specialLightId, byte _isDamaged);
        private static void Vehicle_SetSpecialLightDamagedFallback(nint _vehicle, byte _specialLightId, byte _isDamaged) => throw new Exceptions.OutdatedSdkException("Vehicle_SetSpecialLightDamaged", "Vehicle_SetSpecialLightDamaged SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTimedExplosionDelegate(nint _vehicle, byte _state, nint _culprit, uint _time);
        private static void Vehicle_SetTimedExplosionFallback(nint _vehicle, byte _state, nint _culprit, uint _time) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTimedExplosion", "Vehicle_SetTimedExplosion SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTireSmokeColorDelegate(nint _vehicle, Rgba _color);
        private static void Vehicle_SetTireSmokeColorFallback(nint _vehicle, Rgba _color) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTireSmokeColor", "Vehicle_SetTireSmokeColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainCarriageConfigIndexDelegate(nint _vehicle, sbyte _carriageConfigIndex);
        private static void Vehicle_SetTrainCarriageConfigIndexFallback(nint _vehicle, sbyte _carriageConfigIndex) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainCarriageConfigIndex", "Vehicle_SetTrainCarriageConfigIndex SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainConfigIndexDelegate(nint _vehicle, sbyte _index);
        private static void Vehicle_SetTrainConfigIndexFallback(nint _vehicle, sbyte _index) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainConfigIndex", "Vehicle_SetTrainConfigIndex SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainCruiseSpeedDelegate(nint _vehicle, float _cruiseSpeed);
        private static void Vehicle_SetTrainCruiseSpeedFallback(nint _vehicle, float _cruiseSpeed) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainCruiseSpeed", "Vehicle_SetTrainCruiseSpeed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainDirectionDelegate(nint _vehicle, byte _direction);
        private static void Vehicle_SetTrainDirectionFallback(nint _vehicle, byte _direction) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainDirection", "Vehicle_SetTrainDirection SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainDistanceFromEngineDelegate(nint _vehicle, float _distanceFromEngine);
        private static void Vehicle_SetTrainDistanceFromEngineFallback(nint _vehicle, float _distanceFromEngine) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainDistanceFromEngine", "Vehicle_SetTrainDistanceFromEngine SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainEngineIdDelegate(nint _vehicle, nint _entity);
        private static void Vehicle_SetTrainEngineIdFallback(nint _vehicle, nint _entity) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainEngineId", "Vehicle_SetTrainEngineId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainForceDoorsOpenDelegate(nint _vehicle, byte _forceDoorsOpen);
        private static void Vehicle_SetTrainForceDoorsOpenFallback(nint _vehicle, byte _forceDoorsOpen) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainForceDoorsOpen", "Vehicle_SetTrainForceDoorsOpen SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainHasPassengerCarriagesDelegate(nint _vehicle, byte _hasPassengerCarriages);
        private static void Vehicle_SetTrainHasPassengerCarriagesFallback(nint _vehicle, byte _hasPassengerCarriages) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainHasPassengerCarriages", "Vehicle_SetTrainHasPassengerCarriages SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainIsCabooseDelegate(nint _vehicle, byte _isCaboose);
        private static void Vehicle_SetTrainIsCabooseFallback(nint _vehicle, byte _isCaboose) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainIsCaboose", "Vehicle_SetTrainIsCaboose SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainIsEngineDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetTrainIsEngineFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainIsEngine", "Vehicle_SetTrainIsEngine SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainLinkedToBackwardIdDelegate(nint _vehicle, nint _entity);
        private static void Vehicle_SetTrainLinkedToBackwardIdFallback(nint _vehicle, nint _entity) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainLinkedToBackwardId", "Vehicle_SetTrainLinkedToBackwardId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainLinkedToForwardIdDelegate(nint _vehicle, nint _entity);
        private static void Vehicle_SetTrainLinkedToForwardIdFallback(nint _vehicle, nint _entity) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainLinkedToForwardId", "Vehicle_SetTrainLinkedToForwardId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainMissionTrainDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetTrainMissionTrainFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainMissionTrain", "Vehicle_SetTrainMissionTrain SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainRenderDerailedDelegate(nint _vehicle, byte _renderDerailed);
        private static void Vehicle_SetTrainRenderDerailedFallback(nint _vehicle, byte _renderDerailed) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainRenderDerailed", "Vehicle_SetTrainRenderDerailed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetTrainTrackIdDelegate(nint _vehicle, sbyte _trackId);
        private static void Vehicle_SetTrainTrackIdFallback(nint _vehicle, sbyte _trackId) => throw new Exceptions.OutdatedSdkException("Vehicle_SetTrainTrackId", "Vehicle_SetTrainTrackId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWeaponCapacityDelegate(nint _vehicle, byte _index, int _state);
        private static void Vehicle_SetWeaponCapacityFallback(nint _vehicle, byte _index, int _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWeaponCapacity", "Vehicle_SetWeaponCapacity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWheelBurstDelegate(nint _vehicle, byte _wheelId, byte _state);
        private static void Vehicle_SetWheelBurstFallback(nint _vehicle, byte _wheelId, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWheelBurst", "Vehicle_SetWheelBurst SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWheelColorDelegate(nint _vehicle, byte _color);
        private static void Vehicle_SetWheelColorFallback(nint _vehicle, byte _color) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWheelColor", "Vehicle_SetWheelColor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWheelDetachedDelegate(nint _vehicle, byte _wheelId, byte _state);
        private static void Vehicle_SetWheelDetachedFallback(nint _vehicle, byte _wheelId, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWheelDetached", "Vehicle_SetWheelDetached SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWheelFixedDelegate(nint _vehicle, byte _wheelId);
        private static void Vehicle_SetWheelFixedFallback(nint _vehicle, byte _wheelId) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWheelFixed", "Vehicle_SetWheelFixed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWheelHasTireDelegate(nint _vehicle, byte _wheelId, byte _state);
        private static void Vehicle_SetWheelHasTireFallback(nint _vehicle, byte _wheelId, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWheelHasTire", "Vehicle_SetWheelHasTire SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWheelHealthDelegate(nint _vehicle, byte _wheelId, float _health);
        private static void Vehicle_SetWheelHealthFallback(nint _vehicle, byte _wheelId, float _health) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWheelHealth", "Vehicle_SetWheelHealth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWheelOnFireDelegate(nint _vehicle, byte _wheelId, byte _state);
        private static void Vehicle_SetWheelOnFireFallback(nint _vehicle, byte _wheelId, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWheelOnFire", "Vehicle_SetWheelOnFire SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWheelsDelegate(nint _vehicle, byte _type, byte _variation);
        private static void Vehicle_SetWheelsFallback(nint _vehicle, byte _type, byte _variation) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWheels", "Vehicle_SetWheels SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWindowDamagedDelegate(nint _vehicle, byte _windowId, byte _isDamaged);
        private static void Vehicle_SetWindowDamagedFallback(nint _vehicle, byte _windowId, byte _isDamaged) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWindowDamaged", "Vehicle_SetWindowDamaged SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWindowOpenedDelegate(nint _vehicle, byte _windowId, byte _state);
        private static void Vehicle_SetWindowOpenedFallback(nint _vehicle, byte _windowId, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWindowOpened", "Vehicle_SetWindowOpened SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWindowTintDelegate(nint _vehicle, byte _tint);
        private static void Vehicle_SetWindowTintFallback(nint _vehicle, byte _tint) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWindowTint", "Vehicle_SetWindowTint SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_ToggleExtraDelegate(nint _vehicle, byte _extraID, byte _state);
        private static void Vehicle_ToggleExtraFallback(nint _vehicle, byte _extraID, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_ToggleExtra", "Vehicle_ToggleExtra SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void VirtualEntity_DeleteStreamSyncedMetaDataDelegate(nint _virtualEntity, nint _key);
        private static void VirtualEntity_DeleteStreamSyncedMetaDataFallback(nint _virtualEntity, nint _key) => throw new Exceptions.OutdatedSdkException("VirtualEntity_DeleteStreamSyncedMetaData", "VirtualEntity_DeleteStreamSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void VirtualEntity_SetStreamSyncedMetaDataDelegate(nint _virtualEntity, nint _key, nint _val);
        private static void VirtualEntity_SetStreamSyncedMetaDataFallback(nint _virtualEntity, nint _key, nint _val) => throw new Exceptions.OutdatedSdkException("VirtualEntity_SetStreamSyncedMetaData", "VirtualEntity_SetStreamSyncedMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void VoiceChannel_AddPlayerDelegate(nint _channel, nint _player);
        private static void VoiceChannel_AddPlayerFallback(nint _channel, nint _player) => throw new Exceptions.OutdatedSdkException("VoiceChannel_AddPlayer", "VoiceChannel_AddPlayer SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void VoiceChannel_DeleteMetaDataDelegate(nint _voiceChannel, nint _key);
        private static void VoiceChannel_DeleteMetaDataFallback(nint _voiceChannel, nint _key) => throw new Exceptions.OutdatedSdkException("VoiceChannel_DeleteMetaData", "VoiceChannel_DeleteMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint VoiceChannel_GetBaseObjectDelegate(nint _voiceChannel);
        private static nint VoiceChannel_GetBaseObjectFallback(nint _voiceChannel) => throw new Exceptions.OutdatedSdkException("VoiceChannel_GetBaseObject", "VoiceChannel_GetBaseObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint VoiceChannel_GetFilterDelegate(nint _channel);
        private static uint VoiceChannel_GetFilterFallback(nint _channel) => throw new Exceptions.OutdatedSdkException("VoiceChannel_GetFilter", "VoiceChannel_GetFilter SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float VoiceChannel_GetMaxDistanceDelegate(nint _channel);
        private static float VoiceChannel_GetMaxDistanceFallback(nint _channel) => throw new Exceptions.OutdatedSdkException("VoiceChannel_GetMaxDistance", "VoiceChannel_GetMaxDistance SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint VoiceChannel_GetMetaDataDelegate(nint _voiceChannel, nint _key);
        private static nint VoiceChannel_GetMetaDataFallback(nint _voiceChannel, nint _key) => throw new Exceptions.OutdatedSdkException("VoiceChannel_GetMetaData", "VoiceChannel_GetMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate int VoiceChannel_GetPriorityDelegate(nint _channel);
        private static int VoiceChannel_GetPriorityFallback(nint _channel) => throw new Exceptions.OutdatedSdkException("VoiceChannel_GetPriority", "VoiceChannel_GetPriority SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte VoiceChannel_HasMetaDataDelegate(nint _voiceChannel, nint _key);
        private static byte VoiceChannel_HasMetaDataFallback(nint _voiceChannel, nint _key) => throw new Exceptions.OutdatedSdkException("VoiceChannel_HasMetaData", "VoiceChannel_HasMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte VoiceChannel_HasPlayerDelegate(nint _channel, nint _player);
        private static byte VoiceChannel_HasPlayerFallback(nint _channel, nint _player) => throw new Exceptions.OutdatedSdkException("VoiceChannel_HasPlayer", "VoiceChannel_HasPlayer SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte VoiceChannel_IsPlayerMutedDelegate(nint _channel, nint _player);
        private static byte VoiceChannel_IsPlayerMutedFallback(nint _channel, nint _player) => throw new Exceptions.OutdatedSdkException("VoiceChannel_IsPlayerMuted", "VoiceChannel_IsPlayerMuted SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte VoiceChannel_IsSpatialDelegate(nint _channel);
        private static byte VoiceChannel_IsSpatialFallback(nint _channel) => throw new Exceptions.OutdatedSdkException("VoiceChannel_IsSpatial", "VoiceChannel_IsSpatial SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void VoiceChannel_MutePlayerDelegate(nint _channel, nint _player);
        private static void VoiceChannel_MutePlayerFallback(nint _channel, nint _player) => throw new Exceptions.OutdatedSdkException("VoiceChannel_MutePlayer", "VoiceChannel_MutePlayer SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void VoiceChannel_RemovePlayerDelegate(nint _channel, nint _player);
        private static void VoiceChannel_RemovePlayerFallback(nint _channel, nint _player) => throw new Exceptions.OutdatedSdkException("VoiceChannel_RemovePlayer", "VoiceChannel_RemovePlayer SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void VoiceChannel_SetFilterDelegate(nint _channel, uint _filter);
        private static void VoiceChannel_SetFilterFallback(nint _channel, uint _filter) => throw new Exceptions.OutdatedSdkException("VoiceChannel_SetFilter", "VoiceChannel_SetFilter SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void VoiceChannel_SetMetaDataDelegate(nint _channel, nint _key, nint _val);
        private static void VoiceChannel_SetMetaDataFallback(nint _channel, nint _key, nint _val) => throw new Exceptions.OutdatedSdkException("VoiceChannel_SetMetaData", "VoiceChannel_SetMetaData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void VoiceChannel_SetPriorityDelegate(nint _channel, int _priority);
        private static void VoiceChannel_SetPriorityFallback(nint _channel, int _priority) => throw new Exceptions.OutdatedSdkException("VoiceChannel_SetPriority", "VoiceChannel_SetPriority SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void VoiceChannel_UnmutePlayerDelegate(nint _channel, nint _player);
        private static void VoiceChannel_UnmutePlayerFallback(nint _channel, nint _player) => throw new Exceptions.OutdatedSdkException("VoiceChannel_UnmutePlayer", "VoiceChannel_UnmutePlayer SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WorldObject_GetPositionCoordsDelegate(nint _worldObject, float* _position_x, float* _position_y, float* _position_z, int* _dimension);
        private static void WorldObject_GetPositionCoordsFallback(nint _worldObject, float* _position_x, float* _position_y, float* _position_z, int* _dimension) => throw new Exceptions.OutdatedSdkException("WorldObject_GetPositionCoords", "WorldObject_GetPositionCoords SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WorldObject_SetDimensionDelegate(nint _worldObject, int _dimension);
        private static void WorldObject_SetDimensionFallback(nint _worldObject, int _dimension) => throw new Exceptions.OutdatedSdkException("WorldObject_SetDimension", "WorldObject_SetDimension SDK method is outdated. Please update your module nuget");
        public bool Outdated { get; private set; }
        private IntPtr GetUnmanagedPtr<T>(IDictionary<ulong, IntPtr> funcTable, ulong hash, T fn) where T : Delegate {
            if (funcTable.TryGetValue(hash, out var ptr)) return ptr;
            Outdated = true;
            return Marshal.GetFunctionPointerForDelegate<T>(fn);
        }
        public ServerLibrary(Dictionary<ulong, IntPtr> funcTable)
        {
            if (!funcTable.TryGetValue(0, out var capiHash)) Outdated = true;
            else if (capiHash == IntPtr.Zero || *(ulong*)capiHash != 256916740904720869UL) Outdated = true;
            BaseObject_DeleteSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<BaseObject_DeleteSyncedMetaDataDelegate>(funcTable, 8228424877092269355UL, BaseObject_DeleteSyncedMetaDataFallback);
            BaseObject_SetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<BaseObject_SetSyncedMetaDataDelegate>(funcTable, 8002999088966424231UL, BaseObject_SetSyncedMetaDataFallback);
            Blip_AttachedTo = (delegate* unmanaged[Cdecl]<nint, BaseObjectType*, nint>) GetUnmanagedPtr<Blip_AttachedToDelegate>(funcTable, 15602966080933483258UL, Blip_AttachedToFallback);
            Blip_IsAttached = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_IsAttachedDelegate>(funcTable, 7870458832410754161UL, Blip_IsAttachedFallback);
            ColShape_GetColShapeType = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<ColShape_GetColShapeTypeDelegate>(funcTable, 18034368716132758796UL, ColShape_GetColShapeTypeFallback);
            ColShape_IsPlayersOnly = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<ColShape_IsPlayersOnlyDelegate>(funcTable, 123106227395069751UL, ColShape_IsPlayersOnlyFallback);
            ColShape_SetPlayersOnly = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<ColShape_SetPlayersOnlyDelegate>(funcTable, 16332474445990008748UL, ColShape_SetPlayersOnlyFallback);
            ConnectionInfo_Accept = (delegate* unmanaged[Cdecl]<IntPtr, byte, void>) GetUnmanagedPtr<ConnectionInfo_AcceptDelegate>(funcTable, 12411302106891962144UL, ConnectionInfo_AcceptFallback);
            ConnectionInfo_Decline = (delegate* unmanaged[Cdecl]<IntPtr, nint, void>) GetUnmanagedPtr<ConnectionInfo_DeclineDelegate>(funcTable, 17030579920009662077UL, ConnectionInfo_DeclineFallback);
            ConnectionInfo_GetAuthToken = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) GetUnmanagedPtr<ConnectionInfo_GetAuthTokenDelegate>(funcTable, 8194004283135524333UL, ConnectionInfo_GetAuthTokenFallback);
            ConnectionInfo_GetBaseObject = (delegate* unmanaged[Cdecl]<IntPtr, nint>) GetUnmanagedPtr<ConnectionInfo_GetBaseObjectDelegate>(funcTable, 12397496971801767822UL, ConnectionInfo_GetBaseObjectFallback);
            ConnectionInfo_GetBranch = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) GetUnmanagedPtr<ConnectionInfo_GetBranchDelegate>(funcTable, 1577439110274874884UL, ConnectionInfo_GetBranchFallback);
            ConnectionInfo_GetBuild = (delegate* unmanaged[Cdecl]<IntPtr, uint>) GetUnmanagedPtr<ConnectionInfo_GetBuildDelegate>(funcTable, 14204191833155309704UL, ConnectionInfo_GetBuildFallback);
            ConnectionInfo_GetCdnUrl = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) GetUnmanagedPtr<ConnectionInfo_GetCdnUrlDelegate>(funcTable, 5988681596904693572UL, ConnectionInfo_GetCdnUrlFallback);
            ConnectionInfo_GetCloudAuthHash = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) GetUnmanagedPtr<ConnectionInfo_GetCloudAuthHashDelegate>(funcTable, 3511183830329804829UL, ConnectionInfo_GetCloudAuthHashFallback);
            ConnectionInfo_GetDiscordUserID = (delegate* unmanaged[Cdecl]<IntPtr, long>) GetUnmanagedPtr<ConnectionInfo_GetDiscordUserIDDelegate>(funcTable, 4175744399917476392UL, ConnectionInfo_GetDiscordUserIDFallback);
            ConnectionInfo_GetHwIdExHash = (delegate* unmanaged[Cdecl]<IntPtr, ulong>) GetUnmanagedPtr<ConnectionInfo_GetHwIdExHashDelegate>(funcTable, 3151831504154255688UL, ConnectionInfo_GetHwIdExHashFallback);
            ConnectionInfo_GetHwIdHash = (delegate* unmanaged[Cdecl]<IntPtr, ulong>) GetUnmanagedPtr<ConnectionInfo_GetHwIdHashDelegate>(funcTable, 11409383581668438027UL, ConnectionInfo_GetHwIdHashFallback);
            ConnectionInfo_GetID = (delegate* unmanaged[Cdecl]<IntPtr, uint>) GetUnmanagedPtr<ConnectionInfo_GetIDDelegate>(funcTable, 8080268107975854795UL, ConnectionInfo_GetIDFallback);
            ConnectionInfo_GetIp = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) GetUnmanagedPtr<ConnectionInfo_GetIpDelegate>(funcTable, 14736154404219321063UL, ConnectionInfo_GetIpFallback);
            ConnectionInfo_GetIsDebug = (delegate* unmanaged[Cdecl]<IntPtr, byte>) GetUnmanagedPtr<ConnectionInfo_GetIsDebugDelegate>(funcTable, 13717058348136733066UL, ConnectionInfo_GetIsDebugFallback);
            ConnectionInfo_GetName = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) GetUnmanagedPtr<ConnectionInfo_GetNameDelegate>(funcTable, 6953750044596480329UL, ConnectionInfo_GetNameFallback);
            ConnectionInfo_GetPasswordHash = (delegate* unmanaged[Cdecl]<IntPtr, ulong>) GetUnmanagedPtr<ConnectionInfo_GetPasswordHashDelegate>(funcTable, 18130628108130086100UL, ConnectionInfo_GetPasswordHashFallback);
            ConnectionInfo_GetSocialId = (delegate* unmanaged[Cdecl]<IntPtr, ulong>) GetUnmanagedPtr<ConnectionInfo_GetSocialIdDelegate>(funcTable, 10464338232675126241UL, ConnectionInfo_GetSocialIdFallback);
            ConnectionInfo_GetSocialName = (delegate* unmanaged[Cdecl]<IntPtr, int*, nint>) GetUnmanagedPtr<ConnectionInfo_GetSocialNameDelegate>(funcTable, 12079559810042444284UL, ConnectionInfo_GetSocialNameFallback);
            ConnectionInfo_IsAccepted = (delegate* unmanaged[Cdecl]<IntPtr, byte>) GetUnmanagedPtr<ConnectionInfo_IsAcceptedDelegate>(funcTable, 8806505177995284480UL, ConnectionInfo_IsAcceptedFallback);
            Core_CreateBlip = (delegate* unmanaged[Cdecl]<nint, nint, byte, Vector3, uint*, nint>) GetUnmanagedPtr<Core_CreateBlipDelegate>(funcTable, 15248911099905088878UL, Core_CreateBlipFallback);
            Core_CreateBlipAttached = (delegate* unmanaged[Cdecl]<nint, nint, byte, nint, uint*, nint>) GetUnmanagedPtr<Core_CreateBlipAttachedDelegate>(funcTable, 18353410539108177249UL, Core_CreateBlipAttachedFallback);
            Core_CreateCheckpoint = (delegate* unmanaged[Cdecl]<nint, byte, Vector3, float, float, Rgba, uint, uint*, nint>) GetUnmanagedPtr<Core_CreateCheckpointDelegate>(funcTable, 3410920088129362997UL, Core_CreateCheckpointFallback);
            Core_CreateMarker = (delegate* unmanaged[Cdecl]<nint, nint, byte, Vector3, Rgba, nint, uint*, nint>) GetUnmanagedPtr<Core_CreateMarkerDelegate>(funcTable, 9200413248217250533UL, Core_CreateMarkerFallback);
            Core_CreateNetworkObject = (delegate* unmanaged[Cdecl]<nint, uint, Vector3, Rotation, byte, byte, ushort, uint*, nint>) GetUnmanagedPtr<Core_CreateNetworkObjectDelegate>(funcTable, 12388703530222285438UL, Core_CreateNetworkObjectFallback);
            Core_CreatePed = (delegate* unmanaged[Cdecl]<nint, uint, Vector3, Rotation, uint*, nint>) GetUnmanagedPtr<Core_CreatePedDelegate>(funcTable, 3289494476065537885UL, Core_CreatePedFallback);
            Core_CreateVehicle = (delegate* unmanaged[Cdecl]<nint, uint, Vector3, Rotation, uint*, nint>) GetUnmanagedPtr<Core_CreateVehicleDelegate>(funcTable, 2859438702466150327UL, Core_CreateVehicleFallback);
            Core_CreateVoiceChannel = (delegate* unmanaged[Cdecl]<nint, byte, float, uint*, nint>) GetUnmanagedPtr<Core_CreateVoiceChannelDelegate>(funcTable, 16510685691058823138UL, Core_CreateVoiceChannelFallback);
            Core_DeallocPedModelInfo = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Core_DeallocPedModelInfoDelegate>(funcTable, 7933678493039322900UL, Core_DeallocPedModelInfoFallback);
            Core_DeallocVehicleModelInfo = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Core_DeallocVehicleModelInfoDelegate>(funcTable, 11272860948152964480UL, Core_DeallocVehicleModelInfoFallback);
            Core_DeleteSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_DeleteSyncedMetaDataDelegate>(funcTable, 3060359612519609111UL, Core_DeleteSyncedMetaDataFallback);
            Core_DestroyCheckpoint = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_DestroyCheckpointDelegate>(funcTable, 15803665224272553601UL, Core_DestroyCheckpointFallback);
            Core_DestroyColShape = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_DestroyColShapeDelegate>(funcTable, 16312284234900575747UL, Core_DestroyColShapeFallback);
            Core_DestroyVehicle = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_DestroyVehicleDelegate>(funcTable, 14452794280175707515UL, Core_DestroyVehicleFallback);
            Core_DestroyVoiceChannel = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_DestroyVoiceChannelDelegate>(funcTable, 10333270135403224879UL, Core_DestroyVoiceChannelFallback);
            Core_GetClosestEntities = (delegate* unmanaged[Cdecl]<nint, Vector3, int, int, int, ulong, nint[], byte[], ulong, void>) GetUnmanagedPtr<Core_GetClosestEntitiesDelegate>(funcTable, 4559218685940666205UL, Core_GetClosestEntitiesFallback);
            Core_GetClosestEntitiesCount = (delegate* unmanaged[Cdecl]<nint, Vector3, int, int, int, ulong, ulong>) GetUnmanagedPtr<Core_GetClosestEntitiesCountDelegate>(funcTable, 419502286495548608UL, Core_GetClosestEntitiesCountFallback);
            Core_GetConnectionInfos = (delegate* unmanaged[Cdecl]<nint, ulong*, nint>) GetUnmanagedPtr<Core_GetConnectionInfosDelegate>(funcTable, 13972691773502904173UL, Core_GetConnectionInfosFallback);
            Core_GetEntitiesInDimension = (delegate* unmanaged[Cdecl]<nint, int, ulong, nint[], byte[], ulong, void>) GetUnmanagedPtr<Core_GetEntitiesInDimensionDelegate>(funcTable, 4124119004202747553UL, Core_GetEntitiesInDimensionFallback);
            Core_GetEntitiesInDimensionCount = (delegate* unmanaged[Cdecl]<nint, int, ulong, ulong>) GetUnmanagedPtr<Core_GetEntitiesInDimensionCountDelegate>(funcTable, 12784287737200780200UL, Core_GetEntitiesInDimensionCountFallback);
            Core_GetEntitiesInRange = (delegate* unmanaged[Cdecl]<nint, Vector3, int, int, ulong, nint[], byte[], ulong, void>) GetUnmanagedPtr<Core_GetEntitiesInRangeDelegate>(funcTable, 12414549446254212526UL, Core_GetEntitiesInRangeFallback);
            Core_GetEntitiesInRangeCount = (delegate* unmanaged[Cdecl]<nint, Vector3, int, int, ulong, ulong>) GetUnmanagedPtr<Core_GetEntitiesInRangeCountDelegate>(funcTable, 6795936790869684439UL, Core_GetEntitiesInRangeCountFallback);
            Core_GetNetTime = (delegate* unmanaged[Cdecl]<nint, int>) GetUnmanagedPtr<Core_GetNetTimeDelegate>(funcTable, 15652019729912249391UL, Core_GetNetTimeFallback);
            Core_GetPedModelInfo = (delegate* unmanaged[Cdecl]<nint, uint, nint>) GetUnmanagedPtr<Core_GetPedModelInfoDelegate>(funcTable, 7718568480211772772UL, Core_GetPedModelInfoFallback);
            Core_GetRootDirectory = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Core_GetRootDirectoryDelegate>(funcTable, 12125306445698504265UL, Core_GetRootDirectoryFallback);
            Core_GetServerConfig = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Core_GetServerConfigDelegate>(funcTable, 14723504540957489106UL, Core_GetServerConfigFallback);
            Core_GetVehicleModelInfo = (delegate* unmanaged[Cdecl]<nint, uint, nint>) GetUnmanagedPtr<Core_GetVehicleModelInfoDelegate>(funcTable, 4351657857321681174UL, Core_GetVehicleModelInfoFallback);
            Core_HashPassword = (delegate* unmanaged[Cdecl]<nint, nint, ulong>) GetUnmanagedPtr<Core_HashPasswordDelegate>(funcTable, 11016797678327133571UL, Core_HashPasswordFallback);
            Core_RegisterMetric = (delegate* unmanaged[Cdecl]<nint, nint, byte, nint[], nint[], ulong, nint>) GetUnmanagedPtr<Core_RegisterMetricDelegate>(funcTable, 5640834261493040151UL, Core_RegisterMetricFallback);
            Core_RestartResource = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_RestartResourceDelegate>(funcTable, 14370739159812248240UL, Core_RestartResourceFallback);
            Core_SetPassword = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_SetPasswordDelegate>(funcTable, 6443050816994465854UL, Core_SetPasswordFallback);
            Core_SetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<Core_SetSyncedMetaDataDelegate>(funcTable, 15257521334482717721UL, Core_SetSyncedMetaDataFallback);
            Core_SetWorldProfiler = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Core_SetWorldProfilerDelegate>(funcTable, 10444519920811589155UL, Core_SetWorldProfilerFallback);
            Core_StartResource = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_StartResourceDelegate>(funcTable, 16286692558347341301UL, Core_StartResourceFallback);
            Core_StopResource = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_StopResourceDelegate>(funcTable, 6124037131742433471UL, Core_StopResourceFallback);
            Core_StopServer = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Core_StopServerDelegate>(funcTable, 2943797268083244741UL, Core_StopServerFallback);
            Core_SubscribeCommand = (delegate* unmanaged[Cdecl]<nint, nint, CommandCallback, byte>) GetUnmanagedPtr<Core_SubscribeCommandDelegate>(funcTable, 16924649568138200617UL, Core_SubscribeCommandFallback);
            Core_TriggerClientEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void>) GetUnmanagedPtr<Core_TriggerClientEventDelegate>(funcTable, 12171087854734907223UL, Core_TriggerClientEventFallback);
            Core_TriggerClientEventForAll = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) GetUnmanagedPtr<Core_TriggerClientEventForAllDelegate>(funcTable, 9104514502849926149UL, Core_TriggerClientEventForAllFallback);
            Core_TriggerClientEventForSome = (delegate* unmanaged[Cdecl]<nint, nint[], int, nint, nint[], int, void>) GetUnmanagedPtr<Core_TriggerClientEventForSomeDelegate>(funcTable, 5959099227636084384UL, Core_TriggerClientEventForSomeFallback);
            Core_TriggerClientEventUnreliable = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void>) GetUnmanagedPtr<Core_TriggerClientEventUnreliableDelegate>(funcTable, 4821179867491879744UL, Core_TriggerClientEventUnreliableFallback);
            Core_TriggerClientEventUnreliableForAll = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) GetUnmanagedPtr<Core_TriggerClientEventUnreliableForAllDelegate>(funcTable, 9578627964183564598UL, Core_TriggerClientEventUnreliableForAllFallback);
            Core_TriggerClientEventUnreliableForSome = (delegate* unmanaged[Cdecl]<nint, nint[], int, nint, nint[], int, void>) GetUnmanagedPtr<Core_TriggerClientEventUnreliableForSomeDelegate>(funcTable, 14557546483922608997UL, Core_TriggerClientEventUnreliableForSomeFallback);
            Core_TriggerServerEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) GetUnmanagedPtr<Core_TriggerServerEventDelegate>(funcTable, 4092140335578989631UL, Core_TriggerServerEventFallback);
            Core_UnrgisterMetric = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_UnrgisterMetricDelegate>(funcTable, 12132329207255716449UL, Core_UnrgisterMetricFallback);
            Entity_AttachToEntity = (delegate* unmanaged[Cdecl]<nint, nint, short, short, Vector3, Rotation, byte, byte, void>) GetUnmanagedPtr<Entity_AttachToEntityDelegate>(funcTable, 8214096007757560094UL, Entity_AttachToEntityFallback);
            Entity_AttachToEntity_BoneString = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint, Vector3, Rotation, byte, byte, void>) GetUnmanagedPtr<Entity_AttachToEntity_BoneStringDelegate>(funcTable, 4813711775676193020UL, Entity_AttachToEntity_BoneStringFallback);
            Entity_DeleteStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Entity_DeleteStreamSyncedMetaDataDelegate>(funcTable, 10985243845337635807UL, Entity_DeleteStreamSyncedMetaDataFallback);
            Entity_Detach = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Entity_DetachDelegate>(funcTable, 720717099291838457UL, Entity_DetachFallback);
            Entity_GetStreamed = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Entity_GetStreamedDelegate>(funcTable, 10576887087871473326UL, Entity_GetStreamedFallback);
            Entity_GetVisible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Entity_GetVisibleDelegate>(funcTable, 10813148612330668827UL, Entity_GetVisibleFallback);
            Entity_HasCollision = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Entity_HasCollisionDelegate>(funcTable, 2223226199436541021UL, Entity_HasCollisionFallback);
            Entity_SetCollision = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Entity_SetCollisionDelegate>(funcTable, 10673322505892191972UL, Entity_SetCollisionFallback);
            Entity_SetNetOwner = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) GetUnmanagedPtr<Entity_SetNetOwnerDelegate>(funcTable, 6937824812303569788UL, Entity_SetNetOwnerFallback);
            Entity_SetStreamed = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Entity_SetStreamedDelegate>(funcTable, 6004628797499736605UL, Entity_SetStreamedFallback);
            Entity_SetStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<Entity_SetStreamSyncedMetaDataDelegate>(funcTable, 12798418058428333585UL, Entity_SetStreamSyncedMetaDataFallback);
            Entity_SetVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Entity_SetVisibleDelegate>(funcTable, 8026011842118229214UL, Entity_SetVisibleFallback);
            Event_WeaponDamageEvent_SetDamageValue = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Event_WeaponDamageEvent_SetDamageValueDelegate>(funcTable, 18440396865533386791UL, Event_WeaponDamageEvent_SetDamageValueFallback);
            Metric_Begin = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Metric_BeginDelegate>(funcTable, 2348810001298180138UL, Metric_BeginFallback);
            Metric_End = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Metric_EndDelegate>(funcTable, 13016512038826983106UL, Metric_EndFallback);
            Metric_GetName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Metric_GetNameDelegate>(funcTable, 8652629169459184520UL, Metric_GetNameFallback);
            Metric_GetValue = (delegate* unmanaged[Cdecl]<nint, ulong>) GetUnmanagedPtr<Metric_GetValueDelegate>(funcTable, 16033500183040421617UL, Metric_GetValueFallback);
            Metric_SetValue = (delegate* unmanaged[Cdecl]<nint, ulong, void>) GetUnmanagedPtr<Metric_SetValueDelegate>(funcTable, 13198892627580896636UL, Metric_SetValueFallback);
            NetworkObject_ActivatePhysics = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<NetworkObject_ActivatePhysicsDelegate>(funcTable, 8450915683705067802UL, NetworkObject_ActivatePhysicsFallback);
            NetworkObject_PlaceOnGroundProperly = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<NetworkObject_PlaceOnGroundProperlyDelegate>(funcTable, 4893173731336848168UL, NetworkObject_PlaceOnGroundProperlyFallback);
            NetworkObject_SetAlpha = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<NetworkObject_SetAlphaDelegate>(funcTable, 10303430124488928578UL, NetworkObject_SetAlphaFallback);
            NetworkObject_SetLodDistance = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<NetworkObject_SetLodDistanceDelegate>(funcTable, 12196894478919570199UL, NetworkObject_SetLodDistanceFallback);
            NetworkObject_SetTextureVariation = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<NetworkObject_SetTextureVariationDelegate>(funcTable, 9562028816575046132UL, NetworkObject_SetTextureVariationFallback);
            Ped_SetArmour = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Ped_SetArmourDelegate>(funcTable, 4244342379127106529UL, Ped_SetArmourFallback);
            Ped_SetCurrentWeapon = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Ped_SetCurrentWeaponDelegate>(funcTable, 1890144317981520558UL, Ped_SetCurrentWeaponFallback);
            Ped_SetHealth = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Ped_SetHealthDelegate>(funcTable, 15651278310887155719UL, Ped_SetHealthFallback);
            Ped_SetMaxHealth = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Ped_SetMaxHealthDelegate>(funcTable, 487582698440451683UL, Ped_SetMaxHealthFallback);
            Player_AddWeaponComponent = (delegate* unmanaged[Cdecl]<nint, uint, uint, void>) GetUnmanagedPtr<Player_AddWeaponComponentDelegate>(funcTable, 9305362021789278268UL, Player_AddWeaponComponentFallback);
            Player_ClearBloodDamage = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Player_ClearBloodDamageDelegate>(funcTable, 1935399752104807234UL, Player_ClearBloodDamageFallback);
            Player_ClearProps = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Player_ClearPropsDelegate>(funcTable, 14293729102633233291UL, Player_ClearPropsFallback);
            Player_ClearTasks = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Player_ClearTasksDelegate>(funcTable, 2394928316223850939UL, Player_ClearTasksFallback);
            Player_DeleteLocalMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Player_DeleteLocalMetaDataDelegate>(funcTable, 18350138927152444768UL, Player_DeleteLocalMetaDataFallback);
            Player_Despawn = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Player_DespawnDelegate>(funcTable, 10068978925729858744UL, Player_DespawnFallback);
            Player_GetAuthToken = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Player_GetAuthTokenDelegate>(funcTable, 1189077145064378629UL, Player_GetAuthTokenFallback);
            Player_GetClothes = (delegate* unmanaged[Cdecl]<nint, byte, Cloth*, void>) GetUnmanagedPtr<Player_GetClothesDelegate>(funcTable, 5651306477145172672UL, Player_GetClothesFallback);
            Player_GetCurrentWeaponTintIndex = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_GetCurrentWeaponTintIndexDelegate>(funcTable, 11764387330920927539UL, Player_GetCurrentWeaponTintIndexFallback);
            Player_GetDiscordId = (delegate* unmanaged[Cdecl]<nint, long>) GetUnmanagedPtr<Player_GetDiscordIdDelegate>(funcTable, 4212976016289999495UL, Player_GetDiscordIdFallback);
            Player_GetDlcClothes = (delegate* unmanaged[Cdecl]<nint, byte, DlcCloth*, void>) GetUnmanagedPtr<Player_GetDlcClothesDelegate>(funcTable, 1024671376313962844UL, Player_GetDlcClothesFallback);
            Player_GetDlcProps = (delegate* unmanaged[Cdecl]<nint, byte, DlcProp*, void>) GetUnmanagedPtr<Player_GetDlcPropsDelegate>(funcTable, 13456080432183428807UL, Player_GetDlcPropsFallback);
            Player_GetEyeColor = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Player_GetEyeColorDelegate>(funcTable, 7454702606973673436UL, Player_GetEyeColorFallback);
            Player_GetFaceFeatureScale = (delegate* unmanaged[Cdecl]<nint, byte, float>) GetUnmanagedPtr<Player_GetFaceFeatureScaleDelegate>(funcTable, 18060880335075103399UL, Player_GetFaceFeatureScaleFallback);
            Player_GetHairColor = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_GetHairColorDelegate>(funcTable, 12027992059985426894UL, Player_GetHairColorFallback);
            Player_GetHairHighlightColor = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_GetHairHighlightColorDelegate>(funcTable, 12261743220780946704UL, Player_GetHairHighlightColorFallback);
            Player_GetHeadBlendData = (delegate* unmanaged[Cdecl]<nint, HeadBlendData*, void>) GetUnmanagedPtr<Player_GetHeadBlendDataDelegate>(funcTable, 12996031514192232278UL, Player_GetHeadBlendDataFallback);
            Player_GetHeadBlendPaletteColor = (delegate* unmanaged[Cdecl]<nint, byte, Rgba*, void>) GetUnmanagedPtr<Player_GetHeadBlendPaletteColorDelegate>(funcTable, 6875264309357036667UL, Player_GetHeadBlendPaletteColorFallback);
            Player_GetHeadOverlay = (delegate* unmanaged[Cdecl]<nint, byte, HeadOverlay*, void>) GetUnmanagedPtr<Player_GetHeadOverlayDelegate>(funcTable, 18242810182906526031UL, Player_GetHeadOverlayFallback);
            Player_GetHwidExHash = (delegate* unmanaged[Cdecl]<nint, ulong>) GetUnmanagedPtr<Player_GetHwidExHashDelegate>(funcTable, 424368865670330442UL, Player_GetHwidExHashFallback);
            Player_GetHwidHash = (delegate* unmanaged[Cdecl]<nint, ulong>) GetUnmanagedPtr<Player_GetHwidHashDelegate>(funcTable, 9546723288515311389UL, Player_GetHwidHashFallback);
            Player_GetInteriorLocation = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Player_GetInteriorLocationDelegate>(funcTable, 16961931856292652951UL, Player_GetInteriorLocationFallback);
            Player_GetInvincible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_GetInvincibleDelegate>(funcTable, 7798711259932314794UL, Player_GetInvincibleFallback);
            Player_GetIP = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Player_GetIPDelegate>(funcTable, 8783734273686352045UL, Player_GetIPFallback);
            Player_GetLastDamagedBodyPart = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Player_GetLastDamagedBodyPartDelegate>(funcTable, 9058687391069917590UL, Player_GetLastDamagedBodyPartFallback);
            Player_GetLocalMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<Player_GetLocalMetaDataDelegate>(funcTable, 15142887281553588533UL, Player_GetLocalMetaDataFallback);
            Player_GetPing = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Player_GetPingDelegate>(funcTable, 9418660647453374374UL, Player_GetPingFallback);
            Player_GetProps = (delegate* unmanaged[Cdecl]<nint, byte, Prop*, void>) GetUnmanagedPtr<Player_GetPropsDelegate>(funcTable, 8714568292526998675UL, Player_GetPropsFallback);
            Player_GetSendNames = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_GetSendNamesDelegate>(funcTable, 7490273379384857895UL, Player_GetSendNamesFallback);
            Player_GetSocialClubName = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Player_GetSocialClubNameDelegate>(funcTable, 17452312619664438538UL, Player_GetSocialClubNameFallback);
            Player_GetSocialID = (delegate* unmanaged[Cdecl]<nint, ulong>) GetUnmanagedPtr<Player_GetSocialIDDelegate>(funcTable, 17807664466527734655UL, Player_GetSocialIDFallback);
            Player_GetWeaponCount = (delegate* unmanaged[Cdecl]<nint, ulong>) GetUnmanagedPtr<Player_GetWeaponCountDelegate>(funcTable, 17600594564491002166UL, Player_GetWeaponCountFallback);
            Player_GetWeapons = (delegate* unmanaged[Cdecl]<nint, nint*, uint*, void>) GetUnmanagedPtr<Player_GetWeaponsDelegate>(funcTable, 3618744060322552484UL, Player_GetWeaponsFallback);
            Player_GetWeaponTintIndex = (delegate* unmanaged[Cdecl]<nint, uint, byte>) GetUnmanagedPtr<Player_GetWeaponTintIndexDelegate>(funcTable, 7900539810461516189UL, Player_GetWeaponTintIndexFallback);
            Player_GiveWeapon = (delegate* unmanaged[Cdecl]<nint, uint, int, byte, void>) GetUnmanagedPtr<Player_GiveWeaponDelegate>(funcTable, 5246190565479056930UL, Player_GiveWeaponFallback);
            Player_HasLocalMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Player_HasLocalMetaDataDelegate>(funcTable, 887625289441263538UL, Player_HasLocalMetaDataFallback);
            Player_HasWeaponComponent = (delegate* unmanaged[Cdecl]<nint, uint, uint, byte>) GetUnmanagedPtr<Player_HasWeaponComponentDelegate>(funcTable, 18283733509389143244UL, Player_HasWeaponComponentFallback);
            Player_IsConnected = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsConnectedDelegate>(funcTable, 16462043613168172496UL, Player_IsConnectedFallback);
            Player_IsCrouching = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsCrouchingDelegate>(funcTable, 14630872318254829849UL, Player_IsCrouchingFallback);
            Player_IsEntityInStreamingRange = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Player_IsEntityInStreamingRangeDelegate>(funcTable, 4495638180817996194UL, Player_IsEntityInStreamingRangeFallback);
            Player_IsStealthy = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsStealthyDelegate>(funcTable, 13440527787182826435UL, Player_IsStealthyFallback);
            Player_IsSuperJumpEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsSuperJumpEnabledDelegate>(funcTable, 6165254230688543493UL, Player_IsSuperJumpEnabledFallback);
            Player_Kick = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Player_KickDelegate>(funcTable, 1188245696791696101UL, Player_KickFallback);
            Player_PlayAmbientSpeech = (delegate* unmanaged[Cdecl]<nint, nint, nint, uint, void>) GetUnmanagedPtr<Player_PlayAmbientSpeechDelegate>(funcTable, 8410706621915957253UL, Player_PlayAmbientSpeechFallback);
            Player_PlayAnimation = (delegate* unmanaged[Cdecl]<nint, nint, nint, float, float, int, int, float, byte, byte, byte, void>) GetUnmanagedPtr<Player_PlayAnimationDelegate>(funcTable, 3904282782623490761UL, Player_PlayAnimationFallback);
            Player_RemoveAllWeapons = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Player_RemoveAllWeaponsDelegate>(funcTable, 17492760648600181256UL, Player_RemoveAllWeaponsFallback);
            Player_RemoveFaceFeature = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Player_RemoveFaceFeatureDelegate>(funcTable, 1204109734587833282UL, Player_RemoveFaceFeatureFallback);
            Player_RemoveHeadOverlay = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Player_RemoveHeadOverlayDelegate>(funcTable, 12300710546613769705UL, Player_RemoveHeadOverlayFallback);
            Player_RemoveWeapon = (delegate* unmanaged[Cdecl]<nint, uint, byte>) GetUnmanagedPtr<Player_RemoveWeaponDelegate>(funcTable, 6739305111416325852UL, Player_RemoveWeaponFallback);
            Player_RemoveWeaponComponent = (delegate* unmanaged[Cdecl]<nint, uint, uint, void>) GetUnmanagedPtr<Player_RemoveWeaponComponentDelegate>(funcTable, 937601034617427157UL, Player_RemoveWeaponComponentFallback);
            Player_SetArmor = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Player_SetArmorDelegate>(funcTable, 5448975639456714442UL, Player_SetArmorFallback);
            Player_SetClothes = (delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte, byte>) GetUnmanagedPtr<Player_SetClothesDelegate>(funcTable, 11224074188063298114UL, Player_SetClothesFallback);
            Player_SetCurrentWeapon = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Player_SetCurrentWeaponDelegate>(funcTable, 1968418760268978302UL, Player_SetCurrentWeaponFallback);
            Player_SetDateTime = (delegate* unmanaged[Cdecl]<nint, int, int, int, int, int, int, void>) GetUnmanagedPtr<Player_SetDateTimeDelegate>(funcTable, 9083292309969581317UL, Player_SetDateTimeFallback);
            Player_SetDlcClothes = (delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte, uint, byte>) GetUnmanagedPtr<Player_SetDlcClothesDelegate>(funcTable, 9625056966078090800UL, Player_SetDlcClothesFallback);
            Player_SetDlcProps = (delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, uint, byte>) GetUnmanagedPtr<Player_SetDlcPropsDelegate>(funcTable, 8489445328683674574UL, Player_SetDlcPropsFallback);
            Player_SetEyeColor = (delegate* unmanaged[Cdecl]<nint, ushort, byte>) GetUnmanagedPtr<Player_SetEyeColorDelegate>(funcTable, 10735865801793422780UL, Player_SetEyeColorFallback);
            Player_SetFaceFeature = (delegate* unmanaged[Cdecl]<nint, byte, float, byte>) GetUnmanagedPtr<Player_SetFaceFeatureDelegate>(funcTable, 15141272301133032025UL, Player_SetFaceFeatureFallback);
            Player_SetHairColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Player_SetHairColorDelegate>(funcTable, 605531555837771349UL, Player_SetHairColorFallback);
            Player_SetHairHighlightColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Player_SetHairHighlightColorDelegate>(funcTable, 7824003541268948351UL, Player_SetHairHighlightColorFallback);
            Player_SetHeadBlendData = (delegate* unmanaged[Cdecl]<nint, uint, uint, uint, uint, uint, uint, float, float, float, void>) GetUnmanagedPtr<Player_SetHeadBlendDataDelegate>(funcTable, 16792485100356674934UL, Player_SetHeadBlendDataFallback);
            Player_SetHeadBlendPaletteColor = (delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, byte>) GetUnmanagedPtr<Player_SetHeadBlendPaletteColorDelegate>(funcTable, 4812058342522920922UL, Player_SetHeadBlendPaletteColorFallback);
            Player_SetHeadOverlay = (delegate* unmanaged[Cdecl]<nint, byte, byte, float, byte>) GetUnmanagedPtr<Player_SetHeadOverlayDelegate>(funcTable, 5036228291735152530UL, Player_SetHeadOverlayFallback);
            Player_SetHeadOverlayColor = (delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, byte>) GetUnmanagedPtr<Player_SetHeadOverlayColorDelegate>(funcTable, 8921506678163013966UL, Player_SetHeadOverlayColorFallback);
            Player_SetHealth = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Player_SetHealthDelegate>(funcTable, 30941545022839701UL, Player_SetHealthFallback);
            Player_SetIntoVehicle = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) GetUnmanagedPtr<Player_SetIntoVehicleDelegate>(funcTable, 10377816601047780579UL, Player_SetIntoVehicleFallback);
            Player_SetInvincible = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Player_SetInvincibleDelegate>(funcTable, 5652100087484927961UL, Player_SetInvincibleFallback);
            Player_SetLastDamagedBodyPart = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Player_SetLastDamagedBodyPartDelegate>(funcTable, 10687757689804664093UL, Player_SetLastDamagedBodyPartFallback);
            Player_SetLocalMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<Player_SetLocalMetaDataDelegate>(funcTable, 827100853319049704UL, Player_SetLocalMetaDataFallback);
            Player_SetMaxArmor = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Player_SetMaxArmorDelegate>(funcTable, 415910985208965186UL, Player_SetMaxArmorFallback);
            Player_SetMaxHealth = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Player_SetMaxHealthDelegate>(funcTable, 10929207046366144781UL, Player_SetMaxHealthFallback);
            Player_SetModel = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Player_SetModelDelegate>(funcTable, 13570087722085690158UL, Player_SetModelFallback);
            Player_SetProps = (delegate* unmanaged[Cdecl]<nint, byte, ushort, byte, byte>) GetUnmanagedPtr<Player_SetPropsDelegate>(funcTable, 6668196575965816060UL, Player_SetPropsFallback);
            Player_SetSendNames = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Player_SetSendNamesDelegate>(funcTable, 15189973730348812706UL, Player_SetSendNamesFallback);
            Player_SetWeaponTintIndex = (delegate* unmanaged[Cdecl]<nint, uint, byte, void>) GetUnmanagedPtr<Player_SetWeaponTintIndexDelegate>(funcTable, 968905854061954392UL, Player_SetWeaponTintIndexFallback);
            Player_SetWeather = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Player_SetWeatherDelegate>(funcTable, 1822619990745107975UL, Player_SetWeatherFallback);
            Player_Spawn = (delegate* unmanaged[Cdecl]<nint, Vector3, uint, void>) GetUnmanagedPtr<Player_SpawnDelegate>(funcTable, 5945475651017052621UL, Player_SpawnFallback);
            Resource_GetMain = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Resource_GetMainDelegate>(funcTable, 8337898451868765791UL, Resource_GetMainFallback);
            Resource_GetPath = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Resource_GetPathDelegate>(funcTable, 10659090672396987581UL, Resource_GetPathFallback);
            Resource_Start = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Resource_StartDelegate>(funcTable, 2255534561568952884UL, Resource_StartFallback);
            Resource_Stop = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Resource_StopDelegate>(funcTable, 7462267939906784556UL, Resource_StopFallback);
            Vehicle_DoesWheelHasTire = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_DoesWheelHasTireDelegate>(funcTable, 8416964569973671667UL, Vehicle_DoesWheelHasTireFallback);
            Vehicle_GetAppearanceDataBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Vehicle_GetAppearanceDataBase64Delegate>(funcTable, 3632203335502296505UL, Vehicle_GetAppearanceDataBase64Fallback);
            Vehicle_GetArmoredWindowHealth = (delegate* unmanaged[Cdecl]<nint, byte, float>) GetUnmanagedPtr<Vehicle_GetArmoredWindowHealthDelegate>(funcTable, 7966408129250273744UL, Vehicle_GetArmoredWindowHealthFallback);
            Vehicle_GetArmoredWindowShootCount = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_GetArmoredWindowShootCountDelegate>(funcTable, 1975272227796355721UL, Vehicle_GetArmoredWindowShootCountFallback);
            Vehicle_GetAttached = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Vehicle_GetAttachedDelegate>(funcTable, 2423140866671700142UL, Vehicle_GetAttachedFallback);
            Vehicle_GetAttachedTo = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Vehicle_GetAttachedToDelegate>(funcTable, 1884500231720349747UL, Vehicle_GetAttachedToFallback);
            Vehicle_GetBoatAnchor = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetBoatAnchorDelegate>(funcTable, 15746529459417614900UL, Vehicle_GetBoatAnchorFallback);
            Vehicle_GetBodyAdditionalHealth = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Vehicle_GetBodyAdditionalHealthDelegate>(funcTable, 1269347486506827783UL, Vehicle_GetBodyAdditionalHealthFallback);
            Vehicle_GetBodyHealth = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Vehicle_GetBodyHealthDelegate>(funcTable, 2235337646201152502UL, Vehicle_GetBodyHealthFallback);
            Vehicle_GetBumperDamageLevel = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_GetBumperDamageLevelDelegate>(funcTable, 2929119416191807641UL, Vehicle_GetBumperDamageLevelFallback);
            Vehicle_GetCounterMeasureCount = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Vehicle_GetCounterMeasureCountDelegate>(funcTable, 7262431296410707143UL, Vehicle_GetCounterMeasureCountFallback);
            Vehicle_GetCustomTires = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetCustomTiresDelegate>(funcTable, 16298627533374836407UL, Vehicle_GetCustomTiresFallback);
            Vehicle_GetDamageDataBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Vehicle_GetDamageDataBase64Delegate>(funcTable, 4393478606065674962UL, Vehicle_GetDamageDataBase64Fallback);
            Vehicle_GetDashboardColor = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetDashboardColorDelegate>(funcTable, 3164804470767655728UL, Vehicle_GetDashboardColorFallback);
            Vehicle_GetDirtLevel = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetDirtLevelDelegate>(funcTable, 1312826368700331414UL, Vehicle_GetDirtLevelFallback);
            Vehicle_GetDoorState = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_GetDoorStateDelegate>(funcTable, 3655237348473428026UL, Vehicle_GetDoorStateFallback);
            Vehicle_GetDriver = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Vehicle_GetDriverDelegate>(funcTable, 8554773347420139463UL, Vehicle_GetDriverFallback);
            Vehicle_GetDriverID = (delegate* unmanaged[Cdecl]<nint, ushort*, byte>) GetUnmanagedPtr<Vehicle_GetDriverIDDelegate>(funcTable, 6476166832678215577UL, Vehicle_GetDriverIDFallback);
            Vehicle_GetEngineHealth = (delegate* unmanaged[Cdecl]<nint, int>) GetUnmanagedPtr<Vehicle_GetEngineHealthDelegate>(funcTable, 8002690258276396481UL, Vehicle_GetEngineHealthFallback);
            Vehicle_GetGameStateBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Vehicle_GetGameStateBase64Delegate>(funcTable, 4097244648501164820UL, Vehicle_GetGameStateBase64Fallback);
            Vehicle_GetHeadlightColor = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetHeadlightColorDelegate>(funcTable, 10761034670704244318UL, Vehicle_GetHeadlightColorFallback);
            Vehicle_GetHealthDataBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Vehicle_GetHealthDataBase64Delegate>(funcTable, 16435096973185009469UL, Vehicle_GetHealthDataBase64Fallback);
            Vehicle_GetHybridExtraActive = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetHybridExtraActiveDelegate>(funcTable, 13937947855950420355UL, Vehicle_GetHybridExtraActiveFallback);
            Vehicle_GetHybridExtraState = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetHybridExtraStateDelegate>(funcTable, 13357688267232314078UL, Vehicle_GetHybridExtraStateFallback);
            Vehicle_GetInteriorColor = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetInteriorColorDelegate>(funcTable, 16605858542065332380UL, Vehicle_GetInteriorColorFallback);
            Vehicle_GetLightsMultiplier = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_GetLightsMultiplierDelegate>(funcTable, 554317566951363114UL, Vehicle_GetLightsMultiplierFallback);
            Vehicle_GetLightState = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetLightStateDelegate>(funcTable, 8516664736191903198UL, Vehicle_GetLightStateFallback);
            Vehicle_GetLivery = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetLiveryDelegate>(funcTable, 15183248080542367608UL, Vehicle_GetLiveryFallback);
            Vehicle_GetLockState = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetLockStateDelegate>(funcTable, 7643361960323807741UL, Vehicle_GetLockStateFallback);
            Vehicle_GetMod = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_GetModDelegate>(funcTable, 2523210803484160525UL, Vehicle_GetModFallback);
            Vehicle_GetModKit = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetModKitDelegate>(funcTable, 15776275225618936077UL, Vehicle_GetModKitFallback);
            Vehicle_GetModKitsCount = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetModKitsCountDelegate>(funcTable, 12663576059300545357UL, Vehicle_GetModKitsCountFallback);
            Vehicle_GetModsCount = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_GetModsCountDelegate>(funcTable, 575873775847860285UL, Vehicle_GetModsCountFallback);
            Vehicle_GetNeonActive = (delegate* unmanaged[Cdecl]<nint, byte*, byte*, byte*, byte*, void>) GetUnmanagedPtr<Vehicle_GetNeonActiveDelegate>(funcTable, 12498704994887046670UL, Vehicle_GetNeonActiveFallback);
            Vehicle_GetNeonColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) GetUnmanagedPtr<Vehicle_GetNeonColorDelegate>(funcTable, 6406234233502748685UL, Vehicle_GetNeonColorFallback);
            Vehicle_GetNumberplateIndex = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Vehicle_GetNumberplateIndexDelegate>(funcTable, 13944338770493453261UL, Vehicle_GetNumberplateIndexFallback);
            Vehicle_GetNumberplateText = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Vehicle_GetNumberplateTextDelegate>(funcTable, 10767500614704999252UL, Vehicle_GetNumberplateTextFallback);
            Vehicle_GetPartBulletHoles = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_GetPartBulletHolesDelegate>(funcTable, 6808733807057690309UL, Vehicle_GetPartBulletHolesFallback);
            Vehicle_GetPartDamageLevel = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_GetPartDamageLevelDelegate>(funcTable, 12086844516725116331UL, Vehicle_GetPartDamageLevelFallback);
            Vehicle_GetPearlColor = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetPearlColorDelegate>(funcTable, 15213363766571057872UL, Vehicle_GetPearlColorFallback);
            Vehicle_GetPrimaryColor = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetPrimaryColorDelegate>(funcTable, 6361531094469306918UL, Vehicle_GetPrimaryColorFallback);
            Vehicle_GetPrimaryColorRGB = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) GetUnmanagedPtr<Vehicle_GetPrimaryColorRGBDelegate>(funcTable, 12628655035446474558UL, Vehicle_GetPrimaryColorRGBFallback);
            Vehicle_GetQuaternion = (delegate* unmanaged[Cdecl]<nint, Quaternion>) GetUnmanagedPtr<Vehicle_GetQuaternionDelegate>(funcTable, 2293158668820125317UL, Vehicle_GetQuaternionFallback);
            Vehicle_GetRadioStationIndex = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Vehicle_GetRadioStationIndexDelegate>(funcTable, 4283418015941180107UL, Vehicle_GetRadioStationIndexFallback);
            Vehicle_GetRearWheelVariation = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetRearWheelVariationDelegate>(funcTable, 3402335583322585123UL, Vehicle_GetRearWheelVariationFallback);
            Vehicle_GetRepairsCount = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetRepairsCountDelegate>(funcTable, 13519520674920899414UL, Vehicle_GetRepairsCountFallback);
            Vehicle_GetRocketRefuelSpeed = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_GetRocketRefuelSpeedDelegate>(funcTable, 15609307098236441512UL, Vehicle_GetRocketRefuelSpeedFallback);
            Vehicle_GetRoofLivery = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetRoofLiveryDelegate>(funcTable, 2608479699205284158UL, Vehicle_GetRoofLiveryFallback);
            Vehicle_GetRoofState = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetRoofStateDelegate>(funcTable, 7626267752797424064UL, Vehicle_GetRoofStateFallback);
            Vehicle_GetScriptDataBase64 = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Vehicle_GetScriptDataBase64Delegate>(funcTable, 14998297632079967688UL, Vehicle_GetScriptDataBase64Fallback);
            Vehicle_GetScriptMaxSpeed = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_GetScriptMaxSpeedDelegate>(funcTable, 17416808335692421258UL, Vehicle_GetScriptMaxSpeedFallback);
            Vehicle_GetSecondaryColor = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetSecondaryColorDelegate>(funcTable, 14172903387851795634UL, Vehicle_GetSecondaryColorFallback);
            Vehicle_GetSecondaryColorRGB = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) GetUnmanagedPtr<Vehicle_GetSecondaryColorRGBDelegate>(funcTable, 14310164949555082610UL, Vehicle_GetSecondaryColorRGBFallback);
            Vehicle_GetSpecialDarkness = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetSpecialDarknessDelegate>(funcTable, 14213848578023585681UL, Vehicle_GetSpecialDarknessFallback);
            Vehicle_GetTimedExplosionCulprit = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Vehicle_GetTimedExplosionCulpritDelegate>(funcTable, 10814387811937670626UL, Vehicle_GetTimedExplosionCulpritFallback);
            Vehicle_GetTimedExplosionTime = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Vehicle_GetTimedExplosionTimeDelegate>(funcTable, 8302796318601840675UL, Vehicle_GetTimedExplosionTimeFallback);
            Vehicle_GetTireSmokeColor = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) GetUnmanagedPtr<Vehicle_GetTireSmokeColorDelegate>(funcTable, 8782960240081250816UL, Vehicle_GetTireSmokeColorFallback);
            Vehicle_GetTrainCarriageConfigIndex = (delegate* unmanaged[Cdecl]<nint, sbyte>) GetUnmanagedPtr<Vehicle_GetTrainCarriageConfigIndexDelegate>(funcTable, 3570735871695593196UL, Vehicle_GetTrainCarriageConfigIndexFallback);
            Vehicle_GetTrainConfigIndex = (delegate* unmanaged[Cdecl]<nint, sbyte>) GetUnmanagedPtr<Vehicle_GetTrainConfigIndexDelegate>(funcTable, 1475332107693048062UL, Vehicle_GetTrainConfigIndexFallback);
            Vehicle_GetTrainCruiseSpeed = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_GetTrainCruiseSpeedDelegate>(funcTable, 17701404211540696024UL, Vehicle_GetTrainCruiseSpeedFallback);
            Vehicle_GetTrainDirection = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetTrainDirectionDelegate>(funcTable, 11490711419926021348UL, Vehicle_GetTrainDirectionFallback);
            Vehicle_GetTrainDistanceFromEngine = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_GetTrainDistanceFromEngineDelegate>(funcTable, 13171736797128222753UL, Vehicle_GetTrainDistanceFromEngineFallback);
            Vehicle_GetTrainEngineId = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Vehicle_GetTrainEngineIdDelegate>(funcTable, 9254867853965609035UL, Vehicle_GetTrainEngineIdFallback);
            Vehicle_GetTrainForceDoorsOpen = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetTrainForceDoorsOpenDelegate>(funcTable, 10757720802904664655UL, Vehicle_GetTrainForceDoorsOpenFallback);
            Vehicle_GetTrainLinkedToBackwardId = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Vehicle_GetTrainLinkedToBackwardIdDelegate>(funcTable, 6553325610630104416UL, Vehicle_GetTrainLinkedToBackwardIdFallback);
            Vehicle_GetTrainLinkedToForwardId = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Vehicle_GetTrainLinkedToForwardIdDelegate>(funcTable, 11637828876482387744UL, Vehicle_GetTrainLinkedToForwardIdFallback);
            Vehicle_GetTrainRenderDerailed = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetTrainRenderDerailedDelegate>(funcTable, 14185875420107220449UL, Vehicle_GetTrainRenderDerailedFallback);
            Vehicle_GetTrainTrackId = (delegate* unmanaged[Cdecl]<nint, sbyte>) GetUnmanagedPtr<Vehicle_GetTrainTrackIdDelegate>(funcTable, 7440218482625997154UL, Vehicle_GetTrainTrackIdFallback);
            Vehicle_GetVelocity = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) GetUnmanagedPtr<Vehicle_GetVelocityDelegate>(funcTable, 9475232218292516780UL, Vehicle_GetVelocityFallback);
            Vehicle_GetWeaponCapacity = (delegate* unmanaged[Cdecl]<nint, byte, int>) GetUnmanagedPtr<Vehicle_GetWeaponCapacityDelegate>(funcTable, 1039686418406101301UL, Vehicle_GetWeaponCapacityFallback);
            Vehicle_GetWheelColor = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetWheelColorDelegate>(funcTable, 18347498466552743195UL, Vehicle_GetWheelColorFallback);
            Vehicle_GetWheelHealth = (delegate* unmanaged[Cdecl]<nint, byte, float>) GetUnmanagedPtr<Vehicle_GetWheelHealthDelegate>(funcTable, 18444275782955971099UL, Vehicle_GetWheelHealthFallback);
            Vehicle_GetWheelType = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetWheelTypeDelegate>(funcTable, 12014486823114077012UL, Vehicle_GetWheelTypeFallback);
            Vehicle_GetWheelVariation = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetWheelVariationDelegate>(funcTable, 16504007791942538449UL, Vehicle_GetWheelVariationFallback);
            Vehicle_GetWindowTint = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetWindowTintDelegate>(funcTable, 7070676377669679790UL, Vehicle_GetWindowTintFallback);
            Vehicle_HasArmoredWindows = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_HasArmoredWindowsDelegate>(funcTable, 4293189270879516620UL, Vehicle_HasArmoredWindowsFallback);
            Vehicle_HasTimedExplosion = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_HasTimedExplosionDelegate>(funcTable, 12830650519090663455UL, Vehicle_HasTimedExplosionFallback);
            Vehicle_HasTrainPassengerCarriages = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_HasTrainPassengerCarriagesDelegate>(funcTable, 2554444105701754850UL, Vehicle_HasTrainPassengerCarriagesFallback);
            Vehicle_IsDaylightOn = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsDaylightOnDelegate>(funcTable, 6335054158572605752UL, Vehicle_IsDaylightOnFallback);
            Vehicle_IsDestroyed = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsDestroyedDelegate>(funcTable, 7449429529924688924UL, Vehicle_IsDestroyedFallback);
            Vehicle_IsDriftMode = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsDriftModeDelegate>(funcTable, 15743310844658047717UL, Vehicle_IsDriftModeFallback);
            Vehicle_IsEngineOn = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsEngineOnDelegate>(funcTable, 3514385841065133724UL, Vehicle_IsEngineOnFallback);
            Vehicle_IsExtraOn = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_IsExtraOnDelegate>(funcTable, 18360767208271729044UL, Vehicle_IsExtraOnFallback);
            Vehicle_IsFlamethrowerActive = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsFlamethrowerActiveDelegate>(funcTable, 292816396413146289UL, Vehicle_IsFlamethrowerActiveFallback);
            Vehicle_IsHandbrakeActive = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsHandbrakeActiveDelegate>(funcTable, 11030244632469291311UL, Vehicle_IsHandbrakeActiveFallback);
            Vehicle_IsLightDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_IsLightDamagedDelegate>(funcTable, 5253270677373576288UL, Vehicle_IsLightDamagedFallback);
            Vehicle_IsManualEngineControl = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsManualEngineControlDelegate>(funcTable, 17339945504294461378UL, Vehicle_IsManualEngineControlFallback);
            Vehicle_IsNeonActive = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsNeonActiveDelegate>(funcTable, 6810098793323566371UL, Vehicle_IsNeonActiveFallback);
            Vehicle_IsNightlightOn = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsNightlightOnDelegate>(funcTable, 393593600849553108UL, Vehicle_IsNightlightOnFallback);
            Vehicle_IsPrimaryColorRGB = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsPrimaryColorRGBDelegate>(funcTable, 3246602745742951177UL, Vehicle_IsPrimaryColorRGBFallback);
            Vehicle_IsSecondaryColorRGB = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsSecondaryColorRGBDelegate>(funcTable, 5475689999282997661UL, Vehicle_IsSecondaryColorRGBFallback);
            Vehicle_IsSirenActive = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsSirenActiveDelegate>(funcTable, 14858049513303226544UL, Vehicle_IsSirenActiveFallback);
            Vehicle_IsSpecialLightDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_IsSpecialLightDamagedDelegate>(funcTable, 631190088328166457UL, Vehicle_IsSpecialLightDamagedFallback);
            Vehicle_IsTireSmokeColorCustom = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsTireSmokeColorCustomDelegate>(funcTable, 8265817743805565238UL, Vehicle_IsTireSmokeColorCustomFallback);
            Vehicle_IsTowingDisabled = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsTowingDisabledDelegate>(funcTable, 9684236099723813055UL, Vehicle_IsTowingDisabledFallback);
            Vehicle_IsTrainCaboose = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsTrainCabooseDelegate>(funcTable, 15357409166142265171UL, Vehicle_IsTrainCabooseFallback);
            Vehicle_IsTrainEngine = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsTrainEngineDelegate>(funcTable, 16222854328452812697UL, Vehicle_IsTrainEngineFallback);
            Vehicle_IsTrainMissionTrain = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsTrainMissionTrainDelegate>(funcTable, 3888784849052609375UL, Vehicle_IsTrainMissionTrainFallback);
            Vehicle_IsWheelBurst = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_IsWheelBurstDelegate>(funcTable, 7387521157980114232UL, Vehicle_IsWheelBurstFallback);
            Vehicle_IsWheelDetached = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_IsWheelDetachedDelegate>(funcTable, 16637629476435945994UL, Vehicle_IsWheelDetachedFallback);
            Vehicle_IsWheelOnFire = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_IsWheelOnFireDelegate>(funcTable, 8838149399450321903UL, Vehicle_IsWheelOnFireFallback);
            Vehicle_IsWindowDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_IsWindowDamagedDelegate>(funcTable, 11826181606742921976UL, Vehicle_IsWindowDamagedFallback);
            Vehicle_IsWindowOpened = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_IsWindowOpenedDelegate>(funcTable, 18379774352659401934UL, Vehicle_IsWindowOpenedFallback);
            Vehicle_LoadAppearanceDataFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Vehicle_LoadAppearanceDataFromBase64Delegate>(funcTable, 16083140820382459150UL, Vehicle_LoadAppearanceDataFromBase64Fallback);
            Vehicle_LoadDamageDataFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Vehicle_LoadDamageDataFromBase64Delegate>(funcTable, 17122813768646519469UL, Vehicle_LoadDamageDataFromBase64Fallback);
            Vehicle_LoadGameStateFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Vehicle_LoadGameStateFromBase64Delegate>(funcTable, 12185057153568059447UL, Vehicle_LoadGameStateFromBase64Fallback);
            Vehicle_LoadHealthDataFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Vehicle_LoadHealthDataFromBase64Delegate>(funcTable, 7534930619285916522UL, Vehicle_LoadHealthDataFromBase64Fallback);
            Vehicle_LoadScriptDataFromBase64 = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Vehicle_LoadScriptDataFromBase64Delegate>(funcTable, 15701706088061678883UL, Vehicle_LoadScriptDataFromBase64Fallback);
            Vehicle_Repair = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Vehicle_RepairDelegate>(funcTable, 277481303661922113UL, Vehicle_RepairFallback);
            Vehicle_SetArmoredWindowHealth = (delegate* unmanaged[Cdecl]<nint, byte, float, void>) GetUnmanagedPtr<Vehicle_SetArmoredWindowHealthDelegate>(funcTable, 1070345202824576095UL, Vehicle_SetArmoredWindowHealthFallback);
            Vehicle_SetArmoredWindowShootCount = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetArmoredWindowShootCountDelegate>(funcTable, 4149223353503655708UL, Vehicle_SetArmoredWindowShootCountFallback);
            Vehicle_SetBoatAnchor = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetBoatAnchorDelegate>(funcTable, 16890059088943800731UL, Vehicle_SetBoatAnchorFallback);
            Vehicle_SetBodyAdditionalHealth = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Vehicle_SetBodyAdditionalHealthDelegate>(funcTable, 5545167983491514394UL, Vehicle_SetBodyAdditionalHealthFallback);
            Vehicle_SetBodyHealth = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Vehicle_SetBodyHealthDelegate>(funcTable, 13734895793996634557UL, Vehicle_SetBodyHealthFallback);
            Vehicle_SetBumperDamageLevel = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetBumperDamageLevelDelegate>(funcTable, 4896146170857709532UL, Vehicle_SetBumperDamageLevelFallback);
            Vehicle_SetCounterMeasureCount = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Vehicle_SetCounterMeasureCountDelegate>(funcTable, 14151953087246239474UL, Vehicle_SetCounterMeasureCountFallback);
            Vehicle_SetCustomTires = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetCustomTiresDelegate>(funcTable, 11016824015312467794UL, Vehicle_SetCustomTiresFallback);
            Vehicle_SetDashboardColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetDashboardColorDelegate>(funcTable, 3393145177112569271UL, Vehicle_SetDashboardColorFallback);
            Vehicle_SetDirtLevel = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetDirtLevelDelegate>(funcTable, 10492762472194549229UL, Vehicle_SetDirtLevelFallback);
            Vehicle_SetDisableTowing = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetDisableTowingDelegate>(funcTable, 4356512486587209458UL, Vehicle_SetDisableTowingFallback);
            Vehicle_SetDoorState = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetDoorStateDelegate>(funcTable, 8306743616252697089UL, Vehicle_SetDoorStateFallback);
            Vehicle_SetDriftMode = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetDriftModeDelegate>(funcTable, 17899000422270832188UL, Vehicle_SetDriftModeFallback);
            Vehicle_SetEngineHealth = (delegate* unmanaged[Cdecl]<nint, int, void>) GetUnmanagedPtr<Vehicle_SetEngineHealthDelegate>(funcTable, 5199230521114654156UL, Vehicle_SetEngineHealthFallback);
            Vehicle_SetEngineOn = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetEngineOnDelegate>(funcTable, 16791686050420127303UL, Vehicle_SetEngineOnFallback);
            Vehicle_SetHeadlightColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetHeadlightColorDelegate>(funcTable, 5418309160808792661UL, Vehicle_SetHeadlightColorFallback);
            Vehicle_SetHybridExtraActive = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetHybridExtraActiveDelegate>(funcTable, 3459212622909721246UL, Vehicle_SetHybridExtraActiveFallback);
            Vehicle_SetHybridExtraState = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetHybridExtraStateDelegate>(funcTable, 15855843859771568037UL, Vehicle_SetHybridExtraStateFallback);
            Vehicle_SetInteriorColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetInteriorColorDelegate>(funcTable, 17031985447220940355UL, Vehicle_SetInteriorColorFallback);
            Vehicle_SetLightDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetLightDamagedDelegate>(funcTable, 11273288101046838075UL, Vehicle_SetLightDamagedFallback);
            Vehicle_SetLightsMultiplier = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_SetLightsMultiplierDelegate>(funcTable, 8647644719134395873UL, Vehicle_SetLightsMultiplierFallback);
            Vehicle_SetLightState = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetLightStateDelegate>(funcTable, 7273524217581467669UL, Vehicle_SetLightStateFallback);
            Vehicle_SetLivery = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetLiveryDelegate>(funcTable, 9411581988332289159UL, Vehicle_SetLiveryFallback);
            Vehicle_SetLockState = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetLockStateDelegate>(funcTable, 14764372114954550256UL, Vehicle_SetLockStateFallback);
            Vehicle_SetManualEngineControl = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetManualEngineControlDelegate>(funcTable, 3379206359062776477UL, Vehicle_SetManualEngineControlFallback);
            Vehicle_SetMod = (delegate* unmanaged[Cdecl]<nint, byte, byte, byte>) GetUnmanagedPtr<Vehicle_SetModDelegate>(funcTable, 1085868007361817261UL, Vehicle_SetModFallback);
            Vehicle_SetModKit = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Vehicle_SetModKitDelegate>(funcTable, 11564299376170797237UL, Vehicle_SetModKitFallback);
            Vehicle_SetNeonActive = (delegate* unmanaged[Cdecl]<nint, byte, byte, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetNeonActiveDelegate>(funcTable, 1179535280233814898UL, Vehicle_SetNeonActiveFallback);
            Vehicle_SetNeonColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) GetUnmanagedPtr<Vehicle_SetNeonColorDelegate>(funcTable, 2251350605404815111UL, Vehicle_SetNeonColorFallback);
            Vehicle_SetNumberplateIndex = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Vehicle_SetNumberplateIndexDelegate>(funcTable, 18117779513936541448UL, Vehicle_SetNumberplateIndexFallback);
            Vehicle_SetNumberplateText = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Vehicle_SetNumberplateTextDelegate>(funcTable, 5374563022053443727UL, Vehicle_SetNumberplateTextFallback);
            Vehicle_SetPartBulletHoles = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetPartBulletHolesDelegate>(funcTable, 2632373577418693136UL, Vehicle_SetPartBulletHolesFallback);
            Vehicle_SetPartDamageLevel = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetPartDamageLevelDelegate>(funcTable, 12872008344641145022UL, Vehicle_SetPartDamageLevelFallback);
            Vehicle_SetPearlColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetPearlColorDelegate>(funcTable, 5092442984600044063UL, Vehicle_SetPearlColorFallback);
            Vehicle_SetPetrolTankHealth = (delegate* unmanaged[Cdecl]<nint, int, void>) GetUnmanagedPtr<Vehicle_SetPetrolTankHealthDelegate>(funcTable, 8082406915422712268UL, Vehicle_SetPetrolTankHealthFallback);
            Vehicle_SetPrimaryColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetPrimaryColorDelegate>(funcTable, 1331330944977889229UL, Vehicle_SetPrimaryColorFallback);
            Vehicle_SetPrimaryColorRGB = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) GetUnmanagedPtr<Vehicle_SetPrimaryColorRGBDelegate>(funcTable, 10226234016994918718UL, Vehicle_SetPrimaryColorRGBFallback);
            Vehicle_SetQuaternion = (delegate* unmanaged[Cdecl]<nint, Quaternion, void>) GetUnmanagedPtr<Vehicle_SetQuaternionDelegate>(funcTable, 3644573911776237792UL, Vehicle_SetQuaternionFallback);
            Vehicle_SetRadioStationIndex = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Vehicle_SetRadioStationIndexDelegate>(funcTable, 10139114821440740454UL, Vehicle_SetRadioStationIndexFallback);
            Vehicle_SetRearWheels = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetRearWheelsDelegate>(funcTable, 11398193715753714450UL, Vehicle_SetRearWheelsFallback);
            Vehicle_SetRocketRefuelSpeed = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_SetRocketRefuelSpeedDelegate>(funcTable, 13400577352062327287UL, Vehicle_SetRocketRefuelSpeedFallback);
            Vehicle_SetRoofLivery = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetRoofLiveryDelegate>(funcTable, 9945220895029722645UL, Vehicle_SetRoofLiveryFallback);
            Vehicle_SetRoofState = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetRoofStateDelegate>(funcTable, 291656348104897951UL, Vehicle_SetRoofStateFallback);
            Vehicle_SetScriptMaxSpeed = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_SetScriptMaxSpeedDelegate>(funcTable, 10329727708072570961UL, Vehicle_SetScriptMaxSpeedFallback);
            Vehicle_SetSearchLight = (delegate* unmanaged[Cdecl]<nint, byte, nint, byte>) GetUnmanagedPtr<Vehicle_SetSearchLightDelegate>(funcTable, 6097044472677911959UL, Vehicle_SetSearchLightFallback);
            Vehicle_SetSecondaryColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetSecondaryColorDelegate>(funcTable, 13723206556140558193UL, Vehicle_SetSecondaryColorFallback);
            Vehicle_SetSecondaryColorRGB = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) GetUnmanagedPtr<Vehicle_SetSecondaryColorRGBDelegate>(funcTable, 16506735945362713754UL, Vehicle_SetSecondaryColorRGBFallback);
            Vehicle_SetSirenActive = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetSirenActiveDelegate>(funcTable, 15323536650696226427UL, Vehicle_SetSirenActiveFallback);
            Vehicle_SetSpecialDarkness = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetSpecialDarknessDelegate>(funcTable, 13869206981302306804UL, Vehicle_SetSpecialDarknessFallback);
            Vehicle_SetSpecialLightDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetSpecialLightDamagedDelegate>(funcTable, 9711604970429202256UL, Vehicle_SetSpecialLightDamagedFallback);
            Vehicle_SetTimedExplosion = (delegate* unmanaged[Cdecl]<nint, byte, nint, uint, void>) GetUnmanagedPtr<Vehicle_SetTimedExplosionDelegate>(funcTable, 15896352255837413981UL, Vehicle_SetTimedExplosionFallback);
            Vehicle_SetTireSmokeColor = (delegate* unmanaged[Cdecl]<nint, Rgba, void>) GetUnmanagedPtr<Vehicle_SetTireSmokeColorDelegate>(funcTable, 11349512303408646456UL, Vehicle_SetTireSmokeColorFallback);
            Vehicle_SetTrainCarriageConfigIndex = (delegate* unmanaged[Cdecl]<nint, sbyte, void>) GetUnmanagedPtr<Vehicle_SetTrainCarriageConfigIndexDelegate>(funcTable, 8624297097646879723UL, Vehicle_SetTrainCarriageConfigIndexFallback);
            Vehicle_SetTrainConfigIndex = (delegate* unmanaged[Cdecl]<nint, sbyte, void>) GetUnmanagedPtr<Vehicle_SetTrainConfigIndexDelegate>(funcTable, 2622923135355073453UL, Vehicle_SetTrainConfigIndexFallback);
            Vehicle_SetTrainCruiseSpeed = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_SetTrainCruiseSpeedDelegate>(funcTable, 8274946090311724863UL, Vehicle_SetTrainCruiseSpeedFallback);
            Vehicle_SetTrainDirection = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetTrainDirectionDelegate>(funcTable, 697887686207032355UL, Vehicle_SetTrainDirectionFallback);
            Vehicle_SetTrainDistanceFromEngine = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_SetTrainDistanceFromEngineDelegate>(funcTable, 2786180204541667140UL, Vehicle_SetTrainDistanceFromEngineFallback);
            Vehicle_SetTrainEngineId = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Vehicle_SetTrainEngineIdDelegate>(funcTable, 6554134726739178678UL, Vehicle_SetTrainEngineIdFallback);
            Vehicle_SetTrainForceDoorsOpen = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetTrainForceDoorsOpenDelegate>(funcTable, 12186181581499607474UL, Vehicle_SetTrainForceDoorsOpenFallback);
            Vehicle_SetTrainHasPassengerCarriages = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetTrainHasPassengerCarriagesDelegate>(funcTable, 9294807688485485845UL, Vehicle_SetTrainHasPassengerCarriagesFallback);
            Vehicle_SetTrainIsCaboose = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetTrainIsCabooseDelegate>(funcTable, 17771148548114657406UL, Vehicle_SetTrainIsCabooseFallback);
            Vehicle_SetTrainIsEngine = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetTrainIsEngineDelegate>(funcTable, 1304693086007295180UL, Vehicle_SetTrainIsEngineFallback);
            Vehicle_SetTrainLinkedToBackwardId = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Vehicle_SetTrainLinkedToBackwardIdDelegate>(funcTable, 4139956032923379799UL, Vehicle_SetTrainLinkedToBackwardIdFallback);
            Vehicle_SetTrainLinkedToForwardId = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Vehicle_SetTrainLinkedToForwardIdDelegate>(funcTable, 9207317571714316271UL, Vehicle_SetTrainLinkedToForwardIdFallback);
            Vehicle_SetTrainMissionTrain = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetTrainMissionTrainDelegate>(funcTable, 12521424597295262006UL, Vehicle_SetTrainMissionTrainFallback);
            Vehicle_SetTrainRenderDerailed = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetTrainRenderDerailedDelegate>(funcTable, 2100308379463132708UL, Vehicle_SetTrainRenderDerailedFallback);
            Vehicle_SetTrainTrackId = (delegate* unmanaged[Cdecl]<nint, sbyte, void>) GetUnmanagedPtr<Vehicle_SetTrainTrackIdDelegate>(funcTable, 11491059579250577481UL, Vehicle_SetTrainTrackIdFallback);
            Vehicle_SetWeaponCapacity = (delegate* unmanaged[Cdecl]<nint, byte, int, void>) GetUnmanagedPtr<Vehicle_SetWeaponCapacityDelegate>(funcTable, 12549320757916354512UL, Vehicle_SetWeaponCapacityFallback);
            Vehicle_SetWheelBurst = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetWheelBurstDelegate>(funcTable, 1262538630118544211UL, Vehicle_SetWheelBurstFallback);
            Vehicle_SetWheelColor = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetWheelColorDelegate>(funcTable, 15740365027195564678UL, Vehicle_SetWheelColorFallback);
            Vehicle_SetWheelDetached = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetWheelDetachedDelegate>(funcTable, 11278902748564777637UL, Vehicle_SetWheelDetachedFallback);
            Vehicle_SetWheelFixed = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetWheelFixedDelegate>(funcTable, 445307264281942855UL, Vehicle_SetWheelFixedFallback);
            Vehicle_SetWheelHasTire = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetWheelHasTireDelegate>(funcTable, 18173107351820543411UL, Vehicle_SetWheelHasTireFallback);
            Vehicle_SetWheelHealth = (delegate* unmanaged[Cdecl]<nint, byte, float, void>) GetUnmanagedPtr<Vehicle_SetWheelHealthDelegate>(funcTable, 10027959156108587406UL, Vehicle_SetWheelHealthFallback);
            Vehicle_SetWheelOnFire = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetWheelOnFireDelegate>(funcTable, 5586813169125693654UL, Vehicle_SetWheelOnFireFallback);
            Vehicle_SetWheels = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetWheelsDelegate>(funcTable, 10816155882129241208UL, Vehicle_SetWheelsFallback);
            Vehicle_SetWindowDamaged = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetWindowDamagedDelegate>(funcTable, 13639034057684506659UL, Vehicle_SetWindowDamagedFallback);
            Vehicle_SetWindowOpened = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_SetWindowOpenedDelegate>(funcTable, 15969735534680114761UL, Vehicle_SetWindowOpenedFallback);
            Vehicle_SetWindowTint = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetWindowTintDelegate>(funcTable, 9528711699442427461UL, Vehicle_SetWindowTintFallback);
            Vehicle_ToggleExtra = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<Vehicle_ToggleExtraDelegate>(funcTable, 1279447449950278570UL, Vehicle_ToggleExtraFallback);
            VirtualEntity_DeleteStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<VirtualEntity_DeleteStreamSyncedMetaDataDelegate>(funcTable, 7898816756250674587UL, VirtualEntity_DeleteStreamSyncedMetaDataFallback);
            VirtualEntity_SetStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<VirtualEntity_SetStreamSyncedMetaDataDelegate>(funcTable, 917775846368661429UL, VirtualEntity_SetStreamSyncedMetaDataFallback);
            VoiceChannel_AddPlayer = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<VoiceChannel_AddPlayerDelegate>(funcTable, 702226521113983568UL, VoiceChannel_AddPlayerFallback);
            VoiceChannel_DeleteMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<VoiceChannel_DeleteMetaDataDelegate>(funcTable, 16738120789012782745UL, VoiceChannel_DeleteMetaDataFallback);
            VoiceChannel_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<VoiceChannel_GetBaseObjectDelegate>(funcTable, 11734947529465976092UL, VoiceChannel_GetBaseObjectFallback);
            VoiceChannel_GetFilter = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<VoiceChannel_GetFilterDelegate>(funcTable, 15469042501608647536UL, VoiceChannel_GetFilterFallback);
            VoiceChannel_GetMaxDistance = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<VoiceChannel_GetMaxDistanceDelegate>(funcTable, 6192611943068059113UL, VoiceChannel_GetMaxDistanceFallback);
            VoiceChannel_GetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<VoiceChannel_GetMetaDataDelegate>(funcTable, 8356047581859527124UL, VoiceChannel_GetMetaDataFallback);
            VoiceChannel_GetPriority = (delegate* unmanaged[Cdecl]<nint, int>) GetUnmanagedPtr<VoiceChannel_GetPriorityDelegate>(funcTable, 13318600532201701611UL, VoiceChannel_GetPriorityFallback);
            VoiceChannel_HasMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<VoiceChannel_HasMetaDataDelegate>(funcTable, 16274950114573272151UL, VoiceChannel_HasMetaDataFallback);
            VoiceChannel_HasPlayer = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<VoiceChannel_HasPlayerDelegate>(funcTable, 5581422978656581114UL, VoiceChannel_HasPlayerFallback);
            VoiceChannel_IsPlayerMuted = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<VoiceChannel_IsPlayerMutedDelegate>(funcTable, 17699707908321743267UL, VoiceChannel_IsPlayerMutedFallback);
            VoiceChannel_IsSpatial = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<VoiceChannel_IsSpatialDelegate>(funcTable, 12897039523672598867UL, VoiceChannel_IsSpatialFallback);
            VoiceChannel_MutePlayer = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<VoiceChannel_MutePlayerDelegate>(funcTable, 13531299650637927664UL, VoiceChannel_MutePlayerFallback);
            VoiceChannel_RemovePlayer = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<VoiceChannel_RemovePlayerDelegate>(funcTable, 12004786576328264047UL, VoiceChannel_RemovePlayerFallback);
            VoiceChannel_SetFilter = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<VoiceChannel_SetFilterDelegate>(funcTable, 954659317800510615UL, VoiceChannel_SetFilterFallback);
            VoiceChannel_SetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<VoiceChannel_SetMetaDataDelegate>(funcTable, 15510848492294686387UL, VoiceChannel_SetMetaDataFallback);
            VoiceChannel_SetPriority = (delegate* unmanaged[Cdecl]<nint, int, void>) GetUnmanagedPtr<VoiceChannel_SetPriorityDelegate>(funcTable, 11160223830254443614UL, VoiceChannel_SetPriorityFallback);
            VoiceChannel_UnmutePlayer = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<VoiceChannel_UnmutePlayerDelegate>(funcTable, 10269140636860300589UL, VoiceChannel_UnmutePlayerFallback);
            WorldObject_GetPositionCoords = (delegate* unmanaged[Cdecl]<nint, float*, float*, float*, int*, void>) GetUnmanagedPtr<WorldObject_GetPositionCoordsDelegate>(funcTable, 16135129168754632706UL, WorldObject_GetPositionCoordsFallback);
            WorldObject_SetDimension = (delegate* unmanaged[Cdecl]<nint, int, void>) GetUnmanagedPtr<WorldObject_SetDimensionDelegate>(funcTable, 8281427375806201830UL, WorldObject_SetDimensionFallback);
        }
    }
}