#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif
#include <altv-cpp-api/entities/IBlip.h>
#include <altv-cpp-api/API.h>
#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
    EXPORT bool Blip_IsGlobal(alt::IBlip *blip);
    EXPORT bool Blip_IsAttached(alt::IBlip *blip);
    EXPORT alt::IEntity *Blip_AttachedTo(alt::IBlip *blip);
    EXPORT uint8_t Blip_GetType(alt::IBlip *blip);
    EXPORT void Blip_SetSprite(alt::IBlip *blip, uint16_t sprite);
    EXPORT void Blip_SetColor(alt::IBlip *blip, uint8_t color);
    EXPORT void Blip_SetRoute(alt::IBlip *blip, bool state);
    EXPORT void Blip_SetRouteColor(alt::IBlip *blip, uint8_t color);
#ifdef __cplusplus
}
#endif
