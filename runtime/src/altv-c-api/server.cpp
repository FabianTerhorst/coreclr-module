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

/*uint32_t Server_Hash(alt::ICore* server, const char* str) {
    return server->Hash(str);
}*/

void Server_SubscribeEvent(alt::ICore* server, alt::CEvent::Type ev, alt::EventCallback cb) {
    return server->SubscribeEvent(ev, cb);
}

void Server_SubscribeTick(alt::ICore* server, alt::TickCallback cb) {
    return server->SubscribeTick(cb);
}

bool Server_SubscribeCommand(alt::ICore* server, const char* cmd, alt::CommandCallback cb) {
    return server->SubscribeCommand(cmd, cb);
}

bool Server_FileExists(alt::ICore* server, const char* path) {
    return server->FileExists(path);
}

void Server_FileRead(alt::ICore* server, const char* path, const char*&text) {
    text = server->FileRead(path).CStr();
}

void Server_TriggerServerEvent(alt::ICore* server, const char* ev, alt::MValueArgs &args) {
    server->TriggerServerEvent(ev, args);
}

void
Server_TriggerClientEvent(alt::ICore* server, alt::IPlayer* target, const char* ev, const alt::MValueArgs &args) {
    server->TriggerClientEvent(target, ev, args);
}

alt::IVehicle*
Server_CreateVehicle(alt::ICore* server, uint32_t model, alt::Position pos, alt::Rotation rot, uint16_t &id) {
    auto vehicle = server->CreateVehicle(model, pos, rot).Get();
    if (vehicle != nullptr) {
        id = vehicle->GetID();
    }
    return vehicle;
}

alt::ICheckpoint*
Server_CreateCheckpoint(alt::ICore* server, alt::IPlayer* target, uint8_t type, alt::Position pos, float radius,
                        float height, alt::RGBA color) {
    return server->CreateCheckpoint(target, type, pos, radius, height, color).Get();
}

alt::IBlip*
Server_CreateBlip(alt::ICore* server, alt::IPlayer* target, uint8_t type, alt::Position pos) {
    return server->CreateBlip(target, (alt::IBlip::Type) type, pos).Get();
}

alt::IBlip*
Server_CreateBlipAttached(alt::ICore* server, alt::IPlayer* target, uint8_t type, alt::IEntity* attachTo) {
    return server->CreateBlip(target, (alt::IBlip::Type) type, attachTo).Get();
}

alt::IResource* Server_GetResource(alt::ICore* server, const char* resourceName) {
    return server->GetResource(resourceName);
}

alt::IVoiceChannel* Server_CreateVoiceChannel(alt::ICore* server, bool spatial, float maxDistance) {
    return server->CreateVoiceChannel(spatial, maxDistance).Get();
}

alt::IColShape* Server_CreateColShapeCylinder(alt::ICore* server, alt::Position pos, float radius, float height) {
    return server->CreateColShapeCylinder(pos, radius, height).Get();
}

alt::IColShape* Server_CreateColShapeSphere(alt::ICore* server, alt::Position pos, float radius) {
    return server->CreateColShapeSphere(pos, radius).Get();
}

alt::IColShape* Server_CreateColShapeCircle(alt::ICore* server, alt::Position pos, float radius) {
    return server->CreateColShapeCircle(pos, radius).Get();
}

alt::IColShape* Server_CreateColShapeCube(alt::ICore* server, alt::Position pos, alt::Position pos2) {
    return server->CreateColShapeCube(pos, pos2).Get();
}

alt::IColShape* Server_CreateColShapeRectangle(alt::ICore* server, alt::Position pos, alt::Position pos2) {
    return server->CreateColShapeRectangle(pos, pos2).Get();
}

/*void Server_DestroyBaseObject(alt::ICore* server, alt::IBaseObject* baseObject) {
    return server->DestroyBaseObject(baseObject);
}*/

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

void Server_GetPlayers(alt::ICore* server, alt::Array<alt::Ref<alt::IPlayer>> &players) {
    players = server->GetPlayers();
}

void Server_GetVehicles(alt::ICore* server, alt::Array<alt::Ref<alt::IVehicle>> &vehicles) {
    vehicles = server->GetVehicles();
}

