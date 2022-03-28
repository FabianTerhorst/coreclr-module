#pragma once
#include "altv-cpp-api/SDK.h"

using namespace alt;

extern "C"
{
//    EXPORT String GetVersion();
//    EXPORT String GetBranch();
    EXPORT void LogInfo(const char* str);
    EXPORT void LogDebug(const char* str);
    EXPORT void LogWarning(const char* str);
    EXPORT void LogError(const char* str);
    EXPORT void LogColored(const char* str);
//    EXPORT MValueNone CreateMValueNone();
//    EXPORT MValueNil CreateMValueNil();
//    EXPORT MValueBool CreateMValueBool(bool val);
//    EXPORT MValueInt CreateMValueInt(int64_t val);
//    EXPORT MValueUInt CreateMValueUInt(uint64_t val);
//    EXPORT MValueDouble CreateMValueDouble(double val);
//    EXPORT MValueString CreateMValueString(String val);
//    EXPORT MValueList CreateMValueList(Size size = 0);
//    EXPORT MValueDict CreateMValueDict();
//    EXPORT MValueBaseObject CreateMValueBaseObject(Ref<IBaseObject> val);
//    EXPORT MValueFunction CreateMValueFunction(IMValueFunction::Impl* impl);
//    EXPORT MValueVector2 CreateMValueVector2(Vector2f val);
//    EXPORT MValueVector3 CreateMValueVector3(Vector3f val);
//    EXPORT MValueRGBA CreateMValueRGBA(RGBA val);
//    EXPORT MValueByteArray CreateMValueByteArray(const uint8_t* data, Size size);
//    EXPORT MValueByteArray CreateMValueByteArray(Size size);
//    EXPORT bool IsDebug();
//    EXPORT uint32_t Hash(StringView str);
//    EXPORT bool RegisterScriptRuntime(StringView resourceType, IScriptRuntime* runtime);
//    EXPORT void SubscribeEvent(CEvent::Type ev, EventCallback cb, void* userData = nullptr);
//    EXPORT void SubscribeTick(TickCallback cb, void* userData = nullptr);
//    EXPORT bool SubscribeCommand(StringView cmd, CommandCallback cb, void* userData = nullptr);
//    EXPORT bool FileExists(StringView path);
//    EXPORT String FileRead(StringView path);
//    EXPORT IResource* GetResource(StringView name);
//    EXPORT Ref<IEntity> GetEntityByID(uint16_t id);
//    EXPORT Array<Ref<IEntity>> GetEntities();
//    EXPORT Array<Ref<IPlayer>> GetPlayers();
//    EXPORT Array<Ref<IVehicle>> GetVehicles();
//    EXPORT Array<Ref<IBlip>> GetBlips();
//    EXPORT void TriggerLocalEvent(StringView ev, MValueArgs args);
//    EXPORT bool HasMetaData(StringView key);
//    EXPORT MValueConst GetMetaData(StringView key);
//    EXPORT void SetMetaData(StringView key, MValue val);
//    EXPORT void DeleteMetaData(StringView key);
//    EXPORT bool HasSyncedMetaData(StringView key);
//    EXPORT MValueConst GetSyncedMetaData(StringView key);
//    EXPORT const Array<Permission> GetRequiredPermissions();
//    EXPORT const Array<Permission> GetOptionalPermissions();
//    EXPORT void DestroyBaseObject(Ref<IBaseObject> handle);
}