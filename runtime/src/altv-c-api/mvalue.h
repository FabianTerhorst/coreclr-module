#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <CSharpResourceImpl.h>

#ifdef __clang__
#pragma clang diagnostic pop
#endif

alt::MValueArgs MValuesToArgs(alt::MValueConst* args[], int size);

#ifdef __cplusplus
extern "C"
{
#endif
EXPORT CustomInvoker* Invoker_Create(CSharpResourceImpl* resource, MValueFunctionCallback val);
EXPORT void Invoker_Destroy(CSharpResourceImpl* resource, CustomInvoker* val);

EXPORT uint8_t MValueConst_GetBool(alt::MValueConst* mValueConst);
EXPORT int64_t MValueConst_GetInt(alt::MValueConst* mValueConst);
EXPORT uint64_t MValueConst_GetUInt(alt::MValueConst* mValueConst);
EXPORT double MValueConst_GetDouble(alt::MValueConst* mValueConst);
EXPORT uint8_t MValueConst_GetString(alt::MValueConst* mValueConst, const char*&value, uint64_t &size);
EXPORT uint64_t MValueConst_GetListSize(alt::MValueConst* mValueConst);
EXPORT uint8_t MValueConst_GetList(alt::MValueConst* mValueConst, alt::MValueConst* values[]);
EXPORT uint64_t MValueConst_GetDictSize(alt::MValueConst* mValueConst);
EXPORT uint8_t MValueConst_GetDict(alt::MValueConst* mValueConst, const char* keys[],
                         alt::MValueConst* values[]);
EXPORT void* MValueConst_GetEntity(alt::MValueConst* mValueConst, alt::IBaseObject::Type &type);
EXPORT alt::MValueConst* MValueConst_CallFunction(alt::ICore* core, alt::MValueConst* mValueConst, alt::MValueConst* val[], uint64_t size);
EXPORT void MValueConst_GetVector3(alt::MValueConst* mValueConst, position_t& position);
EXPORT void MValueConst_GetRGBA(alt::MValueConst* mValueConst, rgba_t& rgba);
EXPORT void MValueConst_GetByteArray(alt::MValueConst* mValueConst, uint64_t size, void* data);
EXPORT uint64_t MValueConst_GetByteArraySize(alt::MValueConst* mValueConst);
EXPORT void MValueConst_AddRef(alt::MValueConst* mValueConst);
EXPORT void MValueConst_RemoveRef(alt::MValueConst* mValueConst);

EXPORT void MValueConst_Delete(alt::MValueConst* mValueConst);
EXPORT uint8_t MValueConst_GetType(alt::MValueConst* mValueConst);
#ifdef __cplusplus
}
#endif
