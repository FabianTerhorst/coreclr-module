#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "data/types.h"
#include "data/vehicle_model_info.h"
#include "utils/export.h"

#ifdef ALT_SERVER_API
#include <CSharpResourceImpl.h>
#elif ALT_CLIENT_API
#include "../client/src/runtime/CSharpResourceImpl.h"
#include "mvalue.h"
#include "data/discord_user.h"

#endif


#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif

EXPORT_SHARED void Core_LogInfo(alt::ICore* server, const char* str);
EXPORT_SHARED void Core_LogDebug(alt::ICore* server, const char* str);
EXPORT_SHARED void Core_LogWarning(alt::ICore* server, const char* str);
EXPORT_SHARED void Core_LogError(alt::ICore* server, const char* str);
EXPORT_SHARED void Core_LogColored(alt::ICore* server, const char* str);

EXPORT_SHARED alt::MValueConst* Core_CreateMValueNil(alt::ICore* core);
EXPORT_SHARED alt::MValueConst* Core_CreateMValueBool(alt::ICore* core, uint8_t value);
EXPORT_SHARED alt::MValueConst* Core_CreateMValueInt(alt::ICore* core, int64_t value);
EXPORT_SHARED alt::MValueConst* Core_CreateMValueUInt(alt::ICore* core, uint64_t value);
EXPORT_SHARED alt::MValueConst* Core_CreateMValueDouble(alt::ICore* core, double value);
EXPORT_SHARED alt::MValueConst* Core_CreateMValueString(alt::ICore* core, const char* value);
EXPORT_SHARED alt::MValueConst* Core_CreateMValueList(alt::ICore* core, alt::MValueConst* val[], uint64_t size);
EXPORT_SHARED alt::MValueConst* Core_CreateMValueDict(alt::ICore* core, const char* keys[], alt::MValueConst* val[], uint64_t size);
EXPORT_SHARED alt::MValueConst* Core_CreateMValueBaseObject(alt::ICore* core, alt::IBaseObject* value);
EXPORT_SHARED alt::MValueConst* Core_CreateMValueVector3(alt::ICore* core, position_t value);
EXPORT_SHARED alt::MValueConst* Core_CreateMValueVector2(alt::ICore* core, vector2_t value);
EXPORT_SHARED alt::MValueConst* Core_CreateMValueRgba(alt::ICore* core, rgba_t value);
EXPORT_SHARED alt::MValueConst* Core_CreateMValueByteArray(alt::ICore* core, uint64_t size, const void* data);
EXPORT_SHARED alt::MValueConst* Core_CreateMValueFunction(alt::ICore* core, CustomInvoker* value);

EXPORT_SHARED uint64_t Core_GetPlayerCount(alt::ICore* server);
EXPORT_SHARED void Core_GetPlayers(alt::ICore* server, alt::IPlayer* players[], uint64_t size);
EXPORT_SHARED uint64_t Core_GetVehicleCount(alt::ICore* server);
EXPORT_SHARED void Core_GetVehicles(alt::ICore* server, alt::IVehicle* vehicles[], uint64_t size);
EXPORT_SHARED void* Core_GetEntityById(alt::ICore* core, uint16_t id, uint8_t& type);

EXPORT_SHARED uint8_t Core_IsDebug(alt::ICore* core);
EXPORT_SHARED const char* Core_GetVersion(alt::ICore* core,int32_t &size);
EXPORT_SHARED const char* Core_GetBranch(alt::ICore* core, int32_t &size);

EXPORT_SHARED void Core_DestroyBaseObject(alt::ICore* server, alt::IBaseObject* baseObject);
EXPORT_SHARED alt::MValueConst* Core_GetMetaData(alt::ICore* core, const char* key);
EXPORT_SHARED void Core_SetMetaData(alt::ICore* core, const char* key, alt::MValueConst* val);
EXPORT_SHARED uint8_t Core_HasMetaData(alt::ICore* core, const char* key);
EXPORT_SHARED void Core_DeleteMetaData(alt::ICore* core, const char* key);
EXPORT_SHARED alt::MValueConst* Core_GetSyncedMetaData(alt::ICore* core, const char* key);
EXPORT_SHARED uint8_t Core_HasSyncedMetaData(alt::ICore* core, const char* key);

