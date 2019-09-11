#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>

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
EXPORT uint32_t Server_Hash(alt::ICore* server, const char* str);
EXPORT void Server_SubscribeEvent(alt::ICore* server, alt::CEvent::Type ev, alt::EventCallback cb);
EXPORT void Server_SubscribeTick(alt::ICore* server, alt::TickCallback cb);
EXPORT bool Server_SubscribeCommand(alt::ICore* server, const char* cmd, alt::CommandCallback cb);
EXPORT void Server_TriggerServerEvent(alt::ICore* server, const char* ev, alt::MValueList &args);
EXPORT void
Server_TriggerClientEvent(alt::ICore* server, alt::IPlayer* target, const char* ev, const alt::MValueList &args);
EXPORT alt::IVehicle*
Server_CreateVehicle(alt::ICore* server, uint32_t model, alt::Position pos, alt::Rotation rot, uint16_t &id);
EXPORT alt::ICheckpoint*
Server_CreateCheckpoint(alt::ICore* server, alt::IPlayer* target, uint8_t type, alt::Position pos, float radius,
                        float height, alt::RGBA color);
EXPORT alt::IBlip*
Server_CreateBlip(alt::ICore* server, alt::IPlayer* target, uint8_t type, alt::Position pos);
EXPORT alt::IBlip*
Server_CreateBlipAttached(alt::ICore* server, alt::IPlayer* target, uint8_t type, alt::IEntity* attachTo);
EXPORT alt::IResource* Server_GetResource(alt::ICore* server, const char* resourceName);
EXPORT alt::IVoiceChannel* Server_CreateVoiceChannel(alt::ICore* server, bool spatial, float maxDistance);
EXPORT alt::IColShape*
Server_CreateColShapeCylinder(alt::ICore* server, alt::Position pos, float radius, float height);
EXPORT alt::IColShape* Server_CreateColShapeSphere(alt::ICore* server, alt::Position pos, float radius);
EXPORT alt::IColShape* Server_CreateColShapeCircle(alt::ICore* server, alt::Position pos, float radius);
EXPORT alt::IColShape* Server_CreateColShapeCube(alt::ICore* server, alt::Position pos, alt::Position pos2);
EXPORT alt::IColShape* Server_CreateColShapeRectangle(alt::ICore* server, alt::Position pos, alt::Position pos2);
EXPORT void Server_DestroyBaseObject(alt::ICore* server, alt::IBaseObject* baseObject);
EXPORT void Server_DestroyVehicle(alt::ICore* server, alt::IVehicle* baseObject);
EXPORT void Server_DestroyBlip(alt::ICore* server, alt::IBlip* baseObject);
EXPORT void Server_DestroyCheckpoint(alt::ICore* server, alt::ICheckpoint* baseObject);
EXPORT void Server_DestroyVoiceChannel(alt::ICore* server, alt::IVoiceChannel* baseObject);
EXPORT void Server_DestroyColShape(alt::ICore* server, alt::IColShape* baseObject);
EXPORT int32_t Server_GetNetTime(alt::ICore* server);
EXPORT void Server_GetRootDirectory(alt::ICore* server, const char*&text);
EXPORT void Server_GetPlayers(alt::ICore* server, alt::Array<alt::IPlayer*> &players);
EXPORT void Server_GetVehicles(alt::ICore* server, alt::Array<alt::IVehicle*> &vehicles);
#ifdef __cplusplus
}
#endif
