#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>
#include "position.h"
#include "rotation.h"
#include "rgba.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
// Entity
EXPORT void ColShape_GetPosition(alt::IColShape* colShape, position_t &position);
EXPORT void ColShape_SetPosition(alt::IColShape* colShape, position_t pos);
EXPORT int32_t ColShape_GetDimension(alt::IColShape* colShape);
EXPORT void ColShape_SetDimension(alt::IColShape* colShape, int32_t dimension);
EXPORT alt::MValueConst* ColShape_GetMetaData(alt::IColShape* colShape, const char* key);
EXPORT void ColShape_SetMetaData(alt::IColShape* colShape, const char* key, alt::MValueConst* val);
EXPORT uint8_t ColShape_HasMetaData(alt::IColShape* colShape, const char* key);
EXPORT void ColShape_DeleteMetaData(alt::IColShape* colShape, const char* key);
EXPORT void ColShape_AddRef(alt::IColShape* colShape);
EXPORT void ColShape_RemoveRef(alt::IColShape* colShape);
// ColShape
EXPORT uint8_t ColShape_GetColShapeType(alt::IColShape* colShape);
//EXPORT uint8_t ColShape_IsEntityIn(alt::IColShape* colShape, alt::IEntity* entity);
EXPORT uint8_t ColShape_IsPlayerIn(alt::IColShape* colShape, alt::IPlayer* player);
EXPORT uint8_t ColShape_IsVehicleIn(alt::IColShape* colShape, alt::IVehicle* vehicle);
EXPORT void ColShape_SetPlayersOnly(alt::IColShape* colShape, uint8_t state);
EXPORT uint8_t ColShape_IsPlayersOnly(alt::IColShape* colShape);
#ifdef __cplusplus
}
#endif
