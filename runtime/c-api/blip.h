#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "data/types.h"

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
EXPORT void Blip_GetScaleXY(alt::IBlip* blip, vector2_t &scale);
EXPORT void Blip_SetScaleXY(alt::IBlip* blip, vector2_t scale);
EXPORT int16_t Blip_GetDisplay(alt::IBlip* blip);
EXPORT void Blip_SetDisplay(alt::IBlip* blip, int16_t display);
EXPORT uint16_t Blip_GetSprite(alt::IBlip* blip);
EXPORT void Blip_SetSprite(alt::IBlip* blip, uint16_t sprite);
EXPORT uint8_t Blip_GetColor(alt::IBlip* blip);
EXPORT void Blip_SetColor(alt::IBlip* blip, uint8_t color);
EXPORT void Blip_GetSecondaryColor(alt::IBlip* blip, rgba_t &color);
EXPORT void Blip_SetSecondaryColor(alt::IBlip* blip, rgba_t color);
EXPORT uint8_t Blip_GetAlpha(alt::IBlip* blip);
EXPORT void Blip_SetAlpha(alt::IBlip* blip, uint8_t alpha);
EXPORT uint16_t Blip_GetFlashTimer(alt::IBlip* blip);
EXPORT void Blip_SetFlashTimer(alt::IBlip* blip, uint16_t timer);
EXPORT uint16_t Blip_GetFlashInterval(alt::IBlip* blip);
EXPORT void Blip_SetFlashInterval(alt::IBlip* blip, uint16_t interval);
EXPORT uint8_t Blip_GetAsFriendly(alt::IBlip* blip);
EXPORT void Blip_SetAsFriendly(alt::IBlip* blip, uint8_t friendly);
EXPORT uint8_t Blip_GetRoute(alt::IBlip* blip);
EXPORT void Blip_SetRoute(alt::IBlip* blip, uint8_t state);
EXPORT uint8_t Blip_GetBright(alt::IBlip* blip);
EXPORT void Blip_SetBright(alt::IBlip* blip, uint8_t state);
EXPORT uint16_t Blip_GetNumber(alt::IBlip* blip);
EXPORT void Blip_SetNumber(alt::IBlip* blip, uint16_t number);
EXPORT uint8_t Blip_GetShowCone(alt::IBlip* blip);
EXPORT void Blip_SetShowCone(alt::IBlip* blip, uint8_t state);
EXPORT uint8_t Blip_GetFlashes(alt::IBlip* blip);
EXPORT void Blip_SetFlashes(alt::IBlip* blip, uint8_t state);
EXPORT uint8_t Blip_GetFlashesAlternate(alt::IBlip* blip);
EXPORT void Blip_SetFlashesAlternate(alt::IBlip* blip, uint8_t state);
EXPORT uint8_t Blip_GetAsShortRange(alt::IBlip* blip);
EXPORT void Blip_SetAsShortRange(alt::IBlip* blip, uint8_t state);
EXPORT uint16_t Blip_GetPriority(alt::IBlip* blip);
EXPORT void Blip_SetPriority(alt::IBlip* blip, uint16_t priority);
EXPORT float Blip_GetRotation(alt::IBlip* blip);
EXPORT void Blip_SetRotation(alt::IBlip* blip, float rotation);
EXPORT void Blip_GetGxtName(alt::IBlip* blip, const char* &name);
EXPORT void Blip_SetGxtName(alt::IBlip* blip, const char* name);
EXPORT void Blip_GetName(alt::IBlip* blip, const char* &name);
EXPORT void Blip_SetName(alt::IBlip* blip, const char* name);
EXPORT void Blip_GetRouteColor(alt::IBlip* blip, rgba_t &color);
EXPORT void Blip_SetRouteColor(alt::IBlip* blip, rgba_t color);
EXPORT uint8_t Blip_GetPulse(alt::IBlip* blip);
EXPORT void Blip_SetPulse(alt::IBlip* blip, uint8_t state);
EXPORT uint8_t Blip_GetAsMissionCreator(alt::IBlip* blip);
EXPORT void Blip_SetAsMissionCreator(alt::IBlip* blip, uint8_t state);
EXPORT uint8_t Blip_GetTickVisible(alt::IBlip* blip);
EXPORT void Blip_SetTickVisible(alt::IBlip* blip, uint8_t state);
EXPORT uint8_t Blip_GetHeadingIndicatorVisible(alt::IBlip* blip);
EXPORT void Blip_SetHeadingIndicatorVisible(alt::IBlip* blip, uint8_t state);
EXPORT uint8_t Blip_GetOutlineIndicatorVisible(alt::IBlip* blip);
EXPORT void Blip_SetOutlineIndicatorVisible(alt::IBlip* blip, uint8_t state);
EXPORT uint8_t Blip_GetFriendIndicatorVisible(alt::IBlip* blip);
EXPORT void Blip_SetFriendIndicatorVisible(alt::IBlip* blip, uint8_t state);
EXPORT uint8_t Blip_GetCrewIndicatorVisible(alt::IBlip* blip);
EXPORT void Blip_SetCrewIndicatorVisible(alt::IBlip* blip, uint8_t state);
EXPORT uint16_t Blip_GetCategory(alt::IBlip* blip);
EXPORT void Blip_SetCategory(alt::IBlip* blip, uint16_t category);
EXPORT uint8_t Blip_GetAsHighDetail(alt::IBlip* blip);
EXPORT void Blip_SetAsHighDetail(alt::IBlip* blip, uint8_t state);
EXPORT uint8_t Blip_GetShrinked(alt::IBlip* blip);
EXPORT void Blip_SetShrinked(alt::IBlip* blip, uint8_t state);
EXPORT void Blip_Fade(alt::IBlip* blip, uint32_t opacity, uint32_t duration);
#ifdef __cplusplus
}
#endif