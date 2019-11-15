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

void Server_TriggerServerEvent(alt::ICore* server, const char* ev, alt::MValueConst* args[], int size) {
    alt::Array<alt::MValueConst> mValues = alt::Array<alt::MValueConst>(size);
    for (int i = 0; i < size; i++) {
        if (args[i] == nullptr) {
            mValues[i] = server->CreateMValueNil();
        } else {
            mValues[i] = *args[i];
        }
    }
    server->TriggerServerEvent(ev, mValues);
}

void
Server_TriggerClientEvent(alt::ICore* server, alt::IPlayer* target, const char* ev, alt::MValueConst* args[],
                          int size) {
    alt::Array<alt::MValueConst> mValues = alt::Array<alt::MValueConst>(size);
    for (int i = 0; i < size; i++) {
        if (args[i] == nullptr) {
            mValues[i] = server->CreateMValueNil();
        } else {
            mValues[i] = *args[i];
        }
    }
    server->TriggerClientEvent(target, ev, mValues);
}

alt::IVehicle*
Server_CreateVehicle(alt::ICore* server, uint32_t model, position_t pos, rotation_t rot, uint16_t &id) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    alt::Rotation rotation;
    rotation.roll = rot.roll;
    rotation.pitch = rot.pitch;
    rotation.yaw = rot.yaw;
    auto vehicle = server->CreateVehicle(model, position, rotation).Get();
    if (vehicle != nullptr) {
        id = vehicle->GetID();
    }
    return vehicle;
}

alt::ICheckpoint*
Server_CreateCheckpoint(alt::ICore* server, uint8_t type, position_t pos, float radius,
                        float height, alt::RGBA color) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    return server->CreateCheckpoint(type, position, radius, height, color).Get();
}

alt::IBlip*
Server_CreateBlip(alt::ICore* server, alt::IPlayer* target, uint8_t type, position_t pos) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    return server->CreateBlip(target, (alt::IBlip::Type) type, position).Get();
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

alt::IColShape* Server_CreateColShapeCylinder(alt::ICore* server, position_t pos, float radius, float height) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    return server->CreateColShapeCylinder(position, radius, height).Get();
}

alt::IColShape* Server_CreateColShapeSphere(alt::ICore* server, position_t pos, float radius) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    return server->CreateColShapeSphere(position, radius).Get();
}

alt::IColShape* Server_CreateColShapeCircle(alt::ICore* server, position_t pos, float radius) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    return server->CreateColShapeCircle(position, radius).Get();
}

alt::IColShape* Server_CreateColShapeCube(alt::ICore* server, position_t pos, position_t pos2) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;

    alt::Position position2;
    position2.x = pos2.x;
    position2.y = pos2.y;
    position2.z = pos2.z;
    return server->CreateColShapeCube(position, position2).Get();
}

alt::IColShape* Server_CreateColShapeRectangle(alt::ICore* server, float x1, float y1, float x2, float y2, float z) {
    return server->CreateColShapeRectangle(x1, y1, x2, y2, z).Get();
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

uint64_t Server_GetPlayerCount(alt::ICore* server) {
    return server->GetPlayers().GetSize();
}

void Server_GetPlayers(alt::ICore* server, alt::IPlayer* players[], uint64_t size) {
    auto playersArray = server->GetPlayers();
    if (playersArray.GetSize() < size) {
        size = playersArray.GetSize();
    }
    for (uint64_t i = 0; i < size; i++) {
        players[i] = playersArray[i].Get();
    }
}

uint64_t Server_GetVehicleCount(alt::ICore* server) {
    return server->GetVehicles().GetSize();
}

void Server_GetVehicles(alt::ICore* server, alt::IVehicle* vehicles[], uint64_t size) {
    auto vehiclesArray = server->GetVehicles();
    if (vehiclesArray.GetSize() < size) {
        size = vehiclesArray.GetSize();
    }
    for (uint64_t i = 0; i < size; i++) {
        vehicles[i] = vehiclesArray[i].Get();
    }
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

alt::MValueConst* Core_CreateMValueNil(alt::ICore* core) {
    auto mValue = core->CreateMValueNil();
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueBool(alt::ICore* core, bool value) {
    auto mValue = core->CreateMValueBool(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueInt(alt::ICore* core, int64_t value) {
    auto mValue = core->CreateMValueInt(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueUInt(alt::ICore* core, uint64_t value) {
    auto mValue = core->CreateMValueUInt(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueDouble(alt::ICore* core, double value) {
    auto mValue = core->CreateMValueDouble(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueString(alt::ICore* core, const char* value) {
    auto mValue = core->CreateMValueString(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueList(alt::ICore* core, alt::MValueConst* val[], uint64_t size) {
    auto mValueConst = core->CreateMValueList(size);
    auto mValue = mValueConst.Get();
    for (uint64_t i = 0; i < size; i++) {
        auto mValueElement = val[i];
        if (mValueElement == nullptr || mValueElement->Get() == nullptr) {
            mValue->Set(i, core->CreateMValueNil());
        } else {
            mValue->SetConst(i, *val[i]);
        }
    }
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueDict(alt::ICore* core, const char* keys[], alt::MValueConst* val[], uint64_t size) {
    auto mValueConst = core->CreateMValueDict();
    auto mValue = mValueConst.Get();
    for (uint64_t i = 0; i < size; i++) {
        auto mValueElement = val[i];
        if (mValueElement == nullptr || mValueElement->Get() == nullptr) {
            mValue->Set(keys[i], core->CreateMValueNil());
        } else {
            mValue->SetConst(keys[i], *val[i]);
        }
    }
    return new alt::MValueConst(mValue);
}

/*alt::MValueBaseObject* Core_CreateMValueBaseObject(alt::ICore* core, alt::Ref<alt::IBaseObject>* value) {
    auto mValue = core->CreateMValueBaseObject(*value);
    return new alt::Ref(mValue);
}*/

alt::MValueConst* Core_CreateMValueCheckpoint(alt::ICore* core, alt::ICheckpoint* value) {
    auto mValue = core->CreateMValueBaseObject(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueBlip(alt::ICore* core, alt::IBlip* value) {
    auto mValue = core->CreateMValueBaseObject(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueVoiceChannel(alt::ICore* core, alt::IVoiceChannel* value) {
    auto mValue = core->CreateMValueBaseObject(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValuePlayer(alt::ICore* core, alt::IPlayer* value) {
    auto mValue = core->CreateMValueBaseObject(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueVehicle(alt::ICore* core, alt::IVehicle* value) {
    alt::MValueConst mValue = core->CreateMValueBaseObject(value);
    return new alt::MValueConst(mValue);
}

alt::MValueConst* Core_CreateMValueFunction(alt::ICore* core, CustomInvoker* value) {
    alt::MValueConst mValue = core->CreateMValueFunction(value);
    return new alt::MValueConst(mValue);
}
