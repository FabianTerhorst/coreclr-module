#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif

#include <altv-cpp-api/API.h>
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
EXPORT uint32_t Vehicle_GetModel(alt::IVehicle* vehicle);
EXPORT void Vehicle_GetPosition(alt::IVehicle* vehicle, position_t &position);
EXPORT void Vehicle_SetPosition(alt::IVehicle* vehicle, alt::Position pos);
EXPORT void Vehicle_GetRotation(alt::IVehicle* vehicle, rotation_t &rotation);
EXPORT void Vehicle_SetRotation(alt::IVehicle* vehicle, alt::Rotation rot);
EXPORT int16_t Vehicle_GetDimension(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetDimension(alt::IVehicle* vehicle, uint16_t dimension);
EXPORT void Vehicle_GetMetaData(alt::IVehicle* vehicle, const char* key, alt::MValue &val);
EXPORT void Vehicle_SetMetaData(alt::IVehicle* vehicle, const char* key, alt::MValue* val);
EXPORT void Vehicle_GetSyncedMetaData(alt::IVehicle* vehicle, const char* key, alt::MValue &val);
EXPORT void Vehicle_SetSyncedMetaData(alt::IVehicle* vehicle, const char* key, alt::MValue* val);
// Vehicle
EXPORT alt::IPlayer* Vehicle_GetDriver(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetMod(alt::IVehicle* vehicle, uint8_t category);
EXPORT uint8_t Vehicle_GetModsCount(alt::IVehicle* vehicle, uint8_t category);
EXPORT bool Vehicle_SetMod(alt::IVehicle* vehicle, uint8_t category, uint8_t id);
EXPORT uint8_t Vehicle_GetModKitsCount(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetModKit(alt::IVehicle* vehicle);
EXPORT bool Vehicle_SetModKit(alt::IVehicle* vehicle, uint8_t id);
EXPORT bool Vehicle_IsPrimaryColorRGB(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetPrimaryColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_GetPrimaryColorRGB(alt::IVehicle* vehicle, rgba_t &primaryColor);
EXPORT void Vehicle_SetPrimaryColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT void Vehicle_SetPrimaryColorRGB(alt::IVehicle* vehicle, alt::RGBA color);
EXPORT bool Vehicle_IsSecondaryColorRGB(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetSecondaryColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_GetSecondaryColorRGB(alt::IVehicle* vehicle, rgba_t &secondaryColor);
EXPORT void Vehicle_SetSecondaryColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT void Vehicle_SetSecondaryColorRGB(alt::IVehicle* vehicle, alt::RGBA color);
EXPORT uint8_t Vehicle_GetPearlColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetPearlColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT uint8_t Vehicle_GetWheelColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetWheelColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT uint8_t Vehicle_GetInteriorColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetInteriorColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT uint8_t Vehicle_GetDashboardColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetDashboardColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT bool Vehicle_IsTireSmokeColorCustom(alt::IVehicle* vehicle);
EXPORT void Vehicle_GetTireSmokeColor(alt::IVehicle* vehicle, rgba_t &tireSmokeColor);
EXPORT void Vehicle_SetTireSmokeColor(alt::IVehicle* vehicle, alt::RGBA color);
EXPORT uint8_t Vehicle_GetWheelType(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetWheelVariation(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetWheels(alt::IVehicle* vehicle, uint8_t type, uint8_t variation);
EXPORT bool Vehicle_GetCustomTires(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetCustomTires(alt::IVehicle* vehicle, bool state);
EXPORT uint8_t Vehicle_GetSpecialDarkness(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetSpecialDarkness(alt::IVehicle* vehicle, uint8_t value);
EXPORT uint32_t Vehicle_GetNumberPlateIndex(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetNumberPlateIndex(alt::IVehicle* vehicle, uint32_t index);
EXPORT void Vehicle_GetNumberPlateText(alt::IVehicle* vehicle, const char*&text);
EXPORT void Vehicle_SetNumberPlateText(alt::IVehicle* vehicle, const char* text);
EXPORT uint8_t Vehicle_GetWindowTint(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetWindowTint(alt::IVehicle* vehicle, uint8_t tint);
EXPORT uint8_t Vehicle_GetDirtLevel(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetDirtLevel(alt::IVehicle* vehicle, uint8_t level);
EXPORT bool Vehicle_IsExtraOn(alt::IVehicle* vehicle, uint8_t extraID);
EXPORT void Vehicle_ToggleExtra(alt::IVehicle* vehicle, uint8_t extraID, bool state);
EXPORT bool Vehicle_IsNeonActive(alt::IVehicle* vehicle);
EXPORT void Vehicle_GetNeonActive(alt::IVehicle* vehicle, bool* left, bool* right, bool* front, bool* back);
EXPORT void Vehicle_SetNeonActive(alt::IVehicle* vehicle, bool left, bool right, bool front, bool back);
EXPORT void Vehicle_GetNeonColor(alt::IVehicle* vehicle, rgba_t &neonColor);
EXPORT void Vehicle_SetNeonColor(alt::IVehicle* vehicle, alt::RGBA color);

//TODO: WIP vehicle api's

EXPORT bool Vehicle_IsEngineOn(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetEngineOn(alt::IVehicle* vehicle, bool state);

EXPORT bool Vehicle_IsHandbrakeActive(alt::IVehicle* vehicle);

EXPORT uint8_t Vehicle_GetHeadlightColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetHeadlightColor(alt::IVehicle* vehicle, uint8_t color);

EXPORT bool Vehicle_IsSirenActive(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetSirenActive(alt::IVehicle* vehicle, bool state);

// TODO document available values. Enum?
EXPORT uint8_t Vehicle_GetLockState(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetLockState(alt::IVehicle* vehicle, uint8_t state);

// TODO document available values. Enum?
EXPORT uint8_t Vehicle_GetDoorState(alt::IVehicle* vehicle, uint8_t doorId);
EXPORT void Vehicle_SetDoorState(alt::IVehicle* vehicle, uint8_t doorId, uint8_t state);

EXPORT bool Vehicle_IsWindowOpened(alt::IVehicle* vehicle, uint8_t windowId);
EXPORT void Vehicle_SetWindowOpened(alt::IVehicle* vehicle, uint8_t windowId, bool state);

EXPORT bool Vehicle_IsDaylightOn(alt::IVehicle* vehicle);
EXPORT bool Vehicle_IsNightlightOn(alt::IVehicle* vehicle);

EXPORT bool Vehicle_IsRoofOpened(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetRoofOpened(alt::IVehicle* vehicle, bool state);

EXPORT bool Vehicle_IsFlamethrowerActive(alt::IVehicle* vehicle);

EXPORT void Vehicle_GetGameStateBase64(alt::IVehicle* vehicle, const char*&text);
EXPORT void Vehicle_LoadGameStateFromBase64(alt::IVehicle* vehicle, const char* base64);

//vehicle health
EXPORT int32_t Vehicle_GetEngineHealth(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetEngineHealth(alt::IVehicle* vehicle, int32_t health);

EXPORT int32_t Vehicle_GetPetrolTankHealth(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetPetrolTankHealth(alt::IVehicle* vehicle, int32_t health);

EXPORT uint8_t Vehicle_GetWheelsCount(alt::IVehicle* vehicle);

EXPORT bool Vehicle_IsWheelBurst(alt::IVehicle* vehicle, uint8_t wheelId);
EXPORT void Vehicle_SetWheelBurst(alt::IVehicle* vehicle, uint8_t wheelId, bool state);

EXPORT bool Vehicle_DoesWheelHasTire(alt::IVehicle* vehicle, uint8_t wheelId);
EXPORT void Vehicle_SetWheelHasTire(alt::IVehicle* vehicle, uint8_t wheelId, bool state);

EXPORT float Vehicle_GetWheelHealth(alt::IVehicle* vehicle, uint8_t wheelId);
EXPORT void Vehicle_SetWheelHealth(alt::IVehicle* vehicle, uint8_t wheelId, float health);

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
EXPORT bool Vehicle_IsLightDamaged(alt::IVehicle* vehicle, uint8_t lightId);
EXPORT void Vehicle_SetLightDamaged(alt::IVehicle* vehicle, uint8_t lightId, bool isDamaged);
EXPORT bool Vehicle_IsWindowDamaged(alt::IVehicle* vehicle, uint8_t windowId);
EXPORT void Vehicle_SetWindowDamaged(alt::IVehicle* vehicle, uint8_t windowId, bool isDamaged);
EXPORT bool Vehicle_IsSpecialLightDamaged(alt::IVehicle* vehicle, uint8_t specialLightId);
EXPORT void Vehicle_SetSpecialLightDamaged(alt::IVehicle* vehicle, uint8_t specialLightId, bool isDamaged);
EXPORT bool Vehicle_HasArmoredWindows(alt::IVehicle* vehicle);
EXPORT float Vehicle_GetArmoredWindowHealth(alt::IVehicle* vehicle, uint8_t windowId);
EXPORT void Vehicle_SetArmoredWindowHealth(alt::IVehicle* vehicle, uint8_t windowId, float health);
EXPORT uint8_t Vehicle_GetArmoredWindowShootCount(alt::IVehicle* vehicle, uint8_t windowId);
EXPORT void Vehicle_SetArmoredWindowShootCount(alt::IVehicle* vehicle, uint8_t windowId, uint8_t count);
EXPORT uint8_t Vehicle_GetBumperDamageLevel(alt::IVehicle* vehicle, uint8_t bumperId);
EXPORT void Vehicle_SetBumperDamageLevel(alt::IVehicle* vehicle, uint8_t bumperId, uint8_t damageLevel);

EXPORT void Vehicle_GetDamageDataBase64(alt::IVehicle* vehicle, const char*&text);
EXPORT void Vehicle_LoadDamageDataFromBase64(alt::IVehicle* vehicle, const char* base64);

#ifdef __cplusplus
}
#endif
