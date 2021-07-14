#include "blip.h"

// Entity

void Blip_GetPosition(alt::IBlip* blip, position_t &position) {
    auto blipPosition = blip->GetPosition();
    position.x = blipPosition.x;
    position.y = blipPosition.y;
    position.z = blipPosition.z;
}

void Blip_SetPosition(alt::IBlip* blip, position_t pos) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    blip->SetPosition(position);
}

int32_t Blip_GetDimension(alt::IBlip* blip) {
    return blip->GetDimension();
}

void Blip_SetDimension(alt::IBlip* blip, int32_t dimension) {
    blip->SetDimension(dimension);
}

alt::MValueConst* Blip_GetMetaData(alt::IBlip* blip, const char* key) {
    return new alt::MValueConst(blip->GetMetaData(key));
}

void Blip_SetMetaData(alt::IBlip* blip, const char* key, alt::MValueConst* val) {
    if (val == nullptr) return;
    blip->SetMetaData(key, val->Get()->Clone());
}

uint8_t Blip_HasMetaData(alt::IBlip* blip, const char* key) {
    return blip->HasMetaData(key);
}

void Blip_DeleteMetaData(alt::IBlip* blip, const char* key) {
    blip->DeleteMetaData(key);
}

void Blip_AddRef(alt::IBlip* blip) {
    blip->AddRef();
}

void Blip_RemoveRef(alt::IBlip* blip) {
    blip->RemoveRef();
}

// Blip

uint8_t Blip_IsGlobal(alt::IBlip* blip) {
    return blip->IsGlobal();
}

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

uint8_t Blip_GetType(alt::IBlip* blip) {
    return (uint8_t) blip->GetBlipType();
}

void Blip_SetSprite(alt::IBlip* blip, uint16_t sprite) {
    //blip->SetSprite(sprite);
}

void Blip_SetColor(alt::IBlip* blip, uint8_t color) {
    //blip->SetColor(color);
}

void Blip_SetRoute(alt::IBlip* blip, uint8_t state) {
    //blip->SetRoute(state);
}

void Blip_SetRouteColor(alt::IBlip* blip, uint8_t color) {
    //blip->SetRouteColor(color);
}
