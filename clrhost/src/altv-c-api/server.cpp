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
    /*auto list = args.Get<alt::MValue::List>();
    auto dict = list[list.GetSize() - 1].Get<alt::MValue::Dict>();
    for (auto &it : dict) {
        server->LogInfo(it.first);
        server->LogInfo(it.second.ToString());
    }*/
    server->TriggerServerEvent(ev, args);
}

void
Server_TriggerClientEvent(alt::IServer* server, alt::IPlayer* target, const char* ev, const alt::MValueList &args) {
    server->TriggerClientEvent(target, ev, args);
}

alt::IVehicle*
Server_CreateVehicle(alt::IServer* server, uint32_t model, alt::Position pos, float heading, uint16_t &id) {
    auto vehicle = server->CreateVehicle(model, pos, heading);
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

void Server_RemoveEntity(alt::IServer* server, alt::IEntity* entity) {
    return server->RemoveEntity(entity);
}

void Server_RemoveBlip(alt::IServer* server, alt::IBlip* blip) {
    server->RemoveBlip(blip);
}

void Server_RemoveCheckpoint(alt::IServer* server, alt::ICheckpoint* checkpoint) {
    server->RemoveCheckpoint(checkpoint);
}

void Server_RemoveVehicle(alt::IServer* server, alt::IVehicle* vehicle) {
    server->RemoveEntity(vehicle);
}

void Server_GetResource(alt::IServer* server, const char* resourceName, alt::IResource*&resource) {
    resource = server->GetResource(resourceName);
}