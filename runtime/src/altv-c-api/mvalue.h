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

EXPORT void MValue_CreateNil(alt::MValue &mValue);
EXPORT void MValue_CreateBool(bool val, alt::MValue &mValue);
EXPORT void MValue_CreateInt(int64_t val, alt::MValue &mValue);
EXPORT void MValue_CreateUInt(uint64_t val, alt::MValue &mValue);
EXPORT void MValue_CreateDouble(double val, alt::MValue &mValue);
EXPORT void MValue_CreateString(const char* val, alt::MValue &value);
EXPORT void MValue_CreateList(alt::MValue val[], uint64_t size, alt::MValueList &valueList);
EXPORT void MValue_CreateDict(alt::MValue* val, const char** keys, uint64_t size, alt::MValueDict &mValue);
EXPORT void MValue_CreatePlayer(alt::IPlayer* val, alt::MValue &mValue);
EXPORT void MValue_CreateVehicle(alt::IVehicle* val, alt::MValue &mValue);
EXPORT void MValue_CreateBlip(alt::IVehicle* val, alt::MValue &mValue);
EXPORT void MValue_CreateCheckpoint(alt::ICheckpoint* val, alt::MValue &mValue);
EXPORT void MValue_CreateFunction(CustomInvoker* val, alt::MValue &mValue);

EXPORT bool MValue_GetBool(alt::MValue &mValue);
EXPORT int64_t MValue_GetInt(alt::MValue &mValue);
EXPORT uint64_t MValue_GetUInt(alt::MValue &mValue);
EXPORT double MValue_GetDouble(alt::MValue &mValue);
EXPORT void MValue_GetString(alt::MValue &mValue, const char*&value, uint64_t &size);
EXPORT void MValue_GetList(alt::MValue &mValue, alt::MValue::List &value);
EXPORT void MValue_GetDict(alt::MValue &mValue, alt::Array<alt::String> &keys, alt::MValue::List &values);
EXPORT void* MValue_GetEntity(alt::MValue &mValue, alt::IBaseObject::Type &type);
EXPORT MValueFunctionCallback MValue_GetFunction(alt::MValueFunction &mValue);

EXPORT void MValue_CallFunction(alt::MValue* mValue, alt::MValue* args, int32_t size, alt::MValue &result);
EXPORT void MValue_CallFunctionValue(alt::MValueFunction &mValue, alt::MValueList &value, alt::MValue &result);
EXPORT void MValue_Dispose(alt::MValue* mValue);

//EXPORT alt::MValueFunction::Invoker* MValue_GetInvoker(alt::MValueFunction &mValue);
//EXPORT void MValue_CallInvoker(alt::MValueFunction::Invoker &invoker, alt::MValue &value);
#ifdef __cplusplus
}
#endif
