#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>
#include "position.h"
#include "rotation.h"
#include "rgba.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
// Entity
EXPORT uint16_t Vehicle_GetID(alt::IVehicle* vehicle);
EXPORT alt::IPlayer* Vehicle_GetNetworkOwner(alt::IVehicle* vehicle);
EXPORT uint32_t Vehicle_GetModel(alt::IVehicle* vehicle);
EXPORT void Vehicle_GetPosition(alt::IVehicle* vehicle, position_t &position);
EXPORT void Vehicle_SetPosition(alt::IVehicle* vehicle, position_t pos);
EXPORT void Vehicle_GetRotation(alt::IVehicle* vehicle, rotation_t &rotation);
EXPORT void Vehicle_SetRotation(alt::IVehicle* vehicle, rotation_t rot);
EXPORT int32_t Vehicle_GetDimension(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetDimension(alt::IVehicle* vehicle, int32_t dimension);
EXPORT alt::MValueConst* Vehicle_GetMetaData(alt::IVehicle* vehicle, const char* key);
EXPORT void Vehicle_SetMetaData(alt::IVehicle* vehicle, const char* key, alt::MValueConst* val);
EXPORT uint8_t Vehicle_HasMetaData(alt::IVehicle* vehicle, const char* key);
EXPORT void Vehicle_DeleteMetaData(alt::IVehicle* vehicle, const char* key);
EXPORT alt::MValueConst* Vehicle_GetSyncedMetaData(alt::IVehicle* vehicle, const char* key);
EXPORT void Vehicle_SetSyncedMetaData(alt::IVehicle* vehicle, const char* key, alt::MValueConst* val);
EXPORT uint8_t Vehicle_HasSyncedMetaData(alt::IVehicle* vehicle, const char* key);
EXPORT void Vehicle_DeleteSyncedMetaData(alt::IVehicle* vehicle, const char* key);
EXPORT alt::MValueConst* Vehicle_GetStreamSyncedMetaData(alt::IVehicle* vehicle, const char* key);
EXPORT void Vehicle_SetStreamSyncedMetaData(alt::IVehicle* entity, const char* key, alt::MValueConst* val);
EXPORT uint8_t Vehicle_HasStreamSyncedMetaData(alt::IVehicle* vehicle, const char* key);
EXPORT void Vehicle_DeleteStreamSyncedMetaData(alt::IVehicle* vehicle, const char* key);
EXPORT void Vehicle_AddRef(alt::IVehicle* vehicle);
EXPORT void Vehicle_RemoveRef(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetVisible(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetVisible(alt::IVehicle* vehicle, uint8_t state);
EXPORT uint8_t Vehicle_GetStreamed(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetStreamed(alt::IVehicle* vehicle, uint8_t state);
// Vehicle
EXPORT alt::IPlayer* Vehicle_GetDriver(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_IsDestroyed(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetMod(alt::IVehicle* vehicle, uint8_t category);
EXPORT uint8_t Vehicle_GetModsCount(alt::IVehicle* vehicle, uint8_t category);
EXPORT uint8_t Vehicle_SetMod(alt::IVehicle* vehicle, uint8_t category, uint8_t id);
EXPORT uint8_t Vehicle_GetModKitsCount(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetModKit(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_SetModKit(alt::IVehicle* vehicle, uint8_t id);
EXPORT uint8_t Vehicle_IsPrimaryColorRGB(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetPrimaryColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_GetPrimaryColorRGB(alt::IVehicle* vehicle, rgba_t &primaryColor);
EXPORT void Vehicle_SetPrimaryColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT void Vehicle_SetPrimaryColorRGB(alt::IVehicle* vehicle, rgba_t color);
EXPORT uint8_t Vehicle_IsSecondaryColorRGB(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetSecondaryColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_GetSecondaryColorRGB(alt::IVehicle* vehicle, rgba_t &secondaryColor);
EXPORT void Vehicle_SetSecondaryColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT void Vehicle_SetSecondaryColorRGB(alt::IVehicle* vehicle, rgba_t color);
EXPORT uint8_t Vehicle_GetPearlColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetPearlColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT uint8_t Vehicle_GetWheelColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetWheelColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT uint8_t Vehicle_GetInteriorColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetInteriorColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT uint8_t Vehicle_GetDashboardColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetDashboardColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT uint8_t Vehicle_IsTireSmokeColorCustom(alt::IVehicle* vehicle);
EXPORT void Vehicle_GetTireSmokeColor(alt::IVehicle* vehicle, rgba_t &tireSmokeColor);
EXPORT void Vehicle_SetTireSmokeColor(alt::IVehicle* vehicle, rgba_t color);
EXPORT uint8_t Vehicle_GetWheelType(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetWheelVariation(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetRearWheelVariation(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetWheels(alt::IVehicle* vehicle, uint8_t type, uint8_t variation);
EXPORT void Vehicle_SetRearWheels(alt::IVehicle* vehicle, uint8_t variation);
EXPORT uint8_t Vehicle_GetCustomTires(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetCustomTires(alt::IVehicle* vehicle, uint8_t state);
EXPORT uint8_t Vehicle_GetSpecialDarkness(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetSpecialDarkness(alt::IVehicle* vehicle, uint8_t value);
EXPORT uint32_t Vehicle_GetNumberplateIndex(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetNumberplateIndex(alt::IVehicle* vehicle, uint32_t index);
EXPORT void Vehicle_GetNumberplateText(alt::IVehicle* vehicle, const char*&text);
EXPORT void Vehicle_SetNumberplateText(alt::IVehicle* vehicle, const char* text);
EXPORT uint8_t Vehicle_GetWindowTint(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetWindowTint(alt::IVehicle* vehicle, uint8_t tint);
EXPORT uint8_t Vehicle_GetDirtLevel(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetDirtLevel(alt::IVehicle* vehicle, uint8_t level);
EXPORT uint8_t Vehicle_IsExtraOn(alt::IVehicle* vehicle, uint8_t extraID);
EXPORT void Vehicle_ToggleExtra(alt::IVehicle* vehicle, uint8_t extraID, uint8_t state);
EXPORT uint8_t Vehicle_IsNeonActive(alt::IVehicle* vehicle);
EXPORT void Vehicle_GetNeonActive(alt::IVehicle* vehicle, uint8_t* left, uint8_t* right, uint8_t* front, uint8_t* back);
EXPORT void Vehicle_SetNeonActive(alt::IVehicle* vehicle, uint8_t left, uint8_t right, uint8_t front, uint8_t back);
EXPORT void Vehicle_GetNeonColor(alt::IVehicle* vehicle, rgba_t &neonColor);
EXPORT void Vehicle_SetNeonColor(alt::IVehicle* vehicle, rgba_t color);

EXPORT uint8_t Vehicle_GetLivery(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetLivery(alt::IVehicle* vehicle, uint8_t livery);
EXPORT uint8_t Vehicle_GetRoofLivery(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetRoofLivery(alt::IVehicle* vehicle, uint8_t roofLivery);

EXPORT void Vehicle_GetAppearanceDataBase64(alt::IVehicle* vehicle, const char*&base64);
EXPORT void Vehicle_LoadAppearanceDataFromBase64(alt::IVehicle* vehicle, const char* base64);

EXPORT uint8_t Vehicle_IsEngineOn(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetEngineOn(alt::IVehicle* vehicle, uint8_t state);

EXPORT uint8_t Vehicle_IsHandbrakeActive(alt::IVehicle* vehicle);

EXPORT uint8_t Vehicle_GetHeadlightColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetHeadlightColor(alt::IVehicle* vehicle, uint8_t color);

EXPORT uint32_t Vehicle_GetRadioStationIndex(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetRadioStationIndex(alt::IVehicle* vehicle, uint32_t stationIndex);

EXPORT uint8_t Vehicle_IsSirenActive(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetSirenActive(alt::IVehicle* vehicle, uint8_t state);

// TODO document available values. Enum?
EXPORT uint8_t Vehicle_GetLockState(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetLockState(alt::IVehicle* vehicle, uint8_t state);

// TODO document available values. Enum?
EXPORT uint8_t Vehicle_GetDoorState(alt::IVehicle* vehicle, uint8_t doorId);
EXPORT void Vehicle_SetDoorState(alt::IVehicle* vehicle, uint8_t doorId, uint8_t state);

EXPORT uint8_t Vehicle_IsWindowOpened(alt::IVehicle* vehicle, uint8_t windowId);
EXPORT void Vehicle_SetWindowOpened(alt::IVehicle* vehicle, uint8_t windowId, uint8_t state);

EXPORT uint8_t Vehicle_IsDaylightOn(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_IsNightlightOn(alt::IVehicle* vehicle);

EXPORT uint8_t Vehicle_GetRoofState(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetRoofState(alt::IVehicle* vehicle, uint8_t state);

EXPORT uint8_t Vehicle_IsFlamethrowerActive(alt::IVehicle* vehicle);

EXPORT float Vehicle_GetLightsMultiplier(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetLightsMultiplier(alt::IVehicle* vehicle, float multiplier);

EXPORT void Vehicle_GetGameStateBase64(alt::IVehicle* vehicle, const char*&text);
EXPORT void Vehicle_LoadGameStateFromBase64(alt::IVehicle* vehicle, const char* base64);

//vehicle health
EXPORT int32_t Vehicle_GetEngineHealth(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetEngineHealth(alt::IVehicle* vehicle, int32_t health);

EXPORT int32_t Vehicle_GetPetrolTankHealth(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetPetrolTankHealth(alt::IVehicle* vehicle, int32_t health);

EXPORT uint8_t Vehicle_GetWheelsCount(alt::IVehicle* vehicle);

EXPORT uint8_t Vehicle_IsWheelBurst(alt::IVehicle* vehicle, uint8_t wheelId);
EXPORT void Vehicle_SetWheelBurst(alt::IVehicle* vehicle, uint8_t wheelId, uint8_t state);

EXPORT uint8_t Vehicle_DoesWheelHasTire(alt::IVehicle* vehicle, uint8_t wheelId);
EXPORT void Vehicle_SetWheelHasTire(alt::IVehicle* vehicle, uint8_t wheelId, uint8_t state);

EXPORT uint8_t Vehicle_IsWheelDetached(alt::IVehicle* vehicle, uint8_t wheelId);
EXPORT void Vehicle_SetWheelDetached(alt::IVehicle* vehicle, uint8_t wheelId, uint8_t state);

EXPORT uint8_t Vehicle_IsWheelOnFire(alt::IVehicle* vehicle, uint8_t wheelId);
EXPORT void Vehicle_SetWheelOnFire(alt::IVehicle* vehicle, uint8_t wheelId, uint8_t state);

EXPORT float Vehicle_GetWheelHealth(alt::IVehicle* vehicle, uint8_t wheelId);
EXPORT void Vehicle_SetWheelHealth(alt::IVehicle* vehicle, uint8_t wheelId, float health);

EXPORT void Vehicle_SetWheelFixed(alt::IVehicle* vehicle, uint8_t wheelId);

EXPORT uint8_t Vehicle_GetRepairsCount(alt::IVehicle* vehicle);

EXPORT uint32_t Vehicle_GetBodyHealth(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetBodyHealth(alt::IVehicle* vehicle, uint32_t health);
EXPORT uint32_t Vehicle_GetBodyAdditionalHealth(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetBodyAdditionalHealth(alt::IVehicle* vehicle, uint32_t health);

EXPORT void Vehicle_GetHealthDataBase64(alt::IVehicle* vehicle, const char*&text);
EXPORT void Vehicle_LoadHealthDataFromBase64(alt::IVehicle* vehicle, const char* base64);

// vehicle damage
EXPORT uint8_t Vehicle_GetPartDamageLevel(alt::IVehicle* vehicle, uint8_t partId);
EXPORT void Vehicle_SetPartDamageLevel(alt::IVehicle* vehicle, uint8_t partId, uint8_t damage);
EXPORT uint8_t Vehicle_GetPartBulletHoles(alt::IVehicle* vehicle, uint8_t partId);
EXPORT void Vehicle_SetPartBulletHoles(alt::IVehicle* vehicle, uint8_t partId, uint8_t shootsCount);
EXPORT uint8_t Vehicle_IsLightDamaged(alt::IVehicle* vehicle, uint8_t lightId);
EXPORT void Vehicle_SetLightDamaged(alt::IVehicle* vehicle, uint8_t lightId, uint8_t isDamaged);
EXPORT uint8_t Vehicle_IsWindowDamaged(alt::IVehicle* vehicle, uint8_t windowId);
EXPORT void Vehicle_SetWindowDamaged(alt::IVehicle* vehicle, uint8_t windowId, uint8_t isDamaged);
EXPORT uint8_t Vehicle_IsSpecialLightDamaged(alt::IVehicle* vehicle, uint8_t specialLightId);
EXPORT void Vehicle_SetSpecialLightDamaged(alt::IVehicle* vehicle, uint8_t specialLightId, uint8_t isDamaged);
EXPORT uint8_t Vehicle_HasArmoredWindows(alt::IVehicle* vehicle);
EXPORT float Vehicle_GetArmoredWindowHealth(alt::IVehicle* vehicle, uint8_t windowId);
EXPORT void Vehicle_SetArmoredWindowHealth(alt::IVehicle* vehicle, uint8_t windowId, float health);
EXPORT uint8_t Vehicle_GetArmoredWindowShootCount(alt::IVehicle* vehicle, uint8_t windowId);
EXPORT void Vehicle_SetArmoredWindowShootCount(alt::IVehicle* vehicle, uint8_t windowId, uint8_t count);
EXPORT uint8_t Vehicle_GetBumperDamageLevel(alt::IVehicle* vehicle, uint8_t bumperId);
EXPORT void Vehicle_SetBumperDamageLevel(alt::IVehicle* vehicle, uint8_t bumperId, uint8_t damageLevel);

EXPORT void Vehicle_GetDamageDataBase64(alt::IVehicle* vehicle, const char*&text);
EXPORT void Vehicle_LoadDamageDataFromBase64(alt::IVehicle* vehicle, const char* base64);

//vehicle script data
EXPORT void Vehicle_SetManualEngineControl(alt::IVehicle* vehicle, uint8_t state);
EXPORT uint8_t Vehicle_IsManualEngineControl(alt::IVehicle* vehicle);

EXPORT void Vehicle_GetScriptDataBase64(alt::IVehicle* vehicle, const char*&base64);
EXPORT void Vehicle_LoadScriptDataFromBase64(alt::IVehicle* vehicle, const char* base64);

EXPORT void Vehicle_GetPositionCoords2(alt::IVehicle* vehicle, float* position_x, float* position_y, float* position_z, float* rotation_x, float* rotation_y, float* rotation_z, int* dimension);

EXPORT void Vehicle_SetNetworkOwner(alt::IVehicle* vehicle, alt::IPlayer* networkOwnerPlayer, uint8_t disableMigration);

EXPORT alt::IVehicle* Vehicle_GetAttached(alt::IVehicle* vehicle);
EXPORT alt::IVehicle* Vehicle_GetAttachedTo(alt::IVehicle* vehicle);

EXPORT void Vehicle_Repair(alt::IVehicle* vehicle);

EXPORT void Vehicle_AttachToEntity_Player(alt::IVehicle* vehicle, alt::IPlayer* entity, int16_t otherBone, int16_t ownBone, position_t pos, rotation_t rot, uint8_t collision, uint8_t noFixedRot);
EXPORT void Vehicle_AttachToEntity_Vehicle(alt::IVehicle* vehicle, alt::IVehicle* entity, int16_t otherBone, int16_t ownBone, position_t pos, rotation_t rot, uint8_t collision, uint8_t noFixedRot);
EXPORT void Vehicle_Detach(alt::IVehicle* vehicle);

EXPORT void Vehicle_GetVelocity(alt::IVehicle* vehicle, position_t &velocity);

EXPORT void Vehicle_SetDriftMode(alt::IVehicle* vehicle, uint8_t state);
EXPORT uint8_t Vehicle_IsDriftMode(alt::IVehicle* vehicle);

EXPORT uint8_t Vehicle_SetSearchLight_Player(alt::IVehicle* vehicle, uint8_t state, alt::IPlayer* spottedEntity);
EXPORT uint8_t Vehicle_SetSearchLight_Vehicle(alt::IVehicle* vehicle, uint8_t state, alt::IVehicle* spottedEntity);

EXPORT uint8_t Vehicle_IsTrainMissionTrain(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainMissionTrain(alt::IVehicle* vehicle, uint8_t state);
EXPORT int8_t Vehicle_GetTrainTrackId(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainTrackId(alt::IVehicle* vehicle, int8_t trackId);
EXPORT alt::IVehicle* Vehicle_GetTrainEngineId(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainEngineId(alt::IVehicle* vehicle, alt::IVehicle* entity);
EXPORT int8_t Vehicle_GetTrainConfigIndex(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainConfigIndex(alt::IVehicle* vehicle, int8_t index);
EXPORT float Vehicle_GetTrainDistanceFromEngine(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainDistanceFromEngine(alt::IVehicle* vehicle, float distanceFromEngine);
EXPORT uint8_t Vehicle_IsTrainEngine(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainIsEngine(alt::IVehicle* vehicle, uint8_t state);
EXPORT uint8_t Vehicle_IsTrainCaboose(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainIsCaboose(alt::IVehicle* vehicle, uint8_t isCaboose);
EXPORT uint8_t Vehicle_GetTrainDirection(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainDirection(alt::IVehicle* vehicle, uint8_t direction);
EXPORT uint8_t Vehicle_HasTrainPassengerCarriages(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainHasPassengerCarriages(alt::IVehicle* vehicle, uint8_t hasPassengerCarriages);
EXPORT uint8_t Vehicle_GetTrainRenderDerailed(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainRenderDerailed(alt::IVehicle* vehicle, uint8_t renderDerailed);
EXPORT uint8_t Vehicle_GetTrainForceDoorsOpen(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainForceDoorsOpen(alt::IVehicle* vehicle, uint8_t forceDoorsOpen);
EXPORT float Vehicle_GetTrainCruiseSpeed(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainCruiseSpeed(alt::IVehicle* vehicle, float cruiseSpeed);
EXPORT int8_t Vehicle_GetTrainCarriageConfigIndex(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainCarriageConfigIndex(alt::IVehicle* vehicle, int8_t carriageConfigIndex);
EXPORT alt::IVehicle* Vehicle_GetTrainLinkedToBackwardId(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainLinkedToBackwardId(alt::IVehicle* vehicle, alt::IVehicle* entity);
EXPORT alt::IVehicle* Vehicle_GetTrainLinkedToForwardId(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetTrainLinkedToForwardId(alt::IVehicle* vehicle, alt::IVehicle* entity);

#ifdef __cplusplus
}
#endif
