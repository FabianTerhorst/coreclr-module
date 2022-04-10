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


EXPORT_SERVER uint8_t Vehicle_GetBoatAnchor(alt::IVehicle* vehicle);
EXPORT_SERVER void Vehicle_SetBoatAnchor(alt::IVehicle* vehicle, uint8_t state);

#ifdef __cplusplus
}
#endif
