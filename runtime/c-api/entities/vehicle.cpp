#include "vehicle.h"
#include "../utils/strings.h"

uint16_t Vehicle_GetID(alt::IVehicle* entity) {
    return entity->GetID();
}

alt::IEntity* Vehicle_GetEntity(alt::IVehicle* entity) {
    return dynamic_cast<alt::IEntity*>(entity);
}

uint8_t Vehicle_GetWheelsCount(alt::IVehicle* vehicle) {
    return vehicle->GetWheelsCount();
}


#ifdef ALT_SERVER_API
alt::IPlayer* Vehicle_GetDriver(alt::IVehicle* vehicle) {
    return vehicle->GetDriver().Get();
}

uint8_t Vehicle_GetDriverID(alt::IVehicle* vehicle, uint16_t& id) {
    auto driver = vehicle->GetDriver();
    if (driver.IsEmpty()) return false;
    id = driver->GetID();
    return true;
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


const char* Vehicle_GetNumberplateText(alt::IVehicle* vehicle, int32_t& size) {
    return AllocateString(vehicle->GetNumberplateText(), size);
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


const char* Vehicle_GetAppearanceDataBase64(alt::IVehicle* vehicle, int32_t& size) {
    return AllocateString(vehicle->GetAppearanceDataBase64(), size);
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


const char* Vehicle_GetGameStateBase64(alt::IVehicle* vehicle, int32_t& size) {
    return AllocateString(vehicle->GetGameStateBase64(), size);
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


const char* Vehicle_GetHealthDataBase64(alt::IVehicle* vehicle, int32_t& size) {
    return AllocateString(vehicle->GetHealthDataBase64(), size);
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

const char* Vehicle_GetDamageDataBase64(alt::IVehicle* vehicle, int32_t& size) {
    return AllocateString(vehicle->GetDamageDataBase64(), size);
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


const char* Vehicle_GetScriptDataBase64(alt::IVehicle* vehicle, int32_t& size) {
    return AllocateString(vehicle->GetScriptDataBase64(), size);
}

void Vehicle_LoadScriptDataFromBase64(alt::IVehicle* vehicle, const char* base64) {
    vehicle->LoadScriptDataFromBase64(base64);
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


void Vehicle_AttachToEntity(alt::IVehicle* vehicle, alt::IEntity* entity, int16_t otherBone, int16_t ownBone, position_t pos, rotation_t rot, uint8_t collision, uint8_t noFixedRot)
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


uint8_t Vehicle_SetSearchLight(alt::IVehicle* vehicle, uint8_t state, alt::IEntity* spottedEntity) {
    return vehicle->SetSearchLight(state, spottedEntity);
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

uint8_t Vehicle_GetBoatAnchor(alt::IVehicle* vehicle) {
  return vehicle->IsBoatAnchorActive();
}

void Vehicle_SetBoatAnchor(alt::IVehicle* vehicle, uint8_t state) {
  vehicle->SetBoatAnchorActive(state);
}
#endif

#ifdef ALT_CLIENT_API
uint16_t Vehicle_GetGear(alt::IVehicle* vehicle)
{
    return vehicle->GetCurrentGear();
}

void Vehicle_SetGear(alt::IVehicle* vehicle, uint16_t value) {
    vehicle->SetCurrentGear(value);
}

uint8_t Vehicle_GetIndicatorLights(alt::IVehicle* vehicle) {
    return vehicle->GetLightsIndicator();
}

void Vehicle_SetIndicatorLights(alt::IVehicle* vehicle, uint8_t value) {
    vehicle->SetLightsIndicator(value);
}

uint16_t Vehicle_GetMaxGear(alt::IVehicle* vehicle) {
    return vehicle->GetMaxGear();
}

void Vehicle_SetMaxGear(alt::IVehicle* vehicle, uint16_t value) {
    vehicle->SetMaxGear(value);
}

float Vehicle_GetRPM(alt::IVehicle* vehicle) {
    return vehicle->GetCurrentRPM();
}

uint8_t Vehicle_GetSeatCount(alt::IVehicle* vehicle) {
    return vehicle->GetSeatCount();
}

float Vehicle_GetWheelSpeed(alt::IVehicle* vehicle) {
    return vehicle->GetWheelSpeed();
}

void Vehicle_GetSpeedVector(alt::IVehicle* vehicle, vector3_t& vector) {
    auto speed = vehicle->GetSpeedVector();
    vector.x = speed[0];
    vector.y = speed[1];
    vector.z = speed[2];
}


void Vehicle_GetHandling(alt::IVehicle* vehicle, alt::IHandlingData*& handling) {
    handling = vehicle->GetHandling().Get();
}

void Vehicle_ReplaceHandling(alt::IVehicle* vehicle) {
    vehicle->ReplaceHandling();
}

void Vehicle_ResetHandling(alt::IVehicle* vehicle) {
    vehicle->ReplaceHandling();
}

uint8_t Vehicle_IsHandlingModified(alt::IVehicle* vehicle) {
    return vehicle->IsHandlingModified();
}

uint8_t Vehicle_Handling_GetByModelHash(alt::ICore* core, uint32_t modelHash, alt::IHandlingData*& handling) {
    auto data = core->GetHandlingData(modelHash);
    if (data.IsEmpty()) return false;
    handling = data.Get();
    return true;
}


uint32_t Vehicle_Handling_GetHandlingNameHash(alt::IHandlingData* handling) {
    return handling->GetHandlingNameHash();
}
float Vehicle_Handling_GetMass(alt::IHandlingData* handling) {
    return handling->GetMass();
}
void Vehicle_Handling_SetMass(alt::IHandlingData* handling, float value) {
    handling->SetMass(value);
}
float Vehicle_Handling_GetInitialDragCoeff(alt::IHandlingData* handling) {
    return handling->GetInitialDragCoeff();
}
void Vehicle_Handling_SetInitialDragCoeff(alt::IHandlingData* handling, float value) {
    handling->SetInitialDragCoeff(value);
}
float Vehicle_Handling_GetDownforceModifier(alt::IHandlingData* handling) {
    return handling->GetDownforceModifier();
}
void Vehicle_Handling_SetDownforceModifier(alt::IHandlingData* handling, float value) {
    handling->SetDownforceModifier(value);
}
float Vehicle_Handling_GetunkFloat1(alt::IHandlingData* handling) {
    return handling->GetunkFloat1();
}
void Vehicle_Handling_SetunkFloat1(alt::IHandlingData* handling, float value) {
    handling->SetunkFloat1(value);
}
float Vehicle_Handling_GetunkFloat2(alt::IHandlingData* handling) {
    return handling->GetunkFloat2();
}
void Vehicle_Handling_SetunkFloat2(alt::IHandlingData* handling, float value) {
    handling->SetunkFloat2(value);
}
void Vehicle_Handling_GetCentreOfMassOffset(alt::IHandlingData* handling, vector3_t& offset) {
    auto vector = handling->GetCentreOfMassOffset();
    offset.x = vector[0];
    offset.y = vector[1];
    offset.z = vector[2];
}
void Vehicle_Handling_SetCentreOfMassOffset(alt::IHandlingData* handling, vector3_t value) {
    handling->SetCentreOfMassOffset(alt::Vector3f(value.x, value.y, value.z));
}
void Vehicle_Handling_GetInertiaMultiplier(alt::IHandlingData* handling, vector3_t& offset) {
    auto vector = handling->GetInertiaMultiplier();
    offset.x = vector[0];
    offset.y = vector[1];
    offset.z = vector[2];
}
void Vehicle_Handling_SetInertiaMultiplier(alt::IHandlingData* handling, vector3_t value) {
    handling->SetInertiaMultiplier(alt::Vector3f(value.x, value.y, value.z));
}
float Vehicle_Handling_GetPercentSubmerged(alt::IHandlingData* handling) {
    return handling->GetPercentSubmerged();
}
void Vehicle_Handling_SetPercentSubmerged(alt::IHandlingData* handling, float value) {
    handling->SetPercentSubmerged(value);
}
float Vehicle_Handling_GetPercentSubmergedRatio(alt::IHandlingData* handling) {
    return handling->GetPercentSubmergedRatio();
}
void Vehicle_Handling_SetPercentSubmergedRatio(alt::IHandlingData* handling, float value) {
    handling->SetPercentSubmergedRatio(value);
}
float Vehicle_Handling_GetDriveBiasFront(alt::IHandlingData* handling) {
    return handling->GetDriveBiasFront();
}
void Vehicle_Handling_SetDriveBiasFront(alt::IHandlingData* handling, float value) {
    handling->SetDriveBiasFront(value);
}
float Vehicle_Handling_GetAcceleration(alt::IHandlingData* handling) {
    return handling->GetAcceleration();
}
void Vehicle_Handling_SetAcceleration(alt::IHandlingData* handling, float value) {
    handling->SetAcceleration(value);
}
uint32_t Vehicle_Handling_GetInitialDriveGears(alt::IHandlingData* handling) {
    return handling->GetInitialDriveGears();
}
void Vehicle_Handling_SetInitialDriveGears(alt::IHandlingData* handling, uint32_t value) {
    handling->SetInitialDriveGears(value);
}
float Vehicle_Handling_GetDriveInertia(alt::IHandlingData* handling) {
    return handling->GetDriveInertia();
}
void Vehicle_Handling_SetDriveInertia(alt::IHandlingData* handling, float value) {
    handling->SetDriveInertia(value);
}
float Vehicle_Handling_GetClutchChangeRateScaleUpShift(alt::IHandlingData* handling) {
    return handling->GetClutchChangeRateScaleUpShift();
}
void Vehicle_Handling_SetClutchChangeRateScaleUpShift(alt::IHandlingData* handling, float value) {
    handling->SetClutchChangeRateScaleUpShift(value);
}
float Vehicle_Handling_GetClutchChangeRateScaleDownShift(alt::IHandlingData* handling) {
    return handling->GetClutchChangeRateScaleDownShift();
}
void Vehicle_Handling_SetClutchChangeRateScaleDownShift(alt::IHandlingData* handling, float value) {
    handling->SetClutchChangeRateScaleDownShift(value);
}
float Vehicle_Handling_GetInitialDriveForce(alt::IHandlingData* handling) {
    return handling->GetInitialDriveForce();
}
void Vehicle_Handling_SetInitialDriveForce(alt::IHandlingData* handling, float value) {
    handling->SetInitialDriveForce(value);
}
float Vehicle_Handling_GetDriveMaxFlatVel(alt::IHandlingData* handling) {
    return handling->GetDriveMaxFlatVel();
}
void Vehicle_Handling_SetDriveMaxFlatVel(alt::IHandlingData* handling, float value) {
    handling->SetDriveMaxFlatVel(value);
}
float Vehicle_Handling_GetInitialDriveMaxFlatVel(alt::IHandlingData* handling) {
    return handling->GetInitialDriveMaxFlatVel();
}
void Vehicle_Handling_SetInitialDriveMaxFlatVel(alt::IHandlingData* handling, float value) {
    handling->SetInitialDriveMaxFlatVel(value);
}
float Vehicle_Handling_GetBrakeForce(alt::IHandlingData* handling) {
    return handling->GetBrakeForce();
}
void Vehicle_Handling_SetBrakeForce(alt::IHandlingData* handling, float value) {
    handling->SetBrakeForce(value);
}
float Vehicle_Handling_GetunkFloat4(alt::IHandlingData* handling) {
    return handling->GetunkFloat4();
}
void Vehicle_Handling_SetunkFloat4(alt::IHandlingData* handling, float value) {
    handling->SetunkFloat4(value);
}
float Vehicle_Handling_GetBrakeBiasFront(alt::IHandlingData* handling) {
    return handling->GetBrakeBiasFront();
}
void Vehicle_Handling_SetBrakeBiasFront(alt::IHandlingData* handling, float value) {
    handling->SetBrakeBiasFront(value);
}
float Vehicle_Handling_GetBrakeBiasRear(alt::IHandlingData* handling) {
    return handling->GetBrakeBiasRear();
}
void Vehicle_Handling_SetBrakeBiasRear(alt::IHandlingData* handling, float value) {
    handling->SetBrakeBiasRear(value);
}
float Vehicle_Handling_GetHandBrakeForce(alt::IHandlingData* handling) {
    return handling->GetHandBrakeForce();
}
void Vehicle_Handling_SetHandBrakeForce(alt::IHandlingData* handling, float value) {
    handling->SetHandBrakeForce(value);
}
float Vehicle_Handling_GetSteeringLock(alt::IHandlingData* handling) {
    return handling->GetSteeringLock();
}
void Vehicle_Handling_SetSteeringLock(alt::IHandlingData* handling, float value) {
    handling->SetSteeringLock(value);
}
float Vehicle_Handling_GetSteeringLockRatio(alt::IHandlingData* handling) {
    return handling->GetSteeringLockRatio();
}
void Vehicle_Handling_SetSteeringLockRatio(alt::IHandlingData* handling, float value) {
    handling->SetSteeringLockRatio(value);
}
float Vehicle_Handling_GetTractionCurveMax(alt::IHandlingData* handling) {
    return handling->GetTractionCurveMax();
}
void Vehicle_Handling_SetTractionCurveMax(alt::IHandlingData* handling, float value) {
    handling->SetTractionCurveMax(value);
}
float Vehicle_Handling_GetTractionCurveMaxRatio(alt::IHandlingData* handling) {
    return handling->GetTractionCurveMaxRatio();
}
void Vehicle_Handling_SetTractionCurveMaxRatio(alt::IHandlingData* handling, float value) {
    handling->SetTractionCurveMaxRatio(value);
}
float Vehicle_Handling_GetTractionCurveMin(alt::IHandlingData* handling) {
    return handling->GetTractionCurveMin();
}
void Vehicle_Handling_SetTractionCurveMin(alt::IHandlingData* handling, float value) {
    handling->SetTractionCurveMin(value);
}
float Vehicle_Handling_GetTractionCurveMinRatio(alt::IHandlingData* handling) {
    return handling->GetTractionCurveMinRatio();
}
void Vehicle_Handling_SetTractionCurveMinRatio(alt::IHandlingData* handling, float value) {
    handling->SetTractionCurveMinRatio(value);
}
float Vehicle_Handling_GetTractionCurveLateral(alt::IHandlingData* handling) {
    return handling->GetTractionCurveLateral();
}
void Vehicle_Handling_SetTractionCurveLateral(alt::IHandlingData* handling, float value) {
    handling->SetTractionCurveLateral(value);
}
float Vehicle_Handling_GetTractionCurveLateralRatio(alt::IHandlingData* handling) {
    return handling->GetTractionCurveLateralRatio();
}
void Vehicle_Handling_SetTractionCurveLateralRatio(alt::IHandlingData* handling, float value) {
    handling->SetTractionCurveLateralRatio(value);
}
float Vehicle_Handling_GetTractionSpringDeltaMax(alt::IHandlingData* handling) {
    return handling->GetTractionSpringDeltaMax();
}
void Vehicle_Handling_SetTractionSpringDeltaMax(alt::IHandlingData* handling, float value) {
    handling->SetTractionSpringDeltaMax(value);
}
float Vehicle_Handling_GetTractionSpringDeltaMaxRatio(alt::IHandlingData* handling) {
    return handling->GetTractionSpringDeltaMaxRatio();
}
void Vehicle_Handling_SetTractionSpringDeltaMaxRatio(alt::IHandlingData* handling, float value) {
    handling->SetTractionSpringDeltaMaxRatio(value);
}
float Vehicle_Handling_GetLowSpeedTractionLossMult(alt::IHandlingData* handling) {
    return handling->GetLowSpeedTractionLossMult();
}
void Vehicle_Handling_SetLowSpeedTractionLossMult(alt::IHandlingData* handling, float value) {
    handling->SetLowSpeedTractionLossMult(value);
}
float Vehicle_Handling_GetCamberStiffness(alt::IHandlingData* handling) {
    return handling->GetCamberStiffness();
}
void Vehicle_Handling_SetCamberStiffness(alt::IHandlingData* handling, float value) {
    handling->SetCamberStiffness(value);
}
float Vehicle_Handling_GetTractionBiasFront(alt::IHandlingData* handling) {
    return handling->GetTractionBiasFront();
}
void Vehicle_Handling_SetTractionBiasFront(alt::IHandlingData* handling, float value) {
    handling->SetTractionBiasFront(value);
}
float Vehicle_Handling_GetTractionBiasRear(alt::IHandlingData* handling) {
    return handling->GetTractionBiasRear();
}
void Vehicle_Handling_SetTractionBiasRear(alt::IHandlingData* handling, float value) {
    handling->SetTractionBiasRear(value);
}
float Vehicle_Handling_GetTractionLossMult(alt::IHandlingData* handling) {
    return handling->GetTractionLossMult();
}
void Vehicle_Handling_SetTractionLossMult(alt::IHandlingData* handling, float value) {
    handling->SetTractionLossMult(value);
}
float Vehicle_Handling_GetSuspensionForce(alt::IHandlingData* handling) {
    return handling->GetSuspensionForce();
}
void Vehicle_Handling_SetSuspensionForce(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionForce(value);
}
float Vehicle_Handling_GetSuspensionCompDamp(alt::IHandlingData* handling) {
    return handling->GetSuspensionCompDamp();
}
void Vehicle_Handling_SetSuspensionCompDamp(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionCompDamp(value);
}
float Vehicle_Handling_GetSuspensionReboundDamp(alt::IHandlingData* handling) {
    return handling->GetSuspensionReboundDamp();
}
void Vehicle_Handling_SetSuspensionReboundDamp(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionReboundDamp(value);
}
float Vehicle_Handling_GetSuspensionUpperLimit(alt::IHandlingData* handling) {
    return handling->GetSuspensionUpperLimit();
}
void Vehicle_Handling_SetSuspensionUpperLimit(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionUpperLimit(value);
}
float Vehicle_Handling_GetSuspensionLowerLimit(alt::IHandlingData* handling) {
    return handling->GetSuspensionLowerLimit();
}
void Vehicle_Handling_SetSuspensionLowerLimit(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionLowerLimit(value);
}
float Vehicle_Handling_GetSuspensionRaise(alt::IHandlingData* handling) {
    return handling->GetSuspensionRaise();
}
void Vehicle_Handling_SetSuspensionRaise(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionRaise(value);
}
float Vehicle_Handling_GetSuspensionBiasFront(alt::IHandlingData* handling) {
    return handling->GetSuspensionBiasFront();
}
void Vehicle_Handling_SetSuspensionBiasFront(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionBiasFront(value);
}
float Vehicle_Handling_GetSuspensionBiasRear(alt::IHandlingData* handling) {
    return handling->GetSuspensionBiasRear();
}
void Vehicle_Handling_SetSuspensionBiasRear(alt::IHandlingData* handling, float value) {
    handling->SetSuspensionBiasRear(value);
}
float Vehicle_Handling_GetAntiRollBarForce(alt::IHandlingData* handling) {
    return handling->GetAntiRollBarForce();
}
void Vehicle_Handling_SetAntiRollBarForce(alt::IHandlingData* handling, float value) {
    handling->SetAntiRollBarForce(value);
}
float Vehicle_Handling_GetAntiRollBarBiasFront(alt::IHandlingData* handling) {
    return handling->GetAntiRollBarBiasFront();
}
void Vehicle_Handling_SetAntiRollBarBiasFront(alt::IHandlingData* handling, float value) {
    handling->SetAntiRollBarBiasFront(value);
}
float Vehicle_Handling_GetAntiRollBarBiasRear(alt::IHandlingData* handling) {
    return handling->GetAntiRollBarBiasRear();
}
void Vehicle_Handling_SetAntiRollBarBiasRear(alt::IHandlingData* handling, float value) {
    handling->SetAntiRollBarBiasRear(value);
}
float Vehicle_Handling_GetRollCentreHeightFront(alt::IHandlingData* handling) {
    return handling->GetRollCentreHeightFront();
}
void Vehicle_Handling_SetRollCentreHeightFront(alt::IHandlingData* handling, float value) {
    handling->SetRollCentreHeightFront(value);
}
float Vehicle_Handling_GetRollCentreHeightRear(alt::IHandlingData* handling) {
    return handling->GetRollCentreHeightRear();
}
void Vehicle_Handling_SetRollCentreHeightRear(alt::IHandlingData* handling, float value) {
    handling->SetRollCentreHeightRear(value);
}
float Vehicle_Handling_GetCollisionDamageMult(alt::IHandlingData* handling) {
    return handling->GetCollisionDamageMult();
}
void Vehicle_Handling_SetCollisionDamageMult(alt::IHandlingData* handling, float value) {
    handling->SetCollisionDamageMult(value);
}
float Vehicle_Handling_GetWeaponDamageMult(alt::IHandlingData* handling) {
    return handling->GetWeaponDamageMult();
}
void Vehicle_Handling_SetWeaponDamageMult(alt::IHandlingData* handling, float value) {
    handling->SetWeaponDamageMult(value);
}
float Vehicle_Handling_GetDeformationDamageMult(alt::IHandlingData* handling) {
    return handling->GetDeformationDamageMult();
}
void Vehicle_Handling_SetDeformationDamageMult(alt::IHandlingData* handling, float value) {
    handling->SetDeformationDamageMult(value);
}
float Vehicle_Handling_GetEngineDamageMult(alt::IHandlingData* handling) {
    return handling->GetEngineDamageMult();
}
void Vehicle_Handling_SetEngineDamageMult(alt::IHandlingData* handling, float value) {
    handling->SetEngineDamageMult(value);
}
float Vehicle_Handling_GetPetrolTankVolume(alt::IHandlingData* handling) {
    return handling->GetPetrolTankVolume();
}
void Vehicle_Handling_SetPetrolTankVolume(alt::IHandlingData* handling, float value) {
    handling->SetPetrolTankVolume(value);
}
float Vehicle_Handling_GetOilVolume(alt::IHandlingData* handling) {
    return handling->GetOilVolume();
}
void Vehicle_Handling_SetOilVolume(alt::IHandlingData* handling, float value) {
    handling->SetOilVolume(value);
}
float Vehicle_Handling_GetunkFloat5(alt::IHandlingData* handling) {
    return handling->GetunkFloat5();
}
void Vehicle_Handling_SetunkFloat5(alt::IHandlingData* handling, float value) {
    handling->SetunkFloat5(value);
}
float Vehicle_Handling_GetSeatOffsetDistX(alt::IHandlingData* handling) {
    return handling->GetSeatOffsetDistX();
}
void Vehicle_Handling_SetSeatOffsetDistX(alt::IHandlingData* handling, float value) {
    handling->SetSeatOffsetDistX(value);
}
float Vehicle_Handling_GetSeatOffsetDistY(alt::IHandlingData* handling) {
    return handling->GetSeatOffsetDistY();
}
void Vehicle_Handling_SetSeatOffsetDistY(alt::IHandlingData* handling, float value) {
    handling->SetSeatOffsetDistY(value);
}
float Vehicle_Handling_GetSeatOffsetDistZ(alt::IHandlingData* handling) {
    return handling->GetSeatOffsetDistZ();
}
void Vehicle_Handling_SetSeatOffsetDistZ(alt::IHandlingData* handling, float value) {
    handling->SetSeatOffsetDistZ(value);
}
uint32_t Vehicle_Handling_GetMonetaryValue(alt::IHandlingData* handling) {
    return handling->GetMonetaryValue();
}
void Vehicle_Handling_SetMonetaryValue(alt::IHandlingData* handling, uint32_t value) {
    handling->SetMonetaryValue(value);
}
uint32_t Vehicle_Handling_GetModelFlags(alt::IHandlingData* handling) {
    return handling->GetModelFlags();
}
void Vehicle_Handling_SetModelFlags(alt::IHandlingData* handling, uint32_t value) {
    handling->SetModelFlags(value);
}
uint32_t Vehicle_Handling_GetHandlingFlags(alt::IHandlingData* handling) {
    return handling->GetHandlingFlags();
}
void Vehicle_Handling_SetHandlingFlags(alt::IHandlingData* handling, uint32_t value) {
    handling->SetHandlingFlags(value);
}
uint32_t Vehicle_Handling_GetDamageFlags(alt::IHandlingData* handling) {
    return handling->GetDamageFlags();
}
void Vehicle_Handling_SetDamageFlags(alt::IHandlingData* handling, uint32_t value) {
    handling->SetDamageFlags(value);
}
#endif