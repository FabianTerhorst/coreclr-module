#include "vehicle.h"

// Entity

uint16_t Vehicle_GetID(alt::IVehicle* entity) {
    return entity->GetID();
}

alt::IPlayer* Vehicle_GetNetworkOwner(alt::IVehicle* vehicle) {
    return vehicle->GetNetworkOwner().Get();
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

void Vehicle_SetPosition(alt::IVehicle* entity, position_t pos) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    entity->SetPosition(position);
}

void Vehicle_GetRotation(alt::IVehicle* entity, rotation_t &rotation) {
    auto checkpointRotation = entity->GetRotation();
    rotation.roll = checkpointRotation.roll;
    rotation.pitch = checkpointRotation.pitch;
    rotation.yaw = checkpointRotation.yaw;
}

void Vehicle_SetRotation(alt::IVehicle* entity, rotation_t rot) {
    alt::Rotation rotation;
    rotation.roll = rot.roll;
    rotation.pitch = rot.pitch;
    rotation.yaw = rot.yaw;
    entity->SetRotation(rotation);
}

int32_t Vehicle_GetDimension(alt::IVehicle* entity) {
    return entity->GetDimension();
}

void Vehicle_SetDimension(alt::IVehicle* entity, int32_t dimension) {
    entity->SetDimension(dimension);
}

alt::MValueConst* Vehicle_GetMetaData(alt::IVehicle* vehicle, const char* key) {
    return new alt::MValueConst(vehicle->GetMetaData(key));
}

void Vehicle_SetMetaData(alt::IVehicle* entity, const char* key, alt::MValueConst* val) {
    if (val == nullptr) return;
    entity->SetMetaData(key, val->Get()->Clone());
}

uint8_t Vehicle_HasMetaData(alt::IVehicle* vehicle, const char* key) {
    return vehicle->HasMetaData(key);
}

void Vehicle_DeleteMetaData(alt::IVehicle* vehicle, const char* key) {
    vehicle->DeleteMetaData(key);
}

alt::MValueConst* Vehicle_GetSyncedMetaData(alt::IVehicle* vehicle, const char* key) {
    return new alt::MValueConst(vehicle->GetSyncedMetaData(key));
}

void Vehicle_SetSyncedMetaData(alt::IVehicle* entity, const char* key, alt::MValueConst* val) {
    if (val == nullptr) return;
    entity->SetSyncedMetaData(key, val->Get()->Clone());
}

uint8_t Vehicle_HasSyncedMetaData(alt::IVehicle* vehicle, const char* key) {
    return vehicle->HasSyncedMetaData(key);
}

void Vehicle_DeleteSyncedMetaData(alt::IVehicle* vehicle, const char* key) {
    vehicle->DeleteSyncedMetaData(key);
}

alt::MValueConst* Vehicle_GetStreamSyncedMetaData(alt::IVehicle* vehicle, const char* key) {
    return new alt::MValueConst(vehicle->GetStreamSyncedMetaData(key));
}

void Vehicle_SetStreamSyncedMetaData(alt::IVehicle* entity, const char* key, alt::MValueConst* val) {
    if (val == nullptr) return;
    entity->SetStreamSyncedMetaData(key, val->Get()->Clone());
}

uint8_t Vehicle_HasStreamSyncedMetaData(alt::IVehicle* vehicle, const char* key) {
    return vehicle->HasStreamSyncedMetaData(key);
}

void Vehicle_DeleteStreamSyncedMetaData(alt::IVehicle* vehicle, const char* key) {
    vehicle->DeleteStreamSyncedMetaData(key);
}

void Vehicle_AddRef(alt::IVehicle* vehicle) {
    vehicle->AddRef();
}

void Vehicle_RemoveRef(alt::IVehicle* vehicle) {
    vehicle->RemoveRef();
}

uint8_t Vehicle_GetVisible(alt::IVehicle* vehicle) {
    return vehicle->GetVisible();
}

void Vehicle_SetVisible(alt::IVehicle* vehicle, uint8_t state) {
    vehicle->SetVisible(state);
}

uint8_t Vehicle_GetStreamed(alt::IVehicle* vehicle) {
    return vehicle->GetStreamed();
}

void Vehicle_SetStreamed(alt::IVehicle* vehicle, uint8_t state) {
    vehicle->SetStreamed(state);
}

// Vehicle

alt::IPlayer* Vehicle_GetDriver(alt::IVehicle* vehicle) {
    return vehicle->GetDriver().Get();
}

