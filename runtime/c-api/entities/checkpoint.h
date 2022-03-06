#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "../data/types.h"
#include "../utils/export.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif

EXPORT_SERVER alt::IWorldObject* Checkpoint_GetWorldObject(alt::ICheckpoint* checkpoint);

EXPORT_SERVER uint8_t Checkpoint_GetCheckpointType(alt::ICheckpoint* checkpoint);
EXPORT_SERVER void Checkpoint_SetCheckpointType(alt::ICheckpoint* checkpoint, uint8_t type);
EXPORT_SERVER float Checkpoint_GetHeight(alt::ICheckpoint* checkpoint);
EXPORT_SERVER void Checkpoint_SetHeight(alt::ICheckpoint* checkpoint, float height);
EXPORT_SERVER float Checkpoint_GetRadius(alt::ICheckpoint* checkpoint);
EXPORT_SERVER void Checkpoint_SetRadius(alt::ICheckpoint* checkpoint, float radius);
EXPORT_SERVER void Checkpoint_GetColor(alt::ICheckpoint* checkpoint, rgba_t &color);
EXPORT_SERVER void Checkpoint_SetColor(alt::ICheckpoint* checkpoint, rgba_t color);
EXPORT_SERVER uint8_t Checkpoint_IsEntityIn(alt::ICheckpoint* checkpoint, alt::IEntity* entity);
EXPORT_SERVER uint8_t Checkpoint_GetColShapeType(alt::ICheckpoint* checkpoint);
EXPORT_SERVER void Checkpoint_SetPlayersOnly(alt::ICheckpoint* checkpoint, uint8_t state);
EXPORT_SERVER uint8_t Checkpoint_IsPlayersOnly(alt::ICheckpoint* checkpoint);
EXPORT_SERVER void Checkpoint_GetNextPosition(alt::ICheckpoint* checkpoint, position_t &pos);
EXPORT_SERVER void Checkpoint_SetNextPosition(alt::ICheckpoint* checkpoint, position_t pos);

#ifdef __cplusplus
}
#endif
