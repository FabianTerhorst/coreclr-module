#include "server.h"

void Server_LogInfo(alt::IServer* server, const char* str) {
    server->LogInfo(str);
}

void Server_LogDebug(alt::IServer* server, const char* str) {
    server->LogDebug(str);
}

void Server_LogWarning(alt::IServer* server, const char* str) {
    server->LogWarning(str);
}

void Server_LogError(alt::IServer* server, const char* str) {
    server->LogError(str);
}

void Server_LogColored(alt::IServer* server, const char* str) {
    server->LogColored(str);
}

uint32_t Server_Hash(alt::IServer* server, const char* str) {
    return server->Hash(str);
}

void Server_SubscribeEvent(alt::IServer* server, alt::CEvent::Type ev, alt::EventCallback cb) {
    return server->SubscribeEvent(ev, cb);
}

void Server_SubscribeTick(alt::IServer* server, alt::TickCallback cb) {
    return server->SubscribeTick(cb);
}

void Server_SubscribeCommand(alt::IServer* server, const char* cmd, alt::CommandCallback cb) {
    return server->SubscribeCommand(cmd, cb);
}

void Server_TriggerServerEvent(alt::IServer* server, const char* ev, alt::MValueList &args) {
    server->TriggerServerEvent(ev, args);
}

void
Server_TriggerClientEvent(alt::IServer* server, alt::IPlayer* target, const char* ev, const alt::MValueList &args) {
    server->TriggerClientEvent(target, ev, args);
}

alt::IVehicle*
Server_CreateVehicle(alt::IServer* server, uint32_t model, alt::Position pos, alt::Rotation rot, uint16_t &id) {
    auto vehicle = server->CreateVehicle(model, pos, rot);
    if (vehicle != nullptr) {
        id = vehicle->GetID();
    }
    return vehicle;
}

alt::ICheckpoint*
Server_CreateCheckpoint(alt::IServer* server, alt::IPlayer* target, uint8_t type, alt::Position pos, float radius,
                        float height, alt::RGBA color) {
    return server->CreateCheckpoint(target, type, pos, radius, height, color);
}

alt::IBlip*
Server_CreateBlip(alt::IServer* server, alt::IPlayer* target, uint8_t type, alt::Position pos) {
    return server->CreateBlip(target, (alt::IBlip::Type) type, pos);
}

alt::IBlip*
Server_CreateBlipAttached(alt::IServer* server, alt::IPlayer* target, uint8_t type, alt::IEntity* attachTo) {
    return server->CreateBlip(target, (alt::IBlip::Type) type, attachTo);
}

void Server_GetResource(alt::IServer* server, const char* resourceName, alt::IResource*&resource) {
    resource = server->GetResource(resourceName);
}

alt::IVoiceChannel* Server_CreateVoiceChannel(alt::IServer* server, bool spatial, float maxDistance) {
    return server->CreateVoiceChannel(spatial, maxDistance);
}

alt::IColShape* Server_CreateColShapeCylinder(alt::IServer* server, alt::Position pos, float radius, float height) {
    return server->CreateColShapeCylinder(pos, radius, height);
}

alt::IColShape* Server_CreateColShapeSphere(alt::IServer* server, alt::Position pos, float radius) {
    return server->CreateColShapeSphere(pos, radius);
}

alt::IColShape* Server_CreateColShapeCircle(alt::IServer* server, alt::Position pos, float radius) {
    return server->CreateColShapeCircle(pos, radius);
}

alt::IColShape* Server_CreateColShapeCube(alt::IServer* server, alt::Position pos, alt::Position pos2) {
    return server->CreateColShapeCube(pos, pos2);
}

alt::IColShape* Server_CreateColShapeRectangle(alt::IServer* server, alt::Position pos, alt::Position pos2) {
    return server->CreateColShapeRectangle(pos, pos2);
}

void Server_DestroyBaseObject(alt::IServer* server, alt::IBaseObject* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

void Server_DestroyVehicle(alt::IServer* server, alt::IVehicle* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

void Server_DestroyBlip(alt::IServer* server, alt::IBlip* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

void Server_DestroyCheckpoint(alt::IServer* server, alt::ICheckpoint* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

void Server_DestroyVoiceChannel(alt::IServer* server, alt::IVoiceChannel* baseObject) {
    return server->DestroyBaseObject(baseObject);
}

void Server_DestroyColShape(alt::IServer* server, alt::IColShape* baseObject) {
    return server->DestroyBaseObject(baseObject);
}