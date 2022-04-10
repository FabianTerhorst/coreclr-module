#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "../../cpp-sdk/types/IConnectionInfo.h"
#include "utils/export.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif


EXPORT_CLIENT void LocalStorage_SetKey(alt::ILocalStorage* localStorage, const char* key, alt::MValueConst* value);
EXPORT_CLIENT void LocalStorage_DeleteKey(alt::ILocalStorage* localStorage, const char* key);
EXPORT_CLIENT alt::MValueConst* LocalStorage_GetKey(alt::ILocalStorage* localStorage, const char* key);
EXPORT_CLIENT void LocalStorage_Clear(alt::ILocalStorage* localStorage);
EXPORT_CLIENT void LocalStorage_Save(alt::ILocalStorage* localStorage);

#ifdef __cplusplus
}
#endif
