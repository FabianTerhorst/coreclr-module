#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif

#include <altv-cpp-api/API.h>

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
EXPORT bool Checkpoint_IsGlobal(alt::ICheckpoint* checkpoint);
EXPORT uint8_t Checkpoint_GetCheckpointType(alt::ICheckpoint* checkpoint);
EXPORT float Checkpoint_GetHeight(alt::ICheckpoint* checkpoint);
EXPORT float Checkpoint_GetRadius(alt::ICheckpoint* checkpoint);
EXPORT alt::RGBA Checkpoint_GetColor(alt::ICheckpoint* checkpoint);
#ifdef __cplusplus
}
#endif
