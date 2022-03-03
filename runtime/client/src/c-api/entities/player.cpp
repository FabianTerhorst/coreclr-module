#include "player.h"
#include "altv-cpp-api/SDK.h"
#include <Log.h>

using namespace alt;

uint16_t Player_GetID(alt::IPlayer* player) {
    return player->GetID();
}

alt::IEntity* Player_GetEntity(alt::IPlayer* player) {
    return dynamic_cast<alt::IEntity*>(player);
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


uint8_t Player_GetVehicleId(alt::IPlayer* player, uint16_t& id) {
    auto vehicle = player->GetVehicle();
    if (vehicle.IsEmpty() || vehicle.Get() == nullptr) return 0;
    id = vehicle->GetID();
    return 1;
}