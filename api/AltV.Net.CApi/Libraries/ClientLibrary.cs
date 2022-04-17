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
        public delegate* unmanaged[Cdecl]<nint, nint, uint, nint, void> Core_AddGXTText { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_AreGameControlsEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_BeginScaleformMovieMethodMinimap { get; }
        public delegate* unmanaged[Cdecl]<nint, int, byte, void> Core_ClearPedProp { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint> Core_Client_CreateAreaBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_Client_CreatePointBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, nint> Core_Client_CreateRadiusBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_CopyToClipboard { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, float, uint, byte, nint> Core_CreateAudio { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Vector3, Vector3, float, float, Rgba, nint> Core_CreateCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateHttpClient { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint> Core_CreateRmlDocument { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint> Core_CreateWebsocketClient { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, Vector2, Vector2, byte, nint> Core_CreateWebView { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, uint, nint, nint> Core_CreateWebView3D { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocDiscordUser { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_DoesConfigFlagExist { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Core_GetCamPos { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_GetConfigFlag { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2*, byte, void> Core_GetCursorPos { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_GetDiscordUser { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Core_GetFPS { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint, int*, nint> Core_GetGXTText { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, int*, nint> Core_GetHeadshotBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetLicenseHash { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetLocale { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetLocalMeta { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint*, nint> Core_GetMapZoomDataByAlias { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint> Core_GetMapZoomDataById { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Core_GetMsPerGameMinute { get; }
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
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasLocalMeta { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsCamFrozen { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsConsoleOpen { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_IsCursorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsGameFocused { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsInStreamerMode { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> Core_IsKeyDown { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> Core_IsKeyToggled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsMenuOpened { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint, byte> Core_IsTextureExistInArchetype { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsVoiceActivityInputEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Core_LoadModel { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Core_LoadModelAsync { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, byte, byte, void> Core_LoadRmlFont { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_LoadYtyp { get; }
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
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreatePlayerModuleDelegate, void> Event_SetCreatePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateVehicleModuleDelegate, void> Event_SetCreateVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityCreateModuleDelegate, void> Event_SetGameEntityCreateDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityDestroyModuleDelegate, void> Event_SetGameEntityDestroyDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalMetaChangeModuleDelegate, void> Event_SetGlobalMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalSyncedMetaChangeModuleDelegate, void> Event_SetGlobalSyncedMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void> Event_SetKeyDownDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void> Event_SetKeyUpDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.LocalMetaChangeModuleDelegate, void> Event_SetLocalMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.NetOwnerChangeModuleDelegate, void> Event_SetNetOwnerChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeVehicleSeatModuleDelegate, void> Event_SetPlayerChangeVehicleSeatDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerDisconnectModuleDelegate, void> Event_SetPlayerDisconnectDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerEnterVehicleModuleDelegate, void> Event_SetPlayerEnterVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerLeaveVehicleModuleDelegate, void> Event_SetPlayerLeaveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerSpawnModuleDelegate, void> Event_SetPlayerSpawnDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveEntityModuleDelegate, void> Event_SetRemoveEntityDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemovePlayerModuleDelegate, void> Event_SetRemovePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveVehicleModuleDelegate, void> Event_SetRemoveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ServerEventModuleDelegate, void> Event_SetServerEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.StreamSyncedMetaChangeModuleDelegate, void> Event_SetStreamSyncedMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.SyncedMetaChangeModuleDelegate, void> Event_SetSyncedMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.TaskChangeModuleDelegate, void> Event_SetTaskChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.TickModuleDelegate, void> Event_SetTickDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WebViewEventModuleDelegate, void> Event_SetWebViewEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WindowFocusChangeModuleDelegate, void> Event_SetWindowFocusChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WindowResolutionChangeModuleDelegate, void> Event_SetWindowResolutionChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeRmlElementArray { get; }
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
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Clear { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> LocalStorage_DeleteKey { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> LocalStorage_GetKey { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Save { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> LocalStorage_SetKey { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MapData_Destroy { get; }
        public delegate* unmanaged[Cdecl]<nint, float> MapData_GetFScrollSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, float> MapData_GetFZoomScale { get; }
        public delegate* unmanaged[Cdecl]<nint, float> MapData_GetFZoomSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, float> MapData_GetVTilesX { get; }
        public delegate* unmanaged[Cdecl]<nint, float> MapData_GetVTilesY { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> MapData_SetFScrollSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> MapData_SetFZoomScale { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> MapData_SetFZoomSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> MapData_SetVTilesX { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> MapData_SetVTilesY { get; }
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
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, void> Vehicle_GetHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetRPM { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSeatCount { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_GetSpeedVector { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetWheelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAcceleration { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint*, byte> Vehicle_Handling_GetByModelHash { get; }
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
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ReplaceHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ResetHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetMaxGear { get; }
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
    }

    public unsafe class ClientLibrary : IClientLibrary
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
        public delegate* unmanaged[Cdecl]<nint, nint, uint, nint, void> Core_AddGXTText { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_AreGameControlsEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_BeginScaleformMovieMethodMinimap { get; }
        public delegate* unmanaged[Cdecl]<nint, int, byte, void> Core_ClearPedProp { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint> Core_Client_CreateAreaBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_Client_CreatePointBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, nint> Core_Client_CreateRadiusBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_CopyToClipboard { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, float, uint, byte, nint> Core_CreateAudio { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, Vector3, Vector3, float, float, Rgba, nint> Core_CreateCheckpoint { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateHttpClient { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint> Core_CreateRmlDocument { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint> Core_CreateWebsocketClient { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, Vector2, Vector2, byte, nint> Core_CreateWebView { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, uint, nint, nint> Core_CreateWebView3D { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocDiscordUser { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_DoesConfigFlagExist { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Core_GetCamPos { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_GetConfigFlag { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2*, byte, void> Core_GetCursorPos { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_GetDiscordUser { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Core_GetFPS { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint, int*, nint> Core_GetGXTText { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, int*, nint> Core_GetHeadshotBase64 { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetLicenseHash { get; }
        public delegate* unmanaged[Cdecl]<nint, int*, nint> Core_GetLocale { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_GetLocalMeta { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, uint*, nint> Core_GetMapZoomDataByAlias { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint> Core_GetMapZoomDataById { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Core_GetMsPerGameMinute { get; }
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
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_HasLocalMeta { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsCamFrozen { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsConsoleOpen { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_IsCursorVisible { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsGameFocused { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsInStreamerMode { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> Core_IsKeyDown { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, byte> Core_IsKeyToggled { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsMenuOpened { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint, byte> Core_IsTextureExistInArchetype { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsVoiceActivityInputEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Core_LoadModel { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Core_LoadModelAsync { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, byte, byte, void> Core_LoadRmlFont { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Core_LoadYtyp { get; }
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
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreatePlayerModuleDelegate, void> Event_SetCreatePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateVehicleModuleDelegate, void> Event_SetCreateVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityCreateModuleDelegate, void> Event_SetGameEntityCreateDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityDestroyModuleDelegate, void> Event_SetGameEntityDestroyDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalMetaChangeModuleDelegate, void> Event_SetGlobalMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalSyncedMetaChangeModuleDelegate, void> Event_SetGlobalSyncedMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void> Event_SetKeyDownDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void> Event_SetKeyUpDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.LocalMetaChangeModuleDelegate, void> Event_SetLocalMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.NetOwnerChangeModuleDelegate, void> Event_SetNetOwnerChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeVehicleSeatModuleDelegate, void> Event_SetPlayerChangeVehicleSeatDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerDisconnectModuleDelegate, void> Event_SetPlayerDisconnectDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerEnterVehicleModuleDelegate, void> Event_SetPlayerEnterVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerLeaveVehicleModuleDelegate, void> Event_SetPlayerLeaveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerSpawnModuleDelegate, void> Event_SetPlayerSpawnDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveEntityModuleDelegate, void> Event_SetRemoveEntityDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemovePlayerModuleDelegate, void> Event_SetRemovePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveVehicleModuleDelegate, void> Event_SetRemoveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ServerEventModuleDelegate, void> Event_SetServerEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.StreamSyncedMetaChangeModuleDelegate, void> Event_SetStreamSyncedMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.SyncedMetaChangeModuleDelegate, void> Event_SetSyncedMetaChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.TaskChangeModuleDelegate, void> Event_SetTaskChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.TickModuleDelegate, void> Event_SetTickDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WebViewEventModuleDelegate, void> Event_SetWebViewEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WindowFocusChangeModuleDelegate, void> Event_SetWindowFocusChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WindowResolutionChangeModuleDelegate, void> Event_SetWindowResolutionChangeDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeRmlElementArray { get; }
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
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Clear { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> LocalStorage_DeleteKey { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> LocalStorage_GetKey { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Save { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> LocalStorage_SetKey { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MapData_Destroy { get; }
        public delegate* unmanaged[Cdecl]<nint, float> MapData_GetFScrollSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, float> MapData_GetFZoomScale { get; }
        public delegate* unmanaged[Cdecl]<nint, float> MapData_GetFZoomSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, float> MapData_GetVTilesX { get; }
        public delegate* unmanaged[Cdecl]<nint, float> MapData_GetVTilesY { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> MapData_SetFScrollSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> MapData_SetFZoomScale { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> MapData_SetFZoomSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> MapData_SetVTilesX { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> MapData_SetVTilesY { get; }
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
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, void> Vehicle_GetHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetRPM { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSeatCount { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_GetSpeedVector { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetWheelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAcceleration { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint*, byte> Vehicle_Handling_GetByModelHash { get; }
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
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ReplaceHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ResetHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetMaxGear { get; }
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
        public ClientLibrary(string dllName)
        {
            const DllImportSearchPath dllImportSearchPath = DllImportSearchPath.LegacyBehavior | DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories | DllImportSearchPath.System32 | DllImportSearchPath.UserDirectories | DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UseDllDirectoryForDependencies;
            var handle = NativeLibrary.Load(dllName, Assembly.GetExecutingAssembly(), dllImportSearchPath);
            Audio_AddOutput_Entity = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Audio_AddOutput_Entity");
            Audio_AddOutput_ScriptId = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Audio_AddOutput_ScriptId");
            Audio_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Audio_GetBaseObject");
            Audio_GetCategory = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Audio_GetCategory");
            Audio_GetCurrentTime = (delegate* unmanaged[Cdecl]<nint, double>) NativeLibrary.GetExport(handle, "Audio_GetCurrentTime");
            Audio_GetLooped = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Audio_GetLooped");
            Audio_GetMaxTime = (delegate* unmanaged[Cdecl]<nint, double>) NativeLibrary.GetExport(handle, "Audio_GetMaxTime");
            Audio_GetOutputs = (delegate* unmanaged[Cdecl]<nint, nint*, nint*, nint*, uint*, void>) NativeLibrary.GetExport(handle, "Audio_GetOutputs");
            Audio_GetSource = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Audio_GetSource");
            Audio_GetVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Audio_GetVolume");
            Audio_IsFrontendPlay = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Audio_IsFrontendPlay");
            Audio_IsPlaying = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Audio_IsPlaying");
            Audio_Pause = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Audio_Pause");
            Audio_Play = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Audio_Play");
            Audio_RemoveOutput_Entity = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Audio_RemoveOutput_Entity");
            Audio_RemoveOutput_ScriptId = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Audio_RemoveOutput_ScriptId");
            Audio_Reset = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Audio_Reset");
            Audio_Seek = (delegate* unmanaged[Cdecl]<nint, double, void>) NativeLibrary.GetExport(handle, "Audio_Seek");
            Audio_SetCategory = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Audio_SetCategory");
            Audio_SetLooped = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Audio_SetLooped");
            Audio_SetSource = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Audio_SetSource");
            Audio_SetVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Audio_SetVolume");
            Blip_GetScriptID = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Blip_GetScriptID");
            Core_AddGXTText = (delegate* unmanaged[Cdecl]<nint, nint, uint, nint, void>) NativeLibrary.GetExport(handle, "Core_AddGXTText");
            Core_AreGameControlsEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Core_AreGameControlsEnabled");
            Core_BeginScaleformMovieMethodMinimap = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_BeginScaleformMovieMethodMinimap");
            Core_ClearPedProp = (delegate* unmanaged[Cdecl]<nint, int, byte, void>) NativeLibrary.GetExport(handle, "Core_ClearPedProp");
            Core_Client_CreateAreaBlip = (delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint>) NativeLibrary.GetExport(handle, "Core_Client_CreateAreaBlip");
            Core_Client_CreatePointBlip = (delegate* unmanaged[Cdecl]<nint, Vector3, nint>) NativeLibrary.GetExport(handle, "Core_Client_CreatePointBlip");
            Core_Client_CreateRadiusBlip = (delegate* unmanaged[Cdecl]<nint, Vector3, float, nint>) NativeLibrary.GetExport(handle, "Core_Client_CreateRadiusBlip");
            Core_CopyToClipboard = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_CopyToClipboard");
            Core_CreateAudio = (delegate* unmanaged[Cdecl]<nint, nint, nint, float, uint, byte, nint>) NativeLibrary.GetExport(handle, "Core_CreateAudio");
            Core_CreateCheckpoint = (delegate* unmanaged[Cdecl]<nint, byte, Vector3, Vector3, float, float, Rgba, nint>) NativeLibrary.GetExport(handle, "Core_CreateCheckpoint");
            Core_CreateHttpClient = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateHttpClient");
            Core_CreateRmlDocument = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateRmlDocument");
            Core_CreateWebsocketClient = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateWebsocketClient");
            Core_CreateWebView = (delegate* unmanaged[Cdecl]<nint, nint, nint, Vector2, Vector2, byte, nint>) NativeLibrary.GetExport(handle, "Core_CreateWebView");
            Core_CreateWebView3D = (delegate* unmanaged[Cdecl]<nint, nint, nint, uint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateWebView3D");
            Core_DeallocDiscordUser = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Core_DeallocDiscordUser");
            Core_DoesConfigFlagExist = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_DoesConfigFlagExist");
            Core_GetCamPos = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Core_GetCamPos");
            Core_GetConfigFlag = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_GetConfigFlag");
            Core_GetCursorPos = (delegate* unmanaged[Cdecl]<nint, Vector2*, byte, void>) NativeLibrary.GetExport(handle, "Core_GetCursorPos");
            Core_GetDiscordUser = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Core_GetDiscordUser");
            Core_GetFPS = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Core_GetFPS");
            Core_GetGXTText = (delegate* unmanaged[Cdecl]<nint, nint, uint, int*, nint>) NativeLibrary.GetExport(handle, "Core_GetGXTText");
            Core_GetHeadshotBase64 = (delegate* unmanaged[Cdecl]<nint, byte, int*, nint>) NativeLibrary.GetExport(handle, "Core_GetHeadshotBase64");
            Core_GetLicenseHash = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Core_GetLicenseHash");
            Core_GetLocale = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Core_GetLocale");
            Core_GetLocalMeta = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_GetLocalMeta");
            Core_GetMapZoomDataByAlias = (delegate* unmanaged[Cdecl]<nint, nint, uint*, nint>) NativeLibrary.GetExport(handle, "Core_GetMapZoomDataByAlias");
            Core_GetMapZoomDataById = (delegate* unmanaged[Cdecl]<nint, uint, nint>) NativeLibrary.GetExport(handle, "Core_GetMapZoomDataById");
            Core_GetMsPerGameMinute = (delegate* unmanaged[Cdecl]<nint, int>) NativeLibrary.GetExport(handle, "Core_GetMsPerGameMinute");
            Core_GetPermissionState = (delegate* unmanaged[Cdecl]<nint, byte, byte>) NativeLibrary.GetExport(handle, "Core_GetPermissionState");
            Core_GetPing = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Core_GetPing");
            Core_GetScreenResolution = (delegate* unmanaged[Cdecl]<nint, Vector2*, void>) NativeLibrary.GetExport(handle, "Core_GetScreenResolution");
            Core_GetServerIp = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "Core_GetServerIp");
            Core_GetServerPort = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Core_GetServerPort");
            Core_GetStatBool = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_GetStatBool");
            Core_GetStatData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_GetStatData");
            Core_GetStatFloat = (delegate* unmanaged[Cdecl]<nint, nint, float>) NativeLibrary.GetExport(handle, "Core_GetStatFloat");
            Core_GetStatInt = (delegate* unmanaged[Cdecl]<nint, nint, int>) NativeLibrary.GetExport(handle, "Core_GetStatInt");
            Core_GetStatLong = (delegate* unmanaged[Cdecl]<nint, nint, long>) NativeLibrary.GetExport(handle, "Core_GetStatLong");
            Core_GetStatString = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint>) NativeLibrary.GetExport(handle, "Core_GetStatString");
            Core_GetStatType = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint>) NativeLibrary.GetExport(handle, "Core_GetStatType");
            Core_GetStatUInt16 = (delegate* unmanaged[Cdecl]<nint, nint, ushort>) NativeLibrary.GetExport(handle, "Core_GetStatUInt16");
            Core_GetStatUInt32 = (delegate* unmanaged[Cdecl]<nint, nint, uint>) NativeLibrary.GetExport(handle, "Core_GetStatUInt32");
            Core_GetStatUInt64 = (delegate* unmanaged[Cdecl]<nint, nint, ulong>) NativeLibrary.GetExport(handle, "Core_GetStatUInt64");
            Core_GetStatUInt8 = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_GetStatUInt8");
            Core_GetTotalPacketsLost = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Core_GetTotalPacketsLost");
            Core_GetTotalPacketsSent = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "Core_GetTotalPacketsSent");
            Core_GetVoiceActivationKey = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Core_GetVoiceActivationKey");
            Core_GetVoiceInputMuted = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Core_GetVoiceInputMuted");
            Core_HasLocalMeta = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_HasLocalMeta");
            Core_IsCamFrozen = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Core_IsCamFrozen");
            Core_IsConsoleOpen = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Core_IsConsoleOpen");
            Core_IsCursorVisible = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_IsCursorVisible");
            Core_IsGameFocused = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Core_IsGameFocused");
            Core_IsInStreamerMode = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Core_IsInStreamerMode");
            Core_IsKeyDown = (delegate* unmanaged[Cdecl]<nint, uint, byte>) NativeLibrary.GetExport(handle, "Core_IsKeyDown");
            Core_IsKeyToggled = (delegate* unmanaged[Cdecl]<nint, uint, byte>) NativeLibrary.GetExport(handle, "Core_IsKeyToggled");
            Core_IsMenuOpened = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Core_IsMenuOpened");
            Core_IsTextureExistInArchetype = (delegate* unmanaged[Cdecl]<nint, uint, nint, byte>) NativeLibrary.GetExport(handle, "Core_IsTextureExistInArchetype");
            Core_IsVoiceActivityInputEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Core_IsVoiceActivityInputEnabled");
            Core_LoadModel = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Core_LoadModel");
            Core_LoadModelAsync = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Core_LoadModelAsync");
            Core_LoadRmlFont = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Core_LoadRmlFont");
            Core_LoadYtyp = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_LoadYtyp");
            Core_RemoveGXTText = (delegate* unmanaged[Cdecl]<nint, nint, uint, void>) NativeLibrary.GetExport(handle, "Core_RemoveGXTText");
            Core_RemoveIpl = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_RemoveIpl");
            Core_RequestIpl = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_RequestIpl");
            Core_ResetAllMapZoomData = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Core_ResetAllMapZoomData");
            Core_ResetMapZoomData = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Core_ResetMapZoomData");
            Core_ResetStat = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "Core_ResetStat");
            Core_ScreenToWorld = (delegate* unmanaged[Cdecl]<nint, Vector2, Vector3*, void>) NativeLibrary.GetExport(handle, "Core_ScreenToWorld");
            Core_SetCamFrozen = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Core_SetCamFrozen");
            Core_SetConfigFlag = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) NativeLibrary.GetExport(handle, "Core_SetConfigFlag");
            Core_SetCursorPos = (delegate* unmanaged[Cdecl]<nint, Vector2, byte, void>) NativeLibrary.GetExport(handle, "Core_SetCursorPos");
            Core_SetMinimapComponentPosition = (delegate* unmanaged[Cdecl]<nint, nint, byte, byte, float, float, float, float, void>) NativeLibrary.GetExport(handle, "Core_SetMinimapComponentPosition");
            Core_SetMinimapIsRectangle = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Core_SetMinimapIsRectangle");
            Core_SetMsPerGameMinute = (delegate* unmanaged[Cdecl]<nint, int, void>) NativeLibrary.GetExport(handle, "Core_SetMsPerGameMinute");
            Core_SetPedDlcClothes = (delegate* unmanaged[Cdecl]<nint, int, uint, byte, byte, byte, byte, void>) NativeLibrary.GetExport(handle, "Core_SetPedDlcClothes");
            Core_SetPedDlcProp = (delegate* unmanaged[Cdecl]<nint, int, uint, byte, byte, byte, void>) NativeLibrary.GetExport(handle, "Core_SetPedDlcProp");
            Core_SetRotationVelocity = (delegate* unmanaged[Cdecl]<nint, int, Vector3, void>) NativeLibrary.GetExport(handle, "Core_SetRotationVelocity");
            Core_SetStatBool = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) NativeLibrary.GetExport(handle, "Core_SetStatBool");
            Core_SetStatFloat = (delegate* unmanaged[Cdecl]<nint, nint, float, void>) NativeLibrary.GetExport(handle, "Core_SetStatFloat");
            Core_SetStatInt = (delegate* unmanaged[Cdecl]<nint, nint, int, void>) NativeLibrary.GetExport(handle, "Core_SetStatInt");
            Core_SetStatLong = (delegate* unmanaged[Cdecl]<nint, nint, long, void>) NativeLibrary.GetExport(handle, "Core_SetStatLong");
            Core_SetStatString = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "Core_SetStatString");
            Core_SetStatUInt16 = (delegate* unmanaged[Cdecl]<nint, nint, ushort, void>) NativeLibrary.GetExport(handle, "Core_SetStatUInt16");
            Core_SetStatUInt32 = (delegate* unmanaged[Cdecl]<nint, nint, uint, void>) NativeLibrary.GetExport(handle, "Core_SetStatUInt32");
            Core_SetStatUInt64 = (delegate* unmanaged[Cdecl]<nint, nint, ulong, void>) NativeLibrary.GetExport(handle, "Core_SetStatUInt64");
            Core_SetStatUInt8 = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) NativeLibrary.GetExport(handle, "Core_SetStatUInt8");
            Core_SetVoiceInputMuted = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Core_SetVoiceInputMuted");
            Core_SetWatermarkPosition = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Core_SetWatermarkPosition");
            Core_SetWeatherCycle = (delegate* unmanaged[Cdecl]<nint, byte[], int, byte[], int, void>) NativeLibrary.GetExport(handle, "Core_SetWeatherCycle");
            Core_SetWeatherSyncActive = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Core_SetWeatherSyncActive");
            Core_ShowCursor = (delegate* unmanaged[Cdecl]<nint, nint, bool, void>) NativeLibrary.GetExport(handle, "Core_ShowCursor");
            Core_StringToSHA256 = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint>) NativeLibrary.GetExport(handle, "Core_StringToSHA256");
            Core_TakeScreenshot = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ScreenshotResultModuleDelegate, byte>) NativeLibrary.GetExport(handle, "Core_TakeScreenshot");
            Core_TakeScreenshotGameOnly = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ScreenshotResultModuleDelegate, byte>) NativeLibrary.GetExport(handle, "Core_TakeScreenshotGameOnly");
            Core_ToggleGameControls = (delegate* unmanaged[Cdecl]<nint, nint, byte, void>) NativeLibrary.GetExport(handle, "Core_ToggleGameControls");
            Core_ToggleRmlControls = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Core_ToggleRmlControls");
            Core_ToggleVoiceControls = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Core_ToggleVoiceControls");
            Core_TriggerServerEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) NativeLibrary.GetExport(handle, "Core_TriggerServerEvent");
            Core_TriggerWebViewEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void>) NativeLibrary.GetExport(handle, "Core_TriggerWebViewEvent");
            Core_UnloadYtyp = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Core_UnloadYtyp");
            Core_WorldToScreen = (delegate* unmanaged[Cdecl]<nint, Vector3, Vector2*, void>) NativeLibrary.GetExport(handle, "Core_WorldToScreen");
            Entity_GetScriptID = (delegate* unmanaged[Cdecl]<nint, int>) NativeLibrary.GetExport(handle, "Entity_GetScriptID");
            Event_SetAnyResourceErrorDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceErrorModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetAnyResourceErrorDelegate");
            Event_SetAnyResourceStartDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceStartModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetAnyResourceStartDelegate");
            Event_SetAnyResourceStopDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.AnyResourceStopModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetAnyResourceStopDelegate");
            Event_SetClientEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ClientEventModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetClientEventDelegate");
            Event_SetConnectionCompleteDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ConnectionCompleteModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetConnectionCompleteDelegate");
            Event_SetConsoleCommandDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ConsoleCommandModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetConsoleCommandDelegate");
            Event_SetCreatePlayerDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreatePlayerModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetCreatePlayerDelegate");
            Event_SetCreateVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateVehicleModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetCreateVehicleDelegate");
            Event_SetGameEntityCreateDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityCreateModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetGameEntityCreateDelegate");
            Event_SetGameEntityDestroyDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityDestroyModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetGameEntityDestroyDelegate");
            Event_SetGlobalMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalMetaChangeModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetGlobalMetaChangeDelegate");
            Event_SetGlobalSyncedMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.GlobalSyncedMetaChangeModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetGlobalSyncedMetaChangeDelegate");
            Event_SetKeyDownDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetKeyDownDelegate");
            Event_SetKeyUpDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetKeyUpDelegate");
            Event_SetLocalMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.LocalMetaChangeModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetLocalMetaChangeDelegate");
            Event_SetNetOwnerChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.NetOwnerChangeModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetNetOwnerChangeDelegate");
            Event_SetPlayerChangeVehicleSeatDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerChangeVehicleSeatModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetPlayerChangeVehicleSeatDelegate");
            Event_SetPlayerDisconnectDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerDisconnectModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetPlayerDisconnectDelegate");
            Event_SetPlayerEnterVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerEnterVehicleModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetPlayerEnterVehicleDelegate");
            Event_SetPlayerLeaveVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerLeaveVehicleModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetPlayerLeaveVehicleDelegate");
            Event_SetPlayerSpawnDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerSpawnModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetPlayerSpawnDelegate");
            Event_SetRemoveEntityDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveEntityModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetRemoveEntityDelegate");
            Event_SetRemovePlayerDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemovePlayerModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetRemovePlayerDelegate");
            Event_SetRemoveVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveVehicleModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetRemoveVehicleDelegate");
            Event_SetServerEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ServerEventModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetServerEventDelegate");
            Event_SetStreamSyncedMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.StreamSyncedMetaChangeModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetStreamSyncedMetaChangeDelegate");
            Event_SetSyncedMetaChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.SyncedMetaChangeModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetSyncedMetaChangeDelegate");
            Event_SetTaskChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.TaskChangeModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetTaskChangeDelegate");
            Event_SetTickDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.TickModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetTickDelegate");
            Event_SetWebViewEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WebViewEventModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetWebViewEventDelegate");
            Event_SetWindowFocusChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WindowFocusChangeModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetWindowFocusChangeDelegate");
            Event_SetWindowResolutionChangeDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WindowResolutionChangeModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetWindowResolutionChangeDelegate");
            FreeRmlElementArray = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeRmlElementArray");
            HttpClient_Connect = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) NativeLibrary.GetExport(handle, "HttpClient_Connect");
            HttpClient_Delete = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) NativeLibrary.GetExport(handle, "HttpClient_Delete");
            HttpClient_Get = (delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) NativeLibrary.GetExport(handle, "HttpClient_Get");
            HttpClient_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "HttpClient_GetBaseObject");
            HttpClient_GetExtraHeaders = (delegate* unmanaged[Cdecl]<nint, nint*, nint*, int*, void>) NativeLibrary.GetExport(handle, "HttpClient_GetExtraHeaders");
            HttpClient_Head = (delegate* unmanaged[Cdecl]<nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) NativeLibrary.GetExport(handle, "HttpClient_Head");
            HttpClient_Options = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) NativeLibrary.GetExport(handle, "HttpClient_Options");
            HttpClient_Patch = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) NativeLibrary.GetExport(handle, "HttpClient_Patch");
            HttpClient_Post = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) NativeLibrary.GetExport(handle, "HttpClient_Post");
            HttpClient_Put = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) NativeLibrary.GetExport(handle, "HttpClient_Put");
            HttpClient_SetExtraHeader = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "HttpClient_SetExtraHeader");
            HttpClient_Trace = (delegate* unmanaged[Cdecl]<nint, nint, nint, ClientEvents.HttpResponseModuleDelegate, void>) NativeLibrary.GetExport(handle, "HttpClient_Trace");
            LocalPlayer_GetCurrentAmmo = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "LocalPlayer_GetCurrentAmmo");
            LocalPlayer_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "LocalPlayer_GetID");
            LocalPlayer_GetPlayer = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "LocalPlayer_GetPlayer");
            LocalStorage_Clear = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "LocalStorage_Clear");
            LocalStorage_DeleteKey = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "LocalStorage_DeleteKey");
            LocalStorage_GetKey = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "LocalStorage_GetKey");
            LocalStorage_Save = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "LocalStorage_Save");
            LocalStorage_SetKey = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "LocalStorage_SetKey");
            MapData_Destroy = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MapData_Destroy");
            MapData_GetFScrollSpeed = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "MapData_GetFScrollSpeed");
            MapData_GetFZoomScale = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "MapData_GetFZoomScale");
            MapData_GetFZoomSpeed = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "MapData_GetFZoomSpeed");
            MapData_GetVTilesX = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "MapData_GetVTilesX");
            MapData_GetVTilesY = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "MapData_GetVTilesY");
            MapData_SetFScrollSpeed = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "MapData_SetFScrollSpeed");
            MapData_SetFZoomScale = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "MapData_SetFZoomScale");
            MapData_SetFZoomSpeed = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "MapData_SetFZoomSpeed");
            MapData_SetVTilesX = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "MapData_SetVTilesX");
            MapData_SetVTilesY = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "MapData_SetVTilesY");
            Player_GetLocal = (delegate* unmanaged[Cdecl]<nint>) NativeLibrary.GetExport(handle, "Player_GetLocal");
            Player_GetMicLevel = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetMicLevel");
            Player_GetNonSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetNonSpatialVolume");
            Player_GetSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetSpatialVolume");
            Player_IsTalking = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsTalking");
            Player_SetNonSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Player_SetNonSpatialVolume");
            Player_SetSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Player_SetSpatialVolume");
            Resource_FileExists = (delegate* unmanaged[Cdecl]<nint, nint, bool>) NativeLibrary.GetExport(handle, "Resource_FileExists");
            Resource_GetFile = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint*, void>) NativeLibrary.GetExport(handle, "Resource_GetFile");
            Resource_GetLocalStorage = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Resource_GetLocalStorage");
            RmlDocument_CreateElement = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "RmlDocument_CreateElement");
            RmlDocument_CreateTextNode = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "RmlDocument_CreateTextNode");
            RmlDocument_GetBody = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "RmlDocument_GetBody");
            RmlDocument_GetRmlElement = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "RmlDocument_GetRmlElement");
            RmlDocument_GetSourceUrl = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "RmlDocument_GetSourceUrl");
            RmlDocument_GetTitle = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "RmlDocument_GetTitle");
            RmlDocument_Hide = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "RmlDocument_Hide");
            RmlDocument_IsModal = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "RmlDocument_IsModal");
            RmlDocument_IsVisible = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "RmlDocument_IsVisible");
            RmlDocument_SetTitle = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "RmlDocument_SetTitle");
            RmlDocument_Show = (delegate* unmanaged[Cdecl]<nint, byte, byte, void>) NativeLibrary.GetExport(handle, "RmlDocument_Show");
            RmlDocument_Update = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "RmlDocument_Update");
            RmlElement_AddClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void>) NativeLibrary.GetExport(handle, "RmlElement_AddClass");
            RmlElement_AddPseudoClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void>) NativeLibrary.GetExport(handle, "RmlElement_AddPseudoClass");
            RmlElement_AppendChild = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "RmlElement_AppendChild");
            RmlElement_Blur = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void>) NativeLibrary.GetExport(handle, "RmlElement_Blur");
            RmlElement_Click = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void>) NativeLibrary.GetExport(handle, "RmlElement_Click");
            RmlElement_Focus = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, void>) NativeLibrary.GetExport(handle, "RmlElement_Focus");
            RmlElement_GetAbsoluteLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetAbsoluteLeft");
            RmlElement_GetAbsoluteOffset = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void>) NativeLibrary.GetExport(handle, "RmlElement_GetAbsoluteOffset");
            RmlElement_GetAbsoluteTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetAbsoluteTop");
            RmlElement_GetAttribute = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetAttribute");
            RmlElement_GetAttributes = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, nint*, uint*, void>) NativeLibrary.GetExport(handle, "RmlElement_GetAttributes");
            RmlElement_GetBaseline = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetBaseline");
            RmlElement_GetBaseObject = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetBaseObject");
            RmlElement_GetChildCount = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, uint>) NativeLibrary.GetExport(handle, "RmlElement_GetChildCount");
            RmlElement_GetChildNodes = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void>) NativeLibrary.GetExport(handle, "RmlElement_GetChildNodes");
            RmlElement_GetClassList = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void>) NativeLibrary.GetExport(handle, "RmlElement_GetClassList");
            RmlElement_GetClientHeight = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetClientHeight");
            RmlElement_GetClientLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetClientLeft");
            RmlElement_GetClientTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetClientTop");
            RmlElement_GetClientWidth = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetClientWidth");
            RmlElement_GetClosest = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetClosest");
            RmlElement_GetContainingBlock = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void>) NativeLibrary.GetExport(handle, "RmlElement_GetContainingBlock");
            RmlElement_GetElementById = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetElementById");
            RmlElement_GetElementsByClassName = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void>) NativeLibrary.GetExport(handle, "RmlElement_GetElementsByClassName");
            RmlElement_GetElementsByTagName = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void>) NativeLibrary.GetExport(handle, "RmlElement_GetElementsByTagName");
            RmlElement_GetFirstChild = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetFirstChild");
            RmlElement_GetFocusedElement = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetFocusedElement");
            RmlElement_GetId = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetId");
            RmlElement_GetInnerRml = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetInnerRml");
            RmlElement_GetLastChild = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetLastChild");
            RmlElement_GetLocalProperty = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetLocalProperty");
            RmlElement_GetNextSibling = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetNextSibling");
            RmlElement_GetOffsetHeight = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetOffsetHeight");
            RmlElement_GetOffsetLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetOffsetLeft");
            RmlElement_GetOffsetTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetOffsetTop");
            RmlElement_GetOffsetWidth = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetOffsetWidth");
            RmlElement_GetOwnerDocument = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetOwnerDocument");
            RmlElement_GetParent = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetParent");
            RmlElement_GetPreviousSibling = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetPreviousSibling");
            RmlElement_GetProperty = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, int*, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetProperty");
            RmlElement_GetPropertyAbsoluteValue = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetPropertyAbsoluteValue");
            RmlElement_GetPseudoClassList = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint*, uint*, void>) NativeLibrary.GetExport(handle, "RmlElement_GetPseudoClassList");
            RmlElement_GetRelativeOffset = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2*, void>) NativeLibrary.GetExport(handle, "RmlElement_GetRelativeOffset");
            RmlElement_GetScrollHeight = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetScrollHeight");
            RmlElement_GetScrollLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetScrollLeft");
            RmlElement_GetScrollTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetScrollTop");
            RmlElement_GetScrollWidth = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetScrollWidth");
            RmlElement_GetTagName = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, int*, nint>) NativeLibrary.GetExport(handle, "RmlElement_GetTagName");
            RmlElement_GetZIndex = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float>) NativeLibrary.GetExport(handle, "RmlElement_GetZIndex");
            RmlElement_HasAttribute = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) NativeLibrary.GetExport(handle, "RmlElement_HasAttribute");
            RmlElement_HasChildren = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte>) NativeLibrary.GetExport(handle, "RmlElement_HasChildren");
            RmlElement_HasClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) NativeLibrary.GetExport(handle, "RmlElement_HasClass");
            RmlElement_HasLocalProperty = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) NativeLibrary.GetExport(handle, "RmlElement_HasLocalProperty");
            RmlElement_HasProperty = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) NativeLibrary.GetExport(handle, "RmlElement_HasProperty");
            RmlElement_HasPseudoClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) NativeLibrary.GetExport(handle, "RmlElement_HasPseudoClass");
            RmlElement_InsertBefore = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "RmlElement_InsertBefore");
            RmlElement_IsOwned = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte>) NativeLibrary.GetExport(handle, "RmlElement_IsOwned");
            RmlElement_IsPointWithinElement = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, Vector2, byte>) NativeLibrary.GetExport(handle, "RmlElement_IsPointWithinElement");
            RmlElement_IsVisible = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte>) NativeLibrary.GetExport(handle, "RmlElement_IsVisible");
            RmlElement_QuerySelector = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint>) NativeLibrary.GetExport(handle, "RmlElement_QuerySelector");
            RmlElement_QuerySelectorAll = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint*, uint*, void>) NativeLibrary.GetExport(handle, "RmlElement_QuerySelectorAll");
            RmlElement_RemoveAttribute = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) NativeLibrary.GetExport(handle, "RmlElement_RemoveAttribute");
            RmlElement_RemoveChild = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "RmlElement_RemoveChild");
            RmlElement_RemoveClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) NativeLibrary.GetExport(handle, "RmlElement_RemoveClass");
            RmlElement_RemoveProperty = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "RmlElement_RemoveProperty");
            RmlElement_RemovePseudoClass = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, byte>) NativeLibrary.GetExport(handle, "RmlElement_RemovePseudoClass");
            RmlElement_ReplaceChild = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "RmlElement_ReplaceChild");
            RmlElement_ScrollIntoView = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, byte, void>) NativeLibrary.GetExport(handle, "RmlElement_ScrollIntoView");
            RmlElement_SetAttribute = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "RmlElement_SetAttribute");
            RmlElement_SetId = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, void>) NativeLibrary.GetExport(handle, "RmlElement_SetId");
            RmlElement_SetInnerRml = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "RmlElement_SetInnerRml");
            RmlElement_SetOffset = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, nint, Vector2, byte, void>) NativeLibrary.GetExport(handle, "RmlElement_SetOffset");
            RmlElement_SetProperty = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "RmlElement_SetProperty");
            RmlElement_SetScrollLeft = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float, void>) NativeLibrary.GetExport(handle, "RmlElement_SetScrollLeft");
            RmlElement_SetScrollTop = (delegate* unmanaged[Cdecl, SuppressGCTransition]<nint, float, void>) NativeLibrary.GetExport(handle, "RmlElement_SetScrollTop");
            Vehicle_GetGear = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Vehicle_GetGear");
            Vehicle_GetHandling = (delegate* unmanaged[Cdecl]<nint, nint*, void>) NativeLibrary.GetExport(handle, "Vehicle_GetHandling");
            Vehicle_GetIndicatorLights = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetIndicatorLights");
            Vehicle_GetMaxGear = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Vehicle_GetMaxGear");
            Vehicle_GetRPM = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_GetRPM");
            Vehicle_GetSeatCount = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetSeatCount");
            Vehicle_GetSpeedVector = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Vehicle_GetSpeedVector");
            Vehicle_GetWheelSpeed = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_GetWheelSpeed");
            Vehicle_Handling_GetAcceleration = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetAcceleration");
            Vehicle_Handling_GetAntiRollBarBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetAntiRollBarBiasFront");
            Vehicle_Handling_GetAntiRollBarBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetAntiRollBarBiasRear");
            Vehicle_Handling_GetAntiRollBarForce = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetAntiRollBarForce");
            Vehicle_Handling_GetBrakeBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetBrakeBiasFront");
            Vehicle_Handling_GetBrakeBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetBrakeBiasRear");
            Vehicle_Handling_GetBrakeForce = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetBrakeForce");
            Vehicle_Handling_GetByModelHash = (delegate* unmanaged[Cdecl]<nint, uint, nint*, byte>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetByModelHash");
            Vehicle_Handling_GetCamberStiffness = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetCamberStiffness");
            Vehicle_Handling_GetCentreOfMassOffset = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetCentreOfMassOffset");
            Vehicle_Handling_GetClutchChangeRateScaleDownShift = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetClutchChangeRateScaleDownShift");
            Vehicle_Handling_GetClutchChangeRateScaleUpShift = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetClutchChangeRateScaleUpShift");
            Vehicle_Handling_GetCollisionDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetCollisionDamageMult");
            Vehicle_Handling_GetDamageFlags = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetDamageFlags");
            Vehicle_Handling_GetDeformationDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetDeformationDamageMult");
            Vehicle_Handling_GetDownforceModifier = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetDownforceModifier");
            Vehicle_Handling_GetDriveBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetDriveBiasFront");
            Vehicle_Handling_GetDriveInertia = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetDriveInertia");
            Vehicle_Handling_GetDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetDriveMaxFlatVel");
            Vehicle_Handling_GetEngineDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetEngineDamageMult");
            Vehicle_Handling_GetHandBrakeForce = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetHandBrakeForce");
            Vehicle_Handling_GetHandlingFlags = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetHandlingFlags");
            Vehicle_Handling_GetHandlingNameHash = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetHandlingNameHash");
            Vehicle_Handling_GetInertiaMultiplier = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetInertiaMultiplier");
            Vehicle_Handling_GetInitialDragCoeff = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetInitialDragCoeff");
            Vehicle_Handling_GetInitialDriveForce = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetInitialDriveForce");
            Vehicle_Handling_GetInitialDriveGears = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetInitialDriveGears");
            Vehicle_Handling_GetInitialDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetInitialDriveMaxFlatVel");
            Vehicle_Handling_GetLowSpeedTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetLowSpeedTractionLossMult");
            Vehicle_Handling_GetMass = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetMass");
            Vehicle_Handling_GetModelFlags = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetModelFlags");
            Vehicle_Handling_GetMonetaryValue = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetMonetaryValue");
            Vehicle_Handling_GetOilVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetOilVolume");
            Vehicle_Handling_GetPercentSubmerged = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetPercentSubmerged");
            Vehicle_Handling_GetPercentSubmergedRatio = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetPercentSubmergedRatio");
            Vehicle_Handling_GetPetrolTankVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetPetrolTankVolume");
            Vehicle_Handling_GetRollCentreHeightFront = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetRollCentreHeightFront");
            Vehicle_Handling_GetRollCentreHeightRear = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetRollCentreHeightRear");
            Vehicle_Handling_GetSeatOffsetDistX = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSeatOffsetDistX");
            Vehicle_Handling_GetSeatOffsetDistY = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSeatOffsetDistY");
            Vehicle_Handling_GetSeatOffsetDistZ = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSeatOffsetDistZ");
            Vehicle_Handling_GetSteeringLock = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSteeringLock");
            Vehicle_Handling_GetSteeringLockRatio = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSteeringLockRatio");
            Vehicle_Handling_GetSuspensionBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionBiasFront");
            Vehicle_Handling_GetSuspensionBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionBiasRear");
            Vehicle_Handling_GetSuspensionCompDamp = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionCompDamp");
            Vehicle_Handling_GetSuspensionForce = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionForce");
            Vehicle_Handling_GetSuspensionLowerLimit = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionLowerLimit");
            Vehicle_Handling_GetSuspensionRaise = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionRaise");
            Vehicle_Handling_GetSuspensionReboundDamp = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionReboundDamp");
            Vehicle_Handling_GetSuspensionUpperLimit = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionUpperLimit");
            Vehicle_Handling_GetTractionBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionBiasFront");
            Vehicle_Handling_GetTractionBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionBiasRear");
            Vehicle_Handling_GetTractionCurveLateral = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionCurveLateral");
            Vehicle_Handling_GetTractionCurveLateralRatio = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionCurveLateralRatio");
            Vehicle_Handling_GetTractionCurveMax = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionCurveMax");
            Vehicle_Handling_GetTractionCurveMaxRatio = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionCurveMaxRatio");
            Vehicle_Handling_GetTractionCurveMin = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionCurveMin");
            Vehicle_Handling_GetTractionCurveMinRatio = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionCurveMinRatio");
            Vehicle_Handling_GetTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionLossMult");
            Vehicle_Handling_GetTractionSpringDeltaMax = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionSpringDeltaMax");
            Vehicle_Handling_GetTractionSpringDeltaMaxRatio = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionSpringDeltaMaxRatio");
            Vehicle_Handling_GetunkFloat1 = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetunkFloat1");
            Vehicle_Handling_GetunkFloat2 = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetunkFloat2");
            Vehicle_Handling_GetunkFloat4 = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetunkFloat4");
            Vehicle_Handling_GetunkFloat5 = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetunkFloat5");
            Vehicle_Handling_GetWeaponDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetWeaponDamageMult");
            Vehicle_Handling_SetAcceleration = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetAcceleration");
            Vehicle_Handling_SetAntiRollBarBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetAntiRollBarBiasFront");
            Vehicle_Handling_SetAntiRollBarBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetAntiRollBarBiasRear");
            Vehicle_Handling_SetAntiRollBarForce = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetAntiRollBarForce");
            Vehicle_Handling_SetBrakeBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetBrakeBiasFront");
            Vehicle_Handling_SetBrakeBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetBrakeBiasRear");
            Vehicle_Handling_SetBrakeForce = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetBrakeForce");
            Vehicle_Handling_SetCamberStiffness = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetCamberStiffness");
            Vehicle_Handling_SetCentreOfMassOffset = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetCentreOfMassOffset");
            Vehicle_Handling_SetClutchChangeRateScaleDownShift = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetClutchChangeRateScaleDownShift");
            Vehicle_Handling_SetClutchChangeRateScaleUpShift = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetClutchChangeRateScaleUpShift");
            Vehicle_Handling_SetCollisionDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetCollisionDamageMult");
            Vehicle_Handling_SetDamageFlags = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetDamageFlags");
            Vehicle_Handling_SetDeformationDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetDeformationDamageMult");
            Vehicle_Handling_SetDownforceModifier = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetDownforceModifier");
            Vehicle_Handling_SetDriveBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetDriveBiasFront");
            Vehicle_Handling_SetDriveInertia = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetDriveInertia");
            Vehicle_Handling_SetDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetDriveMaxFlatVel");
            Vehicle_Handling_SetEngineDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetEngineDamageMult");
            Vehicle_Handling_SetHandBrakeForce = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetHandBrakeForce");
            Vehicle_Handling_SetHandlingFlags = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetHandlingFlags");
            Vehicle_Handling_SetInertiaMultiplier = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetInertiaMultiplier");
            Vehicle_Handling_SetInitialDragCoeff = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetInitialDragCoeff");
            Vehicle_Handling_SetInitialDriveForce = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetInitialDriveForce");
            Vehicle_Handling_SetInitialDriveGears = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetInitialDriveGears");
            Vehicle_Handling_SetInitialDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetInitialDriveMaxFlatVel");
            Vehicle_Handling_SetLowSpeedTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetLowSpeedTractionLossMult");
            Vehicle_Handling_SetMass = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetMass");
            Vehicle_Handling_SetModelFlags = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetModelFlags");
            Vehicle_Handling_SetMonetaryValue = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetMonetaryValue");
            Vehicle_Handling_SetOilVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetOilVolume");
            Vehicle_Handling_SetPercentSubmerged = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetPercentSubmerged");
            Vehicle_Handling_SetPercentSubmergedRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetPercentSubmergedRatio");
            Vehicle_Handling_SetPetrolTankVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetPetrolTankVolume");
            Vehicle_Handling_SetRollCentreHeightFront = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetRollCentreHeightFront");
            Vehicle_Handling_SetRollCentreHeightRear = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetRollCentreHeightRear");
            Vehicle_Handling_SetSeatOffsetDistX = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSeatOffsetDistX");
            Vehicle_Handling_SetSeatOffsetDistY = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSeatOffsetDistY");
            Vehicle_Handling_SetSeatOffsetDistZ = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSeatOffsetDistZ");
            Vehicle_Handling_SetSteeringLock = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSteeringLock");
            Vehicle_Handling_SetSteeringLockRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSteeringLockRatio");
            Vehicle_Handling_SetSuspensionBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionBiasFront");
            Vehicle_Handling_SetSuspensionBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionBiasRear");
            Vehicle_Handling_SetSuspensionCompDamp = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionCompDamp");
            Vehicle_Handling_SetSuspensionForce = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionForce");
            Vehicle_Handling_SetSuspensionLowerLimit = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionLowerLimit");
            Vehicle_Handling_SetSuspensionRaise = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionRaise");
            Vehicle_Handling_SetSuspensionReboundDamp = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionReboundDamp");
            Vehicle_Handling_SetSuspensionUpperLimit = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionUpperLimit");
            Vehicle_Handling_SetTractionBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionBiasFront");
            Vehicle_Handling_SetTractionBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionBiasRear");
            Vehicle_Handling_SetTractionCurveLateral = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionCurveLateral");
            Vehicle_Handling_SetTractionCurveLateralRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionCurveLateralRatio");
            Vehicle_Handling_SetTractionCurveMax = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionCurveMax");
            Vehicle_Handling_SetTractionCurveMaxRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionCurveMaxRatio");
            Vehicle_Handling_SetTractionCurveMin = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionCurveMin");
            Vehicle_Handling_SetTractionCurveMinRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionCurveMinRatio");
            Vehicle_Handling_SetTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionLossMult");
            Vehicle_Handling_SetTractionSpringDeltaMax = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionSpringDeltaMax");
            Vehicle_Handling_SetTractionSpringDeltaMaxRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionSpringDeltaMaxRatio");
            Vehicle_Handling_SetunkFloat1 = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetunkFloat1");
            Vehicle_Handling_SetunkFloat2 = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetunkFloat2");
            Vehicle_Handling_SetunkFloat4 = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetunkFloat4");
            Vehicle_Handling_SetunkFloat5 = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetunkFloat5");
            Vehicle_Handling_SetWeaponDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetWeaponDamageMult");
            Vehicle_IsHandlingModified = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsHandlingModified");
            Vehicle_ReplaceHandling = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Vehicle_ReplaceHandling");
            Vehicle_ResetHandling = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Vehicle_ResetHandling");
            Vehicle_SetGear = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Vehicle_SetGear");
            Vehicle_SetIndicatorLights = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetIndicatorLights");
            Vehicle_SetMaxGear = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Vehicle_SetMaxGear");
            WebSocketClient_AddSubProtocol = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "WebSocketClient_AddSubProtocol");
            WebSocketClient_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "WebSocketClient_GetBaseObject");
            WebSocketClient_GetPingInterval = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "WebSocketClient_GetPingInterval");
            WebSocketClient_GetReadyState = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "WebSocketClient_GetReadyState");
            WebSocketClient_GetSubProtocols = (delegate* unmanaged[Cdecl]<nint, uint*, nint>) NativeLibrary.GetExport(handle, "WebSocketClient_GetSubProtocols");
            WebSocketClient_GetUrl = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "WebSocketClient_GetUrl");
            WebSocketClient_IsAutoReconnect = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "WebSocketClient_IsAutoReconnect");
            WebSocketClient_IsPerMessageDeflate = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "WebSocketClient_IsPerMessageDeflate");
            WebSocketClient_Send_Binary = (delegate* unmanaged[Cdecl]<nint, nint, uint, byte>) NativeLibrary.GetExport(handle, "WebSocketClient_Send_Binary");
            WebSocketClient_Send_String = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "WebSocketClient_Send_String");
            WebSocketClient_SetAutoReconnect = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "WebSocketClient_SetAutoReconnect");
            WebSocketClient_SetExtraHeader = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "WebSocketClient_SetExtraHeader");
            WebSocketClient_SetPerMessageDeflate = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "WebSocketClient_SetPerMessageDeflate");
            WebSocketClient_SetPingInterval = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "WebSocketClient_SetPingInterval");
            WebSocketClient_SetUrl = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "WebSocketClient_SetUrl");
            WebSocketClient_Start = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "WebSocketClient_Start");
            WebSocketClient_Stop = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "WebSocketClient_Stop");
            WebView_Focus = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "WebView_Focus");
            WebView_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "WebView_GetBaseObject");
            WebView_GetPosition = (delegate* unmanaged[Cdecl]<nint, Vector2*, void>) NativeLibrary.GetExport(handle, "WebView_GetPosition");
            WebView_GetSize = (delegate* unmanaged[Cdecl]<nint, Vector2*, void>) NativeLibrary.GetExport(handle, "WebView_GetSize");
            WebView_GetUrl = (delegate* unmanaged[Cdecl]<nint, int*, nint>) NativeLibrary.GetExport(handle, "WebView_GetUrl");
            WebView_IsFocused = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "WebView_IsFocused");
            WebView_IsOverlay = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "WebView_IsOverlay");
            WebView_IsVisible = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "WebView_IsVisible");
            WebView_SetExtraHeader = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "WebView_SetExtraHeader");
            WebView_SetIsVisible = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "WebView_SetIsVisible");
            WebView_SetPosition = (delegate* unmanaged[Cdecl]<nint, Vector2, void>) NativeLibrary.GetExport(handle, "WebView_SetPosition");
            WebView_SetSize = (delegate* unmanaged[Cdecl]<nint, Vector2, void>) NativeLibrary.GetExport(handle, "WebView_SetSize");
            WebView_SetUrl = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "WebView_SetUrl");
            WebView_SetZoomLevel = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "WebView_SetZoomLevel");
            WebView_Unfocus = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "WebView_Unfocus");
        }
    }
}