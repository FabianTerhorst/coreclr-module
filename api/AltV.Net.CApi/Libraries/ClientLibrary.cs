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
        public delegate* unmanaged[Cdecl]<nint, uint> Blip_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint> Core_Client_CreateAreaBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_Client_CreatePointBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, nint> Core_Client_CreateRadiusBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint> Core_CreateRmlDocument { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, Vector2, Vector2, byte, nint> Core_CreateWebView { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, uint, nint, nint> Core_CreateWebView3D { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocDiscordUser { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_GetDiscordUser { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Core_GetVoiceActivationKey { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_GetVoiceInputMuted { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsVoiceActivityInputEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, byte, byte, void> Core_LoadRmlFont { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_SetVoiceInputMuted { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, bool, void> Core_ShowCursor { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerServerEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void> Core_TriggerWebViewEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, Vector2*, void> Core_WorldToScreen { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Entity_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ClientEventModuleDelegate, void> Event_SetClientEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ConsoleCommandModuleDelegate, void> Event_SetConsoleCommandDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreatePlayerModuleDelegate, void> Event_SetCreatePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateVehicleModuleDelegate, void> Event_SetCreateVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityCreateModuleDelegate, void> Event_SetGameEntityCreateDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityDestroyModuleDelegate, void> Event_SetGameEntityDestroyDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void> Event_SetKeyDownDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void> Event_SetKeyUpDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerDisconnectModuleDelegate, void> Event_SetPlayerDisconnectDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerEnterVehicleModuleDelegate, void> Event_SetPlayerEnterVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerSpawnModuleDelegate, void> Event_SetPlayerSpawnDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemovePlayerModuleDelegate, void> Event_SetRemovePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveVehicleModuleDelegate, void> Event_SetRemoveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceErrorModuleDelegate, void> Event_SetResourceErrorDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceStartModuleDelegate, void> Event_SetResourceStartDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceStopModuleDelegate, void> Event_SetResourceStopDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ServerEventModuleDelegate, void> Event_SetServerEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.TickModuleDelegate, void> Event_SetTickDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WebViewEventModuleDelegate, void> Event_SetWebViewEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeRmlElementArray { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetCurrentAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Clear { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> LocalStorage_DeleteKey { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> LocalStorage_GetKey { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Save { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> LocalStorage_SetKey { get; }
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
        public delegate* unmanaged[Cdecl]<nint, uint> Blip_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint> Core_Client_CreateAreaBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_Client_CreatePointBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, float, nint> Core_Client_CreateRadiusBlip { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint> Core_CreateRmlDocument { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, Vector2, Vector2, byte, nint> Core_CreateWebView { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, uint, nint, nint> Core_CreateWebView3D { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Core_DeallocDiscordUser { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_GetDiscordUser { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Core_GetVoiceActivationKey { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_GetVoiceInputMuted { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Core_IsVoiceActivityInputEnabled { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint, byte, byte, void> Core_LoadRmlFont { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Core_SetVoiceInputMuted { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, bool, void> Core_ShowCursor { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void> Core_TriggerServerEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void> Core_TriggerWebViewEvent { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, Vector2*, void> Core_WorldToScreen { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Entity_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ClientEventModuleDelegate, void> Event_SetClientEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ConsoleCommandModuleDelegate, void> Event_SetConsoleCommandDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreatePlayerModuleDelegate, void> Event_SetCreatePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateVehicleModuleDelegate, void> Event_SetCreateVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityCreateModuleDelegate, void> Event_SetGameEntityCreateDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityDestroyModuleDelegate, void> Event_SetGameEntityDestroyDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void> Event_SetKeyDownDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void> Event_SetKeyUpDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerDisconnectModuleDelegate, void> Event_SetPlayerDisconnectDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerEnterVehicleModuleDelegate, void> Event_SetPlayerEnterVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerSpawnModuleDelegate, void> Event_SetPlayerSpawnDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemovePlayerModuleDelegate, void> Event_SetRemovePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveVehicleModuleDelegate, void> Event_SetRemoveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceErrorModuleDelegate, void> Event_SetResourceErrorDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceStartModuleDelegate, void> Event_SetResourceStartDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceStopModuleDelegate, void> Event_SetResourceStopDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.ServerEventModuleDelegate, void> Event_SetServerEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.TickModuleDelegate, void> Event_SetTickDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEvents.WebViewEventModuleDelegate, void> Event_SetWebViewEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeRmlElementArray { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetCurrentAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Clear { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> LocalStorage_DeleteKey { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> LocalStorage_GetKey { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LocalStorage_Save { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> LocalStorage_SetKey { get; }
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
            Blip_GetScriptID = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Blip_GetScriptID");
            Core_Client_CreateAreaBlip = (delegate* unmanaged[Cdecl]<nint, Vector3, float, float, nint>) NativeLibrary.GetExport(handle, "Core_Client_CreateAreaBlip");
            Core_Client_CreatePointBlip = (delegate* unmanaged[Cdecl]<nint, Vector3, nint>) NativeLibrary.GetExport(handle, "Core_Client_CreatePointBlip");
            Core_Client_CreateRadiusBlip = (delegate* unmanaged[Cdecl]<nint, Vector3, float, nint>) NativeLibrary.GetExport(handle, "Core_Client_CreateRadiusBlip");
            Core_CreateRmlDocument = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateRmlDocument");
            Core_CreateWebView = (delegate* unmanaged[Cdecl]<nint, nint, nint, Vector2, Vector2, byte, nint>) NativeLibrary.GetExport(handle, "Core_CreateWebView");
            Core_CreateWebView3D = (delegate* unmanaged[Cdecl]<nint, nint, nint, uint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateWebView3D");
            Core_DeallocDiscordUser = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Core_DeallocDiscordUser");
            Core_GetDiscordUser = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Core_GetDiscordUser");
            Core_GetVoiceActivationKey = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Core_GetVoiceActivationKey");
            Core_GetVoiceInputMuted = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Core_GetVoiceInputMuted");
            Core_IsVoiceActivityInputEnabled = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Core_IsVoiceActivityInputEnabled");
            Core_LoadRmlFont = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint, byte, byte, void>) NativeLibrary.GetExport(handle, "Core_LoadRmlFont");
            Core_SetVoiceInputMuted = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Core_SetVoiceInputMuted");
            Core_ShowCursor = (delegate* unmanaged[Cdecl]<nint, nint, bool, void>) NativeLibrary.GetExport(handle, "Core_ShowCursor");
            Core_TriggerServerEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint[], int, void>) NativeLibrary.GetExport(handle, "Core_TriggerServerEvent");
            Core_TriggerWebViewEvent = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint[], int, void>) NativeLibrary.GetExport(handle, "Core_TriggerWebViewEvent");
            Core_WorldToScreen = (delegate* unmanaged[Cdecl]<nint, Vector3, Vector2*, void>) NativeLibrary.GetExport(handle, "Core_WorldToScreen");
            Entity_GetScriptID = (delegate* unmanaged[Cdecl]<nint, int>) NativeLibrary.GetExport(handle, "Entity_GetScriptID");
            Event_SetClientEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ClientEventModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetClientEventDelegate");
            Event_SetConsoleCommandDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ConsoleCommandModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetConsoleCommandDelegate");
            Event_SetCreatePlayerDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreatePlayerModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetCreatePlayerDelegate");
            Event_SetCreateVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.CreateVehicleModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetCreateVehicleDelegate");
            Event_SetGameEntityCreateDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityCreateModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetGameEntityCreateDelegate");
            Event_SetGameEntityDestroyDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.GameEntityDestroyModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetGameEntityDestroyDelegate");
            Event_SetKeyDownDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyDownModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetKeyDownDelegate");
            Event_SetKeyUpDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.KeyUpModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetKeyUpDelegate");
            Event_SetPlayerDisconnectDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerDisconnectModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetPlayerDisconnectDelegate");
            Event_SetPlayerEnterVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerEnterVehicleModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetPlayerEnterVehicleDelegate");
            Event_SetPlayerSpawnDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.PlayerSpawnModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetPlayerSpawnDelegate");
            Event_SetRemovePlayerDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemovePlayerModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetRemovePlayerDelegate");
            Event_SetRemoveVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.RemoveVehicleModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetRemoveVehicleDelegate");
            Event_SetResourceErrorDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceErrorModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetResourceErrorDelegate");
            Event_SetResourceStartDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceStartModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetResourceStartDelegate");
            Event_SetResourceStopDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ResourceStopModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetResourceStopDelegate");
            Event_SetServerEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.ServerEventModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetServerEventDelegate");
            Event_SetTickDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.TickModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetTickDelegate");
            Event_SetWebViewEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEvents.WebViewEventModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetWebViewEventDelegate");
            FreeRmlElementArray = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeRmlElementArray");
            LocalPlayer_GetCurrentAmmo = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "LocalPlayer_GetCurrentAmmo");
            LocalPlayer_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "LocalPlayer_GetID");
            LocalPlayer_GetPlayer = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "LocalPlayer_GetPlayer");
            LocalStorage_Clear = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "LocalStorage_Clear");
            LocalStorage_DeleteKey = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "LocalStorage_DeleteKey");
            LocalStorage_GetKey = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "LocalStorage_GetKey");
            LocalStorage_Save = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "LocalStorage_Save");
            LocalStorage_SetKey = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "LocalStorage_SetKey");
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