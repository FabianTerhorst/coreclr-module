#pragma once
#include "altv-cpp-api/SDK.h"
#include "types.h"

extern "C"
{
    EXPORT uint16_t Entity_GetID(alt::IEntity* player);
    EXPORT alt::IWorldObject* Entity_GetWorldObject(alt::IEntity* entity);

    EXPORT uint8_t Entity_HasStreamSyncedMetaData(alt::IEntity* Entity, const char* key);
    EXPORT alt::MValueConst* Entity_GetStreamSyncedMetaData(alt::IEntity* Entity, const char* key);

    EXPORT uint8_t Entity_HasSyncedMetaData(alt::IEntity* Entity, const char* key);
    EXPORT alt::MValueConst* Entity_GetSyncedMetaData(alt::IEntity* Entity, const char* key);
}