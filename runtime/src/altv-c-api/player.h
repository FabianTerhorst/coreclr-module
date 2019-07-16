#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>
#include "position.h"
#include "rotation.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

typedef struct {
    uint16_t id;
    position_t position;
    rotation_t rotation;
    int16_t dimension;
    uint32_t ping;
    uint32_t model;
    uint8_t seat;
    position_t aim_position;
    rotation_t head_rotation;
    uint16_t armor;
    float move_speed;
    const char* name;
    uint16_t health;
    bool is_in_ragdoll;
    bool is_dead;
    bool is_shooting;
    bool is_aiming;
    bool is_in_vehicle;
    bool is_jumping;
    bool is_reloading;
    bool is_connected;
    alt::IVehicle* vehicle;
} player_struct_t;

#ifdef __cplusplus
extern "C"
{
#endif
// Entity
EXPORT uint16_t Player_GetID(alt::IPlayer* player);
EXPORT uint32_t Player_GetModel(alt::IPlayer* player);
EXPORT void Player_SetModel(alt::IPlayer* player, uint32_t model);
EXPORT void Player_GetPosition(alt::IPlayer* player, position_t &position);
EXPORT void Player_SetPosition(alt::IPlayer* player, alt::Position pos);
EXPORT void Player_GetRotation(alt::IPlayer* player, rotation_t &rotation);
EXPORT void Player_SetRotation(alt::IPlayer* player, alt::Rotation rot);
EXPORT int16_t Player_GetDimension(alt::IPlayer* player);
EXPORT void Player_SetDimension(alt::IPlayer* player, uint16_t dimension);
EXPORT void Player_GetMetaData(alt::IPlayer* player, const char* key, alt::MValue &val);
EXPORT void Player_SetMetaData(alt::IPlayer* player, const char* key, alt::MValue* val);
EXPORT void Player_GetSyncedMetaData(alt::IPlayer* player, const char* key, alt::MValue &val);
EXPORT void Player_SetSyncedMetaData(alt::IPlayer* player, const char* key, alt::MValue* val);
// Player
EXPORT bool Player_IsConnected(alt::IPlayer* player);
EXPORT void Player_Spawn(alt::IPlayer* player, alt::Position pos, uint32_t delayMs);
EXPORT void Player_Despawn(alt::IPlayer* player);

EXPORT void Player_GetName(alt::IPlayer* player, const char*&name);
EXPORT void Player_SetName(alt::IPlayer* player, const char* name);

EXPORT uint64_t Player_GetSocialID(alt::IPlayer* player);
EXPORT uint64_t Player_GetHwidHash(alt::IPlayer* player);
EXPORT uint64_t Player_GetHwidExHash(alt::IPlayer* player);
EXPORT void Player_GetAuthToken(alt::IPlayer* player, const char*&name);

EXPORT uint16_t Player_GetHealth(alt::IPlayer* player);
EXPORT void Player_SetHealth(alt::IPlayer* player, uint16_t health);

EXPORT uint16_t Player_GetMaxHealth(alt::IPlayer* player);
EXPORT void Player_SetMaxHealth(alt::IPlayer* player, uint16_t maxHealth);

EXPORT void Player_SetDateTime(alt::IPlayer* player, int day, int month, int year, int hour, int minute, int second);
EXPORT void Player_SetWeather(alt::IPlayer* player, uint32_t weather);

EXPORT void Player_GiveWeapon(alt::IPlayer* player, uint32_t weapon, int32_t ammo, bool selectWeapon);
EXPORT void Player_RemoveWeapon(alt::IPlayer* player, uint32_t weapon);
EXPORT void Player_RemoveAllWeapons(alt::IPlayer* player);

EXPORT void Player_AddWeaponComponent(alt::IPlayer* player, uint32_t weapon, uint32_t component);
EXPORT void Player_RemoveWeaponComponent(alt::IPlayer* player, uint32_t weapon, uint32_t component);
EXPORT void Player_GetCurrentWeaponComponents(alt::IPlayer* player, alt::Array<uint32_t> &weaponComponents);

EXPORT void Player_SetWeaponTintIndex(alt::IPlayer* player, uint32_t weapon, uint8_t tintIndex);
EXPORT uint8_t Player_GetCurrentWeaponTintIndex(alt::IPlayer* player);

EXPORT uint32_t Player_GetCurrentWeapon(alt::IPlayer* player);
EXPORT void Player_SetCurrentWeapon(alt::IPlayer* player, uint32_t weapon);

EXPORT bool Player_IsDead(alt::IPlayer* player);

EXPORT bool Player_IsJumping(alt::IPlayer* player);
EXPORT bool Player_IsInRagdoll(alt::IPlayer* player);
EXPORT bool Player_IsAiming(alt::IPlayer* player);
EXPORT bool Player_IsShooting(alt::IPlayer* player);
EXPORT bool Player_IsReloading(alt::IPlayer* player);

EXPORT uint16_t Player_GetArmor(alt::IPlayer* player);
EXPORT void Player_SetArmor(alt::IPlayer* player, uint16_t armor);

EXPORT uint16_t Player_GetMaxArmor(alt::IPlayer* player);
EXPORT void Player_SetMaxArmor(alt::IPlayer* player, uint16_t armor);

EXPORT float Player_GetMoveSpeed(alt::IPlayer* player);

EXPORT uint32_t Player_GetWeapon(alt::IPlayer* player);
EXPORT uint16_t Player_GetAmmo(alt::IPlayer* player);

EXPORT void Player_GetAimPos(alt::IPlayer* player, position_t &aimPosition);
EXPORT void Player_GetHeadRotation(alt::IPlayer* player, rotation_t &headRotation);

EXPORT bool Player_IsInVehicle(alt::IPlayer* player);
EXPORT alt::IVehicle* Player_GetVehicle(alt::IPlayer* player);
EXPORT uint8_t Player_GetSeat(alt::IPlayer* player);

EXPORT alt::IEntity* Player_GetEntityAimingAt(alt::IPlayer* player, alt::IBaseObject::Type &type);
EXPORT void Player_GetEntityAimOffset(alt::IPlayer* player, position_t &position);

EXPORT bool Player_IsFlashlightActive(alt::IPlayer* player);

EXPORT void Player_Kick(alt::IPlayer* player, const char* reason);

EXPORT uint32_t Player_GetPing(alt::IPlayer* player);
EXPORT void Player_GetIP(alt::IPlayer* player, const char*&ip);

EXPORT void Player_Copy(alt::IPlayer* player, player_struct_t* player_struct);
EXPORT void Player_Copy_Dispose(player_struct_t* player_struct);
#ifdef __cplusplus
}
#endif
