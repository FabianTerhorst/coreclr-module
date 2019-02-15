#include "blip.h"

bool Blip_IsGlobal(alt::IBlip* blip) {
    return blip->IsGlobal();
}

bool Blip_IsAttached(alt::IBlip* blip) {
    return blip->IsAttached();
}

alt::IEntity* Blip_AttachedTo(alt::IBlip* blip) {
    return blip->AttachedTo();
}

uint8_t Blip_GetType(alt::IBlip* blip) {
    return blip->GetBlipType();
}

void Blip_SetSprite(alt::IBlip* blip, uint16_t sprite) {
    blip->SetSprite(sprite);
}

void Blip_SetColor(alt::IBlip* blip, uint8_t color) {
    blip->SetColor(color);
}

void Blip_SetRoute(alt::IBlip* blip, bool state) {
    blip->SetRoute(state);
}

void Blip_SetRouteColor(alt::IBlip* blip, uint8_t color) {
    blip->SetRouteColor(color);
}
