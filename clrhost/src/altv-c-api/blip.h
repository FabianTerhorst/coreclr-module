#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif

#include <altv-cpp-api/API.h>
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
EXPORT uint16_t Blip_GetID(alt::IBlip* blip);
EXPORT void Blip_GetPosition(alt::IBlip* blip, position_t &position);
EXPORT void Blip_SetPosition(alt::IBlip* blip, alt::Position pos);
EXPORT int16_t Blip_GetDimension(alt::IBlip* blip);
EXPORT void Blip_SetDimension(alt::IBlip* blip, uint16_t dimension);
EXPORT void Blip_GetMetaData(alt::IBlip* blip, const char* key, alt::MValue &val);
EXPORT void Blip_SetMetaData(alt::IBlip* blip, const char* key, alt::MValue* val);
// Blip
EXPORT bool Blip_IsGlobal(alt::IBlip* blip);
EXPORT bool Blip_IsAttached(alt::IBlip* blip);
EXPORT alt::IEntity* Blip_AttachedTo(alt::IBlip* blip, alt::IBaseObject::Type &type);
EXPORT uint8_t Blip_GetType(alt::IBlip* blip);
EXPORT void Blip_SetSprite(alt::IBlip* blip, uint16_t sprite);
EXPORT void Blip_SetColor(alt::IBlip* blip, uint8_t color);
EXPORT void Blip_SetRoute(alt::IBlip* blip, bool state);
EXPORT void Blip_SetRouteColor(alt::IBlip* blip, uint8_t color);
#ifdef __cplusplus
}
#endif
