#include "player.h"

bool Player_IsConnected(alt::IPlayer* player) {
    return player->IsConnected();
}

void Player_Spawn(alt::IPlayer* player, alt::Position pos) {
    player->Spawn(pos);
}

void Player_Despawn(alt::IPlayer* player) {
    player->Despawn();
}

void Player_GetName(alt::IPlayer* player, const char*& name) {
    name = player->GetName().CStr();
}

void Player_SetName(alt::IPlayer* player, const char* name) {
    player->SetName(alt::String(name));
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

alt::Position Player_GetAimPos(alt::IPlayer* player) {
    return player->GetAimPos();
}

alt::Rotation Player_GetHeadRotation(alt::IPlayer* player) {
    return player->GetHeadRotation();
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
    player->Kick(alt::String(reason));
}

void Player_Copy(alt::IPlayer* player, player_struct_t* player_struct) {
    player_struct->id = player->GetID();
    player_struct->type = player->GetType();
    auto position = player->GetPosition();
    player_struct->position.x = position.x;
    player_struct->position.y = position.y;
    player_struct->position.z= position.x;
    auto rotation = player->GetRotation();
    player_struct->rotation.roll = rotation.roll;
    player_struct->rotation.pitch = rotation.pitch;
    player_struct->rotation.yaw = rotation.yaw;
    player_struct->dimension = player->GetDimension();
}