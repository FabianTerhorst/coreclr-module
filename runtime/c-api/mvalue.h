#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "data/types.h"
#include "data/invoker.h"
#include "utils/export.h"

#ifdef ALT_SERVER_API
#include <CSharpResourceImpl.h>
#endif

#ifdef __clang__
#pragma clang diagnostic pop
#endif

void ToMValueArg(alt::MValueArgs& mValues, alt::ICore *core, alt::MValueConst *val, alt::Size i);

#ifdef __cplusplus
extern "C"
{
#endif

EXPORT_SHARED uint8_t MValueConst_GetBool(alt::MValueConst* mValueConst);
EXPORT_SHARED int64_t MValueConst_GetInt(alt::MValueConst* mValueConst);
EXPORT_SHARED uint64_t MValueConst_GetUInt(alt::MValueConst* mValueConst);
EXPORT_SHARED double MValueConst_GetDouble(alt::MValueConst* mValueConst);
EXPORT_SHARED const char* MValueConst_GetString(alt::MValueConst* mValueConst, int32_t &size);
EXPORT_SHARED uint64_t MValueConst_GetListSize(alt::MValueConst* mValueConst);
EXPORT_SHARED uint8_t MValueConst_GetList(alt::MValueConst* mValueConst, alt::MValueConst* values[]);
EXPORT_SHARED uint64_t MValueConst_GetDictSize(alt::MValueConst* mValueConst);
EXPORT_SHARED uint8_t MValueConst_GetDict(alt::MValueConst* mValueConst, const char* keys[],
                         alt::MValueConst* values[]);
EXPORT_SHARED void* MValueConst_GetEntity(alt::MValueConst* mValueConst, alt::IBaseObject::Type &type);
EXPORT_SHARED alt::MValueConst* MValueConst_CallFunction(alt::ICore* core, alt::MValueConst* mValueConst, alt::MValueConst* val[], uint64_t size);
EXPORT_SHARED void MValueConst_GetVector3(alt::MValueConst* mValueConst, position_t& position);
EXPORT_SHARED void MValueConst_GetRGBA(alt::MValueConst* mValueConst, rgba_t& rgba);
EXPORT_SHARED void MValueConst_GetByteArray(alt::MValueConst* mValueConst, uint64_t size, void* data);
EXPORT_SHARED uint64_t MValueConst_GetByteArraySize(alt::MValueConst* mValueConst);
EXPORT_SHARED void MValueConst_AddRef(alt::MValueConst* mValueConst);
EXPORT_SHARED void MValueConst_RemoveRef(alt::MValueConst* mValueConst);

EXPORT_SHARED void MValueConst_Delete(alt::MValueConst* mValueConst);
EXPORT_SHARED uint8_t MValueConst_GetType(alt::MValueConst* mValueConst);

EXPORT_SHARED CustomInvoker* Invoker_Create(CSharpResourceImpl* resource, MValueFunctionCallback val);
EXPORT_SHARED void Invoker_Destroy(CSharpResourceImpl* resource, CustomInvoker* val);

#ifdef __cplusplus
}
#endif
