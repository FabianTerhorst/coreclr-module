#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>
#include "position.h"
#include "rotation.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
// Entity
EXPORT void Blip_GetPosition(alt::IBlip* blip, position_t &position);
EXPORT void Blip_SetPosition(alt::IBlip* blip, position_t pos);
EXPORT int32_t Blip_GetDimension(alt::IBlip* blip);
EXPORT void Blip_SetDimension(alt::IBlip* blip, int32_t dimension);
EXPORT alt::MValueConst* Blip_GetMetaData(alt::IBlip* blip, const char* key);
EXPORT void Blip_SetMetaData(alt::IBlip* blip, const char* key, alt::MValueConst* val);
EXPORT uint8_t Blip_HasMetaData(alt::IBlip* blip, const char* key);
EXPORT void Blip_DeleteMetaData(alt::IBlip* blip, const char* key);
EXPORT void Blip_AddRef(alt::IBlip* blip);
EXPORT void Blip_RemoveRef(alt::IBlip* blip);
// Blip
EXPORT uint8_t Blip_IsGlobal(alt::IBlip* blip);
EXPORT uint8_t Blip_IsAttached(alt::IBlip* blip);
EXPORT void* Blip_AttachedTo(alt::IBlip* blip, alt::IBaseObject::Type &type);
EXPORT uint8_t Blip_GetType(alt::IBlip* blip);
EXPORT void Blip_SetSprite(alt::IBlip* blip, uint16_t sprite);
EXPORT void Blip_SetColor(alt::IBlip* blip, uint8_t color);
EXPORT void Blip_SetRoute(alt::IBlip* blip, uint8_t state);
EXPORT void Blip_SetRouteColor(alt::IBlip* blip, uint8_t color);
#ifdef __cplusplus
}
#endif
