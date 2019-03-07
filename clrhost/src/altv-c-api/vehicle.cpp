#include "vehicle.h"

// Entity

uint16_t Vehicle_GetID(alt::IVehicle* entity) {
    return entity->GetID();
}

uint32_t Vehicle_GetModel(alt::IVehicle* vehicle) {
    return vehicle->GetModel();
}

void Vehicle_GetPosition(alt::IVehicle* entity, position_t &position) {
    auto vehiclePosition = entity->GetPosition();
    position.x = vehiclePosition.x;
    position.y = vehiclePosition.y;
    position.z = vehiclePosition.z;
}

void Vehicle_SetPosition(alt::IVehicle* entity, alt::Position pos) {
    entity->SetPosition(pos);
}

void Vehicle_GetRotation(alt::IVehicle* entity, rotation_t &rotation) {
    auto checkpointRotation = entity->GetRotation();
    rotation.roll = checkpointRotation.roll;
    rotation.pitch = checkpointRotation.pitch;
    rotation.yaw = checkpointRotation.yaw;
}

void Vehicle_SetRotation(alt::IVehicle* entity, alt::Rotation rot) {
    entity->SetRotation(rot);
}

int16_t Vehicle_GetDimension(alt::IVehicle* entity) {
    return entity->GetDimension();
}

void Vehicle_SetDimension(alt::IVehicle* entity, uint16_t dimension) {
    entity->SetDimension(dimension);
}

void Vehicle_GetMetaData(alt::IVehicle* entity, const char* key, alt::MValue &val) {
    val = entity->GetMetaData(key);
}

void Vehicle_SetMetaData(alt::IVehicle* entity, const char* key, alt::MValue* val) {
    entity->SetMetaData(key, *val);
}

void Vehicle_GetSyncedMetaData(alt::IVehicle* entity, const char* key, alt::MValue &val) {
    val = entity->GetSyncedMetaData(key);
}

void Vehicle_SetSyncedMetaData(alt::IVehicle* entity, const char* key, alt::MValue* val) {
    entity->SetSyncedMetaData(key, *val);
}

// Vehicle

alt::IPlayer* Vehicle_GetDriver(alt::IVehicle* vehicle) {
    return vehicle->GetDriver();
}

uint8_t Vehicle_GetMod(alt::IVehicle* vehicle, uint8_t category) {
    return vehicle->GetMod(category);
}

uint8_t Vehicle_GetModsCount(alt::IVehicle* vehicle, uint8_t category) {
    return vehicle->GetModsCount(category);
}

bool Vehicle_SetMod(alt::IVehicle* vehicle, uint8_t category, uint8_t id) {
    return vehicle->SetMod(category, id);
}

uint8_t Vehicle_GetModKitsCount(alt::IVehicle* vehicle) {
    return vehicle->GetModKitsCount();
}

uint8_t Vehicle_GetModKit(alt::IVehicle* vehicle) {
    return vehicle->GetModKit();
}

bool Vehicle_SetModKit(alt::IVehicle* vehicle, uint8_t id) {
    return vehicle->SetModKit(id);
}

bool Vehicle_IsPrimaryColorRGB(alt::IVehicle* vehicle) {
    return vehicle->IsPrimaryColorRGB();
}

uint8_t Vehicle_GetPrimaryColor(alt::IVehicle* vehicle) {
    return vehicle->GetPrimaryColor();
}

void Vehicle_GetPrimaryColorRGB(alt::IVehicle* vehicle, rgba_t &primaryColor) {
    auto vehiclePrimaryColor = vehicle->GetPrimaryColorRGB();
    primaryColor.r = vehiclePrimaryColor.r;
    primaryColor.g = vehiclePrimaryColor.g;
    primaryColor.b = vehiclePrimaryColor.b;
    primaryColor.a = vehiclePrimaryColor.a;
}

void Vehicle_SetPrimaryColor(alt::IVehicle* vehicle, uint8_t color) {
    vehicle->SetPrimaryColor(color);
}