EXPORT_SERVER uint8_t Core_SubscribeCommand(alt::ICore* server, const char* cmd, alt::CommandCallback cb);
EXPORT_SERVER uint8_t Core_FileExists(alt::ICore* server, const char* path);
EXPORT_SERVER void Core_FileRead(alt::ICore* server, const char* path, const char*&text);
EXPORT_SERVER void Core_TriggerServerEvent(alt::ICore* server, const char* ev, alt::MValueConst* args[], int size);
EXPORT_SERVER void Core_TriggerClientEvent(alt::ICore* server, alt::IPlayer* target, const char* ev, alt::MValueConst* args[], int size);
EXPORT_SERVER void Core_TriggerClientEventForAll(alt::ICore* server, const char* ev, alt::MValueConst* args[], int size);
EXPORT_SERVER void Core_TriggerClientEventForSome(alt::ICore* server, alt::IPlayer* targets[], int targetsSize, const char* ev, alt::MValueConst* args[], int argsSize);
EXPORT_SERVER alt::IVehicle* Core_CreateVehicle(alt::ICore* server, uint32_t model, position_t pos, rotation_t rot, uint16_t &id);
EXPORT_SERVER alt::ICheckpoint* Core_CreateCheckpoint(alt::ICore* server, uint8_t type, position_t pos, float radius, float height, rgba_t color);
EXPORT_SERVER alt::IBlip* Core_CreateBlip(alt::ICore* server, alt::IPlayer* target, uint8_t type, position_t pos);
EXPORT_SERVER alt::IBlip* Core_CreateBlipAttached(alt::ICore* server, alt::IPlayer* target, uint8_t type, alt::IEntity* attachTo);
EXPORT_SERVER alt::IResource* Core_GetResource(alt::ICore* server, const char* resourceName);
EXPORT_SERVER ClrVehicleModelInfo* Core_GetVehicleModelInfo(alt::ICore* server, uint32_t hash);
EXPORT_SERVER void Core_DeallocVehicleModelInfo(ClrVehicleModelInfo* modelInfo);
EXPORT_SERVER alt::IVoiceChannel* Core_CreateVoiceChannel(alt::ICore* server, uint8_t spatial, float maxDistance);
EXPORT_SERVER alt::IColShape* Core_CreateColShapeCylinder(alt::ICore* server, position_t pos, float radius, float height);
EXPORT_SERVER alt::IColShape* Core_CreateColShapeSphere(alt::ICore* server, position_t pos, float radius);
EXPORT_SERVER alt::IColShape* Core_CreateColShapeCircle(alt::ICore* server, position_t pos, float radius);
EXPORT_SERVER alt::IColShape* Core_CreateColShapeCube(alt::ICore* server, position_t pos, position_t pos2);
EXPORT_SERVER alt::IColShape* Core_CreateColShapeRectangle(alt::ICore* server, float x1, float y1, float x2, float y2, float z);
EXPORT_SERVER alt::IColShape* Core_CreateColShapePolygon(alt::ICore* server, float minZ, float maxZ, vector2_t points[], int pointSize);
EXPORT_SERVER void Core_DestroyVehicle(alt::ICore* server, alt::IVehicle* baseObject);
EXPORT_SERVER void Core_DestroyCheckpoint(alt::ICore* server, alt::ICheckpoint* baseObject);
EXPORT_SERVER void Core_DestroyVoiceChannel(alt::ICore* server, alt::IVoiceChannel* baseObject);
EXPORT_SERVER void Core_DestroyColShape(alt::ICore* server, alt::IColShape* baseObject);
EXPORT_SERVER int32_t Core_GetNetTime(alt::ICore* server);
EXPORT_SERVER void Core_GetRootDirectory(alt::ICore* server, const char*&text);
EXPORT_SERVER void Core_StartResource(alt::ICore* server, const char* text);
EXPORT_SERVER void Core_StopResource(alt::ICore* server, const char* text);
EXPORT_SERVER void Core_RestartResource(alt::ICore* server, const char* text);
EXPORT_SERVER void Core_SetSyncedMetaData(alt::ICore* core, const char* key, alt::MValueConst* val);
EXPORT_SERVER void Core_DeleteSyncedMetaData(alt::ICore* core, const char* key);
EXPORT_SERVER uint64_t Core_HashPassword(alt::ICore* core, const char* password);
EXPORT_SERVER void Core_SetPassword(alt::ICore* core, const char* value);
EXPORT_SERVER void Core_StopServer(alt::ICore* core);

EXPORT_CLIENT alt::IBlip* Core_Client_CreatePointBlip(alt::ICore* core, vector3_t position);
EXPORT_CLIENT alt::IBlip* Core_Client_CreateRadiusBlip(alt::ICore* core, vector3_t position, float radius);
EXPORT_CLIENT alt::IBlip* Core_Client_CreateAreaBlip(alt::ICore* core, vector3_t position, float width, float height);
EXPORT_CLIENT alt::IWebView* Core_CreateWebView(alt::ICore* core, alt::IResource* resource, const char* url, vector2_t pos, vector2_t size, uint8_t isOverlay);
EXPORT_CLIENT alt::IWebView* Core_CreateWebView3D(alt::ICore* core, alt::IResource* resource, const char* url, uint32_t hash, const char* targetTexture);
EXPORT_CLIENT void Core_TriggerWebViewEvent(alt::ICore* core, alt::IWebView* webview, const char* event, alt::MValueConst* args[], int size);
EXPORT_CLIENT void Core_TriggerServerEvent(alt::ICore* core, const char* event, alt::MValueConst* args[], int size);

EXPORT_CLIENT void Core_ShowCursor(alt::ICore* core, alt::IResource* resource, bool state);

EXPORT_CLIENT ClrDiscordUser* Core_GetDiscordUser(alt::ICore* core);
EXPORT_CLIENT void Core_DeallocDiscordUser(ClrDiscordUser* user);

#ifdef __cplusplus
}
#endif
