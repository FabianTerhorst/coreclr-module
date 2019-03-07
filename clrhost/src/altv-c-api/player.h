#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif

#include <altv-cpp-api/API.h>
#include "position.h"
#include "rotation.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

typedef struct {
    uint16_t id;
    alt::IBaseObject::Type type;
    position_t position;
    rotation_t rotation;
    uint16_t dimension;
} player_struct_t;

#ifdef __cplusplus
extern "C"
{
#endif
// Entity
EXPORT uint16_t Player_GetID(alt::IPlayer* player);
EXPORT uint32_t Player_GetModel(alt::IPlayer* player);
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
EXPORT void Player_Spawn(alt::IPlayer* player, alt::Position pos);
EXPORT void Player_Despawn(alt::IPlayer* player);

EXPORT void Player_GetName(alt::IPlayer* player, const char*&name);
EXPORT void Player_SetName(alt::IPlayer* player, const char* name);

EXPORT uint16_t Player_GetHealth(alt::IPlayer* player);
EXPORT void Player_SetHealth(alt::IPlayer* player, uint16_t health);

EXPORT void Player_SetDateTime(alt::IPlayer* player, int day, int month, int year, int hour, int minute, int second);
EXPORT void Player_SetWeather(alt::IPlayer* player, uint32_t weather);

EXPORT bool Player_IsDead(alt::IPlayer* player);

EXPORT bool Player_IsJumping(alt::IPlayer* player);
EXPORT bool Player_IsInRagdoll(alt::IPlayer* player);
EXPORT bool Player_IsAiming(alt::IPlayer* player);
EXPORT bool Player_IsShooting(alt::IPlayer* player);
EXPORT bool Player_IsReloading(alt::IPlayer* player);

EXPORT uint16_t Player_GetArmor(alt::IPlayer* player);
EXPORT void Player_SetArmor(alt::IPlayer* player, uint16_t armor);

EXPORT float Player_GetMoveSpeed(alt::IPlayer* player);

EXPORT uint32_t Player_GetWeapon(alt::IPlayer* player);
EXPORT uint16_t Player_GetAmmo(alt::IPlayer* player);

EXPORT void Player_GetAimPos(alt::IPlayer* player, position_t &aimPosition);
EXPORT void Player_GetHeadRotation(alt::IPlayer* player, rotation_t &headRotation);

EXPORT bool Player_IsInVehicle(alt::IPlayer* player);
EXPORT alt::IVehicle* Player_GetVehicle(alt::IPlayer* player);
EXPORT uint8_t Player_GetSeat(alt::IPlayer* player);
EXPORT void Player_Kick(alt::IPlayer* player, const char* reason);

EXPORT uint32_t Player_GetPing(alt::IPlayer* player);

EXPORT void Player_Copy(alt::IPlayer* player, player_struct_t* player_struct);
#ifdef __cplusplus
}
#endif