void Vehicle_SetPrimaryColorRGB(alt::IVehicle* vehicle, alt::RGBA color) {
    vehicle->SetPrimaryColorRGB(color);
}

bool Vehicle_IsSecondaryColorRGB(alt::IVehicle* vehicle) {
    return vehicle->IsSecondaryColorRGB();
}

uint8_t Vehicle_GetSecondaryColor(alt::IVehicle* vehicle) {
    return vehicle->GetSecondaryColor();
}

void Vehicle_GetSecondaryColorRGB(alt::IVehicle* vehicle, rgba_t &secondaryColor) {
    auto vehicleSecondaryColor = vehicle->GetSecondaryColorRGB();
    secondaryColor.r = vehicleSecondaryColor.r;
    secondaryColor.g = vehicleSecondaryColor.g;
    secondaryColor.b = vehicleSecondaryColor.b;
    secondaryColor.a = vehicleSecondaryColor.a;
}

void Vehicle_SetSecondaryColor(alt::IVehicle* vehicle, uint8_t color) {
    vehicle->SetSecondaryColor(color);
}

void Vehicle_SetSecondaryColorRGB(alt::IVehicle* vehicle, alt::RGBA color) {
    vehicle->SetSecondaryColorRGB(color);
}

uint8_t Vehicle_GetPearlColor(alt::IVehicle* vehicle) {
    return vehicle->GetPearlColor();
}

void Vehicle_SetPearlColor(alt::IVehicle* vehicle, uint8_t color) {
    vehicle->SetPearlColor(color);
}

uint8_t Vehicle_GetWheelColor(alt::IVehicle* vehicle) {
    return vehicle->GetWheelColor();
}

void Vehicle_SetWheelColor(alt::IVehicle* vehicle, uint8_t color) {
    vehicle->SetWheelColor(color);
}

uint8_t Vehicle_GetInteriorColor(alt::IVehicle* vehicle) {
    return vehicle->GetInteriorColor();
}

void Vehicle_SetInteriorColor(alt::IVehicle* vehicle, uint8_t color) {
    vehicle->SetInteriorColor(color);
}

uint8_t Vehicle_GetDashboardColor(alt::IVehicle* vehicle) {
    return vehicle->GetDashboardColor();
}

void Vehicle_SetDashboardColor(alt::IVehicle* vehicle, uint8_t color) {
    vehicle->SetDashboardColor(color);
}

bool Vehicle_IsTireSmokeColorCustom(alt::IVehicle* vehicle) {
    return vehicle->IsTireSmokeColorCustom();
}

void Vehicle_GetTireSmokeColor(alt::IVehicle* vehicle, rgba_t &tireSmokeColor) {
    auto vehicleTireSmokeColor = vehicle->GetTireSmokeColor();
    tireSmokeColor.r = vehicleTireSmokeColor.r;
    tireSmokeColor.g = vehicleTireSmokeColor.g;
    tireSmokeColor.b = vehicleTireSmokeColor.b;
    tireSmokeColor.a = vehicleTireSmokeColor.a;
}

void Vehicle_SetTireSmokeColor(alt::IVehicle* vehicle, alt::RGBA color) {
    vehicle->SetTireSmokeColor(color);
}

uint8_t Vehicle_GetWheelType(alt::IVehicle* vehicle) {
    return vehicle->GetWheelType();
}

uint8_t Vehicle_GetWheelVariation(alt::IVehicle* vehicle) {
    return vehicle->GetWheelVariation();
}

void Vehicle_SetWheels(alt::IVehicle* vehicle, uint8_t type, uint8_t variation) {
    vehicle->SetWheels(type, variation);
}

bool Vehicle_GetCustomTires(alt::IVehicle* vehicle) {
    return vehicle->GetCustomTires();
}

void Vehicle_SetCustomTires(alt::IVehicle* vehicle, bool state) {
    return vehicle->SetCustomTires(state);
}

uint8_t Vehicle_GetSpecialDarkness(alt::IVehicle* vehicle) {
    return vehicle->GetSpecialDarkness();
}

