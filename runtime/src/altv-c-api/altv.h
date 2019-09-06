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
EXPORT void FreeUIntArray(alt::Array<uint16_t> *array);
EXPORT void FreePlayerPointerArray(alt::Array<alt::IPlayer*> *array);
EXPORT void FreeVehiclePointerArray(alt::Array<alt::IVehicle*>* array);
EXPORT void FreeStringViewArray(alt::Array<alt::StringView> *array);
EXPORT void FreeStringArray(alt::Array<alt::String>* array);
EXPORT void FreeMValueArray(alt::Array<alt::MValue> *array);
#ifdef __cplusplus
}
#endif
