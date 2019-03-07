#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif

#include <altv-cpp-api/API.h>

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
Server_CreateVehicle(alt::IServer* server, uint32_t model, alt::Position pos, float heading, uint16_t &id);
EXPORT alt::ICheckpoint*
Server_CreateCheckpoint(alt::IServer* server, alt::IPlayer* target, uint8_t type, alt::Position pos, float radius,
                        float height, alt::RGBA color);
EXPORT alt::IBlip*
Server_CreateBlip(alt::IServer* server, alt::IPlayer* target, uint8_t type, alt::Position pos);
EXPORT alt::IBlip*
Server_CreateBlipAttached(alt::IServer* server, alt::IPlayer* target, uint8_t type, alt::IEntity* attachTo);
EXPORT void Server_RemoveEntity(alt::IServer* server, alt::IEntity* entity);
EXPORT void Server_RemoveBlip(alt::IServer* server, alt::IBlip* blip);
EXPORT void Server_RemoveCheckpoint(alt::IServer* server, alt::ICheckpoint* checkpoint);
EXPORT void Server_RemoveVehicle(alt::IServer* server, alt::IVehicle* vehicle);
EXPORT void Server_GetResource(alt::IServer* server, const char* resourceName, alt::IResource*&resource);
#ifdef __cplusplus
}
#endif
