#pragma once
#include "altv-cpp-api/SDK.h"
#include "types.h"

extern "C"
{
    EXPORT uint16_t Vehicle_GetID(alt::IVehicle* vehicle); // optimization so the Vehicle_GetEntity isn't needed to retrieve the id
    EXPORT alt::IEntity* Vehicle_GetEntity(alt::IVehicle* player);
    EXPORT uint32_t Vehicle_GetModel(alt::IVehicle* player);
}