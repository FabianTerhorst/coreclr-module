#include "vehicle.h"
#include "altv-cpp-api/SDK.h"
#include <Log.h>

using namespace alt;

uint16_t Vehicle_GetID(alt::IVehicle* vehicle) {
    return vehicle->GetID();
}

alt::IEntity* Vehicle_GetEntity(alt::IVehicle* vehicle) {
    return dynamic_cast<alt::IEntity*>(vehicle);
}


uint32_t Vehicle_GetModel(alt::IVehicle* vehicle) {
    return vehicle->GetModel();
}


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

uint8_t Vehicle_GetWheelsCount(alt::IVehicle* vehicle) {
    return vehicle->GetWheelsCount();
}
