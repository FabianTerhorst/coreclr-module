#include "blip.h"

// Entity

uint16_t Blip_GetID(alt::IBlip* blip) {
    return blip->GetID();
}

void Blip_GetPosition(alt::IBlip* blip, position_t &position) {
    auto blipPosition = blip->GetPosition();
    position.x = blipPosition.x;
    position.y = blipPosition.y;
    position.z = blipPosition.z;
}

void Blip_SetPosition(alt::IBlip* blip, alt::Position pos) {
    blip->SetPosition(pos);
}

void Blip_GetRotation(alt::IBlip* blip, rotation_t &rotation) {
    auto blipRotation = blip->GetRotation();
    rotation.roll = blipRotation.roll;
    rotation.pitch = blipRotation.pitch;
    rotation.yaw = blipRotation.yaw;
}

void Blip_SetRotation(alt::IBlip* blip, alt::Rotation rot) {
    blip->SetRotation(rot);
}

uint16_t Blip_GetDimension(alt::IBlip* blip) {
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

void Blip_GetSyncedMetaData(alt::IBlip* blip, const char* key, alt::MValue &val) {
    val = blip->GetSyncedMetaData(key);
}

void Blip_SetSyncedMetaData(alt::IBlip* blip, const char* key, alt::MValue* val) {
    blip->SetSyncedMetaData(key, *val);
}

// Blip

bool Blip_IsGlobal(alt::IBlip* blip) {
    return blip->IsGlobal();
}

bool Blip_IsAttached(alt::IBlip* blip) {
    return blip->IsAttached();
}

alt::IEntity* Blip_AttachedTo(alt::IBlip* blip, alt::IBaseObject::Type &type) {
    type = blip->AttachedTo()->GetType();
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
