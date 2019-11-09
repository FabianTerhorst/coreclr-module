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
EXPORT CustomInvoker* Invoker_Create(CSharpResourceImpl* resource, MValueFunctionCallback val);
EXPORT void Invoker_Destroy(CSharpResourceImpl* resource, CustomInvoker* val);

/*EXPORT bool MValue_GetBool(alt::MValueBool &mValue);
EXPORT int64_t MValue_GetInt(alt::MValueInt &mValue);
EXPORT uint64_t MValue_GetUInt(alt::MValueUInt &mValue);
EXPORT double MValue_GetDouble(alt::MValueDouble &mValue);
EXPORT void MValue_GetString(alt::MValueString &mValue, const char*&value, uint64_t &size);
EXPORT void MValue_GetList(alt::MValueList &mValue, alt::Array<alt::MValue> &value);
EXPORT void
MValue_GetDict(alt::MValueDict &mValue, alt::Array<alt::String> &keys, alt::Array<alt::MValueConst> &values);
EXPORT void* MValue_GetEntity(alt::MValueBaseObject &mValue, alt::IBaseObject::Type &type);
EXPORT void MValue_CallFunction(alt::MValueFunction &mValue, alt::MValue val[], int32_t size, alt::MValue &result);
EXPORT void MValue_Dispose(alt::MValue* mValue);*/

EXPORT bool MValueConst_GetBool(alt::MValueConst* mValueConst);
EXPORT int64_t MValueConst_GetInt(alt::MValueConst* mValueConst);
EXPORT uint64_t MValueConst_GetUInt(alt::MValueConst* mValueConst);
EXPORT double MValueConst_GetDouble(alt::MValueConst* mValueConst);
EXPORT bool MValueConst_GetString(alt::MValueConst* mValueConst, const char*&value, uint64_t &size);
EXPORT uint64_t MValueConst_GetListSize(alt::MValueConst* mValueConst);
EXPORT bool MValueConst_GetList(alt::MValueConst* mValueConst, alt::MValueConst* values[]);
EXPORT uint64_t MValueConst_GetDictSize(alt::MValueConst* mValueConst);
EXPORT bool MValueConst_GetDict(alt::MValueConst* mValueConst, const char* keys[],
                         alt::MValueConst* values[]);
EXPORT void* MValueConst_GetEntity(alt::MValueConst* mValueConst, alt::IBaseObject::Type &type);
EXPORT alt::MValueConst* MValueConst_CallFunction(alt::MValueConst* mValueConst, alt::MValueConst* val[], uint64_t size);

EXPORT bool MValue_GetBool(alt::MValue* mValueConst);
EXPORT int64_t MValue_GetInt(alt::MValue* mValueConst);
EXPORT uint64_t MValue_GetUInt(alt::MValue* mValueConst);
EXPORT double MValue_GetDouble(alt::MValue* mValueConst);
EXPORT bool MValue_GetString(alt::MValue* mValueConst, const char*&value, uint64_t &size);
EXPORT uint64_t MValue_GetListSize(alt::MValue* mValueConst);
EXPORT bool MValue_GetList(alt::MValue* mValueConst, alt::MValue* values[]);
EXPORT uint64_t MValue_GetDictSize(alt::MValue* mValueConst);
EXPORT bool MValue_GetDict(alt::MValue* mValueConst, const char* keys[],
                                alt::MValueConst* values[]);
EXPORT void* MValue_GetEntity(alt::MValue* mValueConst, alt::IBaseObject::Type &type);
EXPORT alt::MValue* MValue_CallFunction(alt::MValue* mValueConst, alt::MValue* val[], uint64_t size);

EXPORT void MValueConst_Delete(alt::MValueConst* mValueConst);
EXPORT void MValue_Delete(alt::MValue* mValue);
EXPORT uint8_t MValueConst_GetType(alt::MValueConst* mValueConst);
EXPORT uint8_t MValue_GetType(alt::MValue* mValueConst);
#ifdef __cplusplus
}
#endif
