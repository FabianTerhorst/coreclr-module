#pragma once
#include "altv-cpp-api/SDK.h"
#include "../types.h"

extern "C"
{
    EXPORT alt::IPlayer* Player_GetLocal();
    EXPORT uint16_t Player_GetID(alt::IPlayer* player);
    EXPORT void Player_GetPosition(alt::IPlayer* player, vector3_t& position);
}