#pragma once
#include "altv-cpp-api/SDK.h"
#include "types.h"

extern "C"
{
    EXPORT uint16_t Entity_GetID(alt::IEntity* player);
    EXPORT alt::IWorldObject* Entity_GetWorldObject(alt::IEntity* entity);
    EXPORT uint8_t Entity_GetTypeByID(alt::ICore* core, uint16_t id, uint8_t& type);

    EXPORT uint32_t Entity_GetModel(alt::IEntity* entity);
    EXPORT void Entity_GetNetOwnerId(alt::IEntity* entity, uint8_t& exists, uint16_t& id);
    EXPORT int32_t Entity_GetScriptID(alt::IEntity* entity);
    EXPORT void Entity_GetRotation(alt::IEntity* entity, vector3_t& rot);

    EXPORT uint8_t Entity_HasStreamSyncedMetaData(alt::IEntity* Entity, const char* key);
    EXPORT alt::MValueConst* Entity_GetStreamSyncedMetaData(alt::IEntity* Entity, const char* key);

    EXPORT uint8_t Entity_HasSyncedMetaData(alt::IEntity* Entity, const char* key);
    EXPORT alt::MValueConst* Entity_GetSyncedMetaData(alt::IEntity* Entity, const char* key);
}