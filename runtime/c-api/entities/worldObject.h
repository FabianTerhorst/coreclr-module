#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "../data/types.h"
#include "../utils/export.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif

EXPORT_SHARED alt::IBaseObject* WorldObject_GetBaseObject(alt::IWorldObject* worldObject);
EXPORT_SHARED void WorldObject_GetPosition(alt::IWorldObject* worldObject, vector3_t& position);
EXPORT_SHARED void WorldObject_GetPositionCoords(alt::IWorldObject* worldObject, float* position_x, float* position_y, float* position_z, int* dimension);

EXPORT_SERVER void WorldObject_SetPosition(alt::IWorldObject* player, position_t pos);

#ifdef __cplusplus
}
#endif
