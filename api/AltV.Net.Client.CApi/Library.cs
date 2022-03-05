using AltV.Net.Client.Data;
using AltV.Net.Client.CApi.Events;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.Client.CApi.Data;
namespace AltV.Net.Client.CApi
{
    public unsafe interface ILibrary
    {
        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> BaseObject_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> BaseObject_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> BaseObject_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> BaseObject_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> BaseObject_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Entity_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte> Entity_GetTypeByID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Entity_GetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte*, ushort*, void> Entity_GetNetOwnerID { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Entity_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Entity_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<object, void> Event_Cancel { get; }
        public delegate* unmanaged[Cdecl]<object, byte> Event_WasCancelled { get; }
        public delegate* unmanaged[Cdecl]<nint, TickModuleDelegate, void> Event_SetTickDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ServerEventModuleDelegate, void> Event_SetServerEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEventModuleDelegate, void> Event_SetClientEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ConsoleCommandModuleDelegate, void> Event_SetConsoleCommandDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, CreatePlayerModuleDelegate, void> Event_SetCreatePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, RemovePlayerModuleDelegate, void> Event_SetRemovePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, CreateVehicleModuleDelegate, void> Event_SetCreateVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, RemoveVehicleModuleDelegate, void> Event_SetRemoveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, PlayerSpawnModuleDelegate, void> Event_SetPlayerSpawnDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, PlayerDisconnectModuleDelegate, void> Event_SetPlayerDisconnectDelegate { get; }
        public delegate* unmanaged[Cdecl]<UIntArray*, void> FreeUIntArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeCharArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_CreateMValueNil { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint> Core_CreateMValueBool { get; }
        public delegate* unmanaged[Cdecl]<nint, long, nint> Core_CreateMValueInt { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint> Core_CreateMValueUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, double, nint> Core_CreateMValueDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint> Core_CreateMValueList { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint> Core_CreateMValueDict { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_CreateMValueVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, nint> Core_CreateMValueVector2 { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, nint> Core_CreateMValueRgba { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, object, nint> Core_CreateMValueByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetBool { get; }
        public delegate* unmanaged[Cdecl]<nint, long> MValueConst_GetInt { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, double> MValueConst_GetDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, ulong*, byte> MValueConst_GetString { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetListSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], byte> MValueConst_GetList { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetDictSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte> MValueConst_GetDict { get; }
        public delegate* unmanaged[Cdecl]<nint, object, object> MValueConst_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint> MValueConst_CallFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> MValueConst_GetVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> MValueConst_GetRGBA { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, object, void> MValueConst_GetByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetByteArraySize { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Player_GetVehicleID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetAimPos { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetArmour { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, UIntArray*, void> Player_GetCurrentWeaponComponents { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetEntityAimOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Player_GetEntityAimingAtID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsFlashlightActive { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetHeadRot { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsAiming { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsDead { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInRagdoll { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsReloading { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsTalking { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxArmour { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMicLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMoveSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetSeat { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint> Player_GetLocal { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetCurrentAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint*, void> Resource_GetFile { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, bool> Resource_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetCSharpImpl { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogDebug { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogWarning { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogError { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogColored { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetRPM { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSeatCount { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetWheelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_GetSpeedVector { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint*, byte> Vehicle_Handling_GetByModelHash { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, void> Vehicle_GetHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ReplaceHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ResetHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsHandlingModified { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetHandlingNameHash { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetMass { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetMass { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetInitialDragCoeff { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetInitialDragCoeff { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDownforceModifier { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDownforceModifier { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat1 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat1 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat2 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat2 { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_Handling_GetCentreOfMassOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Vehicle_Handling_SetCentreOfMassOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_Handling_GetInertiaMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Vehicle_Handling_SetInertiaMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetPercentSubmerged { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetPercentSubmerged { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetPercentSubmergedRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetPercentSubmergedRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDriveBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDriveBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAcceleration { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAcceleration { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetInitialDriveGears { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetInitialDriveGears { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDriveInertia { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDriveInertia { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetClutchChangeRateScaleUpShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetClutchChangeRateScaleUpShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetClutchChangeRateScaleDownShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetClutchChangeRateScaleDownShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetInitialDriveForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetInitialDriveForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetInitialDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetInitialDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat4 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat4 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetBrakeBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetBrakeBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetHandBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetHandBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSteeringLock { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSteeringLock { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSteeringLockRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSteeringLockRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMin { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMin { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMinRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMinRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveLateral { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveLateral { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveLateralRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveLateralRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionSpringDeltaMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionSpringDeltaMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionSpringDeltaMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionSpringDeltaMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetLowSpeedTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetLowSpeedTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetCamberStiffness { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetCamberStiffness { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionCompDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionCompDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionReboundDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionReboundDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionUpperLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionUpperLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionLowerLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionLowerLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionRaise { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionRaise { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAntiRollBarForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAntiRollBarBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAntiRollBarBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetRollCentreHeightFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetRollCentreHeightFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetRollCentreHeightRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetRollCentreHeightRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetCollisionDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetCollisionDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetWeaponDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetWeaponDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDeformationDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDeformationDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetEngineDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetEngineDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetPetrolTankVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetPetrolTankVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetOilVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetOilVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat5 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat5 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSeatOffsetDistX { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSeatOffsetDistX { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSeatOffsetDistY { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSeatOffsetDistY { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSeatOffsetDistZ { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSeatOffsetDistZ { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetMonetaryValue { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetMonetaryValue { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetModelFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetModelFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetHandlingFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetHandlingFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetDamageFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetDamageFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> WorldObject_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> WorldObject_GetPosition { get; }
    }

    public unsafe class Library : ILibrary
    {
        private const string DllName = "coreclr-client-module";

        public delegate* unmanaged[Cdecl]<nint, nint, nint, void> BaseObject_SetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> BaseObject_HasMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, void> BaseObject_DeleteMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> BaseObject_GetMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> BaseObject_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Entity_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Entity_GetWorldObject { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte> Entity_GetTypeByID { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Entity_GetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, byte*, ushort*, void> Entity_GetNetOwnerID { get; }
        public delegate* unmanaged[Cdecl]<nint, int> Entity_GetScriptID { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Entity_GetRotation { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetStreamSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, byte> Entity_HasSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Entity_GetSyncedMetaData { get; }
        public delegate* unmanaged[Cdecl]<object, void> Event_Cancel { get; }
        public delegate* unmanaged[Cdecl]<object, byte> Event_WasCancelled { get; }
        public delegate* unmanaged[Cdecl]<nint, TickModuleDelegate, void> Event_SetTickDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ServerEventModuleDelegate, void> Event_SetServerEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ClientEventModuleDelegate, void> Event_SetClientEventDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, ConsoleCommandModuleDelegate, void> Event_SetConsoleCommandDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, CreatePlayerModuleDelegate, void> Event_SetCreatePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, RemovePlayerModuleDelegate, void> Event_SetRemovePlayerDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, CreateVehicleModuleDelegate, void> Event_SetCreateVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, RemoveVehicleModuleDelegate, void> Event_SetRemoveVehicleDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, PlayerSpawnModuleDelegate, void> Event_SetPlayerSpawnDelegate { get; }
        public delegate* unmanaged[Cdecl]<nint, PlayerDisconnectModuleDelegate, void> Event_SetPlayerDisconnectDelegate { get; }
        public delegate* unmanaged[Cdecl]<UIntArray*, void> FreeUIntArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeCharArray { get; }
        public delegate* unmanaged[Cdecl]<nint, void> FreeString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Core_CreateMValueNil { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, nint> Core_CreateMValueBool { get; }
        public delegate* unmanaged[Cdecl]<nint, long, nint> Core_CreateMValueInt { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, nint> Core_CreateMValueUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, double, nint> Core_CreateMValueDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint> Core_CreateMValueString { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint> Core_CreateMValueList { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint> Core_CreateMValueDict { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, nint> Core_CreateMValueVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector2, nint> Core_CreateMValueVector2 { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba, nint> Core_CreateMValueRgba { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, object, nint> Core_CreateMValueByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetBool { get; }
        public delegate* unmanaged[Cdecl]<nint, long> MValueConst_GetInt { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetUInt { get; }
        public delegate* unmanaged[Cdecl]<nint, double> MValueConst_GetDouble { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, ulong*, byte> MValueConst_GetString { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetListSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], byte> MValueConst_GetList { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetDictSize { get; }
        public delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte> MValueConst_GetDict { get; }
        public delegate* unmanaged[Cdecl]<nint, object, object> MValueConst_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint> MValueConst_CallFunction { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> MValueConst_GetVector3 { get; }
        public delegate* unmanaged[Cdecl]<nint, Rgba*, void> MValueConst_GetRGBA { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong, object, void> MValueConst_GetByteArray { get; }
        public delegate* unmanaged[Cdecl]<nint, ulong> MValueConst_GetByteArraySize { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_AddRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_RemoveRef { get; }
        public delegate* unmanaged[Cdecl]<nint, void> MValueConst_Delete { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> MValueConst_GetType { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Player_GetVehicleID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetAimPos { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetArmour { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetCurrentWeapon { get; }
        public delegate* unmanaged[Cdecl]<nint, UIntArray*, void> Player_GetCurrentWeaponComponents { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetEntityAimOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort*, byte> Player_GetEntityAimingAtID { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsFlashlightActive { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Player_GetHeadRot { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsAiming { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsDead { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsInRagdoll { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsReloading { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_IsTalking { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxArmour { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetMaxHealth { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMicLevel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetMoveSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetNonSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Player_GetSeat { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Player_GetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Player_SetSpatialVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint> Player_GetLocal { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> LocalPlayer_GetPlayer { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> LocalPlayer_GetCurrentAmmo { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetName { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, int*, nint*, void> Resource_GetFile { get; }
        public delegate* unmanaged[Cdecl]<nint, nint, bool> Resource_FileExists { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Resource_GetCSharpImpl { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogInfo { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogDebug { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogWarning { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogError { get; }
        public delegate* unmanaged[Cdecl]<nint, void> LogColored { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Vehicle_GetEntity { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetGear { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, byte, void> Vehicle_SetIndicatorLights { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort> Vehicle_GetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, ushort, void> Vehicle_SetMaxGear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetRPM { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetSeatCount { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_GetWheelSpeed { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_GetSpeedVector { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_GetWheelsCount { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, nint*, byte> Vehicle_Handling_GetByModelHash { get; }
        public delegate* unmanaged[Cdecl]<nint, nint*, void> Vehicle_GetHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ReplaceHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, void> Vehicle_ResetHandling { get; }
        public delegate* unmanaged[Cdecl]<nint, byte> Vehicle_IsHandlingModified { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetHandlingNameHash { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetMass { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetMass { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetInitialDragCoeff { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetInitialDragCoeff { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDownforceModifier { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDownforceModifier { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat1 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat1 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat2 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat2 { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_Handling_GetCentreOfMassOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Vehicle_Handling_SetCentreOfMassOffset { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> Vehicle_Handling_GetInertiaMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3, void> Vehicle_Handling_SetInertiaMultiplier { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetPercentSubmerged { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetPercentSubmerged { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetPercentSubmergedRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetPercentSubmergedRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDriveBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDriveBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAcceleration { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAcceleration { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetInitialDriveGears { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetInitialDriveGears { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDriveInertia { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDriveInertia { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetClutchChangeRateScaleUpShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetClutchChangeRateScaleUpShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetClutchChangeRateScaleDownShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetClutchChangeRateScaleDownShift { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetInitialDriveForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetInitialDriveForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetInitialDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetInitialDriveMaxFlatVel { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat4 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat4 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetBrakeBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetBrakeBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetBrakeBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetHandBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetHandBrakeForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSteeringLock { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSteeringLock { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSteeringLockRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSteeringLockRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMin { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMin { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveMinRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveMinRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveLateral { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveLateral { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionCurveLateralRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionCurveLateralRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionSpringDeltaMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionSpringDeltaMax { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionSpringDeltaMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionSpringDeltaMaxRatio { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetLowSpeedTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetLowSpeedTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetCamberStiffness { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetCamberStiffness { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetTractionLossMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionCompDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionCompDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionReboundDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionReboundDamp { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionUpperLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionUpperLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionLowerLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionLowerLimit { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionRaise { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionRaise { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSuspensionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSuspensionBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAntiRollBarForce { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAntiRollBarBiasFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetAntiRollBarBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetAntiRollBarBiasRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetRollCentreHeightFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetRollCentreHeightFront { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetRollCentreHeightRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetRollCentreHeightRear { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetCollisionDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetCollisionDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetWeaponDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetWeaponDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetDeformationDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetDeformationDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetEngineDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetEngineDamageMult { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetPetrolTankVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetPetrolTankVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetOilVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetOilVolume { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetunkFloat5 { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetunkFloat5 { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSeatOffsetDistX { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSeatOffsetDistX { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSeatOffsetDistY { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSeatOffsetDistY { get; }
        public delegate* unmanaged[Cdecl]<nint, float> Vehicle_Handling_GetSeatOffsetDistZ { get; }
        public delegate* unmanaged[Cdecl]<nint, float, void> Vehicle_Handling_SetSeatOffsetDistZ { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetMonetaryValue { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetMonetaryValue { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetModelFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetModelFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetHandlingFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetHandlingFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Vehicle_Handling_GetDamageFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Vehicle_Handling_SetDamageFlags { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> WorldObject_GetBaseObject { get; }
        public delegate* unmanaged[Cdecl]<nint, Vector3*, void> WorldObject_GetPosition { get; }
        public Library()
        {
            const DllImportSearchPath dllImportSearchPath = DllImportSearchPath.LegacyBehavior | DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories | DllImportSearchPath.System32 | DllImportSearchPath.UserDirectories | DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UseDllDirectoryForDependencies;
            var handle = NativeLibrary.Load(DllName, Assembly.GetExecutingAssembly(), dllImportSearchPath);
            BaseObject_SetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint, void>) NativeLibrary.GetExport(handle, "BaseObject_SetMetaData");
            BaseObject_HasMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "BaseObject_HasMetaData");
            BaseObject_DeleteMetaData = (delegate* unmanaged[Cdecl]<nint, nint, void>) NativeLibrary.GetExport(handle, "BaseObject_DeleteMetaData");
            BaseObject_GetMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "BaseObject_GetMetaData");
            BaseObject_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "BaseObject_GetType");
            Entity_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Entity_GetID");
            Entity_GetWorldObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Entity_GetWorldObject");
            Entity_GetTypeByID = (delegate* unmanaged[Cdecl]<nint, ushort, byte*, byte>) NativeLibrary.GetExport(handle, "Entity_GetTypeByID");
            Entity_GetModel = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Entity_GetModel");
            Entity_GetNetOwnerID = (delegate* unmanaged[Cdecl]<nint, byte*, ushort*, void>) NativeLibrary.GetExport(handle, "Entity_GetNetOwnerID");
            Entity_GetScriptID = (delegate* unmanaged[Cdecl]<nint, int>) NativeLibrary.GetExport(handle, "Entity_GetScriptID");
            Entity_GetRotation = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Entity_GetRotation");
            Entity_HasStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Entity_HasStreamSyncedMetaData");
            Entity_GetStreamSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Entity_GetStreamSyncedMetaData");
            Entity_HasSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, byte>) NativeLibrary.GetExport(handle, "Entity_HasSyncedMetaData");
            Entity_GetSyncedMetaData = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Entity_GetSyncedMetaData");
            Event_Cancel = (delegate* unmanaged[Cdecl]<object, void>) NativeLibrary.GetExport(handle, "Event_Cancel");
            Event_WasCancelled = (delegate* unmanaged[Cdecl]<object, byte>) NativeLibrary.GetExport(handle, "Event_WasCancelled");
            Event_SetTickDelegate = (delegate* unmanaged[Cdecl]<nint, TickModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetTickDelegate");
            Event_SetServerEventDelegate = (delegate* unmanaged[Cdecl]<nint, ServerEventModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetServerEventDelegate");
            Event_SetClientEventDelegate = (delegate* unmanaged[Cdecl]<nint, ClientEventModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetClientEventDelegate");
            Event_SetConsoleCommandDelegate = (delegate* unmanaged[Cdecl]<nint, ConsoleCommandModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetConsoleCommandDelegate");
            Event_SetCreatePlayerDelegate = (delegate* unmanaged[Cdecl]<nint, CreatePlayerModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetCreatePlayerDelegate");
            Event_SetRemovePlayerDelegate = (delegate* unmanaged[Cdecl]<nint, RemovePlayerModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetRemovePlayerDelegate");
            Event_SetCreateVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, CreateVehicleModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetCreateVehicleDelegate");
            Event_SetRemoveVehicleDelegate = (delegate* unmanaged[Cdecl]<nint, RemoveVehicleModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetRemoveVehicleDelegate");
            Event_SetPlayerSpawnDelegate = (delegate* unmanaged[Cdecl]<nint, PlayerSpawnModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetPlayerSpawnDelegate");
            Event_SetPlayerDisconnectDelegate = (delegate* unmanaged[Cdecl]<nint, PlayerDisconnectModuleDelegate, void>) NativeLibrary.GetExport(handle, "Event_SetPlayerDisconnectDelegate");
            FreeUIntArray = (delegate* unmanaged[Cdecl]<UIntArray*, void>) NativeLibrary.GetExport(handle, "FreeUIntArray");
            FreeCharArray = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeCharArray");
            FreeString = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "FreeString");
            Core_CreateMValueNil = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueNil");
            Core_CreateMValueBool = (delegate* unmanaged[Cdecl]<nint, byte, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueBool");
            Core_CreateMValueInt = (delegate* unmanaged[Cdecl]<nint, long, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueInt");
            Core_CreateMValueUInt = (delegate* unmanaged[Cdecl]<nint, ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueUInt");
            Core_CreateMValueDouble = (delegate* unmanaged[Cdecl]<nint, double, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueDouble");
            Core_CreateMValueString = (delegate* unmanaged[Cdecl]<nint, nint, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueString");
            Core_CreateMValueList = (delegate* unmanaged[Cdecl]<nint, nint[], ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueList");
            Core_CreateMValueDict = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], ulong, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueDict");
            Core_CreateMValueVector3 = (delegate* unmanaged[Cdecl]<nint, Vector3, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueVector3");
            Core_CreateMValueVector2 = (delegate* unmanaged[Cdecl]<nint, Vector2, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueVector2");
            Core_CreateMValueRgba = (delegate* unmanaged[Cdecl]<nint, Rgba, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueRgba");
            Core_CreateMValueByteArray = (delegate* unmanaged[Cdecl]<nint, ulong, object, nint>) NativeLibrary.GetExport(handle, "Core_CreateMValueByteArray");
            MValueConst_GetBool = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "MValueConst_GetBool");
            MValueConst_GetInt = (delegate* unmanaged[Cdecl]<nint, long>) NativeLibrary.GetExport(handle, "MValueConst_GetInt");
            MValueConst_GetUInt = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetUInt");
            MValueConst_GetDouble = (delegate* unmanaged[Cdecl]<nint, double>) NativeLibrary.GetExport(handle, "MValueConst_GetDouble");
            MValueConst_GetString = (delegate* unmanaged[Cdecl]<nint, nint*, ulong*, byte>) NativeLibrary.GetExport(handle, "MValueConst_GetString");
            MValueConst_GetListSize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetListSize");
            MValueConst_GetList = (delegate* unmanaged[Cdecl]<nint, nint[], byte>) NativeLibrary.GetExport(handle, "MValueConst_GetList");
            MValueConst_GetDictSize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetDictSize");
            MValueConst_GetDict = (delegate* unmanaged[Cdecl]<nint, nint[], nint[], byte>) NativeLibrary.GetExport(handle, "MValueConst_GetDict");
            MValueConst_GetEntity = (delegate* unmanaged[Cdecl]<nint, object, object>) NativeLibrary.GetExport(handle, "MValueConst_GetEntity");
            MValueConst_CallFunction = (delegate* unmanaged[Cdecl]<nint, nint, nint[], ulong, nint>) NativeLibrary.GetExport(handle, "MValueConst_CallFunction");
            MValueConst_GetVector3 = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "MValueConst_GetVector3");
            MValueConst_GetRGBA = (delegate* unmanaged[Cdecl]<nint, Rgba*, void>) NativeLibrary.GetExport(handle, "MValueConst_GetRGBA");
            MValueConst_GetByteArray = (delegate* unmanaged[Cdecl]<nint, ulong, object, void>) NativeLibrary.GetExport(handle, "MValueConst_GetByteArray");
            MValueConst_GetByteArraySize = (delegate* unmanaged[Cdecl]<nint, ulong>) NativeLibrary.GetExport(handle, "MValueConst_GetByteArraySize");
            MValueConst_AddRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_AddRef");
            MValueConst_RemoveRef = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_RemoveRef");
            MValueConst_Delete = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "MValueConst_Delete");
            MValueConst_GetType = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "MValueConst_GetType");
            Player_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetID");
            Player_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Player_GetEntity");
            Player_GetVehicleID = (delegate* unmanaged[Cdecl]<nint, ushort*, byte>) NativeLibrary.GetExport(handle, "Player_GetVehicleID");
            Player_GetName = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Player_GetName");
            Player_GetAimPos = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Player_GetAimPos");
            Player_GetArmour = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetArmour");
            Player_GetCurrentWeapon = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Player_GetCurrentWeapon");
            Player_GetCurrentWeaponComponents = (delegate* unmanaged[Cdecl]<nint, UIntArray*, void>) NativeLibrary.GetExport(handle, "Player_GetCurrentWeaponComponents");
            Player_GetEntityAimOffset = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Player_GetEntityAimOffset");
            Player_GetEntityAimingAtID = (delegate* unmanaged[Cdecl]<nint, ushort*, byte>) NativeLibrary.GetExport(handle, "Player_GetEntityAimingAtID");
            Player_IsFlashlightActive = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsFlashlightActive");
            Player_GetHeadRot = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Player_GetHeadRot");
            Player_GetHealth = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetHealth");
            Player_IsAiming = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsAiming");
            Player_IsDead = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsDead");
            Player_IsInRagdoll = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsInRagdoll");
            Player_IsReloading = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsReloading");
            Player_IsTalking = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_IsTalking");
            Player_GetMaxArmour = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetMaxArmour");
            Player_GetMaxHealth = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetMaxHealth");
            Player_GetMicLevel = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetMicLevel");
            Player_GetMoveSpeed = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetMoveSpeed");
            Player_GetNonSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetNonSpatialVolume");
            Player_SetNonSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Player_SetNonSpatialVolume");
            Player_GetSeat = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Player_GetSeat");
            Player_GetSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Player_GetSpatialVolume");
            Player_SetSpatialVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Player_SetSpatialVolume");
            LocalPlayer_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "LocalPlayer_GetID");
            Player_GetLocal = (delegate* unmanaged[Cdecl]<nint>) NativeLibrary.GetExport(handle, "Player_GetLocal");
            LocalPlayer_GetPlayer = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "LocalPlayer_GetPlayer");
            LocalPlayer_GetCurrentAmmo = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "LocalPlayer_GetCurrentAmmo");
            Resource_GetName = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Resource_GetName");
            Resource_GetFile = (delegate* unmanaged[Cdecl]<nint, nint, int*, nint*, void>) NativeLibrary.GetExport(handle, "Resource_GetFile");
            Resource_FileExists = (delegate* unmanaged[Cdecl]<nint, nint, bool>) NativeLibrary.GetExport(handle, "Resource_FileExists");
            Resource_GetCSharpImpl = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Resource_GetCSharpImpl");
            LogInfo = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "LogInfo");
            LogDebug = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "LogDebug");
            LogWarning = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "LogWarning");
            LogError = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "LogError");
            LogColored = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "LogColored");
            Vehicle_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Vehicle_GetID");
            Vehicle_GetEntity = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Vehicle_GetEntity");
            Vehicle_GetGear = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Vehicle_GetGear");
            Vehicle_SetGear = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Vehicle_SetGear");
            Vehicle_GetIndicatorLights = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetIndicatorLights");
            Vehicle_SetIndicatorLights = (delegate* unmanaged[Cdecl]<nint, byte, void>) NativeLibrary.GetExport(handle, "Vehicle_SetIndicatorLights");
            Vehicle_GetMaxGear = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Vehicle_GetMaxGear");
            Vehicle_SetMaxGear = (delegate* unmanaged[Cdecl]<nint, ushort, void>) NativeLibrary.GetExport(handle, "Vehicle_SetMaxGear");
            Vehicle_GetRPM = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_GetRPM");
            Vehicle_GetSeatCount = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetSeatCount");
            Vehicle_GetWheelSpeed = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_GetWheelSpeed");
            Vehicle_GetSpeedVector = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Vehicle_GetSpeedVector");
            Vehicle_GetWheelsCount = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_GetWheelsCount");
            Vehicle_Handling_GetByModelHash = (delegate* unmanaged[Cdecl]<nint, uint, nint*, byte>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetByModelHash");
            Vehicle_GetHandling = (delegate* unmanaged[Cdecl]<nint, nint*, void>) NativeLibrary.GetExport(handle, "Vehicle_GetHandling");
            Vehicle_ReplaceHandling = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Vehicle_ReplaceHandling");
            Vehicle_ResetHandling = (delegate* unmanaged[Cdecl]<nint, void>) NativeLibrary.GetExport(handle, "Vehicle_ResetHandling");
            Vehicle_IsHandlingModified = (delegate* unmanaged[Cdecl]<nint, byte>) NativeLibrary.GetExport(handle, "Vehicle_IsHandlingModified");
            Vehicle_Handling_GetHandlingNameHash = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetHandlingNameHash");
            Vehicle_Handling_GetMass = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetMass");
            Vehicle_Handling_SetMass = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetMass");
            Vehicle_Handling_GetInitialDragCoeff = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetInitialDragCoeff");
            Vehicle_Handling_SetInitialDragCoeff = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetInitialDragCoeff");
            Vehicle_Handling_GetDownforceModifier = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetDownforceModifier");
            Vehicle_Handling_SetDownforceModifier = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetDownforceModifier");
            Vehicle_Handling_GetunkFloat1 = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetunkFloat1");
            Vehicle_Handling_SetunkFloat1 = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetunkFloat1");
            Vehicle_Handling_GetunkFloat2 = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetunkFloat2");
            Vehicle_Handling_SetunkFloat2 = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetunkFloat2");
            Vehicle_Handling_GetCentreOfMassOffset = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetCentreOfMassOffset");
            Vehicle_Handling_SetCentreOfMassOffset = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetCentreOfMassOffset");
            Vehicle_Handling_GetInertiaMultiplier = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetInertiaMultiplier");
            Vehicle_Handling_SetInertiaMultiplier = (delegate* unmanaged[Cdecl]<nint, Vector3, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetInertiaMultiplier");
            Vehicle_Handling_GetPercentSubmerged = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetPercentSubmerged");
            Vehicle_Handling_SetPercentSubmerged = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetPercentSubmerged");
            Vehicle_Handling_GetPercentSubmergedRatio = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetPercentSubmergedRatio");
            Vehicle_Handling_SetPercentSubmergedRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetPercentSubmergedRatio");
            Vehicle_Handling_GetDriveBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetDriveBiasFront");
            Vehicle_Handling_SetDriveBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetDriveBiasFront");
            Vehicle_Handling_GetAcceleration = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetAcceleration");
            Vehicle_Handling_SetAcceleration = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetAcceleration");
            Vehicle_Handling_GetInitialDriveGears = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetInitialDriveGears");
            Vehicle_Handling_SetInitialDriveGears = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetInitialDriveGears");
            Vehicle_Handling_GetDriveInertia = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetDriveInertia");
            Vehicle_Handling_SetDriveInertia = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetDriveInertia");
            Vehicle_Handling_GetClutchChangeRateScaleUpShift = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetClutchChangeRateScaleUpShift");
            Vehicle_Handling_SetClutchChangeRateScaleUpShift = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetClutchChangeRateScaleUpShift");
            Vehicle_Handling_GetClutchChangeRateScaleDownShift = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetClutchChangeRateScaleDownShift");
            Vehicle_Handling_SetClutchChangeRateScaleDownShift = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetClutchChangeRateScaleDownShift");
            Vehicle_Handling_GetInitialDriveForce = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetInitialDriveForce");
            Vehicle_Handling_SetInitialDriveForce = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetInitialDriveForce");
            Vehicle_Handling_GetDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetDriveMaxFlatVel");
            Vehicle_Handling_SetDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetDriveMaxFlatVel");
            Vehicle_Handling_GetInitialDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetInitialDriveMaxFlatVel");
            Vehicle_Handling_SetInitialDriveMaxFlatVel = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetInitialDriveMaxFlatVel");
            Vehicle_Handling_GetBrakeForce = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetBrakeForce");
            Vehicle_Handling_SetBrakeForce = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetBrakeForce");
            Vehicle_Handling_GetunkFloat4 = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetunkFloat4");
            Vehicle_Handling_SetunkFloat4 = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetunkFloat4");
            Vehicle_Handling_GetBrakeBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetBrakeBiasFront");
            Vehicle_Handling_SetBrakeBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetBrakeBiasFront");
            Vehicle_Handling_GetBrakeBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetBrakeBiasRear");
            Vehicle_Handling_SetBrakeBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetBrakeBiasRear");
            Vehicle_Handling_GetHandBrakeForce = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetHandBrakeForce");
            Vehicle_Handling_SetHandBrakeForce = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetHandBrakeForce");
            Vehicle_Handling_GetSteeringLock = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSteeringLock");
            Vehicle_Handling_SetSteeringLock = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSteeringLock");
            Vehicle_Handling_GetSteeringLockRatio = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSteeringLockRatio");
            Vehicle_Handling_SetSteeringLockRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSteeringLockRatio");
            Vehicle_Handling_GetTractionCurveMax = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionCurveMax");
            Vehicle_Handling_SetTractionCurveMax = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionCurveMax");
            Vehicle_Handling_GetTractionCurveMaxRatio = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionCurveMaxRatio");
            Vehicle_Handling_SetTractionCurveMaxRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionCurveMaxRatio");
            Vehicle_Handling_GetTractionCurveMin = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionCurveMin");
            Vehicle_Handling_SetTractionCurveMin = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionCurveMin");
            Vehicle_Handling_GetTractionCurveMinRatio = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionCurveMinRatio");
            Vehicle_Handling_SetTractionCurveMinRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionCurveMinRatio");
            Vehicle_Handling_GetTractionCurveLateral = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionCurveLateral");
            Vehicle_Handling_SetTractionCurveLateral = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionCurveLateral");
            Vehicle_Handling_GetTractionCurveLateralRatio = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionCurveLateralRatio");
            Vehicle_Handling_SetTractionCurveLateralRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionCurveLateralRatio");
            Vehicle_Handling_GetTractionSpringDeltaMax = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionSpringDeltaMax");
            Vehicle_Handling_SetTractionSpringDeltaMax = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionSpringDeltaMax");
            Vehicle_Handling_GetTractionSpringDeltaMaxRatio = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionSpringDeltaMaxRatio");
            Vehicle_Handling_SetTractionSpringDeltaMaxRatio = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionSpringDeltaMaxRatio");
            Vehicle_Handling_GetLowSpeedTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetLowSpeedTractionLossMult");
            Vehicle_Handling_SetLowSpeedTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetLowSpeedTractionLossMult");
            Vehicle_Handling_GetCamberStiffness = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetCamberStiffness");
            Vehicle_Handling_SetCamberStiffness = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetCamberStiffness");
            Vehicle_Handling_GetTractionBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionBiasFront");
            Vehicle_Handling_SetTractionBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionBiasFront");
            Vehicle_Handling_GetTractionBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionBiasRear");
            Vehicle_Handling_SetTractionBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionBiasRear");
            Vehicle_Handling_GetTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetTractionLossMult");
            Vehicle_Handling_SetTractionLossMult = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetTractionLossMult");
            Vehicle_Handling_GetSuspensionForce = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionForce");
            Vehicle_Handling_SetSuspensionForce = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionForce");
            Vehicle_Handling_GetSuspensionCompDamp = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionCompDamp");
            Vehicle_Handling_SetSuspensionCompDamp = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionCompDamp");
            Vehicle_Handling_GetSuspensionReboundDamp = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionReboundDamp");
            Vehicle_Handling_SetSuspensionReboundDamp = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionReboundDamp");
            Vehicle_Handling_GetSuspensionUpperLimit = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionUpperLimit");
            Vehicle_Handling_SetSuspensionUpperLimit = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionUpperLimit");
            Vehicle_Handling_GetSuspensionLowerLimit = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionLowerLimit");
            Vehicle_Handling_SetSuspensionLowerLimit = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionLowerLimit");
            Vehicle_Handling_GetSuspensionRaise = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionRaise");
            Vehicle_Handling_SetSuspensionRaise = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionRaise");
            Vehicle_Handling_GetSuspensionBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionBiasFront");
            Vehicle_Handling_SetSuspensionBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionBiasFront");
            Vehicle_Handling_GetSuspensionBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSuspensionBiasRear");
            Vehicle_Handling_SetSuspensionBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSuspensionBiasRear");
            Vehicle_Handling_GetAntiRollBarForce = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetAntiRollBarForce");
            Vehicle_Handling_SetAntiRollBarForce = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetAntiRollBarForce");
            Vehicle_Handling_GetAntiRollBarBiasFront = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetAntiRollBarBiasFront");
            Vehicle_Handling_SetAntiRollBarBiasFront = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetAntiRollBarBiasFront");
            Vehicle_Handling_GetAntiRollBarBiasRear = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetAntiRollBarBiasRear");
            Vehicle_Handling_SetAntiRollBarBiasRear = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetAntiRollBarBiasRear");
            Vehicle_Handling_GetRollCentreHeightFront = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetRollCentreHeightFront");
            Vehicle_Handling_SetRollCentreHeightFront = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetRollCentreHeightFront");
            Vehicle_Handling_GetRollCentreHeightRear = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetRollCentreHeightRear");
            Vehicle_Handling_SetRollCentreHeightRear = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetRollCentreHeightRear");
            Vehicle_Handling_GetCollisionDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetCollisionDamageMult");
            Vehicle_Handling_SetCollisionDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetCollisionDamageMult");
            Vehicle_Handling_GetWeaponDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetWeaponDamageMult");
            Vehicle_Handling_SetWeaponDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetWeaponDamageMult");
            Vehicle_Handling_GetDeformationDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetDeformationDamageMult");
            Vehicle_Handling_SetDeformationDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetDeformationDamageMult");
            Vehicle_Handling_GetEngineDamageMult = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetEngineDamageMult");
            Vehicle_Handling_SetEngineDamageMult = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetEngineDamageMult");
            Vehicle_Handling_GetPetrolTankVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetPetrolTankVolume");
            Vehicle_Handling_SetPetrolTankVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetPetrolTankVolume");
            Vehicle_Handling_GetOilVolume = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetOilVolume");
            Vehicle_Handling_SetOilVolume = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetOilVolume");
            Vehicle_Handling_GetunkFloat5 = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetunkFloat5");
            Vehicle_Handling_SetunkFloat5 = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetunkFloat5");
            Vehicle_Handling_GetSeatOffsetDistX = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSeatOffsetDistX");
            Vehicle_Handling_SetSeatOffsetDistX = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSeatOffsetDistX");
            Vehicle_Handling_GetSeatOffsetDistY = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSeatOffsetDistY");
            Vehicle_Handling_SetSeatOffsetDistY = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSeatOffsetDistY");
            Vehicle_Handling_GetSeatOffsetDistZ = (delegate* unmanaged[Cdecl]<nint, float>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetSeatOffsetDistZ");
            Vehicle_Handling_SetSeatOffsetDistZ = (delegate* unmanaged[Cdecl]<nint, float, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetSeatOffsetDistZ");
            Vehicle_Handling_GetMonetaryValue = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetMonetaryValue");
            Vehicle_Handling_SetMonetaryValue = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetMonetaryValue");
            Vehicle_Handling_GetModelFlags = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetModelFlags");
            Vehicle_Handling_SetModelFlags = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetModelFlags");
            Vehicle_Handling_GetHandlingFlags = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetHandlingFlags");
            Vehicle_Handling_SetHandlingFlags = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetHandlingFlags");
            Vehicle_Handling_GetDamageFlags = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Vehicle_Handling_GetDamageFlags");
            Vehicle_Handling_SetDamageFlags = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Vehicle_Handling_SetDamageFlags");
            WorldObject_GetBaseObject = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "WorldObject_GetBaseObject");
            WorldObject_GetPosition = (delegate* unmanaged[Cdecl]<nint, Vector3*, void>) NativeLibrary.GetExport(handle, "WorldObject_GetPosition");
        }
    }
}