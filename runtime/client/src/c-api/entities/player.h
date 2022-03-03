#pragma once
#include "altv-cpp-api/SDK.h"
#include "types.h"

extern "C"
{
    EXPORT uint16_t Player_GetID(alt::IPlayer* player); // optimization so the Player_GetEntity isn't needed to retrieve the id
    EXPORT alt::IEntity* Player_GetEntity(alt::IPlayer* player);

    EXPORT uint16_t LocalPlayer_GetID(alt::ILocalPlayer* localPlayer);
    EXPORT alt::ILocalPlayer* Player_GetLocal();
    EXPORT alt::IPlayer* LocalPlayer_GetPlayer(alt::ILocalPlayer* player);

    EXPORT uint8_t Player_GetVehicleId(alt::IPlayer* player, uint16_t& id);
    EXPORT char* Player_GetName(alt::IPlayer* player);
}