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


uint32_t Entity_GetModel(alt::IEntity* entity) {
    return entity->GetModel();
}

void Entity_GetNetOwnerId(alt::IEntity* entity, uint8_t& exists, uint16_t& id) {
    auto owner = entity->GetNetworkOwner();
    if (owner.IsEmpty()) {
        exists = false;
        return;
    }

    exists = true;
    id = owner->GetID();
}

int32_t Entity_GetScriptID(alt::IEntity* entity) {
    return entity->GetScriptGuid();
}

void Entity_GetRotation(alt::IEntity* entity, vector3_t& rot) {
    auto vector = entity->GetRotation();
    rot.x = vector.roll;
    rot.y = vector.pitch;
    rot.z = vector.yaw;
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
