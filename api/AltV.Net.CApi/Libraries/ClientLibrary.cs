// ReSharper disable InconsistentNaming
using AltV.Net.Data;
using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.CApi.Libraries
{
    public unsafe interface IClientLibrary
    {
        public bool Outdated { get; }
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
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, float, int, uint> AudioFilter_AddAutowahEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, int, float, float, float, float, float, int, uint> AudioFilter_AddBqfEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, float, int, uint> AudioFilter_AddChorusEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, int, uint> AudioFilter_AddCompressor2Effect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, int, uint> AudioFilter_AddDampEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, int, uint> AudioFilter_AddDistortionEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, int, uint> AudioFilter_AddEcho4Effect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, uint, int, uint> AudioFilter_AddFreeverbEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, int, float, float, float, float, int, uint> AudioFilter_AddPeakeqEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, float, int, uint> AudioFilter_AddPhaserEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, long, long, int, uint> AudioFilter_AddPitchshiftEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, int, uint> AudioFilter_AddRotateEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, int, uint> AudioFilter_AddVolumeEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> AudioFilter_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> AudioFilter_GetHash { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> AudioFilter_RemoveEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Blip_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Checkpoint_IsStreamedIn { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint, nint, void> Core_AddGXTText { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_AreGameControlsEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_AreRmlControlsEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_AreVoiceControlsEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_BeginScaleformMovieMethodMinimap { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_ClearFocusOverride { get; }
        public delegate* unmanaged[Cdecl]<nint, int, byte, void> Core_ClearPedProp { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint, uint*, nint> Core_Client_CreateAreaBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint, uint*, nint> Core_Client_CreatePointBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, nint, uint*, nint> Core_Client_CreateRadiusBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, byte> Core_Client_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, int*, nint> Core_Client_FileRead { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_CopyToClipboard { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, float, uint, byte, uint*, nint> Core_CreateAudio { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Vector3, Vector3, float, float, Rgba, uint, nint, uint*, nint> Core_CreateCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint*, nint> Core_CreateHttpClient { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, int, Vector3, Rotation, byte, uint, nint, uint*, nint> Core_CreateLocalPed { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, int, Vector3, Rotation, byte, uint, nint, uint*, nint> Core_CreateLocalVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Vector3, Rgba, nint, uint*, nint> Core_CreateMarker_Client { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, Vector3, Vector3, byte, byte, nint, ushort*, nint> Core_CreateObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, uint*, nint> Core_CreateRmlDocument { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, float, float, Vector3, Rotation, Rgba, float, Rgba, nint, uint*, nint> Core_CreateTextLabel { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, uint*, nint> Core_CreateWebsocketClient { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, Vector2, Vector2, byte, uint*, nint> Core_CreateWebView { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, uint, nint, uint*, nint> Core_CreateWebView3D { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocDiscordUser { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.DiscordOAuth2TokenResultModuleDelegate, void> Core_Discord_GetOAuth2Token { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_DoesConfigFlagExist { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Core_GetAudioCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, void> Core_GetAudios { get; }
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
        public delegate* unmanaged[Cdecl]<nint, int, ushort, Vector3*, void> Core_GetPedBonePos { get; }
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
        public delegate* unmanaged[Cdecl]<nint, ulong> Core_GetWebViewCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, void> Core_GetWebViews { get; }
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
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerServerEventUnreliable { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void> Core_TriggerWebViewEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_UnloadYtyp { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, Vector2*, void> Core_WorldToScreen { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Entity_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceErrorModuleDelegate, void> Event_SetAnyResourceErrorDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceStartModuleDelegate, void> Event_SetAnyResourceStartDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceStopModuleDelegate, void> Event_SetAnyResourceStopDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CheckpointModuleDelegate, void> Event_SetCheckpointDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ClientEventModuleDelegate, void> Event_SetClientEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ColShapeModuleDelegate, void> Event_SetColShapeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ConnectionCompleteModuleDelegate, void> Event_SetConnectionCompleteDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ConsoleCommandModuleDelegate, void> Event_SetConsoleCommandDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateBaseObjectModuleDelegate, void> Event_SetCreateBaseObjectDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityCreateModuleDelegate, void> Event_SetGameEntityCreateDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityDestroyModuleDelegate, void> Event_SetGameEntityDestroyDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalMetaChangeModuleDelegate, void> Event_SetGlobalMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalSyncedMetaChangeModuleDelegate, void> Event_SetGlobalSyncedMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void> Event_SetKeyDownDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void> Event_SetKeyUpDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.LocalMetaChangeModuleDelegate, void> Event_SetLocalMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.MetaChangeModuleDelegate, void> Event_SetMetaChangeDelegate { get; }
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
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveBaseObjectModuleDelegate, void> Event_SetRemoveBaseObjectDelegate { get; }
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
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WorldObjectPositionChangeModuleDelegate, void> Event_SetWorldObjectPositionChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WorldObjectStreamInModuleDelegate, void> Event_SetWorldObjectStreamInDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WorldObjectStreamOutModuleDelegate, void> Event_SetWorldObjectStreamOutDelegate { get; }
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
        public delegate* unmanaged[Cdecl]<nint, uint> LocalPed_GetRemoteID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalPed_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> LocalPed_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> LocalPed_IsStreamedIn { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetCurrentAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalPlayer_GetCurrentWeaponHash { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, float> LocalPlayer_GetMaxStamina { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, float> LocalPlayer_GetStamina { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, ushort> LocalPlayer_GetWeaponAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint*, uint*, void> LocalPlayer_GetWeaponComponents { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, uint*, void> LocalPlayer_GetWeapons { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> LocalPlayer_HasWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> LocalPlayer_SetMaxStamina { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> LocalPlayer_SetStamina { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Clear { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> LocalStorage_DeleteKey { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> LocalStorage_GetKey { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Save { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> LocalStorage_SetKey { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalVehicle_GetRemoteID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalVehicle_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> LocalVehicle_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> LocalVehicle_IsStreamedIn { get; }
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
        public delegate* unmanaged[Cdecl]<nint, uint> Marker_GetRemoteID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Marker_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsStreamedIn { get; }
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
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint> RmlElement_GetRmlId { get; }
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
        public delegate* unmanaged[Cdecl]<nint, uint> TextLabel_GetRemoteID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> TextLabel_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetAbsLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetBatteryLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetCurrentGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetCurrentRPM { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetEngineLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetEngineTemperature { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetFuelLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetLightsIndicator { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetOccupiedSeatsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetOilLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetOilLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetPetrolLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSeatCount { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_GetSpeedVector { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelCamber { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelRimRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetWheelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, uint> Vehicle_GetWheelSurfaceMaterial { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelTrackWidth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelTyreRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelTyreWidth { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsTaxiLightOn { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ResetDashboardLights { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ResetHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetAbsLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetBatteryLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetCurrentGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetCurrentRPM { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetEngineLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetEngineTemperature { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetFuelLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetLightsIndicator { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetOilLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetOilLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetPetrolLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetWheelCamber { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetWheelHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetWheelRimRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetWheelTrackWidth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetWheelTyreRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetWheelTyreWidth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_ToggleTaxiLight { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VirtualEntity_GetRemoteID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> VirtualEntity_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> VirtualEntity_IsStreamedIn { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VirtualEntityGroup_GetRemoteID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> VirtualEntityGroup_IsRemote { get; }
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
        public readonly uint Methods = 1493;
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
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, float, int, uint> AudioFilter_AddAutowahEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, int, float, float, float, float, float, int, uint> AudioFilter_AddBqfEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, float, int, uint> AudioFilter_AddChorusEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, int, uint> AudioFilter_AddCompressor2Effect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, int, uint> AudioFilter_AddDampEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, int, uint> AudioFilter_AddDistortionEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, int, uint> AudioFilter_AddEcho4Effect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, uint, int, uint> AudioFilter_AddFreeverbEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, int, float, float, float, float, int, uint> AudioFilter_AddPeakeqEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, float, int, uint> AudioFilter_AddPhaserEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, float, long, long, int, uint> AudioFilter_AddPitchshiftEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, int, uint> AudioFilter_AddRotateEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, float, int, uint> AudioFilter_AddVolumeEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> AudioFilter_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> AudioFilter_GetHash { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> AudioFilter_RemoveEffect { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Blip_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Blip_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Checkpoint_IsStreamedIn { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint, nint, void> Core_AddGXTText { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_AreGameControlsEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_AreRmlControlsEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_AreVoiceControlsEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_BeginScaleformMovieMethodMinimap { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_ClearFocusOverride { get; }
        public delegate* unmanaged[Cdecl]<nint, int, byte, void> Core_ClearPedProp { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint, uint*, nint> Core_Client_CreateAreaBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint, uint*, nint> Core_Client_CreatePointBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, nint, uint*, nint> Core_Client_CreateRadiusBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, byte> Core_Client_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, int*, nint> Core_Client_FileRead { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_CopyToClipboard { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, float, uint, byte, uint*, nint> Core_CreateAudio { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Vector3, Vector3, float, float, Rgba, uint, nint, uint*, nint> Core_CreateCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint*, nint> Core_CreateHttpClient { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, int, Vector3, Rotation, byte, uint, nint, uint*, nint> Core_CreateLocalPed { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, int, Vector3, Rotation, byte, uint, nint, uint*, nint> Core_CreateLocalVehicle { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Vector3, Rgba, nint, uint*, nint> Core_CreateMarker_Client { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, Vector3, Vector3, byte, byte, nint, ushort*, nint> Core_CreateObject { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, uint*, nint> Core_CreateRmlDocument { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, float, float, Vector3, Rotation, Rgba, float, Rgba, nint, uint*, nint> Core_CreateTextLabel { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, uint*, nint> Core_CreateWebsocketClient { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, Vector2, Vector2, byte, uint*, nint> Core_CreateWebView { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, uint, nint, uint*, nint> Core_CreateWebView3D { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocDiscordUser { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.DiscordOAuth2TokenResultModuleDelegate, void> Core_Discord_GetOAuth2Token { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_DoesConfigFlagExist { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> Core_GetAudioCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, void> Core_GetAudios { get; }
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
        public delegate* unmanaged[Cdecl]<nint, int, ushort, Vector3*, void> Core_GetPedBonePos { get; }
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
        public delegate* unmanaged[Cdecl]<nint, ulong> Core_GetWebViewCount { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, void> Core_GetWebViews { get; }
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
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerServerEventUnreliable { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void> Core_TriggerWebViewEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_UnloadYtyp { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, Vector2*, void> Core_WorldToScreen { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Entity_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceErrorModuleDelegate, void> Event_SetAnyResourceErrorDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceStartModuleDelegate, void> Event_SetAnyResourceStartDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceStopModuleDelegate, void> Event_SetAnyResourceStopDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CheckpointModuleDelegate, void> Event_SetCheckpointDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ClientEventModuleDelegate, void> Event_SetClientEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ColShapeModuleDelegate, void> Event_SetColShapeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ConnectionCompleteModuleDelegate, void> Event_SetConnectionCompleteDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ConsoleCommandModuleDelegate, void> Event_SetConsoleCommandDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateBaseObjectModuleDelegate, void> Event_SetCreateBaseObjectDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityCreateModuleDelegate, void> Event_SetGameEntityCreateDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityDestroyModuleDelegate, void> Event_SetGameEntityDestroyDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalMetaChangeModuleDelegate, void> Event_SetGlobalMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalSyncedMetaChangeModuleDelegate, void> Event_SetGlobalSyncedMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void> Event_SetKeyDownDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void> Event_SetKeyUpDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.LocalMetaChangeModuleDelegate, void> Event_SetLocalMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.MetaChangeModuleDelegate, void> Event_SetMetaChangeDelegate { get; }
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
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveBaseObjectModuleDelegate, void> Event_SetRemoveBaseObjectDelegate { get; }
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
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WorldObjectPositionChangeModuleDelegate, void> Event_SetWorldObjectPositionChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WorldObjectStreamInModuleDelegate, void> Event_SetWorldObjectStreamInDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WorldObjectStreamOutModuleDelegate, void> Event_SetWorldObjectStreamOutDelegate { get; }
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
        public delegate* unmanaged[Cdecl]<nint, uint> LocalPed_GetRemoteID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalPed_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> LocalPed_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> LocalPed_IsStreamedIn { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetCurrentAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalPlayer_GetCurrentWeaponHash { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, float> LocalPlayer_GetMaxStamina { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, float> LocalPlayer_GetStamina { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, ushort> LocalPlayer_GetWeaponAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint*, uint*, void> LocalPlayer_GetWeaponComponents { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, uint*, void> LocalPlayer_GetWeapons { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> LocalPlayer_HasWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> LocalPlayer_SetMaxStamina { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> LocalPlayer_SetStamina { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Clear { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> LocalStorage_DeleteKey { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> LocalStorage_GetKey { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Save { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> LocalStorage_SetKey { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalVehicle_GetRemoteID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> LocalVehicle_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> LocalVehicle_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> LocalVehicle_IsStreamedIn { get; }
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
        public delegate* unmanaged[Cdecl]<nint, uint> Marker_GetRemoteID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Marker_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Object_IsStreamedIn { get; }
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
        public delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint> RmlElement_GetRmlId { get; }
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
        public delegate* unmanaged[Cdecl]<nint, uint> TextLabel_GetRemoteID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> TextLabel_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetAbsLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetBatteryLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetCurrentGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetCurrentRPM { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetEngineLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetEngineTemperature { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetFuelLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetLightsIndicator { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetOccupiedSeatsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetOilLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetOilLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetPetrolLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSeatCount { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_GetSpeedVector { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelCamber { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelRimRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetWheelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, uint> Vehicle_GetWheelSurfaceMaterial { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelTrackWidth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelTyreRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float> Vehicle_GetWheelTyreWidth { get; }
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
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsTaxiLightOn { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ResetDashboardLights { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ResetHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetAbsLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetBatteryLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetCurrentGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetCurrentRPM { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetEngineLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetEngineTemperature { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetFuelLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetLightsIndicator { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_SetOilLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetOilLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetPetrolLightState { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetWheelCamber { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetWheelHeight { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetWheelRimRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetWheelTrackWidth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetWheelTyreRadius { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, float, void> Vehicle_SetWheelTyreWidth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_ToggleTaxiLight { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VirtualEntity_GetRemoteID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> VirtualEntity_IsRemote { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> VirtualEntity_IsStreamedIn { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> VirtualEntityGroup_GetRemoteID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> VirtualEntityGroup_IsRemote { get; }
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
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Audio_AddOutput_EntityDelegate(nint _audio, nint _value);
        private static void Audio_AddOutput_EntityFallback(nint _audio, nint _value) => throw new Exceptions.OutdatedSdkException("Audio_AddOutput_Entity", "Audio_AddOutput_Entity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Audio_AddOutput_ScriptIdDelegate(nint _audio, uint _value);
        private static void Audio_AddOutput_ScriptIdFallback(nint _audio, uint _value) => throw new Exceptions.OutdatedSdkException("Audio_AddOutput_ScriptId", "Audio_AddOutput_ScriptId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Audio_GetBaseObjectDelegate(nint _audio);
        private static nint Audio_GetBaseObjectFallback(nint _audio) => throw new Exceptions.OutdatedSdkException("Audio_GetBaseObject", "Audio_GetBaseObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Audio_GetCategoryDelegate(nint _audio);
        private static uint Audio_GetCategoryFallback(nint _audio) => throw new Exceptions.OutdatedSdkException("Audio_GetCategory", "Audio_GetCategory SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate double Audio_GetCurrentTimeDelegate(nint _audio);
        private static double Audio_GetCurrentTimeFallback(nint _audio) => throw new Exceptions.OutdatedSdkException("Audio_GetCurrentTime", "Audio_GetCurrentTime SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Audio_GetLoopedDelegate(nint _audio);
        private static byte Audio_GetLoopedFallback(nint _audio) => throw new Exceptions.OutdatedSdkException("Audio_GetLooped", "Audio_GetLooped SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate double Audio_GetMaxTimeDelegate(nint _audio);
        private static double Audio_GetMaxTimeFallback(nint _audio) => throw new Exceptions.OutdatedSdkException("Audio_GetMaxTime", "Audio_GetMaxTime SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Audio_GetOutputsDelegate(nint _audio, nint* _entityArray, nint* _entityTypesArray, nint* _scriptIdArray, uint* _size);
        private static void Audio_GetOutputsFallback(nint _audio, nint* _entityArray, nint* _entityTypesArray, nint* _scriptIdArray, uint* _size) => throw new Exceptions.OutdatedSdkException("Audio_GetOutputs", "Audio_GetOutputs SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Audio_GetSourceDelegate(nint _audio, int* _size);
        private static nint Audio_GetSourceFallback(nint _audio, int* _size) => throw new Exceptions.OutdatedSdkException("Audio_GetSource", "Audio_GetSource SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Audio_GetVolumeDelegate(nint _audio);
        private static float Audio_GetVolumeFallback(nint _audio) => throw new Exceptions.OutdatedSdkException("Audio_GetVolume", "Audio_GetVolume SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Audio_IsFrontendPlayDelegate(nint _audio);
        private static byte Audio_IsFrontendPlayFallback(nint _audio) => throw new Exceptions.OutdatedSdkException("Audio_IsFrontendPlay", "Audio_IsFrontendPlay SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Audio_IsPlayingDelegate(nint _audio);
        private static byte Audio_IsPlayingFallback(nint _audio) => throw new Exceptions.OutdatedSdkException("Audio_IsPlaying", "Audio_IsPlaying SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Audio_PauseDelegate(nint _audio);
        private static void Audio_PauseFallback(nint _audio) => throw new Exceptions.OutdatedSdkException("Audio_Pause", "Audio_Pause SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Audio_PlayDelegate(nint _audio);
        private static void Audio_PlayFallback(nint _audio) => throw new Exceptions.OutdatedSdkException("Audio_Play", "Audio_Play SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Audio_RemoveOutput_EntityDelegate(nint _audio, nint _value);
        private static void Audio_RemoveOutput_EntityFallback(nint _audio, nint _value) => throw new Exceptions.OutdatedSdkException("Audio_RemoveOutput_Entity", "Audio_RemoveOutput_Entity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Audio_RemoveOutput_ScriptIdDelegate(nint _audio, uint _value);
        private static void Audio_RemoveOutput_ScriptIdFallback(nint _audio, uint _value) => throw new Exceptions.OutdatedSdkException("Audio_RemoveOutput_ScriptId", "Audio_RemoveOutput_ScriptId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Audio_ResetDelegate(nint _audio);
        private static void Audio_ResetFallback(nint _audio) => throw new Exceptions.OutdatedSdkException("Audio_Reset", "Audio_Reset SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Audio_SeekDelegate(nint _audio, double _time);
        private static void Audio_SeekFallback(nint _audio, double _time) => throw new Exceptions.OutdatedSdkException("Audio_Seek", "Audio_Seek SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Audio_SetCategoryDelegate(nint _audio, uint _value);
        private static void Audio_SetCategoryFallback(nint _audio, uint _value) => throw new Exceptions.OutdatedSdkException("Audio_SetCategory", "Audio_SetCategory SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Audio_SetLoopedDelegate(nint _audio, byte _value);
        private static void Audio_SetLoopedFallback(nint _audio, byte _value) => throw new Exceptions.OutdatedSdkException("Audio_SetLooped", "Audio_SetLooped SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Audio_SetSourceDelegate(nint _audio, nint _source);
        private static void Audio_SetSourceFallback(nint _audio, nint _source) => throw new Exceptions.OutdatedSdkException("Audio_SetSource", "Audio_SetSource SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Audio_SetVolumeDelegate(nint _audio, float _value);
        private static void Audio_SetVolumeFallback(nint _audio, float _value) => throw new Exceptions.OutdatedSdkException("Audio_SetVolume", "Audio_SetVolume SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint AudioFilter_AddAutowahEffectDelegate(nint _audioFilter, float _dryMix, float _wetMix, float _feedback, float _rate, float _range, float _freq, int _priority);
        private static uint AudioFilter_AddAutowahEffectFallback(nint _audioFilter, float _dryMix, float _wetMix, float _feedback, float _rate, float _range, float _freq, int _priority) => throw new Exceptions.OutdatedSdkException("AudioFilter_AddAutowahEffect", "AudioFilter_AddAutowahEffect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint AudioFilter_AddBqfEffectDelegate(nint _audioFilter, int _lFilter, float _center, float _gain, float _bandwidth, float _q, float _s, int _priority);
        private static uint AudioFilter_AddBqfEffectFallback(nint _audioFilter, int _lFilter, float _center, float _gain, float _bandwidth, float _q, float _s, int _priority) => throw new Exceptions.OutdatedSdkException("AudioFilter_AddBqfEffect", "AudioFilter_AddBqfEffect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint AudioFilter_AddChorusEffectDelegate(nint _audioFilter, float _dryMix, float _wetMix, float _feedback, float _minSweep, float _maxSweep, float _rate, int _priority);
        private static uint AudioFilter_AddChorusEffectFallback(nint _audioFilter, float _dryMix, float _wetMix, float _feedback, float _minSweep, float _maxSweep, float _rate, int _priority) => throw new Exceptions.OutdatedSdkException("AudioFilter_AddChorusEffect", "AudioFilter_AddChorusEffect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint AudioFilter_AddCompressor2EffectDelegate(nint _audioFilter, float _gain, float _threshold, float _ratio, float _attack, float _release, int _priority);
        private static uint AudioFilter_AddCompressor2EffectFallback(nint _audioFilter, float _gain, float _threshold, float _ratio, float _attack, float _release, int _priority) => throw new Exceptions.OutdatedSdkException("AudioFilter_AddCompressor2Effect", "AudioFilter_AddCompressor2Effect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint AudioFilter_AddDampEffectDelegate(nint _audioFilter, float _target, float _quiet, float _rate, float _gain, float _delay, int _priority);
        private static uint AudioFilter_AddDampEffectFallback(nint _audioFilter, float _target, float _quiet, float _rate, float _gain, float _delay, int _priority) => throw new Exceptions.OutdatedSdkException("AudioFilter_AddDampEffect", "AudioFilter_AddDampEffect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint AudioFilter_AddDistortionEffectDelegate(nint _audioFilter, float _drive, float _dryMix, float _wetMix, float _feedback, float _volume, int _priority);
        private static uint AudioFilter_AddDistortionEffectFallback(nint _audioFilter, float _drive, float _dryMix, float _wetMix, float _feedback, float _volume, int _priority) => throw new Exceptions.OutdatedSdkException("AudioFilter_AddDistortionEffect", "AudioFilter_AddDistortionEffect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint AudioFilter_AddEcho4EffectDelegate(nint _audioFilter, float _dryMix, float _wetMix, float _feedback, float _delay, int _priority);
        private static uint AudioFilter_AddEcho4EffectFallback(nint _audioFilter, float _dryMix, float _wetMix, float _feedback, float _delay, int _priority) => throw new Exceptions.OutdatedSdkException("AudioFilter_AddEcho4Effect", "AudioFilter_AddEcho4Effect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint AudioFilter_AddFreeverbEffectDelegate(nint _audioFilter, float _dryMix, float _wetMix, float _roomSize, float _damp, float _width, uint _lMode, int _priority);
        private static uint AudioFilter_AddFreeverbEffectFallback(nint _audioFilter, float _dryMix, float _wetMix, float _roomSize, float _damp, float _width, uint _lMode, int _priority) => throw new Exceptions.OutdatedSdkException("AudioFilter_AddFreeverbEffect", "AudioFilter_AddFreeverbEffect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint AudioFilter_AddPeakeqEffectDelegate(nint _audioFilter, int _lBand, float _bandwidth, float _q, float _center, float _gain, int _priority);
        private static uint AudioFilter_AddPeakeqEffectFallback(nint _audioFilter, int _lBand, float _bandwidth, float _q, float _center, float _gain, int _priority) => throw new Exceptions.OutdatedSdkException("AudioFilter_AddPeakeqEffect", "AudioFilter_AddPeakeqEffect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint AudioFilter_AddPhaserEffectDelegate(nint _audioFilter, float _dryMix, float _wetMix, float _feedback, float _rate, float _range, float _freq, int _priority);
        private static uint AudioFilter_AddPhaserEffectFallback(nint _audioFilter, float _dryMix, float _wetMix, float _feedback, float _rate, float _range, float _freq, int _priority) => throw new Exceptions.OutdatedSdkException("AudioFilter_AddPhaserEffect", "AudioFilter_AddPhaserEffect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint AudioFilter_AddPitchshiftEffectDelegate(nint _audioFilter, float _pitchShift, float _semitones, long _lFFTsize, long _lOsamp, int _priority);
        private static uint AudioFilter_AddPitchshiftEffectFallback(nint _audioFilter, float _pitchShift, float _semitones, long _lFFTsize, long _lOsamp, int _priority) => throw new Exceptions.OutdatedSdkException("AudioFilter_AddPitchshiftEffect", "AudioFilter_AddPitchshiftEffect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint AudioFilter_AddRotateEffectDelegate(nint _audioFilter, float _rate, int _priority);
        private static uint AudioFilter_AddRotateEffectFallback(nint _audioFilter, float _rate, int _priority) => throw new Exceptions.OutdatedSdkException("AudioFilter_AddRotateEffect", "AudioFilter_AddRotateEffect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint AudioFilter_AddVolumeEffectDelegate(nint _audioFilter, float _volume, int _priority);
        private static uint AudioFilter_AddVolumeEffectFallback(nint _audioFilter, float _volume, int _priority) => throw new Exceptions.OutdatedSdkException("AudioFilter_AddVolumeEffect", "AudioFilter_AddVolumeEffect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint AudioFilter_GetBaseObjectDelegate(nint _audioFilter);
        private static nint AudioFilter_GetBaseObjectFallback(nint _audioFilter) => throw new Exceptions.OutdatedSdkException("AudioFilter_GetBaseObject", "AudioFilter_GetBaseObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint AudioFilter_GetHashDelegate(nint _audioFilter);
        private static uint AudioFilter_GetHashFallback(nint _audioFilter) => throw new Exceptions.OutdatedSdkException("AudioFilter_GetHash", "AudioFilter_GetHash SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte AudioFilter_RemoveEffectDelegate(nint _audioFilter, uint _hfxHandler);
        private static byte AudioFilter_RemoveEffectFallback(nint _audioFilter, uint _hfxHandler) => throw new Exceptions.OutdatedSdkException("AudioFilter_RemoveEffect", "AudioFilter_RemoveEffect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Blip_GetScriptIDDelegate(nint _blip);
        private static uint Blip_GetScriptIDFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_GetScriptID", "Blip_GetScriptID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Blip_IsRemoteDelegate(nint _blip);
        private static byte Blip_IsRemoteFallback(nint _blip) => throw new Exceptions.OutdatedSdkException("Blip_IsRemote", "Blip_IsRemote SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Checkpoint_IsStreamedInDelegate(nint _checkpoint);
        private static byte Checkpoint_IsStreamedInFallback(nint _checkpoint) => throw new Exceptions.OutdatedSdkException("Checkpoint_IsStreamedIn", "Checkpoint_IsStreamedIn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_AddGXTTextDelegate(nint _core, nint _resource, uint _key, nint _value);
        private static void Core_AddGXTTextFallback(nint _core, nint _resource, uint _key, nint _value) => throw new Exceptions.OutdatedSdkException("Core_AddGXTText", "Core_AddGXTText SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_AreGameControlsEnabledDelegate(nint _core);
        private static byte Core_AreGameControlsEnabledFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_AreGameControlsEnabled", "Core_AreGameControlsEnabled SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_AreRmlControlsEnabledDelegate(nint _core);
        private static byte Core_AreRmlControlsEnabledFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_AreRmlControlsEnabled", "Core_AreRmlControlsEnabled SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_AreVoiceControlsEnabledDelegate(nint _core);
        private static byte Core_AreVoiceControlsEnabledFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_AreVoiceControlsEnabled", "Core_AreVoiceControlsEnabled SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_BeginScaleformMovieMethodMinimapDelegate(nint _core, nint _methodName);
        private static byte Core_BeginScaleformMovieMethodMinimapFallback(nint _core, nint _methodName) => throw new Exceptions.OutdatedSdkException("Core_BeginScaleformMovieMethodMinimap", "Core_BeginScaleformMovieMethodMinimap SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_ClearFocusOverrideDelegate(nint _core);
        private static void Core_ClearFocusOverrideFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_ClearFocusOverride", "Core_ClearFocusOverride SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_ClearPedPropDelegate(nint _core, int _scriptID, byte _component);
        private static void Core_ClearPedPropFallback(nint _core, int _scriptID, byte _component) => throw new Exceptions.OutdatedSdkException("Core_ClearPedProp", "Core_ClearPedProp SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_Client_CreateAreaBlipDelegate(nint _core, Vector3 _position, float _width, float _height, nint _resource, uint* _id);
        private static nint Core_Client_CreateAreaBlipFallback(nint _core, Vector3 _position, float _width, float _height, nint _resource, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_Client_CreateAreaBlip", "Core_Client_CreateAreaBlip SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_Client_CreatePointBlipDelegate(nint _core, Vector3 _position, nint _resource, uint* _id);
        private static nint Core_Client_CreatePointBlipFallback(nint _core, Vector3 _position, nint _resource, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_Client_CreatePointBlip", "Core_Client_CreatePointBlip SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_Client_CreateRadiusBlipDelegate(nint _core, Vector3 _position, float _radius, nint _resource, uint* _id);
        private static nint Core_Client_CreateRadiusBlipFallback(nint _core, Vector3 _position, float _radius, nint _resource, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_Client_CreateRadiusBlip", "Core_Client_CreateRadiusBlip SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_Client_FileExistsDelegate(nint _core, nint _resource, nint _path);
        private static byte Core_Client_FileExistsFallback(nint _core, nint _resource, nint _path) => throw new Exceptions.OutdatedSdkException("Core_Client_FileExists", "Core_Client_FileExists SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_Client_FileReadDelegate(nint _core, nint _resource, nint _path, int* _size);
        private static nint Core_Client_FileReadFallback(nint _core, nint _resource, nint _path, int* _size) => throw new Exceptions.OutdatedSdkException("Core_Client_FileRead", "Core_Client_FileRead SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_CopyToClipboardDelegate(nint _core, nint _value);
        private static byte Core_CopyToClipboardFallback(nint _core, nint _value) => throw new Exceptions.OutdatedSdkException("Core_CopyToClipboard", "Core_CopyToClipboard SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateAudioDelegate(nint _core, nint _resource, nint _source, float _volume, uint _category, byte _frontend, uint* _id);
        private static nint Core_CreateAudioFallback(nint _core, nint _resource, nint _source, float _volume, uint _category, byte _frontend, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateAudio", "Core_CreateAudio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateCheckpointDelegate(nint _server, byte _type, Vector3 _pos, Vector3 _nextPos, float _radius, float _height, Rgba _color, uint _streamingDistance, nint _resource, uint* _id);
        private static nint Core_CreateCheckpointFallback(nint _server, byte _type, Vector3 _pos, Vector3 _nextPos, float _radius, float _height, Rgba _color, uint _streamingDistance, nint _resource, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateCheckpoint", "Core_CreateCheckpoint SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateHttpClientDelegate(nint _core, nint _resource, uint* _id);
        private static nint Core_CreateHttpClientFallback(nint _core, nint _resource, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateHttpClient", "Core_CreateHttpClient SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateLocalPedDelegate(nint _core, uint _modelHash, int _dimension, Vector3 _pos, Rotation _rot, byte _useStreaming, uint _streamingDistance, nint _resource, uint* _id);
        private static nint Core_CreateLocalPedFallback(nint _core, uint _modelHash, int _dimension, Vector3 _pos, Rotation _rot, byte _useStreaming, uint _streamingDistance, nint _resource, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateLocalPed", "Core_CreateLocalPed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateLocalVehicleDelegate(nint _core, uint _modelHash, int _dimension, Vector3 _pos, Rotation _rot, byte _useStreaming, uint _streamingDistance, nint _resource, uint* _id);
        private static nint Core_CreateLocalVehicleFallback(nint _core, uint _modelHash, int _dimension, Vector3 _pos, Rotation _rot, byte _useStreaming, uint _streamingDistance, nint _resource, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateLocalVehicle", "Core_CreateLocalVehicle SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateMarker_ClientDelegate(nint _core, byte _type, Vector3 _pos, Rgba _color, nint _resource, uint* _id);
        private static nint Core_CreateMarker_ClientFallback(nint _core, byte _type, Vector3 _pos, Rgba _color, nint _resource, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateMarker_Client", "Core_CreateMarker_Client SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateObjectDelegate(nint _core, uint _modelHash, Vector3 _position, Vector3 _rot, byte _noOffset, byte _dynamic, nint _resource, ushort* _id);
        private static nint Core_CreateObjectFallback(nint _core, uint _modelHash, Vector3 _position, Vector3 _rot, byte _noOffset, byte _dynamic, nint _resource, ushort* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateObject", "Core_CreateObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateRmlDocumentDelegate(nint _core, nint _resource, nint _url, uint* _id);
        private static nint Core_CreateRmlDocumentFallback(nint _core, nint _resource, nint _url, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateRmlDocument", "Core_CreateRmlDocument SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateTextLabelDelegate(nint _core, nint _text, nint _fontName, float _fontSize, float _scale, Vector3 _pos, Rotation _rot, Rgba _color, float _outlineWith, Rgba _outlineColor, nint _resource, uint* _id);
        private static nint Core_CreateTextLabelFallback(nint _core, nint _text, nint _fontName, float _fontSize, float _scale, Vector3 _pos, Rotation _rot, Rgba _color, float _outlineWith, Rgba _outlineColor, nint _resource, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateTextLabel", "Core_CreateTextLabel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateWebsocketClientDelegate(nint _core, nint _resource, nint _url, uint* _id);
        private static nint Core_CreateWebsocketClientFallback(nint _core, nint _resource, nint _url, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateWebsocketClient", "Core_CreateWebsocketClient SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateWebViewDelegate(nint _core, nint _resource, nint _url, Vector2 _pos, Vector2 _size, byte _isOverlay, uint* _id);
        private static nint Core_CreateWebViewFallback(nint _core, nint _resource, nint _url, Vector2 _pos, Vector2 _size, byte _isOverlay, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateWebView", "Core_CreateWebView SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_CreateWebView3DDelegate(nint _core, nint _resource, nint _url, uint _hash, nint _targetTexture, uint* _id);
        private static nint Core_CreateWebView3DFallback(nint _core, nint _resource, nint _url, uint _hash, nint _targetTexture, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_CreateWebView3D", "Core_CreateWebView3D SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_DeallocDiscordUserDelegate(nint _user);
        private static void Core_DeallocDiscordUserFallback(nint _user) => throw new Exceptions.OutdatedSdkException("Core_DeallocDiscordUser", "Core_DeallocDiscordUser SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_Discord_GetOAuth2TokenDelegate(nint _core, nint _appId, ClientEvents.DiscordOAuth2TokenResultModuleDelegate _delegate);
        private static void Core_Discord_GetOAuth2TokenFallback(nint _core, nint _appId, ClientEvents.DiscordOAuth2TokenResultModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Core_Discord_GetOAuth2Token", "Core_Discord_GetOAuth2Token SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_DoesConfigFlagExistDelegate(nint _core, nint _flag);
        private static byte Core_DoesConfigFlagExistFallback(nint _core, nint _flag) => throw new Exceptions.OutdatedSdkException("Core_DoesConfigFlagExist", "Core_DoesConfigFlagExist SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong Core_GetAudioCountDelegate(nint _core);
        private static ulong Core_GetAudioCountFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_GetAudioCount", "Core_GetAudioCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_GetAudiosDelegate(nint _core, nint[] audios, ulong _size);
        private static void Core_GetAudiosFallback(nint _core, nint[] audios, ulong _size) => throw new Exceptions.OutdatedSdkException("Core_GetAudios", "Core_GetAudios SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_GetCamPosDelegate(nint _core, Vector3* _out);
        private static void Core_GetCamPosFallback(nint _core, Vector3* _out) => throw new Exceptions.OutdatedSdkException("Core_GetCamPos", "Core_GetCamPos SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetClientPathDelegate(nint _core, int* _size);
        private static nint Core_GetClientPathFallback(nint _core, int* _size) => throw new Exceptions.OutdatedSdkException("Core_GetClientPath", "Core_GetClientPath SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_GetConfigFlagDelegate(nint _core, nint _flag);
        private static byte Core_GetConfigFlagFallback(nint _core, nint _flag) => throw new Exceptions.OutdatedSdkException("Core_GetConfigFlag", "Core_GetConfigFlag SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_GetCursorPosDelegate(nint _core, Vector2* _out, byte _normalized);
        private static void Core_GetCursorPosFallback(nint _core, Vector2* _out, byte _normalized) => throw new Exceptions.OutdatedSdkException("Core_GetCursorPos", "Core_GetCursorPos SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetDiscordUserDelegate(nint _core);
        private static nint Core_GetDiscordUserFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_GetDiscordUser", "Core_GetDiscordUser SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetFocusOverrideEntityDelegate(nint _core, byte* _type);
        private static nint Core_GetFocusOverrideEntityFallback(nint _core, byte* _type) => throw new Exceptions.OutdatedSdkException("Core_GetFocusOverrideEntity", "Core_GetFocusOverrideEntity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_GetFocusOverrideOffsetDelegate(nint _core, Vector3* _offset);
        private static void Core_GetFocusOverrideOffsetFallback(nint _core, Vector3* _offset) => throw new Exceptions.OutdatedSdkException("Core_GetFocusOverrideOffset", "Core_GetFocusOverrideOffset SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_GetFocusOverridePosDelegate(nint _core, Vector3* _pos);
        private static void Core_GetFocusOverridePosFallback(nint _core, Vector3* _pos) => throw new Exceptions.OutdatedSdkException("Core_GetFocusOverridePos", "Core_GetFocusOverridePos SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Core_GetFPSDelegate(nint _core);
        private static ushort Core_GetFPSFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_GetFPS", "Core_GetFPS SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetGXTTextDelegate(nint _core, nint _resource, uint _key, int* _size);
        private static nint Core_GetGXTTextFallback(nint _core, nint _resource, uint _key, int* _size) => throw new Exceptions.OutdatedSdkException("Core_GetGXTText", "Core_GetGXTText SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetHeadshotBase64Delegate(nint _core, byte _id, int* _size);
        private static nint Core_GetHeadshotBase64Fallback(nint _core, byte _id, int* _size) => throw new Exceptions.OutdatedSdkException("Core_GetHeadshotBase64", "Core_GetHeadshotBase64 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetLicenseHashDelegate(nint _core, int* _size);
        private static nint Core_GetLicenseHashFallback(nint _core, int* _size) => throw new Exceptions.OutdatedSdkException("Core_GetLicenseHash", "Core_GetLicenseHash SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetLocaleDelegate(nint _core, int* _size);
        private static nint Core_GetLocaleFallback(nint _core, int* _size) => throw new Exceptions.OutdatedSdkException("Core_GetLocale", "Core_GetLocale SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetLocalMetaDelegate(nint _core, nint _key);
        private static nint Core_GetLocalMetaFallback(nint _core, nint _key) => throw new Exceptions.OutdatedSdkException("Core_GetLocalMeta", "Core_GetLocalMeta SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetMapZoomDataByAliasDelegate(nint _core, nint _alias, uint* _id);
        private static nint Core_GetMapZoomDataByAliasFallback(nint _core, nint _alias, uint* _id) => throw new Exceptions.OutdatedSdkException("Core_GetMapZoomDataByAlias", "Core_GetMapZoomDataByAlias SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate int Core_GetMsPerGameMinuteDelegate(nint _core);
        private static int Core_GetMsPerGameMinuteFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_GetMsPerGameMinute", "Core_GetMsPerGameMinute SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetObjectsDelegate(nint _core, uint* _size);
        private static nint Core_GetObjectsFallback(nint _core, uint* _size) => throw new Exceptions.OutdatedSdkException("Core_GetObjects", "Core_GetObjects SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_GetPedBonePosDelegate(nint _core, int _scriptId, ushort _boneId, Vector3* _pos);
        private static void Core_GetPedBonePosFallback(nint _core, int _scriptId, ushort _boneId, Vector3* _pos) => throw new Exceptions.OutdatedSdkException("Core_GetPedBonePos", "Core_GetPedBonePos SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_GetPermissionStateDelegate(nint _core, byte _permission);
        private static byte Core_GetPermissionStateFallback(nint _core, byte _permission) => throw new Exceptions.OutdatedSdkException("Core_GetPermissionState", "Core_GetPermissionState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Core_GetPingDelegate(nint _core);
        private static ushort Core_GetPingFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_GetPing", "Core_GetPing SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_GetScreenResolutionDelegate(nint _core, Vector2* _out);
        private static void Core_GetScreenResolutionFallback(nint _core, Vector2* _out) => throw new Exceptions.OutdatedSdkException("Core_GetScreenResolution", "Core_GetScreenResolution SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetServerIpDelegate(nint _core, int* _size);
        private static nint Core_GetServerIpFallback(nint _core, int* _size) => throw new Exceptions.OutdatedSdkException("Core_GetServerIp", "Core_GetServerIp SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Core_GetServerPortDelegate(nint _core);
        private static ushort Core_GetServerPortFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_GetServerPort", "Core_GetServerPort SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_GetStatBoolDelegate(nint _core, nint _stat);
        private static byte Core_GetStatBoolFallback(nint _core, nint _stat) => throw new Exceptions.OutdatedSdkException("Core_GetStatBool", "Core_GetStatBool SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetStatDataDelegate(nint _core, nint _stat);
        private static nint Core_GetStatDataFallback(nint _core, nint _stat) => throw new Exceptions.OutdatedSdkException("Core_GetStatData", "Core_GetStatData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Core_GetStatFloatDelegate(nint _core, nint _stat);
        private static float Core_GetStatFloatFallback(nint _core, nint _stat) => throw new Exceptions.OutdatedSdkException("Core_GetStatFloat", "Core_GetStatFloat SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate int Core_GetStatIntDelegate(nint _core, nint _stat);
        private static int Core_GetStatIntFallback(nint _core, nint _stat) => throw new Exceptions.OutdatedSdkException("Core_GetStatInt", "Core_GetStatInt SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate long Core_GetStatLongDelegate(nint _core, nint _stat);
        private static long Core_GetStatLongFallback(nint _core, nint _stat) => throw new Exceptions.OutdatedSdkException("Core_GetStatLong", "Core_GetStatLong SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetStatStringDelegate(nint _core, nint _stat, int* _size);
        private static nint Core_GetStatStringFallback(nint _core, nint _stat, int* _size) => throw new Exceptions.OutdatedSdkException("Core_GetStatString", "Core_GetStatString SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetStatTypeDelegate(nint _core, nint _stat, int* _size);
        private static nint Core_GetStatTypeFallback(nint _core, nint _stat, int* _size) => throw new Exceptions.OutdatedSdkException("Core_GetStatType", "Core_GetStatType SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Core_GetStatUInt16Delegate(nint _core, nint _stat);
        private static ushort Core_GetStatUInt16Fallback(nint _core, nint _stat) => throw new Exceptions.OutdatedSdkException("Core_GetStatUInt16", "Core_GetStatUInt16 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Core_GetStatUInt32Delegate(nint _core, nint _stat);
        private static uint Core_GetStatUInt32Fallback(nint _core, nint _stat) => throw new Exceptions.OutdatedSdkException("Core_GetStatUInt32", "Core_GetStatUInt32 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong Core_GetStatUInt64Delegate(nint _core, nint _stat);
        private static ulong Core_GetStatUInt64Fallback(nint _core, nint _stat) => throw new Exceptions.OutdatedSdkException("Core_GetStatUInt64", "Core_GetStatUInt64 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_GetStatUInt8Delegate(nint _core, nint _stat);
        private static byte Core_GetStatUInt8Fallback(nint _core, nint _stat) => throw new Exceptions.OutdatedSdkException("Core_GetStatUInt8", "Core_GetStatUInt8 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Core_GetTotalPacketsLostDelegate(nint _core);
        private static uint Core_GetTotalPacketsLostFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_GetTotalPacketsLost", "Core_GetTotalPacketsLost SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong Core_GetTotalPacketsSentDelegate(nint _core);
        private static ulong Core_GetTotalPacketsSentFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_GetTotalPacketsSent", "Core_GetTotalPacketsSent SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Core_GetVoiceActivationKeyDelegate(nint _core);
        private static uint Core_GetVoiceActivationKeyFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_GetVoiceActivationKey", "Core_GetVoiceActivationKey SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_GetVoiceInputMutedDelegate(nint _core);
        private static byte Core_GetVoiceInputMutedFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_GetVoiceInputMuted", "Core_GetVoiceInputMuted SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ulong Core_GetWebViewCountDelegate(nint _core);
        private static ulong Core_GetWebViewCountFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_GetWebViewCount", "Core_GetWebViewCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_GetWebViewsDelegate(nint _core, nint[] webViews, ulong _size);
        private static void Core_GetWebViewsFallback(nint _core, nint[] webViews, ulong _size) => throw new Exceptions.OutdatedSdkException("Core_GetWebViews", "Core_GetWebViews SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_GetWorldObjectsDelegate(nint _core, uint* _size);
        private static nint Core_GetWorldObjectsFallback(nint _core, uint* _size) => throw new Exceptions.OutdatedSdkException("Core_GetWorldObjects", "Core_GetWorldObjects SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_HasLocalMetaDelegate(nint _core, nint _key);
        private static byte Core_HasLocalMetaFallback(nint _core, nint _key) => throw new Exceptions.OutdatedSdkException("Core_HasLocalMeta", "Core_HasLocalMeta SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_IsCamFrozenDelegate(nint _core);
        private static byte Core_IsCamFrozenFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_IsCamFrozen", "Core_IsCamFrozen SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_IsConsoleOpenDelegate(nint _core);
        private static byte Core_IsConsoleOpenFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_IsConsoleOpen", "Core_IsConsoleOpen SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_IsCursorVisibleDelegate(nint _core, nint _resource);
        private static byte Core_IsCursorVisibleFallback(nint _core, nint _resource) => throw new Exceptions.OutdatedSdkException("Core_IsCursorVisible", "Core_IsCursorVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_IsFocusOverridenDelegate(nint _core);
        private static byte Core_IsFocusOverridenFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_IsFocusOverriden", "Core_IsFocusOverriden SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_IsGameFocusedDelegate(nint _core);
        private static byte Core_IsGameFocusedFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_IsGameFocused", "Core_IsGameFocused SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_IsInStreamerModeDelegate(nint _core);
        private static byte Core_IsInStreamerModeFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_IsInStreamerMode", "Core_IsInStreamerMode SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_IsKeyDownDelegate(nint _core, uint _key);
        private static byte Core_IsKeyDownFallback(nint _core, uint _key) => throw new Exceptions.OutdatedSdkException("Core_IsKeyDown", "Core_IsKeyDown SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_IsKeyToggledDelegate(nint _core, uint _key);
        private static byte Core_IsKeyToggledFallback(nint _core, uint _key) => throw new Exceptions.OutdatedSdkException("Core_IsKeyToggled", "Core_IsKeyToggled SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_IsMenuOpenedDelegate(nint _core);
        private static byte Core_IsMenuOpenedFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_IsMenuOpened", "Core_IsMenuOpened SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_IsPointOnScreenDelegate(nint _core, Vector3 _pos);
        private static byte Core_IsPointOnScreenFallback(nint _core, Vector3 _pos) => throw new Exceptions.OutdatedSdkException("Core_IsPointOnScreen", "Core_IsPointOnScreen SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_IsTextureExistInArchetypeDelegate(nint _core, uint _modelHash, nint _targetTextureName);
        private static byte Core_IsTextureExistInArchetypeFallback(nint _core, uint _modelHash, nint _targetTextureName) => throw new Exceptions.OutdatedSdkException("Core_IsTextureExistInArchetype", "Core_IsTextureExistInArchetype SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_IsVoiceActivityInputEnabledDelegate(nint _core);
        private static byte Core_IsVoiceActivityInputEnabledFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_IsVoiceActivityInputEnabled", "Core_IsVoiceActivityInputEnabled SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_LoadDefaultIplsDelegate(nint _core);
        private static void Core_LoadDefaultIplsFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_LoadDefaultIpls", "Core_LoadDefaultIpls SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_LoadModelDelegate(nint _core, uint _modelHash);
        private static void Core_LoadModelFallback(nint _core, uint _modelHash) => throw new Exceptions.OutdatedSdkException("Core_LoadModel", "Core_LoadModel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_LoadModelAsyncDelegate(nint _core, uint _modelHash);
        private static void Core_LoadModelAsyncFallback(nint _core, uint _modelHash) => throw new Exceptions.OutdatedSdkException("Core_LoadModelAsync", "Core_LoadModelAsync SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_LoadRmlFontDelegate(nint _core, nint _resource, nint _path, nint _name, byte _italic, byte _bold);
        private static void Core_LoadRmlFontFallback(nint _core, nint _resource, nint _path, nint _name, byte _italic, byte _bold) => throw new Exceptions.OutdatedSdkException("Core_LoadRmlFont", "Core_LoadRmlFont SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_LoadYtypDelegate(nint _core, nint _path);
        private static byte Core_LoadYtypFallback(nint _core, nint _path) => throw new Exceptions.OutdatedSdkException("Core_LoadYtyp", "Core_LoadYtyp SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_OverrideFocusEntityDelegate(nint _core, nint _entity);
        private static void Core_OverrideFocusEntityFallback(nint _core, nint _entity) => throw new Exceptions.OutdatedSdkException("Core_OverrideFocusEntity", "Core_OverrideFocusEntity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_OverrideFocusPositionDelegate(nint _core, Vector3 _pos, Vector3 _offset);
        private static void Core_OverrideFocusPositionFallback(nint _core, Vector3 _pos, Vector3 _offset) => throw new Exceptions.OutdatedSdkException("Core_OverrideFocusPosition", "Core_OverrideFocusPosition SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_RemoveGXTTextDelegate(nint _core, nint _resource, uint _key);
        private static void Core_RemoveGXTTextFallback(nint _core, nint _resource, uint _key) => throw new Exceptions.OutdatedSdkException("Core_RemoveGXTText", "Core_RemoveGXTText SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_RemoveIplDelegate(nint _core, nint _path);
        private static void Core_RemoveIplFallback(nint _core, nint _path) => throw new Exceptions.OutdatedSdkException("Core_RemoveIpl", "Core_RemoveIpl SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_RequestIplDelegate(nint _core, nint _path);
        private static void Core_RequestIplFallback(nint _core, nint _path) => throw new Exceptions.OutdatedSdkException("Core_RequestIpl", "Core_RequestIpl SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_ResetAllMapZoomDataDelegate(nint _core);
        private static void Core_ResetAllMapZoomDataFallback(nint _core) => throw new Exceptions.OutdatedSdkException("Core_ResetAllMapZoomData", "Core_ResetAllMapZoomData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_ResetMapZoomDataDelegate(nint _core, uint _id);
        private static void Core_ResetMapZoomDataFallback(nint _core, uint _id) => throw new Exceptions.OutdatedSdkException("Core_ResetMapZoomData", "Core_ResetMapZoomData SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_ResetStatDelegate(nint _core, nint _stat);
        private static void Core_ResetStatFallback(nint _core, nint _stat) => throw new Exceptions.OutdatedSdkException("Core_ResetStat", "Core_ResetStat SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_ScreenToWorldDelegate(nint _core, Vector2 _in, Vector3* _out);
        private static void Core_ScreenToWorldFallback(nint _core, Vector2 _in, Vector3* _out) => throw new Exceptions.OutdatedSdkException("Core_ScreenToWorld", "Core_ScreenToWorld SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetCamFrozenDelegate(nint _core, byte _value);
        private static void Core_SetCamFrozenFallback(nint _core, byte _value) => throw new Exceptions.OutdatedSdkException("Core_SetCamFrozen", "Core_SetCamFrozen SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetConfigFlagDelegate(nint _core, nint _flag, byte _state);
        private static void Core_SetConfigFlagFallback(nint _core, nint _flag, byte _state) => throw new Exceptions.OutdatedSdkException("Core_SetConfigFlag", "Core_SetConfigFlag SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetCursorPosDelegate(nint _core, Vector2 _pos, byte _normalized);
        private static void Core_SetCursorPosFallback(nint _core, Vector2 _pos, byte _normalized) => throw new Exceptions.OutdatedSdkException("Core_SetCursorPos", "Core_SetCursorPos SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetMinimapComponentPositionDelegate(nint _core, nint _name, byte _alignX, byte _alignY, float _posX, float _posY, float _sizeX, float _sizeY);
        private static void Core_SetMinimapComponentPositionFallback(nint _core, nint _name, byte _alignX, byte _alignY, float _posX, float _posY, float _sizeX, float _sizeY) => throw new Exceptions.OutdatedSdkException("Core_SetMinimapComponentPosition", "Core_SetMinimapComponentPosition SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetMinimapIsRectangleDelegate(nint _core, byte _state);
        private static void Core_SetMinimapIsRectangleFallback(nint _core, byte _state) => throw new Exceptions.OutdatedSdkException("Core_SetMinimapIsRectangle", "Core_SetMinimapIsRectangle SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetMsPerGameMinuteDelegate(nint _core, int _ms);
        private static void Core_SetMsPerGameMinuteFallback(nint _core, int _ms) => throw new Exceptions.OutdatedSdkException("Core_SetMsPerGameMinute", "Core_SetMsPerGameMinute SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetPedDlcClothesDelegate(nint _core, int _scriptID, uint _dlc, byte _component, byte _drawable, byte _texture, byte _palette);
        private static void Core_SetPedDlcClothesFallback(nint _core, int _scriptID, uint _dlc, byte _component, byte _drawable, byte _texture, byte _palette) => throw new Exceptions.OutdatedSdkException("Core_SetPedDlcClothes", "Core_SetPedDlcClothes SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetPedDlcPropDelegate(nint _core, int _scriptID, uint _dlc, byte _component, byte _drawable, byte _texture);
        private static void Core_SetPedDlcPropFallback(nint _core, int _scriptID, uint _dlc, byte _component, byte _drawable, byte _texture) => throw new Exceptions.OutdatedSdkException("Core_SetPedDlcProp", "Core_SetPedDlcProp SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetRotationVelocityDelegate(nint _core, int _scriptID, Vector3 _velocity);
        private static void Core_SetRotationVelocityFallback(nint _core, int _scriptID, Vector3 _velocity) => throw new Exceptions.OutdatedSdkException("Core_SetRotationVelocity", "Core_SetRotationVelocity SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetStatBoolDelegate(nint _core, nint _stat, byte _value);
        private static void Core_SetStatBoolFallback(nint _core, nint _stat, byte _value) => throw new Exceptions.OutdatedSdkException("Core_SetStatBool", "Core_SetStatBool SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetStatFloatDelegate(nint _core, nint _stat, float _value);
        private static void Core_SetStatFloatFallback(nint _core, nint _stat, float _value) => throw new Exceptions.OutdatedSdkException("Core_SetStatFloat", "Core_SetStatFloat SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetStatIntDelegate(nint _core, nint _stat, int _value);
        private static void Core_SetStatIntFallback(nint _core, nint _stat, int _value) => throw new Exceptions.OutdatedSdkException("Core_SetStatInt", "Core_SetStatInt SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetStatLongDelegate(nint _core, nint _stat, long _value);
        private static void Core_SetStatLongFallback(nint _core, nint _stat, long _value) => throw new Exceptions.OutdatedSdkException("Core_SetStatLong", "Core_SetStatLong SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetStatStringDelegate(nint _core, nint _stat, nint _value);
        private static void Core_SetStatStringFallback(nint _core, nint _stat, nint _value) => throw new Exceptions.OutdatedSdkException("Core_SetStatString", "Core_SetStatString SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetStatUInt16Delegate(nint _core, nint _stat, ushort _value);
        private static void Core_SetStatUInt16Fallback(nint _core, nint _stat, ushort _value) => throw new Exceptions.OutdatedSdkException("Core_SetStatUInt16", "Core_SetStatUInt16 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetStatUInt32Delegate(nint _core, nint _stat, uint _value);
        private static void Core_SetStatUInt32Fallback(nint _core, nint _stat, uint _value) => throw new Exceptions.OutdatedSdkException("Core_SetStatUInt32", "Core_SetStatUInt32 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetStatUInt64Delegate(nint _core, nint _stat, ulong _value);
        private static void Core_SetStatUInt64Fallback(nint _core, nint _stat, ulong _value) => throw new Exceptions.OutdatedSdkException("Core_SetStatUInt64", "Core_SetStatUInt64 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetStatUInt8Delegate(nint _core, nint _stat, byte _value);
        private static void Core_SetStatUInt8Fallback(nint _core, nint _stat, byte _value) => throw new Exceptions.OutdatedSdkException("Core_SetStatUInt8", "Core_SetStatUInt8 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetVoiceInputMutedDelegate(nint _core, byte _value);
        private static void Core_SetVoiceInputMutedFallback(nint _core, byte _value) => throw new Exceptions.OutdatedSdkException("Core_SetVoiceInputMuted", "Core_SetVoiceInputMuted SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetWatermarkPositionDelegate(nint _core, byte _position);
        private static void Core_SetWatermarkPositionFallback(nint _core, byte _position) => throw new Exceptions.OutdatedSdkException("Core_SetWatermarkPosition", "Core_SetWatermarkPosition SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetWeatherCycleDelegate(nint _core, byte[] weathers, int _weathersSize, byte[] multipliers, int _multipliersSize);
        private static void Core_SetWeatherCycleFallback(nint _core, byte[] weathers, int _weathersSize, byte[] multipliers, int _multipliersSize) => throw new Exceptions.OutdatedSdkException("Core_SetWeatherCycle", "Core_SetWeatherCycle SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_SetWeatherSyncActiveDelegate(nint _core, byte _state);
        private static void Core_SetWeatherSyncActiveFallback(nint _core, byte _state) => throw new Exceptions.OutdatedSdkException("Core_SetWeatherSyncActive", "Core_SetWeatherSyncActive SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_ShowCursorDelegate(nint _core, nint _resource, bool _state);
        private static void Core_ShowCursorFallback(nint _core, nint _resource, bool _state) => throw new Exceptions.OutdatedSdkException("Core_ShowCursor", "Core_ShowCursor SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Core_StringToSHA256Delegate(nint _core, nint _string, int* _size);
        private static nint Core_StringToSHA256Fallback(nint _core, nint _string, int* _size) => throw new Exceptions.OutdatedSdkException("Core_StringToSHA256", "Core_StringToSHA256 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_TakeScreenshotDelegate(nint _core, ClientEvents.ScreenshotResultModuleDelegate _delegate);
        private static byte Core_TakeScreenshotFallback(nint _core, ClientEvents.ScreenshotResultModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Core_TakeScreenshot", "Core_TakeScreenshot SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_TakeScreenshotGameOnlyDelegate(nint _core, ClientEvents.ScreenshotResultModuleDelegate _delegate);
        private static byte Core_TakeScreenshotGameOnlyFallback(nint _core, ClientEvents.ScreenshotResultModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Core_TakeScreenshotGameOnly", "Core_TakeScreenshotGameOnly SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_ToggleGameControlsDelegate(nint _core, nint _resource, byte _state);
        private static void Core_ToggleGameControlsFallback(nint _core, nint _resource, byte _state) => throw new Exceptions.OutdatedSdkException("Core_ToggleGameControls", "Core_ToggleGameControls SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_ToggleRmlControlsDelegate(nint _core, byte _state);
        private static void Core_ToggleRmlControlsFallback(nint _core, byte _state) => throw new Exceptions.OutdatedSdkException("Core_ToggleRmlControls", "Core_ToggleRmlControls SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_ToggleVoiceControlsDelegate(nint _core, byte _state);
        private static void Core_ToggleVoiceControlsFallback(nint _core, byte _state) => throw new Exceptions.OutdatedSdkException("Core_ToggleVoiceControls", "Core_ToggleVoiceControls SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_TriggerServerEventDelegate(nint _core, nint _event, nint[] args, int _size);
        private static void Core_TriggerServerEventFallback(nint _core, nint _event, nint[] args, int _size) => throw new Exceptions.OutdatedSdkException("Core_TriggerServerEvent", "Core_TriggerServerEvent SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_TriggerServerEventUnreliableDelegate(nint _core, nint _event, nint[] args, int _size);
        private static void Core_TriggerServerEventUnreliableFallback(nint _core, nint _event, nint[] args, int _size) => throw new Exceptions.OutdatedSdkException("Core_TriggerServerEventUnreliable", "Core_TriggerServerEventUnreliable SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_TriggerWebViewEventDelegate(nint _core, nint _webview, nint _event, nint[] args, int _size);
        private static void Core_TriggerWebViewEventFallback(nint _core, nint _webview, nint _event, nint[] args, int _size) => throw new Exceptions.OutdatedSdkException("Core_TriggerWebViewEvent", "Core_TriggerWebViewEvent SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Core_UnloadYtypDelegate(nint _core, nint _path);
        private static byte Core_UnloadYtypFallback(nint _core, nint _path) => throw new Exceptions.OutdatedSdkException("Core_UnloadYtyp", "Core_UnloadYtyp SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Core_WorldToScreenDelegate(nint _core, Vector3 _in, Vector2* _out);
        private static void Core_WorldToScreenFallback(nint _core, Vector3 _in, Vector2* _out) => throw new Exceptions.OutdatedSdkException("Core_WorldToScreen", "Core_WorldToScreen SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate int Entity_GetScriptIDDelegate(nint _entity);
        private static int Entity_GetScriptIDFallback(nint _entity) => throw new Exceptions.OutdatedSdkException("Entity_GetScriptID", "Entity_GetScriptID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetAnyResourceErrorDelegateDelegate(nint _resource, ClientEvents.AnyResourceErrorModuleDelegate _delegate);
        private static void Event_SetAnyResourceErrorDelegateFallback(nint _resource, ClientEvents.AnyResourceErrorModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetAnyResourceErrorDelegate", "Event_SetAnyResourceErrorDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetAnyResourceStartDelegateDelegate(nint _resource, ClientEvents.AnyResourceStartModuleDelegate _delegate);
        private static void Event_SetAnyResourceStartDelegateFallback(nint _resource, ClientEvents.AnyResourceStartModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetAnyResourceStartDelegate", "Event_SetAnyResourceStartDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetAnyResourceStopDelegateDelegate(nint _resource, ClientEvents.AnyResourceStopModuleDelegate _delegate);
        private static void Event_SetAnyResourceStopDelegateFallback(nint _resource, ClientEvents.AnyResourceStopModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetAnyResourceStopDelegate", "Event_SetAnyResourceStopDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetCheckpointDelegateDelegate(nint _resource, ClientEvents.CheckpointModuleDelegate _delegate);
        private static void Event_SetCheckpointDelegateFallback(nint _resource, ClientEvents.CheckpointModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetCheckpointDelegate", "Event_SetCheckpointDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetClientEventDelegateDelegate(nint _resource, ClientEvents.ClientEventModuleDelegate _delegate);
        private static void Event_SetClientEventDelegateFallback(nint _resource, ClientEvents.ClientEventModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetClientEventDelegate", "Event_SetClientEventDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetColShapeDelegateDelegate(nint _resource, ClientEvents.ColShapeModuleDelegate _delegate);
        private static void Event_SetColShapeDelegateFallback(nint _resource, ClientEvents.ColShapeModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetColShapeDelegate", "Event_SetColShapeDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetConnectionCompleteDelegateDelegate(nint _resource, ClientEvents.ConnectionCompleteModuleDelegate _delegate);
        private static void Event_SetConnectionCompleteDelegateFallback(nint _resource, ClientEvents.ConnectionCompleteModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetConnectionCompleteDelegate", "Event_SetConnectionCompleteDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetConsoleCommandDelegateDelegate(nint _resource, ClientEvents.ConsoleCommandModuleDelegate _delegate);
        private static void Event_SetConsoleCommandDelegateFallback(nint _resource, ClientEvents.ConsoleCommandModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetConsoleCommandDelegate", "Event_SetConsoleCommandDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetCreateBaseObjectDelegateDelegate(nint _resource, ClientEvents.CreateBaseObjectModuleDelegate _delegate);
        private static void Event_SetCreateBaseObjectDelegateFallback(nint _resource, ClientEvents.CreateBaseObjectModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetCreateBaseObjectDelegate", "Event_SetCreateBaseObjectDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetGameEntityCreateDelegateDelegate(nint _resource, ClientEvents.GameEntityCreateModuleDelegate _delegate);
        private static void Event_SetGameEntityCreateDelegateFallback(nint _resource, ClientEvents.GameEntityCreateModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetGameEntityCreateDelegate", "Event_SetGameEntityCreateDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetGameEntityDestroyDelegateDelegate(nint _resource, ClientEvents.GameEntityDestroyModuleDelegate _delegate);
        private static void Event_SetGameEntityDestroyDelegateFallback(nint _resource, ClientEvents.GameEntityDestroyModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetGameEntityDestroyDelegate", "Event_SetGameEntityDestroyDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetGlobalMetaChangeDelegateDelegate(nint _resource, ClientEvents.GlobalMetaChangeModuleDelegate _delegate);
        private static void Event_SetGlobalMetaChangeDelegateFallback(nint _resource, ClientEvents.GlobalMetaChangeModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetGlobalMetaChangeDelegate", "Event_SetGlobalMetaChangeDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetGlobalSyncedMetaChangeDelegateDelegate(nint _resource, ClientEvents.GlobalSyncedMetaChangeModuleDelegate _delegate);
        private static void Event_SetGlobalSyncedMetaChangeDelegateFallback(nint _resource, ClientEvents.GlobalSyncedMetaChangeModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetGlobalSyncedMetaChangeDelegate", "Event_SetGlobalSyncedMetaChangeDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetKeyDownDelegateDelegate(nint _resource, ClientEvents.KeyDownModuleDelegate _delegate);
        private static void Event_SetKeyDownDelegateFallback(nint _resource, ClientEvents.KeyDownModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetKeyDownDelegate", "Event_SetKeyDownDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetKeyUpDelegateDelegate(nint _resource, ClientEvents.KeyUpModuleDelegate _delegate);
        private static void Event_SetKeyUpDelegateFallback(nint _resource, ClientEvents.KeyUpModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetKeyUpDelegate", "Event_SetKeyUpDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetLocalMetaChangeDelegateDelegate(nint _resource, ClientEvents.LocalMetaChangeModuleDelegate _delegate);
        private static void Event_SetLocalMetaChangeDelegateFallback(nint _resource, ClientEvents.LocalMetaChangeModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetLocalMetaChangeDelegate", "Event_SetLocalMetaChangeDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetMetaChangeDelegateDelegate(nint _resource, ClientEvents.MetaChangeModuleDelegate _delegate);
        private static void Event_SetMetaChangeDelegateFallback(nint _resource, ClientEvents.MetaChangeModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetMetaChangeDelegate", "Event_SetMetaChangeDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetNetOwnerChangeDelegateDelegate(nint _resource, ClientEvents.NetOwnerChangeModuleDelegate _delegate);
        private static void Event_SetNetOwnerChangeDelegateFallback(nint _resource, ClientEvents.NetOwnerChangeModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetNetOwnerChangeDelegate", "Event_SetNetOwnerChangeDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetPlayerChangeAnimationDelegateDelegate(nint _resource, ClientEvents.PlayerChangeAnimationModuleDelegate _delegate);
        private static void Event_SetPlayerChangeAnimationDelegateFallback(nint _resource, ClientEvents.PlayerChangeAnimationModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetPlayerChangeAnimationDelegate", "Event_SetPlayerChangeAnimationDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetPlayerChangeInteriorDelegateDelegate(nint _resource, ClientEvents.PlayerChangeInteriorModuleDelegate _delegate);
        private static void Event_SetPlayerChangeInteriorDelegateFallback(nint _resource, ClientEvents.PlayerChangeInteriorModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetPlayerChangeInteriorDelegate", "Event_SetPlayerChangeInteriorDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetPlayerChangeVehicleSeatDelegateDelegate(nint _resource, ClientEvents.PlayerChangeVehicleSeatModuleDelegate _delegate);
        private static void Event_SetPlayerChangeVehicleSeatDelegateFallback(nint _resource, ClientEvents.PlayerChangeVehicleSeatModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetPlayerChangeVehicleSeatDelegate", "Event_SetPlayerChangeVehicleSeatDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetPlayerDisconnectDelegateDelegate(nint _resource, ClientEvents.PlayerDisconnectModuleDelegate _delegate);
        private static void Event_SetPlayerDisconnectDelegateFallback(nint _resource, ClientEvents.PlayerDisconnectModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetPlayerDisconnectDelegate", "Event_SetPlayerDisconnectDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetPlayerEnterVehicleDelegateDelegate(nint _resource, ClientEvents.PlayerEnterVehicleModuleDelegate _delegate);
        private static void Event_SetPlayerEnterVehicleDelegateFallback(nint _resource, ClientEvents.PlayerEnterVehicleModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetPlayerEnterVehicleDelegate", "Event_SetPlayerEnterVehicleDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetPlayerLeaveVehicleDelegateDelegate(nint _resource, ClientEvents.PlayerLeaveVehicleModuleDelegate _delegate);
        private static void Event_SetPlayerLeaveVehicleDelegateFallback(nint _resource, ClientEvents.PlayerLeaveVehicleModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetPlayerLeaveVehicleDelegate", "Event_SetPlayerLeaveVehicleDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetPlayerSpawnDelegateDelegate(nint _resource, ClientEvents.PlayerSpawnModuleDelegate _delegate);
        private static void Event_SetPlayerSpawnDelegateFallback(nint _resource, ClientEvents.PlayerSpawnModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetPlayerSpawnDelegate", "Event_SetPlayerSpawnDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetPlayerWeaponChangeDelegateDelegate(nint _resource, ClientEvents.PlayerWeaponChangeModuleDelegate _delegate);
        private static void Event_SetPlayerWeaponChangeDelegateFallback(nint _resource, ClientEvents.PlayerWeaponChangeModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetPlayerWeaponChangeDelegate", "Event_SetPlayerWeaponChangeDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetPlayerWeaponShootDelegateDelegate(nint _resource, ClientEvents.PlayerWeaponShootModuleDelegate _delegate);
        private static void Event_SetPlayerWeaponShootDelegateFallback(nint _resource, ClientEvents.PlayerWeaponShootModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetPlayerWeaponShootDelegate", "Event_SetPlayerWeaponShootDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetRemoveBaseObjectDelegateDelegate(nint _resource, ClientEvents.RemoveBaseObjectModuleDelegate _delegate);
        private static void Event_SetRemoveBaseObjectDelegateFallback(nint _resource, ClientEvents.RemoveBaseObjectModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetRemoveBaseObjectDelegate", "Event_SetRemoveBaseObjectDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetRmlEventDelegateDelegate(nint _resource, ClientEvents.RmlEventModuleDelegate _delegate);
        private static void Event_SetRmlEventDelegateFallback(nint _resource, ClientEvents.RmlEventModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetRmlEventDelegate", "Event_SetRmlEventDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetServerEventDelegateDelegate(nint _resource, ClientEvents.ServerEventModuleDelegate _delegate);
        private static void Event_SetServerEventDelegateFallback(nint _resource, ClientEvents.ServerEventModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetServerEventDelegate", "Event_SetServerEventDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetStreamSyncedMetaChangeDelegateDelegate(nint _resource, ClientEvents.StreamSyncedMetaChangeModuleDelegate _delegate);
        private static void Event_SetStreamSyncedMetaChangeDelegateFallback(nint _resource, ClientEvents.StreamSyncedMetaChangeModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetStreamSyncedMetaChangeDelegate", "Event_SetStreamSyncedMetaChangeDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetSyncedMetaChangeDelegateDelegate(nint _resource, ClientEvents.SyncedMetaChangeModuleDelegate _delegate);
        private static void Event_SetSyncedMetaChangeDelegateFallback(nint _resource, ClientEvents.SyncedMetaChangeModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetSyncedMetaChangeDelegate", "Event_SetSyncedMetaChangeDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetTaskChangeDelegateDelegate(nint _resource, ClientEvents.TaskChangeModuleDelegate _delegate);
        private static void Event_SetTaskChangeDelegateFallback(nint _resource, ClientEvents.TaskChangeModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetTaskChangeDelegate", "Event_SetTaskChangeDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetTickDelegateDelegate(nint _resource, ClientEvents.TickModuleDelegate _delegate);
        private static void Event_SetTickDelegateFallback(nint _resource, ClientEvents.TickModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetTickDelegate", "Event_SetTickDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetWeaponDamageDelegateDelegate(nint _resource, ClientEvents.WeaponDamageModuleDelegate _delegate);
        private static void Event_SetWeaponDamageDelegateFallback(nint _resource, ClientEvents.WeaponDamageModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetWeaponDamageDelegate", "Event_SetWeaponDamageDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetWebSocketEventDelegateDelegate(nint _resource, ClientEvents.WebSocketEventModuleDelegate _delegate);
        private static void Event_SetWebSocketEventDelegateFallback(nint _resource, ClientEvents.WebSocketEventModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetWebSocketEventDelegate", "Event_SetWebSocketEventDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetWebViewEventDelegateDelegate(nint _resource, ClientEvents.WebViewEventModuleDelegate _delegate);
        private static void Event_SetWebViewEventDelegateFallback(nint _resource, ClientEvents.WebViewEventModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetWebViewEventDelegate", "Event_SetWebViewEventDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetWindowFocusChangeDelegateDelegate(nint _resource, ClientEvents.WindowFocusChangeModuleDelegate _delegate);
        private static void Event_SetWindowFocusChangeDelegateFallback(nint _resource, ClientEvents.WindowFocusChangeModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetWindowFocusChangeDelegate", "Event_SetWindowFocusChangeDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetWindowResolutionChangeDelegateDelegate(nint _resource, ClientEvents.WindowResolutionChangeModuleDelegate _delegate);
        private static void Event_SetWindowResolutionChangeDelegateFallback(nint _resource, ClientEvents.WindowResolutionChangeModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetWindowResolutionChangeDelegate", "Event_SetWindowResolutionChangeDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetWorldObjectPositionChangeDelegateDelegate(nint _resource, ClientEvents.WorldObjectPositionChangeModuleDelegate _delegate);
        private static void Event_SetWorldObjectPositionChangeDelegateFallback(nint _resource, ClientEvents.WorldObjectPositionChangeModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetWorldObjectPositionChangeDelegate", "Event_SetWorldObjectPositionChangeDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetWorldObjectStreamInDelegateDelegate(nint _resource, ClientEvents.WorldObjectStreamInModuleDelegate _delegate);
        private static void Event_SetWorldObjectStreamInDelegateFallback(nint _resource, ClientEvents.WorldObjectStreamInModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetWorldObjectStreamInDelegate", "Event_SetWorldObjectStreamInDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Event_SetWorldObjectStreamOutDelegateDelegate(nint _resource, ClientEvents.WorldObjectStreamOutModuleDelegate _delegate);
        private static void Event_SetWorldObjectStreamOutDelegateFallback(nint _resource, ClientEvents.WorldObjectStreamOutModuleDelegate _delegate) => throw new Exceptions.OutdatedSdkException("Event_SetWorldObjectStreamOutDelegate", "Event_SetWorldObjectStreamOutDelegate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void FreeRmlElementArrayDelegate(nint _rmlElementArray);
        private static void FreeRmlElementArrayFallback(nint _rmlElementArray) => throw new Exceptions.OutdatedSdkException("FreeRmlElementArray", "FreeRmlElementArray SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint GetNativeFuncTableDelegate();
        private static nint GetNativeFuncTableFallback() => throw new Exceptions.OutdatedSdkException("GetNativeFuncTable", "GetNativeFuncTable SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetAccelerationDelegate(uint _modelHash);
        private static float Handling_GetAccelerationFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetAcceleration", "Handling_GetAcceleration SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetAntiRollBarBiasFrontDelegate(uint _modelHash);
        private static float Handling_GetAntiRollBarBiasFrontFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetAntiRollBarBiasFront", "Handling_GetAntiRollBarBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetAntiRollBarBiasRearDelegate(uint _modelHash);
        private static float Handling_GetAntiRollBarBiasRearFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetAntiRollBarBiasRear", "Handling_GetAntiRollBarBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetAntiRollBarForceDelegate(uint _modelHash);
        private static float Handling_GetAntiRollBarForceFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetAntiRollBarForce", "Handling_GetAntiRollBarForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetBrakeBiasFrontDelegate(uint _modelHash);
        private static float Handling_GetBrakeBiasFrontFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetBrakeBiasFront", "Handling_GetBrakeBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetBrakeBiasRearDelegate(uint _modelHash);
        private static float Handling_GetBrakeBiasRearFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetBrakeBiasRear", "Handling_GetBrakeBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetBrakeForceDelegate(uint _modelHash);
        private static float Handling_GetBrakeForceFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetBrakeForce", "Handling_GetBrakeForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetCamberStiffnessDelegate(uint _modelHash);
        private static float Handling_GetCamberStiffnessFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetCamberStiffness", "Handling_GetCamberStiffness SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_GetCentreOfMassOffsetDelegate(uint _modelHash, Vector3* _offset);
        private static void Handling_GetCentreOfMassOffsetFallback(uint _modelHash, Vector3* _offset) => throw new Exceptions.OutdatedSdkException("Handling_GetCentreOfMassOffset", "Handling_GetCentreOfMassOffset SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetClutchChangeRateScaleDownShiftDelegate(uint _modelHash);
        private static float Handling_GetClutchChangeRateScaleDownShiftFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetClutchChangeRateScaleDownShift", "Handling_GetClutchChangeRateScaleDownShift SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetClutchChangeRateScaleUpShiftDelegate(uint _modelHash);
        private static float Handling_GetClutchChangeRateScaleUpShiftFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetClutchChangeRateScaleUpShift", "Handling_GetClutchChangeRateScaleUpShift SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetCollisionDamageMultDelegate(uint _modelHash);
        private static float Handling_GetCollisionDamageMultFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetCollisionDamageMult", "Handling_GetCollisionDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Handling_GetDamageFlagsDelegate(uint _modelHash);
        private static uint Handling_GetDamageFlagsFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetDamageFlags", "Handling_GetDamageFlags SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetDeformationDamageMultDelegate(uint _modelHash);
        private static float Handling_GetDeformationDamageMultFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetDeformationDamageMult", "Handling_GetDeformationDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetDownforceModifierDelegate(uint _modelHash);
        private static float Handling_GetDownforceModifierFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetDownforceModifier", "Handling_GetDownforceModifier SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetDriveBiasFrontDelegate(uint _modelHash);
        private static float Handling_GetDriveBiasFrontFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetDriveBiasFront", "Handling_GetDriveBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetDriveInertiaDelegate(uint _modelHash);
        private static float Handling_GetDriveInertiaFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetDriveInertia", "Handling_GetDriveInertia SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetDriveMaxFlatVelDelegate(uint _modelHash);
        private static float Handling_GetDriveMaxFlatVelFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetDriveMaxFlatVel", "Handling_GetDriveMaxFlatVel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetEngineDamageMultDelegate(uint _modelHash);
        private static float Handling_GetEngineDamageMultFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetEngineDamageMult", "Handling_GetEngineDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetHandBrakeForceDelegate(uint _modelHash);
        private static float Handling_GetHandBrakeForceFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetHandBrakeForce", "Handling_GetHandBrakeForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Handling_GetHandlingFlagsDelegate(uint _modelHash);
        private static uint Handling_GetHandlingFlagsFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetHandlingFlags", "Handling_GetHandlingFlags SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Handling_GetHandlingNameHashDelegate(uint _modelHash);
        private static uint Handling_GetHandlingNameHashFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetHandlingNameHash", "Handling_GetHandlingNameHash SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_GetInertiaMultiplierDelegate(uint _modelHash, Vector3* _offset);
        private static void Handling_GetInertiaMultiplierFallback(uint _modelHash, Vector3* _offset) => throw new Exceptions.OutdatedSdkException("Handling_GetInertiaMultiplier", "Handling_GetInertiaMultiplier SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetInitialDragCoeffDelegate(uint _modelHash);
        private static float Handling_GetInitialDragCoeffFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetInitialDragCoeff", "Handling_GetInitialDragCoeff SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetInitialDriveForceDelegate(uint _modelHash);
        private static float Handling_GetInitialDriveForceFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetInitialDriveForce", "Handling_GetInitialDriveForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Handling_GetInitialDriveGearsDelegate(uint _modelHash);
        private static uint Handling_GetInitialDriveGearsFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetInitialDriveGears", "Handling_GetInitialDriveGears SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetInitialDriveMaxFlatVelDelegate(uint _modelHash);
        private static float Handling_GetInitialDriveMaxFlatVelFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetInitialDriveMaxFlatVel", "Handling_GetInitialDriveMaxFlatVel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetLowSpeedTractionLossMultDelegate(uint _modelHash);
        private static float Handling_GetLowSpeedTractionLossMultFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetLowSpeedTractionLossMult", "Handling_GetLowSpeedTractionLossMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetMassDelegate(uint _modelHash);
        private static float Handling_GetMassFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetMass", "Handling_GetMass SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Handling_GetModelFlagsDelegate(uint _modelHash);
        private static uint Handling_GetModelFlagsFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetModelFlags", "Handling_GetModelFlags SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Handling_GetMonetaryValueDelegate(uint _modelHash);
        private static uint Handling_GetMonetaryValueFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetMonetaryValue", "Handling_GetMonetaryValue SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetOilVolumeDelegate(uint _modelHash);
        private static float Handling_GetOilVolumeFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetOilVolume", "Handling_GetOilVolume SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetPercentSubmergedDelegate(uint _modelHash);
        private static float Handling_GetPercentSubmergedFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetPercentSubmerged", "Handling_GetPercentSubmerged SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetPercentSubmergedRatioDelegate(uint _modelHash);
        private static float Handling_GetPercentSubmergedRatioFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetPercentSubmergedRatio", "Handling_GetPercentSubmergedRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetPetrolTankVolumeDelegate(uint _modelHash);
        private static float Handling_GetPetrolTankVolumeFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetPetrolTankVolume", "Handling_GetPetrolTankVolume SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetRollCentreHeightFrontDelegate(uint _modelHash);
        private static float Handling_GetRollCentreHeightFrontFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetRollCentreHeightFront", "Handling_GetRollCentreHeightFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetRollCentreHeightRearDelegate(uint _modelHash);
        private static float Handling_GetRollCentreHeightRearFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetRollCentreHeightRear", "Handling_GetRollCentreHeightRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetSeatOffsetDistXDelegate(uint _modelHash);
        private static float Handling_GetSeatOffsetDistXFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetSeatOffsetDistX", "Handling_GetSeatOffsetDistX SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetSeatOffsetDistYDelegate(uint _modelHash);
        private static float Handling_GetSeatOffsetDistYFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetSeatOffsetDistY", "Handling_GetSeatOffsetDistY SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetSeatOffsetDistZDelegate(uint _modelHash);
        private static float Handling_GetSeatOffsetDistZFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetSeatOffsetDistZ", "Handling_GetSeatOffsetDistZ SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetSteeringLockDelegate(uint _modelHash);
        private static float Handling_GetSteeringLockFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetSteeringLock", "Handling_GetSteeringLock SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetSteeringLockRatioDelegate(uint _modelHash);
        private static float Handling_GetSteeringLockRatioFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetSteeringLockRatio", "Handling_GetSteeringLockRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetSuspensionBiasFrontDelegate(uint _modelHash);
        private static float Handling_GetSuspensionBiasFrontFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetSuspensionBiasFront", "Handling_GetSuspensionBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetSuspensionBiasRearDelegate(uint _modelHash);
        private static float Handling_GetSuspensionBiasRearFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetSuspensionBiasRear", "Handling_GetSuspensionBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetSuspensionCompDampDelegate(uint _modelHash);
        private static float Handling_GetSuspensionCompDampFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetSuspensionCompDamp", "Handling_GetSuspensionCompDamp SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetSuspensionForceDelegate(uint _modelHash);
        private static float Handling_GetSuspensionForceFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetSuspensionForce", "Handling_GetSuspensionForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetSuspensionLowerLimitDelegate(uint _modelHash);
        private static float Handling_GetSuspensionLowerLimitFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetSuspensionLowerLimit", "Handling_GetSuspensionLowerLimit SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetSuspensionRaiseDelegate(uint _modelHash);
        private static float Handling_GetSuspensionRaiseFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetSuspensionRaise", "Handling_GetSuspensionRaise SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetSuspensionReboundDampDelegate(uint _modelHash);
        private static float Handling_GetSuspensionReboundDampFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetSuspensionReboundDamp", "Handling_GetSuspensionReboundDamp SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetSuspensionUpperLimitDelegate(uint _modelHash);
        private static float Handling_GetSuspensionUpperLimitFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetSuspensionUpperLimit", "Handling_GetSuspensionUpperLimit SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetTractionBiasFrontDelegate(uint _modelHash);
        private static float Handling_GetTractionBiasFrontFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetTractionBiasFront", "Handling_GetTractionBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetTractionBiasRearDelegate(uint _modelHash);
        private static float Handling_GetTractionBiasRearFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetTractionBiasRear", "Handling_GetTractionBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetTractionCurveLateralDelegate(uint _modelHash);
        private static float Handling_GetTractionCurveLateralFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetTractionCurveLateral", "Handling_GetTractionCurveLateral SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetTractionCurveLateralRatioDelegate(uint _modelHash);
        private static float Handling_GetTractionCurveLateralRatioFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetTractionCurveLateralRatio", "Handling_GetTractionCurveLateralRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetTractionCurveMaxDelegate(uint _modelHash);
        private static float Handling_GetTractionCurveMaxFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetTractionCurveMax", "Handling_GetTractionCurveMax SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetTractionCurveMaxRatioDelegate(uint _modelHash);
        private static float Handling_GetTractionCurveMaxRatioFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetTractionCurveMaxRatio", "Handling_GetTractionCurveMaxRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetTractionCurveMinDelegate(uint _modelHash);
        private static float Handling_GetTractionCurveMinFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetTractionCurveMin", "Handling_GetTractionCurveMin SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetTractionCurveMinRatioDelegate(uint _modelHash);
        private static float Handling_GetTractionCurveMinRatioFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetTractionCurveMinRatio", "Handling_GetTractionCurveMinRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetTractionLossMultDelegate(uint _modelHash);
        private static float Handling_GetTractionLossMultFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetTractionLossMult", "Handling_GetTractionLossMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetTractionSpringDeltaMaxDelegate(uint _modelHash);
        private static float Handling_GetTractionSpringDeltaMaxFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetTractionSpringDeltaMax", "Handling_GetTractionSpringDeltaMax SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetTractionSpringDeltaMaxRatioDelegate(uint _modelHash);
        private static float Handling_GetTractionSpringDeltaMaxRatioFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetTractionSpringDeltaMaxRatio", "Handling_GetTractionSpringDeltaMaxRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetunkFloat1Delegate(uint _modelHash);
        private static float Handling_GetunkFloat1Fallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetunkFloat1", "Handling_GetunkFloat1 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetunkFloat2Delegate(uint _modelHash);
        private static float Handling_GetunkFloat2Fallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetunkFloat2", "Handling_GetunkFloat2 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetunkFloat4Delegate(uint _modelHash);
        private static float Handling_GetunkFloat4Fallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetunkFloat4", "Handling_GetunkFloat4 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetunkFloat5Delegate(uint _modelHash);
        private static float Handling_GetunkFloat5Fallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetunkFloat5", "Handling_GetunkFloat5 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Handling_GetWeaponDamageMultDelegate(uint _modelHash);
        private static float Handling_GetWeaponDamageMultFallback(uint _modelHash) => throw new Exceptions.OutdatedSdkException("Handling_GetWeaponDamageMult", "Handling_GetWeaponDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetAccelerationDelegate(uint _modelHash, float _value);
        private static void Handling_SetAccelerationFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetAcceleration", "Handling_SetAcceleration SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetAntiRollBarBiasFrontDelegate(uint _modelHash, float _value);
        private static void Handling_SetAntiRollBarBiasFrontFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetAntiRollBarBiasFront", "Handling_SetAntiRollBarBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetAntiRollBarBiasRearDelegate(uint _modelHash, float _value);
        private static void Handling_SetAntiRollBarBiasRearFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetAntiRollBarBiasRear", "Handling_SetAntiRollBarBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetAntiRollBarForceDelegate(uint _modelHash, float _value);
        private static void Handling_SetAntiRollBarForceFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetAntiRollBarForce", "Handling_SetAntiRollBarForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetBrakeBiasFrontDelegate(uint _modelHash, float _value);
        private static void Handling_SetBrakeBiasFrontFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetBrakeBiasFront", "Handling_SetBrakeBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetBrakeBiasRearDelegate(uint _modelHash, float _value);
        private static void Handling_SetBrakeBiasRearFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetBrakeBiasRear", "Handling_SetBrakeBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetBrakeForceDelegate(uint _modelHash, float _value);
        private static void Handling_SetBrakeForceFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetBrakeForce", "Handling_SetBrakeForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetCamberStiffnessDelegate(uint _modelHash, float _value);
        private static void Handling_SetCamberStiffnessFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetCamberStiffness", "Handling_SetCamberStiffness SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetCentreOfMassOffsetDelegate(uint _modelHash, Vector3 _value);
        private static void Handling_SetCentreOfMassOffsetFallback(uint _modelHash, Vector3 _value) => throw new Exceptions.OutdatedSdkException("Handling_SetCentreOfMassOffset", "Handling_SetCentreOfMassOffset SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetClutchChangeRateScaleDownShiftDelegate(uint _modelHash, float _value);
        private static void Handling_SetClutchChangeRateScaleDownShiftFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetClutchChangeRateScaleDownShift", "Handling_SetClutchChangeRateScaleDownShift SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetClutchChangeRateScaleUpShiftDelegate(uint _modelHash, float _value);
        private static void Handling_SetClutchChangeRateScaleUpShiftFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetClutchChangeRateScaleUpShift", "Handling_SetClutchChangeRateScaleUpShift SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetCollisionDamageMultDelegate(uint _modelHash, float _value);
        private static void Handling_SetCollisionDamageMultFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetCollisionDamageMult", "Handling_SetCollisionDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetDamageFlagsDelegate(uint _modelHash, uint _value);
        private static void Handling_SetDamageFlagsFallback(uint _modelHash, uint _value) => throw new Exceptions.OutdatedSdkException("Handling_SetDamageFlags", "Handling_SetDamageFlags SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetDeformationDamageMultDelegate(uint _modelHash, float _value);
        private static void Handling_SetDeformationDamageMultFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetDeformationDamageMult", "Handling_SetDeformationDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetDownforceModifierDelegate(uint _modelHash, float _value);
        private static void Handling_SetDownforceModifierFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetDownforceModifier", "Handling_SetDownforceModifier SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetDriveBiasFrontDelegate(uint _modelHash, float _value);
        private static void Handling_SetDriveBiasFrontFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetDriveBiasFront", "Handling_SetDriveBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetDriveInertiaDelegate(uint _modelHash, float _value);
        private static void Handling_SetDriveInertiaFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetDriveInertia", "Handling_SetDriveInertia SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetDriveMaxFlatVelDelegate(uint _modelHash, float _value);
        private static void Handling_SetDriveMaxFlatVelFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetDriveMaxFlatVel", "Handling_SetDriveMaxFlatVel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetEngineDamageMultDelegate(uint _modelHash, float _value);
        private static void Handling_SetEngineDamageMultFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetEngineDamageMult", "Handling_SetEngineDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetHandBrakeForceDelegate(uint _modelHash, float _value);
        private static void Handling_SetHandBrakeForceFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetHandBrakeForce", "Handling_SetHandBrakeForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetHandlingFlagsDelegate(uint _modelHash, uint _value);
        private static void Handling_SetHandlingFlagsFallback(uint _modelHash, uint _value) => throw new Exceptions.OutdatedSdkException("Handling_SetHandlingFlags", "Handling_SetHandlingFlags SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetInertiaMultiplierDelegate(uint _modelHash, Vector3 _value);
        private static void Handling_SetInertiaMultiplierFallback(uint _modelHash, Vector3 _value) => throw new Exceptions.OutdatedSdkException("Handling_SetInertiaMultiplier", "Handling_SetInertiaMultiplier SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetInitialDragCoeffDelegate(uint _modelHash, float _value);
        private static void Handling_SetInitialDragCoeffFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetInitialDragCoeff", "Handling_SetInitialDragCoeff SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetInitialDriveForceDelegate(uint _modelHash, float _value);
        private static void Handling_SetInitialDriveForceFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetInitialDriveForce", "Handling_SetInitialDriveForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetInitialDriveGearsDelegate(uint _modelHash, uint _value);
        private static void Handling_SetInitialDriveGearsFallback(uint _modelHash, uint _value) => throw new Exceptions.OutdatedSdkException("Handling_SetInitialDriveGears", "Handling_SetInitialDriveGears SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetInitialDriveMaxFlatVelDelegate(uint _modelHash, float _value);
        private static void Handling_SetInitialDriveMaxFlatVelFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetInitialDriveMaxFlatVel", "Handling_SetInitialDriveMaxFlatVel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetLowSpeedTractionLossMultDelegate(uint _modelHash, float _value);
        private static void Handling_SetLowSpeedTractionLossMultFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetLowSpeedTractionLossMult", "Handling_SetLowSpeedTractionLossMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetMassDelegate(uint _modelHash, float _value);
        private static void Handling_SetMassFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetMass", "Handling_SetMass SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetModelFlagsDelegate(uint _modelHash, uint _value);
        private static void Handling_SetModelFlagsFallback(uint _modelHash, uint _value) => throw new Exceptions.OutdatedSdkException("Handling_SetModelFlags", "Handling_SetModelFlags SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetMonetaryValueDelegate(uint _modelHash, uint _value);
        private static void Handling_SetMonetaryValueFallback(uint _modelHash, uint _value) => throw new Exceptions.OutdatedSdkException("Handling_SetMonetaryValue", "Handling_SetMonetaryValue SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetOilVolumeDelegate(uint _modelHash, float _value);
        private static void Handling_SetOilVolumeFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetOilVolume", "Handling_SetOilVolume SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetPercentSubmergedDelegate(uint _modelHash, float _value);
        private static void Handling_SetPercentSubmergedFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetPercentSubmerged", "Handling_SetPercentSubmerged SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetPercentSubmergedRatioDelegate(uint _modelHash, float _value);
        private static void Handling_SetPercentSubmergedRatioFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetPercentSubmergedRatio", "Handling_SetPercentSubmergedRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetPetrolTankVolumeDelegate(uint _modelHash, float _value);
        private static void Handling_SetPetrolTankVolumeFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetPetrolTankVolume", "Handling_SetPetrolTankVolume SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetRollCentreHeightFrontDelegate(uint _modelHash, float _value);
        private static void Handling_SetRollCentreHeightFrontFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetRollCentreHeightFront", "Handling_SetRollCentreHeightFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetRollCentreHeightRearDelegate(uint _modelHash, float _value);
        private static void Handling_SetRollCentreHeightRearFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetRollCentreHeightRear", "Handling_SetRollCentreHeightRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetSeatOffsetDistXDelegate(uint _modelHash, float _value);
        private static void Handling_SetSeatOffsetDistXFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetSeatOffsetDistX", "Handling_SetSeatOffsetDistX SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetSeatOffsetDistYDelegate(uint _modelHash, float _value);
        private static void Handling_SetSeatOffsetDistYFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetSeatOffsetDistY", "Handling_SetSeatOffsetDistY SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetSeatOffsetDistZDelegate(uint _modelHash, float _value);
        private static void Handling_SetSeatOffsetDistZFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetSeatOffsetDistZ", "Handling_SetSeatOffsetDistZ SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetSteeringLockDelegate(uint _modelHash, float _value);
        private static void Handling_SetSteeringLockFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetSteeringLock", "Handling_SetSteeringLock SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetSteeringLockRatioDelegate(uint _modelHash, float _value);
        private static void Handling_SetSteeringLockRatioFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetSteeringLockRatio", "Handling_SetSteeringLockRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetSuspensionBiasFrontDelegate(uint _modelHash, float _value);
        private static void Handling_SetSuspensionBiasFrontFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetSuspensionBiasFront", "Handling_SetSuspensionBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetSuspensionBiasRearDelegate(uint _modelHash, float _value);
        private static void Handling_SetSuspensionBiasRearFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetSuspensionBiasRear", "Handling_SetSuspensionBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetSuspensionCompDampDelegate(uint _modelHash, float _value);
        private static void Handling_SetSuspensionCompDampFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetSuspensionCompDamp", "Handling_SetSuspensionCompDamp SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetSuspensionForceDelegate(uint _modelHash, float _value);
        private static void Handling_SetSuspensionForceFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetSuspensionForce", "Handling_SetSuspensionForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetSuspensionLowerLimitDelegate(uint _modelHash, float _value);
        private static void Handling_SetSuspensionLowerLimitFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetSuspensionLowerLimit", "Handling_SetSuspensionLowerLimit SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetSuspensionRaiseDelegate(uint _modelHash, float _value);
        private static void Handling_SetSuspensionRaiseFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetSuspensionRaise", "Handling_SetSuspensionRaise SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetSuspensionReboundDampDelegate(uint _modelHash, float _value);
        private static void Handling_SetSuspensionReboundDampFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetSuspensionReboundDamp", "Handling_SetSuspensionReboundDamp SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetSuspensionUpperLimitDelegate(uint _modelHash, float _value);
        private static void Handling_SetSuspensionUpperLimitFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetSuspensionUpperLimit", "Handling_SetSuspensionUpperLimit SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetTractionBiasFrontDelegate(uint _modelHash, float _value);
        private static void Handling_SetTractionBiasFrontFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetTractionBiasFront", "Handling_SetTractionBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetTractionBiasRearDelegate(uint _modelHash, float _value);
        private static void Handling_SetTractionBiasRearFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetTractionBiasRear", "Handling_SetTractionBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetTractionCurveLateralDelegate(uint _modelHash, float _value);
        private static void Handling_SetTractionCurveLateralFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetTractionCurveLateral", "Handling_SetTractionCurveLateral SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetTractionCurveLateralRatioDelegate(uint _modelHash, float _value);
        private static void Handling_SetTractionCurveLateralRatioFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetTractionCurveLateralRatio", "Handling_SetTractionCurveLateralRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetTractionCurveMaxDelegate(uint _modelHash, float _value);
        private static void Handling_SetTractionCurveMaxFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetTractionCurveMax", "Handling_SetTractionCurveMax SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetTractionCurveMaxRatioDelegate(uint _modelHash, float _value);
        private static void Handling_SetTractionCurveMaxRatioFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetTractionCurveMaxRatio", "Handling_SetTractionCurveMaxRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetTractionCurveMinDelegate(uint _modelHash, float _value);
        private static void Handling_SetTractionCurveMinFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetTractionCurveMin", "Handling_SetTractionCurveMin SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetTractionCurveMinRatioDelegate(uint _modelHash, float _value);
        private static void Handling_SetTractionCurveMinRatioFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetTractionCurveMinRatio", "Handling_SetTractionCurveMinRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetTractionLossMultDelegate(uint _modelHash, float _value);
        private static void Handling_SetTractionLossMultFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetTractionLossMult", "Handling_SetTractionLossMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetTractionSpringDeltaMaxDelegate(uint _modelHash, float _value);
        private static void Handling_SetTractionSpringDeltaMaxFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetTractionSpringDeltaMax", "Handling_SetTractionSpringDeltaMax SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetTractionSpringDeltaMaxRatioDelegate(uint _modelHash, float _value);
        private static void Handling_SetTractionSpringDeltaMaxRatioFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetTractionSpringDeltaMaxRatio", "Handling_SetTractionSpringDeltaMaxRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetunkFloat1Delegate(uint _modelHash, float _value);
        private static void Handling_SetunkFloat1Fallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetunkFloat1", "Handling_SetunkFloat1 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetunkFloat2Delegate(uint _modelHash, float _value);
        private static void Handling_SetunkFloat2Fallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetunkFloat2", "Handling_SetunkFloat2 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetunkFloat4Delegate(uint _modelHash, float _value);
        private static void Handling_SetunkFloat4Fallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetunkFloat4", "Handling_SetunkFloat4 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetunkFloat5Delegate(uint _modelHash, float _value);
        private static void Handling_SetunkFloat5Fallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetunkFloat5", "Handling_SetunkFloat5 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Handling_SetWeaponDamageMultDelegate(uint _modelHash, float _value);
        private static void Handling_SetWeaponDamageMultFallback(uint _modelHash, float _value) => throw new Exceptions.OutdatedSdkException("Handling_SetWeaponDamageMult", "Handling_SetWeaponDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void HttpClient_ConnectDelegate(nint _httpClient, nint _url, nint _body, ClientEvents.HttpResponseModuleDelegate _callback);
        private static void HttpClient_ConnectFallback(nint _httpClient, nint _url, nint _body, ClientEvents.HttpResponseModuleDelegate _callback) => throw new Exceptions.OutdatedSdkException("HttpClient_Connect", "HttpClient_Connect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void HttpClient_DeleteDelegate(nint _httpClient, nint _url, nint _body, ClientEvents.HttpResponseModuleDelegate _callback);
        private static void HttpClient_DeleteFallback(nint _httpClient, nint _url, nint _body, ClientEvents.HttpResponseModuleDelegate _callback) => throw new Exceptions.OutdatedSdkException("HttpClient_Delete", "HttpClient_Delete SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void HttpClient_GetDelegate(nint _httpClient, nint _url, ClientEvents.HttpResponseModuleDelegate _callback);
        private static void HttpClient_GetFallback(nint _httpClient, nint _url, ClientEvents.HttpResponseModuleDelegate _callback) => throw new Exceptions.OutdatedSdkException("HttpClient_Get", "HttpClient_Get SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint HttpClient_GetBaseObjectDelegate(nint _httpClient);
        private static nint HttpClient_GetBaseObjectFallback(nint _httpClient) => throw new Exceptions.OutdatedSdkException("HttpClient_GetBaseObject", "HttpClient_GetBaseObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void HttpClient_GetExtraHeadersDelegate(nint _httpClient, nint* _keys, nint* _values, int* _size);
        private static void HttpClient_GetExtraHeadersFallback(nint _httpClient, nint* _keys, nint* _values, int* _size) => throw new Exceptions.OutdatedSdkException("HttpClient_GetExtraHeaders", "HttpClient_GetExtraHeaders SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void HttpClient_HeadDelegate(nint _httpClient, nint _url, ClientEvents.HttpResponseModuleDelegate _callback);
        private static void HttpClient_HeadFallback(nint _httpClient, nint _url, ClientEvents.HttpResponseModuleDelegate _callback) => throw new Exceptions.OutdatedSdkException("HttpClient_Head", "HttpClient_Head SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void HttpClient_OptionsDelegate(nint _httpClient, nint _url, nint _body, ClientEvents.HttpResponseModuleDelegate _callback);
        private static void HttpClient_OptionsFallback(nint _httpClient, nint _url, nint _body, ClientEvents.HttpResponseModuleDelegate _callback) => throw new Exceptions.OutdatedSdkException("HttpClient_Options", "HttpClient_Options SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void HttpClient_PatchDelegate(nint _httpClient, nint _url, nint _body, ClientEvents.HttpResponseModuleDelegate _callback);
        private static void HttpClient_PatchFallback(nint _httpClient, nint _url, nint _body, ClientEvents.HttpResponseModuleDelegate _callback) => throw new Exceptions.OutdatedSdkException("HttpClient_Patch", "HttpClient_Patch SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void HttpClient_PostDelegate(nint _httpClient, nint _url, nint _body, ClientEvents.HttpResponseModuleDelegate _callback);
        private static void HttpClient_PostFallback(nint _httpClient, nint _url, nint _body, ClientEvents.HttpResponseModuleDelegate _callback) => throw new Exceptions.OutdatedSdkException("HttpClient_Post", "HttpClient_Post SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void HttpClient_PutDelegate(nint _httpClient, nint _url, nint _body, ClientEvents.HttpResponseModuleDelegate _callback);
        private static void HttpClient_PutFallback(nint _httpClient, nint _url, nint _body, ClientEvents.HttpResponseModuleDelegate _callback) => throw new Exceptions.OutdatedSdkException("HttpClient_Put", "HttpClient_Put SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void HttpClient_SetExtraHeaderDelegate(nint _httpClient, nint _key, nint _value);
        private static void HttpClient_SetExtraHeaderFallback(nint _httpClient, nint _key, nint _value) => throw new Exceptions.OutdatedSdkException("HttpClient_SetExtraHeader", "HttpClient_SetExtraHeader SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void HttpClient_TraceDelegate(nint _httpClient, nint _url, nint _body, ClientEvents.HttpResponseModuleDelegate _callback);
        private static void HttpClient_TraceFallback(nint _httpClient, nint _url, nint _body, ClientEvents.HttpResponseModuleDelegate _callback) => throw new Exceptions.OutdatedSdkException("HttpClient_Trace", "HttpClient_Trace SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint LocalPed_GetRemoteIDDelegate(nint _localPed);
        private static uint LocalPed_GetRemoteIDFallback(nint _localPed) => throw new Exceptions.OutdatedSdkException("LocalPed_GetRemoteID", "LocalPed_GetRemoteID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint LocalPed_GetScriptIDDelegate(nint _localPed);
        private static uint LocalPed_GetScriptIDFallback(nint _localPed) => throw new Exceptions.OutdatedSdkException("LocalPed_GetScriptID", "LocalPed_GetScriptID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte LocalPed_IsRemoteDelegate(nint _localPed);
        private static byte LocalPed_IsRemoteFallback(nint _localPed) => throw new Exceptions.OutdatedSdkException("LocalPed_IsRemote", "LocalPed_IsRemote SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte LocalPed_IsStreamedInDelegate(nint _localPed);
        private static byte LocalPed_IsStreamedInFallback(nint _localPed) => throw new Exceptions.OutdatedSdkException("LocalPed_IsStreamedIn", "LocalPed_IsStreamedIn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort LocalPlayer_GetCurrentAmmoDelegate(nint _localPlayer);
        private static ushort LocalPlayer_GetCurrentAmmoFallback(nint _localPlayer) => throw new Exceptions.OutdatedSdkException("LocalPlayer_GetCurrentAmmo", "LocalPlayer_GetCurrentAmmo SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint LocalPlayer_GetCurrentWeaponHashDelegate(nint _localPlayer);
        private static uint LocalPlayer_GetCurrentWeaponHashFallback(nint _localPlayer) => throw new Exceptions.OutdatedSdkException("LocalPlayer_GetCurrentWeaponHash", "LocalPlayer_GetCurrentWeaponHash SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort LocalPlayer_GetIDDelegate(nint _localPlayer);
        private static ushort LocalPlayer_GetIDFallback(nint _localPlayer) => throw new Exceptions.OutdatedSdkException("LocalPlayer_GetID", "LocalPlayer_GetID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float LocalPlayer_GetMaxStaminaDelegate(nint _localPlayer);
        private static float LocalPlayer_GetMaxStaminaFallback(nint _localPlayer) => throw new Exceptions.OutdatedSdkException("LocalPlayer_GetMaxStamina", "LocalPlayer_GetMaxStamina SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint LocalPlayer_GetPlayerDelegate(nint _player);
        private static nint LocalPlayer_GetPlayerFallback(nint _player) => throw new Exceptions.OutdatedSdkException("LocalPlayer_GetPlayer", "LocalPlayer_GetPlayer SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float LocalPlayer_GetStaminaDelegate(nint _localPlayer);
        private static float LocalPlayer_GetStaminaFallback(nint _localPlayer) => throw new Exceptions.OutdatedSdkException("LocalPlayer_GetStamina", "LocalPlayer_GetStamina SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort LocalPlayer_GetWeaponAmmoDelegate(nint _localPlayer, uint _weaponHash);
        private static ushort LocalPlayer_GetWeaponAmmoFallback(nint _localPlayer, uint _weaponHash) => throw new Exceptions.OutdatedSdkException("LocalPlayer_GetWeaponAmmo", "LocalPlayer_GetWeaponAmmo SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void LocalPlayer_GetWeaponComponentsDelegate(nint _localPlayer, uint _weaponHash, nint* _weaponComponents, uint* _size);
        private static void LocalPlayer_GetWeaponComponentsFallback(nint _localPlayer, uint _weaponHash, nint* _weaponComponents, uint* _size) => throw new Exceptions.OutdatedSdkException("LocalPlayer_GetWeaponComponents", "LocalPlayer_GetWeaponComponents SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void LocalPlayer_GetWeaponsDelegate(nint _localPlayer, nint* _weapons, uint* _size);
        private static void LocalPlayer_GetWeaponsFallback(nint _localPlayer, nint* _weapons, uint* _size) => throw new Exceptions.OutdatedSdkException("LocalPlayer_GetWeapons", "LocalPlayer_GetWeapons SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte LocalPlayer_HasWeaponDelegate(nint _localPlayer, uint _weaponHash);
        private static byte LocalPlayer_HasWeaponFallback(nint _localPlayer, uint _weaponHash) => throw new Exceptions.OutdatedSdkException("LocalPlayer_HasWeapon", "LocalPlayer_HasWeapon SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void LocalPlayer_SetMaxStaminaDelegate(nint _localPlayer, float _stamina);
        private static void LocalPlayer_SetMaxStaminaFallback(nint _localPlayer, float _stamina) => throw new Exceptions.OutdatedSdkException("LocalPlayer_SetMaxStamina", "LocalPlayer_SetMaxStamina SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void LocalPlayer_SetStaminaDelegate(nint _localPlayer, float _stamina);
        private static void LocalPlayer_SetStaminaFallback(nint _localPlayer, float _stamina) => throw new Exceptions.OutdatedSdkException("LocalPlayer_SetStamina", "LocalPlayer_SetStamina SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void LocalStorage_ClearDelegate(nint _localStorage);
        private static void LocalStorage_ClearFallback(nint _localStorage) => throw new Exceptions.OutdatedSdkException("LocalStorage_Clear", "LocalStorage_Clear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void LocalStorage_DeleteKeyDelegate(nint _localStorage, nint _key);
        private static void LocalStorage_DeleteKeyFallback(nint _localStorage, nint _key) => throw new Exceptions.OutdatedSdkException("LocalStorage_DeleteKey", "LocalStorage_DeleteKey SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint LocalStorage_GetKeyDelegate(nint _localStorage, nint _key);
        private static nint LocalStorage_GetKeyFallback(nint _localStorage, nint _key) => throw new Exceptions.OutdatedSdkException("LocalStorage_GetKey", "LocalStorage_GetKey SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void LocalStorage_SaveDelegate(nint _localStorage);
        private static void LocalStorage_SaveFallback(nint _localStorage) => throw new Exceptions.OutdatedSdkException("LocalStorage_Save", "LocalStorage_Save SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void LocalStorage_SetKeyDelegate(nint _localStorage, nint _key, nint _value);
        private static void LocalStorage_SetKeyFallback(nint _localStorage, nint _key, nint _value) => throw new Exceptions.OutdatedSdkException("LocalStorage_SetKey", "LocalStorage_SetKey SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint LocalVehicle_GetRemoteIDDelegate(nint _localVehicle);
        private static uint LocalVehicle_GetRemoteIDFallback(nint _localVehicle) => throw new Exceptions.OutdatedSdkException("LocalVehicle_GetRemoteID", "LocalVehicle_GetRemoteID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint LocalVehicle_GetScriptIDDelegate(nint _localVehicle);
        private static uint LocalVehicle_GetScriptIDFallback(nint _localVehicle) => throw new Exceptions.OutdatedSdkException("LocalVehicle_GetScriptID", "LocalVehicle_GetScriptID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte LocalVehicle_IsRemoteDelegate(nint _localVehicle);
        private static byte LocalVehicle_IsRemoteFallback(nint _localVehicle) => throw new Exceptions.OutdatedSdkException("LocalVehicle_IsRemote", "LocalVehicle_IsRemote SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte LocalVehicle_IsStreamedInDelegate(nint _localVehicle);
        private static byte LocalVehicle_IsStreamedInFallback(nint _localVehicle) => throw new Exceptions.OutdatedSdkException("LocalVehicle_IsStreamedIn", "LocalVehicle_IsStreamedIn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float MapData_GetFScrollSpeedDelegate(uint _id);
        private static float MapData_GetFScrollSpeedFallback(uint _id) => throw new Exceptions.OutdatedSdkException("MapData_GetFScrollSpeed", "MapData_GetFScrollSpeed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float MapData_GetFZoomScaleDelegate(uint _id);
        private static float MapData_GetFZoomScaleFallback(uint _id) => throw new Exceptions.OutdatedSdkException("MapData_GetFZoomScale", "MapData_GetFZoomScale SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float MapData_GetFZoomSpeedDelegate(uint _id);
        private static float MapData_GetFZoomSpeedFallback(uint _id) => throw new Exceptions.OutdatedSdkException("MapData_GetFZoomSpeed", "MapData_GetFZoomSpeed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float MapData_GetVTilesXDelegate(uint _id);
        private static float MapData_GetVTilesXFallback(uint _id) => throw new Exceptions.OutdatedSdkException("MapData_GetVTilesX", "MapData_GetVTilesX SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float MapData_GetVTilesYDelegate(uint _id);
        private static float MapData_GetVTilesYFallback(uint _id) => throw new Exceptions.OutdatedSdkException("MapData_GetVTilesY", "MapData_GetVTilesY SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void MapData_SetFScrollSpeedDelegate(uint _id, float _value);
        private static void MapData_SetFScrollSpeedFallback(uint _id, float _value) => throw new Exceptions.OutdatedSdkException("MapData_SetFScrollSpeed", "MapData_SetFScrollSpeed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void MapData_SetFZoomScaleDelegate(uint _id, float _value);
        private static void MapData_SetFZoomScaleFallback(uint _id, float _value) => throw new Exceptions.OutdatedSdkException("MapData_SetFZoomScale", "MapData_SetFZoomScale SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void MapData_SetFZoomSpeedDelegate(uint _id, float _value);
        private static void MapData_SetFZoomSpeedFallback(uint _id, float _value) => throw new Exceptions.OutdatedSdkException("MapData_SetFZoomSpeed", "MapData_SetFZoomSpeed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void MapData_SetVTilesXDelegate(uint _id, float _value);
        private static void MapData_SetVTilesXFallback(uint _id, float _value) => throw new Exceptions.OutdatedSdkException("MapData_SetVTilesX", "MapData_SetVTilesX SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void MapData_SetVTilesYDelegate(uint _id, float _value);
        private static void MapData_SetVTilesYFallback(uint _id, float _value) => throw new Exceptions.OutdatedSdkException("MapData_SetVTilesY", "MapData_SetVTilesY SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Marker_GetRemoteIDDelegate(nint _marker);
        private static uint Marker_GetRemoteIDFallback(nint _marker) => throw new Exceptions.OutdatedSdkException("Marker_GetRemoteID", "Marker_GetRemoteID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Marker_IsRemoteDelegate(nint _marker);
        private static byte Marker_IsRemoteFallback(nint _marker) => throw new Exceptions.OutdatedSdkException("Marker_IsRemote", "Marker_IsRemote SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Object_IsRemoteDelegate(nint _object);
        private static byte Object_IsRemoteFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_IsRemote", "Object_IsRemote SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Object_IsStreamedInDelegate(nint _object);
        private static byte Object_IsStreamedInFallback(nint _object) => throw new Exceptions.OutdatedSdkException("Object_IsStreamedIn", "Object_IsStreamedIn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Player_GetLocalDelegate();
        private static nint Player_GetLocalFallback() => throw new Exceptions.OutdatedSdkException("Player_GetLocal", "Player_GetLocal SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Player_GetMicLevelDelegate(nint _player);
        private static float Player_GetMicLevelFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetMicLevel", "Player_GetMicLevel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Player_GetNonSpatialVolumeDelegate(nint _player);
        private static float Player_GetNonSpatialVolumeFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetNonSpatialVolume", "Player_GetNonSpatialVolume SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Player_GetSpatialVolumeDelegate(nint _player);
        private static float Player_GetSpatialVolumeFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_GetSpatialVolume", "Player_GetSpatialVolume SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Player_IsTalkingDelegate(nint _player);
        private static byte Player_IsTalkingFallback(nint _player) => throw new Exceptions.OutdatedSdkException("Player_IsTalking", "Player_IsTalking SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetNonSpatialVolumeDelegate(nint _player, float _value);
        private static void Player_SetNonSpatialVolumeFallback(nint _player, float _value) => throw new Exceptions.OutdatedSdkException("Player_SetNonSpatialVolume", "Player_SetNonSpatialVolume SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Player_SetSpatialVolumeDelegate(nint _player, float _value);
        private static void Player_SetSpatialVolumeFallback(nint _player, float _value) => throw new Exceptions.OutdatedSdkException("Player_SetSpatialVolume", "Player_SetSpatialVolume SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate bool Resource_FileExistsDelegate(nint _resource, nint _path);
        private static bool Resource_FileExistsFallback(nint _resource, nint _path) => throw new Exceptions.OutdatedSdkException("Resource_FileExists", "Resource_FileExists SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Resource_GetFileDelegate(nint _resource, nint _path, int* _bufferSize, nint* _buffer);
        private static void Resource_GetFileFallback(nint _resource, nint _path, int* _bufferSize, nint* _buffer) => throw new Exceptions.OutdatedSdkException("Resource_GetFile", "Resource_GetFile SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Resource_GetLocalStorageDelegate(nint _resource);
        private static nint Resource_GetLocalStorageFallback(nint _resource) => throw new Exceptions.OutdatedSdkException("Resource_GetLocalStorage", "Resource_GetLocalStorage SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlDocument_CreateElementDelegate(nint _rmlDocument, nint _tag);
        private static nint RmlDocument_CreateElementFallback(nint _rmlDocument, nint _tag) => throw new Exceptions.OutdatedSdkException("RmlDocument_CreateElement", "RmlDocument_CreateElement SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlDocument_CreateTextNodeDelegate(nint _rmlDocument, nint _text);
        private static nint RmlDocument_CreateTextNodeFallback(nint _rmlDocument, nint _text) => throw new Exceptions.OutdatedSdkException("RmlDocument_CreateTextNode", "RmlDocument_CreateTextNode SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlDocument_GetBodyDelegate(nint _rmlDocument);
        private static nint RmlDocument_GetBodyFallback(nint _rmlDocument) => throw new Exceptions.OutdatedSdkException("RmlDocument_GetBody", "RmlDocument_GetBody SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlDocument_GetRmlElementDelegate(nint _rmlDocument);
        private static nint RmlDocument_GetRmlElementFallback(nint _rmlDocument) => throw new Exceptions.OutdatedSdkException("RmlDocument_GetRmlElement", "RmlDocument_GetRmlElement SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlDocument_GetSourceUrlDelegate(nint _rmlDocument, int* _size);
        private static nint RmlDocument_GetSourceUrlFallback(nint _rmlDocument, int* _size) => throw new Exceptions.OutdatedSdkException("RmlDocument_GetSourceUrl", "RmlDocument_GetSourceUrl SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlDocument_GetTitleDelegate(nint _rmlDocument, int* _size);
        private static nint RmlDocument_GetTitleFallback(nint _rmlDocument, int* _size) => throw new Exceptions.OutdatedSdkException("RmlDocument_GetTitle", "RmlDocument_GetTitle SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlDocument_HideDelegate(nint _rmlDocument);
        private static void RmlDocument_HideFallback(nint _rmlDocument) => throw new Exceptions.OutdatedSdkException("RmlDocument_Hide", "RmlDocument_Hide SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlDocument_IsModalDelegate(nint _rmlDocument);
        private static byte RmlDocument_IsModalFallback(nint _rmlDocument) => throw new Exceptions.OutdatedSdkException("RmlDocument_IsModal", "RmlDocument_IsModal SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlDocument_IsVisibleDelegate(nint _rmlDocument);
        private static byte RmlDocument_IsVisibleFallback(nint _rmlDocument) => throw new Exceptions.OutdatedSdkException("RmlDocument_IsVisible", "RmlDocument_IsVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlDocument_SetTitleDelegate(nint _rmlDocument, nint _title);
        private static void RmlDocument_SetTitleFallback(nint _rmlDocument, nint _title) => throw new Exceptions.OutdatedSdkException("RmlDocument_SetTitle", "RmlDocument_SetTitle SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlDocument_ShowDelegate(nint _rmlDocument, byte _isModal, byte _focused);
        private static void RmlDocument_ShowFallback(nint _rmlDocument, byte _isModal, byte _focused) => throw new Exceptions.OutdatedSdkException("RmlDocument_Show", "RmlDocument_Show SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlDocument_UpdateDelegate(nint _rmlDocument);
        private static void RmlDocument_UpdateFallback(nint _rmlDocument) => throw new Exceptions.OutdatedSdkException("RmlDocument_Update", "RmlDocument_Update SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_AddClassDelegate(nint _rmlElement, nint _name);
        private static void RmlElement_AddClassFallback(nint _rmlElement, nint _name) => throw new Exceptions.OutdatedSdkException("RmlElement_AddClass", "RmlElement_AddClass SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_AddPseudoClassDelegate(nint _rmlElement, nint _name);
        private static void RmlElement_AddPseudoClassFallback(nint _rmlElement, nint _name) => throw new Exceptions.OutdatedSdkException("RmlElement_AddPseudoClass", "RmlElement_AddPseudoClass SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_AppendChildDelegate(nint _rmlElement, nint _child);
        private static void RmlElement_AppendChildFallback(nint _rmlElement, nint _child) => throw new Exceptions.OutdatedSdkException("RmlElement_AppendChild", "RmlElement_AppendChild SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_BlurDelegate(nint _rmlElement);
        private static void RmlElement_BlurFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_Blur", "RmlElement_Blur SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_ClickDelegate(nint _rmlElement);
        private static void RmlElement_ClickFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_Click", "RmlElement_Click SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_FocusDelegate(nint _rmlElement);
        private static void RmlElement_FocusFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_Focus", "RmlElement_Focus SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetAbsoluteLeftDelegate(nint _rmlElement);
        private static float RmlElement_GetAbsoluteLeftFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetAbsoluteLeft", "RmlElement_GetAbsoluteLeft SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_GetAbsoluteOffsetDelegate(nint _rmlElement, Vector2* _offset);
        private static void RmlElement_GetAbsoluteOffsetFallback(nint _rmlElement, Vector2* _offset) => throw new Exceptions.OutdatedSdkException("RmlElement_GetAbsoluteOffset", "RmlElement_GetAbsoluteOffset SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetAbsoluteTopDelegate(nint _rmlElement);
        private static float RmlElement_GetAbsoluteTopFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetAbsoluteTop", "RmlElement_GetAbsoluteTop SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetAttributeDelegate(nint _rmlElement, nint _name, int* _size);
        private static nint RmlElement_GetAttributeFallback(nint _rmlElement, nint _name, int* _size) => throw new Exceptions.OutdatedSdkException("RmlElement_GetAttribute", "RmlElement_GetAttribute SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_GetAttributesDelegate(nint _rmlElement, nint* _keys, nint* _values, uint* _size);
        private static void RmlElement_GetAttributesFallback(nint _rmlElement, nint* _keys, nint* _values, uint* _size) => throw new Exceptions.OutdatedSdkException("RmlElement_GetAttributes", "RmlElement_GetAttributes SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetBaselineDelegate(nint _rmlElement);
        private static float RmlElement_GetBaselineFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetBaseline", "RmlElement_GetBaseline SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetBaseObjectDelegate(nint _rmlElement);
        private static nint RmlElement_GetBaseObjectFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetBaseObject", "RmlElement_GetBaseObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint RmlElement_GetChildCountDelegate(nint _rmlElement);
        private static uint RmlElement_GetChildCountFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetChildCount", "RmlElement_GetChildCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_GetChildNodesDelegate(nint _rmlElement, nint* _arr, uint* _size);
        private static void RmlElement_GetChildNodesFallback(nint _rmlElement, nint* _arr, uint* _size) => throw new Exceptions.OutdatedSdkException("RmlElement_GetChildNodes", "RmlElement_GetChildNodes SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_GetClassListDelegate(nint _rmlElement, nint* _classes, uint* _size);
        private static void RmlElement_GetClassListFallback(nint _rmlElement, nint* _classes, uint* _size) => throw new Exceptions.OutdatedSdkException("RmlElement_GetClassList", "RmlElement_GetClassList SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetClientHeightDelegate(nint _rmlElement);
        private static float RmlElement_GetClientHeightFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetClientHeight", "RmlElement_GetClientHeight SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetClientLeftDelegate(nint _rmlElement);
        private static float RmlElement_GetClientLeftFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetClientLeft", "RmlElement_GetClientLeft SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetClientTopDelegate(nint _rmlElement);
        private static float RmlElement_GetClientTopFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetClientTop", "RmlElement_GetClientTop SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetClientWidthDelegate(nint _rmlElement);
        private static float RmlElement_GetClientWidthFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetClientWidth", "RmlElement_GetClientWidth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetClosestDelegate(nint _rmlElement, nint _selectors);
        private static nint RmlElement_GetClosestFallback(nint _rmlElement, nint _selectors) => throw new Exceptions.OutdatedSdkException("RmlElement_GetClosest", "RmlElement_GetClosest SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_GetContainingBlockDelegate(nint _rmlElement, Vector2* _containingBlock);
        private static void RmlElement_GetContainingBlockFallback(nint _rmlElement, Vector2* _containingBlock) => throw new Exceptions.OutdatedSdkException("RmlElement_GetContainingBlock", "RmlElement_GetContainingBlock SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetElementByIdDelegate(nint _rmlElement, nint _id);
        private static nint RmlElement_GetElementByIdFallback(nint _rmlElement, nint _id) => throw new Exceptions.OutdatedSdkException("RmlElement_GetElementById", "RmlElement_GetElementById SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_GetElementsByClassNameDelegate(nint _rmlElement, nint _className, nint* _arr, uint* _size);
        private static void RmlElement_GetElementsByClassNameFallback(nint _rmlElement, nint _className, nint* _arr, uint* _size) => throw new Exceptions.OutdatedSdkException("RmlElement_GetElementsByClassName", "RmlElement_GetElementsByClassName SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_GetElementsByTagNameDelegate(nint _rmlElement, nint _tagName, nint* _arr, uint* _size);
        private static void RmlElement_GetElementsByTagNameFallback(nint _rmlElement, nint _tagName, nint* _arr, uint* _size) => throw new Exceptions.OutdatedSdkException("RmlElement_GetElementsByTagName", "RmlElement_GetElementsByTagName SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetFirstChildDelegate(nint _rmlElement);
        private static nint RmlElement_GetFirstChildFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetFirstChild", "RmlElement_GetFirstChild SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetFocusedElementDelegate(nint _rmlElement);
        private static nint RmlElement_GetFocusedElementFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetFocusedElement", "RmlElement_GetFocusedElement SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetInnerRmlDelegate(nint _rmlElement, int* _size);
        private static nint RmlElement_GetInnerRmlFallback(nint _rmlElement, int* _size) => throw new Exceptions.OutdatedSdkException("RmlElement_GetInnerRml", "RmlElement_GetInnerRml SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetLastChildDelegate(nint _rmlElement);
        private static nint RmlElement_GetLastChildFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetLastChild", "RmlElement_GetLastChild SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetLocalPropertyDelegate(nint _rmlElement, nint _name, int* _size);
        private static nint RmlElement_GetLocalPropertyFallback(nint _rmlElement, nint _name, int* _size) => throw new Exceptions.OutdatedSdkException("RmlElement_GetLocalProperty", "RmlElement_GetLocalProperty SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetNextSiblingDelegate(nint _rmlElement);
        private static nint RmlElement_GetNextSiblingFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetNextSibling", "RmlElement_GetNextSibling SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetOffsetHeightDelegate(nint _rmlElement);
        private static float RmlElement_GetOffsetHeightFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetOffsetHeight", "RmlElement_GetOffsetHeight SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetOffsetLeftDelegate(nint _rmlElement);
        private static float RmlElement_GetOffsetLeftFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetOffsetLeft", "RmlElement_GetOffsetLeft SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetOffsetTopDelegate(nint _rmlElement);
        private static float RmlElement_GetOffsetTopFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetOffsetTop", "RmlElement_GetOffsetTop SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetOffsetWidthDelegate(nint _rmlElement);
        private static float RmlElement_GetOffsetWidthFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetOffsetWidth", "RmlElement_GetOffsetWidth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetOwnerDocumentDelegate(nint _rmlElement);
        private static nint RmlElement_GetOwnerDocumentFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetOwnerDocument", "RmlElement_GetOwnerDocument SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetParentDelegate(nint _rmlElement);
        private static nint RmlElement_GetParentFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetParent", "RmlElement_GetParent SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetPreviousSiblingDelegate(nint _rmlElement);
        private static nint RmlElement_GetPreviousSiblingFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetPreviousSibling", "RmlElement_GetPreviousSibling SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetPropertyDelegate(nint _rmlElement, nint _name, int* _size);
        private static nint RmlElement_GetPropertyFallback(nint _rmlElement, nint _name, int* _size) => throw new Exceptions.OutdatedSdkException("RmlElement_GetProperty", "RmlElement_GetProperty SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetPropertyAbsoluteValueDelegate(nint _rmlElement, nint _name);
        private static float RmlElement_GetPropertyAbsoluteValueFallback(nint _rmlElement, nint _name) => throw new Exceptions.OutdatedSdkException("RmlElement_GetPropertyAbsoluteValue", "RmlElement_GetPropertyAbsoluteValue SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_GetPseudoClassListDelegate(nint _rmlElement, nint* _classes, uint* _size);
        private static void RmlElement_GetPseudoClassListFallback(nint _rmlElement, nint* _classes, uint* _size) => throw new Exceptions.OutdatedSdkException("RmlElement_GetPseudoClassList", "RmlElement_GetPseudoClassList SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_GetRelativeOffsetDelegate(nint _rmlElement, Vector2* _offset);
        private static void RmlElement_GetRelativeOffsetFallback(nint _rmlElement, Vector2* _offset) => throw new Exceptions.OutdatedSdkException("RmlElement_GetRelativeOffset", "RmlElement_GetRelativeOffset SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetRmlIdDelegate(nint _rmlElement, int* _size);
        private static nint RmlElement_GetRmlIdFallback(nint _rmlElement, int* _size) => throw new Exceptions.OutdatedSdkException("RmlElement_GetRmlId", "RmlElement_GetRmlId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetScrollHeightDelegate(nint _rmlElement);
        private static float RmlElement_GetScrollHeightFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetScrollHeight", "RmlElement_GetScrollHeight SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetScrollLeftDelegate(nint _rmlElement);
        private static float RmlElement_GetScrollLeftFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetScrollLeft", "RmlElement_GetScrollLeft SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetScrollTopDelegate(nint _rmlElement);
        private static float RmlElement_GetScrollTopFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetScrollTop", "RmlElement_GetScrollTop SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetScrollWidthDelegate(nint _rmlElement);
        private static float RmlElement_GetScrollWidthFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetScrollWidth", "RmlElement_GetScrollWidth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_GetTagNameDelegate(nint _rmlElement, int* _size);
        private static nint RmlElement_GetTagNameFallback(nint _rmlElement, int* _size) => throw new Exceptions.OutdatedSdkException("RmlElement_GetTagName", "RmlElement_GetTagName SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float RmlElement_GetZIndexDelegate(nint _rmlElement);
        private static float RmlElement_GetZIndexFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_GetZIndex", "RmlElement_GetZIndex SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlElement_HasAttributeDelegate(nint _rmlElement, nint _name);
        private static byte RmlElement_HasAttributeFallback(nint _rmlElement, nint _name) => throw new Exceptions.OutdatedSdkException("RmlElement_HasAttribute", "RmlElement_HasAttribute SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlElement_HasChildrenDelegate(nint _rmlElement);
        private static byte RmlElement_HasChildrenFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_HasChildren", "RmlElement_HasChildren SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlElement_HasClassDelegate(nint _rmlElement, nint _name);
        private static byte RmlElement_HasClassFallback(nint _rmlElement, nint _name) => throw new Exceptions.OutdatedSdkException("RmlElement_HasClass", "RmlElement_HasClass SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlElement_HasLocalPropertyDelegate(nint _rmlElement, nint _name);
        private static byte RmlElement_HasLocalPropertyFallback(nint _rmlElement, nint _name) => throw new Exceptions.OutdatedSdkException("RmlElement_HasLocalProperty", "RmlElement_HasLocalProperty SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlElement_HasPropertyDelegate(nint _rmlElement, nint _name);
        private static byte RmlElement_HasPropertyFallback(nint _rmlElement, nint _name) => throw new Exceptions.OutdatedSdkException("RmlElement_HasProperty", "RmlElement_HasProperty SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlElement_HasPseudoClassDelegate(nint _rmlElement, nint _name);
        private static byte RmlElement_HasPseudoClassFallback(nint _rmlElement, nint _name) => throw new Exceptions.OutdatedSdkException("RmlElement_HasPseudoClass", "RmlElement_HasPseudoClass SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_InsertBeforeDelegate(nint _rmlElement, nint _child, nint _adjacent);
        private static void RmlElement_InsertBeforeFallback(nint _rmlElement, nint _child, nint _adjacent) => throw new Exceptions.OutdatedSdkException("RmlElement_InsertBefore", "RmlElement_InsertBefore SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlElement_IsOwnedDelegate(nint _rmlElement);
        private static byte RmlElement_IsOwnedFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_IsOwned", "RmlElement_IsOwned SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlElement_IsPointWithinElementDelegate(nint _rmlElement, Vector2 _point);
        private static byte RmlElement_IsPointWithinElementFallback(nint _rmlElement, Vector2 _point) => throw new Exceptions.OutdatedSdkException("RmlElement_IsPointWithinElement", "RmlElement_IsPointWithinElement SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlElement_IsVisibleDelegate(nint _rmlElement);
        private static byte RmlElement_IsVisibleFallback(nint _rmlElement) => throw new Exceptions.OutdatedSdkException("RmlElement_IsVisible", "RmlElement_IsVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint RmlElement_QuerySelectorDelegate(nint _rmlElement, nint _selector);
        private static nint RmlElement_QuerySelectorFallback(nint _rmlElement, nint _selector) => throw new Exceptions.OutdatedSdkException("RmlElement_QuerySelector", "RmlElement_QuerySelector SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_QuerySelectorAllDelegate(nint _rmlElement, nint _selector, nint* _arr, uint* _size);
        private static void RmlElement_QuerySelectorAllFallback(nint _rmlElement, nint _selector, nint* _arr, uint* _size) => throw new Exceptions.OutdatedSdkException("RmlElement_QuerySelectorAll", "RmlElement_QuerySelectorAll SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlElement_RemoveAttributeDelegate(nint _rmlElement, nint _name);
        private static byte RmlElement_RemoveAttributeFallback(nint _rmlElement, nint _name) => throw new Exceptions.OutdatedSdkException("RmlElement_RemoveAttribute", "RmlElement_RemoveAttribute SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_RemoveChildDelegate(nint _rmlElement, nint _child);
        private static void RmlElement_RemoveChildFallback(nint _rmlElement, nint _child) => throw new Exceptions.OutdatedSdkException("RmlElement_RemoveChild", "RmlElement_RemoveChild SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlElement_RemoveClassDelegate(nint _rmlElement, nint _name);
        private static byte RmlElement_RemoveClassFallback(nint _rmlElement, nint _name) => throw new Exceptions.OutdatedSdkException("RmlElement_RemoveClass", "RmlElement_RemoveClass SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlElement_RemovePropertyDelegate(nint _rmlElement, nint _name);
        private static byte RmlElement_RemovePropertyFallback(nint _rmlElement, nint _name) => throw new Exceptions.OutdatedSdkException("RmlElement_RemoveProperty", "RmlElement_RemoveProperty SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte RmlElement_RemovePseudoClassDelegate(nint _rmlElement, nint _name);
        private static byte RmlElement_RemovePseudoClassFallback(nint _rmlElement, nint _name) => throw new Exceptions.OutdatedSdkException("RmlElement_RemovePseudoClass", "RmlElement_RemovePseudoClass SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_ReplaceChildDelegate(nint _rmlElement, nint _newElem, nint _oldElem);
        private static void RmlElement_ReplaceChildFallback(nint _rmlElement, nint _newElem, nint _oldElem) => throw new Exceptions.OutdatedSdkException("RmlElement_ReplaceChild", "RmlElement_ReplaceChild SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_ScrollIntoViewDelegate(nint _rmlElement, byte _alignToTop);
        private static void RmlElement_ScrollIntoViewFallback(nint _rmlElement, byte _alignToTop) => throw new Exceptions.OutdatedSdkException("RmlElement_ScrollIntoView", "RmlElement_ScrollIntoView SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_SetAttributeDelegate(nint _rmlElement, nint _name, nint _value);
        private static void RmlElement_SetAttributeFallback(nint _rmlElement, nint _name, nint _value) => throw new Exceptions.OutdatedSdkException("RmlElement_SetAttribute", "RmlElement_SetAttribute SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_SetIdDelegate(nint _rmlElement, nint _value);
        private static void RmlElement_SetIdFallback(nint _rmlElement, nint _value) => throw new Exceptions.OutdatedSdkException("RmlElement_SetId", "RmlElement_SetId SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_SetInnerRmlDelegate(nint _rmlElement, nint _value);
        private static void RmlElement_SetInnerRmlFallback(nint _rmlElement, nint _value) => throw new Exceptions.OutdatedSdkException("RmlElement_SetInnerRml", "RmlElement_SetInnerRml SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_SetOffsetDelegate(nint _rmlElement, nint _element, Vector2 _offset, byte _fixed);
        private static void RmlElement_SetOffsetFallback(nint _rmlElement, nint _element, Vector2 _offset, byte _fixed) => throw new Exceptions.OutdatedSdkException("RmlElement_SetOffset", "RmlElement_SetOffset SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_SetPropertyDelegate(nint _rmlElement, nint _name, nint _value);
        private static void RmlElement_SetPropertyFallback(nint _rmlElement, nint _name, nint _value) => throw new Exceptions.OutdatedSdkException("RmlElement_SetProperty", "RmlElement_SetProperty SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_SetScrollLeftDelegate(nint _rmlElement, float _value);
        private static void RmlElement_SetScrollLeftFallback(nint _rmlElement, float _value) => throw new Exceptions.OutdatedSdkException("RmlElement_SetScrollLeft", "RmlElement_SetScrollLeft SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void RmlElement_SetScrollTopDelegate(nint _rmlElement, float _value);
        private static void RmlElement_SetScrollTopFallback(nint _rmlElement, float _value) => throw new Exceptions.OutdatedSdkException("RmlElement_SetScrollTop", "RmlElement_SetScrollTop SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint TextLabel_GetRemoteIDDelegate(nint _textLabel);
        private static uint TextLabel_GetRemoteIDFallback(nint _textLabel) => throw new Exceptions.OutdatedSdkException("TextLabel_GetRemoteID", "TextLabel_GetRemoteID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte TextLabel_IsRemoteDelegate(nint _textLabel);
        private static byte TextLabel_IsRemoteFallback(nint _textLabel) => throw new Exceptions.OutdatedSdkException("TextLabel_IsRemote", "TextLabel_IsRemote SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetAbsLightStateDelegate(nint _vehicle);
        private static byte Vehicle_GetAbsLightStateFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetAbsLightState", "Vehicle_GetAbsLightState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetBatteryLightStateDelegate(nint _vehicle);
        private static byte Vehicle_GetBatteryLightStateFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetBatteryLightState", "Vehicle_GetBatteryLightState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Vehicle_GetCurrentGearDelegate(nint _vehicle);
        private static ushort Vehicle_GetCurrentGearFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetCurrentGear", "Vehicle_GetCurrentGear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetCurrentRPMDelegate(nint _vehicle);
        private static float Vehicle_GetCurrentRPMFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetCurrentRPM", "Vehicle_GetCurrentRPM SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetEngineLightStateDelegate(nint _vehicle);
        private static byte Vehicle_GetEngineLightStateFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetEngineLightState", "Vehicle_GetEngineLightState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetEngineTemperatureDelegate(nint _vehicle);
        private static float Vehicle_GetEngineTemperatureFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetEngineTemperature", "Vehicle_GetEngineTemperature SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetFuelLevelDelegate(nint _vehicle);
        private static float Vehicle_GetFuelLevelFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetFuelLevel", "Vehicle_GetFuelLevel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetLightsIndicatorDelegate(nint _vehicle);
        private static byte Vehicle_GetLightsIndicatorFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetLightsIndicator", "Vehicle_GetLightsIndicator SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort Vehicle_GetMaxGearDelegate(nint _vehicle);
        private static ushort Vehicle_GetMaxGearFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetMaxGear", "Vehicle_GetMaxGear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetOccupiedSeatsCountDelegate(nint _vehicle);
        private static byte Vehicle_GetOccupiedSeatsCountFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetOccupiedSeatsCount", "Vehicle_GetOccupiedSeatsCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetOilLevelDelegate(nint _vehicle);
        private static float Vehicle_GetOilLevelFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetOilLevel", "Vehicle_GetOilLevel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetOilLightStateDelegate(nint _vehicle);
        private static byte Vehicle_GetOilLightStateFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetOilLightState", "Vehicle_GetOilLightState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetPetrolLightStateDelegate(nint _vehicle);
        private static byte Vehicle_GetPetrolLightStateFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetPetrolLightState", "Vehicle_GetPetrolLightState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_GetSeatCountDelegate(nint _vehicle);
        private static byte Vehicle_GetSeatCountFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetSeatCount", "Vehicle_GetSeatCount SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_GetSpeedVectorDelegate(nint _vehicle, Vector3* _vector);
        private static void Vehicle_GetSpeedVectorFallback(nint _vehicle, Vector3* _vector) => throw new Exceptions.OutdatedSdkException("Vehicle_GetSpeedVector", "Vehicle_GetSpeedVector SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetWheelCamberDelegate(nint _vehicle, byte _wheel);
        private static float Vehicle_GetWheelCamberFallback(nint _vehicle, byte _wheel) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWheelCamber", "Vehicle_GetWheelCamber SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetWheelHeightDelegate(nint _vehicle, byte _wheel);
        private static float Vehicle_GetWheelHeightFallback(nint _vehicle, byte _wheel) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWheelHeight", "Vehicle_GetWheelHeight SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetWheelRimRadiusDelegate(nint _vehicle, byte _wheel);
        private static float Vehicle_GetWheelRimRadiusFallback(nint _vehicle, byte _wheel) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWheelRimRadius", "Vehicle_GetWheelRimRadius SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetWheelSpeedDelegate(nint _vehicle);
        private static float Vehicle_GetWheelSpeedFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWheelSpeed", "Vehicle_GetWheelSpeed SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Vehicle_GetWheelSurfaceMaterialDelegate(nint _vehicle, byte _wheel);
        private static uint Vehicle_GetWheelSurfaceMaterialFallback(nint _vehicle, byte _wheel) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWheelSurfaceMaterial", "Vehicle_GetWheelSurfaceMaterial SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetWheelTrackWidthDelegate(nint _vehicle, byte _wheel);
        private static float Vehicle_GetWheelTrackWidthFallback(nint _vehicle, byte _wheel) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWheelTrackWidth", "Vehicle_GetWheelTrackWidth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetWheelTyreRadiusDelegate(nint _vehicle, byte _wheel);
        private static float Vehicle_GetWheelTyreRadiusFallback(nint _vehicle, byte _wheel) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWheelTyreRadius", "Vehicle_GetWheelTyreRadius SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_GetWheelTyreWidthDelegate(nint _vehicle, byte _wheel);
        private static float Vehicle_GetWheelTyreWidthFallback(nint _vehicle, byte _wheel) => throw new Exceptions.OutdatedSdkException("Vehicle_GetWheelTyreWidth", "Vehicle_GetWheelTyreWidth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetAccelerationDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetAccelerationFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetAcceleration", "Vehicle_Handling_GetAcceleration SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetAntiRollBarBiasFrontDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetAntiRollBarBiasFrontFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetAntiRollBarBiasFront", "Vehicle_Handling_GetAntiRollBarBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetAntiRollBarBiasRearDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetAntiRollBarBiasRearFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetAntiRollBarBiasRear", "Vehicle_Handling_GetAntiRollBarBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetAntiRollBarForceDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetAntiRollBarForceFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetAntiRollBarForce", "Vehicle_Handling_GetAntiRollBarForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetBrakeBiasFrontDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetBrakeBiasFrontFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetBrakeBiasFront", "Vehicle_Handling_GetBrakeBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetBrakeBiasRearDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetBrakeBiasRearFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetBrakeBiasRear", "Vehicle_Handling_GetBrakeBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetBrakeForceDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetBrakeForceFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetBrakeForce", "Vehicle_Handling_GetBrakeForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetCamberStiffnessDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetCamberStiffnessFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetCamberStiffness", "Vehicle_Handling_GetCamberStiffness SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_GetCentreOfMassOffsetDelegate(nint _vehicle, Vector3* _offset);
        private static void Vehicle_Handling_GetCentreOfMassOffsetFallback(nint _vehicle, Vector3* _offset) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetCentreOfMassOffset", "Vehicle_Handling_GetCentreOfMassOffset SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetClutchChangeRateScaleDownShiftDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetClutchChangeRateScaleDownShiftFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetClutchChangeRateScaleDownShift", "Vehicle_Handling_GetClutchChangeRateScaleDownShift SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetClutchChangeRateScaleUpShiftDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetClutchChangeRateScaleUpShiftFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetClutchChangeRateScaleUpShift", "Vehicle_Handling_GetClutchChangeRateScaleUpShift SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetCollisionDamageMultDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetCollisionDamageMultFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetCollisionDamageMult", "Vehicle_Handling_GetCollisionDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Vehicle_Handling_GetDamageFlagsDelegate(nint _vehicle);
        private static uint Vehicle_Handling_GetDamageFlagsFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetDamageFlags", "Vehicle_Handling_GetDamageFlags SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetDeformationDamageMultDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetDeformationDamageMultFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetDeformationDamageMult", "Vehicle_Handling_GetDeformationDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetDownforceModifierDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetDownforceModifierFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetDownforceModifier", "Vehicle_Handling_GetDownforceModifier SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetDriveBiasFrontDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetDriveBiasFrontFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetDriveBiasFront", "Vehicle_Handling_GetDriveBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetDriveInertiaDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetDriveInertiaFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetDriveInertia", "Vehicle_Handling_GetDriveInertia SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetDriveMaxFlatVelDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetDriveMaxFlatVelFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetDriveMaxFlatVel", "Vehicle_Handling_GetDriveMaxFlatVel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetEngineDamageMultDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetEngineDamageMultFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetEngineDamageMult", "Vehicle_Handling_GetEngineDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetHandBrakeForceDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetHandBrakeForceFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetHandBrakeForce", "Vehicle_Handling_GetHandBrakeForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Vehicle_Handling_GetHandlingFlagsDelegate(nint _vehicle);
        private static uint Vehicle_Handling_GetHandlingFlagsFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetHandlingFlags", "Vehicle_Handling_GetHandlingFlags SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Vehicle_Handling_GetHandlingNameHashDelegate(nint _vehicle);
        private static uint Vehicle_Handling_GetHandlingNameHashFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetHandlingNameHash", "Vehicle_Handling_GetHandlingNameHash SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_GetInertiaMultiplierDelegate(nint _vehicle, Vector3* _offset);
        private static void Vehicle_Handling_GetInertiaMultiplierFallback(nint _vehicle, Vector3* _offset) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetInertiaMultiplier", "Vehicle_Handling_GetInertiaMultiplier SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetInitialDragCoeffDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetInitialDragCoeffFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetInitialDragCoeff", "Vehicle_Handling_GetInitialDragCoeff SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetInitialDriveForceDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetInitialDriveForceFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetInitialDriveForce", "Vehicle_Handling_GetInitialDriveForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Vehicle_Handling_GetInitialDriveGearsDelegate(nint _vehicle);
        private static uint Vehicle_Handling_GetInitialDriveGearsFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetInitialDriveGears", "Vehicle_Handling_GetInitialDriveGears SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetInitialDriveMaxFlatVelDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetInitialDriveMaxFlatVelFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetInitialDriveMaxFlatVel", "Vehicle_Handling_GetInitialDriveMaxFlatVel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetLowSpeedTractionLossMultDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetLowSpeedTractionLossMultFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetLowSpeedTractionLossMult", "Vehicle_Handling_GetLowSpeedTractionLossMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetMassDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetMassFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetMass", "Vehicle_Handling_GetMass SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Vehicle_Handling_GetModelFlagsDelegate(nint _vehicle);
        private static uint Vehicle_Handling_GetModelFlagsFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetModelFlags", "Vehicle_Handling_GetModelFlags SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint Vehicle_Handling_GetMonetaryValueDelegate(nint _vehicle);
        private static uint Vehicle_Handling_GetMonetaryValueFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetMonetaryValue", "Vehicle_Handling_GetMonetaryValue SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetOilVolumeDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetOilVolumeFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetOilVolume", "Vehicle_Handling_GetOilVolume SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetPercentSubmergedDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetPercentSubmergedFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetPercentSubmerged", "Vehicle_Handling_GetPercentSubmerged SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetPercentSubmergedRatioDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetPercentSubmergedRatioFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetPercentSubmergedRatio", "Vehicle_Handling_GetPercentSubmergedRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetPetrolTankVolumeDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetPetrolTankVolumeFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetPetrolTankVolume", "Vehicle_Handling_GetPetrolTankVolume SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetRollCentreHeightFrontDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetRollCentreHeightFrontFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetRollCentreHeightFront", "Vehicle_Handling_GetRollCentreHeightFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetRollCentreHeightRearDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetRollCentreHeightRearFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetRollCentreHeightRear", "Vehicle_Handling_GetRollCentreHeightRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetSeatOffsetDistXDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetSeatOffsetDistXFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetSeatOffsetDistX", "Vehicle_Handling_GetSeatOffsetDistX SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetSeatOffsetDistYDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetSeatOffsetDistYFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetSeatOffsetDistY", "Vehicle_Handling_GetSeatOffsetDistY SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetSeatOffsetDistZDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetSeatOffsetDistZFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetSeatOffsetDistZ", "Vehicle_Handling_GetSeatOffsetDistZ SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetSteeringLockDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetSteeringLockFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetSteeringLock", "Vehicle_Handling_GetSteeringLock SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetSteeringLockRatioDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetSteeringLockRatioFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetSteeringLockRatio", "Vehicle_Handling_GetSteeringLockRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetSuspensionBiasFrontDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetSuspensionBiasFrontFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetSuspensionBiasFront", "Vehicle_Handling_GetSuspensionBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetSuspensionBiasRearDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetSuspensionBiasRearFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetSuspensionBiasRear", "Vehicle_Handling_GetSuspensionBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetSuspensionCompDampDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetSuspensionCompDampFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetSuspensionCompDamp", "Vehicle_Handling_GetSuspensionCompDamp SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetSuspensionForceDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetSuspensionForceFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetSuspensionForce", "Vehicle_Handling_GetSuspensionForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetSuspensionLowerLimitDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetSuspensionLowerLimitFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetSuspensionLowerLimit", "Vehicle_Handling_GetSuspensionLowerLimit SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetSuspensionRaiseDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetSuspensionRaiseFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetSuspensionRaise", "Vehicle_Handling_GetSuspensionRaise SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetSuspensionReboundDampDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetSuspensionReboundDampFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetSuspensionReboundDamp", "Vehicle_Handling_GetSuspensionReboundDamp SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetSuspensionUpperLimitDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetSuspensionUpperLimitFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetSuspensionUpperLimit", "Vehicle_Handling_GetSuspensionUpperLimit SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetTractionBiasFrontDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetTractionBiasFrontFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetTractionBiasFront", "Vehicle_Handling_GetTractionBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetTractionBiasRearDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetTractionBiasRearFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetTractionBiasRear", "Vehicle_Handling_GetTractionBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetTractionCurveLateralDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetTractionCurveLateralFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetTractionCurveLateral", "Vehicle_Handling_GetTractionCurveLateral SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetTractionCurveLateralRatioDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetTractionCurveLateralRatioFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetTractionCurveLateralRatio", "Vehicle_Handling_GetTractionCurveLateralRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetTractionCurveMaxDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetTractionCurveMaxFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetTractionCurveMax", "Vehicle_Handling_GetTractionCurveMax SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetTractionCurveMaxRatioDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetTractionCurveMaxRatioFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetTractionCurveMaxRatio", "Vehicle_Handling_GetTractionCurveMaxRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetTractionCurveMinDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetTractionCurveMinFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetTractionCurveMin", "Vehicle_Handling_GetTractionCurveMin SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetTractionCurveMinRatioDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetTractionCurveMinRatioFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetTractionCurveMinRatio", "Vehicle_Handling_GetTractionCurveMinRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetTractionLossMultDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetTractionLossMultFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetTractionLossMult", "Vehicle_Handling_GetTractionLossMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetTractionSpringDeltaMaxDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetTractionSpringDeltaMaxFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetTractionSpringDeltaMax", "Vehicle_Handling_GetTractionSpringDeltaMax SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetTractionSpringDeltaMaxRatioDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetTractionSpringDeltaMaxRatioFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetTractionSpringDeltaMaxRatio", "Vehicle_Handling_GetTractionSpringDeltaMaxRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetunkFloat1Delegate(nint _vehicle);
        private static float Vehicle_Handling_GetunkFloat1Fallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetunkFloat1", "Vehicle_Handling_GetunkFloat1 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetunkFloat2Delegate(nint _vehicle);
        private static float Vehicle_Handling_GetunkFloat2Fallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetunkFloat2", "Vehicle_Handling_GetunkFloat2 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetunkFloat4Delegate(nint _vehicle);
        private static float Vehicle_Handling_GetunkFloat4Fallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetunkFloat4", "Vehicle_Handling_GetunkFloat4 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetunkFloat5Delegate(nint _vehicle);
        private static float Vehicle_Handling_GetunkFloat5Fallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetunkFloat5", "Vehicle_Handling_GetunkFloat5 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float Vehicle_Handling_GetWeaponDamageMultDelegate(nint _vehicle);
        private static float Vehicle_Handling_GetWeaponDamageMultFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_GetWeaponDamageMult", "Vehicle_Handling_GetWeaponDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetAccelerationDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetAccelerationFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetAcceleration", "Vehicle_Handling_SetAcceleration SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetAntiRollBarBiasFrontDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetAntiRollBarBiasFrontFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetAntiRollBarBiasFront", "Vehicle_Handling_SetAntiRollBarBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetAntiRollBarBiasRearDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetAntiRollBarBiasRearFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetAntiRollBarBiasRear", "Vehicle_Handling_SetAntiRollBarBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetAntiRollBarForceDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetAntiRollBarForceFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetAntiRollBarForce", "Vehicle_Handling_SetAntiRollBarForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetBrakeBiasFrontDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetBrakeBiasFrontFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetBrakeBiasFront", "Vehicle_Handling_SetBrakeBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetBrakeBiasRearDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetBrakeBiasRearFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetBrakeBiasRear", "Vehicle_Handling_SetBrakeBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetBrakeForceDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetBrakeForceFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetBrakeForce", "Vehicle_Handling_SetBrakeForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetCamberStiffnessDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetCamberStiffnessFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetCamberStiffness", "Vehicle_Handling_SetCamberStiffness SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetCentreOfMassOffsetDelegate(nint _vehicle, Vector3 _value);
        private static void Vehicle_Handling_SetCentreOfMassOffsetFallback(nint _vehicle, Vector3 _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetCentreOfMassOffset", "Vehicle_Handling_SetCentreOfMassOffset SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetClutchChangeRateScaleDownShiftDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetClutchChangeRateScaleDownShiftFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetClutchChangeRateScaleDownShift", "Vehicle_Handling_SetClutchChangeRateScaleDownShift SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetClutchChangeRateScaleUpShiftDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetClutchChangeRateScaleUpShiftFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetClutchChangeRateScaleUpShift", "Vehicle_Handling_SetClutchChangeRateScaleUpShift SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetCollisionDamageMultDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetCollisionDamageMultFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetCollisionDamageMult", "Vehicle_Handling_SetCollisionDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetDamageFlagsDelegate(nint _vehicle, uint _value);
        private static void Vehicle_Handling_SetDamageFlagsFallback(nint _vehicle, uint _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetDamageFlags", "Vehicle_Handling_SetDamageFlags SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetDeformationDamageMultDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetDeformationDamageMultFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetDeformationDamageMult", "Vehicle_Handling_SetDeformationDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetDownforceModifierDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetDownforceModifierFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetDownforceModifier", "Vehicle_Handling_SetDownforceModifier SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetDriveBiasFrontDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetDriveBiasFrontFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetDriveBiasFront", "Vehicle_Handling_SetDriveBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetDriveInertiaDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetDriveInertiaFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetDriveInertia", "Vehicle_Handling_SetDriveInertia SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetDriveMaxFlatVelDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetDriveMaxFlatVelFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetDriveMaxFlatVel", "Vehicle_Handling_SetDriveMaxFlatVel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetEngineDamageMultDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetEngineDamageMultFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetEngineDamageMult", "Vehicle_Handling_SetEngineDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetHandBrakeForceDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetHandBrakeForceFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetHandBrakeForce", "Vehicle_Handling_SetHandBrakeForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetHandlingFlagsDelegate(nint _vehicle, uint _value);
        private static void Vehicle_Handling_SetHandlingFlagsFallback(nint _vehicle, uint _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetHandlingFlags", "Vehicle_Handling_SetHandlingFlags SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetInertiaMultiplierDelegate(nint _vehicle, Vector3 _value);
        private static void Vehicle_Handling_SetInertiaMultiplierFallback(nint _vehicle, Vector3 _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetInertiaMultiplier", "Vehicle_Handling_SetInertiaMultiplier SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetInitialDragCoeffDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetInitialDragCoeffFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetInitialDragCoeff", "Vehicle_Handling_SetInitialDragCoeff SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetInitialDriveForceDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetInitialDriveForceFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetInitialDriveForce", "Vehicle_Handling_SetInitialDriveForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetInitialDriveGearsDelegate(nint _vehicle, uint _value);
        private static void Vehicle_Handling_SetInitialDriveGearsFallback(nint _vehicle, uint _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetInitialDriveGears", "Vehicle_Handling_SetInitialDriveGears SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetInitialDriveMaxFlatVelDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetInitialDriveMaxFlatVelFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetInitialDriveMaxFlatVel", "Vehicle_Handling_SetInitialDriveMaxFlatVel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetLowSpeedTractionLossMultDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetLowSpeedTractionLossMultFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetLowSpeedTractionLossMult", "Vehicle_Handling_SetLowSpeedTractionLossMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetMassDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetMassFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetMass", "Vehicle_Handling_SetMass SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetModelFlagsDelegate(nint _vehicle, uint _value);
        private static void Vehicle_Handling_SetModelFlagsFallback(nint _vehicle, uint _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetModelFlags", "Vehicle_Handling_SetModelFlags SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetMonetaryValueDelegate(nint _vehicle, uint _value);
        private static void Vehicle_Handling_SetMonetaryValueFallback(nint _vehicle, uint _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetMonetaryValue", "Vehicle_Handling_SetMonetaryValue SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetOilVolumeDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetOilVolumeFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetOilVolume", "Vehicle_Handling_SetOilVolume SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetPercentSubmergedDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetPercentSubmergedFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetPercentSubmerged", "Vehicle_Handling_SetPercentSubmerged SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetPercentSubmergedRatioDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetPercentSubmergedRatioFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetPercentSubmergedRatio", "Vehicle_Handling_SetPercentSubmergedRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetPetrolTankVolumeDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetPetrolTankVolumeFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetPetrolTankVolume", "Vehicle_Handling_SetPetrolTankVolume SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetRollCentreHeightFrontDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetRollCentreHeightFrontFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetRollCentreHeightFront", "Vehicle_Handling_SetRollCentreHeightFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetRollCentreHeightRearDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetRollCentreHeightRearFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetRollCentreHeightRear", "Vehicle_Handling_SetRollCentreHeightRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetSeatOffsetDistXDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetSeatOffsetDistXFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetSeatOffsetDistX", "Vehicle_Handling_SetSeatOffsetDistX SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetSeatOffsetDistYDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetSeatOffsetDistYFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetSeatOffsetDistY", "Vehicle_Handling_SetSeatOffsetDistY SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetSeatOffsetDistZDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetSeatOffsetDistZFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetSeatOffsetDistZ", "Vehicle_Handling_SetSeatOffsetDistZ SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetSteeringLockDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetSteeringLockFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetSteeringLock", "Vehicle_Handling_SetSteeringLock SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetSteeringLockRatioDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetSteeringLockRatioFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetSteeringLockRatio", "Vehicle_Handling_SetSteeringLockRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetSuspensionBiasFrontDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetSuspensionBiasFrontFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetSuspensionBiasFront", "Vehicle_Handling_SetSuspensionBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetSuspensionBiasRearDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetSuspensionBiasRearFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetSuspensionBiasRear", "Vehicle_Handling_SetSuspensionBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetSuspensionCompDampDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetSuspensionCompDampFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetSuspensionCompDamp", "Vehicle_Handling_SetSuspensionCompDamp SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetSuspensionForceDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetSuspensionForceFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetSuspensionForce", "Vehicle_Handling_SetSuspensionForce SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetSuspensionLowerLimitDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetSuspensionLowerLimitFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetSuspensionLowerLimit", "Vehicle_Handling_SetSuspensionLowerLimit SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetSuspensionRaiseDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetSuspensionRaiseFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetSuspensionRaise", "Vehicle_Handling_SetSuspensionRaise SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetSuspensionReboundDampDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetSuspensionReboundDampFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetSuspensionReboundDamp", "Vehicle_Handling_SetSuspensionReboundDamp SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetSuspensionUpperLimitDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetSuspensionUpperLimitFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetSuspensionUpperLimit", "Vehicle_Handling_SetSuspensionUpperLimit SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetTractionBiasFrontDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetTractionBiasFrontFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetTractionBiasFront", "Vehicle_Handling_SetTractionBiasFront SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetTractionBiasRearDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetTractionBiasRearFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetTractionBiasRear", "Vehicle_Handling_SetTractionBiasRear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetTractionCurveLateralDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetTractionCurveLateralFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetTractionCurveLateral", "Vehicle_Handling_SetTractionCurveLateral SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetTractionCurveLateralRatioDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetTractionCurveLateralRatioFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetTractionCurveLateralRatio", "Vehicle_Handling_SetTractionCurveLateralRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetTractionCurveMaxDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetTractionCurveMaxFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetTractionCurveMax", "Vehicle_Handling_SetTractionCurveMax SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetTractionCurveMaxRatioDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetTractionCurveMaxRatioFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetTractionCurveMaxRatio", "Vehicle_Handling_SetTractionCurveMaxRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetTractionCurveMinDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetTractionCurveMinFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetTractionCurveMin", "Vehicle_Handling_SetTractionCurveMin SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetTractionCurveMinRatioDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetTractionCurveMinRatioFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetTractionCurveMinRatio", "Vehicle_Handling_SetTractionCurveMinRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetTractionLossMultDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetTractionLossMultFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetTractionLossMult", "Vehicle_Handling_SetTractionLossMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetTractionSpringDeltaMaxDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetTractionSpringDeltaMaxFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetTractionSpringDeltaMax", "Vehicle_Handling_SetTractionSpringDeltaMax SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetTractionSpringDeltaMaxRatioDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetTractionSpringDeltaMaxRatioFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetTractionSpringDeltaMaxRatio", "Vehicle_Handling_SetTractionSpringDeltaMaxRatio SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetunkFloat1Delegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetunkFloat1Fallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetunkFloat1", "Vehicle_Handling_SetunkFloat1 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetunkFloat2Delegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetunkFloat2Fallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetunkFloat2", "Vehicle_Handling_SetunkFloat2 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetunkFloat4Delegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetunkFloat4Fallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetunkFloat4", "Vehicle_Handling_SetunkFloat4 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetunkFloat5Delegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetunkFloat5Fallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetunkFloat5", "Vehicle_Handling_SetunkFloat5 SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_Handling_SetWeaponDamageMultDelegate(nint _vehicle, float _value);
        private static void Vehicle_Handling_SetWeaponDamageMultFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_Handling_SetWeaponDamageMult", "Vehicle_Handling_SetWeaponDamageMult SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsHandlingModifiedDelegate(nint _vehicle);
        private static byte Vehicle_IsHandlingModifiedFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsHandlingModified", "Vehicle_IsHandlingModified SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte Vehicle_IsTaxiLightOnDelegate(nint _vehicle);
        private static byte Vehicle_IsTaxiLightOnFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_IsTaxiLightOn", "Vehicle_IsTaxiLightOn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_ResetDashboardLightsDelegate(nint _vehicle);
        private static void Vehicle_ResetDashboardLightsFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_ResetDashboardLights", "Vehicle_ResetDashboardLights SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_ResetHandlingDelegate(nint _vehicle);
        private static void Vehicle_ResetHandlingFallback(nint _vehicle) => throw new Exceptions.OutdatedSdkException("Vehicle_ResetHandling", "Vehicle_ResetHandling SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetAbsLightStateDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetAbsLightStateFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetAbsLightState", "Vehicle_SetAbsLightState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetBatteryLightStateDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetBatteryLightStateFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetBatteryLightState", "Vehicle_SetBatteryLightState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetCurrentGearDelegate(nint _vehicle, ushort _value);
        private static void Vehicle_SetCurrentGearFallback(nint _vehicle, ushort _value) => throw new Exceptions.OutdatedSdkException("Vehicle_SetCurrentGear", "Vehicle_SetCurrentGear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetCurrentRPMDelegate(nint _vehicle, float _rpm);
        private static void Vehicle_SetCurrentRPMFallback(nint _vehicle, float _rpm) => throw new Exceptions.OutdatedSdkException("Vehicle_SetCurrentRPM", "Vehicle_SetCurrentRPM SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetEngineLightStateDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetEngineLightStateFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetEngineLightState", "Vehicle_SetEngineLightState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetEngineTemperatureDelegate(nint _vehicle, float _value);
        private static void Vehicle_SetEngineTemperatureFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_SetEngineTemperature", "Vehicle_SetEngineTemperature SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetFuelLevelDelegate(nint _vehicle, float _value);
        private static void Vehicle_SetFuelLevelFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_SetFuelLevel", "Vehicle_SetFuelLevel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetLightsIndicatorDelegate(nint _vehicle, byte _value);
        private static void Vehicle_SetLightsIndicatorFallback(nint _vehicle, byte _value) => throw new Exceptions.OutdatedSdkException("Vehicle_SetLightsIndicator", "Vehicle_SetLightsIndicator SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetMaxGearDelegate(nint _vehicle, ushort _value);
        private static void Vehicle_SetMaxGearFallback(nint _vehicle, ushort _value) => throw new Exceptions.OutdatedSdkException("Vehicle_SetMaxGear", "Vehicle_SetMaxGear SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetOilLevelDelegate(nint _vehicle, float _value);
        private static void Vehicle_SetOilLevelFallback(nint _vehicle, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_SetOilLevel", "Vehicle_SetOilLevel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetOilLightStateDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetOilLightStateFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetOilLightState", "Vehicle_SetOilLightState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetPetrolLightStateDelegate(nint _vehicle, byte _state);
        private static void Vehicle_SetPetrolLightStateFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_SetPetrolLightState", "Vehicle_SetPetrolLightState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWheelCamberDelegate(nint _vehicle, byte _wheel, float _value);
        private static void Vehicle_SetWheelCamberFallback(nint _vehicle, byte _wheel, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWheelCamber", "Vehicle_SetWheelCamber SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWheelHeightDelegate(nint _vehicle, byte _wheel, float _value);
        private static void Vehicle_SetWheelHeightFallback(nint _vehicle, byte _wheel, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWheelHeight", "Vehicle_SetWheelHeight SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWheelRimRadiusDelegate(nint _vehicle, byte _wheel, float _value);
        private static void Vehicle_SetWheelRimRadiusFallback(nint _vehicle, byte _wheel, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWheelRimRadius", "Vehicle_SetWheelRimRadius SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWheelTrackWidthDelegate(nint _vehicle, byte _wheel, float _value);
        private static void Vehicle_SetWheelTrackWidthFallback(nint _vehicle, byte _wheel, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWheelTrackWidth", "Vehicle_SetWheelTrackWidth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWheelTyreRadiusDelegate(nint _vehicle, byte _wheel, float _value);
        private static void Vehicle_SetWheelTyreRadiusFallback(nint _vehicle, byte _wheel, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWheelTyreRadius", "Vehicle_SetWheelTyreRadius SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_SetWheelTyreWidthDelegate(nint _vehicle, byte _wheel, float _value);
        private static void Vehicle_SetWheelTyreWidthFallback(nint _vehicle, byte _wheel, float _value) => throw new Exceptions.OutdatedSdkException("Vehicle_SetWheelTyreWidth", "Vehicle_SetWheelTyreWidth SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void Vehicle_ToggleTaxiLightDelegate(nint _vehicle, byte _state);
        private static void Vehicle_ToggleTaxiLightFallback(nint _vehicle, byte _state) => throw new Exceptions.OutdatedSdkException("Vehicle_ToggleTaxiLight", "Vehicle_ToggleTaxiLight SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint VirtualEntity_GetRemoteIDDelegate(nint _virtualEntity);
        private static uint VirtualEntity_GetRemoteIDFallback(nint _virtualEntity) => throw new Exceptions.OutdatedSdkException("VirtualEntity_GetRemoteID", "VirtualEntity_GetRemoteID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte VirtualEntity_IsRemoteDelegate(nint _virtualEntity);
        private static byte VirtualEntity_IsRemoteFallback(nint _virtualEntity) => throw new Exceptions.OutdatedSdkException("VirtualEntity_IsRemote", "VirtualEntity_IsRemote SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte VirtualEntity_IsStreamedInDelegate(nint _virtualEntity);
        private static byte VirtualEntity_IsStreamedInFallback(nint _virtualEntity) => throw new Exceptions.OutdatedSdkException("VirtualEntity_IsStreamedIn", "VirtualEntity_IsStreamedIn SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint VirtualEntityGroup_GetRemoteIDDelegate(nint _virtualEntityGroup);
        private static uint VirtualEntityGroup_GetRemoteIDFallback(nint _virtualEntityGroup) => throw new Exceptions.OutdatedSdkException("VirtualEntityGroup_GetRemoteID", "VirtualEntityGroup_GetRemoteID SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte VirtualEntityGroup_IsRemoteDelegate(nint _virtualEntityGroup);
        private static byte VirtualEntityGroup_IsRemoteFallback(nint _virtualEntityGroup) => throw new Exceptions.OutdatedSdkException("VirtualEntityGroup_IsRemote", "VirtualEntityGroup_IsRemote SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float WeaponData_GetAccuracySpreadDelegate(uint _weaponHash);
        private static float WeaponData_GetAccuracySpreadFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetAccuracySpread", "WeaponData_GetAccuracySpread SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float WeaponData_GetAnimReloadRateDelegate(uint _weaponHash);
        private static float WeaponData_GetAnimReloadRateFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetAnimReloadRate", "WeaponData_GetAnimReloadRate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint WeaponData_GetClipSizeDelegate(uint _weaponHash);
        private static uint WeaponData_GetClipSizeFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetClipSize", "WeaponData_GetClipSize SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float WeaponData_GetDamageDelegate(uint _weaponHash);
        private static float WeaponData_GetDamageFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetDamage", "WeaponData_GetDamage SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float WeaponData_GetHeadshotDamageModifierDelegate(uint _weaponHash);
        private static float WeaponData_GetHeadshotDamageModifierFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetHeadshotDamageModifier", "WeaponData_GetHeadshotDamageModifier SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float WeaponData_GetLockOnRangeDelegate(uint _weaponHash);
        private static float WeaponData_GetLockOnRangeFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetLockOnRange", "WeaponData_GetLockOnRange SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint WeaponData_GetModelHashDelegate(uint _weaponHash);
        private static uint WeaponData_GetModelHashFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetModelHash", "WeaponData_GetModelHash SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate uint WeaponData_GetNameHashDelegate(uint _weaponHash);
        private static uint WeaponData_GetNameHashFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetNameHash", "WeaponData_GetNameHash SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float WeaponData_GetPlayerDamageModifierDelegate(uint _weaponHash);
        private static float WeaponData_GetPlayerDamageModifierFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetPlayerDamageModifier", "WeaponData_GetPlayerDamageModifier SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float WeaponData_GetRangeDelegate(uint _weaponHash);
        private static float WeaponData_GetRangeFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetRange", "WeaponData_GetRange SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float WeaponData_GetRecoilAccuracyMaxDelegate(uint _weaponHash);
        private static float WeaponData_GetRecoilAccuracyMaxFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetRecoilAccuracyMax", "WeaponData_GetRecoilAccuracyMax SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float WeaponData_GetRecoilAccuracyToAllowHeadshotPlayerDelegate(uint _weaponHash);
        private static float WeaponData_GetRecoilAccuracyToAllowHeadshotPlayerFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetRecoilAccuracyToAllowHeadshotPlayer", "WeaponData_GetRecoilAccuracyToAllowHeadshotPlayer SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float WeaponData_GetRecoilRecoveryRateDelegate(uint _weaponHash);
        private static float WeaponData_GetRecoilRecoveryRateFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetRecoilRecoveryRate", "WeaponData_GetRecoilRecoveryRate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float WeaponData_GetRecoilShakeAmplitudeDelegate(uint _weaponHash);
        private static float WeaponData_GetRecoilShakeAmplitudeFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetRecoilShakeAmplitude", "WeaponData_GetRecoilShakeAmplitude SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float WeaponData_GetTimeBetweenShotsDelegate(uint _weaponHash);
        private static float WeaponData_GetTimeBetweenShotsFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetTimeBetweenShots", "WeaponData_GetTimeBetweenShots SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate float WeaponData_GetVehicleReloadTimeDelegate(uint _weaponHash);
        private static float WeaponData_GetVehicleReloadTimeFallback(uint _weaponHash) => throw new Exceptions.OutdatedSdkException("WeaponData_GetVehicleReloadTime", "WeaponData_GetVehicleReloadTime SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WeaponData_SetAccuracySpreadDelegate(uint _weaponHash, float _val);
        private static void WeaponData_SetAccuracySpreadFallback(uint _weaponHash, float _val) => throw new Exceptions.OutdatedSdkException("WeaponData_SetAccuracySpread", "WeaponData_SetAccuracySpread SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WeaponData_SetAnimReloadRateDelegate(uint _weaponHash, float _val);
        private static void WeaponData_SetAnimReloadRateFallback(uint _weaponHash, float _val) => throw new Exceptions.OutdatedSdkException("WeaponData_SetAnimReloadRate", "WeaponData_SetAnimReloadRate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WeaponData_SetDamageDelegate(uint _weaponHash, float _val);
        private static void WeaponData_SetDamageFallback(uint _weaponHash, float _val) => throw new Exceptions.OutdatedSdkException("WeaponData_SetDamage", "WeaponData_SetDamage SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WeaponData_SetHeadshotDamageModifierDelegate(uint _weaponHash, float _val);
        private static void WeaponData_SetHeadshotDamageModifierFallback(uint _weaponHash, float _val) => throw new Exceptions.OutdatedSdkException("WeaponData_SetHeadshotDamageModifier", "WeaponData_SetHeadshotDamageModifier SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WeaponData_SetLockOnRangeDelegate(uint _weaponHash, float _val);
        private static void WeaponData_SetLockOnRangeFallback(uint _weaponHash, float _val) => throw new Exceptions.OutdatedSdkException("WeaponData_SetLockOnRange", "WeaponData_SetLockOnRange SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WeaponData_SetPlayerDamageModifierDelegate(uint _weaponHash, float _val);
        private static void WeaponData_SetPlayerDamageModifierFallback(uint _weaponHash, float _val) => throw new Exceptions.OutdatedSdkException("WeaponData_SetPlayerDamageModifier", "WeaponData_SetPlayerDamageModifier SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WeaponData_SetRangeDelegate(uint _weaponHash, float _val);
        private static void WeaponData_SetRangeFallback(uint _weaponHash, float _val) => throw new Exceptions.OutdatedSdkException("WeaponData_SetRange", "WeaponData_SetRange SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WeaponData_SetRecoilAccuracyMaxDelegate(uint _weaponHash, float _val);
        private static void WeaponData_SetRecoilAccuracyMaxFallback(uint _weaponHash, float _val) => throw new Exceptions.OutdatedSdkException("WeaponData_SetRecoilAccuracyMax", "WeaponData_SetRecoilAccuracyMax SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WeaponData_SetRecoilAccuracyToAllowHeadshotPlayerDelegate(uint _weaponHash, float _val);
        private static void WeaponData_SetRecoilAccuracyToAllowHeadshotPlayerFallback(uint _weaponHash, float _val) => throw new Exceptions.OutdatedSdkException("WeaponData_SetRecoilAccuracyToAllowHeadshotPlayer", "WeaponData_SetRecoilAccuracyToAllowHeadshotPlayer SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WeaponData_SetRecoilRecoveryRateDelegate(uint _weaponHash, float _val);
        private static void WeaponData_SetRecoilRecoveryRateFallback(uint _weaponHash, float _val) => throw new Exceptions.OutdatedSdkException("WeaponData_SetRecoilRecoveryRate", "WeaponData_SetRecoilRecoveryRate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WeaponData_SetRecoilShakeAmplitudeDelegate(uint _weaponHash, float _val);
        private static void WeaponData_SetRecoilShakeAmplitudeFallback(uint _weaponHash, float _val) => throw new Exceptions.OutdatedSdkException("WeaponData_SetRecoilShakeAmplitude", "WeaponData_SetRecoilShakeAmplitude SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WeaponData_SetVehicleReloadTimeDelegate(uint _weaponHash, float _val);
        private static void WeaponData_SetVehicleReloadTimeFallback(uint _weaponHash, float _val) => throw new Exceptions.OutdatedSdkException("WeaponData_SetVehicleReloadTime", "WeaponData_SetVehicleReloadTime SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebSocketClient_AddSubProtocolDelegate(nint _webSocketClient, nint _protocol);
        private static void WebSocketClient_AddSubProtocolFallback(nint _webSocketClient, nint _protocol) => throw new Exceptions.OutdatedSdkException("WebSocketClient_AddSubProtocol", "WebSocketClient_AddSubProtocol SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint WebSocketClient_GetBaseObjectDelegate(nint _webSocketClient);
        private static nint WebSocketClient_GetBaseObjectFallback(nint _webSocketClient) => throw new Exceptions.OutdatedSdkException("WebSocketClient_GetBaseObject", "WebSocketClient_GetBaseObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate ushort WebSocketClient_GetPingIntervalDelegate(nint _webSocketClient);
        private static ushort WebSocketClient_GetPingIntervalFallback(nint _webSocketClient) => throw new Exceptions.OutdatedSdkException("WebSocketClient_GetPingInterval", "WebSocketClient_GetPingInterval SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte WebSocketClient_GetReadyStateDelegate(nint _webSocketClient);
        private static byte WebSocketClient_GetReadyStateFallback(nint _webSocketClient) => throw new Exceptions.OutdatedSdkException("WebSocketClient_GetReadyState", "WebSocketClient_GetReadyState SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint WebSocketClient_GetSubProtocolsDelegate(nint _webSocketClient, uint* _size);
        private static nint WebSocketClient_GetSubProtocolsFallback(nint _webSocketClient, uint* _size) => throw new Exceptions.OutdatedSdkException("WebSocketClient_GetSubProtocols", "WebSocketClient_GetSubProtocols SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint WebSocketClient_GetUrlDelegate(nint _webSocketClient, int* _size);
        private static nint WebSocketClient_GetUrlFallback(nint _webSocketClient, int* _size) => throw new Exceptions.OutdatedSdkException("WebSocketClient_GetUrl", "WebSocketClient_GetUrl SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte WebSocketClient_IsAutoReconnectDelegate(nint _webSocketClient);
        private static byte WebSocketClient_IsAutoReconnectFallback(nint _webSocketClient) => throw new Exceptions.OutdatedSdkException("WebSocketClient_IsAutoReconnect", "WebSocketClient_IsAutoReconnect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte WebSocketClient_IsPerMessageDeflateDelegate(nint _webSocketClient);
        private static byte WebSocketClient_IsPerMessageDeflateFallback(nint _webSocketClient) => throw new Exceptions.OutdatedSdkException("WebSocketClient_IsPerMessageDeflate", "WebSocketClient_IsPerMessageDeflate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte WebSocketClient_Send_BinaryDelegate(nint _webSocketClient, nint _str, uint _size);
        private static byte WebSocketClient_Send_BinaryFallback(nint _webSocketClient, nint _str, uint _size) => throw new Exceptions.OutdatedSdkException("WebSocketClient_Send_Binary", "WebSocketClient_Send_Binary SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte WebSocketClient_Send_StringDelegate(nint _webSocketClient, nint _str);
        private static byte WebSocketClient_Send_StringFallback(nint _webSocketClient, nint _str) => throw new Exceptions.OutdatedSdkException("WebSocketClient_Send_String", "WebSocketClient_Send_String SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebSocketClient_SetAutoReconnectDelegate(nint _webSocketClient, byte _value);
        private static void WebSocketClient_SetAutoReconnectFallback(nint _webSocketClient, byte _value) => throw new Exceptions.OutdatedSdkException("WebSocketClient_SetAutoReconnect", "WebSocketClient_SetAutoReconnect SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebSocketClient_SetExtraHeaderDelegate(nint _webSocketClient, nint _key, nint _value);
        private static void WebSocketClient_SetExtraHeaderFallback(nint _webSocketClient, nint _key, nint _value) => throw new Exceptions.OutdatedSdkException("WebSocketClient_SetExtraHeader", "WebSocketClient_SetExtraHeader SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebSocketClient_SetPerMessageDeflateDelegate(nint _webSocketClient, byte _value);
        private static void WebSocketClient_SetPerMessageDeflateFallback(nint _webSocketClient, byte _value) => throw new Exceptions.OutdatedSdkException("WebSocketClient_SetPerMessageDeflate", "WebSocketClient_SetPerMessageDeflate SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebSocketClient_SetPingIntervalDelegate(nint _webSocketClient, ushort _value);
        private static void WebSocketClient_SetPingIntervalFallback(nint _webSocketClient, ushort _value) => throw new Exceptions.OutdatedSdkException("WebSocketClient_SetPingInterval", "WebSocketClient_SetPingInterval SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebSocketClient_SetUrlDelegate(nint _webSocketClient, nint _value);
        private static void WebSocketClient_SetUrlFallback(nint _webSocketClient, nint _value) => throw new Exceptions.OutdatedSdkException("WebSocketClient_SetUrl", "WebSocketClient_SetUrl SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebSocketClient_StartDelegate(nint _webSocketClient);
        private static void WebSocketClient_StartFallback(nint _webSocketClient) => throw new Exceptions.OutdatedSdkException("WebSocketClient_Start", "WebSocketClient_Start SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebSocketClient_StopDelegate(nint _webSocketClient);
        private static void WebSocketClient_StopFallback(nint _webSocketClient) => throw new Exceptions.OutdatedSdkException("WebSocketClient_Stop", "WebSocketClient_Stop SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebView_FocusDelegate(nint _webView);
        private static void WebView_FocusFallback(nint _webView) => throw new Exceptions.OutdatedSdkException("WebView_Focus", "WebView_Focus SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint WebView_GetBaseObjectDelegate(nint _webView);
        private static nint WebView_GetBaseObjectFallback(nint _webView) => throw new Exceptions.OutdatedSdkException("WebView_GetBaseObject", "WebView_GetBaseObject SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebView_GetPositionDelegate(nint _webView, Vector2* _pos);
        private static void WebView_GetPositionFallback(nint _webView, Vector2* _pos) => throw new Exceptions.OutdatedSdkException("WebView_GetPosition", "WebView_GetPosition SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebView_GetSizeDelegate(nint _webView, Vector2* _size);
        private static void WebView_GetSizeFallback(nint _webView, Vector2* _size) => throw new Exceptions.OutdatedSdkException("WebView_GetSize", "WebView_GetSize SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint WebView_GetUrlDelegate(nint _webView, int* _size);
        private static nint WebView_GetUrlFallback(nint _webView, int* _size) => throw new Exceptions.OutdatedSdkException("WebView_GetUrl", "WebView_GetUrl SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte WebView_IsFocusedDelegate(nint _webView);
        private static byte WebView_IsFocusedFallback(nint _webView) => throw new Exceptions.OutdatedSdkException("WebView_IsFocused", "WebView_IsFocused SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte WebView_IsOverlayDelegate(nint _webView);
        private static byte WebView_IsOverlayFallback(nint _webView) => throw new Exceptions.OutdatedSdkException("WebView_IsOverlay", "WebView_IsOverlay SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate byte WebView_IsVisibleDelegate(nint _webView);
        private static byte WebView_IsVisibleFallback(nint _webView) => throw new Exceptions.OutdatedSdkException("WebView_IsVisible", "WebView_IsVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebView_SetExtraHeaderDelegate(nint _webView, nint _key, nint _value);
        private static void WebView_SetExtraHeaderFallback(nint _webView, nint _key, nint _value) => throw new Exceptions.OutdatedSdkException("WebView_SetExtraHeader", "WebView_SetExtraHeader SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebView_SetIsVisibleDelegate(nint _webView, byte _visible);
        private static void WebView_SetIsVisibleFallback(nint _webView, byte _visible) => throw new Exceptions.OutdatedSdkException("WebView_SetIsVisible", "WebView_SetIsVisible SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebView_SetPositionDelegate(nint _webView, Vector2 _pos);
        private static void WebView_SetPositionFallback(nint _webView, Vector2 _pos) => throw new Exceptions.OutdatedSdkException("WebView_SetPosition", "WebView_SetPosition SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebView_SetSizeDelegate(nint _webView, Vector2 _size);
        private static void WebView_SetSizeFallback(nint _webView, Vector2 _size) => throw new Exceptions.OutdatedSdkException("WebView_SetSize", "WebView_SetSize SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebView_SetUrlDelegate(nint _webView, nint _url);
        private static void WebView_SetUrlFallback(nint _webView, nint _url) => throw new Exceptions.OutdatedSdkException("WebView_SetUrl", "WebView_SetUrl SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebView_SetZoomLevelDelegate(nint _webView, float _value);
        private static void WebView_SetZoomLevelFallback(nint _webView, float _value) => throw new Exceptions.OutdatedSdkException("WebView_SetZoomLevel", "WebView_SetZoomLevel SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate void WebView_UnfocusDelegate(nint _webView);
        private static void WebView_UnfocusFallback(nint _webView) => throw new Exceptions.OutdatedSdkException("WebView_Unfocus", "WebView_Unfocus SDK method is outdated. Please update your module nuget");
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] private delegate nint Win_GetTaskDialogDelegate();
        private static nint Win_GetTaskDialogFallback() => throw new Exceptions.OutdatedSdkException("Win_GetTaskDialog", "Win_GetTaskDialog SDK method is outdated. Please update your module nuget");
        public bool Outdated { get; private set; }
        private IntPtr GetUnmanagedPtr<T>(IDictionary<ulong, IntPtr> funcTable, ulong hash, T fn) where T : Delegate {
            if (funcTable.TryGetValue(hash, out var ptr)) return ptr;
            Outdated = true;
            return Marshal.GetFunctionPointerForDelegate<T>(fn);
        }
        public ClientLibrary(Dictionary<ulong, IntPtr> funcTable)
        {
            if (!funcTable.TryGetValue(0, out var capiHash)) Outdated = true;
            else if (capiHash == IntPtr.Zero || *(ulong*)capiHash != 2348991114702301885UL) Outdated = true;
            Audio_AddOutput_Entity = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Audio_AddOutput_EntityDelegate>(funcTable, 9879036518735269522UL, Audio_AddOutput_EntityFallback);
            Audio_AddOutput_ScriptId = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Audio_AddOutput_ScriptIdDelegate>(funcTable, 14116998947805478300UL, Audio_AddOutput_ScriptIdFallback);
            Audio_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Audio_GetBaseObjectDelegate>(funcTable, 6330360502401226894UL, Audio_GetBaseObjectFallback);
            Audio_GetCategory = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Audio_GetCategoryDelegate>(funcTable, 12345892022413856728UL, Audio_GetCategoryFallback);
            Audio_GetCurrentTime = (delegate* unmanaged[Cdecl]<nint, double>) GetUnmanagedPtr<Audio_GetCurrentTimeDelegate>(funcTable, 2944324482134975819UL, Audio_GetCurrentTimeFallback);
            Audio_GetLooped = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Audio_GetLoopedDelegate>(funcTable, 10560005262055961188UL, Audio_GetLoopedFallback);
            Audio_GetMaxTime = (delegate* unmanaged[Cdecl]<nint, double>) GetUnmanagedPtr<Audio_GetMaxTimeDelegate>(funcTable, 5963004639906097584UL, Audio_GetMaxTimeFallback);
            Audio_GetOutputs = (delegate* unmanaged[Cdecl]<nint, nint*, nint*, nint*, uint*, void>) GetUnmanagedPtr<Audio_GetOutputsDelegate>(funcTable, 10960639574387403531UL, Audio_GetOutputsFallback);
            Audio_GetSource = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Audio_GetSourceDelegate>(funcTable, 12278705681242498405UL, Audio_GetSourceFallback);
            Audio_GetVolume = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Audio_GetVolumeDelegate>(funcTable, 8275612815502917842UL, Audio_GetVolumeFallback);
            Audio_IsFrontendPlay = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Audio_IsFrontendPlayDelegate>(funcTable, 936635821185311219UL, Audio_IsFrontendPlayFallback);
            Audio_IsPlaying = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Audio_IsPlayingDelegate>(funcTable, 14342104995157365387UL, Audio_IsPlayingFallback);
            Audio_Pause = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Audio_PauseDelegate>(funcTable, 312129387563128742UL, Audio_PauseFallback);
            Audio_Play = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Audio_PlayDelegate>(funcTable, 18104521197990433214UL, Audio_PlayFallback);
            Audio_RemoveOutput_Entity = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Audio_RemoveOutput_EntityDelegate>(funcTable, 7265503788671851963UL, Audio_RemoveOutput_EntityFallback);
            Audio_RemoveOutput_ScriptId = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Audio_RemoveOutput_ScriptIdDelegate>(funcTable, 16157836184241443811UL, Audio_RemoveOutput_ScriptIdFallback);
            Audio_Reset = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Audio_ResetDelegate>(funcTable, 1881771096446693299UL, Audio_ResetFallback);
            Audio_Seek = (delegate* unmanaged[Cdecl]<nint, double, void>) GetUnmanagedPtr<Audio_SeekDelegate>(funcTable, 11376704802141530478UL, Audio_SeekFallback);
            Audio_SetCategory = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Audio_SetCategoryDelegate>(funcTable, 17618115768214791263UL, Audio_SetCategoryFallback);
            Audio_SetLooped = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Audio_SetLoopedDelegate>(funcTable, 11197286000910319739UL, Audio_SetLoopedFallback);
            Audio_SetSource = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Audio_SetSourceDelegate>(funcTable, 1985919874242680186UL, Audio_SetSourceFallback);
            Audio_SetVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Audio_SetVolumeDelegate>(funcTable, 12440427729460375257UL, Audio_SetVolumeFallback);
            AudioFilter_AddAutowahEffect = (delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, float, int, uint>) GetUnmanagedPtr<AudioFilter_AddAutowahEffectDelegate>(funcTable, 14212377165691564503UL, AudioFilter_AddAutowahEffectFallback);
            AudioFilter_AddBqfEffect = (delegate* unmanaged[Cdecl]<nint, int, float, float, float, float, float, int, uint>) GetUnmanagedPtr<AudioFilter_AddBqfEffectDelegate>(funcTable, 4087111773947664402UL, AudioFilter_AddBqfEffectFallback);
            AudioFilter_AddChorusEffect = (delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, float, int, uint>) GetUnmanagedPtr<AudioFilter_AddChorusEffectDelegate>(funcTable, 9972569973446180314UL, AudioFilter_AddChorusEffectFallback);
            AudioFilter_AddCompressor2Effect = (delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, int, uint>) GetUnmanagedPtr<AudioFilter_AddCompressor2EffectDelegate>(funcTable, 17322162260950965408UL, AudioFilter_AddCompressor2EffectFallback);
            AudioFilter_AddDampEffect = (delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, int, uint>) GetUnmanagedPtr<AudioFilter_AddDampEffectDelegate>(funcTable, 4015248769723727249UL, AudioFilter_AddDampEffectFallback);
            AudioFilter_AddDistortionEffect = (delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, int, uint>) GetUnmanagedPtr<AudioFilter_AddDistortionEffectDelegate>(funcTable, 7285621841123341024UL, AudioFilter_AddDistortionEffectFallback);
            AudioFilter_AddEcho4Effect = (delegate* unmanaged[Cdecl]<nint, float, float, float, float, int, uint>) GetUnmanagedPtr<AudioFilter_AddEcho4EffectDelegate>(funcTable, 9336932188943118341UL, AudioFilter_AddEcho4EffectFallback);
            AudioFilter_AddFreeverbEffect = (delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, uint, int, uint>) GetUnmanagedPtr<AudioFilter_AddFreeverbEffectDelegate>(funcTable, 10140673001977917335UL, AudioFilter_AddFreeverbEffectFallback);
            AudioFilter_AddPeakeqEffect = (delegate* unmanaged[Cdecl]<nint, int, float, float, float, float, int, uint>) GetUnmanagedPtr<AudioFilter_AddPeakeqEffectDelegate>(funcTable, 1255796572498720691UL, AudioFilter_AddPeakeqEffectFallback);
            AudioFilter_AddPhaserEffect = (delegate* unmanaged[Cdecl]<nint, float, float, float, float, float, float, int, uint>) GetUnmanagedPtr<AudioFilter_AddPhaserEffectDelegate>(funcTable, 4076092769167870615UL, AudioFilter_AddPhaserEffectFallback);
            AudioFilter_AddPitchshiftEffect = (delegate* unmanaged[Cdecl]<nint, float, float, long, long, int, uint>) GetUnmanagedPtr<AudioFilter_AddPitchshiftEffectDelegate>(funcTable, 13860375026413797308UL, AudioFilter_AddPitchshiftEffectFallback);
            AudioFilter_AddRotateEffect = (delegate* unmanaged[Cdecl]<nint, float, int, uint>) GetUnmanagedPtr<AudioFilter_AddRotateEffectDelegate>(funcTable, 3023765297763740660UL, AudioFilter_AddRotateEffectFallback);
            AudioFilter_AddVolumeEffect = (delegate* unmanaged[Cdecl]<nint, float, int, uint>) GetUnmanagedPtr<AudioFilter_AddVolumeEffectDelegate>(funcTable, 4712013335136464389UL, AudioFilter_AddVolumeEffectFallback);
            AudioFilter_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<AudioFilter_GetBaseObjectDelegate>(funcTable, 8867334748367703826UL, AudioFilter_GetBaseObjectFallback);
            AudioFilter_GetHash = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<AudioFilter_GetHashDelegate>(funcTable, 10116851781453819636UL, AudioFilter_GetHashFallback);
            AudioFilter_RemoveEffect = (delegate* unmanaged[Cdecl]<nint, uint, byte>) GetUnmanagedPtr<AudioFilter_RemoveEffectDelegate>(funcTable, 4769953165963999553UL, AudioFilter_RemoveEffectFallback);
            Blip_GetScriptID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Blip_GetScriptIDDelegate>(funcTable, 16517785578451896264UL, Blip_GetScriptIDFallback);
            Blip_IsRemote = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Blip_IsRemoteDelegate>(funcTable, 16853945182069856363UL, Blip_IsRemoteFallback);
            Checkpoint_IsStreamedIn = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Checkpoint_IsStreamedInDelegate>(funcTable, 11169437175796680635UL, Checkpoint_IsStreamedInFallback);
            Core_AddGXTText = (delegate* unmanaged[Cdecl]<nint, nint, uint, nint, void>) GetUnmanagedPtr<Core_AddGXTTextDelegate>(funcTable, 15861482869617048160UL, Core_AddGXTTextFallback);
            Core_AreGameControlsEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Core_AreGameControlsEnabledDelegate>(funcTable, 332214446285856938UL, Core_AreGameControlsEnabledFallback);
            Core_AreRmlControlsEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Core_AreRmlControlsEnabledDelegate>(funcTable, 6617672605820539119UL, Core_AreRmlControlsEnabledFallback);
            Core_AreVoiceControlsEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Core_AreVoiceControlsEnabledDelegate>(funcTable, 787373906810962396UL, Core_AreVoiceControlsEnabledFallback);
            Core_BeginScaleformMovieMethodMinimap = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Core_BeginScaleformMovieMethodMinimapDelegate>(funcTable, 16061113947833308071UL, Core_BeginScaleformMovieMethodMinimapFallback);
            Core_ClearFocusOverride = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Core_ClearFocusOverrideDelegate>(funcTable, 8870045277295379001UL, Core_ClearFocusOverrideFallback);
            Core_ClearPedProp = (delegate* unmanaged[Cdecl]<nint, int, byte, void>) GetUnmanagedPtr<Core_ClearPedPropDelegate>(funcTable, 13130998754672555937UL, Core_ClearPedPropFallback);
            Core_Client_CreateAreaBlip = (delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint, uint*, nint>) GetUnmanagedPtr<Core_Client_CreateAreaBlipDelegate>(funcTable, 16151961653066348551UL, Core_Client_CreateAreaBlipFallback);
            Core_Client_CreatePointBlip = (delegate* unmanaged[Cdecl]<nint, Vector3, nint, uint*, nint>) GetUnmanagedPtr<Core_Client_CreatePointBlipDelegate>(funcTable, 1099162925802423302UL, Core_Client_CreatePointBlipFallback);
            Core_Client_CreateRadiusBlip = (delegate* unmanaged[Cdecl]<nint, Vector3, float, nint, uint*, nint>) GetUnmanagedPtr<Core_Client_CreateRadiusBlipDelegate>(funcTable, 8390302372109372413UL, Core_Client_CreateRadiusBlipFallback);
            Core_Client_FileExists = (delegate* unmanaged[Cdecl]<nint, nint, nint, byte>) GetUnmanagedPtr<Core_Client_FileExistsDelegate>(funcTable, 2755966381047025099UL, Core_Client_FileExistsFallback);
            Core_Client_FileRead = (delegate* unmanaged[Cdecl]<nint, nint, nint, int*, nint>) GetUnmanagedPtr<Core_Client_FileReadDelegate>(funcTable, 6889820282703247958UL, Core_Client_FileReadFallback);
            Core_CopyToClipboard = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Core_CopyToClipboardDelegate>(funcTable, 5818638619878077112UL, Core_CopyToClipboardFallback);
            Core_CreateAudio = (delegate* unmanaged[Cdecl]<nint, nint, nint, float, uint, byte, uint*, nint>) GetUnmanagedPtr<Core_CreateAudioDelegate>(funcTable, 7736168136360038277UL, Core_CreateAudioFallback);
            Core_CreateCheckpoint = (delegate* unmanaged[Cdecl]<nint, byte, Vector3, Vector3, float, float, Rgba, uint, nint, uint*, nint>) GetUnmanagedPtr<Core_CreateCheckpointDelegate>(funcTable, 10431723440614759657UL, Core_CreateCheckpointFallback);
            Core_CreateHttpClient = (delegate* unmanaged[Cdecl]<nint, nint, uint*, nint>) GetUnmanagedPtr<Core_CreateHttpClientDelegate>(funcTable, 18346481764601280220UL, Core_CreateHttpClientFallback);
            Core_CreateLocalPed = (delegate* unmanaged[Cdecl]<nint, uint, int, Vector3, Rotation, byte, uint, nint, uint*, nint>) GetUnmanagedPtr<Core_CreateLocalPedDelegate>(funcTable, 17592230005859506401UL, Core_CreateLocalPedFallback);
            Core_CreateLocalVehicle = (delegate* unmanaged[Cdecl]<nint, uint, int, Vector3, Rotation, byte, uint, nint, uint*, nint>) GetUnmanagedPtr<Core_CreateLocalVehicleDelegate>(funcTable, 12946643233919435339UL, Core_CreateLocalVehicleFallback);
            Core_CreateMarker_Client = (delegate* unmanaged[Cdecl]<nint, byte, Vector3, Rgba, nint, uint*, nint>) GetUnmanagedPtr<Core_CreateMarker_ClientDelegate>(funcTable, 3957829277222763273UL, Core_CreateMarker_ClientFallback);
            Core_CreateObject = (delegate* unmanaged[Cdecl]<nint, uint, Vector3, Vector3, byte, byte, nint, ushort*, nint>) GetUnmanagedPtr<Core_CreateObjectDelegate>(funcTable, 12959857024542892545UL, Core_CreateObjectFallback);
            Core_CreateRmlDocument = (delegate* unmanaged[Cdecl]<nint, nint, nint, uint*, nint>) GetUnmanagedPtr<Core_CreateRmlDocumentDelegate>(funcTable, 6616548211992387591UL, Core_CreateRmlDocumentFallback);
            Core_CreateTextLabel = (delegate* unmanaged[Cdecl]<nint, nint, nint, float, float, Vector3, Rotation, Rgba, float, Rgba, nint, uint*, nint>) GetUnmanagedPtr<Core_CreateTextLabelDelegate>(funcTable, 13482323824940594004UL, Core_CreateTextLabelFallback);
            Core_CreateWebsocketClient = (delegate* unmanaged[Cdecl]<nint, nint, nint, uint*, nint>) GetUnmanagedPtr<Core_CreateWebsocketClientDelegate>(funcTable, 10887342887795907175UL, Core_CreateWebsocketClientFallback);
            Core_CreateWebView = (delegate* unmanaged[Cdecl]<nint, nint, nint, Vector2, Vector2, byte, uint*, nint>) GetUnmanagedPtr<Core_CreateWebViewDelegate>(funcTable, 10630250283173809055UL, Core_CreateWebViewFallback);
            Core_CreateWebView3D = (delegate* unmanaged[Cdecl]<nint, nint, nint, uint, nint, uint*, nint>) GetUnmanagedPtr<Core_CreateWebView3DDelegate>(funcTable, 7487980836838238402UL, Core_CreateWebView3DFallback);
            Core_DeallocDiscordUser = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Core_DeallocDiscordUserDelegate>(funcTable, 1212339219242517554UL, Core_DeallocDiscordUserFallback);
            Core_Discord_GetOAuth2Token = (delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.DiscordOAuth2TokenResultModuleDelegate, void>) GetUnmanagedPtr<Core_Discord_GetOAuth2TokenDelegate>(funcTable, 11971296438427190394UL, Core_Discord_GetOAuth2TokenFallback);
            Core_DoesConfigFlagExist = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Core_DoesConfigFlagExistDelegate>(funcTable, 2905154853369701790UL, Core_DoesConfigFlagExistFallback);
            Core_GetAudioCount = (delegate* unmanaged[Cdecl]<nint, ulong>) GetUnmanagedPtr<Core_GetAudioCountDelegate>(funcTable, 18419578908798121866UL, Core_GetAudioCountFallback);
            Core_GetAudios = (delegate* unmanaged[Cdecl]<nint, nint[], ulong, void>) GetUnmanagedPtr<Core_GetAudiosDelegate>(funcTable, 4570431726496627488UL, Core_GetAudiosFallback);
            Core_GetCamPos = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) GetUnmanagedPtr<Core_GetCamPosDelegate>(funcTable, 13815274607564352429UL, Core_GetCamPosFallback);
            Core_GetClientPath = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Core_GetClientPathDelegate>(funcTable, 10032718746164771334UL, Core_GetClientPathFallback);
            Core_GetConfigFlag = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Core_GetConfigFlagDelegate>(funcTable, 9388016697579829930UL, Core_GetConfigFlagFallback);
            Core_GetCursorPos = (delegate* unmanaged[Cdecl]<nint, Vector2*, byte, void>) GetUnmanagedPtr<Core_GetCursorPosDelegate>(funcTable, 15134150969197995835UL, Core_GetCursorPosFallback);
            Core_GetDiscordUser = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Core_GetDiscordUserDelegate>(funcTable, 18034315400823009421UL, Core_GetDiscordUserFallback);
            Core_GetFocusOverrideEntity = (delegate* unmanaged[Cdecl]<nint, byte*, nint>) GetUnmanagedPtr<Core_GetFocusOverrideEntityDelegate>(funcTable, 16108636330639358203UL, Core_GetFocusOverrideEntityFallback);
            Core_GetFocusOverrideOffset = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) GetUnmanagedPtr<Core_GetFocusOverrideOffsetDelegate>(funcTable, 14124476912621313487UL, Core_GetFocusOverrideOffsetFallback);
            Core_GetFocusOverridePos = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) GetUnmanagedPtr<Core_GetFocusOverridePosDelegate>(funcTable, 10400898725559876700UL, Core_GetFocusOverridePosFallback);
            Core_GetFPS = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Core_GetFPSDelegate>(funcTable, 15838077309260023251UL, Core_GetFPSFallback);
            Core_GetGXTText = (delegate* unmanaged[Cdecl]<nint, nint, uint, int*, nint>) GetUnmanagedPtr<Core_GetGXTTextDelegate>(funcTable, 16801614011390187646UL, Core_GetGXTTextFallback);
            Core_GetHeadshotBase64 = (delegate* unmanaged[Cdecl]<nint, byte, int*, nint>) GetUnmanagedPtr<Core_GetHeadshotBase64Delegate>(funcTable, 5040479552600550005UL, Core_GetHeadshotBase64Fallback);
            Core_GetLicenseHash = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Core_GetLicenseHashDelegate>(funcTable, 10784782962609535909UL, Core_GetLicenseHashFallback);
            Core_GetLocale = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Core_GetLocaleDelegate>(funcTable, 6468969374274395248UL, Core_GetLocaleFallback);
            Core_GetLocalMeta = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<Core_GetLocalMetaDelegate>(funcTable, 15640072761507866309UL, Core_GetLocalMetaFallback);
            Core_GetMapZoomDataByAlias = (delegate* unmanaged[Cdecl]<nint, nint, uint*, nint>) GetUnmanagedPtr<Core_GetMapZoomDataByAliasDelegate>(funcTable, 2945049114999400896UL, Core_GetMapZoomDataByAliasFallback);
            Core_GetMsPerGameMinute = (delegate* unmanaged[Cdecl]<nint, int>) GetUnmanagedPtr<Core_GetMsPerGameMinuteDelegate>(funcTable, 12789007219848936500UL, Core_GetMsPerGameMinuteFallback);
            Core_GetObjects = (delegate* unmanaged[Cdecl]<nint, uint*, nint>) GetUnmanagedPtr<Core_GetObjectsDelegate>(funcTable, 12780127882459247882UL, Core_GetObjectsFallback);
            Core_GetPedBonePos = (delegate* unmanaged[Cdecl]<nint, int, ushort, Vector3*, void>) GetUnmanagedPtr<Core_GetPedBonePosDelegate>(funcTable, 9678094278922411472UL, Core_GetPedBonePosFallback);
            Core_GetPermissionState = (delegate* unmanaged[Cdecl]<nint, byte, byte>) GetUnmanagedPtr<Core_GetPermissionStateDelegate>(funcTable, 6070013237365852957UL, Core_GetPermissionStateFallback);
            Core_GetPing = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Core_GetPingDelegate>(funcTable, 17183361268059997356UL, Core_GetPingFallback);
            Core_GetScreenResolution = (delegate* unmanaged[Cdecl]<nint, Vector2*, void>) GetUnmanagedPtr<Core_GetScreenResolutionDelegate>(funcTable, 16078537130538515891UL, Core_GetScreenResolutionFallback);
            Core_GetServerIp = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<Core_GetServerIpDelegate>(funcTable, 1389091625205062844UL, Core_GetServerIpFallback);
            Core_GetServerPort = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Core_GetServerPortDelegate>(funcTable, 14148467334937601992UL, Core_GetServerPortFallback);
            Core_GetStatBool = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Core_GetStatBoolDelegate>(funcTable, 4132285709171755304UL, Core_GetStatBoolFallback);
            Core_GetStatData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<Core_GetStatDataDelegate>(funcTable, 311843349031918009UL, Core_GetStatDataFallback);
            Core_GetStatFloat = (delegate* unmanaged[Cdecl]<nint, nint, float>) GetUnmanagedPtr<Core_GetStatFloatDelegate>(funcTable, 175428875067811253UL, Core_GetStatFloatFallback);
            Core_GetStatInt = (delegate* unmanaged[Cdecl]<nint, nint, int>) GetUnmanagedPtr<Core_GetStatIntDelegate>(funcTable, 14081919868345197535UL, Core_GetStatIntFallback);
            Core_GetStatLong = (delegate* unmanaged[Cdecl]<nint, nint, long>) GetUnmanagedPtr<Core_GetStatLongDelegate>(funcTable, 18038285482496731165UL, Core_GetStatLongFallback);
            Core_GetStatString = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint>) GetUnmanagedPtr<Core_GetStatStringDelegate>(funcTable, 11498372026862319408UL, Core_GetStatStringFallback);
            Core_GetStatType = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint>) GetUnmanagedPtr<Core_GetStatTypeDelegate>(funcTable, 2950339715084715443UL, Core_GetStatTypeFallback);
            Core_GetStatUInt16 = (delegate* unmanaged[Cdecl]<nint, nint, ushort>) GetUnmanagedPtr<Core_GetStatUInt16Delegate>(funcTable, 6152251698478014800UL, Core_GetStatUInt16Fallback);
            Core_GetStatUInt32 = (delegate* unmanaged[Cdecl]<nint, nint, uint>) GetUnmanagedPtr<Core_GetStatUInt32Delegate>(funcTable, 17019346626521204164UL, Core_GetStatUInt32Fallback);
            Core_GetStatUInt64 = (delegate* unmanaged[Cdecl]<nint, nint, ulong>) GetUnmanagedPtr<Core_GetStatUInt64Delegate>(funcTable, 11902544171987303902UL, Core_GetStatUInt64Fallback);
            Core_GetStatUInt8 = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Core_GetStatUInt8Delegate>(funcTable, 14377981926026585630UL, Core_GetStatUInt8Fallback);
            Core_GetTotalPacketsLost = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Core_GetTotalPacketsLostDelegate>(funcTable, 6512224235646012609UL, Core_GetTotalPacketsLostFallback);
            Core_GetTotalPacketsSent = (delegate* unmanaged[Cdecl]<nint, ulong>) GetUnmanagedPtr<Core_GetTotalPacketsSentDelegate>(funcTable, 16154816553672886942UL, Core_GetTotalPacketsSentFallback);
            Core_GetVoiceActivationKey = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Core_GetVoiceActivationKeyDelegate>(funcTable, 2249875648683273533UL, Core_GetVoiceActivationKeyFallback);
            Core_GetVoiceInputMuted = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Core_GetVoiceInputMutedDelegate>(funcTable, 14294729290243559040UL, Core_GetVoiceInputMutedFallback);
            Core_GetWebViewCount = (delegate* unmanaged[Cdecl]<nint, ulong>) GetUnmanagedPtr<Core_GetWebViewCountDelegate>(funcTable, 5500487167100623739UL, Core_GetWebViewCountFallback);
            Core_GetWebViews = (delegate* unmanaged[Cdecl]<nint, nint[], ulong, void>) GetUnmanagedPtr<Core_GetWebViewsDelegate>(funcTable, 8710938014357466262UL, Core_GetWebViewsFallback);
            Core_GetWorldObjects = (delegate* unmanaged[Cdecl]<nint, uint*, nint>) GetUnmanagedPtr<Core_GetWorldObjectsDelegate>(funcTable, 18414288505939983172UL, Core_GetWorldObjectsFallback);
            Core_HasLocalMeta = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Core_HasLocalMetaDelegate>(funcTable, 9239396081375157170UL, Core_HasLocalMetaFallback);
            Core_IsCamFrozen = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Core_IsCamFrozenDelegate>(funcTable, 11416637200173234902UL, Core_IsCamFrozenFallback);
            Core_IsConsoleOpen = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Core_IsConsoleOpenDelegate>(funcTable, 853721528952962006UL, Core_IsConsoleOpenFallback);
            Core_IsCursorVisible = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Core_IsCursorVisibleDelegate>(funcTable, 5868453964529506584UL, Core_IsCursorVisibleFallback);
            Core_IsFocusOverriden = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Core_IsFocusOverridenDelegate>(funcTable, 18011869490521432431UL, Core_IsFocusOverridenFallback);
            Core_IsGameFocused = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Core_IsGameFocusedDelegate>(funcTable, 5897797979124897124UL, Core_IsGameFocusedFallback);
            Core_IsInStreamerMode = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Core_IsInStreamerModeDelegate>(funcTable, 11592577439059234246UL, Core_IsInStreamerModeFallback);
            Core_IsKeyDown = (delegate* unmanaged[Cdecl]<nint, uint, byte>) GetUnmanagedPtr<Core_IsKeyDownDelegate>(funcTable, 95870224445067735UL, Core_IsKeyDownFallback);
            Core_IsKeyToggled = (delegate* unmanaged[Cdecl]<nint, uint, byte>) GetUnmanagedPtr<Core_IsKeyToggledDelegate>(funcTable, 5811391940054436855UL, Core_IsKeyToggledFallback);
            Core_IsMenuOpened = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Core_IsMenuOpenedDelegate>(funcTable, 6801040455860092307UL, Core_IsMenuOpenedFallback);
            Core_IsPointOnScreen = (delegate* unmanaged[Cdecl]<nint, Vector3, byte>) GetUnmanagedPtr<Core_IsPointOnScreenDelegate>(funcTable, 9053921873104901604UL, Core_IsPointOnScreenFallback);
            Core_IsTextureExistInArchetype = (delegate* unmanaged[Cdecl]<nint, uint, nint, byte>) GetUnmanagedPtr<Core_IsTextureExistInArchetypeDelegate>(funcTable, 5487028108265672799UL, Core_IsTextureExistInArchetypeFallback);
            Core_IsVoiceActivityInputEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Core_IsVoiceActivityInputEnabledDelegate>(funcTable, 4433142925114007365UL, Core_IsVoiceActivityInputEnabledFallback);
            Core_LoadDefaultIpls = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Core_LoadDefaultIplsDelegate>(funcTable, 17184217455720907957UL, Core_LoadDefaultIplsFallback);
            Core_LoadModel = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Core_LoadModelDelegate>(funcTable, 12272171669941913364UL, Core_LoadModelFallback);
            Core_LoadModelAsync = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Core_LoadModelAsyncDelegate>(funcTable, 9589250181503294824UL, Core_LoadModelAsyncFallback);
            Core_LoadRmlFont = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint, byte, byte, void>) GetUnmanagedPtr<Core_LoadRmlFontDelegate>(funcTable, 17080520873501735033UL, Core_LoadRmlFontFallback);
            Core_LoadYtyp = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Core_LoadYtypDelegate>(funcTable, 9006970651286241104UL, Core_LoadYtypFallback);
            Core_OverrideFocusEntity = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_OverrideFocusEntityDelegate>(funcTable, 11543552066785919265UL, Core_OverrideFocusEntityFallback);
            Core_OverrideFocusPosition = (delegate* unmanaged[Cdecl]<nint, Vector3, Vector3, void>) GetUnmanagedPtr<Core_OverrideFocusPositionDelegate>(funcTable, 15255809094076439747UL, Core_OverrideFocusPositionFallback);
            Core_RemoveGXTText = (delegate* unmanaged[Cdecl]<nint, nint, uint, void>) GetUnmanagedPtr<Core_RemoveGXTTextDelegate>(funcTable, 2950682702415179672UL, Core_RemoveGXTTextFallback);
            Core_RemoveIpl = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_RemoveIplDelegate>(funcTable, 3186817815537256556UL, Core_RemoveIplFallback);
            Core_RequestIpl = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_RequestIplDelegate>(funcTable, 6993510006268976715UL, Core_RequestIplFallback);
            Core_ResetAllMapZoomData = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Core_ResetAllMapZoomDataDelegate>(funcTable, 664982279299386907UL, Core_ResetAllMapZoomDataFallback);
            Core_ResetMapZoomData = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Core_ResetMapZoomDataDelegate>(funcTable, 12948735896839739671UL, Core_ResetMapZoomDataFallback);
            Core_ResetStat = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<Core_ResetStatDelegate>(funcTable, 5460369299538905850UL, Core_ResetStatFallback);
            Core_ScreenToWorld = (delegate* unmanaged[Cdecl]<nint, Vector2, Vector3*, void>) GetUnmanagedPtr<Core_ScreenToWorldDelegate>(funcTable, 15701563360488661578UL, Core_ScreenToWorldFallback);
            Core_SetCamFrozen = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Core_SetCamFrozenDelegate>(funcTable, 2415100583194488559UL, Core_SetCamFrozenFallback);
            Core_SetConfigFlag = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) GetUnmanagedPtr<Core_SetConfigFlagDelegate>(funcTable, 9549326506872223025UL, Core_SetConfigFlagFallback);
            Core_SetCursorPos = (delegate* unmanaged[Cdecl]<nint, Vector2, byte, void>) GetUnmanagedPtr<Core_SetCursorPosDelegate>(funcTable, 9986862625405376281UL, Core_SetCursorPosFallback);
            Core_SetMinimapComponentPosition = (delegate* unmanaged[Cdecl]<nint, nint, byte, byte, float, float, float, float, void>) GetUnmanagedPtr<Core_SetMinimapComponentPositionDelegate>(funcTable, 14327556077081423510UL, Core_SetMinimapComponentPositionFallback);
            Core_SetMinimapIsRectangle = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Core_SetMinimapIsRectangleDelegate>(funcTable, 16400827921977308918UL, Core_SetMinimapIsRectangleFallback);
            Core_SetMsPerGameMinute = (delegate* unmanaged[Cdecl]<nint, int, void>) GetUnmanagedPtr<Core_SetMsPerGameMinuteDelegate>(funcTable, 18167344434001544403UL, Core_SetMsPerGameMinuteFallback);
            Core_SetPedDlcClothes = (delegate* unmanaged[Cdecl]<nint, int, uint, byte, byte, byte, byte, void>) GetUnmanagedPtr<Core_SetPedDlcClothesDelegate>(funcTable, 9421218499029934377UL, Core_SetPedDlcClothesFallback);
            Core_SetPedDlcProp = (delegate* unmanaged[Cdecl]<nint, int, uint, byte, byte, byte, void>) GetUnmanagedPtr<Core_SetPedDlcPropDelegate>(funcTable, 18355053040011203830UL, Core_SetPedDlcPropFallback);
            Core_SetRotationVelocity = (delegate* unmanaged[Cdecl]<nint, int, Vector3, void>) GetUnmanagedPtr<Core_SetRotationVelocityDelegate>(funcTable, 6025325608795024645UL, Core_SetRotationVelocityFallback);
            Core_SetStatBool = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) GetUnmanagedPtr<Core_SetStatBoolDelegate>(funcTable, 5976505749163784383UL, Core_SetStatBoolFallback);
            Core_SetStatFloat = (delegate* unmanaged[Cdecl]<nint, nint, float, void>) GetUnmanagedPtr<Core_SetStatFloatDelegate>(funcTable, 17910078615237601616UL, Core_SetStatFloatFallback);
            Core_SetStatInt = (delegate* unmanaged[Cdecl]<nint, nint, int, void>) GetUnmanagedPtr<Core_SetStatIntDelegate>(funcTable, 7586687973544236922UL, Core_SetStatIntFallback);
            Core_SetStatLong = (delegate* unmanaged[Cdecl]<nint, nint, long, void>) GetUnmanagedPtr<Core_SetStatLongDelegate>(funcTable, 966754007191809072UL, Core_SetStatLongFallback);
            Core_SetStatString = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<Core_SetStatStringDelegate>(funcTable, 7897642741297771571UL, Core_SetStatStringFallback);
            Core_SetStatUInt16 = (delegate* unmanaged[Cdecl]<nint, nint, ushort, void>) GetUnmanagedPtr<Core_SetStatUInt16Delegate>(funcTable, 3853551070927598127UL, Core_SetStatUInt16Fallback);
            Core_SetStatUInt32 = (delegate* unmanaged[Cdecl]<nint, nint, uint, void>) GetUnmanagedPtr<Core_SetStatUInt32Delegate>(funcTable, 12531864998990370835UL, Core_SetStatUInt32Fallback);
            Core_SetStatUInt64 = (delegate* unmanaged[Cdecl]<nint, nint, ulong, void>) GetUnmanagedPtr<Core_SetStatUInt64Delegate>(funcTable, 1883057044483778445UL, Core_SetStatUInt64Fallback);
            Core_SetStatUInt8 = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) GetUnmanagedPtr<Core_SetStatUInt8Delegate>(funcTable, 15051718600062446893UL, Core_SetStatUInt8Fallback);
            Core_SetVoiceInputMuted = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Core_SetVoiceInputMutedDelegate>(funcTable, 7814638701493567231UL, Core_SetVoiceInputMutedFallback);
            Core_SetWatermarkPosition = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Core_SetWatermarkPositionDelegate>(funcTable, 7934747004301392615UL, Core_SetWatermarkPositionFallback);
            Core_SetWeatherCycle = (delegate* unmanaged[Cdecl]<nint, byte[], int, byte[], int, void>) GetUnmanagedPtr<Core_SetWeatherCycleDelegate>(funcTable, 16585286735482336540UL, Core_SetWeatherCycleFallback);
            Core_SetWeatherSyncActive = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Core_SetWeatherSyncActiveDelegate>(funcTable, 13045279996168078519UL, Core_SetWeatherSyncActiveFallback);
            Core_ShowCursor = (delegate* unmanaged[Cdecl]<nint, nint, bool, void>) GetUnmanagedPtr<Core_ShowCursorDelegate>(funcTable, 116504442046363049UL, Core_ShowCursorFallback);
            Core_StringToSHA256 = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint>) GetUnmanagedPtr<Core_StringToSHA256Delegate>(funcTable, 12026527936481267742UL, Core_StringToSHA256Fallback);
            Core_TakeScreenshot = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ScreenshotResultModuleDelegate, byte>) GetUnmanagedPtr<Core_TakeScreenshotDelegate>(funcTable, 3114386706331256143UL, Core_TakeScreenshotFallback);
            Core_TakeScreenshotGameOnly = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ScreenshotResultModuleDelegate, byte>) GetUnmanagedPtr<Core_TakeScreenshotGameOnlyDelegate>(funcTable, 9005944037868881587UL, Core_TakeScreenshotGameOnlyFallback);
            Core_ToggleGameControls = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) GetUnmanagedPtr<Core_ToggleGameControlsDelegate>(funcTable, 12189407258528336173UL, Core_ToggleGameControlsFallback);
            Core_ToggleRmlControls = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Core_ToggleRmlControlsDelegate>(funcTable, 6777794076841720469UL, Core_ToggleRmlControlsFallback);
            Core_ToggleVoiceControls = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Core_ToggleVoiceControlsDelegate>(funcTable, 9233489201974974422UL, Core_ToggleVoiceControlsFallback);
            Core_TriggerServerEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) GetUnmanagedPtr<Core_TriggerServerEventDelegate>(funcTable, 4092140335578989631UL, Core_TriggerServerEventFallback);
            Core_TriggerServerEventUnreliable = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) GetUnmanagedPtr<Core_TriggerServerEventUnreliableDelegate>(funcTable, 718150788563346996UL, Core_TriggerServerEventUnreliableFallback);
            Core_TriggerWebViewEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void>) GetUnmanagedPtr<Core_TriggerWebViewEventDelegate>(funcTable, 3268039739443301173UL, Core_TriggerWebViewEventFallback);
            Core_UnloadYtyp = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<Core_UnloadYtypDelegate>(funcTable, 17753040748478874447UL, Core_UnloadYtypFallback);
            Core_WorldToScreen = (delegate* unmanaged[Cdecl]<nint, Vector3, Vector2*, void>) GetUnmanagedPtr<Core_WorldToScreenDelegate>(funcTable, 5389506501733691988UL, Core_WorldToScreenFallback);
            Entity_GetScriptID = (delegate* unmanaged[Cdecl]<nint, int>) GetUnmanagedPtr<Entity_GetScriptIDDelegate>(funcTable, 12438992660215991189UL, Entity_GetScriptIDFallback);
            Event_SetAnyResourceErrorDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceErrorModuleDelegate, void>) GetUnmanagedPtr<Event_SetAnyResourceErrorDelegateDelegate>(funcTable, 14079997901958077241UL, Event_SetAnyResourceErrorDelegateFallback);
            Event_SetAnyResourceStartDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceStartModuleDelegate, void>) GetUnmanagedPtr<Event_SetAnyResourceStartDelegateDelegate>(funcTable, 18259284189737259993UL, Event_SetAnyResourceStartDelegateFallback);
            Event_SetAnyResourceStopDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceStopModuleDelegate, void>) GetUnmanagedPtr<Event_SetAnyResourceStopDelegateDelegate>(funcTable, 13707820718504089625UL, Event_SetAnyResourceStopDelegateFallback);
            Event_SetCheckpointDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CheckpointModuleDelegate, void>) GetUnmanagedPtr<Event_SetCheckpointDelegateDelegate>(funcTable, 9134925632861949057UL, Event_SetCheckpointDelegateFallback);
            Event_SetClientEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ClientEventModuleDelegate, void>) GetUnmanagedPtr<Event_SetClientEventDelegateDelegate>(funcTable, 8284770729125093177UL, Event_SetClientEventDelegateFallback);
            Event_SetColShapeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ColShapeModuleDelegate, void>) GetUnmanagedPtr<Event_SetColShapeDelegateDelegate>(funcTable, 1859619355480397883UL, Event_SetColShapeDelegateFallback);
            Event_SetConnectionCompleteDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ConnectionCompleteModuleDelegate, void>) GetUnmanagedPtr<Event_SetConnectionCompleteDelegateDelegate>(funcTable, 12310767706503758111UL, Event_SetConnectionCompleteDelegateFallback);
            Event_SetConsoleCommandDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ConsoleCommandModuleDelegate, void>) GetUnmanagedPtr<Event_SetConsoleCommandDelegateDelegate>(funcTable, 11736526557039894433UL, Event_SetConsoleCommandDelegateFallback);
            Event_SetCreateBaseObjectDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateBaseObjectModuleDelegate, void>) GetUnmanagedPtr<Event_SetCreateBaseObjectDelegateDelegate>(funcTable, 3079581392961204745UL, Event_SetCreateBaseObjectDelegateFallback);
            Event_SetGameEntityCreateDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityCreateModuleDelegate, void>) GetUnmanagedPtr<Event_SetGameEntityCreateDelegateDelegate>(funcTable, 8846162864874241135UL, Event_SetGameEntityCreateDelegateFallback);
            Event_SetGameEntityDestroyDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityDestroyModuleDelegate, void>) GetUnmanagedPtr<Event_SetGameEntityDestroyDelegateDelegate>(funcTable, 16291703028607344173UL, Event_SetGameEntityDestroyDelegateFallback);
            Event_SetGlobalMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalMetaChangeModuleDelegate, void>) GetUnmanagedPtr<Event_SetGlobalMetaChangeDelegateDelegate>(funcTable, 263634197021329745UL, Event_SetGlobalMetaChangeDelegateFallback);
            Event_SetGlobalSyncedMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalSyncedMetaChangeModuleDelegate, void>) GetUnmanagedPtr<Event_SetGlobalSyncedMetaChangeDelegateDelegate>(funcTable, 3897147411585328099UL, Event_SetGlobalSyncedMetaChangeDelegateFallback);
            Event_SetKeyDownDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void>) GetUnmanagedPtr<Event_SetKeyDownDelegateDelegate>(funcTable, 9792688891158114141UL, Event_SetKeyDownDelegateFallback);
            Event_SetKeyUpDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void>) GetUnmanagedPtr<Event_SetKeyUpDelegateDelegate>(funcTable, 13013609938360144345UL, Event_SetKeyUpDelegateFallback);
            Event_SetLocalMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.LocalMetaChangeModuleDelegate, void>) GetUnmanagedPtr<Event_SetLocalMetaChangeDelegateDelegate>(funcTable, 1555813148561817401UL, Event_SetLocalMetaChangeDelegateFallback);
            Event_SetMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.MetaChangeModuleDelegate, void>) GetUnmanagedPtr<Event_SetMetaChangeDelegateDelegate>(funcTable, 10052271841742065911UL, Event_SetMetaChangeDelegateFallback);
            Event_SetNetOwnerChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.NetOwnerChangeModuleDelegate, void>) GetUnmanagedPtr<Event_SetNetOwnerChangeDelegateDelegate>(funcTable, 15651483423859541657UL, Event_SetNetOwnerChangeDelegateFallback);
            Event_SetPlayerChangeAnimationDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeAnimationModuleDelegate, void>) GetUnmanagedPtr<Event_SetPlayerChangeAnimationDelegateDelegate>(funcTable, 1013031841840963141UL, Event_SetPlayerChangeAnimationDelegateFallback);
            Event_SetPlayerChangeInteriorDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeInteriorModuleDelegate, void>) GetUnmanagedPtr<Event_SetPlayerChangeInteriorDelegateDelegate>(funcTable, 10641081887455190199UL, Event_SetPlayerChangeInteriorDelegateFallback);
            Event_SetPlayerChangeVehicleSeatDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeVehicleSeatModuleDelegate, void>) GetUnmanagedPtr<Event_SetPlayerChangeVehicleSeatDelegateDelegate>(funcTable, 2849447755791784577UL, Event_SetPlayerChangeVehicleSeatDelegateFallback);
            Event_SetPlayerDisconnectDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerDisconnectModuleDelegate, void>) GetUnmanagedPtr<Event_SetPlayerDisconnectDelegateDelegate>(funcTable, 11526105887646755055UL, Event_SetPlayerDisconnectDelegateFallback);
            Event_SetPlayerEnterVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerEnterVehicleModuleDelegate, void>) GetUnmanagedPtr<Event_SetPlayerEnterVehicleDelegateDelegate>(funcTable, 16259534399403863387UL, Event_SetPlayerEnterVehicleDelegateFallback);
            Event_SetPlayerLeaveVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerLeaveVehicleModuleDelegate, void>) GetUnmanagedPtr<Event_SetPlayerLeaveVehicleDelegateDelegate>(funcTable, 10354256863799375649UL, Event_SetPlayerLeaveVehicleDelegateFallback);
            Event_SetPlayerSpawnDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerSpawnModuleDelegate, void>) GetUnmanagedPtr<Event_SetPlayerSpawnDelegateDelegate>(funcTable, 2502988276907442605UL, Event_SetPlayerSpawnDelegateFallback);
            Event_SetPlayerWeaponChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerWeaponChangeModuleDelegate, void>) GetUnmanagedPtr<Event_SetPlayerWeaponChangeDelegateDelegate>(funcTable, 5096554163307275927UL, Event_SetPlayerWeaponChangeDelegateFallback);
            Event_SetPlayerWeaponShootDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerWeaponShootModuleDelegate, void>) GetUnmanagedPtr<Event_SetPlayerWeaponShootDelegateDelegate>(funcTable, 12142428092035142689UL, Event_SetPlayerWeaponShootDelegateFallback);
            Event_SetRemoveBaseObjectDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveBaseObjectModuleDelegate, void>) GetUnmanagedPtr<Event_SetRemoveBaseObjectDelegateDelegate>(funcTable, 8121512912272945641UL, Event_SetRemoveBaseObjectDelegateFallback);
            Event_SetRmlEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RmlEventModuleDelegate, void>) GetUnmanagedPtr<Event_SetRmlEventDelegateDelegate>(funcTable, 1513529985252499227UL, Event_SetRmlEventDelegateFallback);
            Event_SetServerEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ServerEventModuleDelegate, void>) GetUnmanagedPtr<Event_SetServerEventDelegateDelegate>(funcTable, 5521055548998327457UL, Event_SetServerEventDelegateFallback);
            Event_SetStreamSyncedMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.StreamSyncedMetaChangeModuleDelegate, void>) GetUnmanagedPtr<Event_SetStreamSyncedMetaChangeDelegateDelegate>(funcTable, 8576321635222028243UL, Event_SetStreamSyncedMetaChangeDelegateFallback);
            Event_SetSyncedMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.SyncedMetaChangeModuleDelegate, void>) GetUnmanagedPtr<Event_SetSyncedMetaChangeDelegateDelegate>(funcTable, 12745100726667735891UL, Event_SetSyncedMetaChangeDelegateFallback);
            Event_SetTaskChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.TaskChangeModuleDelegate, void>) GetUnmanagedPtr<Event_SetTaskChangeDelegateDelegate>(funcTable, 11607888672861240667UL, Event_SetTaskChangeDelegateFallback);
            Event_SetTickDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.TickModuleDelegate, void>) GetUnmanagedPtr<Event_SetTickDelegateDelegate>(funcTable, 6297655192007422547UL, Event_SetTickDelegateFallback);
            Event_SetWeaponDamageDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WeaponDamageModuleDelegate, void>) GetUnmanagedPtr<Event_SetWeaponDamageDelegateDelegate>(funcTable, 3915432127661349363UL, Event_SetWeaponDamageDelegateFallback);
            Event_SetWebSocketEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WebSocketEventModuleDelegate, void>) GetUnmanagedPtr<Event_SetWebSocketEventDelegateDelegate>(funcTable, 1607737297081958503UL, Event_SetWebSocketEventDelegateFallback);
            Event_SetWebViewEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WebViewEventModuleDelegate, void>) GetUnmanagedPtr<Event_SetWebViewEventDelegateDelegate>(funcTable, 12568421593610200155UL, Event_SetWebViewEventDelegateFallback);
            Event_SetWindowFocusChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WindowFocusChangeModuleDelegate, void>) GetUnmanagedPtr<Event_SetWindowFocusChangeDelegateDelegate>(funcTable, 3313131202173863273UL, Event_SetWindowFocusChangeDelegateFallback);
            Event_SetWindowResolutionChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WindowResolutionChangeModuleDelegate, void>) GetUnmanagedPtr<Event_SetWindowResolutionChangeDelegateDelegate>(funcTable, 15282055500069881033UL, Event_SetWindowResolutionChangeDelegateFallback);
            Event_SetWorldObjectPositionChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WorldObjectPositionChangeModuleDelegate, void>) GetUnmanagedPtr<Event_SetWorldObjectPositionChangeDelegateDelegate>(funcTable, 8085309467174887077UL, Event_SetWorldObjectPositionChangeDelegateFallback);
            Event_SetWorldObjectStreamInDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WorldObjectStreamInModuleDelegate, void>) GetUnmanagedPtr<Event_SetWorldObjectStreamInDelegateDelegate>(funcTable, 12189198227473694261UL, Event_SetWorldObjectStreamInDelegateFallback);
            Event_SetWorldObjectStreamOutDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WorldObjectStreamOutModuleDelegate, void>) GetUnmanagedPtr<Event_SetWorldObjectStreamOutDelegateDelegate>(funcTable, 1153552198753902363UL, Event_SetWorldObjectStreamOutDelegateFallback);
            FreeRmlElementArray = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<FreeRmlElementArrayDelegate>(funcTable, 14086618333811829142UL, FreeRmlElementArrayFallback);
            GetNativeFuncTable = (delegate* unmanaged[Cdecl]<nint>) GetUnmanagedPtr<GetNativeFuncTableDelegate>(funcTable, 15955613981878964089UL, GetNativeFuncTableFallback);
            Handling_GetAcceleration = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetAccelerationDelegate>(funcTable, 13640121750592766571UL, Handling_GetAccelerationFallback);
            Handling_GetAntiRollBarBiasFront = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetAntiRollBarBiasFrontDelegate>(funcTable, 6509087878150057559UL, Handling_GetAntiRollBarBiasFrontFallback);
            Handling_GetAntiRollBarBiasRear = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetAntiRollBarBiasRearDelegate>(funcTable, 10256732486804859248UL, Handling_GetAntiRollBarBiasRearFallback);
            Handling_GetAntiRollBarForce = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetAntiRollBarForceDelegate>(funcTable, 15070448398404561078UL, Handling_GetAntiRollBarForceFallback);
            Handling_GetBrakeBiasFront = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetBrakeBiasFrontDelegate>(funcTable, 12193334824673381544UL, Handling_GetBrakeBiasFrontFallback);
            Handling_GetBrakeBiasRear = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetBrakeBiasRearDelegate>(funcTable, 1311793400499101185UL, Handling_GetBrakeBiasRearFallback);
            Handling_GetBrakeForce = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetBrakeForceDelegate>(funcTable, 16077423409890630453UL, Handling_GetBrakeForceFallback);
            Handling_GetCamberStiffness = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetCamberStiffnessDelegate>(funcTable, 7034652040042312382UL, Handling_GetCamberStiffnessFallback);
            Handling_GetCentreOfMassOffset = (delegate* unmanaged[Cdecl]<uint, Vector3*, void>) GetUnmanagedPtr<Handling_GetCentreOfMassOffsetDelegate>(funcTable, 9087734868325776496UL, Handling_GetCentreOfMassOffsetFallback);
            Handling_GetClutchChangeRateScaleDownShift = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetClutchChangeRateScaleDownShiftDelegate>(funcTable, 18110194879225217864UL, Handling_GetClutchChangeRateScaleDownShiftFallback);
            Handling_GetClutchChangeRateScaleUpShift = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetClutchChangeRateScaleUpShiftDelegate>(funcTable, 14867633031441795237UL, Handling_GetClutchChangeRateScaleUpShiftFallback);
            Handling_GetCollisionDamageMult = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetCollisionDamageMultDelegate>(funcTable, 12867000272333939660UL, Handling_GetCollisionDamageMultFallback);
            Handling_GetDamageFlags = (delegate* unmanaged[Cdecl]<uint, uint>) GetUnmanagedPtr<Handling_GetDamageFlagsDelegate>(funcTable, 15564643496952804311UL, Handling_GetDamageFlagsFallback);
            Handling_GetDeformationDamageMult = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetDeformationDamageMultDelegate>(funcTable, 5381538823265150070UL, Handling_GetDeformationDamageMultFallback);
            Handling_GetDownforceModifier = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetDownforceModifierDelegate>(funcTable, 7829933718567089587UL, Handling_GetDownforceModifierFallback);
            Handling_GetDriveBiasFront = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetDriveBiasFrontDelegate>(funcTable, 5342300288616537851UL, Handling_GetDriveBiasFrontFallback);
            Handling_GetDriveInertia = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetDriveInertiaDelegate>(funcTable, 14153061510559409341UL, Handling_GetDriveInertiaFallback);
            Handling_GetDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetDriveMaxFlatVelDelegate>(funcTable, 7459423795923006317UL, Handling_GetDriveMaxFlatVelFallback);
            Handling_GetEngineDamageMult = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetEngineDamageMultDelegate>(funcTable, 496589732490112468UL, Handling_GetEngineDamageMultFallback);
            Handling_GetHandBrakeForce = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetHandBrakeForceDelegate>(funcTable, 6070053561112702062UL, Handling_GetHandBrakeForceFallback);
            Handling_GetHandlingFlags = (delegate* unmanaged[Cdecl]<uint, uint>) GetUnmanagedPtr<Handling_GetHandlingFlagsDelegate>(funcTable, 6962542370431861347UL, Handling_GetHandlingFlagsFallback);
            Handling_GetHandlingNameHash = (delegate* unmanaged[Cdecl]<uint, uint>) GetUnmanagedPtr<Handling_GetHandlingNameHashDelegate>(funcTable, 7903031557311169491UL, Handling_GetHandlingNameHashFallback);
            Handling_GetInertiaMultiplier = (delegate* unmanaged[Cdecl]<uint, Vector3*, void>) GetUnmanagedPtr<Handling_GetInertiaMultiplierDelegate>(funcTable, 6225482181288706658UL, Handling_GetInertiaMultiplierFallback);
            Handling_GetInitialDragCoeff = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetInitialDragCoeffDelegate>(funcTable, 10720335020863185538UL, Handling_GetInitialDragCoeffFallback);
            Handling_GetInitialDriveForce = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetInitialDriveForceDelegate>(funcTable, 2032569468200694716UL, Handling_GetInitialDriveForceFallback);
            Handling_GetInitialDriveGears = (delegate* unmanaged[Cdecl]<uint, uint>) GetUnmanagedPtr<Handling_GetInitialDriveGearsDelegate>(funcTable, 3477491608161757695UL, Handling_GetInitialDriveGearsFallback);
            Handling_GetInitialDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetInitialDriveMaxFlatVelDelegate>(funcTable, 14911638129270116483UL, Handling_GetInitialDriveMaxFlatVelFallback);
            Handling_GetLowSpeedTractionLossMult = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetLowSpeedTractionLossMultDelegate>(funcTable, 3910172163486028031UL, Handling_GetLowSpeedTractionLossMultFallback);
            Handling_GetMass = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetMassDelegate>(funcTable, 16503753649195520827UL, Handling_GetMassFallback);
            Handling_GetModelFlags = (delegate* unmanaged[Cdecl]<uint, uint>) GetUnmanagedPtr<Handling_GetModelFlagsDelegate>(funcTable, 16471152888163436925UL, Handling_GetModelFlagsFallback);
            Handling_GetMonetaryValue = (delegate* unmanaged[Cdecl]<uint, uint>) GetUnmanagedPtr<Handling_GetMonetaryValueDelegate>(funcTable, 15249223473075651523UL, Handling_GetMonetaryValueFallback);
            Handling_GetOilVolume = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetOilVolumeDelegate>(funcTable, 15793792662665813751UL, Handling_GetOilVolumeFallback);
            Handling_GetPercentSubmerged = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetPercentSubmergedDelegate>(funcTable, 3162106568401648632UL, Handling_GetPercentSubmergedFallback);
            Handling_GetPercentSubmergedRatio = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetPercentSubmergedRatioDelegate>(funcTable, 14775477681684572161UL, Handling_GetPercentSubmergedRatioFallback);
            Handling_GetPetrolTankVolume = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetPetrolTankVolumeDelegate>(funcTable, 9804426030471504335UL, Handling_GetPetrolTankVolumeFallback);
            Handling_GetRollCentreHeightFront = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetRollCentreHeightFrontDelegate>(funcTable, 12195085171321915651UL, Handling_GetRollCentreHeightFrontFallback);
            Handling_GetRollCentreHeightRear = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetRollCentreHeightRearDelegate>(funcTable, 11241408610602895836UL, Handling_GetRollCentreHeightRearFallback);
            Handling_GetSeatOffsetDistX = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetSeatOffsetDistXDelegate>(funcTable, 3042828230575818279UL, Handling_GetSeatOffsetDistXFallback);
            Handling_GetSeatOffsetDistY = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetSeatOffsetDistYDelegate>(funcTable, 16760108398390445714UL, Handling_GetSeatOffsetDistYFallback);
            Handling_GetSeatOffsetDistZ = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetSeatOffsetDistZDelegate>(funcTable, 6633475798662300569UL, Handling_GetSeatOffsetDistZFallback);
            Handling_GetSteeringLock = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetSteeringLockDelegate>(funcTable, 5769493266015753395UL, Handling_GetSteeringLockFallback);
            Handling_GetSteeringLockRatio = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetSteeringLockRatioDelegate>(funcTable, 13969835253681202000UL, Handling_GetSteeringLockRatioFallback);
            Handling_GetSuspensionBiasFront = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetSuspensionBiasFrontDelegate>(funcTable, 13263749569856476492UL, Handling_GetSuspensionBiasFrontFallback);
            Handling_GetSuspensionBiasRear = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetSuspensionBiasRearDelegate>(funcTable, 16486706265955324677UL, Handling_GetSuspensionBiasRearFallback);
            Handling_GetSuspensionCompDamp = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetSuspensionCompDampDelegate>(funcTable, 11275793516157249723UL, Handling_GetSuspensionCompDampFallback);
            Handling_GetSuspensionForce = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetSuspensionForceDelegate>(funcTable, 4725366036834847137UL, Handling_GetSuspensionForceFallback);
            Handling_GetSuspensionLowerLimit = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetSuspensionLowerLimitDelegate>(funcTable, 2218754085154588696UL, Handling_GetSuspensionLowerLimitFallback);
            Handling_GetSuspensionRaise = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetSuspensionRaiseDelegate>(funcTable, 6322519027849983332UL, Handling_GetSuspensionRaiseFallback);
            Handling_GetSuspensionReboundDamp = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetSuspensionReboundDampDelegate>(funcTable, 9970530249142124439UL, Handling_GetSuspensionReboundDampFallback);
            Handling_GetSuspensionUpperLimit = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetSuspensionUpperLimitDelegate>(funcTable, 9712770424552208677UL, Handling_GetSuspensionUpperLimitFallback);
            Handling_GetTractionBiasFront = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetTractionBiasFrontDelegate>(funcTable, 8208890300147464313UL, Handling_GetTractionBiasFrontFallback);
            Handling_GetTractionBiasRear = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetTractionBiasRearDelegate>(funcTable, 518028693101285054UL, Handling_GetTractionBiasRearFallback);
            Handling_GetTractionCurveLateral = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetTractionCurveLateralDelegate>(funcTable, 16115188561501757109UL, Handling_GetTractionCurveLateralFallback);
            Handling_GetTractionCurveLateralRatio = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetTractionCurveLateralRatioDelegate>(funcTable, 12796358647581644614UL, Handling_GetTractionCurveLateralRatioFallback);
            Handling_GetTractionCurveMax = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetTractionCurveMaxDelegate>(funcTable, 17999502034314921050UL, Handling_GetTractionCurveMaxFallback);
            Handling_GetTractionCurveMaxRatio = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetTractionCurveMaxRatioDelegate>(funcTable, 14850880836919503279UL, Handling_GetTractionCurveMaxRatioFallback);
            Handling_GetTractionCurveMin = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetTractionCurveMinDelegate>(funcTable, 1131939413563292152UL, Handling_GetTractionCurveMinFallback);
            Handling_GetTractionCurveMinRatio = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetTractionCurveMinRatioDelegate>(funcTable, 18223709290805191169UL, Handling_GetTractionCurveMinRatioFallback);
            Handling_GetTractionLossMult = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetTractionLossMultDelegate>(funcTable, 11014941263668810732UL, Handling_GetTractionLossMultFallback);
            Handling_GetTractionSpringDeltaMax = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetTractionSpringDeltaMaxDelegate>(funcTable, 12997318808710526924UL, Handling_GetTractionSpringDeltaMaxFallback);
            Handling_GetTractionSpringDeltaMaxRatio = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetTractionSpringDeltaMaxRatioDelegate>(funcTable, 7706641570588997421UL, Handling_GetTractionSpringDeltaMaxRatioFallback);
            Handling_GetunkFloat1 = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetunkFloat1Delegate>(funcTable, 15712892985873465694UL, Handling_GetunkFloat1Fallback);
            Handling_GetunkFloat2 = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetunkFloat2Delegate>(funcTable, 8778495500291373909UL, Handling_GetunkFloat2Fallback);
            Handling_GetunkFloat4 = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetunkFloat4Delegate>(funcTable, 16356297962238647527UL, Handling_GetunkFloat4Fallback);
            Handling_GetunkFloat5 = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetunkFloat5Delegate>(funcTable, 4661719046437834322UL, Handling_GetunkFloat5Fallback);
            Handling_GetWeaponDamageMult = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<Handling_GetWeaponDamageMultDelegate>(funcTable, 277249662807444034UL, Handling_GetWeaponDamageMultFallback);
            Handling_SetAcceleration = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetAccelerationDelegate>(funcTable, 16866255586563037390UL, Handling_SetAccelerationFallback);
            Handling_SetAntiRollBarBiasFront = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetAntiRollBarBiasFrontDelegate>(funcTable, 9421920479908058850UL, Handling_SetAntiRollBarBiasFrontFallback);
            Handling_SetAntiRollBarBiasRear = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetAntiRollBarBiasRearDelegate>(funcTable, 16105117954749420927UL, Handling_SetAntiRollBarBiasRearFallback);
            Handling_SetAntiRollBarForce = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetAntiRollBarForceDelegate>(funcTable, 10250999986359269437UL, Handling_SetAntiRollBarForceFallback);
            Handling_SetBrakeBiasFront = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetBrakeBiasFrontDelegate>(funcTable, 17378707885284136007UL, Handling_SetBrakeBiasFrontFallback);
            Handling_SetBrakeBiasRear = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetBrakeBiasRearDelegate>(funcTable, 18388086088039249292UL, Handling_SetBrakeBiasRearFallback);
            Handling_SetBrakeForce = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetBrakeForceDelegate>(funcTable, 6278267294049833272UL, Handling_SetBrakeForceFallback);
            Handling_SetCamberStiffness = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetCamberStiffnessDelegate>(funcTable, 8006158683824150549UL, Handling_SetCamberStiffnessFallback);
            Handling_SetCentreOfMassOffset = (delegate* unmanaged[Cdecl]<uint, Vector3, void>) GetUnmanagedPtr<Handling_SetCentreOfMassOffsetDelegate>(funcTable, 230584723392666224UL, Handling_SetCentreOfMassOffsetFallback);
            Handling_SetClutchChangeRateScaleDownShift = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetClutchChangeRateScaleDownShiftDelegate>(funcTable, 2154015959963480959UL, Handling_SetClutchChangeRateScaleDownShiftFallback);
            Handling_SetClutchChangeRateScaleUpShift = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetClutchChangeRateScaleUpShiftDelegate>(funcTable, 9012916550907508640UL, Handling_SetClutchChangeRateScaleUpShiftFallback);
            Handling_SetCollisionDamageMult = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetCollisionDamageMultDelegate>(funcTable, 2861987634531657779UL, Handling_SetCollisionDamageMultFallback);
            Handling_SetDamageFlags = (delegate* unmanaged[Cdecl]<uint, uint, void>) GetUnmanagedPtr<Handling_SetDamageFlagsDelegate>(funcTable, 1408233360774057658UL, Handling_SetDamageFlagsFallback);
            Handling_SetDeformationDamageMult = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetDeformationDamageMultDelegate>(funcTable, 10141919336511995253UL, Handling_SetDeformationDamageMultFallback);
            Handling_SetDownforceModifier = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetDownforceModifierDelegate>(funcTable, 10480890064636847038UL, Handling_SetDownforceModifierFallback);
            Handling_SetDriveBiasFront = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetDriveBiasFrontDelegate>(funcTable, 13201673460408288262UL, Handling_SetDriveBiasFrontFallback);
            Handling_SetDriveInertia = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetDriveInertiaDelegate>(funcTable, 15611200483174743552UL, Handling_SetDriveInertiaFallback);
            Handling_SetDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetDriveMaxFlatVelDelegate>(funcTable, 3861610181173130504UL, Handling_SetDriveMaxFlatVelFallback);
            Handling_SetEngineDamageMult = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetEngineDamageMultDelegate>(funcTable, 8781324928923140083UL, Handling_SetEngineDamageMultFallback);
            Handling_SetHandBrakeForce = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetHandBrakeForceDelegate>(funcTable, 7762839872036477605UL, Handling_SetHandBrakeForceFallback);
            Handling_SetHandlingFlags = (delegate* unmanaged[Cdecl]<uint, uint, void>) GetUnmanagedPtr<Handling_SetHandlingFlagsDelegate>(funcTable, 3536265886880805678UL, Handling_SetHandlingFlagsFallback);
            Handling_SetInertiaMultiplier = (delegate* unmanaged[Cdecl]<uint, Vector3, void>) GetUnmanagedPtr<Handling_SetInertiaMultiplierDelegate>(funcTable, 13146875571840562122UL, Handling_SetInertiaMultiplierFallback);
            Handling_SetInitialDragCoeff = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetInitialDragCoeffDelegate>(funcTable, 5576269511232614785UL, Handling_SetInitialDragCoeffFallback);
            Handling_SetInitialDriveForce = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetInitialDriveForceDelegate>(funcTable, 12390677840693118275UL, Handling_SetInitialDriveForceFallback);
            Handling_SetInitialDriveGears = (delegate* unmanaged[Cdecl]<uint, uint, void>) GetUnmanagedPtr<Handling_SetInitialDriveGearsDelegate>(funcTable, 10521816927365923002UL, Handling_SetInitialDriveGearsFallback);
            Handling_SetInitialDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetInitialDriveMaxFlatVelDelegate>(funcTable, 5271240803351310462UL, Handling_SetInitialDriveMaxFlatVelFallback);
            Handling_SetLowSpeedTractionLossMult = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetLowSpeedTractionLossMultDelegate>(funcTable, 14304205891478132450UL, Handling_SetLowSpeedTractionLossMultFallback);
            Handling_SetMass = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetMassDelegate>(funcTable, 16520694489329105190UL, Handling_SetMassFallback);
            Handling_SetModelFlags = (delegate* unmanaged[Cdecl]<uint, uint, void>) GetUnmanagedPtr<Handling_SetModelFlagsDelegate>(funcTable, 14495929787086383136UL, Handling_SetModelFlagsFallback);
            Handling_SetMonetaryValue = (delegate* unmanaged[Cdecl]<uint, uint, void>) GetUnmanagedPtr<Handling_SetMonetaryValueDelegate>(funcTable, 8625449591148959670UL, Handling_SetMonetaryValueFallback);
            Handling_SetOilVolume = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetOilVolumeDelegate>(funcTable, 12030673134051984370UL, Handling_SetOilVolumeFallback);
            Handling_SetPercentSubmerged = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetPercentSubmergedDelegate>(funcTable, 13713342139114294543UL, Handling_SetPercentSubmergedFallback);
            Handling_SetPercentSubmergedRatio = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetPercentSubmergedRatioDelegate>(funcTable, 17282283658198254604UL, Handling_SetPercentSubmergedRatioFallback);
            Handling_SetPetrolTankVolume = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetPetrolTankVolumeDelegate>(funcTable, 7763339297554302098UL, Handling_SetPetrolTankVolumeFallback);
            Handling_SetRollCentreHeightFront = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetRollCentreHeightFrontDelegate>(funcTable, 17890615811903016862UL, Handling_SetRollCentreHeightFrontFallback);
            Handling_SetRollCentreHeightRear = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetRollCentreHeightRearDelegate>(funcTable, 16676432685378347227UL, Handling_SetRollCentreHeightRearFallback);
            Handling_SetSeatOffsetDistX = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetSeatOffsetDistXDelegate>(funcTable, 2180310838557494490UL, Handling_SetSeatOffsetDistXFallback);
            Handling_SetSeatOffsetDistY = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetSeatOffsetDistYDelegate>(funcTable, 8562731924397751049UL, Handling_SetSeatOffsetDistYFallback);
            Handling_SetSeatOffsetDistZ = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetSeatOffsetDistZDelegate>(funcTable, 15289882413715294428UL, Handling_SetSeatOffsetDistZFallback);
            Handling_SetSteeringLock = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetSteeringLockDelegate>(funcTable, 12740843278827647086UL, Handling_SetSteeringLockFallback);
            Handling_SetSteeringLockRatio = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetSteeringLockRatioDelegate>(funcTable, 6803691727635975895UL, Handling_SetSteeringLockRatioFallback);
            Handling_SetSuspensionBiasFront = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetSuspensionBiasFrontDelegate>(funcTable, 11639418090534943587UL, Handling_SetSuspensionBiasFrontFallback);
            Handling_SetSuspensionBiasRear = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetSuspensionBiasRearDelegate>(funcTable, 1616664646841918808UL, Handling_SetSuspensionBiasRearFallback);
            Handling_SetSuspensionCompDamp = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetSuspensionCompDampDelegate>(funcTable, 422327979887670390UL, Handling_SetSuspensionCompDampFallback);
            Handling_SetSuspensionForce = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetSuspensionForceDelegate>(funcTable, 12753752240219159964UL, Handling_SetSuspensionForceFallback);
            Handling_SetSuspensionLowerLimit = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetSuspensionLowerLimitDelegate>(funcTable, 15616537274093301551UL, Handling_SetSuspensionLowerLimitFallback);
            Handling_SetSuspensionRaise = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetSuspensionRaiseDelegate>(funcTable, 6439176005833759571UL, Handling_SetSuspensionRaiseFallback);
            Handling_SetSuspensionReboundDamp = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetSuspensionReboundDampDelegate>(funcTable, 13521637365833375026UL, Handling_SetSuspensionReboundDampFallback);
            Handling_SetSuspensionUpperLimit = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetSuspensionUpperLimitDelegate>(funcTable, 8287121377107754360UL, Handling_SetSuspensionUpperLimitFallback);
            Handling_SetTractionBiasFront = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetTractionBiasFrontDelegate>(funcTable, 3329439851428631524UL, Handling_SetTractionBiasFrontFallback);
            Handling_SetTractionBiasRear = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetTractionBiasRearDelegate>(funcTable, 10770488584871025421UL, Handling_SetTractionBiasRearFallback);
            Handling_SetTractionCurveLateral = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetTractionCurveLateralDelegate>(funcTable, 222347075071495040UL, Handling_SetTractionCurveLateralFallback);
            Handling_SetTractionCurveLateralRatio = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetTractionCurveLateralRatioDelegate>(funcTable, 5807432443172453565UL, Handling_SetTractionCurveLateralRatioFallback);
            Handling_SetTractionCurveMax = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetTractionCurveMaxDelegate>(funcTable, 8378570435560866529UL, Handling_SetTractionCurveMaxFallback);
            Handling_SetTractionCurveMaxRatio = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetTractionCurveMaxRatioDelegate>(funcTable, 10991704476147084906UL, Handling_SetTractionCurveMaxRatioFallback);
            Handling_SetTractionCurveMin = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetTractionCurveMinDelegate>(funcTable, 8408170480838006775UL, Handling_SetTractionCurveMinFallback);
            Handling_SetTractionCurveMinRatio = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetTractionCurveMinRatioDelegate>(funcTable, 5928252640960202372UL, Handling_SetTractionCurveMinRatioFallback);
            Handling_SetTractionLossMult = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetTractionLossMultDelegate>(funcTable, 12791106940086909491UL, Handling_SetTractionLossMultFallback);
            Handling_SetTractionSpringDeltaMax = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetTractionSpringDeltaMaxDelegate>(funcTable, 13427075510262679803UL, Handling_SetTractionSpringDeltaMaxFallback);
            Handling_SetTractionSpringDeltaMaxRatio = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetTractionSpringDeltaMaxRatioDelegate>(funcTable, 15725739789188081296UL, Handling_SetTractionSpringDeltaMaxRatioFallback);
            Handling_SetunkFloat1 = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetunkFloat1Delegate>(funcTable, 17085352889016025885UL, Handling_SetunkFloat1Fallback);
            Handling_SetunkFloat2 = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetunkFloat2Delegate>(funcTable, 12067366790403314928UL, Handling_SetunkFloat2Fallback);
            Handling_SetunkFloat4 = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetunkFloat4Delegate>(funcTable, 12575454135444746890UL, Handling_SetunkFloat4Fallback);
            Handling_SetunkFloat5 = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetunkFloat5Delegate>(funcTable, 13881745711554294521UL, Handling_SetunkFloat5Fallback);
            Handling_SetWeaponDamageMult = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<Handling_SetWeaponDamageMultDelegate>(funcTable, 2629584631090240089UL, Handling_SetWeaponDamageMultFallback);
            HttpClient_Connect = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) GetUnmanagedPtr<HttpClient_ConnectDelegate>(funcTable, 14518115896852316044UL, HttpClient_ConnectFallback);
            HttpClient_Delete = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) GetUnmanagedPtr<HttpClient_DeleteDelegate>(funcTable, 12738580200349269835UL, HttpClient_DeleteFallback);
            HttpClient_Get = (delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) GetUnmanagedPtr<HttpClient_GetDelegate>(funcTable, 9939859777425678379UL, HttpClient_GetFallback);
            HttpClient_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<HttpClient_GetBaseObjectDelegate>(funcTable, 9733920421548981244UL, HttpClient_GetBaseObjectFallback);
            HttpClient_GetExtraHeaders = (delegate* unmanaged[Cdecl]<nint, nint*, nint*, int*, void>) GetUnmanagedPtr<HttpClient_GetExtraHeadersDelegate>(funcTable, 2324307793094272834UL, HttpClient_GetExtraHeadersFallback);
            HttpClient_Head = (delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) GetUnmanagedPtr<HttpClient_HeadDelegate>(funcTable, 12853676315635395495UL, HttpClient_HeadFallback);
            HttpClient_Options = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) GetUnmanagedPtr<HttpClient_OptionsDelegate>(funcTable, 6917164239019746796UL, HttpClient_OptionsFallback);
            HttpClient_Patch = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) GetUnmanagedPtr<HttpClient_PatchDelegate>(funcTable, 17492503413390795820UL, HttpClient_PatchFallback);
            HttpClient_Post = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) GetUnmanagedPtr<HttpClient_PostDelegate>(funcTable, 10115980172647901894UL, HttpClient_PostFallback);
            HttpClient_Put = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) GetUnmanagedPtr<HttpClient_PutDelegate>(funcTable, 8280976854604120523UL, HttpClient_PutFallback);
            HttpClient_SetExtraHeader = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<HttpClient_SetExtraHeaderDelegate>(funcTable, 4939806300942583161UL, HttpClient_SetExtraHeaderFallback);
            HttpClient_Trace = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) GetUnmanagedPtr<HttpClient_TraceDelegate>(funcTable, 12260251650657662947UL, HttpClient_TraceFallback);
            LocalPed_GetRemoteID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<LocalPed_GetRemoteIDDelegate>(funcTable, 3556889050580092677UL, LocalPed_GetRemoteIDFallback);
            LocalPed_GetScriptID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<LocalPed_GetScriptIDDelegate>(funcTable, 11244098567921137770UL, LocalPed_GetScriptIDFallback);
            LocalPed_IsRemote = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<LocalPed_IsRemoteDelegate>(funcTable, 8774830374925011759UL, LocalPed_IsRemoteFallback);
            LocalPed_IsStreamedIn = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<LocalPed_IsStreamedInDelegate>(funcTable, 17855389711155670583UL, LocalPed_IsStreamedInFallback);
            LocalPlayer_GetCurrentAmmo = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<LocalPlayer_GetCurrentAmmoDelegate>(funcTable, 18043294013722431113UL, LocalPlayer_GetCurrentAmmoFallback);
            LocalPlayer_GetCurrentWeaponHash = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<LocalPlayer_GetCurrentWeaponHashDelegate>(funcTable, 10510537453292567897UL, LocalPlayer_GetCurrentWeaponHashFallback);
            LocalPlayer_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<LocalPlayer_GetIDDelegate>(funcTable, 11619807947618676643UL, LocalPlayer_GetIDFallback);
            LocalPlayer_GetMaxStamina = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<LocalPlayer_GetMaxStaminaDelegate>(funcTable, 5236676524679058301UL, LocalPlayer_GetMaxStaminaFallback);
            LocalPlayer_GetPlayer = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<LocalPlayer_GetPlayerDelegate>(funcTable, 12486927465188645710UL, LocalPlayer_GetPlayerFallback);
            LocalPlayer_GetStamina = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<LocalPlayer_GetStaminaDelegate>(funcTable, 13452859435150190491UL, LocalPlayer_GetStaminaFallback);
            LocalPlayer_GetWeaponAmmo = (delegate* unmanaged[Cdecl]<nint, uint, ushort>) GetUnmanagedPtr<LocalPlayer_GetWeaponAmmoDelegate>(funcTable, 15876977288054249699UL, LocalPlayer_GetWeaponAmmoFallback);
            LocalPlayer_GetWeaponComponents = (delegate* unmanaged[Cdecl]<nint, uint, nint*, uint*, void>) GetUnmanagedPtr<LocalPlayer_GetWeaponComponentsDelegate>(funcTable, 8289213042275148887UL, LocalPlayer_GetWeaponComponentsFallback);
            LocalPlayer_GetWeapons = (delegate* unmanaged[Cdecl]<nint, nint*, uint*, void>) GetUnmanagedPtr<LocalPlayer_GetWeaponsDelegate>(funcTable, 16930194824602487393UL, LocalPlayer_GetWeaponsFallback);
            LocalPlayer_HasWeapon = (delegate* unmanaged[Cdecl]<nint, uint, byte>) GetUnmanagedPtr<LocalPlayer_HasWeaponDelegate>(funcTable, 7339081946549932096UL, LocalPlayer_HasWeaponFallback);
            LocalPlayer_SetMaxStamina = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<LocalPlayer_SetMaxStaminaDelegate>(funcTable, 311823464795673480UL, LocalPlayer_SetMaxStaminaFallback);
            LocalPlayer_SetStamina = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<LocalPlayer_SetStaminaDelegate>(funcTable, 15388475796254006774UL, LocalPlayer_SetStaminaFallback);
            LocalStorage_Clear = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<LocalStorage_ClearDelegate>(funcTable, 5882434795069919583UL, LocalStorage_ClearFallback);
            LocalStorage_DeleteKey = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<LocalStorage_DeleteKeyDelegate>(funcTable, 9477816035737488937UL, LocalStorage_DeleteKeyFallback);
            LocalStorage_GetKey = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<LocalStorage_GetKeyDelegate>(funcTable, 13895693989408516536UL, LocalStorage_GetKeyFallback);
            LocalStorage_Save = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<LocalStorage_SaveDelegate>(funcTable, 15681738723671545643UL, LocalStorage_SaveFallback);
            LocalStorage_SetKey = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<LocalStorage_SetKeyDelegate>(funcTable, 9720785834619501975UL, LocalStorage_SetKeyFallback);
            LocalVehicle_GetRemoteID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<LocalVehicle_GetRemoteIDDelegate>(funcTable, 9770939955199624595UL, LocalVehicle_GetRemoteIDFallback);
            LocalVehicle_GetScriptID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<LocalVehicle_GetScriptIDDelegate>(funcTable, 1209681771302240080UL, LocalVehicle_GetScriptIDFallback);
            LocalVehicle_IsRemote = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<LocalVehicle_IsRemoteDelegate>(funcTable, 13777437884824800799UL, LocalVehicle_IsRemoteFallback);
            LocalVehicle_IsStreamedIn = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<LocalVehicle_IsStreamedInDelegate>(funcTable, 15389369330489891823UL, LocalVehicle_IsStreamedInFallback);
            MapData_GetFScrollSpeed = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<MapData_GetFScrollSpeedDelegate>(funcTable, 5153918154812676518UL, MapData_GetFScrollSpeedFallback);
            MapData_GetFZoomScale = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<MapData_GetFZoomScaleDelegate>(funcTable, 9310461554478426287UL, MapData_GetFZoomScaleFallback);
            MapData_GetFZoomSpeed = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<MapData_GetFZoomSpeedDelegate>(funcTable, 13681270171346140740UL, MapData_GetFZoomSpeedFallback);
            MapData_GetVTilesX = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<MapData_GetVTilesXDelegate>(funcTable, 4099196628772301299UL, MapData_GetVTilesXFallback);
            MapData_GetVTilesY = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<MapData_GetVTilesYDelegate>(funcTable, 17185316530570654526UL, MapData_GetVTilesYFallback);
            MapData_SetFScrollSpeed = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<MapData_SetFScrollSpeedDelegate>(funcTable, 14258735547233246213UL, MapData_SetFScrollSpeedFallback);
            MapData_SetFZoomScale = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<MapData_SetFZoomScaleDelegate>(funcTable, 449380527313245266UL, MapData_SetFZoomScaleFallback);
            MapData_SetFZoomSpeed = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<MapData_SetFZoomSpeedDelegate>(funcTable, 2665336952407925027UL, MapData_SetFZoomSpeedFallback);
            MapData_SetVTilesX = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<MapData_SetVTilesXDelegate>(funcTable, 7101748004939864958UL, MapData_SetVTilesXFallback);
            MapData_SetVTilesY = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<MapData_SetVTilesYDelegate>(funcTable, 4990605972443241597UL, MapData_SetVTilesYFallback);
            Marker_GetRemoteID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Marker_GetRemoteIDDelegate>(funcTable, 4030920042457960705UL, Marker_GetRemoteIDFallback);
            Marker_IsRemote = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Marker_IsRemoteDelegate>(funcTable, 4843710155211034967UL, Marker_IsRemoteFallback);
            Object_IsRemote = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Object_IsRemoteDelegate>(funcTable, 9871487800950929995UL, Object_IsRemoteFallback);
            Object_IsStreamedIn = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Object_IsStreamedInDelegate>(funcTable, 14733844975814872903UL, Object_IsStreamedInFallback);
            Player_GetLocal = (delegate* unmanaged[Cdecl]<nint>) GetUnmanagedPtr<Player_GetLocalDelegate>(funcTable, 4153837117751475501UL, Player_GetLocalFallback);
            Player_GetMicLevel = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Player_GetMicLevelDelegate>(funcTable, 15449156962697427469UL, Player_GetMicLevelFallback);
            Player_GetNonSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Player_GetNonSpatialVolumeDelegate>(funcTable, 3333598534924196965UL, Player_GetNonSpatialVolumeFallback);
            Player_GetSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Player_GetSpatialVolumeDelegate>(funcTable, 1924883508304421034UL, Player_GetSpatialVolumeFallback);
            Player_IsTalking = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Player_IsTalkingDelegate>(funcTable, 2228995248668686637UL, Player_IsTalkingFallback);
            Player_SetNonSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Player_SetNonSpatialVolumeDelegate>(funcTable, 13836779891982146248UL, Player_SetNonSpatialVolumeFallback);
            Player_SetSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Player_SetSpatialVolumeDelegate>(funcTable, 2220752195777140849UL, Player_SetSpatialVolumeFallback);
            Resource_FileExists = (delegate* unmanaged[Cdecl]<nint, nint, bool>) GetUnmanagedPtr<Resource_FileExistsDelegate>(funcTable, 7333169666764702095UL, Resource_FileExistsFallback);
            Resource_GetFile = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint*, void>) GetUnmanagedPtr<Resource_GetFileDelegate>(funcTable, 6999624240602148408UL, Resource_GetFileFallback);
            Resource_GetLocalStorage = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<Resource_GetLocalStorageDelegate>(funcTable, 9724925408750062794UL, Resource_GetLocalStorageFallback);
            RmlDocument_CreateElement = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<RmlDocument_CreateElementDelegate>(funcTable, 8394251270352122332UL, RmlDocument_CreateElementFallback);
            RmlDocument_CreateTextNode = (delegate* unmanaged[Cdecl]<nint, nint, nint>) GetUnmanagedPtr<RmlDocument_CreateTextNodeDelegate>(funcTable, 7438392858638256497UL, RmlDocument_CreateTextNodeFallback);
            RmlDocument_GetBody = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<RmlDocument_GetBodyDelegate>(funcTable, 3163186035077937721UL, RmlDocument_GetBodyFallback);
            RmlDocument_GetRmlElement = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<RmlDocument_GetRmlElementDelegate>(funcTable, 13477729632222101190UL, RmlDocument_GetRmlElementFallback);
            RmlDocument_GetSourceUrl = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<RmlDocument_GetSourceUrlDelegate>(funcTable, 5192820878301116090UL, RmlDocument_GetSourceUrlFallback);
            RmlDocument_GetTitle = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<RmlDocument_GetTitleDelegate>(funcTable, 17830148757283697382UL, RmlDocument_GetTitleFallback);
            RmlDocument_Hide = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<RmlDocument_HideDelegate>(funcTable, 5659208679942729092UL, RmlDocument_HideFallback);
            RmlDocument_IsModal = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<RmlDocument_IsModalDelegate>(funcTable, 4436463553685911346UL, RmlDocument_IsModalFallback);
            RmlDocument_IsVisible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<RmlDocument_IsVisibleDelegate>(funcTable, 592516437879461567UL, RmlDocument_IsVisibleFallback);
            RmlDocument_SetTitle = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<RmlDocument_SetTitleDelegate>(funcTable, 13775656357343568853UL, RmlDocument_SetTitleFallback);
            RmlDocument_Show = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) GetUnmanagedPtr<RmlDocument_ShowDelegate>(funcTable, 15895391050437794405UL, RmlDocument_ShowFallback);
            RmlDocument_Update = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<RmlDocument_UpdateDelegate>(funcTable, 7796044476597861513UL, RmlDocument_UpdateFallback);
            RmlElement_AddClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void>) GetUnmanagedPtr<RmlElement_AddClassDelegate>(funcTable, 14077984434351350772UL, RmlElement_AddClassFallback);
            RmlElement_AddPseudoClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void>) GetUnmanagedPtr<RmlElement_AddPseudoClassDelegate>(funcTable, 1170410331129093106UL, RmlElement_AddPseudoClassFallback);
            RmlElement_AppendChild = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<RmlElement_AppendChildDelegate>(funcTable, 17728220528843273276UL, RmlElement_AppendChildFallback);
            RmlElement_Blur = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void>) GetUnmanagedPtr<RmlElement_BlurDelegate>(funcTable, 10971872640494644843UL, RmlElement_BlurFallback);
            RmlElement_Click = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void>) GetUnmanagedPtr<RmlElement_ClickDelegate>(funcTable, 16406947797483688126UL, RmlElement_ClickFallback);
            RmlElement_Focus = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void>) GetUnmanagedPtr<RmlElement_FocusDelegate>(funcTable, 13206000731161135546UL, RmlElement_FocusFallback);
            RmlElement_GetAbsoluteLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetAbsoluteLeftDelegate>(funcTable, 3408210961803447022UL, RmlElement_GetAbsoluteLeftFallback);
            RmlElement_GetAbsoluteOffset = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void>) GetUnmanagedPtr<RmlElement_GetAbsoluteOffsetDelegate>(funcTable, 327051398557117839UL, RmlElement_GetAbsoluteOffsetFallback);
            RmlElement_GetAbsoluteTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetAbsoluteTopDelegate>(funcTable, 2282235996872357720UL, RmlElement_GetAbsoluteTopFallback);
            RmlElement_GetAttribute = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint>) GetUnmanagedPtr<RmlElement_GetAttributeDelegate>(funcTable, 13502901951364202503UL, RmlElement_GetAttributeFallback);
            RmlElement_GetAttributes = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, nint*, uint*, void>) GetUnmanagedPtr<RmlElement_GetAttributesDelegate>(funcTable, 15583980586965112500UL, RmlElement_GetAttributesFallback);
            RmlElement_GetBaseline = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetBaselineDelegate>(funcTable, 5149977555457732673UL, RmlElement_GetBaselineFallback);
            RmlElement_GetBaseObject = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) GetUnmanagedPtr<RmlElement_GetBaseObjectDelegate>(funcTable, 3003380013478745532UL, RmlElement_GetBaseObjectFallback);
            RmlElement_GetChildCount = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, uint>) GetUnmanagedPtr<RmlElement_GetChildCountDelegate>(funcTable, 3428605514501400321UL, RmlElement_GetChildCountFallback);
            RmlElement_GetChildNodes = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void>) GetUnmanagedPtr<RmlElement_GetChildNodesDelegate>(funcTable, 4953541695606006102UL, RmlElement_GetChildNodesFallback);
            RmlElement_GetClassList = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void>) GetUnmanagedPtr<RmlElement_GetClassListDelegate>(funcTable, 10706410199538950394UL, RmlElement_GetClassListFallback);
            RmlElement_GetClientHeight = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetClientHeightDelegate>(funcTable, 9373516720903454738UL, RmlElement_GetClientHeightFallback);
            RmlElement_GetClientLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetClientLeftDelegate>(funcTable, 11545588651999170492UL, RmlElement_GetClientLeftFallback);
            RmlElement_GetClientTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetClientTopDelegate>(funcTable, 65608241643298882UL, RmlElement_GetClientTopFallback);
            RmlElement_GetClientWidth = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetClientWidthDelegate>(funcTable, 5805331239560198965UL, RmlElement_GetClientWidthFallback);
            RmlElement_GetClosest = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint>) GetUnmanagedPtr<RmlElement_GetClosestDelegate>(funcTable, 8510717355100354031UL, RmlElement_GetClosestFallback);
            RmlElement_GetContainingBlock = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void>) GetUnmanagedPtr<RmlElement_GetContainingBlockDelegate>(funcTable, 11181576916436475402UL, RmlElement_GetContainingBlockFallback);
            RmlElement_GetElementById = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint>) GetUnmanagedPtr<RmlElement_GetElementByIdDelegate>(funcTable, 11263720171078249248UL, RmlElement_GetElementByIdFallback);
            RmlElement_GetElementsByClassName = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void>) GetUnmanagedPtr<RmlElement_GetElementsByClassNameDelegate>(funcTable, 16780072708039950983UL, RmlElement_GetElementsByClassNameFallback);
            RmlElement_GetElementsByTagName = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void>) GetUnmanagedPtr<RmlElement_GetElementsByTagNameDelegate>(funcTable, 13630662056285368499UL, RmlElement_GetElementsByTagNameFallback);
            RmlElement_GetFirstChild = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) GetUnmanagedPtr<RmlElement_GetFirstChildDelegate>(funcTable, 6553458957728450615UL, RmlElement_GetFirstChildFallback);
            RmlElement_GetFocusedElement = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) GetUnmanagedPtr<RmlElement_GetFocusedElementDelegate>(funcTable, 13041364075361654452UL, RmlElement_GetFocusedElementFallback);
            RmlElement_GetInnerRml = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint>) GetUnmanagedPtr<RmlElement_GetInnerRmlDelegate>(funcTable, 5158963891260214371UL, RmlElement_GetInnerRmlFallback);
            RmlElement_GetLastChild = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) GetUnmanagedPtr<RmlElement_GetLastChildDelegate>(funcTable, 17352588287218438411UL, RmlElement_GetLastChildFallback);
            RmlElement_GetLocalProperty = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint>) GetUnmanagedPtr<RmlElement_GetLocalPropertyDelegate>(funcTable, 8073218222026259545UL, RmlElement_GetLocalPropertyFallback);
            RmlElement_GetNextSibling = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) GetUnmanagedPtr<RmlElement_GetNextSiblingDelegate>(funcTable, 10669792900656173800UL, RmlElement_GetNextSiblingFallback);
            RmlElement_GetOffsetHeight = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetOffsetHeightDelegate>(funcTable, 5197551779775381022UL, RmlElement_GetOffsetHeightFallback);
            RmlElement_GetOffsetLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetOffsetLeftDelegate>(funcTable, 580277859662252592UL, RmlElement_GetOffsetLeftFallback);
            RmlElement_GetOffsetTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetOffsetTopDelegate>(funcTable, 2505271217405816062UL, RmlElement_GetOffsetTopFallback);
            RmlElement_GetOffsetWidth = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetOffsetWidthDelegate>(funcTable, 6536101004380487001UL, RmlElement_GetOffsetWidthFallback);
            RmlElement_GetOwnerDocument = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) GetUnmanagedPtr<RmlElement_GetOwnerDocumentDelegate>(funcTable, 10162409526272546342UL, RmlElement_GetOwnerDocumentFallback);
            RmlElement_GetParent = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) GetUnmanagedPtr<RmlElement_GetParentDelegate>(funcTable, 6319997825989852827UL, RmlElement_GetParentFallback);
            RmlElement_GetPreviousSibling = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) GetUnmanagedPtr<RmlElement_GetPreviousSiblingDelegate>(funcTable, 7154920421729537988UL, RmlElement_GetPreviousSiblingFallback);
            RmlElement_GetProperty = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint>) GetUnmanagedPtr<RmlElement_GetPropertyDelegate>(funcTable, 3116251059678318494UL, RmlElement_GetPropertyFallback);
            RmlElement_GetPropertyAbsoluteValue = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, float>) GetUnmanagedPtr<RmlElement_GetPropertyAbsoluteValueDelegate>(funcTable, 1472783352164812952UL, RmlElement_GetPropertyAbsoluteValueFallback);
            RmlElement_GetPseudoClassList = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void>) GetUnmanagedPtr<RmlElement_GetPseudoClassListDelegate>(funcTable, 5954717048838062752UL, RmlElement_GetPseudoClassListFallback);
            RmlElement_GetRelativeOffset = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void>) GetUnmanagedPtr<RmlElement_GetRelativeOffsetDelegate>(funcTable, 11910576358229328046UL, RmlElement_GetRelativeOffsetFallback);
            RmlElement_GetRmlId = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint>) GetUnmanagedPtr<RmlElement_GetRmlIdDelegate>(funcTable, 753581056598568298UL, RmlElement_GetRmlIdFallback);
            RmlElement_GetScrollHeight = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetScrollHeightDelegate>(funcTable, 9108383606206669496UL, RmlElement_GetScrollHeightFallback);
            RmlElement_GetScrollLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetScrollLeftDelegate>(funcTable, 18439136340342378146UL, RmlElement_GetScrollLeftFallback);
            RmlElement_GetScrollTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetScrollTopDelegate>(funcTable, 12769945018436172868UL, RmlElement_GetScrollTopFallback);
            RmlElement_GetScrollWidth = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetScrollWidthDelegate>(funcTable, 13102543825718521159UL, RmlElement_GetScrollWidthFallback);
            RmlElement_GetTagName = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint>) GetUnmanagedPtr<RmlElement_GetTagNameDelegate>(funcTable, 1247944464691079813UL, RmlElement_GetTagNameFallback);
            RmlElement_GetZIndex = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) GetUnmanagedPtr<RmlElement_GetZIndexDelegate>(funcTable, 2741503180404494288UL, RmlElement_GetZIndexFallback);
            RmlElement_HasAttribute = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) GetUnmanagedPtr<RmlElement_HasAttributeDelegate>(funcTable, 3060759057644054684UL, RmlElement_HasAttributeFallback);
            RmlElement_HasChildren = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte>) GetUnmanagedPtr<RmlElement_HasChildrenDelegate>(funcTable, 13491878657537994760UL, RmlElement_HasChildrenFallback);
            RmlElement_HasClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) GetUnmanagedPtr<RmlElement_HasClassDelegate>(funcTable, 12580015942621427048UL, RmlElement_HasClassFallback);
            RmlElement_HasLocalProperty = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) GetUnmanagedPtr<RmlElement_HasLocalPropertyDelegate>(funcTable, 11665463956728223934UL, RmlElement_HasLocalPropertyFallback);
            RmlElement_HasProperty = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) GetUnmanagedPtr<RmlElement_HasPropertyDelegate>(funcTable, 3797843305932641739UL, RmlElement_HasPropertyFallback);
            RmlElement_HasPseudoClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) GetUnmanagedPtr<RmlElement_HasPseudoClassDelegate>(funcTable, 15268086550568970510UL, RmlElement_HasPseudoClassFallback);
            RmlElement_InsertBefore = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<RmlElement_InsertBeforeDelegate>(funcTable, 6666593390906623970UL, RmlElement_InsertBeforeFallback);
            RmlElement_IsOwned = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte>) GetUnmanagedPtr<RmlElement_IsOwnedDelegate>(funcTable, 33208906076258982UL, RmlElement_IsOwnedFallback);
            RmlElement_IsPointWithinElement = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2, byte>) GetUnmanagedPtr<RmlElement_IsPointWithinElementDelegate>(funcTable, 14201942279164433661UL, RmlElement_IsPointWithinElementFallback);
            RmlElement_IsVisible = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte>) GetUnmanagedPtr<RmlElement_IsVisibleDelegate>(funcTable, 5664161720531195301UL, RmlElement_IsVisibleFallback);
            RmlElement_QuerySelector = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint>) GetUnmanagedPtr<RmlElement_QuerySelectorDelegate>(funcTable, 17064022902486360431UL, RmlElement_QuerySelectorFallback);
            RmlElement_QuerySelectorAll = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void>) GetUnmanagedPtr<RmlElement_QuerySelectorAllDelegate>(funcTable, 4516995876570774730UL, RmlElement_QuerySelectorAllFallback);
            RmlElement_RemoveAttribute = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) GetUnmanagedPtr<RmlElement_RemoveAttributeDelegate>(funcTable, 2295473148079782678UL, RmlElement_RemoveAttributeFallback);
            RmlElement_RemoveChild = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<RmlElement_RemoveChildDelegate>(funcTable, 14657499505158151392UL, RmlElement_RemoveChildFallback);
            RmlElement_RemoveClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) GetUnmanagedPtr<RmlElement_RemoveClassDelegate>(funcTable, 16647214568333197574UL, RmlElement_RemoveClassFallback);
            RmlElement_RemoveProperty = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<RmlElement_RemovePropertyDelegate>(funcTable, 11285298952870955085UL, RmlElement_RemovePropertyFallback);
            RmlElement_RemovePseudoClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) GetUnmanagedPtr<RmlElement_RemovePseudoClassDelegate>(funcTable, 3288811469534978852UL, RmlElement_RemovePseudoClassFallback);
            RmlElement_ReplaceChild = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<RmlElement_ReplaceChildDelegate>(funcTable, 8859753723526739098UL, RmlElement_ReplaceChildFallback);
            RmlElement_ScrollIntoView = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte, void>) GetUnmanagedPtr<RmlElement_ScrollIntoViewDelegate>(funcTable, 9747040310019678598UL, RmlElement_ScrollIntoViewFallback);
            RmlElement_SetAttribute = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint, void>) GetUnmanagedPtr<RmlElement_SetAttributeDelegate>(funcTable, 9715739411149823680UL, RmlElement_SetAttributeFallback);
            RmlElement_SetId = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void>) GetUnmanagedPtr<RmlElement_SetIdDelegate>(funcTable, 7350120607458974702UL, RmlElement_SetIdFallback);
            RmlElement_SetInnerRml = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<RmlElement_SetInnerRmlDelegate>(funcTable, 14124113203556569364UL, RmlElement_SetInnerRmlFallback);
            RmlElement_SetOffset = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, Vector2, byte, void>) GetUnmanagedPtr<RmlElement_SetOffsetDelegate>(funcTable, 17706736457461964530UL, RmlElement_SetOffsetFallback);
            RmlElement_SetProperty = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<RmlElement_SetPropertyDelegate>(funcTable, 909974105310409725UL, RmlElement_SetPropertyFallback);
            RmlElement_SetScrollLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float, void>) GetUnmanagedPtr<RmlElement_SetScrollLeftDelegate>(funcTable, 6756114124150098233UL, RmlElement_SetScrollLeftFallback);
            RmlElement_SetScrollTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float, void>) GetUnmanagedPtr<RmlElement_SetScrollTopDelegate>(funcTable, 14066701879635486595UL, RmlElement_SetScrollTopFallback);
            TextLabel_GetRemoteID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<TextLabel_GetRemoteIDDelegate>(funcTable, 6875066532735329283UL, TextLabel_GetRemoteIDFallback);
            TextLabel_IsRemote = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<TextLabel_IsRemoteDelegate>(funcTable, 11338052500504691613UL, TextLabel_IsRemoteFallback);
            Vehicle_GetAbsLightState = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetAbsLightStateDelegate>(funcTable, 8108528114312743590UL, Vehicle_GetAbsLightStateFallback);
            Vehicle_GetBatteryLightState = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetBatteryLightStateDelegate>(funcTable, 3961634604730468941UL, Vehicle_GetBatteryLightStateFallback);
            Vehicle_GetCurrentGear = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Vehicle_GetCurrentGearDelegate>(funcTable, 940949709699448452UL, Vehicle_GetCurrentGearFallback);
            Vehicle_GetCurrentRPM = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_GetCurrentRPMDelegate>(funcTable, 17697023829474700250UL, Vehicle_GetCurrentRPMFallback);
            Vehicle_GetEngineLightState = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetEngineLightStateDelegate>(funcTable, 4800919791480938200UL, Vehicle_GetEngineLightStateFallback);
            Vehicle_GetEngineTemperature = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_GetEngineTemperatureDelegate>(funcTable, 14902444857320523076UL, Vehicle_GetEngineTemperatureFallback);
            Vehicle_GetFuelLevel = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_GetFuelLevelDelegate>(funcTable, 6319189367492429230UL, Vehicle_GetFuelLevelFallback);
            Vehicle_GetLightsIndicator = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetLightsIndicatorDelegate>(funcTable, 5449705498281195827UL, Vehicle_GetLightsIndicatorFallback);
            Vehicle_GetMaxGear = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<Vehicle_GetMaxGearDelegate>(funcTable, 2653946512437825487UL, Vehicle_GetMaxGearFallback);
            Vehicle_GetOccupiedSeatsCount = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetOccupiedSeatsCountDelegate>(funcTable, 13154968843890943206UL, Vehicle_GetOccupiedSeatsCountFallback);
            Vehicle_GetOilLevel = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_GetOilLevelDelegate>(funcTable, 18315887447397721786UL, Vehicle_GetOilLevelFallback);
            Vehicle_GetOilLightState = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetOilLightStateDelegate>(funcTable, 8681931137170346790UL, Vehicle_GetOilLightStateFallback);
            Vehicle_GetPetrolLightState = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetPetrolLightStateDelegate>(funcTable, 16925568246751944168UL, Vehicle_GetPetrolLightStateFallback);
            Vehicle_GetSeatCount = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_GetSeatCountDelegate>(funcTable, 9710490073882806517UL, Vehicle_GetSeatCountFallback);
            Vehicle_GetSpeedVector = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) GetUnmanagedPtr<Vehicle_GetSpeedVectorDelegate>(funcTable, 9716002269308828916UL, Vehicle_GetSpeedVectorFallback);
            Vehicle_GetWheelCamber = (delegate* unmanaged[Cdecl]<nint, byte, float>) GetUnmanagedPtr<Vehicle_GetWheelCamberDelegate>(funcTable, 13303370691287708161UL, Vehicle_GetWheelCamberFallback);
            Vehicle_GetWheelHeight = (delegate* unmanaged[Cdecl]<nint, byte, float>) GetUnmanagedPtr<Vehicle_GetWheelHeightDelegate>(funcTable, 1338791052731372072UL, Vehicle_GetWheelHeightFallback);
            Vehicle_GetWheelRimRadius = (delegate* unmanaged[Cdecl]<nint, byte, float>) GetUnmanagedPtr<Vehicle_GetWheelRimRadiusDelegate>(funcTable, 13382865868223894905UL, Vehicle_GetWheelRimRadiusFallback);
            Vehicle_GetWheelSpeed = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_GetWheelSpeedDelegate>(funcTable, 13422594452494959622UL, Vehicle_GetWheelSpeedFallback);
            Vehicle_GetWheelSurfaceMaterial = (delegate* unmanaged[Cdecl]<nint, byte, uint>) GetUnmanagedPtr<Vehicle_GetWheelSurfaceMaterialDelegate>(funcTable, 1528473557310374151UL, Vehicle_GetWheelSurfaceMaterialFallback);
            Vehicle_GetWheelTrackWidth = (delegate* unmanaged[Cdecl]<nint, byte, float>) GetUnmanagedPtr<Vehicle_GetWheelTrackWidthDelegate>(funcTable, 491499874893114118UL, Vehicle_GetWheelTrackWidthFallback);
            Vehicle_GetWheelTyreRadius = (delegate* unmanaged[Cdecl]<nint, byte, float>) GetUnmanagedPtr<Vehicle_GetWheelTyreRadiusDelegate>(funcTable, 4686947598406478597UL, Vehicle_GetWheelTyreRadiusFallback);
            Vehicle_GetWheelTyreWidth = (delegate* unmanaged[Cdecl]<nint, byte, float>) GetUnmanagedPtr<Vehicle_GetWheelTyreWidthDelegate>(funcTable, 10175809585401109345UL, Vehicle_GetWheelTyreWidthFallback);
            Vehicle_Handling_GetAcceleration = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetAccelerationDelegate>(funcTable, 10078299693896381022UL, Vehicle_Handling_GetAccelerationFallback);
            Vehicle_Handling_GetAntiRollBarBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetAntiRollBarBiasFrontDelegate>(funcTable, 2075764309745505478UL, Vehicle_Handling_GetAntiRollBarBiasFrontFallback);
            Vehicle_Handling_GetAntiRollBarBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetAntiRollBarBiasRearDelegate>(funcTable, 5876755422566029523UL, Vehicle_Handling_GetAntiRollBarBiasRearFallback);
            Vehicle_Handling_GetAntiRollBarForce = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetAntiRollBarForceDelegate>(funcTable, 16400280465546780439UL, Vehicle_Handling_GetAntiRollBarForceFallback);
            Vehicle_Handling_GetBrakeBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetBrakeBiasFrontDelegate>(funcTable, 16036331434020158573UL, Vehicle_Handling_GetBrakeBiasFrontFallback);
            Vehicle_Handling_GetBrakeBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetBrakeBiasRearDelegate>(funcTable, 11815864316444209286UL, Vehicle_Handling_GetBrakeBiasRearFallback);
            Vehicle_Handling_GetBrakeForce = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetBrakeForceDelegate>(funcTable, 9123059872480092544UL, Vehicle_Handling_GetBrakeForceFallback);
            Vehicle_Handling_GetCamberStiffness = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetCamberStiffnessDelegate>(funcTable, 13706415439184921653UL, Vehicle_Handling_GetCamberStiffnessFallback);
            Vehicle_Handling_GetCentreOfMassOffset = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) GetUnmanagedPtr<Vehicle_Handling_GetCentreOfMassOffsetDelegate>(funcTable, 544626726408311105UL, Vehicle_Handling_GetCentreOfMassOffsetFallback);
            Vehicle_Handling_GetClutchChangeRateScaleDownShift = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetClutchChangeRateScaleDownShiftDelegate>(funcTable, 17823698664766581057UL, Vehicle_Handling_GetClutchChangeRateScaleDownShiftFallback);
            Vehicle_Handling_GetClutchChangeRateScaleUpShift = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetClutchChangeRateScaleUpShiftDelegate>(funcTable, 1847766962336073256UL, Vehicle_Handling_GetClutchChangeRateScaleUpShiftFallback);
            Vehicle_Handling_GetCollisionDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetCollisionDamageMultDelegate>(funcTable, 3640187002251451195UL, Vehicle_Handling_GetCollisionDamageMultFallback);
            Vehicle_Handling_GetDamageFlags = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Vehicle_Handling_GetDamageFlagsDelegate>(funcTable, 15724336201653917130UL, Vehicle_Handling_GetDamageFlagsFallback);
            Vehicle_Handling_GetDeformationDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetDeformationDamageMultDelegate>(funcTable, 4224890290177597729UL, Vehicle_Handling_GetDeformationDamageMultFallback);
            Vehicle_Handling_GetDownforceModifier = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetDownforceModifierDelegate>(funcTable, 8794621706814880064UL, Vehicle_Handling_GetDownforceModifierFallback);
            Vehicle_Handling_GetDriveBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetDriveBiasFrontDelegate>(funcTable, 10514767894163983614UL, Vehicle_Handling_GetDriveBiasFrontFallback);
            Vehicle_Handling_GetDriveInertia = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetDriveInertiaDelegate>(funcTable, 13091197092896554364UL, Vehicle_Handling_GetDriveInertiaFallback);
            Vehicle_Handling_GetDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetDriveMaxFlatVelDelegate>(funcTable, 17653040055654987534UL, Vehicle_Handling_GetDriveMaxFlatVelFallback);
            Vehicle_Handling_GetEngineDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetEngineDamageMultDelegate>(funcTable, 13123198670756185941UL, Vehicle_Handling_GetEngineDamageMultFallback);
            Vehicle_Handling_GetHandBrakeForce = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetHandBrakeForceDelegate>(funcTable, 15071042556745097419UL, Vehicle_Handling_GetHandBrakeForceFallback);
            Vehicle_Handling_GetHandlingFlags = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Vehicle_Handling_GetHandlingFlagsDelegate>(funcTable, 15712800079613684274UL, Vehicle_Handling_GetHandlingFlagsFallback);
            Vehicle_Handling_GetHandlingNameHash = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Vehicle_Handling_GetHandlingNameHashDelegate>(funcTable, 9056058048184508796UL, Vehicle_Handling_GetHandlingNameHashFallback);
            Vehicle_Handling_GetInertiaMultiplier = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) GetUnmanagedPtr<Vehicle_Handling_GetInertiaMultiplierDelegate>(funcTable, 374180732922095341UL, Vehicle_Handling_GetInertiaMultiplierFallback);
            Vehicle_Handling_GetInitialDragCoeff = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetInitialDragCoeffDelegate>(funcTable, 6069506253388365935UL, Vehicle_Handling_GetInitialDragCoeffFallback);
            Vehicle_Handling_GetInitialDriveForce = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetInitialDriveForceDelegate>(funcTable, 14207124342130964195UL, Vehicle_Handling_GetInitialDriveForceFallback);
            Vehicle_Handling_GetInitialDriveGears = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Vehicle_Handling_GetInitialDriveGearsDelegate>(funcTable, 7988604432980063790UL, Vehicle_Handling_GetInitialDriveGearsFallback);
            Vehicle_Handling_GetInitialDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetInitialDriveMaxFlatVelDelegate>(funcTable, 1869896813051298938UL, Vehicle_Handling_GetInitialDriveMaxFlatVelFallback);
            Vehicle_Handling_GetLowSpeedTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetLowSpeedTractionLossMultDelegate>(funcTable, 12245703430179167058UL, Vehicle_Handling_GetLowSpeedTractionLossMultFallback);
            Vehicle_Handling_GetMass = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetMassDelegate>(funcTable, 6108107448568242326UL, Vehicle_Handling_GetMassFallback);
            Vehicle_Handling_GetModelFlags = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Vehicle_Handling_GetModelFlagsDelegate>(funcTable, 4933176887065087610UL, Vehicle_Handling_GetModelFlagsFallback);
            Vehicle_Handling_GetMonetaryValue = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<Vehicle_Handling_GetMonetaryValueDelegate>(funcTable, 6663124450615589926UL, Vehicle_Handling_GetMonetaryValueFallback);
            Vehicle_Handling_GetOilVolume = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetOilVolumeDelegate>(funcTable, 17728911957820472960UL, Vehicle_Handling_GetOilVolumeFallback);
            Vehicle_Handling_GetPercentSubmerged = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetPercentSubmergedDelegate>(funcTable, 10907127174707713317UL, Vehicle_Handling_GetPercentSubmergedFallback);
            Vehicle_Handling_GetPercentSubmergedRatio = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetPercentSubmergedRatioDelegate>(funcTable, 4328061774659836762UL, Vehicle_Handling_GetPercentSubmergedRatioFallback);
            Vehicle_Handling_GetPetrolTankVolume = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetPetrolTankVolumeDelegate>(funcTable, 6982194366825608730UL, Vehicle_Handling_GetPetrolTankVolumeFallback);
            Vehicle_Handling_GetRollCentreHeightFront = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetRollCentreHeightFrontDelegate>(funcTable, 14426028478326537196UL, Vehicle_Handling_GetRollCentreHeightFrontFallback);
            Vehicle_Handling_GetRollCentreHeightRear = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetRollCentreHeightRearDelegate>(funcTable, 7815129605583621589UL, Vehicle_Handling_GetRollCentreHeightRearFallback);
            Vehicle_Handling_GetSeatOffsetDistX = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetSeatOffsetDistXDelegate>(funcTable, 1825976306734658816UL, Vehicle_Handling_GetSeatOffsetDistXFallback);
            Vehicle_Handling_GetSeatOffsetDistY = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetSeatOffsetDistYDelegate>(funcTable, 7378855169663253137UL, Vehicle_Handling_GetSeatOffsetDistYFallback);
            Vehicle_Handling_GetSeatOffsetDistZ = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetSeatOffsetDistZDelegate>(funcTable, 15048519683235294830UL, Vehicle_Handling_GetSeatOffsetDistZFallback);
            Vehicle_Handling_GetSteeringLock = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetSteeringLockDelegate>(funcTable, 15159407727398897994UL, Vehicle_Handling_GetSteeringLockFallback);
            Vehicle_Handling_GetSteeringLockRatio = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetSteeringLockRatioDelegate>(funcTable, 13507421085391188727UL, Vehicle_Handling_GetSteeringLockRatioFallback);
            Vehicle_Handling_GetSuspensionBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetSuspensionBiasFrontDelegate>(funcTable, 15563431338634229199UL, Vehicle_Handling_GetSuspensionBiasFrontFallback);
            Vehicle_Handling_GetSuspensionBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetSuspensionBiasRearDelegate>(funcTable, 7154917036451016252UL, Vehicle_Handling_GetSuspensionBiasRearFallback);
            Vehicle_Handling_GetSuspensionCompDamp = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetSuspensionCompDampDelegate>(funcTable, 3573911048335423790UL, Vehicle_Handling_GetSuspensionCompDampFallback);
            Vehicle_Handling_GetSuspensionForce = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetSuspensionForceDelegate>(funcTable, 12271198816022057866UL, Vehicle_Handling_GetSuspensionForceFallback);
            Vehicle_Handling_GetSuspensionLowerLimit = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetSuspensionLowerLimitDelegate>(funcTable, 4961536539817484733UL, Vehicle_Handling_GetSuspensionLowerLimitFallback);
            Vehicle_Handling_GetSuspensionRaise = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetSuspensionRaiseDelegate>(funcTable, 14436023266494160439UL, Vehicle_Handling_GetSuspensionRaiseFallback);
            Vehicle_Handling_GetSuspensionReboundDamp = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetSuspensionReboundDampDelegate>(funcTable, 2586446577883056672UL, Vehicle_Handling_GetSuspensionReboundDampFallback);
            Vehicle_Handling_GetSuspensionUpperLimit = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetSuspensionUpperLimitDelegate>(funcTable, 2718011031566821432UL, Vehicle_Handling_GetSuspensionUpperLimitFallback);
            Vehicle_Handling_GetTractionBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetTractionBiasFrontDelegate>(funcTable, 14106527674446349874UL, Vehicle_Handling_GetTractionBiasFrontFallback);
            Vehicle_Handling_GetTractionBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetTractionBiasRearDelegate>(funcTable, 17296437853927048671UL, Vehicle_Handling_GetTractionBiasRearFallback);
            Vehicle_Handling_GetTractionCurveLateral = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetTractionCurveLateralDelegate>(funcTable, 1653686489521659456UL, Vehicle_Handling_GetTractionCurveLateralFallback);
            Vehicle_Handling_GetTractionCurveLateralRatio = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetTractionCurveLateralRatioDelegate>(funcTable, 3343113090641609713UL, Vehicle_Handling_GetTractionCurveLateralRatioFallback);
            Vehicle_Handling_GetTractionCurveMax = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetTractionCurveMaxDelegate>(funcTable, 7785419357218432267UL, Vehicle_Handling_GetTractionCurveMaxFallback);
            Vehicle_Handling_GetTractionCurveMaxRatio = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetTractionCurveMaxRatioDelegate>(funcTable, 18254558197957842428UL, Vehicle_Handling_GetTractionCurveMaxRatioFallback);
            Vehicle_Handling_GetTractionCurveMin = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetTractionCurveMinDelegate>(funcTable, 17588571315194933945UL, Vehicle_Handling_GetTractionCurveMinFallback);
            Vehicle_Handling_GetTractionCurveMinRatio = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetTractionCurveMinRatioDelegate>(funcTable, 2364488402618009974UL, Vehicle_Handling_GetTractionCurveMinRatioFallback);
            Vehicle_Handling_GetTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetTractionLossMultDelegate>(funcTable, 14744673056818120329UL, Vehicle_Handling_GetTractionLossMultFallback);
            Vehicle_Handling_GetTractionSpringDeltaMax = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetTractionSpringDeltaMaxDelegate>(funcTable, 13815466131879173121UL, Vehicle_Handling_GetTractionSpringDeltaMaxFallback);
            Vehicle_Handling_GetTractionSpringDeltaMaxRatio = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetTractionSpringDeltaMaxRatioDelegate>(funcTable, 13575487466046163342UL, Vehicle_Handling_GetTractionSpringDeltaMaxRatioFallback);
            Vehicle_Handling_GetunkFloat1 = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetunkFloat1Delegate>(funcTable, 12743699742158836921UL, Vehicle_Handling_GetunkFloat1Fallback);
            Vehicle_Handling_GetunkFloat2 = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetunkFloat2Delegate>(funcTable, 10423513342346289878UL, Vehicle_Handling_GetunkFloat2Fallback);
            Vehicle_Handling_GetunkFloat4 = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetunkFloat4Delegate>(funcTable, 11893830950833771180UL, Vehicle_Handling_GetunkFloat4Fallback);
            Vehicle_Handling_GetunkFloat5 = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetunkFloat5Delegate>(funcTable, 7652662052385596845UL, Vehicle_Handling_GetunkFloat5Fallback);
            Vehicle_Handling_GetWeaponDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) GetUnmanagedPtr<Vehicle_Handling_GetWeaponDamageMultDelegate>(funcTable, 11922787843029535275UL, Vehicle_Handling_GetWeaponDamageMultFallback);
            Vehicle_Handling_SetAcceleration = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetAccelerationDelegate>(funcTable, 18029758670461994365UL, Vehicle_Handling_SetAccelerationFallback);
            Vehicle_Handling_SetAntiRollBarBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetAntiRollBarBiasFrontDelegate>(funcTable, 17130103214803834989UL, Vehicle_Handling_SetAntiRollBarBiasFrontFallback);
            Vehicle_Handling_SetAntiRollBarBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetAntiRollBarBiasRearDelegate>(funcTable, 2692497708077112726UL, Vehicle_Handling_SetAntiRollBarBiasRearFallback);
            Vehicle_Handling_SetAntiRollBarForce = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetAntiRollBarForceDelegate>(funcTable, 18369044924651600610UL, Vehicle_Handling_SetAntiRollBarForceFallback);
            Vehicle_Handling_SetBrakeBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetBrakeBiasFrontDelegate>(funcTable, 10582912406802465936UL, Vehicle_Handling_SetBrakeBiasFrontFallback);
            Vehicle_Handling_SetBrakeBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetBrakeBiasRearDelegate>(funcTable, 5096516830878001661UL, Vehicle_Handling_SetBrakeBiasRearFallback);
            Vehicle_Handling_SetBrakeForce = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetBrakeForceDelegate>(funcTable, 15871848644311504543UL, Vehicle_Handling_SetBrakeForceFallback);
            Vehicle_Handling_SetCamberStiffness = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetCamberStiffnessDelegate>(funcTable, 12400001208957853600UL, Vehicle_Handling_SetCamberStiffnessFallback);
            Vehicle_Handling_SetCentreOfMassOffset = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) GetUnmanagedPtr<Vehicle_Handling_SetCentreOfMassOffsetDelegate>(funcTable, 17994040563171180043UL, Vehicle_Handling_SetCentreOfMassOffsetFallback);
            Vehicle_Handling_SetClutchChangeRateScaleDownShift = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetClutchChangeRateScaleDownShiftDelegate>(funcTable, 10096237319592134284UL, Vehicle_Handling_SetClutchChangeRateScaleDownShiftFallback);
            Vehicle_Handling_SetClutchChangeRateScaleUpShift = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetClutchChangeRateScaleUpShiftDelegate>(funcTable, 13111595691801697903UL, Vehicle_Handling_SetClutchChangeRateScaleUpShiftFallback);
            Vehicle_Handling_SetCollisionDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetCollisionDamageMultDelegate>(funcTable, 6438939762459316822UL, Vehicle_Handling_SetCollisionDamageMultFallback);
            Vehicle_Handling_SetDamageFlags = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Vehicle_Handling_SetDamageFlagsDelegate>(funcTable, 3908725796662714889UL, Vehicle_Handling_SetDamageFlagsFallback);
            Vehicle_Handling_SetDeformationDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetDeformationDamageMultDelegate>(funcTable, 3715895871076668228UL, Vehicle_Handling_SetDeformationDamageMultFallback);
            Vehicle_Handling_SetDownforceModifier = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetDownforceModifierDelegate>(funcTable, 14978721618745882503UL, Vehicle_Handling_SetDownforceModifierFallback);
            Vehicle_Handling_SetDriveBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetDriveBiasFrontDelegate>(funcTable, 15668539880874518677UL, Vehicle_Handling_SetDriveBiasFrontFallback);
            Vehicle_Handling_SetDriveInertia = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetDriveInertiaDelegate>(funcTable, 10019280768018311739UL, Vehicle_Handling_SetDriveInertiaFallback);
            Vehicle_Handling_SetDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetDriveMaxFlatVelDelegate>(funcTable, 1702635411438007893UL, Vehicle_Handling_SetDriveMaxFlatVelFallback);
            Vehicle_Handling_SetEngineDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetEngineDamageMultDelegate>(funcTable, 17302007799028099256UL, Vehicle_Handling_SetEngineDamageMultFallback);
            Vehicle_Handling_SetHandBrakeForce = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetHandBrakeForceDelegate>(funcTable, 12276253478525626262UL, Vehicle_Handling_SetHandBrakeForceFallback);
            Vehicle_Handling_SetHandlingFlags = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Vehicle_Handling_SetHandlingFlagsDelegate>(funcTable, 4597845088196659657UL, Vehicle_Handling_SetHandlingFlagsFallback);
            Vehicle_Handling_SetInertiaMultiplier = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) GetUnmanagedPtr<Vehicle_Handling_SetInertiaMultiplierDelegate>(funcTable, 2157682978198906103UL, Vehicle_Handling_SetInertiaMultiplierFallback);
            Vehicle_Handling_SetInitialDragCoeff = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetInitialDragCoeffDelegate>(funcTable, 15532896665185257570UL, Vehicle_Handling_SetInitialDragCoeffFallback);
            Vehicle_Handling_SetInitialDriveForce = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetInitialDriveForceDelegate>(funcTable, 18270808580206557790UL, Vehicle_Handling_SetInitialDriveForceFallback);
            Vehicle_Handling_SetInitialDriveGears = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Vehicle_Handling_SetInitialDriveGearsDelegate>(funcTable, 2325663906168656981UL, Vehicle_Handling_SetInitialDriveGearsFallback);
            Vehicle_Handling_SetInitialDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetInitialDriveMaxFlatVelDelegate>(funcTable, 4721735489012961441UL, Vehicle_Handling_SetInitialDriveMaxFlatVelFallback);
            Vehicle_Handling_SetLowSpeedTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetLowSpeedTractionLossMultDelegate>(funcTable, 1596211192320289009UL, Vehicle_Handling_SetLowSpeedTractionLossMultFallback);
            Vehicle_Handling_SetMass = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetMassDelegate>(funcTable, 15366979755955923021UL, Vehicle_Handling_SetMassFallback);
            Vehicle_Handling_SetModelFlags = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Vehicle_Handling_SetModelFlagsDelegate>(funcTable, 8268986722826371337UL, Vehicle_Handling_SetModelFlagsFallback);
            Vehicle_Handling_SetMonetaryValue = (delegate* unmanaged[Cdecl]<nint, uint, void>) GetUnmanagedPtr<Vehicle_Handling_SetMonetaryValueDelegate>(funcTable, 7656294773977229045UL, Vehicle_Handling_SetMonetaryValueFallback);
            Vehicle_Handling_SetOilVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetOilVolumeDelegate>(funcTable, 12136538940531187671UL, Vehicle_Handling_SetOilVolumeFallback);
            Vehicle_Handling_SetPercentSubmerged = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetPercentSubmergedDelegate>(funcTable, 14971386103610270736UL, Vehicle_Handling_SetPercentSubmergedFallback);
            Vehicle_Handling_SetPercentSubmergedRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetPercentSubmergedRatioDelegate>(funcTable, 15496690316921237057UL, Vehicle_Handling_SetPercentSubmergedRatioFallback);
            Vehicle_Handling_SetPetrolTankVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetPetrolTankVolumeDelegate>(funcTable, 17920045702689580089UL, Vehicle_Handling_SetPetrolTankVolumeFallback);
            Vehicle_Handling_SetRollCentreHeightFront = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetRollCentreHeightFrontDelegate>(funcTable, 191200897835472739UL, Vehicle_Handling_SetRollCentreHeightFrontFallback);
            Vehicle_Handling_SetRollCentreHeightRear = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetRollCentreHeightRearDelegate>(funcTable, 2584973866369014424UL, Vehicle_Handling_SetRollCentreHeightRearFallback);
            Vehicle_Handling_SetSeatOffsetDistX = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetSeatOffsetDistXDelegate>(funcTable, 11337807014342450303UL, Vehicle_Handling_SetSeatOffsetDistXFallback);
            Vehicle_Handling_SetSeatOffsetDistY = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetSeatOffsetDistYDelegate>(funcTable, 15894164694500761500UL, Vehicle_Handling_SetSeatOffsetDistYFallback);
            Vehicle_Handling_SetSeatOffsetDistZ = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetSeatOffsetDistZDelegate>(funcTable, 4632458476507794509UL, Vehicle_Handling_SetSeatOffsetDistZFallback);
            Vehicle_Handling_SetSteeringLock = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetSteeringLockDelegate>(funcTable, 6250520021083522785UL, Vehicle_Handling_SetSteeringLockFallback);
            Vehicle_Handling_SetSteeringLockRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetSteeringLockRatioDelegate>(funcTable, 6937651752435158290UL, Vehicle_Handling_SetSteeringLockRatioFallback);
            Vehicle_Handling_SetSuspensionBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetSuspensionBiasFrontDelegate>(funcTable, 18290438802755583722UL, Vehicle_Handling_SetSuspensionBiasFrontFallback);
            Vehicle_Handling_SetSuspensionBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetSuspensionBiasRearDelegate>(funcTable, 4312208500846030555UL, Vehicle_Handling_SetSuspensionBiasRearFallback);
            Vehicle_Handling_SetSuspensionCompDamp = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetSuspensionCompDampDelegate>(funcTable, 11059815704258404773UL, Vehicle_Handling_SetSuspensionCompDampFallback);
            Vehicle_Handling_SetSuspensionForce = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetSuspensionForceDelegate>(funcTable, 6634472175858969265UL, Vehicle_Handling_SetSuspensionForceFallback);
            Vehicle_Handling_SetSuspensionLowerLimit = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetSuspensionLowerLimitDelegate>(funcTable, 6634371299852484728UL, Vehicle_Handling_SetSuspensionLowerLimitFallback);
            Vehicle_Handling_SetSuspensionRaise = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetSuspensionRaiseDelegate>(funcTable, 11035317218716750346UL, Vehicle_Handling_SetSuspensionRaiseFallback);
            Vehicle_Handling_SetSuspensionReboundDamp = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetSuspensionReboundDampDelegate>(funcTable, 11919899368398657543UL, Vehicle_Handling_SetSuspensionReboundDampFallback);
            Vehicle_Handling_SetSuspensionUpperLimit = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetSuspensionUpperLimitDelegate>(funcTable, 2974358477257940935UL, Vehicle_Handling_SetSuspensionUpperLimitFallback);
            Vehicle_Handling_SetTractionBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetTractionBiasFrontDelegate>(funcTable, 9161433281435000857UL, Vehicle_Handling_SetTractionBiasFrontFallback);
            Vehicle_Handling_SetTractionBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetTractionBiasRearDelegate>(funcTable, 1803398808846216418UL, Vehicle_Handling_SetTractionBiasRearFallback);
            Vehicle_Handling_SetTractionCurveLateral = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetTractionCurveLateralDelegate>(funcTable, 1604394664419303831UL, Vehicle_Handling_SetTractionCurveLateralFallback);
            Vehicle_Handling_SetTractionCurveLateralRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetTractionCurveLateralRatioDelegate>(funcTable, 14846767552647138156UL, Vehicle_Handling_SetTractionCurveLateralRatioFallback);
            Vehicle_Handling_SetTractionCurveMax = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetTractionCurveMaxDelegate>(funcTable, 17607728305469459926UL, Vehicle_Handling_SetTractionCurveMaxFallback);
            Vehicle_Handling_SetTractionCurveMaxRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetTractionCurveMaxRatioDelegate>(funcTable, 5678242342192068675UL, Vehicle_Handling_SetTractionCurveMaxRatioFallback);
            Vehicle_Handling_SetTractionCurveMin = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetTractionCurveMinDelegate>(funcTable, 17856754155531892556UL, Vehicle_Handling_SetTractionCurveMinFallback);
            Vehicle_Handling_SetTractionCurveMinRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetTractionCurveMinRatioDelegate>(funcTable, 8350236606338904165UL, Vehicle_Handling_SetTractionCurveMinRatioFallback);
            Vehicle_Handling_SetTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetTractionLossMultDelegate>(funcTable, 11393576321966669636UL, Vehicle_Handling_SetTractionLossMultFallback);
            Vehicle_Handling_SetTractionSpringDeltaMax = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetTractionSpringDeltaMaxDelegate>(funcTable, 7604256083538583668UL, Vehicle_Handling_SetTractionSpringDeltaMaxFallback);
            Vehicle_Handling_SetTractionSpringDeltaMaxRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetTractionSpringDeltaMaxRatioDelegate>(funcTable, 12403140303173876253UL, Vehicle_Handling_SetTractionSpringDeltaMaxRatioFallback);
            Vehicle_Handling_SetunkFloat1 = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetunkFloat1Delegate>(funcTable, 10206269865034437676UL, Vehicle_Handling_SetunkFloat1Fallback);
            Vehicle_Handling_SetunkFloat2 = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetunkFloat2Delegate>(funcTable, 3080507646262582877UL, Vehicle_Handling_SetunkFloat2Fallback);
            Vehicle_Handling_SetunkFloat4 = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetunkFloat4Delegate>(funcTable, 7252291121552322267UL, Vehicle_Handling_SetunkFloat4Fallback);
            Vehicle_Handling_SetunkFloat5 = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetunkFloat5Delegate>(funcTable, 7118045643471075160UL, Vehicle_Handling_SetunkFloat5Fallback);
            Vehicle_Handling_SetWeaponDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_Handling_SetWeaponDamageMultDelegate>(funcTable, 12755205586862478630UL, Vehicle_Handling_SetWeaponDamageMultFallback);
            Vehicle_IsHandlingModified = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsHandlingModifiedDelegate>(funcTable, 7839453310356146623UL, Vehicle_IsHandlingModifiedFallback);
            Vehicle_IsTaxiLightOn = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<Vehicle_IsTaxiLightOnDelegate>(funcTable, 4756907206915806650UL, Vehicle_IsTaxiLightOnFallback);
            Vehicle_ResetDashboardLights = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Vehicle_ResetDashboardLightsDelegate>(funcTable, 2579542930706467116UL, Vehicle_ResetDashboardLightsFallback);
            Vehicle_ResetHandling = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<Vehicle_ResetHandlingDelegate>(funcTable, 16908138174351619522UL, Vehicle_ResetHandlingFallback);
            Vehicle_SetAbsLightState = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetAbsLightStateDelegate>(funcTable, 4563279063364526693UL, Vehicle_SetAbsLightStateFallback);
            Vehicle_SetBatteryLightState = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetBatteryLightStateDelegate>(funcTable, 2853437131811490624UL, Vehicle_SetBatteryLightStateFallback);
            Vehicle_SetCurrentGear = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Vehicle_SetCurrentGearDelegate>(funcTable, 12232454538624166963UL, Vehicle_SetCurrentGearFallback);
            Vehicle_SetCurrentRPM = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_SetCurrentRPMDelegate>(funcTable, 13116174141655747505UL, Vehicle_SetCurrentRPMFallback);
            Vehicle_SetEngineLightState = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetEngineLightStateDelegate>(funcTable, 15206512772388781191UL, Vehicle_SetEngineLightStateFallback);
            Vehicle_SetEngineTemperature = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_SetEngineTemperatureDelegate>(funcTable, 347347259026240651UL, Vehicle_SetEngineTemperatureFallback);
            Vehicle_SetFuelLevel = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_SetFuelLevelDelegate>(funcTable, 1181039797416690365UL, Vehicle_SetFuelLevelFallback);
            Vehicle_SetLightsIndicator = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetLightsIndicatorDelegate>(funcTable, 12348151689393422822UL, Vehicle_SetLightsIndicatorFallback);
            Vehicle_SetMaxGear = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<Vehicle_SetMaxGearDelegate>(funcTable, 4269579782367060642UL, Vehicle_SetMaxGearFallback);
            Vehicle_SetOilLevel = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<Vehicle_SetOilLevelDelegate>(funcTable, 5809609101227239569UL, Vehicle_SetOilLevelFallback);
            Vehicle_SetOilLightState = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetOilLightStateDelegate>(funcTable, 17937666064672185253UL, Vehicle_SetOilLightStateFallback);
            Vehicle_SetPetrolLightState = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_SetPetrolLightStateDelegate>(funcTable, 2675407408828596847UL, Vehicle_SetPetrolLightStateFallback);
            Vehicle_SetWheelCamber = (delegate* unmanaged[Cdecl]<nint, byte, float, void>) GetUnmanagedPtr<Vehicle_SetWheelCamberDelegate>(funcTable, 10533830814607560700UL, Vehicle_SetWheelCamberFallback);
            Vehicle_SetWheelHeight = (delegate* unmanaged[Cdecl]<nint, byte, float, void>) GetUnmanagedPtr<Vehicle_SetWheelHeightDelegate>(funcTable, 14037400183140364255UL, Vehicle_SetWheelHeightFallback);
            Vehicle_SetWheelRimRadius = (delegate* unmanaged[Cdecl]<nint, byte, float, void>) GetUnmanagedPtr<Vehicle_SetWheelRimRadiusDelegate>(funcTable, 3095801372631152772UL, Vehicle_SetWheelRimRadiusFallback);
            Vehicle_SetWheelTrackWidth = (delegate* unmanaged[Cdecl]<nint, byte, float, void>) GetUnmanagedPtr<Vehicle_SetWheelTrackWidthDelegate>(funcTable, 2293924763385881861UL, Vehicle_SetWheelTrackWidthFallback);
            Vehicle_SetWheelTyreRadius = (delegate* unmanaged[Cdecl]<nint, byte, float, void>) GetUnmanagedPtr<Vehicle_SetWheelTyreRadiusDelegate>(funcTable, 16643704314243471312UL, Vehicle_SetWheelTyreRadiusFallback);
            Vehicle_SetWheelTyreWidth = (delegate* unmanaged[Cdecl]<nint, byte, float, void>) GetUnmanagedPtr<Vehicle_SetWheelTyreWidthDelegate>(funcTable, 1387113924672541868UL, Vehicle_SetWheelTyreWidthFallback);
            Vehicle_ToggleTaxiLight = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<Vehicle_ToggleTaxiLightDelegate>(funcTable, 4622127485385870092UL, Vehicle_ToggleTaxiLightFallback);
            VirtualEntity_GetRemoteID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<VirtualEntity_GetRemoteIDDelegate>(funcTable, 6588184116561289319UL, VirtualEntity_GetRemoteIDFallback);
            VirtualEntity_IsRemote = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<VirtualEntity_IsRemoteDelegate>(funcTable, 4187106702657265911UL, VirtualEntity_IsRemoteFallback);
            VirtualEntity_IsStreamedIn = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<VirtualEntity_IsStreamedInDelegate>(funcTable, 2202580267134569763UL, VirtualEntity_IsStreamedInFallback);
            VirtualEntityGroup_GetRemoteID = (delegate* unmanaged[Cdecl]<nint, uint>) GetUnmanagedPtr<VirtualEntityGroup_GetRemoteIDDelegate>(funcTable, 7104309680900591031UL, VirtualEntityGroup_GetRemoteIDFallback);
            VirtualEntityGroup_IsRemote = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<VirtualEntityGroup_IsRemoteDelegate>(funcTable, 1612443214905956487UL, VirtualEntityGroup_IsRemoteFallback);
            WeaponData_GetAccuracySpread = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<WeaponData_GetAccuracySpreadDelegate>(funcTable, 12282797124788259414UL, WeaponData_GetAccuracySpreadFallback);
            WeaponData_GetAnimReloadRate = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<WeaponData_GetAnimReloadRateDelegate>(funcTable, 3872485645449808126UL, WeaponData_GetAnimReloadRateFallback);
            WeaponData_GetClipSize = (delegate* unmanaged[Cdecl]<uint, uint>) GetUnmanagedPtr<WeaponData_GetClipSizeDelegate>(funcTable, 16005079481042718507UL, WeaponData_GetClipSizeFallback);
            WeaponData_GetDamage = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<WeaponData_GetDamageDelegate>(funcTable, 12259856190095492527UL, WeaponData_GetDamageFallback);
            WeaponData_GetHeadshotDamageModifier = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<WeaponData_GetHeadshotDamageModifierDelegate>(funcTable, 9285280070621118862UL, WeaponData_GetHeadshotDamageModifierFallback);
            WeaponData_GetLockOnRange = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<WeaponData_GetLockOnRangeDelegate>(funcTable, 15403499347943624825UL, WeaponData_GetLockOnRangeFallback);
            WeaponData_GetModelHash = (delegate* unmanaged[Cdecl]<uint, uint>) GetUnmanagedPtr<WeaponData_GetModelHashDelegate>(funcTable, 11234559899732648733UL, WeaponData_GetModelHashFallback);
            WeaponData_GetNameHash = (delegate* unmanaged[Cdecl]<uint, uint>) GetUnmanagedPtr<WeaponData_GetNameHashDelegate>(funcTable, 9846369368372041755UL, WeaponData_GetNameHashFallback);
            WeaponData_GetPlayerDamageModifier = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<WeaponData_GetPlayerDamageModifierDelegate>(funcTable, 5418586889827318863UL, WeaponData_GetPlayerDamageModifierFallback);
            WeaponData_GetRange = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<WeaponData_GetRangeDelegate>(funcTable, 11435716851646181823UL, WeaponData_GetRangeFallback);
            WeaponData_GetRecoilAccuracyMax = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<WeaponData_GetRecoilAccuracyMaxDelegate>(funcTable, 15082342643853536041UL, WeaponData_GetRecoilAccuracyMaxFallback);
            WeaponData_GetRecoilAccuracyToAllowHeadshotPlayer = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<WeaponData_GetRecoilAccuracyToAllowHeadshotPlayerDelegate>(funcTable, 8267723648257335352UL, WeaponData_GetRecoilAccuracyToAllowHeadshotPlayerFallback);
            WeaponData_GetRecoilRecoveryRate = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<WeaponData_GetRecoilRecoveryRateDelegate>(funcTable, 4192514354217953357UL, WeaponData_GetRecoilRecoveryRateFallback);
            WeaponData_GetRecoilShakeAmplitude = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<WeaponData_GetRecoilShakeAmplitudeDelegate>(funcTable, 9480023621281612395UL, WeaponData_GetRecoilShakeAmplitudeFallback);
            WeaponData_GetTimeBetweenShots = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<WeaponData_GetTimeBetweenShotsDelegate>(funcTable, 5640116596268350196UL, WeaponData_GetTimeBetweenShotsFallback);
            WeaponData_GetVehicleReloadTime = (delegate* unmanaged[Cdecl]<uint, float>) GetUnmanagedPtr<WeaponData_GetVehicleReloadTimeDelegate>(funcTable, 11178647132814566028UL, WeaponData_GetVehicleReloadTimeFallback);
            WeaponData_SetAccuracySpread = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<WeaponData_SetAccuracySpreadDelegate>(funcTable, 14821451850297800757UL, WeaponData_SetAccuracySpreadFallback);
            WeaponData_SetAnimReloadRate = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<WeaponData_SetAnimReloadRateDelegate>(funcTable, 1534659069629753541UL, WeaponData_SetAnimReloadRateFallback);
            WeaponData_SetDamage = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<WeaponData_SetDamageDelegate>(funcTable, 3582991520049763058UL, WeaponData_SetDamageFallback);
            WeaponData_SetHeadshotDamageModifier = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<WeaponData_SetHeadshotDamageModifierDelegate>(funcTable, 14513242844091195741UL, WeaponData_SetHeadshotDamageModifierFallback);
            WeaponData_SetLockOnRange = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<WeaponData_SetLockOnRangeDelegate>(funcTable, 3815011183285354604UL, WeaponData_SetLockOnRangeFallback);
            WeaponData_SetPlayerDamageModifier = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<WeaponData_SetPlayerDamageModifierDelegate>(funcTable, 9052872854748340826UL, WeaponData_SetPlayerDamageModifierFallback);
            WeaponData_SetRange = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<WeaponData_SetRangeDelegate>(funcTable, 17027516130676194978UL, WeaponData_SetRangeFallback);
            WeaponData_SetRecoilAccuracyMax = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<WeaponData_SetRecoilAccuracyMaxDelegate>(funcTable, 16496623387920080268UL, WeaponData_SetRecoilAccuracyMaxFallback);
            WeaponData_SetRecoilAccuracyToAllowHeadshotPlayer = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<WeaponData_SetRecoilAccuracyToAllowHeadshotPlayerDelegate>(funcTable, 9883063394541868775UL, WeaponData_SetRecoilAccuracyToAllowHeadshotPlayerFallback);
            WeaponData_SetRecoilRecoveryRate = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<WeaponData_SetRecoilRecoveryRateDelegate>(funcTable, 4278449304231160888UL, WeaponData_SetRecoilRecoveryRateFallback);
            WeaponData_SetRecoilShakeAmplitude = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<WeaponData_SetRecoilShakeAmplitudeDelegate>(funcTable, 11587152197260268366UL, WeaponData_SetRecoilShakeAmplitudeFallback);
            WeaponData_SetVehicleReloadTime = (delegate* unmanaged[Cdecl]<uint, float, void>) GetUnmanagedPtr<WeaponData_SetVehicleReloadTimeDelegate>(funcTable, 4671142066908734019UL, WeaponData_SetVehicleReloadTimeFallback);
            WebSocketClient_AddSubProtocol = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<WebSocketClient_AddSubProtocolDelegate>(funcTable, 11555750091679903352UL, WebSocketClient_AddSubProtocolFallback);
            WebSocketClient_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<WebSocketClient_GetBaseObjectDelegate>(funcTable, 18205331954583363954UL, WebSocketClient_GetBaseObjectFallback);
            WebSocketClient_GetPingInterval = (delegate* unmanaged[Cdecl]<nint, ushort>) GetUnmanagedPtr<WebSocketClient_GetPingIntervalDelegate>(funcTable, 14698647012530242007UL, WebSocketClient_GetPingIntervalFallback);
            WebSocketClient_GetReadyState = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<WebSocketClient_GetReadyStateDelegate>(funcTable, 9387255086102683293UL, WebSocketClient_GetReadyStateFallback);
            WebSocketClient_GetSubProtocols = (delegate* unmanaged[Cdecl]<nint, uint*, nint>) GetUnmanagedPtr<WebSocketClient_GetSubProtocolsDelegate>(funcTable, 10900773598724192064UL, WebSocketClient_GetSubProtocolsFallback);
            WebSocketClient_GetUrl = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<WebSocketClient_GetUrlDelegate>(funcTable, 12430231500242481077UL, WebSocketClient_GetUrlFallback);
            WebSocketClient_IsAutoReconnect = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<WebSocketClient_IsAutoReconnectDelegate>(funcTable, 5396480563898951525UL, WebSocketClient_IsAutoReconnectFallback);
            WebSocketClient_IsPerMessageDeflate = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<WebSocketClient_IsPerMessageDeflateDelegate>(funcTable, 4813724348905978186UL, WebSocketClient_IsPerMessageDeflateFallback);
            WebSocketClient_Send_Binary = (delegate* unmanaged[Cdecl]<nint, nint, uint, byte>) GetUnmanagedPtr<WebSocketClient_Send_BinaryDelegate>(funcTable, 16264215090640453357UL, WebSocketClient_Send_BinaryFallback);
            WebSocketClient_Send_String = (delegate* unmanaged[Cdecl]<nint, nint, byte>) GetUnmanagedPtr<WebSocketClient_Send_StringDelegate>(funcTable, 8369806506248139478UL, WebSocketClient_Send_StringFallback);
            WebSocketClient_SetAutoReconnect = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<WebSocketClient_SetAutoReconnectDelegate>(funcTable, 1696064676371870540UL, WebSocketClient_SetAutoReconnectFallback);
            WebSocketClient_SetExtraHeader = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<WebSocketClient_SetExtraHeaderDelegate>(funcTable, 3511930102272382967UL, WebSocketClient_SetExtraHeaderFallback);
            WebSocketClient_SetPerMessageDeflate = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<WebSocketClient_SetPerMessageDeflateDelegate>(funcTable, 7760619546648311717UL, WebSocketClient_SetPerMessageDeflateFallback);
            WebSocketClient_SetPingInterval = (delegate* unmanaged[Cdecl]<nint, ushort, void>) GetUnmanagedPtr<WebSocketClient_SetPingIntervalDelegate>(funcTable, 11135209075363899066UL, WebSocketClient_SetPingIntervalFallback);
            WebSocketClient_SetUrl = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<WebSocketClient_SetUrlDelegate>(funcTable, 15544145713551234810UL, WebSocketClient_SetUrlFallback);
            WebSocketClient_Start = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<WebSocketClient_StartDelegate>(funcTable, 2682447818769918952UL, WebSocketClient_StartFallback);
            WebSocketClient_Stop = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<WebSocketClient_StopDelegate>(funcTable, 17422281030211529492UL, WebSocketClient_StopFallback);
            WebView_Focus = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<WebView_FocusDelegate>(funcTable, 10962546642911564188UL, WebView_FocusFallback);
            WebView_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) GetUnmanagedPtr<WebView_GetBaseObjectDelegate>(funcTable, 4337031963608011434UL, WebView_GetBaseObjectFallback);
            WebView_GetPosition = (delegate* unmanaged[Cdecl]<nint, Vector2*, void>) GetUnmanagedPtr<WebView_GetPositionDelegate>(funcTable, 12573435703332554258UL, WebView_GetPositionFallback);
            WebView_GetSize = (delegate* unmanaged[Cdecl]<nint, Vector2*, void>) GetUnmanagedPtr<WebView_GetSizeDelegate>(funcTable, 17498347147301708492UL, WebView_GetSizeFallback);
            WebView_GetUrl = (delegate* unmanaged[Cdecl]<nint, int*, nint>) GetUnmanagedPtr<WebView_GetUrlDelegate>(funcTable, 15835367058086887959UL, WebView_GetUrlFallback);
            WebView_IsFocused = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<WebView_IsFocusedDelegate>(funcTable, 12966075852738562650UL, WebView_IsFocusedFallback);
            WebView_IsOverlay = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<WebView_IsOverlayDelegate>(funcTable, 15699676283380308481UL, WebView_IsOverlayFallback);
            WebView_IsVisible = (delegate* unmanaged[Cdecl]<nint, byte>) GetUnmanagedPtr<WebView_IsVisibleDelegate>(funcTable, 15260270363629504087UL, WebView_IsVisibleFallback);
            WebView_SetExtraHeader = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) GetUnmanagedPtr<WebView_SetExtraHeaderDelegate>(funcTable, 685349709143430945UL, WebView_SetExtraHeaderFallback);
            WebView_SetIsVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) GetUnmanagedPtr<WebView_SetIsVisibleDelegate>(funcTable, 9134142886485710584UL, WebView_SetIsVisibleFallback);
            WebView_SetPosition = (delegate* unmanaged[Cdecl]<nint, Vector2, void>) GetUnmanagedPtr<WebView_SetPositionDelegate>(funcTable, 10974483219111968090UL, WebView_SetPositionFallback);
            WebView_SetSize = (delegate* unmanaged[Cdecl]<nint, Vector2, void>) GetUnmanagedPtr<WebView_SetSizeDelegate>(funcTable, 12659655240926292772UL, WebView_SetSizeFallback);
            WebView_SetUrl = (delegate* unmanaged[Cdecl]<nint, nint, void>) GetUnmanagedPtr<WebView_SetUrlDelegate>(funcTable, 447189513112254992UL, WebView_SetUrlFallback);
            WebView_SetZoomLevel = (delegate* unmanaged[Cdecl]<nint, float, void>) GetUnmanagedPtr<WebView_SetZoomLevelDelegate>(funcTable, 1697055721043632334UL, WebView_SetZoomLevelFallback);
            WebView_Unfocus = (delegate* unmanaged[Cdecl]<nint, void>) GetUnmanagedPtr<WebView_UnfocusDelegate>(funcTable, 4944474832415344657UL, WebView_UnfocusFallback);
            Win_GetTaskDialog = (delegate* unmanaged[Cdecl]<nint>) GetUnmanagedPtr<Win_GetTaskDialogDelegate>(funcTable, 7613313658222329036UL, Win_GetTaskDialogFallback);
        }
    }
}