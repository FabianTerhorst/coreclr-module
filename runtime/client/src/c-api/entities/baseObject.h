#pragma once
#include "altv-cpp-api/SDK.h"
#include "types.h"

extern "C"
{
    EXPORT void BaseObject_SetMetaData(alt::IBaseObject* baseObject, const char* key, alt::MValueConst* value);
    EXPORT uint8_t BaseObject_HasMetaData(alt::IBaseObject* baseObject, const char* key);
    EXPORT void BaseObject_DeleteMetaData(alt::IBaseObject* baseObject, const char* key);
    EXPORT alt::MValueConst* BaseObject_GetMetaData(alt::IBaseObject* baseObject, const char* key);

    EXPORT uint8_t BaseObject_GetType(alt::IBaseObject* baseObject);
}