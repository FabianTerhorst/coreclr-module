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
        public delegate* unmanaged[Cdecl]<nint, nint, void> Audio_AddOutput_Entity { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Audio_AddOutput_ScriptId { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Audio_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Audio_GetCategory { get; }
        public delegate* unmanaged[Cdecl]<nint, double> Audio_GetCurrentTime { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Audio_GetLooped { get; }
        public delegate* unmanaged[Cdecl]<nint, double> Audio_GetMaxTime { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, nint*, nint*, uint*, void> Audio_GetOutputs { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Audio_GetSource { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Audio_GetVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Audio_IsFrontendPlay { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Audio_IsPlaying { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Audio_Pause { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Audio_Play { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Audio_RemoveOutput_Entity { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Audio_RemoveOutput_ScriptId { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Audio_Reset { get; }
        public delegate* unmanaged[Cdecl]<nint, double, void> Audio_Seek { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Audio_SetCategory { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Audio_SetLooped { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Audio_SetSource { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Audio_SetVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Blip_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint, nint, void> Core_AddGXTText { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_AreGameControlsEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_AreRmlControlsEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_AreVoiceControlsEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_BeginScaleformMovieMethodMinimap { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_ClearFocusOverride { get; }
        public delegate* unmanaged[Cdecl]<nint, int, byte, void> Core_ClearPedProp { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint> Core_Client_CreateAreaBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_Client_CreatePointBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, nint> Core_Client_CreateRadiusBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, byte> Core_Client_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, int*, nint> Core_Client_FileRead { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_CopyToClipboard { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, float, uint, byte, nint> Core_CreateAudio { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Vector3, Vector3, float, float, Rgba, nint> Core_CreateCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateHttpClient { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, Vector3, Vector3, byte, byte, nint> Core_CreateObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint> Core_CreateRmlDocument { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint> Core_CreateWebsocketClient { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, Vector2, Vector2, byte, nint> Core_CreateWebView { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, uint, nint, nint> Core_CreateWebView3D { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocDiscordUser { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.DiscordOAuth2TokenResultModuleDelegate, void> Core_Discord_GetOAuth2Token { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_DoesConfigFlagExist { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Core_GetCamPos { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetClientPath { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_GetConfigFlag { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2*, byte, void> Core_GetCursorPos { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_GetDiscordUser { get; }
        public delegate* unmanaged[Cdecl]<nint, byte*, nint> Core_GetFocusOverrideEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Core_GetFocusOverrideOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Core_GetFocusOverridePos { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Core_GetFPS { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint, int*, nint> Core_GetGXTText { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, int*, nint> Core_GetHeadshotBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetLicenseHash { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetLocale { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetLocalMeta { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint*, nint> Core_GetMapZoomDataByAlias { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Core_GetMsPerGameMinute { get; }
        public delegate* unmanaged[Cdecl]<nint, uint*, nint> Core_GetObjects { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Core_GetPermissionState { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Core_GetPing { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2*, void> Core_GetScreenResolution { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetServerIp { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Core_GetServerPort { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_GetStatBool { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetStatData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, float> Core_GetStatFloat { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int> Core_GetStatInt { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, long> Core_GetStatLong { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint> Core_GetStatString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint> Core_GetStatType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ushort> Core_GetStatUInt16 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint> Core_GetStatUInt32 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ulong> Core_GetStatUInt64 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_GetStatUInt8 { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Core_GetTotalPacketsLost { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Core_GetTotalPacketsSent { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Core_GetVoiceActivationKey { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_GetVoiceInputMuted { get; }
        public delegate* unmanaged[Cdecl]<nint, uint*, nint> Core_GetWorldObjects { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasLocalMeta { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsCamFrozen { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsConsoleOpen { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_IsCursorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsFocusOverriden { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsGameFocused { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsInStreamerMode { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> Core_IsKeyDown { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> Core_IsKeyToggled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsMenuOpened { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, byte> Core_IsPointOnScreen { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint, byte> Core_IsTextureExistInArchetype { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsVoiceActivityInputEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_LoadDefaultIpls { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Core_LoadModel { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Core_LoadModelAsync { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, byte, byte, void> Core_LoadRmlFont { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_LoadYtyp { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_OverrideFocusEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, Vector3, void> Core_OverrideFocusPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint, void> Core_RemoveGXTText { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_RemoveIpl { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_RequestIpl { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_ResetAllMapZoomData { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Core_ResetMapZoomData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_ResetStat { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, Vector3*, void> Core_ScreenToWorld { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_SetCamFrozen { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Core_SetConfigFlag { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, byte, void> Core_SetCursorPos { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, byte, float, float, float, float, void> Core_SetMinimapComponentPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_SetMinimapIsRectangle { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> Core_SetMsPerGameMinute { get; }
        public delegate* unmanaged[Cdecl]<nint, int, uint, byte, byte, byte, byte, void> Core_SetPedDlcClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, int, uint, byte, byte, byte, void> Core_SetPedDlcProp { get; }
        public delegate* unmanaged[Cdecl]<nint, int, Vector3, void> Core_SetRotationVelocity { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Core_SetStatBool { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, float, void> Core_SetStatFloat { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int, void> Core_SetStatInt { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, long, void> Core_SetStatLong { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Core_SetStatString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ushort, void> Core_SetStatUInt16 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint, void> Core_SetStatUInt32 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ulong, void> Core_SetStatUInt64 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Core_SetStatUInt8 { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_SetVoiceInputMuted { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_SetWatermarkPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, byte[], int, byte[], int, void> Core_SetWeatherCycle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_SetWeatherSyncActive { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, bool, void> Core_ShowCursor { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint> Core_StringToSHA256 { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ScreenshotResultModuleDelegate, byte> Core_TakeScreenshot { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ScreenshotResultModuleDelegate, byte> Core_TakeScreenshotGameOnly { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Core_ToggleGameControls { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_ToggleRmlControls { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_ToggleVoiceControls { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerServerEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void> Core_TriggerWebViewEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_UnloadYtyp { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, Vector2*, void> Core_WorldToScreen { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Entity_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceErrorModuleDelegate, void> Event_SetAnyResourceErrorDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceStartModuleDelegate, void> Event_SetAnyResourceStartDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceStopModuleDelegate, void> Event_SetAnyResourceStopDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ClientEventModuleDelegate, void> Event_SetClientEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ConnectionCompleteModuleDelegate, void> Event_SetConnectionCompleteDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ConsoleCommandModuleDelegate, void> Event_SetConsoleCommandDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateAudioModuleDelegate, void> Event_SetCreateAudioDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateBlipModuleDelegate, void> Event_SetCreateBlipDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateCheckpointModuleDelegate, void> Event_SetCreateCheckpointDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateHttpClientModuleDelegate, void> Event_SetCreateHttpClientDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateObjectModuleDelegate, void> Event_SetCreateObjectDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreatePlayerModuleDelegate, void> Event_SetCreatePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateRmlDocumentModuleDelegate, void> Event_SetCreateRmlDocumentDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateRmlElementModuleDelegate, void> Event_SetCreateRmlElementDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateVehicleModuleDelegate, void> Event_SetCreateVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateWebSocketClientModuleDelegate, void> Event_SetCreateWebSocketClientDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateWebViewModuleDelegate, void> Event_SetCreateWebViewDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityCreateModuleDelegate, void> Event_SetGameEntityCreateDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityDestroyModuleDelegate, void> Event_SetGameEntityDestroyDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalMetaChangeModuleDelegate, void> Event_SetGlobalMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalSyncedMetaChangeModuleDelegate, void> Event_SetGlobalSyncedMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void> Event_SetKeyDownDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void> Event_SetKeyUpDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.LocalMetaChangeModuleDelegate, void> Event_SetLocalMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.NetOwnerChangeModuleDelegate, void> Event_SetNetOwnerChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeAnimationModuleDelegate, void> Event_SetPlayerChangeAnimationDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeInteriorModuleDelegate, void> Event_SetPlayerChangeInteriorDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeVehicleSeatModuleDelegate, void> Event_SetPlayerChangeVehicleSeatDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerDisconnectModuleDelegate, void> Event_SetPlayerDisconnectDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerEnterVehicleModuleDelegate, void> Event_SetPlayerEnterVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerLeaveVehicleModuleDelegate, void> Event_SetPlayerLeaveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerSpawnModuleDelegate, void> Event_SetPlayerSpawnDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerWeaponChangeModuleDelegate, void> Event_SetPlayerWeaponChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerWeaponShootModuleDelegate, void> Event_SetPlayerWeaponShootDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveAudioModuleDelegate, void> Event_SetRemoveAudioDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveBlipModuleDelegate, void> Event_SetRemoveBlipDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveCheckpointModuleDelegate, void> Event_SetRemoveCheckpointDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveEntityModuleDelegate, void> Event_SetRemoveEntityDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveHttpClientModuleDelegate, void> Event_SetRemoveHttpClientDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveObjectModuleDelegate, void> Event_SetRemoveObjectDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemovePlayerModuleDelegate, void> Event_SetRemovePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveRmlDocumentModuleDelegate, void> Event_SetRemoveRmlDocumentDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveRmlElementModuleDelegate, void> Event_SetRemoveRmlElementDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveVehicleModuleDelegate, void> Event_SetRemoveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveWebSocketClientModuleDelegate, void> Event_SetRemoveWebSocketClientDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveWebViewModuleDelegate, void> Event_SetRemoveWebViewDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RmlEventModuleDelegate, void> Event_SetRmlEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ServerEventModuleDelegate, void> Event_SetServerEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.StreamSyncedMetaChangeModuleDelegate, void> Event_SetStreamSyncedMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.SyncedMetaChangeModuleDelegate, void> Event_SetSyncedMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.TaskChangeModuleDelegate, void> Event_SetTaskChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.TickModuleDelegate, void> Event_SetTickDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WeaponDamageModuleDelegate, void> Event_SetWeaponDamageDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WebSocketEventModuleDelegate, void> Event_SetWebSocketEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WebViewEventModuleDelegate, void> Event_SetWebViewEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WindowFocusChangeModuleDelegate, void> Event_SetWindowFocusChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WindowResolutionChangeModuleDelegate, void> Event_SetWindowResolutionChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeRmlElementArray { get; }
        public delegate* unmanaged[Cdecl]<nint> GetNativeFuncTable { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetAcceleration { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetAntiRollBarBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetAntiRollBarBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetAntiRollBarForce { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetBrakeBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetBrakeBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetCamberStiffness { get; }
        public delegate* unmanaged[Cdecl]<uint, Vector3*, void> Handling_GetCentreOfMassOffset { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetClutchChangeRateScaleDownShift { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetClutchChangeRateScaleUpShift { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetCollisionDamageMult { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> Handling_GetDamageFlags { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetDeformationDamageMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetDownforceModifier { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetDriveBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetDriveInertia { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetEngineDamageMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetHandBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> Handling_GetHandlingFlags { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> Handling_GetHandlingNameHash { get; }
        public delegate* unmanaged[Cdecl]<uint, Vector3*, void> Handling_GetInertiaMultiplier { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetInitialDragCoeff { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetInitialDriveForce { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> Handling_GetInitialDriveGears { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetInitialDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetLowSpeedTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetMass { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> Handling_GetModelFlags { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> Handling_GetMonetaryValue { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetOilVolume { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetPercentSubmerged { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetPercentSubmergedRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetPetrolTankVolume { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetRollCentreHeightFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetRollCentreHeightRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSeatOffsetDistX { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSeatOffsetDistY { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSeatOffsetDistZ { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSteeringLock { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSteeringLockRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionCompDamp { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionForce { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionLowerLimit { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionRaise { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionReboundDamp { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionUpperLimit { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionCurveLateral { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionCurveLateralRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionCurveMax { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionCurveMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionCurveMin { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionCurveMinRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionSpringDeltaMax { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionSpringDeltaMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetunkFloat1 { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetunkFloat2 { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetunkFloat4 { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetunkFloat5 { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetWeaponDamageMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetAcceleration { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetAntiRollBarBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetAntiRollBarBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetAntiRollBarForce { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetBrakeBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetBrakeBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetCamberStiffness { get; }
        public delegate* unmanaged[Cdecl]<uint, Vector3, void> Handling_SetCentreOfMassOffset { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetClutchChangeRateScaleDownShift { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetClutchChangeRateScaleUpShift { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetCollisionDamageMult { get; }
        public delegate* unmanaged[Cdecl]<uint, uint, void> Handling_SetDamageFlags { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetDeformationDamageMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetDownforceModifier { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetDriveBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetDriveInertia { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetEngineDamageMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetHandBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<uint, uint, void> Handling_SetHandlingFlags { get; }
        public delegate* unmanaged[Cdecl]<uint, Vector3, void> Handling_SetInertiaMultiplier { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetInitialDragCoeff { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetInitialDriveForce { get; }
        public delegate* unmanaged[Cdecl]<uint, uint, void> Handling_SetInitialDriveGears { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetInitialDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetLowSpeedTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetMass { get; }
        public delegate* unmanaged[Cdecl]<uint, uint, void> Handling_SetModelFlags { get; }
        public delegate* unmanaged[Cdecl]<uint, uint, void> Handling_SetMonetaryValue { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetOilVolume { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetPercentSubmerged { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetPercentSubmergedRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetPetrolTankVolume { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetRollCentreHeightFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetRollCentreHeightRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSeatOffsetDistX { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSeatOffsetDistY { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSeatOffsetDistZ { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSteeringLock { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSteeringLockRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionCompDamp { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionForce { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionLowerLimit { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionRaise { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionReboundDamp { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionUpperLimit { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionCurveLateral { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionCurveLateralRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionCurveMax { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionCurveMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionCurveMin { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionCurveMinRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionSpringDeltaMax { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionSpringDeltaMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetunkFloat1 { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetunkFloat2 { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetunkFloat4 { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetunkFloat5 { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetWeaponDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Connect { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Get { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> HttpClient_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, nint*, int*, void> HttpClient_GetExtraHeaders { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Head { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Options { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Patch { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Post { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Put { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> HttpClient_SetExtraHeader { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Trace { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetCurrentAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalPlayer_GetCurrentWeaponHash { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, ushort> LocalPlayer_GetWeaponAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint*, uint*, void> LocalPlayer_GetWeaponComponents { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, uint*, void> LocalPlayer_GetWeapons { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> LocalPlayer_HasWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Clear { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> LocalStorage_DeleteKey { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> LocalStorage_GetKey { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Save { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> LocalStorage_SetKey { get; }
        public delegate* unmanaged[Cdecl]<uint, float> MapData_GetFScrollSpeed { get; }
        public delegate* unmanaged[Cdecl]<uint, float> MapData_GetFZoomScale { get; }
        public delegate* unmanaged[Cdecl]<uint, float> MapData_GetFZoomSpeed { get; }
        public delegate* unmanaged[Cdecl]<uint, float> MapData_GetVTilesX { get; }
        public delegate* unmanaged[Cdecl]<uint, float> MapData_GetVTilesY { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> MapData_SetFScrollSpeed { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> MapData_SetFZoomScale { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> MapData_SetFZoomSpeed { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> MapData_SetVTilesX { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> MapData_SetVTilesY { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint> Player_GetLocal { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMicLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsTalking { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, bool> Resource_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint*, void> Resource_GetFile { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetLocalStorage { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> RmlDocument_CreateElement { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> RmlDocument_CreateTextNode { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> RmlDocument_GetBody { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> RmlDocument_GetRmlElement { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> RmlDocument_GetSourceUrl { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> RmlDocument_GetTitle { get; }
        public delegate* unmanaged[Cdecl]<nint, void> RmlDocument_Hide { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> RmlDocument_IsModal { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> RmlDocument_IsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> RmlDocument_SetTitle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> RmlDocument_Show { get; }
        public delegate* unmanaged[Cdecl]<nint, void> RmlDocument_Update { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void> RmlElement_AddClass { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void> RmlElement_AddPseudoClass { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> RmlElement_AppendChild { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void> RmlElement_Blur { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void> RmlElement_Click { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void> RmlElement_Focus { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetAbsoluteLeft { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void> RmlElement_GetAbsoluteOffset { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetAbsoluteTop { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint> RmlElement_GetAttribute { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, nint*, uint*, void> RmlElement_GetAttributes { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetBaseline { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, uint> RmlElement_GetChildCount { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void> RmlElement_GetChildNodes { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void> RmlElement_GetClassList { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetClientHeight { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetClientLeft { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetClientTop { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetClientWidth { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint> RmlElement_GetClosest { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void> RmlElement_GetContainingBlock { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint> RmlElement_GetElementById { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void> RmlElement_GetElementsByClassName { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void> RmlElement_GetElementsByTagName { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetFirstChild { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetFocusedElement { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint> RmlElement_GetId { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint> RmlElement_GetInnerRml { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetLastChild { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint> RmlElement_GetLocalProperty { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetNextSibling { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetOffsetHeight { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetOffsetLeft { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetOffsetTop { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetOffsetWidth { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetOwnerDocument { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetParent { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetPreviousSibling { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint> RmlElement_GetProperty { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, float> RmlElement_GetPropertyAbsoluteValue { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void> RmlElement_GetPseudoClassList { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void> RmlElement_GetRelativeOffset { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetScrollHeight { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetScrollLeft { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetScrollTop { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetScrollWidth { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint> RmlElement_GetTagName { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetZIndex { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_HasAttribute { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte> RmlElement_HasChildren { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_HasClass { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_HasLocalProperty { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_HasProperty { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_HasPseudoClass { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> RmlElement_InsertBefore { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte> RmlElement_IsOwned { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2, byte> RmlElement_IsPointWithinElement { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte> RmlElement_IsVisible { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint> RmlElement_QuerySelector { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void> RmlElement_QuerySelectorAll { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_RemoveAttribute { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> RmlElement_RemoveChild { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_RemoveClass { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> RmlElement_RemoveProperty { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_RemovePseudoClass { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> RmlElement_ReplaceChild { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte, void> RmlElement_ScrollIntoView { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint, void> RmlElement_SetAttribute { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void> RmlElement_SetId { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> RmlElement_SetInnerRml { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, Vector2, byte, void> RmlElement_SetOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> RmlElement_SetProperty { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float, void> RmlElement_SetScrollLeft { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float, void> RmlElement_SetScrollTop { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetAbsLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetBatteryLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetEngineLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetEngineTemperature { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetFuelLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetOilLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetOilLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetPetrolLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetRPM { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSeatCount { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_GetSpeedVector { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetWheelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, uint> Vehicle_GetWheelSurfaceMaterial { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAcceleration { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetCamberStiffness { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_Handling_GetCentreOfMassOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetClutchChangeRateScaleDownShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetClutchChangeRateScaleUpShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetCollisionDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetDamageFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDeformationDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDownforceModifier { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDriveBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDriveInertia { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetEngineDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetHandBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetHandlingFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetHandlingNameHash { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_Handling_GetInertiaMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetInitialDragCoeff { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetInitialDriveForce { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetInitialDriveGears { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetInitialDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetLowSpeedTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetMass { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetModelFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetMonetaryValue { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetOilVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetPercentSubmerged { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetPercentSubmergedRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetPetrolTankVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetRollCentreHeightFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetRollCentreHeightRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSeatOffsetDistX { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSeatOffsetDistY { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSeatOffsetDistZ { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSteeringLock { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSteeringLockRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionCompDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionLowerLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionRaise { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionReboundDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionUpperLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveLateral { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveLateralRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMin { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMinRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionSpringDeltaMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionSpringDeltaMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat1 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat2 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat4 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat5 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetWeaponDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAcceleration { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAntiRollBarBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAntiRollBarBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAntiRollBarForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetBrakeBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetBrakeBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetCamberStiffness { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Vehicle_Handling_SetCentreOfMassOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetClutchChangeRateScaleDownShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetClutchChangeRateScaleUpShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetCollisionDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetDamageFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDeformationDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDownforceModifier { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDriveBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDriveInertia { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetEngineDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetHandBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetHandlingFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Vehicle_Handling_SetInertiaMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetInitialDragCoeff { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetInitialDriveForce { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetInitialDriveGears { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetInitialDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetLowSpeedTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetMass { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetModelFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetMonetaryValue { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetOilVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetPercentSubmerged { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetPercentSubmergedRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetPetrolTankVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetRollCentreHeightFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetRollCentreHeightRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSeatOffsetDistX { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSeatOffsetDistY { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSeatOffsetDistZ { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSteeringLock { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSteeringLockRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionCompDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionLowerLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionRaise { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionReboundDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionUpperLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveLateral { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveLateralRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMin { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMinRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionSpringDeltaMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionSpringDeltaMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat1 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat2 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat4 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat5 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetWeaponDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsHandlingModified { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ResetDashboardLights { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ResetHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetAbsLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetBatteryLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetEngineLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetEngineTemperature { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetFuelLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetOilLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetOilLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetPetrolLightState { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetAccuracySpread { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetAnimReloadRate { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> WeaponData_GetClipSize { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetDamage { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetHeadshotDamageModifier { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetLockOnRange { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> WeaponData_GetModelHash { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> WeaponData_GetNameHash { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetPlayerDamageModifier { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetRange { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetRecoilAccuracyMax { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetRecoilAccuracyToAllowHeadshotPlayer { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetRecoilRecoveryRate { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetRecoilShakeAmplitude { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetTimeBetweenShots { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetVehicleReloadTime { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetAccuracySpread { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetAnimReloadRate { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetDamage { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetHeadshotDamageModifier { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetLockOnRange { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetPlayerDamageModifier { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetRange { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetRecoilAccuracyMax { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetRecoilAccuracyToAllowHeadshotPlayer { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetRecoilRecoveryRate { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetRecoilShakeAmplitude { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetVehicleReloadTime { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> WebSocketClient_AddSubProtocol { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> WebSocketClient_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> WebSocketClient_GetPingInterval { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> WebSocketClient_GetReadyState { get; }
        public delegate* unmanaged[Cdecl]<nint, uint*, nint> WebSocketClient_GetSubProtocols { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> WebSocketClient_GetUrl { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> WebSocketClient_IsAutoReconnect { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> WebSocketClient_IsPerMessageDeflate { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint, byte> WebSocketClient_Send_Binary { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> WebSocketClient_Send_String { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> WebSocketClient_SetAutoReconnect { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> WebSocketClient_SetExtraHeader { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> WebSocketClient_SetPerMessageDeflate { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> WebSocketClient_SetPingInterval { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> WebSocketClient_SetUrl { get; }
        public delegate* unmanaged[Cdecl]<nint, void> WebSocketClient_Start { get; }
        public delegate* unmanaged[Cdecl]<nint, void> WebSocketClient_Stop { get; }
        public delegate* unmanaged[Cdecl]<nint, void> WebView_Focus { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> WebView_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2*, void> WebView_GetPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2*, void> WebView_GetSize { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> WebView_GetUrl { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> WebView_IsFocused { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> WebView_IsOverlay { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> WebView_IsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> WebView_SetExtraHeader { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> WebView_SetIsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, void> WebView_SetPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, void> WebView_SetSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> WebView_SetUrl { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> WebView_SetZoomLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, void> WebView_Unfocus { get; }
        public delegate* unmanaged[Cdecl]<nint> Win_GetTaskDialog { get; }
    }

    public unsafe class ClientLibrary : IClientLibrary
    {
        public readonly uint Methods = 1307;
        public delegate* unmanaged[Cdecl]<nint, nint, void> Audio_AddOutput_Entity { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Audio_AddOutput_ScriptId { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Audio_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Audio_GetCategory { get; }
        public delegate* unmanaged[Cdecl]<nint, double> Audio_GetCurrentTime { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Audio_GetLooped { get; }
        public delegate* unmanaged[Cdecl]<nint, double> Audio_GetMaxTime { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, nint*, nint*, uint*, void> Audio_GetOutputs { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Audio_GetSource { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Audio_GetVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Audio_IsFrontendPlay { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Audio_IsPlaying { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Audio_Pause { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Audio_Play { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Audio_RemoveOutput_Entity { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Audio_RemoveOutput_ScriptId { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Audio_Reset { get; }
        public delegate* unmanaged[Cdecl]<nint, double, void> Audio_Seek { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Audio_SetCategory { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Audio_SetLooped { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Audio_SetSource { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Audio_SetVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Blip_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint, nint, void> Core_AddGXTText { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_AreGameControlsEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_AreRmlControlsEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_AreVoiceControlsEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_BeginScaleformMovieMethodMinimap { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_ClearFocusOverride { get; }
        public delegate* unmanaged[Cdecl]<nint, int, byte, void> Core_ClearPedProp { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint> Core_Client_CreateAreaBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_Client_CreatePointBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, nint> Core_Client_CreateRadiusBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, byte> Core_Client_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, int*, nint> Core_Client_FileRead { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_CopyToClipboard { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, float, uint, byte, nint> Core_CreateAudio { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Vector3, Vector3, float, float, Rgba, nint> Core_CreateCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateHttpClient { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, Vector3, Vector3, byte, byte, nint> Core_CreateObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint> Core_CreateRmlDocument { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint> Core_CreateWebsocketClient { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, Vector2, Vector2, byte, nint> Core_CreateWebView { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, uint, nint, nint> Core_CreateWebView3D { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocDiscordUser { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.DiscordOAuth2TokenResultModuleDelegate, void> Core_Discord_GetOAuth2Token { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_DoesConfigFlagExist { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Core_GetCamPos { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetClientPath { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_GetConfigFlag { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2*, byte, void> Core_GetCursorPos { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_GetDiscordUser { get; }
        public delegate* unmanaged[Cdecl]<nint, byte*, nint> Core_GetFocusOverrideEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Core_GetFocusOverrideOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Core_GetFocusOverridePos { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Core_GetFPS { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint, int*, nint> Core_GetGXTText { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, int*, nint> Core_GetHeadshotBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetLicenseHash { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetLocale { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetLocalMeta { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint*, nint> Core_GetMapZoomDataByAlias { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Core_GetMsPerGameMinute { get; }
        public delegate* unmanaged[Cdecl]<nint, uint*, nint> Core_GetObjects { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte> Core_GetPermissionState { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Core_GetPing { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2*, void> Core_GetScreenResolution { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetServerIp { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Core_GetServerPort { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_GetStatBool { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetStatData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, float> Core_GetStatFloat { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int> Core_GetStatInt { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, long> Core_GetStatLong { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint> Core_GetStatString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint> Core_GetStatType { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ushort> Core_GetStatUInt16 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint> Core_GetStatUInt32 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ulong> Core_GetStatUInt64 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_GetStatUInt8 { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Core_GetTotalPacketsLost { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Core_GetTotalPacketsSent { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Core_GetVoiceActivationKey { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_GetVoiceInputMuted { get; }
        public delegate* unmanaged[Cdecl]<nint, uint*, nint> Core_GetWorldObjects { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasLocalMeta { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsCamFrozen { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsConsoleOpen { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_IsCursorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsFocusOverriden { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsGameFocused { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsInStreamerMode { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> Core_IsKeyDown { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> Core_IsKeyToggled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsMenuOpened { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, byte> Core_IsPointOnScreen { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint, byte> Core_IsTextureExistInArchetype { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsVoiceActivityInputEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_LoadDefaultIpls { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Core_LoadModel { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Core_LoadModelAsync { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, byte, byte, void> Core_LoadRmlFont { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_LoadYtyp { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_OverrideFocusEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, Vector3, void> Core_OverrideFocusPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint, void> Core_RemoveGXTText { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_RemoveIpl { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_RequestIpl { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_ResetAllMapZoomData { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Core_ResetMapZoomData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> Core_ResetStat { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, Vector3*, void> Core_ScreenToWorld { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_SetCamFrozen { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Core_SetConfigFlag { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, byte, void> Core_SetCursorPos { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, byte, float, float, float, float, void> Core_SetMinimapComponentPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_SetMinimapIsRectangle { get; }
        public delegate* unmanaged[Cdecl]<nint, int, void> Core_SetMsPerGameMinute { get; }
        public delegate* unmanaged[Cdecl]<nint, int, uint, byte, byte, byte, byte, void> Core_SetPedDlcClothes { get; }
        public delegate* unmanaged[Cdecl]<nint, int, uint, byte, byte, byte, void> Core_SetPedDlcProp { get; }
        public delegate* unmanaged[Cdecl]<nint, int, Vector3, void> Core_SetRotationVelocity { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Core_SetStatBool { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, float, void> Core_SetStatFloat { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int, void> Core_SetStatInt { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, long, void> Core_SetStatLong { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> Core_SetStatString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ushort, void> Core_SetStatUInt16 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint, void> Core_SetStatUInt32 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ulong, void> Core_SetStatUInt64 { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Core_SetStatUInt8 { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_SetVoiceInputMuted { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_SetWatermarkPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, byte[], int, byte[], int, void> Core_SetWeatherCycle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_SetWeatherSyncActive { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, bool, void> Core_ShowCursor { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint> Core_StringToSHA256 { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ScreenshotResultModuleDelegate, byte> Core_TakeScreenshot { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ScreenshotResultModuleDelegate, byte> Core_TakeScreenshotGameOnly { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte, void> Core_ToggleGameControls { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_ToggleRmlControls { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_ToggleVoiceControls { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerServerEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void> Core_TriggerWebViewEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_UnloadYtyp { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, Vector2*, void> Core_WorldToScreen { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Entity_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceErrorModuleDelegate, void> Event_SetAnyResourceErrorDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceStartModuleDelegate, void> Event_SetAnyResourceStartDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceStopModuleDelegate, void> Event_SetAnyResourceStopDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ClientEventModuleDelegate, void> Event_SetClientEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ConnectionCompleteModuleDelegate, void> Event_SetConnectionCompleteDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ConsoleCommandModuleDelegate, void> Event_SetConsoleCommandDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateAudioModuleDelegate, void> Event_SetCreateAudioDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateBlipModuleDelegate, void> Event_SetCreateBlipDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateCheckpointModuleDelegate, void> Event_SetCreateCheckpointDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateHttpClientModuleDelegate, void> Event_SetCreateHttpClientDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateObjectModuleDelegate, void> Event_SetCreateObjectDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreatePlayerModuleDelegate, void> Event_SetCreatePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateRmlDocumentModuleDelegate, void> Event_SetCreateRmlDocumentDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateRmlElementModuleDelegate, void> Event_SetCreateRmlElementDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateVehicleModuleDelegate, void> Event_SetCreateVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateWebSocketClientModuleDelegate, void> Event_SetCreateWebSocketClientDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateWebViewModuleDelegate, void> Event_SetCreateWebViewDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityCreateModuleDelegate, void> Event_SetGameEntityCreateDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityDestroyModuleDelegate, void> Event_SetGameEntityDestroyDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalMetaChangeModuleDelegate, void> Event_SetGlobalMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalSyncedMetaChangeModuleDelegate, void> Event_SetGlobalSyncedMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void> Event_SetKeyDownDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void> Event_SetKeyUpDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.LocalMetaChangeModuleDelegate, void> Event_SetLocalMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.NetOwnerChangeModuleDelegate, void> Event_SetNetOwnerChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeAnimationModuleDelegate, void> Event_SetPlayerChangeAnimationDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeInteriorModuleDelegate, void> Event_SetPlayerChangeInteriorDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeVehicleSeatModuleDelegate, void> Event_SetPlayerChangeVehicleSeatDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerDisconnectModuleDelegate, void> Event_SetPlayerDisconnectDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerEnterVehicleModuleDelegate, void> Event_SetPlayerEnterVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerLeaveVehicleModuleDelegate, void> Event_SetPlayerLeaveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerSpawnModuleDelegate, void> Event_SetPlayerSpawnDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerWeaponChangeModuleDelegate, void> Event_SetPlayerWeaponChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerWeaponShootModuleDelegate, void> Event_SetPlayerWeaponShootDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveAudioModuleDelegate, void> Event_SetRemoveAudioDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveBlipModuleDelegate, void> Event_SetRemoveBlipDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveCheckpointModuleDelegate, void> Event_SetRemoveCheckpointDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveEntityModuleDelegate, void> Event_SetRemoveEntityDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveHttpClientModuleDelegate, void> Event_SetRemoveHttpClientDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveObjectModuleDelegate, void> Event_SetRemoveObjectDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemovePlayerModuleDelegate, void> Event_SetRemovePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveRmlDocumentModuleDelegate, void> Event_SetRemoveRmlDocumentDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveRmlElementModuleDelegate, void> Event_SetRemoveRmlElementDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveVehicleModuleDelegate, void> Event_SetRemoveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveWebSocketClientModuleDelegate, void> Event_SetRemoveWebSocketClientDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveWebViewModuleDelegate, void> Event_SetRemoveWebViewDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RmlEventModuleDelegate, void> Event_SetRmlEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ServerEventModuleDelegate, void> Event_SetServerEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.StreamSyncedMetaChangeModuleDelegate, void> Event_SetStreamSyncedMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.SyncedMetaChangeModuleDelegate, void> Event_SetSyncedMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.TaskChangeModuleDelegate, void> Event_SetTaskChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.TickModuleDelegate, void> Event_SetTickDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WeaponDamageModuleDelegate, void> Event_SetWeaponDamageDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WebSocketEventModuleDelegate, void> Event_SetWebSocketEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WebViewEventModuleDelegate, void> Event_SetWebViewEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WindowFocusChangeModuleDelegate, void> Event_SetWindowFocusChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WindowResolutionChangeModuleDelegate, void> Event_SetWindowResolutionChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeRmlElementArray { get; }
        public delegate* unmanaged[Cdecl]<nint> GetNativeFuncTable { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetAcceleration { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetAntiRollBarBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetAntiRollBarBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetAntiRollBarForce { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetBrakeBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetBrakeBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetCamberStiffness { get; }
        public delegate* unmanaged[Cdecl]<uint, Vector3*, void> Handling_GetCentreOfMassOffset { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetClutchChangeRateScaleDownShift { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetClutchChangeRateScaleUpShift { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetCollisionDamageMult { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> Handling_GetDamageFlags { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetDeformationDamageMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetDownforceModifier { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetDriveBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetDriveInertia { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetEngineDamageMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetHandBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> Handling_GetHandlingFlags { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> Handling_GetHandlingNameHash { get; }
        public delegate* unmanaged[Cdecl]<uint, Vector3*, void> Handling_GetInertiaMultiplier { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetInitialDragCoeff { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetInitialDriveForce { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> Handling_GetInitialDriveGears { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetInitialDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetLowSpeedTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetMass { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> Handling_GetModelFlags { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> Handling_GetMonetaryValue { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetOilVolume { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetPercentSubmerged { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetPercentSubmergedRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetPetrolTankVolume { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetRollCentreHeightFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetRollCentreHeightRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSeatOffsetDistX { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSeatOffsetDistY { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSeatOffsetDistZ { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSteeringLock { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSteeringLockRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionCompDamp { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionForce { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionLowerLimit { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionRaise { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionReboundDamp { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetSuspensionUpperLimit { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionCurveLateral { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionCurveLateralRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionCurveMax { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionCurveMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionCurveMin { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionCurveMinRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionSpringDeltaMax { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetTractionSpringDeltaMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetunkFloat1 { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetunkFloat2 { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetunkFloat4 { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetunkFloat5 { get; }
        public delegate* unmanaged[Cdecl]<uint, float> Handling_GetWeaponDamageMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetAcceleration { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetAntiRollBarBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetAntiRollBarBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetAntiRollBarForce { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetBrakeBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetBrakeBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetCamberStiffness { get; }
        public delegate* unmanaged[Cdecl]<uint, Vector3, void> Handling_SetCentreOfMassOffset { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetClutchChangeRateScaleDownShift { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetClutchChangeRateScaleUpShift { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetCollisionDamageMult { get; }
        public delegate* unmanaged[Cdecl]<uint, uint, void> Handling_SetDamageFlags { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetDeformationDamageMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetDownforceModifier { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetDriveBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetDriveInertia { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetEngineDamageMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetHandBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<uint, uint, void> Handling_SetHandlingFlags { get; }
        public delegate* unmanaged[Cdecl]<uint, Vector3, void> Handling_SetInertiaMultiplier { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetInitialDragCoeff { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetInitialDriveForce { get; }
        public delegate* unmanaged[Cdecl]<uint, uint, void> Handling_SetInitialDriveGears { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetInitialDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetLowSpeedTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetMass { get; }
        public delegate* unmanaged[Cdecl]<uint, uint, void> Handling_SetModelFlags { get; }
        public delegate* unmanaged[Cdecl]<uint, uint, void> Handling_SetMonetaryValue { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetOilVolume { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetPercentSubmerged { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetPercentSubmergedRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetPetrolTankVolume { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetRollCentreHeightFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetRollCentreHeightRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSeatOffsetDistX { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSeatOffsetDistY { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSeatOffsetDistZ { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSteeringLock { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSteeringLockRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionCompDamp { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionForce { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionLowerLimit { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionRaise { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionReboundDamp { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetSuspensionUpperLimit { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionCurveLateral { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionCurveLateralRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionCurveMax { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionCurveMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionCurveMin { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionCurveMinRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionSpringDeltaMax { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetTractionSpringDeltaMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetunkFloat1 { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetunkFloat2 { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetunkFloat4 { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetunkFloat5 { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> Handling_SetWeaponDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Connect { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Get { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> HttpClient_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, nint*, int*, void> HttpClient_GetExtraHeaders { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Head { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Options { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Patch { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Post { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Put { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> HttpClient_SetExtraHeader { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void> HttpClient_Trace { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetCurrentAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalPlayer_GetCurrentWeaponHash { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, ushort> LocalPlayer_GetWeaponAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint*, uint*, void> LocalPlayer_GetWeaponComponents { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, uint*, void> LocalPlayer_GetWeapons { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> LocalPlayer_HasWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Clear { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> LocalStorage_DeleteKey { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> LocalStorage_GetKey { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Save { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> LocalStorage_SetKey { get; }
        public delegate* unmanaged[Cdecl]<uint, float> MapData_GetFScrollSpeed { get; }
        public delegate* unmanaged[Cdecl]<uint, float> MapData_GetFZoomScale { get; }
        public delegate* unmanaged[Cdecl]<uint, float> MapData_GetFZoomSpeed { get; }
        public delegate* unmanaged[Cdecl]<uint, float> MapData_GetVTilesX { get; }
        public delegate* unmanaged[Cdecl]<uint, float> MapData_GetVTilesY { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> MapData_SetFScrollSpeed { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> MapData_SetFZoomScale { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> MapData_SetFZoomSpeed { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> MapData_SetVTilesX { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> MapData_SetVTilesY { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint> Player_GetLocal { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMicLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsTalking { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, bool> Resource_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint*, void> Resource_GetFile { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetLocalStorage { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> RmlDocument_CreateElement { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> RmlDocument_CreateTextNode { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> RmlDocument_GetBody { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> RmlDocument_GetRmlElement { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> RmlDocument_GetSourceUrl { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> RmlDocument_GetTitle { get; }
        public delegate* unmanaged[Cdecl]<nint, void> RmlDocument_Hide { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> RmlDocument_IsModal { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> RmlDocument_IsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> RmlDocument_SetTitle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, byte, void> RmlDocument_Show { get; }
        public delegate* unmanaged[Cdecl]<nint, void> RmlDocument_Update { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void> RmlElement_AddClass { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void> RmlElement_AddPseudoClass { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> RmlElement_AppendChild { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void> RmlElement_Blur { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void> RmlElement_Click { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void> RmlElement_Focus { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetAbsoluteLeft { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void> RmlElement_GetAbsoluteOffset { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetAbsoluteTop { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint> RmlElement_GetAttribute { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, nint*, uint*, void> RmlElement_GetAttributes { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetBaseline { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, uint> RmlElement_GetChildCount { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void> RmlElement_GetChildNodes { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void> RmlElement_GetClassList { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetClientHeight { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetClientLeft { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetClientTop { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetClientWidth { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint> RmlElement_GetClosest { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void> RmlElement_GetContainingBlock { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint> RmlElement_GetElementById { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void> RmlElement_GetElementsByClassName { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void> RmlElement_GetElementsByTagName { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetFirstChild { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetFocusedElement { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint> RmlElement_GetId { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint> RmlElement_GetInnerRml { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetLastChild { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint> RmlElement_GetLocalProperty { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetNextSibling { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetOffsetHeight { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetOffsetLeft { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetOffsetTop { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetOffsetWidth { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetOwnerDocument { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetParent { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint> RmlElement_GetPreviousSibling { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint> RmlElement_GetProperty { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, float> RmlElement_GetPropertyAbsoluteValue { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void> RmlElement_GetPseudoClassList { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void> RmlElement_GetRelativeOffset { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetScrollHeight { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetScrollLeft { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetScrollTop { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetScrollWidth { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint> RmlElement_GetTagName { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float> RmlElement_GetZIndex { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_HasAttribute { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte> RmlElement_HasChildren { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_HasClass { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_HasLocalProperty { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_HasProperty { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_HasPseudoClass { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> RmlElement_InsertBefore { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte> RmlElement_IsOwned { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2, byte> RmlElement_IsPointWithinElement { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte> RmlElement_IsVisible { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint> RmlElement_QuerySelector { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void> RmlElement_QuerySelectorAll { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_RemoveAttribute { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> RmlElement_RemoveChild { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_RemoveClass { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> RmlElement_RemoveProperty { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte> RmlElement_RemovePseudoClass { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> RmlElement_ReplaceChild { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte, void> RmlElement_ScrollIntoView { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint, void> RmlElement_SetAttribute { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void> RmlElement_SetId { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> RmlElement_SetInnerRml { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, Vector2, byte, void> RmlElement_SetOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> RmlElement_SetProperty { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float, void> RmlElement_SetScrollLeft { get; }
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float, void> RmlElement_SetScrollTop { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetAbsLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetBatteryLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetEngineLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetEngineTemperature { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetFuelLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetOilLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetOilLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetPetrolLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetRPM { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSeatCount { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_GetSpeedVector { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetWheelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, uint> Vehicle_GetWheelSurfaceMaterial { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAcceleration { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetCamberStiffness { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_Handling_GetCentreOfMassOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetClutchChangeRateScaleDownShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetClutchChangeRateScaleUpShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetCollisionDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetDamageFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDeformationDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDownforceModifier { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDriveBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDriveInertia { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetEngineDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetHandBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetHandlingFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetHandlingNameHash { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_Handling_GetInertiaMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetInitialDragCoeff { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetInitialDriveForce { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetInitialDriveGears { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetInitialDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetLowSpeedTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetMass { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetModelFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetMonetaryValue { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetOilVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetPercentSubmerged { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetPercentSubmergedRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetPetrolTankVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetRollCentreHeightFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetRollCentreHeightRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSeatOffsetDistX { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSeatOffsetDistY { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSeatOffsetDistZ { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSteeringLock { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSteeringLockRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionCompDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionLowerLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionRaise { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionReboundDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionUpperLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveLateral { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveLateralRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMin { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMinRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionSpringDeltaMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionSpringDeltaMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat1 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat2 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat4 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat5 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetWeaponDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAcceleration { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAntiRollBarBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAntiRollBarBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAntiRollBarForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetBrakeBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetBrakeBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetCamberStiffness { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Vehicle_Handling_SetCentreOfMassOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetClutchChangeRateScaleDownShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetClutchChangeRateScaleUpShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetCollisionDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetDamageFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDeformationDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDownforceModifier { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDriveBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDriveInertia { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetEngineDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetHandBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetHandlingFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Vehicle_Handling_SetInertiaMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetInitialDragCoeff { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetInitialDriveForce { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetInitialDriveGears { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetInitialDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetLowSpeedTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetMass { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetModelFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetMonetaryValue { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetOilVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetPercentSubmerged { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetPercentSubmergedRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetPetrolTankVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetRollCentreHeightFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetRollCentreHeightRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSeatOffsetDistX { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSeatOffsetDistY { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSeatOffsetDistZ { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSteeringLock { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSteeringLockRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionCompDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionLowerLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionRaise { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionReboundDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionUpperLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveLateral { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveLateralRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMin { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMinRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionSpringDeltaMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionSpringDeltaMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat1 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat2 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat4 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat5 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetWeaponDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsHandlingModified { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ResetDashboardLights { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ResetHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetAbsLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetBatteryLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetEngineLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetEngineTemperature { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetFuelLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetOilLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetOilLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetPetrolLightState { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetAccuracySpread { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetAnimReloadRate { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> WeaponData_GetClipSize { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetDamage { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetHeadshotDamageModifier { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetLockOnRange { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> WeaponData_GetModelHash { get; }
        public delegate* unmanaged[Cdecl]<uint, uint> WeaponData_GetNameHash { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetPlayerDamageModifier { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetRange { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetRecoilAccuracyMax { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetRecoilAccuracyToAllowHeadshotPlayer { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetRecoilRecoveryRate { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetRecoilShakeAmplitude { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetTimeBetweenShots { get; }
        public delegate* unmanaged[Cdecl]<uint, float> WeaponData_GetVehicleReloadTime { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetAccuracySpread { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetAnimReloadRate { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetDamage { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetHeadshotDamageModifier { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetLockOnRange { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetPlayerDamageModifier { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetRange { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetRecoilAccuracyMax { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetRecoilAccuracyToAllowHeadshotPlayer { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetRecoilRecoveryRate { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetRecoilShakeAmplitude { get; }
        public delegate* unmanaged[Cdecl]<uint, float, void> WeaponData_SetVehicleReloadTime { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> WebSocketClient_AddSubProtocol { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> WebSocketClient_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> WebSocketClient_GetPingInterval { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> WebSocketClient_GetReadyState { get; }
        public delegate* unmanaged[Cdecl]<nint, uint*, nint> WebSocketClient_GetSubProtocols { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> WebSocketClient_GetUrl { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> WebSocketClient_IsAutoReconnect { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> WebSocketClient_IsPerMessageDeflate { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint, byte> WebSocketClient_Send_Binary { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> WebSocketClient_Send_String { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> WebSocketClient_SetAutoReconnect { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> WebSocketClient_SetExtraHeader { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> WebSocketClient_SetPerMessageDeflate { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> WebSocketClient_SetPingInterval { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> WebSocketClient_SetUrl { get; }
        public delegate* unmanaged[Cdecl]<nint, void> WebSocketClient_Start { get; }
        public delegate* unmanaged[Cdecl]<nint, void> WebSocketClient_Stop { get; }
        public delegate* unmanaged[Cdecl]<nint, void> WebView_Focus { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> WebView_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2*, void> WebView_GetPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2*, void> WebView_GetSize { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> WebView_GetUrl { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> WebView_IsFocused { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> WebView_IsOverlay { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> WebView_IsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> WebView_SetExtraHeader { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> WebView_SetIsVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, void> WebView_SetPosition { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, void> WebView_SetSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> WebView_SetUrl { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> WebView_SetZoomLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, void> WebView_Unfocus { get; }
        public delegate* unmanaged[Cdecl]<nint> Win_GetTaskDialog { get; }
        public ClientLibrary(Dictionary<ulong, IntPtr> funcTable)
        {
            Audio_AddOutput_Entity = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[16905578002628361906UL];
            Audio_AddOutput_ScriptId = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[5827298603098340943UL];
            Audio_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[5745233318326249240UL];
            Audio_GetCategory = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[15851037700138976694UL];
            Audio_GetCurrentTime = (delegate* unmanaged[Cdecl]<nint, double>) funcTable[11388986138037019142UL];
            Audio_GetLooped = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[6452844773777188117UL];
            Audio_GetMaxTime = (delegate* unmanaged[Cdecl]<nint, double>) funcTable[14356497270925355001UL];
            Audio_GetOutputs = (delegate* unmanaged[Cdecl]<nint, nint*, nint*, nint*, uint*, void>) funcTable[310457562583077580UL];
            Audio_GetSource = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[2194544719439267187UL];
            Audio_GetVolume = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[6461029116268465856UL];
            Audio_IsFrontendPlay = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[8802650293774203272UL];
            Audio_IsPlaying = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[18428683720958370944UL];
            Audio_Pause = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[4013212545266273652UL];
            Audio_Play = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[6674157256459581756UL];
            Audio_RemoveOutput_Entity = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[4030228605190822971UL];
            Audio_RemoveOutput_ScriptId = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[15937992446941802542UL];
            Audio_Reset = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[1619886962681253957UL];
            Audio_Seek = (delegate* unmanaged[Cdecl]<nint, double, void>) funcTable[754724177255938058UL];
            Audio_SetCategory = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[9152106765223926458UL];
            Audio_SetLooped = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[10754367750886277313UL];
            Audio_SetSource = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[791581795911185855UL];
            Audio_SetVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[8060600266486702404UL];
            Blip_GetScriptID = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[501721953999360323UL];
            Blip_IsRemote = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[3408870513353193473UL];
            Core_AddGXTText = (delegate* unmanaged[Cdecl]<nint, nint, uint, nint, void>) funcTable[5418530400531695192UL];
            Core_AreGameControlsEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[7505799004862739448UL];
            Core_AreRmlControlsEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[3403936900050438517UL];
            Core_AreVoiceControlsEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[13782596125011622546UL];
            Core_BeginScaleformMovieMethodMinimap = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[7610960948896539060UL];
            Core_ClearFocusOverride = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[11767134789034974988UL];
            Core_ClearPedProp = (delegate* unmanaged[Cdecl]<nint, int, byte, void>) funcTable[7241406705564868488UL];
            Core_Client_CreateAreaBlip = (delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint>) funcTable[1457536000366622407UL];
            Core_Client_CreatePointBlip = (delegate* unmanaged[Cdecl]<nint, Vector3, nint>) funcTable[10337435189885118154UL];
            Core_Client_CreateRadiusBlip = (delegate* unmanaged[Cdecl]<nint, Vector3, float, nint>) funcTable[1182859742647676376UL];
            Core_Client_FileExists = (delegate* unmanaged[Cdecl]<nint, nint, nint, byte>) funcTable[11956902508611497191UL];
            Core_Client_FileRead = (delegate* unmanaged[Cdecl]<nint, nint, nint, int*, nint>) funcTable[10617806201607563UL];
            Core_CopyToClipboard = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[3316379192020150055UL];
            Core_CreateAudio = (delegate* unmanaged[Cdecl]<nint, nint, nint, float, uint, byte, nint>) funcTable[16041000328065974383UL];
            Core_CreateCheckpoint = (delegate* unmanaged[Cdecl]<nint, byte, Vector3, Vector3, float, float, Rgba, nint>) funcTable[102161523841082289UL];
            Core_CreateHttpClient = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[8831170399766098212UL];
            Core_CreateObject = (delegate* unmanaged[Cdecl]<nint, uint, Vector3, Vector3, byte, byte, nint>) funcTable[12239910895707142552UL];
            Core_CreateRmlDocument = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint>) funcTable[8193598009746798351UL];
            Core_CreateWebsocketClient = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint>) funcTable[16434074828551718169UL];
            Core_CreateWebView = (delegate* unmanaged[Cdecl]<nint, nint, nint, Vector2, Vector2, byte, nint>) funcTable[5367354558636304814UL];
            Core_CreateWebView3D = (delegate* unmanaged[Cdecl]<nint, nint, nint, uint, nint, nint>) funcTable[10047886549591616921UL];
            Core_DeallocDiscordUser = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[15118189593860798044UL];
            Core_Discord_GetOAuth2Token = (delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.DiscordOAuth2TokenResultModuleDelegate, void>) funcTable[11931635815981319218UL];
            Core_DoesConfigFlagExist = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[9036876578219638445UL];
            Core_GetCamPos = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) funcTable[13858125070841044430UL];
            Core_GetClientPath = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[15647930946817256013UL];
            Core_GetConfigFlag = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[9032464247095711729UL];
            Core_GetCursorPos = (delegate* unmanaged[Cdecl]<nint, Vector2*, byte, void>) funcTable[16391498633294951383UL];
            Core_GetDiscordUser = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[17782609338683863460UL];
            Core_GetFocusOverrideEntity = (delegate* unmanaged[Cdecl]<nint, byte*, nint>) funcTable[15949137910261152748UL];
            Core_GetFocusOverrideOffset = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) funcTable[17077642725661397792UL];
            Core_GetFocusOverridePos = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) funcTable[8247812221923307363UL];
            Core_GetFPS = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[14046862447045356112UL];
            Core_GetGXTText = (delegate* unmanaged[Cdecl]<nint, nint, uint, int*, nint>) funcTable[8354620589505894441UL];
            Core_GetHeadshotBase64 = (delegate* unmanaged[Cdecl]<nint, byte, int*, nint>) funcTable[12777215372699677116UL];
            Core_GetLicenseHash = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[2622104054008169308UL];
            Core_GetLocale = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[8251030815154001183UL];
            Core_GetLocalMeta = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[2183995282040000869UL];
            Core_GetMapZoomDataByAlias = (delegate* unmanaged[Cdecl]<nint, nint, uint*, nint>) funcTable[15467645387540161121UL];
            Core_GetMsPerGameMinute = (delegate* unmanaged[Cdecl]<nint, int>) funcTable[7581745445590498846UL];
            Core_GetObjects = (delegate* unmanaged[Cdecl]<nint, uint*, nint>) funcTable[12367811699706904051UL];
            Core_GetPermissionState = (delegate* unmanaged[Cdecl]<nint, byte, byte>) funcTable[3859965617919065407UL];
            Core_GetPing = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[343388931206758433UL];
            Core_GetScreenResolution = (delegate* unmanaged[Cdecl]<nint, Vector2*, void>) funcTable[5184228836792416747UL];
            Core_GetServerIp = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[12875920274339473323UL];
            Core_GetServerPort = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[13612895546936521317UL];
            Core_GetStatBool = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[8298827394480893291UL];
            Core_GetStatData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[17824728879159590423UL];
            Core_GetStatFloat = (delegate* unmanaged[Cdecl]<nint, nint, float>) funcTable[7307416501315667515UL];
            Core_GetStatInt = (delegate* unmanaged[Cdecl]<nint, nint, int>) funcTable[7167729718835129856UL];
            Core_GetStatLong = (delegate* unmanaged[Cdecl]<nint, nint, long>) funcTable[1154702955606022233UL];
            Core_GetStatString = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint>) funcTable[6938285851022152026UL];
            Core_GetStatType = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint>) funcTable[1836585749512071671UL];
            Core_GetStatUInt16 = (delegate* unmanaged[Cdecl]<nint, nint, ushort>) funcTable[12241813567944212404UL];
            Core_GetStatUInt32 = (delegate* unmanaged[Cdecl]<nint, nint, uint>) funcTable[12239830048967298210UL];
            Core_GetStatUInt64 = (delegate* unmanaged[Cdecl]<nint, nint, ulong>) funcTable[12237032891385697101UL];
            Core_GetStatUInt8 = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[7393683926412120933UL];
            Core_GetTotalPacketsLost = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[17900332284634749644UL];
            Core_GetTotalPacketsSent = (delegate* unmanaged[Cdecl]<nint, ulong>) funcTable[14317008880510264460UL];
            Core_GetVoiceActivationKey = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[3075102187149534616UL];
            Core_GetVoiceInputMuted = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[5064579761377174510UL];
            Core_GetWorldObjects = (delegate* unmanaged[Cdecl]<nint, uint*, nint>) funcTable[17005623567895098393UL];
            Core_HasLocalMeta = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[11339904639883011785UL];
            Core_IsCamFrozen = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[8263359495025555388UL];
            Core_IsConsoleOpen = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[6112743714019862716UL];
            Core_IsCursorVisible = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[4651014201401555441UL];
            Core_IsFocusOverriden = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[6340487333443957237UL];
            Core_IsGameFocused = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[12257277232006255834UL];
            Core_IsInStreamerMode = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[11837576841137789452UL];
            Core_IsKeyDown = (delegate* unmanaged[Cdecl]<nint, uint, byte>) funcTable[7832339747543811174UL];
            Core_IsKeyToggled = (delegate* unmanaged[Cdecl]<nint, uint, byte>) funcTable[16393292154899659654UL];
            Core_IsMenuOpened = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[4674004737288150305UL];
            Core_IsPointOnScreen = (delegate* unmanaged[Cdecl]<nint, Vector3, byte>) funcTable[4486503442730341798UL];
            Core_IsTextureExistInArchetype = (delegate* unmanaged[Cdecl]<nint, uint, nint, byte>) funcTable[7244922572803522205UL];
            Core_IsVoiceActivityInputEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[15357067730603383667UL];
            Core_LoadDefaultIpls = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[7329989724110956008UL];
            Core_LoadModel = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[14785869974555852752UL];
            Core_LoadModelAsync = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[11548332561929147700UL];
            Core_LoadRmlFont = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint, byte, byte, void>) funcTable[18001251951939315539UL];
            Core_LoadYtyp = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[4601093208659730383UL];
            Core_OverrideFocusEntity = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[16396428673743430178UL];
            Core_OverrideFocusPosition = (delegate* unmanaged[Cdecl]<nint, Vector3, Vector3, void>) funcTable[10642205490788875634UL];
            Core_RemoveGXTText = (delegate* unmanaged[Cdecl]<nint, nint, uint, void>) funcTable[667318050992389259UL];
            Core_RemoveIpl = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[13334999182310259566UL];
            Core_RequestIpl = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[6925033075213640227UL];
            Core_ResetAllMapZoomData = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[8242878727879681410UL];
            Core_ResetMapZoomData = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[12406873252395372951UL];
            Core_ResetStat = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[16462727202164397128UL];
            Core_ScreenToWorld = (delegate* unmanaged[Cdecl]<nint, Vector2, Vector3*, void>) funcTable[18039191205029818070UL];
            Core_SetCamFrozen = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[9151730674609431682UL];
            Core_SetConfigFlag = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) funcTable[4597047729016767197UL];
            Core_SetCursorPos = (delegate* unmanaged[Cdecl]<nint, Vector2, byte, void>) funcTable[4696341770716269003UL];
            Core_SetMinimapComponentPosition = (delegate* unmanaged[Cdecl]<nint, nint, byte, byte, float, float, float, float, void>) funcTable[9963658435643169452UL];
            Core_SetMinimapIsRectangle = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[840321627262686653UL];
            Core_SetMsPerGameMinute = (delegate* unmanaged[Cdecl]<nint, int, void>) funcTable[8352251247416526730UL];
            Core_SetPedDlcClothes = (delegate* unmanaged[Cdecl]<nint, int, uint, byte, byte, byte, byte, void>) funcTable[2641051818984616609UL];
            Core_SetPedDlcProp = (delegate* unmanaged[Cdecl]<nint, int, uint, byte, byte, byte, void>) funcTable[11299516571588720518UL];
            Core_SetRotationVelocity = (delegate* unmanaged[Cdecl]<nint, int, Vector3, void>) funcTable[16295748319316595460UL];
            Core_SetStatBool = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) funcTable[16383321398330802727UL];
            Core_SetStatFloat = (delegate* unmanaged[Cdecl]<nint, nint, float, void>) funcTable[2797222242620039223UL];
            Core_SetStatInt = (delegate* unmanaged[Cdecl]<nint, nint, int, void>) funcTable[11392649224362214012UL];
            Core_SetStatLong = (delegate* unmanaged[Cdecl]<nint, nint, long, void>) funcTable[11480600638667152813UL];
            Core_SetStatString = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[2785755254553588470UL];
            Core_SetStatUInt16 = (delegate* unmanaged[Cdecl]<nint, nint, ushort, void>) funcTable[10929608262219096552UL];
            Core_SetStatUInt32 = (delegate* unmanaged[Cdecl]<nint, nint, uint, void>) funcTable[10927633539335208046UL];
            Core_SetStatUInt64 = (delegate* unmanaged[Cdecl]<nint, nint, ulong, void>) funcTable[10932409817847210505UL];
            Core_SetStatUInt8 = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) funcTable[2001471761436444265UL];
            Core_SetVoiceInputMuted = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[9648705763194192850UL];
            Core_SetWatermarkPosition = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[2862293364498039610UL];
            Core_SetWeatherCycle = (delegate* unmanaged[Cdecl]<nint, byte[], int, byte[], int, void>) funcTable[7963270655301960263UL];
            Core_SetWeatherSyncActive = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[7365007530117915530UL];
            Core_ShowCursor = (delegate* unmanaged[Cdecl]<nint, nint, bool, void>) funcTable[9183993827692923828UL];
            Core_StringToSHA256 = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint>) funcTable[16023175963702356044UL];
            Core_TakeScreenshot = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ScreenshotResultModuleDelegate, byte>) funcTable[5602594238455239620UL];
            Core_TakeScreenshotGameOnly = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ScreenshotResultModuleDelegate, byte>) funcTable[5742104717135457688UL];
            Core_ToggleGameControls = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) funcTable[9429763464273101007UL];
            Core_ToggleRmlControls = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[16327742095787259856UL];
            Core_ToggleVoiceControls = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[11909673682429312349UL];
            Core_TriggerServerEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) funcTable[12151558921348552198UL];
            Core_TriggerWebViewEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void>) funcTable[494903379947186396UL];
            Core_UnloadYtyp = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[16737023472725732364UL];
            Core_WorldToScreen = (delegate* unmanaged[Cdecl]<nint, Vector3, Vector2*, void>) funcTable[2200757103428916860UL];
            Entity_GetScriptID = (delegate* unmanaged[Cdecl]<nint, int>) funcTable[4666687282706913387UL];
            Event_SetAnyResourceErrorDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceErrorModuleDelegate, void>) funcTable[2051700994507480739UL];
            Event_SetAnyResourceStartDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceStartModuleDelegate, void>) funcTable[637610180866174749UL];
            Event_SetAnyResourceStopDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceStopModuleDelegate, void>) funcTable[6904273545794070333UL];
            Event_SetClientEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ClientEventModuleDelegate, void>) funcTable[9091490689786074738UL];
            Event_SetConnectionCompleteDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ConnectionCompleteModuleDelegate, void>) funcTable[13322214633698294440UL];
            Event_SetConsoleCommandDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ConsoleCommandModuleDelegate, void>) funcTable[15216863314700083185UL];
            Event_SetCreateAudioDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateAudioModuleDelegate, void>) funcTable[1501501791265169993UL];
            Event_SetCreateBlipDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateBlipModuleDelegate, void>) funcTable[10027964349129237884UL];
            Event_SetCreateCheckpointDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateCheckpointModuleDelegate, void>) funcTable[16682929889509585829UL];
            Event_SetCreateHttpClientDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateHttpClientModuleDelegate, void>) funcTable[5289962328167419764UL];
            Event_SetCreateObjectDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateObjectModuleDelegate, void>) funcTable[8596908447804149764UL];
            Event_SetCreatePlayerDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreatePlayerModuleDelegate, void>) funcTable[782265067539102198UL];
            Event_SetCreateRmlDocumentDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateRmlDocumentModuleDelegate, void>) funcTable[6518274951224615377UL];
            Event_SetCreateRmlElementDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateRmlElementModuleDelegate, void>) funcTable[10951149381175963786UL];
            Event_SetCreateVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateVehicleModuleDelegate, void>) funcTable[17044910335916169675UL];
            Event_SetCreateWebSocketClientDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateWebSocketClientModuleDelegate, void>) funcTable[8083766988198005595UL];
            Event_SetCreateWebViewDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateWebViewModuleDelegate, void>) funcTable[698310834935122268UL];
            Event_SetGameEntityCreateDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityCreateModuleDelegate, void>) funcTable[4836811662332180478UL];
            Event_SetGameEntityDestroyDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityDestroyModuleDelegate, void>) funcTable[8571100532037439142UL];
            Event_SetGlobalMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalMetaChangeModuleDelegate, void>) funcTable[2598489207307002921UL];
            Event_SetGlobalSyncedMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalSyncedMetaChangeModuleDelegate, void>) funcTable[3524597941952442491UL];
            Event_SetKeyDownDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void>) funcTable[9404030408280664108UL];
            Event_SetKeyUpDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void>) funcTable[9931752130358912669UL];
            Event_SetLocalMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.LocalMetaChangeModuleDelegate, void>) funcTable[14805688063406012213UL];
            Event_SetNetOwnerChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.NetOwnerChangeModuleDelegate, void>) funcTable[12367901277371547469UL];
            Event_SetPlayerChangeAnimationDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeAnimationModuleDelegate, void>) funcTable[14326612057973920746UL];
            Event_SetPlayerChangeInteriorDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeInteriorModuleDelegate, void>) funcTable[13673383168510680058UL];
            Event_SetPlayerChangeVehicleSeatDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeVehicleSeatModuleDelegate, void>) funcTable[3790585998434893641UL];
            Event_SetPlayerDisconnectDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerDisconnectModuleDelegate, void>) funcTable[1549554798684622204UL];
            Event_SetPlayerEnterVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerEnterVehicleModuleDelegate, void>) funcTable[1923165119346441184UL];
            Event_SetPlayerLeaveVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerLeaveVehicleModuleDelegate, void>) funcTable[14961736025769794951UL];
            Event_SetPlayerSpawnDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerSpawnModuleDelegate, void>) funcTable[11268891869591421375UL];
            Event_SetPlayerWeaponChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerWeaponChangeModuleDelegate, void>) funcTable[5492979685604513694UL];
            Event_SetPlayerWeaponShootDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerWeaponShootModuleDelegate, void>) funcTable[6818256047375626987UL];
            Event_SetRemoveAudioDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveAudioModuleDelegate, void>) funcTable[11315069979801977141UL];
            Event_SetRemoveBlipDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveBlipModuleDelegate, void>) funcTable[8037796803964619936UL];
            Event_SetRemoveCheckpointDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveCheckpointModuleDelegate, void>) funcTable[6221955488446414337UL];
            Event_SetRemoveEntityDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveEntityModuleDelegate, void>) funcTable[16152155238890224004UL];
            Event_SetRemoveHttpClientDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveHttpClientModuleDelegate, void>) funcTable[13360057399041602448UL];
            Event_SetRemoveObjectDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveObjectModuleDelegate, void>) funcTable[6587615673997035144UL];
            Event_SetRemovePlayerDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemovePlayerModuleDelegate, void>) funcTable[10423383830368468802UL];
            Event_SetRemoveRmlDocumentDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveRmlDocumentModuleDelegate, void>) funcTable[14117547966752822893UL];
            Event_SetRemoveRmlElementDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveRmlElementModuleDelegate, void>) funcTable[18223771896748589182UL];
            Event_SetRemoveVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveVehicleModuleDelegate, void>) funcTable[14424169933644660431UL];
            Event_SetRemoveWebSocketClientDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveWebSocketClientModuleDelegate, void>) funcTable[2032550370597953799UL];
            Event_SetRemoveWebViewDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveWebViewModuleDelegate, void>) funcTable[10199063866704599224UL];
            Event_SetRmlEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RmlEventModuleDelegate, void>) funcTable[30496965812679242UL];
            Event_SetServerEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ServerEventModuleDelegate, void>) funcTable[2971692831775383478UL];
            Event_SetStreamSyncedMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.StreamSyncedMetaChangeModuleDelegate, void>) funcTable[5661536634945721572UL];
            Event_SetSyncedMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.SyncedMetaChangeModuleDelegate, void>) funcTable[11449647566401505476UL];
            Event_SetTaskChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.TaskChangeModuleDelegate, void>) funcTable[17990382389078263474UL];
            Event_SetTickDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.TickModuleDelegate, void>) funcTable[9675161512950549314UL];
            Event_SetWeaponDamageDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WeaponDamageModuleDelegate, void>) funcTable[14786305860957378010UL];
            Event_SetWebSocketEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WebSocketEventModuleDelegate, void>) funcTable[6718035728053543946UL];
            Event_SetWebViewEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WebViewEventModuleDelegate, void>) funcTable[9098832370734780314UL];
            Event_SetWindowFocusChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WindowFocusChangeModuleDelegate, void>) funcTable[16816237331587672803UL];
            Event_SetWindowResolutionChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WindowResolutionChangeModuleDelegate, void>) funcTable[11266509741016760981UL];
            FreeRmlElementArray = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[2759792098189334963UL];
            GetNativeFuncTable = (delegate* unmanaged[Cdecl]<nint>) funcTable[18057905405504285670UL];
            Handling_GetAcceleration = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[13624814751546614143UL];
            Handling_GetAntiRollBarBiasFront = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[10594740743203586123UL];
            Handling_GetAntiRollBarBiasRear = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[8848326371558118226UL];
            Handling_GetAntiRollBarForce = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[18144702919216862476UL];
            Handling_GetBrakeBiasFront = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[1540917475990943978UL];
            Handling_GetBrakeBiasRear = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[9959676847579137673UL];
            Handling_GetBrakeForce = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[16066690649818527533UL];
            Handling_GetCamberStiffness = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[12856149426501638164UL];
            Handling_GetCentreOfMassOffset = (delegate* unmanaged[Cdecl]<uint, Vector3*, void>) funcTable[7612983020008677754UL];
            Handling_GetClutchChangeRateScaleDownShift = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[1299281864095515466UL];
            Handling_GetClutchChangeRateScaleUpShift = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[8827401313805566749UL];
            Handling_GetCollisionDamageMult = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[12237428543997087742UL];
            Handling_GetDamageFlags = (delegate* unmanaged[Cdecl]<uint, uint>) funcTable[14947966424705389613UL];
            Handling_GetDeformationDamageMult = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[7161067882439203788UL];
            Handling_GetDownforceModifier = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[13379963907557264903UL];
            Handling_GetDriveBiasFront = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[3677408191440066959UL];
            Handling_GetDriveInertia = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[8747113372100260085UL];
            Handling_GetDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[7038895793064914469UL];
            Handling_GetEngineDamageMult = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[11550094524282418598UL];
            Handling_GetHandBrakeForce = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[11603414005013245572UL];
            Handling_GetHandlingFlags = (delegate* unmanaged[Cdecl]<uint, uint>) funcTable[6943413718566419993UL];
            Handling_GetHandlingNameHash = (delegate* unmanaged[Cdecl]<uint, uint>) funcTable[8640968326648039369UL];
            Handling_GetInertiaMultiplier = (delegate* unmanaged[Cdecl]<uint, Vector3*, void>) funcTable[11212186208992921224UL];
            Handling_GetInitialDragCoeff = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[5688175012660882904UL];
            Handling_GetInitialDriveForce = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[8840995133194739886UL];
            Handling_GetInitialDriveGears = (delegate* unmanaged[Cdecl]<uint, uint>) funcTable[6687641533430313749UL];
            Handling_GetInitialDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[14144818963284424087UL];
            Handling_GetLowSpeedTractionLossMult = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[17987394206782768947UL];
            Handling_GetMass = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[5501036719479541711UL];
            Handling_GetModelFlags = (delegate* unmanaged[Cdecl]<uint, uint>) funcTable[3855073073528413619UL];
            Handling_GetMonetaryValue = (delegate* unmanaged[Cdecl]<uint, uint>) funcTable[7375093732080490105UL];
            Handling_GetOilVolume = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[16483321693947688363UL];
            Handling_GetPercentSubmerged = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[4127528026938310074UL];
            Handling_GetPercentSubmergedRatio = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[8555153053561029769UL];
            Handling_GetPetrolTankVolume = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[18414804403188978051UL];
            Handling_GetRollCentreHeightFront = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[8497407164550207255UL];
            Handling_GetRollCentreHeightRear = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[14075511625417471246UL];
            Handling_GetSeatOffsetDistX = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[4005205065366672795UL];
            Handling_GetSeatOffsetDistY = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[4005203965855044584UL];
            Handling_GetSeatOffsetDistZ = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[4005207264389929217UL];
            Handling_GetSteeringLock = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[7974432269354924807UL];
            Handling_GetSteeringLockRatio = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[12905887441999468274UL];
            Handling_GetSuspensionBiasFront = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[6741856606398893182UL];
            Handling_GetSuspensionBiasRear = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[15901469631126965309UL];
            Handling_GetSuspensionCompDamp = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[7515049029653772367UL];
            Handling_GetSuspensionForce = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[4036932257369728873UL];
            Handling_GetSuspensionLowerLimit = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[10822460398559637530UL];
            Handling_GetSuspensionRaise = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[8425902362403546934UL];
            Handling_GetSuspensionReboundDamp = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[483850675192275083UL];
            Handling_GetSuspensionUpperLimit = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[7608663264912133277UL];
            Handling_GetTractionBiasFront = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[10805860439014824609UL];
            Handling_GetTractionBiasRear = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[4466190029644065812UL];
            Handling_GetTractionCurveLateral = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[10570605158004541869UL];
            Handling_GetTractionCurveLateralRatio = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[17305170651865432732UL];
            Handling_GetTractionCurveMax = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[13012063275439258128UL];
            Handling_GetTractionCurveMaxRatio = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[288330456725482275UL];
            Handling_GetTractionCurveMin = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[13004487640322398138UL];
            Handling_GetTractionCurveMinRatio = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[2861602113259983497UL];
            Handling_GetTractionLossMult = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[15639344535663345118UL];
            Handling_GetTractionSpringDeltaMax = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[7406735691348904958UL];
            Handling_GetTractionSpringDeltaMaxRatio = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[9158827384634469349UL];
            Handling_GetunkFloat1 = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[1982175074059174772UL];
            Handling_GetunkFloat2 = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[1982178372594059405UL];
            Handling_GetunkFloat4 = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[1982171775524290139UL];
            Handling_GetunkFloat5 = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[1982170676012661928UL];
            Handling_GetWeaponDamageMult = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[2413407182364190104UL];
            Handling_SetAcceleration = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[1758592208721049987UL];
            Handling_SetAntiRollBarBiasFront = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[16243312669711460567UL];
            Handling_SetAntiRollBarBiasRear = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[15187606792306631886UL];
            Handling_SetAntiRollBarForce = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[15457469788774083360UL];
            Handling_SetBrakeBiasFront = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[11849399891457904950UL];
            Handling_SetBrakeBiasRear = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[16722829573808656293UL];
            Handling_SetBrakeForce = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[5919963323462108577UL];
            Handling_SetCamberStiffness = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[2624932986328626168UL];
            Handling_SetCentreOfMassOffset = (delegate* unmanaged[Cdecl]<uint, Vector3, void>) funcTable[13812113430490255198UL];
            Handling_SetClutchChangeRateScaleDownShift = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[2303154151539548878UL];
            Handling_SetClutchChangeRateScaleUpShift = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[7445885150995272041UL];
            Handling_SetCollisionDamageMult = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[3571731783216579106UL];
            Handling_SetDamageFlags = (delegate* unmanaged[Cdecl]<uint, uint, void>) funcTable[537662139595455537UL];
            Handling_SetDeformationDamageMult = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[784308426389024792UL];
            Handling_SetDownforceModifier = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[9145673695655900243UL];
            Handling_SetDriveBiasFront = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[16572611112120812027UL];
            Handling_SetDriveInertia = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[14728385455329543689UL];
            Handling_SetDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[12184195394360257745UL];
            Handling_SetEngineDamageMult = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[15273639201901822562UL];
            Handling_SetHandBrakeForce = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[3927236931217555944UL];
            Handling_SetHandlingFlags = (delegate* unmanaged[Cdecl]<uint, uint, void>) funcTable[376016819761821317UL];
            Handling_SetInertiaMultiplier = (delegate* unmanaged[Cdecl]<uint, Vector3, void>) funcTable[1724956346568874092UL];
            Handling_SetInitialDragCoeff = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[17184681692411087028UL];
            Handling_SetInitialDriveForce = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[11970016635293724434UL];
            Handling_SetInitialDriveGears = (delegate* unmanaged[Cdecl]<uint, uint, void>) funcTable[3734366437378273841UL];
            Handling_SetInitialDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[7403114842201132179UL];
            Handling_SetLowSpeedTractionLossMult = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[15289976609215981783UL];
            Handling_SetMass = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[8190254034030138331UL];
            Handling_SetModelFlags = (delegate* unmanaged[Cdecl]<uint, uint, void>) funcTable[11497460465166503559UL];
            Handling_SetMonetaryValue = (delegate* unmanaged[Cdecl]<uint, uint, void>) funcTable[2594570157380173805UL];
            Handling_SetOilVolume = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[3253947611054675143UL];
            Handling_SetPercentSubmerged = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[13115758554391751486UL];
            Handling_SetPercentSubmergedRatio = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[15898995197540963877UL];
            Handling_SetPetrolTankVolume = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[966697117301139367UL];
            Handling_SetRollCentreHeightFront = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[12619280032445944563UL];
            Handling_SetRollCentreHeightRear = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[4523306816309501738UL];
            Handling_SetSeatOffsetDistX = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[15308632544548493615UL];
            Handling_SetSeatOffsetDistY = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[15308631445036865404UL];
            Handling_SetSeatOffsetDistZ = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[15308634743571750037UL];
            Handling_SetSteeringLock = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[394620128617625187UL];
            Handling_SetSteeringLockRatio = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[7887478553515539366UL];
            Handling_SetSuspensionBiasFront = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[5149586735442141938UL];
            Handling_SetSuspensionBiasRear = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[11545810037051194625UL];
            Handling_SetSuspensionCompDamp = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[7504016883110333899UL];
            Handling_SetSuspensionForce = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[1810703612634991061UL];
            Handling_SetSuspensionLowerLimit = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[12067101740945464222UL];
            Handling_SetSuspensionRaise = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[128416076886968066UL];
            Handling_SetSuspensionReboundDamp = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[12752057920719603847UL];
            Handling_SetSuspensionUpperLimit = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[9464075263166591073UL];
            Handling_SetTractionBiasFront = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[15100090231323996861UL];
            Handling_SetTractionBiasRear = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[10850124511941666000UL];
            Handling_SetTractionCurveLateral = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[14643574737777941385UL];
            Handling_SetTractionCurveLateralRatio = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[8826815076074522528UL];
            Handling_SetTractionCurveMax = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[12335988240743993172UL];
            Handling_SetTractionCurveMaxRatio = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[16770555692902172511UL];
            Handling_SetTractionCurveMin = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[12328368625162004742UL];
            Handling_SetTractionCurveMinRatio = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[925954911097918237UL];
            Handling_SetTractionLossMult = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[16760038608373822498UL];
            Handling_SetTractionSpringDeltaMax = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[1869935309309611530UL];
            Handling_SetTractionSpringDeltaMaxRatio = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[4808092995242021049UL];
            Handling_SetunkFloat1 = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[15161870714787733568UL];
            Handling_SetunkFloat2 = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[15161874013322618201UL];
            Handling_SetunkFloat4 = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[15161876212345874623UL];
            Handling_SetunkFloat5 = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[15161875112834246412UL];
            Handling_SetWeaponDamageMult = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[14105911650575848876UL];
            HttpClient_Connect = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) funcTable[2365480475834603879UL];
            HttpClient_Delete = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) funcTable[8232918492481382800UL];
            HttpClient_Get = (delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) funcTable[4334635731329240893UL];
            HttpClient_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[2366043818608618855UL];
            HttpClient_GetExtraHeaders = (delegate* unmanaged[Cdecl]<nint, nint*, nint*, int*, void>) funcTable[10548421098226168213UL];
            HttpClient_Head = (delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) funcTable[7252671215097431945UL];
            HttpClient_Options = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) funcTable[7387919532121243399UL];
            HttpClient_Patch = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) funcTable[7418218987542253639UL];
            HttpClient_Post = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) funcTable[381490135483714293UL];
            HttpClient_Put = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) funcTable[12099739788502530064UL];
            HttpClient_SetExtraHeader = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[6380481551828770088UL];
            HttpClient_Trace = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) funcTable[10929952870369787448UL];
            LocalPlayer_GetCurrentAmmo = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[11323017524450537377UL];
            LocalPlayer_GetCurrentWeaponHash = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[14780359424452904819UL];
            LocalPlayer_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[16652520629046945775UL];
            LocalPlayer_GetPlayer = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[3247950422735147003UL];
            LocalPlayer_GetWeaponAmmo = (delegate* unmanaged[Cdecl]<nint, uint, ushort>) funcTable[10335677192059765124UL];
            LocalPlayer_GetWeaponComponents = (delegate* unmanaged[Cdecl]<nint, uint, nint*, uint*, void>) funcTable[9592241143794164726UL];
            LocalPlayer_GetWeapons = (delegate* unmanaged[Cdecl]<nint, nint*, uint*, void>) funcTable[10466395082714547523UL];
            LocalPlayer_HasWeapon = (delegate* unmanaged[Cdecl]<nint, uint, byte>) funcTable[3731445245582274998UL];
            LocalStorage_Clear = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[16361869751406691467UL];
            LocalStorage_DeleteKey = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[6274499691882983444UL];
            LocalStorage_GetKey = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[17812344948919371541UL];
            LocalStorage_Save = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[5262946451355414287UL];
            LocalStorage_SetKey = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[4533176811146616409UL];
            MapData_GetFScrollSpeed = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[13751151120093323324UL];
            MapData_GetFZoomScale = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[11933189166389491747UL];
            MapData_GetFZoomSpeed = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[14895176095785107798UL];
            MapData_GetVTilesX = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[2372302576683995975UL];
            MapData_GetVTilesY = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[2372301477172367764UL];
            MapData_SetFScrollSpeed = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[3015442569045559176UL];
            MapData_SetFZoomScale = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[16660126263762344935UL];
            MapData_SetFZoomSpeed = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[5404397572483975730UL];
            MapData_SetVTilesX = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[5209892052509722515UL];
            MapData_SetVTilesY = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[5209890952998094304UL];
            Object_IsRemote = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[11016334243399582569UL];
            Player_GetLocal = (delegate* unmanaged[Cdecl]<nint>) funcTable[8938755572393001806UL];
            Player_GetMicLevel = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[17456899458340282168UL];
            Player_GetNonSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[12611070433478166976UL];
            Player_GetSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[549392158271724311UL];
            Player_IsTalking = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[5955622104882402305UL];
            Player_SetNonSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[8874972969567149348UL];
            Player_SetSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[4055666754970683163UL];
            Resource_FileExists = (delegate* unmanaged[Cdecl]<nint, nint, bool>) funcTable[6014125782844400152UL];
            Resource_GetFile = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint*, void>) funcTable[3871814524701254220UL];
            Resource_GetLocalStorage = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[12051979412148222794UL];
            RmlDocument_CreateElement = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[10642752819905143098UL];
            RmlDocument_CreateTextNode = (delegate* unmanaged[Cdecl]<nint, nint, nint>) funcTable[13119221992970511377UL];
            RmlDocument_GetBody = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[15665040113694440550UL];
            RmlDocument_GetRmlElement = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[17657575332131456787UL];
            RmlDocument_GetSourceUrl = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[16640194521382798072UL];
            RmlDocument_GetTitle = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[18024986439806194532UL];
            RmlDocument_Hide = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[3748615861796363270UL];
            RmlDocument_IsModal = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[4914669130875794147UL];
            RmlDocument_IsVisible = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[9948589942909096300UL];
            RmlDocument_SetTitle = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[268904169853084696UL];
            RmlDocument_Show = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) funcTable[750501874769424971UL];
            RmlDocument_Update = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[9541093055848395471UL];
            RmlElement_AddClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void>) funcTable[2820183251482068224UL];
            RmlElement_AddPseudoClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void>) funcTable[7641244424263498150UL];
            RmlElement_AppendChild = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[11927563774793348621UL];
            RmlElement_Blur = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void>) funcTable[9586147878740724260UL];
            RmlElement_Click = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void>) funcTable[3595109554644131579UL];
            RmlElement_Focus = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void>) funcTable[4908473844226331151UL];
            RmlElement_GetAbsoluteLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[4800056776949415707UL];
            RmlElement_GetAbsoluteOffset = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void>) funcTable[9902532974072673849UL];
            RmlElement_GetAbsoluteTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[2024085596978035673UL];
            RmlElement_GetAttribute = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint>) funcTable[16965861644844510697UL];
            RmlElement_GetAttributes = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, nint*, uint*, void>) funcTable[8490637140982103214UL];
            RmlElement_GetBaseline = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[10767331024826426212UL];
            RmlElement_GetBaseObject = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) funcTable[17879251354768112461UL];
            RmlElement_GetChildCount = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, uint>) funcTable[1640654979607706762UL];
            RmlElement_GetChildNodes = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void>) funcTable[17435735590641149320UL];
            RmlElement_GetClassList = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void>) funcTable[12760509477431494769UL];
            RmlElement_GetClientHeight = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[10818546577735888199UL];
            RmlElement_GetClientLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[11511990416760542485UL];
            RmlElement_GetClientTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[14961707319790707639UL];
            RmlElement_GetClientWidth = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[16370669061563861424UL];
            RmlElement_GetClosest = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint>) funcTable[14584183246732471166UL];
            RmlElement_GetContainingBlock = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void>) funcTable[8721946258576908700UL];
            RmlElement_GetElementById = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint>) funcTable[8218622718140617609UL];
            RmlElement_GetElementsByClassName = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void>) funcTable[18302228518552372158UL];
            RmlElement_GetElementsByTagName = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void>) funcTable[7021646799462461682UL];
            RmlElement_GetFirstChild = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) funcTable[14724327319195357191UL];
            RmlElement_GetFocusedElement = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) funcTable[8533147306514776532UL];
            RmlElement_GetId = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint>) funcTable[8955717777830966830UL];
            RmlElement_GetInnerRml = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint>) funcTable[9121188437455194084UL];
            RmlElement_GetLastChild = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) funcTable[15501254274659713275UL];
            RmlElement_GetLocalProperty = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint>) funcTable[16271818300377620391UL];
            RmlElement_GetNextSibling = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) funcTable[12361074701820253768UL];
            RmlElement_GetOffsetHeight = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[11246602282940266059UL];
            RmlElement_GetOffsetLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[14818159675802816753UL];
            RmlElement_GetOffsetTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[10072592414721142635UL];
            RmlElement_GetOffsetWidth = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[15595715949877553980UL];
            RmlElement_GetOwnerDocument = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) funcTable[12637146364043628907UL];
            RmlElement_GetParent = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) funcTable[10938522686801509707UL];
            RmlElement_GetPreviousSibling = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) funcTable[891239922054421668UL];
            RmlElement_GetProperty = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint>) funcTable[15257370850213777354UL];
            RmlElement_GetPropertyAbsoluteValue = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, float>) funcTable[17328530976822535904UL];
            RmlElement_GetPseudoClassList = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void>) funcTable[13068152492708219703UL];
            RmlElement_GetRelativeOffset = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void>) funcTable[12160532298285136584UL];
            RmlElement_GetScrollHeight = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[832599130103298937UL];
            RmlElement_GetScrollLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[738930211639948503UL];
            RmlElement_GetScrollTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[16746723301275513981UL];
            RmlElement_GetScrollWidth = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[16141158796341216134UL];
            RmlElement_GetTagName = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint>) funcTable[5037799530212790618UL];
            RmlElement_GetZIndex = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) funcTable[3408290893694336209UL];
            RmlElement_HasAttribute = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) funcTable[9022337411770312669UL];
            RmlElement_HasChildren = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte>) funcTable[9258967865644915936UL];
            RmlElement_HasClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) funcTable[829832327312277641UL];
            RmlElement_HasLocalProperty = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) funcTable[127541762084006323UL];
            RmlElement_HasProperty = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) funcTable[2230027563475148118UL];
            RmlElement_HasPseudoClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) funcTable[1152211250355982979UL];
            RmlElement_InsertBefore = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[10893638794791098551UL];
            RmlElement_IsOwned = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte>) funcTable[5906509668218647018UL];
            RmlElement_IsPointWithinElement = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2, byte>) funcTable[17360541281702394490UL];
            RmlElement_IsVisible = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte>) funcTable[13297758914040133709UL];
            RmlElement_QuerySelector = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint>) funcTable[1307214619736161022UL];
            RmlElement_QuerySelectorAll = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void>) funcTable[16234728570293987085UL];
            RmlElement_RemoveAttribute = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) funcTable[18366492142368160987UL];
            RmlElement_RemoveChild = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[11888855452435811633UL];
            RmlElement_RemoveClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) funcTable[4509347774832794955UL];
            RmlElement_RemoveProperty = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[10693221490638295644UL];
            RmlElement_RemovePseudoClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) funcTable[9790078136470308117UL];
            RmlElement_ReplaceChild = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[2983086139257394207UL];
            RmlElement_ScrollIntoView = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte, void>) funcTable[8195300208997372979UL];
            RmlElement_SetAttribute = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint, void>) funcTable[15566360484909892493UL];
            RmlElement_SetId = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void>) funcTable[9672388707467178682UL];
            RmlElement_SetInnerRml = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[5541303684283065696UL];
            RmlElement_SetOffset = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, Vector2, byte, void>) funcTable[1617253728850426284UL];
            RmlElement_SetProperty = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[13107304283685121926UL];
            RmlElement_SetScrollLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float, void>) funcTable[3020228453977319747UL];
            RmlElement_SetScrollTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float, void>) funcTable[12254382028928613937UL];
            Vehicle_GetAbsLightState = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[11465910969401486109UL];
            Vehicle_GetBatteryLightState = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[7848965836586438468UL];
            Vehicle_GetEngineLightState = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[13394205865713256511UL];
            Vehicle_GetEngineTemperature = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[17519926568328251068UL];
            Vehicle_GetFuelLevel = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[7580042278215800086UL];
            Vehicle_GetGear = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[9309814334597532303UL];
            Vehicle_GetIndicatorLights = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[12221325088471441924UL];
            Vehicle_GetMaxGear = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[12126835936703230501UL];
            Vehicle_GetOilLevel = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[1927937236085810986UL];
            Vehicle_GetOilLightState = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[1882387157498793117UL];
            Vehicle_GetPetrolLightState = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[7527247142245896335UL];
            Vehicle_GetRPM = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[2741222111971626377UL];
            Vehicle_GetSeatCount = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[4466655922564697820UL];
            Vehicle_GetSpeedVector = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) funcTable[6222226012404492852UL];
            Vehicle_GetWheelSpeed = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[12526415873184871038UL];
            Vehicle_GetWheelSurfaceMaterial = (delegate* unmanaged[Cdecl]<nint, byte, uint>) funcTable[14498368668841337331UL];
            Vehicle_Handling_GetAcceleration = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[6447107622156387014UL];
            Vehicle_Handling_GetAntiRollBarBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[7256591593615684542UL];
            Vehicle_Handling_GetAntiRollBarBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[4077980556768758653UL];
            Vehicle_Handling_GetAntiRollBarForce = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[18435352829241725865UL];
            Vehicle_Handling_GetBrakeBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[6184847547648978919UL];
            Vehicle_Handling_GetBrakeBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[12987368804787444734UL];
            Vehicle_Handling_GetBrakeForce = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[3213094684959060080UL];
            Vehicle_Handling_GetCamberStiffness = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[3732965928815068415UL];
            Vehicle_Handling_GetCentreOfMassOffset = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) funcTable[9507675400344119443UL];
            Vehicle_Handling_GetClutchChangeRateScaleDownShift = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[6980526537418099731UL];
            Vehicle_Handling_GetClutchChangeRateScaleUpShift = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[2887520218081357128UL];
            Vehicle_Handling_GetCollisionDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[16383514226076622293UL];
            Vehicle_Handling_GetDamageFlags = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[12056759872942180618UL];
            Vehicle_Handling_GetDeformationDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[5659700838891907059UL];
            Vehicle_Handling_GetDownforceModifier = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[17727616566934238384UL];
            Vehicle_Handling_GetDriveBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[4530996063217069670UL];
            Vehicle_Handling_GetDriveInertia = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[12172383629611372740UL];
            Vehicle_Handling_GetDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[13020113782025083638UL];
            Vehicle_Handling_GetEngineDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[10051804440091844767UL];
            Vehicle_Handling_GetHandBrakeForce = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[342229853263984485UL];
            Vehicle_Handling_GetHandlingFlags = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[15662252560696187394UL];
            Vehicle_Handling_GetHandlingNameHash = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[16352503887678862784UL];
            Vehicle_Handling_GetInertiaMultiplier = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) funcTable[17893067791811527415UL];
            Vehicle_Handling_GetInitialDragCoeff = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[11536658760227957329UL];
            Vehicle_Handling_GetInitialDriveForce = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[2706614254080389709UL];
            Vehicle_Handling_GetInitialDriveGears = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[683714825302252806UL];
            Vehicle_Handling_GetInitialDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[12653651903821535850UL];
            Vehicle_Handling_GetLowSpeedTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[15310234787245408210UL];
            Vehicle_Handling_GetMass = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[9591105156773969614UL];
            Vehicle_Handling_GetModelFlags = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[4283572218989440954UL];
            Vehicle_Handling_GetMonetaryValue = (delegate* unmanaged[Cdecl]<nint, uint>) funcTable[7557776831182655982UL];
            Vehicle_Handling_GetOilVolume = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[17022918435085709168UL];
            Vehicle_Handling_GetPercentSubmerged = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[1328757541459836847UL];
            Vehicle_Handling_GetPercentSubmergedRatio = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[17218504520074703690UL];
            Vehicle_Handling_GetPetrolTankVolume = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[5831273882635521162UL];
            Vehicle_Handling_GetRollCentreHeightFront = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[7843856576211842228UL];
            Vehicle_Handling_GetRollCentreHeightRear = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[6419496600324581407UL];
            Vehicle_Handling_GetSeatOffsetDistX = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[14928232606397351664UL];
            Vehicle_Handling_GetSeatOffsetDistY = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[14928233705908979875UL];
            Vehicle_Handling_GetSeatOffsetDistZ = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[14928234805420608086UL];
            Vehicle_Handling_GetSteeringLock = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[7292724090849323962UL];
            Vehicle_Handling_GetSteeringLockRatio = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[1298215191180480137UL];
            Vehicle_Handling_GetSuspensionBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[6517771070232854321UL];
            Vehicle_Handling_GetSuspensionBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[9041966748987438852UL];
            Vehicle_Handling_GetSuspensionCompDamp = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[7732655125904378774UL];
            Vehicle_Handling_GetSuspensionForce = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[14555500913880272506UL];
            Vehicle_Handling_GetSuspensionLowerLimit = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[13810088143408445943UL];
            Vehicle_Handling_GetSuspensionRaise = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[7280457455038904649UL];
            Vehicle_Handling_GetSuspensionReboundDamp = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[10014586847579495440UL];
            Vehicle_Handling_GetSuspensionUpperLimit = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[2064232965778437272UL];
            Vehicle_Handling_GetTractionBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[11385181389226018226UL];
            Vehicle_Handling_GetTractionBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[9594149276752837825UL];
            Vehicle_Handling_GetTractionCurveLateral = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[534082592445893552UL];
            Vehicle_Handling_GetTractionCurveLateralRatio = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[5626574420149731843UL];
            Vehicle_Handling_GetTractionCurveMax = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[9832819786632703269UL];
            Vehicle_Handling_GetTractionCurveMaxRatio = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[4601222526193131076UL];
            Vehicle_Handling_GetTractionCurveMin = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[9840430606121666011UL];
            Vehicle_Handling_GetTractionCurveMinRatio = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[7136027236258291374UL];
            Vehicle_Handling_GetTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[2248564621668422635UL];
            Vehicle_Handling_GetTractionSpringDeltaMax = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[9757970846134686035UL];
            Vehicle_Handling_GetTractionSpringDeltaMaxRatio = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[11316631929456207478UL];
            Vehicle_Handling_GetunkFloat1 = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[4808133989544786907UL];
            Vehicle_Handling_GetunkFloat2 = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[4808135089056415118UL];
            Vehicle_Handling_GetunkFloat4 = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[4808137288079671540UL];
            Vehicle_Handling_GetunkFloat5 = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[4808138387591299751UL];
            Vehicle_Handling_GetWeaponDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) funcTable[12323651444162571717UL];
            Vehicle_Handling_SetAcceleration = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[15106533278746961370UL];
            Vehicle_Handling_SetAntiRollBarBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[16638968082430627690UL];
            Vehicle_Handling_SetAntiRollBarBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[3274134675670177289UL];
            Vehicle_Handling_SetAntiRollBarForce = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[13924267053015573933UL];
            Vehicle_Handling_SetBrakeBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[13158394514505254339UL];
            Vehicle_Handling_SetBrakeBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[15054984352340739674UL];
            Vehicle_Handling_SetBrakeForce = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[18311355750023466244UL];
            Vehicle_Handling_SetCamberStiffness = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[9234402101822179187UL];
            Vehicle_Handling_SetCentreOfMassOffset = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) funcTable[6452421273342482743UL];
            Vehicle_Handling_SetClutchChangeRateScaleDownShift = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[18254580469174698855UL];
            Vehicle_Handling_SetClutchChangeRateScaleUpShift = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[5076757107666434868UL];
            Vehicle_Handling_SetCollisionDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[2789843895875420361UL];
            Vehicle_Handling_SetDamageFlags = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[18178148431073907246UL];
            Vehicle_Handling_SetDeformationDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[18182492532635156463UL];
            Vehicle_Handling_SetDownforceModifier = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[15514642209212203804UL];
            Vehicle_Handling_SetDriveBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[4564559942385746402UL];
            Vehicle_Handling_SetDriveInertia = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[7730126370537688552UL];
            Vehicle_Handling_SetDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[4591283739989300642UL];
            Vehicle_Handling_SetEngineDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[6624156074364677019UL];
            Vehicle_Handling_SetHandBrakeForce = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[10705633238916026377UL];
            Vehicle_Handling_SetHandlingFlags = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[9906600460569644270UL];
            Vehicle_Handling_SetInertiaMultiplier = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) funcTable[1816307337051823467UL];
            Vehicle_Handling_SetInitialDragCoeff = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[4043275867962795821UL];
            Vehicle_Handling_SetInitialDriveForce = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[15357625830756814433UL];
            Vehicle_Handling_SetInitialDriveGears = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[9065355636246472242UL];
            Vehicle_Handling_SetInitialDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[281293266165798950UL];
            Vehicle_Handling_SetLowSpeedTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[8895965605036240854UL];
            Vehicle_Handling_SetMass = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[7151825199476808906UL];
            Vehicle_Handling_SetModelFlags = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[6056936688800253742UL];
            Vehicle_Handling_SetMonetaryValue = (delegate* unmanaged[Cdecl]<nint, uint, void>) funcTable[15819996972218358546UL];
            Vehicle_Handling_SetOilVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[3549287771343907724UL];
            Vehicle_Handling_SetPercentSubmerged = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[6477141810310072643UL];
            Vehicle_Handling_SetPercentSubmergedRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[15383388972106689350UL];
            Vehicle_Handling_SetPetrolTankVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[1497531346267417774UL];
            Vehicle_Handling_SetRollCentreHeightFront = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[4524337672947469440UL];
            Vehicle_Handling_SetRollCentreHeightRear = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[9581089564722294907UL];
            Vehicle_Handling_SetSeatOffsetDistX = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[15635845820584287588UL];
            Vehicle_Handling_SetSeatOffsetDistY = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[15635846920095915799UL];
            Vehicle_Handling_SetSeatOffsetDistZ = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[15635848019607544010UL];
            Vehicle_Handling_SetSteeringLock = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[10188586324588770150UL];
            Vehicle_Handling_SetSteeringLockRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[6273551755216734141UL];
            Vehicle_Handling_SetSuspensionBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[11177545997217526949UL];
            Vehicle_Handling_SetSuspensionBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[16305748508626481800UL];
            Vehicle_Handling_SetSuspensionCompDamp = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[3593876208755398802UL];
            Vehicle_Handling_SetSuspensionForce = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[5286513994799631766UL];
            Vehicle_Handling_SetSuspensionLowerLimit = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[13687971358154974811UL];
            Vehicle_Handling_SetSuspensionRaise = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[8302592036766463941UL];
            Vehicle_Handling_SetSuspensionReboundDamp = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[10090490188791414684UL];
            Vehicle_Handling_SetSuspensionUpperLimit = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[17916460604483963228UL];
            Vehicle_Handling_SetTractionBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[11277773691139858062UL];
            Vehicle_Handling_SetTractionBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[17464553981869049773UL];
            Vehicle_Handling_SetTractionCurveLateral = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[3019713143471126604UL];
            Vehicle_Handling_SetTractionCurveLateralRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[1819845031926358855UL];
            Vehicle_Handling_SetTractionCurveMax = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[10772241836561203273UL];
            Vehicle_Handling_SetTractionCurveMaxRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[15065622036225381472UL];
            Vehicle_Handling_SetTractionCurveMin = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[10764661803397830439UL];
            Vehicle_Handling_SetTractionCurveMinRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[9038485735910964562UL];
            Vehicle_Handling_SetTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[2292760461423496175UL];
            Vehicle_Handling_SetTractionSpringDeltaMax = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[12188740530353601983UL];
            Vehicle_Handling_SetTractionSpringDeltaMaxRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[2068724641429698938UL];
            Vehicle_Handling_SetunkFloat1 = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[1821583616903019271UL];
            Vehicle_Handling_SetunkFloat2 = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[1821584716414647482UL];
            Vehicle_Handling_SetunkFloat4 = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[1821578119344878216UL];
            Vehicle_Handling_SetunkFloat5 = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[1821579218856506427UL];
            Vehicle_Handling_SetWeaponDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[6185502032595814905UL];
            Vehicle_IsHandlingModified = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[13271914989488024838UL];
            Vehicle_ResetDashboardLights = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[10347186584210476912UL];
            Vehicle_ResetHandling = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[8789889568362468306UL];
            Vehicle_SetAbsLightState = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[9720329968455796217UL];
            Vehicle_SetBatteryLightState = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[6265377987717374872UL];
            Vehicle_SetEngineLightState = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[7196701746429391243UL];
            Vehicle_SetEngineTemperature = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[1548276320594586840UL];
            Vehicle_SetFuelLevel = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[12489292962874585114UL];
            Vehicle_SetGear = (delegate* unmanaged[Cdecl]<nint, ushort, void>) funcTable[18234704538353625523UL];
            Vehicle_SetIndicatorLights = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[14417244985087537000UL];
            Vehicle_SetMaxGear = (delegate* unmanaged[Cdecl]<nint, ushort, void>) funcTable[17066336397728873081UL];
            Vehicle_SetOilLevel = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[10946448823261225590UL];
            Vehicle_SetOilLightState = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[14482522476363790265UL];
            Vehicle_SetPetrolLightState = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[953227185363569571UL];
            WeaponData_GetAccuracySpread = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[6458291939687526764UL];
            WeaponData_GetAnimReloadRate = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[12096121937914309204UL];
            WeaponData_GetClipSize = (delegate* unmanaged[Cdecl]<uint, uint>) funcTable[7560945065168273249UL];
            WeaponData_GetDamage = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[4924797105201757987UL];
            WeaponData_GetHeadshotDamageModifier = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[11148147521706823012UL];
            WeaponData_GetLockOnRange = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[8482855862564954785UL];
            WeaponData_GetModelHash = (delegate* unmanaged[Cdecl]<uint, uint>) funcTable[8278072704993834323UL];
            WeaponData_GetNameHash = (delegate* unmanaged[Cdecl]<uint, uint>) funcTable[13383509881679893265UL];
            WeaponData_GetPlayerDamageModifier = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[6850449658572044547UL];
            WeaponData_GetRange = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[15674881949419675123UL];
            WeaponData_GetRecoilAccuracyMax = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[5516024233113413457UL];
            WeaponData_GetRecoilAccuracyToAllowHeadshotPlayer = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[13726346651669483514UL];
            WeaponData_GetRecoilRecoveryRate = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[11665202374263940677UL];
            WeaponData_GetRecoilShakeAmplitude = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[8233583210732773759UL];
            WeaponData_GetTimeBetweenShots = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[10261116904358114950UL];
            WeaponData_GetVehicleReloadTime = (delegate* unmanaged[Cdecl]<uint, float>) funcTable[16091036566678053054UL];
            WeaponData_SetAccuracySpread = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[2613737423113370456UL];
            WeaponData_SetAnimReloadRate = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[4915557895075279816UL];
            WeaponData_SetDamage = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[17427083799982535623UL];
            WeaponData_SetHeadshotDamageModifier = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[2355528396046901504UL];
            WeaponData_SetLockOnRange = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[12045687920312066629UL];
            WeaponData_SetPlayerDamageModifier = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[15300169018667300527UL];
            WeaponData_SetRange = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[713592550431277335UL];
            WeaponData_SetRecoilAccuracyMax = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[17114686518385801125UL];
            WeaponData_SetRecoilAccuracyToAllowHeadshotPlayer = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[16236921157421742102UL];
            WeaponData_SetRecoilRecoveryRate = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[7351012088533086369UL];
            WeaponData_SetRecoilShakeAmplitude = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[17570987505440631811UL];
            WeaponData_SetVehicleReloadTime = (delegate* unmanaged[Cdecl]<uint, float, void>) funcTable[7198902818462088210UL];
            WebSocketClient_AddSubProtocol = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[3961992883077581219UL];
            WebSocketClient_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[14949720871466430310UL];
            WebSocketClient_GetPingInterval = (delegate* unmanaged[Cdecl]<nint, ushort>) funcTable[12773908850394117493UL];
            WebSocketClient_GetReadyState = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[16026093225715483724UL];
            WebSocketClient_GetSubProtocols = (delegate* unmanaged[Cdecl]<nint, uint*, nint>) funcTable[14734809972492421551UL];
            WebSocketClient_GetUrl = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[9959653516838593909UL];
            WebSocketClient_IsAutoReconnect = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[6298118548799262084UL];
            WebSocketClient_IsPerMessageDeflate = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[3928425054427750161UL];
            WebSocketClient_Send_Binary = (delegate* unmanaged[Cdecl]<nint, nint, uint, byte>) funcTable[7310308102899182334UL];
            WebSocketClient_Send_String = (delegate* unmanaged[Cdecl]<nint, nint, byte>) funcTable[2018807005983750854UL];
            WebSocketClient_SetAutoReconnect = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[8537464875508100220UL];
            WebSocketClient_SetExtraHeader = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[8894344070566607703UL];
            WebSocketClient_SetPerMessageDeflate = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[2310711047425432521UL];
            WebSocketClient_SetPingInterval = (delegate* unmanaged[Cdecl]<nint, ushort, void>) funcTable[18336829373356940433UL];
            WebSocketClient_SetUrl = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[12969001719297584385UL];
            WebSocketClient_Start = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[17682468416515600732UL];
            WebSocketClient_Stop = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[8800612367193848248UL];
            WebView_Focus = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[11547922272787924519UL];
            WebView_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) funcTable[2968282708276401205UL];
            WebView_GetPosition = (delegate* unmanaged[Cdecl]<nint, Vector2*, void>) funcTable[9654887934276909256UL];
            WebView_GetSize = (delegate* unmanaged[Cdecl]<nint, Vector2*, void>) funcTable[11195384541242827434UL];
            WebView_GetUrl = (delegate* unmanaged[Cdecl]<nint, int*, nint>) funcTable[13560098099783634684UL];
            WebView_IsFocused = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[245846713292397958UL];
            WebView_IsOverlay = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[8799882357637942207UL];
            WebView_IsVisible = (delegate* unmanaged[Cdecl]<nint, byte>) funcTable[12164031854344542229UL];
            WebView_SetExtraHeader = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) funcTable[15889823903084571218UL];
            WebView_SetIsVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) funcTable[14291631713216556967UL];
            WebView_SetPosition = (delegate* unmanaged[Cdecl]<nint, Vector2, void>) funcTable[12310068904464718844UL];
            WebView_SetSize = (delegate* unmanaged[Cdecl]<nint, Vector2, void>) funcTable[8369301594100020598UL];
            WebView_SetUrl = (delegate* unmanaged[Cdecl]<nint, nint, void>) funcTable[2862825641035231160UL];
            WebView_SetZoomLevel = (delegate* unmanaged[Cdecl]<nint, float, void>) funcTable[4109860120949142406UL];
            WebView_Unfocus = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[238745989994911666UL];
            Win_GetTaskDialog = (delegate* unmanaged[Cdecl]<nint>) funcTable[3417173460843507503UL];
        }
    }
}