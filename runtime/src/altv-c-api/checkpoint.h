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
EXPORT void Checkpoint_AddRef(alt::ICheckpoint* checkpoint);
EXPORT void Checkpoint_RemoveRef(alt::ICheckpoint* checkpoint);
// Checkpoint
EXPORT uint8_t Checkpoint_GetCheckpointType(alt::ICheckpoint* checkpoint);
EXPORT float Checkpoint_GetHeight(alt::ICheckpoint* checkpoint);
EXPORT float Checkpoint_GetRadius(alt::ICheckpoint* checkpoint);
EXPORT void Checkpoint_GetColor(alt::ICheckpoint* checkpoint, rgba_t &color);
EXPORT bool Checkpoint_IsPlayerIn(alt::ICheckpoint* checkpoint, alt::IPlayer* player);
EXPORT bool Checkpoint_IsVehicleIn(alt::ICheckpoint* checkpoint, alt::IVehicle* vehicle);
#ifdef __cplusplus
}
#endif
