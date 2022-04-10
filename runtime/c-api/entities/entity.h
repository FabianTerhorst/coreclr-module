#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "../utils/export.h"
#include "../data/types.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif

EXPORT_SHARED uint16_t Entity_GetID(alt::IEntity* entity);
EXPORT_SHARED alt::IWorldObject* Entity_GetWorldObject(alt::IEntity* entity);
EXPORT_SHARED uint8_t Entity_GetTypeByID(alt::ICore* core, uint16_t id, uint8_t& type);

EXPORT_SHARED uint32_t Entity_GetModel(alt::IEntity* entity);
EXPORT_SHARED uint8_t Entity_GetNetOwnerID(alt::IEntity* entity, uint16_t& id);
EXPORT_SHARED alt::IPlayer* Entity_GetNetOwner(alt::IEntity* entity);
EXPORT_SHARED void Entity_GetRotation(alt::IEntity* entity, rotation_t& rot);

EXPORT_SHARED uint8_t Entity_HasStreamSyncedMetaData(alt::IEntity* Entity, const char* key);
EXPORT_SHARED alt::MValueConst* Entity_GetStreamSyncedMetaData(alt::IEntity* Entity, const char* key);
EXPORT_SHARED uint8_t Entity_HasSyncedMetaData(alt::IEntity* Entity, const char* key);
EXPORT_SHARED alt::MValueConst* Entity_GetSyncedMetaData(alt::IEntity* Entity, const char* key);

EXPORT_SERVER void Entity_SetNetOwner(alt::IEntity* entity, alt::IPlayer* networkOwnerPlayer, uint8_t disableMigration);
EXPORT_SERVER void Entity_SetRotation(alt::IEntity* entity, rotation_t rot);

EXPORT_SERVER void Entity_SetStreamSyncedMetaData(alt::IEntity* entity, const char* key, alt::MValueConst* val);
EXPORT_SERVER void Entity_DeleteStreamSyncedMetaData(alt::IEntity* entity, const char* key);
EXPORT_SERVER void Entity_SetSyncedMetaData(alt::IEntity* entity, const char* key, alt::MValueConst* val);
EXPORT_SERVER void Entity_DeleteSyncedMetaData(alt::IEntity* entity, const char* key);

EXPORT_SERVER uint8_t Entity_GetVisible(alt::IEntity* entity);
EXPORT_SERVER void Entity_SetVisible(alt::IEntity* entity, uint8_t state);

EXPORT_SERVER uint8_t Entity_GetStreamed(alt::IEntity* entity);
EXPORT_SERVER void Entity_SetStreamed(alt::IEntity* entity, uint8_t state);

EXPORT_CLIENT int32_t Entity_GetScriptID(alt::IEntity* entity);

EXPORT_SERVER uint8_t Entity_IsFrozen(alt::IEntity* entity);
EXPORT_SERVER void Entity_SetFrozen(alt::IEntity* entity, uint8_t state);

EXPORT_SERVER uint8_t Entity_HasCollision(alt::IEntity* entity);
EXPORT_SERVER void Entity_SetCollision(alt::IEntity* entity, uint8_t state);

#ifdef __cplusplus
}
#endif
