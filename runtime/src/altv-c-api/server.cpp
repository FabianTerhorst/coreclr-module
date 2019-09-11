#include <CSharpResourceImpl.h>
#include "server.h"

void Server_LogInfo(alt::ICore* server, const char* str) {
    server->LogInfo(str);
}

void Server_LogDebug(alt::ICore* server, const char* str) {
    server->LogDebug(str);
}

void Server_LogWarning(alt::ICore* server, const char* str) {
    server->LogWarning(str);
}

void Server_LogError(alt::ICore* server, const char* str) {
    server->LogError(str);
}

void Server_LogColored(alt::ICore* server, const char* str) {
    server->LogColored(str);
}

uint32_t Server_Hash(alt::ICore* server, const char* str) {
    return server->Hash(str);
}

void Server_SubscribeEvent(alt::ICore* server, alt::CEvent::Type ev, alt::EventCallback cb) {
    return server->SubscribeEvent(ev, cb);
}

void Server_SubscribeTick(alt::ICore* server, alt::TickCallback cb) {
    return server->SubscribeTick(cb);
}

bool Server_SubscribeCommand(alt::ICore* server, const char* cmd, alt::CommandCallback cb) {
    return server->SubscribeCommand(cmd, cb);
}

void Server_TriggerServerEvent(alt::ICore* server, const char* ev, alt::MValueList &args) {
    server->TriggerServerEvent(ev, args);
}

void
Server_TriggerClientEvent(alt::ICore* server, alt::IPlayer* target, const char* ev, const alt::MValueList &args) {
    server->TriggerClientEvent(target, ev, args);
}

alt::IVehicle*
Server_CreateVehicle(alt::ICore* server, uint32_t model, alt::Position pos, alt::Rotation rot, uint16_t &id) {
    auto vehicle = server->CreateVehicle(model, pos, rot);
    if (vehicle != nullptr) {
        id = vehicle->GetID();
    }
    return vehicle;
}

alt::ICheckpoint*
Server_CreateCheckpoint(alt::ICore* server, alt::IPlayer* target, uint8_t type, alt::Position pos, float radius,
                        float height, alt::RGBA color) {
    return server->CreateCheckpoint(target, type, pos, radius, height, color);
}

alt::IBlip*
Server_CreateBlip(alt::ICore* server, alt::IPlayer* target, uint8_t type, alt::Position pos) {
    return server->CreateBlip(target, (alt::IBlip::Type) type, pos);
}

alt::IBlip*
Server_CreateBlipAttached(alt::ICore* server, alt::IPlayer* target, uint8_t type, alt::IEntity* attachTo) {
    return server->CreateBlip(target, (alt::IBlip::Type) type, attachTo);
}

alt::IResource* Server_GetResource(alt::ICore* server, const char* resourceName) {
    return server->GetResource(resourceName);
}

alt::IVoiceChannel* Server_CreateVoiceChannel(alt::ICore* server, bool spatial, float maxDistance) {
    return server->CreateVoiceChannel(spatial, maxDistance);
}

alt::IColShape* Server_CreateColShapeCylinder(alt::ICore* server, alt::Position pos, float radius, float height) {
    return server->CreateColShapeCylinder(pos, radius, height);
}

alt::IColShape* Server_CreateColShapeSphere(alt::ICore* server, alt::Position pos, float radius) {
    return server->CreateColShapeSphere(pos, radius);
}

alt::IColShape* Server_CreateColShapeCircle(alt::ICore* server, alt::Position pos, float radius) {
    return server->CreateColShapeCircle(pos, radius);
}

alt::IColShape* Server_CreateColShapeCube(alt::ICore* server, alt::Position pos, alt::Position pos2) {
    return server->CreateColShapeCube(pos, pos2);
}

alt::IColShape* Server_CreateColShapeRectangle(alt::ICore* server, alt::Position pos, alt::Position pos2) {
    return server->CreateColShapeRectangle(pos, pos2);
}

void Server_DestroyBaseObject(alt::ICore* server, alt::IBaseObject* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

void Server_DestroyVehicle(alt::ICore* server, alt::IVehicle* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

void Server_DestroyBlip(alt::ICore* server, alt::IBlip* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

void Server_DestroyCheckpoint(alt::ICore* server, alt::ICheckpoint* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

void Server_DestroyVoiceChannel(alt::ICore* server, alt::IVoiceChannel* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

void Server_DestroyColShape(alt::ICore* server, alt::IColShape* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

int32_t Server_GetNetTime(alt::ICore* server) {
    return server->GetNetTime();
}

void Server_GetRootDirectory(alt::ICore* server, const char*&text) {
    text = server->GetRootDirectory().CStr();
}

void Server_GetPlayers(alt::ICore* server, alt::Array<alt::IPlayer*> &players) {
    players = server->GetPlayers();
}

void Server_GetVehicles(alt::ICore* server, alt::Array<alt::IVehicle*> &vehicles) {
    vehicles = server->GetVehicles();
}