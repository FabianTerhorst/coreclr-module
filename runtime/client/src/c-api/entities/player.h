#pragma once
#include "altv-cpp-api/SDK.h"
#include "types.h"

extern "C"
{
    EXPORT uint16_t Player_GetID(alt::IPlayer* player); // optimization so the Player_GetEntity isn't needed to retrieve the id
    EXPORT alt::IEntity* Player_GetEntity(alt::IPlayer* player);

    EXPORT uint8_t Player_GetVehicleId(alt::IPlayer* player, uint16_t& id);
    EXPORT char* Player_GetName(alt::IPlayer* player);
    EXPORT void Player_GetAimPos(alt::IPlayer* player, vector3_t& pos);
    EXPORT uint16_t Player_GetArmour(alt::IPlayer* player);
    EXPORT uint32_t Player_GetCurrentWeapon(alt::IPlayer* player);
    // todo current weapon components
    EXPORT void Player_GetEntityAimOffset(alt::IPlayer* player, vector3_t& offset);
    // todo entity aiming at
    EXPORT uint8_t Player_IsFlashlightActive(alt::IPlayer* player);
    EXPORT void Player_GetHeadRot(alt::IPlayer* player, vector3_t& rot);
    EXPORT uint16_t Player_GetHealth(alt::IPlayer* player);
    EXPORT uint8_t Player_IsAiming(alt::IPlayer* player);
    EXPORT uint8_t Player_IsDead(alt::IPlayer* player);
    EXPORT uint8_t Player_IsInRagdoll(alt::IPlayer* player);
    EXPORT uint8_t Player_IsReloading(alt::IPlayer* player);
    EXPORT uint8_t Player_IsTalking(alt::IPlayer* player);
    EXPORT uint16_t Player_GetMaxArmour(alt::IPlayer* player);
    EXPORT uint16_t Player_GetMaxHealth(alt::IPlayer* player);
    EXPORT float Player_GetMicLevel(alt::IPlayer* player);
    EXPORT float Player_GetMoveSpeed(alt::IPlayer* player);
    EXPORT float Player_GetNonSpatialVolume(alt::IPlayer* player);
    EXPORT void Player_SetNonSpatialVolume(alt::IPlayer* player, float value);
    EXPORT uint8_t Player_GetSeat(alt::IPlayer* player);
    EXPORT float Player_GetSpatialVolume(alt::IPlayer* player);
    EXPORT void Player_SetSpatialVolume(alt::IPlayer* player, float value);

    EXPORT uint16_t LocalPlayer_GetID(alt::ILocalPlayer* localPlayer);
    EXPORT alt::ILocalPlayer* Player_GetLocal();
    EXPORT alt::IPlayer* LocalPlayer_GetPlayer(alt::ILocalPlayer* player);

    EXPORT uint16_t LocalPlayer_GetCurrentAmmo(alt::ILocalPlayer* localPlayer);
}