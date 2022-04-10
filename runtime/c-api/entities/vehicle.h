#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "../data/types.h"
#include "../utils/export.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif

EXPORT_SHARED uint16_t Vehicle_GetID(alt::IVehicle* vehicle);
EXPORT_SHARED alt::IEntity* Vehicle_GetEntity(alt::IVehicle* vehicle);

EXPORT_SHARED uint8_t Vehicle_GetWheelsCount(alt::IVehicle* vehicle);

EXPORT_SERVER alt::IPlayer* Vehicle_GetDriver(alt::IVehicle* vehicle);
EXPORT_SERVER uint8_t Vehicle_GetDriverID(alt::IVehicle* vehicle, uint16_t& id);

EXPORT_SERVER uint8_t Vehicle_IsDestroyed(alt::IVehicle* vehicle);

EXPORT_SERVER uint8_t Vehicle_GetMod(alt::IVehicle* vehicle, uint8_t category);
EXPORT_SERVER uint8_t Vehicle_GetModsCount(alt::IVehicle* vehicle, uint8_t category);
EXPORT_SERVER uint8_t Vehicle_SetMod(alt::IVehicle* vehicle, uint8_t category, uint8_t id);
EXPORT_SERVER uint8_t Vehicle_GetModKitsCount(alt::IVehicle* vehicle);
EXPORT_SERVER uint8_t Vehicle_GetModKit(alt::IVehicle* vehicle);
EXPORT_SERVER uint8_t Vehicle_SetModKit(alt::IVehicle* vehicle, uint8_t id);

