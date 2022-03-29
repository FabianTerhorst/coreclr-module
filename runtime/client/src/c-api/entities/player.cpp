#include "player.h"
#include "../../../../cpp-sdk/SDK.h"
#include <Log.h>
#include "utils.h"

using namespace alt;

uint16_t Player_GetID(alt::IPlayer* player) {
    return player->GetID();
}

alt::IEntity* Player_GetEntity(alt::IPlayer* player) {
    return dynamic_cast<alt::IEntity*>(player);
}


alt::IVehicle* Player_GetVehicle(alt::IPlayer* player) {
    auto vehicle = player->GetVehicle();
    if (vehicle.IsEmpty()) return nullptr;
    return vehicle.Get();
}

char* Player_GetName(alt::IPlayer* player) {
    return utils::get_clr_value(player->GetName().c_str());
}

void Player_GetAimPos(alt::IPlayer* player, vector3_t& pos) {
    auto vector = player->GetAimPos();
    pos.x = vector.x;
    pos.y = vector.y;
    pos.z = vector.z;
}

uint16_t Player_GetArmour(alt::IPlayer* player)
{
    return player->GetArmour();
}

uint32_t Player_GetCurrentWeapon(alt::IPlayer* player) {
    return player->GetCurrentWeapon();
}

void Player_GetCurrentWeaponComponents(alt::IPlayer* player, alt::Array<uint32_t> &weaponComponents) {
    auto currWeaponComponents = player->GetCurrentWeaponComponents();
    alt::Array<uint32_t> values;
    for (auto currWeaponComponent : currWeaponComponents) {
        values.Push(currWeaponComponent);
    }
    weaponComponents = values;
}

void Player_GetEntityAimOffset(alt::IPlayer* player, vector3_t& offset) {
    auto vector = player->GetEntityAimOffset();
    offset.x = vector.x;
    offset.y = vector.y;
    offset.z = vector.z;
}

uint8_t Player_GetEntityAimingAtID(alt::IPlayer* player, uint16_t& id) {
    auto entity = player->GetEntityAimingAt();
    if (entity.IsEmpty()) return false;
    id = entity->GetID();
    return true;
}

uint8_t Player_IsFlashlightActive(alt::IPlayer* player) {
    return player->IsFlashlightActive();
}

void Player_GetHeadRot(alt::IPlayer* player, vector3_t& rot) {
    auto vector = player->GetHeadRotation();
    rot.x = vector.roll;
    rot.y = vector.pitch;
    rot.z = vector.yaw;
}

uint16_t Player_GetHealth(alt::IPlayer* player) {
    return player->GetHealth();
}

uint8_t Player_IsAiming(alt::IPlayer* player) {
    return player->IsAiming();
}

uint8_t Player_IsDead(alt::IPlayer* player) {
    return player->IsDead();
}

uint8_t Player_IsInRagdoll(alt::IPlayer* player) {
    return player->IsInRagdoll();
}

uint8_t Player_IsReloading(alt::IPlayer* player) {
    return player->IsReloading();
}

uint8_t Player_IsTalking(alt::IPlayer* player) {
    return player->IsTalking();
}

uint16_t Player_GetMaxArmour(alt::IPlayer* player) {
    return player->GetMaxArmour();
}

uint16_t Player_GetMaxHealth(alt::IPlayer* player) {
    return player->GetMaxHealth();
}

float Player_GetMicLevel(alt::IPlayer* player) {
    return player->GetMicLevel();
}

float Player_GetMoveSpeed(alt::IPlayer* player) {
    return player->GetMoveSpeed();
}

float Player_GetNonSpatialVolume(alt::IPlayer* player) {
    return player->GetNonSpatialVolume();
}

void Player_SetNonSpatialVolume(alt::IPlayer* player, float value) {
    player->SetNonSpatialVolume(value);
}

uint8_t Player_GetSeat(alt::IPlayer* player) {
    return player->GetSeat();
}

float Player_GetSpatialVolume(alt::IPlayer* player) {
    return player->GetSpatialVolume();
}

void Player_SetSpatialVolume(alt::IPlayer* player, float value) {
    player->SetSpatialVolume(value);
}


alt::ILocalPlayer* Player_GetLocal() {
    return alt::ICore::Instance().GetLocalPlayer().Get();
}

uint16_t LocalPlayer_GetID(alt::ILocalPlayer* player) {
    return player->GetID();
}

alt::IPlayer* LocalPlayer_GetPlayer(alt::ILocalPlayer* localPlayer) {
    return dynamic_cast<alt::IPlayer*>(localPlayer);
}


uint16_t LocalPlayer_GetCurrentAmmo(alt::ILocalPlayer* localPlayer) {
    return localPlayer->GetCurrentAmmo();
}