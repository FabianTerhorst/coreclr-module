#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif

#include <altv-cpp-api/API.h>
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
EXPORT void Checkpoint_SetPosition(alt::ICheckpoint* checkpoint, alt::Position pos);
EXPORT int16_t Checkpoint_GetDimension(alt::ICheckpoint* checkpoint);
EXPORT void Checkpoint_SetDimension(alt::ICheckpoint* checkpoint, uint16_t dimension);
EXPORT void Checkpoint_GetMetaData(alt::ICheckpoint* checkpoint, const char* key, alt::MValue &val);
EXPORT void Checkpoint_SetMetaData(alt::ICheckpoint* checkpoint, const char* key, alt::MValue* val);
// Checkpoint
EXPORT bool Checkpoint_IsGlobal(alt::ICheckpoint* checkpoint);
EXPORT uint8_t Checkpoint_GetCheckpointType(alt::ICheckpoint* checkpoint);
EXPORT float Checkpoint_GetHeight(alt::ICheckpoint* checkpoint);
EXPORT float Checkpoint_GetRadius(alt::ICheckpoint* checkpoint);
EXPORT void Checkpoint_GetColor(alt::ICheckpoint* checkpoint, rgba_t &color);
EXPORT bool Checkpoint_IsPlayerIn(alt::ICheckpoint* checkpoint, alt::IPlayer* player);
EXPORT bool Checkpoint_IsVehicleIn(alt::ICheckpoint* checkpoint, alt::IVehicle* vehicle);
EXPORT alt::IPlayer* Checkpoint_GetTarget(alt::ICheckpoint* checkpoint);
#ifdef __cplusplus
}
#endif