EXPORT_SERVER uint8_t Vehicle_IsPrimaryColorRGB(alt::IVehicle* vehicle);
EXPORT_SERVER uint8_t Vehicle_GetPrimaryColor(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_GetPrimaryColorRGB(alt::IVehicle* vehicle, rgba_t &primaryColor);
EXPORT_SERVER void Vehicle_SetPrimaryColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT_SERVER void Vehicle_SetPrimaryColorRGB(alt::IVehicle* vehicle, rgba_t color);

EXPORT_SERVER uint8_t Vehicle_IsSecondaryColorRGB(alt::IVehicle* vehicle);
EXPORT_SERVER uint8_t Vehicle_GetSecondaryColor(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_GetSecondaryColorRGB(alt::IVehicle* vehicle, rgba_t &secondaryColor);
EXPORT_SERVER void Vehicle_SetSecondaryColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT_SERVER void Vehicle_SetSecondaryColorRGB(alt::IVehicle* vehicle, rgba_t color);

EXPORT_SERVER uint8_t Vehicle_GetPearlColor(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetPearlColor(alt::IVehicle* vehicle, uint8_t color);

EXPORT_SERVER uint8_t Vehicle_GetWheelColor(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetWheelColor(alt::IVehicle* vehicle, uint8_t color);

EXPORT_SERVER uint8_t Vehicle_GetInteriorColor(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetInteriorColor(alt::IVehicle* vehicle, uint8_t color);

EXPORT_SERVER uint8_t Vehicle_GetDashboardColor(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetDashboardColor(alt::IVehicle* vehicle, uint8_t color);

EXPORT_SERVER uint8_t Vehicle_IsTireSmokeColorCustom(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_GetTireSmokeColor(alt::IVehicle* vehicle, rgba_t &tireSmokeColor);
EXPORT_SERVER void Vehicle_SetTireSmokeColor(alt::IVehicle* vehicle, rgba_t color);

EXPORT_SERVER uint8_t Vehicle_GetWheelType(alt::IVehicle* vehicle);
EXPORT_SERVER uint8_t Vehicle_GetWheelVariation(alt::IVehicle* vehicle);
EXPORT_SERVER uint8_t Vehicle_GetRearWheelVariation(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetWheels(alt::IVehicle* vehicle, uint8_t type, uint8_t variation);
EXPORT_SERVER void Vehicle_SetRearWheels(alt::IVehicle* vehicle, uint8_t variation);

EXPORT_SERVER uint8_t Vehicle_GetCustomTires(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetCustomTires(alt::IVehicle* vehicle, uint8_t state);

EXPORT_SERVER uint8_t Vehicle_GetSpecialDarkness(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetSpecialDarkness(alt::IVehicle* vehicle, uint8_t value);

EXPORT_SERVER uint32_t Vehicle_GetNumberplateIndex(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetNumberplateIndex(alt::IVehicle* vehicle, uint32_t index);

EXPORT_SERVER const char* Vehicle_GetNumberplateText(alt::IVehicle* vehicle, int32_t& size);
EXPORT_SERVER void Vehicle_SetNumberplateText(alt::IVehicle* vehicle, const char* text);

EXPORT_SERVER uint8_t Vehicle_GetWindowTint(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetWindowTint(alt::IVehicle* vehicle, uint8_t tint);

EXPORT_SERVER uint8_t Vehicle_GetDirtLevel(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetDirtLevel(alt::IVehicle* vehicle, uint8_t level);

EXPORT_SERVER uint8_t Vehicle_IsExtraOn(alt::IVehicle* vehicle, uint8_t extraID);
EXPORT_SERVER void Vehicle_ToggleExtra(alt::IVehicle* vehicle, uint8_t extraID, uint8_t state);

EXPORT_SERVER uint8_t Vehicle_IsNeonActive(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_GetNeonActive(alt::IVehicle* vehicle, uint8_t* left, uint8_t* right, uint8_t* front, uint8_t* back);
EXPORT_SERVER void Vehicle_SetNeonActive(alt::IVehicle* vehicle, uint8_t left, uint8_t right, uint8_t front, uint8_t back);
EXPORT_SERVER void Vehicle_GetNeonColor(alt::IVehicle* vehicle, rgba_t &neonColor);
EXPORT_SERVER void Vehicle_SetNeonColor(alt::IVehicle* vehicle, rgba_t color);

EXPORT_SERVER uint8_t Vehicle_GetLivery(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetLivery(alt::IVehicle* vehicle, uint8_t livery);

EXPORT_SERVER uint8_t Vehicle_GetRoofLivery(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetRoofLivery(alt::IVehicle* vehicle, uint8_t roofLivery);

EXPORT_SERVER const char* Vehicle_GetAppearanceDataBase64(alt::IVehicle* vehicle, int32_t& size);
EXPORT_SERVER void Vehicle_LoadAppearanceDataFromBase64(alt::IVehicle* vehicle, const char* base64);

EXPORT_SERVER uint8_t Vehicle_IsEngineOn(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetEngineOn(alt::IVehicle* vehicle, uint8_t state);

EXPORT_SERVER uint8_t Vehicle_IsHandbrakeActive(alt::IVehicle* vehicle);

EXPORT_SERVER uint8_t Vehicle_GetHeadlightColor(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetHeadlightColor(alt::IVehicle* vehicle, uint8_t color);

EXPORT_SERVER uint32_t Vehicle_GetRadioStationIndex(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetRadioStationIndex(alt::IVehicle* vehicle, uint32_t stationIndex);

EXPORT_SERVER uint8_t Vehicle_IsSirenActive(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetSirenActive(alt::IVehicle* vehicle, uint8_t state);

// TODO document available values. Enum?
EXPORT_SERVER uint8_t Vehicle_GetLockState(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetLockState(alt::IVehicle* vehicle, uint8_t state);

// TODO document available values. Enum?
EXPORT_SERVER uint8_t Vehicle_GetDoorState(alt::IVehicle* vehicle, uint8_t doorId);
EXPORT_SERVER void Vehicle_SetDoorState(alt::IVehicle* vehicle, uint8_t doorId, uint8_t state);

EXPORT_SERVER uint8_t Vehicle_IsWindowOpened(alt::IVehicle* vehicle, uint8_t windowId);
EXPORT_SERVER void Vehicle_SetWindowOpened(alt::IVehicle* vehicle, uint8_t windowId, uint8_t state);

EXPORT_SERVER uint8_t Vehicle_IsDaylightOn(alt::IVehicle* vehicle);
EXPORT_SERVER uint8_t Vehicle_IsNightlightOn(alt::IVehicle* vehicle);

EXPORT_SERVER uint8_t Vehicle_GetRoofState(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetRoofState(alt::IVehicle* vehicle, uint8_t state);

EXPORT_SERVER uint8_t Vehicle_IsFlamethrowerActive(alt::IVehicle* vehicle);

EXPORT_SERVER float Vehicle_GetLightsMultiplier(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetLightsMultiplier(alt::IVehicle* vehicle, float multiplier);

EXPORT_SERVER const char* Vehicle_GetGameStateBase64(alt::IVehicle* vehicle, int32_t& size);
EXPORT_SERVER void Vehicle_LoadGameStateFromBase64(alt::IVehicle* vehicle, const char* base64);

EXPORT_SERVER int32_t Vehicle_GetEngineHealth(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetEngineHealth(alt::IVehicle* vehicle, int32_t health);

EXPORT_SERVER int32_t Vehicle_GetPetrolTankHealth(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetPetrolTankHealth(alt::IVehicle* vehicle, int32_t health);

EXPORT_SERVER uint8_t Vehicle_IsWheelBurst(alt::IVehicle* vehicle, uint8_t wheelId);
EXPORT_SERVER void Vehicle_SetWheelBurst(alt::IVehicle* vehicle, uint8_t wheelId, uint8_t state);

EXPORT_SERVER uint8_t Vehicle_DoesWheelHasTire(alt::IVehicle* vehicle, uint8_t wheelId);
EXPORT_SERVER void Vehicle_SetWheelHasTire(alt::IVehicle* vehicle, uint8_t wheelId, uint8_t state);

EXPORT_SERVER uint8_t Vehicle_IsWheelDetached(alt::IVehicle* vehicle, uint8_t wheelId);
EXPORT_SERVER void Vehicle_SetWheelDetached(alt::IVehicle* vehicle, uint8_t wheelId, uint8_t state);

EXPORT_SERVER uint8_t Vehicle_IsWheelOnFire(alt::IVehicle* vehicle, uint8_t wheelId);
EXPORT_SERVER void Vehicle_SetWheelOnFire(alt::IVehicle* vehicle, uint8_t wheelId, uint8_t state);

EXPORT_SERVER float Vehicle_GetWheelHealth(alt::IVehicle* vehicle, uint8_t wheelId);
EXPORT_SERVER void Vehicle_SetWheelHealth(alt::IVehicle* vehicle, uint8_t wheelId, float health);

EXPORT_SERVER void Vehicle_SetWheelFixed(alt::IVehicle* vehicle, uint8_t wheelId);

EXPORT_SERVER uint8_t Vehicle_GetRepairsCount(alt::IVehicle* vehicle);

EXPORT_SERVER uint32_t Vehicle_GetBodyHealth(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetBodyHealth(alt::IVehicle* vehicle, uint32_t health);
EXPORT_SERVER uint32_t Vehicle_GetBodyAdditionalHealth(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetBodyAdditionalHealth(alt::IVehicle* vehicle, uint32_t health);

EXPORT_SERVER const char* Vehicle_GetHealthDataBase64(alt::IVehicle* vehicle, int32_t& size);
EXPORT_SERVER void Vehicle_LoadHealthDataFromBase64(alt::IVehicle* vehicle, const char* base64);

EXPORT_SERVER uint8_t Vehicle_GetPartDamageLevel(alt::IVehicle* vehicle, uint8_t partId);
EXPORT_SERVER void Vehicle_SetPartDamageLevel(alt::IVehicle* vehicle, uint8_t partId, uint8_t damage);
EXPORT_SERVER uint8_t Vehicle_GetPartBulletHoles(alt::IVehicle* vehicle, uint8_t partId);
EXPORT_SERVER void Vehicle_SetPartBulletHoles(alt::IVehicle* vehicle, uint8_t partId, uint8_t shootsCount);
EXPORT_SERVER uint8_t Vehicle_IsLightDamaged(alt::IVehicle* vehicle, uint8_t lightId);
EXPORT_SERVER void Vehicle_SetLightDamaged(alt::IVehicle* vehicle, uint8_t lightId, uint8_t isDamaged);
EXPORT_SERVER uint8_t Vehicle_IsWindowDamaged(alt::IVehicle* vehicle, uint8_t windowId);
EXPORT_SERVER void Vehicle_SetWindowDamaged(alt::IVehicle* vehicle, uint8_t windowId, uint8_t isDamaged);
EXPORT_SERVER uint8_t Vehicle_IsSpecialLightDamaged(alt::IVehicle* vehicle, uint8_t specialLightId);
EXPORT_SERVER void Vehicle_SetSpecialLightDamaged(alt::IVehicle* vehicle, uint8_t specialLightId, uint8_t isDamaged);
EXPORT_SERVER uint8_t Vehicle_HasArmoredWindows(alt::IVehicle* vehicle);
EXPORT_SERVER float Vehicle_GetArmoredWindowHealth(alt::IVehicle* vehicle, uint8_t windowId);
EXPORT_SERVER void Vehicle_SetArmoredWindowHealth(alt::IVehicle* vehicle, uint8_t windowId, float health);
EXPORT_SERVER uint8_t Vehicle_GetArmoredWindowShootCount(alt::IVehicle* vehicle, uint8_t windowId);
EXPORT_SERVER void Vehicle_SetArmoredWindowShootCount(alt::IVehicle* vehicle, uint8_t windowId, uint8_t count);
EXPORT_SERVER uint8_t Vehicle_GetBumperDamageLevel(alt::IVehicle* vehicle, uint8_t bumperId);
EXPORT_SERVER void Vehicle_SetBumperDamageLevel(alt::IVehicle* vehicle, uint8_t bumperId, uint8_t damageLevel);

EXPORT_SERVER const char* Vehicle_GetDamageDataBase64(alt::IVehicle* vehicle, int32_t& size);
EXPORT_SERVER void Vehicle_LoadDamageDataFromBase64(alt::IVehicle* vehicle, const char* base64);

EXPORT_SERVER void Vehicle_SetManualEngineControl(alt::IVehicle* vehicle, uint8_t state);
EXPORT_SERVER uint8_t Vehicle_IsManualEngineControl(alt::IVehicle* vehicle);

EXPORT_SERVER const char* Vehicle_GetScriptDataBase64(alt::IVehicle* vehicle, int32_t& size);
EXPORT_SERVER void Vehicle_LoadScriptDataFromBase64(alt::IVehicle* vehicle, const char* base64);

EXPORT_SERVER alt::IVehicle* Vehicle_GetAttached(alt::IVehicle* vehicle);
EXPORT_SERVER alt::IVehicle* Vehicle_GetAttachedTo(alt::IVehicle* vehicle);

EXPORT_SERVER void Vehicle_Repair(alt::IVehicle* vehicle);

EXPORT_SERVER void Vehicle_AttachToEntity(alt::IVehicle* vehicle, alt::IEntity* entity, int16_t otherBone, int16_t ownBone, position_t pos, rotation_t rot, uint8_t collision, uint8_t noFixedRot);
EXPORT_SERVER void Vehicle_Detach(alt::IVehicle* vehicle);

EXPORT_SERVER void Vehicle_GetVelocity(alt::IVehicle* vehicle, position_t &velocity);

EXPORT_SERVER void Vehicle_SetDriftMode(alt::IVehicle* vehicle, uint8_t state);
EXPORT_SERVER uint8_t Vehicle_IsDriftMode(alt::IVehicle* vehicle);

EXPORT_SERVER uint8_t Vehicle_SetSearchLight(alt::IVehicle* vehicle, uint8_t state, alt::IEntity* spottedEntity);

EXPORT_SERVER uint8_t Vehicle_IsTrainMissionTrain(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainMissionTrain(alt::IVehicle* vehicle, uint8_t state);
EXPORT_SERVER int8_t Vehicle_GetTrainTrackId(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainTrackId(alt::IVehicle* vehicle, int8_t trackId);
EXPORT_SERVER alt::IVehicle* Vehicle_GetTrainEngineId(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainEngineId(alt::IVehicle* vehicle, alt::IVehicle* entity);
EXPORT_SERVER int8_t Vehicle_GetTrainConfigIndex(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainConfigIndex(alt::IVehicle* vehicle, int8_t index);
EXPORT_SERVER float Vehicle_GetTrainDistanceFromEngine(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainDistanceFromEngine(alt::IVehicle* vehicle, float distanceFromEngine);
EXPORT_SERVER uint8_t Vehicle_IsTrainEngine(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainIsEngine(alt::IVehicle* vehicle, uint8_t state);
EXPORT_SERVER uint8_t Vehicle_IsTrainCaboose(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainIsCaboose(alt::IVehicle* vehicle, uint8_t isCaboose);
EXPORT_SERVER uint8_t Vehicle_GetTrainDirection(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainDirection(alt::IVehicle* vehicle, uint8_t direction);
EXPORT_SERVER uint8_t Vehicle_HasTrainPassengerCarriages(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainHasPassengerCarriages(alt::IVehicle* vehicle, uint8_t hasPassengerCarriages);
EXPORT_SERVER uint8_t Vehicle_GetTrainRenderDerailed(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainRenderDerailed(alt::IVehicle* vehicle, uint8_t renderDerailed);
EXPORT_SERVER uint8_t Vehicle_GetTrainForceDoorsOpen(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainForceDoorsOpen(alt::IVehicle* vehicle, uint8_t forceDoorsOpen);
EXPORT_SERVER float Vehicle_GetTrainCruiseSpeed(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainCruiseSpeed(alt::IVehicle* vehicle, float cruiseSpeed);
EXPORT_SERVER int8_t Vehicle_GetTrainCarriageConfigIndex(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainCarriageConfigIndex(alt::IVehicle* vehicle, int8_t carriageConfigIndex);
EXPORT_SERVER alt::IVehicle* Vehicle_GetTrainLinkedToBackwardId(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainLinkedToBackwardId(alt::IVehicle* vehicle, alt::IVehicle* entity);
EXPORT_SERVER alt::IVehicle* Vehicle_GetTrainLinkedToForwardId(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetTrainLinkedToForwardId(alt::IVehicle* vehicle, alt::IVehicle* entity);

EXPORT_SERVER uint8_t Vehicle_GetBoatAnchor(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetBoatAnchor(alt::IVehicle* vehicle, uint8_t state);


EXPORT_CLIENT uint16_t Vehicle_GetGear(alt::IVehicle* vehicle);
EXPORT_CLIENT void Vehicle_SetGear(alt::IVehicle* vehicle, uint16_t value);

EXPORT_CLIENT uint8_t Vehicle_GetIndicatorLights(alt::IVehicle* vehicle);
EXPORT_CLIENT void Vehicle_SetIndicatorLights(alt::IVehicle* vehicle, uint8_t value);

EXPORT_CLIENT uint16_t Vehicle_GetMaxGear(alt::IVehicle* vehicle);
EXPORT_CLIENT void Vehicle_SetMaxGear(alt::IVehicle* vehicle, uint16_t value);

EXPORT_CLIENT float Vehicle_GetRPM(alt::IVehicle* vehicle);
EXPORT_CLIENT uint8_t Vehicle_GetSeatCount(alt::IVehicle* vehicle);
EXPORT_CLIENT float Vehicle_GetWheelSpeed(alt::IVehicle* vehicle);
EXPORT_CLIENT void Vehicle_GetSpeedVector(alt::IVehicle* vehicle, vector3_t& vector);

EXPORT_CLIENT uint8_t Vehicle_Handling_GetByModelHash(alt::ICore* core, uint32_t modelHash, alt::IHandlingData*& handling);
EXPORT_CLIENT void Vehicle_GetHandling(alt::IVehicle* vehicle, alt::IHandlingData*& handling);
EXPORT_CLIENT void Vehicle_ReplaceHandling(alt::IVehicle* vehicle);
EXPORT_CLIENT void Vehicle_ResetHandling(alt::IVehicle* vehicle);
EXPORT_CLIENT uint8_t Vehicle_IsHandlingModified(alt::IVehicle* vehicle);

EXPORT_CLIENT uint32_t Vehicle_Handling_GetHandlingNameHash(alt::IHandlingData* handling);
EXPORT_CLIENT float Vehicle_Handling_GetMass(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetMass(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetInitialDragCoeff(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetInitialDragCoeff(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetDownforceModifier(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetDownforceModifier(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetunkFloat1(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetunkFloat1(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetunkFloat2(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetunkFloat2(alt::IHandlingData* handling, float value);
EXPORT_CLIENT void Vehicle_Handling_GetCentreOfMassOffset(alt::IHandlingData* handling, vector3_t& offset);
EXPORT_CLIENT void Vehicle_Handling_SetCentreOfMassOffset(alt::IHandlingData* handling, vector3_t value);
EXPORT_CLIENT void Vehicle_Handling_GetInertiaMultiplier(alt::IHandlingData* handling, vector3_t& offset);
EXPORT_CLIENT void Vehicle_Handling_SetInertiaMultiplier(alt::IHandlingData* handling, vector3_t value);
EXPORT_CLIENT float Vehicle_Handling_GetPercentSubmerged(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetPercentSubmerged(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetPercentSubmergedRatio(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetPercentSubmergedRatio(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetDriveBiasFront(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetDriveBiasFront(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetAcceleration(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetAcceleration(alt::IHandlingData* handling, float value);
EXPORT_CLIENT uint32_t Vehicle_Handling_GetInitialDriveGears(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetInitialDriveGears(alt::IHandlingData* handling, uint32_t value);
EXPORT_CLIENT float Vehicle_Handling_GetDriveInertia(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetDriveInertia(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetClutchChangeRateScaleUpShift(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetClutchChangeRateScaleUpShift(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetClutchChangeRateScaleDownShift(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetClutchChangeRateScaleDownShift(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetInitialDriveForce(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetInitialDriveForce(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetDriveMaxFlatVel(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetDriveMaxFlatVel(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetInitialDriveMaxFlatVel(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetInitialDriveMaxFlatVel(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetBrakeForce(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetBrakeForce(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetunkFloat4(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetunkFloat4(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetBrakeBiasFront(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetBrakeBiasFront(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetBrakeBiasRear(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetBrakeBiasRear(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetHandBrakeForce(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetHandBrakeForce(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetSteeringLock(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetSteeringLock(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetSteeringLockRatio(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetSteeringLockRatio(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetTractionCurveMax(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetTractionCurveMax(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetTractionCurveMaxRatio(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetTractionCurveMaxRatio(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetTractionCurveMin(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetTractionCurveMin(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetTractionCurveMinRatio(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetTractionCurveMinRatio(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetTractionCurveLateral(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetTractionCurveLateral(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetTractionCurveLateralRatio(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetTractionCurveLateralRatio(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetTractionSpringDeltaMax(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetTractionSpringDeltaMax(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetTractionSpringDeltaMaxRatio(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetTractionSpringDeltaMaxRatio(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetLowSpeedTractionLossMult(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetLowSpeedTractionLossMult(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetCamberStiffness(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetCamberStiffness(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetTractionBiasFront(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetTractionBiasFront(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetTractionBiasRear(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetTractionBiasRear(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetTractionLossMult(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetTractionLossMult(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetSuspensionForce(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetSuspensionForce(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetSuspensionCompDamp(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetSuspensionCompDamp(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetSuspensionReboundDamp(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetSuspensionReboundDamp(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetSuspensionUpperLimit(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetSuspensionUpperLimit(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetSuspensionLowerLimit(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetSuspensionLowerLimit(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetSuspensionRaise(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetSuspensionRaise(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetSuspensionBiasFront(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetSuspensionBiasFront(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetSuspensionBiasRear(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetSuspensionBiasRear(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetAntiRollBarForce(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetAntiRollBarForce(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetAntiRollBarBiasFront(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetAntiRollBarBiasFront(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetAntiRollBarBiasRear(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetAntiRollBarBiasRear(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetRollCentreHeightFront(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetRollCentreHeightFront(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetRollCentreHeightRear(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetRollCentreHeightRear(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetCollisionDamageMult(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetCollisionDamageMult(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetWeaponDamageMult(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetWeaponDamageMult(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetDeformationDamageMult(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetDeformationDamageMult(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetEngineDamageMult(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetEngineDamageMult(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetPetrolTankVolume(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetPetrolTankVolume(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetOilVolume(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetOilVolume(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetunkFloat5(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetunkFloat5(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetSeatOffsetDistX(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetSeatOffsetDistX(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetSeatOffsetDistY(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetSeatOffsetDistY(alt::IHandlingData* handling, float value);
EXPORT_CLIENT float Vehicle_Handling_GetSeatOffsetDistZ(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetSeatOffsetDistZ(alt::IHandlingData* handling, float value);
EXPORT_CLIENT uint32_t Vehicle_Handling_GetMonetaryValue(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetMonetaryValue(alt::IHandlingData* handling, uint32_t value);
EXPORT_CLIENT uint32_t Vehicle_Handling_GetModelFlags(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetModelFlags(alt::IHandlingData* handling, uint32_t value);
EXPORT_CLIENT uint32_t Vehicle_Handling_GetHandlingFlags(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetHandlingFlags(alt::IHandlingData* handling, uint32_t value);
EXPORT_CLIENT uint32_t Vehicle_Handling_GetDamageFlags(alt::IHandlingData* handling);
EXPORT_CLIENT void Vehicle_Handling_SetDamageFlags(alt::IHandlingData* handling, uint32_t value);

#ifdef __cplusplus
}
#endif
