#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif
#include <altv-cpp-api/IBaseObject.h>
#include <altv-cpp-api/API.h>
#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
    EXPORT alt::IBaseObject::Type BaseObject_GetType(alt::IBaseObject *baseObject);
#ifdef __cplusplus
}
#endif
