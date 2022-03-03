#pragma once
#include "altv-cpp-api/SDK.h"
#include "types.h"

extern "C"
{
    EXPORT uint16_t Vehicle_GetID(alt::IVehicle* vehicle); // optimization so the Vehicle_GetEntity isn't needed to retrieve the id
    EXPORT alt::IEntity* Vehicle_GetEntity(alt::IVehicle* player);
    EXPORT uint32_t Vehicle_GetModel(alt::IVehicle* player);

    EXPORT uint16_t Vehicle_GetGear(alt::IVehicle* vehicle);
    EXPORT void Vehicle_SetGear(alt::IVehicle* vehicle, uint16_t value);
    // todo handling
    EXPORT uint8_t Vehicle_GetIndicatorLights(alt::IVehicle* vehicle);
    EXPORT void Vehicle_SetIndicatorLights(alt::IVehicle* vehicle, uint8_t value);
    EXPORT uint16_t Vehicle_GetMaxGear(alt::IVehicle* vehicle);
    EXPORT void Vehicle_SetMaxGear(alt::IVehicle* vehicle, uint16_t value);
    EXPORT float Vehicle_GetRPM(alt::IVehicle* vehicle);
    EXPORT uint8_t Vehicle_GetSeatCount(alt::IVehicle* vehicle);
    EXPORT float Vehicle_GetWheelSpeed(alt::IVehicle* vehicle);
    EXPORT void Vehicle_GetSpeedVector(alt::IVehicle* vehicle, vector3_t& vector);
    EXPORT uint8_t Vehicle_GetWheelsCount(alt::IVehicle* vehicle);
}