void Server_StartResource(alt::ICore* server, const char* text) {
    server->StartResource(text);
}

void Server_StopResource(alt::ICore* server, const char* text) {
    server->StopResource(text);
}

void Server_RestartResource(alt::ICore* server, const char* text) {
    server->RestartResource(text);
}

alt::MValue* Core_CreateMValueNil(alt::ICore* core) {
    auto mValue = (alt::IMValue*) core->CreateMValueNil().Get();
    return new alt::Ref(mValue);
}

alt::MValue* Core_CreateMValueBool(alt::ICore* core, bool value) {
    auto mValue = (alt::IMValue*) core->CreateMValueBool(value).Get();
    return new alt::Ref(mValue);
}

alt::MValue* Core_CreateMValueInt(alt::ICore* core, int64_t value) {
    auto mValue = (alt::IMValue*) core->CreateMValueInt(value).Get();
    return new alt::Ref(mValue);
}

alt::MValue* Core_CreateMValueUInt(alt::ICore* core, uint64_t value) {
    auto mValue = (alt::IMValue*) core->CreateMValueUInt(value).Get();
    return new alt::Ref(mValue);
}

alt::MValue* Core_CreateMValueDouble(alt::ICore* core, double value) {
    auto mValue = (alt::IMValue*) core->CreateMValueDouble(value).Get();
    return new alt::Ref(mValue);
}

alt::MValue* Core_CreateMValueString(alt::ICore* core, const char* value) {
    auto mValue = (alt::IMValue*) core->CreateMValueString(value).Get();
    return new alt::Ref(mValue);
}

alt::MValue* Core_CreateMValueList(alt::ICore* core, alt::MValue val[], uint64_t size) {
    auto mValue = core->CreateMValueList(size).Get();
    for (uint64_t i = 0; i < size; i++) {
        mValue->Set(i, val[i]);
    }
    return new alt::Ref((alt::IMValue*) mValue);
}

alt::MValue* Core_CreateMValueDict(alt::ICore* core, const char** keys, alt::MValue val[], uint64_t size) {
    auto mValue = core->CreateMValueDict().Get();
    for (uint64_t i = 0; i < size; i++) {
        mValue->Set(keys[i], val[i]);
    }
    return new alt::Ref((alt::IMValue*) mValue);
}

/*alt::MValueBaseObject* Core_CreateMValueBaseObject(alt::ICore* core, alt::Ref<alt::IBaseObject>* value) {
    auto mValue = core->CreateMValueBaseObject(*value);
    return new alt::Ref(mValue);
}*/

alt::MValue* Core_CreateMValueCheckpoint(alt::ICore* core, alt::ICheckpoint* value) {
    auto mValue = core->CreateMValueBaseObject(value).Get();
    return new alt::Ref((alt::IMValue*) mValue);
}

alt::MValue* Core_CreateMValueBlip(alt::ICore* core, alt::IBlip* value) {
    auto mValue = core->CreateMValueBaseObject(value).Get();
    return new alt::Ref((alt::IMValue*) mValue);
}

alt::MValue* Core_CreateMValueVoiceChannel(alt::ICore* core, alt::IVoiceChannel* value) {
    auto mValue = core->CreateMValueBaseObject(value).Get();
    return new alt::Ref((alt::IMValue*) mValue);
}

alt::MValue* Core_CreateMValuePlayer(alt::ICore* core, alt::IPlayer* value) {
    auto mValue = core->CreateMValueBaseObject(value).Get();
    return new alt::Ref((alt::IMValue*) mValue);
}

alt::MValue* Core_CreateMValueVehicle(alt::ICore* core, alt::IVehicle* value) {
    auto mValue = core->CreateMValueBaseObject(value).Get();
    return new alt::Ref((alt::IMValue*) mValue);
}

alt::MValue* Core_CreateMValueFunction(alt::ICore* core, alt::IMValueFunction::Impl* value) {
    auto mValue = core->CreateMValueFunction(value).Get();
    return new alt::Ref((alt::IMValue*) mValue);
}
