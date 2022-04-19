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

EXPORT_SHARED alt::IColShape* Checkpoint_GetColShape(alt::ICheckpoint* checkpoint);

EXPORT_SHARED uint8_t Checkpoint_GetCheckpointType(alt::ICheckpoint* checkpoint);
EXPORT_SHARED void Checkpoint_SetCheckpointType(alt::ICheckpoint* checkpoint, uint8_t type);
EXPORT_SHARED float Checkpoint_GetHeight(alt::ICheckpoint* checkpoint);
EXPORT_SHARED void Checkpoint_SetHeight(alt::ICheckpoint* checkpoint, float height);
EXPORT_SHARED float Checkpoint_GetRadius(alt::ICheckpoint* checkpoint);
EXPORT_SHARED void Checkpoint_SetRadius(alt::ICheckpoint* checkpoint, float radius);
EXPORT_SHARED void Checkpoint_GetColor(alt::ICheckpoint* checkpoint, rgba_t &color);
EXPORT_SHARED void Checkpoint_SetColor(alt::ICheckpoint* checkpoint, rgba_t color);
EXPORT_SHARED void Checkpoint_GetNextPosition(alt::ICheckpoint* checkpoint, vector3_t &pos);
EXPORT_SHARED void Checkpoint_SetNextPosition(alt::ICheckpoint* checkpoint, vector3_t pos);

#ifdef __cplusplus
}
#endif
