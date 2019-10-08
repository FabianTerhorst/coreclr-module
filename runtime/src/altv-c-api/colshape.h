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
EXPORT void ColShape_SetPosition(alt::IColShape* colShape, alt::Position pos);
EXPORT int16_t ColShape_GetDimension(alt::IColShape* colShape);
EXPORT void ColShape_SetDimension(alt::IColShape* colShape, uint16_t dimension);
EXPORT void ColShape_GetMetaData(alt::IColShape* colShape, const char* key, alt::MValue &val);
EXPORT void ColShape_SetMetaData(alt::IColShape* colShape, const char* key, alt::MValue* val);
// ColShape
EXPORT alt::ColShapeType ColShape_GetColShapeType(alt::IColShape* colShape);
EXPORT bool ColShape_IsEntityIn(alt::IColShape* colShape, alt::IEntity* entity);
#ifdef __cplusplus
}
#endif
