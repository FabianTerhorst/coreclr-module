#pragma once
#include "../../../cpp-sdk/SDK.h"
#include "../types.h"

using namespace alt;

extern "C"
{
    EXPORT alt::MValueConst* Core_CreateMValueNil(alt::ICore* core);
    EXPORT alt::MValueConst* Core_CreateMValueBool(alt::ICore* core, uint8_t value);
    EXPORT alt::MValueConst* Core_CreateMValueInt(alt::ICore* core, int64_t value);
    EXPORT alt::MValueConst* Core_CreateMValueUInt(alt::ICore* core, uint64_t value);
    EXPORT alt::MValueConst* Core_CreateMValueDouble(alt::ICore* core, double value);
    EXPORT alt::MValueConst* Core_CreateMValueString(alt::ICore* core, const char* value);
    EXPORT alt::MValueConst* Core_CreateMValueList(alt::ICore* core, alt::MValueConst* val[], uint64_t size);
    EXPORT alt::MValueConst* Core_CreateMValueDict(alt::ICore* core, const char* keys[], alt::MValueConst* val[], uint64_t size);
//    EXPORT alt::MValueConst* Core_CreateMValueCheckpoint(alt::ICore* core, alt::ICheckpoint* value);
//    EXPORT alt::MValueConst* Core_CreateMValueBlip(alt::ICore* core, alt::IBlip* value);
//    EXPORT alt::MValueConst* Core_CreateMValueVoiceChannel(alt::ICore* core, alt::IVoiceChannel* value);
//    EXPORT alt::MValueConst* Core_CreateMValuePlayer(alt::ICore* core, alt::IPlayer* value);
//    EXPORT alt::MValueConst* Core_CreateMValueVehicle(alt::ICore* core, alt::IVehicle* value);
//    EXPORT alt::MValueConst* Core_CreateMValueFunction(alt::ICore* core, CustomInvoker* value);
    EXPORT alt::MValueConst* Core_CreateMValueVector3(alt::ICore* core, vector3_t value);
    EXPORT alt::MValueConst* Core_CreateMValueVector2(alt::ICore* core, vector2_t value);
    EXPORT alt::MValueConst* Core_CreateMValueRgba(alt::ICore* core, rgba_t value);
    EXPORT alt::MValueConst* Core_CreateMValueByteArray(alt::ICore* core, uint64_t size, const void* data);


    EXPORT uint8_t MValueConst_GetBool(alt::MValueConst* mValueConst);
    EXPORT int64_t MValueConst_GetInt(alt::MValueConst* mValueConst);
    EXPORT uint64_t MValueConst_GetUInt(alt::MValueConst* mValueConst);
    EXPORT double MValueConst_GetDouble(alt::MValueConst* mValueConst);
    EXPORT uint8_t MValueConst_GetString(alt::MValueConst* mValueConst, const char*& value, uint64_t& size);
    EXPORT uint64_t MValueConst_GetListSize(alt::MValueConst* mValueConst);
    EXPORT uint8_t MValueConst_GetList(alt::MValueConst* mValueConst, alt::MValueConst* values[]);
    EXPORT uint64_t MValueConst_GetDictSize(alt::MValueConst* mValueConst);
    EXPORT uint8_t MValueConst_GetDict(alt::MValueConst* mValueConst, const char* keys[], alt::MValueConst* values[]);
    EXPORT void* MValueConst_GetEntity(alt::MValueConst* mValueConst, alt::IBaseObject::Type &type);
    EXPORT alt::MValueConst* MValueConst_CallFunction(alt::ICore* core, alt::MValueConst* mValueConst, alt::MValueConst* val[], uint64_t size);
    EXPORT void MValueConst_GetVector3(alt::MValueConst* mValueConst, vector3_t& position);
    EXPORT void MValueConst_GetRGBA(alt::MValueConst* mValueConst, rgba_t& rgba);
    EXPORT void MValueConst_GetByteArray(alt::MValueConst* mValueConst, uint64_t size, void* data);
    EXPORT uint64_t MValueConst_GetByteArraySize(alt::MValueConst* mValueConst);
    EXPORT void MValueConst_AddRef(alt::MValueConst* mValueConst);
    EXPORT void MValueConst_RemoveRef(alt::MValueConst* mValueConst);

    EXPORT void MValueConst_Delete(alt::MValueConst* mValueConst);
    EXPORT uint8_t MValueConst_GetType(alt::MValueConst* mValueConst);
}