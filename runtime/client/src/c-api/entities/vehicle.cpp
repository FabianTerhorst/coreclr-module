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