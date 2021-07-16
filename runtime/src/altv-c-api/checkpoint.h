#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>
#include "rgba.h"
#include "position.h"
#include "rotation.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
// Entity
EXPORT void Checkpoint_GetPosition(alt::ICheckpoint* checkpoint, position_t &position);
EXPORT void Checkpoint_SetPosition(alt::ICheckpoint* checkpoint, position_t pos);
EXPORT int32_t Checkpoint_GetDimension(alt::ICheckpoint* checkpoint);
EXPORT void Checkpoint_SetDimension(alt::ICheckpoint* checkpoint, int32_t dimension);
EXPORT alt::MValueConst* Checkpoint_GetMetaData(alt::ICheckpoint* checkpoint, const char* key);
EXPORT void Checkpoint_SetMetaData(alt::ICheckpoint* checkpoint, const char* key, alt::MValueConst* val);
EXPORT uint8_t Checkpoint_HasMetaData(alt::ICheckpoint* checkpoint, const char* key);
EXPORT void Checkpoint_DeleteMetaData(alt::ICheckpoint* checkpoint, const char* key);
EXPORT void Checkpoint_AddRef(alt::ICheckpoint* checkpoint);
EXPORT void Checkpoint_RemoveRef(alt::ICheckpoint* checkpoint);
// Checkpoint
EXPORT uint8_t Checkpoint_GetCheckpointType(alt::ICheckpoint* checkpoint);
EXPORT void Checkpoint_SetCheckpointType(alt::ICheckpoint* checkpoint, uint8_t type);
EXPORT float Checkpoint_GetHeight(alt::ICheckpoint* checkpoint);
EXPORT void Checkpoint_SetHeight(alt::ICheckpoint* checkpoint, float height);
EXPORT float Checkpoint_GetRadius(alt::ICheckpoint* checkpoint);
EXPORT void Checkpoint_SetRadius(alt::ICheckpoint* checkpoint, float radius);
EXPORT void Checkpoint_GetColor(alt::ICheckpoint* checkpoint, rgba_t &color);
EXPORT void Checkpoint_SetColor(alt::ICheckpoint* checkpoint, rgba_t color);
EXPORT uint8_t Checkpoint_IsPlayerIn(alt::ICheckpoint* checkpoint, alt::IPlayer* player);
EXPORT uint8_t Checkpoint_IsVehicleIn(alt::ICheckpoint* checkpoint, alt::IVehicle* vehicle);
EXPORT uint8_t Checkpoint_GetColShapeType(alt::ICheckpoint* checkpoint);
EXPORT void Checkpoint_SetPlayersOnly(alt::ICheckpoint* checkpoint, uint8_t state);
EXPORT uint8_t Checkpoint_IsPlayersOnly(alt::ICheckpoint* checkpoint);
EXPORT void Checkpoint_GetNextPosition(alt::ICheckpoint* checkpoint, position_t &pos);
EXPORT void Checkpoint_SetNextPosition(alt::ICheckpoint* checkpoint, position_t pos);
#ifdef __cplusplus
}
#endif
