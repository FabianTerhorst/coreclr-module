#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif
#include <altv-cpp-api/types/MValue.h>
#include <altv-cpp-api/API.h>
#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
    EXPORT alt::MValue MValue_CreateNil();
    EXPORT alt::MValue MValue_CreateBool(const bool &val);
    EXPORT alt::MValue MValue_CreateInt(const int32_t &val);
    EXPORT alt::MValue MValue_CreateUInt(const uint32_t &val);
    EXPORT alt::MValue MValue_CreateDouble(const double &val);
    EXPORT alt::MValue MValue_CreateString(const char *val);
    EXPORT alt::MValue MValue_CreateList(const alt::Array<alt::MValue> &val);
    EXPORT alt::MValue MValue_CreateDict(const std::unordered_map<alt::String, alt::MValue> &val);
    EXPORT alt::MValue MValue_CreateEntity(const alt::IBaseObject *&val);
    EXPORT alt::MValue MValue_CreateFunction(const alt::MValue::Function &val);
#ifdef __cplusplus
}
#endif
