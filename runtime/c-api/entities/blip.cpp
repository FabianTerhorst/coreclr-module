#include "blip.h"

alt::IWorldObject* Blip_GetWorldObject(alt::IBlip* blip) {
    return dynamic_cast<alt::IWorldObject*>(blip);
}

uint8_t Blip_IsGlobal(alt::IBlip* blip) {
    return blip->IsGlobal();
}

uint8_t Blip_GetType(alt::IBlip* blip) {
    return (uint8_t) blip->GetBlipType();
}

void Blip_GetScaleXY(alt::IBlip* blip, vector2_t &scale) {
    auto blipScale = blip->GetScaleXY();
    scale.x = blipScale[0];
    scale.y = blipScale[1];
}

void Blip_SetScaleXY(alt::IBlip* blip, vector2_t scale) {
    alt::Vector2f blipScale;
    blipScale[0] = scale.x;
    blipScale[1] = scale.y;
    blip->SetScaleXY(blipScale);
}

int16_t Blip_GetDisplay(alt::IBlip* blip) {
    return blip->GetDisplay();
}

void Blip_SetDisplay(alt::IBlip* blip, int16_t display) {
    blip->SetDisplay(display);
}

uint16_t Blip_GetSprite(alt::IBlip* blip) {
    return blip->GetSprite();
}

void Blip_SetSprite(alt::IBlip* blip, uint16_t sprite) {
    blip->SetSprite(sprite);
}

uint8_t Blip_GetColor(alt::IBlip* blip) {
    return blip->GetColor();
}

void Blip_SetColor(alt::IBlip* blip, uint8_t color) {
    blip->SetColor(color);
}

void Blip_GetSecondaryColor(alt::IBlip* blip, rgba_t &color) {
    auto blipSecondaryColor = blip->GetSecondaryColor();
    color.r = blipSecondaryColor.r;
    color.g = blipSecondaryColor.g;
    color.b = blipSecondaryColor.b;
    color.a = blipSecondaryColor.a;
}

void Blip_SetSecondaryColor(alt::IBlip* blip, rgba_t color) {
    alt::RGBA blipSecondaryColor;
    blipSecondaryColor.r = color.r;
    blipSecondaryColor.g = color.g;
    blipSecondaryColor.b = color.b;
    blipSecondaryColor.a = color.a;
    blip->SetSecondaryColor(blipSecondaryColor);
}

uint8_t Blip_GetAlpha(alt::IBlip* blip) {
    return blip->GetAlpha();
}

void Blip_SetAlpha(alt::IBlip* blip, uint8_t alpha) {
    blip->SetAlpha(alpha);
}

uint16_t Blip_GetFlashTimer(alt::IBlip* blip) {
    return blip->GetFlashTimer();
}

void Blip_SetFlashTimer(alt::IBlip* blip, uint16_t timer) {
    blip->SetFlashTimer(timer);
}

uint16_t Blip_GetFlashInterval(alt::IBlip* blip) {
    return blip->GetFlashInterval();
}

void Blip_SetFlashInterval(alt::IBlip* blip, uint16_t interval) {
    blip->SetFlashInterval(interval);
}

uint8_t Blip_GetAsFriendly(alt::IBlip* blip) {
    return blip->GetAsFriendly();
}

void Blip_SetAsFriendly(alt::IBlip* blip, uint8_t friendly) {
    blip->SetAsFriendly(friendly);
}

uint8_t Blip_GetRoute(alt::IBlip* blip) {
    return blip->GetRoute();
}

void Blip_SetRoute(alt::IBlip* blip, uint8_t state) {
    blip->SetRoute(state);
}

uint8_t Blip_GetBright(alt::IBlip* blip) {
    return blip->GetBright();
}

void Blip_SetBright(alt::IBlip* blip, uint8_t state) {
    blip->SetBright(state);
}

uint16_t Blip_GetNumber(alt::IBlip* blip) {
    return blip->GetNumber();
}

void Blip_SetNumber(alt::IBlip* blip, uint16_t number) {
    blip->SetNumber(number);
}

uint8_t Blip_GetShowCone(alt::IBlip* blip) {
    return blip->GetShowCone();
}

void Blip_SetShowCone(alt::IBlip* blip, uint8_t state) {
    blip->SetShowCone(state);
}

uint8_t Blip_GetFlashes(alt::IBlip* blip) {
    return blip->GetFlashes();
}

void Blip_SetFlashes(alt::IBlip* blip, uint8_t state) {
    blip->SetFlashes(state);
}

uint8_t Blip_GetFlashesAlternate(alt::IBlip* blip) {
    return blip->GetFlashesAlternate();
}

void Blip_SetFlashesAlternate(alt::IBlip* blip, uint8_t state) {
    blip->SetFlashesAlternate(state);
}

uint8_t Blip_GetAsShortRange(alt::IBlip* blip) {
    return blip->GetAsShortRange();
}

void Blip_SetAsShortRange(alt::IBlip* blip, uint8_t state) {
    blip->SetAsShortRange(state);
}

uint16_t Blip_GetPriority(alt::IBlip* blip) {
    return blip->GetPriority();
}

