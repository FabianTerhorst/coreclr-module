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

EXPORT_SERVER alt::IWorldObject* ColShape_GetWorldObject(alt::IColShape* colShape);

EXPORT_SERVER uint8_t ColShape_GetColShapeType(alt::IColShape* colShape);
EXPORT_SERVER uint8_t ColShape_IsEntityIn(alt::IColShape* colShape, alt::IEntity* entity);
EXPORT_SERVER void ColShape_SetPlayersOnly(alt::IColShape* colShape, uint8_t state);
EXPORT_SERVER uint8_t ColShape_IsPlayersOnly(alt::IColShape* colShape);

#ifdef __cplusplus
}
#endif
