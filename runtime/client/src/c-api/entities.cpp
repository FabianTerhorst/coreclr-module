#include "entities.h"
#include "altv-cpp-api/SDK.h"
#include <Log.h>

using namespace alt;

alt::IPlayer* Player_GetLocal() {
    return alt::ICore::Instance().GetLocalPlayer().Get();
}   

uint16_t Player_GetID(alt::IPlayer* player) {
    return player->GetID();
}

void Player_GetPosition(alt::IPlayer* player, vector3_t& position) {
    auto pos = player->GetPosition();
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
}