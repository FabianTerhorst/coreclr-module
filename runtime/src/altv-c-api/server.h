#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>
#include <CSharpResourceImpl.h>
#include "rotation.h"
#include "position.h"
#include "vector2.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
EXPORT void Server_LogInfo(alt::ICore* server, const char* str);
EXPORT void Server_LogDebug(alt::ICore* server, const char* str);
EXPORT void Server_LogWarning(alt::ICore* server, const char* str);
EXPORT void Server_LogError(alt::ICore* server, const char* str);
EXPORT void Server_LogColored(alt::ICore* server, const char* str);
//EXPORT uint32_t Server_Hash(alt::ICore* server, const char* str);
EXPORT uint8_t Server_SubscribeCommand(alt::ICore* server, const char* cmd, alt::CommandCallback cb);
EXPORT uint8_t Server_FileExists(alt::ICore* server, const char* path);
EXPORT void Server_FileRead(alt::ICore* server, const char* path, const char*&text);
EXPORT void Server_TriggerServerEvent(alt::ICore* server, const char* ev, alt::MValueConst* args[], int size);
EXPORT void
Server_TriggerClientEvent(alt::ICore* server, alt::IPlayer* target, const char* ev, alt::MValueConst* args[], int size);
EXPORT void
Server_TriggerClientEventForAll(alt::ICore* server, const char* ev, alt::MValueConst* args[], int size);
EXPORT void
Server_TriggerClientEventForSome(alt::ICore* server, alt::IPlayer* targets[], int targetsSize, const char* ev, alt::MValueConst* args[], int argsSize);
EXPORT alt::IVehicle*
Server_CreateVehicle(alt::ICore* server, uint32_t model, position_t pos, rotation_t rot, uint16_t &id);
EXPORT alt::ICheckpoint*
Server_CreateCheckpoint(alt::ICore* server, uint8_t type, position_t pos, float radius,
                        float height, rgba_t color);