void Vehicle_SetSpecialDarkness(alt::IVehicle* vehicle, uint8_t value) {
    vehicle->SetSpecialDarkness(value);
}

uint32_t Vehicle_GetNumberPlateIndex(alt::IVehicle* vehicle) {
    return vehicle->GetNumberPlateIndex();
}

void Vehicle_SetNumberPlateIndex(alt::IVehicle* vehicle, uint32_t index) {
    vehicle->SetNumberPlateIndex(index);
}

void Vehicle_GetNumberPlateText(alt::IVehicle* vehicle, const char*&text) {
    text = vehicle->GetNumberPlateText().CStr();
}

void Vehicle_SetNumberPlateText(alt::IVehicle* vehicle, const char* text) {
    vehicle->SetNumberPlateText(text);
}

uint8_t Vehicle_GetWindowTint(alt::IVehicle* vehicle) {
    return vehicle->GetWindowTint();
}

void Vehicle_SetWindowTint(alt::IVehicle* vehicle, uint8_t tint) {
    vehicle->SetWindowTint(tint);
}

uint8_t Vehicle_GetDirtLevel(alt::IVehicle* vehicle) {
    return vehicle->GetDirtLevel();
}

void Vehicle_SetDirtLevel(alt::IVehicle* vehicle, uint8_t level) {
    vehicle->SetDirtLevel(level);
}

bool Vehicle_IsExtraOn(alt::IVehicle* vehicle, uint8_t extraID) {
    return vehicle->IsExtraOn(extraID);
}

void Vehicle_ToggleExtra(alt::IVehicle* vehicle, uint8_t extraID, bool state) {
    vehicle->ToggleExtra(extraID, state);
}

bool Vehicle_IsNeonActive(alt::IVehicle* vehicle) {
    return vehicle->IsNeonActive();
}

void Vehicle_GetNeonActive(alt::IVehicle* vehicle, bool* left, bool* right, bool* front, bool* back) {
    vehicle->GetNeonActive(left, right, front, back);
}

void Vehicle_SetNeonActive(alt::IVehicle* vehicle, bool left, bool right, bool front, bool back) {
    vehicle->SetNeonActive(left, right, front, back);
}

void Vehicle_GetNeonColor(alt::IVehicle* vehicle, rgba_t &neonColor) {
    auto vehicleNeonColor = vehicle->GetNeonColor();
    neonColor.r = vehicleNeonColor.r;
    neonColor.g = vehicleNeonColor.g;
    neonColor.b = vehicleNeonColor.b;
    neonColor.a = vehicleNeonColor.a;
}

void Vehicle_SetNeonColor(alt::IVehicle* vehicle, alt::RGBA color) {
    return vehicle->SetNeonColor(color);
}

bool Vehicle_IsEngineOn(alt::IVehicle* vehicle) {
    return vehicle->IsEngineOn();
}

void Vehicle_SetEngineOn(alt::IVehicle* vehicle, bool state) {
    vehicle->SetEngineOn(state);
}

bool Vehicle_IsHandbrakeActive(alt::IVehicle* vehicle) {
    return vehicle->IsHandbrakeActive();
}

uint8_t Vehicle_GetHeadlightColor(alt::IVehicle* vehicle) {
    return vehicle->GetHeadlightColor();
}

void Vehicle_SetHeadlightColor(alt::IVehicle* vehicle, uint8_t color) {
    vehicle->SetHeadlightColor(color);
}

bool Vehicle_IsSirenActive(alt::IVehicle* vehicle) {
    return vehicle->IsSirenActive();
}

void Vehicle_SetSirenActive(alt::IVehicle* vehicle, bool state) {
    vehicle->SetSirenActive(state);
}

uint8_t Vehicle_GetLockState(alt::IVehicle* vehicle) {
    return vehicle->GetLockState();
}

void Vehicle_SetLockState(alt::IVehicle* vehicle, uint8_t state) {
    vehicle->SetLockState(state);
}

uint8_t Vehicle_GetDoorState(alt::IVehicle* vehicle, uint8_t doorId) {
    return vehicle->GetDoorState(doorId);
}

