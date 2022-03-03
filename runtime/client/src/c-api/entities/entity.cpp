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

uint8_t Entity_HasStreamSyncedMetaData(alt::IEntity* Entity, const char* key) {
    return Entity->HasStreamSyncedMetaData(key);
}

alt::MValueConst* Entity_GetStreamSyncedMetaData(alt::IEntity* Entity, const char* key) {
    return new MValueConst(Entity->GetStreamSyncedMetaData(key));
}

uint8_t Entity_HasSyncedMetaData(alt::IEntity* Entity, const char* key) {
    return Entity->HasSyncedMetaData(key);
}

alt::MValueConst* Entity_GetSyncedMetaData(alt::IEntity* Entity, const char* key) {
    return new MValueConst(Entity->GetSyncedMetaData(key));
}
