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
EXPORT void Server_LogInfo(alt::IServer* server, const char* str);
EXPORT void Server_LogDebug(alt::IServer* server, const char* str);
EXPORT void Server_LogWarning(alt::IServer* server, const char* str);
EXPORT void Server_LogError(alt::IServer* server, const char* str);
EXPORT void Server_LogColored(alt::IServer* server, const char* str);
EXPORT uint32_t Server_Hash(alt::IServer* server, const char* str);
EXPORT void Server_SubscribeEvent(alt::IServer* server, alt::CEvent::Type ev, alt::EventCallback cb);
EXPORT void Server_SubscribeTick(alt::IServer* server, alt::TickCallback cb);
EXPORT void Server_SubscribeCommand(alt::IServer* server, const char* cmd, alt::CommandCallback cb);
EXPORT void Server_TriggerServerEvent(alt::IServer* server, const char* ev, alt::MValueList &args);
EXPORT void
Server_TriggerClientEvent(alt::IServer* server, alt::IPlayer* target, const char* ev, const alt::MValueList &args);
EXPORT alt::IVehicle*
Server_CreateVehicle(alt::IServer* server, uint32_t model, alt::Position pos, alt::Rotation rot, uint16_t &id);
EXPORT alt::ICheckpoint*
Server_CreateCheckpoint(alt::IServer* server, alt::IPlayer* target, uint8_t type, alt::Position pos, float radius,
                        float height, alt::RGBA color);
EXPORT alt::IBlip*
Server_CreateBlip(alt::IServer* server, alt::IPlayer* target, uint8_t type, alt::Position pos);
EXPORT alt::IBlip*
Server_CreateBlipAttached(alt::IServer* server, alt::IPlayer* target, uint8_t type, alt::IEntity* attachTo);
EXPORT void Server_GetResource(alt::IServer* server, const char* resourceName, alt::IResource*&resource);
EXPORT alt::IVoiceChannel* Server_CreateVoiceChannel(alt::IServer* server, bool spatial, float maxDistance);
EXPORT alt::IColShape*
Server_CreateColShapeCylinder(alt::IServer* server, alt::Position pos, float radius, float height);
EXPORT alt::IColShape* Server_CreateColShapeSphere(alt::IServer* server, alt::Position pos, float radius);
EXPORT alt::IColShape* Server_CreateColShapeCircle(alt::IServer* server, alt::Position pos, float radius);
EXPORT alt::IColShape* Server_CreateColShapeCube(alt::IServer* server, alt::Position pos, alt::Position pos2);
EXPORT alt::IColShape* Server_CreateColShapeRectangle(alt::IServer* server, alt::Position pos, alt::Position pos2);
EXPORT void Server_DestroyBaseObject(alt::IServer* server, alt::IBaseObject* baseObject);
EXPORT void Server_DestroyVehicle(alt::IServer* server, alt::IVehicle* baseObject);
EXPORT void Server_DestroyBlip(alt::IServer* server, alt::IBlip* baseObject);
EXPORT void Server_DestroyCheckpoint(alt::IServer* server, alt::ICheckpoint* baseObject);
EXPORT void Server_DestroyVoiceChannel(alt::IServer* server, alt::IVoiceChannel* baseObject);
EXPORT void Server_DestroyColShape(alt::IServer* server, alt::IColShape* baseObject);
#ifdef __cplusplus
}
#endif