void Vehicle_SetDoorState(alt::IVehicle* vehicle, uint8_t doorId, uint8_t state) {
    vehicle->SetDoorState(doorId, state);
}

bool Vehicle_IsWindowOpened(alt::IVehicle* vehicle, uint8_t windowId) {
    return vehicle->IsWindowOpened(windowId);
}

void Vehicle_SetWindowOpened(alt::IVehicle* vehicle, uint8_t windowId, bool state) {
    vehicle->SetWindowOpened(windowId, state);
}

bool Vehicle_IsDaylightOn(alt::IVehicle* vehicle) {
    return vehicle->IsDaylightOn();
}

bool Vehicle_IsNightlightOn(alt::IVehicle* vehicle) {
    return vehicle->IsNightlightOn();
}

bool Vehicle_IsRoofOpened(alt::IVehicle* vehicle) {
    return vehicle->IsRoofOpened();
}

void Vehicle_SetRoofOpened(alt::IVehicle* vehicle, bool state) {
    vehicle->SetRoofOpened(state);
}

bool Vehicle_IsFlamethrowerActive(alt::IVehicle* vehicle) {
    return vehicle->IsFlamethrowerActive();
}

void Vehicle_GetGameStateBase64(alt::IVehicle* vehicle, const char*&text) {
    text = vehicle->GetGameStateBase64().CStr();
}

void Vehicle_LoadGameStateFromBase64(alt::IVehicle* vehicle, const char* base64) {
    vehicle->LoadGameStateFromBase64(base64);
}

int32_t Vehicle_GetEngineHealth(alt::IVehicle* vehicle) {
    return vehicle->GetEngineHealth();
}

void Vehicle_SetEngineHealth(alt::IVehicle* vehicle, int32_t health) {
    vehicle->SetEngineHealth(health);
}

int32_t Vehicle_GetPetrolTankHealth(alt::IVehicle* vehicle) {
    return vehicle->GetPetrolTankHealth();
}

void Vehicle_SetPetrolTankHealth(alt::IVehicle* vehicle, int32_t health) {
    vehicle->SetPetrolTankHealth(health);
}

uint8_t Vehicle_GetWheelsCount(alt::IVehicle* vehicle) {
    return vehicle->GetWheelsCount();
}

bool Vehicle_IsWheelBurst(alt::IVehicle* vehicle, uint8_t wheelId) {
    return vehicle->IsWheelBurst(wheelId);
}

void Vehicle_SetWheelBurst(alt::IVehicle* vehicle, uint8_t wheelId, bool state) {
    vehicle->SetWheelBurst(wheelId, state);
}

bool Vehicle_DoesWheelHasTire(alt::IVehicle* vehicle, uint8_t wheelId) {
    return vehicle->DoesWheelHasTire(wheelId);
}

void Vehicle_SetWheelHasTire(alt::IVehicle* vehicle, uint8_t wheelId, bool state) {
    vehicle->SetWheelHasTire(wheelId, state);
}

float Vehicle_GetWheelHealth(alt::IVehicle* vehicle, uint8_t wheelId) {
    return vehicle->GetWheelHealth(wheelId);
}

void Vehicle_SetWheelHealth(alt::IVehicle* vehicle, uint8_t wheelId, float health) {
    vehicle->SetWheelHealth(wheelId, health);
}

uint8_t Vehicle_GetRepairsCount(alt::IVehicle* vehicle) {
    return vehicle->GetRepairsCount();
}

uint32_t Vehicle_GetBodyHealth(alt::IVehicle* vehicle) {
    return vehicle->GetBodyHealth();
}

void Vehicle_SetBodyHealth(alt::IVehicle* vehicle, uint32_t health) {
    vehicle->SetBodyHealth(health);
}

uint32_t Vehicle_GetBodyAdditionalHealth(alt::IVehicle* vehicle) {
    return vehicle->GetBodyAdditionalHealth();
}

