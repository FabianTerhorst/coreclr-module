#pragma once

#include "utils/export.h"
#include "utils/strings.h"
#include "../../cpp-sdk/SDK.h"

#ifdef __cplusplus
extern "C"
{
#endif

EXPORT_SHARED void FreeUIntArray(alt::Array<uint32_t> *array);
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
