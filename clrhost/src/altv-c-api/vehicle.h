#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif

#include <altv-cpp-api/API.h>

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
EXPORT alt::IPlayer* Vehicle_GetDriver(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetMod(alt::IVehicle* vehicle, uint8_t category);
EXPORT uint8_t Vehicle_GetModsCount(alt::IVehicle* vehicle, uint8_t category);
EXPORT bool Vehicle_SetMod(alt::IVehicle* vehicle, uint8_t category, uint8_t id);
EXPORT uint8_t Vehicle_GetModKitsCount(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetModKit(alt::IVehicle* vehicle);
EXPORT bool Vehicle_SetModKit(alt::IVehicle* vehicle, uint8_t id);
EXPORT bool Vehicle_IsPrimaryColorRGB(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetPrimaryColor(alt::IVehicle* vehicle);
EXPORT alt::RGBA Vehicle_GetPrimaryColorRGB(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetPrimaryColor(alt::IVehicle* vehicle, uint8_t color);
EXPORT void Vehicle_SetPrimaryColorRGB(alt::IVehicle* vehicle, alt::RGBA color);
EXPORT bool Vehicle_IsSecondaryColorRGB(alt::IVehicle* vehicle);
EXPORT uint8_t Vehicle_GetSecondaryColor(alt::IVehicle* vehicle);
EXPORT alt::RGBA Vehicle_GetSecondaryColorRGB(alt::IVehicle* vehicle);
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
EXPORT alt::RGBA Vehicle_GetTireSmokeColor(alt::IVehicle* vehicle);
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
EXPORT void Vehicle_GetNeonActive(alt::IVehicle* vehicle, bool &left, bool &right, bool &top, bool &back);
EXPORT void Vehicle_SetNeonActive(alt::IVehicle* vehicle, bool left, bool right, bool top, bool back);
EXPORT alt::RGBA Vehicle_GetNeonColor(alt::IVehicle* vehicle);
EXPORT void Vehicle_SetNeonColor(alt::IVehicle* vehicle, alt::RGBA color);
#ifdef __cplusplus
}
#endif
