#pragma once

#include "baseobject.h"
#include "blip.h"
#include "checkpoint.h"
#include "player.h"
#include "server.h"
#include "vehicle.h"
#include "mvalue.h"
#include "function.h"
#include "strings.h"

#ifdef __cplusplus
extern "C"
{
#endif
EXPORT void FreeUIntArray(alt::Array<uint32_t> *array);
//EXPORT void FreePlayerPointerArray(alt::Array<alt::IPlayer*> *array);
//EXPORT void FreeStringViewArray(alt::Array<alt::StringView> *array);
//EXPORT void FreeStringArray(alt::Array<alt::String>* array);
/*EXPORT void FreeMValueArray(alt::Array<alt::MValue> *array);*/
EXPORT void FreeCharArray(char charArray[]);
EXPORT void FreeString(const char* string);
EXPORT const char* GetVersionStatic(int32_t &size);
EXPORT const char* GetBranchStatic(int32_t &size);
#ifdef __cplusplus
}
#endif
