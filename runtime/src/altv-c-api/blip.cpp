#include "blip.h"

// Entity

void Blip_GetPosition(alt::IBlip* blip, position_t &position) {
    auto blipPosition = blip->GetPosition();
    position.x = blipPosition.x;
    position.y = blipPosition.y;
    position.z = blipPosition.z;
}

void Blip_SetPosition(alt::IBlip* blip, alt::Position pos) {
    blip->SetPosition(pos);
}

int16_t Blip_GetDimension(alt::IBlip* blip) {
    return blip->GetDimension();
}

void Blip_SetDimension(alt::IBlip* blip, uint16_t dimension) {
    blip->SetDimension(dimension);
}

void Blip_GetMetaData(alt::IBlip* blip, const char* key, alt::MValue &val) {
    val = blip->GetMetaData(key);
}

void Blip_SetMetaData(alt::IBlip* blip, const char* key, alt::MValue* val) {
    blip->SetMetaData(key, *val);
}

// Blip

bool Blip_IsGlobal(alt::IBlip* blip) {
    return blip->IsGlobal();
}

bool Blip_IsAttached(alt::IBlip* blip) {
    return blip->IsAttached();
}

void* Blip_AttachedTo(alt::IBlip* blip, alt::IBaseObject::Type &type) {
    auto entity = blip->AttachedTo();
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

uint8_t Blip_GetType(alt::IBlip* blip) {
    return (uint8_t) blip->GetBlipType();
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
