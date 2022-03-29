#pragma once
#include "../../../../cpp-sdk/SDK.h"
#include "types.h"

extern "C"
{
    EXPORT alt::IBaseObject* WorldObject_GetBaseObject(alt::IWorldObject* worldObject);

    EXPORT void WorldObject_GetPosition(alt::IWorldObject* worldObject, vector3_t& position);
}