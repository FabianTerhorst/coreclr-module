#include "player.h"

// Entity

uint16_t Player_GetID(alt::IPlayer* player) {
    return player->GetID();
}

uint32_t Player_GetModel(alt::IPlayer* player) {
    return player->GetModel();
}

void Player_GetPosition(alt::IPlayer* player, position_t& position) {
    auto playerPosition = player->GetPosition();
    position.x = playerPosition.x;
    position.y = playerPosition.y;
    position.z = playerPosition.z;
}

void Player_SetPosition(alt::IPlayer* player, alt::Position pos) {
    player->SetPosition(pos);
}

void Player_GetRotation(alt::IPlayer* player, rotation_t& rotation) {
    auto playerRotation = player->GetRotation();
    rotation.roll = playerRotation.roll;
    rotation.pitch = playerRotation.pitch;
    rotation.yaw = playerRotation.yaw;
}

void Player_SetRotation(alt::IPlayer* player, alt::Rotation rot) {
    player->SetRotation(rot);
}

int16_t Player_GetDimension(alt::IPlayer* player) {
    return player->GetDimension();
}

void Player_SetDimension(alt::IPlayer* player, uint16_t dimension) {
    player->SetDimension(dimension);
}

void Player_GetMetaData(alt::IPlayer* player, const char* key, alt::MValue &val) {
    val = player->GetMetaData(key);
}

void Player_SetMetaData(alt::IPlayer* player, const char* key, alt::MValue* val) {
    player->SetMetaData(key, *val);
}

void Player_GetSyncedMetaData(alt::IPlayer* player, const char* key, alt::MValue &val) {
    val = player->GetSyncedMetaData(key);
}

void Player_SetSyncedMetaData(alt::IPlayer* player, const char* key, alt::MValue* val) {
    player->SetSyncedMetaData(key, *val);
}

// Player

bool Player_IsConnected(alt::IPlayer* player) {
    return player->IsConnected();
}

void Player_Spawn(alt::IPlayer* player, alt::Position pos) {
    player->Spawn(pos);
}

void Player_Despawn(alt::IPlayer* player) {
    player->Despawn();
}

void Player_GetName(alt::IPlayer* player, const char*&name) {
    name = player->GetName().CStr();
}

void Player_SetName(alt::IPlayer* player, const char* name) {
    player->SetName(name);
}

uint16_t Player_GetHealth(alt::IPlayer* player) {
    return player->GetHealth();
}

void Player_SetHealth(alt::IPlayer* player, uint16_t health) {
    player->SetHealth(health);
}

void Player_SetDateTime(alt::IPlayer* player, int day, int month, int year, int hour, int minute, int second) {
    player->SetDateTime(day, month, year, hour, minute, second);
}

void Player_SetWeather(alt::IPlayer* player, uint32_t weather) {
    player->SetWeather(weather);
}

bool Player_IsDead(alt::IPlayer* player) {
    return player->IsDead();
}

bool Player_IsJumping(alt::IPlayer* player) {
    return player->IsJumping();
}

bool Player_IsInRagdoll(alt::IPlayer* player) {
    return player->IsInRagdoll();
}

bool Player_IsAiming(alt::IPlayer* player) {
    return player->IsAiming();
}

bool Player_IsShooting(alt::IPlayer* player) {
    return player->IsShooting();
}

bool Player_IsReloading(alt::IPlayer* player) {
    return player->IsReloading();
}

uint16_t Player_GetArmor(alt::IPlayer* player) {
    return player->GetArmor();
}

void Player_SetArmor(alt::IPlayer* player, uint16_t armor) {
    player->SetArmor(armor);
}

float Player_GetMoveSpeed(alt::IPlayer* player) {
    return player->GetMoveSpeed();
}

uint32_t Player_GetWeapon(alt::IPlayer* player) {
    return player->GetWeapon();
}

uint16_t Player_GetAmmo(alt::IPlayer* player) {
    return player->GetAmmo();
}

void Player_GetAimPos(alt::IPlayer* player, position_t& aimPosition) {
    auto playerAimPosition = player->GetAimPos();
    aimPosition.x = playerAimPosition.x;
    aimPosition.y = playerAimPosition.y;
    aimPosition.z = playerAimPosition.z;
}

void Player_GetHeadRotation(alt::IPlayer* player, rotation_t& headRotation) {
    auto playerHeadRotation = player->GetHeadRotation();
    headRotation.roll = playerHeadRotation.roll;
    headRotation.pitch = playerHeadRotation.pitch;
    headRotation.yaw = playerHeadRotation.yaw;
}

bool Player_IsInVehicle(alt::IPlayer* player) {
    return player->IsInVehicle();
}

alt::IVehicle* Player_GetVehicle(alt::IPlayer* player) {
    return player->GetVehicle();
}

uint8_t Player_GetSeat(alt::IPlayer* player) {
    return player->GetSeat();
}

void Player_Kick(alt::IPlayer* player, const char* reason) {
    player->Kick(reason);
}

uint32_t Player_GetPing(alt::IPlayer* player) {
    return player->GetPing();
}

void Player_Copy(alt::IPlayer* player, player_struct_t* player_struct) {
    player_struct->id = player->GetID();
    player_struct->type = player->GetType();
    auto position = player->GetPosition();
    player_struct->position.x = position.x;
    player_struct->position.y = position.y;
    player_struct->position.z = position.x;
    auto rotation = player->GetRotation();
    player_struct->rotation.roll = rotation.roll;
    player_struct->rotation.pitch = rotation.pitch;
    player_struct->rotation.yaw = rotation.yaw;
    player_struct->dimension = player->GetDimension();
}