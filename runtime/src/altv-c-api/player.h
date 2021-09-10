#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>
#include "position.h"
#include "rotation.h"
#include "cloth.h"
#include "dlc_cloth.h"
#include "prop.h"
#include "dlc_prop.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

typedef struct {
    uint16_t id;
    position_t position;
    rotation_t rotation;
    int32_t dimension;
    uint32_t ping;
    uint32_t model;
    uint8_t seat;
    position_t aim_position;
    rotation_t head_rotation;
    uint16_t armor;
    float move_speed;
    const char* name;
    uint16_t health;
    uint8_t is_in_ragdoll;
    uint8_t is_dead;
    uint8_t is_shooting;
    uint8_t is_aiming;
    uint8_t is_in_vehicle;
    uint8_t is_jumping;
    uint8_t is_reloading;
    uint8_t is_connected;
    alt::IVehicle* vehicle;
} player_struct_t;

#ifdef __cplusplus
extern "C"
{
#endif
// Entity
EXPORT uint16_t Player_GetID(alt::IPlayer* player);
EXPORT alt::IPlayer* Player_GetNetworkOwner(alt::IPlayer* player);
EXPORT uint32_t Player_GetModel(alt::IPlayer* player);
EXPORT void Player_SetModel(alt::IPlayer* player, uint32_t model);
EXPORT void Player_GetPosition(alt::IPlayer* player, position_t &position);
EXPORT void
Player_GetPositionCoords(alt::IPlayer* player, float* position_x, float* position_y, float* position_z, int* dimension);
EXPORT void Player_SetPosition(alt::IPlayer* player, position_t pos);
EXPORT void Player_GetRotation(alt::IPlayer* player, rotation_t &rotation);
EXPORT void Player_SetRotation(alt::IPlayer* player, rotation_t rot);
EXPORT int32_t Player_GetDimension(alt::IPlayer* player);
EXPORT void Player_SetDimension(alt::IPlayer* player, int32_t dimension);
EXPORT alt::MValueConst* Player_GetMetaData(alt::IPlayer* player, const char* key);
EXPORT void Player_SetMetaData(alt::IPlayer* player, const char* key, alt::MValueConst* val);
EXPORT uint8_t Player_HasMetaData(alt::IPlayer* player, const char* key);
EXPORT void Player_DeleteMetaData(alt::IPlayer* player, const char* key);
EXPORT alt::MValueConst* Player_GetSyncedMetaData(alt::IPlayer* player, const char* key);
EXPORT void Player_SetSyncedMetaData(alt::IPlayer* player, const char* key, alt::MValueConst* val);
EXPORT uint8_t Player_HasSyncedMetaData(alt::IPlayer* player, const char* key);
EXPORT void Player_DeleteSyncedMetaData(alt::IPlayer* player, const char* key);
EXPORT alt::MValueConst* Player_GetStreamSyncedMetaData(alt::IPlayer* player, const char* key);
EXPORT void Player_SetStreamSyncedMetaData(alt::IPlayer* player, const char* key, alt::MValueConst* val);
EXPORT uint8_t Player_HasStreamSyncedMetaData(alt::IPlayer* player, const char* key);
EXPORT void Player_DeleteStreamSyncedMetaData(alt::IPlayer* player, const char* key);
EXPORT void Player_AddRef(alt::IPlayer* player);
EXPORT void Player_RemoveRef(alt::IPlayer* player);
EXPORT uint8_t Player_GetVisible(alt::IPlayer* player);
EXPORT void Player_SetVisible(alt::IPlayer* player, uint8_t state);
EXPORT uint8_t Player_GetStreamed(alt::IPlayer* player);
EXPORT void Player_SetStreamed(alt::IPlayer* player, uint8_t state);
// Player
EXPORT uint8_t Player_IsConnected(alt::IPlayer* player);
EXPORT void Player_Spawn(alt::IPlayer* player, alt::Position pos, uint32_t delayMs);
EXPORT void Player_Despawn(alt::IPlayer* player);

EXPORT void Player_GetName(alt::IPlayer* player, const char*&name);

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

EXPORT void Player_GiveWeapon(alt::IPlayer* player, uint32_t weapon, int32_t ammo, uint8_t selectWeapon);
EXPORT uint8_t Player_RemoveWeapon(alt::IPlayer* player, uint32_t weapon);
EXPORT void Player_RemoveAllWeapons(alt::IPlayer* player);

EXPORT void Player_AddWeaponComponent(alt::IPlayer* player, uint32_t weapon, uint32_t component);
EXPORT void Player_RemoveWeaponComponent(alt::IPlayer* player, uint32_t weapon, uint32_t component);
EXPORT uint8_t Player_HasWeaponComponent(alt::IPlayer* player, uint32_t weapon, uint32_t component);
EXPORT void Player_GetCurrentWeaponComponents(alt::IPlayer* player, alt::Array<uint32_t> &weaponComponents);

EXPORT void Player_SetWeaponTintIndex(alt::IPlayer* player, uint32_t weapon, uint8_t tintIndex);
EXPORT uint8_t Player_GetWeaponTintIndex(alt::IPlayer* player, uint32_t weapon);
EXPORT uint8_t Player_GetCurrentWeaponTintIndex(alt::IPlayer* player);

EXPORT uint32_t Player_GetCurrentWeapon(alt::IPlayer* player);
EXPORT void Player_SetCurrentWeapon(alt::IPlayer* player, uint32_t weapon);

EXPORT uint8_t Player_IsDead(alt::IPlayer* player);

EXPORT uint8_t Player_IsJumping(alt::IPlayer* player);
EXPORT uint8_t Player_IsInRagdoll(alt::IPlayer* player);
EXPORT uint8_t Player_IsAiming(alt::IPlayer* player);
EXPORT uint8_t Player_IsShooting(alt::IPlayer* player);
EXPORT uint8_t Player_IsReloading(alt::IPlayer* player);

EXPORT uint16_t Player_GetArmor(alt::IPlayer* player);
EXPORT void Player_SetArmor(alt::IPlayer* player, uint16_t armor);

EXPORT uint16_t Player_GetMaxArmor(alt::IPlayer* player);
EXPORT void Player_SetMaxArmor(alt::IPlayer* player, uint16_t armor);

EXPORT float Player_GetMoveSpeed(alt::IPlayer* player);

EXPORT void Player_GetAimPos(alt::IPlayer* player, position_t &aimPosition);
EXPORT void Player_GetHeadRotation(alt::IPlayer* player, rotation_t &headRotation);

EXPORT uint8_t Player_IsInVehicle(alt::IPlayer* player);
EXPORT alt::IVehicle* Player_GetVehicle(alt::IPlayer* player);
EXPORT uint8_t Player_GetSeat(alt::IPlayer* player);

EXPORT void* Player_GetEntityAimingAt(alt::IPlayer* player, alt::IBaseObject::Type &type);
EXPORT void Player_GetEntityAimOffset(alt::IPlayer* player, position_t &position);

EXPORT uint8_t Player_IsFlashlightActive(alt::IPlayer* player);

EXPORT void Player_Kick(alt::IPlayer* player, const char* reason);

EXPORT uint32_t Player_GetPing(alt::IPlayer* player);
EXPORT void Player_GetIP(alt::IPlayer* player, const char*&ip);

//EXPORT void Player_Copy(alt::IPlayer* player, player_struct_t* player_struct);
//EXPORT void Player_Copy_Dispose(player_struct_t* player_struct);

EXPORT void Player_GetPositionCoords2(alt::IPlayer* player, float* position_x, float* position_y, float* position_z, float* rotation_x, float* rotation_y, float* rotation_z, int* dimension);

EXPORT void Player_SetNetworkOwner(alt::IPlayer* player, alt::IPlayer* networkOwnerPlayer, uint8_t disableMigration);

EXPORT void Player_ClearBloodDamage(alt::IPlayer* player);

EXPORT void Player_GetClothes(alt::IPlayer* player, uint8_t component, cloth_t& cloth);
EXPORT void Player_SetClothes(alt::IPlayer* player, uint8_t component, uint16_t drawable, uint8_t texture, uint8_t palette);

EXPORT void Player_GetDlcClothes(alt::IPlayer* player, uint8_t component, dlccloth_t& cloth);
EXPORT void Player_SetDlcClothes(alt::IPlayer* player, uint8_t component, uint16_t drawable, uint8_t texture, uint8_t palette, uint32_t dlc);

EXPORT void Player_GetProps(alt::IPlayer* player, uint8_t component, prop_t& prop);
EXPORT void Player_SetProps(alt::IPlayer* player, uint8_t component, uint16_t drawable, uint8_t texture);

EXPORT void Player_GetDlcProps(alt::IPlayer* player, uint8_t component, dlcprop_t& prop);
EXPORT void Player_SetDlcProps(alt::IPlayer* player, uint8_t component, uint16_t drawable, uint8_t texture, uint32_t dlc);

EXPORT void Player_ClearProps(alt::IPlayer* player, uint8_t component);

EXPORT uint8_t Player_IsEntityInStreamingRange_Player(alt::IPlayer* player, alt::IPlayer* entity);
EXPORT uint8_t Player_IsEntityInStreamingRange_Vehicle(alt::IPlayer* player, alt::IVehicle* entity);

EXPORT void Player_AttachToEntity_Player(alt::IPlayer* player, alt::IPlayer* entity, int16_t otherBone, int16_t ownBone, position_t pos, rotation_t rot, uint8_t collision, uint8_t noFixedRot);
EXPORT void Player_AttachToEntity_Vehicle(alt::IPlayer* player, alt::IVehicle* entity, int16_t otherBone, int16_t ownBone, position_t pos, rotation_t rot, uint8_t collision, uint8_t noFixedRot);
EXPORT void Player_Detach(alt::IPlayer* player);

EXPORT uint8_t Player_GetInvincible(alt::IPlayer* player);
EXPORT void Player_SetInvincible(alt::IPlayer* player, uint8_t state);

EXPORT void Player_SetIntoVehicle(alt::IPlayer* player, alt::IVehicle* vehicle, uint8_t seat);

#ifdef __cplusplus
}
#endif
