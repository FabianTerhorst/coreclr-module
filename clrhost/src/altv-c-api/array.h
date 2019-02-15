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
EXPORT alt::Array<alt::MValue> MValueArray_Create();
EXPORT void MValueArray_Push(alt::Array<alt::MValue> arr, const alt::MValue &val);
#ifdef __cplusplus
}
#endif
