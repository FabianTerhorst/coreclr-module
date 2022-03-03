#include "entity.h"
#include "altv-cpp-api/SDK.h"
#include <Log.h>

using namespace alt;

uint16_t Entity_GetID(alt::IEntity* player) {
    return player->GetID();
}

alt::IWorldObject* Entity_GetWorldObject(alt::IEntity* entity) {
    return dynamic_cast<alt::IWorldObject*>(entity);
}