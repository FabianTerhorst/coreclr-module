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
EXPORT_SHARED void FreeCharArray(char charArray[]);
EXPORT_SHARED void FreeString(const char* string);
EXPORT_SHARED void FreeStringArray(const char** stringArray, uint32_t size);
EXPORT_SHARED void FreeResourceArray(alt::IResource** resourceArray);
EXPORT_SHARED const char* GetVersionStatic(int32_t &size);
EXPORT_SHARED const char* GetBranchStatic(int32_t &size);
EXPORT_SHARED const char* GetCApiVersion(int32_t &size);

EXPORT_CLIENT void FreeRmlElementArray(alt::IRmlElement** rmlElementArray);

#ifdef __cplusplus
}
#endif