void Vehicle_SetBodyAdditionalHealth(alt::IVehicle* vehicle, uint32_t health) {
    vehicle->SetBodyAdditionalHealth(health);
}

void Vehicle_GetHealthDataBase64(alt::IVehicle* vehicle, const char*&text) {
    text = vehicle->GetHealthDataBase64().CStr();
}

void Vehicle_LoadHealthDataFromBase64(alt::IVehicle* vehicle, const char* base64) {
    vehicle->LoadHealthDataFromBase64(base64);
}

uint8_t Vehicle_GetPartDamageLevel(alt::IVehicle* vehicle, uint8_t partId) {
    return vehicle->GetPartDamageLevel(partId);
}

void Vehicle_SetPartDamageLevel(alt::IVehicle* vehicle, uint8_t partId, uint8_t damage) {
    vehicle->SetPartDamageLevel(partId, damage);
}

uint8_t Vehicle_GetPartBulletHoles(alt::IVehicle* vehicle, uint8_t partId) {
    return vehicle->GetPartBulletHoles(partId);
}

void Vehicle_SetPartBulletHoles(alt::IVehicle* vehicle, uint8_t partId, uint8_t shootsCount) {
    vehicle->SetPartBulletHoles(partId, shootsCount);
}

bool Vehicle_IsLightDamaged(alt::IVehicle* vehicle, uint8_t lightId) {
    return vehicle->IsLightDamaged(lightId);
}

void Vehicle_SetLightDamaged(alt::IVehicle* vehicle, uint8_t lightId, bool isDamaged) {
    vehicle->SetLightDamaged(lightId, isDamaged);
}

bool Vehicle_IsWindowDamaged(alt::IVehicle* vehicle, uint8_t windowId) {
    return vehicle->IsWindowDamaged(windowId);
}

void Vehicle_SetWindowDamaged(alt::IVehicle* vehicle, uint8_t windowId, bool isDamaged) {
    vehicle->SetWindowDamaged(windowId, isDamaged);
}

bool Vehicle_IsSpecialLightDamaged(alt::IVehicle* vehicle, uint8_t specialLightId) {
    return vehicle->IsSpecialLightDamaged(specialLightId);
}

void Vehicle_SetSpecialLightDamaged(alt::IVehicle* vehicle, uint8_t specialLightId, bool isDamaged) {
    vehicle->SetSpecialLightDamaged(specialLightId, isDamaged);
}

bool Vehicle_HasArmoredWindows(alt::IVehicle* vehicle) {
    return vehicle->HasArmoredWindows();
}

float Vehicle_GetArmoredWindowHealth(alt::IVehicle* vehicle, uint8_t windowId) {
    return vehicle->GetArmoredWindowHealth(windowId);
}

void Vehicle_SetArmoredWindowHealth(alt::IVehicle* vehicle, uint8_t windowId, float health) {
    vehicle->SetArmoredWindowHealth(windowId, health);
}

uint8_t Vehicle_GetArmoredWindowShootCount(alt::IVehicle* vehicle, uint8_t windowId) {
    return vehicle->GetArmoredWindowShootCount(windowId);
}

void Vehicle_SetArmoredWindowShootCount(alt::IVehicle* vehicle, uint8_t windowId, uint8_t count) {
    vehicle->SetArmoredWindowShootCount(windowId, count);
}

uint8_t Vehicle_GetBumperDamageLevel(alt::IVehicle* vehicle, uint8_t bumperId) {
    return vehicle->GetBumperDamageLevel(bumperId);
}

void Vehicle_SetBumperDamageLevel(alt::IVehicle* vehicle, uint8_t bumperId, uint8_t damageLevel) {
    vehicle->SetBumperDamageLevel(bumperId, damageLevel);
}

void Vehicle_GetDamageDataBase64(alt::IVehicle* vehicle, const char*&text) {
    text = vehicle->GetDamageDataBase64().CStr();
}

void Vehicle_LoadDamageDataFromBase64(alt::IVehicle* vehicle, const char* base64) {
    vehicle->LoadDamageDataFromBase64(base64);
}