void Blip_SetPriority(alt::IBlip* blip, uint16_t priority) {
    blip->SetPriority(priority);
}

float Blip_GetRotation(alt::IBlip* blip) {
    return blip->GetRotation();
}

void Blip_SetRotation(alt::IBlip* blip, float rotation) {
    blip->SetRotation(rotation);
}

void Blip_GetGxtName(alt::IBlip* blip, const char* &name) {
    name = blip->GetGxtName().CStr();
}

void Blip_SetGxtName(alt::IBlip* blip, const char* name) {
    blip->SetGxtName(name);
}

void Blip_GetName(alt::IBlip* blip, const char* &name) {
    name = blip->GetName().CStr();
}

void Blip_SetName(alt::IBlip* blip, const char* name) {
    blip->SetName(name);
}

void Blip_GetRouteColor(alt::IBlip* blip, rgba_t &color) {
    auto blipRouteColor = blip->GetRouteColor();
    color.r = blipRouteColor.r;
    color.g = blipRouteColor.g;
    color.b = blipRouteColor.b;
    color.a = blipRouteColor.a;
}

void Blip_SetRouteColor(alt::IBlip* blip, rgba_t color) {
    alt::RGBA blipRouteColor;
    blipRouteColor.r = color.r;
    blipRouteColor.g = color.g;
    blipRouteColor.b = color.b;
    blipRouteColor.a = color.a;
    blip->SetRouteColor(blipRouteColor);
}

uint8_t Blip_GetPulse(alt::IBlip* blip) {
    return blip->GetPulse();
}

void Blip_SetPulse(alt::IBlip* blip, uint8_t state) {
    blip->SetPulse(state);
}

uint8_t Blip_GetAsMissionCreator(alt::IBlip* blip) {
    return blip->GetAsMissionCreator();
}

void Blip_SetAsMissionCreator(alt::IBlip* blip, uint8_t state) {
    blip->SetAsMissionCreator(state);
}

uint8_t Blip_GetTickVisible(alt::IBlip* blip) {
    return blip->GetTickVisible();
}

void Blip_SetTickVisible(alt::IBlip* blip, uint8_t state) {
    blip->SetTickVisible(state);
}

uint8_t Blip_GetHeadingIndicatorVisible(alt::IBlip* blip) {
    return blip->GetHeadingIndicatorVisible();
}

void Blip_SetHeadingIndicatorVisible(alt::IBlip* blip, uint8_t state) {
    blip->SetHeadingIndicatorVisible(state);
}

uint8_t Blip_GetOutlineIndicatorVisible(alt::IBlip* blip) {
    return blip->GetOutlineIndicatorVisible();
}

void Blip_SetOutlineIndicatorVisible(alt::IBlip* blip, uint8_t state) {
    blip->SetOutlineIndicatorVisible(state);
}

uint8_t Blip_GetFriendIndicatorVisible(alt::IBlip* blip) {
    return blip->GetFriendIndicatorVisible();
}

void Blip_SetFriendIndicatorVisible(alt::IBlip* blip, uint8_t state) {
    blip->SetFriendIndicatorVisible(state);
}

uint8_t Blip_GetCrewIndicatorVisible(alt::IBlip* blip) {
    return blip->GetCrewIndicatorVisible();
}

void Blip_SetCrewIndicatorVisible(alt::IBlip* blip, uint8_t state) {
    blip->SetCrewIndicatorVisible(state);
}

uint16_t Blip_GetCategory(alt::IBlip* blip) {
    return blip->GetCategory();
}

void Blip_SetCategory(alt::IBlip* blip, uint16_t category) {
    blip->SetCategory(category);
}

uint8_t Blip_GetAsHighDetail(alt::IBlip* blip) {
    return blip->GetAsHighDetail();
}

void Blip_SetAsHighDetail(alt::IBlip* blip, uint8_t state) {
    blip->SetAsHighDetail(state);
}

uint8_t Blip_GetShrinked(alt::IBlip* blip) {
    return blip->GetShrinked();
}

void Blip_SetShrinked(alt::IBlip* blip, uint8_t state) {
    blip->SetShrinked(state);
}

void Blip_Fade(alt::IBlip* blip, uint32_t opacity, uint32_t duration) {
    blip->Fade(opacity, duration);
}


#ifdef ALT_SERVER_API
uint8_t Blip_IsAttached(alt::IBlip* blip) {
    return blip->IsAttached();
}

void* Blip_AttachedTo(alt::IBlip* blip, alt::IBaseObject::Type &type) {
    auto entity = blip->AttachedTo().Get();
    if (entity != nullptr) {
        type = entity->GetType();
        switch (type) {
            case alt::IBaseObject::Type::PLAYER:
                return dynamic_cast<alt::IPlayer*>(entity);
            case alt::IBaseObject::Type::VEHICLE:
                return dynamic_cast<alt::IVehicle*>(entity);
            default:
                return nullptr;
        }
    }
    return nullptr;
}
#endif

#ifdef ALT_CLIENT_API
uint32_t Blip_GetScriptID(alt::IBlip* blip) {
    return blip->GetScriptID();
}
#endif