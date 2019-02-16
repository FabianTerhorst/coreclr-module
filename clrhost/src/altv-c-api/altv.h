#pragma once

#include "baseobject.h"
#include "blip.h"
#include "checkpoint.h"
#include "entity.h"
#include "player.h"
#include "server.h"
#include "vehicle.h"
#include "mvalue.h"
#include "function.h"

#ifdef __cplusplus
extern "C"
{
#endif

EXPORT void FreeObject(void* pointer);
EXPORT void FreeArray(void* array);

#ifdef __cplusplus
}
#endif
