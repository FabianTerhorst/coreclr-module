#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif

#include <altv-cpp-api/entities/IPlayer.h>
#include <altv-cpp-api/API.h>

#ifdef __clang__
#pragma clang diagnostic pop
#endif

typedef struct {
    float x;
    float y;
    float z;
} position_t;

typedef struct {
    float roll;
    float pitch;
    float yaw;
} rotation_t;

typedef struct {
    uint16_t id;
    uint8_t type;
    position_t position;
    rotation_t rotation;
    uint16_t dimension;
} player_struct_t;

#ifdef __cplusplus
extern "C"
{
#endif
EXPORT bool Player_IsConnected(alt::IPlayer* player);
EXPORT void Player_Spawn(alt::IPlayer* player, alt::Position pos);
EXPORT void Player_Despawn(alt::IPlayer* player);

EXPORT const char* Player_GetName(alt::IPlayer* player);
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

EXPORT alt::Position Player_GetAimPos(alt::IPlayer* player);
EXPORT alt::Rotation Player_GetHeadRotation(alt::IPlayer* player);

EXPORT bool Player_IsInVehicle(alt::IPlayer* player);
EXPORT alt::IVehicle* Player_GetVehicle(alt::IPlayer* player);
EXPORT uint8_t Player_GetSeat(alt::IPlayer* player);
EXPORT void Player_Kick(alt::IPlayer* player, alt::StringView reason);

EXPORT void Player_Copy(alt::IPlayer* player, player_struct_t* player_struct);
#ifdef __cplusplus
}
#endif