EXPORT alt::IBlip*
Server_CreateBlip(alt::ICore* server, alt::IPlayer* target, uint8_t type, position_t pos);
EXPORT alt::IBlip*
Server_CreateBlipAttachedPlayer(alt::ICore* server, alt::IPlayer* target, uint8_t type, alt::IPlayer* attachTo);
EXPORT alt::IBlip*
Server_CreateBlipAttachedVehicle(alt::ICore* server, alt::IPlayer* target, uint8_t type, alt::IVehicle* attachTo);
EXPORT alt::IResource* Server_GetResource(alt::ICore* server, const char* resourceName);
EXPORT alt::IVoiceChannel* Server_CreateVoiceChannel(alt::ICore* server, uint8_t spatial, float maxDistance);
EXPORT alt::IColShape*
Server_CreateColShapeCylinder(alt::ICore* server, position_t pos, float radius, float height);
EXPORT alt::IColShape* Server_CreateColShapeSphere(alt::ICore* server, position_t pos, float radius);
EXPORT alt::IColShape* Server_CreateColShapeCircle(alt::ICore* server, position_t pos, float radius);
EXPORT alt::IColShape* Server_CreateColShapeCube(alt::ICore* server, position_t pos, position_t pos2);
EXPORT alt::IColShape* Server_CreateColShapeRectangle(alt::ICore* server, float x1, float y1, float x2, float y2, float z);
EXPORT alt::IColShape* Server_CreateColShapePolygon(alt::ICore* server, float minZ, float maxZ, vector2_t points[], int pointSize);
//EXPORT void Server_DestroyBaseObject(alt::ICore* server, alt::IBaseObject* baseObject);
EXPORT void Server_DestroyVehicle(alt::ICore* server, alt::IVehicle* baseObject);
EXPORT void Server_DestroyBlip(alt::ICore* server, alt::IBlip* baseObject);
EXPORT void Server_DestroyCheckpoint(alt::ICore* server, alt::ICheckpoint* baseObject);
EXPORT void Server_DestroyVoiceChannel(alt::ICore* server, alt::IVoiceChannel* baseObject);
EXPORT void Server_DestroyColShape(alt::ICore* server, alt::IColShape* baseObject);
EXPORT int32_t Server_GetNetTime(alt::ICore* server);
EXPORT void Server_GetRootDirectory(alt::ICore* server, const char*&text);
EXPORT uint64_t Server_GetPlayerCount(alt::ICore* server);
EXPORT void Server_GetPlayers(alt::ICore* server, alt::IPlayer* players[], uint64_t size);
EXPORT uint64_t Server_GetVehicleCount(alt::ICore* server);
EXPORT void Server_GetVehicles(alt::ICore* server, alt::IVehicle* vehicles[], uint64_t size);
EXPORT void* Server_GetEntityById(alt::ICore* core, uint16_t id, uint8_t& type);
EXPORT void Server_StartResource(alt::ICore* server, const char* text);
EXPORT void Server_StopResource(alt::ICore* server, const char* text);
EXPORT void Server_RestartResource(alt::ICore* server, const char* text);
EXPORT void Server_GetAllResources(alt::ICore* server, alt::IResource* resources[], uint64_t size);
EXPORT uint64_t Server_GetAllResourceCount(alt::ICore* server);
EXPORT alt::MValueConst* Server_GetMetaData(alt::ICore* core, const char* key);
EXPORT void Server_SetMetaData(alt::ICore* core, const char* key, alt::MValueConst* val);
EXPORT uint8_t Server_HasMetaData(alt::ICore* core, const char* key);
EXPORT void Server_DeleteMetaData(alt::ICore* core, const char* key);
EXPORT alt::MValueConst* Server_GetSyncedMetaData(alt::ICore* core, const char* key);
EXPORT void Server_SetSyncedMetaData(alt::ICore* core, const char* key, alt::MValueConst* val);
EXPORT uint8_t Server_HasSyncedMetaData(alt::ICore* core, const char* key);
EXPORT void Server_DeleteSyncedMetaData(alt::ICore* core, const char* key);
EXPORT alt::MValueConst* Core_CreateMValueNil(alt::ICore* core);
EXPORT alt::MValueConst* Core_CreateMValueBool(alt::ICore* core, uint8_t value);
EXPORT alt::MValueConst* Core_CreateMValueInt(alt::ICore* core, int64_t value);
EXPORT alt::MValueConst* Core_CreateMValueUInt(alt::ICore* core, uint64_t value);
EXPORT alt::MValueConst* Core_CreateMValueDouble(alt::ICore* core, double value);
EXPORT alt::MValueConst* Core_CreateMValueString(alt::ICore* core, const char* value);
EXPORT alt::MValueConst* Core_CreateMValueList(alt::ICore* core, alt::MValueConst* val[], uint64_t size);
EXPORT alt::MValueConst*
Core_CreateMValueDict(alt::ICore* core, const char* keys[], alt::MValueConst* val[], uint64_t size);
//EXPORT alt::MValueBaseObject* Core_CreateMValueBaseObject(alt::ICore* core, alt::Ref<alt::IBaseObject>* value)
EXPORT alt::MValueConst* Core_CreateMValueCheckpoint(alt::ICore* core, alt::ICheckpoint* value);
EXPORT alt::MValueConst* Core_CreateMValueBlip(alt::ICore* core, alt::IBlip* value);
EXPORT alt::MValueConst* Core_CreateMValueVoiceChannel(alt::ICore* core, alt::IVoiceChannel* value);
EXPORT alt::MValueConst* Core_CreateMValuePlayer(alt::ICore* core, alt::IPlayer* value);
EXPORT alt::MValueConst* Core_CreateMValueVehicle(alt::ICore* core, alt::IVehicle* value);
EXPORT alt::MValueConst* Core_CreateMValueFunction(alt::ICore* core, CustomInvoker* value);
EXPORT alt::MValueConst* Core_CreateMValueVector3(alt::ICore* core, position_t value);
EXPORT alt::MValueConst* Core_CreateMValueVector2(alt::ICore* core, vector2_t value);
EXPORT alt::MValueConst* Core_CreateMValueRgba(alt::ICore* core, rgba_t value);
EXPORT alt::MValueConst* Core_CreateMValueByteArray(alt::ICore* core, uint64_t size, const void* data);
EXPORT uint64_t Core_HashPassword(alt::ICore* core, const char* password);
EXPORT uint8_t Core_IsDebug(alt::ICore* core);
EXPORT const char* Core_GetVersion(alt::ICore* core,int32_t &size);
EXPORT const char* Core_GetBranch(alt::ICore* core, int32_t &size);
EXPORT void Core_SetPassword(alt::ICore* core, const char* value);
EXPORT void Core_StopServer(alt::ICore* core);

#ifdef __cplusplus
}
#endif
