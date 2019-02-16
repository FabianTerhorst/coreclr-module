#include "vehicle.h"

// Entity

uint16_t Vehicle_GetID(alt::IVehicle* entity) {
    return entity->GetID();
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

uint16_t Vehicle_GetDimension(alt::IVehicle* entity) {
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

void Vehicle_GetNeonActive(alt::IVehicle* vehicle, bool &left, bool &right, bool &top, bool &back) {
    vehicle->GetNeonActive(left, right, top, back);
}

void Vehicle_SetNeonActive(alt::IVehicle* vehicle, bool left, bool right, bool top, bool back) {
    vehicle->SetNeonActive(left, right, top, back);
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