uint8_t Vehicle_IsDestroyed(alt::IVehicle* vehicle) {
    return vehicle->IsDestroyed();
}

uint8_t Vehicle_GetMod(alt::IVehicle* vehicle, uint8_t category) {
    return vehicle->GetMod(category);
}

uint8_t Vehicle_GetModsCount(alt::IVehicle* vehicle, uint8_t category) {
    return vehicle->GetModsCount(category);
}

uint8_t Vehicle_SetMod(alt::IVehicle* vehicle, uint8_t category, uint8_t id) {
    return vehicle->SetMod(category, id);
}

uint8_t Vehicle_GetModKitsCount(alt::IVehicle* vehicle) {
    return vehicle->GetModKitsCount();
}

uint8_t Vehicle_GetModKit(alt::IVehicle* vehicle) {
    return vehicle->GetModKit();
}

uint8_t Vehicle_SetModKit(alt::IVehicle* vehicle, uint8_t id) {
    return vehicle->SetModKit(id);
}

uint8_t Vehicle_IsPrimaryColorRGB(alt::IVehicle* vehicle) {
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

void Vehicle_SetPrimaryColorRGB(alt::IVehicle* vehicle, rgba_t primaryColor) {
    alt::RGBA color;
    color.r = primaryColor.r;
    color.g = primaryColor.g;
    color.b = primaryColor.b;
    color.a = primaryColor.a;
    vehicle->SetPrimaryColorRGB(color);
}

uint8_t Vehicle_IsSecondaryColorRGB(alt::IVehicle* vehicle) {
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

void Vehicle_SetSecondaryColorRGB(alt::IVehicle* vehicle,rgba_t secondaryColor) {
    alt::RGBA color;
    color.r = secondaryColor.r;
    color.g = secondaryColor.g;
    color.b = secondaryColor.b;
    color.a = secondaryColor.a;
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

uint8_t Vehicle_IsTireSmokeColorCustom(alt::IVehicle* vehicle) {
    return vehicle->IsTireSmokeColorCustom();
}

void Vehicle_GetTireSmokeColor(alt::IVehicle* vehicle, rgba_t &tireSmokeColor) {
    auto vehicleTireSmokeColor = vehicle->GetTireSmokeColor();
    tireSmokeColor.r = vehicleTireSmokeColor.r;
    tireSmokeColor.g = vehicleTireSmokeColor.g;
    tireSmokeColor.b = vehicleTireSmokeColor.b;
    tireSmokeColor.a = vehicleTireSmokeColor.a;
}

void Vehicle_SetTireSmokeColor(alt::IVehicle* vehicle, rgba_t tireSmokeColor) {
    alt::RGBA color;
    color.r = tireSmokeColor.r;
    color.g = tireSmokeColor.g;
    color.b = tireSmokeColor.b;
    color.a = tireSmokeColor.a;
    vehicle->SetTireSmokeColor(color);
}

uint8_t Vehicle_GetWheelType(alt::IVehicle* vehicle) {
    return vehicle->GetWheelType();
}

uint8_t Vehicle_GetWheelVariation(alt::IVehicle* vehicle) {
    return vehicle->GetWheelVariation();
}

uint8_t Vehicle_GetRearWheelVariation(alt::IVehicle* vehicle) {
    return vehicle->GetRearWheelVariation();
}

void Vehicle_SetWheels(alt::IVehicle* vehicle, uint8_t type, uint8_t variation) {
    vehicle->SetWheels(type, variation);
}

void Vehicle_SetRearWheels(alt::IVehicle* vehicle, uint8_t variation) {
    vehicle->SetRearWheels(variation);
}

uint8_t Vehicle_GetCustomTires(alt::IVehicle* vehicle) {
    return vehicle->GetCustomTires();
}

void Vehicle_SetCustomTires(alt::IVehicle* vehicle, uint8_t state) {
    return vehicle->SetCustomTires(state);
}

uint8_t Vehicle_GetSpecialDarkness(alt::IVehicle* vehicle) {
    return vehicle->GetSpecialDarkness();
}

void Vehicle_SetSpecialDarkness(alt::IVehicle* vehicle, uint8_t value) {
    vehicle->SetSpecialDarkness(value);
}

uint32_t Vehicle_GetNumberplateIndex(alt::IVehicle* vehicle) {
    return vehicle->GetNumberplateIndex();
}

void Vehicle_SetNumberplateIndex(alt::IVehicle* vehicle, uint32_t index) {
    vehicle->SetNumberplateIndex(index);
}

void Vehicle_GetNumberplateText(alt::IVehicle* vehicle, const char*&text) {
    text = vehicle->GetNumberplateText().CStr();
}

void Vehicle_SetNumberplateText(alt::IVehicle* vehicle, const char* text) {
    vehicle->SetNumberplateText(text);
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

uint8_t Vehicle_IsExtraOn(alt::IVehicle* vehicle, uint8_t extraID) {
    return vehicle->IsExtraOn(extraID);
}

void Vehicle_ToggleExtra(alt::IVehicle* vehicle, uint8_t extraID, uint8_t state) {
    vehicle->ToggleExtra(extraID, state);
}

uint8_t Vehicle_IsNeonActive(alt::IVehicle* vehicle) {
    return vehicle->IsNeonActive();
}

void Vehicle_GetNeonActive(alt::IVehicle* vehicle, uint8_t* left, uint8_t* right, uint8_t* front, uint8_t* back) {
    bool bLeft, bRight, bFront, bBack;
    vehicle->GetNeonActive(&bLeft, &bRight, &bFront, &bBack);
    *left = bLeft;
    *right = bRight;
    *front = bFront;
    *back = bBack;
}

void Vehicle_SetNeonActive(alt::IVehicle* vehicle, uint8_t left, uint8_t right, uint8_t front, uint8_t back) {
    vehicle->SetNeonActive(left, right, front, back);
}

void Vehicle_GetNeonColor(alt::IVehicle* vehicle, rgba_t &neonColor) {
    auto vehicleNeonColor = vehicle->GetNeonColor();
    neonColor.r = vehicleNeonColor.r;
    neonColor.g = vehicleNeonColor.g;
    neonColor.b = vehicleNeonColor.b;
    neonColor.a = vehicleNeonColor.a;
}

void Vehicle_SetNeonColor(alt::IVehicle* vehicle, rgba_t neonColor) {
    alt::RGBA color;
    color.r = neonColor.r;
    color.g = neonColor.g;
    color.b = neonColor.b;
    color.a = neonColor.a;
    return vehicle->SetNeonColor(color);
}

uint8_t Vehicle_GetLivery(alt::IVehicle* vehicle) {
    return vehicle->GetLivery();
}

void Vehicle_SetLivery(alt::IVehicle* vehicle, uint8_t livery) {
    vehicle->SetLivery(livery);
}

uint8_t Vehicle_GetRoofLivery(alt::IVehicle* vehicle) {
    return vehicle->GetRoofLivery();
}

void Vehicle_SetRoofLivery(alt::IVehicle* vehicle, uint8_t roofLivery) {
    vehicle->SetRoofLivery(roofLivery);
}

void Vehicle_GetAppearanceDataBase64(alt::IVehicle* vehicle, const char*&base64) {
    base64 = vehicle->GetAppearanceDataBase64().CStr();
}

void Vehicle_LoadAppearanceDataFromBase64(alt::IVehicle* vehicle, const char* base64) {
    vehicle->LoadAppearanceDataFromBase64(base64);
}

uint8_t Vehicle_IsEngineOn(alt::IVehicle* vehicle) {
    return vehicle->IsEngineOn();
}

void Vehicle_SetEngineOn(alt::IVehicle* vehicle, uint8_t state) {
    vehicle->SetEngineOn(state);
}

uint8_t Vehicle_IsHandbrakeActive(alt::IVehicle* vehicle) {
    return vehicle->IsHandbrakeActive();
}

uint8_t Vehicle_GetHeadlightColor(alt::IVehicle* vehicle) {
    return vehicle->GetHeadlightColor();
}

void Vehicle_SetHeadlightColor(alt::IVehicle* vehicle, uint8_t color) {
    vehicle->SetHeadlightColor(color);
}

uint32_t Vehicle_GetRadioStationIndex(alt::IVehicle* vehicle) {
    return vehicle->GetRadioStationIndex();
}

void Vehicle_SetRadioStationIndex(alt::IVehicle* vehicle, uint32_t stationIndex) {
    vehicle->SetRadioStationIndex(stationIndex);
}

uint8_t Vehicle_IsSirenActive(alt::IVehicle* vehicle) {
    return vehicle->IsSirenActive();
}

void Vehicle_SetSirenActive(alt::IVehicle* vehicle, uint8_t state) {
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

uint8_t Vehicle_IsWindowOpened(alt::IVehicle* vehicle, uint8_t windowId) {
    return vehicle->IsWindowOpened(windowId);
}

void Vehicle_SetWindowOpened(alt::IVehicle* vehicle, uint8_t windowId, uint8_t state) {
    vehicle->SetWindowOpened(windowId, state);
}

uint8_t Vehicle_IsDaylightOn(alt::IVehicle* vehicle) {
    return vehicle->IsDaylightOn();
}

uint8_t Vehicle_IsNightlightOn(alt::IVehicle* vehicle) {
    return vehicle->IsNightlightOn();
}

uint8_t Vehicle_GetRoofState(alt::IVehicle* vehicle) {
    return vehicle->GetRoofState();
}

void Vehicle_SetRoofState(alt::IVehicle* vehicle, uint8_t state) {
    vehicle->SetRoofState(state);
}

uint8_t Vehicle_IsFlamethrowerActive(alt::IVehicle* vehicle) {
    return vehicle->IsFlamethrowerActive();
}

float Vehicle_GetLightsMultiplier(alt::IVehicle* vehicle) {
    return vehicle->GetLightsMultiplier();
}

void Vehicle_SetLightsMultiplier(alt::IVehicle* vehicle, float multiplier) {
    vehicle->SetLightsMultiplier(multiplier);
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

uint8_t Vehicle_IsWheelBurst(alt::IVehicle* vehicle, uint8_t wheelId) {
    return vehicle->IsWheelBurst(wheelId);
}

void Vehicle_SetWheelBurst(alt::IVehicle* vehicle, uint8_t wheelId, uint8_t state) {
    vehicle->SetWheelBurst(wheelId, state);
}

uint8_t Vehicle_DoesWheelHasTire(alt::IVehicle* vehicle, uint8_t wheelId) {
    return vehicle->DoesWheelHasTire(wheelId);
}

void Vehicle_SetWheelHasTire(alt::IVehicle* vehicle, uint8_t wheelId, uint8_t state) {
    vehicle->SetWheelHasTire(wheelId, state);
}

uint8_t Vehicle_IsWheelDetached(alt::IVehicle* vehicle, uint8_t wheelId) {
    return vehicle->IsWheelDetached(wheelId);
}

void Vehicle_SetWheelDetached(alt::IVehicle* vehicle, uint8_t wheelId, uint8_t state) {
    vehicle->SetWheelDetached(wheelId, state);
}

uint8_t Vehicle_IsWheelOnFire(alt::IVehicle* vehicle, uint8_t wheelId) {
    return vehicle->IsWheelOnFire(wheelId);
}

void Vehicle_SetWheelOnFire(alt::IVehicle* vehicle, uint8_t wheelId, uint8_t state) {
    vehicle->SetWheelOnFire(wheelId, state);
}

float Vehicle_GetWheelHealth(alt::IVehicle* vehicle, uint8_t wheelId) {
    return vehicle->GetWheelHealth(wheelId);
}

void Vehicle_SetWheelHealth(alt::IVehicle* vehicle, uint8_t wheelId, float health) {
    vehicle->SetWheelHealth(wheelId, health);
}

void Vehicle_SetWheelFixed(alt::IVehicle* vehicle, uint8_t wheelId) {
    vehicle->SetWheelFixed(wheelId);
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

uint8_t Vehicle_IsLightDamaged(alt::IVehicle* vehicle, uint8_t lightId) {
    return vehicle->IsLightDamaged(lightId);
}

void Vehicle_SetLightDamaged(alt::IVehicle* vehicle, uint8_t lightId, uint8_t isDamaged) {
    vehicle->SetLightDamaged(lightId, isDamaged);
}

uint8_t Vehicle_IsWindowDamaged(alt::IVehicle* vehicle, uint8_t windowId) {
    return vehicle->IsWindowDamaged(windowId);
}

void Vehicle_SetWindowDamaged(alt::IVehicle* vehicle, uint8_t windowId, uint8_t isDamaged) {
    vehicle->SetWindowDamaged(windowId, isDamaged);
}

uint8_t Vehicle_IsSpecialLightDamaged(alt::IVehicle* vehicle, uint8_t specialLightId) {
    return vehicle->IsSpecialLightDamaged(specialLightId);
}

void Vehicle_SetSpecialLightDamaged(alt::IVehicle* vehicle, uint8_t specialLightId, uint8_t isDamaged) {
    vehicle->SetSpecialLightDamaged(specialLightId, isDamaged);
}

uint8_t Vehicle_HasArmoredWindows(alt::IVehicle* vehicle) {
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

void Vehicle_SetManualEngineControl(alt::IVehicle* vehicle, uint8_t state) {
    vehicle->SetManualEngineControl(state);
}

uint8_t Vehicle_IsManualEngineControl(alt::IVehicle* vehicle) {
    return vehicle->IsManualEngineControl();
}

void Vehicle_GetScriptDataBase64(alt::IVehicle* vehicle, const char*&base64) {
    base64 = vehicle->GetScriptDataBase64().CStr();
}

void Vehicle_LoadScriptDataFromBase64(alt::IVehicle* vehicle, const char* base64) {
    vehicle->LoadScriptDataFromBase64(base64);
}

void Vehicle_GetPositionCoords2(alt::IVehicle* vehicle, float* position_x, float* position_y, float* position_z, float* rotation_x, float* rotation_y, float* rotation_z, int* dimension) {
    auto vehiclePosition = vehicle->GetPosition();
    *position_x = vehiclePosition.x;
    *position_y = vehiclePosition.y;
    *position_z = vehiclePosition.z;
    auto vehicleRotation = vehicle->GetRotation();
    *rotation_x = vehicleRotation.pitch;
    *rotation_y = vehicleRotation.roll;
    *rotation_z = vehicleRotation.yaw;
    *dimension = vehicle->GetDimension();
}

void Vehicle_SetNetworkOwner(alt::IVehicle* vehicle, alt::IPlayer* networkOwnerPlayer, uint8_t disableMigration) {
    vehicle->SetNetworkOwner(networkOwnerPlayer, disableMigration);
}

alt::IVehicle* Vehicle_GetAttached(alt::IVehicle* vehicle) {
    return vehicle->GetAttached().Get();
}

alt::IVehicle* Vehicle_GetAttachedTo(alt::IVehicle* vehicle) {
    return vehicle->GetAttachedTo().Get();
}

void Vehicle_Repair(alt::IVehicle* vehicle) {
    vehicle->SetFixed();
}

void Vehicle_AttachToEntity_Player(alt::IVehicle* vehicle, alt::IPlayer* entity, int16_t otherBone, int16_t ownBone, position_t pos, rotation_t rot, uint8_t collision, uint8_t noFixedRot)
{
    alt::Position position{pos.x, pos.y, pos.z};
    alt::Rotation rotation{rot.roll, rot.pitch, rot.yaw};
    vehicle->AttachToEntity(entity, otherBone, ownBone, position, rotation, collision, noFixedRot);
}

void Vehicle_AttachToEntity_Vehicle(alt::IVehicle* vehicle, alt::IVehicle* entity, int16_t otherBone, int16_t ownBone, position_t pos, rotation_t rot, uint8_t collision, uint8_t noFixedRot)
{
    alt::Position position{pos.x, pos.y, pos.z};
    alt::Rotation rotation{rot.roll, rot.pitch, rot.yaw};
    vehicle->AttachToEntity(entity, otherBone, ownBone, position, rotation, collision, noFixedRot);
}

void Vehicle_Detach(alt::IVehicle* vehicle)
{
    vehicle->Detach();
}

void Vehicle_GetVelocity(alt::IVehicle* vehicle, position_t &velocity) {
    auto vehicleVelocity = vehicle->GetVelocity();
    velocity.x = vehicleVelocity[0];
    velocity.y = vehicleVelocity[1];
    velocity.z = vehicleVelocity[2];
}

void Vehicle_SetDriftMode(alt::IVehicle* vehicle, uint8_t state) {
    vehicle->SetDriftMode(state);
}

uint8_t Vehicle_IsDriftMode(alt::IVehicle* vehicle) {
    return vehicle->IsDriftMode();
}

uint8_t Vehicle_IsTrainMissionTrain(alt::IVehicle* vehicle) {
    return vehicle->IsTrainMissionTrain();
}

void Vehicle_SetTrainMissionTrain(alt::IVehicle* vehicle, uint8_t state) {
    vehicle->SetTrainMissionTrain(state);
}

int8_t Vehicle_GetTrainTrackId(alt::IVehicle* vehicle) {
    return vehicle->GetTrainTrackId();
}

void Vehicle_SetTrainTrackId(alt::IVehicle* vehicle, int8_t trackId) {
    vehicle->SetTrainTrackId(trackId);
}

alt::IVehicle* Vehicle_GetTrainEngineId(alt::IVehicle* vehicle) {
    return vehicle->GetTrainEngineId().Get();
}

void Vehicle_SetTrainEngineId(alt::IVehicle* vehicle, alt::IVehicle* entity) {
    vehicle->SetTrainEngineId(entity);
}

int8_t Vehicle_GetTrainConfigIndex(alt::IVehicle* vehicle) {
    return vehicle->GetTrainConfigIndex();
}

void Vehicle_SetTrainConfigIndex(alt::IVehicle* vehicle, int8_t index) {
    vehicle->SetTrainConfigIndex(index);
}

float Vehicle_GetTrainDistanceFromEngine(alt::IVehicle* vehicle) {
    return vehicle->GetTrainDistanceFromEngine();
}

void Vehicle_SetTrainDistanceFromEngine(alt::IVehicle* vehicle, float distanceFromEngine) {
    vehicle->SetTrainDistanceFromEngine(distanceFromEngine);
}

uint8_t Vehicle_IsTrainEngine(alt::IVehicle* vehicle) {
    return vehicle->IsTrainEngine();
}

void Vehicle_SetTrainIsEngine(alt::IVehicle* vehicle, uint8_t state) {
    vehicle->SetTrainIsEngine(state);
}

uint8_t Vehicle_IsTrainCaboose(alt::IVehicle* vehicle) {
    return vehicle->IsTrainCaboose();
}

void Vehicle_SetTrainIsCaboose(alt::IVehicle* vehicle, uint8_t isCaboose) {
    vehicle->SetTrainIsCaboose(isCaboose);
}

uint8_t Vehicle_GetTrainDirection(alt::IVehicle* vehicle) {
    return vehicle->GetTrainDirection();
}

void Vehicle_SetTrainDirection(alt::IVehicle* vehicle, uint8_t direction) {
    vehicle->SetTrainDirection(direction);
}

uint8_t Vehicle_HasTrainPassengerCarriages(alt::IVehicle* vehicle) {
    return vehicle->HasTrainPassengerCarriages();
}

void Vehicle_SetTrainHasPassengerCarriages(alt::IVehicle* vehicle, uint8_t hasPassengerCarriages) {
    vehicle->SetTrainHasPassengerCarriages(hasPassengerCarriages);
}

uint8_t Vehicle_GetTrainRenderDerailed(alt::IVehicle* vehicle) {
    return vehicle->GetTrainRenderDerailed();
}

void Vehicle_SetTrainRenderDerailed(alt::IVehicle* vehicle, uint8_t renderDerailed) {
    vehicle->SetTrainRenderDerailed(renderDerailed);
}

uint8_t Vehicle_GetTrainForceDoorsOpen(alt::IVehicle* vehicle) {
    return vehicle->GetTrainForceDoorsOpen();
}

void Vehicle_SetTrainForceDoorsOpen(alt::IVehicle* vehicle, uint8_t forceDoorsOpen) {
    vehicle->SetTrainForceDoorsOpen(forceDoorsOpen);
}

float Vehicle_GetTrainCruiseSpeed(alt::IVehicle* vehicle) {
    return vehicle->GetTrainCruiseSpeed();
}

void Vehicle_SetTrainCruiseSpeed(alt::IVehicle* vehicle, float cruiseSpeed) {
    vehicle->SetTrainCruiseSpeed(cruiseSpeed);
}

int8_t Vehicle_GetTrainCarriageConfigIndex(alt::IVehicle* vehicle) {
    return vehicle->GetTrainCarriageConfigIndex();
}

void Vehicle_SetTrainCarriageConfigIndex(alt::IVehicle* vehicle, int8_t carriageConfigIndex) {
    vehicle->SetTrainCarriageConfigIndex(carriageConfigIndex);
}

alt::IVehicle* Vehicle_GetTrainLinkedToBackwardId(alt::IVehicle* vehicle) {
    return vehicle->GetTrainLinkedToBackwardId().Get();
}

void Vehicle_SetTrainLinkedToBackwardId(alt::IVehicle* vehicle, alt::IVehicle* entity) {
    vehicle->SetTrainLinkedToBackwardId(entity);
}

alt::IVehicle* Vehicle_GetTrainLinkedToForwardId(alt::IVehicle* vehicle) {
    return vehicle->GetTrainLinkedToForwardId().Get();
}

void Vehicle_SetTrainLinkedToForwardId(alt::IVehicle* vehicle, alt::IVehicle* entity) {
    vehicle->SetTrainLinkedToForwardId(vehicle);
}