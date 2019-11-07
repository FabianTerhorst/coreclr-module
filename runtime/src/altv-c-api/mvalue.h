#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>
#include <CSharpResourceImpl.h>

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
EXPORT alt::IMValueFunction::Impl* Invoker_Create(CSharpResourceImpl* resource, MValueFunctionCallback val);
EXPORT void Invoker_Destroy(CSharpResourceImpl* resource, CustomInvoker* val);

EXPORT bool MValue_GetBool(alt::MValueBool &mValue);
EXPORT int64_t MValue_GetInt(alt::MValueInt &mValue);
EXPORT uint64_t MValue_GetUInt(alt::MValueUInt &mValue);
EXPORT double MValue_GetDouble(alt::MValueDouble &mValue);
EXPORT void MValue_GetString(alt::MValueString &mValue, const char*&value, uint64_t &size);
EXPORT void MValue_GetList(alt::MValueList &mValue, alt::Array<alt::MValue> &value);
EXPORT void
MValue_GetDict(alt::MValueDict &mValue, alt::Array<alt::String> &keys, alt::Array<alt::MValueConst> &values);
EXPORT void* MValue_GetEntity(alt::MValueBaseObject &mValue, alt::IBaseObject::Type &type);
EXPORT void MValue_CallFunction(alt::MValueFunction &mValue, alt::MValue val[], int32_t size, alt::MValue &result);
EXPORT void MValue_Dispose(alt::MValue* mValue);

EXPORT bool MValueConst_GetBool(alt::MValueConst* mValueConst);
EXPORT int64_t MValueConst_GetInt(alt::MValueConst* mValueConst);
EXPORT uint64_t MValueConst_GetUInt(alt::MValueConst* mValueConst);
EXPORT double MValueConst_GetDouble(alt::MValueConst* mValueConst);
EXPORT bool MValueConst_GetString(alt::MValueConst* mValueConst, const char*&value, uint64_t &size);
EXPORT bool MValueConst_GetList(alt::MValueConst* mValueConst, alt::Array<alt::MValueConst> &value);
EXPORT bool MValueConst_GetDict(alt::MValueConst* mValueConst, alt::Array<alt::String> &keys, alt::Array<alt::MValueConst> &values);
EXPORT void* MValueConst_GetEntity(alt::MValueConst* mValueConst, alt::IBaseObject::Type &type);
EXPORT bool MValueConst_CallFunction(alt::MValueConst* mValueConst, alt::MValue val[], int32_t size, alt::MValue &result);
EXPORT void MValueConst_Delete(alt::MValueConst* mValueConst);
EXPORT uint8_t MValueConst_GetType(alt::MValueConst* mValueConst);
#ifdef __cplusplus
}
#endif
