#pragma once
#include "altv-cpp-api/SDK.h"
#include "types.h"

extern "C"
{
    EXPORT uint16_t Entity_GetID(alt::IEntity* player);
    EXPORT alt::IWorldObject* Entity_GetWorldObject(alt::IEntity* entity);
}